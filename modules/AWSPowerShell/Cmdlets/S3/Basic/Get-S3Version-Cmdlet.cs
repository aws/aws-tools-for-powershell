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
    /// <important><para>
    /// End of support notice: Beginning October 1, 2025, Amazon S3 will stop returning <c>DisplayName</c>.
    /// Update your applications to use canonical IDs (unique identifier for Amazon Web Services
    /// accounts), Amazon Web Services account ID (12 digit identifier) or IAM ARNs (full
    /// resource naming) as a direct replacement of <c>DisplayName</c>. 
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
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjectsV2.html">ListObjectsV2</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteObject.html">DeleteObject</a></para></li></ul>
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
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name that contains the objects. </para>
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
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// <c>403 Forbidden</c> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
        #endregion
        
        #region Parameter KeyMarker
        /// <summary>
        /// <para>
        /// <para>Specifies the key to start with when listing objects in a bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMarker { get; set; }
        #endregion
        
        #region Parameter OptionalObjectAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies the optional fields that you want returned in the response. Fields that
        /// you do not specify are not returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>Specifies the object version you want to start listing from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionIdMarker { get; set; }
        #endregion
        
        #region Parameter Delimiter
        /// <summary>
        /// <para>
        /// <para>A delimiter is a character that you specify to group keys. All keys that contain the
        /// same string between the <c>prefix</c> and the first occurrence of the delimiter are
        /// grouped under a single result element in <c>CommonPrefixes</c>. These groups are counted
        /// as one result against the <c>max-keys</c> limitation. These keys are not returned
        /// elsewhere in the response.</para><para><c>CommonPrefixes</c> is filtered out from results if it is not lexicographically
        /// greater than the key-marker.</para>
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
        /// <c>max-keys</c> was exceeded, the response contains <c>&lt;isTruncated&gt;true&lt;/isTruncated&gt;</c>.
        /// To return the additional keys, see <c>key-marker</c> and <c>version-id-marker</c>.</para>
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
        /// think of using <c>prefix</c> to make groups in the same way that you'd use a folder
        /// in a file system.) You can use <c>prefix</c> with <c>delimiter</c> to roll up numerous
        /// objects into a single result under <c>CommonPrefixes</c>. </para>
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Delimiter = this.Delimiter;
            context.Encoding = this.Encoding;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.KeyMarker = this.KeyMarker;
            context.MaxKey = this.MaxKey;
            if (this.OptionalObjectAttribute != null)
            {
                context.OptionalObjectAttribute = new List<System.String>(this.OptionalObjectAttribute);
            }
            context.Prefix = this.Prefix;
            context.RequestPayer = this.RequestPayer;
            context.VersionIdMarker = this.VersionIdMarker;
            
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
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
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
                return client.ListVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3.EncodingType Encoding { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String KeyMarker { get; set; }
            public System.Int32? MaxKey { get; set; }
            public List<System.String> OptionalObjectAttribute { get; set; }
            public System.String Prefix { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionIdMarker { get; set; }
            public System.Func<Amazon.S3.Model.ListVersionsResponse, GetS3VersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
