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
using Amazon.SageMakerMetrics;
using Amazon.SageMakerMetrics.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMM
{
    /// <summary>
    /// Used to retrieve training metrics from SageMaker.
    /// </summary>
    [Cmdlet("Get", "SMMMetric")]
    [OutputType("Amazon.SageMakerMetrics.Model.MetricQueryResult")]
    [AWSCmdlet("Calls the Amazon SageMaker Metrics Service BatchGetMetrics API operation.", Operation = new[] {"BatchGetMetrics"}, SelectReturnType = typeof(Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse))]
    [AWSCmdletOutput("Amazon.SageMakerMetrics.Model.MetricQueryResult or Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse",
        "This cmdlet returns a collection of Amazon.SageMakerMetrics.Model.MetricQueryResult objects.",
        "The service call response (type Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMMMetricCmdlet : AmazonSageMakerMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetricQuery
        /// <summary>
        /// <para>
        /// <para>Queries made to retrieve training metrics from SageMaker.</para>
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
        [Alias("MetricQueries")]
        public Amazon.SageMakerMetrics.Model.MetricQuery[] MetricQuery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricQueryResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse).
        /// Specifying the name of a property of type Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricQueryResults";
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
                context.Select = CreateSelectDelegate<Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse, GetSMMMetricCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.MetricQuery != null)
            {
                context.MetricQuery = new List<Amazon.SageMakerMetrics.Model.MetricQuery>(this.MetricQuery);
            }
            #if MODULAR
            if (this.MetricQuery == null && ParameterWasBound(nameof(this.MetricQuery)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricQuery which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerMetrics.Model.BatchGetMetricsRequest();
            
            if (cmdletContext.MetricQuery != null)
            {
                request.MetricQueries = cmdletContext.MetricQuery;
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
        
        private Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse CallAWSServiceOperation(IAmazonSageMakerMetrics client, Amazon.SageMakerMetrics.Model.BatchGetMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Metrics Service", "BatchGetMetrics");
            try
            {
                return client.BatchGetMetricsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SageMakerMetrics.Model.MetricQuery> MetricQuery { get; set; }
            public System.Func<Amazon.SageMakerMetrics.Model.BatchGetMetricsResponse, GetSMMMetricCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricQueryResults;
        }
        
    }
}
