using AWSPowerShellGenerator.Analysis;
using AWSPowerShellGenerator.CmdletConfig;
using AWSPowerShellGenerator.Writers;

namespace AWSPowerShellGenerator.Generators.ParamEmitters
{
    internal interface IParamEmitter
    {
        /// <summary>
        /// Called to write the custom parameters in place of the specified parameter. The implementor, if
        /// it chooses to write positional parameter data, should return the index of the last position
        /// used.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="analyzer"></param>
        /// <param name="spi"></param>
        /// <param name="paramCustomization"></param>
        /// <param name="usedPositionalCount">How many parameters have been tagged as positional (PS recommends no more than 5)</param>
        /// <remarks>
        /// Make sure we stick to the PS recommendation of no more than 5 positional parameters, not
        /// including any credentials or region parameters we get from the base cmdlet class.
        /// </remarks>
        void WriteParams(IndentedTextWriter writer, OperationAnalyzer analyzer, SimplePropertyInfo spi, Param paramCustomization, ref int usedPositionalCount);

        /// <summary>
        /// Populate the context member with values the user has assigned to the custom parameter(s)
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="contextVar"></param>
        /// <param name="spi"></param>
        /// <param name="paramCustomization"></param>
        void WriteContextMembers(IndentedTextWriter writer, string contextVar, SimplePropertyInfo spi, Param paramCustomization);
    }
}
