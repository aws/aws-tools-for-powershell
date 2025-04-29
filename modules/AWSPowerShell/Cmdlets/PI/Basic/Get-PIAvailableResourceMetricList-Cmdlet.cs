/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.PI;
using Amazon.PI.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PI
{
    /// <summary>
    /// Retrieve metrics of the specified types that can be queried for a specified DB instance.
    /// </summary>
    [Cmdlet("Get", "PIAvailableResourceMetricList")]
    [OutputType("Amazon.PI.Model.ResponseResourceMetric")]
    [AWSCmdlet("Calls the AWS Performance Insights ListAvailableResourceMetrics API operation.", Operation = new[] {"ListAvailableResourceMetrics"}, SelectReturnType = typeof(Amazon.PI.Model.ListAvailableResourceMetricsResponse))]
    [AWSCmdletOutput("Amazon.PI.Model.ResponseResourceMetric or Amazon.PI.Model.ListAvailableResourceMetricsResponse",
        "This cmdlet returns a collection of Amazon.PI.Model.ResponseResourceMetric objects.",
        "The service call response (type Amazon.PI.Model.ListAvailableResourceMetricsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPIAvailableResourceMetricListCmdlet : AmazonPIClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>An immutable identifier for a data source that is unique within an Amazon Web Services
        /// Region. Performance Insights gathers metrics from this data source. To use an Amazon
        /// RDS DB instance as a data source, specify its <c>DbiResourceId</c> value. For example,
        /// specify <c>db-ABCDEFGHIJKLMNOPQRSTU1VWZ</c>. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter MetricType
        /// <summary>
        /// <para>
        /// <para>The types of metrics to return in the response. Valid values in the array include
        /// the following:</para><ul><li><para><c>os</c> (OS counter metrics) - All engines</para></li><li><para><c>db</c> (DB load metrics) - All engines except for Amazon DocumentDB</para></li><li><para><c>db.sql.stats</c> (per-SQL metrics) - All engines except for Amazon DocumentDB</para></li><li><para><c>db.sql_tokenized.stats</c> (per-SQL digest metrics) - All engines except for Amazon
        /// DocumentDB</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("MetricTypes")]
        public System.String[] MetricType { get; set; }
        #endregion
        
        #region Parameter ServiceType
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service for which Performance Insights returns metrics.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PI.ServiceType")]
        public Amazon.PI.ServiceType ServiceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return. If the <c>MaxRecords</c> value is less than
        /// the number of existing items, the response includes a pagination token. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>An optional pagination token provided by a previous request. If this parameter is
        /// specified, the response includes only records beyond the token, up to the value specified
        /// by <c>MaxRecords</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Metrics'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PI.Model.ListAvailableResourceMetricsResponse).
        /// Specifying the name of a property of type Amazon.PI.Model.ListAvailableResourceMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Metrics";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PI.Model.ListAvailableResourceMetricsResponse, GetPIAvailableResourceMetricListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            if (this.MetricType != null)
            {
                context.MetricType = new List<System.String>(this.MetricType);
            }
            #if MODULAR
            if (this.MetricType == null && ParameterWasBound(nameof(this.MetricType)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.ServiceType = this.ServiceType;
            #if MODULAR
            if (this.ServiceType == null && ParameterWasBound(nameof(this.ServiceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.PI.Model.ListAvailableResourceMetricsRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MetricType != null)
            {
                request.MetricTypes = cmdletContext.MetricType;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServiceType != null)
            {
                request.ServiceType = cmdletContext.ServiceType;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.PI.Model.ListAvailableResourceMetricsResponse CallAWSServiceOperation(IAmazonPI client, Amazon.PI.Model.ListAvailableResourceMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Performance Insights", "ListAvailableResourceMetrics");
            try
            {
                return client.ListAvailableResourceMetricsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.String> MetricType { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.PI.ServiceType ServiceType { get; set; }
            public System.Func<Amazon.PI.Model.ListAvailableResourceMetricsResponse, GetPIAvailableResourceMetricListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Metrics;
        }
        
    }
}
