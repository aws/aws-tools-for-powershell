/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ScheduledInstanceAvailability")]
    [OutputType("Amazon.EC2.Model.ScheduledInstanceAvailability")]
    [AWSCmdlet("Invokes the DescribeScheduledInstanceAvailability operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeScheduledInstanceAvailability"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ScheduledInstanceAvailability",
        "This cmdlet returns a collection of ScheduledInstanceAvailability objects.",
        "The service call response (type Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetEC2ScheduledInstanceAvailabilityCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter FirstSlotStartTimeRange_EarliestTime
        /// <summary>
        /// <para>
        /// <para>The earliest date and time, in UTC, for the Scheduled Instance to start.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime FirstSlotStartTimeRange_EarliestTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone (for example, <code>us-west-2a</code>).</para></li><li><para><code>instance-type</code> - The instance type (for example, <code>c4.large</code>).</para></li><li><para><code>network-platform</code> - The network platform (<code>EC2-Classic</code> or
        /// <code>EC2-VPC</code>).</para></li><li><para><code>platform</code> - The platform (<code>Linux/UNIX</code> or <code>Windows</code>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter Recurrence_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency (<code>Daily</code>, <code>Weekly</code>, or <code>Monthly</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Recurrence_Frequency { get; set; }
        #endregion
        
        #region Parameter Recurrence_Interval
        /// <summary>
        /// <para>
        /// <para>The interval quantity. The interval unit depends on the value of <code>Frequency</code>.
        /// For example, every 2 weeks or every 2 months.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Recurrence_Interval { get; set; }
        #endregion
        
        #region Parameter FirstSlotStartTimeRange_LatestTime
        /// <summary>
        /// <para>
        /// <para>The latest date and time, in UTC, for the Scheduled Instance to start. This value
        /// must be later than or equal to the earliest date and at most three months in the future.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime FirstSlotStartTimeRange_LatestTime { get; set; }
        #endregion
        
        #region Parameter MaxSlotDurationInHour
        /// <summary>
        /// <para>
        /// <para>The maximum available duration, in hours. This value must be greater than <code>MinSlotDurationInHours</code>
        /// and less than 1,720.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxSlotDurationInHours")]
        public System.Int32 MaxSlotDurationInHour { get; set; }
        #endregion
        
        #region Parameter MinSlotDurationInHour
        /// <summary>
        /// <para>
        /// <para>The minimum available duration, in hours. The minimum required duration is 1,200 hours
        /// per year. For example, the minimum daily schedule is 4 hours, the minimum weekly schedule
        /// is 24 hours, and the minimum monthly schedule is 100 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MinSlotDurationInHours")]
        public System.Int32 MinSlotDurationInHour { get; set; }
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
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.Boolean Recurrence_OccurrenceRelativeToEnd { get; set; }
        #endregion
        
        #region Parameter Recurrence_OccurrenceUnit
        /// <summary>
        /// <para>
        /// <para>The unit for <code>OccurrenceDays</code> (<code>DayOfWeek</code> or <code>DayOfMonth</code>).
        /// This value is required for a monthly schedule. You can't specify <code>DayOfWeek</code>
        /// with a weekly schedule. You can't specify this value with a daily schedule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Recurrence_OccurrenceUnit { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. This value can be between
        /// 5 and 300. The default value is 300. To retrieve the remaining results, make another
        /// call with the returned <code>NextToken</code> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("FirstSlotStartTimeRange_EarliestTime"))
                context.FirstSlotStartTimeRange_EarliestTime = this.FirstSlotStartTimeRange_EarliestTime;
            if (ParameterWasBound("FirstSlotStartTimeRange_LatestTime"))
                context.FirstSlotStartTimeRange_LatestTime = this.FirstSlotStartTimeRange_LatestTime;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (ParameterWasBound("MaxSlotDurationInHour"))
                context.MaxSlotDurationInHours = this.MaxSlotDurationInHour;
            if (ParameterWasBound("MinSlotDurationInHour"))
                context.MinSlotDurationInHours = this.MinSlotDurationInHour;
            context.NextToken = this.NextToken;
            context.Recurrence_Frequency = this.Recurrence_Frequency;
            if (ParameterWasBound("Recurrence_Interval"))
                context.Recurrence_Interval = this.Recurrence_Interval;
            if (this.Recurrence_OccurrenceDay != null)
            {
                context.Recurrence_OccurrenceDays = new List<System.Int32>(this.Recurrence_OccurrenceDay);
            }
            if (ParameterWasBound("Recurrence_OccurrenceRelativeToEnd"))
                context.Recurrence_OccurrenceRelativeToEnd = this.Recurrence_OccurrenceRelativeToEnd;
            context.Recurrence_OccurrenceUnit = this.Recurrence_OccurrenceUnit;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeScheduledInstanceAvailabilityRequest();
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            
             // populate FirstSlotStartTimeRange
            bool requestFirstSlotStartTimeRangeIsNull = true;
            request.FirstSlotStartTimeRange = new Amazon.EC2.Model.SlotDateTimeRangeRequest();
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_EarliestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime = cmdletContext.FirstSlotStartTimeRange_EarliestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime != null)
            {
                request.FirstSlotStartTimeRange.EarliestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_EarliestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
            System.DateTime? requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = null;
            if (cmdletContext.FirstSlotStartTimeRange_LatestTime != null)
            {
                requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime = cmdletContext.FirstSlotStartTimeRange_LatestTime.Value;
            }
            if (requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime != null)
            {
                request.FirstSlotStartTimeRange.LatestTime = requestFirstSlotStartTimeRange_firstSlotStartTimeRange_LatestTime.Value;
                requestFirstSlotStartTimeRangeIsNull = false;
            }
             // determine if request.FirstSlotStartTimeRange should be set to null
            if (requestFirstSlotStartTimeRangeIsNull)
            {
                request.FirstSlotStartTimeRange = null;
            }
            if (cmdletContext.MaxSlotDurationInHours != null)
            {
                request.MaxSlotDurationInHours = cmdletContext.MaxSlotDurationInHours.Value;
            }
            if (cmdletContext.MinSlotDurationInHours != null)
            {
                request.MinSlotDurationInHours = cmdletContext.MinSlotDurationInHours.Value;
            }
            
             // populate Recurrence
            bool requestRecurrenceIsNull = true;
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
            if (cmdletContext.Recurrence_OccurrenceDays != null)
            {
                requestRecurrence_recurrence_OccurrenceDay = cmdletContext.Recurrence_OccurrenceDays;
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
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeScheduledInstanceAvailability(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ScheduledInstanceAvailabilitySet;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ScheduledInstanceAvailabilitySet.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public System.DateTime? FirstSlotStartTimeRange_EarliestTime { get; set; }
            public System.DateTime? FirstSlotStartTimeRange_LatestTime { get; set; }
            public int? MaxResults { get; set; }
            public System.Int32? MaxSlotDurationInHours { get; set; }
            public System.Int32? MinSlotDurationInHours { get; set; }
            public System.String NextToken { get; set; }
            public System.String Recurrence_Frequency { get; set; }
            public System.Int32? Recurrence_Interval { get; set; }
            public List<System.Int32> Recurrence_OccurrenceDays { get; set; }
            public System.Boolean? Recurrence_OccurrenceRelativeToEnd { get; set; }
            public System.String Recurrence_OccurrenceUnit { get; set; }
        }
        
    }
}
