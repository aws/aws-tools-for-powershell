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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Starts generating a report of the file metadata currently cached by an S3 File Gateway
    /// for a specific file share. You can use this report to identify and resolve issues
    /// if you have files failing upload from your gateway to Amazon S3. The report is a CSV
    /// file containing a list of files which match the set of filter parameters you specify
    /// in the request.
    /// 
    ///  <note><para>
    /// The <b>Files Failing Upload</b> flag is reset every 24 hours and during gateway reboot.
    /// If this report captures the files after the reset, but before they become flagged
    /// again, they will not be reported as <b>Files Failing Upload</b>.
    /// </para></note><para>
    /// The following requirements must be met to successfully generate a cache report:
    /// </para><ul><li><para>
    /// You must have permissions to list the entire Amazon S3 bucket associated with the
    /// specified file share.
    /// </para></li><li><para>
    /// No other cache reports can currently be in-progress for the specified file share.
    /// </para></li><li><para>
    /// There must be fewer than 10 existing cache reports for the specified file share.
    /// </para></li><li><para>
    /// The gateway must be online and connected to Amazon Web Services.
    /// </para></li><li><para>
    /// The root disk must have at least 20GB of free space when report generation starts.
    /// </para></li><li><para>
    /// You must specify at least one value for <c>InclusionFilters</c> or <c>ExclusionFilters</c>
    /// in the request.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "SGCacheReport", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway StartCacheReport API operation.", Operation = new[] {"StartCacheReport"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.StartCacheReportResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.StartCacheReportResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.StartCacheReportResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartSGCacheReportCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region of the Amazon S3 bucket where you want to save the
        /// cache report.</para>
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
        public System.String BucketRegion { get; set; }
        #endregion
        
        #region Parameter ExclusionFilter
        /// <summary>
        /// <para>
        /// <para>The list of filters and parameters that determine which files are excluded from the
        /// report. You must specify at least one value for <c>InclusionFilters</c> or <c>ExclusionFilters</c>
        /// in a <c>StartCacheReport</c> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionFilters")]
        public Amazon.StorageGateway.Model.CacheReportFilter[] ExclusionFilter { get; set; }
        #endregion
        
        #region Parameter FileShareARN
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FileShareARN { get; set; }
        #endregion
        
        #region Parameter InclusionFilter
        /// <summary>
        /// <para>
        /// <para>The list of filters and parameters that determine which files are included in the
        /// report. You must specify at least one value for <c>InclusionFilters</c> or <c>ExclusionFilters</c>
        /// in a <c>StartCacheReport</c> request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InclusionFilters")]
        public Amazon.StorageGateway.Model.CacheReportFilter[] InclusionFilter { get; set; }
        #endregion
        
        #region Parameter LocationARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon S3 bucket where you want to save the cache report.</para><note><para>We do not recommend saving the cache report to the same Amazon S3 bucket for which
        /// you are generating the report.</para><para>This field does not accept access point ARNs.</para></note>
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
        public System.String LocationARN { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role used when saving the cache report to Amazon S3.</para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 key/value tags that you can assign to the cache report. Using tags
        /// can help you categorize your reports and more easily locate them in search results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VPCEndpointDNSName
        /// <summary>
        /// <para>
        /// <para>The DNS name of the VPC endpoint associated with the Amazon S3 where you want to save
        /// the cache report. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VPCEndpointDNSName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you use to ensure idempotent report generation if you need
        /// to retry an unsuccessful <c>StartCacheReport</c> request. If you retry a request,
        /// use the same <c>ClientToken</c> you specified in the initial request.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheReportARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.StartCacheReportResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.StartCacheReportResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheReportARN";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VPCEndpointDNSName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SGCacheReport (StartCacheReport)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.StartCacheReportResponse, StartSGCacheReportCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketRegion = this.BucketRegion;
            #if MODULAR
            if (this.BucketRegion == null && ParameterWasBound(nameof(this.BucketRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ExclusionFilter != null)
            {
                context.ExclusionFilter = new List<Amazon.StorageGateway.Model.CacheReportFilter>(this.ExclusionFilter);
            }
            context.FileShareARN = this.FileShareARN;
            #if MODULAR
            if (this.FileShareARN == null && ParameterWasBound(nameof(this.FileShareARN)))
            {
                WriteWarning("You are passing $null as a value for parameter FileShareARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InclusionFilter != null)
            {
                context.InclusionFilter = new List<Amazon.StorageGateway.Model.CacheReportFilter>(this.InclusionFilter);
            }
            context.LocationARN = this.LocationARN;
            #if MODULAR
            if (this.LocationARN == null && ParameterWasBound(nameof(this.LocationARN)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            context.VPCEndpointDNSName = this.VPCEndpointDNSName;
            
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
            var request = new Amazon.StorageGateway.Model.StartCacheReportRequest();
            
            if (cmdletContext.BucketRegion != null)
            {
                request.BucketRegion = cmdletContext.BucketRegion;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExclusionFilter != null)
            {
                request.ExclusionFilters = cmdletContext.ExclusionFilter;
            }
            if (cmdletContext.FileShareARN != null)
            {
                request.FileShareARN = cmdletContext.FileShareARN;
            }
            if (cmdletContext.InclusionFilter != null)
            {
                request.InclusionFilters = cmdletContext.InclusionFilter;
            }
            if (cmdletContext.LocationARN != null)
            {
                request.LocationARN = cmdletContext.LocationARN;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VPCEndpointDNSName != null)
            {
                request.VPCEndpointDNSName = cmdletContext.VPCEndpointDNSName;
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
        
        private Amazon.StorageGateway.Model.StartCacheReportResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.StartCacheReportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "StartCacheReport");
            try
            {
                return client.StartCacheReportAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketRegion { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.StorageGateway.Model.CacheReportFilter> ExclusionFilter { get; set; }
            public System.String FileShareARN { get; set; }
            public List<Amazon.StorageGateway.Model.CacheReportFilter> InclusionFilter { get; set; }
            public System.String LocationARN { get; set; }
            public System.String Role { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public System.String VPCEndpointDNSName { get; set; }
            public System.Func<Amazon.StorageGateway.Model.StartCacheReportResponse, StartSGCacheReportCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheReportARN;
        }
        
    }
}
