using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Generators;
using AWSPowerShellGenerator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace AWSPowerShellGenerator.Writers.SourceCode
{
    /// <summary>
    /// <para>
    /// Text-based parser that scans the source file for an advanced (hand-maintained)
    /// cmdlet looking for 'interesting' items. Currently this just means looking for
    /// marker attributes on parameters that signal the use of ConstantClass-derived
    /// types for which argument completers should be generated.
    /// </summary>
    internal class AdvancedCmdletScanner
    {
        /// <summary>
        /// The parent service assembly for the cmdlet to be processed. Used to
        /// load remaining type definitions we may not have already seen when
        /// generating cmdlets.
        /// </summary>
        public Assembly ServiceAssembly { get; set; }

        public AdvancedCmdletScanner(Assembly serviceAssembly)
        {
            this.ServiceAssembly = serviceAssembly;
        }

        /// <summary>
        /// Perform the scan on the source file. If we locate attributes marking use
        /// of ConstantClass-derived types, update the service model so that argument
        /// completers are generated and/or the cmdlet is added to the completer
        /// registration.
        /// </summary>
        public void Scan(string sourceFile, Dictionary<string, AdvancedCmdletInfo> advancedCmdlets, ArgumentCompleterDetails argumentCompleters = null)
        {
            var originalSource = File.ReadAllText(sourceFile);

            try
            {
                SyntaxTree tree = CSharpSyntaxTree.ParseText(originalSource);
                CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

                foreach (var ns in root.Members.OfType<NamespaceDeclarationSyntax>())
                {
                    foreach (var cls in ns.Members.OfType<ClassDeclarationSyntax>())
                    {
                        var attributes = cls.AttributeLists.SelectMany(al => al.Attributes).ToArray();
                        var cmdletAttribute = attributes.FirstOrDefault(attr => GetAttributeName(attr) == "Cmdlet");
                        if (cmdletAttribute != null)
                        {
                            var cmdletVerb = (cmdletAttribute.ArgumentList.Arguments[0].Expression as LiteralExpressionSyntax).Token.ValueText;
                            var cmdletNoun = (cmdletAttribute.ArgumentList.Arguments[1].Expression as LiteralExpressionSyntax).Token.ValueText;
                            var cmdletName = $"{cmdletVerb}-{cmdletNoun}";
                            var cmdletInfo = new AdvancedCmdletInfo();
                            advancedCmdlets.Add(cmdletName, cmdletInfo);

                            var awsCmdletAttribute = attributes.FirstOrDefault(attr => GetAttributeName(attr) == "AWSCmdlet");
                            var operationNameAttribute = awsCmdletAttribute?.ArgumentList.Arguments.Where(arg => arg.NameEquals?.Name.Identifier.ValueText == "Operation").FirstOrDefault() as AttributeArgumentSyntax;
                            var operationNames = (operationNameAttribute?.Expression as ImplicitArrayCreationExpressionSyntax)?.Initializer.Expressions.OfType<LiteralExpressionSyntax>().Select(expr => expr.Token.ValueText);
                            if (operationNames != null)
                            {
                                cmdletInfo.OperationNames.AddRange(operationNames);
                            }

                            if (argumentCompleters != null)
                            {
                                foreach (var prop in cls.Members.OfType<PropertyDeclarationSyntax>())
                                {
                                    var propertyAttributes = prop.AttributeLists.SelectMany(al => al.Attributes).ToArray();
                                    if (propertyAttributes.Any(attr => GetAttributeName(attr) == "Parameter"))
                                    {
                                        var awsConstantClassSourceAttribute = propertyAttributes.FirstOrDefault(attr => GetAttributeName(attr) == "AWSConstantClassSource");
                                        if (awsConstantClassSourceAttribute != null)
                                        {
                                            var constantType = (awsConstantClassSourceAttribute.ArgumentList.Arguments[0].Expression as LiteralExpressionSyntax).Token.ValueText;
                                            var propertyName = prop.Identifier.ValueText;

                                            if (!argumentCompleters.IsConstantClassRegistered(constantType))
                                            {
                                                var propertyType = ServiceAssembly.GetType(constantType);
                                                var members = SimplePropertyInfo.GetConstantClassMembers(propertyType);
                                                argumentCompleters.AddConstantClass(constantType, members);
                                            }
                                            argumentCompleters.AddConstantClassReference(constantType, propertyName, cmdletName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidDataException($"Error parsing advanced cmdlet file {sourceFile}", e);
            }
        }

        private static string GetAttributeName(AttributeSyntax attributeSyntax)
        {
            switch (attributeSyntax.Name)
            {
                case IdentifierNameSyntax idName:
                    return idName.Identifier.Text;
                case QualifiedNameSyntax qName:
                    return qName.ChildNodes().OfType<IdentifierNameSyntax>().FirstOrDefault()?.Identifier.Text;
                default:
                    return null;
            }
        }
    }
}
