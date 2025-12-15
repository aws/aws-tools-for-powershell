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
using Amazon.MediaTailor;
using Amazon.MediaTailor.Model;

namespace Amazon.PowerShell.Cmdlets.EMT
{
    /// <summary>
    /// Creates a prefetch schedule for a playback configuration. A prefetch schedule allows
    /// you to tell MediaTailor to fetch and prepare certain ads before an ad break happens.
    /// For more information about ad prefetching, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/prefetching-ads.html">Using
    /// ad prefetching</a> in the <i>MediaTailor User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EMTPrefetchSchedule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaTailor CreatePrefetchSchedule API operation.", Operation = new[] {"CreatePrefetchSchedule"}, SelectReturnType = typeof(Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse))]
    [AWSCmdletOutput("Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse",
        "This cmdlet returns an Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse object containing multiple properties."
    )]
    public partial class NewEMTPrefetchScheduleCmdlet : AmazonMediaTailorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Consumption_AvailMatchingCriterion
        /// <summary>
        /// <para>
        /// <para>If you only want MediaTailor to insert prefetched ads into avails (ad breaks) that
        /// match specific dynamic variables, such as <c>scte.event_id</c>, set the avail matching
        /// criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Consumption_AvailMatchingCriteria")]
        public Amazon.MediaTailor.Model.AvailMatchingCriteria[] Consumption_AvailMatchingCriterion { get; set; }
        #endregion
        
        #region Parameter RecurringConsumption_AvailMatchingCriterion
        /// <summary>
        /// <para>
        /// <para>The configuration for the dynamic variables that determine which ad breaks that MediaTailor
        /// inserts prefetched ads in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringConsumption_AvailMatchingCriteria")]
        public Amazon.MediaTailor.Model.AvailMatchingCriteria[] RecurringConsumption_AvailMatchingCriterion { get; set; }
        #endregion
        
        #region Parameter RecurringRetrieval_DelayAfterAvailEndSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds that MediaTailor waits after an ad avail before prefetching
        /// ads for the next avail. If not set, the default is 0 (no delay).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringRetrieval_DelayAfterAvailEndSeconds")]
        public System.Int32? RecurringRetrieval_DelayAfterAvailEndSecond { get; set; }
        #endregion
        
        #region Parameter RecurringRetrieval_DynamicVariable
        /// <summary>
        /// <para>
        /// <para>The dynamic variables to use for substitution during prefetch requests to the ADS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringRetrieval_DynamicVariables")]
        public System.Collections.Hashtable RecurringRetrieval_DynamicVariable { get; set; }
        #endregion
        
        #region Parameter Retrieval_DynamicVariable
        /// <summary>
        /// <para>
        /// <para>The dynamic variables to use for substitution during prefetch requests to the ad decision
        /// server (ADS).</para><para>You initially configure <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/variables.html">dynamic
        /// variables</a> for the ADS URL when you set up your playback configuration. When you
        /// specify <c>DynamicVariables</c> for prefetch retrieval, MediaTailor includes the dynamic
        /// variables in the request to the ADS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Retrieval_DynamicVariables")]
        public System.Collections.Hashtable Retrieval_DynamicVariable { get; set; }
        #endregion
        
        #region Parameter Consumption_EndTime
        /// <summary>
        /// <para>
        /// <para>The time when MediaTailor no longer considers the prefetched ads for use in an ad
        /// break. MediaTailor automatically deletes prefetch schedules no less than seven days
        /// after the end time. If you'd like to manually delete the prefetch schedule, you can
        /// call <c>DeletePrefetchSchedule</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Consumption_EndTime { get; set; }
        #endregion
        
        #region Parameter RecurringPrefetchConfiguration_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the window that MediaTailor prefetches and inserts ads in a live
        /// event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecurringPrefetchConfiguration_EndTime { get; set; }
        #endregion
        
        #region Parameter Retrieval_EndTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetch retrieval ends for the ad break. Prefetching will be attempted
        /// for manifest requests that occur at or before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Retrieval_EndTime { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name to assign to the schedule request.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers
        /// <summary>
        /// <para>
        /// <para>The expected peak number of concurrent viewers for your content. MediaTailor uses
        /// this value along with peak TPS to determine how to distribute prefetch requests across
        /// the available capacity without exceeding your ADS limits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers { get; set; }
        #endregion
        
