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
    /// Passes transformed objects to a <code>GetObject</code> operation when using Object
    /// Lambda Access Points. For information about Object Lambda Access Points, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/transforming-objects.html">Transforming
    /// objects with Object Lambda Access Points</a> in the <i>Amazon S3 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// This operation supports metadata that can be returned by <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a>,
    /// in addition to <code>RequestRoute</code>, <code>RequestToken</code>, <code>StatusCode</code>,
    /// <code>ErrorCode</code>, and <code>ErrorMessage</code>. The <code>GetObject</code>
    /// response metadata is supported so that the <code>WriteGetObjectResponse</code> caller,
    /// typically an AWS Lambda function, can provide the same metadata when it internally
    /// invokes <code>GetObject</code>. When <code>WriteGetObjectResponse</code> is called
    /// by a customer-owned Lambda function, the metadata returned to the end user <code>GetObject</code>
    /// call might differ from what Amazon S3 would normally return.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "S3GetObjectResponse", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) WriteGetObjectResponse API operation.", Operation = new[] {"WriteGetObjectResponse"}, SelectReturnType = typeof(Amazon.S3.Model.WriteGetObjectResponseResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.WriteGetObjectResponseResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.WriteGetObjectResponseResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3GetObjectResponseCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptRange
        /// <summary>
        /// <para>
        /// Indicates that a range of bytes was specified.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceptRanges")]
        public System.String AcceptRange { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The object data</para>.
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public object Body { get; set; }
        #endregion
        
        #region Parameter BucketKeyEnabled
        /// <summary>
        /// <para>
        /// Indicates whether the object stored in Amazon S3 uses a S3 Bucket Key for server-side encryption with AWS KMS (SSE-KMS).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BucketKeyEnabled { get; set; }
        #endregion
        
        #region Parameter CacheControl
        /// <summary>
        /// <para>
        /// Specifies caching behavior along the request/reply chain.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheControl { get; set; }
        #endregion
        
        #region Parameter ContentDisposition
        /// <summary>
        /// <para>
        /// Specifies presentational information for the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentDisposition { get; set; }
        #endregion
        
        #region Parameter ContentEncoding
        /// <summary>
        /// <para>
        /// Specifies what content encodings have been applied to the object and thus what decoding mechanisms must be applied to obtain the media-type referenced by the Content-Type header field.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentEncoding { get; set; }
        #endregion
        
        #region Parameter ContentLanguage
        /// <summary>
        /// <para>
        /// The language the content is in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentLanguage { get; set; }
        #endregion
        
        #region Parameter ContentLength
        /// <summary>
        /// <para>
        /// The size of the body in bytes.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ContentLength { get; set; }
        #endregion
        
        #region Parameter ContentRange
        /// <summary>
        /// <para>
        /// The portion of the object returned in the response.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentRange { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// A standard MIME type describing the format of the object data.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter DeleteMarker
        /// <summary>
        /// <para>
        /// Specifies whether an object stored in Amazon S3 is (<code>true</code>) or is not (<code>false</code>) a delete marker.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteMarker { get; set; }
        #endregion
        
        #region Parameter ErrorCode
        /// <summary>
        /// <para>
        /// A string that uniquely identifies an error condition. Returned in &lt;Code&gt; tag of error XML response for corresponding GetObject call. Cannot be used with successful <code>StatusCode</code> header or when transformed object is provided in body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ErrorCode { get; set; }
        #endregion
        
        #region Parameter ErrorMessage
        /// <summary>
        /// <para>
        /// Contains a generic description of the error condition. Returned in &lt;Message&gt; tag of error XML response for corresponding GetObject call. Cannot be used with successful <code>StatusCode</code> header or when transformed object is provided in body.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ErrorMessage { get; set; }
        #endregion
        
        #region Parameter Expiration
        /// <summary>
        /// <para>
        /// If object stored in Amazon S3 expiration is configured (see PUT Bucket lifecycle) it includes expiry-date and rule-id key-value pairs providing object expiration information. The value of the rule-id is URL encoded.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Expiration { get; set; }
        #endregion
        
        #region Parameter Expire
        /// <summary>
        /// <para>
        /// The date and time at which the object is no longer cacheable.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Expires")]
        public System.DateTime? Expire { get; set; }
        #endregion
        
        #region Parameter LastModified
        /// <summary>
        /// <para>
        /// Date and time the object was last modified.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? LastModified { get; set; }
        #endregion
        
        #region Parameter MissingMeta
        /// <summary>
        /// <para>
        /// Set to the number of metadata entries not returned in <code>x-amz-meta</code> headers. This can happen if you create metadata using an API like SOAP that supports more flexible metadata than the REST API. For example, using SOAP, you can create metadata whose values are not legal HTTP headers.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MissingMeta { get; set; }
        #endregion
        
        #region Parameter ObjectLockLegalHoldStatus
        /// <summary>
        /// <para>
        /// Indicates whether object stored in Amazon S3 has an active legal hold.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ObjectLockLegalHoldStatus")]
        public Amazon.S3.ObjectLockLegalHoldStatus ObjectLockLegalHoldStatus { get; set; }
        #endregion
        
        #region Parameter ObjectLockMode
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.WriteGetObjectResponseRequest.ObjectLockMode
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ObjectLockMode")]
        public Amazon.S3.ObjectLockMode ObjectLockMode { get; set; }
        #endregion
        
        #region Parameter ObjectLockRetainUntilDate
        /// <summary>
        /// <para>
        /// Date and time when Object Lock is configured to expire.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ObjectLockRetainUntilDate { get; set; }
        #endregion
        
        #region Parameter PartsCount
        /// <summary>
        /// <para>
        /// The count of parts this object has.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartsCount { get; set; }
        #endregion
        
        #region Parameter ReplicationStatus
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.WriteGetObjectResponseRequest.ReplicationStatus
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ReplicationStatus")]
        public Amazon.S3.ReplicationStatus ReplicationStatus { get; set; }
        #endregion
        
        #region Parameter RequestCharged
        /// <summary>
        /// <para>
        /// If present, indicates that the requester was successfully charged for the request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestCharged")]
        public Amazon.S3.RequestCharged RequestCharged { get; set; }
        #endregion
        
        #region Parameter RequestRoute
        /// <summary>
        /// <para>
        /// Route prefix to the HTTP URL generated.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestRoute { get; set; }
        #endregion
        
        #region Parameter RequestToken
        /// <summary>
        /// <para>
        /// A single use encrypted token that maps <code>WriteGetObjectResponse</code> to the end user <code>GetObject</code> request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestToken { get; set; }
        #endregion
        
        #region Parameter Restore
        /// <summary>
        /// <para>
        /// Provides information about object restoration operation and expiration time of the restored object copy.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Restore { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionMethod
        /// <summary>
        /// <para>
        /// The server-side encryption algorithm used when storing requested object in Amazon S3 (for example, AES256, aws:kms).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionMethod")]
        public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
        #endregion
        
        #region Parameter SSECustomerAlgorithm
        /// <summary>
        /// <para>
        /// Encryption algorithm used if server-side encryption with a customer-provided encryption key was specified for object stored in Amazon S3.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod SSECustomerAlgorithm { get; set; }
        #endregion
        
        #region Parameter SSECustomerKeyMD5
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.WriteGetObjectResponseRequest.SSECustomerKeyMD5
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSECustomerKeyMD5 { get; set; }
        #endregion
        
        #region Parameter SSEKMSKeyId
        /// <summary>
        /// <para>
        /// If present, specifies the ID of the AWS Key Management Service (AWS KMS) symmetric customer managed customer master key (CMK) that was used for stored in Amazon S3 object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSEKMSKeyId { get; set; }
        #endregion
        
        #region Parameter StatusCode
        /// <summary>
        /// <para>
        /// Amazon.S3.Model.WriteGetObjectResponseRequest.StatusCode
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StatusCode { get; set; }
        #endregion
        
        #region Parameter StorageClass
        /// <summary>
        /// <para>
        /// The class of storage used to store object in Amazon S3.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.S3StorageClass")]
        public Amazon.S3.S3StorageClass StorageClass { get; set; }
        #endregion
        
        #region Parameter TagCount
        /// <summary>
        /// <para>
        /// The number of tags, if any, on the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TagCount { get; set; }
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
        
        #region Parameter ETag
        /// <summary>
        /// <para>
        /// An ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ETag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.WriteGetObjectResponseResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3GetObjectResponse (WriteGetObjectResponse)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.WriteGetObjectResponseResponse, WriteS3GetObjectResponseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RequestRoute = this.RequestRoute;
            context.RequestToken = this.RequestToken;
            context.StatusCode = this.StatusCode;
            context.ErrorCode = this.ErrorCode;
            context.ErrorMessage = this.ErrorMessage;
            context.AcceptRange = this.AcceptRange;
            context.CacheControl = this.CacheControl;
            context.ContentDisposition = this.ContentDisposition;
            context.ContentEncoding = this.ContentEncoding;
            context.ContentLanguage = this.ContentLanguage;
            context.ContentLength = this.ContentLength;
            context.ContentRange = this.ContentRange;
            context.ContentType = this.ContentType;
            context.DeleteMarker = this.DeleteMarker;
            context.ETag = this.ETag;
            context.Expire = this.Expire;
            context.Expiration = this.Expiration;
            context.LastModified = this.LastModified;
            context.MissingMeta = this.MissingMeta;
            context.ObjectLockMode = this.ObjectLockMode;
            context.ObjectLockLegalHoldStatus = this.ObjectLockLegalHoldStatus;
            context.ObjectLockRetainUntilDate = this.ObjectLockRetainUntilDate;
            context.PartsCount = this.PartsCount;
            context.ReplicationStatus = this.ReplicationStatus;
            context.RequestCharged = this.RequestCharged;
            context.Restore = this.Restore;
            context.ServerSideEncryptionMethod = this.ServerSideEncryptionMethod;
            context.SSECustomerAlgorithm = this.SSECustomerAlgorithm;
            context.SSEKMSKeyId = this.SSEKMSKeyId;
            context.SSECustomerKeyMD5 = this.SSECustomerKeyMD5;
            context.StorageClass = this.StorageClass;
            context.TagCount = this.TagCount;
            context.VersionId = this.VersionId;
            context.BucketKeyEnabled = this.BucketKeyEnabled;
            context.Body = this.Body;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.S3.Model.WriteGetObjectResponseRequest();
                
                if (cmdletContext.RequestRoute != null)
                {
                    request.RequestRoute = cmdletContext.RequestRoute;
                }
                if (cmdletContext.RequestToken != null)
                {
                    request.RequestToken = cmdletContext.RequestToken;
                }
                if (cmdletContext.StatusCode != null)
                {
                    request.StatusCode = cmdletContext.StatusCode.Value;
                }
                if (cmdletContext.ErrorCode != null)
                {
                    request.ErrorCode = cmdletContext.ErrorCode;
                }
                if (cmdletContext.ErrorMessage != null)
                {
                    request.ErrorMessage = cmdletContext.ErrorMessage;
                }
                if (cmdletContext.AcceptRange != null)
                {
                    request.AcceptRanges = cmdletContext.AcceptRange;
                }
                if (cmdletContext.CacheControl != null)
                {
                    request.CacheControl = cmdletContext.CacheControl;
                }
                if (cmdletContext.ContentDisposition != null)
                {
                    request.ContentDisposition = cmdletContext.ContentDisposition;
                }
                if (cmdletContext.ContentEncoding != null)
                {
                    request.ContentEncoding = cmdletContext.ContentEncoding;
                }
                if (cmdletContext.ContentLanguage != null)
                {
                    request.ContentLanguage = cmdletContext.ContentLanguage;
                }
                if (cmdletContext.ContentLength != null)
                {
                    request.ContentLength = cmdletContext.ContentLength.Value;
                }
                if (cmdletContext.ContentRange != null)
                {
                    request.ContentRange = cmdletContext.ContentRange;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.DeleteMarker != null)
                {
                    request.DeleteMarker = cmdletContext.DeleteMarker.Value;
                }
                if (cmdletContext.ETag != null)
                {
                    request.ETag = cmdletContext.ETag;
                }
                if (cmdletContext.Expire != null)
                {
                    request.Expires = cmdletContext.Expire.Value;
                }
                if (cmdletContext.Expiration != null)
                {
                    request.Expiration = cmdletContext.Expiration;
                }
                if (cmdletContext.LastModified != null)
                {
                    request.LastModified = cmdletContext.LastModified.Value;
                }
                if (cmdletContext.MissingMeta != null)
                {
                    request.MissingMeta = cmdletContext.MissingMeta.Value;
                }
                if (cmdletContext.ObjectLockMode != null)
                {
                    request.ObjectLockMode = cmdletContext.ObjectLockMode;
                }
                if (cmdletContext.ObjectLockLegalHoldStatus != null)
                {
                    request.ObjectLockLegalHoldStatus = cmdletContext.ObjectLockLegalHoldStatus;
                }
                if (cmdletContext.ObjectLockRetainUntilDate != null)
                {
                    request.ObjectLockRetainUntilDate = cmdletContext.ObjectLockRetainUntilDate.Value;
                }
                if (cmdletContext.PartsCount != null)
                {
                    request.PartsCount = cmdletContext.PartsCount.Value;
                }
                if (cmdletContext.ReplicationStatus != null)
                {
                    request.ReplicationStatus = cmdletContext.ReplicationStatus;
                }
                if (cmdletContext.RequestCharged != null)
                {
                    request.RequestCharged = cmdletContext.RequestCharged;
                }
                if (cmdletContext.Restore != null)
                {
                    request.Restore = cmdletContext.Restore;
                }
                if (cmdletContext.ServerSideEncryptionMethod != null)
                {
                    request.ServerSideEncryptionMethod = cmdletContext.ServerSideEncryptionMethod;
                }
                if (cmdletContext.SSECustomerAlgorithm != null)
                {
                    request.SSECustomerAlgorithm = cmdletContext.SSECustomerAlgorithm;
                }
                if (cmdletContext.SSEKMSKeyId != null)
                {
                    request.SSEKMSKeyId = cmdletContext.SSEKMSKeyId;
                }
                if (cmdletContext.SSECustomerKeyMD5 != null)
                {
                    request.SSECustomerKeyMD5 = cmdletContext.SSECustomerKeyMD5;
                }
                if (cmdletContext.StorageClass != null)
                {
                    request.StorageClass = cmdletContext.StorageClass;
                }
                if (cmdletContext.TagCount != null)
                {
                    request.TagCount = cmdletContext.TagCount.Value;
                }
                if (cmdletContext.VersionId != null)
                {
                    request.VersionId = cmdletContext.VersionId;
                }
                if (cmdletContext.BucketKeyEnabled != null)
                {
                    request.BucketKeyEnabled = cmdletContext.BucketKeyEnabled.Value;
                }
                if (cmdletContext.Body != null)
                {
                    _BodyStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.Body);
                    request.Body = _BodyStream;
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
            finally
            {
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.WriteGetObjectResponseResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.WriteGetObjectResponseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "WriteGetObjectResponse");
            try
            {
                #if DESKTOP
                return client.WriteGetObjectResponse(request);
                #elif CORECLR
                return client.WriteGetObjectResponseAsync(request).GetAwaiter().GetResult();
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
            public System.String RequestRoute { get; set; }
            public System.String RequestToken { get; set; }
            public System.Int32? StatusCode { get; set; }
            public System.String ErrorCode { get; set; }
            public System.String ErrorMessage { get; set; }
            public System.String AcceptRange { get; set; }
            public System.String CacheControl { get; set; }
            public System.String ContentDisposition { get; set; }
            public System.String ContentEncoding { get; set; }
            public System.String ContentLanguage { get; set; }
            public System.Int64? ContentLength { get; set; }
            public System.String ContentRange { get; set; }
            public System.String ContentType { get; set; }
            public System.Boolean? DeleteMarker { get; set; }
            public System.String ETag { get; set; }
            public System.DateTime? Expire { get; set; }
            public System.String Expiration { get; set; }
            public System.DateTime? LastModified { get; set; }
            public System.Int32? MissingMeta { get; set; }
            public Amazon.S3.ObjectLockMode ObjectLockMode { get; set; }
            public Amazon.S3.ObjectLockLegalHoldStatus ObjectLockLegalHoldStatus { get; set; }
            public System.DateTime? ObjectLockRetainUntilDate { get; set; }
            public System.Int32? PartsCount { get; set; }
            public Amazon.S3.ReplicationStatus ReplicationStatus { get; set; }
            public Amazon.S3.RequestCharged RequestCharged { get; set; }
            public System.String Restore { get; set; }
            public Amazon.S3.ServerSideEncryptionMethod ServerSideEncryptionMethod { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod SSECustomerAlgorithm { get; set; }
            public System.String SSEKMSKeyId { get; set; }
            public System.String SSECustomerKeyMD5 { get; set; }
            public Amazon.S3.S3StorageClass StorageClass { get; set; }
            public System.Int32? TagCount { get; set; }
            public System.String VersionId { get; set; }
            public System.Boolean? BucketKeyEnabled { get; set; }
            public object Body { get; set; }
            public System.Func<Amazon.S3.Model.WriteGetObjectResponseResponse, WriteS3GetObjectResponseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
