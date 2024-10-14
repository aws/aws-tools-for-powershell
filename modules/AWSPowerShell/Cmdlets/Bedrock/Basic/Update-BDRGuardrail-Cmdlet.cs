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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Updates a guardrail with the values you specify.
    /// 
    ///  <ul><li><para>
    /// Specify a <c>name</c> and optional <c>description</c>.
    /// </para></li><li><para>
    /// Specify messages for when the guardrail successfully blocks a prompt or a model response
    /// in the <c>blockedInputMessaging</c> and <c>blockedOutputsMessaging</c> fields.
    /// </para></li><li><para>
    /// Specify topics for the guardrail to deny in the <c>topicPolicyConfig</c> object. Each
    /// <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GuardrailTopicConfig.html">GuardrailTopicConfig</a>
    /// object in the <c>topicsConfig</c> list pertains to one topic.
    /// </para><ul><li><para>
    /// Give a <c>name</c> and <c>description</c> so that the guardrail can properly identify
    /// the topic.
    /// </para></li><li><para>
    /// Specify <c>DENY</c> in the <c>type</c> field.
    /// </para></li><li><para>
    /// (Optional) Provide up to five prompts that you would categorize as belonging to the
    /// topic in the <c>examples</c> list.
    /// </para></li></ul></li><li><para>
    /// Specify filter strengths for the harmful categories defined in Amazon Bedrock in the
    /// <c>contentPolicyConfig</c> object. Each <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GuardrailContentFilterConfig.html">GuardrailContentFilterConfig</a>
    /// object in the <c>filtersConfig</c> list pertains to a harmful category. For more information,
    /// see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/guardrails-content-filters">Content
    /// filters</a>. For more information about the fields in a content filter, see <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GuardrailContentFilterConfig.html">GuardrailContentFilterConfig</a>.
    /// </para><ul><li><para>
    /// Specify the category in the <c>type</c> field.
    /// </para></li><li><para>
    /// Specify the strength of the filter for prompts in the <c>inputStrength</c> field and
    /// for model responses in the <c>strength</c> field of the <a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GuardrailContentFilterConfig.html">GuardrailContentFilterConfig</a>.
    /// </para></li></ul></li><li><para>
    /// (Optional) For security, include the ARN of a KMS key in the <c>kmsKeyId</c> field.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "BDRGuardrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.UpdateGuardrailResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock UpdateGuardrail API operation.", Operation = new[] {"UpdateGuardrail"}, SelectReturnType = typeof(Amazon.Bedrock.Model.UpdateGuardrailResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.UpdateGuardrailResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.UpdateGuardrailResponse object containing multiple properties."
    )]
    public partial class UpdateBDRGuardrailCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlockedInputMessaging
        /// <summary>
        /// <para>
        /// <para>The message to return when the guardrail blocks a prompt.</para>
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
        /// <para>The message to return when the guardrail blocks a model response.</para>
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
        /// <para>A description of the guardrail.</para>
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
        public Amazon.Bedrock.Model.GuardrailContentFilterConfig[] ContentPolicyConfig_FiltersConfig { get; set; }
        #endregion
        
        #region Parameter ContextualGroundingPolicyConfig_FiltersConfig
        /// <summary>
        /// <para>
        /// <para>The filter configuration details for the guardrails contextual grounding policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig[] ContextualGroundingPolicyConfig_FiltersConfig { get; set; }
        #endregion
        
        #region Parameter GuardrailIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the guardrail. This can be an ID or the ARN.</para>
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
        public System.String GuardrailIdentifier { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key with which to encrypt the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter WordPolicyConfig_ManagedWordListsConfig
        /// <summary>
        /// <para>
        /// <para>A list of managed words to configure for the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailManagedWordsConfig[] WordPolicyConfig_ManagedWordListsConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the guardrail.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SensitiveInformationPolicyConfig_PiiEntitiesConfig
        /// <summary>
        /// <para>
        /// <para>A list of PII entities to configure to the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailPiiEntityConfig[] SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
        #endregion
        
        #region Parameter SensitiveInformationPolicyConfig_RegexesConfig
        /// <summary>
        /// <para>
        /// <para>A list of regular expressions to configure to the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailRegexConfig[] SensitiveInformationPolicyConfig_RegexesConfig { get; set; }
        #endregion
        
        #region Parameter TopicPolicyConfig_TopicsConfig
        /// <summary>
        /// <para>
        /// <para>A list of policies related to topics that the guardrail should deny.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailTopicConfig[] TopicPolicyConfig_TopicsConfig { get; set; }
        #endregion
        
        #region Parameter WordPolicyConfig_WordsConfig
        /// <summary>
        /// <para>
        /// <para>A list of words to configure for the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailWordConfig[] WordPolicyConfig_WordsConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.UpdateGuardrailResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.UpdateGuardrailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GuardrailIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GuardrailIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GuardrailIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GuardrailIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BDRGuardrail (UpdateGuardrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.UpdateGuardrailResponse, UpdateBDRGuardrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GuardrailIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            if (this.ContentPolicyConfig_FiltersConfig != null)
            {
                context.ContentPolicyConfig_FiltersConfig = new List<Amazon.Bedrock.Model.GuardrailContentFilterConfig>(this.ContentPolicyConfig_FiltersConfig);
            }
            if (this.ContextualGroundingPolicyConfig_FiltersConfig != null)
            {
                context.ContextualGroundingPolicyConfig_FiltersConfig = new List<Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig>(this.ContextualGroundingPolicyConfig_FiltersConfig);
            }
            context.Description = this.Description;
            context.GuardrailIdentifier = this.GuardrailIdentifier;
            #if MODULAR
            if (this.GuardrailIdentifier == null && ParameterWasBound(nameof(this.GuardrailIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GuardrailIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                context.SensitiveInformationPolicyConfig_PiiEntitiesConfig = new List<Amazon.Bedrock.Model.GuardrailPiiEntityConfig>(this.SensitiveInformationPolicyConfig_PiiEntitiesConfig);
            }
            if (this.SensitiveInformationPolicyConfig_RegexesConfig != null)
            {
                context.SensitiveInformationPolicyConfig_RegexesConfig = new List<Amazon.Bedrock.Model.GuardrailRegexConfig>(this.SensitiveInformationPolicyConfig_RegexesConfig);
            }
            if (this.TopicPolicyConfig_TopicsConfig != null)
            {
                context.TopicPolicyConfig_TopicsConfig = new List<Amazon.Bedrock.Model.GuardrailTopicConfig>(this.TopicPolicyConfig_TopicsConfig);
            }
            if (this.WordPolicyConfig_ManagedWordListsConfig != null)
            {
                context.WordPolicyConfig_ManagedWordListsConfig = new List<Amazon.Bedrock.Model.GuardrailManagedWordsConfig>(this.WordPolicyConfig_ManagedWordListsConfig);
            }
            if (this.WordPolicyConfig_WordsConfig != null)
            {
                context.WordPolicyConfig_WordsConfig = new List<Amazon.Bedrock.Model.GuardrailWordConfig>(this.WordPolicyConfig_WordsConfig);
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
            var request = new Amazon.Bedrock.Model.UpdateGuardrailRequest();
            
            if (cmdletContext.BlockedInputMessaging != null)
            {
                request.BlockedInputMessaging = cmdletContext.BlockedInputMessaging;
            }
            if (cmdletContext.BlockedOutputsMessaging != null)
            {
                request.BlockedOutputsMessaging = cmdletContext.BlockedOutputsMessaging;
            }
            
             // populate ContentPolicyConfig
            var requestContentPolicyConfigIsNull = true;
            request.ContentPolicyConfig = new Amazon.Bedrock.Model.GuardrailContentPolicyConfig();
            List<Amazon.Bedrock.Model.GuardrailContentFilterConfig> requestContentPolicyConfig_contentPolicyConfig_FiltersConfig = null;
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
            request.ContextualGroundingPolicyConfig = new Amazon.Bedrock.Model.GuardrailContextualGroundingPolicyConfig();
            List<Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig> requestContextualGroundingPolicyConfig_contextualGroundingPolicyConfig_FiltersConfig = null;
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
            if (cmdletContext.GuardrailIdentifier != null)
            {
                request.GuardrailIdentifier = cmdletContext.GuardrailIdentifier;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SensitiveInformationPolicyConfig
            var requestSensitiveInformationPolicyConfigIsNull = true;
            request.SensitiveInformationPolicyConfig = new Amazon.Bedrock.Model.GuardrailSensitiveInformationPolicyConfig();
            List<Amazon.Bedrock.Model.GuardrailPiiEntityConfig> requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig = null;
            if (cmdletContext.SensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig = cmdletContext.SensitiveInformationPolicyConfig_PiiEntitiesConfig;
            }
            if (requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig != null)
            {
                request.SensitiveInformationPolicyConfig.PiiEntitiesConfig = requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_PiiEntitiesConfig;
                requestSensitiveInformationPolicyConfigIsNull = false;
            }
            List<Amazon.Bedrock.Model.GuardrailRegexConfig> requestSensitiveInformationPolicyConfig_sensitiveInformationPolicyConfig_RegexesConfig = null;
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
            request.TopicPolicyConfig = new Amazon.Bedrock.Model.GuardrailTopicPolicyConfig();
            List<Amazon.Bedrock.Model.GuardrailTopicConfig> requestTopicPolicyConfig_topicPolicyConfig_TopicsConfig = null;
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
            
             // populate WordPolicyConfig
            var requestWordPolicyConfigIsNull = true;
            request.WordPolicyConfig = new Amazon.Bedrock.Model.GuardrailWordPolicyConfig();
            List<Amazon.Bedrock.Model.GuardrailManagedWordsConfig> requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig = null;
            if (cmdletContext.WordPolicyConfig_ManagedWordListsConfig != null)
            {
                requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig = cmdletContext.WordPolicyConfig_ManagedWordListsConfig;
            }
            if (requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig != null)
            {
                request.WordPolicyConfig.ManagedWordListsConfig = requestWordPolicyConfig_wordPolicyConfig_ManagedWordListsConfig;
                requestWordPolicyConfigIsNull = false;
            }
            List<Amazon.Bedrock.Model.GuardrailWordConfig> requestWordPolicyConfig_wordPolicyConfig_WordsConfig = null;
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
        
        private Amazon.Bedrock.Model.UpdateGuardrailResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.UpdateGuardrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "UpdateGuardrail");
            try
            {
                #if DESKTOP
                return client.UpdateGuardrail(request);
                #elif CORECLR
                return client.UpdateGuardrailAsync(request).GetAwaiter().GetResult();
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
            public System.String BlockedInputMessaging { get; set; }
            public System.String BlockedOutputsMessaging { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailContentFilterConfig> ContentPolicyConfig_FiltersConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig> ContextualGroundingPolicyConfig_FiltersConfig { get; set; }
            public System.String Description { get; set; }
            public System.String GuardrailIdentifier { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailPiiEntityConfig> SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailRegexConfig> SensitiveInformationPolicyConfig_RegexesConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailTopicConfig> TopicPolicyConfig_TopicsConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailManagedWordsConfig> WordPolicyConfig_ManagedWordListsConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailWordConfig> WordPolicyConfig_WordsConfig { get; set; }
            public System.Func<Amazon.Bedrock.Model.UpdateGuardrailResponse, UpdateBDRGuardrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
