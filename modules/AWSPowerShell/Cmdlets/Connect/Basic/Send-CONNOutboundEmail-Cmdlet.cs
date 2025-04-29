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
    /// Send outbound email for outbound campaigns. For more information about outbound campaigns,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-outbound-campaigns.html">Set
    /// up Amazon Connect outbound campaigns</a>.
    /// 
    ///  <note><para>
    /// Only the Amazon Connect outbound campaigns service principal is allowed to assume
    /// a role in your account and call this API.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "CONNOutboundEmail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service SendOutboundEmail API operation.", Operation = new[] {"SendOutboundEmail"}, SelectReturnType = typeof(Amazon.Connect.Model.SendOutboundEmailResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.SendOutboundEmailResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.SendOutboundEmailResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendCONNOutboundEmailCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RawMessage_Body
        /// <summary>
        /// <para>
        /// <para>The email message body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_Body")]
        public System.String RawMessage_Body { get; set; }
        #endregion
        
        #region Parameter SourceCampaign_CampaignId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCampaign_CampaignId { get; set; }
        #endregion
        
        #region Parameter AdditionalRecipients_CcEmailAddress
        /// <summary>
        /// <para>
        /// <para>The additional CC email address recipients information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalRecipients_CcEmailAddresses")]
        public Amazon.Connect.Model.EmailAddressInfo[] AdditionalRecipients_CcEmailAddress { get; set; }
        #endregion
        
        #region Parameter RawMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>Type of content, that is, <c>text/plain</c> or <c>text/html</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_ContentType")]
        public System.String RawMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter TemplateAttributes_CustomAttribute
        /// <summary>
        /// <para>
        /// <para>An object that specifies the custom attributes values to use for variables in the
        /// message template. This object contains different categories of key-value pairs. Each
        /// key defines a variable or placeholder in the message template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_TemplatedMessageConfig_TemplateAttributes_CustomAttributes")]
        public System.Collections.Hashtable TemplateAttributes_CustomAttribute { get; set; }
        #endregion
        
        #region Parameter TemplateAttributes_CustomerProfileAttribute
        /// <summary>
        /// <para>
        /// <para>An object that specifies the customer profile attributes values to use for variables
        /// in the message template. This object contains different categories of key-value pairs.
        /// Each key defines a variable or placeholder in the message template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_TemplatedMessageConfig_TemplateAttributes_CustomerProfileAttributes")]
        public System.String TemplateAttributes_CustomerProfileAttribute { get; set; }
        #endregion
        
        #region Parameter DestinationEmailAddress_DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DestinationEmailAddress_DisplayName { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress_DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FromEmailAddress_DisplayName { get; set; }
        #endregion
        
        #region Parameter DestinationEmailAddress_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address with the instance, in [^\s@]+@[^\s@]+\.[^\s@]+ format.</para>
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
        public System.String DestinationEmailAddress_EmailAddress { get; set; }
        #endregion
        
        #region Parameter FromEmailAddress_EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address with the instance, in [^\s@]+@[^\s@]+\.[^\s@]+ format.</para>
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
        public System.String FromEmailAddress_EmailAddress { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
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
        
        #region Parameter TemplatedMessageConfig_KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_TemplatedMessageConfig_KnowledgeBaseId")]
        public System.String TemplatedMessageConfig_KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter EmailMessage_MessageSourceType
        /// <summary>
        /// <para>
        /// <para>The message source type, that is, <c>RAW</c> or <c>TEMPLATE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.OutboundMessageSourceType")]
        public Amazon.Connect.OutboundMessageSourceType EmailMessage_MessageSourceType { get; set; }
        #endregion
        
        #region Parameter TemplatedMessageConfig_MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template Id.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_TemplatedMessageConfig_MessageTemplateId")]
        public System.String TemplatedMessageConfig_MessageTemplateId { get; set; }
        #endregion
        
        #region Parameter SourceCampaign_OutboundRequestId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a each request part of same campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCampaign_OutboundRequestId { get; set; }
        #endregion
        
        #region Parameter RawMessage_Subject
        /// <summary>
        /// <para>
        /// <para>The email subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailMessage_RawMessage_Subject")]
        public System.String RawMessage_Subject { get; set; }
        #endregion
        
        #region Parameter TrafficType
        /// <summary>
        /// <para>
        /// <para>Denotes the class of traffic.</para><note><para>Only the CAMPAIGN traffic type is supported.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.TrafficType")]
        public Amazon.Connect.TrafficType TrafficType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SendOutboundEmailResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CONNOutboundEmail (SendOutboundEmail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SendOutboundEmailResponse, SendCONNOutboundEmailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalRecipients_CcEmailAddress != null)
            {
                context.AdditionalRecipients_CcEmailAddress = new List<Amazon.Connect.Model.EmailAddressInfo>(this.AdditionalRecipients_CcEmailAddress);
            }
            context.ClientToken = this.ClientToken;
            context.DestinationEmailAddress_DisplayName = this.DestinationEmailAddress_DisplayName;
            context.DestinationEmailAddress_EmailAddress = this.DestinationEmailAddress_EmailAddress;
            #if MODULAR
            if (this.DestinationEmailAddress_EmailAddress == null && ParameterWasBound(nameof(this.DestinationEmailAddress_EmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationEmailAddress_EmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMessage_MessageSourceType = this.EmailMessage_MessageSourceType;
            #if MODULAR
            if (this.EmailMessage_MessageSourceType == null && ParameterWasBound(nameof(this.EmailMessage_MessageSourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailMessage_MessageSourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RawMessage_Body = this.RawMessage_Body;
            context.RawMessage_ContentType = this.RawMessage_ContentType;
            context.RawMessage_Subject = this.RawMessage_Subject;
            context.TemplatedMessageConfig_KnowledgeBaseId = this.TemplatedMessageConfig_KnowledgeBaseId;
            context.TemplatedMessageConfig_MessageTemplateId = this.TemplatedMessageConfig_MessageTemplateId;
            if (this.TemplateAttributes_CustomAttribute != null)
            {
                context.TemplateAttributes_CustomAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TemplateAttributes_CustomAttribute.Keys)
                {
                    context.TemplateAttributes_CustomAttribute.Add((String)hashKey, (System.String)(this.TemplateAttributes_CustomAttribute[hashKey]));
                }
            }
            context.TemplateAttributes_CustomerProfileAttribute = this.TemplateAttributes_CustomerProfileAttribute;
            context.FromEmailAddress_DisplayName = this.FromEmailAddress_DisplayName;
            context.FromEmailAddress_EmailAddress = this.FromEmailAddress_EmailAddress;
            #if MODULAR
            if (this.FromEmailAddress_EmailAddress == null && ParameterWasBound(nameof(this.FromEmailAddress_EmailAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter FromEmailAddress_EmailAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceCampaign_CampaignId = this.SourceCampaign_CampaignId;
            context.SourceCampaign_OutboundRequestId = this.SourceCampaign_OutboundRequestId;
            context.TrafficType = this.TrafficType;
            #if MODULAR
            if (this.TrafficType == null && ParameterWasBound(nameof(this.TrafficType)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.SendOutboundEmailRequest();
            
            
             // populate AdditionalRecipients
            var requestAdditionalRecipientsIsNull = true;
            request.AdditionalRecipients = new Amazon.Connect.Model.OutboundAdditionalRecipients();
            List<Amazon.Connect.Model.EmailAddressInfo> requestAdditionalRecipients_additionalRecipients_CcEmailAddress = null;
            if (cmdletContext.AdditionalRecipients_CcEmailAddress != null)
            {
                requestAdditionalRecipients_additionalRecipients_CcEmailAddress = cmdletContext.AdditionalRecipients_CcEmailAddress;
            }
            if (requestAdditionalRecipients_additionalRecipients_CcEmailAddress != null)
            {
                request.AdditionalRecipients.CcEmailAddresses = requestAdditionalRecipients_additionalRecipients_CcEmailAddress;
                requestAdditionalRecipientsIsNull = false;
            }
             // determine if request.AdditionalRecipients should be set to null
            if (requestAdditionalRecipientsIsNull)
            {
                request.AdditionalRecipients = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DestinationEmailAddress
            var requestDestinationEmailAddressIsNull = true;
            request.DestinationEmailAddress = new Amazon.Connect.Model.EmailAddressInfo();
            System.String requestDestinationEmailAddress_destinationEmailAddress_DisplayName = null;
            if (cmdletContext.DestinationEmailAddress_DisplayName != null)
            {
                requestDestinationEmailAddress_destinationEmailAddress_DisplayName = cmdletContext.DestinationEmailAddress_DisplayName;
            }
            if (requestDestinationEmailAddress_destinationEmailAddress_DisplayName != null)
            {
                request.DestinationEmailAddress.DisplayName = requestDestinationEmailAddress_destinationEmailAddress_DisplayName;
                requestDestinationEmailAddressIsNull = false;
            }
            System.String requestDestinationEmailAddress_destinationEmailAddress_EmailAddress = null;
            if (cmdletContext.DestinationEmailAddress_EmailAddress != null)
            {
                requestDestinationEmailAddress_destinationEmailAddress_EmailAddress = cmdletContext.DestinationEmailAddress_EmailAddress;
            }
            if (requestDestinationEmailAddress_destinationEmailAddress_EmailAddress != null)
            {
                request.DestinationEmailAddress.EmailAddress = requestDestinationEmailAddress_destinationEmailAddress_EmailAddress;
                requestDestinationEmailAddressIsNull = false;
            }
             // determine if request.DestinationEmailAddress should be set to null
            if (requestDestinationEmailAddressIsNull)
            {
                request.DestinationEmailAddress = null;
            }
            
             // populate EmailMessage
            var requestEmailMessageIsNull = true;
            request.EmailMessage = new Amazon.Connect.Model.OutboundEmailContent();
            Amazon.Connect.OutboundMessageSourceType requestEmailMessage_emailMessage_MessageSourceType = null;
            if (cmdletContext.EmailMessage_MessageSourceType != null)
            {
                requestEmailMessage_emailMessage_MessageSourceType = cmdletContext.EmailMessage_MessageSourceType;
            }
            if (requestEmailMessage_emailMessage_MessageSourceType != null)
            {
                request.EmailMessage.MessageSourceType = requestEmailMessage_emailMessage_MessageSourceType;
                requestEmailMessageIsNull = false;
            }
            Amazon.Connect.Model.OutboundRawMessage requestEmailMessage_emailMessage_RawMessage = null;
            
             // populate RawMessage
            var requestEmailMessage_emailMessage_RawMessageIsNull = true;
            requestEmailMessage_emailMessage_RawMessage = new Amazon.Connect.Model.OutboundRawMessage();
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_Body = null;
            if (cmdletContext.RawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_Body = cmdletContext.RawMessage_Body;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Body = requestEmailMessage_emailMessage_RawMessage_rawMessage_Body;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType = null;
            if (cmdletContext.RawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType = cmdletContext.RawMessage_ContentType;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage.ContentType = requestEmailMessage_emailMessage_RawMessage_rawMessage_ContentType;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject = null;
            if (cmdletContext.RawMessage_Subject != null)
            {
                requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject = cmdletContext.RawMessage_Subject;
            }
            if (requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Subject = requestEmailMessage_emailMessage_RawMessage_rawMessage_Subject;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
             // determine if requestEmailMessage_emailMessage_RawMessage should be set to null
            if (requestEmailMessage_emailMessage_RawMessageIsNull)
            {
                requestEmailMessage_emailMessage_RawMessage = null;
            }
            if (requestEmailMessage_emailMessage_RawMessage != null)
            {
                request.EmailMessage.RawMessage = requestEmailMessage_emailMessage_RawMessage;
                requestEmailMessageIsNull = false;
            }
            Amazon.Connect.Model.TemplatedMessageConfig requestEmailMessage_emailMessage_TemplatedMessageConfig = null;
            
             // populate TemplatedMessageConfig
            var requestEmailMessage_emailMessage_TemplatedMessageConfigIsNull = true;
            requestEmailMessage_emailMessage_TemplatedMessageConfig = new Amazon.Connect.Model.TemplatedMessageConfig();
            System.String requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_KnowledgeBaseId = null;
            if (cmdletContext.TemplatedMessageConfig_KnowledgeBaseId != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_KnowledgeBaseId = cmdletContext.TemplatedMessageConfig_KnowledgeBaseId;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_KnowledgeBaseId != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig.KnowledgeBaseId = requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_KnowledgeBaseId;
                requestEmailMessage_emailMessage_TemplatedMessageConfigIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_MessageTemplateId = null;
            if (cmdletContext.TemplatedMessageConfig_MessageTemplateId != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_MessageTemplateId = cmdletContext.TemplatedMessageConfig_MessageTemplateId;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_MessageTemplateId != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig.MessageTemplateId = requestEmailMessage_emailMessage_TemplatedMessageConfig_templatedMessageConfig_MessageTemplateId;
                requestEmailMessage_emailMessage_TemplatedMessageConfigIsNull = false;
            }
            Amazon.Connect.Model.TemplateAttributes requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes = null;
            
             // populate TemplateAttributes
            var requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributesIsNull = true;
            requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes = new Amazon.Connect.Model.TemplateAttributes();
            Dictionary<System.String, System.String> requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomAttribute = null;
            if (cmdletContext.TemplateAttributes_CustomAttribute != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomAttribute = cmdletContext.TemplateAttributes_CustomAttribute;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomAttribute != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes.CustomAttributes = requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomAttribute;
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributesIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomerProfileAttribute = null;
            if (cmdletContext.TemplateAttributes_CustomerProfileAttribute != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomerProfileAttribute = cmdletContext.TemplateAttributes_CustomerProfileAttribute;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomerProfileAttribute != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes.CustomerProfileAttributes = requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes_templateAttributes_CustomerProfileAttribute;
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributesIsNull = false;
            }
             // determine if requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes should be set to null
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributesIsNull)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes = null;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes != null)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig.TemplateAttributes = requestEmailMessage_emailMessage_TemplatedMessageConfig_emailMessage_TemplatedMessageConfig_TemplateAttributes;
                requestEmailMessage_emailMessage_TemplatedMessageConfigIsNull = false;
            }
             // determine if requestEmailMessage_emailMessage_TemplatedMessageConfig should be set to null
            if (requestEmailMessage_emailMessage_TemplatedMessageConfigIsNull)
            {
                requestEmailMessage_emailMessage_TemplatedMessageConfig = null;
            }
            if (requestEmailMessage_emailMessage_TemplatedMessageConfig != null)
            {
                request.EmailMessage.TemplatedMessageConfig = requestEmailMessage_emailMessage_TemplatedMessageConfig;
                requestEmailMessageIsNull = false;
            }
             // determine if request.EmailMessage should be set to null
            if (requestEmailMessageIsNull)
            {
                request.EmailMessage = null;
            }
            
             // populate FromEmailAddress
            var requestFromEmailAddressIsNull = true;
            request.FromEmailAddress = new Amazon.Connect.Model.EmailAddressInfo();
            System.String requestFromEmailAddress_fromEmailAddress_DisplayName = null;
            if (cmdletContext.FromEmailAddress_DisplayName != null)
            {
                requestFromEmailAddress_fromEmailAddress_DisplayName = cmdletContext.FromEmailAddress_DisplayName;
            }
            if (requestFromEmailAddress_fromEmailAddress_DisplayName != null)
            {
                request.FromEmailAddress.DisplayName = requestFromEmailAddress_fromEmailAddress_DisplayName;
                requestFromEmailAddressIsNull = false;
            }
            System.String requestFromEmailAddress_fromEmailAddress_EmailAddress = null;
            if (cmdletContext.FromEmailAddress_EmailAddress != null)
            {
                requestFromEmailAddress_fromEmailAddress_EmailAddress = cmdletContext.FromEmailAddress_EmailAddress;
            }
            if (requestFromEmailAddress_fromEmailAddress_EmailAddress != null)
            {
                request.FromEmailAddress.EmailAddress = requestFromEmailAddress_fromEmailAddress_EmailAddress;
                requestFromEmailAddressIsNull = false;
            }
             // determine if request.FromEmailAddress should be set to null
            if (requestFromEmailAddressIsNull)
            {
                request.FromEmailAddress = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate SourceCampaign
            var requestSourceCampaignIsNull = true;
            request.SourceCampaign = new Amazon.Connect.Model.SourceCampaign();
            System.String requestSourceCampaign_sourceCampaign_CampaignId = null;
            if (cmdletContext.SourceCampaign_CampaignId != null)
            {
                requestSourceCampaign_sourceCampaign_CampaignId = cmdletContext.SourceCampaign_CampaignId;
            }
            if (requestSourceCampaign_sourceCampaign_CampaignId != null)
            {
                request.SourceCampaign.CampaignId = requestSourceCampaign_sourceCampaign_CampaignId;
                requestSourceCampaignIsNull = false;
            }
            System.String requestSourceCampaign_sourceCampaign_OutboundRequestId = null;
            if (cmdletContext.SourceCampaign_OutboundRequestId != null)
            {
                requestSourceCampaign_sourceCampaign_OutboundRequestId = cmdletContext.SourceCampaign_OutboundRequestId;
            }
            if (requestSourceCampaign_sourceCampaign_OutboundRequestId != null)
            {
                request.SourceCampaign.OutboundRequestId = requestSourceCampaign_sourceCampaign_OutboundRequestId;
                requestSourceCampaignIsNull = false;
            }
             // determine if request.SourceCampaign should be set to null
            if (requestSourceCampaignIsNull)
            {
                request.SourceCampaign = null;
            }
            if (cmdletContext.TrafficType != null)
            {
                request.TrafficType = cmdletContext.TrafficType;
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
        
        private Amazon.Connect.Model.SendOutboundEmailResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SendOutboundEmailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SendOutboundEmail");
            try
            {
                return client.SendOutboundEmailAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.EmailAddressInfo> AdditionalRecipients_CcEmailAddress { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DestinationEmailAddress_DisplayName { get; set; }
            public System.String DestinationEmailAddress_EmailAddress { get; set; }
            public Amazon.Connect.OutboundMessageSourceType EmailMessage_MessageSourceType { get; set; }
            public System.String RawMessage_Body { get; set; }
            public System.String RawMessage_ContentType { get; set; }
            public System.String RawMessage_Subject { get; set; }
            public System.String TemplatedMessageConfig_KnowledgeBaseId { get; set; }
            public System.String TemplatedMessageConfig_MessageTemplateId { get; set; }
            public Dictionary<System.String, System.String> TemplateAttributes_CustomAttribute { get; set; }
            public System.String TemplateAttributes_CustomerProfileAttribute { get; set; }
            public System.String FromEmailAddress_DisplayName { get; set; }
            public System.String FromEmailAddress_EmailAddress { get; set; }
            public System.String InstanceId { get; set; }
            public System.String SourceCampaign_CampaignId { get; set; }
            public System.String SourceCampaign_OutboundRequestId { get; set; }
            public Amazon.Connect.TrafficType TrafficType { get; set; }
            public System.Func<Amazon.Connect.Model.SendOutboundEmailResponse, SendCONNOutboundEmailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
