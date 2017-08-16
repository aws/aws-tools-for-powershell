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
using Amazon.AWSHealth;
using Amazon.AWSHealth.Model;

namespace Amazon.PowerShell.Cmdlets.HLTH
{
    /// <summary>
    /// Returns the event types that meet the specified filter criteria. If no filter criteria
    /// are specified, all event types are returned, in no particular order.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "HLTHEventType")]
    [OutputType("Amazon.AWSHealth.Model.EventType")]
    [AWSCmdlet("Invokes the DescribeEventTypes operation against AWS Health.", Operation = new[] {"DescribeEventTypes"})]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.EventType",
        "This cmdlet returns a collection of EventType objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeEventTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetHLTHEventTypeCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
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
        /// <para>A list of event type codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_EventTypeCodes")]
        public System.String[] Filter_EventTypeCode { get; set; }
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in one batch, between 10 and 100, inclusive.</para>
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
            
            if (this.Filter_EventTypeCategory != null)
            {
                context.Filter_EventTypeCategories = new List<System.String>(this.Filter_EventTypeCategory);
            }
            if (this.Filter_EventTypeCode != null)
            {
                context.Filter_EventTypeCodes = new List<System.String>(this.Filter_EventTypeCode);
            }
            if (this.Filter_Service != null)
            {
                context.Filter_Services = new List<System.String>(this.Filter_Service);
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
            var request = new Amazon.AWSHealth.Model.DescribeEventTypesRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EventTypeFilter();
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
                        object pipelineOutput = response.EventTypes;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.EventTypes.Count;
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
        
        private Amazon.AWSHealth.Model.DescribeEventTypesResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeEventTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeEventTypes");
            try
            {
                #if DESKTOP
                return client.DescribeEventTypes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeEventTypesAsync(request);
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
            public List<System.String> Filter_EventTypeCategories { get; set; }
            public List<System.String> Filter_EventTypeCodes { get; set; }
            public List<System.String> Filter_Services { get; set; }
            public System.String Locale { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
