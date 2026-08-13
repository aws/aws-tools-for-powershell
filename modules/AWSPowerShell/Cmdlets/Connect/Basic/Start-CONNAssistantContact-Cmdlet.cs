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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Starts a chat contact with an AI agent.
    /// 
    ///  
    /// <para>
    /// Use the returned <c>ParticipantToken</c> to call the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// API.
    /// </para><para>
    /// For more information about chat, see the following topics in the <i>Connect Customer
    /// Administrator Guide</i>: 
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/web-and-mobile-chat.html">Concepts:
    /// Web and mobile messaging capabilities in Connect Customer</a></para></li><li><para><a href="https://docs.aws.amazon.com/connect/latest/adminguide/security-best-practices.html#bp-security-chat">Connect
    /// Customer Chat security best practices</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "CONNAssistantContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartAssistantContactResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartAssistantContact API operation.", Operation = new[] {"StartAssistantContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartAssistantContactResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartAssistantContactResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartAssistantContactResponse object containing multiple properties."
    )]
    public partial class StartCONNAssistantContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AiAgent_AiAgentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AI agent that participates in the contact.</para>
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
        public System.String AiAgent_AiAgentId { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs to associate with the contact. Amazon Connect makes these
        /// attributes available to flows as standard contact attributes.</para><para>You can provide up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can contain only alphanumeric characters, dashes, and underscores.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter InitialMessage_Content
        /// <summary>
        /// <para>
        /// <para>The content of the chat message. Maximum of 16,384 bytes for all content types (<c>text/plain</c>,
        /// <c>text/markdown</c>, <c>application/json</c>, and <c>application/vnd.amazonaws.connect.message.interactive.response</c>).</para><para>Some messaging channels enforce lower limits. For channel-specific message size limits,
        /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/feature-limits.html#chat-message-size-limits">Chat
        /// message size limits by channel</a> in the <i>Amazon Connect Customer Administrator
        /// Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialMessage_Content { get; set; }
        #endregion
        
        #region Parameter InitialMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of the content. Supported types are <c>text/plain</c>, <c>text/markdown</c>,
        /// <c>application/json</c>, and <c>application/vnd.amazonaws.connect.message.interactive.response</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>Display name of the participant.</para>
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
        public System.String ParticipantDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PersistentChat_RehydrationType
        /// <summary>
        /// <para>
        /// <para>The contactId that is used for rehydration depends on the rehydration type. RehydrationType
        /// is required for persistent chat. </para><ul><li><para><c>ENTIRE_PAST_SESSION</c>: Rehydrates a chat from the most recently terminated past
        /// chat contact of the specified past ended chat session. To use this type, provide the
        /// <c>initialContactId</c> of the past ended chat session in the <c>sourceContactId</c>
        /// field. In this type, Connect Customer determines the most recent chat contact on the
        /// specified chat session that has ended, and uses it to start a persistent chat. </para></li><li><para><c>FROM_SEGMENT</c>: Rehydrates a chat from the past chat contact that is specified
        /// in the <c>sourceContactId</c> field. </para></li></ul><para>The actual contactId used for rehydration is provided in the response of this API.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.RehydrationType")]
        public Amazon.Connect.RehydrationType PersistentChat_RehydrationType { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of an Connect Customer contact related to the new assistant contact.</para><note><para>You cannot provide both <c>RelatedContactId</c> and <c>PersistentChat</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter PersistentChat_SourceContactId
        /// <summary>
        /// <para>
        /// <para>The contactId from which a persistent chat session must be started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PersistentChat_SourceContactId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartAssistantContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartAssistantContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNAssistantContact (StartAssistantContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartAssistantContactResponse, StartCONNAssistantContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AiAgent_AiAgentId = this.AiAgent_AiAgentId;
            #if MODULAR
            if (this.AiAgent_AiAgentId == null && ParameterWasBound(nameof(this.AiAgent_AiAgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AiAgent_AiAgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.InitialMessage_Content = this.InitialMessage_Content;
            context.InitialMessage_ContentType = this.InitialMessage_ContentType;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            #if MODULAR
            if (this.ParticipantDetails_DisplayName == null && ParameterWasBound(nameof(this.ParticipantDetails_DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantDetails_DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersistentChat_RehydrationType = this.PersistentChat_RehydrationType;
            context.PersistentChat_SourceContactId = this.PersistentChat_SourceContactId;
            context.RelatedContactId = this.RelatedContactId;
            
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
            var request = new Amazon.Connect.Model.StartAssistantContactRequest();
            
            
             // populate AiAgent
            var requestAiAgentIsNull = true;
            request.AiAgent = new Amazon.Connect.Model.AiAgentInput();
            System.String requestAiAgent_aiAgent_AiAgentId = null;
            if (cmdletContext.AiAgent_AiAgentId != null)
            {
                requestAiAgent_aiAgent_AiAgentId = cmdletContext.AiAgent_AiAgentId;
            }
            if (requestAiAgent_aiAgent_AiAgentId != null)
            {
                request.AiAgent.AiAgentId = requestAiAgent_aiAgent_AiAgentId;
                requestAiAgentIsNull = false;
            }
             // determine if request.AiAgent should be set to null
            if (requestAiAgentIsNull)
            {
                request.AiAgent = null;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate InitialMessage
            var requestInitialMessageIsNull = true;
            request.InitialMessage = new Amazon.Connect.Model.ChatMessage();
            System.String requestInitialMessage_initialMessage_Content = null;
            if (cmdletContext.InitialMessage_Content != null)
            {
                requestInitialMessage_initialMessage_Content = cmdletContext.InitialMessage_Content;
            }
            if (requestInitialMessage_initialMessage_Content != null)
            {
                request.InitialMessage.Content = requestInitialMessage_initialMessage_Content;
                requestInitialMessageIsNull = false;
            }
            System.String requestInitialMessage_initialMessage_ContentType = null;
            if (cmdletContext.InitialMessage_ContentType != null)
            {
                requestInitialMessage_initialMessage_ContentType = cmdletContext.InitialMessage_ContentType;
            }
            if (requestInitialMessage_initialMessage_ContentType != null)
            {
                request.InitialMessage.ContentType = requestInitialMessage_initialMessage_ContentType;
                requestInitialMessageIsNull = false;
            }
             // determine if request.InitialMessage should be set to null
            if (requestInitialMessageIsNull)
            {
                request.InitialMessage = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate ParticipantDetails
            var requestParticipantDetailsIsNull = true;
            request.ParticipantDetails = new Amazon.Connect.Model.ParticipantDetails();
            System.String requestParticipantDetails_participantDetails_DisplayName = null;
            if (cmdletContext.ParticipantDetails_DisplayName != null)
            {
                requestParticipantDetails_participantDetails_DisplayName = cmdletContext.ParticipantDetails_DisplayName;
            }
            if (requestParticipantDetails_participantDetails_DisplayName != null)
            {
                request.ParticipantDetails.DisplayName = requestParticipantDetails_participantDetails_DisplayName;
                requestParticipantDetailsIsNull = false;
            }
             // determine if request.ParticipantDetails should be set to null
            if (requestParticipantDetailsIsNull)
            {
                request.ParticipantDetails = null;
            }
            
             // populate PersistentChat
            var requestPersistentChatIsNull = true;
            request.PersistentChat = new Amazon.Connect.Model.PersistentChat();
            Amazon.Connect.RehydrationType requestPersistentChat_persistentChat_RehydrationType = null;
            if (cmdletContext.PersistentChat_RehydrationType != null)
            {
                requestPersistentChat_persistentChat_RehydrationType = cmdletContext.PersistentChat_RehydrationType;
            }
            if (requestPersistentChat_persistentChat_RehydrationType != null)
            {
                request.PersistentChat.RehydrationType = requestPersistentChat_persistentChat_RehydrationType;
                requestPersistentChatIsNull = false;
            }
            System.String requestPersistentChat_persistentChat_SourceContactId = null;
            if (cmdletContext.PersistentChat_SourceContactId != null)
            {
                requestPersistentChat_persistentChat_SourceContactId = cmdletContext.PersistentChat_SourceContactId;
            }
            if (requestPersistentChat_persistentChat_SourceContactId != null)
            {
                request.PersistentChat.SourceContactId = requestPersistentChat_persistentChat_SourceContactId;
                requestPersistentChatIsNull = false;
            }
             // determine if request.PersistentChat should be set to null
            if (requestPersistentChatIsNull)
            {
                request.PersistentChat = null;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
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
        
        private Amazon.Connect.Model.StartAssistantContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartAssistantContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartAssistantContact");
            try
            {
                return client.StartAssistantContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AiAgent_AiAgentId { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String InitialMessage_Content { get; set; }
            public System.String InitialMessage_ContentType { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public Amazon.Connect.RehydrationType PersistentChat_RehydrationType { get; set; }
            public System.String PersistentChat_SourceContactId { get; set; }
            public System.String RelatedContactId { get; set; }
            public System.Func<Amazon.Connect.Model.StartAssistantContactResponse, StartCONNAssistantContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
