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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the resource counts across accounts and regions that are present in your AWS
    /// Config aggregator. You can request the resource counts by providing filters and GroupByKey.
    /// 
    ///  
    /// <para>
    /// For example, if the input contains accountID 12345678910 and region us-east-1 in filters,
    /// the API returns the count of resources in account ID 12345678910 and region us-east-1.
    /// If the input contains ACCOUNT_ID as a GroupByKey, the API returns resource counts
    /// for all source accounts that are present in your aggregator.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFGAggregateDiscoveredResourceCount")]
    [OutputType("Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse")]
    [AWSCmdlet("Calls the AWS Config GetAggregateDiscoveredResourceCounts API operation.", Operation = new[] {"GetAggregateDiscoveredResourceCounts"})]
    [AWSCmdletOutput("Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse",
        "This cmdlet returns a Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateDiscoveredResourceCountCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit ID of the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter GroupByKey
        /// <summary>
        /// <para>
        /// <para>The key to group the resource counts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceCountGroupKey")]
        public Amazon.ConfigService.ResourceCountGroupKey GroupByKey { get; set; }
        #endregion
        
        #region Parameter Filters_Region
        /// <summary>
        /// <para>
        /// <para>The region where the account is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Filters_Region { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the AWS resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType Filters_ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of <a>GroupedResourceCount</a> objects returned on each page. The
        /// default is 1000. You cannot specify a number greater than 1000. If you specify 0,
        /// AWS Config uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response. </para>
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
            
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_Region = this.Filters_Region;
            context.Filters_ResourceType = this.Filters_ResourceType;
            context.GroupByKey = this.GroupByKey;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
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
            // create request
            var request = new Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate Filters
            bool requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ResourceCountFilters();
            System.String requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountId = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_Region = null;
            if (cmdletContext.Filters_Region != null)
            {
                requestFilters_filters_Region = cmdletContext.Filters_Region;
            }
            if (requestFilters_filters_Region != null)
            {
                request.Filters.Region = requestFilters_filters_Region;
                requestFiltersIsNull = false;
            }
            Amazon.ConfigService.ResourceType requestFilters_filters_ResourceType = null;
            if (cmdletContext.Filters_ResourceType != null)
            {
                requestFilters_filters_ResourceType = cmdletContext.Filters_ResourceType;
            }
            if (requestFilters_filters_ResourceType != null)
            {
                request.Filters.ResourceType = requestFilters_filters_ResourceType;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.GroupByKey != null)
            {
                request.GroupByKey = cmdletContext.GroupByKey;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetAggregateDiscoveredResourceCounts");
            try
            {
                #if DESKTOP
                return client.GetAggregateDiscoveredResourceCounts(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetAggregateDiscoveredResourceCountsAsync(request);
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
            public System.String ConfigurationAggregatorName { get; set; }
            public System.String Filters_AccountId { get; set; }
            public System.String Filters_Region { get; set; }
            public Amazon.ConfigService.ResourceType Filters_ResourceType { get; set; }
            public Amazon.ConfigService.ResourceCountGroupKey GroupByKey { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
        }
        
    }
}
