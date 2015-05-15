using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.Generators.ParamEmitters.AmazonS3
{
    internal class ProtocolParamEmitter : IParamEmitter
    {
        public void WriteParams(IndentedTextWriter writer, OperationAnalyzer analyzer, SimplePropertyInfo spi, CmdletConfig.Param param, ref int usedPositionalCount)
        {
            // replace the enum type with a string param instead and convert to enum member on execution
            writer.WriteLine("/// <summary>");
            writer.WriteLine("/// Specifies the protocol that will be used. Allowable values are 'HTTP' and 'HTTPS'.");
            writer.WriteLine("/// </summary>");
            writer.WriteLine("[System.Management.Automation.Parameter]");
            writer.WriteLine("public String {0} {{ get; set; }}", spi.CmdletParameterName);
        }

        public void WriteContextMembers(IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, Param paramCustomization)
        {
            string contextMember = string.Format("{0}.{1}", contextVar, spi.ContextParameterName);

            writer.WriteLine("if (!string.IsNullOrEmpty(this.{0}))", spi.CmdletParameterName);
            writer.OpenRegion();
            {
                writer.WriteLine("try");
                writer.OpenRegion();
                {
                    writer.WriteLine("{0} = (Protocol)Enum.Parse(typeof(Protocol), this.{1}, true);", contextMember, spi.CmdletParameterName);
                }
                writer.CloseRegion();
                writer.WriteLine("catch (ArgumentException e)");
                writer.OpenRegion();
                {
                    writer.WriteLine("string errMsg = \"Invalid parameter value; allowable values: \" + string.Join(\", \", Enum.GetNames(typeof(Protocol)));");
                    writer.WriteLine("this.ThrowArgumentError(errMsg, this.{0}, e);", spi.CmdletParameterName);
                }
                writer.CloseRegion();
            }
            writer.CloseRegion();
            writer.WriteLine();
        }
    }
}
