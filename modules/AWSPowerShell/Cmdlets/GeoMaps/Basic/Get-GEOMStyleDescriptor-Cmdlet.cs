/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.GeoMaps;
using Amazon.GeoMaps.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GEOM
{
    /// <summary>
    /// <c>GetStyleDescriptor</c> returns information about the style.
    /// </summary>
    [Cmdlet("Get", "GEOMStyleDescriptor")]
    [OutputType("Amazon.GeoMaps.Model.GetStyleDescriptorResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Maps V2 GetStyleDescriptor API operation.", Operation = new[] {"GetStyleDescriptor"}, SelectReturnType = typeof(Amazon.GeoMaps.Model.GetStyleDescriptorResponse))]
    [AWSCmdletOutput("Amazon.GeoMaps.Model.GetStyleDescriptorResponse",
        "This cmdlet returns an Amazon.GeoMaps.Model.GetStyleDescriptorResponse object containing multiple properties."
    )]
    public partial class GetGEOMStyleDescriptorCmdlet : AmazonGeoMapsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ColorScheme
        /// <summary>
        /// <para>
        /// <para>Sets color tone for map such as dark and light for specific map styles. It applies
        /// to only vector map styles such as Standard and Monochrome.</para><para>Example: <c>Light</c></para><para>Default value: <c>Light</c></para><note><para>Valid values for ColorScheme are case sensitive.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoMaps.ColorScheme")]
        public Amazon.GeoMaps.ColorScheme ColorScheme { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Optional: The API key to be used for authorization. Either an API key or valid SigV4
        /// signature must be provided when making a request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter PoliticalView
        /// <summary>
        /// <para>
        /// <para>Specifies the political view using ISO 3166-2 or ISO 3166-3 country code format.</para><para>The following political views are currently supported:</para><ul><li><para><c>ARG</c>: Argentina's view on the Southern Patagonian Ice Field and Tierra Del
        /// Fuego, including the Falkland Islands, South Georgia, and South Sandwich Islands</para></li><li><para><c>EGY</c>: Egypt's view on Bir Tawil</para></li><li><para><c>IND</c>: India's view on Gilgit-Baltistan</para></li><li><para><c>KEN</c>: Kenya's view on the Ilemi Triangle</para></li><li><para><c>MAR</c>: Morocco's view on Western Sahara</para></li><li><para><c>RUS</c>: Russia's view on Crimea</para></li><li><para><c>SDN</c>: Sudan's view on the Halaib Triangle</para></li><li><para><c>SRB</c>: Serbia's view on Kosovo, Vukovar, and Sarengrad Islands</para></li><li><para><c>SUR</c>: Suriname's view on the Courantyne Headwaters and Lawa Headwaters</para></li><li><para><c>SYR</c>: Syria's view on the Golan Heights</para></li><li><para><c>TUR</c>: Turkey's view on Cyprus and Northern Cyprus</para></li><li><para><c>TZA</c>: Tanzania's view on Lake Malawi</para></li><li><para><c>URY</c>: Uruguay's view on Rincon de Artigas</para></li><li><para><c>VNM</c>: Vietnam's view on the Paracel Islands and Spratly Islands</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PoliticalView { get; set; }
        #endregion
        
        #region Parameter Style
        /// <summary>
        /// <para>
        /// <para>Style specifies the desired map style.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GeoMaps.MapStyle")]
        public Amazon.GeoMaps.MapStyle Style { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoMaps.Model.GetStyleDescriptorResponse).
        /// Specifying the name of a property of type Amazon.GeoMaps.Model.GetStyleDescriptorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoMaps.Model.GetStyleDescriptorResponse, GetGEOMStyleDescriptorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ColorScheme = this.ColorScheme;
            context.Key = this.Key;
            context.PoliticalView = this.PoliticalView;
            context.Style = this.Style;
            #if MODULAR
            if (this.Style == null && ParameterWasBound(nameof(this.Style)))
            {
                WriteWarning("You are passing $null as a value for parameter Style which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GeoMaps.Model.GetStyleDescriptorRequest();
            
            if (cmdletContext.ColorScheme != null)
            {
                request.ColorScheme = cmdletContext.ColorScheme;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.PoliticalView != null)
            {
                request.PoliticalView = cmdletContext.PoliticalView;
            }
            if (cmdletContext.Style != null)
            {
                request.Style = cmdletContext.Style;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.GeoMaps.Model.GetStyleDescriptorResponse CallAWSServiceOperation(IAmazonGeoMaps client, Amazon.GeoMaps.Model.GetStyleDescriptorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Maps V2", "GetStyleDescriptor");
            try
            {
                return client.GetStyleDescriptorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public Amazon.GeoMaps.ColorScheme ColorScheme { get; set; }
            public System.String Key { get; set; }
            public System.String PoliticalView { get; set; }
            public Amazon.GeoMaps.MapStyle Style { get; set; }
            public System.Func<Amazon.GeoMaps.Model.GetStyleDescriptorResponse, GetGEOMStyleDescriptorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
