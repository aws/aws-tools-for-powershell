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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Retrieves the reservation coverage for your account, which you can use to see how
    /// much of your Amazon Elastic Compute Cloud, Amazon ElastiCache, Amazon Relational Database
    /// Service, or Amazon Redshift usage is covered by a reservation. An organization's management
    /// account can see the coverage of the associated member accounts. This supports dimensions,
    /// Cost Categories, and nested expressions. For any time period, you can filter data
    /// about reservation usage by the following dimensions:
    /// 
    ///  <ul><li><para>
    /// AZ
    /// </para></li><li><para>
    /// CACHE_ENGINE
    /// </para></li><li><para>
    /// DATABASE_ENGINE
    /// </para></li><li><para>
    /// DEPLOYMENT_OPTION
    /// </para></li><li><para>
    /// INSTANCE_TYPE
    /// </para></li><li><para>
    /// LINKED_ACCOUNT
    /// </para></li><li><para>
    /// OPERATING_SYSTEM
    /// </para></li><li><para>
    /// PLATFORM
    /// </para></li><li><para>
    /// REGION
    /// </para></li><li><para>
    /// SERVICE
    /// </para></li><li><para>
    /// TAG
    /// </para></li><li><para>
    /// TENANCY
    /// </para></li></ul><para>
    /// To determine valid values for a dimension, use the <code>GetDimensionValues</code>
    /// operation. 
    /// </para><br/><br/>In the AWS.Tools.CostExplorer module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CEReservationCoverage")]
    [OutputType("Amazon.CostExplorer.Model.GetReservationCoverageResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetReservationCoverage API operation.", Operation = new[] {"GetReservationCoverage"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetReservationCoverageResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetReservationCoverageResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetReservationCoverageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEReservationCoverageCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters utilization data by dimensions. You can filter by the following dimensions:</para><ul><li><para>AZ</para></li><li><para>CACHE_ENGINE</para></li><li><para>DATABASE_ENGINE</para></li><li><para>DEPLOYMENT_OPTION</para></li><li><para>INSTANCE_TYPE</para></li><li><para>LINKED_ACCOUNT</para></li><li><para>OPERATING_SYSTEM</para></li><li><para>PLATFORM</para></li><li><para>REGION</para></li><li><para>SERVICE</para></li><li><para>TAG</para></li><li><para>TENANCY</para></li></ul><para><code>GetReservationCoverage</code> uses the same <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object as the other operations, but only <code>AND</code> is supported among each
        /// dimension. You can nest only one level deep. If there are multiple values for a dimension,
        /// they are OR'd together.</para><para>If you don't provide a <code>SERVICE</code> filter, Cost Explorer defaults to EC2.</para><para>Cost category is also supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The granularity of the Amazon Web Services cost data for the reservation. Valid values
        /// are <code>MONTHLY</code> and <code>DAILY</code>.</para><para>If <code>GroupBy</code> is set, <code>Granularity</code> can't be set. If <code>Granularity</code>
        /// isn't set, the response object doesn't include <code>Granularity</code>, either <code>MONTHLY</code>
        /// or <code>DAILY</code>.</para><para>The <code>GetReservationCoverage</code> operation supports only <code>DAILY</code>
        /// and <code>MONTHLY</code> granularities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>You can group the data by the following attributes:</para><ul><li><para>AZ</para></li><li><para>CACHE_ENGINE</para></li><li><para>DATABASE_ENGINE</para></li><li><para>DEPLOYMENT_OPTION</para></li><li><para>INSTANCE_TYPE</para></li><li><para>INVOICING_ENTITY</para></li><li><para>LINKED_ACCOUNT</para></li><li><para>OPERATING_SYSTEM</para></li><li><para>PLATFORM</para></li><li><para>REGION</para></li><li><para>TENANCY</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.GroupDefinition[] GroupBy { get; set; }
        #endregion
        
        #region Parameter SortBy_Key
        /// <summary>
        /// <para>
        /// <para>The key that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SortBy_Key { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>The measurement that you want your reservation coverage reported in.</para><para>Valid values are <code>Hour</code>, <code>Unit</code>, and <code>Cost</code>. You
        /// can use multiple values in a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter SortBy_SortOrder
        /// <summary>
        /// <para>
        /// <para>The order that's used to sort the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.SortOrder")]
        public Amazon.CostExplorer.SortOrder SortBy_SortOrder { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>The start and end dates of the period that you want to retrieve data about reservation
        /// coverage for. You can retrieve data for a maximum of 13 months: the last 12 months
        /// and the current month. The start date is inclusive, but the end date is exclusive.
        /// For example, if <code>start</code> is <code>2017-01-01</code> and <code>end</code>
        /// is <code>2017-05-01</code>, then the cost and usage data is retrieved from <code>2017-01-01</code>
        /// up to and including <code>2017-04-30</code> but not including <code>2017-05-01</code>.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of objects that you returned for this request. If more objects
        /// are available, in the response, Amazon Web Services provides a NextPageToken value
        /// that you can use in a subsequent call to get the next batch of objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CostExplorer module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextPageToken $null' for the first call and '-NextPageToken $AWSHistory.LastServiceResponse.NextPageToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetReservationCoverageResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetReservationCoverageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetReservationCoverageResponse, GetCEReservationCoverageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filter = this.Filter;
            context.Granularity = this.Granularity;
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<Amazon.CostExplorer.Model.GroupDefinition>(this.GroupBy);
            }
            context.MaxResult = this.MaxResult;
            if (this.Metric != null)
            {
                context.Metric = new List<System.String>(this.Metric);
            }
            context.NextPageToken = this.NextPageToken;
            context.SortBy_Key = this.SortBy_Key;
            context.SortBy_SortOrder = this.SortBy_SortOrder;
            context.TimePeriod = this.TimePeriod;
            #if MODULAR
            if (this.TimePeriod == null && ParameterWasBound(nameof(this.TimePeriod)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CostExplorer.Model.GetReservationCoverageRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.CostExplorer.Model.SortDefinition();
            System.String requestSortBy_sortBy_Key = null;
            if (cmdletContext.SortBy_Key != null)
            {
                requestSortBy_sortBy_Key = cmdletContext.SortBy_Key;
            }
            if (requestSortBy_sortBy_Key != null)
            {
                request.SortBy.Key = requestSortBy_sortBy_Key;
                requestSortByIsNull = false;
            }
            Amazon.CostExplorer.SortOrder requestSortBy_sortBy_SortOrder = null;
            if (cmdletContext.SortBy_SortOrder != null)
            {
                requestSortBy_sortBy_SortOrder = cmdletContext.SortBy_SortOrder;
            }
            if (requestSortBy_sortBy_SortOrder != null)
            {
                request.SortBy.SortOrder = requestSortBy_sortBy_SortOrder;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
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
                    
                    _nextToken = response.NextPageToken;
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
            var request = new Amazon.CostExplorer.Model.GetReservationCoverageRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
            }
            
             // populate SortBy
            var requestSortByIsNull = true;
            request.SortBy = new Amazon.CostExplorer.Model.SortDefinition();
            System.String requestSortBy_sortBy_Key = null;
            if (cmdletContext.SortBy_Key != null)
            {
                requestSortBy_sortBy_Key = cmdletContext.SortBy_Key;
            }
            if (requestSortBy_sortBy_Key != null)
            {
                request.SortBy.Key = requestSortBy_sortBy_Key;
                requestSortByIsNull = false;
            }
            Amazon.CostExplorer.SortOrder requestSortBy_sortBy_SortOrder = null;
            if (cmdletContext.SortBy_SortOrder != null)
            {
                requestSortBy_sortBy_SortOrder = cmdletContext.SortBy_SortOrder;
            }
            if (requestSortBy_sortBy_SortOrder != null)
            {
                request.SortBy.SortOrder = requestSortBy_sortBy_SortOrder;
                requestSortByIsNull = false;
            }
             // determine if request.SortBy should be set to null
            if (requestSortByIsNull)
            {
                request.SortBy = null;
            }
            if (cmdletContext.TimePeriod != null)
            {
                request.TimePeriod = cmdletContext.TimePeriod;
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
        
        private Amazon.CostExplorer.Model.GetReservationCoverageResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetReservationCoverageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetReservationCoverage");
            try
            {
                #if DESKTOP
                return client.GetReservationCoverage(request);
                #elif CORECLR
                return client.GetReservationCoverageAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.Granularity Granularity { get; set; }
            public List<Amazon.CostExplorer.Model.GroupDefinition> GroupBy { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> Metric { get; set; }
            public System.String NextPageToken { get; set; }
            public System.String SortBy_Key { get; set; }
            public Amazon.CostExplorer.SortOrder SortBy_SortOrder { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetReservationCoverageResponse, GetCEReservationCoverageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
