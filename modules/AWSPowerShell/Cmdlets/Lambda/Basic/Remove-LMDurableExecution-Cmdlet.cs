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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Deletes a completed Lambda <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-functions.html">durable
    /// execution</a> and its data. The execution must be in a terminal state (<c>SUCCEEDED</c>,
    /// <c>FAILED</c>, <c>STOPPED</c>, or <c>TIMED_OUT</c>). Otherwise, this operation returns
    /// a <c>ResourceConflictException</c>.
    /// 
    ///  
    /// <para>
    /// The execution has <c>DELETING</c> status until the deletion finishes. For more information,
    /// see <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-delete.html">Deleting
    /// durable executions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "LMDurableExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("System.DateTime")]
    [AWSCmdlet("Calls the AWS Lambda DeleteDurableExecution API operation.", Operation = new[] {"DeleteDurableExecution"}, SelectReturnType = typeof(Amazon.Lambda.Model.DeleteDurableExecutionResponse))]
    [AWSCmdletOutput("System.DateTime or Amazon.Lambda.Model.DeleteDurableExecutionResponse",
        "This cmdlet returns a collection of System.DateTime objects.",
        "The service call response (type Amazon.Lambda.Model.DeleteDurableExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveLMDurableExecutionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurableExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the durable execution.</para>
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
        public System.String DurableExecutionArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeletionRequestTimestamp'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.DeleteDurableExecutionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.DeleteDurableExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeletionRequestTimestamp";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DurableExecutionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LMDurableExecution (DeleteDurableExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.DeleteDurableExecutionResponse, RemoveLMDurableExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DurableExecutionArn = this.DurableExecutionArn;
            #if MODULAR
            if (this.DurableExecutionArn == null && ParameterWasBound(nameof(this.DurableExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DurableExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Lambda.Model.DeleteDurableExecutionRequest();
            
            if (cmdletContext.DurableExecutionArn != null)
            {
                request.DurableExecutionArn = cmdletContext.DurableExecutionArn;
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
        
        private Amazon.Lambda.Model.DeleteDurableExecutionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.DeleteDurableExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "DeleteDurableExecution");
            try
            {
                return client.DeleteDurableExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DurableExecutionArn { get; set; }
            public System.Func<Amazon.Lambda.Model.DeleteDurableExecutionResponse, RemoveLMDurableExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeletionRequestTimestamp;
        }
        
    }
}
