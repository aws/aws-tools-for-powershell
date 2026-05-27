using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AWSPowerShellGenerator.Analysis
{
    public class CommonParameterInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Aliases { get; set; } = new List<string>();
    }

    /// <summary>
    /// Scans base cmdlet source files (CredentialsArguments.cs, BaseCmdlets.cs) using Roslyn
    /// to extract common/inherited parameters and their aliases.
    /// </summary>
    public static class CommonParameterScanner
    {
        private static readonly HashSet<string> TargetClasses = new HashSet<string>
        {
            "AWSCommonArgumentsCmdlet",
            "AWSRegionArgumentsCmdlet",
            "AWSCredentialsArgumentsFullCmdlet",
            "AnonymousServiceCmdlet",
            "ServiceCmdlet"
        };

        public static List<CommonParameterInfo> ScanFolder(string commonFolder)
        {
            var parameters = new Dictionary<string, CommonParameterInfo>();

            var sourceFiles = Directory.GetFiles(commonFolder, "*.cs");
            foreach (var file in sourceFiles)
            {
                ScanFile(file, parameters);
            }

            // Add standard PowerShell common parameters (from PSCmdlet/Cmdlet base class)
            AddPowerShellCommonParameters(parameters);

            return parameters.Values.ToList();
        }

        private static void ScanFile(string filePath, Dictionary<string, CommonParameterInfo> parameters)
        {
            var source = File.ReadAllText(filePath);
            var tree = CSharpSyntaxTree.ParseText(source);
            var root = tree.GetCompilationUnitRoot();

            foreach (var ns in root.Members.OfType<NamespaceDeclarationSyntax>())
            {
                foreach (var cls in ns.Members.OfType<ClassDeclarationSyntax>())
                {
                    var className = cls.Identifier.ValueText;
                    if (!TargetClasses.Contains(className))
                        continue;

                    foreach (var prop in cls.Members.OfType<PropertyDeclarationSyntax>())
                    {
                        var attributes = prop.AttributeLists.SelectMany(al => al.Attributes).ToArray();
                        var hasParameter = attributes.Any(attr => GetAttributeName(attr) == "Parameter");
                        if (!hasParameter)
                            continue;

                        var paramName = prop.Identifier.ValueText;
                        var paramType = prop.Type.ToString();

                        if (parameters.ContainsKey(paramName))
                            continue;

                        var info = new CommonParameterInfo
                        {
                            Name = paramName,
                            Type = paramType
                        };

                        var aliasAttr = attributes.FirstOrDefault(attr => GetAttributeName(attr) == "Alias");
                        if (aliasAttr?.ArgumentList != null)
                        {
                            foreach (var arg in aliasAttr.ArgumentList.Arguments)
                            {
                                if (arg.Expression is LiteralExpressionSyntax literal)
                                {
                                    info.Aliases.Add(literal.Token.ValueText);
                                }
                                else if (arg.Expression is MemberAccessExpressionSyntax)
                                {
                                    // Handle constants like AWSRegionArgumentsCmdlet.RegionParameterAlias
                                    // Resolve known constant: "RegionToCall"
                                    info.Aliases.Add("RegionToCall");
                                }
                            }
                        }

                        parameters[paramName] = info;
                    }
                }
            }
        }

        private static void AddPowerShellCommonParameters(Dictionary<string, CommonParameterInfo> parameters)
        {
            var psCommonParams = new[]
            {
                "Verbose", "Debug", "ErrorAction", "WarningAction", "InformationAction",
                "ErrorVariable", "WarningVariable", "InformationVariable",
                "OutVariable", "OutBuffer", "PipelineVariable", "ProgressAction"
            };

            foreach (var name in psCommonParams)
            {
                if (!parameters.ContainsKey(name))
                {
                    parameters[name] = new CommonParameterInfo
                    {
                        Name = name,
                        Type = "System.Management.Automation.ActionPreference"
                    };
                }
            }

            // -Select is generated inline on every service cmdlet (by CmdletSourceWriter.WriteSelectParam)
            // rather than inherited from a base class, but it's effectively universal.
            if (!parameters.ContainsKey("Select"))
            {
                parameters["Select"] = new CommonParameterInfo
                {
                    Name = "Select",
                    Type = "System.String"
                };
            }

            // -NoAutoIteration is generated on auto-paginating cmdlets. Not universal but
            // common enough to avoid false positives during validation.
            if (!parameters.ContainsKey("NoAutoIteration"))
            {
                parameters["NoAutoIteration"] = new CommonParameterInfo
                {
                    Name = "NoAutoIteration",
                    Type = "System.Management.Automation.SwitchParameter"
                };
            }
        }

        private static string GetAttributeName(AttributeSyntax attributeSyntax)
        {
            switch (attributeSyntax.Name)
            {
                case IdentifierNameSyntax idName:
                    return idName.Identifier.Text;
                case QualifiedNameSyntax qName:
                    return qName.ChildNodes().OfType<IdentifierNameSyntax>().LastOrDefault()?.Identifier.Text;
                default:
                    return null;
            }
        }
    }
}
