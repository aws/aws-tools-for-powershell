using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Amazon.PowerShell.Installer
{
    /// <summary>
    /// Generates a <c>PSGetModuleInfo.xml</c> document compatible with
    /// <c>PowerShellGet</c> (<c>Get-InstalledModule</c>, <c>Uninstall-Module</c>) and
    /// <c>PSResourceGet</c> (<c>Uninstall-PSResource</c>). The exact XML shape is a
    /// consumer-visible contract that mirrors what <c>New-PSGetModuleInfo.ps1</c>
    /// produces - keep changes here behind a regression test.
    /// </summary>
    public static class PSGetModuleInfoXmlBuilder
    {
        private const string DefaultRepository = "PSGallery";
        private const string DefaultRepositorySourceLocation = "https://www.powershellgallery.com/api/v2";
        // Must match the value of ExpectedModuleCompanyName in modules/Installer/Config/general.psd1
        // (read by Find-AWSToolsModule.ps1). The CompanyName quirk that prevents changing this is
        // documented in general.psd1.
        private const string DefaultCompanyName = "aws-dotnet-sdk-team";

        // SetAttributes(...Hidden) is a no-op on non-Windows platforms - calling it throws
        // PlatformNotSupportedException (or IOException on .NET 5+). Across many modules the
        // throw/catch costs measurable wall-clock on Linux. Cache the platform check.
        private static readonly bool IsWindows =
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        // Characters that need XML-escaping. Used by Esc()'s IndexOfAny fast-path.
        private static readonly char[] EscChars = { '&', '<', '>', '"' };

        /// <summary>
        /// Generates and writes <c>PSGetModuleInfo.xml</c> next to the supplied .psd1 manifest,
        /// using the same content/format as <c>New-PSGetModuleInfo.ps1</c>. Sets the file's
        /// Hidden attribute to match <c>Write-PSGetModuleInfo.ps1</c>.
        /// </summary>
        public static void GenerateAndWrite(string psd1Path, string normalizedVersion, string installedLocation)
        {
            var manifest = Psd1.Load(psd1Path);
            var moduleName = Path.GetFileNameWithoutExtension(psd1Path);
            GenerateAndWrite(manifest, moduleName, normalizedVersion, installedLocation);
        }

        /// <summary>
        /// Overload accepting a pre-parsed manifest hashtable. Use this when the
        /// caller has already invoked <see cref="Psd1.Load(string)"/> for other
        /// purposes; it avoids parsing the same .psd1 twice.
        /// </summary>
        public static void GenerateAndWrite(
            Hashtable manifest, string moduleName, string normalizedVersion, string installedLocation)
        {
            var xml = BuildXml(manifest, moduleName, normalizedVersion, installedLocation, DateTime.Now, DateTime.Now);
            var xmlPath = Path.Combine(installedLocation, "PSGetModuleInfo.xml");
            // On Windows, an existing Hidden or ReadOnly file makes File.WriteAllText
            // throw UnauthorizedAccessException. Clear both before writing so re-installs
            // and upgrades can overwrite their own previously-emitted file. PowerShellGet
            // only sets Hidden today, but third-party tools (AV, copy-with-attrs) may set
            // ReadOnly on synced files - clearing both is cheap and removes a brittle edge.
            if (IsWindows && File.Exists(xmlPath))
                File.SetAttributes(xmlPath, File.GetAttributes(xmlPath) & ~(FileAttributes.Hidden | FileAttributes.ReadOnly));
            // UTF-8 without BOM, matching PSGallery's on-disk format for PSGetModuleInfo.xml.
            File.WriteAllText(xmlPath, xml, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            if (IsWindows)
            {
                try { File.SetAttributes(xmlPath, File.GetAttributes(xmlPath) | FileAttributes.Hidden); }
                catch (UnauthorizedAccessException) { /* best effort */ }
                catch (IOException) { /* best effort */ }
            }
        }

        /// <summary>
        /// Pure XML generation, no I/O. Public so tests can call it directly.
        /// </summary>
        public static string Generate(string psd1Path, string normalizedVersion, string installedLocation)
        {
            var manifest = Psd1.Load(psd1Path);
            var moduleName = Path.GetFileNameWithoutExtension(psd1Path);
            return BuildXml(manifest, moduleName, normalizedVersion, installedLocation, DateTime.Now, DateTime.Now);
        }

        // Public entry point for deterministic testing and for callers that already have a parsed manifest.
        public static string BuildXml(
            Hashtable manifest, string moduleName, string normalizedVersion, string installedLocation,
            DateTime publishedDate, DateTime installedDate)
        {
            string moduleVersion = GetString(manifest, "ModuleVersion") ?? normalizedVersion;
            string description = GetString(manifest, "Description") ?? string.Empty;
            string author = GetString(manifest, "Author") ?? "Amazon.com, Inc";
            // Match PS: $manifest.Author -replace ', Inc$', ' Inc'
            if (author.EndsWith(", Inc", StringComparison.Ordinal))
                author = author.Substring(0, author.Length - ", Inc".Length) + " Inc";
            string copyright = GetString(manifest, "Copyright") ?? string.Empty;
            string guid = GetString(manifest, "GUID") ?? string.Empty;
            string powerShellVersion = GetString(manifest, "PowerShellVersion") ?? string.Empty;
            string dotNetFrameworkVersion = GetString(manifest, "DotNetFrameworkVersion") ?? string.Empty;
            // Top-level CompanyName uses the configured default. AdditionalMetadata.CompanyName
            // uses the manifest's literal CompanyName field; this matches the preview001
            // PowerShell behavior and is what consumers reading AdditionalMetadata expect.
            string companyName = DefaultCompanyName;
            string manifestCompanyName = GetString(manifest, "CompanyName") ?? string.Empty;

            // PrivateData.PSData.*
            var psData = GetNestedHashtable(manifest, "PrivateData", "PSData");
            string licenseUri = GetString(psData, "LicenseUri") ?? string.Empty;
            string projectUri = GetString(psData, "ProjectUri") ?? string.Empty;
            string iconUri = GetString(psData, "IconUri") ?? string.Empty;
            string releaseNotes = GetString(psData, "ReleaseNotes") ?? string.Empty;
            var psDataTags = GetStringArray(psData, "Tags");

            var cmdletsToExport = GetStringArray(manifest, "CmdletsToExport");
            var requiredModules = GetArray(manifest, "RequiredModules");

            // Format description: PS does $description -replace "`r`n", "_x000D__x000A_" -replace "`n", "_x000D__x000A_"
            // Then XML-escape so manifest descriptions containing '&', '<', '>', or '"' do not
            // produce malformed PSGetModuleInfo.xml. The encoded newline marker contains no
            // XML-special characters, so escaping after the CRLF substitution is safe.
            string descriptionXml = Esc(
                description
                    .Replace("\r\n", "_x000D__x000A_")
                    .Replace("\n", "_x000D__x000A_"));

            // Build allTags string for AdditionalMetadata.tags:
            //   PSData.Tags + "PSModule" + ("PSCmdlet_X" + "PSCommand_X")* + "PSIncludes_Cmdlet"
            var allTags = new List<string>();
            allTags.AddRange(psDataTags);
            allTags.Add("PSModule");
            foreach (var cmd in cmdletsToExport)
            {
                allTags.Add("PSCmdlet_" + cmd);
                allTags.Add("PSCommand_" + cmd);
            }
            allTags.Add("PSIncludes_Cmdlet");
            string tagsString = string.Join(" ", allTags);

            // Build cmdlet list XML (used in two places: Cmdlet and Command)
            string cmdletListXml = string.Join("\r\n",
                cmdletsToExport.Select(c => "                <S>" + Esc(c) + "</S>"));

            // Build Tags LST (PSData.Tags + PSModule)
            var sbTags = new StringBuilder();
            foreach (var t in psDataTags)
                sbTags.AppendLine("          <S>" + Esc(t) + "</S>");
            sbTags.Append("          <S>PSModule</S>");

            // Dependencies XML from RequiredModules
            string dependencyXml = BuildDependencyXml(requiredModules, moduleVersion);

            // AdditionalMetadata entries (built in same order as PS for byte-stability).
            var meta = new List<string>();
            if (!string.IsNullOrEmpty(copyright))
                meta.Add("          <S N=\"copyright\">" + Esc(copyright) + "</S>");
            if (!string.IsNullOrEmpty(description))
                meta.Add("          <S N=\"description\">" + descriptionXml + "</S>");
            meta.Add("          <S N=\"requireLicenseAcceptance\">False</S>");
            if (!string.IsNullOrEmpty(releaseNotes))
                meta.Add("          <S N=\"releaseNotes\">" + Esc(releaseNotes) + "</S>");
            if (!string.IsNullOrEmpty(tagsString))
                meta.Add("          <S N=\"tags\">" + Esc(tagsString) + "</S>");
            if (!string.IsNullOrEmpty(manifestCompanyName))
                meta.Add("          <S N=\"CompanyName\">" + Esc(manifestCompanyName) + "</S>");
            if (!string.IsNullOrEmpty(guid))
                meta.Add("          <S N=\"GUID\">" + Esc(guid) + "</S>");
            if (!string.IsNullOrEmpty(powerShellVersion))
                meta.Add("          <S N=\"PowerShellVersion\">" + Esc(powerShellVersion) + "</S>");
            if (!string.IsNullOrEmpty(dotNetFrameworkVersion))
                meta.Add("          <S N=\"DotNetFrameworkVersion\">" + Esc(dotNetFrameworkVersion) + "</S>");
            if (!string.IsNullOrEmpty(normalizedVersion))
                meta.Add("          <S N=\"NormalizedVersion\">" + Esc(normalizedVersion) + "</S>");
            string additionalMetadataXml = string.Join("\r\n", meta);

            string published = publishedDate.ToString("yyyy-MM-ddTHH:mm:ss.ffK", CultureInfo.InvariantCulture);
            string installed = installedDate.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture);

            return string.Format(CultureInfo.InvariantCulture, XmlTemplate,
                /* {0} */ Esc(moduleName),
                /* {1} */ Esc(moduleVersion),
                /* {2} */ descriptionXml,
                /* {3} */ Esc(author),
                /* {4} */ Esc(companyName),
                /* {5} */ Esc(copyright),
                /* {6} */ published,
                /* {7} */ installed,
                /* {8} */ Esc(licenseUri),
                /* {9} */ Esc(projectUri),
                /* {10} */ Esc(iconUri),
                /* {11} */ sbTags.ToString(),
                /* {12} */ cmdletListXml,
                /* {13} */ Esc(releaseNotes),
                /* {14} */ dependencyXml,
                /* {15} */ Esc(DefaultRepositorySourceLocation),
                /* {16} */ Esc(DefaultRepository),
                /* {17} */ additionalMetadataXml,
                /* {18} */ Esc(installedLocation));
        }

        private static string BuildDependencyXml(object[] requiredModules, string fallbackVersion)
        {
            if (requiredModules.Length == 0) return string.Empty;

            var sb = new StringBuilder();
            for (int i = 0; i < requiredModules.Length; i++)
            {
                var entry = requiredModules[i];
                string depName, depVersion;

                if (entry is string s)
                {
                    depName = s;
                    depVersion = fallbackVersion;
                }
                else if (entry is Hashtable h)
                {
                    depName = GetString(h, "ModuleName") ?? GetString(h, "Name") ?? entry.ToString() ?? string.Empty;
                    depVersion = GetString(h, "RequiredVersion") ?? GetString(h, "ModuleVersion") ?? fallbackVersion;
                }
                else
                {
                    depName = entry?.ToString() ?? string.Empty;
                    depVersion = fallbackVersion;
                }

                if (i > 0) sb.AppendLine();
                sb.Append(string.Format(CultureInfo.InvariantCulture, DependencyEntryTemplate,
                    Esc(depName), Esc(depVersion)));
            }
            return sb.ToString();
        }

        // ----- Hashtable accessors -----

        private static string? GetString(Hashtable? table, string key)
        {
            if (table is null) return null;
            var v = table[key];
            return v?.ToString();
        }

        private static Hashtable? GetNestedHashtable(Hashtable? table, params string[] keys)
        {
            Hashtable? current = table;
            foreach (var k in keys)
            {
                if (current is null) return null;
                current = current[k] as Hashtable;
            }
            return current;
        }

        private static string[] GetStringArray(Hashtable? table, string key)
        {
            if (table is null) return Array.Empty<string>();
            var v = table[key];
            return v switch
            {
                null => Array.Empty<string>(),
                string s => new[] { s },
                object[] arr => arr.Select(o => o?.ToString() ?? string.Empty).Where(s => !string.IsNullOrEmpty(s)).ToArray(),
                IEnumerable e => e.Cast<object>().Select(o => o?.ToString() ?? string.Empty).Where(s => !string.IsNullOrEmpty(s)).ToArray(),
                _ => new[] { v.ToString() ?? string.Empty }
            };
        }

        private static object[] GetArray(Hashtable? table, string key)
        {
            if (table is null) return Array.Empty<object>();
            var v = table[key];
            return v switch
            {
                null => Array.Empty<object>(),
                object[] arr => arr,
                IEnumerable e => e.Cast<object>().ToArray(),
                _ => new[] { v }
            };
        }

        // ----- XML escaping -----

        private static string Esc(string? value)
        {
            if (string.IsNullOrEmpty(value)) return value ?? string.Empty;
            // Common case for AWS.Tools manifests: nothing to escape. Single O(n) scan
            // returns the original string instead of 4 chained Replace passes.
            int idx = value!.IndexOfAny(EscChars);
            if (idx < 0) return value;

            var sb = new StringBuilder(value.Length + 8);
            sb.Append(value, 0, idx);
            for (int i = idx; i < value.Length; i++)
            {
                char c = value[i];
                switch (c)
                {
                    case '&':  sb.Append("&amp;");  break;
                    case '<':  sb.Append("&lt;");   break;
                    case '>':  sb.Append("&gt;");   break;
                    case '"':  sb.Append("&quot;"); break;
                    default:   sb.Append(c);        break;
                }
            }
            return sb.ToString();
        }

        // ----- Templates -----
        // Indentation, attribute order, and RefId numbers match New-PSGetModuleInfo.ps1.

        private const string DependencyEntryTemplate =
@"          <Obj RefId=""9"">
            <TN RefId=""4"">
              <T>System.Collections.Specialized.OrderedDictionary</T>
              <T>System.Object</T>
            </TN>
            <DCT>
              <En>
                <S N=""Key"">Name</S>
                <S N=""Value"">{0}</S>
              </En>
              <En>
                <S N=""Key"">RequiredVersion</S>
                <S N=""Value"">{1}</S>
              </En>
              <En>
                <S N=""Key"">CanonicalId</S>
                <S N=""Value"">nuget:{0}/[{1}]</S>
              </En>
            </DCT>
          </Obj>";

        private const string XmlTemplate =
@"<Objs Version=""1.1.0.1"" xmlns=""http://schemas.microsoft.com/powershell/2004/04"">
  <Obj RefId=""0"">
    <TN RefId=""0"">
      <T>Microsoft.PowerShell.Commands.PSRepositoryItemInfo</T>
      <T>System.Management.Automation.PSCustomObject</T>
      <T>System.Object</T>
    </TN>
    <MS>
      <S N=""Name"">{0}</S>
      <Version N=""Version"">{1}</Version>
      <S N=""Type"">Module</S>
      <S N=""Description"">{2}</S>
      <S N=""Author"">{3}</S>
      <S N=""CompanyName"">{4}</S>
      <S N=""Copyright"">{5}</S>
      <DT N=""PublishedDate"">{6}</DT>
      <Obj N=""InstalledDate"" RefId=""1"">
        <DT>{7}</DT>
        <MS>
          <Obj N=""DisplayHint"" RefId=""2"">
            <TN RefId=""1"">
              <T>Microsoft.PowerShell.Commands.DisplayHintType</T>
              <T>System.Enum</T>
              <T>System.ValueType</T>
              <T>System.Object</T>
            </TN>
            <ToString>DateTime</ToString>
            <I32>2</I32>
          </Obj>
        </MS>
      </Obj>
      <Nil N=""UpdatedDate"" />
      <URI N=""LicenseUri"">{8}</URI>
      <URI N=""ProjectUri"">{9}</URI>
      <URI N=""IconUri"">{10}</URI>
      <Obj N=""Tags"" RefId=""3"">
        <TN RefId=""2"">
          <T>System.Object[]</T>
          <T>System.Array</T>
          <T>System.Object</T>
        </TN>
        <LST>
{11}
        </LST>
      </Obj>
      <Obj N=""Includes"" RefId=""4"">
        <TN RefId=""3"">
          <T>System.Collections.Hashtable</T>
          <T>System.Object</T>
        </TN>
        <DCT>
          <En>
            <S N=""Key"">Cmdlet</S>
            <Obj N=""Value"" RefId=""5"">
              <TNRef RefId=""2"" />
              <LST>
{12}
              </LST>
            </Obj>
          </En>
          <En>
            <S N=""Key"">DscResource</S>
            <Obj N=""Value"" RefId=""6"">
              <TNRef RefId=""2"" />
              <LST />
            </Obj>
          </En>
          <En>
            <S N=""Key"">RoleCapability</S>
            <Ref N=""Value"" RefId=""6"" />
          </En>
          <En>
            <S N=""Key"">Command</S>
            <Obj N=""Value"" RefId=""7"">
              <TNRef RefId=""2"" />
              <LST>
{12}
              </LST>
            </Obj>
          </En>
          <En>
            <S N=""Key"">Workflow</S>
            <Ref N=""Value"" RefId=""6"" />
          </En>
          <En>
            <S N=""Key"">Function</S>
            <Ref N=""Value"" RefId=""6"" />
          </En>
        </DCT>
      </Obj>
      <Nil N=""PowerShellGetFormatVersion"" />
      <S N=""ReleaseNotes"">{13}</S>
      <Obj N=""Dependencies"" RefId=""8"">
        <TNRef RefId=""2"" />
        <LST>
{14}
        </LST>
      </Obj>
      <S N=""RepositorySourceLocation"">{15}</S>
      <S N=""Repository"">{16}</S>
      <S N=""PackageManagementProvider"">NuGet</S>
      <Obj N=""AdditionalMetadata"" RefId=""10"">
        <TN RefId=""5"">
          <T>System.Management.Automation.PSCustomObject</T>
          <T>System.Object</T>
        </TN>
        <MS>
{17}
        </MS>
      </Obj>
      <S N=""InstalledLocation"">{18}</S>
    </MS>
  </Obj>
</Objs>";
    }
}
