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
    /// Updates the specified properties of a given geofence collection.
    /// </summary>
    [Cmdlet("Edit", "LOCGeofenceCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.UpdateGeofenceCollectionResponse")]
    [AWSCmdlet("Calls the Amazon Location Service UpdateGeofenceCollection API operation.", Operation = new[] {"UpdateGeofenceCollection"}, SelectReturnType = typeof(Amazon.LocationService.Model.UpdateGeofenceCollectionResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.UpdateGeofenceCollectionResponse",
        "This cmdlet returns an Amazon.LocationService.Model.UpdateGeofenceCollectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditLOCGeofenceCollectionCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CollectionName
        /// <summary>
        /// <para>
        /// <para>The name of the geofence collection to update.</para>
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
        public System.String CollectionName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Updates the description for the geofence collection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>No longer used. If included, the only allowed value is <code>RequestBasedUsage</code>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated. If included, the only allowed value is RequestBasedUsage.")]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter PricingPlanDataSource
        /// <summary>
        /// <para>
        /// <para>This parameter is no longer used.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated. No longer allowed.")]
        public System.String PricingPlanDataSource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.UpdateGeofenceCollectionResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.UpdateGeofenceCollectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CollectionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CollectionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CollectionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-LOCGeofenceCollection (UpdateGeofenceCollection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.UpdateGeofenceCollectionResponse, EditLOCGeofenceCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CollectionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CollectionName = this.CollectionName;
            #if MODULAR
            if (this.CollectionName == null && ParameterWasBound(nameof(this.CollectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlan = this.PricingPlan;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlanDataSource = this.PricingPlanDataSource;
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
            var request = new Amazon.LocationService.Model.UpdateGeofenceCollectionRequest();
            
            if (cmdletContext.CollectionName != null)
            {
                request.CollectionName = cmdletContext.CollectionName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PricingPlanDataSource != null)
            {
                request.PricingPlanDataSource = cmdletContext.PricingPlanDataSource;
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
        
        private Amazon.LocationService.Model.UpdateGeofenceCollectionResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.UpdateGeofenceCollectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "UpdateGeofenceCollection");
            try
            {
                #if DESKTOP
                return client.UpdateGeofenceCollection(request);
                #elif CORECLR
                return client.UpdateGeofenceCollectionAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionName { get; set; }
            public System.String Description { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            [System.ObsoleteAttribute]
            public System.String PricingPlanDataSource { get; set; }
            public System.Func<Amazon.LocationService.Model.UpdateGeofenceCollectionResponse, EditLOCGeofenceCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
