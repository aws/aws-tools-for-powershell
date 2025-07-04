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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Evaluates device positions against the geofence geometries from a given geofence collection.
    /// 
    ///  
    /// <para>
    /// This operation always returns an empty response because geofences are asynchronously
    /// evaluated. The evaluation determines if the device has entered or exited a geofenced
    /// area, and then publishes one of the following events to Amazon EventBridge:
    /// </para><ul><li><para><c>ENTER</c> if Amazon Location determines that the tracked device has entered a
    /// geofenced area.
    /// </para></li><li><para><c>EXIT</c> if Amazon Location determines that the tracked device has exited a geofenced
    /// area.
    /// </para></li></ul><note><para>
    /// The last geofence that a device was observed within is tracked for 30 days after the
    /// most recent device position update.
    /// </para></note><note><para>
    /// Geofence evaluation uses the given device position. It does not account for the optional
    /// <c>Accuracy</c> of a <c>DevicePositionUpdate</c>.
    /// </para></note><note><para>
    /// The <c>DeviceID</c> is used as a string to represent the device. You do not need to
    /// have a <c>Tracker</c> associated with the <c>DeviceID</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Submit", "LOCGeofenceEvaluationBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.BatchEvaluateGeofencesResponse")]
    [AWSCmdlet("Calls the Amazon Location Service BatchEvaluateGeofences API operation.", Operation = new[] {"BatchEvaluateGeofences"}, SelectReturnType = typeof(Amazon.LocationService.Model.BatchEvaluateGeofencesResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.BatchEvaluateGeofencesResponse",
        "This cmdlet returns an Amazon.LocationService.Model.BatchEvaluateGeofencesResponse object containing multiple properties."
    )]
    public partial class SubmitLOCGeofenceEvaluationBatchCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CollectionName
        /// <summary>
        /// <para>
        /// <para>The geofence collection used in evaluating the position of devices against its geofences.</para>
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
        
        #region Parameter DevicePositionUpdate
        /// <summary>
        /// <para>
        /// <para>Contains device details for each device to be evaluated against the given geofence
        /// collection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DevicePositionUpdates")]
        public Amazon.LocationService.Model.DevicePositionUpdate[] DevicePositionUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.BatchEvaluateGeofencesResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.BatchEvaluateGeofencesResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Submit-LOCGeofenceEvaluationBatch (BatchEvaluateGeofences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.BatchEvaluateGeofencesResponse, SubmitLOCGeofenceEvaluationBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CollectionName = this.CollectionName;
            #if MODULAR
            if (this.CollectionName == null && ParameterWasBound(nameof(this.CollectionName)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DevicePositionUpdate != null)
            {
                context.DevicePositionUpdate = new List<Amazon.LocationService.Model.DevicePositionUpdate>(this.DevicePositionUpdate);
            }
            #if MODULAR
            if (this.DevicePositionUpdate == null && ParameterWasBound(nameof(this.DevicePositionUpdate)))
            {
                WriteWarning("You are passing $null as a value for parameter DevicePositionUpdate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.BatchEvaluateGeofencesRequest();
            
            if (cmdletContext.CollectionName != null)
            {
                request.CollectionName = cmdletContext.CollectionName;
            }
            if (cmdletContext.DevicePositionUpdate != null)
            {
                request.DevicePositionUpdates = cmdletContext.DevicePositionUpdate;
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
        
        private Amazon.LocationService.Model.BatchEvaluateGeofencesResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.BatchEvaluateGeofencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "BatchEvaluateGeofences");
            try
            {
                return client.BatchEvaluateGeofencesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.LocationService.Model.DevicePositionUpdate> DevicePositionUpdate { get; set; }
            public System.Func<Amazon.LocationService.Model.BatchEvaluateGeofencesResponse, SubmitLOCGeofenceEvaluationBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
