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
    /// Submits a structured report. Amazon Web Services validates it and returns a report
    /// ID. A successful response confirms that Amazon Web Services received your report.
    /// It doesn't mean that Amazon Web Services has reached an outcome. Use <a>GetAbuseReportStatus</a>
    /// with the report ID to check the report's status and outcome.
    /// 
    ///  
    /// <para>
    /// This operation is idempotent within a time window. If you provide a <c>clientToken</c>,
    /// duplicate requests within 24 hours return the existing report ID. If you omit it,
    /// the service generates a token scoped to 5 minutes.
    /// </para><important><para><b>Cross-Region data residency:</b> By submitting a report, you instruct Amazon Web
    /// Services to store it in all supported Regions (<c>us-east-1</c>, <c>us-west-2</c>,
    /// and <c>eu-west-2</c>), including across the United States and Europe. If data must
    /// remain in a single Region, do not include it in the report.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "ABSAbuseReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AbuseSignal.Model.CreateAbuseReportResponse")]
    [AWSCmdlet("Calls the AWS Abuse Signal API CreateAbuseReport API operation.", Operation = new[] {"CreateAbuseReport"}, SelectReturnType = typeof(Amazon.AbuseSignal.Model.CreateAbuseReportResponse))]
    [AWSCmdletOutput("Amazon.AbuseSignal.Model.CreateAbuseReportResponse",
        "This cmdlet returns an Amazon.AbuseSignal.Model.CreateAbuseReportResponse object containing multiple properties."
    )]
    public partial class NewABSAbuseReportCmdlet : AmazonAbuseSignalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CorrelationId
        /// <summary>
        /// <para>
        /// <para>An optional correlation ID for tracking the report in the reporter's system. The service
        /// echoes this value back in responses, and you can use it to filter reports with <a>ListAbuseReportStatuses</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CorrelationId { get; set; }
        #endregion
        
        #region Parameter Report_Xarf
        /// <summary>
        /// <para>
        /// <para>A JSON object that conforms to the XARF v4 specification. At a minimum, the document
        /// must include the XARF core fields, including the required <c>category</c> and <c>type</c>
        /// fields that classify the report (for example, <c>category</c><c>content</c> with
        /// <c>type</c><c>phishing</c>). For the XARF core fields and detailed schema definitions
        /// of each report type, see the <a href="https://xarf.org/docs/specification/">XARF v4
        /// Technical Specification on the XARF website</a>.</para><note><para>Never include images, video, or copies of child sexual abuse or child sexual exploitation
        /// material in a report, in any field and for any report type. Send URLs, hash values,
        /// and reference identifiers only.</para></note><para>If you suspect that activity is illegal, use the XARF <c>description</c> field to
        /// explain why and name the laws concerned.</para><para><b>Testing your integration</b></para><para>To test your integration, add the tag <c>lifecycle:test</c> to the report. Amazon
        /// Web Services validates test reports and returns a report ID and status in the same
        /// way as other reports, but doesn't process them as abuse reports. Amazon Web Services
        /// deletes test reports shortly after submission.</para><para>Use test values only, such as example.com and the IP address ranges reserved for documentation
        /// (192.0.2.0/24, 198.51.100.0/24 and 203.0.113.0/24). Don't add this tag to a real abuse
        /// report.</para><para>Tag keys that begin with <c>aws:</c> are reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject Report_Xarf { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An optional, client-provided idempotency token that ensures the operation completes
        /// no more than once. If the token matches a previous request within 24 hours, the service
        /// returns the existing report ID instead of creating a new report. When you omit this
        /// token, the service automatically generates one that is scoped to a 5-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AbuseSignal.Model.CreateAbuseReportResponse).
        /// Specifying the name of a property of type Amazon.AbuseSignal.Model.CreateAbuseReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CorrelationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ABSAbuseReport (CreateAbuseReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AbuseSignal.Model.CreateAbuseReportResponse, NewABSAbuseReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CorrelationId = this.CorrelationId;
            context.Report_Xarf = this.Report_Xarf;
            
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
            var request = new Amazon.AbuseSignal.Model.CreateAbuseReportRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CorrelationId != null)
            {
                request.CorrelationId = cmdletContext.CorrelationId;
            }
            
             // populate Report
            var requestReportIsNull = true;
            request.Report = new Amazon.AbuseSignal.Model.ReportData();
            Amazon.Runtime.Documents.Document? requestReport_report_Xarf = null;
            if (cmdletContext.Report_Xarf != null)
            {
                requestReport_report_Xarf = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.Report_Xarf);
            }
            if (requestReport_report_Xarf != null)
            {
                request.Report.Xarf = requestReport_report_Xarf.Value;
                requestReportIsNull = false;
            }
             // determine if request.Report should be set to null
            if (requestReportIsNull)
            {
                request.Report = null;
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
        
        private Amazon.AbuseSignal.Model.CreateAbuseReportResponse CallAWSServiceOperation(IAmazonAbuseSignal client, Amazon.AbuseSignal.Model.CreateAbuseReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Abuse Signal API", "CreateAbuseReport");
            try
            {
                return client.CreateAbuseReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String CorrelationId { get; set; }
            public System.Management.Automation.PSObject Report_Xarf { get; set; }
            public System.Func<Amazon.AbuseSignal.Model.CreateAbuseReportResponse, NewABSAbuseReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
