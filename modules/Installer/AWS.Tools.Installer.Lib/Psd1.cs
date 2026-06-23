using System.Collections;
using System.IO;
using System.Management.Automation.Language;

namespace Amazon.PowerShell.Installer
{
    /// <summary>
    /// Parses a PowerShell module manifest (.psd1) into a fully-resolved
    /// <see cref="Hashtable"/>.
    /// </summary>
    internal static class Psd1
    {
        /// <summary>
        /// Returns the manifest's top-level hashtable. Values are the literal CLR
        /// types declared in the .psd1: strings as <c>string</c>, arrays as
        /// <c>object[]</c>, nested hashtables as <see cref="Hashtable"/>. Lookups
        /// are by key (e.g. <c>manifest["ModuleVersion"]</c>); navigate nested
        /// sections by casting:
        /// <code>
        /// var psData = (manifest["PrivateData"] as Hashtable)?["PSData"] as Hashtable;
        /// </code>
        /// Only literal values are evaluated; expressions, function calls, and
        /// variable references in the .psd1 cause an <see cref="InvalidDataException"/>.
        /// </summary>
        /// <exception cref="System.ArgumentNullException"><paramref name="psd1Path"/> is null.</exception>
        /// <exception cref="FileNotFoundException">No file at <paramref name="psd1Path"/>.</exception>
        /// <exception cref="InvalidDataException">The file does not parse, or contains no top-level hashtable.</exception>
        public static Hashtable Load(string psd1Path)
        {
            if (psd1Path is null) throw new System.ArgumentNullException(nameof(psd1Path));
            if (!File.Exists(psd1Path))
                throw new FileNotFoundException("Module manifest not found.", psd1Path);

            var ast = Parser.ParseFile(psd1Path, out _, out var errors);
            if (errors != null && errors.Length > 0)
                throw new InvalidDataException($"Could not parse manifest: {psd1Path} ({errors[0].Message})");

            var hashtableAst = ast.Find(static a => a is HashtableAst, false) as HashtableAst;
            if (hashtableAst is null)
                throw new InvalidDataException($"No hashtable in manifest: {psd1Path}");

            return (Hashtable)hashtableAst.SafeGetValue();
        }
    }
}
