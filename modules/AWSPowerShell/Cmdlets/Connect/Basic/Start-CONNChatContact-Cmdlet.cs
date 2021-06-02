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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Initiates a contact flow to start a new chat for the customer. Response of this API
    /// provides a token required to obtain credentials from the <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// API in the Amazon Connect Participant Service.
    /// 
    ///  
    /// <para>
    /// When a new chat contact is successfully created, clients must subscribe to the participant’s
    /// connection for the created chat within 5 minutes. This is achieved by invoking <a href="https://docs.aws.amazon.com/connect-participant/latest/APIReference/API_CreateParticipantConnection.html">CreateParticipantConnection</a>
    /// with WEBSOCKET and CONNECTION_CREDENTIALS. 
    /// </para><para>
    /// A 429 error occurs in two situations:
    /// </para><ul><li><para>
    /// API rate limit is exceeded. API TPS throttling returns a <code>TooManyRequests</code>
    /// exception.
    /// </para></li><li><para>
    /// The <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html">quota
    /// for concurrent active chats</a> is exceeded. Active chat throttling returns a <code>LimitExceededException</code>.
    /// </para></li></ul><para>
    /// For more information about chat, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/chat.html">Chat</a>
    /// in the <i>Amazon Connect Administrator Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CONNChatContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.StartChatContactResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service StartChatContact API operation.", Operation = new[] {"StartChatContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartChatContactResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.StartChatContactResponse",
        "This cmdlet returns an Amazon.Connect.Model.StartChatContactResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCONNChatContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes. They can be accessed in contact flows just like any other contact
        /// attributes. </para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact flow for initiating the chat. To see the ContactFlowId
        /// in the Amazon Connect console user interface, on the navigation menu go to <b>Routing</b>,
        /// <b>Contact Flows</b>. Choose the contact flow. On the contact flow page, under the
        /// name of the contact flow, choose <b>Show additional flow information</b>. The ContactFlowId
        /// is the last part of the ARN, shown here in bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
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
        public System.String ContactFlowId { get; set; }
        #endregion
        
        #region Parameter InitialMessage_Content
        /// <summary>
        /// <para>
        /// <para>The content of the chat message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialMessage_Content { get; set; }
        #endregion
        
        #region Parameter InitialMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>The type of the content. Supported types are text and plain.</para>
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
        /// <para>The identifier of the Amazon Connect instance. You can find the instanceId in the
        /// ARN of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartChatContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartChatContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactFlowId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactFlowId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNChatContact (StartChatContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartChatContactResponse, StartCONNChatContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactFlowId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            #if MODULAR
            if (this.ContactFlowId == null && ParameterWasBound(nameof(this.ContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Connect.Model.StartChatContactRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
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
        
        private Amazon.Connect.Model.StartChatContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartChatContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartChatContact");
            try
            {
                #if DESKTOP
                return client.StartChatContact(request);
                #elif CORECLR
                return client.StartChatContactAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String InitialMessage_Content { get; set; }
            public System.String InitialMessage_ContentType { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public System.Func<Amazon.Connect.Model.StartChatContactResponse, StartCONNChatContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
