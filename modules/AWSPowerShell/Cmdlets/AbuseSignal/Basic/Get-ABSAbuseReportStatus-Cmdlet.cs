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
using Amazon.AbuseSignal;
using Amazon.AbuseSignal.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABS
{
    /// <summary>
    /// Retrieves the current processing status of a previously submitted abuse report, including
    /// the status, submission timestamp, and last-update time.
    /// 
    ///  
    /// <para>
    /// You can poll this operation to track the report's status. <c>PROCESSING</c> confirms
    /// that Amazon Web Services received your report and is processing it. <c>COMPLETED</c>
    /// means Amazon Web Services finished resolving the report, and the response includes
    /// a <c>reasonCode</c>. The time to reach <c>COMPLETED</c> may vary and can take up to
    /// several days depending on the scope and complexity of the suspected abuse.
    /// </para><note><para><c>COMPLETED</c> is the only terminal status. To wait for a report, use the <c>ReportProcessing</c>
    /// waiter, which succeeds when the report reaches <c>PROCESSING</c> or <c>COMPLETED</c>.
    /// If you poll this operation yourself, wait 1–5 seconds between calls.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ABSAbuseReportStatus")]
    [OutputType("Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse")]
    [AWSCmdlet("Calls the AWS Abuse Signal API GetAbuseReportStatus API operation.", Operation = new[] {"GetAbuseReportStatus"}, SelectReturnType = typeof(Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse))]
    [AWSCmdletOutput("Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse",
        "This cmdlet returns an Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse object containing multiple properties."
    )]
    public partial class GetABSAbuseReportStatusCmdlet : AmazonAbuseSignalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReportId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the abuse report to retrieve status for. This is the <c>reportId</c>
        /// that is returned by <a>CreateAbuseReport</a>.</para>
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
        public System.String ReportId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse).
        /// Specifying the name of a property of type Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse, GetABSAbuseReportStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReportId = this.ReportId;
            #if MODULAR
            if (this.ReportId == null && ParameterWasBound(nameof(this.ReportId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReportId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AbuseSignal.Model.GetAbuseReportStatusRequest();
            
            if (cmdletContext.ReportId != null)
            {
                request.ReportId = cmdletContext.ReportId;
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
        
        private Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse CallAWSServiceOperation(IAmazonAbuseSignal client, Amazon.AbuseSignal.Model.GetAbuseReportStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Abuse Signal API", "GetAbuseReportStatus");
            try
            {
                return client.GetAbuseReportStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ReportId { get; set; }
            public System.Func<Amazon.AbuseSignal.Model.GetAbuseReportStatusResponse, GetABSAbuseReportStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
