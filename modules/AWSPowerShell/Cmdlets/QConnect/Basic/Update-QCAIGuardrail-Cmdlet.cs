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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Updates an AI Guardrail.
    /// </summary>
    [Cmdlet("Update", "QCAIGuardrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AIGuardrailData")]
    [AWSCmdlet("Calls the Amazon Q Connect UpdateAIGuardrail API operation.", Operation = new[] {"UpdateAIGuardrail"}, SelectReturnType = typeof(Amazon.QConnect.Model.UpdateAIGuardrailResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AIGuardrailData or Amazon.QConnect.Model.UpdateAIGuardrailResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AIGuardrailData object.",
        "The service call response (type Amazon.QConnect.Model.UpdateAIGuardrailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQCAIGuardrailCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AiGuardrailId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect AI Guardrail.</para>
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
        public System.String AiGuardrailId { get; set; }
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
        
        #region Parameter BlockedInputMessaging
        /// <summary>
        /// <para>
        /// <para>The message to return when the AI Guardrail blocks a prompt.</para>
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
        public System.String BlockedInputMessaging { get; set; }
        #endregion
        
        #region Parameter BlockedOutputsMessaging
        /// <summary>
        /// <para>
        /// <para>The message to return when the AI Guardrail blocks a model response.</para>
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
        public System.String BlockedOutputsMessaging { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the AI Guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ContentPolicyConfig_FiltersConfig
        /// <summary>
        /// <para>
        /// <para>Contains the type of the content filter and how strongly it should apply to prompts
        /// and model responses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailContentFilterConfig[] ContentPolicyConfig_FiltersConfig { get; set; }
        #endregion
        
        #region Parameter ContextualGroundingPolicyConfig_FiltersConfig
        /// <summary>
        /// <para>
        /// <para>The filter configuration details for the AI Guardrails contextual grounding policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailContextualGroundingFilterConfig[] ContextualGroundingPolicyConfig_FiltersConfig { get; set; }
        #endregion
        
        #region Parameter WordPolicyConfig_ManagedWordListsConfig
        /// <summary>
        /// <para>
        /// <para>A list of managed words to configure for the AI Guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailManagedWordsConfig[] WordPolicyConfig_ManagedWordListsConfig { get; set; }
        #endregion
        
        #region Parameter SensitiveInformationPolicyConfig_PiiEntitiesConfig
        /// <summary>
        /// <para>
        /// <para>A list of PII entities to configure to the AI Guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailPiiEntityConfig[] SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
        #endregion
        
        #region Parameter SensitiveInformationPolicyConfig_RegexesConfig
        /// <summary>
        /// <para>
        /// <para>A list of regular expressions to configure to the AI Guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailRegexConfig[] SensitiveInformationPolicyConfig_RegexesConfig { get; set; }
        #endregion
        
        #region Parameter TopicPolicyConfig_TopicsConfig
        /// <summary>
        /// <para>
        /// <para>A list of policies related to topics that the AI Guardrail should deny.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailTopicConfig[] TopicPolicyConfig_TopicsConfig { get; set; }
        #endregion
        
        #region Parameter VisibilityStatus
        /// <summary>
        /// <para>
        /// <para>The visibility status of the Amazon Q in Connect AI Guardrail.</para>
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
        
        #region Parameter WordPolicyConfig_WordsConfig
        /// <summary>
        /// <para>
        /// <para>A list of words to configure for the AI Guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.GuardrailWordConfig[] WordPolicyConfig_WordsConfig { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AiGuardrail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.UpdateAIGuardrailResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.UpdateAIGuardrailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AiGuardrail";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AiGuardrailId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AiGuardrailId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AiGuardrailId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AiGuardrailId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QCAIGuardrail (UpdateAIGuardrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.UpdateAIGuardrailResponse, UpdateQCAIGuardrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AiGuardrailId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AiGuardrailId = this.AiGuardrailId;
            #if MODULAR
            if (this.AiGuardrailId == null && ParameterWasBound(nameof(this.AiGuardrailId)))
            {
                WriteWarning("You are passing $null as a value for parameter AiGuardrailId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlockedInputMessaging = this.BlockedInputMessaging;
            #if MODULAR
            if (this.BlockedInputMessaging == null && ParameterWasBound(nameof(this.BlockedInputMessaging)))
            {
                WriteWarning("You are passing $null as a value for parameter BlockedInputMessaging which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BlockedOutputsMessaging = this.BlockedOutputsMessaging;
            #if MODULAR
            if (this.BlockedOutputsMessaging == null && ParameterWasBound(nameof(this.BlockedOutputsMessaging)))
            {
                WriteWarning("You are passing $null as a value for parameter BlockedOutputsMessaging which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.ContentPolicyConfig_FiltersConfig != null)
            {
                context.ContentPolicyConfig_FiltersConfig = new List<Amazon.QConnect.Model.GuardrailContentFilterConfig>(this.ContentPolicyConfig_FiltersConfig);
            }
            if (this.ContextualGroundingPolicyConfig_FiltersConfig != null)
            {
                context.ContextualGroundingPolicyConfig_FiltersConfig = new List<Amazon.QConnect.Model.GuardrailContextualGroundingFilterConfig>(this.ContextualGroundingPolicyConfig_FiltersConfig);
            }
            context.Description = this.Description;
            if (this.SensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                context.SensitiveInformationPolicyConfig_PiiEntitiesConfig = new List<Amazon.QConnect.Model.GuardrailPiiEntityConfig>(this.SensitiveInformationPolicyConfig_PiiEntitiesConfig);
            }
            if (this.SensitiveInformationPolicyConfig_RegexesConfig != null)
            {
                context.SensitiveInformationPolicyConfig_RegexesConfig = new List<Amazon.QConnect.Model.GuardrailRegexConfig>(this.SensitiveInformationPolicyConfig_RegexesConfig);
            }
            if (this.TopicPolicyConfig_TopicsConfig != null)
            {
                context.TopicPolicyConfig_TopicsConfig = new List<Amazon.QConnect.Model.GuardrailTopicConfig>(this.TopicPolicyConfig_TopicsConfig);
            }
            context.VisibilityStatus = this.VisibilityStatus;
            #if MODULAR
            if (this.VisibilityStatus == null && ParameterWasBound(nameof(this.VisibilityStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter VisibilityStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.WordPolicyConfig_ManagedWordListsConfig != null)
            {
                context.WordPolicyConfig_ManagedWordListsConfig = new List<Amazon.QConnect.Model.GuardrailManagedWordsConfig>(this.WordPolicyConfig_ManagedWordListsConfig);
            }
            if (this.WordPolicyConfig_WordsConfig != null)
            {
                context.WordPolicyConfig_WordsConfig = new List<Amazon.QConnect.Model.GuardrailWordConfig>(this.WordPolicyConfig_WordsConfig);
            }
            
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
            var request = new Amazon.QConnect.Model.UpdateAIGuardrailRequest();
            
            if (cmdletContext.AiGuardrailId != null)
            {
                request.AiGuardrailId = cmdletContext.AiGuardrailId;
            }
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.BlockedInputMessaging != null)
            {
                request.BlockedInputMessaging = cmdletContext.BlockedInputMessaging;
            }
            if (cmdletContext.BlockedOutputsMessaging != null)
            {
                request.BlockedOutputsMessaging = cmdletContext.BlockedOutputsMessaging;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ContentPolicyConfig
            var requestContentPolicyConfigIsNull = true;
            request.ContentPolicyConfig = new Amazon.QConnect.Model.AIGuardrailContentPolicyConfig();
            List<Amazon.QConnect.Model.GuardrailContentFilterConfig> requestContentPolicyConfig_contentPolicyConfig_FiltersConfig = null;
            if (cmdletContext.ContentPolicyConfig_FiltersConfig != null)
            {
                requestContentPolicyConfig_contentPolicyConfig_FiltersConfig = cmdletContext.ContentPolicyConfig_FiltersConfig;
            }
            if (requestContentPolicyConfig_contentPolicyConfig_FiltersConfig != null)
            {
                request.ContentPolicyConfig.FiltersConfig = requestContentPolicyConfig_contentPolicyConfig_FiltersConfig;
                requestContentPolicyConfigIsNull = false;
            }
             // determine if request.ContentPolicyConfig should be set to null
            if (requestContentPolicyConfigIsNull)
            {
                request.ContentPolicyConfig = null;
            }
            
             // populate ContextualGroundingPolicyConfig
            var requestContextualGroundingPolicyConfigIsNull = true;
            request.ContextualGroundingPolicyConfig = new Amazon.QConnect.Model.AIGuardrailContextualGroundingPolicyConfig();
            List<Amazon.QConnect.Model.GuardrailContextualGroundingFilterConfig> requestContextualGroundingPolicyConfig_contextualGroundingPolicyConfig_FiltersConfig = null;
            if (cmdletContext.ContextualGroundingPolicyConfig_FiltersConfig != null)
            {
                requestContextualGroundingPolicyConfig_contextualGroundingPolicyConfig_FiltersConfig = cmdletContext.ContextualGroundingPolicyConfig_FiltersConfig;
            }
            if (requestContextualGroundingPolicyConfig_contextualGroundingPolicyConfig_FiltersConfig != null)
            {
                request.ContextualGroundingPolicyConfig.FiltersConfig = requestContextualGroundingPolicyConfig_contextualGroundingPolicyConfig_FiltersConfig;
                requestContextualGroundingPolicyConfigIsNull = false;
            }
             // determine if request.ContextualGroundingPolicyConfig should be set to null
            if (requestContextualGroundingPolicyConfigIsNull)
            {
                request.ContextualGroundingPolicyConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate SensitiveInformationPolicyConfig
            var requestSensitiveInformationPolicyConfigIsNull = true;
            request.SensitiveInformationPolicyConfig = new Amazon.QConnect.Model.AIGuardrailSensitiveInformationPolicyConfig();
            List<Amazon.QConnect.Model.GuardrailPiiEntityConfig> requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig = null;
            if (cmdletContext.SensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig = cmdletContext.SensitiveInformationPolicyConfig_PiiEntitiesConfig;
            }
            if (requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                request.SensitiveInformationPolicyConfig.PiiEntitiesConfig = requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig;
                requestSensitiveInformationPolicyConfigIsNull = false;
            }
            List<Amazon.QConnect.Model.GuardrailRegexConfig> requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_RegexesConfig = null;
            if (cmdletContext.SensitiveInformationPolicyConfig_RegexesConfig != null)
            {
                requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_RegexesConfig = cmdletContext.SensitiveInformationPolicyConfig_RegexesConfig;
            }
            if (requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_RegexesConfig != null)
            {
                request.SensitiveInformationPolicyConfig.RegexesConfig = requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_RegexesConfig;
                requestSensitiveInformationPolicyConfigIsNull = false;
            }
             // determine if request.SensitiveInformationPolicyConfig should be set to null
            if (requestSensitiveInformationPolicyConfigIsNull)
            {
                request.SensitiveInformationPolicyConfig = null;
            }
            
             // populate TopicPolicyConfig
            var requestTopicPolicyConfigIsNull = true;
            request.TopicPolicyConfig = new Amazon.QConnect.Model.AIGuardrailTopicPolicyConfig();
            List<Amazon.QConnect.Model.GuardrailTopicConfig> requestTopicPolicyConfig_topicPolicyConfig_TopicsConfig = null;
            if (cmdletContext.TopicPolicyConfig_TopicsConfig != null)
            {
                requestTopicPolicyConfig_topicPolicyConfig_TopicsConfig = cmdletContext.TopicPolicyConfig_TopicsConfig;
            }
            if (requestTopicPolicyConfig_topicPolicyConfig_TopicsConfig != null)
            {
                request.TopicPolicyConfig.TopicsConfig = requestTopicPolicyConfig_topicPolicyConfig_TopicsConfig;
                requestTopicPolicyConfigIsNull = false;
            }
             // determine if request.TopicPolicyConfig should be set to null
            if (requestTopicPolicyConfigIsNull)
            {
                request.TopicPolicyConfig = null;
            }
            if (cmdletContext.VisibilityStatus != null)
            {
                request.VisibilityStatus = cmdletContext.VisibilityStatus;
            }
            
             // populate WordPolicyConfig
            var requestWordPolicyConfigIsNull = true;
            request.WordPolicyConfig = new Amazon.QConnect.Model.AIGuardrailWordPolicyConfig();
            List<Amazon.QConnect.Model.GuardrailManagedWordsConfig> requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig = null;
            if (cmdletContext.WordPolicyConfig_ManagedWordListsConfig != null)
            {
                requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig = cmdletContext.WordPolicyConfig_ManagedWordListsConfig;
            }
            if (requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig != null)
            {
                request.WordPolicyConfig.ManagedWordListsConfig = requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig;
                requestWordPolicyConfigIsNull = false;
            }
            List<Amazon.QConnect.Model.GuardrailWordConfig> requestWordPolicyConfig_wordPolicyConfig_WordsConfig = null;
            if (cmdletContext.WordPolicyConfig_WordsConfig != null)
            {
                requestWordPolicyConfig_wordPolicyConfig_WordsConfig = cmdletContext.WordPolicyConfig_WordsConfig;
            }
            if (requestWordPolicyConfig_wordPolicyConfig_WordsConfig != null)
            {
                request.WordPolicyConfig.WordsConfig = requestWordPolicyConfig_wordPolicyConfig_WordsConfig;
                requestWordPolicyConfigIsNull = false;
            }
             // determine if request.WordPolicyConfig should be set to null
            if (requestWordPolicyConfigIsNull)
            {
                request.WordPolicyConfig = null;
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
        
        private Amazon.QConnect.Model.UpdateAIGuardrailResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.UpdateAIGuardrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "UpdateAIGuardrail");
            try
            {
                #if DESKTOP
                return client.UpdateAIGuardrail(request);
                #elif CORECLR
                return client.UpdateAIGuardrailAsync(request).GetAwaiter().GetResult();
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
            public System.String AiGuardrailId { get; set; }
            public System.String AssistantId { get; set; }
            public System.String BlockedInputMessaging { get; set; }
            public System.String BlockedOutputsMessaging { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.QConnect.Model.GuardrailContentFilterConfig> ContentPolicyConfig_FiltersConfig { get; set; }
            public List<Amazon.QConnect.Model.GuardrailContextualGroundingFilterConfig> ContextualGroundingPolicyConfig_FiltersConfig { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.QConnect.Model.GuardrailPiiEntityConfig> SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
            public List<Amazon.QConnect.Model.GuardrailRegexConfig> SensitiveInformationPolicyConfig_RegexesConfig { get; set; }
            public List<Amazon.QConnect.Model.GuardrailTopicConfig> TopicPolicyConfig_TopicsConfig { get; set; }
            public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
            public List<Amazon.QConnect.Model.GuardrailManagedWordsConfig> WordPolicyConfig_ManagedWordListsConfig { get; set; }
            public List<Amazon.QConnect.Model.GuardrailWordConfig> WordPolicyConfig_WordsConfig { get; set; }
            public System.Func<Amazon.QConnect.Model.UpdateAIGuardrailResponse, UpdateQCAIGuardrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AiGuardrail;
        }
        
    }
}
