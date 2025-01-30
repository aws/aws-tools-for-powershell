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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// For a given input image, first detects the largest face in the image, and then searches
    /// the specified collection for matching faces. The operation compares the features of
    /// the input face with faces in the specified collection. 
    /// 
    ///  <note><para>
    /// To search for all faces in an input image, you might first call the <a>IndexFaces</a>
    /// operation, and then use the face IDs returned in subsequent calls to the <a>SearchFaces</a>
    /// operation. 
    /// </para><para>
    ///  You can also call the <c>DetectFaces</c> operation and use the bounding boxes in
    /// the response to make face crops, which then you can pass in to the <c>SearchFacesByImage</c>
    /// operation. 
    /// </para></note><para>
    /// You pass the input image either as base64-encoded image bytes or as a reference to
    /// an image in an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition
    /// operations, passing image bytes is not supported. The image must be either a PNG or
    /// JPEG formatted file. 
    /// </para><para>
    ///  The response returns an array of faces that match, ordered by similarity score with
    /// the highest similarity first. More specifically, it is an array of metadata for each
    /// face match found. Along with the metadata, the response also includes a <c>similarity</c>
    /// indicating how similar the face is to the input face. In the response, the operation
    /// also returns the bounding box (and a confidence level that the bounding box contains
    /// a face) of the face that Amazon Rekognition used for the input image. 
    /// </para><para>
    /// If no faces are detected in the input image, <c>SearchFacesByImage</c> returns an
    /// <c>InvalidParameterException</c> error. 
    /// </para><para>
    /// For an example, Searching for a Face Using an Image in the Amazon Rekognition Developer
    /// Guide.
    /// </para><para>
    /// The <c>QualityFilter</c> input parameter allows you to filter out detected faces that
    /// don’t meet a required quality bar. The quality bar is based on a variety of common
    /// use cases. Use <c>QualityFilter</c> to set the quality bar for filtering by specifying
    /// <c>LOW</c>, <c>MEDIUM</c>, or <c>HIGH</c>. If you do not want to filter detected faces,
    /// specify <c>NONE</c>. The default value is <c>NONE</c>.
    /// </para><note><para>
    /// To use quality filtering, you need a collection associated with version 3 of the face
    /// model or higher. To get the version of the face model associated with a collection,
    /// call <a>DescribeCollection</a>. 
    /// </para></note><para>
    /// This operation requires permissions to perform the <c>rekognition:SearchFacesByImage</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "REKFacesByImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchFacesByImageResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition SearchFacesByImage API operation.", Operation = new[] {"SearchFacesByImage"}, SelectReturnType = typeof(Amazon.Rekognition.Model.SearchFacesByImageResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchFacesByImageResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.SearchFacesByImageResponse object containing multiple properties."
    )]
    public partial class SearchREKFacesByImageCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImageBucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageBucket { get; set; }
        #endregion
        
        #region Parameter ImageContent
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs. Note that the maximum image size you can pass to
        /// <c>DetectCustomLabels</c> is 4MB. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ImageContent { get; set; }
        #endregion
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>ID of the collection to search.</para>
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
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the minimum confidence in the face match to return. For example,
        /// don't return any matches where confidence in matches is less than 70%. The default
        /// value is 80%.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>Maximum number of faces to return. The operation returns the maximum number of faces
        /// with the highest confidence in the match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxFaces")]
        public System.Int32? MaxFace { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter QualityFilter
        /// <summary>
        /// <para>
        /// <para>A filter that specifies a quality bar for how much filtering is done to identify faces.
        /// Filtered faces aren't searched for in the collection. If you specify <c>AUTO</c>,
        /// Amazon Rekognition chooses the quality bar. If you specify <c>LOW</c>, <c>MEDIUM</c>,
        /// or <c>HIGH</c>, filtering removes all faces that don’t meet the chosen quality bar.
        /// The quality bar is based on a variety of common use cases. Low-quality detections
        /// can occur for a number of reasons. Some examples are an object that's misidentified
        /// as a face, a face that's too blurry, or a face with a pose that's too extreme to use.
        /// If you specify <c>NONE</c>, no filtering is performed. The default value is <c>NONE</c>.
        /// </para><para>To use quality filtering, the collection you are using must be associated with version
        /// 3 of the face model or higher.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Rekognition.QualityFilter")]
        public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
        #endregion
        
        #region Parameter ImageVersion
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.SearchFacesByImageResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.SearchFacesByImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CollectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CollectionId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CollectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKFacesByImage (SearchFacesByImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.SearchFacesByImageResponse, SearchREKFacesByImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CollectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CollectionId = this.CollectionId;
            #if MODULAR
            if (this.CollectionId == null && ParameterWasBound(nameof(this.CollectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter CollectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FaceMatchThreshold = this.FaceMatchThreshold;
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            context.MaxFace = this.MaxFace;
            context.QualityFilter = this.QualityFilter;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _ImageContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.SearchFacesByImageRequest();
                
                if (cmdletContext.CollectionId != null)
                {
                    request.CollectionId = cmdletContext.CollectionId;
                }
                if (cmdletContext.FaceMatchThreshold != null)
                {
                    request.FaceMatchThreshold = cmdletContext.FaceMatchThreshold.Value;
                }
                
                 // populate Image
                var requestImageIsNull = true;
                request.Image = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestImage_imageContent = null;
                if (cmdletContext.ImageContent != null)
                {
                    _ImageContentStream = new System.IO.MemoryStream(cmdletContext.ImageContent);
                    requestImage_imageContent = _ImageContentStream;
                }
                if (requestImage_imageContent != null)
                {
                    request.Image.Bytes = requestImage_imageContent;
                    requestImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestImage_image_S3Object = null;
                
                 // populate S3Object
                var requestImage_image_S3ObjectIsNull = true;
                requestImage_image_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestImage_image_S3Object_imageBucket = null;
                if (cmdletContext.ImageBucket != null)
                {
                    requestImage_image_S3Object_imageBucket = cmdletContext.ImageBucket;
                }
                if (requestImage_image_S3Object_imageBucket != null)
                {
                    requestImage_image_S3Object.Bucket = requestImage_image_S3Object_imageBucket;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_imageName = null;
                if (cmdletContext.ImageName != null)
                {
                    requestImage_image_S3Object_imageName = cmdletContext.ImageName;
                }
                if (requestImage_image_S3Object_imageName != null)
                {
                    requestImage_image_S3Object.Name = requestImage_image_S3Object_imageName;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_imageVersion = null;
                if (cmdletContext.ImageVersion != null)
                {
                    requestImage_image_S3Object_imageVersion = cmdletContext.ImageVersion;
                }
                if (requestImage_image_S3Object_imageVersion != null)
                {
                    requestImage_image_S3Object.Version = requestImage_image_S3Object_imageVersion;
                    requestImage_image_S3ObjectIsNull = false;
                }
                 // determine if requestImage_image_S3Object should be set to null
                if (requestImage_image_S3ObjectIsNull)
                {
                    requestImage_image_S3Object = null;
                }
                if (requestImage_image_S3Object != null)
                {
                    request.Image.S3Object = requestImage_image_S3Object;
                    requestImageIsNull = false;
                }
                 // determine if request.Image should be set to null
                if (requestImageIsNull)
                {
                    request.Image = null;
                }
                if (cmdletContext.MaxFace != null)
                {
                    request.MaxFaces = cmdletContext.MaxFace.Value;
                }
                if (cmdletContext.QualityFilter != null)
                {
                    request.QualityFilter = cmdletContext.QualityFilter;
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
                if( _ImageContentStream != null)
                {
                    _ImageContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.SearchFacesByImageResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.SearchFacesByImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "SearchFacesByImage");
            try
            {
                #if DESKTOP
                return client.SearchFacesByImage(request);
                #elif CORECLR
                return client.SearchFacesByImageAsync(request).GetAwaiter().GetResult();
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
            public System.String CollectionId { get; set; }
            public System.Single? FaceMatchThreshold { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Int32? MaxFace { get; set; }
            public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
            public System.Func<Amazon.Rekognition.Model.SearchFacesByImageResponse, SearchREKFacesByImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