        #region Parameter Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers
        /// <summary>
        /// <para>
        /// <para>The expected peak number of concurrent viewers for your content. MediaTailor uses
        /// this value along with peak TPS to determine how to distribute prefetch requests across
        /// the available capacity without exceeding your ADS limits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers { get; set; }
        #endregion
        
        #region Parameter RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps
        /// <summary>
        /// <para>
        /// <para>The maximum number of transactions per second (TPS) that your ad decision server (ADS)
        /// can handle. MediaTailor uses this value along with concurrent users and headroom multiplier
        /// to calculate optimal traffic distribution and prevent ADS overload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps { get; set; }
        #endregion
        
        #region Parameter Retrieval_TrafficShapingTpsConfiguration_PeakTps
        /// <summary>
        /// <para>
        /// <para>The maximum number of transactions per second (TPS) that your ad decision server (ADS)
        /// can handle. MediaTailor uses this value along with concurrent users and headroom multiplier
        /// to calculate optimal traffic distribution and prevent ADS overload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Retrieval_TrafficShapingTpsConfiguration_PeakTps { get; set; }
        #endregion
        
        #region Parameter PlaybackConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name to assign to the playback configuration.</para>
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
        public System.String PlaybackConfigurationName { get; set; }
        #endregion
        
        #region Parameter RecurringTrafficShaping_WindowDurationSeconds
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that MediaTailor spreads prefetch requests to the
        /// ADS. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow_RetrievalWindowDurationSeconds","RecurringTrafficShaping_RetrievalWindowDurationSeconds")]
        public System.Int32? RecurringTrafficShaping_WindowDurationSeconds { get; set; }
        #endregion
        
        #region Parameter TrafficShaping_WindowDurationSeconds
        /// <summary>
        /// <para>
        /// <para>The amount of time, in seconds, that MediaTailor spreads prefetch requests to the
        /// ADS. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Retrieval_TrafficShapingRetrievalWindow_RetrievalWindowDurationSeconds","TrafficShaping_RetrievalWindowDurationSeconds")]
        public System.Int32? TrafficShaping_WindowDurationSeconds { get; set; }
        #endregion
        
        #region Parameter RecurringConsumption_RetrievedAdExpirationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds that an ad is available for insertion after it was prefetched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringConsumption_RetrievedAdExpirationSeconds")]
        public System.Int32? RecurringConsumption_RetrievedAdExpirationSecond { get; set; }
        #endregion
        
        #region Parameter ScheduleType
        /// <summary>
        /// <para>
        /// <para>The frequency that MediaTailor creates prefetch schedules. <c>SINGLE</c> indicates
        /// that this schedule applies to one ad break. <c>RECURRING</c> indicates that MediaTailor
        /// automatically creates a schedule for each ad avail in a live event.</para><para>For more information about the prefetch types and when you might use each, see <a href="https://docs.aws.amazon.com/mediatailor/latest/ug/prefetching-ads.html">Prefetching
        /// ads in Elemental MediaTailor.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.PrefetchScheduleType")]
        public Amazon.MediaTailor.PrefetchScheduleType ScheduleType { get; set; }
        #endregion
        
        #region Parameter Consumption_StartTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetched ads are considered for use in an ad break. If you don't specify
        /// <c>StartTime</c>, the prefetched ads are available after MediaTailor retrieves them
        /// from the ad decision server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Consumption_StartTime { get; set; }
        #endregion
        
        #region Parameter RecurringPrefetchConfiguration_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the window that MediaTailor prefetches and inserts ads in a live
        /// event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? RecurringPrefetchConfiguration_StartTime { get; set; }
        #endregion
        
        #region Parameter Retrieval_StartTime
        /// <summary>
        /// <para>
        /// <para>The time when prefetch retrievals can start for this break. Ad prefetching will be
        /// attempted for manifest requests that occur at or after this time. Defaults to the
        /// current time. If not specified, the prefetch retrieval starts as soon as possible.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Retrieval_StartTime { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para>An optional stream identifier that MediaTailor uses to prefetch ads for multiple streams
        /// that use the same playback configuration. If <c>StreamId</c> is specified, MediaTailor
        /// returns all of the prefetch schedules with an exact match on <c>StreamId</c>. If not
        /// specified, MediaTailor returns all of the prefetch schedules for the playback configuration,
        /// regardless of <c>StreamId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter RecurringRetrieval_TrafficShapingType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of traffic shaping used to limit the number of requests to the
        /// ADS at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingType")]
        [AWSConstantClassSource("Amazon.MediaTailor.TrafficShapingType")]
        public Amazon.MediaTailor.TrafficShapingType RecurringRetrieval_TrafficShapingType { get; set; }
        #endregion
        
