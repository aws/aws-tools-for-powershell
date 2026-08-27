/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Management.Automation;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Path helpers ----------------------------------------------------

        private bool IsDriveRoot(string path)
        {
            if (string.IsNullOrEmpty(path)) return true;
            return path.Trim(Separators).Length == 0;
        }

        // Split a provider path into bucket + S3 key ("my-bucket\2026\q2" -> "my-bucket", "2026/q2").
        // Strips any "<provider>::" and "<drive>:" qualifier first: the engine sometimes hands us a
        // qualified path (e.g. "AWS.Tools.S3\AWS.S3::S3:\bucket\key"), which would otherwise parse the
        // bucket as "S3:" and probe a garbage bucket.
        private void ParsePath(string path, out string bucket, out string key)
        {
            bucket = "";
            key = "";

            var norm = ApplyDriveRoot(StripQualifiers(path, out var driveQualifier), driveQualifier);
            if (norm.Length == 0) return;

            var idx = norm.IndexOf('/');
            if (idx < 0) { bucket = norm; }
            else { bucket = norm.Substring(0, idx); key = norm.Substring(idx + 1); }
        }

        // Drop the qualifiers and fold accepted separators to '/', yielding a bucket/key string.
        private string StripQualifiers(string path, out string driveQualifier)
        {
            driveQualifier = null;
            if (string.IsNullOrEmpty(path)) return "";

            var p = path;

            // Strip a provider-qualified prefix "Module\Provider::" if present. A key may contain
            // "::", so only treat it as a qualifier when the left side names this provider.
            var sep = p.IndexOf("::", StringComparison.Ordinal);
            if (sep >= 0 && IsProviderQualifier(p.Substring(0, sep)))
                p = p.Substring(sep + 2);

            // Strip a leading drive qualifier "name:" (e.g. "S3:"). A key may contain ':', so the
            // colon is a qualifier only when it appears before the first path separator.
            var colon = p.IndexOf(':');
            var firstSeparator = p.IndexOfAny(Separators);
            if (colon >= 0 && (firstSeparator < 0 || colon < firstSeparator))
            {
                driveQualifier = p.Substring(0, colon);
                p = p.Substring(colon + 1);
            }

            return ToKeySeparators(p).Trim('/');
        }

        // On a -Root drive the leading root segment of an incoming path is either the root the engine
        // prepended (strip it) or a real folder that happens to share the root's name (keep it). The text
        // is identical either way, so both readings are possible whenever such a folder exists. If BOTH
        // name an existing object, refuse: picking one silently targets the wrong object. Account-root
        // drives strip nothing and never reach this.
        private bool RootReadingIsAmbiguous(string path, string bucket, string key)
        {
            var root = NormalizeRoot(PSDriveInfo?.Root);
            if (root.Length == 0 || string.IsNullOrEmpty(key)) return false;

            var raw = StripQualifiers(path, out _);
            if (!raw.StartsWith(root + "/", StringComparison.Ordinal)) return false;

            // The "leading segment was NOT the root" reading.
            var full = root + "/" + raw;
            var idx = full.IndexOf('/');
            var altBucket = idx < 0 ? full : full.Substring(0, idx);
            var altKey = idx < 0 ? "" : full.Substring(idx + 1);
            if (altKey.Length == 0
                || (string.Equals(altBucket, bucket, StringComparison.Ordinal)
                    && string.Equals(altKey, key, StringComparison.Ordinal)))
                return false;

            try
            {
                var drive = DriveForPath(path);
                if (drive == null) return false;
                return ObjectExists(drive, bucket, key) == true
                    && ObjectExists(drive, altBucket, altKey) == true;
            }
            catch (Amazon.S3.AmazonS3Exception)
            {
                return false;   // can't tell; let the operation itself surface the real error
            }
        }

        // For a rooted drive (Root = "bucket/prefix"), the engine sometimes hands a root-relative child
        // path instead of prepending the root. Rebase it onto the real bucket/key so a write/delete
        // stays scoped under the mounted root.
        private string ApplyDriveRoot(string normalizedPath, string driveQualifier)
        {
            if (string.IsNullOrEmpty(normalizedPath)) return normalizedPath;

            var root = ResolveDriveRoot(driveQualifier);
            if (string.IsNullOrWhiteSpace(root)) return normalizedPath;

            var normalizedRoot = ToKeySeparators(root).Trim('/');
            if (normalizedRoot.Length == 0) return normalizedPath;

            var relative = normalizedPath;
            var rootWithSlash = normalizedRoot + "/";

            if (string.Equals(relative, normalizedRoot, StringComparison.Ordinal))
                relative = "";
            else if (relative.StartsWith(rootWithSlash, StringComparison.Ordinal))
                relative = relative.Substring(rootWithSlash.Length);
            else
            {
                var slash = normalizedRoot.IndexOf('/');
                var rootKey = slash < 0 ? "" : normalizedRoot.Substring(slash + 1);
                if (!string.IsNullOrEmpty(rootKey))
                {
                    var rootKeyWithSlash = rootKey + "/";
                    if (string.Equals(relative, rootKey, StringComparison.Ordinal))
                        relative = "";
                    else if (relative.StartsWith(rootKeyWithSlash, StringComparison.Ordinal))
                        relative = relative.Substring(rootKeyWithSlash.Length);
                }
            }

            // The engine can feed the root back repeated ("bucket/prefix/bucket/prefix/new.txt");
            // collapse the repeats to a single base.
            while (string.Equals(relative, normalizedRoot, StringComparison.Ordinal) ||
                   relative.StartsWith(rootWithSlash, StringComparison.Ordinal))
            {
                relative = relative.Length == normalizedRoot.Length
                    ? ""
                    : relative.Substring(rootWithSlash.Length);
            }

            return string.IsNullOrEmpty(relative)
                ? normalizedRoot
                : normalizedRoot + "/" + relative;
        }

        private string ResolveDriveRoot(string driveQualifier)
        {
            if (!string.IsNullOrEmpty(driveQualifier) && ProviderInfo?.Drives != null)
            {
                foreach (var d in ProviderInfo.Drives)
                    if (string.Equals(d.Name, driveQualifier, StringComparison.OrdinalIgnoreCase))
                        return d.Root;
            }

            if (!string.IsNullOrEmpty(PSDriveInfo?.Root))
                return PSDriveInfo.Root;

            return null;
        }

        private bool IsProviderQualifier(string qualifier)
        {
            if (string.IsNullOrEmpty(qualifier)) return false;

            var providerName = ProviderInfo?.Name ?? "AWS.S3";
            var q = qualifier.Replace('/', '\\');
            return string.Equals(q, providerName, StringComparison.OrdinalIgnoreCase)
                || q.EndsWith("\\" + providerName, StringComparison.OrdinalIgnoreCase);
        }

        // Parse a path that must point at an object (non-empty bucket AND key); on failure WriteErrors
        // with the given message/id and returns false. Shared by RemoveItem/GetContent{Reader,Writer}.
        private bool TryParseObjectPath(string path, string message, string errorId,
            out string bucket, out string key)
        {
            ParsePath(path, out bucket, out key);
            if (string.IsNullOrEmpty(bucket) || string.IsNullOrEmpty(key))
            {
                WriteError(new ErrorRecord(
                    new ArgumentException(message), errorId, ErrorCategory.InvalidArgument, path));
                return false;
            }

            if (RootReadingIsAmbiguous(path, bucket, key))
            {
                var root = NormalizeRoot(PSDriveInfo?.Root);
                var conflicting = root;
                var lastSlash = root.LastIndexOf('/');
                if (lastSlash >= 0) conflicting = root.Substring(lastSlash + 1);

                WriteError(new ErrorRecord(
                    new InvalidOperationException(
                        $"Cannot resolve '{path}': this drive is rooted at '{root}', which also contains a folder " +
                        $"named '{conflicting}'. The path therefore matches two different objects and the provider " +
                        "cannot tell which was meant. Navigating into the folder does not help, because the drive " +
                        "root is applied to every path. Mount a drive without -Root and address the object by its " +
                        "full bucket and key instead."),
                    "AmbiguousDriveRoot", ErrorCategory.InvalidArgument, path));
                return false;
            }
            return true;
        }

        private static string EnsureTrailingSlash(string key) =>
            key.EndsWith("/") ? key : key + "/";

        // Map the friendly -Encoding names (matching the built-in cmdlet) to encodings; UTF-8 no-BOM
        // when unspecified.
        private static System.Text.Encoding ResolveEncoding(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new System.Text.UTF8Encoding(false);

            switch (name.Trim().ToLowerInvariant())
            {
                case "ascii":             return System.Text.Encoding.ASCII;
                case "utf8":
                case "utf8nobom":         return new System.Text.UTF8Encoding(false);
                case "utf8bom":           return new System.Text.UTF8Encoding(true);
                case "utf16":
                case "unicode":           return System.Text.Encoding.Unicode;
                case "bigendianunicode":  return System.Text.Encoding.BigEndianUnicode;
                case "utf32":             return System.Text.Encoding.UTF32;
                case "latin1":            return System.Text.Encoding.GetEncoding("iso-8859-1");
                default:
                    // Fall back to .NET's own lookup (accepts code pages / canonical names).
                    try { return System.Text.Encoding.GetEncoding(name); }
                    catch { throw new ArgumentException($"Unsupported -Encoding value '{name}'."); }
            }
        }

        private static readonly bool WindowsPaths =
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Windows);

        // Separator to EMIT in paths handed back to the engine: OS-native ('\' on Windows, '/' else).
        private static readonly char Sep = WindowsPaths ? '\\' : '/';

        // Separators accepted on INPUT. Only Windows treats '\' as one, because it is the OS separator
        // there; elsewhere '\' stays an ordinary character, so keys containing it resolve correctly.
        private static readonly char[] Separators = WindowsPaths ? new[] { '\\', '/' } : new[] { '/' };

        private static string ToKeySeparators(string s) => WindowsPaths ? s.Replace('\\', '/') : s;

        // Emit the provider-internal, drive-INDEPENDENT path (bucket + key), not "S3:\...". The engine
        // wraps it as "Module\Provider::<path>" and, when that is piped back, re-resolves the remainder
        // against the hidden drive; a "S3:" qualifier here would leave a dangling "S3:" it can't resolve.
        // Built-in providers do the same (FileSystem emits "C:\foo", not a drive-qualified path).
        private string MakeItemPath(string childName) => childName;

        // "b", "2026/q2/x.csv" -> "b\2026\q2\x.csv" (OS-native separator; drive-independent, see MakeItemPath).
        private string MakeChildPath(string bucket, string fullKey)
        {
            var rel = fullKey.TrimEnd('/').Replace('/', Sep);
            return $"{bucket}{Sep}{rel}";
        }

        // -Filter support (ProviderCapabilities.Filter). The engine sets the inherited Filter property;
        // we apply it client-side as a case-insensitive wildcard on the LEAF name, matching the
        // FileSystem provider. No filter set => everything matches. Compiled once per invocation.
        private WildcardPattern _filterPattern;
        private string _filterPatternSource;

        private bool MatchesFilter(string leafName)
        {
            var filter = Filter;
            if (string.IsNullOrEmpty(filter))
                return true;
            if (!ReferenceEquals(filter, _filterPatternSource) && filter != _filterPatternSource)
            {
                _filterPattern = new WildcardPattern(filter, WildcardOptions.IgnoreCase);
                _filterPatternSource = filter;
            }
            return _filterPattern.IsMatch(leafName);
        }

        // The leaf segment of a (possibly nested, possibly "/"- or "\"-separated) child name. Under
        // -Recurse a child Name can be a relative key like "sub/deep.txt"; -Filter matches the leaf,
        // as FileSystem's -Filter -Recurse does.
        private static string LeafName(string name)
        {
            var n = ToKeySeparators(name).TrimEnd('/');
            var i = n.LastIndexOf('/');
            return i < 0 ? n : n.Substring(i + 1);
        }
    }
}
