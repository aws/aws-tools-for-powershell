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
    /// Creates a map resource in your AWS account, which provides map tiles of different
    /// styles sourced from global location data providers.
    /// </summary>
    [Cmdlet("New", "LOCMap", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.CreateMapResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CreateMap API operation.", Operation = new[] {"CreateMap"}, SelectReturnType = typeof(Amazon.LocationService.Model.CreateMapResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CreateMapResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CreateMapResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewLOCMapCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the map resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MapName
        /// <summary>
        /// <para>
        /// <para>The name for the map resource.</para><para>Requirements:</para><ul><li><para>Must contain only alphanumeric characters (A–Z, a–z, 0–9), hyphens (-), periods (.),
        /// and underscores (_). </para></li><li><para>Must be a unique map resource name. </para></li><li><para>No spaces allowed. For example, <code>ExampleMap</code>.</para></li></ul>
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
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>Specifies the pricing plan for your map resource.</para><para>For additional details and restrictions on each pricing plan option, see <a href="https://aws.amazon.com/location/pricing/">Amazon
        /// Location Service pricing</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter Configuration_Style
        /// <summary>
        /// <para>
        /// <para>Specifies the map style selected from an available data provider.</para><para>Valid <a href="https://docs.aws.amazon.com/location/latest/developerguide/esri.html">Esri
        /// map styles</a>:</para><ul><li><para><code>VectorEsriDarkGrayCanvas</code> – The Esri Dark Gray Canvas map style. A vector
        /// basemap with a dark gray, neutral background with minimal colors, labels, and features
        /// that's designed to draw attention to your thematic content. </para></li><li><para><code>RasterEsriImagery</code> – The Esri Imagery map style. A raster basemap that
        /// provides one meter or better satellite and aerial imagery in many parts of the world
        /// and lower resolution satellite imagery worldwide. </para></li><li><para><code>VectorEsriLightGrayCanvas</code> – The Esri Light Gray Canvas map style, which
        /// provides a detailed vector basemap with a light gray, neutral background style with
        /// minimal colors, labels, and features that's designed to draw attention to your thematic
        /// content. </para></li><li><para><code>VectorEsriTopographic</code> – The Esri Light map style, which provides a detailed
        /// vector basemap with a classic Esri map style.</para></li><li><para><code>VectorEsriStreets</code> – The Esri World Streets map style, which provides
        /// a detailed vector basemap for the world symbolized with a classic Esri street map
        /// style. The vector tile layer is similar in content and style to the World Street Map
        /// raster map.</para></li><li><para><code>VectorEsriNavigation</code> – The Esri World Navigation map style, which provides
        /// a detailed basemap for the world symbolized with a custom navigation map style that's
        /// designed for use during the day in mobile devices.</para></li></ul><para>Valid <a href="https://docs.aws.amazon.com/location/latest/developerguide/HERE.html">HERE
        /// Technologies map styles</a>:</para><ul><li><para><code>VectorHereBerlin</code> – The HERE Berlin map style is a high contrast detailed
        /// base map of the world that blends 3D and 2D rendering.</para><note><para>When using HERE as your data provider, and selecting the Style <code>VectorHereBerlin</code>,
        /// you may not use HERE Technologies maps for Asset Management. See the <a href="https://aws.amazon.com/service-terms/">AWS
        /// Service Terms</a> for Amazon Location Service.</para></note></li></ul>
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
        public System.String Configuration_Style { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to the map resource. A tag is a key-value pair helps manage,
        /// identify, search, and filter your resources by labelling them.</para><para>Format: <code>"key" : "value"</code></para><para>Restrictions:</para><ul><li><para>Maximum 50 tags per resource</para></li><li><para>Each resource tag must be unique with a maximum of one value.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8</para></li><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9), and the following characters: + -
        /// = . _ : / @. </para></li><li><para>Cannot use "aws:" as a prefix for a key.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CreateMapResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CreateMapResponse will result in that property being returned.
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
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MapName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOCMap (CreateMap)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CreateMapResponse, NewLOCMapCmdlet>(Select) ??
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
            context.Configuration_Style = this.Configuration_Style;
            #if MODULAR
            if (this.Configuration_Style == null && ParameterWasBound(nameof(this.Configuration_Style)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Style which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.MapName = this.MapName;
            #if MODULAR
            if (this.MapName == null && ParameterWasBound(nameof(this.MapName)))
            {
                WriteWarning("You are passing $null as a value for parameter MapName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PricingPlan = this.PricingPlan;
            #if MODULAR
            if (this.PricingPlan == null && ParameterWasBound(nameof(this.PricingPlan)))
            {
                WriteWarning("You are passing $null as a value for parameter PricingPlan which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.LocationService.Model.CreateMapRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.LocationService.Model.MapConfiguration();
            System.String requestConfiguration_configuration_Style = null;
            if (cmdletContext.Configuration_Style != null)
            {
                requestConfiguration_configuration_Style = cmdletContext.Configuration_Style;
            }
            if (requestConfiguration_configuration_Style != null)
            {
                request.Configuration.Style = requestConfiguration_configuration_Style;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MapName != null)
            {
                request.MapName = cmdletContext.MapName;
            }
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LocationService.Model.CreateMapResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CreateMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CreateMap");
            try
            {
                #if DESKTOP
                return client.CreateMap(request);
                #elif CORECLR
                return client.CreateMapAsync(request).GetAwaiter().GetResult();
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
            public System.String Configuration_Style { get; set; }
            public System.String Description { get; set; }
            public System.String MapName { get; set; }
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LocationService.Model.CreateMapResponse, NewLOCMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
