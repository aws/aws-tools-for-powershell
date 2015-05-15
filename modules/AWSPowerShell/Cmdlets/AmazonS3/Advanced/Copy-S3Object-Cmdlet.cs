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
    [Cmdlet("Copy", "S3Object", DefaultParameterSetName = "LocalFileParamSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType(new[] { typeof(CopyObjectResponse), typeof(FileInfo) })]
    [AWSCmdlet("Invokes the CopyObject operation to copy an existing S3 object to another S3 destination (bucket and/or object) "
                    + "or uses the TransferUtility to download the S3 object to a local file.",
                    Operation = new [] {"CopyObject"})]
    [AWSCmdletOutput("Amazon.S3.Model.CopyObjectResponse or System.IO.FileInfo",
        "This cmdlet returns a CopyObjectResponse instance from the service when copying to another S3 object. "
            + " When copying from S3 to the local file system, the cmdlet returns a FileInfo instance representing the local file.",
        "The service response (type CopyObjectResponse) is also added to the cmdlet entry in the $AWSHistory stack regardless of S3->S3 or S3->local file copy mode."
    )]
    public class CopyS3ObjectCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        /// <summary>
        /// The name of the bucket containing the source object.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SourceBucket")]
        public String BucketName { get; set; }

        /// <summary>
        /// The key of the source object to copy.
        /// </summary>
        [Parameter(Position = 1, Mandatory = true)]
        [Alias("SourceKey")]
        public String Key { get; set; }

        /// <summary>
        /// Specifies the version of the source object to copy.
        /// </summary>
        [Parameter]
        [Alias("SourceVersionId")]
        public String VersionId { get; set; }

        #region Copy to S3 Target Parameters

        /// <summary>
        /// The key for the copy of the source S3 object.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = "S3toS3ParamSet", Mandatory=true)]
        public String DestinationKey { get; set; }

        /// <summary>
        /// The name of the bucket that will contain the copied object. If not specified,
        /// the copy is to another S3 object in the source bucket.
        /// </summary>
        [Parameter(Position = 3, ParameterSetName = "S3toS3ParamSet")]
        public String DestinationBucket { get; set; }

        /// <summary>
        /// Specifies whether the metadata is copied from the source object or replaced with metadata provided in the request.
        /// Valid values are COPY or REPLACE. COPY is the default if not specified.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public string MetadataDirective { get; set; }

        /// <summary>
        /// Sets the content type of the target object; if not specified an attempt is made to infer it using the destination
        /// or source object keys.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public String ContentType { get; set; }

        /// <summary>
        /// Specifies the canned ACL (access control list) of permissions to be applied to the S3 bucket.
        /// Please refer to <see cref="T:Amazon.S3.Model.S3CannedACL" /> for information on S3 Canned ACLs.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public string CannedACLName { get; set; }

        /// <summary>
        /// If set, applies an ACL making the bucket public with read-only permissions
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public SwitchParameter PublicReadOnly { get; set; }

        /// <summary>
        /// If set, applies an ACL making the bucket public with read-write permissions
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public SwitchParameter PublicReadWrite { get; set; }

        /// <summary>
        /// Specifies the STANDARD storage class, which is the default storage class for S3 objects.
        /// Provides a 99.999999999% durability guarantee.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public SwitchParameter StandardStorage { get; set; }

        /// <summary>
        /// Specifies S3 should use REDUCED_REDUNDANCY storage class for the object. This
        /// provides a reduced (99.99%) durability guarantee at a lower
        /// cost as compared to the STANDARD storage class. Use this
        /// storage class for non-mission critical data or for data
        /// that doesn’t require the higher level of durability that S3
        /// provides with the STANDARD storage class.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public SwitchParameter ReducedRedundancyStorage { get; set; }

        /// <summary>
        /// Specifies the encryption used on the server to store the content.
        /// Allowable values: None, AES256, AWSKMS.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public string ServerSideEncryption { get; set; }

        /// <summary>
        /// Specifies the AWS KMS key for Amazon S3 to use to encrypt the object.
        /// </summary>
        [Parameter]
        public string ServerSideEncryptionKeyManagementServiceKeyId { get; set; }

        /// <summary>
        /// Gets and sets the WebsiteRedirectLocation property.
        /// If this is set then when a GET request is made from the S3 website endpoint a 301 HTTP status code
        /// will be returned indicating a redirect with this value as the redirect location.
        /// </summary>
        [Parameter(ParameterSetName = "S3toS3ParamSet")]
        public String WebsiteRedirectLocation { get; set; }

        /// <summary>
        /// Metadata headers to set on the object.
        /// </summary>
        [Parameter]
        public Hashtable Metadata { get; set; }

        /// <summary>
        /// Response headers to set on the object.
        /// </summary>
        [Parameter]
        [Alias("Headers")]
        public Hashtable HeaderCollection { get; set; }

        #endregion

        #region Copy to Local File Parameters

        /// <summary>
        /// The full path to the local file that will be created.
        /// </summary>
        [Parameter(Position = 2, ParameterSetName = "LocalFileParamSet", Mandatory = true)]
        public String LocalFile { get; set; }

        #endregion

        /// <summary>
        /// Copies the object if its entity tag (ETag) matches the specified tag; otherwise return a PreconditionFailed.
        /// </summary>
        [Parameter]
        public String ETagToMatch { get; set; }

        /// <summary>
        /// Copies the object if its entity tag (ETag) is different than the specified Etag; otherwise returns an error.
        /// </summary>
        [Parameter]
        public String ETagToNotMatch { get; set; }

        /// <summary>
        /// Copies the object if it has been modified since the specified time; otherwise returns an error.
        /// </summary>
        [Parameter]
        public DateTime ModifiedSinceDate { get; set; }

        /// <summary>
        /// Copies the object if it hasn't been modified since the specified time; otherwise returns a PreconditionFailed.
        /// </summary>
        [Parameter]
        public DateTime UnmodifiedSinceDate { get; set; }

        /// <summary>
        /// Specifies the server-side encryption algorithm used on the source object with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter]
        public string CopySourceServerSideEncryptionCustomerMethod { get; set; }

        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 used on the source object.
        /// </summary>
        [Parameter]
        public string CopySourceServerSideEncryptionCustomerProvidedKey { get; set; }

        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 used on the source object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter]
        public string CopySourceServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

        /// <summary>
        /// Specifies the server-side encryption algorithm to be used with the customer provided key.
        /// Allowable values: None or AES256.
        /// </summary>
        [Parameter]
        public string ServerSideEncryptionCustomerMethod { get; set; }

        /// <summary>
        /// Specifies base64-encoded encryption key for Amazon S3 to use to decrypt the object.
        /// </summary>
        [Parameter]
        public string ServerSideEncryptionCustomerProvidedKey { get; set; }

        /// <summary>
        /// Specifies base64-encoded MD5 of the encryption key for Amazon S3 to use to decrypt the object. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </summary>
        [Parameter]
        public string ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

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
                LocalFile = this.LocalFile,
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

            if (ParameterWasBound("ModifiedSinceDate"))
                context.ModifiedSinceDate = this.ModifiedSinceDate;
            if (ParameterWasBound("UnmodifiedSinceDate"))
                UnmodifiedSinceDate = this.UnmodifiedSinceDate;

            if (!string.IsNullOrEmpty(this.MetadataDirective))
            {
                try
                {
                    context.MetadataDirective = (S3MetadataDirective)Enum.Parse(typeof(S3MetadataDirective), this.MetadataDirective, true);
                }
                catch (ArgumentException e)
                {
                    string errMsg = "Invalid S3MetadataDirective value; allowable values: " + string.Join(", ", Enum.GetNames(typeof(S3MetadataDirective)));
                    ThrowArgumentError(errMsg, this.MetadataDirective, e);
                }
            }

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

            if (this.StandardStorage.IsPresent)
            {
                context.StorageClass = S3StorageClass.Standard;
            }
            else if (this.ReducedRedundancyStorage.IsPresent)
            {
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
                    var response = client.CopyObject(request);
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
