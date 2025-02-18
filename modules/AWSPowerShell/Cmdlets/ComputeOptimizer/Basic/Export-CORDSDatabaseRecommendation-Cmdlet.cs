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
    /// Export optimization recommendations for your Amazon Relational Database Service (Amazon
    /// RDS). 
    /// 
    ///  
    /// <para>
    /// Recommendations are exported in a comma-separated values (CSV) file, and its metadata
    /// in a JavaScript Object Notation (JSON) file, to an existing Amazon Simple Storage
    /// Service (Amazon S3) bucket that you specify. For more information, see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/exporting-recommendations.html">Exporting
    /// Recommendations</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para><para>
    /// You can have only one Amazon RDS export job in progress per Amazon Web Services Region.
    /// </para>
    /// </summary>
    [Cmdlet("Export", "CORDSDatabaseRecommendation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse")]
    [AWSCmdlet("Calls the AWS Compute Optimizer ExportRDSDatabaseRecommendations API operation.", Operation = new[] {"ExportRDSDatabaseRecommendations"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse",
        "This cmdlet returns an Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse object containing multiple properties."
    )]
    public partial class ExportCORDSDatabaseRecommendationCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account IDs for the export Amazon RDS recommendations. </para><para>If your account is the management account or the delegated administrator of an organization,
        /// use this parameter to specify the member account you want to export recommendations
        /// to.</para><para>This parameter can't be specified together with the include member accounts parameter.
        /// The parameters are mutually exclusive.</para><para>If this parameter or the include member accounts parameter is omitted, the recommendations
        /// for member accounts aren't included in the export.</para><para>You can specify multiple account IDs per request.</para>
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
        
        #region Parameter RecommendationPreferences_CpuVendorArchitecture
        /// <summary>
        /// <para>
        /// <para>Specifies the CPU vendor and architecture for Amazon EC2 instance and Auto Scaling
        /// group recommendations.</para><para>For example, when you specify <c>AWS_ARM64</c> with:</para><ul><li><para>A <a>GetEC2InstanceRecommendations</a> or <a>GetAutoScalingGroupRecommendations</a>
        /// request, Compute Optimizer returns recommendations that consist of Graviton instance
        /// types only.</para></li><li><para>A <a>GetEC2RecommendationProjectedMetrics</a> request, Compute Optimizer returns projected
        /// utilization metrics for Graviton instance type recommendations only.</para></li><li><para>A <a>ExportEC2InstanceRecommendations</a> or <a>ExportAutoScalingGroupRecommendations</a>
        /// request, Compute Optimizer exports recommendations that consist of Graviton instance
        /// types only.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationPreferences_CpuVendorArchitectures")]
        public System.String[] RecommendationPreferences_CpuVendorArchitecture { get; set; }
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
        /// <para> The format of the export file. </para><para>The CSV file is the only export file format currently supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ComputeOptimizer.FileFormat")]
        public Amazon.ComputeOptimizer.FileFormat FileFormat { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para> An array of objects to specify a filter that exports a more specific set of Amazon
        /// RDS recommendations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizer.Model.RDSDBRecommendationFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeMemberAccount
        /// <summary>
        /// <para>
        /// <para>If your account is the management account or the delegated administrator of an organization,
        /// this parameter indicates whether to include recommendations for resources in all member
        /// accounts of the organization.</para><para>The member accounts must also be opted in to Compute Optimizer, and trusted access
        /// for Compute Optimizer must be enabled in the organization account. For more information,
        /// see <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/security-iam.html#trusted-service-access">Compute
        /// Optimizer and Amazon Web Services Organizations trusted access</a> in the <i>Compute
        /// Optimizer User Guide</i>.</para><para>If this parameter is omitted, recommendations for member accounts of the organization
        /// aren't included in the export file.</para><para>If this parameter or the account ID parameter is omitted, recommendations for member
        /// accounts aren't included in the export.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Export-CORDSDatabaseRecommendation (ExportRDSDatabaseRecommendations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse, ExportCORDSDatabaseRecommendationCmdlet>(Select) ??
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
                context.Filter = new List<Amazon.ComputeOptimizer.Model.RDSDBRecommendationFilter>(this.Filter);
            }
            context.IncludeMemberAccount = this.IncludeMemberAccount;
            if (this.RecommendationPreferences_CpuVendorArchitecture != null)
            {
                context.RecommendationPreferences_CpuVendorArchitecture = new List<System.String>(this.RecommendationPreferences_CpuVendorArchitecture);
            }
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
            var request = new Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsRequest();
            
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
            
             // populate RecommendationPreferences
            var requestRecommendationPreferencesIsNull = true;
            request.RecommendationPreferences = new Amazon.ComputeOptimizer.Model.RecommendationPreferences();
            List<System.String> requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture = null;
            if (cmdletContext.RecommendationPreferences_CpuVendorArchitecture != null)
            {
                requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture = cmdletContext.RecommendationPreferences_CpuVendorArchitecture;
            }
            if (requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture != null)
            {
                request.RecommendationPreferences.CpuVendorArchitectures = requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture;
                requestRecommendationPreferencesIsNull = false;
            }
             // determine if request.RecommendationPreferences should be set to null
            if (requestRecommendationPreferencesIsNull)
            {
                request.RecommendationPreferences = null;
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
        
        private Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "ExportRDSDatabaseRecommendations");
            try
            {
                return client.ExportRDSDatabaseRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ComputeOptimizer.Model.RDSDBRecommendationFilter> Filter { get; set; }
            public System.Boolean? IncludeMemberAccount { get; set; }
            public List<System.String> RecommendationPreferences_CpuVendorArchitecture { get; set; }
            public System.String S3DestinationConfig_Bucket { get; set; }
            public System.String S3DestinationConfig_KeyPrefix { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.ExportRDSDatabaseRecommendationsResponse, ExportCORDSDatabaseRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
