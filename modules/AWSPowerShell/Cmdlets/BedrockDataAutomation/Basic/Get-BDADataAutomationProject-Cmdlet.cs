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
using Amazon.BedrockDataAutomation;
using Amazon.BedrockDataAutomation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDA
{
    /// <summary>
    /// Gets an existing Amazon Bedrock Data Automation Project
    /// </summary>
    [Cmdlet("Get", "BDADataAutomationProject")]
    [OutputType("Amazon.BedrockDataAutomation.Model.DataAutomationProject")]
    [AWSCmdlet("Calls the Data Automation for Amazon Bedrock GetDataAutomationProject API operation.", Operation = new[] {"GetDataAutomationProject"}, SelectReturnType = typeof(Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomation.Model.DataAutomationProject or Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomation.Model.DataAutomationProject object.",
        "The service call response (type Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDADataAutomationProjectCmdlet : AmazonBedrockDataAutomationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para>ARN generated at the server side when a DataAutomationProject is created</para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter ProjectStage
        /// <summary>
        /// <para>
        /// <para>Optional field to delete a specific DataAutomationProject stage</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockDataAutomation.DataAutomationProjectStage")]
        public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectStage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Project'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Project";
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
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse, GetBDADataAutomationProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectStage = this.ProjectStage;
            
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
            var request = new Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectRequest();
            
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
            }
            if (cmdletContext.ProjectStage != null)
            {
                request.ProjectStage = cmdletContext.ProjectStage;
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
        
        private Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse CallAWSServiceOperation(IAmazonBedrockDataAutomation client, Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Data Automation for Amazon Bedrock", "GetDataAutomationProject");
            try
            {
                return client.GetDataAutomationProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProjectArn { get; set; }
            public Amazon.BedrockDataAutomation.DataAutomationProjectStage ProjectStage { get; set; }
            public System.Func<Amazon.BedrockDataAutomation.Model.GetDataAutomationProjectResponse, GetBDADataAutomationProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Project;
        }
        
    }
}
