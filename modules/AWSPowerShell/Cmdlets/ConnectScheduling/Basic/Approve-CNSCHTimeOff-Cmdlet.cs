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
    /// Approves a time off request. Evaluates agent time off balances and group time off
    /// allowances before approving. <c>RuleFailureAction</c> controls what happens when these
    /// evaluations fail. The request is rejected with <c>CONFLICTING_TIME_OFF_REQUEST</c>
    /// if it overlaps another time off request for the user that is <c>APPROVED</c> or being
    /// approved.
    /// 
    ///  
    /// <para>
    /// The time off request is processed asynchronously, so a successful call doesn't indicate
    /// the final status. Read the resulting status with <c>GetTimeOff</c> or from the time
    /// off state-change events.
    /// </para><para>
    /// Approving an <c>APPROVED</c> request succeeds without a change. Approving a <c>REJECTED</c>
    /// request evaluates the rules again, so it can end <c>APPROVED</c> or <c>REJECTED</c>,
    /// and repeating the call can give a different result. Check the status with <c>GetTimeOff</c>
    /// before you retry.
    /// </para><para>
    /// Returns <c>ConflictException</c> if the request is <c>PENDING</c> or <c>CANCELLED</c>.
    /// <c>PENDING</c> means Connect Customer is still processing the request asynchronously.
    /// Wait until <c>GetTimeOff</c> returns a status other than <c>PENDING</c>, and then
    /// retry.
    /// </para><important><para>
    /// When the approval succeeds, Connect Customer cancels any overtime or voluntary time
    /// off activity that overlaps the approved window.
    /// </para></important><note><para>
    /// Connect Customer doesn't check whether the principal that calls this operation supervises
    /// the user. The staffing group's approval settings also don't apply. IAM permissions
    /// are the only control. If you allow a principal to call this operation, that principal
    /// can send <c>RuleFailureAction</c><c>OVERRIDE</c> and approve a request past failed
    /// rules. Grant permission for this operation only to principals that you trust to override
    /// time off rules.
    /// </para></note>
    /// </summary>
    [Cmdlet("Approve", "CNSCHTimeOff", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Scheduling ApproveTimeOff API operation.", Operation = new[] {"ApproveTimeOff"}, SelectReturnType = typeof(Amazon.ConnectScheduling.Model.ApproveTimeOffResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectScheduling.Model.ApproveTimeOffResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectScheduling.Model.ApproveTimeOffResponse) be returned by specifying '-Select *'."
    )]
    public partial class ApproveCNSCHTimeOffCmdlet : AmazonConnectSchedulingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description recorded with the approval. <c>GetTimeOff</c> doesn't return it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
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
        /// an <c>ERROR</c> and leaves the request <c>REJECTED</c>. <c>OVERRIDE</c> records a
        /// <c>WARNING</c> and approves the request, like the <i>Override time off rules</i> option
        /// in the Connect Customer admin website. <c>OVERRIDE</c> never waives <c>CONFLICTING_TIME_OFF_REQUEST</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectScheduling.RuleFailureAction")]
        public Amazon.ConnectScheduling.RuleFailureAction RuleFailureAction { get; set; }
        #endregion
        
        #region Parameter TimeOffId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the time off request to approve. If the time off request
        /// doesn't belong to <c>UserId</c>, the operation returns <c>ResourceNotFoundException</c>.</para>
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
        public System.String TimeOffId { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user who the time off request belongs to. This can be the ID
        /// or the ARN of the user.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectScheduling.Model.ApproveTimeOffResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TimeOffId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-CNSCHTimeOff (ApproveTimeOff)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectScheduling.Model.ApproveTimeOffResponse, ApproveCNSCHTimeOffCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleFailureAction = this.RuleFailureAction;
            context.TimeOffId = this.TimeOffId;
            #if MODULAR
            if (this.TimeOffId == null && ParameterWasBound(nameof(this.TimeOffId)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeOffId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectScheduling.Model.ApproveTimeOffRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.RuleFailureAction != null)
            {
                request.RuleFailureAction = cmdletContext.RuleFailureAction;
            }
            if (cmdletContext.TimeOffId != null)
            {
                request.TimeOffId = cmdletContext.TimeOffId;
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
        
        private Amazon.ConnectScheduling.Model.ApproveTimeOffResponse CallAWSServiceOperation(IAmazonConnectScheduling client, Amazon.ConnectScheduling.Model.ApproveTimeOffRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Scheduling", "ApproveTimeOff");
            try
            {
                return client.ApproveTimeOffAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public Amazon.ConnectScheduling.RuleFailureAction RuleFailureAction { get; set; }
            public System.String TimeOffId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.ConnectScheduling.Model.ApproveTimeOffResponse, ApproveCNSCHTimeOffCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
