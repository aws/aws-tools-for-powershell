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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates an Amazon Q in Connect AI Prompt.
    /// </summary>
    [Cmdlet("New", "QCAIPrompt", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AIPromptData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateAIPrompt API operation.", Operation = new[] {"CreateAIPrompt"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateAIPromptResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AIPromptData or Amazon.QConnect.Model.CreateAIPromptResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AIPromptData object.",
        "The service call response (type Amazon.QConnect.Model.CreateAIPromptResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCAIPromptCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiFormat
        /// <summary>
        /// <para>
        /// <para>The API Format of the AI Prompt.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.AIPromptAPIFormat")]
        public Amazon.QConnect.AIPromptAPIFormat ApiFormat { get; set; }
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
        /// <para>The description of the AI Prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ModelId
        /// <summary>
        /// <para>
        /// <para>The identifier of the model used for this AI Prompt. Model Ids supported are: <c>anthropic.claude-3-haiku-20240307-v1:0</c></para>
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
        public System.String ModelId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the AI Prompt.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TemplateType
        /// <summary>
        /// <para>
        /// <para>The type of the prompt template for this AI Prompt.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.AIPromptTemplateType")]
        public Amazon.QConnect.AIPromptTemplateType TemplateType { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of this AI Prompt.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.AIPromptType")]
        public Amazon.QConnect.AIPromptType Type { get; set; }
        #endregion
        
        #region Parameter VisibilityStatus
        /// <summary>
        /// <para>
        /// <para>The visibility status of the AI Prompt.</para>
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
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="http://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AiPrompt'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateAIPromptResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateAIPromptResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AiPrompt";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCAIPrompt (CreateAIPrompt)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateAIPromptResponse, NewQCAIPromptCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiFormat = this.ApiFormat;
            #if MODULAR
            if (this.ApiFormat == null && ParameterWasBound(nameof(this.ApiFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.ModelId = this.ModelId;
            #if MODULAR
            if (this.ModelId == null && ParameterWasBound(nameof(this.ModelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TextFullAIPromptEditTemplateConfiguration_Text = this.TextFullAIPromptEditTemplateConfiguration_Text;
            context.TemplateType = this.TemplateType;
            #if MODULAR
            if (this.TemplateType == null && ParameterWasBound(nameof(this.TemplateType)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.QConnect.Model.CreateAIPromptRequest();
            
            if (cmdletContext.ApiFormat != null)
            {
                request.ApiFormat = cmdletContext.ApiFormat;
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
            if (cmdletContext.ModelId != null)
            {
                request.ModelId = cmdletContext.ModelId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            if (cmdletContext.TemplateType != null)
            {
                request.TemplateType = cmdletContext.TemplateType;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QConnect.Model.CreateAIPromptResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateAIPromptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateAIPrompt");
            try
            {
                return client.CreateAIPromptAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.QConnect.AIPromptAPIFormat ApiFormat { get; set; }
            public System.String AssistantId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String ModelId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TextFullAIPromptEditTemplateConfiguration_Text { get; set; }
            public Amazon.QConnect.AIPromptTemplateType TemplateType { get; set; }
            public Amazon.QConnect.AIPromptType Type { get; set; }
            public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateAIPromptResponse, NewQCAIPromptCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AiPrompt;
        }
        
    }
}
