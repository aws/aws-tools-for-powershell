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
using Amazon.ConnectScheduling;
using Amazon.ConnectScheduling.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CNSCH
{
    /// <summary>
    /// Creates a time off request for a user. You don't provide a status, because Connect
    /// Customer owns the request lifecycle. To get the decided status, call <c>GetTimeOff</c>
    /// or use the time off state-change events.
    /// 
    ///  
    /// <para><c>ApprovalType</c> controls who approves the request. You can specify one of the
    /// following values:
    /// </para><ul><li><para><c>AWAIT_APPROVAL</c>: the request waits in <c>AWAITING_APPROVAL</c> until you call
    /// <c>ApproveTimeOff</c> or <c>RejectTimeOff</c>. Rule evaluation and the overlap check
    /// run at approval, not at creation. A waiting request doesn't reserve its window, so
    /// another request for the same window can be approved first.
    /// </para></li><li><para><c>AUTOMATIC</c>: Connect Customer evaluates the rules (time off balances and group
    /// allowances) and decides the request. The request can be <c>PENDING</c> while Connect
    /// Customer decides, and then ends <c>APPROVED</c> or <c>REJECTED</c>. If it overlaps
    /// another time off request for the user, the requested time off ends <c>REJECTED</c>
    /// with <c>CONFLICTING_TIME_OFF_REQUEST</c>. It also ends <c>REJECTED</c> if it overlaps
    /// overtime or voluntary time off. If the whole window is in the past, Connect Customer
    /// records failed rules as <c>WARNING</c> and doesn't reject the request, whatever the
    /// <c>RuleFailureAction</c>.
    /// </para></li></ul><para>
    /// The staffing group's <i>Supervisor approval needed</i> setting doesn't apply to this
    /// operation. <c>ApprovalType</c> alone decides whether the request waits for approval.
    /// The operation fails with <c>ValidationException</c> on <c>UserId</c> in the following
    /// cases:
    /// </para><ul><li><para>
    /// The user isn't in a staffing group, or the staffing group isn't associated with a
    /// forecast group.
    /// </para></li><li><para>
    /// Time off isn't <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-to.html">enabled</a>
    /// for the user's staffing group, or the user's staff rules don't allow time off.
    /// </para></li></ul><para>
    /// To change the dates of a request, cancel it with <c>CancelTimeOff</c> and create a
    /// new request. The new request has a new <c>TimeOffId</c>.
    /// </para><note><para>
    /// Connect Customer doesn't check whether the principal that calls this operation supervises
    /// the user. The staffing group's approval settings also don't apply. IAM permissions
    /// are the only control. If you allow a principal to call this operation, that principal
    /// can send <c>ApprovalType</c><c>AUTOMATIC</c> with <c>RuleFailureAction</c><c>OVERRIDE</c>
    /// and approve a request past failed rules. Grant permission for this operation only
    /// to principals that you trust to override time off rules.
    /// </para></note><para>
    /// For information about time off in the Connect Customer admin website, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/scheduling-time-off.html">Time
    /// off management</a> in the <i>Connect Customer Administrator Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CNSCHTimeOff", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Scheduling CreateTimeOff API operation.", Operation = new[] {"CreateTimeOff"}, SelectReturnType = typeof(Amazon.ConnectScheduling.Model.CreateTimeOffResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConnectScheduling.Model.CreateTimeOffResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConnectScheduling.Model.CreateTimeOffResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCNSCHTimeOffCmdlet : AmazonConnectSchedulingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApprovalType
        /// <summary>
        /// <para>
        /// <para>Controls who approves the request. <c>AWAIT_APPROVAL</c> waits for an <c>ApproveTimeOff</c>
        /// or <c>RejectTimeOff</c> call. <c>AUTOMATIC</c> has Connect Customer decide the request.
        /// For details, see <c>CreateTimeOff</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConnectScheduling.ApprovalType")]
        public Amazon.ConnectScheduling.ApprovalType ApprovalType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description recorded on the time off request. If you omit it, the request has no
        /// description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EndAt
        /// <summary>
        /// <para>
        /// <para>The end of the time off window, exclusive. It must be after <c>StartAt</c> and no
        /// later than 24 months after the current date. Connect Customer stores the value as
        /// sent, to the millisecond.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndAt { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. This can be the ID or the ARN of
        /// the instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
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
        
        #region Parameter RuleFailureAction
        /// <summary>
        /// <para>
        /// <para>Controls what happens when a configured rule fails. <c>REJECT</c>, the default, records
        /// an <c>ERROR</c> and ends the request <c>REJECTED</c>, unless the whole window is in
        /// the past. <c>OVERRIDE</c> records a <c>WARNING</c> and ends the request <c>APPROVED</c>,
        /// like the <i>Override time off rules</i> option in the Connect Customer admin website.
        /// <c>OVERRIDE</c> requires <c>AUTOMATIC</c>. With <c>AWAIT_APPROVAL</c>, <c>OVERRIDE</c>
        /// fails with <c>ValidationException</c>. Set it on <c>ApproveTimeOff</c> instead. <c>OVERRIDE</c>
        /// never waives <c>CONFLICTING_TIME_OFF_REQUEST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectScheduling.RuleFailureAction")]
        public Amazon.ConnectScheduling.RuleFailureAction RuleFailureAction { get; set; }
        #endregion
        
        #region Parameter ShiftActivityId
        /// <summary>
        /// <para>
        /// <para>The identifier of the shift activity that defines the type of time off being requested.
        /// This can be the ID or the ARN of the shift activity. It must be a time off activity.
        /// Activities that aren't set as <i>Requestable</i> are accepted.</para>
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
        public System.String ShiftActivityId { get; set; }
        #endregion
        
        #region Parameter StartAt
        /// <summary>
        /// <para>
        /// <para>The start of the time off window, inclusive. It must be no earlier than one year before
        /// the current date. Connect Customer stores the value as sent, to the millisecond.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartAt { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user who the time off request is for. This can be the ID or
        /// the ARN of the user.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If this token matches a previous request, Connect
        /// Customer returns the result of that request and doesn't create another time off request.
        /// If you don't provide a token, the AWS SDK populates this field. If you reuse a client
        /// token with a different request body, the request fails with <c>ValidationException</c>.
        /// For more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TimeOffId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectScheduling.Model.CreateTimeOffResponse).
        /// Specifying the name of a property of type Amazon.ConnectScheduling.Model.CreateTimeOffResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TimeOffId";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.InstanceId),
                nameof(this.ShiftActivityId),
                nameof(this.UserId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CNSCHTimeOff (CreateTimeOff)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectScheduling.Model.CreateTimeOffResponse, NewCNSCHTimeOffCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApprovalType = this.ApprovalType;
            #if MODULAR
            if (this.ApprovalType == null && ParameterWasBound(nameof(this.ApprovalType)))
            {
                WriteWarning("You are passing $null as a value for parameter ApprovalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.EndAt = this.EndAt;
            #if MODULAR
            if (this.EndAt == null && ParameterWasBound(nameof(this.EndAt)))
            {
                WriteWarning("You are passing $null as a value for parameter EndAt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleFailureAction = this.RuleFailureAction;
            context.ShiftActivityId = this.ShiftActivityId;
            #if MODULAR
            if (this.ShiftActivityId == null && ParameterWasBound(nameof(this.ShiftActivityId)))
            {
                WriteWarning("You are passing $null as a value for parameter ShiftActivityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartAt = this.StartAt;
            #if MODULAR
            if (this.StartAt == null && ParameterWasBound(nameof(this.StartAt)))
            {
                WriteWarning("You are passing $null as a value for parameter StartAt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectScheduling.Model.CreateTimeOffRequest();
            
            if (cmdletContext.ApprovalType != null)
            {
                request.ApprovalType = cmdletContext.ApprovalType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EndAt != null)
            {
                request.EndAt = cmdletContext.EndAt.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.RuleFailureAction != null)
            {
                request.RuleFailureAction = cmdletContext.RuleFailureAction;
            }
            if (cmdletContext.ShiftActivityId != null)
            {
                request.ShiftActivityId = cmdletContext.ShiftActivityId;
            }
            if (cmdletContext.StartAt != null)
            {
                request.StartAt = cmdletContext.StartAt.Value;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
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
        
        private Amazon.ConnectScheduling.Model.CreateTimeOffResponse CallAWSServiceOperation(IAmazonConnectScheduling client, Amazon.ConnectScheduling.Model.CreateTimeOffRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Scheduling", "CreateTimeOff");
            try
            {
                return client.CreateTimeOffAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ConnectScheduling.ApprovalType ApprovalType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.DateTime? EndAt { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.ConnectScheduling.RuleFailureAction RuleFailureAction { get; set; }
            public System.String ShiftActivityId { get; set; }
            public System.DateTime? StartAt { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.ConnectScheduling.Model.CreateTimeOffResponse, NewCNSCHTimeOffCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TimeOffId;
        }
        
    }
}
