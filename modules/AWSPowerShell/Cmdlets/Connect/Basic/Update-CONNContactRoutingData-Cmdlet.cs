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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates routing priority and age on the contact (<b>QueuePriority</b> and <b>QueueTimeAdjustmentInSeconds</b>).
    /// These properties can be used to change a customer's position in the queue. For example,
    /// you can move a contact to the back of the queue by setting a lower routing priority
    /// relative to other contacts in queue; or you can move a contact to the front of the
    /// queue by increasing the routing age which will make the contact look artificially
    /// older and therefore higher up in the first-in-first-out routing order. Note that adjusting
    /// the routing age of a contact affects only its position in queue, and not its actual
    /// queue wait time as reported through metrics. These properties can also be updated
    /// by using <a href="https://docs.aws.amazon.com/connect/latest/adminguide/change-routing-priority.html">the
    /// Set routing priority / age flow block</a>.
    /// 
    ///  <note><para>
    /// Either <b>QueuePriority</b> or <b>QueueTimeAdjustmentInSeconds</b> should be provided
    /// within the request body, but not both.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CONNContactRoutingData", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateContactRoutingData API operation.", Operation = new[] {"UpdateContactRoutingData"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateContactRoutingDataResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateContactRoutingDataResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateContactRoutingDataResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNContactRoutingDataCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Amazon Connect. </para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter QueuePriority
        /// <summary>
        /// <para>
        /// <para>Priority of the contact in the queue. The default priority for new contacts is 5.
        /// You can raise the priority of a contact compared to other contacts in the queue by
        /// assigning them a higher priority, such as 1 or 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? QueuePriority { get; set; }
        #endregion
        
        #region Parameter QueueTimeAdjustmentSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds to add or subtract from the contact's routing age. Contacts
        /// are routed to agents on a first-come, first-serve basis. This means that changing
        /// their amount of time in queue compared to others also changes their position in queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueueTimeAdjustmentSeconds")]
        public System.Int32? QueueTimeAdjustmentSecond { get; set; }
        #endregion
        
        #region Parameter RoutingCriteria_Step
        /// <summary>
        /// <para>
        /// <para>When Amazon Connect does not find an available agent meeting the requirements in a
        /// step for a given step duration, the routing criteria will move on to the next step
        /// sequentially until a join is completed with an agent. When all steps are exhausted,
        /// the contact will be offered to any agent in the queue.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingCriteria_Steps")]
        public Amazon.Connect.Model.RoutingCriteriaInputStep[] RoutingCriteria_Step { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateContactRoutingDataResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNContactRoutingData (UpdateContactRoutingData)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateContactRoutingDataResponse, UpdateCONNContactRoutingDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueuePriority = this.QueuePriority;
            context.QueueTimeAdjustmentSecond = this.QueueTimeAdjustmentSecond;
            if (this.RoutingCriteria_Step != null)
            {
                context.RoutingCriteria_Step = new List<Amazon.Connect.Model.RoutingCriteriaInputStep>(this.RoutingCriteria_Step);
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
            var request = new Amazon.Connect.Model.UpdateContactRoutingDataRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.QueuePriority != null)
            {
                request.QueuePriority = cmdletContext.QueuePriority.Value;
            }
            if (cmdletContext.QueueTimeAdjustmentSecond != null)
            {
                request.QueueTimeAdjustmentSeconds = cmdletContext.QueueTimeAdjustmentSecond.Value;
            }
            
             // populate RoutingCriteria
            var requestRoutingCriteriaIsNull = true;
            request.RoutingCriteria = new Amazon.Connect.Model.RoutingCriteriaInput();
            List<Amazon.Connect.Model.RoutingCriteriaInputStep> requestRoutingCriteria_routingCriteria_Step = null;
            if (cmdletContext.RoutingCriteria_Step != null)
            {
                requestRoutingCriteria_routingCriteria_Step = cmdletContext.RoutingCriteria_Step;
            }
            if (requestRoutingCriteria_routingCriteria_Step != null)
            {
                request.RoutingCriteria.Steps = requestRoutingCriteria_routingCriteria_Step;
                requestRoutingCriteriaIsNull = false;
            }
             // determine if request.RoutingCriteria should be set to null
            if (requestRoutingCriteriaIsNull)
            {
                request.RoutingCriteria = null;
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
        
        private Amazon.Connect.Model.UpdateContactRoutingDataResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateContactRoutingDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateContactRoutingData");
            try
            {
                return client.UpdateContactRoutingDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int64? QueuePriority { get; set; }
            public System.Int32? QueueTimeAdjustmentSecond { get; set; }
            public List<Amazon.Connect.Model.RoutingCriteriaInputStep> RoutingCriteria_Step { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateContactRoutingDataResponse, UpdateCONNContactRoutingDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
