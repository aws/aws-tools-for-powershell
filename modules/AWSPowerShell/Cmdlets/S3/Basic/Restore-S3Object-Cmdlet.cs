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
    /// Restores an archived copy of an object back into Amazon S3
    /// </para><para>
    /// This functionality is not supported for Amazon S3 on Outposts.
    /// </para><para>
    /// This action performs the following types of requests: 
    /// </para><ul><li><para><c>restore an archive</c> - Restore an archived object
    /// </para></li></ul><para>
    /// For more information about the <c>S3</c> structure in the request body, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/S3_ACLs_UsingACLs.html">Managing
    /// Access with ACLs</a> in the <i>Amazon S3 User Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/serv-side-encryption.html">Protecting
    /// Data Using Server-Side Encryption</a> in the <i>Amazon S3 User Guide</i></para></li></ul><dl><dt>Permissions</dt><dd><para>
    /// To use this operation, you must have permissions to perform the <c>s3:RestoreObject</c>
    /// action. The bucket owner has this permission by default and can grant this permission
    /// to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></dd><dt>Restoring objects</dt><dd><para>
    /// Objects that you archive to the S3 Glacier Flexible Retrieval or S3 Glacier Deep Archive
    /// storage class, and S3 Intelligent-Tiering Archive or S3 Intelligent-Tiering Deep Archive
    /// tiers, are not accessible in real time. For objects in the S3 Glacier Flexible Retrieval
    /// or S3 Glacier Deep Archive storage classes, you must first initiate a restore request,
    /// and then wait until a temporary copy of the object is available. If you want a permanent
    /// copy of the object, create a copy of it in the Amazon S3 Standard storage class in
    /// your S3 bucket. To access an archived object, you must restore the object for the
    /// duration (number of days) that you specify. For objects in the Archive Access or Deep
    /// Archive Access tiers of S3 Intelligent-Tiering, you must first initiate a restore
    /// request, and then wait until the object is moved into the Frequent Access tier.
    /// </para><para>
    /// To restore a specific object version, you can provide a version ID. If you don't provide
    /// a version ID, Amazon S3 restores the current version.
    /// </para><para>
    /// When restoring an archived object, you can specify one of the following data access
    /// tier options in the <c>Tier</c> element of the request body: 
    /// </para><ul><li><para><c>Expedited</c> - Expedited retrievals allow you to quickly access your data stored
    /// in the S3 Glacier Flexible Retrieval storage class or S3 Intelligent-Tiering Archive
    /// tier when occasional urgent requests for restoring archives are required. For all
    /// but the largest archived objects (250 MB+), data accessed using Expedited retrievals
    /// is typically made available within 1–5 minutes. Provisioned capacity ensures that
    /// retrieval capacity for Expedited retrievals is available when you need it. Expedited
    /// retrievals and provisioned capacity are not available for objects stored in the S3
    /// Glacier Deep Archive storage class or S3 Intelligent-Tiering Deep Archive tier.
    /// </para></li><li><para><c>Standard</c> - Standard retrievals allow you to access any of your archived objects
    /// within several hours. This is the default option for retrieval requests that do not
    /// specify the retrieval option. Standard retrievals typically finish within 3–5 hours
    /// for objects stored in the S3 Glacier Flexible Retrieval storage class or S3 Intelligent-Tiering
    /// Archive tier. They typically finish within 12 hours for objects stored in the S3 Glacier
    /// Deep Archive storage class or S3 Intelligent-Tiering Deep Archive tier. Standard retrievals
    /// are free for objects stored in S3 Intelligent-Tiering.
    /// </para></li><li><para><c>Bulk</c> - Bulk retrievals free for objects stored in the S3 Glacier Flexible
    /// Retrieval and S3 Intelligent-Tiering storage classes, enabling you to retrieve large
    /// amounts, even petabytes, of data at no cost. Bulk retrievals typically finish within
    /// 5–12 hours for objects stored in the S3 Glacier Flexible Retrieval storage class or
    /// S3 Intelligent-Tiering Archive tier. Bulk retrievals are also the lowest-cost retrieval
    /// option when restoring objects from S3 Glacier Deep Archive. They typically finish
    /// within 48 hours for objects stored in the S3 Glacier Deep Archive storage class or
    /// S3 Intelligent-Tiering Deep Archive tier. 
    /// </para></li></ul><para>
    /// For more information about archive retrieval options and provisioned capacity for
    /// <c>Expedited</c> data access, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/restoring-objects.html">Restoring
    /// Archived Objects</a> in the <i>Amazon S3 User Guide</i>. 
    /// </para><para>
    /// You can use Amazon S3 restore speed upgrade to change the restore speed to a faster
    /// speed while it is in progress. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/restoring-objects.html#restoring-objects-upgrade-tier.title.html">
    /// Upgrading the speed of an in-progress restore</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    /// </para><para>
    /// To get the status of object restoration, you can send a <c>HEAD</c> request. Operations
    /// return the <c>x-amz-restore</c> header, which provides information about the restoration
    /// status, in the response. You can use Amazon S3 event notifications to notify you when
    /// a restore is initiated or completed. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/NotificationHowTo.html">Configuring
    /// Amazon S3 Event Notifications</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// After restoring an archived object, you can update the restoration period by reissuing
    /// the request with a new period. Amazon S3 updates the restoration period relative to
    /// the current time and charges only for the request-there are no data transfer charges.
    /// You cannot update the restoration period when Amazon S3 is actively processing your
    /// current restore request for the object.
    /// </para><para>
    /// If your bucket has a lifecycle configuration with a rule that includes an expiration
    /// action, the object expiration overrides the life span that you specify in a restore
    /// request. For example, if you restore an object copy for 10 days, but the object is
    /// scheduled to expire in 3 days, Amazon S3 deletes the object in 3 days. For more information
    /// about lifecycle configuration, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycleConfiguration.html">PutBucketLifecycleConfiguration</a>
    /// and <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/object-lifecycle-mgmt.html">Object
    /// Lifecycle Management</a> in <i>Amazon S3 User Guide</i>.
    /// </para></dd><dt>Responses</dt><dd><para>
    /// A successful action returns either the <c>200 OK</c> or <c>202 Accepted</c> status
    /// code. 
    /// </para><ul><li><para>
    /// If the object is not previously restored, then Amazon S3 returns <c>202 Accepted</c>
    /// in the response. 
    /// </para></li><li><para>
    /// If the object is previously restored, Amazon S3 returns <c>200 OK</c> in the response.
    /// 
    /// </para></li></ul><ul><li><para>
    /// Special errors:
    /// </para><ul><li><para><i>Code: RestoreAlreadyInProgress</i></para></li><li><para><i>Cause: Object restore is already in progress.</i></para></li><li><para><i>HTTP Status Code: 409 Conflict</i></para></li><li><para><i>SOAP Fault Code Prefix: Client</i></para></li></ul></li><li><ul><li><para><i>Code: GlacierExpeditedRetrievalNotAvailable</i></para></li><li><para><i>Cause: expedited retrievals are currently not available. Try again later. (Returned
    /// if there is insufficient capacity to process the Expedited request. This error applies
    /// only to Expedited retrievals and not to S3 Standard or Bulk retrievals.)</i></para></li><li><para><i>HTTP Status Code: 503</i></para></li><li><para><i>SOAP Fault Code Prefix: N/A</i></para></li></ul></li></ul></dd></dl><para>
    /// The following operations are related to <c>RestoreObject</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutBucketLifecycleConfiguration.html">PutBucketLifecycleConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketNotificationConfiguration.html">GetBucketNotificationConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Restore", "S3Object", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.RestoreObjectResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) RestoreObject API operation.", Operation = new[] {"RestoreObject"}, SelectReturnType = typeof(Amazon.S3.Model.RestoreObjectResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.RestoreObjectResponse",
        "This cmdlet returns an Amazon.S3.Model.RestoreObjectResponse object containing multiple properties."
    )]
    public partial class RestoreS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name containing the object to restore. </para><para><b>Access points</b> - When you use this action with an access point for general purpose buckets, you must 
        /// provide the alias of the access point in place of the bucket name or specify the access point ARN. When you 
        /// use this action with an access point for directory buckets, you must provide the access point name in place 
        /// of the bucket name. When using the access point ARN, you must direct requests to the access point hostname. The 
        /// access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. When 
        /// using this action with an access point through the Amazon Web Services SDKs, you provide the access point 
        /// ARN in place of the bucket name. For more information about access point ARNs, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using access points</a> in 
        /// the <i>Amazon S3 User Guide</i>.</para><para><b>S3 on Outposts</b> - When you use this action with S3 on Outposts, you must direct requests to the S3 on Outposts 
        /// hostname. The S3 on Outposts hostname takes the form <c><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>. When 
        /// you use this action with S3 on Outposts, the destination bucket must be the Outposts access point ARN or the access 
        /// point alias. For more information about S3 on Outposts, see 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What is S3 on Outposts?</a> in 
        /// the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket where the restore results will be placed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_CannedACL
        /// <summary>
        /// <para>
        /// The canned ACL to apply to the restore results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_CannedACL")]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL S3_CannedACL { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>Indicates the algorithm used to create the checksum for the object when you use the
        /// SDK. This header will not provide any additional functionality if you don't use the
        /// SDK. When you send this header, there must be a corresponding <c>x-amz-checksum</c>
        /// or <c>x-amz-trailer</c> header sent. Otherwise, Amazon S3 fails the request
        /// with the HTTP status code <c>400 Bad Request</c>. For more information, see
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/checking-object-integrity.html">Checking
        /// object integrity</a> in the <i>Amazon S3 User Guide</i>.</para><para>If you provide an individual checksum, Amazon S3 ignores any provided <c>ChecksumAlgorithm</c>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter CopyLifetimeInDays
        /// <summary>
        /// <para>
        /// <para>Lifetime of the active copy in days. 
        /// Do not use with restores that specify <c>OutputLocation</c>.</para><para>The Days element is required for regular restores, and must not be provided for 
        /// select requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [Alias("Days")]
        public System.Int32? CopyLifetimeInDays { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The optional description for the job.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Owner_DisplayName
        /// <summary>
        /// <para>
        /// <para>Container for the display name of the owner. This value is only supported in the following
        /// Amazon Web Services Regions:</para><ul><li><para>US East (N. Virginia)</para></li><li><para>US West (N. California)</para></li><li><para>US West (Oregon)</para></li><li><para>Asia Pacific (Singapore)</para></li><li><para>Asia Pacific (Sydney)</para></li><li><para>Asia Pacific (Tokyo)</para></li><li><para>Europe (Ireland)</para></li><li><para>South America (São Paulo)</para></li></ul><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_AccessControlList_Owner_DisplayName")]
        public System.String Owner_DisplayName { get; set; }
        #endregion
        
        #region Parameter Encryption_EncryptionType
        /// <summary>
        /// <para>
        /// The server-side encryption algorithm used when storing job results in Amazon S3
        /// (for example, AES256, <code>aws:kms</code>).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_Encryption_EncryptionType")]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod Encryption_EncryptionType { get; set; }
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
        
        #region Parameter AccessControlList_Grant
        /// <summary>
        /// <para>
        /// <para>A list of grants.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_AccessControlList_Grants")]
        public Amazon.S3.Model.S3Grant[] AccessControlList_Grant { get; set; }
        #endregion
        
        #region Parameter Owner_Id
        /// <summary>
        /// <para>
        /// <para>Container for the ID of the owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_AccessControlList_Owner_Id")]
        public System.String Owner_Id { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// This key indicates the S3 object to restore.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Encryption_KMSContext
        /// <summary>
        /// <para>
        /// If the encryption type is aws:kms, this optional value can be used to specify the encryption context for the restore results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_Encryption_KMSContext")]
        public System.String Encryption_KMSContext { get; set; }
        #endregion
        
        #region Parameter Encryption_KMSKeyId
        /// <summary>
        /// <para>
        /// If the encryption type is <code>aws:kms</code>, this optional value
        /// specifies the ID of the symmetric encryption customer managed key to use for encryption
        /// of job results. Amazon S3 only supports symmetric encryption KMS keys. For more information, see 
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">
        /// Asymmetric keys in Amazon Web Services KMS</a> in the <i>Amazon Web Services Key Management Service Developer Guide</i>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_Encryption_KMSKeyId")]
        public System.String Encryption_KMSKeyId { get; set; }
        #endregion
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// The prefix that is prepended to the restore results for this request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// Confirms that the requester knows that she or he will be charged for the request.
        /// Bucket owners need not specify this parameter in their requests.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter RestoreRequestType
        /// <summary>
        /// <para>
        /// Type of restore request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RestoreRequestType")]
        public Amazon.S3.RestoreRequestType RestoreRequestType { get; set; }
        #endregion
        
        #region Parameter RetrievalTier
        /// <summary>
        /// <para>
        /// Retrieval tier at which the restore will be processed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.GlacierJobTier")]
        public Amazon.S3.GlacierJobTier RetrievalTier { get; set; }
        #endregion
        
        #region Parameter SelectParameter
        /// <summary>
        /// <para>
        /// Describes the parameters for Select job types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectParameters")]
        public Amazon.S3.Model.SelectParameters SelectParameter { get; set; }
        #endregion
        
        #region Parameter S3_StorageClass
        /// <summary>
        /// <para>
        /// The class of storage used to store the restore results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_StorageClass")]
        [AWSConstantClassSource("Amazon.S3.S3StorageClass")]
        public Amazon.S3.S3StorageClass S3_StorageClass { get; set; }
        #endregion
        
        #region Parameter Tagging_TagSet
        /// <summary>
        /// <para>
        /// <para>A collection for a set of tags</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_Tagging_TagSet")]
        public Amazon.S3.Model.Tag[] Tagging_TagSet { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// Tier at which the restore will be processed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.GlacierJobTier")]
        public Amazon.S3.GlacierJobTier Tier { get; set; }
        #endregion
        
        #region Parameter S3_UserMetadata
        /// <summary>
        /// <para>
        /// A map of metadata to store with the restore results in S3.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_UserMetadata")]
        public Amazon.S3.Model.MetadataCollection S3_UserMetadata { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// VersionId used to reference a specific version of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.RestoreObjectResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.RestoreObjectResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-S3Object (RestoreObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.RestoreObjectResponse, RestoreS3ObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.CopyLifetimeInDays = this.CopyLifetimeInDays;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Description = this.Description;
            context.Key = this.Key;
            context.Tier = this.Tier;
            context.RetrievalTier = this.RetrievalTier;
            context.RestoreRequestType = this.RestoreRequestType;
            context.SelectParameter = this.SelectParameter;
            context.S3_BucketName = this.S3_BucketName;
            context.S3_Prefix = this.S3_Prefix;
            context.Encryption_EncryptionType = this.Encryption_EncryptionType;
            context.Encryption_KMSKeyId = this.Encryption_KMSKeyId;
            context.Encryption_KMSContext = this.Encryption_KMSContext;
            context.S3_CannedACL = this.S3_CannedACL;
            if (this.AccessControlList_Grant != null)
            {
                context.AccessControlList_Grant = new List<Amazon.S3.Model.S3Grant>(this.AccessControlList_Grant);
            }
            context.Owner_DisplayName = this.Owner_DisplayName;
            context.Owner_Id = this.Owner_Id;
            if (this.Tagging_TagSet != null)
            {
                context.Tagging_TagSet = new List<Amazon.S3.Model.Tag>(this.Tagging_TagSet);
            }
            context.S3_UserMetadata = this.S3_UserMetadata;
            context.S3_StorageClass = this.S3_StorageClass;
            context.RequestPayer = this.RequestPayer;
            context.VersionId = this.VersionId;
            
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
            var request = new Amazon.S3.Model.RestoreObjectRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
            }
            if (cmdletContext.CopyLifetimeInDays != null)
            {
                request.Days = cmdletContext.CopyLifetimeInDays.Value;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
            }
            if (cmdletContext.RetrievalTier != null)
            {
                request.RetrievalTier = cmdletContext.RetrievalTier;
            }
            if (cmdletContext.RestoreRequestType != null)
            {
                request.RestoreRequestType = cmdletContext.RestoreRequestType;
            }
            if (cmdletContext.SelectParameter != null)
            {
                request.SelectParameters = cmdletContext.SelectParameter;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.S3.Model.OutputLocation();
            Amazon.S3.Model.S3Location requestOutputLocation_outputLocation_S3 = null;
            
             // populate S3
            var requestOutputLocation_outputLocation_S3IsNull = true;
            requestOutputLocation_outputLocation_S3 = new Amazon.S3.Model.S3Location();
            System.String requestOutputLocation_outputLocation_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestOutputLocation_outputLocation_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestOutputLocation_outputLocation_S3_s3_BucketName != null)
            {
                requestOutputLocation_outputLocation_S3.BucketName = requestOutputLocation_outputLocation_S3_s3_BucketName;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_s3_Prefix = null;
            if (cmdletContext.S3_Prefix != null)
            {
                requestOutputLocation_outputLocation_S3_s3_Prefix = cmdletContext.S3_Prefix;
            }
            if (requestOutputLocation_outputLocation_S3_s3_Prefix != null)
            {
                requestOutputLocation_outputLocation_S3.Prefix = requestOutputLocation_outputLocation_S3_s3_Prefix;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.S3CannedACL requestOutputLocation_outputLocation_S3_s3_CannedACL = null;
            if (cmdletContext.S3_CannedACL != null)
            {
                requestOutputLocation_outputLocation_S3_s3_CannedACL = cmdletContext.S3_CannedACL;
            }
            if (requestOutputLocation_outputLocation_S3_s3_CannedACL != null)
            {
                requestOutputLocation_outputLocation_S3.CannedACL = requestOutputLocation_outputLocation_S3_s3_CannedACL;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.MetadataCollection requestOutputLocation_outputLocation_S3_s3_UserMetadata = null;
            if (cmdletContext.S3_UserMetadata != null)
            {
                requestOutputLocation_outputLocation_S3_s3_UserMetadata = cmdletContext.S3_UserMetadata;
            }
            if (requestOutputLocation_outputLocation_S3_s3_UserMetadata != null)
            {
                requestOutputLocation_outputLocation_S3.UserMetadata = requestOutputLocation_outputLocation_S3_s3_UserMetadata;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.S3StorageClass requestOutputLocation_outputLocation_S3_s3_StorageClass = null;
            if (cmdletContext.S3_StorageClass != null)
            {
                requestOutputLocation_outputLocation_S3_s3_StorageClass = cmdletContext.S3_StorageClass;
            }
            if (requestOutputLocation_outputLocation_S3_s3_StorageClass != null)
            {
                requestOutputLocation_outputLocation_S3.StorageClass = requestOutputLocation_outputLocation_S3_s3_StorageClass;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.Tagging requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging = null;
            
             // populate Tagging
            var requestOutputLocation_outputLocation_S3_outputLocation_S3_TaggingIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging = new Amazon.S3.Model.Tagging();
            List<Amazon.S3.Model.Tag> requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet = null;
            if (cmdletContext.Tagging_TagSet != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet = cmdletContext.Tagging_TagSet;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging.TagSet = requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_TaggingIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging should be set to null
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_TaggingIsNull)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging = null;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging != null)
            {
                requestOutputLocation_outputLocation_S3.Tagging = requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.S3AccessControlList requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList = null;
            
             // populate AccessControlList
            var requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList = new Amazon.S3.Model.S3AccessControlList();
            List<Amazon.S3.Model.S3Grant> requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant = null;
            if (cmdletContext.AccessControlList_Grant != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant = cmdletContext.AccessControlList_Grant;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList.Grants = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull = false;
            }
            Amazon.S3.Model.Owner requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner = null;
            
             // populate Owner
            var requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner = new Amazon.S3.Model.Owner();
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName = null;
            if (cmdletContext.Owner_DisplayName != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName = cmdletContext.Owner_DisplayName;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner.DisplayName = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id = null;
            if (cmdletContext.Owner_Id != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id = cmdletContext.Owner_Id;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner.Id = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner should be set to null
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner = null;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList.Owner = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList should be set to null
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList = null;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList != null)
            {
                requestOutputLocation_outputLocation_S3.AccessControlList = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.S3Encryption requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption = null;
            
             // populate Encryption
            var requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption = new Amazon.S3.Model.S3Encryption();
            Amazon.S3.ServerSideEncryptionMethod requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType = null;
            if (cmdletContext.Encryption_EncryptionType != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType = cmdletContext.Encryption_EncryptionType;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption.EncryptionType = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId = null;
            if (cmdletContext.Encryption_KMSKeyId != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId = cmdletContext.Encryption_KMSKeyId;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption.KMSKeyId = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext = null;
            if (cmdletContext.Encryption_KMSContext != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext = cmdletContext.Encryption_KMSContext;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption.KMSContext = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption should be set to null
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption = null;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption != null)
            {
                requestOutputLocation_outputLocation_S3.Encryption = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
             // determine if requestOutputLocation_outputLocation_S3 should be set to null
            if (requestOutputLocation_outputLocation_S3IsNull)
            {
                requestOutputLocation_outputLocation_S3 = null;
            }
            if (requestOutputLocation_outputLocation_S3 != null)
            {
                request.OutputLocation.S3 = requestOutputLocation_outputLocation_S3;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
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
        
        private Amazon.S3.Model.RestoreObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.RestoreObjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "RestoreObject");
            try
            {
                return client.RestoreObjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CopyLifetimeInDays { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Description { get; set; }
            public System.String Key { get; set; }
            public Amazon.S3.GlacierJobTier Tier { get; set; }
            public Amazon.S3.GlacierJobTier RetrievalTier { get; set; }
            public Amazon.S3.RestoreRequestType RestoreRequestType { get; set; }
            public Amazon.S3.Model.SelectParameters SelectParameter { get; set; }
            public System.String S3_BucketName { get; set; }
            public System.String S3_Prefix { get; set; }
            public Amazon.S3.ServerSideEncryptionMethod Encryption_EncryptionType { get; set; }
            public System.String Encryption_KMSKeyId { get; set; }
            public System.String Encryption_KMSContext { get; set; }
            public Amazon.S3.S3CannedACL S3_CannedACL { get; set; }
            public List<Amazon.S3.Model.S3Grant> AccessControlList_Grant { get; set; }
            public System.String Owner_DisplayName { get; set; }
            public System.String Owner_Id { get; set; }
            public List<Amazon.S3.Model.Tag> Tagging_TagSet { get; set; }
            public Amazon.S3.Model.MetadataCollection S3_UserMetadata { get; set; }
            public Amazon.S3.S3StorageClass S3_StorageClass { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.RestoreObjectResponse, RestoreS3ObjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
