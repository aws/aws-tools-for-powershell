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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// List the specified metrics. You can use the returned metrics with <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricData.html">GetMetricData</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricStatistics.html">GetMetricStatistics</a>
    /// to get statistical data.
    /// 
    ///  
    /// <para>
    /// Up to 500 results are returned for any one call. To retrieve additional results, use
    /// the returned token with subsequent calls.
    /// </para><para>
    /// After you create a metric, allow up to 15 minutes for the metric to appear. To see
    /// metric statistics sooner, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricData.html">GetMetricData</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricStatistics.html">GetMetricStatistics</a>.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability, you can use this operation
    /// in a monitoring account and view metrics from the linked source accounts. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// </para><para><code>ListMetrics</code> doesn't return information about metrics if those metrics
    /// haven't reported data in the past two weeks. To retrieve those metrics, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricData.html">GetMetricData</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_GetMetricStatistics.html">GetMetricStatistics</a>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWMetricList")]
    [OutputType("Amazon.CloudWatch.Model.Metric")]
    [AWSCmdlet("Calls the Amazon CloudWatch ListMetrics API operation.", Operation = new[] {"ListMetrics"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.ListMetricsResponse), LegacyAlias="Get-CWMetrics")]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.Metric or Amazon.CloudWatch.Model.ListMetricsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatch.Model.Metric objects.",
        "The service call response (type Amazon.CloudWatch.Model.ListMetricsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCWMetricListCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions to filter against. Only the dimensions that match exactly will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("Dimensions")]
        public Amazon.CloudWatch.Model.DimensionFilter[] Dimension { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccount
        /// <summary>
        /// <para>
        /// <para>If you are using this operation in a monitoring account, specify <code>true</code>
        /// to include metrics from source accounts in the returned data.</para><para>The default is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccounts")]
        public System.Boolean? IncludeLinkedAccount { get; set; }
        #endregion
        
        #region Parameter MetricName
        /// <summary>
        /// <para>
        /// <para>The name of the metric to filter against. Only the metrics with names that match exactly
        /// will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String MetricName { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The metric namespace to filter against. Only the namespace that matches exactly will
        /// be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter OwningAccount
        /// <summary>
        /// <para>
        /// <para>When you use this operation in a monitoring account, use this field to return metrics
        /// only from one source account. To do so, specify that source account ID in this field,
        /// and also specify <code>true</code> for <code>IncludeLinkedAccounts</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwningAccount { get; set; }
        #endregion
        
        #region Parameter RecentlyActive
        /// <summary>
        /// <para>
        /// <para>To filter the results to show only metrics that have had data points published in
        /// the past three hours, specify this parameter with a value of <code>PT3H</code>. This
        /// is the only valid value for this parameter.</para><para>The results that are returned are an approximation of the value you specify. There
        /// is a low probability that the returned results include metrics with last published
        /// data as much as 40 minutes more than the specified time interval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatch.RecentlyActive")]
        public Amazon.CloudWatch.RecentlyActive RecentlyActive { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token returned by a previous call to indicate that there is more data available.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Metrics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.ListMetricsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.ListMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Metrics";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Namespace parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Namespace' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Namespace' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.ListMetricsResponse, GetCWMetricListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Namespace;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Dimension != null)
            {
                context.Dimension = new List<Amazon.CloudWatch.Model.DimensionFilter>(this.Dimension);
            }
            context.IncludeLinkedAccount = this.IncludeLinkedAccount;
            context.MetricName = this.MetricName;
            context.Namespace = this.Namespace;
            context.NextToken = this.NextToken;
            context.OwningAccount = this.OwningAccount;
            context.RecentlyActive = this.RecentlyActive;
            
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
            var request = new Amazon.CloudWatch.Model.ListMetricsRequest();
            
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.IncludeLinkedAccount != null)
            {
                request.IncludeLinkedAccounts = cmdletContext.IncludeLinkedAccount.Value;
            }
            if (cmdletContext.MetricName != null)
            {
                request.MetricName = cmdletContext.MetricName;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.OwningAccount != null)
            {
                request.OwningAccount = cmdletContext.OwningAccount;
            }
            if (cmdletContext.RecentlyActive != null)
            {
                request.RecentlyActive = cmdletContext.RecentlyActive;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CloudWatch.Model.ListMetricsResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.ListMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "ListMetrics");
            try
            {
                #if DESKTOP
                return client.ListMetrics(request);
                #elif CORECLR
                return client.ListMetricsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatch.Model.DimensionFilter> Dimension { get; set; }
            public System.Boolean? IncludeLinkedAccount { get; set; }
            public System.String MetricName { get; set; }
            public System.String Namespace { get; set; }
            public System.String NextToken { get; set; }
            public System.String OwningAccount { get; set; }
            public Amazon.CloudWatch.RecentlyActive RecentlyActive { get; set; }
            public System.Func<Amazon.CloudWatch.Model.ListMetricsResponse, GetCWMetricListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Metrics;
        }
        
    }
}
