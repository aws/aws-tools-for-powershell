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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Returns events related to clusters, security groups, snapshots, and parameter groups
    /// for the past 14 days. Events specific to a particular cluster, security group, snapshot
    /// or parameter group can be obtained by providing the name as a parameter. By default,
    /// the past hour of events are returned.
    /// </summary>
    [Cmdlet("Get", "RSEvents")]
    [OutputType("Amazon.Redshift.Model.Event")]
    [AWSCmdlet("Invokes the DescribeEvents operation against Amazon Redshift.", Operation = new[] {"DescribeEvents"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Event",
        "This cmdlet returns a collection of Event objects.",
        "The service call response (type DescribeEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetRSEventsCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The number of minutes prior to the time of the request for which to retrieve events.
        /// For example, if the request is sent at 18:00 and you specify a duration of 60, then
        /// only events which have occurred after 17:00 will be returned. </para><para>Default: <code>60</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Duration { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The end of the time interval for which to retrieve events, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: <code>2009-07-08T18:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier of the event source for which events will be returned. If this parameter
        /// is not specified, then all sources are included in the response. </para><para>Constraints:</para><para>If <i>SourceIdentifier</i> is supplied, <i>SourceType</i> must also be provided.</para><ul><li>Specify a cluster identifier when <i>SourceType</i> is <code>cluster</code>.</li><li>Specify a cluster security group name when <i>SourceType</i> is <code>cluster-security-group</code>.</li><li>Specify a cluster parameter group name when <i>SourceType</i> is <code>cluster-parameter-group</code>.</li><li>Specify a cluster snapshot identifier when <i>SourceType</i> is <code>cluster-snapshot</code>.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String SourceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The event source to retrieve events for. If no value is specified, all events are
        /// returned. </para><para>Constraints:</para><para>If <i>SourceType</i> is supplied, <i>SourceIdentifier</i> must also be provided.</para><ul><li>Specify <code>cluster</code> when <i>SourceIdentifier</i> is a cluster identifier.</li><li>Specify <code>cluster-security-group</code> when <i>SourceIdentifier</i> is a
        /// cluster security group name.</li><li>Specify <code>cluster-parameter-group</code>
        /// when <i>SourceIdentifier</i> is a cluster parameter group name.</li><li>Specify <code>cluster-snapshot</code>
        /// when <i>SourceIdentifier</i> is a cluster snapshot identifier.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public SourceType SourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The beginning of the time interval to retrieve events for, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: <code>2009-07-08T18:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional parameter that specifies the starting point to return a set of response
        /// records. When the results of a <a>DescribeEvents</a> request exceed the value specified
        /// in <code>MaxRecords</code>, AWS returns a value in the <code>Marker</code> field of
        /// the response. You can retrieve the next set of response records by providing the returned
        /// marker value in the <code>Marker</code> parameter and retrying the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of response records to return in each call. If the number of remaining
        /// response records exceeds the specified <code>MaxRecords</code> value, a value is returned
        /// in a <code>marker</code> field of the response. You can retrieve the next set of records
        /// by retrying the command with the returned marker value. </para><para>Default: <code>100</code></para><para>Constraints: minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("Duration"))
                context.Duration = this.Duration;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.SourceIdentifier = this.SourceIdentifier;
            context.SourceType = this.SourceType;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new DescribeEventsRequest();
            if (cmdletContext.Duration != null)
            {
                request.Duration = cmdletContext.Duration.Value;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.SourceIdentifier != null)
            {
                request.SourceIdentifier = cmdletContext.SourceIdentifier;
            }
            if (cmdletContext.SourceType != null)
            {
                request.SourceType = cmdletContext.SourceType;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            // Initialize loop variants and commence piping
            String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, we rely on the service
                // ignoring the set maximum and giving us 100 items back. We'll
                // make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.Marker) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeEvents(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Events;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Events.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
                        
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
                    // The service has a maximum page size of 100 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < 100)
                    {
                        _emitLimit = _remainingItems;
                    }
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
            public Int32? Duration { get; set; }
            public DateTime? EndTime { get; set; }
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public String SourceIdentifier { get; set; }
            public SourceType SourceType { get; set; }
            public DateTime? StartTime { get; set; }
        }
        
    }
}
