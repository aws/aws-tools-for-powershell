/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns information about events that meet the specified filter criteria. Events are
    /// returned in a summary form and do not include the detailed description, any additional
    /// metadata that depends on the event type, or any affected resources. To retrieve that
    /// information, use the <a>DescribeEventDetails</a> and <a>DescribeAffectedEntities</a>
    /// operations.
    /// 
    ///  
    /// <para>
    /// If no filter criteria are specified, all events are returned. Results are sorted by
    /// <code>lastModifiedTime</code>, starting with the most recent.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "HLTHEvent")]
    [OutputType("Amazon.AWSHealth.Model.Event")]
    [AWSCmdlet("Calls the AWS Health DescribeEvents API operation.", Operation = new[] {"DescribeEvents"})]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.Event",
        "This cmdlet returns a collection of Event objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetHLTHEventCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
        #region Parameter Filter_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>A list of AWS availability zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_AvailabilityZones")]
        public System.String[] Filter_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Filter_EndTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event ended.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EndTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_EndTime { get; set; }
        #endregion
        
        #region Parameter Filter_EntityArn
        /// <summary>
        /// <para>
        /// <para>A list of entity ARNs (unique identifiers).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EntityArns")]
        public System.String[] Filter_EntityArn { get; set; }
        #endregion
        
        #region Parameter Filter_EntityValue
        /// <summary>
        /// <para>
        /// <para>A list of entity identifiers, such as EC2 instance IDs (<code>i-34ab692e</code>) or
        /// EBS volumes (<code>vol-426ab23e</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EntityValues")]
        public System.String[] Filter_EntityValue { get; set; }
        #endregion
        
        #region Parameter Filter_EventArn
        /// <summary>
        /// <para>
        /// <para>A list of event ARNs (unique identifiers). For example: <code>"arn:aws:health:us-east-1::event/AWS_EC2_MAINTENANCE_5331",
        /// "arn:aws:health:us-west-1::event/AWS_EBS_LOST_VOLUME_xyz"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EventArns")]
        public System.String[] Filter_EventArn { get; set; }
        #endregion
        
        #region Parameter Filter_EventStatusCode
        /// <summary>
        /// <para>
        /// <para>A list of event status codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EventStatusCodes")]
        public System.String[] Filter_EventStatusCode { get; set; }
        #endregion
        
        #region Parameter Filter_EventTypeCategory
        /// <summary>
        /// <para>
        /// <para>A list of event type category codes (<code>issue</code>, <code>scheduledChange</code>,
        /// or <code>accountNotification</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EventTypeCategories")]
        public System.String[] Filter_EventTypeCategory { get; set; }
        #endregion
        
        #region Parameter Filter_EventTypeCode
        /// <summary>
        /// <para>
        /// <para>A list of unique identifiers for event types. For example, <code>"AWS_EC2_SYSTEM_MAINTENANCE_EVENT","AWS_RDS_MAINTENANCE_SCHEDULED"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EventTypeCodes")]
        public System.String[] Filter_EventTypeCode { get; set; }
        #endregion
        
        #region Parameter Filter_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event was last updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_LastUpdatedTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_LastUpdatedTime { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale (language) to return information in. English (en) is the default and the
        /// only supported value at this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Locale { get; set; }
        #endregion
        
        #region Parameter Filter_Region
        /// <summary>
        /// <para>
        /// <para>A list of AWS regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_Regions")]
        public System.String[] Filter_Region { get; set; }
        #endregion
        
        #region Parameter Filter_Service
        /// <summary>
        /// <para>
        /// <para>The AWS services associated with the event. For example, <code>EC2</code>, <code>RDS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_Services")]
        public System.String[] Filter_Service { get; set; }
        #endregion
        
        #region Parameter Filter_StartTime
        /// <summary>
        /// <para>
        /// <para>A list of dates and times that the event began.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StartTimes")]
        public Amazon.AWSHealth.Model.DateTimeRange[] Filter_StartTime { get; set; }
        #endregion
        
        #region Parameter Filter_Tag
        /// <summary>
        /// <para>
        /// <para>A map of entity tags attached to the affected entity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_Tags")]
        public System.Collections.Hashtable[] Filter_Tag { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in one batch, between 10 and 100, inclusive.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the results of a search are large, only a portion of the results are returned,
        /// and a <code>nextToken</code> pagination token is returned in the response. To retrieve
        /// the next batch of results, reissue the search request and include the returned token.
        /// When all results have been returned, the response does not contain a pagination token
        /// value.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter_AvailabilityZone != null)
            {
                context.Filter_AvailabilityZones = new List<System.String>(this.Filter_AvailabilityZone);
            }
            if (this.Filter_EndTime != null)
            {
                context.Filter_EndTimes = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_EndTime);
            }
            if (this.Filter_EntityArn != null)
            {
                context.Filter_EntityArns = new List<System.String>(this.Filter_EntityArn);
            }
            if (this.Filter_EntityValue != null)
            {
                context.Filter_EntityValues = new List<System.String>(this.Filter_EntityValue);
            }
            if (this.Filter_EventArn != null)
            {
                context.Filter_EventArns = new List<System.String>(this.Filter_EventArn);
            }
            if (this.Filter_EventStatusCode != null)
            {
                context.Filter_EventStatusCodes = new List<System.String>(this.Filter_EventStatusCode);
            }
            if (this.Filter_EventTypeCategory != null)
            {
                context.Filter_EventTypeCategories = new List<System.String>(this.Filter_EventTypeCategory);
            }
            if (this.Filter_EventTypeCode != null)
            {
                context.Filter_EventTypeCodes = new List<System.String>(this.Filter_EventTypeCode);
            }
            if (this.Filter_LastUpdatedTime != null)
            {
                context.Filter_LastUpdatedTimes = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_LastUpdatedTime);
            }
            if (this.Filter_Region != null)
            {
                context.Filter_Regions = new List<System.String>(this.Filter_Region);
            }
            if (this.Filter_Service != null)
            {
                context.Filter_Services = new List<System.String>(this.Filter_Service);
            }
            if (this.Filter_StartTime != null)
            {
                context.Filter_StartTimes = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_StartTime);
            }
            if (this.Filter_Tag != null)
            {
                context.Filter_Tags = new List<Dictionary<System.String, System.String>>();
                foreach (var hashTable in this.Filter_Tag)
                {
                    var d = new Dictionary<System.String, System.String>();
                    foreach (var hashKey in hashTable.Keys)
                    {
                        d.Add((String)hashKey, (String)(hashTable[hashKey]));
                    }
                    context.Filter_Tags.Add(d);
                }
            }
            context.Locale = this.Locale;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.AWSHealth.Model.DescribeEventsRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventFilter();
            List<System.String> requestFilter_filter_AvailabilityZone = null;
            if (cmdletContext.Filter_AvailabilityZones != null)
            {
                requestFilter_filter_AvailabilityZone = cmdletContext.Filter_AvailabilityZones;
            }
            if (requestFilter_filter_AvailabilityZone != null)
            {
                request.Filter.AvailabilityZones = requestFilter_filter_AvailabilityZone;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_EndTime = null;
            if (cmdletContext.Filter_EndTimes != null)
            {
                requestFilter_filter_EndTime = cmdletContext.Filter_EndTimes;
            }
            if (requestFilter_filter_EndTime != null)
            {
                request.Filter.EndTimes = requestFilter_filter_EndTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityArn = null;
            if (cmdletContext.Filter_EntityArns != null)
            {
                requestFilter_filter_EntityArn = cmdletContext.Filter_EntityArns;
            }
            if (requestFilter_filter_EntityArn != null)
            {
                request.Filter.EntityArns = requestFilter_filter_EntityArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EntityValue = null;
            if (cmdletContext.Filter_EntityValues != null)
            {
                requestFilter_filter_EntityValue = cmdletContext.Filter_EntityValues;
            }
            if (requestFilter_filter_EntityValue != null)
            {
                request.Filter.EntityValues = requestFilter_filter_EntityValue;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventArn = null;
            if (cmdletContext.Filter_EventArns != null)
            {
                requestFilter_filter_EventArn = cmdletContext.Filter_EventArns;
            }
            if (requestFilter_filter_EventArn != null)
            {
                request.Filter.EventArns = requestFilter_filter_EventArn;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventStatusCode = null;
            if (cmdletContext.Filter_EventStatusCodes != null)
            {
                requestFilter_filter_EventStatusCode = cmdletContext.Filter_EventStatusCodes;
            }
            if (requestFilter_filter_EventStatusCode != null)
            {
                request.Filter.EventStatusCodes = requestFilter_filter_EventStatusCode;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCategory = null;
            if (cmdletContext.Filter_EventTypeCategories != null)
            {
                requestFilter_filter_EventTypeCategory = cmdletContext.Filter_EventTypeCategories;
            }
            if (requestFilter_filter_EventTypeCategory != null)
            {
                request.Filter.EventTypeCategories = requestFilter_filter_EventTypeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_EventTypeCode = null;
            if (cmdletContext.Filter_EventTypeCodes != null)
            {
                requestFilter_filter_EventTypeCode = cmdletContext.Filter_EventTypeCodes;
            }
            if (requestFilter_filter_EventTypeCode != null)
            {
                request.Filter.EventTypeCodes = requestFilter_filter_EventTypeCode;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_LastUpdatedTime = null;
            if (cmdletContext.Filter_LastUpdatedTimes != null)
            {
                requestFilter_filter_LastUpdatedTime = cmdletContext.Filter_LastUpdatedTimes;
            }
            if (requestFilter_filter_LastUpdatedTime != null)
            {
                request.Filter.LastUpdatedTimes = requestFilter_filter_LastUpdatedTime;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Region = null;
            if (cmdletContext.Filter_Regions != null)
            {
                requestFilter_filter_Region = cmdletContext.Filter_Regions;
            }
            if (requestFilter_filter_Region != null)
            {
                request.Filter.Regions = requestFilter_filter_Region;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_Service = null;
            if (cmdletContext.Filter_Services != null)
            {
                requestFilter_filter_Service = cmdletContext.Filter_Services;
            }
            if (requestFilter_filter_Service != null)
            {
                request.Filter.Services = requestFilter_filter_Service;
                requestFilterIsNull = false;
            }
            List<Amazon.AWSHealth.Model.DateTimeRange> requestFilter_filter_StartTime = null;
            if (cmdletContext.Filter_StartTimes != null)
            {
                requestFilter_filter_StartTime = cmdletContext.Filter_StartTimes;
            }
            if (requestFilter_filter_StartTime != null)
            {
                request.Filter.StartTimes = requestFilter_filter_StartTime;
                requestFilterIsNull = false;
            }
            List<Dictionary<System.String, System.String>> requestFilter_filter_Tag = null;
            if (cmdletContext.Filter_Tags != null)
            {
                requestFilter_filter_Tag = cmdletContext.Filter_Tags;
            }
            if (requestFilter_filter_Tag != null)
            {
                request.Filter.Tags = requestFilter_filter_Tag;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
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
                        
                        var response = CallAWSServiceOperation(client, request);
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
        
        private Amazon.AWSHealth.Model.DescribeEventsResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEvents");
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
            public List<System.String> Filter_AvailabilityZones { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_EndTimes { get; set; }
            public List<System.String> Filter_EntityArns { get; set; }
            public List<System.String> Filter_EntityValues { get; set; }
            public List<System.String> Filter_EventArns { get; set; }
            public List<System.String> Filter_EventStatusCodes { get; set; }
            public List<System.String> Filter_EventTypeCategories { get; set; }
            public List<System.String> Filter_EventTypeCodes { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_LastUpdatedTimes { get; set; }
            public List<System.String> Filter_Regions { get; set; }
            public List<System.String> Filter_Services { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_StartTimes { get; set; }
            public List<Dictionary<System.String, System.String>> Filter_Tags { get; set; }
            public System.String Locale { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
