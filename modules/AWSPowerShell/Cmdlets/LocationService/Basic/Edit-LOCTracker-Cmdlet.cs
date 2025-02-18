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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Updates the specified properties of a given tracker resource.
    /// </summary>
    [Cmdlet("Edit", "LOCTracker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.UpdateTrackerResponse")]
    [AWSCmdlet("Calls the Amazon Location Service UpdateTracker API operation.", Operation = new[] {"UpdateTracker"}, SelectReturnType = typeof(Amazon.LocationService.Model.UpdateTrackerResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.UpdateTrackerResponse",
        "This cmdlet returns an Amazon.LocationService.Model.UpdateTrackerResponse object containing multiple properties."
    )]
    public partial class EditLOCTrackerCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Updates the description for the tracker resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBridgeEnabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable position <c>UPDATE</c> events from this tracker to be sent to EventBridge.</para><note><para>You do not need enable this feature to get <c>ENTER</c> and <c>EXIT</c> events for
        /// geofences with this tracker. Those events are always sent to EventBridge.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EventBridgeEnabled { get; set; }
        #endregion
        
        #region Parameter KmsKeyEnableGeospatialQuery
        /// <summary>
        /// <para>
        /// <para>Enables <c>GeospatialQueries</c> for a tracker that uses a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keys.html">Amazon
        /// Web Services KMS customer managed key</a>.</para><para>This parameter is only used if you are using a KMS customer managed key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KmsKeyEnableGeospatialQueries")]
        public System.Boolean? KmsKeyEnableGeospatialQuery { get; set; }
        #endregion
        
        #region Parameter PositionFiltering
        /// <summary>
        /// <para>
        /// <para>Updates the position filtering for the tracker resource.</para><para>Valid values:</para><ul><li><para><c>TimeBased</c> - Location updates are evaluated against linked geofence collections,
        /// but not every location update is stored. If your update frequency is more often than
        /// 30 seconds, only one update per 30 seconds is stored for each unique device ID. </para></li><li><para><c>DistanceBased</c> - If the device has moved less than 30 m (98.4 ft), location
        /// updates are ignored. Location updates within this distance are neither evaluated against
        /// linked geofence collections, nor stored. This helps control costs by reducing the
        /// number of geofence evaluations and historical device positions to paginate through.
        /// Distance-based filtering can also reduce the effects of GPS noise when displaying
        /// device trajectories on a map. </para></li><li><para><c>AccuracyBased</c> - If the device has moved less than the measured accuracy, location
        /// updates are ignored. For example, if two consecutive updates from a device have a
        /// horizontal accuracy of 5 m and 10 m, the second update is ignored if the device has
        /// moved less than 15 m. Ignored location updates are neither evaluated against linked
        /// geofence collections, nor stored. This helps educe the effects of GPS noise when displaying
        /// device trajectories on a map, and can help control costs by reducing the number of
        /// geofence evaluations. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.PositionFiltering")]
        public Amazon.LocationService.PositionFiltering PositionFiltering { get; set; }
        #endregion
        
        #region Parameter TrackerName
        /// <summary>
        /// <para>
        /// <para>The name of the tracker resource to update.</para>
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
        public System.String TrackerName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.UpdateTrackerResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.UpdateTrackerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrackerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-LOCTracker (UpdateTracker)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.UpdateTrackerResponse, EditLOCTrackerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EventBridgeEnabled = this.EventBridgeEnabled;
            context.KmsKeyEnableGeospatialQuery = this.KmsKeyEnableGeospatialQuery;
            context.PositionFiltering = this.PositionFiltering;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlan = this.PricingPlan;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlanDataSource = this.PricingPlanDataSource;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TrackerName = this.TrackerName;
            #if MODULAR
            if (this.TrackerName == null && ParameterWasBound(nameof(this.TrackerName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrackerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.UpdateTrackerRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBridgeEnabled != null)
            {
                request.EventBridgeEnabled = cmdletContext.EventBridgeEnabled.Value;
            }
            if (cmdletContext.KmsKeyEnableGeospatialQuery != null)
            {
                request.KmsKeyEnableGeospatialQueries = cmdletContext.KmsKeyEnableGeospatialQuery.Value;
            }
            if (cmdletContext.PositionFiltering != null)
            {
                request.PositionFiltering = cmdletContext.PositionFiltering;
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
            if (cmdletContext.TrackerName != null)
            {
                request.TrackerName = cmdletContext.TrackerName;
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
        
        private Amazon.LocationService.Model.UpdateTrackerResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.UpdateTrackerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "UpdateTracker");
            try
            {
                return client.UpdateTrackerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? EventBridgeEnabled { get; set; }
            public System.Boolean? KmsKeyEnableGeospatialQuery { get; set; }
            public Amazon.LocationService.PositionFiltering PositionFiltering { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            [System.ObsoleteAttribute]
            public System.String PricingPlanDataSource { get; set; }
            public System.String TrackerName { get; set; }
            public System.Func<Amazon.LocationService.Model.UpdateTrackerResponse, EditLOCTrackerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
