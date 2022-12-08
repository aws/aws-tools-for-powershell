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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Finds available schedules that meet the specified criteria.
    /// 
    ///  
    /// <para>
    /// You can search for an available schedule no more than 3 months in advance. You must
    /// meet the minimum required duration of 1,200 hours per year. For example, the minimum
    /// daily schedule is 4 hours, the minimum weekly schedule is 24 hours, and the minimum
    /// monthly schedule is 100 hours.
    /// </para><para>
    /// After you find a schedule that meets your needs, call <a>PurchaseScheduledInstances</a>
    /// to purchase Scheduled Instances with that schedule.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2ScheduledInstanceAvailability")]
    [OutputType("Amazon.EC2.Model.ScheduledInstanceAvailability")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeScheduledInstanceAvailability API operation.", Operation = new[] {"DescribeScheduledInstanceAvailability"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ScheduledInstanceAvailability or Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ScheduledInstanceAvailability objects.",
        "The service call response (type Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ScheduledInstanceAvailabilityCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter FirstSlotStartTimeRange_UtcEarliestTime
        /// <summary>
        /// <para>
        /// <para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FirstSlotStartTimeRange_UtcEarliestTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone (for example, <code>us-west-2a</code>).</para></li><li><para><code>instance-type</code> - The instance type (for example, <code>c4.large</code>).</para></li><li><para><code>network-platform</code> - The network platform (<code>EC2-Classic</code> or
        /// <code>EC2-VPC</code>).</para></li><li><para><code>platform</code> - The platform (<code>Linux/UNIX</code> or <code>Windows</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Recurrence_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency (<code>Daily</code>, <code>Weekly</code>, or <code>Monthly</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recurrence_Frequency { get; set; }
        #endregion
        
        #region Parameter Recurrence_Interval
        /// <summary>
        /// <para>
        /// <para>The interval quantity. The interval unit depends on the value of <code>Frequency</code>.
        /// For example, every 2 weeks or every 2 months.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Recurrence_Interval { get; set; }
        #endregion
        
        #region Parameter FirstSlotStartTimeRange_UtcLatestTime
        /// <summary>
        /// <para>
        /// <para>The latest date and time, in UTC, for the Scheduled Instance to start. This value
        /// must be later than or equal to the earliest date and at most three months in the future.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? FirstSlotStartTimeRange_UtcLatestTime { get; set; }
        #endregion
        
        #region Parameter MaxSlotDurationInHour
        /// <summary>
        /// <para>
        /// <para>The maximum available duration, in hours. This value must be greater than <code>MinSlotDurationInHours</code>
        /// and less than 1,720.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxSlotDurationInHours")]
        public System.Int32? MaxSlotDurationInHour { get; set; }
        #endregion
        
        #region Parameter MinSlotDurationInHour
        /// <summary>
        /// <para>
        /// <para>The minimum available duration, in hours. The minimum required duration is 1,200 hours
        /// per year. For example, the minimum daily schedule is 4 hours, the minimum weekly schedule
        /// is 24 hours, and the minimum monthly schedule is 100 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinSlotDurationInHours")]
        public System.Int32? MinSlotDurationInHour { get; set; }
        #endregion
        
        #region Parameter Recurrence_OccurrenceDay
        /// <summary>
        /// <para>
        /// <para>The days. For a monthly schedule, this is one or more days of the month (1-31). For
        /// a weekly schedule, this is one or more days of the week (1-7, where 1 is Sunday).
        /// You can't specify this value with a daily schedule. If the occurrence is relative
        /// to the end of the month, you can specify only a single day.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recurrence_OccurrenceDays")]
        public System.Int32[] Recurrence_OccurrenceDay { get; set; }
        #endregion
        
        #region Parameter Recurrence_OccurrenceRelativeToEnd
        /// <summary>
        /// <para>
        /// <para>Indicates whether the occurrence is relative to the end of the specified week or month.
        /// You can't specify this value with a daily schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recurrence_OccurrenceRelativeToEnd { get; set; }
        #endregion
        
        #region Parameter Recurrence_OccurrenceUnit
        /// <summary>
        /// <para>
        /// <para>The unit for <code>OccurrenceDays</code> (<code>DayOfWeek</code> or <code>DayOfMonth</code>).
        /// This value is required for a monthly schedule. You can't specify <code>DayOfWeek</code>
        /// with a weekly schedule. You can't specify this value with a daily schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recurrence_OccurrenceUnit { get; set; }
        #endregion
        
        #region Parameter FirstSlotStartTimeRange_EarliestTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use EarliestTimeUtc instead. Setting either EarliestTime
        /// or EarliestTimeUtc results in both EarliestTime and EarliestTimeUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value
        /// of both. EarliestTime is provided for backwards compatibility only and assigning a
        /// non-Utc DateTime to it results in the wrong timestamp being passed to the service.</para><para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use FirstSlotStartTimeRange_UtcEarliestTime instead.")]
        public System.DateTime? FirstSlotStartTimeRange_EarliestTime { get; set; }
        #endregion
        
        #region Parameter FirstSlotStartTimeRange_LatestTime
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use LatestTimeUtc instead. Setting either LatestTime or
        /// LatestTimeUtc results in both LatestTime and LatestTimeUtc being assigned, the latest
        /// assignment to either one of the two property is reflected in the value of both. LatestTime
        /// is provided for backwards compatibility only and assigning a non-Utc DateTime to it
        /// results in the wrong timestamp being passed to the service.</para><para>The latest date and time, in UTC, for the Scheduled Instance to start. This value
        /// must be later than or equal to the earliest date and at most three months in the future.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use FirstSlotStartTimeRange_UtcLatestTime instead.")]
        public System.DateTime? FirstSlotStartTimeRange_LatestTime { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. This value can be between
        /// 5 and 300. The default value is 300. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduledInstanceAvailabilitySet'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduledInstanceAvailabilitySet";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse, GetEC2ScheduledInstanceAvailabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.FirstSlotStartTimeRange_UtcEarliestTime = this.FirstSlotStartTimeRange_UtcEarliestTime;
            #if MODULAR
            if (this.FirstSlotStartTimeRange_UtcEarliestTime == null && ParameterWasBound(nameof(this.FirstSlotStartTimeRange_UtcEarliestTime)))
            {
                WriteWarning("You are passing $null as a value for parameter FirstSlotStartTimeRange_UtcEarliestTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirstSlotStartTimeRange_UtcLatestTime = this.FirstSlotStartTimeRange_UtcLatestTime;
            #if MODULAR
            if (this.FirstSlotStartTimeRange_UtcLatestTime == null && ParameterWasBound(nameof(this.FirstSlotStartTimeRange_UtcLatestTime)))
            {
                WriteWarning("You are passing $null as a value for parameter FirstSlotStartTimeRange_UtcLatestTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirstSlotStartTimeRange_EarliestTime = this.FirstSlotStartTimeRange_EarliestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FirstSlotStartTimeRange_LatestTime = this.FirstSlotStartTimeRange_LatestTime;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MaxSlotDurationInHour = this.MaxSlotDurationInHour;
            context.MinSlotDurationInHour = this.MinSlotDurationInHour;
            context.NextToken = this.NextToken;
            context.Recurrence_Frequency = this.Recurrence_Frequency;
            context.Recurrence_Interval = this.Recurrence_Interval;
            if (this.Recurrence_OccurrenceDay != null)
            {
                context.Recurrence_OccurrenceDay = new List<System.Int32>(this.Recurrence_OccurrenceDay);
            }
            context.Recurrence_OccurrenceRelativeToEnd = this.Recurrence_OccurrenceRelativeToEnd;
            context.Recurrence_OccurrenceUnit = this.Recurrence_OccurrenceUnit;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            
             // populate FirstSlotStartTimeRange
            var requestFirstSlotStartTimeRangeIsNull = true;
            request.FirstSlotStartTimeRange = new Amazon.EC2.Model.SlotDateTimeRangeRequest();
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime = cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime != null)
            {
                request.FirstSlotStartTimeRange.EarliestTimeUtc = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_UtcLatestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime = cmdletContext.FirstSlotStartTimeRange_UtcLatestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime != null)
            {
                request.FirstSlotStartTimeRange.LatestTimeUtc = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_EarliestTime != null)
            {
                if (cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime != null)
                {
                    throw new System.ArgumentException("Parameters FirstSlotStartTimeRange_EarliestTime and FirstSlotStartTimeRange_UtcEarliestTime are mutually exclusive.", nameof(this.FirstSlotStartTimeRange_EarliestTime));
                }
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = cmdletContext.FirstSlotStartTimeRange_EarliestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime != null)
            {
                request.FirstSlotStartTimeRange.EarliestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_LatestTime != null)
            {
                if (cmdletContext.FirstSlotStartTimeRange_UtcLatestTime != null)
                {
                    throw new System.ArgumentException("Parameters FirstSlotStartTimeRange_LatestTime and FirstSlotStartTimeRange_UtcLatestTime are mutually exclusive.", nameof(this.FirstSlotStartTimeRange_LatestTime));
                }
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = cmdletContext.FirstSlotStartTimeRange_LatestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime != null)
            {
                request.FirstSlotStartTimeRange.LatestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.FirstSlotStartTimeRange should be set to null
            if (requestFirstSlotStartTimeRangeIsNull)
            {
                request.FirstSlotStartTimeRange = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MaxSlotDurationInHour != null)
            {
                request.MaxSlotDurationInHours = cmdletContext.MaxSlotDurationInHour.Value;
            }
            if (cmdletContext.MinSlotDurationInHour != null)
            {
                request.MinSlotDurationInHours = cmdletContext.MinSlotDurationInHour.Value;
            }
            
             // populate Recurrence
            var requestRecurrenceIsNull = true;
            request.Recurrence = new Amazon.EC2.Model.ScheduledInstanceRecurrenceRequest();
            System.String requestRecurrence_recurrence_Frequency = null;
            if (cmdletContext.Recurrence_Frequency != null)
            {
                requestRecurrence_recurrence_Frequency = cmdletContext.Recurrence_Frequency;
            }
            if (requestRecurrence_recurrence_Frequency != null)
            {
                request.Recurrence.Frequency = requestRecurrence_recurrence_Frequency;
                requestRecurrenceIsNull = false;
            }
            System.Int32? requestRecurrence_recurrence_Interval = null;
            if (cmdletContext.Recurrence_Interval != null)
            {
                requestRecurrence_recurrence_Interval = cmdletContext.Recurrence_Interval.Value;
            }
            if (requestRecurrence_recurrence_Interval != null)
            {
                request.Recurrence.Interval = requestRecurrence_recurrence_Interval.Value;
                requestRecurrenceIsNull = false;
            }
            List<System.Int32> requestRecurrence_recurrence_OccurrenceDay = null;
            if (cmdletContext.Recurrence_OccurrenceDay != null)
            {
                requestRecurrence_recurrence_OccurrenceDay = cmdletContext.Recurrence_OccurrenceDay;
            }
            if (requestRecurrence_recurrence_OccurrenceDay != null)
            {
                request.Recurrence.OccurrenceDays = requestRecurrence_recurrence_OccurrenceDay;
                requestRecurrenceIsNull = false;
            }
            System.Boolean? requestRecurrence_recurrence_OccurrenceRelativeToEnd = null;
            if (cmdletContext.Recurrence_OccurrenceRelativeToEnd != null)
            {
                requestRecurrence_recurrence_OccurrenceRelativeToEnd = cmdletContext.Recurrence_OccurrenceRelativeToEnd.Value;
            }
            if (requestRecurrence_recurrence_OccurrenceRelativeToEnd != null)
            {
                request.Recurrence.OccurrenceRelativeToEnd = requestRecurrence_recurrence_OccurrenceRelativeToEnd.Value;
                requestRecurrenceIsNull = false;
            }
            System.String requestRecurrence_recurrence_OccurrenceUnit = null;
            if (cmdletContext.Recurrence_OccurrenceUnit != null)
            {
                requestRecurrence_recurrence_OccurrenceUnit = cmdletContext.Recurrence_OccurrenceUnit;
            }
            if (requestRecurrence_recurrence_OccurrenceUnit != null)
            {
                request.Recurrence.OccurrenceUnit = requestRecurrence_recurrence_OccurrenceUnit;
                requestRecurrenceIsNull = false;
            }
             // determine if request.Recurrence should be set to null
            if (requestRecurrenceIsNull)
            {
                request.Recurrence = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            
             // populate FirstSlotStartTimeRange
            var requestFirstSlotStartTimeRangeIsNull = true;
            request.FirstSlotStartTimeRange = new Amazon.EC2.Model.SlotDateTimeRangeRequest();
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime = cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime != null)
            {
                request.FirstSlotStartTimeRange.EarliestTimeUtc = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcEarliestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_UtcLatestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime = cmdletContext.FirstSlotStartTimeRange_UtcLatestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime != null)
            {
                request.FirstSlotStartTimeRange.LatestTimeUtc = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_UtcLatestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_EarliestTime != null)
            {
                if (cmdletContext.FirstSlotStartTimeRange_UtcEarliestTime != null)
                {
                    throw new System.ArgumentException("Parameters FirstSlotStartTimeRange_EarliestTime and FirstSlotStartTimeRange_UtcEarliestTime are mutually exclusive.", nameof(this.FirstSlotStartTimeRange_EarliestTime));
                }
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = cmdletContext.FirstSlotStartTimeRange_EarliestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime != null)
            {
                request.FirstSlotStartTimeRange.EarliestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_LatestTime != null)
            {
                if (cmdletContext.FirstSlotStartTimeRange_UtcLatestTime != null)
                {
                    throw new System.ArgumentException("Parameters FirstSlotStartTimeRange_LatestTime and FirstSlotStartTimeRange_UtcLatestTime are mutually exclusive.", nameof(this.FirstSlotStartTimeRange_LatestTime));
                }
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = cmdletContext.FirstSlotStartTimeRange_LatestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime != null)
            {
                request.FirstSlotStartTimeRange.LatestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
             // determine if request.FirstSlotStartTimeRange should be set to null
            if (requestFirstSlotStartTimeRangeIsNull)
            {
                request.FirstSlotStartTimeRange = null;
            }
            if (cmdletContext.MaxSlotDurationInHour != null)
            {
                request.MaxSlotDurationInHours = cmdletContext.MaxSlotDurationInHour.Value;
            }
            if (cmdletContext.MinSlotDurationInHour != null)
            {
                request.MinSlotDurationInHours = cmdletContext.MinSlotDurationInHour.Value;
            }
            
             // populate Recurrence
            var requestRecurrenceIsNull = true;
            request.Recurrence = new Amazon.EC2.Model.ScheduledInstanceRecurrenceRequest();
            System.String requestRecurrence_recurrence_Frequency = null;
            if (cmdletContext.Recurrence_Frequency != null)
            {
                requestRecurrence_recurrence_Frequency = cmdletContext.Recurrence_Frequency;
            }
            if (requestRecurrence_recurrence_Frequency != null)
            {
                request.Recurrence.Frequency = requestRecurrence_recurrence_Frequency;
                requestRecurrenceIsNull = false;
            }
            System.Int32? requestRecurrence_recurrence_Interval = null;
            if (cmdletContext.Recurrence_Interval != null)
            {
                requestRecurrence_recurrence_Interval = cmdletContext.Recurrence_Interval.Value;
            }
            if (requestRecurrence_recurrence_Interval != null)
            {
                request.Recurrence.Interval = requestRecurrence_recurrence_Interval.Value;
                requestRecurrenceIsNull = false;
            }
            List<System.Int32> requestRecurrence_recurrence_OccurrenceDay = null;
            if (cmdletContext.Recurrence_OccurrenceDay != null)
            {
                requestRecurrence_recurrence_OccurrenceDay = cmdletContext.Recurrence_OccurrenceDay;
            }
            if (requestRecurrence_recurrence_OccurrenceDay != null)
            {
                request.Recurrence.OccurrenceDays = requestRecurrence_recurrence_OccurrenceDay;
                requestRecurrenceIsNull = false;
            }
            System.Boolean? requestRecurrence_recurrence_OccurrenceRelativeToEnd = null;
            if (cmdletContext.Recurrence_OccurrenceRelativeToEnd != null)
            {
                requestRecurrence_recurrence_OccurrenceRelativeToEnd = cmdletContext.Recurrence_OccurrenceRelativeToEnd.Value;
            }
            if (requestRecurrence_recurrence_OccurrenceRelativeToEnd != null)
            {
                request.Recurrence.OccurrenceRelativeToEnd = requestRecurrence_recurrence_OccurrenceRelativeToEnd.Value;
                requestRecurrenceIsNull = false;
            }
            System.String requestRecurrence_recurrence_OccurrenceUnit = null;
            if (cmdletContext.Recurrence_OccurrenceUnit != null)
            {
                requestRecurrence_recurrence_OccurrenceUnit = cmdletContext.Recurrence_OccurrenceUnit;
            }
            if (requestRecurrence_recurrence_OccurrenceUnit != null)
            {
                request.Recurrence.OccurrenceUnit = requestRecurrence_recurrence_OccurrenceUnit;
                requestRecurrenceIsNull = false;
            }
             // determine if request.Recurrence should be set to null
            if (requestRecurrenceIsNull)
            {
                request.Recurrence = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 300. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 300 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(300, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.ScheduledInstanceAvailabilitySet.Count;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 5));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeScheduledInstanceAvailability");
            try
            {
                #if DESKTOP
                return client.DescribeScheduledInstanceAvailability(request);
                #elif CORECLR
                return client.DescribeScheduledInstanceAvailabilityAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.DateTime? FirstSlotStartTimeRange_UtcEarliestTime { get; set; }
            public System.DateTime? FirstSlotStartTimeRange_UtcLatestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? FirstSlotStartTimeRange_EarliestTime { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? FirstSlotStartTimeRange_LatestTime { get; set; }
            public int? MaxResult { get; set; }
            public System.Int32? MaxSlotDurationInHour { get; set; }
            public System.Int32? MinSlotDurationInHour { get; set; }
            public System.String NextToken { get; set; }
            public System.String Recurrence_Frequency { get; set; }
            public System.Int32? Recurrence_Interval { get; set; }
            public List<System.Int32> Recurrence_OccurrenceDay { get; set; }
            public System.Boolean? Recurrence_OccurrenceRelativeToEnd { get; set; }
            public System.String Recurrence_OccurrenceUnit { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse, GetEC2ScheduledInstanceAvailabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduledInstanceAvailabilitySet;
        }
        
    }
}
