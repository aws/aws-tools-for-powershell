/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.IO;
using Amazon.PowerShell.Utils;
using System.Collections;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Makes a copy of an S3 object to another S3 object or to the local file system
    /// </summary>
    [Cmdlet("Copy", "S3Object", DefaultParameterSetName = ToLocalFileParamSet, SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType(new[] { typeof(CopyObjectResponse), typeof(FileInfo) })]
    [AWSCmdlet("Invokes the CopyObject operation to copy an existing S3 object to another S3 destination (bucket and/or object) "
                    + "or uses the TransferUtility to download the S3 object to a local file or folder.",
                    Operation = new [] {"CopyObject"})]
    [AWSCmdletOutput("Amazon.S3.Model.CopyObjectResponse or System.IO.FileInfo",
        "This cmdlet returns an Amazon.S3.Model.CopyObjectResponse instance from the service when copying to another S3 object. "
            + " When copying from S3 to the local file system, the cmdlet returns a FileInfo instance representing the local file.",
        "The service response (type Amazon.S3.Model.CopyObjectResponse) is also added to the cmdlet entry in the $AWSHistory stack regardless of S3->S3 or S3->local file copy mode."
    )]
    public class CopyS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        const string ToLocalFileParamSet = "ToLocalFileParamSet";
        const string ToLocalFolderParamSet = "ToLocalFolderParameterSet";
        const string S3toS3ParamSet = "S3toS3ParamSet";

        #region Parameter BucketName
        /// <summary>
        /// The name of the bucket containing the source object.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SourceBucket")]
        public System.String BucketName { get; set; }
        #endregion

        #region Parameter Key
        /// <summary>
        /// The key of the source object to copy.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Alias("SourceKey")]
        public System.String Key { get; set; }
        #endregion

        #region Parameter VersionId
        /// <summary>
        /// Specifies the version of the source object to copy.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SourceVersionId")]
        public System.String VersionId { get; set; }
        #endregion

        #region Copy to S3 Target Parameters

        #region Parameter DestinationKey
        /// <summary>
        /// The key for the copy of the source S3 object.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = S3toS3ParamSet, Mandatory=true)]
        public System.String DestinationKey { get; set; }
        #endregion

        #region Parameter DestinationBucket
        /// <summary>
        /// The name of the bucket that will contain the copied object. If not specified,
        /// the copy is to another S3 object in the source bucket.
        /// </summary>
        [Parameter(Position = 3, ParameterSetName = S3toS3ParamSet)]
        public System.String DestinationBucket { get; set; }
        #endregion

        #region Parameter MetadataDirective
        /// <summary>
        /// Specifies whether the metadata is copied from the source object or replaced with metadata provided in the request.
        /// Valid values are COPY or REPLACE. COPY is the default if not specified.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public Amazon.S3.S3MetadataDirective MetadataDirective { get; set; }
        #endregion

        #region Parameter ContentType
        /// <summary>
        /// Sets the content type of the target object; if not specified an attempt is made to infer it using the destination
        /// or source object keys.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public System.String ContentType { get; set; }
        #endregion

        #region Parameter CannedACLName
        /// <summary>
        /// Specifies the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <a href="http://docs.aws.amazon.com/sdkfornet/v3/apidocs/Index.html?page=S3/TS3_S3CannedACL.html&tocid=Amazon_S3_S3CannedACL">Amazon.S3.Model.S3CannedACL</a> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        [AWSConstantClassSource("Amazon.S3.S3CannedACL")]
        public Amazon.S3.S3CannedACL CannedACLName { get; set; }
        #endregion

        #region Parameter PublicReadOnly
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public SwitchParameter PublicReadOnly { get; set; }
        #endregion

        #region Parameter PublicReadWrite
        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public SwitchParameter PublicReadWrite { get; set; }
        #endregion

        #region Parameter StorageClass

        // NOTE: This parameter does not use the marker attribute for automated validate set
        // updating because it would cause GLACIER to be added as a valid value. S3 does not
        // support use of GLACIER as a storage class on PutObject, it must be handled as a
        // lifecycle configuration
        // http://docs.aws.amazon.com/AmazonS3/latest/API/RESTObjectPUT.html

        /// <summary>
        /// Specifies the storage class for the object.
        /// Please refer to <a href="http://docs.aws.amazon.com/AmazonS3/latest/dev/storage-class-intro.html">Storage Classes</a> for information on S3 storage classes.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public Amazon.S3.S3StorageClass StorageClass { get; set; }
        #endregion

        #region Parameter StandardStorage
        /// <summary>
        /// Specifies the STANDARD storage class, which is the default storage class for S3 objects.
        /// Provides a 99.999999999% durability guarantee.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public SwitchParameter StandardStorage { get; set; }
        #endregion

        #region Parameter ReducedRedundancyStorage
        /// <summary>
        /// Specifies S3 should use REDUCED_REDUNDANCY storage class for the object. This
        /// provides a reduced (99.99%) durability guarantee at a lower
        /// cost as compared to the STANDARD storage class. Use this
        /// storage class for non-mission critical data or for data
        /// that doesn’t require the higher level of durability that S3
        /// provides with the STANDARD storage class.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public SwitchParameter ReducedRedundancyStorage { get; set; }
        #endregion

        #region Parameter ServerSideEncryption
        /// <summary>
        /// Specifies the encryption used on the server to store the content.
        /// Allowable values: None, AES256, aws:kms.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryption { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionKeyManagementServiceKeyId
        /// <summary>
        /// Specifies the AWS KMS key for Amazon S3 to use to encrypt the object.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public System.String ServerSideEncryptionKeyManagementServiceKeyId { get; set; }
        #endregion

        #region Parameter WebsiteRedirectLocation
        /// <summary>
        /// If this is set then when a GET request is made from the S3 website endpoint a 301 HTTP status code
        /// will be returned indicating a redirect with this value as the redirect location.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public System.String WebsiteRedirectLocation { get; set; }
        #endregion

        #region Parameter Metadata
        /// <summary>
        /// Metadata headers to set on the object.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion

        #region Parameter HeaderCollection
        /// <summary>
        /// Response headers to set on the object.
        /// </summary>
        [Parameter(ParameterSetName = S3toS3ParamSet)]
        [Alias("Headers")]
        public System.Collections.Hashtable HeaderCollection { get; set; }
        #endregion

        #endregion

        #region Copy to Local File Parameters

        #region Parameter LocalFile
        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = ToLocalFileParamSet, Mandatory = true)]
        [Alias("File")]
        public System.String LocalFile { get; set; }
        #endregion

        #endregion

        #region Copy to Local Folder Parameters

        #region Parameter LocalFolder
        /// <summary>
        /// <para>
        /// The path to a local folder that will contain the downloaded object. If a relative path
        /// is supplied, it will be resolved to a full path using the current session's location.
        /// </para>
        /// <para>
        /// When copying to a local folder the object key is used as the filename. Note that object
        /// keys that are not valid filenames for the host system could cause an exception to be thrown.
        /// </para>
        /// </summary>
        [Parameter(ParameterSetName = ToLocalFolderParamSet, Mandatory = true)]
        [Alias("Folder")]
        public System.String LocalFolder { get; set; }
        #endregion

        #endregion

        #region Parameter ETagToMatch
        /// <summary>
        /// Copies the object if its entity tag (ETag) matches the specified tag; otherwise return a PreconditionFailed.
        /// </summary>
        [Parameter]
        public System.String ETagToMatch { get; set; }
        #endregion

        #region Parameter ETagToNotMatch
        /// <summary>
        /// Copies the object if its entity tag (ETag) is different than the specified Etag; otherwise returns an error.
        /// </summary>
        [Parameter]
        public System.String ETagToNotMatch { get; set; }
        #endregion

        #region Parameter ModifiedSinceDate
        /// <summary>
        /// Copies the object if it has been modified since the specified time; otherwise returns an error.
        /// </summary>
        [Parameter]
        public System.DateTime ModifiedSinceDate { get; set; }
        #endregion

        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// Copies the object if it hasn't been modified since the specified time; otherwise returns a PreconditionFailed.
        /// </summary>
        [Parameter]
        public System.DateTime UnmodifiedSinceDate { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm used on the source object with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod CopySourceServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 used on the source object.
        /// </summary>
        [Parameter]
        public System.String CopySourceServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter CopySourceServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 used on the source object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter]
        public System.String CopySourceServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion

        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }
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

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.Key, "Copy-S3Object (CopyObject)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials,
                SourceBucket = this.BucketName,
                SourceKey = this.Key,
                SourceVersionId = this.VersionId,
                DestinationBucket = this.DestinationBucket,
                DestinationKey = this.DestinationKey,
                ContentType = this.ContentType,
                ETagToMatch = this.ETagToMatch,
                ETagToNotMatch = this.ETagToNotMatch,
                WebsiteRedirectLocation = this.WebsiteRedirectLocation,

                ServerSideEncryptionKeyManagementServiceKeyId = this.ServerSideEncryptionKeyManagementServiceKeyId,

                ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod,
                ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey,
                ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5,

                CopySourceServerSideEncryptionCustomerMethod = this.CopySourceServerSideEncryptionCustomerMethod,
                CopySourceServerSideEncryptionCustomerProvidedKey = this.CopySourceServerSideEncryptionCustomerProvidedKey,
                CopySourceServerSideEncryptionCustomerProvidedKeyMD5 = this.CopySourceServerSideEncryptionCustomerProvidedKeyMD5,

                Metadata = this.Metadata,
                Headers = this.HeaderCollection
            };

            if (this.ParameterSetName == ToLocalFileParamSet)
            {
                context.LocalFile = this.LocalFile;
            }
            else if (this.ParameterSetName == ToLocalFolderParamSet)
            {
                var path = PSHelpers.PSPathToAbsolute(this.SessionState.Path, this.LocalFolder);
                context.LocalFile = Path.Combine(path, this.Key);
            }

            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                UnmodifiedSinceDate = this.UnmodifiedSinceDate;

            if (ParameterWasBound("MetadataDirective"))
                context.MetadataDirective = this.MetadataDirective;

            if (!string.IsNullOrEmpty(this.CannedACLName))
            {
                context.CannedACL = this.CannedACLName;
            }
            else if (this.PublicReadOnly.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicRead;
            }
            else if (this.PublicReadWrite.IsPresent)
            {
                context.CannedACL = S3CannedACL.PublicReadWrite;
            }

            if (ParameterWasBound("StorageClass"))
                context.StorageClass = this.StorageClass;
            else
            {
                if (this.StandardStorage.IsPresent)
                    context.StorageClass = S3StorageClass.Standard;
                else if (this.ReducedRedundancyStorage.IsPresent)
                    context.StorageClass = S3StorageClass.ReducedRedundancy;
            }

            if (!string.IsNullOrEmpty(this.ServerSideEncryption))
            {
                context.ServerSideEncryptionMethod = Amazon.PowerShell.Utils.Common.Convert(this.ServerSideEncryption);
            }

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }

        #region IExecutor Members

        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            if (!string.IsNullOrEmpty(cmdletContext.LocalFile))
                return CopyS3ObjectToLocalFile(context);
            else
                return CopyS3ObjectToS3(context);
        }

        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }

        #endregion

        object CopyS3ObjectToS3(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;

            var request = new CopyObjectRequest();

            if (cmdletContext.SourceBucket != null)
                request.SourceBucket = cmdletContext.SourceBucket;
            if (cmdletContext.SourceKey != null)
                request.SourceKey = cmdletContext.SourceKey;
            if (cmdletContext.SourceVersionId != null)
                request.SourceVersionId = cmdletContext.SourceVersionId;

            if (cmdletContext.DestinationBucket != null)
                request.DestinationBucket = cmdletContext.DestinationBucket;
            else
                request.DestinationBucket = cmdletContext.SourceBucket;
            if (cmdletContext.DestinationKey != null)
                request.DestinationKey = cmdletContext.DestinationKey;

            if (cmdletContext.ContentType != null)
                request.ContentType = cmdletContext.ContentType;
            if (cmdletContext.ETagToMatch != null)
                request.ETagToMatch = cmdletContext.ETagToMatch;
            if (cmdletContext.ETagToNotMatch != null)
                request.ETagToNotMatch = cmdletContext.ETagToNotMatch;
            if (cmdletContext.ModifiedSinceDate != null)
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            if (cmdletContext.UnmodifiedSinceDate != null)
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            if (cmdletContext.MetadataDirective != null)
                request.MetadataDirective = cmdletContext.MetadataDirective.Value;
            if (cmdletContext.CannedACL != null)
                request.CannedACL = cmdletContext.CannedACL.Value;
            if (cmdletContext.StorageClass != null)
                request.StorageClass = cmdletContext.StorageClass.Value;
            if (cmdletContext.ServerSideEncryptionMethod != null)
                request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod.Value;
            if (cmdletContext.WebsiteRedirectLocation != null)
                request.WebsiteRedirectLocation = cmdletContext.WebsiteRedirectLocation;
            if (cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId != null)
                request.ServerSideEncryptionKeyManagementServiceKeyId = cmdletContext.ServerSideEncryptionKeyManagementServiceKeyId;

            request.CopySourceServerSideEncryptionCustomerMethod = cmdletContext.CopySourceServerSideEncryptionCustomerMethod;
            request.CopySourceServerSideEncryptionCustomerProvidedKey = cmdletContext.CopySourceServerSideEncryptionCustomerProvidedKey;
            request.CopySourceServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.CopySourceServerSideEncryptionCustomerProvidedKeyMD5;

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            AmazonS3Helper.SetMetadataAndHeaders(request, cmdletContext.Metadata, cmdletContext.Headers);

            // issue call
            using (var client = Client ?? CreateClient(context.Credentials, context.Region))
            {
                CmdletOutput output;
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    output = new CmdletOutput
                    {
                        PipelineOutput = response,
                        ServiceResponse = response
                    };
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }

                return output;
            }
        }

        object CopyS3ObjectToLocalFile(ExecutorContext context)
        {
            // Adapted from Read-S3Object's single file mode
            var cmdletContext = context as CmdletContext;
            var request = new TransferUtilityDownloadRequest();

            request.BucketName = cmdletContext.SourceBucket;
            request.FilePath = cmdletContext.LocalFile;
            request.Key = cmdletContext.SourceKey;
            if (!string.IsNullOrEmpty(cmdletContext.SourceVersionId))
                request.VersionId = cmdletContext.SourceVersionId;
            if (cmdletContext.ModifiedSinceDate.HasValue)
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            if (cmdletContext.UnmodifiedSinceDate.HasValue)
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;

            request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;

            CmdletOutput output;
            using (var tu = new TransferUtility(Client ?? CreateClient(context.Credentials, context.Region)))
            {
                var runner = new ProgressRunner(this);
                var tracker = new ReadS3ObjectCmdlet.DownloadFileProgressTracker(runner, handler => request.WriteObjectProgressEvent += handler, cmdletContext.SourceKey);

                output = runner.SafeRun(() => tu.Download(request), tracker);
                if (output.ErrorResponse == null)
                    output.PipelineOutput = new FileInfo(cmdletContext.LocalFile);
            }

            return output;
        }

        #region AWS Service Operation Call

        private static Amazon.S3.Model.CopyObjectResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.CopyObjectRequest request)
        {
#if DESKTOP
            return client.CopyObject(request);
#elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CopyObjectAsync(request);
            return task.Result;
#else
#error "Unknown build edition"
#endif
        }

        #endregion

        internal class CmdletContext : ExecutorContext
        {
            public String SourceBucket { get; set; }
            public String SourceKey { get; set; }
            public String DestinationBucket { get; set; }
            public String DestinationKey { get; set; }
            public String LocalFile { get; set; }
            public String ContentType { get; set; }
            public String ETagToMatch { get; set; }
            public String ETagToNotMatch { get; set; }
            public DateTime? ModifiedSinceDate { get; set; }
            public DateTime? UnmodifiedSinceDate { get; set; }
            public S3MetadataDirective? MetadataDirective { get; set; }
            public S3CannedACL CannedACL { get; set; }
            public String SourceVersionId { get; set; }
            public S3StorageClass StorageClass { get; set; }
            public ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
            public string ServerSideEncryptionKeyManagementServiceKeyId { get; set; }

            public ServerSideEncryptionCustomerMethod CopySourceServerSideEncryptionCustomerMethod { get; set; }
            public string CopySourceServerSideEncryptionCustomerProvidedKey { get; set; }
            public string CopySourceServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public string ServerSideEncryptionCustomerProvidedKey { get; set; }
            public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

            public Hashtable Metadata { get; set; }
            public Hashtable Headers { get; set; }

            public String WebsiteRedirectLocation { get; set; }
        }
    }
}
