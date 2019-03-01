using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AWSPowerShellGenerator.Generators.ParamEmitters.AmazonS3
{
    internal class AccelerateParamEmitter : IParamEmitter
    {
        public void WriteParams(Writers.IndentedTextWriter writer, Analysis.OperationAnalyzer analyzer, SimplePropertyInfo spi, ServiceConfig.Param paramCustomization)
        {
            writer.WriteLine("#region Parameter UseAccelerateEndpoint");
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.");
            writer.WriteLine("/// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). ");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[Parameter]");
            writer.WriteLine("public SwitchParameter UseAccelerateEndpoint { get; set; }");
            writer.WriteLine();
            writer.WriteLine("#endregion");
        }

        public void WriteContextMembers(Writers.IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, ServiceConfig.Param paramCustomization)
        {
            // No need to emit context members because UseAccelerateEndpoint is set on the S3Config object.
        }
    }
}
