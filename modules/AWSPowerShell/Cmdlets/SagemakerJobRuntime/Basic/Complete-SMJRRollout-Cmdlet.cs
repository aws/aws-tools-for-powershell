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
using Amazon.SagemakerJobRuntime;
using Amazon.SagemakerJobRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMJR
{
    /// <summary>
    /// Marks a rollout as complete, indicating that no further turns will be appended to
    /// the trajectory. After calling this operation, the trajectory is sealed and eligible
    /// for reward submission via the UpdateReward operation.
    /// </summary>
    [Cmdlet("Complete", "SMJRRollout", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Sagemaker Job Runtime Service CompleteRollout API operation.", Operation = new[] {"CompleteRollout"}, SelectReturnType = typeof(Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse))]
    [AWSCmdletOutput("None or Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse) be returned by specifying '-Select *'."
    )]
    public partial class CompleteSMJRRolloutCmdlet : AmazonSagemakerJobRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobArn
        /// <summary>
        /// <para>
        /// <para>The job ARN.</para>
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
        public System.String JobArn { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The target status for the trajectory. Defaults to READY if not specified. Set to FAILED
        /// if the rollout encountered an error and the trajectory should not be used for processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SagemakerJobRuntime.CompletionStatus")]
        public Amazon.SagemakerJobRuntime.CompletionStatus Status { get; set; }
        #endregion
        
        #region Parameter TrajectoryId
        /// <summary>
        /// <para>
        /// <para>The trajectory ID to mark as complete.</para>
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
        public System.String TrajectoryId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse).
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
                nameof(this.TrajectoryId),
                nameof(this.JobArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Complete-SMJRRollout (CompleteRollout)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse, CompleteSMJRRolloutCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.JobArn = this.JobArn;
            #if MODULAR
            if (this.JobArn == null && ParameterWasBound(nameof(this.JobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter JobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            context.TrajectoryId = this.TrajectoryId;
            #if MODULAR
            if (this.TrajectoryId == null && ParameterWasBound(nameof(this.TrajectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrajectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SagemakerJobRuntime.Model.CompleteRolloutRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.JobArn != null)
            {
                request.JobArn = cmdletContext.JobArn;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TrajectoryId != null)
            {
                request.TrajectoryId = cmdletContext.TrajectoryId;
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
        
        private Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse CallAWSServiceOperation(IAmazonSagemakerJobRuntime client, Amazon.SagemakerJobRuntime.Model.CompleteRolloutRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Sagemaker Job Runtime Service", "CompleteRollout");
            try
            {
                return client.CompleteRolloutAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String JobArn { get; set; }
            public Amazon.SagemakerJobRuntime.CompletionStatus Status { get; set; }
            public System.String TrajectoryId { get; set; }
            public System.Func<Amazon.SagemakerJobRuntime.Model.CompleteRolloutResponse, CompleteSMJRRolloutCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
