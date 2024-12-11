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
    /// Returns some or all (up to 1,000) of the objects in a bucket with each request. You
    /// can use the request parameters as selection criteria to return a subset of the objects
    /// in a bucket. A <c>200 OK</c> response can contain valid or invalid XML. Make sure
    /// to design your application to parse the contents of the response and handle it appropriately.
    /// For more information about listing objects, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/ListingKeysUsingAPIs.html">Listing
    /// object keys programmatically</a> in the <i>Amazon S3 User Guide</i>. To get a list
    /// of your buckets, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListBuckets.html">ListBuckets</a>.
    /// 
    ///  <note><ul><li><para><b>General purpose bucket</b> - For general purpose buckets, <c>ListObjectsV2</c>
    /// doesn't return prefixes that are related only to in-progress multipart uploads.
    /// </para></li><li><para><b>Directory buckets</b> - For directory buckets, <c>ListObjectsV2</c> response includes
    /// the prefixes that are related only to in-progress multipart uploads. 
    /// </para></li><li><para><b>Directory buckets</b> - For directory buckets, you must make requests for this
    /// API operation to the Zonal endpoint. These endpoints support virtual-hosted-style
    /// requests in the format <c>https://<i>bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com/<i>key-name</i></c>. Path-style requests are not supported. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-express-Regions-and-Zones.html">Regional
    /// and Zonal endpoints</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li></ul></note><dl><dt>Permissions</dt><dd><ul><li><para><b>General purpose bucket permissions</b> - To use this operation, you must have
    /// READ access to the bucket. You must have permission to perform the <c>s3:ListBucket</c>
    /// action. The bucket owner has this permission by default and can grant this permission
    /// to others. For more information about permissions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-with-s3-actions.html#using-with-s3-actions-related-to-bucket-subresources">Permissions
    /// Related to Bucket Subresource Operations</a> and <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/s3-access-control.html">Managing
    /// Access Permissions to Your Amazon S3 Resources</a> in the <i>Amazon S3 User Guide</i>.
    /// </para></li><li><para><b>Directory bucket permissions</b> - To grant access to this API operation on a
    /// directory bucket, we recommend that you use the <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a> API operation for session-based authorization. Specifically,
    /// you grant the <c>s3express:CreateSession</c> permission to the directory bucket in
    /// a bucket policy or an IAM identity-based policy. Then, you make the <c>CreateSession</c>
    /// API call on the bucket to obtain a session token. With the session token in your request
    /// header, you can make API requests to this operation. After the session token expires,
    /// you make another <c>CreateSession</c> API call to generate a new session token for
    /// use. Amazon Web Services CLI or SDKs create session and refresh the session token
    /// automatically to avoid service interruptions when a session expires. For more information
    /// about authorization, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateSession.html"><c>CreateSession</c></a>.
    /// </para></li></ul></dd><dt>Sorting order of returned objects</dt><dd><ul><li><para><b>General purpose bucket</b> - For general purpose buckets, <c>ListObjectsV2</c>
    /// returns objects in lexicographical order based on their key names.
    /// </para></li><li><para><b>Directory bucket</b> - For directory buckets, <c>ListObjectsV2</c> does not return
    /// objects in lexicographical order.
    /// </para></li></ul></dd><dt>HTTP Host header syntax</dt><dd><para><b>Directory buckets </b> - The HTTP Host header syntax is <c><i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
    /// </para></dd></dl><important><para>
    /// This section describes the latest revision of this action. We recommend that you use
    /// this revised API operation for application development. For backward compatibility,
    /// Amazon S3 continues to support the prior version of this API operation, <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjects.html">ListObjects</a>.
    /// </para></important><para>
    /// The following operations are related to <c>ListObjectsV2</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObject.html">GetObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_PutObject.html">PutObject</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_CreateBucket.html">CreateBucket</a></para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "S3ObjectV2", DefaultParameterSetName="GetMultipleObjects")]
    [OutputType("Amazon.S3.Model.S3Object")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListObjectsV2 API operation.", Operation = new[] {"ListObjectsV2"}, SelectReturnType = typeof(Amazon.S3.Model.ListObjectsV2Response))]
    [AWSCmdletOutput("Amazon.S3.Model.S3Object or Amazon.S3.Model.ListObjectsV2Response",
        "This cmdlet returns a collection of Amazon.S3.Model.S3Object objects.",
        "The service call response (type Amazon.S3.Model.ListObjectsV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class GetS3ObjectV2Cmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para><b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c><i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c><i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c><i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.</para><para><b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.</para><note><para>Access points and Object Lambda access points are not supported by directory buckets.</para></note><para><b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c><i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// <para>Encoding type used by Amazon S3 to encode object keys in the response. If using <c>url</c>,
        /// non-ASCII characters used in an object's key name will be URL encoded. For example,
        /// the object test_file(3).png will appear as test_file%283%29.png.</para>
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
        
        #region Parameter FetchOwner
        /// <summary>
        /// <para>
        /// <para>The owner field is not present in <c>ListObjectsV2</c> by default. If you want
        /// to return the owner field with each key in the result, then set the <c>FetchOwner</c>
        /// field to <c>true</c>.</para><note><para><b>Directory buckets</b> - For directory buckets, the bucket owner is returned as
        /// the object owner for all objects.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FetchOwner { get; set; }
        #endregion
        
        #region Parameter OptionalObjectAttribute
        /// <summary>
        /// <para>
        /// <para>Specifies the optional fields that you want returned in the response. Fields that
        /// you do not specify are not returned.</para><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OptionalObjectAttributes")]
        public System.String[] OptionalObjectAttribute { get; set; }
        #endregion
        
        #region Parameter RequestPayer
        /// <summary>
        /// <para>
        /// <para>Confirms that the requester knows that she or he will be charged for the list objects
        /// request in V2 style. Bucket owners need not specify this parameter in their requests.</para><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.RequestPayer")]
        public Amazon.S3.RequestPayer RequestPayer { get; set; }
        #endregion
        
        #region Parameter StartAfter
        /// <summary>
        /// <para>
        /// <para>StartAfter is where you want Amazon S3 to start listing from. Amazon S3 starts listing
        /// after this specified key. StartAfter can be any key in the bucket.</para><note><para>This functionality is not supported for directory buckets.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartAfter { get; set; }
        #endregion
        
        #region Parameter ContinuationToken
        /// <summary>
        /// <para>
        /// <para><c>ContinuationToken</c> indicates to Amazon S3 that the list is being continued
        /// on this bucket with a token. <c>ContinuationToken</c> is obfuscated and is not
        /// a real key. You can use this <c>ContinuationToken</c> for pagination of the
        /// list results. </para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'ContinuationToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-ContinuationToken' to null for the first call then set the 'ContinuationToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultipleObjects")]
        [Alias("NextToken")]
        public System.String ContinuationToken { get; set; }
        #endregion
        
        #region Parameter Delimiter
        /// <summary>
        /// <para>
        /// <para>A delimiter is a character that you use to group keys.</para><note><ul><li><para><b>Directory buckets</b> - For directory buckets, <c>/</c> is the only supported
        /// delimiter.</para></li><li><para><b>Directory buckets </b> - When you query <c>ListObjectsV2</c> with a delimiter
        /// during in-progress multipart uploads, the <c>CommonPrefixes</c> response parameter
        /// contains the prefixes that are associated with the in-progress multipart uploads.
        /// For more information about multipart uploads, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/mpuoverview.html">Multipart
        /// Upload Overview</a> in the <i>Amazon S3 User Guide</i>.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultipleObjects")]
        public System.String Delimiter { get; set; }
        #endregion
        
        #region Parameter MaxKey
        /// <summary>
        /// <para>
        /// <para>Sets the maximum number of keys returned in the response. By default the action returns
        /// up to 1,000 key names. The response might contain fewer keys but will never contain
        /// more.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultipleObjects")]
        [Alias("MaxItems","MaxKeys")]
        public int? MaxKey { get; set; }
        #endregion
        
        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// <para>Limits the response to keys that begin with the specified prefix.</para><note><para><b>Directory buckets</b> - For directory buckets, only prefixes that end in a delimiter
        /// (<c>/</c>) are supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, ParameterSetName = "GetMultipleObjects")]
        public System.String Prefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'S3Objects'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListObjectsV2Response).
        /// Specifying the name of a property of type Amazon.S3.Model.ListObjectsV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "S3Objects";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of ContinuationToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "s3";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListObjectsV2Response, GetS3ObjectV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BucketName = this.BucketName;
            context.ContinuationToken = this.ContinuationToken;
            context.Delimiter = this.Delimiter;
            context.Encoding = this.Encoding;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.FetchOwner = this.FetchOwner;
            context.MaxKey = this.MaxKey;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxKey)) && this.MaxKey.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxKey parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxKey" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            if (this.OptionalObjectAttribute != null)
            {
                context.OptionalObjectAttribute = new List<System.String>(this.OptionalObjectAttribute);
            }
            context.Prefix = this.Prefix;
            context.RequestPayer = this.RequestPayer;
            context.StartAfter = this.StartAfter;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.S3.Model.ListObjectsV2Request();
            
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
            if (cmdletContext.FetchOwner != null)
            {
                request.FetchOwner = cmdletContext.FetchOwner.Value;
            }
            if (cmdletContext.MaxKey != null)
            {
                request.MaxKeys = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxKey.Value);
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
            if (cmdletContext.StartAfter != null)
            {
                request.StartAfter = cmdletContext.StartAfter;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.ContinuationToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ContinuationToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ContinuationToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextContinuationToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.S3.Model.ListObjectsV2Request();
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
            if (cmdletContext.FetchOwner != null)
            {
                request.FetchOwner = cmdletContext.FetchOwner.Value;
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
            if (cmdletContext.StartAfter != null)
            {
                request.StartAfter = cmdletContext.StartAfter;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.ContinuationToken))
            {
                _nextToken = cmdletContext.ContinuationToken;
            }
            if (cmdletContext.MaxKey.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxKey;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.ContinuationToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.ContinuationToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxKeys = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.S3Objects?.Count ?? 0;
                    
                    _nextToken = response.NextContinuationToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.ListObjectsV2Response CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListObjectsV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListObjectsV2");
            try
            {
                #if DESKTOP
                return client.ListObjectsV2(request);
                #elif CORECLR
                return client.ListObjectsV2Async(request).GetAwaiter().GetResult();
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
            public System.String ContinuationToken { get; set; }
            public System.String Delimiter { get; set; }
            public Amazon.S3.EncodingType Encoding { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Boolean? FetchOwner { get; set; }
            public int? MaxKey { get; set; }
            public List<System.String> OptionalObjectAttribute { get; set; }
            public System.String Prefix { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String StartAfter { get; set; }
            public System.Func<Amazon.S3.Model.ListObjectsV2Response, GetS3ObjectV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.S3Objects;
        }
        
    }
}
