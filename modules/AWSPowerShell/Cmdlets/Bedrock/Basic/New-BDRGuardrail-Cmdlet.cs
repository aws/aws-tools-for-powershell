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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Creates a guardrail to block topics and to implement safeguards for your generative
    /// AI applications.
    /// 
    ///  
    /// <para>
    /// You can configure the following policies in a guardrail to avoid undesirable and harmful
    /// content, filter out denied topics and words, and remove sensitive information for
    /// privacy protection.
    /// </para><ul><li><para><b>Content filters</b> - Adjust filter strengths to block input prompts or model
    /// responses containing harmful content.
    /// </para></li><li><para><b>Denied topics</b> - Define a set of topics that are undesirable in the context
    /// of your application. These topics will be blocked if detected in user queries or model
    /// responses.
    /// </para></li><li><para><b>Word filters</b> - Configure filters to block undesirable words, phrases, and
    /// profanity. Such words can include offensive terms, competitor names etc.
    /// </para></li><li><para><b>Sensitive information filters</b> - Block or mask sensitive information such as
    /// personally identifiable information (PII) or custom regex in user inputs and model
    /// responses.
    /// </para></li></ul><para>
    /// In addition to the above policies, you can also configure the messages to be returned
    /// to the user if a user input or model response is in violation of the policies defined
    /// in the guardrail.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/guardrails.html">Amazon
    /// Bedrock Guardrails</a> in the <i>Amazon Bedrock User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BDRGuardrail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.CreateGuardrailResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock CreateGuardrail API operation.", Operation = new[] {"CreateGuardrail"}, SelectReturnType = typeof(Amazon.Bedrock.Model.CreateGuardrailResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.CreateGuardrailResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.CreateGuardrailResponse object containing multiple properties."
    )]
    public partial class NewBDRGuardrailCmdlet : AmazonBedrockClientCmdlet, IExecutor
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
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than once. If this token matches a previous request, Amazon Bedrock ignores the request,
        /// but does not return an error. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter AutomatedReasoningPolicyConfig_ConfidenceThreshold
        /// <summary>
        /// <para>
        /// <para>The confidence threshold for triggering guardrail actions based on Automated Reasoning
        /// policy violations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AutomatedReasoningPolicyConfig_ConfidenceThreshold { get; set; }
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
        
        #region Parameter CrossRegionConfig_GuardrailProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the guardrail profile that your guardrail
        /// is using. Guardrail profile availability depends on your current Amazon Web Services
        /// Region. For more information, see the <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/guardrails-cross-region-support.html">Amazon
        /// Bedrock User Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CrossRegionConfig_GuardrailProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key that you use to encrypt the guardrail.</para>
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
        /// <para>The name to give the guardrail.</para>
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
        
        #region Parameter SensitiveInformationPolicyConfig_PiiEntitiesConfig
        /// <summary>
        /// <para>
        /// <para>A list of PII entities to configure to the guardrail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Bedrock.Model.GuardrailPiiEntityConfig[] SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
        #endregion
        
        #region Parameter AutomatedReasoningPolicyConfig_Policy
        /// <summary>
        /// <para>
        /// <para>The list of Automated Reasoning policy ARNs to include in the guardrail configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutomatedReasoningPolicyConfig_Policies")]
        public System.String[] AutomatedReasoningPolicyConfig_Policy { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you want to attach to the guardrail. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Bedrock.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ContentPolicyConfig_TierConfig_TierName
        /// <summary>
        /// <para>
        /// <para>The tier that your guardrail uses for content filters. Valid values include:</para><ul><li><para><c>CLASSIC</c> tier – Provides established guardrails functionality supporting English,
        /// French, and Spanish languages.</para></li><li><para><c>STANDARD</c> tier – Provides a more robust solution than the <c>CLASSIC</c> tier
        /// and has more comprehensive language support. This tier requires that your guardrail
        /// use <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/guardrails-cross-region.html">cross-Region
        /// inference</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.GuardrailContentFiltersTierName")]
        public Amazon.Bedrock.GuardrailContentFiltersTierName ContentPolicyConfig_TierConfig_TierName { get; set; }
        #endregion
        
        #region Parameter TopicPolicyConfig_TierConfig_TierName
        /// <summary>
        /// <para>
        /// <para>The tier that your guardrail uses for denied topic filters. Valid values include:</para><ul><li><para><c>CLASSIC</c> tier – Provides established guardrails functionality supporting English,
        /// French, and Spanish languages.</para></li><li><para><c>STANDARD</c> tier – Provides a more robust solution than the <c>CLASSIC</c> tier
        /// and has more comprehensive language support. This tier requires that your guardrail
        /// use <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/guardrails-cross-region.html">cross-Region
        /// inference</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.GuardrailTopicsTierName")]
        public Amazon.Bedrock.GuardrailTopicsTierName TopicPolicyConfig_TierConfig_TierName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.CreateGuardrailResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.CreateGuardrailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BDRGuardrail (CreateGuardrail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.CreateGuardrailResponse, NewBDRGuardrailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutomatedReasoningPolicyConfig_ConfidenceThreshold = this.AutomatedReasoningPolicyConfig_ConfidenceThreshold;
            if (this.AutomatedReasoningPolicyConfig_Policy != null)
            {
                context.AutomatedReasoningPolicyConfig_Policy = new List<System.String>(this.AutomatedReasoningPolicyConfig_Policy);
            }
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
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.ContentPolicyConfig_FiltersConfig != null)
            {
                context.ContentPolicyConfig_FiltersConfig = new List<Amazon.Bedrock.Model.GuardrailContentFilterConfig>(this.ContentPolicyConfig_FiltersConfig);
            }
            context.ContentPolicyConfig_TierConfig_TierName = this.ContentPolicyConfig_TierConfig_TierName;
            if (this.ContextualGroundingPolicyConfig_FiltersConfig != null)
            {
                context.ContextualGroundingPolicyConfig_FiltersConfig = new List<Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig>(this.ContextualGroundingPolicyConfig_FiltersConfig);
            }
            context.CrossRegionConfig_GuardrailProfileIdentifier = this.CrossRegionConfig_GuardrailProfileIdentifier;
            context.Description = this.Description;
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
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Bedrock.Model.Tag>(this.Tag);
            }
            context.TopicPolicyConfig_TierConfig_TierName = this.TopicPolicyConfig_TierConfig_TierName;
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
            var request = new Amazon.Bedrock.Model.CreateGuardrailRequest();
            
            
             // populate AutomatedReasoningPolicyConfig
            var requestAutomatedReasoningPolicyConfigIsNull = true;
            request.AutomatedReasoningPolicyConfig = new Amazon.Bedrock.Model.GuardrailAutomatedReasoningPolicyConfig();
            System.Double? requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_ConfidenceThreshold = null;
            if (cmdletContext.AutomatedReasoningPolicyConfig_ConfidenceThreshold != null)
            {
                requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_ConfidenceThreshold = cmdletContext.AutomatedReasoningPolicyConfig_ConfidenceThreshold.Value;
            }
            if (requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_ConfidenceThreshold != null)
            {
                request.AutomatedReasoningPolicyConfig.ConfidenceThreshold = requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_ConfidenceThreshold.Value;
                requestAutomatedReasoningPolicyConfigIsNull = false;
            }
            List<System.String> requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_Policy = null;
            if (cmdletContext.AutomatedReasoningPolicyConfig_Policy != null)
            {
                requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_Policy = cmdletContext.AutomatedReasoningPolicyConfig_Policy;
            }
            if (requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_Policy != null)
            {
                request.AutomatedReasoningPolicyConfig.Policies = requestAutomatedReasoningPolicyConfig_automatedReasoningPolicyConfig_Policy;
                requestAutomatedReasoningPolicyConfigIsNull = false;
            }
             // determine if request.AutomatedReasoningPolicyConfig should be set to null
            if (requestAutomatedReasoningPolicyConfigIsNull)
            {
                request.AutomatedReasoningPolicyConfig = null;
            }
            if (cmdletContext.BlockedInputMessaging != null)
            {
                request.BlockedInputMessaging = cmdletContext.BlockedInputMessaging;
            }
            if (cmdletContext.BlockedOutputsMessaging != null)
            {
                request.BlockedOutputsMessaging = cmdletContext.BlockedOutputsMessaging;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
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
            Amazon.Bedrock.Model.GuardrailContentFiltersTierConfig requestContentPolicyConfig_contentPolicyConfig_TierConfig = null;
            
             // populate TierConfig
            var requestContentPolicyConfig_contentPolicyConfig_TierConfigIsNull = true;
            requestContentPolicyConfig_contentPolicyConfig_TierConfig = new Amazon.Bedrock.Model.GuardrailContentFiltersTierConfig();
            Amazon.Bedrock.GuardrailContentFiltersTierName requestContentPolicyConfig_contentPolicyConfig_TierConfig_contentPolicyConfig_TierConfig_TierName = null;
            if (cmdletContext.ContentPolicyConfig_TierConfig_TierName != null)
            {
                requestContentPolicyConfig_contentPolicyConfig_TierConfig_contentPolicyConfig_TierConfig_TierName = cmdletContext.ContentPolicyConfig_TierConfig_TierName;
            }
            if (requestContentPolicyConfig_contentPolicyConfig_TierConfig_contentPolicyConfig_TierConfig_TierName != null)
            {
                requestContentPolicyConfig_contentPolicyConfig_TierConfig.TierName = requestContentPolicyConfig_contentPolicyConfig_TierConfig_contentPolicyConfig_TierConfig_TierName;
                requestContentPolicyConfig_contentPolicyConfig_TierConfigIsNull = false;
            }
             // determine if requestContentPolicyConfig_contentPolicyConfig_TierConfig should be set to null
            if (requestContentPolicyConfig_contentPolicyConfig_TierConfigIsNull)
            {
                requestContentPolicyConfig_contentPolicyConfig_TierConfig = null;
            }
            if (requestContentPolicyConfig_contentPolicyConfig_TierConfig != null)
            {
                request.ContentPolicyConfig.TierConfig = requestContentPolicyConfig_contentPolicyConfig_TierConfig;
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
            
             // populate CrossRegionConfig
            var requestCrossRegionConfigIsNull = true;
            request.CrossRegionConfig = new Amazon.Bedrock.Model.GuardrailCrossRegionConfig();
            System.String requestCrossRegionConfig_crossRegionConfig_GuardrailProfileIdentifier = null;
            if (cmdletContext.CrossRegionConfig_GuardrailProfileIdentifier != null)
            {
                requestCrossRegionConfig_crossRegionConfig_GuardrailProfileIdentifier = cmdletContext.CrossRegionConfig_GuardrailProfileIdentifier;
            }
            if (requestCrossRegionConfig_crossRegionConfig_GuardrailProfileIdentifier != null)
            {
                request.CrossRegionConfig.GuardrailProfileIdentifier = requestCrossRegionConfig_crossRegionConfig_GuardrailProfileIdentifier;
                requestCrossRegionConfigIsNull = false;
            }
             // determine if request.CrossRegionConfig should be set to null
            if (requestCrossRegionConfigIsNull)
            {
                request.CrossRegionConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
            Amazon.Bedrock.Model.GuardrailTopicsTierConfig requestTopicPolicyConfig_topicPolicyConfig_TierConfig = null;
            
             // populate TierConfig
            var requestTopicPolicyConfig_topicPolicyConfig_TierConfigIsNull = true;
            requestTopicPolicyConfig_topicPolicyConfig_TierConfig = new Amazon.Bedrock.Model.GuardrailTopicsTierConfig();
            Amazon.Bedrock.GuardrailTopicsTierName requestTopicPolicyConfig_topicPolicyConfig_TierConfig_topicPolicyConfig_TierConfig_TierName = null;
            if (cmdletContext.TopicPolicyConfig_TierConfig_TierName != null)
            {
                requestTopicPolicyConfig_topicPolicyConfig_TierConfig_topicPolicyConfig_TierConfig_TierName = cmdletContext.TopicPolicyConfig_TierConfig_TierName;
            }
            if (requestTopicPolicyConfig_topicPolicyConfig_TierConfig_topicPolicyConfig_TierConfig_TierName != null)
            {
                requestTopicPolicyConfig_topicPolicyConfig_TierConfig.TierName = requestTopicPolicyConfig_topicPolicyConfig_TierConfig_topicPolicyConfig_TierConfig_TierName;
                requestTopicPolicyConfig_topicPolicyConfig_TierConfigIsNull = false;
            }
             // determine if requestTopicPolicyConfig_topicPolicyConfig_TierConfig should be set to null
            if (requestTopicPolicyConfig_topicPolicyConfig_TierConfigIsNull)
            {
                requestTopicPolicyConfig_topicPolicyConfig_TierConfig = null;
            }
            if (requestTopicPolicyConfig_topicPolicyConfig_TierConfig != null)
            {
                request.TopicPolicyConfig.TierConfig = requestTopicPolicyConfig_topicPolicyConfig_TierConfig;
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
        
        private Amazon.Bedrock.Model.CreateGuardrailResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.CreateGuardrailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "CreateGuardrail");
            try
            {
                #if DESKTOP
                return client.CreateGuardrail(request);
                #elif CORECLR
                return client.CreateGuardrailAsync(request).GetAwaiter().GetResult();
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
            public System.Double? AutomatedReasoningPolicyConfig_ConfidenceThreshold { get; set; }
            public List<System.String> AutomatedReasoningPolicyConfig_Policy { get; set; }
            public System.String BlockedInputMessaging { get; set; }
            public System.String BlockedOutputsMessaging { get; set; }
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailContentFilterConfig> ContentPolicyConfig_FiltersConfig { get; set; }
            public Amazon.Bedrock.GuardrailContentFiltersTierName ContentPolicyConfig_TierConfig_TierName { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailContextualGroundingFilterConfig> ContextualGroundingPolicyConfig_FiltersConfig { get; set; }
            public System.String CrossRegionConfig_GuardrailProfileIdentifier { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailPiiEntityConfig> SensitiveInformationPolicyConfig_PiiEntitiesConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailRegexConfig> SensitiveInformationPolicyConfig_RegexesConfig { get; set; }
            public List<Amazon.Bedrock.Model.Tag> Tag { get; set; }
            public Amazon.Bedrock.GuardrailTopicsTierName TopicPolicyConfig_TierConfig_TierName { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailTopicConfig> TopicPolicyConfig_TopicsConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailManagedWordsConfig> WordPolicyConfig_ManagedWordListsConfig { get; set; }
            public List<Amazon.Bedrock.Model.GuardrailWordConfig> WordPolicyConfig_WordsConfig { get; set; }
            public System.Func<Amazon.Bedrock.Model.CreateGuardrailResponse, NewBDRGuardrailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
