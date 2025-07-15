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
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <important><para>
    ///  We recommend that you create your S3 Metadata configurations by using the V2 <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a>
    /// API operation. We no longer recommend using the V1 <c>CreateBucketMetadataTableConfiguration</c>
    /// API operation. 
    /// </para><para>
    /// If you created your S3 Metadata configuration before July 15, 2025, we recommend that
    /// you delete and re-create your configuration by using <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucketMetadataConfiguration.html">CreateBucketMetadataConfiguration</a>
    /// so that you can expire journal table records and create a live inventory table.
    /// </para></important><para>
    /// Creates a V1 S3 Metadata configuration for a general purpose bucket. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-overview.html">Accelerating
    /// data discovery with S3 Metadata</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have the following permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">Setting
    /// up permissions for configuring metadata tables</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// If you want to encrypt your metadata tables with server-side encryption with Key Management
    /// Service (KMS) keys (SSE-KMS), you need additional permissions. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/metadata-tables-permissions.html">
    /// Setting up permissions for configuring metadata tables</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><para>
    /// If you also want to integrate your table bucket with Amazon Web Services analytics
    /// services so that you can query your metadata table, you need additional permissions.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-tables-integrating-aws.html">
    /// Integrating Amazon S3 Tables with Amazon Web Services analytics services</a> in the
    /// <i>Amazon S3 User Guide</i>.
    /// </para><ul><li><para><c>s3:CreateBucketMetadataTableConfiguration</c></para></li><li><para><c>s3tables:CreateNamespace</c></para></li><li><para><c>s3tables:GetTable</c></para></li><li><para><c>s3tables:CreateTable</c></para></li><li><para><c>s3tables:PutTablePolicy</c></para></li></ul></dd></dl><para>
    /// The following operations are related to <c>CreateBucketMetadataTableConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketMetadataTableConfiguration.html">DeleteBucketMetadataTableConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketMetadataTableConfiguration.html">GetBucketMetadataTableConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3BucketMetadataTableConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) CreateBucketMetadataTableConfiguration API operation.", Operation = new[] {"CreateBucketMetadataTableConfiguration"}, SelectReturnType = typeof(Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewS3BucketMetadataTableConfigurationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para> The general purpose bucket that you want to create the metadata table configuration
        /// for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para> The checksum algorithm to use with your metadata table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para> The <c>Content-MD5</c> header for the metadata table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para> The expected owner of the general purpose bucket that corresponds to your metadata
        /// table configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3TablesDestination_TableBucketArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) for the table bucket that's specified as the destination
        /// in the metadata table configuration. The destination table bucket must be in the same
        /// Region and Amazon Web Services account as the general purpose bucket. </para>
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
        [Alias("MetadataTableConfiguration_S3TablesDestination_TableBucketArn")]
        public System.String S3TablesDestination_TableBucketArn { get; set; }
        #endregion
        
        #region Parameter S3TablesDestination_TableName
        /// <summary>
        /// <para>
        /// <para> The name for the metadata table in your metadata table configuration. The specified
        /// metadata table name must be unique within the <c>aws_s3_metadata</c> namespace in
        /// the destination table bucket. </para>
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
        [Alias("MetadataTableConfiguration_S3TablesDestination_TableName")]
        public System.String S3TablesDestination_TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3BucketMetadataTableConfiguration (CreateBucketMetadataTableConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse, NewS3BucketMetadataTableConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.S3TablesDestination_TableBucketArn = this.S3TablesDestination_TableBucketArn;
            #if MODULAR
            if (this.S3TablesDestination_TableBucketArn == null && ParameterWasBound(nameof(this.S3TablesDestination_TableBucketArn)))
            {
                WriteWarning("You are passing $null as a value for parameter S3TablesDestination_TableBucketArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3TablesDestination_TableName = this.S3TablesDestination_TableName;
            #if MODULAR
            if (this.S3TablesDestination_TableName == null && ParameterWasBound(nameof(this.S3TablesDestination_TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3TablesDestination_TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.S3.Model.CreateBucketMetadataTableConfigurationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            
             // populate MetadataTableConfiguration
            var requestMetadataTableConfigurationIsNull = true;
            request.MetadataTableConfiguration = new Amazon.S3.Model.MetadataTableConfiguration();
            Amazon.S3.Model.S3TablesDestination requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = null;
            
             // populate S3TablesDestination
            var requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = true;
            requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = new Amazon.S3.Model.S3TablesDestination();
            System.String requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn = null;
            if (cmdletContext.S3TablesDestination_TableBucketArn != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn = cmdletContext.S3TablesDestination_TableBucketArn;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination.TableBucketArn = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableBucketArn;
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = false;
            }
            System.String requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName = null;
            if (cmdletContext.S3TablesDestination_TableName != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName = cmdletContext.S3TablesDestination_TableName;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName != null)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination.TableName = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination_s3TablesDestination_TableName;
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull = false;
            }
             // determine if requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination should be set to null
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestinationIsNull)
            {
                requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination = null;
            }
            if (requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination != null)
            {
                request.MetadataTableConfiguration.S3TablesDestination = requestMetadataTableConfiguration_metadataTableConfiguration_S3TablesDestination;
                requestMetadataTableConfigurationIsNull = false;
            }
             // determine if request.MetadataTableConfiguration should be set to null
            if (requestMetadataTableConfigurationIsNull)
            {
                request.MetadataTableConfiguration = null;
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
        
        private Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CreateBucketMetadataTableConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "CreateBucketMetadataTableConfiguration");
            try
            {
                return client.CreateBucketMetadataTableConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String S3TablesDestination_TableBucketArn { get; set; }
            public System.String S3TablesDestination_TableName { get; set; }
            public System.Func<Amazon.S3.Model.CreateBucketMetadataTableConfigurationResponse, NewS3BucketMetadataTableConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
