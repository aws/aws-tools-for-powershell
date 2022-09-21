/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.S3Control;
using Amazon.S3Control.Model;

namespace Amazon.PowerShell.Cmdlets.S3C
{
    /// <summary>
    /// You can use S3 Batch Operations to perform large-scale batch actions on Amazon S3
    /// objects. Batch Operations can run a single action on lists of Amazon S3 objects that
    /// you specify. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/batch-ops.html">S3
    /// Batch Operations</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This action creates a S3 Batch Operations job.
    /// </para><para>
    /// Related actions include:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_DescribeJob.html">DescribeJob</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_ListJobs.html">ListJobs</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_UpdateJobPriority.html">UpdateJobPriority</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_UpdateJobStatus.html">UpdateJobStatus</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_control_JobOperation.html">JobOperation</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "S3CJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon S3 Control CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.S3Control.Model.CreateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.S3Control.Model.CreateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.S3Control.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewS3CJobCmdlet : AmazonS3ControlClientCmdlet, IExecutor
    {
        
        #region Parameter S3PutObjectCopy_AccessControlGrant
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_AccessControlGrants")]
        public Amazon.S3Control.Model.S3Grant[] S3PutObjectCopy_AccessControlGrant { get; set; }
        #endregion
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that creates the job.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ManifestOutputLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The bucket ARN the generated manifest should be written to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_Bucket")]
        public System.String ManifestOutputLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter Report_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the bucket where specified job-completion report
        /// will be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Report_Bucket { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_BucketKeyEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon S3 should use an S3 Bucket Key for object encryption with
        /// server-side encryption using Amazon Web Services KMS (SSE-KMS). Setting this header
        /// to <code>true</code> causes Amazon S3 to use an S3 Bucket Key for object encryption
        /// with SSE-KMS.</para><para>Specifying this header with an <i>object</i> action doesn’t affect <i>bucket-level</i>
        /// settings for S3 Bucket Key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_BucketKeyEnabled")]
        public System.Boolean? S3PutObjectCopy_BucketKeyEnabled { get; set; }
        #endregion
        
        #region Parameter S3PutObjectRetention_BypassGovernanceRetention
        /// <summary>
        /// <para>
        /// <para>Indicates if the action should be applied to objects in the Batch Operations job even
        /// if they have Object Lock <code> GOVERNANCE</code> type in place.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectRetention_BypassGovernanceRetention")]
        public System.Boolean? S3PutObjectRetention_BypassGovernanceRetention { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_CacheControl
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_CacheControl")]
        public System.String NewObjectMetadata_CacheControl { get; set; }
        #endregion
        
        #region Parameter AccessControlPolicy_CannedAccessControlList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectAcl_AccessControlPolicy_CannedAccessControlList")]
        [AWSConstantClassSource("Amazon.S3Control.S3CannedAccessControlList")]
        public Amazon.S3Control.S3CannedAccessControlList AccessControlPolicy_CannedAccessControlList { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_CannedAccessControlList
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_CannedAccessControlList")]
        [AWSConstantClassSource("Amazon.S3Control.S3CannedAccessControlList")]
        public Amazon.S3Control.S3CannedAccessControlList S3PutObjectCopy_CannedAccessControlList { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm you want Amazon S3 to use to create the checksum. For more
        /// information see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/CheckingObjectIntegrity.xml">
        /// Checking object integrity</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_ChecksumAlgorithm")]
        [AWSConstantClassSource("Amazon.S3Control.S3ChecksumAlgorithm")]
        public Amazon.S3Control.S3ChecksumAlgorithm S3PutObjectCopy_ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token to ensure that you don't accidentally submit the same request
        /// twice. You can use any string up to the maximum length.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ConfirmationRequired
        /// <summary>
        /// <para>
        /// <para>Indicates whether confirmation is required before Amazon S3 runs the job. Confirmation
        /// is only required for jobs created through the Amazon S3 console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfirmationRequired { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentDisposition
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentDisposition")]
        public System.String NewObjectMetadata_ContentDisposition { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentEncoding
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentEncoding")]
        public System.String NewObjectMetadata_ContentEncoding { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentLanguage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentLanguage")]
        public System.String NewObjectMetadata_ContentLanguage { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentLength
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentLength")]
        public System.Int64? NewObjectMetadata_ContentLength { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentMD5
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentMD5")]
        public System.String NewObjectMetadata_ContentMD5 { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_ContentType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_ContentType")]
        public System.String NewObjectMetadata_ContentType { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedAfter
        /// <summary>
        /// <para>
        /// <para>If provided, the generated manifest should include only source bucket objects that
        /// were created after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_Filter_CreatedAfter")]
        public System.DateTime? Filter_CreatedAfter { get; set; }
        #endregion
        
        #region Parameter Filter_CreatedBefore
        /// <summary>
        /// <para>
        /// <para>If provided, the generated manifest should include only source bucket objects that
        /// were created before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_Filter_CreatedBefore")]
        public System.DateTime? Filter_CreatedBefore { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for this job. You can use any string within the permitted length. Descriptions
        /// don't need to be unique and can be used for multiple jobs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Owner_DisplayName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_DisplayName")]
        public System.String Owner_DisplayName { get; set; }
        #endregion
        
        #region Parameter Filter_EligibleForReplication
        /// <summary>
        /// <para>
        /// <para>Include objects in the generated manifest only if they are eligible for replication
        /// according to the Replication configuration on the source bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_Filter_EligibleForReplication")]
        public System.Boolean? Filter_EligibleForReplication { get; set; }
        #endregion
        
        #region Parameter Report_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether the specified job will generate a job-completion report.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Report_Enabled { get; set; }
        #endregion
        
        #region Parameter S3JobManifestGenerator_EnableManifestOutput
        /// <summary>
        /// <para>
        /// <para>Determines whether or not to write the job's generated manifest to a bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_EnableManifestOutput")]
        public System.Boolean? S3JobManifestGenerator_EnableManifestOutput { get; set; }
        #endregion
        
        #region Parameter Location_ETag
        /// <summary>
        /// <para>
        /// <para>The ETag for the specified manifest object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Location_ETag")]
        public System.String Location_ETag { get; set; }
        #endregion
        
        #region Parameter S3JobManifestGenerator_ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that owns the bucket the generated manifest is
        /// written to. If provided the generated manifest bucket's owner Amazon Web Services
        /// account ID must match this value, else the job fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ExpectedBucketOwner")]
        public System.String S3JobManifestGenerator_ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter ManifestOutputLocation_ExpectedManifestBucketOwner
        /// <summary>
        /// <para>
        /// <para>The Account ID that owns the bucket the generated manifest is written to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ExpectedManifestBucketOwner")]
        public System.String ManifestOutputLocation_ExpectedManifestBucketOwner { get; set; }
        #endregion
        
        #region Parameter S3InitiateRestoreObject_ExpirationInDay
        /// <summary>
        /// <para>
        /// <para>This argument specifies how long the S3 Glacier or S3 Glacier Deep Archive object
        /// remains available in Amazon S3. S3 Initiate Restore Object jobs that target S3 Glacier
        /// and S3 Glacier Deep Archive objects require <code>ExpirationInDays</code> set to 1
        /// or greater.</para><para>Conversely, do <i>not</i> set <code>ExpirationInDays</code> when creating S3 Initiate
        /// Restore Object jobs that target S3 Intelligent-Tiering Archive Access and Deep Archive
        /// Access tier objects. Objects in S3 Intelligent-Tiering archive access tiers are not
        /// subject to restore expiry, so specifying <code>ExpirationInDays</code> results in
        /// restore request failure.</para><para>S3 Batch Operations jobs can operate either on S3 Glacier and S3 Glacier Deep Archive
        /// storage class objects or on S3 Intelligent-Tiering Archive Access and Deep Archive
        /// Access storage tier objects, but not both types in the same job. If you need to restore
        /// objects of both types you <i>must</i> create separate Batch Operations jobs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3InitiateRestoreObject_ExpirationInDays")]
        public System.Int32? S3InitiateRestoreObject_ExpirationInDay { get; set; }
        #endregion
        
        #region Parameter Spec_Field
        /// <summary>
        /// <para>
        /// <para>If the specified manifest object is in the <code>S3BatchOperations_CSV_20180820</code>
        /// format, this element describes which columns contain the required data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Spec_Fields")]
        public System.String[] Spec_Field { get; set; }
        #endregion
        
        #region Parameter Spec_Format
        /// <summary>
        /// <para>
        /// <para>Indicates which of the available formats the specified manifest uses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Spec_Format")]
        [AWSConstantClassSource("Amazon.S3Control.JobManifestFormat")]
        public Amazon.S3Control.JobManifestFormat Spec_Format { get; set; }
        #endregion
        
        #region Parameter Report_Format
        /// <summary>
        /// <para>
        /// <para>The format of the specified job-completion report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.JobReportFormat")]
        public Amazon.S3Control.JobReportFormat Report_Format { get; set; }
        #endregion
        
        #region Parameter LambdaInvoke_FunctionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Lambda function that the specified job will
        /// invoke on every object in the manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_LambdaInvoke_FunctionArn")]
        public System.String LambdaInvoke_FunctionArn { get; set; }
        #endregion
        
        #region Parameter S3InitiateRestoreObject_GlacierJobTier
        /// <summary>
        /// <para>
        /// <para>S3 Batch Operations supports <code>STANDARD</code> and <code>BULK</code> retrieval
        /// tiers, but not the <code>EXPEDITED</code> retrieval tier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3InitiateRestoreObject_GlacierJobTier")]
        [AWSConstantClassSource("Amazon.S3Control.S3GlacierJobTier")]
        public Amazon.S3Control.S3GlacierJobTier S3InitiateRestoreObject_GlacierJobTier { get; set; }
        #endregion
        
        #region Parameter AccessControlList_Grant
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Grants")]
        public Amazon.S3Control.Model.S3Grant[] AccessControlList_Grant { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_HttpExpiresDate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_HttpExpiresDate")]
        public System.DateTime? NewObjectMetadata_HttpExpiresDate { get; set; }
        #endregion
        
        #region Parameter Owner_ID
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_ID")]
        public System.String Owner_ID { get; set; }
        #endregion
        
        #region Parameter SSEKMS_KeyId
        /// <summary>
        /// <para>
        /// <para>Specifies the ID of the Amazon Web Services Key Management Service (Amazon Web Services
        /// KMS) symmetric encryption customer managed key to use for encrypting generated manifest
        /// objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS_KeyId")]
        public System.String SSEKMS_KeyId { get; set; }
        #endregion
        
        #region Parameter ManifestOutputLocation_ManifestFormat
        /// <summary>
        /// <para>
        /// <para>The format of the generated manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestFormat")]
        [AWSConstantClassSource("Amazon.S3Control.GeneratedManifestFormat")]
        public Amazon.S3Control.GeneratedManifestFormat ManifestOutputLocation_ManifestFormat { get; set; }
        #endregion
        
        #region Parameter ManifestOutputLocation_ManifestPrefix
        /// <summary>
        /// <para>
        /// <para>Prefix identifying one or more objects to which the manifest applies.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestPrefix")]
        public System.String ManifestOutputLocation_ManifestPrefix { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_MetadataDirective
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_MetadataDirective")]
        [AWSConstantClassSource("Amazon.S3Control.S3MetadataDirective")]
        public Amazon.S3Control.S3MetadataDirective S3PutObjectCopy_MetadataDirective { get; set; }
        #endregion
        
        #region Parameter Retention_Mode
        /// <summary>
        /// <para>
        /// <para>The Object Lock retention mode to be applied to all objects in the Batch Operations
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectRetention_Retention_Mode")]
        [AWSConstantClassSource("Amazon.S3Control.S3ObjectLockRetentionMode")]
        public Amazon.S3Control.S3ObjectLockRetentionMode Retention_Mode { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_ModifiedSinceConstraint
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_ModifiedSinceConstraint")]
        public System.DateTime? S3PutObjectCopy_ModifiedSinceConstraint { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_NewObjectTagging
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectTagging")]
        public Amazon.S3Control.Model.S3Tag[] S3PutObjectCopy_NewObjectTagging { get; set; }
        #endregion
        
        #region Parameter Location_ObjectArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for a manifest object.</para><important><para>Replacement must be made for object keys containing special characters (such as carriage
        /// returns) when using XML requests. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-keys.html#object-key-xml-related-constraints">
        /// XML related object key constraints</a>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Location_ObjectArn")]
        public System.String Location_ObjectArn { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_ObjectLockLegalHoldStatus
        /// <summary>
        /// <para>
        /// <para>The legal hold status to be applied to all objects in the Batch Operations job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_ObjectLockLegalHoldStatus")]
        [AWSConstantClassSource("Amazon.S3Control.S3ObjectLockLegalHoldStatus")]
        public Amazon.S3Control.S3ObjectLockLegalHoldStatus S3PutObjectCopy_ObjectLockLegalHoldStatus { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_ObjectLockMode
        /// <summary>
        /// <para>
        /// <para>The retention mode to be applied to all objects in the Batch Operations job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_ObjectLockMode")]
        [AWSConstantClassSource("Amazon.S3Control.S3ObjectLockMode")]
        public Amazon.S3Control.S3ObjectLockMode S3PutObjectCopy_ObjectLockMode { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_ObjectLockRetainUntilDate
        /// <summary>
        /// <para>
        /// <para>The date when the applied object retention configuration expires on all objects in
        /// the Batch Operations job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_ObjectLockRetainUntilDate")]
        public System.DateTime? S3PutObjectCopy_ObjectLockRetainUntilDate { get; set; }
        #endregion
        
        #region Parameter Filter_ObjectReplicationStatus
        /// <summary>
        /// <para>
        /// <para>If provided, the generated manifest should include only source bucket objects that
        /// have one of the specified Replication statuses.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_Filter_ObjectReplicationStatuses")]
        public System.String[] Filter_ObjectReplicationStatus { get; set; }
        #endregion
        
        #region Parameter Location_ObjectVersionId
        /// <summary>
        /// <para>
        /// <para>The optional version ID to identify a specific version of the manifest object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Location_ObjectVersionId")]
        public System.String Location_ObjectVersionId { get; set; }
        #endregion
        
        #region Parameter Report_Prefix
        /// <summary>
        /// <para>
        /// <para>An optional prefix to describe where in the specified bucket the job-completion report
        /// will be stored. Amazon S3 stores the job-completion report at <code>&lt;prefix&gt;/job-&lt;job-id&gt;/report.json</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Report_Prefix { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The numerical priority for this job. Higher numbers indicate higher priority.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_RedirectLocation
        /// <summary>
        /// <para>
        /// <para>Specifies an optional metadata property for website redirects, <code>x-amz-website-redirect-location</code>.
        /// Allows webpage redirects if the object is accessed through a website endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_RedirectLocation")]
        public System.String S3PutObjectCopy_RedirectLocation { get; set; }
        #endregion
        
        #region Parameter Report_ReportScope
        /// <summary>
        /// <para>
        /// <para>Indicates whether the job-completion report will include details of all tasks or only
        /// failed tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3Control.JobReportScope")]
        public Amazon.S3Control.JobReportScope Report_ReportScope { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_RequesterCharged
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_RequesterCharged")]
        public System.Boolean? NewObjectMetadata_RequesterCharged { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_RequesterPay
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_RequesterPays")]
        public System.Boolean? S3PutObjectCopy_RequesterPay { get; set; }
        #endregion
        
        #region Parameter Retention_RetainUntilDate
        /// <summary>
        /// <para>
        /// <para>The date when the applied Object Lock retention will expire on all objects set by
        /// the Batch Operations job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectRetention_Retention_RetainUntilDate")]
        public System.DateTime? Retention_RetainUntilDate { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the Identity and Access Management (IAM) role that
        /// Batch Operations will use to run this job's action on every object in the manifest.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Operation_S3DeleteObjectTagging
        /// <summary>
        /// <para>
        /// <para>Directs the specified job to execute a DELETE Object tagging call on every object
        /// in the manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3Control.Model.S3DeleteObjectTaggingOperation Operation_S3DeleteObjectTagging { get; set; }
        #endregion
        
        #region Parameter Operation_S3ReplicateObject
        /// <summary>
        /// <para>
        /// <para>Directs the specified job to invoke <code>ReplicateObject</code> on every object in
        /// the job's manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3Control.Model.S3ReplicateObjectOperation Operation_S3ReplicateObject { get; set; }
        #endregion
        
        #region Parameter S3JobManifestGenerator_SourceBucket
        /// <summary>
        /// <para>
        /// <para>The source bucket used by the ManifestGenerator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_SourceBucket")]
        public System.String S3JobManifestGenerator_SourceBucket { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_SSEAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_SSEAlgorithm")]
        [AWSConstantClassSource("Amazon.S3Control.S3SSEAlgorithm")]
        public Amazon.S3Control.S3SSEAlgorithm NewObjectMetadata_SSEAlgorithm { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_SSEAwsKmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_SSEAwsKmsKeyId")]
        public System.String S3PutObjectCopy_SSEAwsKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ManifestEncryption_SSES3
        /// <summary>
        /// <para>
        /// <para>Specifies the use of SSE-S3 to encrypt generated manifest objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSES3")]
        public Amazon.S3Control.Model.SSES3Encryption ManifestEncryption_SSES3 { get; set; }
        #endregion
        
        #region Parameter LegalHold_Status
        /// <summary>
        /// <para>
        /// <para>The Object Lock legal hold status to be applied to all objects in the Batch Operations
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectLegalHold_LegalHold_Status")]
        [AWSConstantClassSource("Amazon.S3Control.S3ObjectLockLegalHoldStatus")]
        public Amazon.S3Control.S3ObjectLockLegalHoldStatus LegalHold_Status { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_StorageClass
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_StorageClass")]
        [AWSConstantClassSource("Amazon.S3Control.S3StorageClass")]
        public Amazon.S3Control.S3StorageClass S3PutObjectCopy_StorageClass { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags to associate with the S3 Batch Operations job. This is an optional parameter.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.S3Control.Model.S3Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter S3PutObjectTagging_TagSet
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectTagging_TagSet")]
        public Amazon.S3Control.Model.S3Tag[] S3PutObjectTagging_TagSet { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_TargetKeyPrefix
        /// <summary>
        /// <para>
        /// <para>Specifies the folder prefix into which you would like the objects to be copied. For
        /// example, to copy objects into a folder named <code>Folder1</code> in the destination
        /// bucket, set the TargetKeyPrefix to <code>Folder1</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_TargetKeyPrefix")]
        public System.String S3PutObjectCopy_TargetKeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_TargetResource
        /// <summary>
        /// <para>
        /// <para>Specifies the destination bucket ARN for the batch copy operation. For example, to
        /// copy objects to a bucket named "destinationBucket", set the TargetResource to "arn:aws:s3:::destinationBucket".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_TargetResource")]
        public System.String S3PutObjectCopy_TargetResource { get; set; }
        #endregion
        
        #region Parameter S3PutObjectCopy_UnModifiedSinceConstraint
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_UnModifiedSinceConstraint")]
        public System.DateTime? S3PutObjectCopy_UnModifiedSinceConstraint { get; set; }
        #endregion
        
        #region Parameter NewObjectMetadata_UserMetadata
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Operation_S3PutObjectCopy_NewObjectMetadata_UserMetadata")]
        public System.Collections.Hashtable NewObjectMetadata_UserMetadata { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3Control.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.S3Control.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-S3CJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3Control.Model.CreateJobResponse, NewS3CJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ConfirmationRequired = this.ConfirmationRequired;
            context.Description = this.Description;
            context.Location_ETag = this.Location_ETag;
            context.Location_ObjectArn = this.Location_ObjectArn;
            context.Location_ObjectVersionId = this.Location_ObjectVersionId;
            if (this.Spec_Field != null)
            {
                context.Spec_Field = new List<System.String>(this.Spec_Field);
            }
            context.Spec_Format = this.Spec_Format;
            context.S3JobManifestGenerator_EnableManifestOutput = this.S3JobManifestGenerator_EnableManifestOutput;
            context.S3JobManifestGenerator_ExpectedBucketOwner = this.S3JobManifestGenerator_ExpectedBucketOwner;
            context.Filter_CreatedAfter = this.Filter_CreatedAfter;
            context.Filter_CreatedBefore = this.Filter_CreatedBefore;
            context.Filter_EligibleForReplication = this.Filter_EligibleForReplication;
            if (this.Filter_ObjectReplicationStatus != null)
            {
                context.Filter_ObjectReplicationStatus = new List<System.String>(this.Filter_ObjectReplicationStatus);
            }
            context.ManifestOutputLocation_Bucket = this.ManifestOutputLocation_Bucket;
            context.ManifestOutputLocation_ExpectedManifestBucketOwner = this.ManifestOutputLocation_ExpectedManifestBucketOwner;
            context.SSEKMS_KeyId = this.SSEKMS_KeyId;
            context.ManifestEncryption_SSES3 = this.ManifestEncryption_SSES3;
            context.ManifestOutputLocation_ManifestFormat = this.ManifestOutputLocation_ManifestFormat;
            context.ManifestOutputLocation_ManifestPrefix = this.ManifestOutputLocation_ManifestPrefix;
            context.S3JobManifestGenerator_SourceBucket = this.S3JobManifestGenerator_SourceBucket;
            context.LambdaInvoke_FunctionArn = this.LambdaInvoke_FunctionArn;
            context.Operation_S3DeleteObjectTagging = this.Operation_S3DeleteObjectTagging;
            context.S3InitiateRestoreObject_ExpirationInDay = this.S3InitiateRestoreObject_ExpirationInDay;
            context.S3InitiateRestoreObject_GlacierJobTier = this.S3InitiateRestoreObject_GlacierJobTier;
            if (this.AccessControlList_Grant != null)
            {
                context.AccessControlList_Grant = new List<Amazon.S3Control.Model.S3Grant>(this.AccessControlList_Grant);
            }
            context.Owner_DisplayName = this.Owner_DisplayName;
            context.Owner_ID = this.Owner_ID;
            context.AccessControlPolicy_CannedAccessControlList = this.AccessControlPolicy_CannedAccessControlList;
            if (this.S3PutObjectCopy_AccessControlGrant != null)
            {
                context.S3PutObjectCopy_AccessControlGrant = new List<Amazon.S3Control.Model.S3Grant>(this.S3PutObjectCopy_AccessControlGrant);
            }
            context.S3PutObjectCopy_BucketKeyEnabled = this.S3PutObjectCopy_BucketKeyEnabled;
            context.S3PutObjectCopy_CannedAccessControlList = this.S3PutObjectCopy_CannedAccessControlList;
            context.S3PutObjectCopy_ChecksumAlgorithm = this.S3PutObjectCopy_ChecksumAlgorithm;
            context.S3PutObjectCopy_MetadataDirective = this.S3PutObjectCopy_MetadataDirective;
            context.S3PutObjectCopy_ModifiedSinceConstraint = this.S3PutObjectCopy_ModifiedSinceConstraint;
            context.NewObjectMetadata_CacheControl = this.NewObjectMetadata_CacheControl;
            context.NewObjectMetadata_ContentDisposition = this.NewObjectMetadata_ContentDisposition;
            context.NewObjectMetadata_ContentEncoding = this.NewObjectMetadata_ContentEncoding;
            context.NewObjectMetadata_ContentLanguage = this.NewObjectMetadata_ContentLanguage;
            context.NewObjectMetadata_ContentLength = this.NewObjectMetadata_ContentLength;
            context.NewObjectMetadata_ContentMD5 = this.NewObjectMetadata_ContentMD5;
            context.NewObjectMetadata_ContentType = this.NewObjectMetadata_ContentType;
            context.NewObjectMetadata_HttpExpiresDate = this.NewObjectMetadata_HttpExpiresDate;
            context.NewObjectMetadata_RequesterCharged = this.NewObjectMetadata_RequesterCharged;
            context.NewObjectMetadata_SSEAlgorithm = this.NewObjectMetadata_SSEAlgorithm;
            if (this.NewObjectMetadata_UserMetadata != null)
            {
                context.NewObjectMetadata_UserMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.NewObjectMetadata_UserMetadata.Keys)
                {
                    context.NewObjectMetadata_UserMetadata.Add((String)hashKey, (String)(this.NewObjectMetadata_UserMetadata[hashKey]));
                }
            }
            if (this.S3PutObjectCopy_NewObjectTagging != null)
            {
                context.S3PutObjectCopy_NewObjectTagging = new List<Amazon.S3Control.Model.S3Tag>(this.S3PutObjectCopy_NewObjectTagging);
            }
            context.S3PutObjectCopy_ObjectLockLegalHoldStatus = this.S3PutObjectCopy_ObjectLockLegalHoldStatus;
            context.S3PutObjectCopy_ObjectLockMode = this.S3PutObjectCopy_ObjectLockMode;
            context.S3PutObjectCopy_ObjectLockRetainUntilDate = this.S3PutObjectCopy_ObjectLockRetainUntilDate;
            context.S3PutObjectCopy_RedirectLocation = this.S3PutObjectCopy_RedirectLocation;
            context.S3PutObjectCopy_RequesterPay = this.S3PutObjectCopy_RequesterPay;
            context.S3PutObjectCopy_SSEAwsKmsKeyId = this.S3PutObjectCopy_SSEAwsKmsKeyId;
            context.S3PutObjectCopy_StorageClass = this.S3PutObjectCopy_StorageClass;
            context.S3PutObjectCopy_TargetKeyPrefix = this.S3PutObjectCopy_TargetKeyPrefix;
            context.S3PutObjectCopy_TargetResource = this.S3PutObjectCopy_TargetResource;
            context.S3PutObjectCopy_UnModifiedSinceConstraint = this.S3PutObjectCopy_UnModifiedSinceConstraint;
            context.LegalHold_Status = this.LegalHold_Status;
            context.S3PutObjectRetention_BypassGovernanceRetention = this.S3PutObjectRetention_BypassGovernanceRetention;
            context.Retention_Mode = this.Retention_Mode;
            context.Retention_RetainUntilDate = this.Retention_RetainUntilDate;
            if (this.S3PutObjectTagging_TagSet != null)
            {
                context.S3PutObjectTagging_TagSet = new List<Amazon.S3Control.Model.S3Tag>(this.S3PutObjectTagging_TagSet);
            }
            context.Operation_S3ReplicateObject = this.Operation_S3ReplicateObject;
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Report_Bucket = this.Report_Bucket;
            context.Report_Enabled = this.Report_Enabled;
            #if MODULAR
            if (this.Report_Enabled == null && ParameterWasBound(nameof(this.Report_Enabled)))
            {
                WriteWarning("You are passing $null as a value for parameter Report_Enabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Report_Format = this.Report_Format;
            context.Report_Prefix = this.Report_Prefix;
            context.Report_ReportScope = this.Report_ReportScope;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.S3Control.Model.S3Tag>(this.Tag);
            }
            
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
            var request = new Amazon.S3Control.Model.CreateJobRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ConfirmationRequired != null)
            {
                request.ConfirmationRequired = cmdletContext.ConfirmationRequired.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Manifest
            var requestManifestIsNull = true;
            request.Manifest = new Amazon.S3Control.Model.JobManifest();
            Amazon.S3Control.Model.JobManifestSpec requestManifest_manifest_Spec = null;
            
             // populate Spec
            var requestManifest_manifest_SpecIsNull = true;
            requestManifest_manifest_Spec = new Amazon.S3Control.Model.JobManifestSpec();
            List<System.String> requestManifest_manifest_Spec_spec_Field = null;
            if (cmdletContext.Spec_Field != null)
            {
                requestManifest_manifest_Spec_spec_Field = cmdletContext.Spec_Field;
            }
            if (requestManifest_manifest_Spec_spec_Field != null)
            {
                requestManifest_manifest_Spec.Fields = requestManifest_manifest_Spec_spec_Field;
                requestManifest_manifest_SpecIsNull = false;
            }
            Amazon.S3Control.JobManifestFormat requestManifest_manifest_Spec_spec_Format = null;
            if (cmdletContext.Spec_Format != null)
            {
                requestManifest_manifest_Spec_spec_Format = cmdletContext.Spec_Format;
            }
            if (requestManifest_manifest_Spec_spec_Format != null)
            {
                requestManifest_manifest_Spec.Format = requestManifest_manifest_Spec_spec_Format;
                requestManifest_manifest_SpecIsNull = false;
            }
             // determine if requestManifest_manifest_Spec should be set to null
            if (requestManifest_manifest_SpecIsNull)
            {
                requestManifest_manifest_Spec = null;
            }
            if (requestManifest_manifest_Spec != null)
            {
                request.Manifest.Spec = requestManifest_manifest_Spec;
                requestManifestIsNull = false;
            }
            Amazon.S3Control.Model.JobManifestLocation requestManifest_manifest_Location = null;
            
             // populate Location
            var requestManifest_manifest_LocationIsNull = true;
            requestManifest_manifest_Location = new Amazon.S3Control.Model.JobManifestLocation();
            System.String requestManifest_manifest_Location_location_ETag = null;
            if (cmdletContext.Location_ETag != null)
            {
                requestManifest_manifest_Location_location_ETag = cmdletContext.Location_ETag;
            }
            if (requestManifest_manifest_Location_location_ETag != null)
            {
                requestManifest_manifest_Location.ETag = requestManifest_manifest_Location_location_ETag;
                requestManifest_manifest_LocationIsNull = false;
            }
            System.String requestManifest_manifest_Location_location_ObjectArn = null;
            if (cmdletContext.Location_ObjectArn != null)
            {
                requestManifest_manifest_Location_location_ObjectArn = cmdletContext.Location_ObjectArn;
            }
            if (requestManifest_manifest_Location_location_ObjectArn != null)
            {
                requestManifest_manifest_Location.ObjectArn = requestManifest_manifest_Location_location_ObjectArn;
                requestManifest_manifest_LocationIsNull = false;
            }
            System.String requestManifest_manifest_Location_location_ObjectVersionId = null;
            if (cmdletContext.Location_ObjectVersionId != null)
            {
                requestManifest_manifest_Location_location_ObjectVersionId = cmdletContext.Location_ObjectVersionId;
            }
            if (requestManifest_manifest_Location_location_ObjectVersionId != null)
            {
                requestManifest_manifest_Location.ObjectVersionId = requestManifest_manifest_Location_location_ObjectVersionId;
                requestManifest_manifest_LocationIsNull = false;
            }
             // determine if requestManifest_manifest_Location should be set to null
            if (requestManifest_manifest_LocationIsNull)
            {
                requestManifest_manifest_Location = null;
            }
            if (requestManifest_manifest_Location != null)
            {
                request.Manifest.Location = requestManifest_manifest_Location;
                requestManifestIsNull = false;
            }
             // determine if request.Manifest should be set to null
            if (requestManifestIsNull)
            {
                request.Manifest = null;
            }
            
             // populate ManifestGenerator
            var requestManifestGeneratorIsNull = true;
            request.ManifestGenerator = new Amazon.S3Control.Model.JobManifestGenerator();
            Amazon.S3Control.Model.S3JobManifestGenerator requestManifestGenerator_manifestGenerator_S3JobManifestGenerator = null;
            
             // populate S3JobManifestGenerator
            var requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = true;
            requestManifestGenerator_manifestGenerator_S3JobManifestGenerator = new Amazon.S3Control.Model.S3JobManifestGenerator();
            System.Boolean? requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_EnableManifestOutput = null;
            if (cmdletContext.S3JobManifestGenerator_EnableManifestOutput != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_EnableManifestOutput = cmdletContext.S3JobManifestGenerator_EnableManifestOutput.Value;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_EnableManifestOutput != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator.EnableManifestOutput = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_EnableManifestOutput.Value;
                requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = false;
            }
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_ExpectedBucketOwner = null;
            if (cmdletContext.S3JobManifestGenerator_ExpectedBucketOwner != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_ExpectedBucketOwner = cmdletContext.S3JobManifestGenerator_ExpectedBucketOwner;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_ExpectedBucketOwner != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator.ExpectedBucketOwner = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_ExpectedBucketOwner;
                requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = false;
            }
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_SourceBucket = null;
            if (cmdletContext.S3JobManifestGenerator_SourceBucket != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_SourceBucket = cmdletContext.S3JobManifestGenerator_SourceBucket;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_SourceBucket != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator.SourceBucket = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_s3JobManifestGenerator_SourceBucket;
                requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = false;
            }
            Amazon.S3Control.Model.JobManifestGeneratorFilter requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter = null;
            
             // populate Filter
            var requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull = true;
            requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter = new Amazon.S3Control.Model.JobManifestGeneratorFilter();
            System.DateTime? requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedAfter = null;
            if (cmdletContext.Filter_CreatedAfter != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedAfter = cmdletContext.Filter_CreatedAfter.Value;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedAfter != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter.CreatedAfter = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedAfter.Value;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull = false;
            }
            System.DateTime? requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedBefore = null;
            if (cmdletContext.Filter_CreatedBefore != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedBefore = cmdletContext.Filter_CreatedBefore.Value;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedBefore != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter.CreatedBefore = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_CreatedBefore.Value;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull = false;
            }
            System.Boolean? requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_EligibleForReplication = null;
            if (cmdletContext.Filter_EligibleForReplication != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_EligibleForReplication = cmdletContext.Filter_EligibleForReplication.Value;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_EligibleForReplication != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter.EligibleForReplication = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_EligibleForReplication.Value;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull = false;
            }
            List<System.String> requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_ObjectReplicationStatus = null;
            if (cmdletContext.Filter_ObjectReplicationStatus != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_ObjectReplicationStatus = cmdletContext.Filter_ObjectReplicationStatus;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_ObjectReplicationStatus != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter.ObjectReplicationStatuses = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter_filter_ObjectReplicationStatus;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull = false;
            }
             // determine if requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter should be set to null
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_FilterIsNull)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter = null;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator.Filter = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_Filter;
                requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = false;
            }
            Amazon.S3Control.Model.S3ManifestOutputLocation requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation = null;
            
             // populate ManifestOutputLocation
            var requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = true;
            requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation = new Amazon.S3Control.Model.S3ManifestOutputLocation();
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_Bucket = null;
            if (cmdletContext.ManifestOutputLocation_Bucket != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_Bucket = cmdletContext.ManifestOutputLocation_Bucket;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_Bucket != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation.Bucket = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_Bucket;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = false;
            }
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ExpectedManifestBucketOwner = null;
            if (cmdletContext.ManifestOutputLocation_ExpectedManifestBucketOwner != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ExpectedManifestBucketOwner = cmdletContext.ManifestOutputLocation_ExpectedManifestBucketOwner;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ExpectedManifestBucketOwner != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation.ExpectedManifestBucketOwner = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ExpectedManifestBucketOwner;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = false;
            }
            Amazon.S3Control.GeneratedManifestFormat requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestFormat = null;
            if (cmdletContext.ManifestOutputLocation_ManifestFormat != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestFormat = cmdletContext.ManifestOutputLocation_ManifestFormat;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestFormat != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation.ManifestFormat = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestFormat;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = false;
            }
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestPrefix = null;
            if (cmdletContext.ManifestOutputLocation_ManifestPrefix != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestPrefix = cmdletContext.ManifestOutputLocation_ManifestPrefix;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestPrefix != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation.ManifestPrefix = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestOutputLocation_ManifestPrefix;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = false;
            }
            Amazon.S3Control.Model.GeneratedManifestEncryption requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption = null;
            
             // populate ManifestEncryption
            var requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryptionIsNull = true;
            requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption = new Amazon.S3Control.Model.GeneratedManifestEncryption();
            Amazon.S3Control.Model.SSES3Encryption requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestEncryption_SSES3 = null;
            if (cmdletContext.ManifestEncryption_SSES3 != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestEncryption_SSES3 = cmdletContext.ManifestEncryption_SSES3;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestEncryption_SSES3 != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption.SSES3 = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestEncryption_SSES3;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryptionIsNull = false;
            }
            Amazon.S3Control.Model.SSEKMSEncryption requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS = null;
            
             // populate SSEKMS
            var requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMSIsNull = true;
            requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS = new Amazon.S3Control.Model.SSEKMSEncryption();
            System.String requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS_sSEKMS_KeyId = null;
            if (cmdletContext.SSEKMS_KeyId != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS_sSEKMS_KeyId = cmdletContext.SSEKMS_KeyId;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS_sSEKMS_KeyId != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS.KeyId = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS_sSEKMS_KeyId;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMSIsNull = false;
            }
             // determine if requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS should be set to null
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMSIsNull)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS = null;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption.SSEKMS = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption_SSEKMS;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryptionIsNull = false;
            }
             // determine if requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption should be set to null
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryptionIsNull)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption = null;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation.ManifestEncryption = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation_ManifestEncryption;
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull = false;
            }
             // determine if requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation should be set to null
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocationIsNull)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation = null;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation != null)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator.ManifestOutputLocation = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator_manifestGenerator_S3JobManifestGenerator_ManifestOutputLocation;
                requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull = false;
            }
             // determine if requestManifestGenerator_manifestGenerator_S3JobManifestGenerator should be set to null
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGeneratorIsNull)
            {
                requestManifestGenerator_manifestGenerator_S3JobManifestGenerator = null;
            }
            if (requestManifestGenerator_manifestGenerator_S3JobManifestGenerator != null)
            {
                request.ManifestGenerator.S3JobManifestGenerator = requestManifestGenerator_manifestGenerator_S3JobManifestGenerator;
                requestManifestGeneratorIsNull = false;
            }
             // determine if request.ManifestGenerator should be set to null
            if (requestManifestGeneratorIsNull)
            {
                request.ManifestGenerator = null;
            }
            
             // populate Operation
            var requestOperationIsNull = true;
            request.Operation = new Amazon.S3Control.Model.JobOperation();
            Amazon.S3Control.Model.S3DeleteObjectTaggingOperation requestOperation_operation_S3DeleteObjectTagging = null;
            if (cmdletContext.Operation_S3DeleteObjectTagging != null)
            {
                requestOperation_operation_S3DeleteObjectTagging = cmdletContext.Operation_S3DeleteObjectTagging;
            }
            if (requestOperation_operation_S3DeleteObjectTagging != null)
            {
                request.Operation.S3DeleteObjectTagging = requestOperation_operation_S3DeleteObjectTagging;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3ReplicateObjectOperation requestOperation_operation_S3ReplicateObject = null;
            if (cmdletContext.Operation_S3ReplicateObject != null)
            {
                requestOperation_operation_S3ReplicateObject = cmdletContext.Operation_S3ReplicateObject;
            }
            if (requestOperation_operation_S3ReplicateObject != null)
            {
                request.Operation.S3ReplicateObject = requestOperation_operation_S3ReplicateObject;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.LambdaInvokeOperation requestOperation_operation_LambdaInvoke = null;
            
             // populate LambdaInvoke
            var requestOperation_operation_LambdaInvokeIsNull = true;
            requestOperation_operation_LambdaInvoke = new Amazon.S3Control.Model.LambdaInvokeOperation();
            System.String requestOperation_operation_LambdaInvoke_lambdaInvoke_FunctionArn = null;
            if (cmdletContext.LambdaInvoke_FunctionArn != null)
            {
                requestOperation_operation_LambdaInvoke_lambdaInvoke_FunctionArn = cmdletContext.LambdaInvoke_FunctionArn;
            }
            if (requestOperation_operation_LambdaInvoke_lambdaInvoke_FunctionArn != null)
            {
                requestOperation_operation_LambdaInvoke.FunctionArn = requestOperation_operation_LambdaInvoke_lambdaInvoke_FunctionArn;
                requestOperation_operation_LambdaInvokeIsNull = false;
            }
             // determine if requestOperation_operation_LambdaInvoke should be set to null
            if (requestOperation_operation_LambdaInvokeIsNull)
            {
                requestOperation_operation_LambdaInvoke = null;
            }
            if (requestOperation_operation_LambdaInvoke != null)
            {
                request.Operation.LambdaInvoke = requestOperation_operation_LambdaInvoke;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3SetObjectAclOperation requestOperation_operation_S3PutObjectAcl = null;
            
             // populate S3PutObjectAcl
            var requestOperation_operation_S3PutObjectAclIsNull = true;
            requestOperation_operation_S3PutObjectAcl = new Amazon.S3Control.Model.S3SetObjectAclOperation();
            Amazon.S3Control.Model.S3AccessControlPolicy requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy = null;
            
             // populate AccessControlPolicy
            var requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicyIsNull = true;
            requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy = new Amazon.S3Control.Model.S3AccessControlPolicy();
            Amazon.S3Control.S3CannedAccessControlList requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_accessControlPolicy_CannedAccessControlList = null;
            if (cmdletContext.AccessControlPolicy_CannedAccessControlList != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_accessControlPolicy_CannedAccessControlList = cmdletContext.AccessControlPolicy_CannedAccessControlList;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_accessControlPolicy_CannedAccessControlList != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy.CannedAccessControlList = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_accessControlPolicy_CannedAccessControlList;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicyIsNull = false;
            }
            Amazon.S3Control.Model.S3AccessControlList requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList = null;
            
             // populate AccessControlList
            var requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlListIsNull = true;
            requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList = new Amazon.S3Control.Model.S3AccessControlList();
            List<Amazon.S3Control.Model.S3Grant> requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_accessControlList_Grant = null;
            if (cmdletContext.AccessControlList_Grant != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_accessControlList_Grant = cmdletContext.AccessControlList_Grant;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_accessControlList_Grant != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList.Grants = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_accessControlList_Grant;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlListIsNull = false;
            }
            Amazon.S3Control.Model.S3ObjectOwner requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner = null;
            
             // populate Owner
            var requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_OwnerIsNull = true;
            requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner = new Amazon.S3Control.Model.S3ObjectOwner();
            System.String requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_DisplayName = null;
            if (cmdletContext.Owner_DisplayName != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_DisplayName = cmdletContext.Owner_DisplayName;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_DisplayName != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner.DisplayName = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_DisplayName;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_OwnerIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_ID = null;
            if (cmdletContext.Owner_ID != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_ID = cmdletContext.Owner_ID;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_ID != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner.ID = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner_owner_ID;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_OwnerIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner should be set to null
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_OwnerIsNull)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner = null;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList.Owner = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList_Owner;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlListIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList should be set to null
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlListIsNull)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList = null;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList != null)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy.AccessControlList = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy_operation_S3PutObjectAcl_AccessControlPolicy_AccessControlList;
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicyIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy should be set to null
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicyIsNull)
            {
                requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy = null;
            }
            if (requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy != null)
            {
                requestOperation_operation_S3PutObjectAcl.AccessControlPolicy = requestOperation_operation_S3PutObjectAcl_operation_S3PutObjectAcl_AccessControlPolicy;
                requestOperation_operation_S3PutObjectAclIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectAcl should be set to null
            if (requestOperation_operation_S3PutObjectAclIsNull)
            {
                requestOperation_operation_S3PutObjectAcl = null;
            }
            if (requestOperation_operation_S3PutObjectAcl != null)
            {
                request.Operation.S3PutObjectAcl = requestOperation_operation_S3PutObjectAcl;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3SetObjectLegalHoldOperation requestOperation_operation_S3PutObjectLegalHold = null;
            
             // populate S3PutObjectLegalHold
            var requestOperation_operation_S3PutObjectLegalHoldIsNull = true;
            requestOperation_operation_S3PutObjectLegalHold = new Amazon.S3Control.Model.S3SetObjectLegalHoldOperation();
            Amazon.S3Control.Model.S3ObjectLockLegalHold requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold = null;
            
             // populate LegalHold
            var requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHoldIsNull = true;
            requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold = new Amazon.S3Control.Model.S3ObjectLockLegalHold();
            Amazon.S3Control.S3ObjectLockLegalHoldStatus requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold_legalHold_Status = null;
            if (cmdletContext.LegalHold_Status != null)
            {
                requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold_legalHold_Status = cmdletContext.LegalHold_Status;
            }
            if (requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold_legalHold_Status != null)
            {
                requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold.Status = requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold_legalHold_Status;
                requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHoldIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold should be set to null
            if (requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHoldIsNull)
            {
                requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold = null;
            }
            if (requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold != null)
            {
                requestOperation_operation_S3PutObjectLegalHold.LegalHold = requestOperation_operation_S3PutObjectLegalHold_operation_S3PutObjectLegalHold_LegalHold;
                requestOperation_operation_S3PutObjectLegalHoldIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectLegalHold should be set to null
            if (requestOperation_operation_S3PutObjectLegalHoldIsNull)
            {
                requestOperation_operation_S3PutObjectLegalHold = null;
            }
            if (requestOperation_operation_S3PutObjectLegalHold != null)
            {
                request.Operation.S3PutObjectLegalHold = requestOperation_operation_S3PutObjectLegalHold;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3SetObjectTaggingOperation requestOperation_operation_S3PutObjectTagging = null;
            
             // populate S3PutObjectTagging
            var requestOperation_operation_S3PutObjectTaggingIsNull = true;
            requestOperation_operation_S3PutObjectTagging = new Amazon.S3Control.Model.S3SetObjectTaggingOperation();
            List<Amazon.S3Control.Model.S3Tag> requestOperation_operation_S3PutObjectTagging_s3PutObjectTagging_TagSet = null;
            if (cmdletContext.S3PutObjectTagging_TagSet != null)
            {
                requestOperation_operation_S3PutObjectTagging_s3PutObjectTagging_TagSet = cmdletContext.S3PutObjectTagging_TagSet;
            }
            if (requestOperation_operation_S3PutObjectTagging_s3PutObjectTagging_TagSet != null)
            {
                requestOperation_operation_S3PutObjectTagging.TagSet = requestOperation_operation_S3PutObjectTagging_s3PutObjectTagging_TagSet;
                requestOperation_operation_S3PutObjectTaggingIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectTagging should be set to null
            if (requestOperation_operation_S3PutObjectTaggingIsNull)
            {
                requestOperation_operation_S3PutObjectTagging = null;
            }
            if (requestOperation_operation_S3PutObjectTagging != null)
            {
                request.Operation.S3PutObjectTagging = requestOperation_operation_S3PutObjectTagging;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3InitiateRestoreObjectOperation requestOperation_operation_S3InitiateRestoreObject = null;
            
             // populate S3InitiateRestoreObject
            var requestOperation_operation_S3InitiateRestoreObjectIsNull = true;
            requestOperation_operation_S3InitiateRestoreObject = new Amazon.S3Control.Model.S3InitiateRestoreObjectOperation();
            System.Int32? requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_ExpirationInDay = null;
            if (cmdletContext.S3InitiateRestoreObject_ExpirationInDay != null)
            {
                requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_ExpirationInDay = cmdletContext.S3InitiateRestoreObject_ExpirationInDay.Value;
            }
            if (requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_ExpirationInDay != null)
            {
                requestOperation_operation_S3InitiateRestoreObject.ExpirationInDays = requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_ExpirationInDay.Value;
                requestOperation_operation_S3InitiateRestoreObjectIsNull = false;
            }
            Amazon.S3Control.S3GlacierJobTier requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_GlacierJobTier = null;
            if (cmdletContext.S3InitiateRestoreObject_GlacierJobTier != null)
            {
                requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_GlacierJobTier = cmdletContext.S3InitiateRestoreObject_GlacierJobTier;
            }
            if (requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_GlacierJobTier != null)
            {
                requestOperation_operation_S3InitiateRestoreObject.GlacierJobTier = requestOperation_operation_S3InitiateRestoreObject_s3InitiateRestoreObject_GlacierJobTier;
                requestOperation_operation_S3InitiateRestoreObjectIsNull = false;
            }
             // determine if requestOperation_operation_S3InitiateRestoreObject should be set to null
            if (requestOperation_operation_S3InitiateRestoreObjectIsNull)
            {
                requestOperation_operation_S3InitiateRestoreObject = null;
            }
            if (requestOperation_operation_S3InitiateRestoreObject != null)
            {
                request.Operation.S3InitiateRestoreObject = requestOperation_operation_S3InitiateRestoreObject;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3SetObjectRetentionOperation requestOperation_operation_S3PutObjectRetention = null;
            
             // populate S3PutObjectRetention
            var requestOperation_operation_S3PutObjectRetentionIsNull = true;
            requestOperation_operation_S3PutObjectRetention = new Amazon.S3Control.Model.S3SetObjectRetentionOperation();
            System.Boolean? requestOperation_operation_S3PutObjectRetention_s3PutObjectRetention_BypassGovernanceRetention = null;
            if (cmdletContext.S3PutObjectRetention_BypassGovernanceRetention != null)
            {
                requestOperation_operation_S3PutObjectRetention_s3PutObjectRetention_BypassGovernanceRetention = cmdletContext.S3PutObjectRetention_BypassGovernanceRetention.Value;
            }
            if (requestOperation_operation_S3PutObjectRetention_s3PutObjectRetention_BypassGovernanceRetention != null)
            {
                requestOperation_operation_S3PutObjectRetention.BypassGovernanceRetention = requestOperation_operation_S3PutObjectRetention_s3PutObjectRetention_BypassGovernanceRetention.Value;
                requestOperation_operation_S3PutObjectRetentionIsNull = false;
            }
            Amazon.S3Control.Model.S3Retention requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention = null;
            
             // populate Retention
            var requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_RetentionIsNull = true;
            requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention = new Amazon.S3Control.Model.S3Retention();
            Amazon.S3Control.S3ObjectLockRetentionMode requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_Mode = null;
            if (cmdletContext.Retention_Mode != null)
            {
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_Mode = cmdletContext.Retention_Mode;
            }
            if (requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_Mode != null)
            {
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention.Mode = requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_Mode;
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_RetentionIsNull = false;
            }
            System.DateTime? requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_RetainUntilDate = null;
            if (cmdletContext.Retention_RetainUntilDate != null)
            {
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_RetainUntilDate = cmdletContext.Retention_RetainUntilDate.Value;
            }
            if (requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_RetainUntilDate != null)
            {
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention.RetainUntilDate = requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention_retention_RetainUntilDate.Value;
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_RetentionIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention should be set to null
            if (requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_RetentionIsNull)
            {
                requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention = null;
            }
            if (requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention != null)
            {
                requestOperation_operation_S3PutObjectRetention.Retention = requestOperation_operation_S3PutObjectRetention_operation_S3PutObjectRetention_Retention;
                requestOperation_operation_S3PutObjectRetentionIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectRetention should be set to null
            if (requestOperation_operation_S3PutObjectRetentionIsNull)
            {
                requestOperation_operation_S3PutObjectRetention = null;
            }
            if (requestOperation_operation_S3PutObjectRetention != null)
            {
                request.Operation.S3PutObjectRetention = requestOperation_operation_S3PutObjectRetention;
                requestOperationIsNull = false;
            }
            Amazon.S3Control.Model.S3CopyObjectOperation requestOperation_operation_S3PutObjectCopy = null;
            
             // populate S3PutObjectCopy
            var requestOperation_operation_S3PutObjectCopyIsNull = true;
            requestOperation_operation_S3PutObjectCopy = new Amazon.S3Control.Model.S3CopyObjectOperation();
            List<Amazon.S3Control.Model.S3Grant> requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_AccessControlGrant = null;
            if (cmdletContext.S3PutObjectCopy_AccessControlGrant != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_AccessControlGrant = cmdletContext.S3PutObjectCopy_AccessControlGrant;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_AccessControlGrant != null)
            {
                requestOperation_operation_S3PutObjectCopy.AccessControlGrants = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_AccessControlGrant;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.Boolean? requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_BucketKeyEnabled = null;
            if (cmdletContext.S3PutObjectCopy_BucketKeyEnabled != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_BucketKeyEnabled = cmdletContext.S3PutObjectCopy_BucketKeyEnabled.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_BucketKeyEnabled != null)
            {
                requestOperation_operation_S3PutObjectCopy.BucketKeyEnabled = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_BucketKeyEnabled.Value;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3CannedAccessControlList requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_CannedAccessControlList = null;
            if (cmdletContext.S3PutObjectCopy_CannedAccessControlList != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_CannedAccessControlList = cmdletContext.S3PutObjectCopy_CannedAccessControlList;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_CannedAccessControlList != null)
            {
                requestOperation_operation_S3PutObjectCopy.CannedAccessControlList = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_CannedAccessControlList;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3ChecksumAlgorithm requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ChecksumAlgorithm = null;
            if (cmdletContext.S3PutObjectCopy_ChecksumAlgorithm != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ChecksumAlgorithm = cmdletContext.S3PutObjectCopy_ChecksumAlgorithm;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ChecksumAlgorithm != null)
            {
                requestOperation_operation_S3PutObjectCopy.ChecksumAlgorithm = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ChecksumAlgorithm;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3MetadataDirective requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_MetadataDirective = null;
            if (cmdletContext.S3PutObjectCopy_MetadataDirective != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_MetadataDirective = cmdletContext.S3PutObjectCopy_MetadataDirective;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_MetadataDirective != null)
            {
                requestOperation_operation_S3PutObjectCopy.MetadataDirective = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_MetadataDirective;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.DateTime? requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ModifiedSinceConstraint = null;
            if (cmdletContext.S3PutObjectCopy_ModifiedSinceConstraint != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ModifiedSinceConstraint = cmdletContext.S3PutObjectCopy_ModifiedSinceConstraint.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ModifiedSinceConstraint != null)
            {
                requestOperation_operation_S3PutObjectCopy.ModifiedSinceConstraint = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ModifiedSinceConstraint.Value;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            List<Amazon.S3Control.Model.S3Tag> requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_NewObjectTagging = null;
            if (cmdletContext.S3PutObjectCopy_NewObjectTagging != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_NewObjectTagging = cmdletContext.S3PutObjectCopy_NewObjectTagging;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_NewObjectTagging != null)
            {
                requestOperation_operation_S3PutObjectCopy.NewObjectTagging = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_NewObjectTagging;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3ObjectLockLegalHoldStatus requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockLegalHoldStatus = null;
            if (cmdletContext.S3PutObjectCopy_ObjectLockLegalHoldStatus != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockLegalHoldStatus = cmdletContext.S3PutObjectCopy_ObjectLockLegalHoldStatus;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockLegalHoldStatus != null)
            {
                requestOperation_operation_S3PutObjectCopy.ObjectLockLegalHoldStatus = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockLegalHoldStatus;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3ObjectLockMode requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockMode = null;
            if (cmdletContext.S3PutObjectCopy_ObjectLockMode != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockMode = cmdletContext.S3PutObjectCopy_ObjectLockMode;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockMode != null)
            {
                requestOperation_operation_S3PutObjectCopy.ObjectLockMode = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockMode;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.DateTime? requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockRetainUntilDate = null;
            if (cmdletContext.S3PutObjectCopy_ObjectLockRetainUntilDate != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockRetainUntilDate = cmdletContext.S3PutObjectCopy_ObjectLockRetainUntilDate.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockRetainUntilDate != null)
            {
                requestOperation_operation_S3PutObjectCopy.ObjectLockRetainUntilDate = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_ObjectLockRetainUntilDate.Value;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RedirectLocation = null;
            if (cmdletContext.S3PutObjectCopy_RedirectLocation != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RedirectLocation = cmdletContext.S3PutObjectCopy_RedirectLocation;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RedirectLocation != null)
            {
                requestOperation_operation_S3PutObjectCopy.RedirectLocation = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RedirectLocation;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.Boolean? requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RequesterPay = null;
            if (cmdletContext.S3PutObjectCopy_RequesterPay != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RequesterPay = cmdletContext.S3PutObjectCopy_RequesterPay.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RequesterPay != null)
            {
                requestOperation_operation_S3PutObjectCopy.RequesterPays = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_RequesterPay.Value;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_SSEAwsKmsKeyId = null;
            if (cmdletContext.S3PutObjectCopy_SSEAwsKmsKeyId != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_SSEAwsKmsKeyId = cmdletContext.S3PutObjectCopy_SSEAwsKmsKeyId;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_SSEAwsKmsKeyId != null)
            {
                requestOperation_operation_S3PutObjectCopy.SSEAwsKmsKeyId = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_SSEAwsKmsKeyId;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.S3StorageClass requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_StorageClass = null;
            if (cmdletContext.S3PutObjectCopy_StorageClass != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_StorageClass = cmdletContext.S3PutObjectCopy_StorageClass;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_StorageClass != null)
            {
                requestOperation_operation_S3PutObjectCopy.StorageClass = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_StorageClass;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetKeyPrefix = null;
            if (cmdletContext.S3PutObjectCopy_TargetKeyPrefix != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetKeyPrefix = cmdletContext.S3PutObjectCopy_TargetKeyPrefix;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetKeyPrefix != null)
            {
                requestOperation_operation_S3PutObjectCopy.TargetKeyPrefix = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetKeyPrefix;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetResource = null;
            if (cmdletContext.S3PutObjectCopy_TargetResource != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetResource = cmdletContext.S3PutObjectCopy_TargetResource;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetResource != null)
            {
                requestOperation_operation_S3PutObjectCopy.TargetResource = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_TargetResource;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            System.DateTime? requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_UnModifiedSinceConstraint = null;
            if (cmdletContext.S3PutObjectCopy_UnModifiedSinceConstraint != null)
            {
                requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_UnModifiedSinceConstraint = cmdletContext.S3PutObjectCopy_UnModifiedSinceConstraint.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_UnModifiedSinceConstraint != null)
            {
                requestOperation_operation_S3PutObjectCopy.UnModifiedSinceConstraint = requestOperation_operation_S3PutObjectCopy_s3PutObjectCopy_UnModifiedSinceConstraint.Value;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
            Amazon.S3Control.Model.S3ObjectMetadata requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata = null;
            
             // populate NewObjectMetadata
            var requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = true;
            requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata = new Amazon.S3Control.Model.S3ObjectMetadata();
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_CacheControl = null;
            if (cmdletContext.NewObjectMetadata_CacheControl != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_CacheControl = cmdletContext.NewObjectMetadata_CacheControl;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_CacheControl != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.CacheControl = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_CacheControl;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentDisposition = null;
            if (cmdletContext.NewObjectMetadata_ContentDisposition != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentDisposition = cmdletContext.NewObjectMetadata_ContentDisposition;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentDisposition != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentDisposition = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentDisposition;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentEncoding = null;
            if (cmdletContext.NewObjectMetadata_ContentEncoding != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentEncoding = cmdletContext.NewObjectMetadata_ContentEncoding;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentEncoding != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentEncoding = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentEncoding;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLanguage = null;
            if (cmdletContext.NewObjectMetadata_ContentLanguage != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLanguage = cmdletContext.NewObjectMetadata_ContentLanguage;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLanguage != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentLanguage = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLanguage;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.Int64? requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLength = null;
            if (cmdletContext.NewObjectMetadata_ContentLength != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLength = cmdletContext.NewObjectMetadata_ContentLength.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLength != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentLength = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentLength.Value;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentMD5 = null;
            if (cmdletContext.NewObjectMetadata_ContentMD5 != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentMD5 = cmdletContext.NewObjectMetadata_ContentMD5;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentMD5 != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentMD5 = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentMD5;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.String requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentType = null;
            if (cmdletContext.NewObjectMetadata_ContentType != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentType = cmdletContext.NewObjectMetadata_ContentType;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentType != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.ContentType = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_ContentType;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.DateTime? requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_HttpExpiresDate = null;
            if (cmdletContext.NewObjectMetadata_HttpExpiresDate != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_HttpExpiresDate = cmdletContext.NewObjectMetadata_HttpExpiresDate.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_HttpExpiresDate != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.HttpExpiresDate = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_HttpExpiresDate.Value;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            System.Boolean? requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_RequesterCharged = null;
            if (cmdletContext.NewObjectMetadata_RequesterCharged != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_RequesterCharged = cmdletContext.NewObjectMetadata_RequesterCharged.Value;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_RequesterCharged != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.RequesterCharged = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_RequesterCharged.Value;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            Amazon.S3Control.S3SSEAlgorithm requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_SSEAlgorithm = null;
            if (cmdletContext.NewObjectMetadata_SSEAlgorithm != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_SSEAlgorithm = cmdletContext.NewObjectMetadata_SSEAlgorithm;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_SSEAlgorithm != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.SSEAlgorithm = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_SSEAlgorithm;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
            Dictionary<System.String, System.String> requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_UserMetadata = null;
            if (cmdletContext.NewObjectMetadata_UserMetadata != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_UserMetadata = cmdletContext.NewObjectMetadata_UserMetadata;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_UserMetadata != null)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata.UserMetadata = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata_newObjectMetadata_UserMetadata;
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata should be set to null
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadataIsNull)
            {
                requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata = null;
            }
            if (requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata != null)
            {
                requestOperation_operation_S3PutObjectCopy.NewObjectMetadata = requestOperation_operation_S3PutObjectCopy_operation_S3PutObjectCopy_NewObjectMetadata;
                requestOperation_operation_S3PutObjectCopyIsNull = false;
            }
             // determine if requestOperation_operation_S3PutObjectCopy should be set to null
            if (requestOperation_operation_S3PutObjectCopyIsNull)
            {
                requestOperation_operation_S3PutObjectCopy = null;
            }
            if (requestOperation_operation_S3PutObjectCopy != null)
            {
                request.Operation.S3PutObjectCopy = requestOperation_operation_S3PutObjectCopy;
                requestOperationIsNull = false;
            }
             // determine if request.Operation should be set to null
            if (requestOperationIsNull)
            {
                request.Operation = null;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            
             // populate Report
            var requestReportIsNull = true;
            request.Report = new Amazon.S3Control.Model.JobReport();
            System.String requestReport_report_Bucket = null;
            if (cmdletContext.Report_Bucket != null)
            {
                requestReport_report_Bucket = cmdletContext.Report_Bucket;
            }
            if (requestReport_report_Bucket != null)
            {
                request.Report.Bucket = requestReport_report_Bucket;
                requestReportIsNull = false;
            }
            System.Boolean? requestReport_report_Enabled = null;
            if (cmdletContext.Report_Enabled != null)
            {
                requestReport_report_Enabled = cmdletContext.Report_Enabled.Value;
            }
            if (requestReport_report_Enabled != null)
            {
                request.Report.Enabled = requestReport_report_Enabled.Value;
                requestReportIsNull = false;
            }
            Amazon.S3Control.JobReportFormat requestReport_report_Format = null;
            if (cmdletContext.Report_Format != null)
            {
                requestReport_report_Format = cmdletContext.Report_Format;
            }
            if (requestReport_report_Format != null)
            {
                request.Report.Format = requestReport_report_Format;
                requestReportIsNull = false;
            }
            System.String requestReport_report_Prefix = null;
            if (cmdletContext.Report_Prefix != null)
            {
                requestReport_report_Prefix = cmdletContext.Report_Prefix;
            }
            if (requestReport_report_Prefix != null)
            {
                request.Report.Prefix = requestReport_report_Prefix;
                requestReportIsNull = false;
            }
            Amazon.S3Control.JobReportScope requestReport_report_ReportScope = null;
            if (cmdletContext.Report_ReportScope != null)
            {
                requestReport_report_ReportScope = cmdletContext.Report_ReportScope;
            }
            if (requestReport_report_ReportScope != null)
            {
                request.Report.ReportScope = requestReport_report_ReportScope;
                requestReportIsNull = false;
            }
             // determine if request.Report should be set to null
            if (requestReportIsNull)
            {
                request.Report = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.S3Control.Model.CreateJobResponse CallAWSServiceOperation(IAmazonS3Control client, Amazon.S3Control.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon S3 Control", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                return client.CreateJobAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String AccountId { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? ConfirmationRequired { get; set; }
            public System.String Description { get; set; }
            public System.String Location_ETag { get; set; }
            public System.String Location_ObjectArn { get; set; }
            public System.String Location_ObjectVersionId { get; set; }
            public List<System.String> Spec_Field { get; set; }
            public Amazon.S3Control.JobManifestFormat Spec_Format { get; set; }
            public System.Boolean? S3JobManifestGenerator_EnableManifestOutput { get; set; }
            public System.String S3JobManifestGenerator_ExpectedBucketOwner { get; set; }
            public System.DateTime? Filter_CreatedAfter { get; set; }
            public System.DateTime? Filter_CreatedBefore { get; set; }
            public System.Boolean? Filter_EligibleForReplication { get; set; }
            public List<System.String> Filter_ObjectReplicationStatus { get; set; }
            public System.String ManifestOutputLocation_Bucket { get; set; }
            public System.String ManifestOutputLocation_ExpectedManifestBucketOwner { get; set; }
            public System.String SSEKMS_KeyId { get; set; }
            public Amazon.S3Control.Model.SSES3Encryption ManifestEncryption_SSES3 { get; set; }
            public Amazon.S3Control.GeneratedManifestFormat ManifestOutputLocation_ManifestFormat { get; set; }
            public System.String ManifestOutputLocation_ManifestPrefix { get; set; }
            public System.String S3JobManifestGenerator_SourceBucket { get; set; }
            public System.String LambdaInvoke_FunctionArn { get; set; }
            public Amazon.S3Control.Model.S3DeleteObjectTaggingOperation Operation_S3DeleteObjectTagging { get; set; }
            public System.Int32? S3InitiateRestoreObject_ExpirationInDay { get; set; }
            public Amazon.S3Control.S3GlacierJobTier S3InitiateRestoreObject_GlacierJobTier { get; set; }
            public List<Amazon.S3Control.Model.S3Grant> AccessControlList_Grant { get; set; }
            public System.String Owner_DisplayName { get; set; }
            public System.String Owner_ID { get; set; }
            public Amazon.S3Control.S3CannedAccessControlList AccessControlPolicy_CannedAccessControlList { get; set; }
            public List<Amazon.S3Control.Model.S3Grant> S3PutObjectCopy_AccessControlGrant { get; set; }
            public System.Boolean? S3PutObjectCopy_BucketKeyEnabled { get; set; }
            public Amazon.S3Control.S3CannedAccessControlList S3PutObjectCopy_CannedAccessControlList { get; set; }
            public Amazon.S3Control.S3ChecksumAlgorithm S3PutObjectCopy_ChecksumAlgorithm { get; set; }
            public Amazon.S3Control.S3MetadataDirective S3PutObjectCopy_MetadataDirective { get; set; }
            public System.DateTime? S3PutObjectCopy_ModifiedSinceConstraint { get; set; }
            public System.String NewObjectMetadata_CacheControl { get; set; }
            public System.String NewObjectMetadata_ContentDisposition { get; set; }
            public System.String NewObjectMetadata_ContentEncoding { get; set; }
            public System.String NewObjectMetadata_ContentLanguage { get; set; }
            public System.Int64? NewObjectMetadata_ContentLength { get; set; }
            public System.String NewObjectMetadata_ContentMD5 { get; set; }
            public System.String NewObjectMetadata_ContentType { get; set; }
            public System.DateTime? NewObjectMetadata_HttpExpiresDate { get; set; }
            public System.Boolean? NewObjectMetadata_RequesterCharged { get; set; }
            public Amazon.S3Control.S3SSEAlgorithm NewObjectMetadata_SSEAlgorithm { get; set; }
            public Dictionary<System.String, System.String> NewObjectMetadata_UserMetadata { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> S3PutObjectCopy_NewObjectTagging { get; set; }
            public Amazon.S3Control.S3ObjectLockLegalHoldStatus S3PutObjectCopy_ObjectLockLegalHoldStatus { get; set; }
            public Amazon.S3Control.S3ObjectLockMode S3PutObjectCopy_ObjectLockMode { get; set; }
            public System.DateTime? S3PutObjectCopy_ObjectLockRetainUntilDate { get; set; }
            public System.String S3PutObjectCopy_RedirectLocation { get; set; }
            public System.Boolean? S3PutObjectCopy_RequesterPay { get; set; }
            public System.String S3PutObjectCopy_SSEAwsKmsKeyId { get; set; }
            public Amazon.S3Control.S3StorageClass S3PutObjectCopy_StorageClass { get; set; }
            public System.String S3PutObjectCopy_TargetKeyPrefix { get; set; }
            public System.String S3PutObjectCopy_TargetResource { get; set; }
            public System.DateTime? S3PutObjectCopy_UnModifiedSinceConstraint { get; set; }
            public Amazon.S3Control.S3ObjectLockLegalHoldStatus LegalHold_Status { get; set; }
            public System.Boolean? S3PutObjectRetention_BypassGovernanceRetention { get; set; }
            public Amazon.S3Control.S3ObjectLockRetentionMode Retention_Mode { get; set; }
            public System.DateTime? Retention_RetainUntilDate { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> S3PutObjectTagging_TagSet { get; set; }
            public Amazon.S3Control.Model.S3ReplicateObjectOperation Operation_S3ReplicateObject { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String Report_Bucket { get; set; }
            public System.Boolean? Report_Enabled { get; set; }
            public Amazon.S3Control.JobReportFormat Report_Format { get; set; }
            public System.String Report_Prefix { get; set; }
            public Amazon.S3Control.JobReportScope Report_ReportScope { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.S3Control.Model.S3Tag> Tag { get; set; }
            public System.Func<Amazon.S3Control.Model.CreateJobResponse, NewS3CJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
