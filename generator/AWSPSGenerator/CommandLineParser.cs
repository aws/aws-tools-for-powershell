using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSPowerShellGenerator
{
    /// <summary>
    /// Parses the command line into argument settings controlling the documentation
    /// generator.
    /// </summary>
    internal class CommandArguments
    {
        /// <summary>
        /// Takes the command line arguments, fuses them with any response file that may also have
        /// been specified, and parses them.
        /// </summary>
        /// <param name="cmdlineArgs">The set of arguments supplied to the program</param>
        /// <returns></returns>
        public static CommandArguments Parse(string[] cmdlineArgs)
        {
            var arguments = new CommandArguments();
            arguments.Process(cmdlineArgs);
            return arguments;
        }

        /// <summary>
        /// Set if an error is encountered whilst parsing arguments.
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// <para>
        /// The collection of options parsed from the command line.
        /// These arguments exist on the command line as individual entries
        /// prefixed with '-' or '/'. Options can be set in a response file
        /// and indicated with a '@' prefix, in which case the contents
        /// of the file will be read and inserted into the same relative
        /// location in the arguments to parse (allowing for later
        /// arguments to override).
        /// </para>
        /// <para>
        /// Options not specified on the command line are set from internal
        /// defaults.
        /// </para>
        /// </summary>
        public GeneratorOptions ParsedOptions { get; private set; }

        private CommandArguments()
        {
            ParsedOptions = new GeneratorOptions();
        }

        private void Process(IEnumerable<string> cmdlineArgs)
        {
            // walk the supplied command line looking for any response file(s), indicated using
            // @filename, and fuse into one logical set of arguments we can parse
            var argsToParse = new List<string>();
            foreach (var a in cmdlineArgs)
            {
                if (a.StartsWith("@", StringComparison.OrdinalIgnoreCase))
                    AddResponseFileArguments(a.Substring(1), argsToParse);
                else
                    argsToParse.Add(a);
            }

            if (string.IsNullOrEmpty(Error))
            {
                for (var argIndex = 0; argIndex < argsToParse.Count; argIndex++)
                {
                    if (!IsSwitch(argsToParse[argIndex])) continue;

                    var argDeclaration = FindArgDeclaration(argsToParse[argIndex]);
                    if (argDeclaration != null)
                    {
                        if (argDeclaration.HasValue)
                            argIndex++;
                        if (argIndex < argsToParse.Count)
                            argDeclaration.Parse(this, argsToParse[argIndex]);
                        else
                            Error = "Expected value for argument: " + argDeclaration.OptionName;
                    }
                    else
                        Error = "Unrecognised argument: " + argsToParse[argIndex];

                    if (!string.IsNullOrEmpty(Error))
                        break;
                }
            }
        }

        private void AddResponseFileArguments(string responseFile, ICollection<string> args)
        {
            try
            {
                // Response file format is one argument (plus optional value)
                // per line. Comments can be used by putting # as the first char.
                using (var s = new StreamReader(ResolvePath(responseFile)))
                {
                    var line = s.ReadLine();
                    while (line != null)
                    {
                        if (line.Length != 0 && line[0] != '#')
                        {
                            // trying to be flexible here and allow for lines with or without keyword 
                            // prefix in the response file
                            var keywordEnd = line.IndexOf(' ');
                            var keyword = keywordEnd > 0 ? line.Substring(0, keywordEnd) : line;

                            if (ArgumentPrefixes.Any(prefix => keyword.StartsWith(prefix.ToString(CultureInfo.InvariantCulture))))
                                args.Add(keyword);
                            else
                                args.Add(ArgumentPrefixes[0] + keyword);

                            if (keywordEnd > 0)
                            {
                                keywordEnd++;
                                if (keywordEnd < line.Length)
                                {
                                    var value = line.Substring(keywordEnd).Trim(' ');
                                    if (!string.IsNullOrEmpty(value))
                                        args.Add(value);
                                }
                            }
                        }
                        line = s.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Error = string.Format("Caught exception processing response file {0} - {1}", responseFile, e.Message);
            }
        }

        delegate void ParseArgument(CommandArguments arguments, string argValue = null);

        class ArgDeclaration
        {
            public string OptionName { get; set; }
            public string ShortName { get; set; }
            public bool HasValue { get; set; }
            public ParseArgument Parse { get; set; }
            public string HelpText { get; set; }
            public string HelpExample { get; set; }
        }

        static readonly ArgDeclaration[] ArgumentsTable =
        {
            new ArgDeclaration
            {
                OptionName = "verbose", 
                ShortName = "v", 
                Parse = (arguments, argValue) => arguments.ParsedOptions.Verbose = true, 
                HelpText = "Enable verbose output."
            },    
            new ArgDeclaration
            {
                OptionName = "waitonexit", 
                ShortName = "w", 
                Parse = (arguments, argValue) => arguments.ParsedOptions.WaitOnExit = true, 
                HelpText = "Pauses waiting for a keypress after code generation completes."
            },    
            new ArgDeclaration
            {
                OptionName = "sdknugetfolder", 
                ShortName = "sdk", 
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.SdkNugetFolder = argValue, 
                HelpText = "The folder containing the built sdk nupkg files to be used in generating cmdlets."
            },
            new ArgDeclaration
            {
                OptionName = "rootpath",
                ShortName = "rp",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.RootPath = argValue,
                HelpText = "The root folder location containing the generator and artifacts. Subpaths to the various components and deployment artifacts will be inferred from this location."
            },
            new ArgDeclaration
            {
                OptionName = "tasks",
                ShortName = "t",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.Tasks = new HashSet<string>(argValue.Split(',')),
                HelpText = "Comma-delimited set of generator tasks to run. If not specified, all tasks are run."
            },
            new ArgDeclaration
            {
                OptionName = "createnewcmdlets",
                ShortName = "cnc",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.CreateNewCmdlets = bool.Parse(argValue),
                HelpText = "If true (default), cmdlets are created for discovered service operations. Set false to generate code for an emergency maintenance releases without needing to configure new service operations changes first."
            },
            new ArgDeclaration
            {
                OptionName = "breakonnewoperations",
                ShortName = "bno",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.BreakOnNewOperations = bool.Parse(argValue),
                HelpText = "If true (the default is false), the build will fail if new operations are present in the SDK. Set to true for release builds when all configurations are expected to be already committed."
            },
            new ArgDeclaration
            {
                OptionName = "moduleslocation",
                ShortName = "ml",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.BuiltModulesLocation = argValue,
                HelpText = "The folder location containing the built AWSPowerShell module(s). Used when generating web docs in a separate build process."
            },
            new ArgDeclaration
            {
                OptionName = "assemblyname",
                ShortName = "an",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.AssemblyName = argValue,
                HelpText = "Name of the assembly to analyze, doesn't include the extension. Used for help and format generation."
            },
            new ArgDeclaration
            {
                OptionName = "docoutputfolder",
                ShortName = "dof",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.DocOutputFolder = argValue,
                HelpText = "The folder location that will hold the generated web docs. Used when generating web docs in a separate build process."
            },
            new ArgDeclaration
            {
                OptionName = "edition",
                ShortName = "e",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.Edition = argValue,
                HelpText = "The edition (desktop or coreclr) that we are building additional content (help etc) for. This affects the location where we output the built module as well as #ifdef statements for specific environment targetting in the cmdlet source code."
            },
            new ArgDeclaration
            {
                OptionName = "skipcmdletgeneration",
                ShortName = "scg",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.SkipCmdletGeneration = bool.Parse(argValue),
                HelpText = "If true (it defaults to false), skips reflecting over the service client to generate cmdlets. Set true to perform test builds against new SDK releases without having to update the service models."
            },
            new ArgDeclaration
            {
                OptionName = "versionnumber",
                ShortName = "vn",
                HasValue = true,
                Parse = (arguments, argValue) => arguments.ParsedOptions.VersionNumber = argValue,
                HelpText = "The four-components version number e.g. 4.0.0.0."
            }
        };

        static readonly char[] ArgumentPrefixes = { '-', '/' };

        /// <summary>
        /// Returns true if the supplied value has a argument prefix indicator, marking it as
        /// an argumentkeyword.
        /// </summary>
        /// <param name="argument"></param>
        /// <returns></returns>
        static bool IsSwitch(string argument)
        {
            return ArgumentPrefixes.Any(c => argument.StartsWith(c.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// Scans the argument declaration table to find a matching entry for a token from the command line
        /// that is potentially an option keyword.
        /// </summary>
        /// <param name="argument">Keyword found on the command line. Any prefixes will be removed before attempting to match.</param>
        /// <returns>Matching declaration or null if keyword not recognised</returns>
        static ArgDeclaration FindArgDeclaration(string argument)
        {
            var keyword = argument.TrimStart(ArgumentPrefixes);
            return ArgumentsTable.FirstOrDefault(argDeclation
                => keyword.Equals(argDeclation.ShortName, StringComparison.OrdinalIgnoreCase)
                   || keyword.Equals(argDeclation.OptionName, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Resolves any relatively pathed filename.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        static string ResolvePath(string filePath)
        {
            if (Path.IsPathRooted(filePath))
                return filePath;

            return Path.GetFullPath(filePath);
        }
    }
}
