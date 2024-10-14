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
    /// Retrieves cost and usage metrics with resources for your account. You can specify
    /// which cost and usage-related metric, such as <c>BlendedCosts</c> or <c>UsageQuantity</c>,
    /// that you want the request to return. You can also filter and group your data by various
    /// dimensions, such as <c>SERVICE</c> or <c>AZ</c>, in a specific time range. For a complete
    /// list of valid dimensions, see the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_GetDimensionValues.html">GetDimensionValues</a>
    /// operation. Management account in an organization in Organizations have access to all
    /// member accounts.
    /// 
    ///  
    /// <para>
    /// Hourly granularity is only available for EC2-Instances (Elastic Compute Cloud) resource-level
    /// data. All other resource-level data is available at daily granularity.
    /// </para><note><para>
    /// This is an opt-in only feature. You can enable this feature from the Cost Explorer
    /// Settings page. For information about how to access the Settings page, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/ce-access.html">Controlling
    /// Access for Cost Explorer</a> in the <i>Billing and Cost Management User Guide</i>.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CECostAndUsageWithResource")]
    [OutputType("Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetCostAndUsageWithResources API operation.", Operation = new[] {"GetCostAndUsageWithResources"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse object containing multiple properties."
    )]
    public partial class GetCECostAndUsageWithResourceCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters Amazon Web Services costs by different dimensions. For example, you can specify
        /// <c>SERVICE</c> and <c>LINKED_ACCOUNT</c> and get the costs that are associated with
        /// that account's usage of that service. You can nest <c>Expression</c> objects to define
        /// any combination of dimension filters. For more information, see <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>.
        /// </para><para>The <c>GetCostAndUsageWithResources</c> operation requires that you either group by
        /// or filter by a <c>ResourceId</c>. It requires the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a><c>"SERVICE = Amazon Elastic Compute Cloud - Compute"</c> in the filter.</para><para>Valid values for <c>MatchOptions</c> for <c>Dimensions</c> are <c>EQUALS</c> and <c>CASE_SENSITIVE</c>.</para><para>Valid values for <c>MatchOptions</c> for <c>CostCategories</c> and <c>Tags</c> are
        /// <c>EQUALS</c>, <c>ABSENT</c>, and <c>CASE_SENSITIVE</c>. Default values are <c>EQUALS</c>
        /// and <c>CASE_SENSITIVE</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>Sets the Amazon Web Services cost granularity to <c>MONTHLY</c>, <c>DAILY</c>, or
        /// <c>HOURLY</c>. If <c>Granularity</c> isn't set, the response object doesn't include
        /// the <c>Granularity</c>, <c>MONTHLY</c>, <c>DAILY</c>, or <c>HOURLY</c>. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.Granularity")]
        public Amazon.CostExplorer.Granularity Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>You can group Amazon Web Services costs using up to two different groups: <c>DIMENSION</c>,
        /// <c>TAG</c>, <c>COST_CATEGORY</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.GroupDefinition[] GroupBy { get; set; }
        #endregion
        
        #region Parameter Metric
        /// <summary>
        /// <para>
        /// <para>Which metrics are returned in the query. For more information about blended and unblended
        /// rates, see <a href="http://aws.amazon.com/premiumsupport/knowledge-center/blended-rates-intro/">Why
        /// does the "blended" annotation appear on some line items in my bill?</a>. </para><para>Valid values are <c>AmortizedCost</c>, <c>BlendedCost</c>, <c>NetAmortizedCost</c>,
        /// <c>NetUnblendedCost</c>, <c>NormalizedUsageAmount</c>, <c>UnblendedCost</c>, and <c>UsageQuantity</c>.
        /// </para><note><para>If you return the <c>UsageQuantity</c> metric, the service aggregates all usage numbers
        /// without taking the units into account. For example, if you aggregate <c>usageQuantity</c>
        /// across all of Amazon EC2, the results aren't meaningful because Amazon EC2 compute
        /// hours and data transfer are measured in different units (for example, hour or GB).
        /// To get more meaningful <c>UsageQuantity</c> metrics, filter by <c>UsageType</c> or
        /// <c>UsageTypeGroups</c>. </para></note><para><c>Metrics</c> is required for <c>GetCostAndUsageWithResources</c> requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Metrics")]
        public System.String[] Metric { get; set; }
        #endregion
        
        #region Parameter TimePeriod
        /// <summary>
        /// <para>
        /// <para>Sets the start and end dates for retrieving Amazon Web Services costs. The range must
        /// be within the last 14 days (the start date cannot be earlier than 14 days ago). The
        /// start date is inclusive, but the end date is exclusive. For example, if <c>start</c>
        /// is <c>2017-01-01</c> and <c>end</c> is <c>2017-05-01</c>, then the cost and usage
        /// data is retrieved from <c>2017-01-01</c> up to and including <c>2017-04-30</c> but
        /// not including <c>2017-05-01</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next set of results. Amazon Web Services provides the token
        /// when the response from a previous call has more results than the maximum page size.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextPageToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextPageToken' to null for the first call then set the 'NextPageToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TimePeriod parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TimePeriod' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse, GetCECostAndUsageWithResourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TimePeriod;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filter = this.Filter;
            #if MODULAR
            if (this.Filter == null && ParameterWasBound(nameof(this.Filter)))
            {
                WriteWarning("You are passing $null as a value for parameter Filter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Granularity = this.Granularity;
            #if MODULAR
            if (this.Granularity == null && ParameterWasBound(nameof(this.Granularity)))
            {
                WriteWarning("You are passing $null as a value for parameter Granularity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<Amazon.CostExplorer.Model.GroupDefinition>(this.GroupBy);
            }
            if (this.Metric != null)
            {
                context.Metric = new List<System.String>(this.Metric);
            }
            context.NextPageToken = this.NextPageToken;
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
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesRequest();
            
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
            if (cmdletContext.Metric != null)
            {
                request.Metrics = cmdletContext.Metric;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetCostAndUsageWithResources");
            try
            {
                #if DESKTOP
                return client.GetCostAndUsageWithResources(request);
                #elif CORECLR
                return client.GetCostAndUsageWithResourcesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Metric { get; set; }
            public System.String NextPageToken { get; set; }
            public Amazon.CostExplorer.Model.DateInterval TimePeriod { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetCostAndUsageWithResourcesResponse, GetCECostAndUsageWithResourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
