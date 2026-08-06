using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.PowerShell.Installer
{
    /// <summary>
    /// Result of installing a single module from the archive. <see cref="ModuleBase"/> is the
    /// absolute path to the version-stamped folder PowerShell loads from
    /// (<c>&lt;TargetPath&gt;/&lt;Name&gt;/&lt;Version&gt;</c>). <see cref="Warning"/> is non-null
    /// only when the install completed but a non-fatal issue occurred (e.g. the optional
    /// <c>PSGetModuleInfo.xml</c> write failed). The PowerShell caller surfaces it via
    /// <c>Write-Warning</c>.
    /// </summary>
    public sealed class InstalledModule
    {
        public string Name { get; }
        public string Version { get; }
        public string FullVersionString { get; }
        public string ModuleBase { get; }
        public string? Warning { get; }

        public InstalledModule(string name, string version, string fullVersionString, string moduleBase, string? warning = null)
        {
            Name = name;
            Version = version;
            FullVersionString = fullVersionString;
            ModuleBase = moduleBase;
            Warning = warning;
        }
    }

    /// <summary>
    /// Thrown by <see cref="ModuleInstaller"/> when a caller-requested module is not present
    /// in the archive being extracted. Carries the typed list of missing module names so
    /// callers can surface them without re-parsing the exception message.
    /// </summary>
    public sealed class MissingModulesException : Exception
    {
        public IReadOnlyList<string> MissingModules { get; }

        public MissingModulesException(IReadOnlyList<string> missingModules)
            : base("Required modules not found in archive: " + string.Join(", ", missingModules ?? Array.Empty<string>()))
        {
            MissingModules = missingModules ?? Array.Empty<string>();
        }
    }

    /// <summary>
    /// High-throughput helpers backing <c>Install-AWSToolsModule</c> and
    /// <c>Uninstall-AWSToolsModule</c>.
    /// </summary>
    public static class ModuleInstaller
    {
        // 1 MiB; baseline buffer size. Buffer is allocated once per worker (not per module)
        // via the Parallel.ForEach<TSource,TLocal> overload below.
        private const int CopyBufferSize = 1024 * 1024;

        private static readonly bool IsWindows =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        // Win32 sharing-violation code surfaced on IOException.HResult when a file is locked by
        // another handle, e.g. the loaded AWS.Tools.Installer.dll during a self-update.
        private const int HResultSharingViolation = unchecked((int)0x80070020);

        // Suffix for a locked file moved aside so its replacement can take the original path. A
        // loaded assembly cannot be deleted or truncated but can be renamed on the same volume.
        // SweepLockedRenames deletes these once the lock is gone (a later install or a restart).
        public const string LockedRenameSuffix = ".awstoolsdelete";

        /// <summary>
        /// Deletes each directory in <paramref name="paths"/> in parallel, then sweeps any
        /// parent directories that became empty as a result. Returns the paths that could
        /// not be deleted (file in use, ACL denied). Never throws on per-path failures —
        /// callers inspect the returned array to decide what to surface to the user.
        /// </summary>
        /// <param name="paths">Absolute directory paths to delete recursively.</param>
        /// <param name="ct">Cancellation token. Pass <c>$PSCmdlet.StoppingToken</c> from PowerShell
        /// to make the delete interruptible by Ctrl+C.</param>
        /// <returns>Paths that failed to delete. Empty array on full success.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="paths"/> is null.</exception>
        public static string[] DeleteDirectoriesParallel(string[] paths, CancellationToken ct = default)
        {
            if (paths is null) throw new ArgumentNullException(nameof(paths));
            if (paths.Length == 0) return Array.Empty<string>();

            var failed = new ConcurrentBag<string>();
            Parallel.ForEach(
                paths,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount,
                    CancellationToken = ct,
                },
                path =>
                {
                    try
                    {
                        if (Directory.Exists(path))
                            Directory.Delete(path, recursive: true);
                    }
                    catch (IOException) { failed.Add(path); }
                    catch (UnauthorizedAccessException) { failed.Add(path); }
                });

            // Best-effort: remove parent dirs that are now empty.
            var parents = new HashSet<string>(StringComparer.Ordinal);
            foreach (var p in paths)
            {
                var par = Path.GetDirectoryName(p);
                if (!string.IsNullOrEmpty(par)) parents.Add(par!);
            }
            foreach (var par in parents)
            {
                try
                {
                    if (Directory.Exists(par) && Directory.GetFileSystemEntries(par).Length == 0)
                        Directory.Delete(par);
                }
                catch (IOException) { /* best-effort */ }
                catch (UnauthorizedAccessException) { /* best-effort */ }
            }

            return failed.ToArray();
        }

        /// <summary>
        /// Per-worker locals threaded through <c>Parallel.ForEach</c>: a copy buffer
        /// and a <c>ZipArchive</c> handle. Both are reused across every module a
        /// worker processes - the buffer to avoid LOH churn, the ZipArchive to skip
        /// re-reading the zip's central directory once per module.
        /// </summary>
        private sealed class WorkerLocal : IDisposable
        {
            public byte[] Buffer { get; }
            public ZipArchive Archive { get; }

            public WorkerLocal(string zipPath, int bufferSize)
            {
                Buffer = new byte[bufferSize];
                Archive = ZipFile.OpenRead(zipPath);
            }

            public void Dispose() => Archive.Dispose();
        }

        /// <summary>
        /// Extracts the modules requested from <paramref name="zipPath"/> into
        /// <paramref name="targetPath"/> and writes a <c>PSGetModuleInfo.xml</c>
        /// next to each extracted module's manifest. Returns one
        /// <see cref="InstalledModule"/> per (module, version) pair extracted.
        /// </summary>
        /// <param name="zipPath">Path to the AWS.Tools zip on disk.</param>
        /// <param name="targetPath">Module-root directory that will receive
        /// <c>&lt;Name&gt;/&lt;Version&gt;/...</c> trees.</param>
        /// <param name="moduleNames">Modules the caller asked for. <c>null</c> or empty means extract all.</param>
        /// <param name="mandatoryModules">Modules to add to <paramref name="moduleNames"/>
        /// (e.g. <c>AWS.Tools.Common</c>). Ignored if <paramref name="moduleNames"/> is null/empty.</param>
        /// <param name="ct">Cancellation token. Pass <c>$PSCmdlet.StoppingToken</c> from PowerShell
        /// to make the install interruptible by Ctrl+C.</param>
        /// <param name="handleLockedFiles">When true, a destination locked by the running process
        /// (the loaded AWS.Tools.Installer.dll during a self-update) is skipped if its content
        /// already matches, or replaced via rename if it differs. Only Install-AWSToolsInstaller
        /// passes true; module installs leave this false and keep the original write behavior.</param>
        /// <returns>One <see cref="InstalledModule"/> per (module, version) pair extracted.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="zipPath"/> or <paramref name="targetPath"/> is null.</exception>
        /// <exception cref="FileNotFoundException">No file at <paramref name="zipPath"/>.</exception>
        /// <exception cref="MissingModulesException">A name in <paramref name="moduleNames"/> or <paramref name="mandatoryModules"/> is not present in the archive.</exception>
        /// <exception cref="OperationCanceledException"><paramref name="ct"/> was cancelled before or during the extract.</exception>
        public static InstalledModule[] ExtractAndInstall(
            string zipPath, string targetPath,
            string[]? moduleNames, string[]? mandatoryModules,
            CancellationToken ct = default,
            bool handleLockedFiles = false)
        {
            if (zipPath is null) throw new ArgumentNullException(nameof(zipPath));
            if (targetPath is null) throw new ArgumentNullException(nameof(targetPath));
            if (!File.Exists(zipPath)) throw new FileNotFoundException("Zip file not found.", zipPath);

            Directory.CreateDirectory(targetPath);

            // Remove marker files left when a prior self-update replaced a locked DLL. Installer
            // only; module installs never set the flag, so their behavior is unchanged.
            if (handleLockedFiles)
                SweepLockedRenames(targetPath);

            var entriesByModule = IndexEntriesByModule(zipPath);
            entriesByModule = FilterRequested(entriesByModule, moduleNames, mandatoryModules);

            var results = new ConcurrentBag<InstalledModule>();
            // Testing on EC2 (Windows, Defender ON) showed Windows <=2 cores ran
            // fastest at 4x ProcessorCount; 4+ cores regressed under the same
            // setting and ran fastest at ProcessorCount. Linux uses ProcessorCount.
            var maxConcurrency = Math.Max(1,
                (IsWindows && Environment.ProcessorCount <= 2)
                    ? Environment.ProcessorCount * 4
                    : Environment.ProcessorCount);

            Parallel.ForEach(
                entriesByModule,
                new ParallelOptions
                {
                    MaxDegreeOfParallelism = maxConcurrency,
                    CancellationToken = ct,
                },
                localInit: () => new WorkerLocal(zipPath, CopyBufferSize),
                body: (kv, _, local) =>
                {
                    foreach (var item in ExtractModule(local, kv.Key, kv.Value, targetPath, handleLockedFiles))
                        results.Add(item);
                    return local;
                },
                localFinally: local => local.Dispose());

            return results.ToArray();
        }

        private static Dictionary<string, List<string>> IndexEntriesByModule(string zipPath)
        {
            var byModule = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            using var zip = ZipFile.OpenRead(zipPath);
            foreach (var entry in zip.Entries)
            {
                if (string.IsNullOrEmpty(entry.Name)) continue;
                // Normalize separators for parsing. Zip spec mandates '/' but Windows
                // PowerShell 5.1's Compress-Archive emits '\'. After this line the rest
                // of the function can assume forward slashes. Replace returns the same
                // string instance when no occurrences are found, so '/'-only zips pay
                // no allocation here.
                var fullName = entry.FullName.Replace('\\', '/');
                var slash = fullName.IndexOf('/');
                if (slash < 0) continue;
                var moduleName = fullName.Substring(0, slash);
                if (!byModule.TryGetValue(moduleName, out var list))
                {
                    list = new List<string>();
                    byModule[moduleName] = list;
                }
                // Store the ORIGINAL entry name; ZipArchive.GetEntry() in ExtractModule
                // looks up by the archive's recorded name, not the normalized form.
                list.Add(entry.FullName);
            }
            return byModule;
        }

        /// <summary>
        /// When the caller specifies modules, build a small filtered dictionary by lookup
        /// (O(|requested|)) instead of walking all entries. Throws
        /// <see cref="MissingModulesException"/> only when a mandatory module is absent.
        /// Non-mandatory modules that are missing from the archive are silently skipped;
        /// the caller detects them by comparing requested vs. returned module lists.
        /// </summary>
        private static Dictionary<string, List<string>> FilterRequested(
            Dictionary<string, List<string>> entriesByModule,
            string[]? moduleNames,
            string[]? mandatoryModules)
        {
            if (moduleNames is null || moduleNames.Length == 0) return entriesByModule;

            var requested = new HashSet<string>(moduleNames, StringComparer.OrdinalIgnoreCase);
            if (mandatoryModules != null)
                foreach (var m in mandatoryModules) requested.Add(m);
            // "AWS.Tools" (no suffix) is the rollup entry the archive uses to carry the
            // representative version. Always include it when present so the PowerShell
            // caller can derive the install's version string from a stable source.
            if (entriesByModule.ContainsKey("AWS.Tools")) requested.Add("AWS.Tools");

            var mandatorySet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            if (mandatoryModules != null)
                foreach (var m in mandatoryModules) mandatorySet.Add(m);

            var missingMandatory = new List<string>();
            var filtered = new Dictionary<string, List<string>>(requested.Count, StringComparer.OrdinalIgnoreCase);
            foreach (var name in requested)
            {
                if (entriesByModule.TryGetValue(name, out var list))
                    filtered[name] = list;
                else if (mandatorySet.Contains(name))
                    missingMandatory.Add(name);
            }
            if (missingMandatory.Count > 0) throw new MissingModulesException(missingMandatory);
            return filtered;
        }

        /// <summary>
        /// Cheap zip-slip check: reject entries whose relative path is rooted (e.g. "/etc/...")
        /// or escapes the target via "..". O(n) string scan instead of <c>Path.GetFullPath</c>'s
        /// per-call canonicalization syscall. Accepts both separators because Windows
        /// PowerShell 5.1's Compress-Archive emits backslashes (the zip spec mandates '/' but
        /// 5.1 ignores that), and we want zips built on either edition to install cleanly.
        /// </summary>
        private static bool IsUnsafeRelativePath(string entryFullName)
        {
            if (string.IsNullOrEmpty(entryFullName)) return true;
            // Rooted: starts with '/' or '\' or contains a drive-letter prefix.
            char c0 = entryFullName[0];
            if (c0 == '/' || c0 == '\\') return true;
            if (entryFullName.Length >= 2 && entryFullName[1] == ':') return true;
            // ".." segment, bounded on both sides by separators or string boundary.
            int idx = 0;
            while (idx < entryFullName.Length)
            {
                int next = entryFullName.IndexOf("..", idx, StringComparison.Ordinal);
                if (next < 0) return false;
                bool leftOk = next == 0 || entryFullName[next - 1] == '/' || entryFullName[next - 1] == '\\';
                int after = next + 2;
                bool rightOk = after >= entryFullName.Length
                    || entryFullName[after] == '/' || entryFullName[after] == '\\';
                if (leftOk && rightOk) return true;
                idx = next + 1;
            }
            return false;
        }

        /// <summary>
        /// Extracts every entry under <paramref name="moduleName"/> in the archive to
        /// <paramref name="targetPath"/> and returns one <see cref="InstalledModule"/>
        /// per version directory found (a single module name can carry multiple versions
        /// in the same archive).
        /// </summary>
        private static List<InstalledModule> ExtractModule(
            WorkerLocal local, string moduleName, IReadOnlyList<string> entryNames,
            string targetPath, bool handleLockedFiles)
        {
            var buffer = local.Buffer;
            var zip = local.Archive;
            // Canonical target root; every resolved destination below must start with this.
            var fullDestDir = Path.GetFullPath(targetPath + Path.DirectorySeparatorChar);
            // CreateDirectory is idempotent and cheap; cache the last directory we created so
            // that all entries under the same dir don't re-issue the syscall per file.
            string? lastDir = null;
            // Track which version subdirectories this call actually wrote to, so the post-process
            // step only touches just-extracted versions and leaves any pre-existing siblings alone.
            var extractedVersions = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var entryName in entryNames)
            {
                var entry = zip.GetEntry(entryName);
                if (entry is null) continue;

                if (IsUnsafeRelativePath(entry.FullName))
                    throw new InvalidDataException(
                        $"Zip entry '{entry.FullName}' has an unsafe relative path.");

                // Normalize to forward slashes for parsing and for the path build below.
                // After this line the rest of the loop can assume '/' separators.
                var fullName = entry.FullName.Replace('\\', '/');

                // Entry path shape is <moduleName>/<version>/... - capture <version> the first
                // time we see it. The first '/' is at moduleName.Length; the second bounds the version.
                if (fullName.Length > moduleName.Length + 1)
                {
                    int versionStart = moduleName.Length + 1;
                    int versionEnd = fullName.IndexOf('/', versionStart);
                    if (versionEnd > versionStart)
                        extractedVersions.Add(fullName.Substring(versionStart, versionEnd - versionStart));
                }

                // Convert to the host's separator for filesystem paths.
                var rel = IsWindows ? fullName.Replace('/', '\\') : fullName;
                var destPath = Path.GetFullPath(Path.Combine(targetPath, rel));
                // Reject any entry that resolves outside the target root.
                if (!destPath.StartsWith(fullDestDir, StringComparison.Ordinal))
                    throw new InvalidDataException(
                        $"Zip entry '{entry.FullName}' resolves outside the target directory.");
                var destDir = Path.GetDirectoryName(destPath);
                if (!string.IsNullOrEmpty(destDir) && destDir != lastDir)
                {
                    Directory.CreateDirectory(destDir!);
                    lastDir = destDir;
                }

                WriteEntry(entry, destPath, buffer, handleLockedFiles);
            }

            return ProcessExtractedModule(targetPath, moduleName, extractedVersions);
        }

        /// <summary>
        /// Writes a zip entry to <paramref name="destPath"/>, overwriting any existing file. When
        /// <paramref name="handleLockedFiles"/> is set and the destination is locked by the running
        /// process (the loaded DLL during a self-update), the write is retried after either
        /// confirming the content is identical (skip) or moving the locked file aside (replace).
        /// </summary>
        private static void WriteEntry(ZipArchiveEntry entry, string destPath, byte[] buffer, bool handleLockedFiles)
        {
            try
            {
                CopyEntryToFile(entry, destPath, buffer);
            }
            catch (IOException ex) when (handleLockedFiles && IsSharingViolation(ex) && File.Exists(destPath))
            {
                // Destination is locked. If it already matches the incoming bytes there is nothing
                // to do; otherwise move the locked file aside so the new bytes take its path. If
                // even the rename is blocked, File.Move throws and that exception surfaces.
                if (EntryMatchesFile(entry, destPath))
                    return;
                File.Move(destPath, GetAsidePath(destPath));
                CopyEntryToFile(entry, destPath, buffer);
            }
        }

        // FileStream's internal buffer is unnecessary; reads are buffered in the 1 MiB `buffer`
        // and written in 1 MiB chunks. Use the BCL default (4 KiB) to keep pinned-heap low.
        private static void CopyEntryToFile(ZipArchiveEntry entry, string destPath, byte[] buffer)
        {
            using var entryStream = entry.Open();
            using var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write,
                FileShare.None, bufferSize: 4096);
            int read;
            while ((read = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                fileStream.Write(buffer, 0, read);
        }

        private static bool IsSharingViolation(IOException ex) => ex.HResult == HResultSharingViolation;

        // Unique sibling path with the marker suffix, used to move a locked file aside.
        private static string GetAsidePath(string path) =>
            path + "." + Guid.NewGuid().ToString("N") + LockedRenameSuffix;

        // Compares the entry's content against the file on disk by length then bytes.
        private static bool EntryMatchesFile(ZipArchiveEntry entry, string destPath)
        {
            var info = new FileInfo(destPath);
            if (info.Length != entry.Length)
                return false;
            using var entryStream = entry.Open();
            using var fileStream = new FileStream(destPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var a = new byte[8192];
            var b = new byte[8192];
            int n;
            while ((n = ReadBlock(entryStream, a)) > 0)
            {
                if (ReadBlock(fileStream, b, n) != n)
                    return false;
                for (int i = 0; i < n; i++)
                    if (a[i] != b[i])
                        return false;
            }
            return true;
        }

        // Fills up to `count` (default full buffer) bytes, since a single Read may return less.
        private static int ReadBlock(Stream stream, byte[] buffer, int count = -1)
        {
            if (count < 0) count = buffer.Length;
            int total = 0;
            while (total < count)
            {
                int read = stream.Read(buffer, total, count - total);
                if (read == 0) break;
                total += read;
            }
            return total;
        }

        /// <summary>
        /// Removes a version directory, moving aside any file locked by the running process (the
        /// loaded DLL during a self-uninstall) so the directory can be deleted. The marker is
        /// cleaned up by <see cref="SweepLockedRenames"/> later. Returns true if the directory no
        /// longer exists on return. Never throws.
        /// </summary>
        public static bool TryRemoveModuleDirectory(string versionDir)
        {
            if (string.IsNullOrEmpty(versionDir)) return false;
            if (!Directory.Exists(versionDir)) return true;

            // Nothing locked (and always on POSIX, where open files can be unlinked): plain delete.
            try
            {
                Directory.Delete(versionDir, recursive: true);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }

            var evictRoot = Path.GetDirectoryName(versionDir);
            if (string.IsNullOrEmpty(evictRoot)) return false;
            try
            {
                foreach (var file in Directory.GetFiles(versionDir, "*", SearchOption.AllDirectories))
                {
                    try { File.Delete(file); }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        // Move the locked file out of the tree; if even that fails the directory
                        // survives and the check below reports failure.
                        try { File.Move(file, GetAsidePath(Path.Combine(evictRoot!, Path.GetFileName(file)))); }
                        catch (Exception mv) when (mv is IOException || mv is UnauthorizedAccessException) { }
                    }
                }
                Directory.Delete(versionDir, recursive: true);
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }

            return !Directory.Exists(versionDir);
        }

        /// <summary>
        /// Deletes marker files left by <see cref="WriteEntry"/> or
        /// <see cref="TryRemoveModuleDirectory"/> when a locked file was moved aside. Files still
        /// locked are skipped and retried on a later sweep. Never throws.
        /// </summary>
        public static void SweepLockedRenames(string targetPath)
        {
            if (string.IsNullOrEmpty(targetPath) || !Directory.Exists(targetPath)) return;
            try
            {
                foreach (var file in Directory.EnumerateFiles(targetPath, "*" + LockedRenameSuffix,
                             SearchOption.AllDirectories))
                {
                    try { File.Delete(file); }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException) { }
        }

        private static List<InstalledModule> ProcessExtractedModule(
            string targetPath, string moduleName, HashSet<string> extractedVersions)
        {
            var result = new List<InstalledModule>();
            var moduleDir = Path.Combine(targetPath, moduleName);
            if (!Directory.Exists(moduleDir)) return result;

            foreach (var version in extractedVersions)
            {
                var versionDir = Path.Combine(moduleDir, version);
                if (!Directory.Exists(versionDir)) continue;

                var psd1Path = Path.Combine(versionDir, moduleName + ".psd1");
                if (!File.Exists(psd1Path)) continue;

                string fullVersion = version;
                string? warning = null;

                Hashtable? manifest = null;
                try
                {
                    // Parse the manifest once. The parsed hashtable is reused below by
                    // PSGetModuleInfoXmlBuilder.GenerateAndWrite, which has an overload
                    // that accepts a pre-parsed manifest and avoids re-reading the file.
                    manifest = Psd1.Load(psd1Path);
                    var prerelease = (manifest["PrivateData"] as Hashtable)?["PSData"] as Hashtable;
                    var prereleaseTag = prerelease?["Prerelease"]?.ToString();
                    if (!string.IsNullOrEmpty(prereleaseTag))
                        fullVersion = version + "-" + prereleaseTag;
                }
                catch (InvalidDataException ex)
                {
                    warning = $"Could not parse manifest '{psd1Path}': {ex.Message}";
                }
                catch (IOException ex)
                {
                    warning = $"Could not read manifest '{psd1Path}': {ex.Message}";
                }

                if (manifest != null)
                {
                    try
                    {
                        PSGetModuleInfoXmlBuilder.GenerateAndWrite(manifest, moduleName, version, versionDir);
                    }
                    catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
                    {
                        warning = $"Could not write PSGetModuleInfo.xml for '{moduleName}': {ex.Message}";
                    }
                }

                result.Add(new InstalledModule(moduleName, version, fullVersion, versionDir, warning));
            }
            return result;
        }
    }
}
