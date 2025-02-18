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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Export optimization recommendations for your licenses. 
    /// 
    ///  
    /// <para>
    /// Recommendations are exported in a comma-separated values (CSV) file, and its metadata
    /// in a JavaScript Object Notation (JSON) file, to an existing Amazon Simple Storage
    /// Service (Amazon S3) bucket that you specify. For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/exporting-recommendations.html">Exporting
    /// Recommendations</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para><para>
    /// You can have only one license export job in progress per Amazon Web Services Region.
    /// </para>
    /// </summary>
    [Cmdlet("Export", "COLicenseRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse")]
    [AWSCmdlet("Calls the AWS Compute Optimizer ExportLicenseRecommendations API operation.", Operation = new[] {"ExportLicenseRecommendations"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse",
        "This cmdlet returns an Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse object containing multiple properties."
    )]
    public partial class ExportCOLicenseRecommendationCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Amazon Web Services accounts for which to export license recommendations.</para><para>If your account is the management account of an organization, use this parameter to
        /// specify the member account for which you want to export recommendations.</para><para>This parameter can't be specified together with the include member accounts parameter.
        /// The parameters are mutually exclusive.</para><para>If this parameter is omitted, recommendations for member accounts aren't included
        /// in the export.</para><para>You can specify multiple account IDs per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfig_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to use as the destination for an export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfig_Bucket { get; set; }
        #endregion
        
        #region Parameter FieldsToExport
        /// <summary>
        /// <para>
        /// <para>The recommendations data to include in the export file. For more information about
        /// the fields that can be exported, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/exporting-recommendations.html#exported-files">Exported
        /// files</a> in the <i>Compute Optimizer User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] FieldsToExport { get; set; }
        #endregion
        
        #region Parameter FileFormat
        /// <summary>
        /// <para>
        /// <para>The format of the export file.</para><para>A CSV file is the only export format currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.FileFormat")]
        public Amazon.ComputeOptimizer.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> An array of objects to specify a filter that exports a more specific set of license
        /// recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizer.Model.LicenseRecommendationFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeMemberAccount
        /// <summary>
        /// <para>
        /// <para>Indicates whether to include recommendations for resources in all member accounts
        /// of the organization if your account is the management account of an organization.</para><para>The member accounts must also be opted in to Compute Optimizer, and trusted access
        /// for Compute Optimizer must be enabled in the organization account. For more information,
        /// see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/security-iam.html#trusted-service-access">Compute
        /// Optimizer and Amazon Web Services Organizations trusted access</a> in the <i>Compute
        /// Optimizer User Guide</i>.</para><para>If this parameter is omitted, recommendations for member accounts of the organization
        /// aren't included in the export file .</para><para>This parameter cannot be specified together with the account IDs parameter. The parameters
        /// are mutually exclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeMemberAccounts")]
        public System.Boolean? IncludeMemberAccount { get; set; }
        #endregion
        
        #region Parameter S3DestinationConfig_KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket prefix for an export job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3DestinationConfig_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-COLicenseRecommendation (ExportLicenseRecommendations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse, ExportCOLicenseRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            if (this.FieldsToExport != null)
            {
                context.FieldsToExport = new List<System.String>(this.FieldsToExport);
            }
            context.FileFormat = this.FileFormat;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ComputeOptimizer.Model.LicenseRecommendationFilter>(this.Filter);
            }
            context.IncludeMemberAccount = this.IncludeMemberAccount;
            context.S3DestinationConfig_Bucket = this.S3DestinationConfig_Bucket;
            context.S3DestinationConfig_KeyPrefix = this.S3DestinationConfig_KeyPrefix;
            
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
            var request = new Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.FieldsToExport != null)
            {
                request.FieldsToExport = cmdletContext.FieldsToExport;
            }
            if (cmdletContext.FileFormat != null)
            {
                request.FileFormat = cmdletContext.FileFormat;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncludeMemberAccount != null)
            {
                request.IncludeMemberAccounts = cmdletContext.IncludeMemberAccount.Value;
            }
            
             // populate S3DestinationConfig
            var requestS3DestinationConfigIsNull = true;
            request.S3DestinationConfig = new Amazon.ComputeOptimizer.Model.S3DestinationConfig();
            System.String requestS3DestinationConfig_s3DestinationConfig_Bucket = null;
            if (cmdletContext.S3DestinationConfig_Bucket != null)
            {
                requestS3DestinationConfig_s3DestinationConfig_Bucket = cmdletContext.S3DestinationConfig_Bucket;
            }
            if (requestS3DestinationConfig_s3DestinationConfig_Bucket != null)
            {
                request.S3DestinationConfig.Bucket = requestS3DestinationConfig_s3DestinationConfig_Bucket;
                requestS3DestinationConfigIsNull = false;
            }
            System.String requestS3DestinationConfig_s3DestinationConfig_KeyPrefix = null;
            if (cmdletContext.S3DestinationConfig_KeyPrefix != null)
            {
                requestS3DestinationConfig_s3DestinationConfig_KeyPrefix = cmdletContext.S3DestinationConfig_KeyPrefix;
            }
            if (requestS3DestinationConfig_s3DestinationConfig_KeyPrefix != null)
            {
                request.S3DestinationConfig.KeyPrefix = requestS3DestinationConfig_s3DestinationConfig_KeyPrefix;
                requestS3DestinationConfigIsNull = false;
            }
             // determine if request.S3DestinationConfig should be set to null
            if (requestS3DestinationConfigIsNull)
            {
                request.S3DestinationConfig = null;
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
        
        private Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "ExportLicenseRecommendations");
            try
            {
                return client.ExportLicenseRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<System.String> FieldsToExport { get; set; }
            public Amazon.ComputeOptimizer.FileFormat FileFormat { get; set; }
            public List<Amazon.ComputeOptimizer.Model.LicenseRecommendationFilter> Filter { get; set; }
            public System.Boolean? IncludeMemberAccount { get; set; }
            public System.String S3DestinationConfig_Bucket { get; set; }
            public System.String S3DestinationConfig_KeyPrefix { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.ExportLicenseRecommendationsResponse, ExportCOLicenseRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
