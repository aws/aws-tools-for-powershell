using System;
using System.Collections.Generic;
using System.IO;

namespace Amazon.PowerShell.Installer
{
    /// <summary>
    /// Lightweight installed-module discovery for AWS.Tools.* modules.
    ///
    /// <para>
    /// Walks the directories listed in <c>$env:PSModulePath</c> and stream-reads
    /// only the manifest fields the installer's callers need:
    /// <c>(Name, Version, Prerelease, ModuleBase, Path)</c>. Returns
    /// <see cref="InstalledModuleInfo"/> objects rather than full
    /// <c>PSModuleInfo</c>, so callers must use these fields explicitly.
    /// </para>
    /// </summary>
    public sealed class InstalledModuleInfo
    {
        public string Name { get; }
        public string Version { get; }
        public string FullVersionString { get; }
        public string ModuleBase { get; }
        public string Path { get; }

        public InstalledModuleInfo(string name, string version, string fullVersionString, string moduleBase, string path)
        {
            Name = name;
            Version = version;
            FullVersionString = fullVersionString;
            ModuleBase = moduleBase;
            Path = path;
        }
    }

    public static class InstalledModules
    {
        /// <summary>
        /// Returns all modules under <paramref name="psModulePath"/> whose directory
        /// name matches <paramref name="namePattern"/>. Handles both flat layout
        /// (<c>Module/Module.psd1</c>) and versioned layout
        /// (<c>Module/Version/Module.psd1</c>). A module installed under multiple
        /// PSModulePath roots produces multiple entries (matches
        /// <c>Get-Module -ListAvailable</c> behavior).
        /// </summary>
        /// <param name="psModulePath">Colon (Linux) or semicolon (Windows) separated list of module roots - the value of <c>$env:PSModulePath</c>.</param>
        /// <param name="namePattern">Glob-like pattern matching the directory name. Default <c>AWS.Tools.*</c>.</param>
        public static InstalledModuleInfo[] Get(string psModulePath, string namePattern = "AWS.Tools.*")
        {
            if (string.IsNullOrEmpty(psModulePath))
                return Array.Empty<InstalledModuleInfo>();

            var sep = Path.PathSeparator; // ':' on unix, ';' on windows
            var paths = psModulePath.Split(sep);

            // No de-duplication: a module installed under multiple PSModulePath roots
            // produces one entry per root, matching Get-Module -ListAvailable behavior.
            var results = new List<InstalledModuleInfo>(64);

            foreach (var modulePath in paths)
            {
                if (string.IsNullOrWhiteSpace(modulePath)) continue;
                if (!Directory.Exists(modulePath)) continue;

                string[] moduleDirs;
                try
                {
                    moduleDirs = Directory.GetDirectories(modulePath, namePattern);
                }
                catch (UnauthorizedAccessException) { continue; }
                catch (IOException) { continue; }

                foreach (var moduleDir in moduleDirs)
                {
                    var moduleName = Path.GetFileName(moduleDir);

                    // Flat layout: <root>/<Name>/<Name>.psd1
                    var flatPsd1 = Path.Combine(moduleDir, moduleName + ".psd1");
                    if (File.Exists(flatPsd1))
                    {
                        var info = TryReadVersionAndPrerelease(flatPsd1, moduleName, moduleDir);
                        if (info != null) results.Add(info);
                    }

                    // Versioned layout: <root>/<Name>/<Version>/<Name>.psd1
                    string[] versionDirs;
                    try
                    {
                        versionDirs = Directory.GetDirectories(moduleDir);
                    }
                    catch (UnauthorizedAccessException) { continue; }
                    catch (IOException) { continue; }

                    foreach (var versionDir in versionDirs)
                    {
                        var versionDirName = Path.GetFileName(versionDir);
                        // Skip non-version directories (don't try to parse "Public" as Version)
                        if (!IsVersionLikeName(versionDirName)) continue;

                        var versionedPsd1 = Path.Combine(versionDir, moduleName + ".psd1");
                        if (!File.Exists(versionedPsd1)) continue;
                        var info = TryReadVersionAndPrerelease(versionedPsd1, moduleName, versionDir);
                        if (info != null) results.Add(info);
                    }
                }
            }

            return results.ToArray();
        }

