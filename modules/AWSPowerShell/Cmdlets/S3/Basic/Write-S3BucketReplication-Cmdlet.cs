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
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    ///  Creates a replication configuration or replaces an existing one. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/replication.html">Replication</a>
    /// in the <i>Amazon S3 User Guide</i>. 
    /// </para><para>
    /// Specify the replication configuration in the request body. In the replication configuration,
    /// you provide the name of the destination bucket or buckets where you want Amazon S3
    /// to replicate objects, the IAM role that Amazon S3 can assume to replicate objects
    /// on your behalf, and other relevant information. You can invoke this request for a
    /// specific Amazon Web Services Region by using the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_condition-keys.html#condition-keys-requestedregion"><c>aws:RequestedRegion</c></a> condition key.
    /// </para><para>
    /// A replication configuration must include at least one rule, and can contain a maximum
    /// of 1,000. Each rule identifies a subset of objects to replicate by filtering the objects
    /// in the source bucket. To choose additional subsets of objects to replicate, add a
    /// rule for each subset.
    /// </para><para>
    /// To specify a subset of the objects in the source bucket to apply a replication rule
    /// to, add the Filter element as a child of the Rule element. You can filter objects
    /// based on an object key prefix, one or more object tags, or both. When you add the
    /// Filter element in the configuration, you must also add the following elements: <c>DeleteMarkerReplication</c>,
    /// <c>Status</c>, and <c>Priority</c>.
    /// </para><note><para>
    /// If you are using an earlier version of the replication configuration, Amazon S3 handles
    /// replication of delete markers differently. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/replication-add-config.html#replication-backward-compat-considerations">Backward
    /// Compatibility</a>.
    /// </para></note><para>
    /// For information about enabling versioning on a bucket, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/Versioning.html">Using
    /// Versioning</a>.
    /// </para><dl><dt>Handling Replication of Encrypted Objects</dt><dd><para>
    /// By default, Amazon S3 doesn't replicate objects that are stored at rest using server-side
    /// encryption with KMS keys. To replicate Amazon Web Services KMS-encrypted objects,
    /// add the following: <c>SourceSelectionCriteria</c>, <c>SseKmsEncryptedObjects</c>,
    /// <c>Status</c>, <c>EncryptionConfiguration</c>, and <c>ReplicaKmsKeyID</c>. For information
    /// about replication configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/replication-config-for-kms-objects.html">Replicating
    /// Objects Created with SSE Using KMS keys</a>.
    /// </para><para>
    /// For information on <c>PutBucketReplication</c> errors, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/ErrorResponses.html#ReplicationErrorCodeList">List
    /// of replication-related error codes</a></para></dd><dt>Permissions</dt><dd><para>
    /// To create a <c>PutBucketReplication</c> request, you must have <c>s3:PutReplicationConfiguration</c>
    /// permissions for the bucket. 
    /// </para><para>
    /// By default, a resource owner, in this case the Amazon Web Services account that created
    /// the bucket, can perform this operation. The resource owner can also grant others permissions
    /// to perform the operation. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html">Specifying
    /// Permissions in a Policy</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a>.
    /// </para><note><para>
    /// To perform this operation, the user or role performing the action must have the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use_passrole.html">iam:PassRole</a>
    /// permission.
    /// </para></note></dd></dl><para>
    /// The following operations are related to <c>PutBucketReplication</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketReplication.html">GetBucketReplication</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteBucketReplication.html">DeleteBucketReplication</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketReplication API operation.", Operation = new[] {"PutBucketReplication"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketReplicationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketReplicationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketReplicationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3BucketReplicationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket</para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the request when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <c>x-amz-checksum</c>
        /// or <c>x-amz-trailer</c> header sent. Otherwise, Amazon S3 fails the request with the
        /// HTTP status code <c>400 Bad Request</c>. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <c>ChecksumAlgorithm</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>The Base64 encoded 128-bit <c>MD5</c> digest of the data. You must use this header
        /// as a message integrity check to verify that the request body was not corrupted in
        /// transit. For more information, see <a href="http://www.ietf.org/rfc/rfc1864.txt">RFC
        /// 1864</a>.</para><para>For requests made using the Amazon Web Services Command Line Interface (CLI) or Amazon
        /// Web Services SDKs, this field is calculated automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Configuration_Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// Amazon S3 assumes when replicating objects. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/replication-how-setup.html">How
        /// to Set Up Replication</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        public System.String Configuration_Role { get; set; }
        #endregion
        
        #region Parameter Configuration_Rule
        /// <summary>
        /// <para>
        /// <para>A container for one or more replication rules. A replication configuration must have
        /// at least one rule and can contain a maximum of 1,000 rules. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Configuration_Rules")]
        public Amazon.S3.Model.ReplicationRule[] Configuration_Rule { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>A token to allow Object Lock to be enabled for an existing bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketReplicationResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketReplication (PutBucketReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketReplicationResponse, WriteS3BucketReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.Configuration_Role = this.Configuration_Role;
            #if MODULAR
            if (this.Configuration_Role == null && ParameterWasBound(nameof(this.Configuration_Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Configuration_Rule != null)
            {
                context.Configuration_Rule = new List<Amazon.S3.Model.ReplicationRule>(this.Configuration_Rule);
            }
            #if MODULAR
            if (this.Configuration_Rule == null && ParameterWasBound(nameof(this.Configuration_Rule)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Rule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Token = this.Token;
            
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
            var request = new Amazon.S3.Model.PutBucketReplicationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.S3.Model.ReplicationConfiguration();
            System.String requestConfiguration_configuration_Role = null;
            if (cmdletContext.Configuration_Role != null)
            {
                requestConfiguration_configuration_Role = cmdletContext.Configuration_Role;
            }
            if (requestConfiguration_configuration_Role != null)
            {
                request.Configuration.Role = requestConfiguration_configuration_Role;
                requestConfigurationIsNull = false;
            }
            List<Amazon.S3.Model.ReplicationRule> requestConfiguration_configuration_Rule = null;
            if (cmdletContext.Configuration_Rule != null)
            {
                requestConfiguration_configuration_Rule = cmdletContext.Configuration_Rule;
            }
            if (requestConfiguration_configuration_Rule != null)
            {
                request.Configuration.Rules = requestConfiguration_configuration_Rule;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.ContentMD5 != null)
            {
                request.ContentMD5 = cmdletContext.ContentMD5;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
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
        
        private Amazon.S3.Model.PutBucketReplicationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketReplication");
            try
            {
                return client.PutBucketReplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_Role { get; set; }
            public List<Amazon.S3.Model.ReplicationRule> Configuration_Rule { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Token { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketReplicationResponse, WriteS3BucketReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
