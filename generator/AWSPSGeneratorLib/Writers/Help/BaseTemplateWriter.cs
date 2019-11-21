using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AWSPowerShellGenerator.Generators;

namespace AWSPowerShellGenerator.Writers.Help
{
    public abstract class BaseTemplateWriter
    {
        public GeneratorOptions Options { get; private set; }
        public string OutputFolder { get; private set; }

        protected BaseTemplateWriter(GeneratorOptions options, string outputFolder)
        {
            Options = options;
            OutputFolder = outputFolder;
        }

        protected abstract string GetTemplateName();
        protected abstract String ReplaceTokens(String templateBody);

        public void Write()
        {
            var templateName = GetTemplateName();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AWSPowerShellGenerator.HelpMaterials.WebHelp.Templates." + templateName))
            using (var reader = new StreamReader(stream))
            {
                var templateBody = reader.ReadToEnd();
                var finalBody = ReplaceTokens(templateBody);

                var filename = Path.Combine(OutputFolder, templateName);
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(finalBody);
                }
            }
        }

    }
}
