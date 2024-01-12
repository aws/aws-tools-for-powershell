/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Retrieves glyphs used to display labels on a map.
    /// </summary>
    [Cmdlet("Get", "LOCMapGlyph")]
    [OutputType("Amazon.LocationService.Model.GetMapGlyphsResponse")]
    [AWSCmdlet("Calls the Amazon Location Service GetMapGlyphs API operation.", Operation = new[] {"GetMapGlyphs"}, SelectReturnType = typeof(Amazon.LocationService.Model.GetMapGlyphsResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.GetMapGlyphsResponse",
        "This cmdlet returns an Amazon.LocationService.Model.GetMapGlyphsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetLOCMapGlyphCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FontStack
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of fonts to load glyphs from in order of preference. For example,
        /// <c>Noto Sans Regular, Arial Unicode</c>.</para><para>Valid font stacks for <a href="https://docs.aws.amazon.com/location/latest/developerguide/esri.html">Esri</a>
        /// styles: </para><ul><li><para>VectorEsriDarkGrayCanvas – <c>Ubuntu Medium Italic</c> | <c>Ubuntu Medium</c> | <c>Ubuntu
        /// Italic</c> | <c>Ubuntu Regular</c> | <c>Ubuntu Bold</c></para></li><li><para>VectorEsriLightGrayCanvas – <c>Ubuntu Italic</c> | <c>Ubuntu Regular</c> | <c>Ubuntu
        /// Light</c> | <c>Ubuntu Bold</c></para></li><li><para>VectorEsriTopographic – <c>Noto Sans Italic</c> | <c>Noto Sans Regular</c> | <c>Noto
        /// Sans Bold</c> | <c>Noto Serif Regular</c> | <c>Roboto Condensed Light Italic</c></para></li><li><para>VectorEsriStreets – <c>Arial Regular</c> | <c>Arial Italic</c> | <c>Arial Bold</c></para></li><li><para>VectorEsriNavigation – <c>Arial Regular</c> | <c>Arial Italic</c> | <c>Arial Bold</c>
        /// | <c>Arial Unicode MS Bold</c> | <c>Arial Unicode MS Regular</c></para></li></ul><para>Valid font stacks for <a href="https://docs.aws.amazon.com/location/latest/developerguide/HERE.html">HERE
        /// Technologies</a> styles:</para><ul><li><para>VectorHereContrast – <c>Fira GO Regular</c> | <c>Fira GO Bold</c></para></li><li><para>VectorHereExplore, VectorHereExploreTruck, HybridHereExploreSatellite – <c>Fira GO
        /// Italic</c> | <c>Fira GO Map</c> | <c>Fira GO Map Bold</c> | <c>Noto Sans CJK JP Bold</c>
        /// | <c>Noto Sans CJK JP Light</c> | <c>Noto Sans CJK JP Regular</c></para></li></ul><para>Valid font stacks for <a href="https://docs.aws.amazon.com/location/latest/developerguide/grab.html">GrabMaps</a>
        /// styles:</para><ul><li><para>VectorGrabStandardLight, VectorGrabStandardDark – <c>Noto Sans Regular</c> | <c>Noto
        /// Sans Medium</c> | <c>Noto Sans Bold</c></para></li></ul><para>Valid font stacks for <a href="https://docs.aws.amazon.com/location/latest/developerguide/open-data.html">Open
        /// Data</a> styles:</para><ul><li><para>VectorOpenDataStandardLight, VectorOpenDataStandardDark, VectorOpenDataVisualizationLight,
        /// VectorOpenDataVisualizationDark – <c>Amazon Ember Regular,Noto Sans Regular</c> |
        /// <c>Amazon Ember Bold,Noto Sans Bold</c> | <c>Amazon Ember Medium,Noto Sans Medium</c>
        /// | <c>Amazon Ember Regular Italic,Noto Sans Italic</c> | <c>Amazon Ember Condensed
        /// RC Regular,Noto Sans Regular</c> | <c>Amazon Ember Condensed RC Bold,Noto Sans Bold</c>
        /// | <c>Amazon Ember Regular,Noto Sans Regular,Noto Sans Arabic Regular</c> | <c>Amazon
        /// Ember Condensed RC Bold,Noto Sans Bold,Noto Sans Arabic Condensed Bold</c> | <c>Amazon
        /// Ember Bold,Noto Sans Bold,Noto Sans Arabic Bold</c> | <c>Amazon Ember Regular Italic,Noto
        /// Sans Italic,Noto Sans Arabic Regular</c> | <c>Amazon Ember Condensed RC Regular,Noto
        /// Sans Regular,Noto Sans Arabic Condensed Regular</c> | <c>Amazon Ember Medium,Noto
        /// Sans Medium,Noto Sans Arabic Medium</c></para></li></ul><note><para>The fonts used by the Open Data map styles are combined fonts that use <c>Amazon Ember</c>
        /// for most glyphs but <c>Noto Sans</c> for glyphs unsupported by <c>Amazon Ember</c>.</para></note>
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
        public System.String FontStack { get; set; }
        #endregion
        
        #region Parameter FontUnicodeRange
        /// <summary>
        /// <para>
        /// <para>A Unicode range of characters to download glyphs for. Each response will contain 256
        /// characters. For example, 0–255 includes all characters from range <c>U+0000</c> to
        /// <c>00FF</c>. Must be aligned to multiples of 256.</para>
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
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The optional <a href="https://docs.aws.amazon.com/location/latest/developerguide/using-apikeys.html">API
        /// key</a> to authorize the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter MapName
        /// <summary>
        /// <para>
        /// <para>The map resource associated with the glyph ﬁle.</para>
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
        public System.String MapName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.GetMapGlyphsResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.GetMapGlyphsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MapName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MapName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MapName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.GetMapGlyphsResponse, GetLOCMapGlyphCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MapName;
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
            context.Key = this.Key;
            context.MapName = this.MapName;
            #if MODULAR
            if (this.MapName == null && ParameterWasBound(nameof(this.MapName)))
            {
                WriteWarning("You are passing $null as a value for parameter MapName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.GetMapGlyphsRequest();
            
            if (cmdletContext.FontStack != null)
            {
                request.FontStack = cmdletContext.FontStack;
            }
            if (cmdletContext.FontUnicodeRange != null)
            {
                request.FontUnicodeRange = cmdletContext.FontUnicodeRange;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.MapName != null)
            {
                request.MapName = cmdletContext.MapName;
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
        
        private Amazon.LocationService.Model.GetMapGlyphsResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.GetMapGlyphsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "GetMapGlyphs");
            try
            {
                #if DESKTOP
                return client.GetMapGlyphs(request);
                #elif CORECLR
                return client.GetMapGlyphsAsync(request).GetAwaiter().GetResult();
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
            public System.String Key { get; set; }
            public System.String MapName { get; set; }
            public System.Func<Amazon.LocationService.Model.GetMapGlyphsResponse, GetLOCMapGlyphCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
