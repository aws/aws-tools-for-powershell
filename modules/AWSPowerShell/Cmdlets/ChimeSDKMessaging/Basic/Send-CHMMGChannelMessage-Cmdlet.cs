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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Sends a message to a particular channel that the member is a part of.
    /// 
    ///  <note><para>
    /// The <c>x-amz-chime-bearer</c> request header is mandatory. Use the ARN of the <c>AppInstanceUser</c>
    /// or <c>AppInstanceBot</c> that makes the API call as the value in the header.
    /// </para><para>
    /// Also, <c>STANDARD</c> messages can be up to 4KB in size and contain metadata. Metadata
    /// is arbitrary, and you can use it in a variety of ways, such as containing a link to
    /// an attachment.
    /// </para><para><c>CONTROL</c> messages are limited to 30 bytes and do not contain metadata.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "CHMMGChannelMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging SendChannelMessage API operation.", Operation = new[] {"SendChannelMessage"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse object containing multiple properties."
    )]
    public partial class SendCHMMGChannelMessageCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PushNotification_Body
        /// <summary>
        /// <para>
        /// <para>The body of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PushNotification_Body { get; set; }
        #endregion
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c> or <c>AppInstanceBot</c> that makes the API
        /// call.</para>
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
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The <c>Idempotency</c> token for each client request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The content of the channel message.</para>
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
        public System.String Content { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the channel message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter MessageAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes for the message, used for message filtering along with a <c>FilterRule</c>
        /// defined in the <c>PushNotificationPreferences</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MessageAttributes")]
        public System.Collections.Hashtable MessageAttribute { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The optional metadata for each message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter Persistence
        /// <summary>
        /// <para>
        /// <para>Boolean that controls whether the message is persisted on the back end. Required.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType")]
        public Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType Persistence { get; set; }
        #endregion
        
        #region Parameter SubChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the SubChannel in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubChannelId { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The target of a message. Must be a member of the channel, such as another user, a
        /// bot, or the sender. Only the target and the sender can view targeted messages. Only
        /// users who can see targeted messages can take actions on them. However, administrators
        /// can delete targeted messages that they can’t see. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ChimeSDKMessaging.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter PushNotification_Title
        /// <summary>
        /// <para>
        /// <para>The title of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PushNotification_Title { get; set; }
        #endregion
        
        #region Parameter PushNotification_Type
        /// <summary>
        /// <para>
        /// <para>Enum value that indicates the type of the push notification for a message. <c>DEFAULT</c>:
        /// Normal mobile push notification. <c>VOIP</c>: VOIP mobile push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.PushNotificationType")]
        public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of message, <c>STANDARD</c> or <c>CONTROL</c>.</para><para><c>STANDARD</c> messages can be up to 4KB in size and contain metadata. Metadata
        /// is arbitrary, and you can use it in a variety of ways, such as containing a link to
        /// an attachment.</para><para><c>CONTROL</c> messages are limited to 30 bytes and do not contain metadata.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelMessageType")]
        public Amazon.ChimeSDKMessaging.ChannelMessageType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CHMMGChannelMessage (SendChannelMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse, SendCHMMGChannelMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChimeBearer = this.ChimeBearer;
            #if MODULAR
            if (this.ChimeBearer == null && ParameterWasBound(nameof(this.ChimeBearer)))
            {
                WriteWarning("You are passing $null as a value for parameter ChimeBearer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.Content = this.Content;
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContentType = this.ContentType;
            if (this.MessageAttribute != null)
            {
                context.MessageAttribute = new Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.MessageAttribute.Keys)
                {
                    context.MessageAttribute.Add((String)hashKey, (Amazon.ChimeSDKMessaging.Model.MessageAttributeValue)(this.MessageAttribute[hashKey]));
                }
            }
            context.Metadata = this.Metadata;
            context.Persistence = this.Persistence;
            #if MODULAR
            if (this.Persistence == null && ParameterWasBound(nameof(this.Persistence)))
            {
                WriteWarning("You are passing $null as a value for parameter Persistence which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PushNotification_Body = this.PushNotification_Body;
            context.PushNotification_Title = this.PushNotification_Title;
            context.PushNotification_Type = this.PushNotification_Type;
            context.SubChannelId = this.SubChannelId;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.ChimeSDKMessaging.Model.Target>(this.Target);
            }
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
            var request = new Amazon.ChimeSDKMessaging.Model.SendChannelMessageRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.MessageAttribute != null)
            {
                request.MessageAttributes = cmdletContext.MessageAttribute;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Persistence != null)
            {
                request.Persistence = cmdletContext.Persistence;
            }
            
             // populate PushNotification
            var requestPushNotificationIsNull = true;
            request.PushNotification = new Amazon.ChimeSDKMessaging.Model.PushNotificationConfiguration();
            System.String requestPushNotification_pushNotification_Body = null;
            if (cmdletContext.PushNotification_Body != null)
            {
                requestPushNotification_pushNotification_Body = cmdletContext.PushNotification_Body;
            }
            if (requestPushNotification_pushNotification_Body != null)
            {
                request.PushNotification.Body = requestPushNotification_pushNotification_Body;
                requestPushNotificationIsNull = false;
            }
            System.String requestPushNotification_pushNotification_Title = null;
            if (cmdletContext.PushNotification_Title != null)
            {
                requestPushNotification_pushNotification_Title = cmdletContext.PushNotification_Title;
            }
            if (requestPushNotification_pushNotification_Title != null)
            {
                request.PushNotification.Title = requestPushNotification_pushNotification_Title;
                requestPushNotificationIsNull = false;
            }
            Amazon.ChimeSDKMessaging.PushNotificationType requestPushNotification_pushNotification_Type = null;
            if (cmdletContext.PushNotification_Type != null)
            {
                requestPushNotification_pushNotification_Type = cmdletContext.PushNotification_Type;
            }
            if (requestPushNotification_pushNotification_Type != null)
            {
                request.PushNotification.Type = requestPushNotification_pushNotification_Type;
                requestPushNotificationIsNull = false;
            }
             // determine if request.PushNotification should be set to null
            if (requestPushNotificationIsNull)
            {
                request.PushNotification = null;
            }
            if (cmdletContext.SubChannelId != null)
            {
                request.SubChannelId = cmdletContext.SubChannelId;
            }
            if (cmdletContext.Target != null)
            {
                request.Target = cmdletContext.Target;
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
        
        private Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.SendChannelMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "SendChannelMessage");
            try
            {
                return client.SendChannelMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ChimeBearer { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Content { get; set; }
            public System.String ContentType { get; set; }
            public Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue> MessageAttribute { get; set; }
            public System.String Metadata { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelMessagePersistenceType Persistence { get; set; }
            public System.String PushNotification_Body { get; set; }
            public System.String PushNotification_Title { get; set; }
            public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
            public System.String SubChannelId { get; set; }
            public List<Amazon.ChimeSDKMessaging.Model.Target> Target { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelMessageType Type { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.SendChannelMessageResponse, SendCHMMGChannelMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
