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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Sends a templated text message through a notify configuration to a recipient's phone
    /// number.
    /// </summary>
    [Cmdlet("Send", "SMSVNotifyTextMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 SendNotifyTextMessage API operation.", Operation = new[] {"SendNotifyTextMessage"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse object containing multiple properties."
    )]
    public partial class SendSMSVNotifyTextMessageCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set to use. This can be either the ConfigurationSetName
        /// or ConfigurationSetArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter Context
        /// <summary>
        /// <para>
        /// <para>You can specify custom data in this field. If you do, that data is logged to the event
        /// destination.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Context { get; set; }
        #endregion
        
        #region Parameter DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The destination phone number in E.164 format.</para>
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
        public System.String DestinationPhoneNumber { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>When set to true, the message is checked and validated, but isn't sent to the end
        /// recipient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MessageFeedbackEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to enable message feedback for the message. When a user receives the message
        /// you need to update the message status using <a>PutMessageFeedback</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MessageFeedbackEnabled { get; set; }
        #endregion
        
        #region Parameter NotifyConfigurationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the notify configuration to use for sending the message.
        /// This can be either the NotifyConfigurationId or NotifyConfigurationArn.</para>
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
        public System.String NotifyConfigurationId { get; set; }
        #endregion
        
        #region Parameter TemplateId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the template to use for the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateId { get; set; }
        #endregion
        
        #region Parameter TemplateVariable
        /// <summary>
        /// <para>
        /// <para>A map of template variable names and their values. All variable values are passed
        /// as strings regardless of the declared variable type. For example, pass <c>INTEGER</c>
        /// values as <c>"42"</c> and <c>BOOLEAN</c> values as <c>"true"</c> or <c>"false"</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TemplateVariables")]
        public System.Collections.Hashtable TemplateVariable { get; set; }
        #endregion
        
        #region Parameter TimeToLive
        /// <summary>
        /// <para>
        /// <para>How long the text message is valid for, in seconds. By default this is 72 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TimeToLive { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NotifyConfigurationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SMSVNotifyTextMessage (SendNotifyTextMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse, SendSMSVNotifyTextMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.Context != null)
            {
                context.Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Context.Keys)
                {
                    context.Context.Add((String)hashKey, (System.String)(this.Context[hashKey]));
                }
            }
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            #if MODULAR
            if (this.DestinationPhoneNumber == null && ParameterWasBound(nameof(this.DestinationPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.MessageFeedbackEnabled = this.MessageFeedbackEnabled;
            context.NotifyConfigurationId = this.NotifyConfigurationId;
            #if MODULAR
            if (this.NotifyConfigurationId == null && ParameterWasBound(nameof(this.NotifyConfigurationId)))
            {
                WriteWarning("You are passing $null as a value for parameter NotifyConfigurationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemplateId = this.TemplateId;
            if (this.TemplateVariable != null)
            {
                context.TemplateVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TemplateVariable.Keys)
                {
                    context.TemplateVariable.Add((String)hashKey, (System.String)(this.TemplateVariable[hashKey]));
                }
            }
            #if MODULAR
            if (this.TemplateVariable == null && ParameterWasBound(nameof(this.TemplateVariable)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateVariable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeToLive = this.TimeToLive;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Context != null)
            {
                request.Context = cmdletContext.Context;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.MessageFeedbackEnabled != null)
            {
                request.MessageFeedbackEnabled = cmdletContext.MessageFeedbackEnabled.Value;
            }
            if (cmdletContext.NotifyConfigurationId != null)
            {
                request.NotifyConfigurationId = cmdletContext.NotifyConfigurationId;
            }
            if (cmdletContext.TemplateId != null)
            {
                request.TemplateId = cmdletContext.TemplateId;
            }
            if (cmdletContext.TemplateVariable != null)
            {
                request.TemplateVariables = cmdletContext.TemplateVariable;
            }
            if (cmdletContext.TimeToLive != null)
            {
                request.TimeToLive = cmdletContext.TimeToLive.Value;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "SendNotifyTextMessage");
            try
            {
                return client.SendNotifyTextMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public Dictionary<System.String, System.String> Context { get; set; }
            public System.String DestinationPhoneNumber { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? MessageFeedbackEnabled { get; set; }
            public System.String NotifyConfigurationId { get; set; }
            public System.String TemplateId { get; set; }
            public Dictionary<System.String, System.String> TemplateVariable { get; set; }
            public System.Int32? TimeToLive { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.SendNotifyTextMessageResponse, SendSMSVNotifyTextMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
