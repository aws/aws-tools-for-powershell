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
    /// Updates the communication time config for a campaign. This API is idempotent.
    /// </summary>
    [Cmdlet("Update", "CCS2CampaignCommunicationTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AmazonConnectCampaignServiceV2 UpdateCampaignCommunicationTime API operation.", Operation = new[] {"UpdateCampaignCommunicationTime"}, SelectReturnType = typeof(Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCS2CampaignCommunicationTimeCmdlet : AmazonConnectCampaignsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter OpenHours_DailyHour
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
        [Alias("CommunicationTimeConfig_WhatsApp_OpenHours_DailyHours")]
        public System.Collections.Hashtable OpenHours_DailyHour { get; set; }
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
        
        #region Parameter RestrictedPeriods_RestrictedPeriodList
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
        [Alias("CommunicationTimeConfig_WhatsApp_RestrictedPeriods_RestrictedPeriodList")]
        public Amazon.ConnectCampaignsV2.Model.RestrictedPeriod[] RestrictedPeriods_RestrictedPeriodList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCS2CampaignCommunicationTime (UpdateCampaignCommunicationTime)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse, UpdateCCS2CampaignCommunicationTimeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            if (this.OpenHours_DailyHour != null)
            {
                context.OpenHours_DailyHour = new Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>>(StringComparer.Ordinal);
                foreach (var hashKey in this.OpenHours_DailyHour.Keys)
                {
                    object hashValue = this.OpenHours_DailyHour[hashKey];
                    if (hashValue == null)
                    {
                        context.OpenHours_DailyHour.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<Amazon.ConnectCampaignsV2.Model.TimeRange>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((Amazon.ConnectCampaignsV2.Model.TimeRange)s);
                    }
                    context.OpenHours_DailyHour.Add((String)hashKey, valueSet);
                }
            }
            if (this.RestrictedPeriods_RestrictedPeriodList != null)
            {
                context.RestrictedPeriods_RestrictedPeriodList = new List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod>(this.RestrictedPeriods_RestrictedPeriodList);
            }
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
            var request = new Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeRequest();
            
            
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
            Amazon.ConnectCampaignsV2.Model.TimeWindow requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp = null;
            
             // populate WhatsApp
            var requestCommunicationTimeConfig_communicationTimeConfig_WhatsAppIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp = new Amazon.ConnectCampaignsV2.Model.TimeWindow();
            Amazon.ConnectCampaignsV2.Model.OpenHours requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours = null;
            
             // populate OpenHours
            var requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHoursIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours = new Amazon.ConnectCampaignsV2.Model.OpenHours();
            Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours_openHours_DailyHour = null;
            if (cmdletContext.OpenHours_DailyHour != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours_openHours_DailyHour = cmdletContext.OpenHours_DailyHour;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours_openHours_DailyHour != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours.DailyHours = requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours_openHours_DailyHour;
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHoursIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHoursIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp.OpenHours = requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_OpenHours;
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsAppIsNull = false;
            }
            Amazon.ConnectCampaignsV2.Model.RestrictedPeriods requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods = null;
            
             // populate RestrictedPeriods
            var requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriodsIsNull = true;
            requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods = new Amazon.ConnectCampaignsV2.Model.RestrictedPeriods();
            List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods_restrictedPeriods_RestrictedPeriodList = null;
            if (cmdletContext.RestrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods_restrictedPeriods_RestrictedPeriodList = cmdletContext.RestrictedPeriods_RestrictedPeriodList;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods_restrictedPeriods_RestrictedPeriodList != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods.RestrictedPeriodList = requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods_restrictedPeriods_RestrictedPeriodList;
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriodsIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriodsIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods != null)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp.RestrictedPeriods = requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp_communicationTimeConfig_WhatsApp_RestrictedPeriods;
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsAppIsNull = false;
            }
             // determine if requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp should be set to null
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsAppIsNull)
            {
                requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp = null;
            }
            if (requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp != null)
            {
                request.CommunicationTimeConfig.WhatsApp = requestCommunicationTimeConfig_communicationTimeConfig_WhatsApp;
                requestCommunicationTimeConfigIsNull = false;
            }
             // determine if request.CommunicationTimeConfig should be set to null
            if (requestCommunicationTimeConfigIsNull)
            {
                request.CommunicationTimeConfig = null;
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
        
        private Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse CallAWSServiceOperation(IAmazonConnectCampaignsV2 client, Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AmazonConnectCampaignServiceV2", "UpdateCampaignCommunicationTime");
            try
            {
                return client.UpdateCampaignCommunicationTimeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Email_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Email_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public System.String LocalTimeZoneConfig_DefaultTimeZone { get; set; }
            public List<System.String> LocalTimeZoneConfig_LocalTimeZoneDetection { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Sms_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Sms_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> CommunicationTimeConfig_Telephony_OpenHours_DailyHours { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> CommunicationTimeConfig_Telephony_RestrictedPeriods_RestrictedPeriodList { get; set; }
            public Dictionary<System.String, List<Amazon.ConnectCampaignsV2.Model.TimeRange>> OpenHours_DailyHour { get; set; }
            public List<Amazon.ConnectCampaignsV2.Model.RestrictedPeriod> RestrictedPeriods_RestrictedPeriodList { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.ConnectCampaignsV2.Model.UpdateCampaignCommunicationTimeResponse, UpdateCCS2CampaignCommunicationTimeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