        #region Parameter Retrieval_TrafficShapingType
        /// <summary>
        /// <para>
        /// <para>Indicates the type of traffic shaping used to limit the number of requests to the
        /// ADS at one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaTailor.TrafficShapingType")]
        public Amazon.MediaTailor.TrafficShapingType Retrieval_TrafficShapingType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse).
        /// Specifying the name of a property of type Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMTPrefetchSchedule (CreatePrefetchSchedule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse, NewEMTPrefetchScheduleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Consumption_AvailMatchingCriterion != null)
            {
                context.Consumption_AvailMatchingCriterion = new List<Amazon.MediaTailor.Model.AvailMatchingCriteria>(this.Consumption_AvailMatchingCriterion);
            }
            context.Consumption_EndTime = this.Consumption_EndTime;
            context.Consumption_StartTime = this.Consumption_StartTime;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlaybackConfigurationName = this.PlaybackConfigurationName;
            #if MODULAR
            if (this.PlaybackConfigurationName == null && ParameterWasBound(nameof(this.PlaybackConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter PlaybackConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecurringPrefetchConfiguration_EndTime = this.RecurringPrefetchConfiguration_EndTime;
            if (this.RecurringConsumption_AvailMatchingCriterion != null)
            {
                context.RecurringConsumption_AvailMatchingCriterion = new List<Amazon.MediaTailor.Model.AvailMatchingCriteria>(this.RecurringConsumption_AvailMatchingCriterion);
            }
            context.RecurringConsumption_RetrievedAdExpirationSecond = this.RecurringConsumption_RetrievedAdExpirationSecond;
            context.RecurringRetrieval_DelayAfterAvailEndSecond = this.RecurringRetrieval_DelayAfterAvailEndSecond;
            if (this.RecurringRetrieval_DynamicVariable != null)
            {
                context.RecurringRetrieval_DynamicVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RecurringRetrieval_DynamicVariable.Keys)
                {
                    context.RecurringRetrieval_DynamicVariable.Add((String)hashKey, (System.String)(this.RecurringRetrieval_DynamicVariable[hashKey]));
                }
            }
            context.RecurringTrafficShaping_WindowDurationSeconds = this.RecurringTrafficShaping_WindowDurationSeconds;
            context.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = this.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers;
            context.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps = this.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps;
            context.RecurringRetrieval_TrafficShapingType = this.RecurringRetrieval_TrafficShapingType;
            context.RecurringPrefetchConfiguration_StartTime = this.RecurringPrefetchConfiguration_StartTime;
            if (this.Retrieval_DynamicVariable != null)
            {
                context.Retrieval_DynamicVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Retrieval_DynamicVariable.Keys)
                {
                    context.Retrieval_DynamicVariable.Add((String)hashKey, (System.String)(this.Retrieval_DynamicVariable[hashKey]));
                }
            }
            context.Retrieval_EndTime = this.Retrieval_EndTime;
            context.Retrieval_StartTime = this.Retrieval_StartTime;
            context.TrafficShaping_WindowDurationSeconds = this.TrafficShaping_WindowDurationSeconds;
            context.Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = this.Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers;
            context.Retrieval_TrafficShapingTpsConfiguration_PeakTps = this.Retrieval_TrafficShapingTpsConfiguration_PeakTps;
            context.Retrieval_TrafficShapingType = this.Retrieval_TrafficShapingType;
            context.ScheduleType = this.ScheduleType;
            context.StreamId = this.StreamId;
            
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
            var request = new Amazon.MediaTailor.Model.CreatePrefetchScheduleRequest();
            
            
             // populate Consumption
            var requestConsumptionIsNull = true;
            request.Consumption = new Amazon.MediaTailor.Model.PrefetchConsumption();
            List<Amazon.MediaTailor.Model.AvailMatchingCriteria> requestConsumption_consumption_AvailMatchingCriterion = null;
            if (cmdletContext.Consumption_AvailMatchingCriterion != null)
            {
                requestConsumption_consumption_AvailMatchingCriterion = cmdletContext.Consumption_AvailMatchingCriterion;
            }
            if (requestConsumption_consumption_AvailMatchingCriterion != null)
            {
                request.Consumption.AvailMatchingCriteria = requestConsumption_consumption_AvailMatchingCriterion;
                requestConsumptionIsNull = false;
            }
            System.DateTime? requestConsumption_consumption_EndTime = null;
            if (cmdletContext.Consumption_EndTime != null)
            {
                requestConsumption_consumption_EndTime = cmdletContext.Consumption_EndTime.Value;
            }
            if (requestConsumption_consumption_EndTime != null)
            {
                request.Consumption.EndTime = requestConsumption_consumption_EndTime.Value;
                requestConsumptionIsNull = false;
            }
            System.DateTime? requestConsumption_consumption_StartTime = null;
            if (cmdletContext.Consumption_StartTime != null)
            {
                requestConsumption_consumption_StartTime = cmdletContext.Consumption_StartTime.Value;
            }
            if (requestConsumption_consumption_StartTime != null)
            {
                request.Consumption.StartTime = requestConsumption_consumption_StartTime.Value;
                requestConsumptionIsNull = false;
            }
             // determine if request.Consumption should be set to null
            if (requestConsumptionIsNull)
            {
                request.Consumption = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlaybackConfigurationName != null)
            {
                request.PlaybackConfigurationName = cmdletContext.PlaybackConfigurationName;
            }
            
             // populate RecurringPrefetchConfiguration
            var requestRecurringPrefetchConfigurationIsNull = true;
            request.RecurringPrefetchConfiguration = new Amazon.MediaTailor.Model.RecurringPrefetchConfiguration();
            System.DateTime? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_EndTime = null;
            if (cmdletContext.RecurringPrefetchConfiguration_EndTime != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_EndTime = cmdletContext.RecurringPrefetchConfiguration_EndTime.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_EndTime != null)
            {
                request.RecurringPrefetchConfiguration.EndTime = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_EndTime.Value;
                requestRecurringPrefetchConfigurationIsNull = false;
            }
            System.DateTime? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_StartTime = null;
            if (cmdletContext.RecurringPrefetchConfiguration_StartTime != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_StartTime = cmdletContext.RecurringPrefetchConfiguration_StartTime.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_StartTime != null)
            {
                request.RecurringPrefetchConfiguration.StartTime = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_StartTime.Value;
                requestRecurringPrefetchConfigurationIsNull = false;
            }
            Amazon.MediaTailor.Model.RecurringConsumption requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption = null;
            
             // populate RecurringConsumption
            var requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumptionIsNull = true;
            requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption = new Amazon.MediaTailor.Model.RecurringConsumption();
            List<Amazon.MediaTailor.Model.AvailMatchingCriteria> requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_AvailMatchingCriterion = null;
            if (cmdletContext.RecurringConsumption_AvailMatchingCriterion != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_AvailMatchingCriterion = cmdletContext.RecurringConsumption_AvailMatchingCriterion;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_AvailMatchingCriterion != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption.AvailMatchingCriteria = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_AvailMatchingCriterion;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumptionIsNull = false;
            }
            System.Int32? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_RetrievedAdExpirationSecond = null;
            if (cmdletContext.RecurringConsumption_RetrievedAdExpirationSecond != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_RetrievedAdExpirationSecond = cmdletContext.RecurringConsumption_RetrievedAdExpirationSecond.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_RetrievedAdExpirationSecond != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption.RetrievedAdExpirationSeconds = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption_recurringConsumption_RetrievedAdExpirationSecond.Value;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumptionIsNull = false;
            }
             // determine if requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption should be set to null
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumptionIsNull)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption = null;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption != null)
            {
                request.RecurringPrefetchConfiguration.RecurringConsumption = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringConsumption;
                requestRecurringPrefetchConfigurationIsNull = false;
            }
            Amazon.MediaTailor.Model.RecurringRetrieval requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval = null;
            
             // populate RecurringRetrieval
            var requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = true;
            requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval = new Amazon.MediaTailor.Model.RecurringRetrieval();
            System.Int32? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DelayAfterAvailEndSecond = null;
            if (cmdletContext.RecurringRetrieval_DelayAfterAvailEndSecond != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DelayAfterAvailEndSecond = cmdletContext.RecurringRetrieval_DelayAfterAvailEndSecond.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DelayAfterAvailEndSecond != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval.DelayAfterAvailEndSeconds = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DelayAfterAvailEndSecond.Value;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = false;
            }
            Dictionary<System.String, System.String> requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DynamicVariable = null;
            if (cmdletContext.RecurringRetrieval_DynamicVariable != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DynamicVariable = cmdletContext.RecurringRetrieval_DynamicVariable;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DynamicVariable != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval.DynamicVariables = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_DynamicVariable;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = false;
            }
            Amazon.MediaTailor.TrafficShapingType requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_TrafficShapingType = null;
            if (cmdletContext.RecurringRetrieval_TrafficShapingType != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_TrafficShapingType = cmdletContext.RecurringRetrieval_TrafficShapingType;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_TrafficShapingType != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval.TrafficShapingType = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringRetrieval_TrafficShapingType;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = false;
            }
            Amazon.MediaTailor.Model.TrafficShapingRetrievalWindow requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow = null;
            
             // populate TrafficShapingRetrievalWindow
            var requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindowIsNull = true;
            requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow = new Amazon.MediaTailor.Model.TrafficShapingRetrievalWindow();
            System.Int32? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow_recurringTrafficShaping_WindowDurationSeconds = null;
            if (cmdletContext.RecurringTrafficShaping_WindowDurationSeconds != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow_recurringTrafficShaping_WindowDurationSeconds = cmdletContext.RecurringTrafficShaping_WindowDurationSeconds.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow_recurringTrafficShaping_WindowDurationSeconds != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow.RetrievalWindowDurationSeconds = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow_recurringTrafficShaping_WindowDurationSeconds.Value;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindowIsNull = false;
            }
             // determine if requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow should be set to null
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindowIsNull)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow = null;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval.TrafficShapingRetrievalWindow = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingRetrievalWindow;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = false;
            }
            Amazon.MediaTailor.Model.TrafficShapingTpsConfiguration requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration = null;
            
             // populate TrafficShapingTpsConfiguration
            var requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfigurationIsNull = true;
            requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration = new Amazon.MediaTailor.Model.TrafficShapingTpsConfiguration();
            System.Int32? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = null;
            if (cmdletContext.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = cmdletContext.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration.PeakConcurrentUsers = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers.Value;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfigurationIsNull = false;
            }
            System.Int32? requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps = null;
            if (cmdletContext.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps = cmdletContext.RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps.Value;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration.PeakTps = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps.Value;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfigurationIsNull = false;
            }
             // determine if requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration should be set to null
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfigurationIsNull)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration = null;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration != null)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval.TrafficShapingTpsConfiguration = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval_recurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration;
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull = false;
            }
             // determine if requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval should be set to null
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrievalIsNull)
            {
                requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval = null;
            }
            if (requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval != null)
            {
                request.RecurringPrefetchConfiguration.RecurringRetrieval = requestRecurringPrefetchConfiguration_recurringPrefetchConfiguration_RecurringRetrieval;
                requestRecurringPrefetchConfigurationIsNull = false;
            }
             // determine if request.RecurringPrefetchConfiguration should be set to null
            if (requestRecurringPrefetchConfigurationIsNull)
            {
                request.RecurringPrefetchConfiguration = null;
            }
            
             // populate Retrieval
            var requestRetrievalIsNull = true;
            request.Retrieval = new Amazon.MediaTailor.Model.PrefetchRetrieval();
            Dictionary<System.String, System.String> requestRetrieval_retrieval_DynamicVariable = null;
            if (cmdletContext.Retrieval_DynamicVariable != null)
            {
                requestRetrieval_retrieval_DynamicVariable = cmdletContext.Retrieval_DynamicVariable;
            }
            if (requestRetrieval_retrieval_DynamicVariable != null)
            {
                request.Retrieval.DynamicVariables = requestRetrieval_retrieval_DynamicVariable;
                requestRetrievalIsNull = false;
            }
            System.DateTime? requestRetrieval_retrieval_EndTime = null;
            if (cmdletContext.Retrieval_EndTime != null)
            {
                requestRetrieval_retrieval_EndTime = cmdletContext.Retrieval_EndTime.Value;
            }
            if (requestRetrieval_retrieval_EndTime != null)
            {
                request.Retrieval.EndTime = requestRetrieval_retrieval_EndTime.Value;
                requestRetrievalIsNull = false;
            }
            System.DateTime? requestRetrieval_retrieval_StartTime = null;
            if (cmdletContext.Retrieval_StartTime != null)
            {
                requestRetrieval_retrieval_StartTime = cmdletContext.Retrieval_StartTime.Value;
            }
            if (requestRetrieval_retrieval_StartTime != null)
            {
                request.Retrieval.StartTime = requestRetrieval_retrieval_StartTime.Value;
                requestRetrievalIsNull = false;
            }
            Amazon.MediaTailor.TrafficShapingType requestRetrieval_retrieval_TrafficShapingType = null;
            if (cmdletContext.Retrieval_TrafficShapingType != null)
            {
                requestRetrieval_retrieval_TrafficShapingType = cmdletContext.Retrieval_TrafficShapingType;
            }
            if (requestRetrieval_retrieval_TrafficShapingType != null)
            {
                request.Retrieval.TrafficShapingType = requestRetrieval_retrieval_TrafficShapingType;
                requestRetrievalIsNull = false;
            }
            Amazon.MediaTailor.Model.TrafficShapingRetrievalWindow requestRetrieval_retrieval_TrafficShapingRetrievalWindow = null;
            
             // populate TrafficShapingRetrievalWindow
            var requestRetrieval_retrieval_TrafficShapingRetrievalWindowIsNull = true;
            requestRetrieval_retrieval_TrafficShapingRetrievalWindow = new Amazon.MediaTailor.Model.TrafficShapingRetrievalWindow();
            System.Int32? requestRetrieval_retrieval_TrafficShapingRetrievalWindow_trafficShaping_WindowDurationSeconds = null;
            if (cmdletContext.TrafficShaping_WindowDurationSeconds != null)
            {
                requestRetrieval_retrieval_TrafficShapingRetrievalWindow_trafficShaping_WindowDurationSeconds = cmdletContext.TrafficShaping_WindowDurationSeconds.Value;
            }
            if (requestRetrieval_retrieval_TrafficShapingRetrievalWindow_trafficShaping_WindowDurationSeconds != null)
            {
                requestRetrieval_retrieval_TrafficShapingRetrievalWindow.RetrievalWindowDurationSeconds = requestRetrieval_retrieval_TrafficShapingRetrievalWindow_trafficShaping_WindowDurationSeconds.Value;
                requestRetrieval_retrieval_TrafficShapingRetrievalWindowIsNull = false;
            }
             // determine if requestRetrieval_retrieval_TrafficShapingRetrievalWindow should be set to null
            if (requestRetrieval_retrieval_TrafficShapingRetrievalWindowIsNull)
            {
                requestRetrieval_retrieval_TrafficShapingRetrievalWindow = null;
            }
            if (requestRetrieval_retrieval_TrafficShapingRetrievalWindow != null)
            {
                request.Retrieval.TrafficShapingRetrievalWindow = requestRetrieval_retrieval_TrafficShapingRetrievalWindow;
                requestRetrievalIsNull = false;
            }
            Amazon.MediaTailor.Model.TrafficShapingTpsConfiguration requestRetrieval_retrieval_TrafficShapingTpsConfiguration = null;
            
             // populate TrafficShapingTpsConfiguration
            var requestRetrieval_retrieval_TrafficShapingTpsConfigurationIsNull = true;
            requestRetrieval_retrieval_TrafficShapingTpsConfiguration = new Amazon.MediaTailor.Model.TrafficShapingTpsConfiguration();
            System.Int32? requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = null;
            if (cmdletContext.Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers != null)
            {
                requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers = cmdletContext.Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers.Value;
            }
            if (requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers != null)
            {
                requestRetrieval_retrieval_TrafficShapingTpsConfiguration.PeakConcurrentUsers = requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers.Value;
                requestRetrieval_retrieval_TrafficShapingTpsConfigurationIsNull = false;
            }
            System.Int32? requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakTps = null;
            if (cmdletContext.Retrieval_TrafficShapingTpsConfiguration_PeakTps != null)
            {
                requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakTps = cmdletContext.Retrieval_TrafficShapingTpsConfiguration_PeakTps.Value;
            }
            if (requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakTps != null)
            {
                requestRetrieval_retrieval_TrafficShapingTpsConfiguration.PeakTps = requestRetrieval_retrieval_TrafficShapingTpsConfiguration_retrieval_TrafficShapingTpsConfiguration_PeakTps.Value;
                requestRetrieval_retrieval_TrafficShapingTpsConfigurationIsNull = false;
            }
             // determine if requestRetrieval_retrieval_TrafficShapingTpsConfiguration should be set to null
            if (requestRetrieval_retrieval_TrafficShapingTpsConfigurationIsNull)
            {
                requestRetrieval_retrieval_TrafficShapingTpsConfiguration = null;
            }
            if (requestRetrieval_retrieval_TrafficShapingTpsConfiguration != null)
            {
                request.Retrieval.TrafficShapingTpsConfiguration = requestRetrieval_retrieval_TrafficShapingTpsConfiguration;
                requestRetrievalIsNull = false;
            }
             // determine if request.Retrieval should be set to null
            if (requestRetrievalIsNull)
            {
                request.Retrieval = null;
            }
            if (cmdletContext.ScheduleType != null)
            {
                request.ScheduleType = cmdletContext.ScheduleType;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
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
        
        private Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse CallAWSServiceOperation(IAmazonMediaTailor client, Amazon.MediaTailor.Model.CreatePrefetchScheduleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaTailor", "CreatePrefetchSchedule");
            try
            {
                #if DESKTOP
                return client.CreatePrefetchSchedule(request);
                #elif CORECLR
                return client.CreatePrefetchScheduleAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.MediaTailor.Model.AvailMatchingCriteria> Consumption_AvailMatchingCriterion { get; set; }
            public System.DateTime? Consumption_EndTime { get; set; }
            public System.DateTime? Consumption_StartTime { get; set; }
            public System.String Name { get; set; }
            public System.String PlaybackConfigurationName { get; set; }
            public System.DateTime? RecurringPrefetchConfiguration_EndTime { get; set; }
            public List<Amazon.MediaTailor.Model.AvailMatchingCriteria> RecurringConsumption_AvailMatchingCriterion { get; set; }
            public System.Int32? RecurringConsumption_RetrievedAdExpirationSecond { get; set; }
            public System.Int32? RecurringRetrieval_DelayAfterAvailEndSecond { get; set; }
            public Dictionary<System.String, System.String> RecurringRetrieval_DynamicVariable { get; set; }
            public System.Int32? RecurringTrafficShaping_WindowDurationSeconds { get; set; }
            public System.Int32? RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers { get; set; }
            public System.Int32? RecurringPrefetchConfiguration_RecurringRetrieval_TrafficShapingTpsConfiguration_PeakTps { get; set; }
            public Amazon.MediaTailor.TrafficShapingType RecurringRetrieval_TrafficShapingType { get; set; }
            public System.DateTime? RecurringPrefetchConfiguration_StartTime { get; set; }
            public Dictionary<System.String, System.String> Retrieval_DynamicVariable { get; set; }
            public System.DateTime? Retrieval_EndTime { get; set; }
            public System.DateTime? Retrieval_StartTime { get; set; }
            public System.Int32? TrafficShaping_WindowDurationSeconds { get; set; }
            public System.Int32? Retrieval_TrafficShapingTpsConfiguration_PeakConcurrentUsers { get; set; }
            public System.Int32? Retrieval_TrafficShapingTpsConfiguration_PeakTps { get; set; }
            public Amazon.MediaTailor.TrafficShapingType Retrieval_TrafficShapingType { get; set; }
            public Amazon.MediaTailor.PrefetchScheduleType ScheduleType { get; set; }
            public System.String StreamId { get; set; }
            public System.Func<Amazon.MediaTailor.Model.CreatePrefetchScheduleResponse, NewEMTPrefetchScheduleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
