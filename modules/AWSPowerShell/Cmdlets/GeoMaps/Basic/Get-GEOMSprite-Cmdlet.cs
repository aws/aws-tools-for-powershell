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
using Amazon.GeoMaps;
using Amazon.GeoMaps.Model;

namespace Amazon.PowerShell.Cmdlets.GEOM
{
    /// <summary>
    /// <c>GetSprites</c> returns the map's sprites.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/styling-iconography-with-sprites.html">Style
    /// iconography with sprites</a> in the <i>Amazon Location Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GEOMSprite")]
    [OutputType("Amazon.GeoMaps.Model.GetSpritesResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Maps V2 GetSprites API operation.", Operation = new[] {"GetSprites"}, SelectReturnType = typeof(Amazon.GeoMaps.Model.GetSpritesResponse))]
    [AWSCmdletOutput("Amazon.GeoMaps.Model.GetSpritesResponse",
        "This cmdlet returns an Amazon.GeoMaps.Model.GetSpritesResponse object containing multiple properties."
    )]
    public partial class GetGEOMSpriteCmdlet : AmazonGeoMapsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ColorScheme
        /// <summary>
        /// <para>
        /// <para>Sets color tone for map such as dark and light for specific map styles. It applies
        /// to only vector map styles such as Standard and Monochrome.</para><para>Example: <c>Light</c></para><para>Default value: <c>Light</c></para><note><para>Valid values for ColorScheme are case sensitive.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GeoMaps.ColorScheme")]
        public Amazon.GeoMaps.ColorScheme ColorScheme { get; set; }
        #endregion
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para><c>Sprites</c> API: The name of the sprite ﬁle to retrieve, following pattern <c>sprites(@2x)?\.(png|json)</c>.</para><para>Example: <c>sprites.png</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter Style
        /// <summary>
        /// <para>
        /// <para>Style specifies the desired map style for the <c>Sprites</c> APIs.</para>
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
        
        #region Parameter Variant
        /// <summary>
        /// <para>
        /// <para>Optimizes map styles for specific use case or industry. You can choose allowed variant
        /// only with Standard map style.</para><para>Example: <c>Default</c></para><note><para>Valid values for Variant are case sensitive.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GeoMaps.Variant")]
        public Amazon.GeoMaps.Variant Variant { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoMaps.Model.GetSpritesResponse).
        /// Specifying the name of a property of type Amazon.GeoMaps.Model.GetSpritesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Style parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Style' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Style' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoMaps.Model.GetSpritesResponse, GetGEOMSpriteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Style;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ColorScheme = this.ColorScheme;
            #if MODULAR
            if (this.ColorScheme == null && ParameterWasBound(nameof(this.ColorScheme)))
            {
                WriteWarning("You are passing $null as a value for parameter ColorScheme which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Style = this.Style;
            #if MODULAR
            if (this.Style == null && ParameterWasBound(nameof(this.Style)))
            {
                WriteWarning("You are passing $null as a value for parameter Style which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Variant = this.Variant;
            #if MODULAR
            if (this.Variant == null && ParameterWasBound(nameof(this.Variant)))
            {
                WriteWarning("You are passing $null as a value for parameter Variant which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GeoMaps.Model.GetSpritesRequest();
            
            if (cmdletContext.ColorScheme != null)
            {
                request.ColorScheme = cmdletContext.ColorScheme;
            }
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.Style != null)
            {
                request.Style = cmdletContext.Style;
            }
            if (cmdletContext.Variant != null)
            {
                request.Variant = cmdletContext.Variant;
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
        
        private Amazon.GeoMaps.Model.GetSpritesResponse CallAWSServiceOperation(IAmazonGeoMaps client, Amazon.GeoMaps.Model.GetSpritesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Maps V2", "GetSprites");
            try
            {
                #if DESKTOP
                return client.GetSprites(request);
                #elif CORECLR
                return client.GetSpritesAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String FileName { get; set; }
            public Amazon.GeoMaps.MapStyle Style { get; set; }
            public Amazon.GeoMaps.Variant Variant { get; set; }
            public System.Func<Amazon.GeoMaps.Model.GetSpritesResponse, GetGEOMSpriteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
