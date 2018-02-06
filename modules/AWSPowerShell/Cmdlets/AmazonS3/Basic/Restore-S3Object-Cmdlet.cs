/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Restores an archived copy of an object back into Amazon S3
    /// </summary>
    [Cmdlet("Restore", "S3Object", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.RestoreObjectResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service RestoreObject API operation.", Operation = new[] {"RestoreObject"})]
    [AWSCmdletOutput("Amazon.S3.Model.RestoreObjectResponse",
        "This cmdlet returns a Amazon.S3.Model.RestoreObjectResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter S3_CannedACL
        /// <summary>
        /// <para>
        /// The canned ACL to apply to the restore results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_CannedACL")]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL S3_CannedACL { get; set; }
        #endregion
        
        #region Parameter CopyLifetimeInDays
        /// <summary>
        /// <para>
        /// Lifetime of the active copy in days
        /// ** Do not use with restores that specify OutputLocation **
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Days")]
        public System.Int32 CopyLifetimeInDays { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The optional description for the job.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Owner_DisplayName
        /// <summary>
        /// <para>
        /// The display name of the owner.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_AccessControlList_Owner_DisplayName")]
        public System.String Owner_DisplayName { get; set; }
        #endregion
        
        #region Parameter Encryption_EncryptionType
        /// <summary>
        /// <para>
        /// The server-side encryption algorithm used when storing job results in Amazon S3 (e.g., AES256, aws:kms).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_Encryption_EncryptionType")]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod Encryption_EncryptionType { get; set; }
        #endregion
        
        #region Parameter AccessControlList_Grant
        /// <summary>
        /// <para>
        /// A collection of grants.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_AccessControlList_Grants")]
        public Amazon.S3.Model.S3Grant[] AccessControlList_Grant { get; set; }
        #endregion
        
        #region Parameter Owner_Id
        /// <summary>
        /// <para>
        /// The unique identifier of the owner.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_Encryption_KMSContext")]
        public System.String Encryption_KMSContext { get; set; }
        #endregion
        
        #region Parameter Encryption_KMSKeyId
        /// <summary>
        /// <para>
        /// Specifies the AWS KMS key ID to use for object encryption. All GET and PUT requests for an object protected by
        /// AWS KMS will fail if not made via SSL or using SigV4. Documentation on configuring any of the officially supported AWS SDKs and CLI can be found at
        /// http://docs.aws.amazon.com/AmazonS3/latest/dev/UsingAWSSDK.html#specify-signature-version
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_Encryption_KMSKeyId")]
        public System.String Encryption_KMSKeyId { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// Confirms that the requester knows that she or he will be charged for the list objects request.
        /// Bucket owners need not specify this parameter in their requests.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter RestoreRequestType
        /// <summary>
        /// <para>
        /// Type of restore request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.RestoreRequestType")]
        public Amazon.S3.RestoreRequestType RestoreRequestType { get; set; }
        #endregion
        
        #region Parameter RetrievalTier
        /// <summary>
        /// <para>
        /// Glacier retrieval tier at which the restore will be processed.
        /// ** Only use with restores that require OutputLocation **
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.GlacierJobTier")]
        public Amazon.S3.GlacierJobTier RetrievalTier { get; set; }
        #endregion
        
        #region Parameter SelectParameter
        /// <summary>
        /// <para>
        /// Describes the parameters for Select job types.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SelectParameters")]
        public Amazon.S3.Model.SelectParameters SelectParameter { get; set; }
        #endregion
        
        #region Parameter S3_StorageClass
        /// <summary>
        /// <para>
        /// The class of storage used to store the restore results.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_Tagging_TagSet")]
        public Amazon.S3.Model.Tag[] Tagging_TagSet { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// Glacier retrieval tier at which the restore will be processed.
        /// ** Do not use with restores that specify OutputLocation **
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.S3.GlacierJobTier")]
        public Amazon.S3.GlacierJobTier Tier { get; set; }
        #endregion
        
        #region Parameter S3_UserMetadata
        /// <summary>
        /// <para>
        /// A map of metadata to store with the restore results in S3.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        
        #region Parameter S3_Prefix
        /// <summary>
        /// <para>
        /// The prefix that is prepended to the restore results for this request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("OutputLocation_S3_Prefix")]
        public System.String S3_Prefix { get; set; }
        #endregion
        
        #region Parameter UseAccelerateEndpoint
        /// <summary>
        /// Enables S3 accelerate by sending requests to the accelerate endpoint instead of the regular region endpoint.
        /// To use this feature, the bucket name must be DNS compliant and must not contain periods (.). 
        /// </summary>
        [Parameter]
        public SwitchParameter UseAccelerateEndpoint { get; set; }
        
        #endregion
        
        #region Parameter UseDualstackEndpoint
        /// <summary>
        /// Configures the request to Amazon S3 to use the dualstack endpoint for a region.
        /// S3 supports dualstack endpoints which return both IPv6 and IPv4 values.
        /// The dualstack mode of Amazon S3 cannot be used with accelerate mode.
        /// </summary>
        [Parameter]
        public SwitchParameter UseDualstackEndpoint { get; set; }
        
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BucketName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-S3Object (RestoreObject)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.BucketName = this.BucketName;
            context.Key = this.Key;
            if (ParameterWasBound("CopyLifetimeInDays"))
                context.CopyLifetimeInDays = this.CopyLifetimeInDays;
            context.VersionId = this.VersionId;
            context.RequestPayer = this.RequestPayer;
            context.Tier = this.Tier;
            context.RetrievalTier = this.RetrievalTier;
            context.RestoreRequestType = this.RestoreRequestType;
            context.Description = this.Description;
            context.SelectParameters = this.SelectParameter;
            context.OutputLocation_S3_BucketName = this.S3_BucketName;
            context.OutputLocation_S3_Prefix = this.S3_Prefix;
            context.OutputLocation_S3_Encryption_EncryptionType = this.Encryption_EncryptionType;
            context.OutputLocation_S3_Encryption_KMSKeyId = this.Encryption_KMSKeyId;
            context.OutputLocation_S3_Encryption_KMSContext = this.Encryption_KMSContext;
            context.OutputLocation_S3_CannedACL = this.S3_CannedACL;
            context.OutputLocation_S3_AccessControlList_Owner_DisplayName = this.Owner_DisplayName;
            context.OutputLocation_S3_AccessControlList_Owner_Id = this.Owner_Id;
            if (this.AccessControlList_Grant != null)
            {
                context.OutputLocation_S3_AccessControlList_Grants = new List<Amazon.S3.Model.S3Grant>(this.AccessControlList_Grant);
            }
            if (this.Tagging_TagSet != null)
            {
                context.OutputLocation_S3_Tagging_TagSet = new List<Amazon.S3.Model.Tag>(this.Tagging_TagSet);
            }
            context.OutputLocation_S3_UserMetadata = this.S3_UserMetadata;
            context.OutputLocation_S3_StorageClass = this.S3_StorageClass;
            
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
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.CopyLifetimeInDays != null)
            {
                request.Days = cmdletContext.CopyLifetimeInDays.Value;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.SelectParameters != null)
            {
                request.SelectParameters = cmdletContext.SelectParameters;
            }
            
             // populate OutputLocation
            bool requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.S3.Model.OutputLocation();
            Amazon.S3.Model.S3Location requestOutputLocation_outputLocation_S3 = null;
            
             // populate S3
            bool requestOutputLocation_outputLocation_S3IsNull = true;
            requestOutputLocation_outputLocation_S3 = new Amazon.S3.Model.S3Location();
            System.String requestOutputLocation_outputLocation_S3_s3_BucketName = null;
            if (cmdletContext.OutputLocation_S3_BucketName != null)
            {
                requestOutputLocation_outputLocation_S3_s3_BucketName = cmdletContext.OutputLocation_S3_BucketName;
            }
            if (requestOutputLocation_outputLocation_S3_s3_BucketName != null)
            {
                requestOutputLocation_outputLocation_S3.BucketName = requestOutputLocation_outputLocation_S3_s3_BucketName;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_s3_Prefix = null;
            if (cmdletContext.OutputLocation_S3_Prefix != null)
            {
                requestOutputLocation_outputLocation_S3_s3_Prefix = cmdletContext.OutputLocation_S3_Prefix;
            }
            if (requestOutputLocation_outputLocation_S3_s3_Prefix != null)
            {
                requestOutputLocation_outputLocation_S3.Prefix = requestOutputLocation_outputLocation_S3_s3_Prefix;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.S3CannedACL requestOutputLocation_outputLocation_S3_s3_CannedACL = null;
            if (cmdletContext.OutputLocation_S3_CannedACL != null)
            {
                requestOutputLocation_outputLocation_S3_s3_CannedACL = cmdletContext.OutputLocation_S3_CannedACL;
            }
            if (requestOutputLocation_outputLocation_S3_s3_CannedACL != null)
            {
                requestOutputLocation_outputLocation_S3.CannedACL = requestOutputLocation_outputLocation_S3_s3_CannedACL;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.MetadataCollection requestOutputLocation_outputLocation_S3_s3_UserMetadata = null;
            if (cmdletContext.OutputLocation_S3_UserMetadata != null)
            {
                requestOutputLocation_outputLocation_S3_s3_UserMetadata = cmdletContext.OutputLocation_S3_UserMetadata;
            }
            if (requestOutputLocation_outputLocation_S3_s3_UserMetadata != null)
            {
                requestOutputLocation_outputLocation_S3.UserMetadata = requestOutputLocation_outputLocation_S3_s3_UserMetadata;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.S3StorageClass requestOutputLocation_outputLocation_S3_s3_StorageClass = null;
            if (cmdletContext.OutputLocation_S3_StorageClass != null)
            {
                requestOutputLocation_outputLocation_S3_s3_StorageClass = cmdletContext.OutputLocation_S3_StorageClass;
            }
            if (requestOutputLocation_outputLocation_S3_s3_StorageClass != null)
            {
                requestOutputLocation_outputLocation_S3.StorageClass = requestOutputLocation_outputLocation_S3_s3_StorageClass;
                requestOutputLocation_outputLocation_S3IsNull = false;
            }
            Amazon.S3.Model.Tagging requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging = null;
            
             // populate Tagging
            bool requestOutputLocation_outputLocation_S3_outputLocation_S3_TaggingIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging = new Amazon.S3.Model.Tagging();
            List<Amazon.S3.Model.Tag> requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet = null;
            if (cmdletContext.OutputLocation_S3_Tagging_TagSet != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Tagging_tagging_TagSet = cmdletContext.OutputLocation_S3_Tagging_TagSet;
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
            bool requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList = new Amazon.S3.Model.S3AccessControlList();
            List<Amazon.S3.Model.S3Grant> requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant = null;
            if (cmdletContext.OutputLocation_S3_AccessControlList_Grants != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant = cmdletContext.OutputLocation_S3_AccessControlList_Grants;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList.Grants = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_accessControlList_Grant;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlListIsNull = false;
            }
            Amazon.S3.Model.Owner requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner = null;
            
             // populate Owner
            bool requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner = new Amazon.S3.Model.Owner();
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName = null;
            if (cmdletContext.OutputLocation_S3_AccessControlList_Owner_DisplayName != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName = cmdletContext.OutputLocation_S3_AccessControlList_Owner_DisplayName;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner.DisplayName = requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_DisplayName;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_OwnerIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id = null;
            if (cmdletContext.OutputLocation_S3_AccessControlList_Owner_Id != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_AccessControlList_outputLocation_S3_AccessControlList_Owner_owner_Id = cmdletContext.OutputLocation_S3_AccessControlList_Owner_Id;
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
            bool requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = true;
            requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption = new Amazon.S3.Model.S3Encryption();
            Amazon.S3.ServerSideEncryptionMethod requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType = null;
            if (cmdletContext.OutputLocation_S3_Encryption_EncryptionType != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType = cmdletContext.OutputLocation_S3_Encryption_EncryptionType;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption.EncryptionType = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_EncryptionType;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId = null;
            if (cmdletContext.OutputLocation_S3_Encryption_KMSKeyId != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId = cmdletContext.OutputLocation_S3_Encryption_KMSKeyId;
            }
            if (requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption.KMSKeyId = requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSKeyId;
                requestOutputLocation_outputLocation_S3_outputLocation_S3_EncryptionIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext = null;
            if (cmdletContext.OutputLocation_S3_Encryption_KMSContext != null)
            {
                requestOutputLocation_outputLocation_S3_outputLocation_S3_Encryption_encryption_KMSContext = cmdletContext.OutputLocation_S3_Encryption_KMSContext;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service", "RestoreObject");
            try
            {
                #if DESKTOP
                return client.RestoreObject(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RestoreObjectAsync(request);
                return task.Result;
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
            public System.String Key { get; set; }
            public System.Int32? CopyLifetimeInDays { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public Amazon.S3.GlacierJobTier Tier { get; set; }
            public Amazon.S3.GlacierJobTier RetrievalTier { get; set; }
            public Amazon.S3.RestoreRequestType RestoreRequestType { get; set; }
            public System.String Description { get; set; }
            public Amazon.S3.Model.SelectParameters SelectParameters { get; set; }
            public System.String OutputLocation_S3_BucketName { get; set; }
            public System.String OutputLocation_S3_Prefix { get; set; }
            public Amazon.S3.ServerSideEncryptionMethod OutputLocation_S3_Encryption_EncryptionType { get; set; }
            public System.String OutputLocation_S3_Encryption_KMSKeyId { get; set; }
            public System.String OutputLocation_S3_Encryption_KMSContext { get; set; }
            public Amazon.S3.S3CannedACL OutputLocation_S3_CannedACL { get; set; }
            public System.String OutputLocation_S3_AccessControlList_Owner_DisplayName { get; set; }
            public System.String OutputLocation_S3_AccessControlList_Owner_Id { get; set; }
            public List<Amazon.S3.Model.S3Grant> OutputLocation_S3_AccessControlList_Grants { get; set; }
            public List<Amazon.S3.Model.Tag> OutputLocation_S3_Tagging_TagSet { get; set; }
            public Amazon.S3.Model.MetadataCollection OutputLocation_S3_UserMetadata { get; set; }
            public Amazon.S3.S3StorageClass OutputLocation_S3_StorageClass { get; set; }
        }
        
    }
}
