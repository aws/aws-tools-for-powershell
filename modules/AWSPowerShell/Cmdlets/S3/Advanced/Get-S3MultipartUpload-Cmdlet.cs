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
using System.Threading;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// This action lists in-progress multipart uploads. 
    /// An in-progress multipart upload is a multipart upload that has been initiated using the 
    /// Initiate Multipart Upload request, but has not yet been completed or aborted.
    /// </summary>
    [Cmdlet("Get", "S3MultipartUpload")]
    [OutputType("Amazon.S3.Model.MultipartUpload")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) ListMultipartUploads API operation.", Operation = new[] { "ListMultipartUploads" }, SelectReturnType = typeof(Amazon.S3.Model.ListMultipartUploadsResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.MultipartUpload or Amazon.S3.Model.ListMultipartUploadsResponse",
        "This cmdlet returns a collection of Amazon.S3.Model.MultipartUpload objects.",
        "The service call response (type Amazon.S3.Model.ListMultipartUploadsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMultipartUploadCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The name of the bucket to which the multipart upload was initiated. 
        /// </para>
        ///  
        /// <para>
        ///  <b>Directory buckets</b> - When you use this operation with a directory bucket, you
        /// must use virtual-hosted-style requests in the format <c> <i>Bucket_name</i>.s3express-<i>az_id</i>.<i>region</i>.amazonaws.com</c>.
        /// Path-style requests are not supported. Directory bucket names must be unique in the
        /// chosen Availability Zone. Bucket names must follow the format <c> <i>bucket_base_name</i>--<i>az-id</i>--x-s3</c>
        /// (for example, <c> <i>DOC-EXAMPLE-BUCKET</i>--<i>usw2-az1</i>--x-s3</c>). For information
        /// about bucket naming restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/directory-bucket-naming-rules.html">Directory
        /// bucket naming rules</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  
        /// <para>
        ///  <b>Access points</b> - When you use this action with an access point, you must provide
        /// the alias of the access point in place of the bucket name or specify the access point
        /// ARN. When using the access point ARN, you must direct requests to the access point
        /// hostname. The access point hostname takes the form <i>AccessPointName</i>-<i>AccountId</i>.s3-accesspoint.<i>Region</i>.amazonaws.com.
        /// When using this action with an access point through the Amazon Web Services SDKs,
        /// you provide the access point ARN in place of the bucket name. For more information
        /// about access point ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-access-points.html">Using
        /// access points</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        ///  <note> 
        /// <para>
        /// Access points and Object Lambda access points are not supported by directory buckets.
        /// </para>
        ///  </note> 
        /// <para>
        ///  <b>S3 on Outposts</b> - When you use this action with Amazon S3 on Outposts, you
        /// must direct requests to the S3 on Outposts hostname. The S3 on Outposts hostname takes
        /// the form <c> <i>AccessPointName</i>-<i>AccountId</i>.<i>outpostID</i>.s3-outposts.<i>Region</i>.amazonaws.com</c>.
        /// When you use this action with S3 on Outposts through the Amazon Web Services SDKs,
        /// you provide the Outposts access point ARN in place of the bucket name. For more information
        /// about S3 on Outposts ARNs, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/S3onOutposts.html">What
        /// is S3 on Outposts?</a> in the <i>Amazon S3 User Guide</i>.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter Encoding
        /// <summary>
        /// <para>
        /// Requests Amazon S3 to encode the object keys in the response and specifies
        /// the encoding method to use. An object key may contain any Unicode character;
        /// however, XML 1.0 parser cannot parse some characters, such as characters
        /// with an ASCII value from 0 to 10. For characters that are not supported in
        /// XML 1.0, you can add this parameter to request that Amazon S3 encode the
        /// keys in the response.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.EncodingType")]
        public Amazon.S3.EncodingType Encoding { get; set; }
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
        
        #region Parameter Delimiter
        /// <summary>
        /// <para>
        /// Character you use to group keys.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Delimiter { get; set; }
        #endregion

        #region Parameter KeyMarker
        /// <summary>
        /// <para>
        /// Together with upload-id-marker, this parameter specifies the multipart upload after which listing should begin.
        /// </para>
        /// <para>
        /// If upload-id-marker is not specified, only the keys lexicographically greater than the specified key-marker will be included in the list.
        /// </para>
        /// <para>
        /// If upload-id-marker is specified, any multipart uploads for a key equal to the key-marker might also be included, 
        /// provided those multipart uploads have upload IDs lexicographically greater than the specified upload-id-marker.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyMarker { get; set; }
        #endregion

        #region Parameter MaxUpload
        /// <summary>
        /// <para>
        /// Sets the maximum number of multipart uploads, from 1 to 1,000, to return in the response body. 1,000 is the maximum number of uploads that can be returned in a response.
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxUploads")]
        public int? MaxUpload { get; set; }
        #endregion

        #region Parameter Prefix
        /// <summary>
        /// <para>
        /// Lists in-progress uploads only for those keys that begin with the specified prefix.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("KeyPrefix")]
        public System.String Prefix { get; set; }
        #endregion

        #region Parameter UploadIdMarker
        /// <summary>
        /// Together with key-marker, specifies the multipart upload after which listing should begin. 
        /// If key-marker is not specified, the upload-id-marker parameter is ignored. Otherwise, 
        /// any multipart uploads for a key equal to the key-marker might be included in the list only 
        /// if they have an upload ID lexicographically greater than the specified upload-id-marker.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UploadIdMarker { get; set; }
        #endregion


        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MultipartUploads'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.ListMultipartUploadsResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.ListMultipartUploadsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MultipartUploads";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of KeyMarker
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.ListMultipartUploadsResponse, GetMultipartUploadCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }

            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            context.Encoding = this.Encoding;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Delimiter = this.Delimiter;
            context.KeyMarker = this.KeyMarker;
            context.MaxUpload = this.MaxUpload;
            context.Prefix = this.Prefix;
            context.UploadIdMarker = this.UploadIdMarker;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxUpload)) && this.MaxUpload.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxUpload parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxUpload" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif

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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^");
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.S3.Model.ListMultipartUploadsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Delimiter != null)
            {
                request.Delimiter = cmdletContext.Delimiter;
            }
            if (cmdletContext.MaxUpload != null)
            {
                request.MaxUploads = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxUpload.Value);
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.UploadIdMarker != null)
            {
                request.UploadIdMarker = cmdletContext.UploadIdMarker;
            }
            
            // Initialize loop variant and commence piping
            var _nextKeyMarkerToken = cmdletContext.KeyMarker;
            var _nextUploadIdMarkerToken = cmdletContext.UploadIdMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.KeyMarker)); // If key-marker is not specified, the upload-id-marker parameter is ignored

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.KeyMarker = _nextKeyMarkerToken;
                request.UploadIdMarker = _nextUploadIdMarkerToken;
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
                    
                    _nextKeyMarkerToken = response.NextKeyMarker;
                    _nextUploadIdMarkerToken = response.NextUploadIdMarker;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextKeyMarkerToken) && AutoIterationHelpers.HasValue(_nextUploadIdMarkerToken));
            
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
            var request = new Amazon.S3.Model.ListMultipartUploadsRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.Encoding != null)
            {
                request.Encoding = cmdletContext.Encoding;
            }
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.Delimiter != null)
            {
                request.Delimiter = cmdletContext.Delimiter;
            }
            if (cmdletContext.Prefix != null)
            {
                request.Prefix = cmdletContext.Prefix;
            }
            if (cmdletContext.UploadIdMarker != null)
            {
                request.UploadIdMarker = cmdletContext.UploadIdMarker;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextKeyMarkerToken = null;
            System.String _nextUploadIdMarkerToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.KeyMarker))
            {
                _nextKeyMarkerToken = cmdletContext.KeyMarker;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.UploadIdMarker))
            {
                _nextUploadIdMarkerToken = cmdletContext.UploadIdMarker;
            }
            if (cmdletContext.MaxUpload.HasValue)
            {
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxUpload;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.KeyMarker)); // If key-marker is not specified, the upload-id-marker parameter is ignored

            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.KeyMarker = _nextKeyMarkerToken;
                request.UploadIdMarker = _nextUploadIdMarkerToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxUploads = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.MultipartUploads.Count;
                    
                    _nextKeyMarkerToken = response.NextKeyMarker;
                    _nextUploadIdMarkerToken = response.NextUploadIdMarker;
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextKeyMarkerToken) && AutoIterationHelpers.HasValue(_nextUploadIdMarkerToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
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
        
        private Amazon.S3.Model.ListMultipartUploadsResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.ListMultipartUploadsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "ListMultipartUploads");
            try
            {
                return client.ListMultipartUploadsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.S3.EncodingType Encoding { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Delimiter { get; set; }
            public System.String KeyMarker { get; set; }
            public int? MaxUpload { get; set; }
            public System.String Prefix { get; set; }
            public System.String UploadIdMarker { get; set; }
            public System.Func<Amazon.S3.Model.ListMultipartUploadsResponse, GetMultipartUploadCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MultipartUploads;
        }
        
    }
}
