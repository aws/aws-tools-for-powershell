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
    /// Updates the reward values for a trajectory and transitions it to reward-received status,
    /// signaling that it is eligible for processing. Call this operation after CompleteRollout
    /// to provide the computed reward scores.
    /// </summary>
    [Cmdlet("Update", "SMJRReward", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Sagemaker Job Runtime Service UpdateReward API operation.", Operation = new[] {"UpdateReward"}, SelectReturnType = typeof(Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse))]
    [AWSCmdletOutput("None or Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMJRRewardCmdlet : AmazonSagemakerJobRuntimeClientCmdlet, IExecutor
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
        
        #region Parameter Reward
        /// <summary>
        /// <para>
        /// <para>The list of reward values to assign to this trajectory. Provide one reward value per
        /// turn in the trajectory.</para><para />
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
        [Alias("Rewards")]
        public System.Double[] Reward { get; set; }
        #endregion
        
        #region Parameter TrajectoryId
        /// <summary>
        /// <para>
        /// <para>The trajectory ID to update with reward values.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMJRReward (UpdateReward)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse, UpdateSMJRRewardCmdlet>(Select) ??
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
            if (this.Reward != null)
            {
                context.Reward = new List<System.Double>(this.Reward);
            }
            #if MODULAR
            if (this.Reward == null && ParameterWasBound(nameof(this.Reward)))
            {
                WriteWarning("You are passing $null as a value for parameter Reward which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SagemakerJobRuntime.Model.UpdateRewardRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.JobArn != null)
            {
                request.JobArn = cmdletContext.JobArn;
            }
            if (cmdletContext.Reward != null)
            {
                request.Rewards = cmdletContext.Reward;
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
        
        private Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse CallAWSServiceOperation(IAmazonSagemakerJobRuntime client, Amazon.SagemakerJobRuntime.Model.UpdateRewardRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Sagemaker Job Runtime Service", "UpdateReward");
            try
            {
                return client.UpdateRewardAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.Double> Reward { get; set; }
            public System.String TrajectoryId { get; set; }
            public System.Func<Amazon.SagemakerJobRuntime.Model.UpdateRewardResponse, UpdateSMJRRewardCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
