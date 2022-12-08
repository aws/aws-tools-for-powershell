/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Returns the resource counts across accounts and regions that are present in your Config
    /// aggregator. You can request the resource counts by providing filters and GroupByKey.
    /// 
    ///  
    /// <para>
    /// For example, if the input contains accountID 12345678910 and region us-east-1 in filters,
    /// the API returns the count of resources in account ID 12345678910 and region us-east-1.
    /// If the input contains ACCOUNT_ID as a GroupByKey, the API returns resource counts
    /// for all source accounts that are present in your aggregator.
    /// </para><br/><br/>In the AWS.Tools.ConfigService module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGAggregateDiscoveredResourceCount")]
    [OutputType("Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse")]
    [AWSCmdlet("Calls the AWS Config GetAggregateDiscoveredResourceCounts API operation.", Operation = new[] {"GetAggregateDiscoveredResourceCounts"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGAggregateDiscoveredResourceCountCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit ID of the account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter GroupByKey
        /// <summary>
        /// <para>
        /// <para>The key to group the resource counts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceCountGroupKey")]
        public Amazon.ConfigService.ResourceCountGroupKey GroupByKey { get; set; }
        #endregion
        
        #region Parameter Filters_Region
        /// <summary>
        /// <para>
        /// <para>The region where the account is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_Region { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of the Amazon Web Services resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.ResourceType")]
        public Amazon.ConfigService.ResourceType Filters_ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of <a>GroupedResourceCount</a> objects returned on each page. The
        /// default is 1000. You cannot specify a number greater than 1000. If you specify 0,
        /// Config uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.ConfigService module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse, GetCFGAggregateDiscoveredResourceCountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_Region = this.Filters_Region;
            context.Filters_ResourceType = this.Filters_ResourceType;
            context.GroupByKey = this.GroupByKey;
            context.Limit = this.Limit;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
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
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
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
            var requestFiltersIsNull = true;
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        #endif
        
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
                return client.GetAggregateDiscoveredResourceCountsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ConfigService.Model.GetAggregateDiscoveredResourceCountsResponse, GetCFGAggregateDiscoveredResourceCountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
