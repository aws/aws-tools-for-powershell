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
    /// Places an outbound call to a contact, and then initiates the flow. It performs the
    /// actions in the flow that's specified (in <c>ContactFlowId</c>).
    /// 
    ///  
    /// <para>
    /// Agents do not initiate the outbound API, which means that they do not dial the contact.
    /// If the flow places an outbound call to a contact, and then puts the contact in queue,
    /// the call is then routed to the agent, like any other inbound case.
    /// </para><para>
    /// There is a 60-second dialing timeout for this operation. If the call is not connected
    /// after 60 seconds, it fails.
    /// </para><note><para>
    /// UK numbers with a 447 prefix are not allowed by default. Before you can dial these
    /// UK mobile numbers, you must submit a service quota increase request. For more information,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html">Amazon
    /// Connect Service Quotas</a> in the <i>Amazon Connect Administrator Guide</i>. 
    /// </para></note><note><para>
    /// Campaign calls are not allowed by default. Before you can make a call with <c>TrafficType</c>
    /// = <c>CAMPAIGN</c>, you must submit a service quota increase request to the quota <a href="https://docs.aws.amazon.com/connect/latest/adminguide/amazon-connect-service-limits.html#outbound-communications-quotas">Amazon
    /// Connect campaigns</a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "CONNOutboundVoiceContact", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service StartOutboundVoiceContact API operation.", Operation = new[] {"StartOutboundVoiceContact"}, SelectReturnType = typeof(Amazon.Connect.Model.StartOutboundVoiceContactResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.StartOutboundVoiceContactResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.StartOutboundVoiceContactResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCONNOutboundVoiceContactCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Preview_AllowedUserAction
        /// <summary>
        /// <para>
        /// <para>The actions the agent can perform after accepting the preview outbound contact.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutboundStrategy_Config_AgentFirst_Preview_AllowedUserActions")]
        public System.String[] Preview_AllowedUserAction { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A custom key-value pair using an attribute map. The attributes are standard Amazon
        /// Connect attributes, and can be accessed in flows just like any other contact attributes.</para><para>There can be up to 32,768 UTF-8 bytes across all key-value pairs per contact. Attribute
        /// keys can include only alphanumeric, dash, and underscore characters.</para><para />
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
        
        #region Parameter AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt
        /// <summary>
        /// <para>
        /// <para>Wait for the answering machine prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt { get; set; }
        #endregion
        
        #region Parameter CampaignId
        /// <summary>
        /// <para>
        /// <para>The campaign identifier of the outbound communication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CampaignId { get; set; }
        #endregion
        
        #region Parameter ContactFlowId
        /// <summary>
        /// <para>
        /// <para>The identifier of the flow for the outbound call. To see the ContactFlowId in the
        /// Amazon Connect admin website, on the navigation menu go to <b>Routing</b>, <b>Contact
        /// Flows</b>. Choose the flow. On the flow page, under the name of the flow, choose <b>Show
        /// additional flow information</b>. The ContactFlowId is the last part of the ARN, shown
        /// here in bold: </para><para>arn:aws:connect:us-west-2:xxxxxxxxxxxx:instance/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/contact-flow/<b>846ec553-a005-41c0-8341-xxxxxxxxxxxx</b></para>
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the voice contact that appears in the agent's snapshot in the CCP
        /// logs. For more information about CCP logs, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/download-ccp-logs.html">Download
        /// and review CCP logs</a> in the <i>Amazon Connect Administrator Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DestinationPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the customer, in E.164 format.</para>
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
        
        #region Parameter PostAcceptTimeoutConfig_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>Duration in seconds for the countdown timer after the agent accepted the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig_DurationInSeconds")]
        public System.Int32? PostAcceptTimeoutConfig_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter AnswerMachineDetectionConfig_EnableAnswerMachineDetection
        /// <summary>
        /// <para>
        /// <para>The flag to indicate if answer machine detection analysis needs to be performed for
        /// a voice call. If set to <c>true</c>, <c>TrafficType</c> must be set as <c>CAMPAIGN</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a voice contact that is shown to an agent in the Contact Control Panel
        /// (CCP).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The queue for the call. If you specify a queue, the phone displayed for caller ID
        /// is the phone number specified in the queue. If you do not specify a queue, the queue
        /// defined in the flow is used. If you do not specify a queue, you must specify a source
        /// phone number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueueId { get; set; }
        #endregion
        
        #region Parameter Reference
        /// <summary>
        /// <para>
        /// <para>A formatted URL that is shown to an agent in the Contact Control Panel (CCP). Contacts
        /// can have the following reference types at the time of creation: <c>URL</c> | <c>NUMBER</c>
        /// | <c>STRING</c> | <c>DATE</c> | <c>EMAIL</c>. <c>ATTACHMENT</c> is not a supported
        /// reference type during voice contact creation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("References")]
        public System.Collections.Hashtable Reference { get; set; }
        #endregion
        
        #region Parameter RelatedContactId
        /// <summary>
        /// <para>
        /// <para>The <c>contactId</c> that is related to this contact. Linking voice, task, or chat
        /// by using <c>RelatedContactID</c> copies over contact attributes from the related contact
        /// to the new contact. All updates to user-defined attributes in the new contact are
        /// limited to the individual contact ID. There are no limits to the number of contacts
        /// that can be linked by using <c>RelatedContactId</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedContactId { get; set; }
        #endregion
        
        #region Parameter SourcePhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number associated with the Amazon Connect instance, in E.164 format. If
        /// you do not specify a source phone number, you must specify a queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourcePhoneNumber { get; set; }
        #endregion
        
        #region Parameter TrafficType
        /// <summary>
        /// <para>
        /// <para>Denotes the class of traffic. Calls with different traffic types are handled differently
        /// by Amazon Connect. The default value is <c>GENERAL</c>. Use <c>CAMPAIGN</c> if <c>EnableAnswerMachineDetection</c>
        /// is set to <c>true</c>. For all other cases, use <c>GENERAL</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.TrafficType")]
        public Amazon.Connect.TrafficType TrafficType { get; set; }
        #endregion
        
        #region Parameter OutboundStrategy_Type
        /// <summary>
        /// <para>
        /// <para>Type of the outbound strategy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.OutboundStrategyType")]
        public Amazon.Connect.OutboundStrategyType OutboundStrategy_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>. The token is valid for 7 days after creation.
        /// If a contact is already started, the contact ID is returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartOutboundVoiceContactResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.StartOutboundVoiceContactResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactFlowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNOutboundVoiceContact (StartOutboundVoiceContact)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartOutboundVoiceContactResponse, StartCONNOutboundVoiceContactCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt = this.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt;
            context.AnswerMachineDetectionConfig_EnableAnswerMachineDetection = this.AnswerMachineDetectionConfig_EnableAnswerMachineDetection;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.CampaignId = this.CampaignId;
            context.ClientToken = this.ClientToken;
            context.ContactFlowId = this.ContactFlowId;
            #if MODULAR
            if (this.ContactFlowId == null && ParameterWasBound(nameof(this.ContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DestinationPhoneNumber = this.DestinationPhoneNumber;
            #if MODULAR
            if (this.DestinationPhoneNumber == null && ParameterWasBound(nameof(this.DestinationPhoneNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationPhoneNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.Preview_AllowedUserAction != null)
            {
                context.Preview_AllowedUserAction = new List<System.String>(this.Preview_AllowedUserAction);
            }
            context.PostAcceptTimeoutConfig_DurationInSecond = this.PostAcceptTimeoutConfig_DurationInSecond;
            context.OutboundStrategy_Type = this.OutboundStrategy_Type;
            context.QueueId = this.QueueId;
            if (this.Reference != null)
            {
                context.Reference = new Dictionary<System.String, Amazon.Connect.Model.Reference>(StringComparer.Ordinal);
                foreach (var hashKey in this.Reference.Keys)
                {
                    context.Reference.Add((String)hashKey, (Amazon.Connect.Model.Reference)(this.Reference[hashKey]));
                }
            }
            context.RelatedContactId = this.RelatedContactId;
            context.SourcePhoneNumber = this.SourcePhoneNumber;
            context.TrafficType = this.TrafficType;
            
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
            var request = new Amazon.Connect.Model.StartOutboundVoiceContactRequest();
            
            
             // populate AnswerMachineDetectionConfig
            var requestAnswerMachineDetectionConfigIsNull = true;
            request.AnswerMachineDetectionConfig = new Amazon.Connect.Model.AnswerMachineDetectionConfig();
            System.Boolean? requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt = null;
            if (cmdletContext.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt != null)
            {
                requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt = cmdletContext.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt.Value;
            }
            if (requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt != null)
            {
                request.AnswerMachineDetectionConfig.AwaitAnswerMachinePrompt = requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt.Value;
                requestAnswerMachineDetectionConfigIsNull = false;
            }
            System.Boolean? requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = null;
            if (cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
            }
            if (requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                request.AnswerMachineDetectionConfig.EnableAnswerMachineDetection = requestAnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
                requestAnswerMachineDetectionConfigIsNull = false;
            }
             // determine if request.AnswerMachineDetectionConfig should be set to null
            if (requestAnswerMachineDetectionConfigIsNull)
            {
                request.AnswerMachineDetectionConfig = null;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.CampaignId != null)
            {
                request.CampaignId = cmdletContext.CampaignId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactFlowId != null)
            {
                request.ContactFlowId = cmdletContext.ContactFlowId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DestinationPhoneNumber != null)
            {
                request.DestinationPhoneNumber = cmdletContext.DestinationPhoneNumber;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutboundStrategy
            var requestOutboundStrategyIsNull = true;
            request.OutboundStrategy = new Amazon.Connect.Model.OutboundStrategy();
            Amazon.Connect.OutboundStrategyType requestOutboundStrategy_outboundStrategy_Type = null;
            if (cmdletContext.OutboundStrategy_Type != null)
            {
                requestOutboundStrategy_outboundStrategy_Type = cmdletContext.OutboundStrategy_Type;
            }
            if (requestOutboundStrategy_outboundStrategy_Type != null)
            {
                request.OutboundStrategy.Type = requestOutboundStrategy_outboundStrategy_Type;
                requestOutboundStrategyIsNull = false;
            }
            Amazon.Connect.Model.OutboundStrategyConfig requestOutboundStrategy_outboundStrategy_Config = null;
            
             // populate Config
            var requestOutboundStrategy_outboundStrategy_ConfigIsNull = true;
            requestOutboundStrategy_outboundStrategy_Config = new Amazon.Connect.Model.OutboundStrategyConfig();
            Amazon.Connect.Model.AgentFirst requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst = null;
            
             // populate AgentFirst
            var requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirstIsNull = true;
            requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst = new Amazon.Connect.Model.AgentFirst();
            Amazon.Connect.Model.Preview requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview = null;
            
             // populate Preview
            var requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_PreviewIsNull = true;
            requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview = new Amazon.Connect.Model.Preview();
            List<System.String> requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_preview_AllowedUserAction = null;
            if (cmdletContext.Preview_AllowedUserAction != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_preview_AllowedUserAction = cmdletContext.Preview_AllowedUserAction;
            }
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_preview_AllowedUserAction != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview.AllowedUserActions = requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_preview_AllowedUserAction;
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_PreviewIsNull = false;
            }
            Amazon.Connect.Model.PostAcceptTimeoutConfig requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig = null;
            
             // populate PostAcceptTimeoutConfig
            var requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfigIsNull = true;
            requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig = new Amazon.Connect.Model.PostAcceptTimeoutConfig();
            System.Int32? requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig_postAcceptTimeoutConfig_DurationInSecond = null;
            if (cmdletContext.PostAcceptTimeoutConfig_DurationInSecond != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig_postAcceptTimeoutConfig_DurationInSecond = cmdletContext.PostAcceptTimeoutConfig_DurationInSecond.Value;
            }
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig_postAcceptTimeoutConfig_DurationInSecond != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig.DurationInSeconds = requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig_postAcceptTimeoutConfig_DurationInSecond.Value;
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfigIsNull = false;
            }
             // determine if requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig should be set to null
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfigIsNull)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig = null;
            }
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview.PostAcceptTimeoutConfig = requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview_outboundStrategy_Config_AgentFirst_Preview_PostAcceptTimeoutConfig;
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_PreviewIsNull = false;
            }
             // determine if requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview should be set to null
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_PreviewIsNull)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview = null;
            }
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview != null)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst.Preview = requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst_outboundStrategy_Config_AgentFirst_Preview;
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirstIsNull = false;
            }
             // determine if requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst should be set to null
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirstIsNull)
            {
                requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst = null;
            }
            if (requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst != null)
            {
                requestOutboundStrategy_outboundStrategy_Config.AgentFirst = requestOutboundStrategy_outboundStrategy_Config_outboundStrategy_Config_AgentFirst;
                requestOutboundStrategy_outboundStrategy_ConfigIsNull = false;
            }
             // determine if requestOutboundStrategy_outboundStrategy_Config should be set to null
            if (requestOutboundStrategy_outboundStrategy_ConfigIsNull)
            {
                requestOutboundStrategy_outboundStrategy_Config = null;
            }
            if (requestOutboundStrategy_outboundStrategy_Config != null)
            {
                request.OutboundStrategy.Config = requestOutboundStrategy_outboundStrategy_Config;
                requestOutboundStrategyIsNull = false;
            }
             // determine if request.OutboundStrategy should be set to null
            if (requestOutboundStrategyIsNull)
            {
                request.OutboundStrategy = null;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
            }
            if (cmdletContext.Reference != null)
            {
                request.References = cmdletContext.Reference;
            }
            if (cmdletContext.RelatedContactId != null)
            {
                request.RelatedContactId = cmdletContext.RelatedContactId;
            }
            if (cmdletContext.SourcePhoneNumber != null)
            {
                request.SourcePhoneNumber = cmdletContext.SourcePhoneNumber;
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
        
        private Amazon.Connect.Model.StartOutboundVoiceContactResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartOutboundVoiceContactRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartOutboundVoiceContact");
            try
            {
                return client.StartOutboundVoiceContactAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt { get; set; }
            public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String CampaignId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ContactFlowId { get; set; }
            public System.String Description { get; set; }
            public System.String DestinationPhoneNumber { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
            public List<System.String> Preview_AllowedUserAction { get; set; }
            public System.Int32? PostAcceptTimeoutConfig_DurationInSecond { get; set; }
            public Amazon.Connect.OutboundStrategyType OutboundStrategy_Type { get; set; }
            public System.String QueueId { get; set; }
            public Dictionary<System.String, Amazon.Connect.Model.Reference> Reference { get; set; }
            public System.String RelatedContactId { get; set; }
            public System.String SourcePhoneNumber { get; set; }
            public Amazon.Connect.TrafficType TrafficType { get; set; }
            public System.Func<Amazon.Connect.Model.StartOutboundVoiceContactResponse, StartCONNOutboundVoiceContactCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
