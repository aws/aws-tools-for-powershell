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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Returns information about an execution of a pipeline, including details about artifacts,
    /// the pipeline execution ID, and the name, version, and status of the pipeline.
    /// </summary>
    [Cmdlet("Get", "CPPipelineExecution")]
    [OutputType("Amazon.CodePipeline.Model.PipelineExecution")]
    [AWSCmdlet("Calls the AWS CodePipeline GetPipelineExecution API operation.", Operation = new[] {"GetPipelineExecution"}, SelectReturnType = typeof(Amazon.CodePipeline.Model.GetPipelineExecutionResponse))]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.PipelineExecution or Amazon.CodePipeline.Model.GetPipelineExecutionResponse",
        "This cmdlet returns an Amazon.CodePipeline.Model.PipelineExecution object.",
        "The service call response (type Amazon.CodePipeline.Model.GetPipelineExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCPPipelineExecutionCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PipelineExecutionId
        /// <summary>
        /// <para>
        /// <para>The ID of the pipeline execution about which you want to get execution details.</para>
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
        public System.String PipelineExecutionId { get; set; }
        #endregion
        
        #region Parameter PipelineName
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline about which you want to get execution details.</para>
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
        public System.String PipelineName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'PipelineExecution'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodePipeline.Model.GetPipelineExecutionResponse).
        /// Specifying the name of a property of type Amazon.CodePipeline.Model.GetPipelineExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "PipelineExecution";
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
                context.Select = CreateSelectDelegate<Amazon.CodePipeline.Model.GetPipelineExecutionResponse, GetCPPipelineExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PipelineExecutionId = this.PipelineExecutionId;
            #if MODULAR
            if (this.PipelineExecutionId == null && ParameterWasBound(nameof(this.PipelineExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineName = this.PipelineName;
            #if MODULAR
            if (this.PipelineName == null && ParameterWasBound(nameof(this.PipelineName)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodePipeline.Model.GetPipelineExecutionRequest();
            
            if (cmdletContext.PipelineExecutionId != null)
            {
                request.PipelineExecutionId = cmdletContext.PipelineExecutionId;
            }
            if (cmdletContext.PipelineName != null)
            {
                request.PipelineName = cmdletContext.PipelineName;
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
        
        private Amazon.CodePipeline.Model.GetPipelineExecutionResponse CallAWSServiceOperation(IAmazonCodePipeline client, Amazon.CodePipeline.Model.GetPipelineExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodePipeline", "GetPipelineExecution");
            try
            {
                return client.GetPipelineExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String PipelineExecutionId { get; set; }
            public System.String PipelineName { get; set; }
            public System.Func<Amazon.CodePipeline.Model.GetPipelineExecutionResponse, GetCPPipelineExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.PipelineExecution;
        }
        
    }
}
