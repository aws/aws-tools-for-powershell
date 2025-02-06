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
    /// Returns the map's glyphs.
    /// </summary>
    [Cmdlet("Get", "GEOMGlyph")]
    [OutputType("Amazon.GeoMaps.Model.GetGlyphsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Maps V2 GetGlyphs API operation.", Operation = new[] {"GetGlyphs"}, SelectReturnType = typeof(Amazon.GeoMaps.Model.GetGlyphsResponse))]
    [AWSCmdletOutput("Amazon.GeoMaps.Model.GetGlyphsResponse",
        "This cmdlet returns an Amazon.GeoMaps.Model.GetGlyphsResponse object containing multiple properties."
    )]
    public partial class GetGEOMGlyphCmdlet : AmazonGeoMapsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FontStack
        /// <summary>
        /// <para>
        /// <para>Name of the <c>FontStack</c> to retrieve. </para><para>Example: <c>Amazon Ember Bold,Noto Sans Bold</c>.</para><para>The supported font stacks are as follows:</para><ul><li><para>Amazon Ember Bold</para></li><li><para>Amazon Ember Bold Italic</para></li><li><para>Amazon Ember Bold,Noto Sans Bold</para></li><li><para>Amazon Ember Bold,Noto Sans Bold,Noto Sans Arabic Bold</para></li><li><para>Amazon Ember Condensed RC BdItalic</para></li><li><para>Amazon Ember Condensed RC Bold</para></li><li><para>Amazon Ember Condensed RC Bold Italic</para></li><li><para>Amazon Ember Condensed RC Bold,Noto Sans Bold</para></li><li><para>Amazon Ember Condensed RC Bold,Noto Sans Bold,Noto Sans Arabic Condensed Bold</para></li><li><para>Amazon Ember Condensed RC Light</para></li><li><para>Amazon Ember Condensed RC Light Italic</para></li><li><para>Amazon Ember Condensed RC LtItalic</para></li><li><para>Amazon Ember Condensed RC Regular</para></li><li><para>Amazon Ember Condensed RC Regular Italic</para></li><li><para>Amazon Ember Condensed RC Regular,Noto Sans Regular</para></li><li><para>Amazon Ember Condensed RC Regular,Noto Sans Regular,Noto Sans Arabic Condensed Regular</para></li><li><para>Amazon Ember Condensed RC RgItalic</para></li><li><para>Amazon Ember Condensed RC ThItalic</para></li><li><para>Amazon Ember Condensed RC Thin</para></li><li><para>Amazon Ember Condensed RC Thin Italic</para></li><li><para>Amazon Ember Heavy</para></li><li><para>Amazon Ember Heavy Italic</para></li><li><para>Amazon Ember Light</para></li><li><para>Amazon Ember Light Italic</para></li><li><para>Amazon Ember Medium</para></li><li><para>Amazon Ember Medium Italic</para></li><li><para>Amazon Ember Medium,Noto Sans Medium</para></li><li><para>Amazon Ember Medium,Noto Sans Medium,Noto Sans Arabic Medium</para></li><li><para>Amazon Ember Regular</para></li><li><para>Amazon Ember Regular Italic</para></li><li><para>Amazon Ember Regular Italic,Noto Sans Italic</para></li><li><para>Amazon Ember Regular Italic,Noto Sans Italic,Noto Sans Arabic Regular</para></li><li><para>Amazon Ember Regular,Noto Sans Regular</para></li><li><para>Amazon Ember Regular,Noto Sans Regular,Noto Sans Arabic Regular</para></li><li><para>Amazon Ember Thin</para></li><li><para>Amazon Ember Thin Italic</para></li><li><para>AmazonEmberCdRC_Bd</para></li><li><para>AmazonEmberCdRC_BdIt</para></li><li><para>AmazonEmberCdRC_Lt</para></li><li><para>AmazonEmberCdRC_LtIt</para></li><li><para>AmazonEmberCdRC_Rg</para></li><li><para>AmazonEmberCdRC_RgIt</para></li><li><para>AmazonEmberCdRC_Th</para></li><li><para>AmazonEmberCdRC_ThIt</para></li><li><para>AmazonEmber_Bd</para></li><li><para>AmazonEmber_BdIt</para></li><li><para>AmazonEmber_He</para></li><li><para>AmazonEmber_HeIt</para></li><li><para>AmazonEmber_Lt</para></li><li><para>AmazonEmber_LtIt</para></li><li><para>AmazonEmber_Md</para></li><li><para>AmazonEmber_MdIt</para></li><li><para>AmazonEmber_Rg</para></li><li><para>AmazonEmber_RgIt</para></li><li><para>AmazonEmber_Th</para></li><li><para>AmazonEmber_ThIt</para></li><li><para>Noto Sans Black</para></li><li><para>Noto Sans Black Italic</para></li><li><para>Noto Sans Bold</para></li><li><para>Noto Sans Bold Italic</para></li><li><para>Noto Sans Extra Bold</para></li><li><para>Noto Sans Extra Bold Italic</para></li><li><para>Noto Sans Extra Light</para></li><li><para>Noto Sans Extra Light Italic</para></li><li><para>Noto Sans Italic</para></li><li><para>Noto Sans Light</para></li><li><para>Noto Sans Light Italic</para></li><li><para>Noto Sans Medium</para></li><li><para>Noto Sans Medium Italic</para></li><li><para>Noto Sans Regular</para></li><li><para>Noto Sans Semi Bold</para></li><li><para>Noto Sans Semi Bold Italic</para></li><li><para>Noto Sans Thin</para></li><li><para>Noto Sans Thin Italic</para></li><li><para>NotoSans-Bold</para></li><li><para>NotoSans-Italic</para></li><li><para>NotoSans-Medium</para></li><li><para>NotoSans-Regular</para></li><li><para>Open Sans Regular,Arial Unicode MS Regular</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FontStack { get; set; }
        #endregion
        
        #region Parameter FontUnicodeRange
        /// <summary>
        /// <para>
        /// <para>A Unicode range of characters to download glyphs for. This must be aligned to multiples
        /// of 256. </para><para>Example: <c>0-255.pdf</c></para>
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
        public System.String FontUnicodeRange { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoMaps.Model.GetGlyphsResponse).
        /// Specifying the name of a property of type Amazon.GeoMaps.Model.GetGlyphsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FontStack parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FontStack' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FontStack' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GeoMaps.Model.GetGlyphsResponse, GetGEOMGlyphCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FontStack;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FontStack = this.FontStack;
            #if MODULAR
            if (this.FontStack == null && ParameterWasBound(nameof(this.FontStack)))
            {
                WriteWarning("You are passing $null as a value for parameter FontStack which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FontUnicodeRange = this.FontUnicodeRange;
            #if MODULAR
            if (this.FontUnicodeRange == null && ParameterWasBound(nameof(this.FontUnicodeRange)))
            {
                WriteWarning("You are passing $null as a value for parameter FontUnicodeRange which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GeoMaps.Model.GetGlyphsRequest();
            
            if (cmdletContext.FontStack != null)
            {
                request.FontStack = cmdletContext.FontStack;
            }
            if (cmdletContext.FontUnicodeRange != null)
            {
                request.FontUnicodeRange = cmdletContext.FontUnicodeRange;
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
        
        private Amazon.GeoMaps.Model.GetGlyphsResponse CallAWSServiceOperation(IAmazonGeoMaps client, Amazon.GeoMaps.Model.GetGlyphsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Maps V2", "GetGlyphs");
            try
            {
                #if DESKTOP
                return client.GetGlyphs(request);
                #elif CORECLR
                return client.GetGlyphsAsync(request).GetAwaiter().GetResult();
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
            public System.String FontStack { get; set; }
            public System.String FontUnicodeRange { get; set; }
            public System.Func<Amazon.GeoMaps.Model.GetGlyphsResponse, GetGEOMGlyphCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
