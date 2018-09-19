/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Amazon Rekognition does not save the actual faces detected. Instead, the underlying
    /// detection algorithm first detects the faces in the input image, and for each face
    /// extracts facial features into a feature vector, and stores it in the back-end database.
    /// Amazon Rekognition uses feature vectors when performing face match and search operations
    /// using the and operations.
    /// </para><para>
    /// To get the number of faces in a collection, call . 
    /// </para><para>
    /// If you are using version 1.0 of the face detection model, <code>IndexFaces</code>
    /// indexes the 15 largest faces in the input image. Later versions of the face detection
    /// model index the 100 largest faces in the input image. To determine which version of
    /// the model you are using, call and supply the collection ID. You also get the model
    /// version from the value of <code>FaceModelVersion</code> in the response from <code>IndexFaces</code>.
    /// 
    /// </para><para>
    /// For more information, see Model Versioning in the Amazon Rekognition Developer Guide.
    /// </para><para>
    /// If you provide the optional <code>ExternalImageID</code> for the input image you provided,
    /// Amazon Rekognition associates this ID with all faces that it detects. When you call
    /// the operation, the response returns the external ID. You can use this external image
    /// ID to create a client-side index to associate the faces with each image. You can then
    /// use the index to find all faces in an image.
    /// </para><para>
    /// You can specify the maximum number of faces to index with the <code>MaxFaces</code>
    /// input parameter. This is useful when you want to index the largest faces in an image,
    /// and you don't want to index other faces detected in the image.
    /// </para><para>
    /// The <code>QualityFilter</code> input parameter allows you to filter out detected faces
    /// that don’t meet the required quality bar chosen by Amazon Rekognition. The quality
    /// bar is based on a variety of common use cases.
    /// </para><para>
    /// In response, the operation returns an array of metadata for all detected faces, <code>FaceRecords</code>.
    /// This includes: 
    /// </para><ul><li><para>
    /// The bounding box, <code>BoundingBox</code>, of the detected face. 
    /// </para></li><li><para>
    /// A confidence value, <code>Confidence</code>, indicating the confidence that the bounding
    /// box contains a face.
    /// </para></li><li><para>
    /// A face ID, <code>faceId</code>, assigned by the service for each face that is detected
    /// and stored.
    /// </para></li><li><para>
    /// An image ID, <code>ImageId</code>, assigned by the service for the input image.
    /// </para></li></ul><para>
    /// If you request all facial attributes (using the <code>detectionAttributes</code> parameter),
    /// Amazon Rekognition returns detailed facial attributes such as facial landmarks (for
    /// example, location of eye and mouth) and other facial attributes such gender. If you
    /// provide the same image, specify the same collection, and use the same external ID
    /// in the <code>IndexFaces</code> operation, Amazon Rekognition doesn't save duplicate
    /// face metadata.
    /// </para><para>
    /// Information about faces detected in an image, but not indexed, is returned in an array
    /// of objects, <code>UnindexedFaces</code>. Faces are not indexed for reasons such as:
    /// </para><ul><li><para>
    /// The face is too blurry.
    /// </para></li><li><para>
    /// The image is too dark.
    /// </para></li><li><para>
    /// The face has an extreme pose.
    /// </para></li><li><para>
    /// The face is too small.
    /// </para></li><li><para>
    /// The number of faces detected exceeds the value of the <code>MaxFaces</code> request
    /// parameter.
    /// </para></li></ul><para>
    /// For more information, see Adding Faces to a Collection in the Amazon Rekognition Developer
    /// Guide.
    /// </para><para>
    /// The input image is passed either as base64-encoded image bytes or as a reference to
    /// an image in an Amazon S3 bucket. If you use the Amazon CLI to call Amazon Rekognition
    /// operations, passing image bytes is not supported. The image must be either a PNG or
    /// JPEG formatted file. 
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:IndexFaces</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "REKDetectedFacesToCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.IndexFacesResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition IndexFaces API operation.", Operation = new[] {"IndexFaces"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.IndexFacesResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.IndexFacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddREKDetectedFacesToCollectionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter ImageBucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageBucket { get; set; }
        #endregion
        
        #region Parameter ImageContent
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] ImageContent { get; set; }
        #endregion
        
        #region Parameter CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of an existing collection to which you want to add the faces that are detected
        /// in the input images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter DetectionAttribute
        /// <summary>
        /// <para>
        /// <para>An array of facial attributes that you want to be returned. This can be the default
        /// list of attributes or all attributes. If you don't specify a value for <code>Attributes</code>
        /// or if you specify <code>["DEFAULT"]</code>, the API returns the following subset of
        /// facial attributes: <code>BoundingBox</code>, <code>Confidence</code>, <code>Pose</code>,
        /// <code>Quality</code> and <code>Landmarks</code>. If you provide <code>["ALL"]</code>,
        /// all facial attributes are returned but the operation will take longer to complete.</para><para>If you provide both, <code>["ALL", "DEFAULT"]</code>, the service uses a logical AND
        /// operator to determine which attributes to return (in this case, all attributes). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DetectionAttributes")]
        public System.String[] DetectionAttribute { get; set; }
        #endregion
        
        #region Parameter ExternalImageId
        /// <summary>
        /// <para>
        /// <para>ID you want to assign to all the faces detected in the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalImageId { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>The maximum number of faces to index. The value of <code>MaxFaces</code> must be greater
        /// than or equal to 1. <code>IndexFaces</code> returns no more that 100 detected faces
        /// in an image, even if you specify a larger value for <code>MaxFaces</code>.</para><para>If <code>IndexFaces</code> detects more faces than the value of <code>MaxFaces</code>,
        /// the faces with the lowest quality are filtered out first. If there are still more
        /// faces than the value of <code>MaxFaces</code>, the faces with the smallest bounding
        /// boxes are filtered out (up to the number needed to satisfy the value of <code>MaxFaces</code>).
        /// Information about the unindexed faces is available in the <code>UnindexedFaces</code>
        /// array. </para><para>The faces returned by <code>IndexFaces</code> are sorted, in descending order, by
        /// the largest face bounding box size, to the smallest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxFaces")]
        public System.Int32 MaxFace { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter QualityFilter
        /// <summary>
        /// <para>
        /// <para>Specifies how much filtering is done to identify faces detected with low quality.
        /// Filtered faces are not indexed. If you specify <code>AUTO</code>, filtering prioritizes
        /// the identification of faces that don’t meet the required quality bar chosen by Amazon
        /// Rekognition. The quality bar is based on a variety of common use cases. Low quality
        /// detections can arise for a number of reasons. For example, an object misidentified
        /// as a face, a face that is too blurry, or a face with a pose that is too extreme to
        /// use. If you specify <code>NONE</code>, no filtering is performed. The default value
        /// is NONE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Rekognition.QualityFilter")]
        public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
        #endregion
        
        #region Parameter ImageVersion
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageVersion { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CollectionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-REKDetectedFacesToCollection (IndexFaces)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CollectionId = this.CollectionId;
            if (this.DetectionAttribute != null)
            {
                context.DetectionAttributes = new List<System.String>(this.DetectionAttribute);
            }
            context.ExternalImageId = this.ExternalImageId;
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            if (ParameterWasBound("MaxFace"))
                context.MaxFaces = this.MaxFace;
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
                if (cmdletContext.DetectionAttributes != null)
                {
                    request.DetectionAttributes = cmdletContext.DetectionAttributes;
                }
                if (cmdletContext.ExternalImageId != null)
                {
                    request.ExternalImageId = cmdletContext.ExternalImageId;
                }
                
                 // populate Image
                bool requestImageIsNull = true;
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
                bool requestImage_image_S3ObjectIsNull = true;
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
                if (cmdletContext.MaxFaces != null)
                {
                    request.MaxFaces = cmdletContext.MaxFaces.Value;
                }
                if (cmdletContext.QualityFilter != null)
                {
                    request.QualityFilter = cmdletContext.QualityFilter;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response;
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response,
                        Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.IndexFacesAsync(request);
                return task.Result;
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
            public List<System.String> DetectionAttributes { get; set; }
            public System.String ExternalImageId { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Int32? MaxFaces { get; set; }
            public Amazon.Rekognition.QualityFilter QualityFilter { get; set; }
        }
        
    }
}
