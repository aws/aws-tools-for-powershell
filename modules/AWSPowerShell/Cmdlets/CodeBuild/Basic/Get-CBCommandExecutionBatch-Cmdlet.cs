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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Gets information about the command executions.
    /// </summary>
    [Cmdlet("Get", "CBCommandExecutionBatch")]
    [OutputType("Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse")]
    [AWSCmdlet("Calls the AWS CodeBuild BatchGetCommandExecutions API operation.", Operation = new[] {"BatchGetCommandExecutions"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse object containing multiple properties."
    )]
    public partial class GetCBCommandExecutionBatchCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CommandExecutionId
        /// <summary>
        /// <para>
        /// <para>A comma separated list of <c>commandExecutionIds</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CommandExecutionIds")]
        public System.String[] CommandExecutionId { get; set; }
        #endregion
        
        #region Parameter SandboxId
        /// <summary>
        /// <para>
        /// <para>A <c>sandboxId</c> or <c>sandboxArn</c>.</para>
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
        public System.String SandboxId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse, GetCBCommandExecutionBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CommandExecutionId != null)
            {
                context.CommandExecutionId = new List<System.String>(this.CommandExecutionId);
            }
            #if MODULAR
            if (this.CommandExecutionId == null && ParameterWasBound(nameof(this.CommandExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CommandExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SandboxId = this.SandboxId;
            #if MODULAR
            if (this.SandboxId == null && ParameterWasBound(nameof(this.SandboxId)))
            {
                WriteWarning("You are passing $null as a value for parameter SandboxId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeBuild.Model.BatchGetCommandExecutionsRequest();
            
            if (cmdletContext.CommandExecutionId != null)
            {
                request.CommandExecutionIds = cmdletContext.CommandExecutionId;
            }
            if (cmdletContext.SandboxId != null)
            {
                request.SandboxId = cmdletContext.SandboxId;
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
        
        private Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.BatchGetCommandExecutionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "BatchGetCommandExecutions");
            try
            {
                return client.BatchGetCommandExecutionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CommandExecutionId { get; set; }
            public System.String SandboxId { get; set; }
            public System.Func<Amazon.CodeBuild.Model.BatchGetCommandExecutionsResponse, GetCBCommandExecutionBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
