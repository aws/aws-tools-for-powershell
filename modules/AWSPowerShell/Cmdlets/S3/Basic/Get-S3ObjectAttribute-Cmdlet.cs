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
    /// Retrieves all the metadata from an object without returning the object itself. This
    /// action is useful if you're interested only in an object's metadata. To use <code>GetObjectAttributes</code>,
    /// you must have READ access to the object.
    /// 
    ///  
    /// <para><code>GetObjectAttributes</code> combines the functionality of <code>GetObjectAcl</code>,
    /// <code>GetObjectLegalHold</code>, <code>GetObjectLockConfiguration</code>, <code>GetObjectRetention</code>,
    /// <code>GetObjectTagging</code>, <code>HeadObject</code>, and <code>ListParts</code>.
    /// All of the data returned with each of those individual calls can be returned with
    /// a single call to <code>GetObjectAttributes</code>.
    /// </para><para>
    /// If you encrypt an object by using server-side encryption with customer-provided encryption
    /// keys (SSE-C) when you store the object in Amazon S3, then when you retrieve the metadata
    /// from the object, you must use the following headers:
    /// </para><ul><li><para><code>x-amz-server-side-encryption-customer-algorithm</code></para></li><li><para><code>x-amz-server-side-encryption-customer-key</code></para></li><li><para><code>x-amz-server-side-encryption-customer-key-MD5</code></para></li></ul><para>
    /// For more information about SSE-C, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/ServerSideEncryptionCustomerKeys.html">Server-Side
    /// Encryption (Using Customer-Provided Encryption Keys)</a> in the <i>Amazon S3 User
    /// Guide</i>.
    /// </para><note><ul><li><para>
    /// Encryption request headers, such as <code>x-amz-server-side-encryption</code>, should
    /// not be sent for GET requests if your object uses server-side encryption with Amazon
    /// Web Services KMS keys stored in Amazon Web Services Key Management Service (SSE-KMS)
    /// or server-side encryption with Amazon S3 managed encryption keys (SSE-S3). If your
    /// object does use these types of keys, you'll get an HTTP <code>400 Bad Request</code>
    /// error.
    /// </para></li><li><para>
    ///  The last modified property in this case is the creation date of the object.
    /// </para></li></ul></note><para>
    /// Consider the following when using request headers:
    /// </para><ul><li><para>
    ///  If both of the <code>If-Match</code> and <code>If-Unmodified-Since</code> headers
    /// are present in the request as follows, then Amazon S3 returns the HTTP status code
    /// <code>200 OK</code> and the data requested:
    /// </para><ul><li><para><code>If-Match</code> condition evaluates to <code>true</code>.
    /// </para></li><li><para><code>If-Unmodified-Since</code> condition evaluates to <code>false</code>.
    /// </para></li></ul></li><li><para>
    /// If both of the <code>If-None-Match</code> and <code>If-Modified-Since</code> headers
    /// are present in the request as follows, then Amazon S3 returns the HTTP status code
    /// <code>304 Not Modified</code>:
    /// </para><ul><li><para><code>If-None-Match</code> condition evaluates to <code>false</code>.
    /// </para></li><li><para><code>If-Modified-Since</code> condition evaluates to <code>true</code>.
    /// </para></li></ul></li></ul><para>
    /// For more information about conditional requests, see <a href="https://tools.ietf.org/html/rfc7232">RFC
    /// 7232</a>.
    /// </para><para><b>Permissions</b></para><para>
    /// The permissions that you need to use this operation depend on whether the bucket is
    /// versioned. If the bucket is versioned, you need both the <code>s3:GetObjectVersion</code>
    /// and <code>s3:GetObjectVersionAttributes</code> permissions for this operation. If
    /// the bucket is not versioned, you need the <code>s3:GetObject</code> and <code>s3:GetObjectAttributes</code>
    /// permissions. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/using-with-s3-actions.html">Specifying
    /// Permissions in a Policy</a> in the <i>Amazon S3 User Guide</i>. If the object that
    /// you request does not exist, the error Amazon S3 returns depends on whether you also
    /// have the <code>s3:ListBucket</code> permission.
    /// </para><ul><li><para>
    /// If you have the <code>s3:ListBucket</code> permission on the bucket, Amazon S3 returns
    /// an HTTP status code <code>404 Not Found</code> ("no such key") error.
    /// </para></li><li><para>
    /// If you don't have the <code>s3:ListBucket</code> permission, Amazon S3 returns an
    /// HTTP status code <code>403 Forbidden</code> ("access denied") error.
    /// </para></li></ul><para>
    /// The following actions are related to <code>GetObjectAttributes</code>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAcl.html">GetObjectAcl</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectLegalHold.html">GetObjectLegalHold</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectLockConfiguration.html">GetObjectLockConfiguration</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectRetention.html">GetObjectRetention</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectTagging.html">GetObjectTagging</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_HeadObject.html">HeadObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListParts.html">ListParts</a></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "S3ObjectAttribute")]
    [OutputType("Amazon.S3.Model.GetObjectAttributesResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) GetObjectAttributes API operation.", Operation = new[] {"GetObjectAttributes"}, SelectReturnType = typeof(Amazon.S3.Model.GetObjectAttributesResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.GetObjectAttributesResponse",
        "This cmdlet returns an Amazon.S3.Model.GetObjectAttributesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetS3ObjectAttributeCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket that contains the object.</para><para>When using this action with an access point, you must direct requests to the access
        /// point hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><para>When you use this action with Amazon S3 on Outposts, you must direct requests to the
        /// S3 on Outposts hostname. The S3 on Outposts hostname takes the form <code><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</code>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
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
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The object key.</para>
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
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter MaxPart
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of parts to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxParts")]
        public System.Int32? MaxPart { get; set; }
        #endregion
        
        #region Parameter ObjectAttribute
        /// <summary>
        /// <para>
        /// <para>An XML header that specifies the fields at the root level that you want returned in
        /// the response. Fields that you do not specify will not be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ObjectAttributes")]
        public Amazon.S3.ObjectAttributes[] ObjectAttribute { get; set; }
        #endregion
        
        #region Parameter PartNumberMarker
        /// <summary>
        /// <para>
        /// <para>Specifies the part after which listing should begin. Only parts with higher part numbers
        /// will be listed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PartNumberMarker { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter SSECustomerAlgorithm
        /// <summary>
        /// <para>
        /// <para>Specifies the algorithm to use to when encrypting the object (for example, AES256).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSECustomerAlgorithm { get; set; }
        #endregion
        
        #region Parameter SSECustomerKey
        /// <summary>
        /// <para>
        /// <para>Specifies the customer-provided encryption key for Amazon S3 to use in encrypting
        /// data. This value is used to store the object and then it is discarded; Amazon S3 does
        /// not store the encryption key. The key must be appropriate for use with the algorithm
        /// specified in the <code>x-amz-server-side-encryption-customer-algorithm</code> header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSECustomerKey { get; set; }
        #endregion
        
        #region Parameter SSECustomerKeyMD5
        /// <summary>
        /// <para>
        /// <para>Specifies the 128-bit MD5 digest of the encryption key according to RFC 1321. Amazon
        /// S3 uses this header for a message integrity check to ensure that the encryption key
        /// was transmitted without error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SSECustomerKeyMD5 { get; set; }
        #endregion
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.GetObjectAttributesResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.GetObjectAttributesResponse will result in that property being returned.
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
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.GetObjectAttributesResponse, GetS3ObjectAttributeCmdlet>(Select) ??
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
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Key = this.Key;
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxPart = this.MaxPart;
            if (this.ObjectAttribute != null)
            {
                context.ObjectAttribute = new List<Amazon.S3.ObjectAttributes>(this.ObjectAttribute);
            }
            context.PartNumberMarker = this.PartNumberMarker;
            context.RequestPayer = this.RequestPayer;
            context.SSECustomerAlgorithm = this.SSECustomerAlgorithm;
            context.SSECustomerKey = this.SSECustomerKey;
            context.SSECustomerKeyMD5 = this.SSECustomerKeyMD5;
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
            var request = new Amazon.S3.Model.GetObjectAttributesRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.MaxPart != null)
            {
                request.MaxParts = cmdletContext.MaxPart.Value;
            }
            if (cmdletContext.ObjectAttribute != null)
            {
                request.ObjectAttributes = cmdletContext.ObjectAttribute;
            }
            if (cmdletContext.PartNumberMarker != null)
            {
                request.PartNumberMarker = cmdletContext.PartNumberMarker.Value;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.SSECustomerAlgorithm != null)
            {
                request.SSECustomerAlgorithm = cmdletContext.SSECustomerAlgorithm;
            }
            if (cmdletContext.SSECustomerKey != null)
            {
                request.SSECustomerKey = cmdletContext.SSECustomerKey;
            }
            if (cmdletContext.SSECustomerKeyMD5 != null)
            {
                request.SSECustomerKeyMD5 = cmdletContext.SSECustomerKeyMD5;
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
        
        private Amazon.S3.Model.GetObjectAttributesResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.GetObjectAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "GetObjectAttributes");
            try
            {
                #if DESKTOP
                return client.GetObjectAttributes(request);
                #elif CORECLR
                return client.GetObjectAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public System.Int32? MaxPart { get; set; }
            public List<Amazon.S3.ObjectAttributes> ObjectAttribute { get; set; }
            public System.Int32? PartNumberMarker { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String SSECustomerAlgorithm { get; set; }
            public System.String SSECustomerKey { get; set; }
            public System.String SSECustomerKeyMD5 { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.GetObjectAttributesResponse, GetS3ObjectAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
