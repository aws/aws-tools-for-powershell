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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Provider;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    public sealed partial class S3Provider
    {
        // ---- Path helpers ----------------------------------------------------

        private bool IsDriveRoot(string path)
        {
            if (string.IsNullOrEmpty(path)) return true;
            return path.Trim('\\', '/').Length == 0;
        }

        // Split a provider path into bucket + S3 key ("my-bucket\2026\q2" -> "my-bucket", "2026/q2").
        // Strips any "<provider>::" and "<drive>:" qualifier first: the engine sometimes hands us a
        // qualified path (e.g. "AWS.Tools.S3\AWS.S3::S3:\bucket\key"), which would otherwise parse the
        // bucket as "S3:" and probe a garbage bucket.
        private void ParsePath(string path, out string bucket, out string key)
        {
            bucket = "";
            key = "";
            if (string.IsNullOrEmpty(path)) return;

            var p = path;
            string driveQualifier = null;

            // Strip a provider-qualified prefix "Module\Provider::" if present. A key may contain
            // "::", so only treat it as a qualifier when the left side names this provider.
            var sep = p.IndexOf("::", StringComparison.Ordinal);
            if (sep >= 0 && IsProviderQualifier(p.Substring(0, sep)))
                p = p.Substring(sep + 2);

            // Strip a leading drive qualifier "name:" (e.g. "S3:"). A key may contain ':', so the
            // colon is a qualifier only when it appears before the first path separator.
            var colon = p.IndexOf(':');
            var firstSeparator = p.IndexOfAny(new[] { '\\', '/' });
            if (colon >= 0 && (firstSeparator < 0 || colon < firstSeparator))
            {
                driveQualifier = p.Substring(0, colon);
                p = p.Substring(colon + 1);
            }

            var norm = p.Replace('\\', '/').Trim('/');
            norm = ApplyDriveRoot(norm, driveQualifier);
            if (norm.Length == 0) return;

            var idx = norm.IndexOf('/');
            if (idx < 0) { bucket = norm; }
            else { bucket = norm.Substring(0, idx); key = norm.Substring(idx + 1); }
        }

        // For a rooted drive (Root = "bucket/prefix"), the engine sometimes hands a root-relative child
        // path instead of prepending the root. Rebase it onto the real bucket/key so a write/delete
        // stays scoped under the mounted root.
        private string ApplyDriveRoot(string normalizedPath, string driveQualifier)
        {
            if (string.IsNullOrEmpty(normalizedPath)) return normalizedPath;

            var root = ResolveDriveRoot(driveQualifier);
            if (string.IsNullOrWhiteSpace(root)) return normalizedPath;

            var normalizedRoot = root.Replace('\\', '/').Trim('/');
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

        // Separator to EMIT in paths handed back to the engine: OS-native ('\' on Windows, '/' else).
        // ParsePath accepts both on input, so only path-building is OS-aware.
        private static readonly char Sep =
            System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(
                System.Runtime.InteropServices.OSPlatform.Windows) ? '\\' : '/';

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
    }
}
