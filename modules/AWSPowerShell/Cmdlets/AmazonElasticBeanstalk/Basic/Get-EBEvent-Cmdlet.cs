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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Returns list of event descriptions matching criteria up to the last 6 weeks.
    /// 
    ///  <note> This action returns the most recent 1,000 events from the specified <code>NextToken</code>.
    /// </note>
    /// </summary>
    [Cmdlet("Get", "EBEvent")]
    [OutputType("Amazon.ElasticBeanstalk.Model.EventDescription")]
    [AWSCmdlet("Invokes the DescribeEvents operation against AWS Elastic Beanstalk.", Operation = new[] {"DescribeEvents"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.EventDescription",
        "This cmdlet returns a collection of EventDescription objects.",
        "The service call response (type DescribeEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetEBEventCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to include
        /// only those associated with this application. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ApplicationName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// that occur up to, but not including, the <code>EndTime</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime EndTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// associated with this environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EnvironmentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// associated with this environment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String EnvironmentName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the described events to include only
        /// those associated with this request ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String RequestId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, limits the events returned from this call to include only those with
        /// the specified severity or higher. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public EventSeverity Severity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// that occur on or after this time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public DateTime StartTime { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// that are associated with this environment configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String TemplateName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> If specified, AWS Elastic Beanstalk restricts the returned descriptions to those
        /// associated with this application version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String VersionLabel { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum number of events that can be returned, beginning with the most
        /// recent event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Pagination token. If specified, the events return the next batch of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.NextToken = this.NextToken;
            context.RequestId = this.RequestId;
            context.Severity = this.Severity;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            context.TemplateName = this.TemplateName;
            context.VersionLabel = this.VersionLabel;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new DescribeEventsRequest();
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.RequestId != null)
            {
                request.RequestId = cmdletContext.RequestId;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            
            // Initialize loop variants and commence piping
            String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            int? _pageSize = 1000;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxRecords))
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxRecords;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxRecords);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    if (AutoIterationHelpers.HasValue(_pageSize))
                    {
                        int correctPageSize;
                        if (AutoIterationHelpers.IsSet(request.MaxRecords))
                        {
                            correctPageSize = AutoIterationHelpers.Min(_pageSize.Value, request.MaxRecords);
                        }
                        else
                        {
                            correctPageSize = _pageSize.Value;
                        }
                        request.MaxRecords = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeEvents(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Events;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Events.Count;
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
                    // The service has a maximum page size of 1000 and the user has set a retrieval limit.
                    // Deduce what's left to fetch and if less than one page update _emitLimit to fetch just
                    // what's left to match the user's request.
                    
                    var _remainingItems = _emitLimit - _retrievedSoFar;
                    if (_remainingItems < _pageSize)
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
            public String ApplicationName { get; set; }
            public DateTime? EndTime { get; set; }
            public String EnvironmentId { get; set; }
            public String EnvironmentName { get; set; }
            public int? MaxRecords { get; set; }
            public String NextToken { get; set; }
            public String RequestId { get; set; }
            public EventSeverity Severity { get; set; }
            public DateTime? StartTime { get; set; }
            public String TemplateName { get; set; }
            public String VersionLabel { get; set; }
        }
        
    }
}
