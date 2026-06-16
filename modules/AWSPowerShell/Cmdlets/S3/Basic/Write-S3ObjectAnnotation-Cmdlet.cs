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
    /// Attaches an annotation to an Amazon S3 object. An annotation is a named payload of
    /// 1 byte to 1 MiB that you can associate with a specific object or object version. Each
    /// object can have up to 1,000 annotations.
    /// 
    ///  
    /// <para>
    /// For annotation naming rules and restrictions, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/annotations-overview.html">Annotation
    /// naming guidelines</a> in the <i>Amazon S3 User Guide</i>.
    /// </para><para>
    /// Annotations inherit the encryption of their parent object. For objects without server-side
    /// encryption, annotations are encrypted with SSE-S3 (the default for new objects). Objects
    /// encrypted with SSE-C cannot have annotations.
    /// </para><para>
    /// To use this operation, you must have the <c>s3:PutObjectAnnotation</c> permission.
    /// If the bucket has Requester Pays enabled, you must include the <c>x-amz-request-payer</c>
    /// header.
    /// </para><note><para>
    /// Annotations are not supported by the following features: S3 Inventory Reports, API
    /// Gateway, S3 Storage Lens, Amazon S3 File Gateway, Amazon FSx, S3 on Outposts, and
    /// S3 Express One Zone (directory buckets).
    /// </para></note><para>
    /// The following operations are related to <c>PutObjectAnnotation</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetObjectAnnotation.html">GetObjectAnnotation</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_ListObjectAnnotations.html">ListObjectAnnotations</a></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_DeleteObjectAnnotation.html">DeleteObjectAnnotation</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3ObjectAnnotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.S3.Model.PutObjectAnnotationResponse")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutObjectAnnotation API operation.", Operation = new[] {"PutObjectAnnotation"}, SelectReturnType = typeof(Amazon.S3.Model.PutObjectAnnotationResponse))]
    [AWSCmdletOutput("Amazon.S3.Model.PutObjectAnnotationResponse",
        "This cmdlet returns an Amazon.S3.Model.PutObjectAnnotationResponse object containing multiple properties."
    )]
    public partial class WriteS3ObjectAnnotationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnnotationName
        /// <summary>
        /// <para>
        /// <para>The name of the annotation.</para><para>Length Constraints: Minimum length of 1. Maximum length of 512 bytes.</para>
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
        public System.String AnnotationName { get; set; }
        #endregion
        
        #region Parameter AnnotationPayload
        /// <summary>
        /// <para>
        /// <para>The annotation payload. Must be between 1 byte and 1 MiB in size, and must be valid
        /// UTF-8 encoded text. If the payload contains invalid UTF-8 bytes, the request fails
        /// with HTTP 415 (Unsupported Media Type). To store binary data, encode the payload using
        /// Base64 before uploading.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] AnnotationPayload { get; set; }
        #endregion
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the bucket that contains the object.</para>
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
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// <para>The checksum algorithm to use. Supported values: <c>CRC32</c>, <c>CRC32C</c>, <c>CRC64NVME</c>,
        /// <c>SHA1</c>, <c>SHA256</c>, <c>SHA512</c>, <c>MD5</c>, <c>XXHASH64</c>, <c>XXHASH3</c>,
        /// <c>XXHASH128</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter ChecksumCRC32
        /// <summary>
        /// <para>
        /// <para>Base64-encoded CRC32 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumCRC32 { get; set; }
        #endregion
        
        #region Parameter ChecksumCRC32C
        /// <summary>
        /// <para>
        /// <para>Base64-encoded CRC32C checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumCRC32C { get; set; }
        #endregion
        
        #region Parameter ChecksumCRC64NVME
        /// <summary>
        /// <para>
        /// <para>Base64-encoded CRC64NVME checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumCRC64NVME { get; set; }
        #endregion
        
        #region Parameter ChecksumMD5
        /// <summary>
        /// <para>
        /// <para>Base64-encoded MD5 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumMD5 { get; set; }
        #endregion
        
        #region Parameter ChecksumSHA1
        /// <summary>
        /// <para>
        /// <para>Base64-encoded SHA1 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumSHA1 { get; set; }
        #endregion
        
        #region Parameter ChecksumSHA256
        /// <summary>
        /// <para>
        /// <para>Base64-encoded SHA256 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumSHA256 { get; set; }
        #endregion
        
        #region Parameter ChecksumSHA512
        /// <summary>
        /// <para>
        /// <para>Base64-encoded SHA512 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumSHA512 { get; set; }
        #endregion
        
        #region Parameter ChecksumXXHASH128
        /// <summary>
        /// <para>
        /// <para>Base64-encoded XXHASH128 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumXXHASH128 { get; set; }
        #endregion
        
        #region Parameter ChecksumXXHASH3
        /// <summary>
        /// <para>
        /// <para>Base64-encoded XXHASH3 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumXXHASH3 { get; set; }
        #endregion
        
        #region Parameter ChecksumXXHASH64
        /// <summary>
        /// <para>
        /// <para>Base64-encoded XXHASH64 checksum of the annotation payload.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChecksumXXHASH64 { get; set; }
        #endregion
        
        #region Parameter ContentMD5
        /// <summary>
        /// <para>
        /// <para>Base64-encoded MD5 digest of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentMD5 { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the bucket is owned by a different
        /// account, the request fails with an HTTP 403 (Access Denied) error.</para>
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
        
        #region Parameter ObjectIfMatch
        /// <summary>
        /// <para>
        /// <para>If specified, the operation only succeeds if the object's ETag matches the provided
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ObjectIfMatch { get; set; }
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
        
        #region Parameter VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the object to attach the annotation to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VersionId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutObjectAnnotationResponse).
        /// Specifying the name of a property of type Amazon.S3.Model.PutObjectAnnotationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.AnnotationName),
                nameof(this.BucketName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3ObjectAnnotation (PutObjectAnnotation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutObjectAnnotationResponse, WriteS3ObjectAnnotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnnotationName = this.AnnotationName;
            #if MODULAR
            if (this.AnnotationName == null && ParameterWasBound(nameof(this.AnnotationName)))
            {
                WriteWarning("You are passing $null as a value for parameter AnnotationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnnotationPayload = this.AnnotationPayload;
            #if MODULAR
            if (this.AnnotationPayload == null && ParameterWasBound(nameof(this.AnnotationPayload)))
            {
                WriteWarning("You are passing $null as a value for parameter AnnotationPayload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BucketName = this.BucketName;
            #if MODULAR
            if (this.BucketName == null && ParameterWasBound(nameof(this.BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
            context.ChecksumCRC32 = this.ChecksumCRC32;
            context.ChecksumCRC32C = this.ChecksumCRC32C;
            context.ChecksumCRC64NVME = this.ChecksumCRC64NVME;
            context.ChecksumMD5 = this.ChecksumMD5;
            context.ChecksumSHA1 = this.ChecksumSHA1;
            context.ChecksumSHA256 = this.ChecksumSHA256;
            context.ChecksumSHA512 = this.ChecksumSHA512;
            context.ChecksumXXHASH128 = this.ChecksumXXHASH128;
            context.ChecksumXXHASH3 = this.ChecksumXXHASH3;
            context.ChecksumXXHASH64 = this.ChecksumXXHASH64;
            context.ContentMD5 = this.ContentMD5;
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.Key = this.Key;
            #if MODULAR
            if (this.Key == null && ParameterWasBound(nameof(this.Key)))
            {
                WriteWarning("You are passing $null as a value for parameter Key which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectIfMatch = this.ObjectIfMatch;
            context.RequestPayer = this.RequestPayer;
            context.VersionId = this.VersionId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _AnnotationPayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.S3.Model.PutObjectAnnotationRequest();
                
                if (cmdletContext.AnnotationName != null)
                {
                    request.AnnotationName = cmdletContext.AnnotationName;
                }
                if (cmdletContext.AnnotationPayload != null)
                {
                    _AnnotationPayloadStream = new System.IO.MemoryStream(cmdletContext.AnnotationPayload);
                    request.AnnotationPayload = _AnnotationPayloadStream;
                }
                if (cmdletContext.BucketName != null)
                {
                    request.BucketName = cmdletContext.BucketName;
                }
                if (cmdletContext.ChecksumAlgorithm != null)
                {
                    request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
                }
                if (cmdletContext.ChecksumCRC32 != null)
                {
                    request.ChecksumCRC32 = cmdletContext.ChecksumCRC32;
                }
                if (cmdletContext.ChecksumCRC32C != null)
                {
                    request.ChecksumCRC32C = cmdletContext.ChecksumCRC32C;
                }
                if (cmdletContext.ChecksumCRC64NVME != null)
                {
                    request.ChecksumCRC64NVME = cmdletContext.ChecksumCRC64NVME;
                }
                if (cmdletContext.ChecksumMD5 != null)
                {
                    request.ChecksumMD5 = cmdletContext.ChecksumMD5;
                }
                if (cmdletContext.ChecksumSHA1 != null)
                {
                    request.ChecksumSHA1 = cmdletContext.ChecksumSHA1;
                }
                if (cmdletContext.ChecksumSHA256 != null)
                {
                    request.ChecksumSHA256 = cmdletContext.ChecksumSHA256;
                }
                if (cmdletContext.ChecksumSHA512 != null)
                {
                    request.ChecksumSHA512 = cmdletContext.ChecksumSHA512;
                }
                if (cmdletContext.ChecksumXXHASH128 != null)
                {
                    request.ChecksumXXHASH128 = cmdletContext.ChecksumXXHASH128;
                }
                if (cmdletContext.ChecksumXXHASH3 != null)
                {
                    request.ChecksumXXHASH3 = cmdletContext.ChecksumXXHASH3;
                }
                if (cmdletContext.ChecksumXXHASH64 != null)
                {
                    request.ChecksumXXHASH64 = cmdletContext.ChecksumXXHASH64;
                }
                if (cmdletContext.ContentMD5 != null)
                {
                    request.ContentMD5 = cmdletContext.ContentMD5;
                }
                if (cmdletContext.ExpectedBucketOwner != null)
                {
                    request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
                }
                if (cmdletContext.Key != null)
                {
                    request.Key = cmdletContext.Key;
                }
                if (cmdletContext.ObjectIfMatch != null)
                {
                    request.ObjectIfMatch = cmdletContext.ObjectIfMatch;
                }
                if (cmdletContext.RequestPayer != null)
                {
                    request.RequestPayer = cmdletContext.RequestPayer;
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
            finally
            {
                if( _AnnotationPayloadStream != null)
                {
                    _AnnotationPayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.S3.Model.PutObjectAnnotationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutObjectAnnotationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutObjectAnnotation");
            try
            {
                return client.PutObjectAnnotationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnnotationName { get; set; }
            public byte[] AnnotationPayload { get; set; }
            public System.String BucketName { get; set; }
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public System.String ChecksumCRC32 { get; set; }
            public System.String ChecksumCRC32C { get; set; }
            public System.String ChecksumCRC64NVME { get; set; }
            public System.String ChecksumMD5 { get; set; }
            public System.String ChecksumSHA1 { get; set; }
            public System.String ChecksumSHA256 { get; set; }
            public System.String ChecksumSHA512 { get; set; }
            public System.String ChecksumXXHASH128 { get; set; }
            public System.String ChecksumXXHASH3 { get; set; }
            public System.String ChecksumXXHASH64 { get; set; }
            public System.String ContentMD5 { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.String Key { get; set; }
            public System.String ObjectIfMatch { get; set; }
            public Amazon.S3.RequestPayer RequestPayer { get; set; }
            public System.String VersionId { get; set; }
            public System.Func<Amazon.S3.Model.PutObjectAnnotationResponse, WriteS3ObjectAnnotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
