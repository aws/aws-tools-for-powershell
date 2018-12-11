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
using Amazon.PI;
using Amazon.PI.Model;

namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// For a specific time period, retrieve the top <code>N</code> dimension keys for a metric.
    /// </summary>
    [Cmdlet("Get", "PIDimensionKey")]
    [OutputType("Amazon.PI.Model.DescribeDimensionKeysResponse")]
    [AWSCmdlet("Calls the AWS Performance Insights DescribeDimensionKeys API operation.", Operation = new[] {"DescribeDimensionKeys"})]
    [AWSCmdletOutput("Amazon.PI.Model.DescribeDimensionKeysResponse",
        "This cmdlet returns a Amazon.PI.Model.DescribeDimensionKeysResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetPIDimensionKeyCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        #region Parameter GroupBy_Dimension
        /// <summary>
        /// <para>
        /// <para>A list of specific dimensions from a dimension group. If this parameter is not present,
        /// then it signifies that all of the dimensions in the group were requested, or are present
        /// in the response.</para><para>Valid values for elements in the <code>Dimensions</code> array are:</para><ul><li><para>db.user.id</para></li><li><para>db.user.name</para></li><li><para>db.host.id</para></li><li><para>db.host.name</para></li><li><para>db.sql.id</para></li><li><para>db.sql.db_id</para></li><li><para>db.sql.statement</para></li><li><para>db.sql.tokenized_id</para></li><li><para>db.sql_tokenized.id</para></li><li><para>db.sql_tokenized.db_id</para></li><li><para>db.sql_tokenized.statement</para></li><li><para>db.wait_event.name</para></li><li><para>db.wait_event.type</para></li><li><para>db.wait_event_type.name</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GroupBy_Dimensions")]
        public System.String[] GroupBy_Dimension { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Dimension
        /// <summary>
        /// <para>
        /// <para>A list of specific dimensions from a dimension group. If this parameter is not present,
        /// then it signifies that all of the dimensions in the group were requested, or are present
        /// in the response.</para><para>Valid values for elements in the <code>Dimensions</code> array are:</para><ul><li><para>db.user.id</para></li><li><para>db.user.name</para></li><li><para>db.host.id</para></li><li><para>db.host.name</para></li><li><para>db.sql.id</para></li><li><para>db.sql.db_id</para></li><li><para>db.sql.statement</para></li><li><para>db.sql.tokenized_id</para></li><li><para>db.sql_tokenized.id</para></li><li><para>db.sql_tokenized.db_id</para></li><li><para>db.sql_tokenized.statement</para></li><li><para>db.wait_event.name</para></li><li><para>db.wait_event.type</para></li><li><para>db.wait_event_type.name</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PartitionBy_Dimensions")]
        public System.String[] PartitionBy_Dimension { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifying the end of the requested time series data. The value
        /// specified is <i>exclusive</i> - data points less than (but not equal to) <code>EndTime</code>
        /// will be returned.</para><para>The value for <code>EndTime</code> must be later than the value for <code>StartTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndTime { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters to apply in the request. Restrictions:</para><ul><li><para>Any number of filters by the same dimension, as specified in the <code>GroupBy</code>
        /// or <code>Partition</code> parameters.</para></li><li><para>A single filter for any other dimension in this dimension group.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable Filter { get; set; }
        #endregion
        
        #region Parameter GroupBy_Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. Valid values are:</para><ul><li><para><code>db.user</code></para></li><li><para><code>db.host</code></para></li><li><para><code>db.sql</code></para></li><li><para><code>db.sql_tokenized</code></para></li><li><para><code>db.wait_event</code></para></li><li><para><code>db.wait_event_type</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GroupBy_Group { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Group
        /// <summary>
        /// <para>
        /// <para>The name of the dimension group. Valid values are:</para><ul><li><para><code>db.user</code></para></li><li><para><code>db.host</code></para></li><li><para><code>db.sql</code></para></li><li><para><code>db.sql_tokenized</code></para></li><li><para><code>db.wait_event</code></para></li><li><para><code>db.wait_event_type</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PartitionBy_Group { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An immutable, AWS Region-unique identifier for a data source. Performance Insights
        /// gathers metrics from this data source.</para><para>To use an Amazon RDS instance as a data source, you specify its <code>DbiResourceId</code>
        /// value - for example: <code>db-FAIHNTYBKTGAUSUZQYPDS2GW4A</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The name of a Performance Insights metric to be measured.</para><para>Valid values for <code>Metric</code> are:</para><ul><li><para><code>db.load.avg</code> - a scaled representation of the number of active sessions
        /// for the database engine.</para></li><li><para><code>db.sampledload.avg</code> - the raw number of active sessions for the database
        /// engine.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Metric { get; set; }
        #endregion
        
        #region Parameter PeriodInSecond
        /// <summary>
        /// <para>
        /// <para>The granularity, in seconds, of the data points returned from Performance Insights.
        /// A period can be as short as one second, or as long as one day (86400 seconds). Valid
        /// values are:</para><ul><li><para><code>1</code> (one second)</para></li><li><para><code>60</code> (one minute)</para></li><li><para><code>300</code> (five minutes)</para></li><li><para><code>3600</code> (one hour)</para></li><li><para><code>86400</code> (twenty-four hours)</para></li></ul><para>If you don't specify <code>PeriodInSeconds</code>, then Performance Insights will
        /// choose a value for you, with a goal of returning roughly 100-200 data points in the
        /// response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("PeriodInSeconds")]
        public System.Int32 PeriodInSecond { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The AWS service for which Performance Insights will return metrics. The only valid
        /// value for <i>ServiceType</i> is: <code>RDS</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The date and time specifying the beginning of the requested time series data. You
        /// can't specify a <code>StartTime</code> that's earlier than 7 days ago. The value specified
        /// is <i>inclusive</i> - data points equal to or greater than <code>StartTime</code>
        /// will be returned.</para><para>The value for <code>StartTime</code> must be earlier than the value for <code>EndTime</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime StartTime { get; set; }
        #endregion
        
        #region Parameter GroupBy_Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to fetch for this dimension group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 GroupBy_Limit { get; set; }
        #endregion
        
        #region Parameter PartitionBy_Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to fetch for this dimension group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PartitionBy_Limit { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return in the response. If more items exist than the
        /// specified <code>MaxRecords</code> value, a pagination token is included in the response
        /// so that the remaining results can be retrieved. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxResults")]
        public System.Int32 MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the token, up to the value specified
        /// by <code>MaxRecords</code>.</para>
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
            
            if (ParameterWasBound("EndTime"))
                context.EndTime = this.EndTime;
            if (this.Filter != null)
            {
                context.Filter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Filter.Keys)
                {
                    context.Filter.Add((String)hashKey, (String)(this.Filter[hashKey]));
                }
            }
            if (this.GroupBy_Dimension != null)
            {
                context.GroupBy_Dimensions = new List<System.String>(this.GroupBy_Dimension);
            }
            context.GroupBy_Group = this.GroupBy_Group;
            if (ParameterWasBound("GroupBy_Limit"))
                context.GroupBy_Limit = this.GroupBy_Limit;
            context.Identifier = this.Identifier;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            context.Metric = this.Metric;
            context.NextToken = this.NextToken;
            if (this.PartitionBy_Dimension != null)
            {
                context.PartitionBy_Dimensions = new List<System.String>(this.PartitionBy_Dimension);
            }
            context.PartitionBy_Group = this.PartitionBy_Group;
            if (ParameterWasBound("PartitionBy_Limit"))
                context.PartitionBy_Limit = this.PartitionBy_Limit;
            if (ParameterWasBound("PeriodInSecond"))
                context.PeriodInSeconds = this.PeriodInSecond;
            context.ServiceType = this.ServiceType;
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
            // create request
            var request = new Amazon.PI.Model.DescribeDimensionKeysRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            
             // populate GroupBy
            bool requestGroupByIsNull = true;
            request.GroupBy = new Amazon.PI.Model.DimensionGroup();
            List<System.String> requestGroupBy_groupBy_Dimension = null;
            if (cmdletContext.GroupBy_Dimensions != null)
            {
                requestGroupBy_groupBy_Dimension = cmdletContext.GroupBy_Dimensions;
            }
            if (requestGroupBy_groupBy_Dimension != null)
            {
                request.GroupBy.Dimensions = requestGroupBy_groupBy_Dimension;
                requestGroupByIsNull = false;
            }
            System.String requestGroupBy_groupBy_Group = null;
            if (cmdletContext.GroupBy_Group != null)
            {
                requestGroupBy_groupBy_Group = cmdletContext.GroupBy_Group;
            }
            if (requestGroupBy_groupBy_Group != null)
            {
                request.GroupBy.Group = requestGroupBy_groupBy_Group;
                requestGroupByIsNull = false;
            }
            System.Int32? requestGroupBy_groupBy_Limit = null;
            if (cmdletContext.GroupBy_Limit != null)
            {
                requestGroupBy_groupBy_Limit = cmdletContext.GroupBy_Limit.Value;
            }
            if (requestGroupBy_groupBy_Limit != null)
            {
                request.GroupBy.Limit = requestGroupBy_groupBy_Limit.Value;
                requestGroupByIsNull = false;
            }
             // determine if request.GroupBy should be set to null
            if (requestGroupByIsNull)
            {
                request.GroupBy = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MaxResults != null)
            {
                request.MaxResults = cmdletContext.MaxResults.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metric = cmdletContext.Metric;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate PartitionBy
            bool requestPartitionByIsNull = true;
            request.PartitionBy = new Amazon.PI.Model.DimensionGroup();
            List<System.String> requestPartitionBy_partitionBy_Dimension = null;
            if (cmdletContext.PartitionBy_Dimensions != null)
            {
                requestPartitionBy_partitionBy_Dimension = cmdletContext.PartitionBy_Dimensions;
            }
            if (requestPartitionBy_partitionBy_Dimension != null)
            {
                request.PartitionBy.Dimensions = requestPartitionBy_partitionBy_Dimension;
                requestPartitionByIsNull = false;
            }
            System.String requestPartitionBy_partitionBy_Group = null;
            if (cmdletContext.PartitionBy_Group != null)
            {
                requestPartitionBy_partitionBy_Group = cmdletContext.PartitionBy_Group;
            }
            if (requestPartitionBy_partitionBy_Group != null)
            {
                request.PartitionBy.Group = requestPartitionBy_partitionBy_Group;
                requestPartitionByIsNull = false;
            }
            System.Int32? requestPartitionBy_partitionBy_Limit = null;
            if (cmdletContext.PartitionBy_Limit != null)
            {
                requestPartitionBy_partitionBy_Limit = cmdletContext.PartitionBy_Limit.Value;
            }
            if (requestPartitionBy_partitionBy_Limit != null)
            {
                request.PartitionBy.Limit = requestPartitionBy_partitionBy_Limit.Value;
                requestPartitionByIsNull = false;
            }
             // determine if request.PartitionBy should be set to null
            if (requestPartitionByIsNull)
            {
                request.PartitionBy = null;
            }
            if (cmdletContext.PeriodInSeconds != null)
            {
                request.PeriodInSeconds = cmdletContext.PeriodInSeconds.Value;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.PI.Model.DescribeDimensionKeysResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.DescribeDimensionKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "DescribeDimensionKeys");
            try
            {
                #if DESKTOP
                return client.DescribeDimensionKeys(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeDimensionKeysAsync(request);
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
            public System.DateTime? EndTime { get; set; }
            public Dictionary<System.String, System.String> Filter { get; set; }
            public List<System.String> GroupBy_Dimensions { get; set; }
            public System.String GroupBy_Group { get; set; }
            public System.Int32? GroupBy_Limit { get; set; }
            public System.String Identifier { get; set; }
            public System.Int32? MaxResults { get; set; }
            public System.String Metric { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> PartitionBy_Dimensions { get; set; }
            public System.String PartitionBy_Group { get; set; }
            public System.Int32? PartitionBy_Limit { get; set; }
            public System.Int32? PeriodInSeconds { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.DateTime? StartTime { get; set; }
        }
        
    }
}
