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
    /// Returns a list of entities that have been affected by the specified events, based
    /// on the specified filter criteria. Entities can refer to individual customer resources,
    /// groups of customer resources, or any other construct, depending on the AWS service.
    /// Events that have impact beyond that of the affected entities, or where the extent
    /// of impact is unknown, include at least one entity indicating this.
    /// 
    ///  
    /// <para>
    /// At least one event ARN is required. Results are sorted by the <code>lastUpdatedTime</code>
    /// of the entity, starting with the most recent.
    /// </para><br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "HLTHAffectedEntity")]
    [OutputType("Amazon.AWSHealth.Model.AffectedEntity")]
    [AWSCmdlet("Calls the AWS Health DescribeAffectedEntities API operation.", Operation = new[] {"DescribeAffectedEntities"})]
    [AWSCmdletOutput("Amazon.AWSHealth.Model.AffectedEntity",
        "This cmdlet returns a collection of AffectedEntity objects.",
        "The service call response (type Amazon.AWSHealth.Model.DescribeAffectedEntitiesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public partial class GetHLTHAffectedEntityCmdlet : AmazonAWSHealthClientCmdlet, IExecutor
    {
        
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
        /// <para>A list of IDs for affected entities.</para>
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
        
        #region Parameter Filter_LastUpdatedTime
        /// <summary>
        /// <para>
        /// <para>A list of the most recent dates and times that the entity was updated.</para>
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
        
        #region Parameter Filter_StatusCode
        /// <summary>
        /// <para>
        /// <para>A list of entity status codes (<code>IMPAIRED</code>, <code>UNIMPAIRED</code>, or
        /// <code>UNKNOWN</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filter_StatusCodes")]
        public System.String[] Filter_StatusCode { get; set; }
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
            if (this.Filter_LastUpdatedTime != null)
            {
                context.Filter_LastUpdatedTimes = new List<Amazon.AWSHealth.Model.DateTimeRange>(this.Filter_LastUpdatedTime);
            }
            if (this.Filter_StatusCode != null)
            {
                context.Filter_StatusCodes = new List<System.String>(this.Filter_StatusCode);
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
            var request = new Amazon.AWSHealth.Model.DescribeAffectedEntitiesRequest();
            
             // populate Filter
            bool requestFilterIsNull = true;
            request.Filter = new Amazon.AWSHealth.Model.EntityFilter();
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
            List<System.String> requestFilter_filter_StatusCode = null;
            if (cmdletContext.Filter_StatusCodes != null)
            {
                requestFilter_filter_StatusCode = cmdletContext.Filter_StatusCodes;
            }
            if (requestFilter_filter_StatusCode != null)
            {
                request.Filter.StatusCodes = requestFilter_filter_StatusCode;
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
                        object pipelineOutput = response.Entities;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.Entities.Count;
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
        
        private Amazon.AWSHealth.Model.DescribeAffectedEntitiesResponse CallAWSServiceOperation(IAmazonAWSHealth client, Amazon.AWSHealth.Model.DescribeAffectedEntitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Health", "DescribeAffectedEntities");
            try
            {
                #if DESKTOP
                return client.DescribeAffectedEntities(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeAffectedEntitiesAsync(request);
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
            public List<System.String> Filter_EntityArns { get; set; }
            public List<System.String> Filter_EntityValues { get; set; }
            public List<System.String> Filter_EventArns { get; set; }
            public List<Amazon.AWSHealth.Model.DateTimeRange> Filter_LastUpdatedTimes { get; set; }
            public List<System.String> Filter_StatusCodes { get; set; }
            public List<Dictionary<System.String, System.String>> Filter_Tags { get; set; }
            public System.String Locale { get; set; }
            public int? MaxResults { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
