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
    /// Creates a campaign for the specified Amazon Connect account. This API is idempotent.
    /// </summary>
    [Cmdlet("New", "CCS2Campaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse",
        "This cmdlet returns an Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse object containing multiple properties."
    )]
    public partial class NewCCS2CampaignCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
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
        
        #region Parameter AllChannelSubtypes_CommunicationLimitsList
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
        [Alias("CommunicationLimitsOverride_AllChannelSubtypes_CommunicationLimitsList")]
        public Amazon.ConnectCampaignsV2.Model.CommunicationLimit[] AllChannelSubtypes_CommunicationLimitsList { get; set; }
        #endregion
        
        #region Parameter ConnectCampaignFlowArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectCampaignFlowArn { get; set; }
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
        
        #region Parameter ConnectInstanceId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ConnectInstanceId { get; set; }
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
        
        #region Parameter EventTrigger_CustomerProfilesDomainArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EventTrigger_CustomerProfilesDomainArn")]
        public System.String EventTrigger_CustomerProfilesDomainArn { get; set; }
        #endregion
        
        #region Parameter Source_CustomerProfilesSegmentArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_CustomerProfilesSegmentArn { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Email_OpenHours_DailyHours
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
        public System.Collections.Hashtable CommunicationTimeConfig_Email_OpenHours_DailyHours { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Sms_OpenHours_DailyHours
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
        public System.Collections.Hashtable CommunicationTimeConfig_Sms_OpenHours_DailyHours { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Telephony_OpenHours_DailyHours
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
        public System.Collections.Hashtable CommunicationTimeConfig_Telephony_OpenHours_DailyHours { get; set; }
        #endregion
        
        #region Parameter LocalTimeZoneConfig_DefaultTimeZone
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommunicationTimeConfig_LocalTimeZoneConfig_DefaultTimeZone")]
        public System.String LocalTimeZoneConfig_DefaultTimeZone { get; set; }
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
        
        #region Parameter Schedule_EndTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_EndTime { get; set; }
        #endregion
        
        #region Parameter CommunicationLimitsOverride_InstanceLimitsHandling
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectCampaignsV2.InstanceLimitsHandling")]
        public Amazon.ConnectCampaignsV2.InstanceLimitsHandling CommunicationLimitsOverride_InstanceLimitsHandling { get; set; }
        #endregion
        
        #region Parameter LocalTimeZoneConfig_LocalTimeZoneDetection
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
        [Alias("CommunicationTimeConfig_LocalTimeZoneConfig_LocalTimeZoneDetection")]
        public System.String[] LocalTimeZoneConfig_LocalTimeZoneDetection { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Schedule_RefreshFrequency
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_RefreshFrequency { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList
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
        public Amazon.ConnectCampaignsV2.Model.RestrictedPeriod[] CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList
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
        public Amazon.ConnectCampaignsV2.Model.RestrictedPeriod[] CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList { get; set; }
        #endregion
        
        #region Parameter CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList
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
        public Amazon.ConnectCampaignsV2.Model.RestrictedPeriod[] CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList { get; set; }
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
        
        #region Parameter Schedule_StartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_StartTime { get; set; }
        #endregion
        
        #region Parameter Tag
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
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCS2Campaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse, NewCCS2CampaignCmdlet>(Select) ??
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
            if (this.AllChannelSubtypes_CommunicationLimitsList != null)
            {
                context.AllChannelSubtypes_CommunicationLimitsList = new List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit>(this.AllChannelSubtypes_CommunicationLimitsList);
            }
            context.CommunicationLimitsOverride_InstanceLimitsHandling = this.CommunicationLimitsOverride_InstanceLimitsHandling;
            if (this.CommunicationTimeConfig_Email_OpenHours_DailyHours != null)
            {
                context.CommunicationTimeConfig_Email_OpenHours_DailyHours = new Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>>(StringComparer.Ordinal);
                foreach (var hashKey in this.CommunicationTimeConfig_Email_OpenHours_DailyHours.Keys)
                {
                    object hashValue = this.CommunicationTimeConfig_Email_OpenHours_DailyHours[hashKey];
                    if (hashValue == null)
                    {
                        context.CommunicationTimeConfig_Email_OpenHours_DailyHours.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.ConnectCampaignsV2.Model.TimeRange>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.ConnectCampaignsV2.Model.TimeRange)s);
                    }
                    context.CommunicationTimeConfig_Email_OpenHours_DailyHours.Add((String)hashKey, valueSet);
                }
            }
            if (this.CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList != null)
            {
                context.CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList = new List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod>(this.CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList);
            }
            context.LocalTimeZoneConfig_DefaultTimeZone = this.LocalTimeZoneConfig_DefaultTimeZone;
            if (this.LocalTimeZoneConfig_LocalTimeZoneDetection != null)
            {
                context.LocalTimeZoneConfig_LocalTimeZoneDetection = new List<System.String>(this.LocalTimeZoneConfig_LocalTimeZoneDetection);
            }
            if (this.CommunicationTimeConfig_Sms_OpenHours_DailyHours != null)
            {
                context.CommunicationTimeConfig_Sms_OpenHours_DailyHours = new Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>>(StringComparer.Ordinal);
                foreach (var hashKey in this.CommunicationTimeConfig_Sms_OpenHours_DailyHours.Keys)
                {
                    object hashValue = this.CommunicationTimeConfig_Sms_OpenHours_DailyHours[hashKey];
                    if (hashValue == null)
                    {
                        context.CommunicationTimeConfig_Sms_OpenHours_DailyHours.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.ConnectCampaignsV2.Model.TimeRange>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.ConnectCampaignsV2.Model.TimeRange)s);
                    }
                    context.CommunicationTimeConfig_Sms_OpenHours_DailyHours.Add((String)hashKey, valueSet);
                }
            }
            if (this.CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList != null)
            {
                context.CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList = new List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod>(this.CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList);
            }
            if (this.CommunicationTimeConfig_Telephony_OpenHours_DailyHours != null)
            {
                context.CommunicationTimeConfig_Telephony_OpenHours_DailyHours = new Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>>(StringComparer.Ordinal);
                foreach (var hashKey in this.CommunicationTimeConfig_Telephony_OpenHours_DailyHours.Keys)
                {
                    object hashValue = this.CommunicationTimeConfig_Telephony_OpenHours_DailyHours[hashKey];
                    if (hashValue == null)
                    {
                        context.CommunicationTimeConfig_Telephony_OpenHours_DailyHours.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.ConnectCampaignsV2.Model.TimeRange>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.ConnectCampaignsV2.Model.TimeRange)s);
                    }
                    context.CommunicationTimeConfig_Telephony_OpenHours_DailyHours.Add((String)hashKey, valueSet);
                }
            }
            if (this.CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList != null)
            {
                context.CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList = new List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod>(this.CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList);
            }
            context.ConnectCampaignFlowArn = this.ConnectCampaignFlowArn;
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_EndTime = this.Schedule_EndTime;
            context.Schedule_RefreshFrequency = this.Schedule_RefreshFrequency;
            context.Schedule_StartTime = this.Schedule_StartTime;
            context.Source_CustomerProfilesSegmentArn = this.Source_CustomerProfilesSegmentArn;
            context.EventTrigger_CustomerProfilesDomainArn = this.EventTrigger_CustomerProfilesDomainArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.ConnectCampaignsV2.Model.CreateCampaignRequest();
            
            
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
            
             // populate CommunicationLimitsOverride
            var requestCommunicationLimitsOverrideIsNull = true;
            request.CommunicationLimitsOverride = new Amazon.ConnectCampaignsV2.Model.CommunicationLimitsConfig();
            Amazon.ConnectCampaignsV2.InstanceLimitsHandling requestCommunicationLimitsOverride_communicationLimitsOverride_InstanceLimitsHandling = null;
            if (cmdletContext.CommunicationLimitsOverride_InstanceLimitsHandling != null)
            {
                requestCommunicationLimitsOverride_communicationLimitsOverride_InstanceLimitsHandling = cmdletContext.CommunicationLimitsOverride_InstanceLimitsHandling;
            }
            if (requestCommunicationLimitsOverride_communicationLimitsOverride_InstanceLimitsHandling != null)
            {
                request.CommunicationLimitsOverride.InstanceLimitsHandling = requestCommunicationLimitsOverride_communicationLimitsOverride_InstanceLimitsHandling;
                requestCommunicationLimitsOverrideIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.CommunicationLimits requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes = null;
            
             // populate AllChannelSubtypes
            var requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypesIsNull = true;
            requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes = new Amazon.ConnectCampaignsV2.Model.CommunicationLimits();
            List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit> requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList = null;
            if (cmdletContext.AllChannelSubtypes_CommunicationLimitsList != null)
            {
                requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList = cmdletContext.AllChannelSubtypes_CommunicationLimitsList;
            }
            if (requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList != null)
            {
                requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes.CommunicationLimitsList = requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes_allChannelSubtypes_CommunicationLimitsList;
                requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypesIsNull = false;
            }
             // determine if requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes should be set to null
            if (requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypesIsNull)
            {
                requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes = null;
            }
            if (requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes != null)
            {
                request.CommunicationLimitsOverride.AllChannelSubtypes = requestCommunicationLimitsOverride_communicationLimitsOverride_AllChannelSubtypes;
                requestCommunicationLimitsOverrideIsNull = false;
            }
             // determine if request.CommunicationLimitsOverride should be set to null
            if (requestCommunicationLimitsOverrideIsNull)
            {
                request.CommunicationLimitsOverride = null;
            }
            
             // populate CommunicationTimeConfig
            var requestCommunicationTimeConfigIsNull = true;
            request.CommunicationTimeConfig = new Amazon.ConnectCampaignsV2.Model.CommunicationTimeConfig();
            Amazon.ConnectCampaignsV2.Model.TimeWindow requestCommunicationTimeConfig_communicationTimeConfig_Email = null;
            
             // populate Email
            var requestCommunicationTimeConfig_communicationTimeConfig_EmailIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Email = new Amazon.ConnectCampaignsV2.Model.TimeWindow();
            Amazon.ConnectCampaignsV2.Model.OpenHours requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours = null;
            
             // populate OpenHours
            var requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHoursIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours = new Amazon.ConnectCampaignsV2.Model.OpenHours();
            Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours_communicationTimeConfig_Email_OpenHours_DailyHours = null;
            if (cmdletContext.CommunicationTimeConfig_Email_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours_communicationTimeConfig_Email_OpenHours_DailyHours = cmdletContext.CommunicationTimeConfig_Email_OpenHours_DailyHours;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours_communicationTimeConfig_Email_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours.DailyHours = requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours_communicationTimeConfig_Email_OpenHours_DailyHours;
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHoursIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHoursIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email.OpenHours = requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_OpenHours;
                requestCommunicationTimeConfig_communicationTimeConfig_EmailIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.RestrictedPeriods requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods = null;
            
             // populate RestrictedPeriods
            var requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriodsIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods = new Amazon.ConnectCampaignsV2.Model.RestrictedPeriods();
            List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods_communicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList = null;
            if (cmdletContext.CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods_communicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList = cmdletContext.CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods_communicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods.RestrictedPeriodList = requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods_communicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList;
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriodsIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriodsIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email.RestrictedPeriods = requestCommunicationTimeConfig_communicationTimeConfig_Email_communicationTimeConfig_Email_RestrictedPeriods;
                requestCommunicationTimeConfig_communicationTimeConfig_EmailIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Email should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_EmailIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Email = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Email != null)
            {
                request.CommunicationTimeConfig.Email = requestCommunicationTimeConfig_communicationTimeConfig_Email;
                requestCommunicationTimeConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.LocalTimeZoneConfig requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig = null;
            
             // populate LocalTimeZoneConfig
            var requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfigIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig = new Amazon.ConnectCampaignsV2.Model.LocalTimeZoneConfig();
            System.String requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_DefaultTimeZone = null;
            if (cmdletContext.LocalTimeZoneConfig_DefaultTimeZone != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_DefaultTimeZone = cmdletContext.LocalTimeZoneConfig_DefaultTimeZone;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_DefaultTimeZone != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig.DefaultTimeZone = requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_DefaultTimeZone;
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfigIsNull = false;
            }
            List<System.String> requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_LocalTimeZoneDetection = null;
            if (cmdletContext.LocalTimeZoneConfig_LocalTimeZoneDetection != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_LocalTimeZoneDetection = cmdletContext.LocalTimeZoneConfig_LocalTimeZoneDetection;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_LocalTimeZoneDetection != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig.LocalTimeZoneDetection = requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig_localTimeZoneConfig_LocalTimeZoneDetection;
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfigIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfigIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig != null)
            {
                request.CommunicationTimeConfig.LocalTimeZoneConfig = requestCommunicationTimeConfig_communicationTimeConfig_LocalTimeZoneConfig;
                requestCommunicationTimeConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TimeWindow requestCommunicationTimeConfig_communicationTimeConfig_Sms = null;
            
             // populate Sms
            var requestCommunicationTimeConfig_communicationTimeConfig_SmsIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Sms = new Amazon.ConnectCampaignsV2.Model.TimeWindow();
            Amazon.ConnectCampaignsV2.Model.OpenHours requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours = null;
            
             // populate OpenHours
            var requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHoursIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours = new Amazon.ConnectCampaignsV2.Model.OpenHours();
            Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours_communicationTimeConfig_Sms_OpenHours_DailyHours = null;
            if (cmdletContext.CommunicationTimeConfig_Sms_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours_communicationTimeConfig_Sms_OpenHours_DailyHours = cmdletContext.CommunicationTimeConfig_Sms_OpenHours_DailyHours;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours_communicationTimeConfig_Sms_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours.DailyHours = requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours_communicationTimeConfig_Sms_OpenHours_DailyHours;
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHoursIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHoursIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms.OpenHours = requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_OpenHours;
                requestCommunicationTimeConfig_communicationTimeConfig_SmsIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.RestrictedPeriods requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods = null;
            
             // populate RestrictedPeriods
            var requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriodsIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods = new Amazon.ConnectCampaignsV2.Model.RestrictedPeriods();
            List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods_communicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList = null;
            if (cmdletContext.CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods_communicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList = cmdletContext.CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods_communicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods.RestrictedPeriodList = requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods_communicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList;
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriodsIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriodsIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms.RestrictedPeriods = requestCommunicationTimeConfig_communicationTimeConfig_Sms_communicationTimeConfig_Sms_RestrictedPeriods;
                requestCommunicationTimeConfig_communicationTimeConfig_SmsIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Sms should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_SmsIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Sms = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Sms != null)
            {
                request.CommunicationTimeConfig.Sms = requestCommunicationTimeConfig_communicationTimeConfig_Sms;
                requestCommunicationTimeConfigIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.TimeWindow requestCommunicationTimeConfig_communicationTimeConfig_Telephony = null;
            
             // populate Telephony
            var requestCommunicationTimeConfig_communicationTimeConfig_TelephonyIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Telephony = new Amazon.ConnectCampaignsV2.Model.TimeWindow();
            Amazon.ConnectCampaignsV2.Model.OpenHours requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours = null;
            
             // populate OpenHours
            var requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHoursIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours = new Amazon.ConnectCampaignsV2.Model.OpenHours();
            Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours_communicationTimeConfig_Telephony_OpenHours_DailyHours = null;
            if (cmdletContext.CommunicationTimeConfig_Telephony_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours_communicationTimeConfig_Telephony_OpenHours_DailyHours = cmdletContext.CommunicationTimeConfig_Telephony_OpenHours_DailyHours;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours_communicationTimeConfig_Telephony_OpenHours_DailyHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours.DailyHours = requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours_communicationTimeConfig_Telephony_OpenHours_DailyHours;
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHoursIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHoursIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony.OpenHours = requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_OpenHours;
                requestCommunicationTimeConfig_communicationTimeConfig_TelephonyIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.RestrictedPeriods requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods = null;
            
             // populate RestrictedPeriods
            var requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriodsIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods = new Amazon.ConnectCampaignsV2.Model.RestrictedPeriods();
            List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods_communicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList = null;
            if (cmdletContext.CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods_communicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList = cmdletContext.CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods_communicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods.RestrictedPeriodList = requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods_communicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList;
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriodsIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriodsIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony.RestrictedPeriods = requestCommunicationTimeConfig_communicationTimeConfig_Telephony_communicationTimeConfig_Telephony_RestrictedPeriods;
                requestCommunicationTimeConfig_communicationTimeConfig_TelephonyIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_Telephony should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_TelephonyIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_Telephony = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_Telephony != null)
            {
                request.CommunicationTimeConfig.Telephony = requestCommunicationTimeConfig_communicationTimeConfig_Telephony;
                requestCommunicationTimeConfigIsNull = false;
            }
             // determine if request.CommunicationTimeConfig should be set to null
            if (requestCommunicationTimeConfigIsNull)
            {
                request.CommunicationTimeConfig = null;
            }
            if (cmdletContext.ConnectCampaignFlowArn != null)
            {
                request.ConnectCampaignFlowArn = cmdletContext.ConnectCampaignFlowArn;
            }
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.ConnectCampaignsV2.Model.Schedule();
            System.DateTime? requestSchedule_schedule_EndTime = null;
            if (cmdletContext.Schedule_EndTime != null)
            {
                requestSchedule_schedule_EndTime = cmdletContext.Schedule_EndTime.Value;
            }
            if (requestSchedule_schedule_EndTime != null)
            {
                request.Schedule.EndTime = requestSchedule_schedule_EndTime.Value;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_RefreshFrequency = null;
            if (cmdletContext.Schedule_RefreshFrequency != null)
            {
                requestSchedule_schedule_RefreshFrequency = cmdletContext.Schedule_RefreshFrequency;
            }
            if (requestSchedule_schedule_RefreshFrequency != null)
            {
                request.Schedule.RefreshFrequency = requestSchedule_schedule_RefreshFrequency;
                requestScheduleIsNull = false;
            }
            System.DateTime? requestSchedule_schedule_StartTime = null;
            if (cmdletContext.Schedule_StartTime != null)
            {
                requestSchedule_schedule_StartTime = cmdletContext.Schedule_StartTime.Value;
            }
            if (requestSchedule_schedule_StartTime != null)
            {
                request.Schedule.StartTime = requestSchedule_schedule_StartTime.Value;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.ConnectCampaignsV2.Model.Source();
            System.String requestSource_source_CustomerProfilesSegmentArn = null;
            if (cmdletContext.Source_CustomerProfilesSegmentArn != null)
            {
                requestSource_source_CustomerProfilesSegmentArn = cmdletContext.Source_CustomerProfilesSegmentArn;
            }
            if (requestSource_source_CustomerProfilesSegmentArn != null)
            {
                request.Source.CustomerProfilesSegmentArn = requestSource_source_CustomerProfilesSegmentArn;
                requestSourceIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.EventTrigger requestSource_source_EventTrigger = null;
            
             // populate EventTrigger
            var requestSource_source_EventTriggerIsNull = true;
            requestSource_source_EventTrigger = new Amazon.ConnectCampaignsV2.Model.EventTrigger();
            System.String requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn = null;
            if (cmdletContext.EventTrigger_CustomerProfilesDomainArn != null)
            {
                requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn = cmdletContext.EventTrigger_CustomerProfilesDomainArn;
            }
            if (requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn != null)
            {
                requestSource_source_EventTrigger.CustomerProfilesDomainArn = requestSource_source_EventTrigger_eventTrigger_CustomerProfilesDomainArn;
                requestSource_source_EventTriggerIsNull = false;
            }
             // determine if requestSource_source_EventTrigger should be set to null
            if (requestSource_source_EventTriggerIsNull)
            {
                requestSource_source_EventTrigger = null;
            }
            if (requestSource_source_EventTrigger != null)
            {
                request.Source.EventTrigger = requestSource_source_EventTrigger;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "CreateCampaign");
            try
            {
                return client.CreateCampaignAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ConnectCampaignsV2.Model.CommunicationLimit> AllChannelSubtypes_CommunicationLimitsList { get; set; }
            public Amazon.ConnectCampaignsV2.InstanceLimitsHandling CommunicationLimitsOverride_InstanceLimitsHandling { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Email_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public System.String LocalTimeZoneConfig_DefaultTimeZone { get; set; }
            public List<System.String> LocalTimeZoneConfig_LocalTimeZoneDetection { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Sms_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Telephony_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public System.String ConnectCampaignFlowArn { get; set; }
            public System.String ConnectInstanceId { get; set; }
            public System.String Name { get; set; }
            public System.DateTime? Schedule_EndTime { get; set; }
            public System.String Schedule_RefreshFrequency { get; set; }
            public System.DateTime? Schedule_StartTime { get; set; }
            public System.String Source_CustomerProfilesSegmentArn { get; set; }
            public System.String EventTrigger_CustomerProfilesDomainArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.CreateCampaignResponse, NewCCS2CampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
