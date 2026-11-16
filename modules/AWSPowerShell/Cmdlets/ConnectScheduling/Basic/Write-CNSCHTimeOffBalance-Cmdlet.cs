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
    /// Sets the time off balance for one user and shift activity. The value replaces the
    /// existing balance rather than adjusting it, so you can safely retry the call. This
    /// operation can't remove a balance. To remove one, upload a blank balance in the Connect
    /// Customer admin website. For more information, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/upload-timeoff-balance.html">Import
    /// an agent's time off balance</a> in the <i>Connect Customer Administrator Guide</i>.
    /// </summary>
    [Cmdlet("Write", "CNSCHTimeOffBalance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Scheduling PutTimeOffBalance API operation.", Operation = new[] {"PutTimeOffBalance"}, SelectReturnType = typeof(Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCNSCHTimeOffBalanceCmdlet : AmazonConnectSchedulingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter ShiftActivityId
        /// <summary>
        /// <para>
        /// <para>The identifier of the shift activity that the balance applies to. This can be the
        /// ID or the ARN of the shift activity.</para>
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
        
        #region Parameter Balance_Unit
        /// <summary>
        /// <para>
        /// <para>The unit the value is counted in.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConnectScheduling.DurationUnit")]
        public Amazon.ConnectScheduling.DurationUnit Balance_Unit { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user whose balance is being updated. This can be the ID or the
        /// ARN of the user.</para>
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
        
        #region Parameter Balance_Value
        /// <summary>
        /// <para>
        /// <para>The number of units of time. You can use a negative value to report an overdrawn balance.
        /// The value must be within 876,000 hours (100 years) of zero: at most 52,560,000 <c>MINUTES</c>,
        /// 876,000 <c>HOURS</c>, or 36,500 <c>DAYS</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Balance_Value { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.InstanceId),
                nameof(this.ShiftActivityId),
                nameof(this.UserId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CNSCHTimeOffBalance (PutTimeOffBalance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse, WriteCNSCHTimeOffBalanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Balance_Unit = this.Balance_Unit;
            #if MODULAR
            if (this.Balance_Unit == null && ParameterWasBound(nameof(this.Balance_Unit)))
            {
                WriteWarning("You are passing $null as a value for parameter Balance_Unit which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Balance_Value = this.Balance_Value;
            #if MODULAR
            if (this.Balance_Value == null && ParameterWasBound(nameof(this.Balance_Value)))
            {
                WriteWarning("You are passing $null as a value for parameter Balance_Value which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShiftActivityId = this.ShiftActivityId;
            #if MODULAR
            if (this.ShiftActivityId == null && ParameterWasBound(nameof(this.ShiftActivityId)))
            {
                WriteWarning("You are passing $null as a value for parameter ShiftActivityId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectScheduling.Model.PutTimeOffBalanceRequest();
            
            
             // populate Balance
            var requestBalanceIsNull = true;
            request.Balance = new Amazon.ConnectScheduling.Model.Duration();
            Amazon.ConnectScheduling.DurationUnit requestBalance_balance_Unit = null;
            if (cmdletContext.Balance_Unit != null)
            {
                requestBalance_balance_Unit = cmdletContext.Balance_Unit;
            }
            if (requestBalance_balance_Unit != null)
            {
                request.Balance.Unit = requestBalance_balance_Unit;
                requestBalanceIsNull = false;
            }
            System.Int32? requestBalance_balance_Value = null;
            if (cmdletContext.Balance_Value != null)
            {
                requestBalance_balance_Value = cmdletContext.Balance_Value.Value;
            }
            if (requestBalance_balance_Value != null)
            {
                request.Balance.Value = requestBalance_balance_Value.Value;
                requestBalanceIsNull = false;
            }
             // determine if request.Balance should be set to null
            if (requestBalanceIsNull)
            {
                request.Balance = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.ShiftActivityId != null)
            {
                request.ShiftActivityId = cmdletContext.ShiftActivityId;
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
        
        private Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse CallAWSServiceOperation(IAmazonConnectScheduling client, Amazon.ConnectScheduling.Model.PutTimeOffBalanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Scheduling", "PutTimeOffBalance");
            try
            {
                return client.PutTimeOffBalanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ConnectScheduling.DurationUnit Balance_Unit { get; set; }
            public System.Int32? Balance_Value { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ShiftActivityId { get; set; }
            public System.String UserId { get; set; }
            public System.Func<Amazon.ConnectScheduling.Model.PutTimeOffBalanceResponse, WriteCNSCHTimeOffBalanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
