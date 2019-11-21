using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.Writers;
using AWSPowerShellGenerator.ServiceConfig;

namespace AWSPowerShellGenerator.Generators.ParamEmitters.AmazonS3
{
    internal class S3StorageClassParamEmitter : IParamEmitter
    {
        public void WriteParams(IndentedTextWriter writer, OperationAnalyzer analyzer, SimplePropertyInfo spi, ServiceConfig.Param param)
        {
            // for S3StorageClass, we replace the enum type with two string switches instead
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Specifies the STANDARD storage class, which is the default storage class for S3 objects.");
            writer.WriteLine("/// Provides a 99.999999999% durability guarantee.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
            writer.WriteLine("public SwitchParameter StandardStorage { get; set; }");
            writer.WriteLine();

            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Specifies S3 should use REDUCED_REDUNDANCY storage class for the object. This");
            writer.WriteLine("/// provides a reduced (99.99%) durability guarantee at a lower");
            writer.WriteLine("/// cost as compared to the STANDARD storage class. Use this");
            writer.WriteLine("/// storage class for non-mission critical data or for data");
            writer.WriteLine("/// that doesn’t require the higher level of durability that S3");
            writer.WriteLine("/// provides with the STANDARD storage class.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]");
            writer.WriteLine("public SwitchParameter ReducedRedundancyStorage { get; set; }");
        }

        public void WriteContextMembers(IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, Param paramCustomization)
        {
            string contextMember = string.Format("{0}.{1}", contextVar, spi.CmdletParameterName);

            writer.WriteLine("if (this.StandardStorage.IsPresent)");
            writer.OpenRegion();
            {
                writer.WriteLine("{0} = S3StorageClass.Standard;", contextMember);
            }
            writer.CloseRegion();
            writer.WriteLine("else if (this.ReducedRedundancyStorage.IsPresent)");
            writer.OpenRegion();
            {
                writer.WriteLine("{0} = S3StorageClass.ReducedRedundancy;", contextMember);
            }
            writer.CloseRegion();
            writer.WriteLine();
        }
    }
}
