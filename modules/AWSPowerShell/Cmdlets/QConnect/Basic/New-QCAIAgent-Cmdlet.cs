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
    /// Creates an Amazon Q in Connect AI Agent.
    /// </summary>
    [Cmdlet("New", "QCAIAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.AIAgentData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateAIAgent API operation.", Operation = new[] {"CreateAIAgent"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateAIAgentResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.AIAgentData or Amazon.QConnect.Model.CreateAIAgentResponse",
        "This cmdlet returns an Amazon.QConnect.Model.AIAgentData object.",
        "The service call response (type Amazon.QConnect.Model.CreateAIAgentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewQCAIAgentCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Answer Generation prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Answer Generation prompt used by the MANUAL_SEARCH
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId")]
        public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
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
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>The association configurations for overriding behavior on this AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] AnswerRecommendationAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter ManualSearchAIAgentConfiguration_AssociationConfiguration
        /// <summary>
        /// <para>
        /// <para>The association configurations for overriding behavior on this AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ManualSearchAIAgentConfiguration_AssociationConfigurations")]
        public Amazon.QConnect.Model.AssociationConfiguration[] ManualSearchAIAgentConfiguration_AssociationConfiguration { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Intent Labeling prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the AI Agent.</para>
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
        
        #region Parameter AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId
        /// <summary>
        /// <para>
        /// <para>The AI Prompt identifier for the Query Reformulation prompt used by the <c>ANSWER_RECOMMENDATION</c>
        /// AI Agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId")]
        public System.String AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId { get; set; }
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the AI Agent.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.AIAgentType")]
        public Amazon.QConnect.AIAgentType Type { get; set; }
        #endregion
        
        #region Parameter VisibilityStatus
        /// <summary>
        /// <para>
        /// <para>The visibility status of the AI Agent.</para>
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
        /// about idempotency, see <a href="http://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AiAgent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateAIAgentResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateAIAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AiAgent";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCAIAgent (CreateAIAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateAIAgentResponse, NewQCAIAgentCmdlet>(Select) ??
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
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
            if (this.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration);
            }
            context.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
            context.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = this.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
            context.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = this.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
            if (this.ManualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                context.ManualSearchAIAgentConfiguration_AssociationConfiguration = new List<Amazon.QConnect.Model.AssociationConfiguration>(this.ManualSearchAIAgentConfiguration_AssociationConfiguration);
            }
            context.Description = this.Description;
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
            var request = new Amazon.QConnect.Model.CreateAIAgentRequest();
            
            if (cmdletContext.AssistantId != null)
            {
                request.AssistantId = cmdletContext.AssistantId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.QConnect.Model.AIAgentConfiguration();
            Amazon.QConnect.Model.ManualSearchAIAgentConfiguration requestConfiguration_configuration_ManualSearchAIAgentConfiguration = null;
            
             // populate ManualSearchAIAgentConfiguration
            var requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_ManualSearchAIAgentConfiguration = new Amazon.QConnect.Model.ManualSearchAIAgentConfiguration();
            System.String requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId = cmdletContext.ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.AnswerGenerationAIPromptId = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AnswerGenerationAIPromptId;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.ManualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration = cmdletContext.ManualSearchAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_ManualSearchAIAgentConfiguration_manualSearchAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ManualSearchAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_ManualSearchAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_ManualSearchAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_ManualSearchAIAgentConfiguration != null)
            {
                request.Configuration.ManualSearchAIAgentConfiguration = requestConfiguration_configuration_ManualSearchAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.QConnect.Model.AnswerRecommendationAIAgentConfiguration requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = null;
            
             // populate AnswerRecommendationAIAgentConfiguration
            var requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = true;
            requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = new Amazon.QConnect.Model.AnswerRecommendationAIAgentConfiguration();
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.AnswerGenerationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            List<Amazon.QConnect.Model.AssociationConfiguration> requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration = cmdletContext.AnswerRecommendationAIAgentConfiguration_AssociationConfiguration;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.AssociationConfigurations = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_AssociationConfiguration;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.IntentLabelingGenerationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = null;
            if (cmdletContext.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId = cmdletContext.AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId != null)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration.QueryReformulationAIPromptId = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration_answerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId;
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration should be set to null
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfigurationIsNull)
            {
                requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration = null;
            }
            if (requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration != null)
            {
                request.Configuration.AnswerRecommendationAIAgentConfiguration = requestConfiguration_configuration_AnswerRecommendationAIAgentConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.QConnect.Model.CreateAIAgentResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateAIAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateAIAgent");
            try
            {
                #if DESKTOP
                return client.CreateAIAgent(request);
                #elif CORECLR
                return client.CreateAIAgentAsync(request).GetAwaiter().GetResult();
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
            public System.String AssistantId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> AnswerRecommendationAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_IntentLabelingGenerationAIPromptId { get; set; }
            public System.String AnswerRecommendationAIAgentConfiguration_QueryReformulationAIPromptId { get; set; }
            public System.String ManualSearchAIAgentConfiguration_AnswerGenerationAIPromptId { get; set; }
            public List<Amazon.QConnect.Model.AssociationConfiguration> ManualSearchAIAgentConfiguration_AssociationConfiguration { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.QConnect.AIAgentType Type { get; set; }
            public Amazon.QConnect.VisibilityStatus VisibilityStatus { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateAIAgentResponse, NewQCAIAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AiAgent;
        }
        
    }
}
