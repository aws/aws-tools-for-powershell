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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Amazon.S3.IAmazonS3.RestoreObject
    /// </summary>
    [Cmdlet("Restore", "S3Object", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.RestoreObjectResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) RestoreObject API operation.", Operation = new[] {"RestoreObject"}, SelectReturnType = typeof(Amazon.S3.Model.RestoreObjectResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.RestoreObjectResponse",
        "This cmdlet returns an Amazon.S3.Model.RestoreObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name containing the object to restore. </para><para>When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><para>When using this action with Amazon S3 on Outposts, you must direct requests to the
        /// S3 on Outposts hostname. The S3 on Outposts hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com.
        /// When using this action using S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts bucket ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">Using
        /// S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.</para>
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
        
        #region Parameter CopyLifetimeInDays
        /// <summary>
        /// <para>
        /// <para>Lifetime of the active copy in days. 
        /// Do not use with restores that specify <code>OutputLocation</code>.</para><para>The Days element is required for regular restores, and must not be provided for 
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
        /// The display name of the owner.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_AccessControlList_Owner_DisplayName")]
        public System.String Owner_DisplayName { get; set; }
        #endregion
        
        #region Parameter Encryption_EncryptionType
        /// <summary>
        /// <para>
        /// The server-side encryption algorithm used when storing job results in Amazon S3 (e.g., AES256, aws:kms).
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
        /// <para>The account ID of the expected bucket owner. If the bucket is owned by a different
        /// account, the request will fail with an HTTP <code>403 (Access Denied)</code> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter AccessControlList_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutputLocation_S3_AccessControlList_Grants")]
        public Amazon.S3.Model.S3Grant[] AccessControlList_Grant { get; set; }
        #endregion
        
        #region Parameter Owner_Id
        /// <summary>
        /// <para>
        /// The unique identifier of the owner.
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
        /// specifies the ID of the symmetric customer managed key to use for encryption
        /// of job results. Amazon S3 only supports symmetric keys. For more information, see 
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">
        /// Using symmetric and asymmetric keys</a> in the <i>Amazon Web Services Key Management Service Developer Guide</i>.
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
        /// TagSet
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-S3Object (RestoreObject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.RestoreObjectResponse, RestoreS3ObjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
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
            context.Owner_DisplayName = this.Owner_DisplayName;
            context.Owner_Id = this.Owner_Id;
            if (this.AccessControlList_Grant != null)
            {
                context.AccessControlList_Grant = new List<Amazon.S3.Model.S3Grant>(this.AccessControlList_Grant);
            }
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
                #if DESKTOP
                return client.RestoreObject(request);
                #elif CORECLR
                return client.RestoreObjectAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
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
            public System.String Owner_DisplayName { get; set; }
            public System.String Owner_Id { get; set; }
            public List<Amazon.S3.Model.S3Grant> AccessControlList_Grant { get; set; }
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
