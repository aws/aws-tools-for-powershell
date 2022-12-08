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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Calls back Chime SDK Messaging with a processing response message. This should be
    /// invoked from the processor Lambda. This is a developer API.
    /// 
    ///  
    /// <para>
    /// You can return one of the following processing responses:
    /// </para><ul><li><para>
    /// Update message content or metadata
    /// </para></li><li><para>
    /// Deny a message
    /// </para></li><li><para>
    /// Make no changes to the message
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Send", "CHMMGChannelFlowCallback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging ChannelFlowCallback API operation.", Operation = new[] {"ChannelFlowCallback"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendCHMMGChannelFlowCallbackCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        #region Parameter PushNotification_Body
        /// <summary>
        /// <para>
        /// <para>The body of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelMessage_PushNotification_Body")]
        public System.String PushNotification_Body { get; set; }
        #endregion
        
        #region Parameter CallbackId
        /// <summary>
        /// <para>
        /// <para>The identifier passed to the processor by the service when invoked. Use the identifier
        /// to call back the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CallbackId { get; set; }
        #endregion
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ChannelMessage_Content
        /// <summary>
        /// <para>
        /// <para>The message content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelMessage_Content { get; set; }
        #endregion
        
        #region Parameter DeleteResource
        /// <summary>
        /// <para>
        /// <para>When a processor determines that a message needs to be <code>DENIED</code>, pass this
        /// parameter with a value of true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteResource { get; set; }
        #endregion
        
        #region Parameter ChannelMessage_MessageAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes for the message, used for message filtering along with a <code>FilterRule</code>
        /// defined in the <code>PushNotificationPreferences</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelMessage_MessageAttributes")]
        public System.Collections.Hashtable ChannelMessage_MessageAttribute { get; set; }
        #endregion
        
        #region Parameter ChannelMessage_MessageId
        /// <summary>
        /// <para>
        /// <para>The message ID.</para>
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
        public System.String ChannelMessage_MessageId { get; set; }
        #endregion
        
        #region Parameter ChannelMessage_Metadata
        /// <summary>
        /// <para>
        /// <para>The message metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelMessage_Metadata { get; set; }
        #endregion
        
        #region Parameter ChannelMessage_SubChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the SubChannel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelMessage_SubChannelId { get; set; }
        #endregion
        
        #region Parameter PushNotification_Title
        /// <summary>
        /// <para>
        /// <para>The title of the push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelMessage_PushNotification_Title")]
        public System.String PushNotification_Title { get; set; }
        #endregion
        
        #region Parameter PushNotification_Type
        /// <summary>
        /// <para>
        /// <para>Enum value that indicates the type of the push notification for a message. <code>DEFAULT</code>:
        /// Normal mobile push notification. <code>VOIP</code>: VOIP mobile push notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelMessage_PushNotification_Type")]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.PushNotificationType")]
        public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelMessage_MessageId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelMessage_MessageId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelMessage_MessageId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelMessage_MessageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CHMMGChannelFlowCallback (ChannelFlowCallback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse, SendCHMMGChannelFlowCallbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelMessage_MessageId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CallbackId = this.CallbackId;
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelMessage_Content = this.ChannelMessage_Content;
            if (this.ChannelMessage_MessageAttribute != null)
            {
                context.ChannelMessage_MessageAttribute = new Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChannelMessage_MessageAttribute.Keys)
                {
                    context.ChannelMessage_MessageAttribute.Add((String)hashKey, (MessageAttributeValue)(this.ChannelMessage_MessageAttribute[hashKey]));
                }
            }
            context.ChannelMessage_MessageId = this.ChannelMessage_MessageId;
            #if MODULAR
            if (this.ChannelMessage_MessageId == null && ParameterWasBound(nameof(this.ChannelMessage_MessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelMessage_MessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelMessage_Metadata = this.ChannelMessage_Metadata;
            context.PushNotification_Body = this.PushNotification_Body;
            context.PushNotification_Title = this.PushNotification_Title;
            context.PushNotification_Type = this.PushNotification_Type;
            context.ChannelMessage_SubChannelId = this.ChannelMessage_SubChannelId;
            context.DeleteResource = this.DeleteResource;
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackRequest();
            
            if (cmdletContext.CallbackId != null)
            {
                request.CallbackId = cmdletContext.CallbackId;
            }
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            
             // populate ChannelMessage
            var requestChannelMessageIsNull = true;
            request.ChannelMessage = new Amazon.ChimeSDKMessaging.Model.ChannelMessageCallback();
            System.String requestChannelMessage_channelMessage_Content = null;
            if (cmdletContext.ChannelMessage_Content != null)
            {
                requestChannelMessage_channelMessage_Content = cmdletContext.ChannelMessage_Content;
            }
            if (requestChannelMessage_channelMessage_Content != null)
            {
                request.ChannelMessage.Content = requestChannelMessage_channelMessage_Content;
                requestChannelMessageIsNull = false;
            }
            Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue> requestChannelMessage_channelMessage_MessageAttribute = null;
            if (cmdletContext.ChannelMessage_MessageAttribute != null)
            {
                requestChannelMessage_channelMessage_MessageAttribute = cmdletContext.ChannelMessage_MessageAttribute;
            }
            if (requestChannelMessage_channelMessage_MessageAttribute != null)
            {
                request.ChannelMessage.MessageAttributes = requestChannelMessage_channelMessage_MessageAttribute;
                requestChannelMessageIsNull = false;
            }
            System.String requestChannelMessage_channelMessage_MessageId = null;
            if (cmdletContext.ChannelMessage_MessageId != null)
            {
                requestChannelMessage_channelMessage_MessageId = cmdletContext.ChannelMessage_MessageId;
            }
            if (requestChannelMessage_channelMessage_MessageId != null)
            {
                request.ChannelMessage.MessageId = requestChannelMessage_channelMessage_MessageId;
                requestChannelMessageIsNull = false;
            }
            System.String requestChannelMessage_channelMessage_Metadata = null;
            if (cmdletContext.ChannelMessage_Metadata != null)
            {
                requestChannelMessage_channelMessage_Metadata = cmdletContext.ChannelMessage_Metadata;
            }
            if (requestChannelMessage_channelMessage_Metadata != null)
            {
                request.ChannelMessage.Metadata = requestChannelMessage_channelMessage_Metadata;
                requestChannelMessageIsNull = false;
            }
            System.String requestChannelMessage_channelMessage_SubChannelId = null;
            if (cmdletContext.ChannelMessage_SubChannelId != null)
            {
                requestChannelMessage_channelMessage_SubChannelId = cmdletContext.ChannelMessage_SubChannelId;
            }
            if (requestChannelMessage_channelMessage_SubChannelId != null)
            {
                request.ChannelMessage.SubChannelId = requestChannelMessage_channelMessage_SubChannelId;
                requestChannelMessageIsNull = false;
            }
            Amazon.ChimeSDKMessaging.Model.PushNotificationConfiguration requestChannelMessage_channelMessage_PushNotification = null;
            
             // populate PushNotification
            var requestChannelMessage_channelMessage_PushNotificationIsNull = true;
            requestChannelMessage_channelMessage_PushNotification = new Amazon.ChimeSDKMessaging.Model.PushNotificationConfiguration();
            System.String requestChannelMessage_channelMessage_PushNotification_pushNotification_Body = null;
            if (cmdletContext.PushNotification_Body != null)
            {
                requestChannelMessage_channelMessage_PushNotification_pushNotification_Body = cmdletContext.PushNotification_Body;
            }
            if (requestChannelMessage_channelMessage_PushNotification_pushNotification_Body != null)
            {
                requestChannelMessage_channelMessage_PushNotification.Body = requestChannelMessage_channelMessage_PushNotification_pushNotification_Body;
                requestChannelMessage_channelMessage_PushNotificationIsNull = false;
            }
            System.String requestChannelMessage_channelMessage_PushNotification_pushNotification_Title = null;
            if (cmdletContext.PushNotification_Title != null)
            {
                requestChannelMessage_channelMessage_PushNotification_pushNotification_Title = cmdletContext.PushNotification_Title;
            }
            if (requestChannelMessage_channelMessage_PushNotification_pushNotification_Title != null)
            {
                requestChannelMessage_channelMessage_PushNotification.Title = requestChannelMessage_channelMessage_PushNotification_pushNotification_Title;
                requestChannelMessage_channelMessage_PushNotificationIsNull = false;
            }
            Amazon.ChimeSDKMessaging.PushNotificationType requestChannelMessage_channelMessage_PushNotification_pushNotification_Type = null;
            if (cmdletContext.PushNotification_Type != null)
            {
                requestChannelMessage_channelMessage_PushNotification_pushNotification_Type = cmdletContext.PushNotification_Type;
            }
            if (requestChannelMessage_channelMessage_PushNotification_pushNotification_Type != null)
            {
                requestChannelMessage_channelMessage_PushNotification.Type = requestChannelMessage_channelMessage_PushNotification_pushNotification_Type;
                requestChannelMessage_channelMessage_PushNotificationIsNull = false;
            }
             // determine if requestChannelMessage_channelMessage_PushNotification should be set to null
            if (requestChannelMessage_channelMessage_PushNotificationIsNull)
            {
                requestChannelMessage_channelMessage_PushNotification = null;
            }
            if (requestChannelMessage_channelMessage_PushNotification != null)
            {
                request.ChannelMessage.PushNotification = requestChannelMessage_channelMessage_PushNotification;
                requestChannelMessageIsNull = false;
            }
             // determine if request.ChannelMessage should be set to null
            if (requestChannelMessageIsNull)
            {
                request.ChannelMessage = null;
            }
            if (cmdletContext.DeleteResource != null)
            {
                request.DeleteResource = cmdletContext.DeleteResource.Value;
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
        
        private Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "ChannelFlowCallback");
            try
            {
                #if DESKTOP
                return client.ChannelFlowCallback(request);
                #elif CORECLR
                return client.ChannelFlowCallbackAsync(request).GetAwaiter().GetResult();
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
            public System.String CallbackId { get; set; }
            public System.String ChannelArn { get; set; }
            public System.String ChannelMessage_Content { get; set; }
            public Dictionary<System.String, Amazon.ChimeSDKMessaging.Model.MessageAttributeValue> ChannelMessage_MessageAttribute { get; set; }
            public System.String ChannelMessage_MessageId { get; set; }
            public System.String ChannelMessage_Metadata { get; set; }
            public System.String PushNotification_Body { get; set; }
            public System.String PushNotification_Title { get; set; }
            public Amazon.ChimeSDKMessaging.PushNotificationType PushNotification_Type { get; set; }
            public System.String ChannelMessage_SubChannelId { get; set; }
            public System.Boolean? DeleteResource { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.ChannelFlowCallbackResponse, SendCHMMGChannelFlowCallbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
