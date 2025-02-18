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
using Amazon.ResilienceHub;
using Amazon.ResilienceHub.Model;

namespace Amazon.PowerShell.Cmdlets.RESH
{
    /// <summary>
    /// Describes the metrics of the application configuration being exported.
    /// </summary>
    [Cmdlet("Get", "RESHMetricsExport")]
    [OutputType("Amazon.ResilienceHub.Model.DescribeMetricsExportResponse")]
    [AWSCmdlet("Calls the AWS Resilience Hub DescribeMetricsExport API operation.", Operation = new[] {"DescribeMetricsExport"}, SelectReturnType = typeof(Amazon.ResilienceHub.Model.DescribeMetricsExportResponse))]
    [AWSCmdletOutput("Amazon.ResilienceHub.Model.DescribeMetricsExportResponse",
        "This cmdlet returns an Amazon.ResilienceHub.Model.DescribeMetricsExportResponse object containing multiple properties."
    )]
    public partial class GetRESHMetricsExportCmdlet : AmazonResilienceHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MetricsExportId
        /// <summary>
        /// <para>
        /// <para>Identifier of the metrics export task.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String MetricsExportId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ResilienceHub.Model.DescribeMetricsExportResponse).
        /// Specifying the name of a property of type Amazon.ResilienceHub.Model.DescribeMetricsExportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.ResilienceHub.Model.DescribeMetricsExportResponse, GetRESHMetricsExportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MetricsExportId = this.MetricsExportId;
            #if MODULAR
            if (this.MetricsExportId == null && ParameterWasBound(nameof(this.MetricsExportId)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricsExportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ResilienceHub.Model.DescribeMetricsExportRequest();
            
            if (cmdletContext.MetricsExportId != null)
            {
                request.MetricsExportId = cmdletContext.MetricsExportId;
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
        
        private Amazon.ResilienceHub.Model.DescribeMetricsExportResponse CallAWSServiceOperation(IAmazonResilienceHub client, Amazon.ResilienceHub.Model.DescribeMetricsExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Resilience Hub", "DescribeMetricsExport");
            try
            {
                return client.DescribeMetricsExportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String MetricsExportId { get; set; }
            public System.Func<Amazon.ResilienceHub.Model.DescribeMetricsExportResponse, GetRESHMetricsExportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
