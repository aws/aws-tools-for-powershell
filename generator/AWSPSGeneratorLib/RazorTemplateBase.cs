using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWSPowerShellGenerator
{
    public abstract class RazorTemplateBase<T> where T : RazorTemplateBase<T>
    {
        protected TextWriter Output = null;
        private readonly SemaphoreSlim Lock = new SemaphoreSlim(1);
        private static readonly ConcurrentDictionary<Type, Type> GeneratorsCache = new ConcurrentDictionary<Type, Type>();

        public async Task<string> RunAsync()
        {
            await Lock.WaitAsync();
            try
            {
                Output = new StringWriter();
                await ExecuteAsync();
                return Output.ToString();
            }
            finally
            {
                Lock.Release();
            }
        }

        public abstract Task ExecuteAsync();

        public static T CreateGenerator()
        {
            var generatorType = GeneratorsCache.GetOrAdd(typeof(T), CreateGeneratorType);
            return (T)generatorType.GetConstructor(new Type[0]).Invoke(new object[0]);
        }

        private static Type CreateGeneratorType(Type _)
        {
            var name = typeof(T).FullName;

            var metadataReferences = GetMetadataReferences();

            RazorSourceDocument document;
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{name}.razor"))
            {
                if (stream == null)
                {
                    throw new Exception($"Could not find embedded resource {name}.razor");
                }
                using (var reader = new StreamReader(stream))
                {
                    document = RazorSourceDocument.Create(reader.ReadToEnd(), $"{name}.razor");
                }
            }

#pragma warning disable CS0618 //Create and Register are marked as obsolete but there aren't alternative available
            var engine = RazorEngine.Create(b =>
            {
                FunctionsDirective.Register(b);
                InheritsDirective.Register(b);
#pragma warning restore CS0618             
            });
            RazorCodeDocument codeDocument = RazorCodeDocument.Create(document);
            engine.Process(codeDocument);
            string code;
            using (var srcFileWriter = new StringWriter())
            {
                code = codeDocument.GetCSharpDocument().GeneratedCode;
            }

            SourceText sourceText = SourceText.From(code, Encoding.UTF8);
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceText, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest));
            CSharpCompilationOptions compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
                .WithSpecificDiagnosticOptions(new Dictionary<string, ReportDiagnostic> {
                    // Binding redirects
                    ["CS1701"] = ReportDiagnostic.Suppress,
                    ["CS1702"] = ReportDiagnostic.Suppress,
                    ["CS1705"] = ReportDiagnostic.Suppress,
                    ["CS8019"] = ReportDiagnostic.Suppress })
                .WithUsings("System");
            CSharpCompilation compilation = CSharpCompilation.Create(typeof(T).FullName, new List<SyntaxTree> { syntaxTree }, metadataReferences, compilationOptions);

            Assembly assembly;
            EmitOptions emitOptions = new EmitOptions(debugInformationFormat: DebugInformationFormat.PortablePdb);
            using (MemoryStream assemblyStream = new MemoryStream())
            {
                using (MemoryStream pdbStream = new MemoryStream())
                {
                    var emitResult = compilation.Emit(
                        assemblyStream,
                        pdbStream,
                        options: emitOptions);

                    if (!emitResult.Success)
                    {
                        throw new Exception("Compilation error: " + string.Join("; ", emitResult.Diagnostics.Select(d => d.ToString())));
                    }

                    assemblyStream.Seek(0, SeekOrigin.Begin);
                    pdbStream.Seek(0, SeekOrigin.Begin);

                    assembly = Assembly.Load(assemblyStream.ToArray(), pdbStream.ToArray());
                }
            }

            var generatorType = assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(T))).Single();
            return generatorType;
        }

        private static List<MetadataReference> GetMetadataReferences()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => !assembly.IsDynamic && !string.IsNullOrWhiteSpace(assembly.Location))
                .Select(assembly => MetadataReference.CreateFromFile(assembly.Location))
                .ToList<MetadataReference>();
        }

        protected static string FormatCSharp(string code)
        {
            var sourceText = SourceText.From(code, Encoding.UTF8);
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceText, CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.Latest));
            var formattedNode = syntaxTree.GetRoot().NormalizeWhitespace();
            return formattedNode.ToFullString();
        }

        public virtual void WriteLiteral(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                Output.Write(value);
            }
        }

        protected virtual void Write(object value) => WriteLiteral(value?.ToString());

        protected virtual void WriteLiteral(object value) => WriteLiteral(value?.ToString());

        protected string attributeEnd;

        protected void BeginWriteAttribute(string name, string begining, int startPosition, string ending, int endPosition, int thingy)
        {
            if (attributeEnd != null)
                throw new Exception("Wrong state for BeginWriteAttribute");
            WriteLiteral(begining);
            attributeEnd = ending;
        }

        protected void WriteAttributeValue(
            string prefix,
            int prefixOffset,
            object value,
            int valueOffset,
            int valueLength,
            bool isLiteral)
        {
            if (attributeEnd == null)
                throw new Exception("Wrong state for WriteAttributeValue");
            if (isLiteral)
                WriteLiteral(value);
            else
                Write(value);
        }
        protected virtual void EndWriteAttribute()
        {
            if (attributeEnd == null)
                throw new Exception("Wrong state for EndWriteAttribute");
            WriteLiteral(attributeEnd);
            attributeEnd = null;
        }
    }
}
