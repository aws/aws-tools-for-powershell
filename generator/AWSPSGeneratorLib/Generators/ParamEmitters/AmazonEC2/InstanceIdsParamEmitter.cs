using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.ServiceConfig;
using AWSPowerShellGenerator.Writers;
using AWSPowerShellGenerator.Writers.SourceCode;

namespace AWSPowerShellGenerator.Generators.ParamEmitters.AmazonEC2
{
    /// <summary>
    /// Emitter for parameters named 'InstanceIds' declared to take a generic collection of strings in the sdk.
    /// It converts the parameter to 'object[] InstanceIds', with alias 'Instance' to match other calls. The parameter 
    /// can accept collections of reservations or instance objects or string-type instance ids.
    /// </summary>
    internal class InstanceIdsParamEmitter : IParamEmitter
    {
        public void WriteParams(IndentedTextWriter writer, OperationAnalyzer analyzer, SimplePropertyInfo spi, Param param)
        {
            writer.WriteLine(DocumentationUtils.CommentDocumentation(spi.MemberDocumentation/*FlattenedDocumentation*/));
            CmdletSourceWriter.WriteParamAttribute(writer, analyzer, spi, param);
            CmdletSourceWriter.WriteParamAliases(writer, analyzer, spi);
            writer.WriteLine("public object[] {0} {{ get; set; }}", spi.CmdletParameterName);
        }

        public void WriteContextMembers(IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, Param paramCustomization)
        {
            var contextMember = string.Format("{0}.{1}", contextVar, spi.CmdletParameterName);

            writer.WriteLine("if (this.{0} != null)", spi.CmdletParameterName);
            writer.OpenRegion();
            writer.WriteLine("{0} = AmazonEC2Helper.InstanceParamToIDs(this.{1});", contextMember, spi.CmdletParameterName);
            writer.CloseRegion();
            writer.WriteLine();
        }
    }
}
