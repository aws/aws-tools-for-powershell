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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Retrieves detailed information about a specific anomaly detector, including its status
    /// and configuration.
    /// </summary>
    [Cmdlet("Get", "PROMAnomalyDetector")]
    [OutputType("Amazon.PrometheusService.Model.AnomalyDetectorDescription")]
    [AWSCmdlet("Calls the Amazon Prometheus Service DescribeAnomalyDetector API operation.", Operation = new[] {"DescribeAnomalyDetector"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.AnomalyDetectorDescription or Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.AnomalyDetectorDescription object.",
        "The service call response (type Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPROMAnomalyDetectorCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorId
        /// <summary>
        /// <para>
        /// <para>The identifier of the anomaly detector to describe.</para>
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
        public System.String AnomalyDetectorId { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the workspace containing the anomaly detector.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyDetector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyDetector";
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
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse, GetPROMAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorId = this.AnomalyDetectorId;
            #if MODULAR
            if (this.AnomalyDetectorId == null && ParameterWasBound(nameof(this.AnomalyDetectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PrometheusService.Model.DescribeAnomalyDetectorRequest();
            
            if (cmdletContext.AnomalyDetectorId != null)
            {
                request.AnomalyDetectorId = cmdletContext.AnomalyDetectorId;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.DescribeAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "DescribeAnomalyDetector");
            try
            {
                return client.DescribeAnomalyDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorId { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.PrometheusService.Model.DescribeAnomalyDetectorResponse, GetPROMAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyDetector;
        }
        
    }
}
