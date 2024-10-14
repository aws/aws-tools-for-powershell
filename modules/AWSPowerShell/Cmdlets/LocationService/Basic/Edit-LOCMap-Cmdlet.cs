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
    /// Updates the specified properties of a given map resource.
    /// </summary>
    [Cmdlet("Edit", "LOCMap", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.UpdateMapResponse")]
    [AWSCmdlet("Calls the Amazon Location Service UpdateMap API operation.", Operation = new[] {"UpdateMap"}, SelectReturnType = typeof(Amazon.LocationService.Model.UpdateMapResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.UpdateMapResponse",
        "This cmdlet returns an Amazon.LocationService.Model.UpdateMapResponse object containing multiple properties."
    )]
    public partial class EditLOCMapCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationUpdate_CustomLayer
        /// <summary>
        /// <para>
        /// <para>Specifies the custom layers for the style. Leave unset to not enable any custom layer,
        /// or, for styles that support custom layers, you can enable layer(s), such as POI layer
        /// for the VectorEsriNavigation style. Default is <c>unset</c>.</para><note><para>Not all map resources or styles support custom layers. See Custom Layers for more
        /// information.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationUpdate_CustomLayers")]
        public System.String[] ConfigurationUpdate_CustomLayer { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Updates the description for the map resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MapName
        /// <summary>
        /// <para>
        /// <para>The name of the map resource to update.</para>
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
        
        #region Parameter ConfigurationUpdate_PoliticalView
        /// <summary>
        /// <para>
        /// <para>Specifies the political view for the style. Set to an empty string to not use a political
        /// view, or, for styles that support specific political views, you can choose a view,
        /// such as <c>IND</c> for the Indian view.</para><note><para>Not all map resources or styles support political view styles. See <a href="https://docs.aws.amazon.com/location/latest/developerguide/map-concepts.html#political-views">Political
        /// views</a> for more information.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationUpdate_PoliticalView { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>No longer used. If included, the only allowed value is <c>RequestBasedUsage</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated. If included, the only allowed value is RequestBasedUsage.")]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.UpdateMapResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.UpdateMapResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MapName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-LOCMap (UpdateMap)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.UpdateMapResponse, EditLOCMapCmdlet>(Select) ??
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
            if (this.ConfigurationUpdate_CustomLayer != null)
            {
                context.ConfigurationUpdate_CustomLayer = new List<System.String>(this.ConfigurationUpdate_CustomLayer);
            }
            context.ConfigurationUpdate_PoliticalView = this.ConfigurationUpdate_PoliticalView;
            context.Description = this.Description;
            context.MapName = this.MapName;
            #if MODULAR
            if (this.MapName == null && ParameterWasBound(nameof(this.MapName)))
            {
                WriteWarning("You are passing $null as a value for parameter MapName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlan = this.PricingPlan;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.LocationService.Model.UpdateMapRequest();
            
            
             // populate ConfigurationUpdate
            var requestConfigurationUpdateIsNull = true;
            request.ConfigurationUpdate = new Amazon.LocationService.Model.MapConfigurationUpdate();
            List<System.String> requestConfigurationUpdate_configurationUpdate_CustomLayer = null;
            if (cmdletContext.ConfigurationUpdate_CustomLayer != null)
            {
                requestConfigurationUpdate_configurationUpdate_CustomLayer = cmdletContext.ConfigurationUpdate_CustomLayer;
            }
            if (requestConfigurationUpdate_configurationUpdate_CustomLayer != null)
            {
                request.ConfigurationUpdate.CustomLayers = requestConfigurationUpdate_configurationUpdate_CustomLayer;
                requestConfigurationUpdateIsNull = false;
            }
            System.String requestConfigurationUpdate_configurationUpdate_PoliticalView = null;
            if (cmdletContext.ConfigurationUpdate_PoliticalView != null)
            {
                requestConfigurationUpdate_configurationUpdate_PoliticalView = cmdletContext.ConfigurationUpdate_PoliticalView;
            }
            if (requestConfigurationUpdate_configurationUpdate_PoliticalView != null)
            {
                request.ConfigurationUpdate.PoliticalView = requestConfigurationUpdate_configurationUpdate_PoliticalView;
                requestConfigurationUpdateIsNull = false;
            }
             // determine if request.ConfigurationUpdate should be set to null
            if (requestConfigurationUpdateIsNull)
            {
                request.ConfigurationUpdate = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MapName != null)
            {
                request.MapName = cmdletContext.MapName;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.LocationService.Model.UpdateMapResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.UpdateMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "UpdateMap");
            try
            {
                #if DESKTOP
                return client.UpdateMap(request);
                #elif CORECLR
                return client.UpdateMapAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ConfigurationUpdate_CustomLayer { get; set; }
            public System.String ConfigurationUpdate_PoliticalView { get; set; }
            public System.String Description { get; set; }
            public System.String MapName { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            public System.Func<Amazon.LocationService.Model.UpdateMapResponse, EditLOCMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
