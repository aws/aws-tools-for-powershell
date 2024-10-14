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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates an AI Prompt.
    /// </summary>
    [Cmdlet("Update", "QCAIPrompt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AIPromptData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateAIPrompt API operation.", Operation = new[] {"UpdateAIPrompt"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateAIPromptResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AIPromptData or Amazon.QConnect.Model.UpdateAIPromptResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AIPromptData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateAIPromptResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCAIPromptCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AiPromptId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect AI Prompt.</para>
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
        public System.String AiPromptId { get; set; }
        #endregion
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant. Can be either the ID or the ARN.
        /// URLs cannot contain the ARN.</para>
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
        public System.String AssistantId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Amazon Q in Connect AI Prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter TextFullAIPromptEditTemplateConfiguration_Text
        /// <summary>
        /// <para>
        /// <para>The YAML text for the AI Prompt template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemplateConfiguration_TextFullAIPromptEditTemplateConfiguration_Text")]
        public System.String TextFullAIPromptEditTemplateConfiguration_Text { get; set; }
        #endregion
        
        #region Parameter VisibilityStatus
        /// <summary>
        /// <para>
        /// <para>The visibility status of the Amazon Q in Connect AI prompt.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.VisibilityStatus")]
        public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the AWS SDK populates this field. For more information
        /// about idempotency, see <a href="http://aws.amazon.com/https:/aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AiPrompt'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateAIPromptResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateAIPromptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AiPrompt";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AiPromptId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AiPromptId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AiPromptId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AiPromptId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCAIPrompt (UpdateAIPrompt)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateAIPromptResponse, UpdateQCAIPromptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AiPromptId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AiPromptId = this.AiPromptId;
            #if MODULAR
            if (this.AiPromptId == null && ParameterWasBound(nameof(this.AiPromptId)))
            {
                WriteWarning("You are passing $null as a value for parameter AiPromptId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.TextFullAIPromptEditTemplateConfiguration_Text = this.TextFullAIPromptEditTemplateConfiguration_Text;
            context.VisibilityStatus = this.VisibilityStatus;
            #if MODULAR
            if (this.VisibilityStatus == null && ParameterWasBound(nameof(this.VisibilityStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.UpdateAIPromptRequest();
            
            if (cmdletContext.AiPromptId != null)
            {
                request.AiPromptId = cmdletContext.AiPromptId;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate TemplateConfiguration
            var requestTemplateConfigurationIsNull = true;
            request.TemplateConfiguration = new Amazon.QConnect.Model.AIPromptTemplateConfiguration();
            Amazon.QConnect.Model.TextFullAIPromptEditTemplateConfiguration requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration = null;
            
             // populate TextFullAIPromptEditTemplateConfiguration
            var requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfigurationIsNull = true;
            requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration = new Amazon.QConnect.Model.TextFullAIPromptEditTemplateConfiguration();
            System.String requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration_textFullAIPromptEditTemplateConfiguration_Text = null;
            if (cmdletContext.TextFullAIPromptEditTemplateConfiguration_Text != null)
            {
                requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration_textFullAIPromptEditTemplateConfiguration_Text = cmdletContext.TextFullAIPromptEditTemplateConfiguration_Text;
            }
            if (requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration_textFullAIPromptEditTemplateConfiguration_Text != null)
            {
                requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration.Text = requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration_textFullAIPromptEditTemplateConfiguration_Text;
                requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfigurationIsNull = false;
            }
             // determine if requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration should be set to null
            if (requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfigurationIsNull)
            {
                requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration = null;
            }
            if (requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration != null)
            {
                request.TemplateConfiguration.TextFullAIPromptEditTemplateConfiguration = requestTemplateConfiguration_templateConfiguration_TextFullAIPromptEditTemplateConfiguration;
                requestTemplateConfigurationIsNull = false;
            }
             // determine if request.TemplateConfiguration should be set to null
            if (requestTemplateConfigurationIsNull)
            {
                request.TemplateConfiguration = null;
            }
            if (cmdletContext.VisibilityStatus != null)
            {
                request.VisibilityStatus = cmdletContext.VisibilityStatus;
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
        
        private Amazon.QConnect.Model.UpdateAIPromptResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateAIPromptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateAIPrompt");
            try
            {
                #if DESKTOP
                return client.UpdateAIPrompt(request);
                #elif CORECLR
                return client.UpdateAIPromptAsync(request).GetAwaiter().GetResult();
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
            public System.String AiPromptId { get; set; }
            public System.String AssistantId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String TextFullAIPromptEditTemplateConfiguration_Text { get; set; }
            public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateAIPromptResponse, UpdateQCAIPromptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AiPrompt;
        }
        
    }
}
