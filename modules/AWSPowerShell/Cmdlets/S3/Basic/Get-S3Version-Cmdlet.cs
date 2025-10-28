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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// <important><para>
    /// End of support notice: Beginning November 21, 2025, Amazon S3 will stop returning
    /// <c>DisplayName</c>. Update your applications to use canonical IDs (unique identifier
    /// for Amazon Web Services accounts), Amazon Web Services account ID (12 digit identifier)
    /// or IAM ARNs (full resource naming) as a direct replacement of <c>DisplayName</c>.
    /// 
    /// </para><para>
    /// This change affects the following Amazon Web Services Regions: US East (N. Virginia)
    /// Region, US West (N. California) Region, US West (Oregon) Region, Asia Pacific (Singapore)
    /// Region, Asia Pacific (Sydney) Region, Asia Pacific (Tokyo) Region, Europe (Ireland)
    /// Region, and South America (São Paulo) Region.
    /// </para></important><note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Returns metadata about all versions of the objects in a bucket. You can also use request
    /// parameters as selection criteria to return metadata about a subset of all the object
    /// versions.
    /// </para><important><para>
    ///  To use this operation, you must have permission to perform the <c>s3:ListBucketVersions</c>
    /// action. Be aware of the name difference. 
    /// </para></important><note><para>
    ///  A <c>200 OK</c> response can contain valid or invalid XML. Make sure to design your
    /// application to parse the contents of the response and handle it appropriately.
    /// </para></note><para>
    /// To use this operation, you must have READ access to the bucket.
    /// </para><para>
    /// The following operations are related to <c>ListObjectVersions</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjectsV2.html">ListObjectsV2</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteObject.html">DeleteObject</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Get", "S3Version")]
    [OutputType("Amazon.S3.Model.ListVersionsResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListVersions API operation.", Operation = new[] {"ListVersions"}, SelectReturnType = typeof(Amazon.S3.Model.ListVersionsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.ListVersionsResponse",
        "This cmdlet returns an Amazon.S3.Model.ListVersionsResponse object containing multiple properties."
    )]
    public partial class GetS3VersionCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name that contains the objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// <para>Encoding type used by Amazon S3 to encode the 
        /// <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-keys.html">object keys</a> in 
        /// the response. Responses are encoded only in UTF-8. An object key can contain any Unicode character. 
        /// However, the XML 1.0 parser can't parse certain characters, such as characters with an ASCII value 
        /// from 0 to 10. For characters that aren't supported in XML 1.0, you can add this parameter to request 
        /// that Amazon S3 encode the keys in the response. For more information about characters to avoid in object 
        /// key names, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/object-keys.html#object-key-guidelines">Object key naming guidelines</a>.</para><note><para>When using the URL encoding type, non-ASCII characters that are used in an 
        /// object's key name will be percent-encoded according to UTF-8 code values. For example, the object 
        /// <code>test_file(3).png</code> will appear as <code>test_file%283%29.png</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.EncodingType")]
        public Amazon.S3.EncodingType Encoding { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter KeyMarker
        /// <summary>
        /// <para>
        /// Specifies the key to start with when listing objects in a bucket.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMarker { get; set; }
        #endregion
        
        #region Parameter OptionalObjectAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies the optional fields that you want returned in the response. Fields that
        /// you do not specify are not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptionalObjectAttributes")]
        public System.String[] OptionalObjectAttribute { get; set; }
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
        
        #region Parameter VersionIdMarker
        /// <summary>
        /// <para>
        /// Specifies the object version you want to start listing from.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionIdMarker { get; set; }
        #endregion
        
        #region Parameter Delimiter
        /// <summary>
        /// <para>
        /// <para>A delimiter is a character that you specify to group keys. All keys that contain the
        /// same string between the <c>prefix</c> and the first occurrence of the delimiter
        /// are grouped under a single result element in <c>CommonPrefixes</c>. These groups
        /// are counted as one result against the <c>max-keys</c> limitation. These keys
        /// are not returned elsewhere in the response.</para><para><c>CommonPrefixes</c> is filtered out from results if it is not lexicographically greater than the key-marker.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Delimiter { get; set; }
        #endregion
        
        #region Parameter MaxKey
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of keys returned in the response. By default, the action returns
        /// up to 1,000 key names. The response might contain fewer keys but will never contain
        /// more. If additional keys satisfy the search criteria, but were not returned because
        /// <code>max-keys</code> was exceeded, the response contains <code>&lt;isTruncated&gt;true&lt;/isTruncated&gt;</code>.
        /// To return the additional keys, see <code>key-marker</code> and <code>version-id-marker</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxKeys")]
        public System.Int32? MaxKey { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>Use this parameter to select only those keys that begin with the specified prefix.
        /// You can use prefixes to separate a bucket into different groupings of keys. (You can
        /// think of using <code>prefix</code> to make groups in the same way that you'd use a
        /// folder in a file system.) You can use <code>prefix</code> with <code>delimiter</code>
        /// to roll up numerous objects into a single result under <code>CommonPrefixes</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListVersionsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListVersionsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet>(Select) ??
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
            context.Delimiter = this.Delimiter;
            context.KeyMarker = this.KeyMarker;
            context.MaxKey = this.MaxKey;
            if (this.OptionalObjectAttribute != null)
            {
                context.OptionalObjectAttribute = new List<System.String>(this.OptionalObjectAttribute);
            }
            context.Prefix = this.Prefix;
            context.RequestPayer = this.RequestPayer;
            context.VersionIdMarker = this.VersionIdMarker;
            context.Encoding = this.Encoding;
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
            var request = new Amazon.S3.Model.ListVersionsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Delimiter != null)
            {
                request.Delimiter = cmdletContext.Delimiter;
            }
            if (cmdletContext.KeyMarker != null)
            {
                request.KeyMarker = cmdletContext.KeyMarker;
            }
            if (cmdletContext.MaxKey != null)
            {
                request.MaxKeys = cmdletContext.MaxKey.Value;
            }
            if (cmdletContext.OptionalObjectAttribute != null)
            {
                request.OptionalObjectAttributes = cmdletContext.OptionalObjectAttribute;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.RequestPayer != null)
            {
                request.RequestPayer = cmdletContext.RequestPayer;
            }
            if (cmdletContext.VersionIdMarker != null)
            {
                request.VersionIdMarker = cmdletContext.VersionIdMarker;
            }
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
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
        
        private Amazon.S3.Model.ListVersionsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListVersions");
            try
            {
                #if DESKTOP
                return client.ListVersions(request);
                #elif CORECLR
                return client.ListVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Delimiter { get; set; }
            public System.String KeyMarker { get; set; }
            public System.Int32? MaxKey { get; set; }
            public List<System.String> OptionalObjectAttribute { get; set; }
            public System.String Prefix { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionIdMarker { get; set; }
            public Amazon.S3.EncodingType Encoding { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Func<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
