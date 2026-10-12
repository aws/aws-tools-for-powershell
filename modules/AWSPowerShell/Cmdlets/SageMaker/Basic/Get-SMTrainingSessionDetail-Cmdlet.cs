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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Retrieves detailed information about a training session, including its current status,
    /// model configuration, Low-Rank Adaptation (LoRA) parameters, and timestamps.
    /// 
    ///  
    /// <para>
    /// The following operations are related to <c>DescribeTrainingSession</c>:
    /// </para><ul><li><para><c>CreateTrainingSession</c></para></li><li><para><c>ListTrainingSessions</c></para></li><li><para><c>StopTrainingSession</c></para></li><li><para><c>DeleteTrainingSession</c></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "SMTrainingSessionDetail")]
    [OutputType("Amazon.SageMaker.Model.TrainingSessionDetail")]
    [AWSCmdlet("Calls the Amazon SageMaker Service DescribeTrainingSession API operation.", Operation = new[] {"DescribeTrainingSession"}, SelectReturnType = typeof(Amazon.SageMaker.Model.DescribeTrainingSessionResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.TrainingSessionDetail or Amazon.SageMaker.Model.DescribeTrainingSessionResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.TrainingSessionDetail object.",
        "The service call response (type Amazon.SageMaker.Model.DescribeTrainingSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMTrainingSessionDetailCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TrainingSessionName
        /// <summary>
        /// <para>
        /// <para>The name of the training session to describe.</para>
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
        public System.String TrainingSessionName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrainingSessionDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.DescribeTrainingSessionResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.DescribeTrainingSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrainingSessionDetail";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.DescribeTrainingSessionResponse, GetSMTrainingSessionDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TrainingSessionName = this.TrainingSessionName;
            #if MODULAR
            if (this.TrainingSessionName == null && ParameterWasBound(nameof(this.TrainingSessionName)))
            {
                WriteWarning("You are passing $null as a value for parameter TrainingSessionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.DescribeTrainingSessionRequest();
            
            if (cmdletContext.TrainingSessionName != null)
            {
                request.TrainingSessionName = cmdletContext.TrainingSessionName;
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
        
        private Amazon.SageMaker.Model.DescribeTrainingSessionResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.DescribeTrainingSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "DescribeTrainingSession");
            try
            {
                return client.DescribeTrainingSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TrainingSessionName { get; set; }
            public System.Func<Amazon.SageMaker.Model.DescribeTrainingSessionResponse, GetSMTrainingSessionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrainingSessionDetail;
        }
        
    }
}
