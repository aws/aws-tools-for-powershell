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
using Amazon.ConnectCampaignsV2;
using Amazon.ConnectCampaignsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCS2
{
    /// <summary>
    /// Updates the channel subtype config of a campaign. This API is idempotent.
    /// </summary>
    [Cmdlet("Update", "CCS2CampaignChannelSubtypeConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 UpdateCampaignChannelSubtypeConfig API operation.", Operation = new[] {"UpdateCampaignChannelSubtypeConfig"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCS2CampaignChannelSubtypeConfigCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Preview_AgentAction
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_OutboundMode_Preview_AgentActions")]
        public System.String[] Preview_AgentAction { get; set; }
        #endregion
        
        #region Parameter ChannelSubtypeConfig_Email_OutboundMode_Agentless
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Email_OutboundMode_Agentless { get; set; }
        #endregion
        
        #region Parameter ChannelSubtypeConfig_Sms_OutboundMode_Agentless
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Sms_OutboundMode_Agentless { get; set; }
        #endregion
        
        #region Parameter ChannelSubtypeConfig_Telephony_OutboundMode_Agentless
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Telephony_OutboundMode_Agentless { get; set; }
        #endregion
        
        #region Parameter AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt
        /// <summary>
        /// <para>
        /// <para>Enable or disable await answer machine prompt</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt")]
        public System.Boolean? AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt { get; set; }
        #endregion
        
        #region Parameter Predictive_BandwidthAllocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_OutboundMode_Predictive_BandwidthAllocation")]
        public System.Double? Predictive_BandwidthAllocation { get; set; }
        #endregion
        
        #region Parameter Preview_BandwidthAllocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_OutboundMode_Preview_BandwidthAllocation")]
        public System.Double? Preview_BandwidthAllocation { get; set; }
        #endregion
        
        #region Parameter Progressive_BandwidthAllocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_OutboundMode_Progressive_BandwidthAllocation")]
        public System.Double? Progressive_BandwidthAllocation { get; set; }
        #endregion
        
        #region Parameter Email_Capacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Email_Capacity")]
        public System.Double? Email_Capacity { get; set; }
        #endregion
        
        #region Parameter Sms_Capacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Sms_Capacity")]
        public System.Double? Sms_Capacity { get; set; }
        #endregion
        
        #region Parameter Telephony_Capacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_Capacity")]
        public System.Double? Telephony_Capacity { get; set; }
        #endregion
        
        #region Parameter DefaultOutboundConfig_ConnectContactFlowId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_DefaultOutboundConfig_ConnectContactFlowId")]
        public System.String DefaultOutboundConfig_ConnectContactFlowId { get; set; }
        #endregion
        
        #region Parameter Telephony_ConnectQueueId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_ConnectQueueId")]
        public System.String Telephony_ConnectQueueId { get; set; }
        #endregion
        
        #region Parameter DefaultOutboundConfig_ConnectSourceEmailAddress
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Email_DefaultOutboundConfig_ConnectSourceEmailAddress")]
        public System.String DefaultOutboundConfig_ConnectSourceEmailAddress { get; set; }
        #endregion
        
        #region Parameter DefaultOutboundConfig_ConnectSourcePhoneNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_DefaultOutboundConfig_ConnectSourcePhoneNumber")]
        public System.String DefaultOutboundConfig_ConnectSourcePhoneNumber { get; set; }
        #endregion
        
        #region Parameter DefaultOutboundConfig_ConnectSourcePhoneNumberArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Sms_DefaultOutboundConfig_ConnectSourcePhoneNumberArn")]
        public System.String DefaultOutboundConfig_ConnectSourcePhoneNumberArn { get; set; }
        #endregion
        
        #region Parameter TimeoutConfig_DurationInSecond
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig_DurationInSeconds")]
        public System.Int32? TimeoutConfig_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter AnswerMachineDetectionConfig_EnableAnswerMachineDetection
        /// <summary>
        /// <para>
        /// <para>Enable or disable answering machine detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_EnableAnswerMachineDetection")]
        public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter DefaultOutboundConfig_SourceEmailAddressDisplayName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelSubtypeConfig_Email_DefaultOutboundConfig_SourceEmailAddressDisplayName")]
        public System.String DefaultOutboundConfig_SourceEmailAddressDisplayName { get; set; }
        #endregion
        
        #region Parameter ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn { get; set; }
        #endregion
        
        #region Parameter ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCS2CampaignChannelSubtypeConfig (UpdateCampaignChannelSubtypeConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse, UpdateCCS2CampaignChannelSubtypeConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Email_Capacity = this.Email_Capacity;
            context.DefaultOutboundConfig_ConnectSourceEmailAddress = this.DefaultOutboundConfig_ConnectSourceEmailAddress;
            context.DefaultOutboundConfig_SourceEmailAddressDisplayName = this.DefaultOutboundConfig_SourceEmailAddressDisplayName;
            context.ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn = this.ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn;
            context.ChannelSubtypeConfig_Email_OutboundMode_Agentless = this.ChannelSubtypeConfig_Email_OutboundMode_Agentless;
            context.Sms_Capacity = this.Sms_Capacity;
            context.DefaultOutboundConfig_ConnectSourcePhoneNumberArn = this.DefaultOutboundConfig_ConnectSourcePhoneNumberArn;
            context.ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn = this.ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn;
            context.ChannelSubtypeConfig_Sms_OutboundMode_Agentless = this.ChannelSubtypeConfig_Sms_OutboundMode_Agentless;
            context.Telephony_Capacity = this.Telephony_Capacity;
            context.Telephony_ConnectQueueId = this.Telephony_ConnectQueueId;
            context.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt = this.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt;
            context.AnswerMachineDetectionConfig_EnableAnswerMachineDetection = this.AnswerMachineDetectionConfig_EnableAnswerMachineDetection;
            context.DefaultOutboundConfig_ConnectContactFlowId = this.DefaultOutboundConfig_ConnectContactFlowId;
            context.DefaultOutboundConfig_ConnectSourcePhoneNumber = this.DefaultOutboundConfig_ConnectSourcePhoneNumber;
            context.ChannelSubtypeConfig_Telephony_OutboundMode_Agentless = this.ChannelSubtypeConfig_Telephony_OutboundMode_Agentless;
            context.Predictive_BandwidthAllocation = this.Predictive_BandwidthAllocation;
            if (this.Preview_AgentAction != null)
            {
                context.Preview_AgentAction = new List<System.String>(this.Preview_AgentAction);
            }
            context.Preview_BandwidthAllocation = this.Preview_BandwidthAllocation;
            context.TimeoutConfig_DurationInSecond = this.TimeoutConfig_DurationInSecond;
            context.Progressive_BandwidthAllocation = this.Progressive_BandwidthAllocation;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigRequest();
            
            
             // populate ChannelSubtypeConfig
            var requestChannelSubtypeConfigIsNull = true;
            request.ChannelSubtypeConfig = new Amazon.ConnectCampaignsV2.Model.ChannelSubtypeConfig();
            Amazon.ConnectCampaignsV2.Model.EmailChannelSubtypeConfig requestChannelSubtypeConfig_channelSubtypeConfig_Email = null;
            
             // populate Email
            var requestChannelSubtypeConfig_channelSubtypeConfig_EmailIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Email = new Amazon.ConnectCampaignsV2.Model.EmailChannelSubtypeConfig();
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Email_email_Capacity = null;
            if (cmdletContext.Email_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_email_Capacity = cmdletContext.Email_Capacity.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_email_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email.Capacity = requestChannelSubtypeConfig_channelSubtypeConfig_Email_email_Capacity.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_EmailIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.EmailOutboundMode requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode = null;
            
             // populate OutboundMode
            var requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundModeIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode = new Amazon.ConnectCampaignsV2.Model.EmailOutboundMode();
            Amazon.ConnectCampaignsV2.Model.AgentlessConfig requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode_channelSubtypeConfig_Email_OutboundMode_Agentless = null;
            if (cmdletContext.ChannelSubtypeConfig_Email_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode_channelSubtypeConfig_Email_OutboundMode_Agentless = cmdletContext.ChannelSubtypeConfig_Email_OutboundMode_Agentless;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode_channelSubtypeConfig_Email_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode.Agentless = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode_channelSubtypeConfig_Email_OutboundMode_Agentless;
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundModeIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundModeIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email.OutboundMode = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_OutboundMode;
                requestChannelSubtypeConfig_channelSubtypeConfig_EmailIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.EmailOutboundConfig requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig = null;
            
             // populate DefaultOutboundConfig
            var requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfigIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig = new Amazon.ConnectCampaignsV2.Model.EmailOutboundConfig();
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourceEmailAddress = null;
            if (cmdletContext.DefaultOutboundConfig_ConnectSourceEmailAddress != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourceEmailAddress = cmdletContext.DefaultOutboundConfig_ConnectSourceEmailAddress;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourceEmailAddress != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig.ConnectSourceEmailAddress = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourceEmailAddress;
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfigIsNull = false;
            }
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_SourceEmailAddressDisplayName = null;
            if (cmdletContext.DefaultOutboundConfig_SourceEmailAddressDisplayName != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_SourceEmailAddressDisplayName = cmdletContext.DefaultOutboundConfig_SourceEmailAddressDisplayName;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_SourceEmailAddressDisplayName != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig.SourceEmailAddressDisplayName = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_defaultOutboundConfig_SourceEmailAddressDisplayName;
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfigIsNull = false;
            }
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_channelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn = null;
            if (cmdletContext.ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_channelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn = cmdletContext.ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_channelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig.WisdomTemplateArn = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig_channelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn;
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfigIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfigIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email.DefaultOutboundConfig = requestChannelSubtypeConfig_channelSubtypeConfig_Email_channelSubtypeConfig_Email_DefaultOutboundConfig;
                requestChannelSubtypeConfig_channelSubtypeConfig_EmailIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Email should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_EmailIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Email = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Email != null)
            {
                request.ChannelSubtypeConfig.Email = requestChannelSubtypeConfig_channelSubtypeConfig_Email;
                requestChannelSubtypeConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.SmsChannelSubtypeConfig requestChannelSubtypeConfig_channelSubtypeConfig_Sms = null;
            
             // populate Sms
            var requestChannelSubtypeConfig_channelSubtypeConfig_SmsIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Sms = new Amazon.ConnectCampaignsV2.Model.SmsChannelSubtypeConfig();
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Sms_sms_Capacity = null;
            if (cmdletContext.Sms_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_sms_Capacity = cmdletContext.Sms_Capacity.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_sms_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms.Capacity = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_sms_Capacity.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_SmsIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.SmsOutboundMode requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode = null;
            
             // populate OutboundMode
            var requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundModeIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode = new Amazon.ConnectCampaignsV2.Model.SmsOutboundMode();
            Amazon.ConnectCampaignsV2.Model.AgentlessConfig requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode_channelSubtypeConfig_Sms_OutboundMode_Agentless = null;
            if (cmdletContext.ChannelSubtypeConfig_Sms_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode_channelSubtypeConfig_Sms_OutboundMode_Agentless = cmdletContext.ChannelSubtypeConfig_Sms_OutboundMode_Agentless;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode_channelSubtypeConfig_Sms_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode.Agentless = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode_channelSubtypeConfig_Sms_OutboundMode_Agentless;
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundModeIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundModeIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms.OutboundMode = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_OutboundMode;
                requestChannelSubtypeConfig_channelSubtypeConfig_SmsIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.SmsOutboundConfig requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig = null;
            
             // populate DefaultOutboundConfig
            var requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfigIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig = new Amazon.ConnectCampaignsV2.Model.SmsOutboundConfig();
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumberArn = null;
            if (cmdletContext.DefaultOutboundConfig_ConnectSourcePhoneNumberArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumberArn = cmdletContext.DefaultOutboundConfig_ConnectSourcePhoneNumberArn;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumberArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig.ConnectSourcePhoneNumberArn = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumberArn;
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfigIsNull = false;
            }
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_channelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn = null;
            if (cmdletContext.ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_channelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn = cmdletContext.ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_channelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig.WisdomTemplateArn = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig_channelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn;
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfigIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfigIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms.DefaultOutboundConfig = requestChannelSubtypeConfig_channelSubtypeConfig_Sms_channelSubtypeConfig_Sms_DefaultOutboundConfig;
                requestChannelSubtypeConfig_channelSubtypeConfig_SmsIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Sms should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_SmsIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Sms = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Sms != null)
            {
                request.ChannelSubtypeConfig.Sms = requestChannelSubtypeConfig_channelSubtypeConfig_Sms;
                requestChannelSubtypeConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TelephonyChannelSubtypeConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony = null;
            
             // populate Telephony
            var requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony = new Amazon.ConnectCampaignsV2.Model.TelephonyChannelSubtypeConfig();
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_Capacity = null;
            if (cmdletContext.Telephony_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_Capacity = cmdletContext.Telephony_Capacity.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_Capacity != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony.Capacity = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_Capacity.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull = false;
            }
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_ConnectQueueId = null;
            if (cmdletContext.Telephony_ConnectQueueId != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_ConnectQueueId = cmdletContext.Telephony_ConnectQueueId;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_ConnectQueueId != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony.ConnectQueueId = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_telephony_ConnectQueueId;
                requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TelephonyOutboundConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig = null;
            
             // populate DefaultOutboundConfig
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfigIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig = new Amazon.ConnectCampaignsV2.Model.TelephonyOutboundConfig();
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectContactFlowId = null;
            if (cmdletContext.DefaultOutboundConfig_ConnectContactFlowId != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectContactFlowId = cmdletContext.DefaultOutboundConfig_ConnectContactFlowId;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectContactFlowId != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig.ConnectContactFlowId = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectContactFlowId;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfigIsNull = false;
            }
            System.String requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumber = null;
            if (cmdletContext.DefaultOutboundConfig_ConnectSourcePhoneNumber != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumber = cmdletContext.DefaultOutboundConfig_ConnectSourcePhoneNumber;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumber != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig.ConnectSourcePhoneNumber = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_defaultOutboundConfig_ConnectSourcePhoneNumber;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.AnswerMachineDetectionConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig = null;
            
             // populate AnswerMachineDetectionConfig
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfigIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig = new Amazon.ConnectCampaignsV2.Model.AnswerMachineDetectionConfig();
            System.Boolean? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt = null;
            if (cmdletContext.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt = cmdletContext.AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig.AwaitAnswerMachinePrompt = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_AwaitAnswerMachinePrompt.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfigIsNull = false;
            }
            System.Boolean? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = null;
            if (cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig.EnableAnswerMachineDetection = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfigIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfigIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig.AnswerMachineDetectionConfig = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig_channelSubtypeConfig_Telephony_DefaultOutboundConfig_AnswerMachineDetectionConfig;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfigIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfigIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony.DefaultOutboundConfig = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_DefaultOutboundConfig;
                requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TelephonyOutboundMode requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode = null;
            
             // populate OutboundMode
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode = new Amazon.ConnectCampaignsV2.Model.TelephonyOutboundMode();
            Amazon.ConnectCampaignsV2.Model.AgentlessConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Agentless = null;
            if (cmdletContext.ChannelSubtypeConfig_Telephony_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Agentless = cmdletContext.ChannelSubtypeConfig_Telephony_OutboundMode_Agentless;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Agentless != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode.Agentless = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Agentless;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.PredictiveConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive = null;
            
             // populate Predictive
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PredictiveIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive = new Amazon.ConnectCampaignsV2.Model.PredictiveConfig();
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive_predictive_BandwidthAllocation = null;
            if (cmdletContext.Predictive_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive_predictive_BandwidthAllocation = cmdletContext.Predictive_BandwidthAllocation.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive_predictive_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive.BandwidthAllocation = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive_predictive_BandwidthAllocation.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PredictiveIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PredictiveIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode.Predictive = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Predictive;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.ProgressiveConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive = null;
            
             // populate Progressive
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_ProgressiveIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive = new Amazon.ConnectCampaignsV2.Model.ProgressiveConfig();
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive_progressive_BandwidthAllocation = null;
            if (cmdletContext.Progressive_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive_progressive_BandwidthAllocation = cmdletContext.Progressive_BandwidthAllocation.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive_progressive_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive.BandwidthAllocation = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive_progressive_BandwidthAllocation.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_ProgressiveIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_ProgressiveIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode.Progressive = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Progressive;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.PreviewConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview = null;
            
             // populate Preview
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PreviewIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview = new Amazon.ConnectCampaignsV2.Model.PreviewConfig();
            List<System.String> requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_AgentAction = null;
            if (cmdletContext.Preview_AgentAction != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_AgentAction = cmdletContext.Preview_AgentAction;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_AgentAction != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview.AgentActions = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_AgentAction;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PreviewIsNull = false;
            }
            System.Double? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_BandwidthAllocation = null;
            if (cmdletContext.Preview_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_BandwidthAllocation = cmdletContext.Preview_BandwidthAllocation.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_BandwidthAllocation != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview.BandwidthAllocation = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_preview_BandwidthAllocation.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PreviewIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TimeoutConfig requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig = null;
            
             // populate TimeoutConfig
            var requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfigIsNull = true;
            requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig = new Amazon.ConnectCampaignsV2.Model.TimeoutConfig();
            System.Int32? requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig_timeoutConfig_DurationInSecond = null;
            if (cmdletContext.TimeoutConfig_DurationInSecond != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig_timeoutConfig_DurationInSecond = cmdletContext.TimeoutConfig_DurationInSecond.Value;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig_timeoutConfig_DurationInSecond != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig.DurationInSeconds = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig_timeoutConfig_DurationInSecond.Value;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfigIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfigIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview.TimeoutConfig = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview_channelSubtypeConfig_Telephony_OutboundMode_Preview_TimeoutConfig;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PreviewIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_PreviewIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode.Preview = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode_channelSubtypeConfig_Telephony_OutboundMode_Preview;
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundModeIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode != null)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony.OutboundMode = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony_channelSubtypeConfig_Telephony_OutboundMode;
                requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull = false;
            }
             // determine if requestChannelSubtypeConfig_channelSubtypeConfig_Telephony should be set to null
            if (requestChannelSubtypeConfig_channelSubtypeConfig_TelephonyIsNull)
            {
                requestChannelSubtypeConfig_channelSubtypeConfig_Telephony = null;
            }
            if (requestChannelSubtypeConfig_channelSubtypeConfig_Telephony != null)
            {
                request.ChannelSubtypeConfig.Telephony = requestChannelSubtypeConfig_channelSubtypeConfig_Telephony;
                requestChannelSubtypeConfigIsNull = false;
            }
             // determine if request.ChannelSubtypeConfig should be set to null
            if (requestChannelSubtypeConfigIsNull)
            {
                request.ChannelSubtypeConfig = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "UpdateCampaignChannelSubtypeConfig");
            try
            {
                return client.UpdateCampaignChannelSubtypeConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? Email_Capacity { get; set; }
            public System.String DefaultOutboundConfig_ConnectSourceEmailAddress { get; set; }
            public System.String DefaultOutboundConfig_SourceEmailAddressDisplayName { get; set; }
            public System.String ChannelSubtypeConfig_Email_DefaultOutboundConfig_WisdomTemplateArn { get; set; }
            public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Email_OutboundMode_Agentless { get; set; }
            public System.Double? Sms_Capacity { get; set; }
            public System.String DefaultOutboundConfig_ConnectSourcePhoneNumberArn { get; set; }
            public System.String ChannelSubtypeConfig_Sms_DefaultOutboundConfig_WisdomTemplateArn { get; set; }
            public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Sms_OutboundMode_Agentless { get; set; }
            public System.Double? Telephony_Capacity { get; set; }
            public System.String Telephony_ConnectQueueId { get; set; }
            public System.Boolean? AnswerMachineDetectionConfig_AwaitAnswerMachinePrompt { get; set; }
            public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
            public System.String DefaultOutboundConfig_ConnectContactFlowId { get; set; }
            public System.String DefaultOutboundConfig_ConnectSourcePhoneNumber { get; set; }
            public Amazon.ConnectCampaignsV2.Model.AgentlessConfig ChannelSubtypeConfig_Telephony_OutboundMode_Agentless { get; set; }
            public System.Double? Predictive_BandwidthAllocation { get; set; }
            public List<System.String> Preview_AgentAction { get; set; }
            public System.Double? Preview_BandwidthAllocation { get; set; }
            public System.Int32? TimeoutConfig_DurationInSecond { get; set; }
            public System.Double? Progressive_BandwidthAllocation { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.UpdateCampaignChannelSubtypeConfigResponse, UpdateCCS2CampaignChannelSubtypeConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
