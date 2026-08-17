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
using Amazon.Drs;
using Amazon.Drs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Gets a Recovery Plan step by ARN.
    /// </summary>
    [Cmdlet("Get", "EDRSRecoveryPlanStep")]
    [OutputType("Amazon.Drs.Model.RecoveryPlanStep")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service GetRecoveryPlanStep API operation.", Operation = new[] {"GetRecoveryPlanStep"}, SelectReturnType = typeof(Amazon.Drs.Model.GetRecoveryPlanStepResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.RecoveryPlanStep or Amazon.Drs.Model.GetRecoveryPlanStepResponse",
        "This cmdlet returns an Amazon.Drs.Model.RecoveryPlanStep object.",
        "The service call response (type Amazon.Drs.Model.GetRecoveryPlanStepResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEDRSRecoveryPlanStepCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RecoveryPlanStepArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Recovery Plan step to retrieve.</para>
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
        public System.String RecoveryPlanStepArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecoveryPlanStep'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.GetRecoveryPlanStepResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.GetRecoveryPlanStepResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecoveryPlanStep";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.GetRecoveryPlanStepResponse, GetEDRSRecoveryPlanStepCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RecoveryPlanStepArn = this.RecoveryPlanStepArn;
            #if MODULAR
            if (this.RecoveryPlanStepArn == null && ParameterWasBound(nameof(this.RecoveryPlanStepArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryPlanStepArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Drs.Model.GetRecoveryPlanStepRequest();
            
            if (cmdletContext.RecoveryPlanStepArn != null)
            {
                request.RecoveryPlanStepArn = cmdletContext.RecoveryPlanStepArn;
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
        
        private Amazon.Drs.Model.GetRecoveryPlanStepResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.GetRecoveryPlanStepRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "GetRecoveryPlanStep");
            try
            {
                return client.GetRecoveryPlanStepAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RecoveryPlanStepArn { get; set; }
            public System.Func<Amazon.Drs.Model.GetRecoveryPlanStepResponse, GetEDRSRecoveryPlanStepCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecoveryPlanStep;
        }
        
    }
}
