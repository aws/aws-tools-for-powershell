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
    /// The HEAD action retrieves metadata from an object without returning the object itself.
    /// This action is useful if you're only interested in an object's metadata. To use HEAD,
    /// you must have READ access to the object.
    /// 
    ///  
    /// <para>
    /// A <code>HEAD</code> request has the same options as a <code>GET</code> action on an
    /// object. The response is identical to the <code>GET</code> response except that there
    /// is no response body. Because of this, if the <code>HEAD</code> request generates an
    /// error, it returns a generic <code>404 Not Found</code> or <code>403 Forbidden</code>
    /// code. It is not possible to retrieve the exact exception beyond these error codes.
    /// </para><para>
    /// If you encrypt an object by using server-side encryption with customer-provided encryption
    /// keys (SSE-C) when you store the object in Amazon S3, then when you retrieve the metadata
    /// from the object, you must use the following headers:
    /// </para><ul><li><para>
    /// x-amz-server-side-encryption-customer-algorithm
    /// </para></li><li><para>
    /// x-amz-server-side-encryption-customer-key
    /// </para></li><li><para>
    /// x-amz-server-side-encryption-customer-key-MD5
    /// </para></li></ul><para>
    /// For more information about SSE-C, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerSideEncryptionCustomerKeys.html">Server-Side
    /// Encryption (Using Customer-Provided Encryption Keys)</a>.
    /// </para><note><ul><li><para>
    /// Encryption request headers, like <code>x-amz-server-side-encryption</code>, should
    /// not be sent for GET requests if your object uses server-side encryption with CMKs
    /// stored in AWS KMS (SSE-KMS) or server-side encryption with Amazon S3–managed encryption
    /// keys (SSE-S3). If your object does use these types of keys, you’ll get an HTTP 400
    /// BadRequest error.
    /// </para></li><li><para>
    ///  The last modified property in this case is the creation date of the object.
    /// </para></li></ul></note><para>
    /// Request headers are limited to 8 KB in size. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/RESTCommonRequestHeaders.html">Common
    /// Request Headers</a>.
    /// </para><para>
    /// Consider the following when using request headers:
    /// </para><ul><li><para>
    ///  Consideration 1 – If both of the <code>If-Match</code> and <code>If-Unmodified-Since</code>
    /// headers are present in the request as follows:
    /// </para><ul><li><para><code>If-Match</code> condition evaluates to <code>true</code>, and;
    /// </para></li><li><para><code>If-Unmodified-Since</code> condition evaluates to <code>false</code>;
    /// </para></li></ul><para>
    /// Then Amazon S3 returns <code>200 OK</code> and the data requested.
    /// </para></li><li><para>
    ///  Consideration 2 – If both of the <code>If-None-Match</code> and <code>If-Modified-Since</code>
    /// headers are present in the request as follows:
    /// </para><ul><li><para><code>If-None-Match</code> condition evaluates to <code>false</code>, and;
    /// </para></li><li><para><code>If-Modified-Since</code> condition evaluates to <code>true</code>;
    /// </para></li></ul><para>
    /// Then Amazon S3 returns the <code>304 Not Modified</code> response code.
    /// </para></li></ul><para>
    /// For more information about conditional requests, see <a href="https://tools.ietf.org/html/rfc7232">RFC
    /// 7232</a>.
    /// </para><para><b>Permissions</b></para><para>
    /// You need the <code>s3:GetObject</code> permission for this operation. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html">Specifying
    /// Permissions in a Policy</a>. If the object you request does not exist, the error Amazon
    /// S3 returns depends on whether you also have the s3:ListBucket permission.
    /// </para><ul><li><para>
    /// If you have the <code>s3:ListBucket</code> permission on the bucket, Amazon S3 returns
    /// an HTTP status code 404 ("no such key") error.
    /// </para></li><li><para>
    /// If you don’t have the <code>s3:ListBucket</code> permission, Amazon S3 returns an
    /// HTTP status code 403 ("access denied") error.
    /// </para></li></ul><para>
    /// The following action is related to <code>HeadObject</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3ObjectMetadata")]
    [OutputType("Amazon.S3.Model.GetObjectMetadataResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetObjectMetadata API operation.", Operation = new[] {"GetObjectMetadata"}, SelectReturnType = typeof(Amazon.S3.Model.GetObjectMetadataResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.GetObjectMetadataResponse",
        "This cmdlet returns an Amazon.S3.Model.GetObjectMetadataResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3ObjectMetadataCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket containing the object.</para><para>When using this API with an access point, you must direct requests to the access point hostname. 
        /// The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com. 
        /// When using this operation using an access point through the AWS SDKs, you provide the access point ARN in place of the bucket name. 
        /// For more information about access point ARNs, see
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-access-points.html">Using Access Points</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para><para>When using this API with Amazon S3 on Outposts, you must direct requests to the S3 on Outposts hostname. 
        /// The S3 on Outposts hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com. 
        /// When using this operation using S3 on Outposts through the AWS SDKs, you provide the Outposts bucket ARN in place of the bucket name. 
        /// For more information about S3 on Outposts ARNs, see 
        /// <a href="https://docs.aws.amazon.com/">Using S3 on Outposts</a> in the <i>Amazon Simple Storage Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter EtagToMatch
        /// <summary>
        /// <para>
        /// ETag to be matched as a pre-condition for returning the object,
        /// otherwise a PreconditionFailed signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EtagToMatch { get; set; }
        #endregion
        
        #region Parameter EtagToNotMatch
        /// <summary>
        /// <para>
        /// ETag that should not be matched as a pre-condition for returning the object,
        /// otherwise a PreconditionFailed signal is returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EtagToNotMatch { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// The account ID of the expected bucket owner. 
        /// If the bucket is owned by a different account, the request will fail with an HTTP 403 (Access Denied) error.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// The key of the object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter UtcModifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcModifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter PartNumber
        /// <summary>
        /// <para>
        /// Part number of the object being read. This is a positive integer between 1 and 10,000.
        /// Effectively performs a 'ranged' HEAD request for the part specified.
        /// Useful querying about the size of the part and the number of parts in this object.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartNumber { get; set; }
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
        
        #region Parameter ServerSideEncryptionCustomerMethod
        /// <summary>
        /// <para>
        /// The Server-side encryption algorithm to be used with the customer provided key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ServerSideEncryptionCustomerMethod")]
        public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKey
        /// <summary>
        /// <para>
        /// The base64-encoded encryption key for Amazon S3 to use to decrypt the object
        /// <para>Using the encryption key you provide as part of your request Amazon S3 manages both the encryption, as it writes 
        /// to disks, and decryption, when you access your objects. Therefore, you don't need to maintain any data encryption code. The only 
        /// thing you do is manage the encryption keys you provide.</para><para>When you retrieve an object, you must provide the same encryption key as part of your request. Amazon S3 first verifies 
        /// the encryption key you provided matches, and then decrypts the object before returning the object data to you.</para><para>Important: Amazon S3 does not store the encryption key you provide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
        #endregion
        
        #region Parameter ServerSideEncryptionCustomerProvidedKeyMD5
        /// <summary>
        /// <para>
        /// The MD5 of the customer encryption key specified in the ServerSideEncryptionCustomerProvidedKey property. The MD5 is
        /// base 64 encoded. This field is optional, the SDK will calculate the MD5 if this is not set.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
        #endregion
        
        #region Parameter UtcUnmodifiedSinceDate
        /// <summary>
        /// <para>
        /// Returns the object only if it has not been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UtcUnmodifiedSinceDate { get; set; }
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
        
        #region Parameter ModifiedSinceDate
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use ModifiedSinceDateUtc instead. Setting either ModifiedSinceDate or
        /// ModifiedSinceDateUtc results in both ModifiedSinceDate and ModifiedSinceDateUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value of both.
        /// ModifiedSinceDate is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para>
        /// Returns the object only if it has been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcModifiedSinceDate instead.")]
        public System.DateTime? ModifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter UnmodifiedSinceDate
        /// <summary>
        /// <para>
        /// <para>This property is deprecated. Setting this property results in non-UTC DateTimes not
        /// being marshalled correctly. Use UnmodifiedSinceDateUtc instead. Setting either UnmodifiedSinceDate or
        /// UnmodifiedSinceDateUtc results in both UnmodifiedSinceDate and UnmodifiedSinceDateUtc being assigned,
        /// the latest assignment to either one of the two property is reflected in the value of both.
        /// UnmodifiedSinceDate is provided for backwards compatibility only and assigning a non-Utc DateTime
        /// to it results in the wrong timestamp being passed to the service.</para>
        /// Returns the object only if it has not been modified since the specified time, 
        /// otherwise returns a PreconditionFailed.
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("This parameter is deprecated and may result in the wrong timestamp being passed to the service, use UtcUnmodifiedSinceDate instead.")]
        public System.DateTime? UnmodifiedSinceDate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetObjectMetadataResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetObjectMetadataResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetObjectMetadataResponse, GetS3ObjectMetadataCmdlet>(Select) ??
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
            context.EtagToMatch = this.EtagToMatch;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ModifiedSinceDate = this.ModifiedSinceDate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UtcModifiedSinceDate = this.UtcModifiedSinceDate;
            context.EtagToNotMatch = this.EtagToNotMatch;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UnmodifiedSinceDate = this.UnmodifiedSinceDate;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.UtcUnmodifiedSinceDate = this.UtcUnmodifiedSinceDate;
            context.Key = this.Key;
            context.VersionId = this.VersionId;
            context.ServerSideEncryptionCustomerMethod = this.ServerSideEncryptionCustomerMethod;
            context.ServerSideEncryptionCustomerProvidedKey = this.ServerSideEncryptionCustomerProvidedKey;
            context.ServerSideEncryptionCustomerProvidedKeyMD5 = this.ServerSideEncryptionCustomerProvidedKeyMD5;
            context.PartNumber = this.PartNumber;
            context.RequestPayer = this.RequestPayer;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            
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
            var request = new Amazon.S3.Model.GetObjectMetadataRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.EtagToMatch != null)
            {
                request.EtagToMatch = cmdletContext.EtagToMatch;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ModifiedSinceDate != null)
            {
                if (cmdletContext.UtcModifiedSinceDate != null)
                {
                    throw new System.ArgumentException("Parameters ModifiedSinceDate and UtcModifiedSinceDate are mutually exclusive.", nameof(this.ModifiedSinceDate));
                }
                request.ModifiedSinceDate = cmdletContext.ModifiedSinceDate.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UtcModifiedSinceDate != null)
            {
                request.ModifiedSinceDateUtc = cmdletContext.UtcModifiedSinceDate.Value;
            }
            if (cmdletContext.EtagToNotMatch != null)
            {
                request.EtagToNotMatch = cmdletContext.EtagToNotMatch;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UnmodifiedSinceDate != null)
            {
                if (cmdletContext.UtcUnmodifiedSinceDate != null)
                {
                    throw new System.ArgumentException("Parameters UnmodifiedSinceDate and UtcUnmodifiedSinceDate are mutually exclusive.", nameof(this.UnmodifiedSinceDate));
                }
                request.UnmodifiedSinceDate = cmdletContext.UnmodifiedSinceDate.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.UtcUnmodifiedSinceDate != null)
            {
                request.UnmodifiedSinceDateUtc = cmdletContext.UtcUnmodifiedSinceDate.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.VersionId != null)
            {
                request.VersionId = cmdletContext.VersionId;
            }
            if (cmdletContext.ServerSideEncryptionCustomerMethod != null)
            {
                request.ServerSideEncryptionCustomerMethod = cmdletContext.ServerSideEncryptionCustomerMethod;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKey != null)
            {
                request.ServerSideEncryptionCustomerProvidedKey = cmdletContext.ServerSideEncryptionCustomerProvidedKey;
            }
            if (cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5 != null)
            {
                request.ServerSideEncryptionCustomerProvidedKeyMD5 = cmdletContext.ServerSideEncryptionCustomerProvidedKeyMD5;
            }
            if (cmdletContext.PartNumber != null)
            {
                request.PartNumber = cmdletContext.PartNumber.Value;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
        
        private Amazon.S3.Model.GetObjectMetadataResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetObjectMetadataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetObjectMetadata");
            try
            {
                #if DESKTOP
                return client.GetObjectMetadata(request);
                #elif CORECLR
                return client.GetObjectMetadataAsync(request).GetAwaiter().GetResult();
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
            public System.String EtagToMatch { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? ModifiedSinceDate { get; set; }
            public System.DateTime? UtcModifiedSinceDate { get; set; }
            public System.String EtagToNotMatch { get; set; }
            [System.ObsoleteAttribute]
            public System.DateTime? UnmodifiedSinceDate { get; set; }
            public System.DateTime? UtcUnmodifiedSinceDate { get; set; }
            public System.String Key { get; set; }
            public System.String VersionId { get; set; }
            public Amazon.S3.ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKey { get; set; }
            public System.String ServerSideEncryptionCustomerProvidedKeyMD5 { get; set; }
            public System.Int32? PartNumber { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.GetObjectMetadataResponse, GetS3ObjectMetadataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
