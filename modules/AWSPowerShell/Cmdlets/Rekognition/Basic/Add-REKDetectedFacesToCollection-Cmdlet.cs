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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Detects faces in the input image and adds them to the specified collection. 
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition doesn't save the actual faces that are detected. Instead, the underlying
    /// detection algorithm first detects the faces in the input image. For each face, the
    /// algorithm extracts facial features into a feature vector, and stores it in the backend
    /// database. Amazon Rekognition uses feature vectors when it performs face match and
    /// search operations using the <a>SearchFaces</a> and <a>SearchFacesByImage</a> operations.
    /// </para><para>
    /// For more information, see Adding faces to a collection in the Amazon Rekognition Developer
    /// Guide.
    /// </para><para>
    /// To get the number of faces in a collection, call <a>DescribeCollection</a>. 
    /// </para><para>
    /// If you're using version 1.0 of the face detection model, <code>IndexFaces</code> indexes
    /// the 15 largest faces in the input image. Later versions of the face detection model
    /// index the 100 largest faces in the input image. 
    /// </para><para>
    /// If you're using version 4 or later of the face model, image orientation information
    /// is not returned in the <code>OrientationCorrection</code> field. 
    /// </para><para>
    /// To determine which version of the model you're using, call <a>DescribeCollection</a>
    /// and supply the collection ID. You can also get the model version from the value of
    /// <code>FaceModelVersion</code> in the response from <code>IndexFaces</code></para><para>
    /// For more information, see Model Versioning in the Amazon Rekognition Developer Guide.
    /// </para><para>
    /// If you provide the optional <code>ExternalImageId</code> for the input image you provided,
    /// Amazon Rekognition associates this ID with all faces that it detects. When you call
    /// the <a>ListFaces</a> operation, the response returns the external ID. You can use
    /// this external image ID to create a client-side index to associate the faces with each
    /// image. You can then use the index to find all faces in an image.
    /// </para><para>
    /// You can specify the maximum number of faces to index with the <code>MaxFaces</code>
    /// input parameter. This is useful when you want to index the largest faces in an image
    /// and don't want to index smaller faces, such as those belonging to people standing
    /// in the background.
    /// </para><para>
    /// The <code>QualityFilter</code> input parameter allows you to filter out detected faces
    /// that don’t meet a required quality bar. The quality bar is based on a variety of common
    /// use cases. By default, <code>IndexFaces</code> chooses the quality bar that's used
    /// to filter faces. You can also explicitly choose the quality bar. Use <code>QualityFilter</code>,
    /// to set the quality bar by specifying <code>LOW</code>, <code>MEDIUM</code>, or <code>HIGH</code>.
    /// If you do not want to filter detected faces, specify <code>NONE</code>. 
    /// </para><note><para>
    /// To use quality filtering, you need a collection associated with version 3 of the face
    /// model or higher. To get the version of the face model associated with a collection,
    /// call <a>DescribeCollection</a>. 
    /// </para></note><para>
    /// Information about faces detected in an image, but not indexed, is returned in an array
    /// of <a>UnindexedFace</a> objects, <code>UnindexedFaces</code>. Faces aren't indexed
    /// for reasons such as:
    /// </para><ul><li><para>
    /// The number of faces detected exceeds the value of the <code>MaxFaces</code> request
    /// parameter.
    /// </para></li><li><para>
    /// The face is too small compared to the image dimensions.
    /// </para></li><li><para>
    /// The face is too blurry.
    /// </para></li><li><para>
    /// The image is too dark.
    /// </para></li><li><para>
    /// The face has an extreme pose.
    /// </para></li><li><para>
    /// The face doesn’t have enough detail to be suitable for face search.
    /// </para></li></ul><para>
    /// In response, the <code>IndexFaces</code> operation returns an array of metadata for
    /// all detected faces, <code>FaceRecords</code>. This includes: 
    /// </para><ul><li><para>
    /// The bounding box, <code>BoundingBox</code>, of the detected face. 
    /// </para></li><li><para>
    /// A confidence value, <code>Confidence</code>, which indicates the confidence that the
    /// bounding box contains a face.
    /// </para></li><li><para>
    /// A face ID, <code>FaceId</code>, assigned by the service for each face that's detected
    /// and stored.
    /// </para></li><li><para>
    /// An image ID, <code>ImageId</code>, assigned by the service for the input image.
    /// </para></li></ul><para>
    /// If you request all facial attributes (by using the <code>detectionAttributes</code>
    /// parameter), Amazon Rekognition returns detailed facial attributes, such as facial
    /// landmarks (for example, location of eye and mouth) and other facial attributes. If
    /// you provide the same image, specify the same collection, and use the same external
    /// ID in the <code>IndexFaces</code> operation, Amazon Rekognition doesn't save duplicate
    /// face metadata.
    /// </para><para>
    /// The input image is passed either as base64-encoded image bytes, or as a reference
    /// to an image in an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition
    /// operations, passing image bytes isn't supported. The image must be formatted as a
    /// PNG or JPEG file. 
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:IndexFaces</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "REKDetectedFacesToCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.IndexFacesResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition IndexFaces API operation.", Operation = new[] {"IndexFaces"}, SelectReturnType = typeof(Amazon.Rekognition.Model.IndexFacesResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.IndexFacesResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.IndexFacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddREKDetectedFacesToCollectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
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
        /// <code>DetectCustomLabels</code> is 4MB. </para>
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
        /// <para>The ID of an existing collection to which you want to add the faces that are detected
        /// in the input images.</para>
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
        
        #region Parameter DetectionAttribute
        /// <summary>
        /// <para>
        /// <para>An array of facial attributes that you want to be returned. This can be the default
        /// list of attributes or all attributes. If you don't specify a value for <code>Attributes</code>
        /// or if you specify <code>["DEFAULT"]</code>, the API returns the following subset of
        /// facial attributes: <code>BoundingBox</code>, <code>Confidence</code>, <code>Pose</code>,
        /// <code>Quality</code>, and <code>Landmarks</code>. If you provide <code>["ALL"]</code>,
        /// all facial attributes are returned, but the operation takes longer to complete.</para><para>If you provide both, <code>["ALL", "DEFAULT"]</code>, the service uses a logical AND
        /// operator to determine which attributes to return (in this case, all attributes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DetectionAttributes")]
        public System.String[] DetectionAttribute { get; set; }
        #endregion
        
        #region Parameter ExternalImageId
        /// <summary>
        /// <para>
        /// <para>The ID you want to assign to all the faces detected in the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalImageId { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>The maximum number of faces to index. The value of <code>MaxFaces</code> must be greater
        /// than or equal to 1. <code>IndexFaces</code> returns no more than 100 detected faces
        /// in an image, even if you specify a larger value for <code>MaxFaces</code>.</para><para>If <code>IndexFaces</code> detects more faces than the value of <code>MaxFaces</code>,
        /// the faces with the lowest quality are filtered out first. If there are still more
        /// faces than the value of <code>MaxFaces</code>, the faces with the smallest bounding
        /// boxes are filtered out (up to the number that's needed to satisfy the value of <code>MaxFaces</code>).
        /// Information about the unindexed faces is available in the <code>UnindexedFaces</code>
        /// array. </para><para>The faces that are returned by <code>IndexFaces</code> are sorted by the largest face
        /// bounding box size to the smallest size, in descending order.</para><para><code>MaxFaces</code> can be used with a collection associated with any version of
        /// the face model.</para>
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
        /// Filtered faces aren't indexed. If you specify <code>AUTO</code>, Amazon Rekognition
        /// chooses the quality bar. If you specify <code>LOW</code>, <code>MEDIUM</code>, or
        /// <code>HIGH</code>, filtering removes all faces that don’t meet the chosen quality
        /// bar. The default value is <code>AUTO</code>. The quality bar is based on a variety
        /// of common use cases. Low-quality detections can occur for a number of reasons. Some
        /// examples are an object that's misidentified as a face, a face that's too blurry, or
        /// a face with a pose that's too extreme to use. If you specify <code>NONE</code>, no
        /// filtering is performed. </para><para>To use quality filtering, the collection you are using must be associated with version
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.IndexFacesResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.IndexFacesResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-REKDetectedFacesToCollection (IndexFaces)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.IndexFacesResponse, AddREKDetectedFacesToCollectionCmdlet>(Select) ??
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
            if (this.DetectionAttribute != null)
            {
                context.DetectionAttribute = new List<System.String>(this.DetectionAttribute);
            }
            context.ExternalImageId = this.ExternalImageId;
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
                var request = new Amazon.Rekognition.Model.IndexFacesRequest();
                
                if (cmdletContext.CollectionId != null)
                {
                    request.CollectionId = cmdletContext.CollectionId;
                }
                if (cmdletContext.DetectionAttribute != null)
                {
                    request.DetectionAttributes = cmdletContext.DetectionAttribute;
                }
                if (cmdletContext.ExternalImageId != null)
                {
                    request.ExternalImageId = cmdletContext.ExternalImageId;
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
        
        private Amazon.Rekognition.Model.IndexFacesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.IndexFacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "IndexFaces");
            try
            {
                #if DESKTOP
                return client.IndexFaces(request);
                #elif CORECLR
                return client.IndexFacesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DetectionAttribute { get; set; }
            public System.String ExternalImageId { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Int32? MaxFace { get; set; }
            public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
            public System.Func<Amazon.Rekognition.Model.IndexFacesResponse, AddREKDetectedFacesToCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
