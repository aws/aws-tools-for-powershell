using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWSPowerShellGenerator.Generators.ParamEmitters.AmazonS3
{
    internal class DualstackParamEmitter : IParamEmitter
    {
        public void WriteParams(Writers.IndentedTextWriter writer, Analysis.OperationAnalyzer analyzer, SimplePropertyInfo spi, ServiceConfig.Param paramCustomization)
        {
            writer.WriteLine("#region Parameter UseDualstackEndpoint");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Configures the request to Amazon S3 to use the dualstack endpoint for a region.");
            writer.WriteLine("/// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.");
            writer.WriteLine("/// The dualstack mode of Amazon S3 cannot be used with accelerate mode.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[Parameter]");
            writer.WriteLine("public SwitchParameter UseDualstackEndpoint { get; set; }");
            writer.WriteLine();
            writer.WriteLine("#endregion");
        }

        public void WriteContextMembers(Writers.IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, ServiceConfig.Param paramCustomization)
        {
            // No need to emit context members because UseDualstackEndpoint is set on the S3Config object.
        }
    }
}
