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
using Amazon.QBusiness;
using Amazon.QBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.QBUS
{
    /// <summary>
    /// Starts or continues a non-streaming Amazon Q Business conversation.
    /// </summary>
    [Cmdlet("Set", "QBUSChatSync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QBusiness.Model.ChatSyncResponse")]
    [AWSCmdlet("Calls the Amazon QBusiness ChatSync API operation.", Operation = new[] {"ChatSync"}, SelectReturnType = typeof(Amazon.QBusiness.Model.ChatSyncResponse))]
    [AWSCmdletOutput("Amazon.QBusiness.Model.ChatSyncResponse",
        "This cmdlet returns an Amazon.QBusiness.Model.ChatSyncResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetQBUSChatSyncCmdlet : AmazonQBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business application linked to the Amazon Q Business
        /// conversation.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Attachment
        /// <summary>
        /// <para>
        /// <para>A list of files uploaded directly during chat. You can upload a maximum of 5 files
        /// of upto 10 MB each.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attachments")]
        public Amazon.QBusiness.Model.AttachmentInput[] Attachment { get; set; }
        #endregion
        
        #region Parameter AttributeFilter
        /// <summary>
        /// <para>
        /// <para>Enables filtering of Amazon Q Business web experience responses based on document
        /// attributes or metadata fields.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QBusiness.Model.AttributeFilter AttributeFilter { get; set; }
        #endregion
        
        #region Parameter ChatMode
        /// <summary>
        /// <para>
        /// <para>The chat modes available in an Amazon Q Business web experience.</para><ul><li><para><c>RETRIEVAL_MODE</c> - The default chat mode for an Amazon Q Business application.
        /// When this mode is enabled, Amazon Q Business generates responses only from data sources
        /// connected to an Amazon Q Business application.</para></li><li><para><c>CREATOR_MODE</c> - By selecting this mode, users can choose to generate responses
        /// only from the LLM knowledge, without consulting connected data sources, for a chat
        /// request.</para></li><li><para><c>PLUGIN_MODE</c> - By selecting this mode, users can choose to use plugins in chat.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/guardrails.html">Admin
        /// controls and guardrails</a>, <a href="https://docs.aws.amazon.com/amazonq/latest/qbusiness-ug/plugins.html">Plugins</a>,
        /// and <a href="https://docs.aws.amazon.com/amazonq/latest/business-use-dg/using-web-experience.html#chat-source-scope">Conversation
        /// settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QBusiness.ChatMode")]
        public Amazon.QBusiness.ChatMode ChatMode { get; set; }
        #endregion
        
        #region Parameter ConversationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q Business conversation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConversationId { get; set; }
        #endregion
        
        #region Parameter ParentMessageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the previous end user text input message in a conversation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParentMessageId { get; set; }
        #endregion
        
        #region Parameter ActionExecution_Payload
        /// <summary>
        /// <para>
        /// <para>A mapping of field names to the field values in input that an end user provides to
        /// Amazon Q Business requests to perform their plugin action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ActionExecution_Payload { get; set; }
        #endregion
        
        #region Parameter ActionExecution_PayloadFieldNameSeparator
        /// <summary>
        /// <para>
        /// <para>A string used to retain information about the hierarchical contexts within an action
        /// execution event payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionExecution_PayloadFieldNameSeparator { get; set; }
        #endregion
        
        #region Parameter ActionExecution_PluginId
        /// <summary>
        /// <para>
        /// <para>The identifier of the plugin the action is attached to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActionExecution_PluginId { get; set; }
        #endregion
        
        #region Parameter PluginConfiguration_PluginId
        /// <summary>
        /// <para>
        /// <para> The identifier of the plugin you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChatModeConfiguration_PluginConfiguration_PluginId")]
        public System.String PluginConfiguration_PluginId { get; set; }
        #endregion
        
        #region Parameter UserGroup
        /// <summary>
        /// <para>
        /// <para>The groups that a user associated with the chat input belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserGroups")]
        public System.String[] UserGroup { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user attached to the chat input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter UserMessage
        /// <summary>
        /// <para>
        /// <para>A end user message in a conversation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserMessage { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that you provide to identify a chat request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QBusiness.Model.ChatSyncResponse).
        /// Specifying the name of a property of type Amazon.QBusiness.Model.ChatSyncResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-QBUSChatSync (ChatSync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QBusiness.Model.ChatSyncResponse, SetQBUSChatSyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ActionExecution_Payload != null)
            {
                context.ActionExecution_Payload = new Dictionary<System.String, Amazon.QBusiness.Model.ActionExecutionPayloadField>(StringComparer.Ordinal);
                foreach (var hashKey in this.ActionExecution_Payload.Keys)
                {
                    context.ActionExecution_Payload.Add((String)hashKey, (Amazon.QBusiness.Model.ActionExecutionPayloadField)(this.ActionExecution_Payload[hashKey]));
                }
            }
            context.ActionExecution_PayloadFieldNameSeparator = this.ActionExecution_PayloadFieldNameSeparator;
            context.ActionExecution_PluginId = this.ActionExecution_PluginId;
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Attachment != null)
            {
                context.Attachment = new List<Amazon.QBusiness.Model.AttachmentInput>(this.Attachment);
            }
            context.AttributeFilter = this.AttributeFilter;
            context.ChatMode = this.ChatMode;
            context.PluginConfiguration_PluginId = this.PluginConfiguration_PluginId;
            context.ClientToken = this.ClientToken;
            context.ConversationId = this.ConversationId;
            context.ParentMessageId = this.ParentMessageId;
            if (this.UserGroup != null)
            {
                context.UserGroup = new List<System.String>(this.UserGroup);
            }
            context.UserId = this.UserId;
            context.UserMessage = this.UserMessage;
            
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
            var request = new Amazon.QBusiness.Model.ChatSyncRequest();
            
            
             // populate ActionExecution
            var requestActionExecutionIsNull = true;
            request.ActionExecution = new Amazon.QBusiness.Model.ActionExecution();
            Dictionary<System.String, Amazon.QBusiness.Model.ActionExecutionPayloadField> requestActionExecution_actionExecution_Payload = null;
            if (cmdletContext.ActionExecution_Payload != null)
            {
                requestActionExecution_actionExecution_Payload = cmdletContext.ActionExecution_Payload;
            }
            if (requestActionExecution_actionExecution_Payload != null)
            {
                request.ActionExecution.Payload = requestActionExecution_actionExecution_Payload;
                requestActionExecutionIsNull = false;
            }
            System.String requestActionExecution_actionExecution_PayloadFieldNameSeparator = null;
            if (cmdletContext.ActionExecution_PayloadFieldNameSeparator != null)
            {
                requestActionExecution_actionExecution_PayloadFieldNameSeparator = cmdletContext.ActionExecution_PayloadFieldNameSeparator;
            }
            if (requestActionExecution_actionExecution_PayloadFieldNameSeparator != null)
            {
                request.ActionExecution.PayloadFieldNameSeparator = requestActionExecution_actionExecution_PayloadFieldNameSeparator;
                requestActionExecutionIsNull = false;
            }
            System.String requestActionExecution_actionExecution_PluginId = null;
            if (cmdletContext.ActionExecution_PluginId != null)
            {
                requestActionExecution_actionExecution_PluginId = cmdletContext.ActionExecution_PluginId;
            }
            if (requestActionExecution_actionExecution_PluginId != null)
            {
                request.ActionExecution.PluginId = requestActionExecution_actionExecution_PluginId;
                requestActionExecutionIsNull = false;
            }
             // determine if request.ActionExecution should be set to null
            if (requestActionExecutionIsNull)
            {
                request.ActionExecution = null;
            }
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.Attachment != null)
            {
                request.Attachments = cmdletContext.Attachment;
            }
            if (cmdletContext.AttributeFilter != null)
            {
                request.AttributeFilter = cmdletContext.AttributeFilter;
            }
            if (cmdletContext.ChatMode != null)
            {
                request.ChatMode = cmdletContext.ChatMode;
            }
            
             // populate ChatModeConfiguration
            var requestChatModeConfigurationIsNull = true;
            request.ChatModeConfiguration = new Amazon.QBusiness.Model.ChatModeConfiguration();
            Amazon.QBusiness.Model.PluginConfiguration requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration = null;
            
             // populate PluginConfiguration
            var requestChatModeConfiguration_chatModeConfiguration_PluginConfigurationIsNull = true;
            requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration = new Amazon.QBusiness.Model.PluginConfiguration();
            System.String requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration_pluginConfiguration_PluginId = null;
            if (cmdletContext.PluginConfiguration_PluginId != null)
            {
                requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration_pluginConfiguration_PluginId = cmdletContext.PluginConfiguration_PluginId;
            }
            if (requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration_pluginConfiguration_PluginId != null)
            {
                requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration.PluginId = requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration_pluginConfiguration_PluginId;
                requestChatModeConfiguration_chatModeConfiguration_PluginConfigurationIsNull = false;
            }
             // determine if requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration should be set to null
            if (requestChatModeConfiguration_chatModeConfiguration_PluginConfigurationIsNull)
            {
                requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration = null;
            }
            if (requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration != null)
            {
                request.ChatModeConfiguration.PluginConfiguration = requestChatModeConfiguration_chatModeConfiguration_PluginConfiguration;
                requestChatModeConfigurationIsNull = false;
            }
             // determine if request.ChatModeConfiguration should be set to null
            if (requestChatModeConfigurationIsNull)
            {
                request.ChatModeConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConversationId != null)
            {
                request.ConversationId = cmdletContext.ConversationId;
            }
            if (cmdletContext.ParentMessageId != null)
            {
                request.ParentMessageId = cmdletContext.ParentMessageId;
            }
            if (cmdletContext.UserGroup != null)
            {
                request.UserGroups = cmdletContext.UserGroup;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.UserMessage != null)
            {
                request.UserMessage = cmdletContext.UserMessage;
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
        
        private Amazon.QBusiness.Model.ChatSyncResponse CallAWSServiceOperation(IAmazonQBusiness client, Amazon.QBusiness.Model.ChatSyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QBusiness", "ChatSync");
            try
            {
                #if DESKTOP
                return client.ChatSync(request);
                #elif CORECLR
                return client.ChatSyncAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.QBusiness.Model.ActionExecutionPayloadField> ActionExecution_Payload { get; set; }
            public System.String ActionExecution_PayloadFieldNameSeparator { get; set; }
            public System.String ActionExecution_PluginId { get; set; }
            public System.String ApplicationId { get; set; }
            public List<Amazon.QBusiness.Model.AttachmentInput> Attachment { get; set; }
            public Amazon.QBusiness.Model.AttributeFilter AttributeFilter { get; set; }
            public Amazon.QBusiness.ChatMode ChatMode { get; set; }
            public System.String PluginConfiguration_PluginId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ConversationId { get; set; }
            public System.String ParentMessageId { get; set; }
            public List<System.String> UserGroup { get; set; }
            public System.String UserId { get; set; }
            public System.String UserMessage { get; set; }
            public System.Func<Amazon.QBusiness.Model.ChatSyncResponse, SetQBUSChatSyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
