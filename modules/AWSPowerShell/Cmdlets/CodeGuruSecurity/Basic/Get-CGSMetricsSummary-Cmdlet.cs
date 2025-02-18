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
using Amazon.CodeGuruSecurity;
using Amazon.CodeGuruSecurity.Model;

namespace Amazon.PowerShell.Cmdlets.CGS
{
    /// <summary>
    /// Returns a summary of metrics for an account from a specified date, including number
    /// of open findings, the categories with most findings, the scans with most open findings,
    /// and scans with most open critical findings.
    /// </summary>
    [Cmdlet("Get", "CGSMetricsSummary")]
    [OutputType("Amazon.CodeGuruSecurity.Model.MetricsSummary")]
    [AWSCmdlet("Calls the Amazon CodeGuru Security GetMetricsSummary API operation.", Operation = new[] {"GetMetricsSummary"}, SelectReturnType = typeof(Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruSecurity.Model.MetricsSummary or Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse",
        "This cmdlet returns an Amazon.CodeGuruSecurity.Model.MetricsSummary object.",
        "The service call response (type Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCGSMetricsSummaryCmdlet : AmazonCodeGuruSecurityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Date
        /// <summary>
        /// <para>
        /// <para>The date you want to retrieve summary metrics from, rounded to the nearest day. The
        /// date must be within the past two years.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? Date { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricsSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricsSummary";
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
                context.Select = CreateSelectDelegate<Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse, GetCGSMetricsSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Date = this.Date;
            #if MODULAR
            if (this.Date == null && ParameterWasBound(nameof(this.Date)))
            {
                WriteWarning("You are passing $null as a value for parameter Date which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CodeGuruSecurity.Model.GetMetricsSummaryRequest();
            
            if (cmdletContext.Date != null)
            {
                request.Date = cmdletContext.Date.Value;
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
        
        private Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse CallAWSServiceOperation(IAmazonCodeGuruSecurity client, Amazon.CodeGuruSecurity.Model.GetMetricsSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Security", "GetMetricsSummary");
            try
            {
                return client.GetMetricsSummaryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? Date { get; set; }
            public System.Func<Amazon.CodeGuruSecurity.Model.GetMetricsSummaryResponse, GetCGSMetricsSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricsSummary;
        }
        
    }
}
