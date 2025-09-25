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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Submits a message to the Amazon Q in Connect session.
    /// </summary>
    [Cmdlet("Send", "QCMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.SendMessageResponse")]
    [AWSCmdlet("Calls the Amazon Q Connect SendMessage API operation.", Operation = new[] {"SendMessage"}, SelectReturnType = typeof(Amazon.QConnect.Model.SendMessageResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.SendMessageResponse",
        "This cmdlet returns an Amazon.QConnect.Model.SendMessageResponse object containing multiple properties."
    )]
    public partial class SendQCMessageCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssistantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect assistant.</para>
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
        
        #region Parameter Configuration_GenerateFillerMessage
        /// <summary>
        /// <para>
        /// <para>Generates a filler response when tool selection is <c>QUESTION</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Configuration_GenerateFillerMessage { get; set; }
        #endregion
        
        #region Parameter ConversationContext_SelfServiceConversationHistory
        /// <summary>
        /// <para>
        /// <para>The self service conversation history before the Amazon Q in Connect session.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.QConnect.Model.SelfServiceConversationHistory[] ConversationContext_SelfServiceConversationHistory { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Q in Connect session.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The message type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QConnect.MessageType")]
        public Amazon.QConnect.MessageType Type { get; set; }
        #endregion
        
        #region Parameter Text_Value
        /// <summary>
        /// <para>
        /// <para>The value of the message data in text type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Message_Value_Text_Value")]
        public System.String Text_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the AWS SDK populates this field.For more information
        /// about idempotency, see Making retries safe with idempotent APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.SendMessageResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.SendMessageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-QCMessage (SendMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.SendMessageResponse, SendQCMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssistantId = this.AssistantId;
            #if MODULAR
            if (this.AssistantId == null && ParameterWasBound(nameof(this.AssistantId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssistantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Configuration_GenerateFillerMessage = this.Configuration_GenerateFillerMessage;
            if (this.ConversationContext_SelfServiceConversationHistory != null)
            {
                context.ConversationContext_SelfServiceConversationHistory = new List<Amazon.QConnect.Model.SelfServiceConversationHistory>(this.ConversationContext_SelfServiceConversationHistory);
            }
            context.Text_Value = this.Text_Value;
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.SendMessageRequest();
            
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
            request.Configuration = new Amazon.QConnect.Model.MessageConfiguration();
            System.Boolean? requestConfiguration_configuration_GenerateFillerMessage = null;
            if (cmdletContext.Configuration_GenerateFillerMessage != null)
            {
                requestConfiguration_configuration_GenerateFillerMessage = cmdletContext.Configuration_GenerateFillerMessage.Value;
            }
            if (requestConfiguration_configuration_GenerateFillerMessage != null)
            {
                request.Configuration.GenerateFillerMessage = requestConfiguration_configuration_GenerateFillerMessage.Value;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            
             // populate ConversationContext
            var requestConversationContextIsNull = true;
            request.ConversationContext = new Amazon.QConnect.Model.ConversationContext();
            List<Amazon.QConnect.Model.SelfServiceConversationHistory> requestConversationContext_conversationContext_SelfServiceConversationHistory = null;
            if (cmdletContext.ConversationContext_SelfServiceConversationHistory != null)
            {
                requestConversationContext_conversationContext_SelfServiceConversationHistory = cmdletContext.ConversationContext_SelfServiceConversationHistory;
            }
            if (requestConversationContext_conversationContext_SelfServiceConversationHistory != null)
            {
                request.ConversationContext.SelfServiceConversationHistory = requestConversationContext_conversationContext_SelfServiceConversationHistory;
                requestConversationContextIsNull = false;
            }
             // determine if request.ConversationContext should be set to null
            if (requestConversationContextIsNull)
            {
                request.ConversationContext = null;
            }
            
             // populate Message
            var requestMessageIsNull = true;
            request.Message = new Amazon.QConnect.Model.MessageInput();
            Amazon.QConnect.Model.MessageData requestMessage_message_Value = null;
            
             // populate Value
            var requestMessage_message_ValueIsNull = true;
            requestMessage_message_Value = new Amazon.QConnect.Model.MessageData();
            Amazon.QConnect.Model.TextMessage requestMessage_message_Value_message_Value_Text = null;
            
             // populate Text
            var requestMessage_message_Value_message_Value_TextIsNull = true;
            requestMessage_message_Value_message_Value_Text = new Amazon.QConnect.Model.TextMessage();
            System.String requestMessage_message_Value_message_Value_Text_text_Value = null;
            if (cmdletContext.Text_Value != null)
            {
                requestMessage_message_Value_message_Value_Text_text_Value = cmdletContext.Text_Value;
            }
            if (requestMessage_message_Value_message_Value_Text_text_Value != null)
            {
                requestMessage_message_Value_message_Value_Text.Value = requestMessage_message_Value_message_Value_Text_text_Value;
                requestMessage_message_Value_message_Value_TextIsNull = false;
            }
             // determine if requestMessage_message_Value_message_Value_Text should be set to null
            if (requestMessage_message_Value_message_Value_TextIsNull)
            {
                requestMessage_message_Value_message_Value_Text = null;
            }
            if (requestMessage_message_Value_message_Value_Text != null)
            {
                requestMessage_message_Value.Text = requestMessage_message_Value_message_Value_Text;
                requestMessage_message_ValueIsNull = false;
            }
             // determine if requestMessage_message_Value should be set to null
            if (requestMessage_message_ValueIsNull)
            {
                requestMessage_message_Value = null;
            }
            if (requestMessage_message_Value != null)
            {
                request.Message.Value = requestMessage_message_Value;
                requestMessageIsNull = false;
            }
             // determine if request.Message should be set to null
            if (requestMessageIsNull)
            {
                request.Message = null;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.QConnect.Model.SendMessageResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.SendMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "SendMessage");
            try
            {
                return client.SendMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Configuration_GenerateFillerMessage { get; set; }
            public List<Amazon.QConnect.Model.SelfServiceConversationHistory> ConversationContext_SelfServiceConversationHistory { get; set; }
            public System.String Text_Value { get; set; }
            public System.String SessionId { get; set; }
            public Amazon.QConnect.MessageType Type { get; set; }
            public System.Func<Amazon.QConnect.Model.SendMessageResponse, SendQCMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