        /// <summary>
        /// Stream-read a .psd1 to extract just <c>ModuleVersion</c> and the
        /// <c>Prerelease</c> tag from <c>PrivateData.PSData</c>. Returns
        /// <c>null</c> if the file cannot be read or no <c>ModuleVersion</c>
        /// is found. Does not perform an AST parse.
        /// </summary>
        private static InstalledModuleInfo? TryReadVersionAndPrerelease(string psd1Path, string moduleName, string moduleBase)
        {
            string? version = null;
            string? prerelease = null;
            try
            {
                using var reader = new StreamReader(psd1Path);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Strip line comments outside string literals - a # inside a quoted string
                    // would be a problem in general, but the AWS.Tools .psd1 generator never
                    // emits one inside ModuleVersion/Prerelease values.
                    var hashIdx = line.IndexOf('#');
                    var workLine = hashIdx >= 0 ? line.Substring(0, hashIdx) : line;

                    if (version == null && TryMatchSingleQuoted(workLine, "ModuleVersion", out var v))
                        version = v;
                    else if (prerelease == null && TryMatchSingleQuoted(workLine, "Prerelease", out var p))
                        prerelease = p;
                    if (version != null && prerelease != null) break;
                }
            }
            catch (UnauthorizedAccessException) { return null; }
            catch (IOException) { return null; }

            if (version == null) return null;

            var fullVersion = string.IsNullOrEmpty(prerelease) ? version : version + "-" + prerelease!;
            return new InstalledModuleInfo(
                name: moduleName,
                version: version,
                fullVersionString: fullVersion,
                moduleBase: moduleBase,
                path: psd1Path);
        }

        /// <summary>
        /// Match <c>Key = 'value'</c> in a single line. Returns <c>true</c> if matched and writes
        /// the captured value to <paramref name="value"/>. Tolerant of leading whitespace, doubled
        /// single-quote escape (<c>'it''s'</c>), and equals-spacing variants.
        /// </summary>
        private static bool TryMatchSingleQuoted(string line, string key, out string value)
        {
            value = string.Empty;
            // Find "Key" identifier (whole word, optional leading whitespace)
            int idx = IndexOfIdentifier(line, key);
            if (idx < 0) return false;

            // Skip past the key
            int p = idx + key.Length;

            // Optional whitespace, then '='
            while (p < line.Length && (line[p] == ' ' || line[p] == '\t')) p++;
            if (p >= line.Length || line[p] != '=') return false;
            p++;

            // Optional whitespace, then opening single quote
            while (p < line.Length && (line[p] == ' ' || line[p] == '\t')) p++;
            if (p >= line.Length || line[p] != '\'') return false;
            p++;

            // Read until closing single quote, handling '' as escape
            var sb = new System.Text.StringBuilder();
            while (p < line.Length)
            {
                char ch = line[p];
                if (ch == '\'')
                {
                    if (p + 1 < line.Length && line[p + 1] == '\'')
                    {
                        sb.Append('\'');
                        p += 2;
                        continue;
                    }
                    value = sb.ToString();
                    return true;
                }
                sb.Append(ch);
                p++;
            }

            // Unterminated quoted value on this line - bail (don't return what we have)
            return false;
        }

        /// <summary>
        /// Find the index of <paramref name="key"/> in <paramref name="line"/> as a
        /// whole-word identifier (preceded by whitespace or start, followed by whitespace or '=').
        /// </summary>
        private static int IndexOfIdentifier(string line, string key)
        {
            int from = 0;
            while (from < line.Length)
            {
                int idx = line.IndexOf(key, from, StringComparison.Ordinal);
                if (idx < 0) return -1;
                bool leftOk = idx == 0 || char.IsWhiteSpace(line[idx - 1]);
                int after = idx + key.Length;
                bool rightOk = after >= line.Length || line[after] == ' ' || line[after] == '\t' || line[after] == '=';
                if (leftOk && rightOk) return idx;
                from = idx + 1;
            }
            return -1;
        }

        /// <summary>True if the directory name looks like a version (e.g. "5.0.0", "5.0.0.0").</summary>
        private static bool IsVersionLikeName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            // Must start with a digit and contain only digits + dots
            if (!char.IsDigit(name[0])) return false;
            foreach (var ch in name)
            {
                if (!char.IsDigit(ch) && ch != '.') return false;
            }
            return true;
        }
    }
}
