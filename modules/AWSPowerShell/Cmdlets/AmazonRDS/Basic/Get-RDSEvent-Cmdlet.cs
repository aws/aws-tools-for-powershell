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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Returns events related to DB instances, DB security groups, DB snapshots, and DB
    /// parameter groups for the past 14 days. Events specific to a particular DB instance,
    /// DB security group, database snapshot, or DB parameter group can be obtained by providing
    /// the name as a parameter. By default, the past hour of events are returned.
    /// </summary>
    [Cmdlet("Get", "RDSEvent")]
    [OutputType("Amazon.RDS.Model.Event")]
    [AWSCmdlet("Invokes the DescribeEvents operation against Amazon Relational Database Service.", Operation = new[] {"DescribeEvents"})]
    [AWSCmdletOutput("Amazon.RDS.Model.Event",
        "This cmdlet returns a collection of Event objects.",
        "The service call response (type DescribeEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetRDSEventCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The number of minutes to retrieve events for. </para><para>Default: 60</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Duration { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The end of the time interval for which to retrieve events, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: 2009-07-08T18:00Z</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of event categories that trigger notifications for a event notification subscription.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier of the event source for which events will be returned. If not specified,
        /// then all sources are included in the response. </para><para>Constraints:</para><ul><li>If SourceIdentifier is supplied, SourceType must also be provided.</li><li>If the source type is <code>DBInstance</code>, then a <code>DBInstanceIdentifier</code>
        /// must be supplied.</li><li>If the source type is <code>DBSecurityGroup</code>, a <code>DBSecurityGroupName</code>
        /// must be supplied.</li><li>If the source type is <code>DBParameterGroup</code>, a
        /// <code>DBParameterGroupName</code> must be supplied.</li><li>If the source type is
        /// <code>DBSnapshot</code>, a <code>DBSnapshotIdentifier</code> must be supplied.</li><li>Cannot end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String SourceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The event source to retrieve events for. If no value is specified, all events are
        /// returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public SourceType SourceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The beginning of the time interval to retrieve events for, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: 2009-07-08T18:00Z</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous DescribeEvents request. If this
        /// parameter is specified, the response includes only records beyond the marker, up to
        /// the value specified by <code>MaxRecords</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <code>MaxRecords</code> value, a pagination token called a marker is
        /// included in the response so that the remaining results may be retrieved. </para><para>Default: 100</para><para>Constraints: minimum 20, maximum 100</para>
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
            if (this.EventCategory != null)
            {
                context.EventCategories = new List<String>(this.EventCategory);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Filter>(this.Filter);
            }
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
            if (cmdletContext.EventCategories != null)
            {
                request.EventCategories = cmdletContext.EventCategories;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
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
            public List<String> EventCategories { get; set; }
            public List<Filter> Filters { get; set; }
            public String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public String SourceIdentifier { get; set; }
            public SourceType SourceType { get; set; }
            public DateTime? StartTime { get; set; }
        }
        
    }
}
