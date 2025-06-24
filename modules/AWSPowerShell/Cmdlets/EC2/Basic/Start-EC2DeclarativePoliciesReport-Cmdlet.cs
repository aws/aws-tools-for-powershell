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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Generates an account status report. The report is generated asynchronously, and can
    /// take several hours to complete.
    /// 
    ///  
    /// <para>
    /// The report provides the current status of all attributes supported by declarative
    /// policies for the accounts within the specified scope. The scope is determined by the
    /// specified <c>TargetId</c>, which can represent an individual account, or all the accounts
    /// that fall under the specified organizational unit (OU) or root (the entire Amazon
    /// Web Services Organization).
    /// </para><para>
    /// The report is saved to your specified S3 bucket, using the following path structure
    /// (with the <i>italicized placeholders</i> representing your specific values):
    /// </para><para><c>s3://<i>amzn-s3-demo-bucket</i>/<i>your-optional-s3-prefix</i>/ec2_<i>targetId</i>_<i>reportId</i>_<i>yyyyMMdd</i>T<i>hhmm</i>Z.csv</c></para><para><b>Prerequisites for generating a report</b></para><ul><li><para>
    /// The <c>StartDeclarativePoliciesReport</c> API can only be called by the management
    /// account or delegated administrators for the organization.
    /// </para></li><li><para>
    /// An S3 bucket must be available before generating the report (you can create a new
    /// one or use an existing one), it must be in the same Region where the report generation
    /// request is made, and it must have an appropriate bucket policy. For a sample S3 policy,
    /// see <i>Sample Amazon S3 policy</i> under <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_StartDeclarativePoliciesReport.html#API_StartDeclarativePoliciesReport_Examples">Examples</a>.
    /// </para></li><li><para>
    /// Trusted access must be enabled for the service for which the declarative policy will
    /// enforce a baseline configuration. If you use the Amazon Web Services Organizations
    /// console, this is done automatically when you enable declarative policies. The API
    /// uses the following service principal to identify the EC2 service: <c>ec2.amazonaws.com</c>.
    /// For more information on how to enable trusted access with the Amazon Web Services
    /// CLI and Amazon Web Services SDKs, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_integrate_services.html">Using
    /// Organizations with other Amazon Web Services services</a> in the <i>Amazon Web Services
    /// Organizations User Guide</i>.
    /// </para></li><li><para>
    /// Only one report per organization can be generated at a time. Attempting to generate
    /// a report while another is in progress will result in an error.
    /// </para></li></ul><para>
    /// For more information, including the required IAM permissions to run this API, see
    /// <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_policies_declarative_status-report.html">Generating
    /// the account status report for declarative policies</a> in the <i>Amazon Web Services
    /// Organizations User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "EC2DeclarativePoliciesReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) StartDeclarativePoliciesReport API operation.", Operation = new[] {"StartDeclarativePoliciesReport"}, SelectReturnType = typeof(Amazon.EC2.Model.StartDeclarativePoliciesReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.StartDeclarativePoliciesReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.StartDeclarativePoliciesReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartEC2DeclarativePoliciesReportCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter S3Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where the report will be saved. The bucket must be in the
        /// same Region where the report generation request is made.</para>
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
        public System.String S3Bucket { get; set; }
        #endregion
        
        #region Parameter S3Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for your S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3Prefix { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>The root ID, organizational unit ID, or account ID.</para><para>Format:</para><ul><li><para>For root: <c>r-ab12</c></para></li><li><para>For OU: <c>ou-ab12-cdef1234</c></para></li><li><para>For account: <c>123456789012</c></para></li></ul>
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
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReportId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.StartDeclarativePoliciesReportResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.StartDeclarativePoliciesReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReportId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EC2DeclarativePoliciesReport (StartDeclarativePoliciesReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.StartDeclarativePoliciesReportResponse, StartEC2DeclarativePoliciesReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            context.S3Bucket = this.S3Bucket;
            #if MODULAR
            if (this.S3Bucket == null && ParameterWasBound(nameof(this.S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Prefix = this.S3Prefix;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TargetId = this.TargetId;
            #if MODULAR
            if (this.TargetId == null && ParameterWasBound(nameof(this.TargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.StartDeclarativePoliciesReportRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.S3Bucket != null)
            {
                request.S3Bucket = cmdletContext.S3Bucket;
            }
            if (cmdletContext.S3Prefix != null)
            {
                request.S3Prefix = cmdletContext.S3Prefix;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
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
        
        private Amazon.EC2.Model.StartDeclarativePoliciesReportResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.StartDeclarativePoliciesReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "StartDeclarativePoliciesReport");
            try
            {
                return client.StartDeclarativePoliciesReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public System.String S3Bucket { get; set; }
            public System.String S3Prefix { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TargetId { get; set; }
            public System.Func<Amazon.EC2.Model.StartDeclarativePoliciesReportResponse, StartEC2DeclarativePoliciesReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReportId;
        }
        
    }
}
