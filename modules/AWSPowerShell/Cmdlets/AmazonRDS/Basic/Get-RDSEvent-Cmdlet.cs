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
    /// Returns events related to DB instances, DB security groups, DB snapshots, and DB parameter
    /// groups for the past 14 days. Events specific to a particular DB instance, DB security
    /// group, database snapshot, or DB parameter group can be obtained by providing the name
    /// as a parameter. By default, the past hour of events are returned.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "RDSEvent")]
    [OutputType("Amazon.RDS.Model.Event")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DescribeEvents API operation.", Operation = new[] {"DescribeEvents"})]
    [AWSCmdletOutput("Amazon.RDS.Model.Event",
        "This cmdlet returns a collection of Event objects.",
        "The service call response (type Amazon.RDS.Model.DescribeEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type System.String)"
    )]
    public partial class GetRDSEventCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter Duration
        /// <summary>
        /// <para>
        /// <para>The number of minutes to retrieve events for.</para><para>Default: 60</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Duration { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para> The end of the time interval for which to retrieve events, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: 2009-07-08T18:00Z</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter EventCategory
        /// <summary>
        /// <para>
        /// <para>A list of event categories that trigger notifications for a event notification subscription.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventCategories")]
        public System.String[] EventCategory { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>This parameter is not currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.RDS.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the event source for which events are returned. If not specified,
        /// then all sources are included in the response.</para><para>Constraints:</para><ul><li><para>If SourceIdentifier is supplied, SourceType must also be provided.</para></li><li><para>If the source type is <code>DBInstance</code>, then a <code>DBInstanceIdentifier</code>
        /// must be supplied.</para></li><li><para>If the source type is <code>DBSecurityGroup</code>, a <code>DBSecurityGroupName</code>
        /// must be supplied.</para></li><li><para>If the source type is <code>DBParameterGroup</code>, a <code>DBParameterGroupName</code>
        /// must be supplied.</para></li><li><para>If the source type is <code>DBSnapshot</code>, a <code>DBSnapshotIdentifier</code>
        /// must be supplied.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceType
        /// <summary>
        /// <para>
        /// <para>The event source to retrieve events for. If no value is specified, all events are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.RDS.SourceType")]
        public Amazon.RDS.SourceType SourceType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para> The beginning of the time interval to retrieve events for, specified in ISO 8601
        /// format. For more information about ISO 8601, go to the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><para>Example: 2009-07-08T18:00Z</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para> An optional pagination token provided by a previous DescribeEvents request. If this
        /// parameter is specified, the response includes only records beyond the marker, up to
        /// the value specified by <code>MaxRecords</code>. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxRecord
        /// <summary>
        /// <para>
        /// <para> The maximum number of records to include in the response. If more records exist than
        /// the specified <code>MaxRecords</code> value, a pagination token called a marker is
        /// included in the response so that the remaining results can be retrieved. </para><para>Default: 100</para><para>Constraints: Minimum 20, maximum 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxRecords")]
        public int MaxRecord { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("Duration"))
                context.Duration = this.Duration;
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.EventCategory != null)
            {
                context.EventCategories = new List<System.String>(this.EventCategory);
            }
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.RDS.Model.Filter>(this.Filter);
            }
            context.Marker = this.Marker;
            if (ParameterWasBound("MaxRecord"))
                context.MaxRecords = this.MaxRecord;
            context.SourceIdentifier = this.SourceIdentifier;
            context.SourceType = this.SourceType;
            if (ParameterWasBound("StartTime"))
                context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.RDS.Model.DescribeEventsRequest();
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
            System.String _nextMarker = null;
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
                        
                        var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DescribeEventsResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DescribeEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DescribeEvents");
            try
            {
                #if DESKTOP
                return client.DescribeEvents(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeEventsAsync(request);
                return task.Result;
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
            public System.Int32? Duration { get; set; }
            public System.DateTime? EndTime { get; set; }
            public List<System.String> EventCategories { get; set; }
            public List<Amazon.RDS.Model.Filter> Filters { get; set; }
            public System.String Marker { get; set; }
            public int? MaxRecords { get; set; }
            public System.String SourceIdentifier { get; set; }
            public Amazon.RDS.SourceType SourceType { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
