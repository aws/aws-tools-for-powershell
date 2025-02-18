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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Get the summary metrics for this AWS account.
    /// </summary>
    [Cmdlet("Get", "IOTWMetric")]
    [OutputType("Amazon.IoTWireless.Model.SummaryMetricQueryResult")]
    [AWSCmdlet("Calls the AWS IoT Wireless GetMetrics API operation.", Operation = new[] {"GetMetrics"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.GetMetricsResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.SummaryMetricQueryResult or Amazon.IoTWireless.Model.GetMetricsResponse",
        "This cmdlet returns a collection of Amazon.IoTWireless.Model.SummaryMetricQueryResult objects.",
        "The service call response (type Amazon.IoTWireless.Model.GetMetricsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTWMetricCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SummaryMetricQuery
        /// <summary>
        /// <para>
        /// <para>The list of queries to retrieve the summary metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SummaryMetricQueries")]
        public Amazon.IoTWireless.Model.SummaryMetricQuery[] SummaryMetricQuery { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SummaryMetricQueryResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.GetMetricsResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.GetMetricsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SummaryMetricQueryResults";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.GetMetricsResponse, GetIOTWMetricCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SummaryMetricQuery != null)
            {
                context.SummaryMetricQuery = new List<Amazon.IoTWireless.Model.SummaryMetricQuery>(this.SummaryMetricQuery);
            }
            
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
            var request = new Amazon.IoTWireless.Model.GetMetricsRequest();
            
            if (cmdletContext.SummaryMetricQuery != null)
            {
                request.SummaryMetricQueries = cmdletContext.SummaryMetricQuery;
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
        
        private Amazon.IoTWireless.Model.GetMetricsResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.GetMetricsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "GetMetrics");
            try
            {
                return client.GetMetricsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.IoTWireless.Model.SummaryMetricQuery> SummaryMetricQuery { get; set; }
            public System.Func<Amazon.IoTWireless.Model.GetMetricsResponse, GetIOTWMetricCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SummaryMetricQueryResults;
        }
        
    }
}
