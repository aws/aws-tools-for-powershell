/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.BedrockAgent;
using Amazon.BedrockAgent.Model;

namespace Amazon.PowerShell.Cmdlets.AAB
{
    /// <summary>
    /// Retrieves information about the working draft (<c>DRAFT</c> version) of a prompt or
    /// a version of it, depending on whether you include the <c>promptVersion</c> field or
    /// not. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-management-manage.html#prompt-management-view.html">View
    /// information about prompts using Prompt management</a> and <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/prompt-management-deploy.html#prompt-management-versions-view.html">View
    /// information about a version of your prompt</a> in the Amazon Bedrock User Guide.
    /// </summary>
    [Cmdlet("Get", "AABPrompt")]
    [OutputType("Amazon.BedrockAgent.Model.GetPromptResponse")]
    [AWSCmdlet("Calls the Agents for Amazon Bedrock GetPrompt API operation.", Operation = new[] {"GetPrompt"}, SelectReturnType = typeof(Amazon.BedrockAgent.Model.GetPromptResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgent.Model.GetPromptResponse",
        "This cmdlet returns an Amazon.BedrockAgent.Model.GetPromptResponse object containing multiple properties."
    )]
    public partial class GetAABPromptCmdlet : AmazonBedrockAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PromptIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the prompt.</para>
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
        public System.String PromptIdentifier { get; set; }
        #endregion
        
        #region Parameter PromptVersion
        /// <summary>
        /// <para>
        /// <para>The version of the prompt about which you want to retrieve information. Omit this
        /// field to return information about the working draft of the prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PromptVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgent.Model.GetPromptResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgent.Model.GetPromptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PromptIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PromptIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PromptIdentifier' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgent.Model.GetPromptResponse, GetAABPromptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PromptIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PromptIdentifier = this.PromptIdentifier;
            #if MODULAR
            if (this.PromptIdentifier == null && ParameterWasBound(nameof(this.PromptIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter PromptIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PromptVersion = this.PromptVersion;
            
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
            var request = new Amazon.BedrockAgent.Model.GetPromptRequest();
            
            if (cmdletContext.PromptIdentifier != null)
            {
                request.PromptIdentifier = cmdletContext.PromptIdentifier;
            }
            if (cmdletContext.PromptVersion != null)
            {
                request.PromptVersion = cmdletContext.PromptVersion;
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
        
        private Amazon.BedrockAgent.Model.GetPromptResponse CallAWSServiceOperation(IAmazonBedrockAgent client, Amazon.BedrockAgent.Model.GetPromptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Agents for Amazon Bedrock", "GetPrompt");
            try
            {
                #if DESKTOP
                return client.GetPrompt(request);
                #elif CORECLR
                return client.GetPromptAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String PromptIdentifier { get; set; }
            public System.String PromptVersion { get; set; }
            public System.Func<Amazon.BedrockAgent.Model.GetPromptResponse, GetAABPromptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
