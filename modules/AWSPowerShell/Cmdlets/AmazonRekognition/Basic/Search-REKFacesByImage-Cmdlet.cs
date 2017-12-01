/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    ///  To search for all faces in an input image, you might first call the operation, and
    /// then use the face IDs returned in subsequent calls to the operation. 
    /// </para><para>
    ///  You can also call the <code>DetectFaces</code> operation and use the bounding boxes
    /// in the response to make face crops, which then you can pass in to the <code>SearchFacesByImage</code>
    /// operation. 
    /// </para></note><para>
    /// You pass the input image either as base64-encoded image bytes or as a reference to
    /// an image in an Amazon S3 bucket. If you use the Amazon CLI to call Amazon Rekognition
    /// operations, passing image bytes is not supported. The image must be either a PNG or
    /// JPEG formatted file. 
    /// </para><para>
    ///  The response returns an array of faces that match, ordered by similarity score with
    /// the highest similarity first. More specifically, it is an array of metadata for each
    /// face match found. Along with the metadata, the response also includes a <code>similarity</code>
    /// indicating how similar the face is to the input face. In the response, the operation
    /// also returns the bounding box (and a confidence level that the bounding box contains
    /// a face) of the face that Amazon Rekognition used for the input image. 
    /// </para><para>
    /// For an example, see <a>search-face-with-image-procedure</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:SearchFacesByImage</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "REKFacesByImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.SearchFacesByImageResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition SearchFacesByImage API operation.", Operation = new[] {"SearchFacesByImage"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.SearchFacesByImageResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.SearchFacesByImageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchREKFacesByImageCmdlet : AmazonRekognitionClientCmdlet, IExecutor
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
        /// <para>ID of the collection to search.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the minimum confidence in the face match to return. For example,
        /// don't return any matches where confidence in matches is less than 70%.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Single FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter MaxFace
        /// <summary>
        /// <para>
        /// <para>Maximum number of faces to return. The operation returns the maximum number of faces
        /// with the highest confidence in the match.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-REKFacesByImage (SearchFacesByImage)"))
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
            if (ParameterWasBound("FaceMatchThreshold"))
                context.FaceMatchThreshold = this.FaceMatchThreshold;
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            if (ParameterWasBound("MaxFace"))
                context.MaxFaces = this.MaxFace;
            
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
        
        private Amazon.Rekognition.Model.SearchFacesByImageResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.SearchFacesByImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "SearchFacesByImage");
            try
            {
                #if DESKTOP
                return client.SearchFacesByImage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SearchFacesByImageAsync(request);
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
            public System.Single? FaceMatchThreshold { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Int32? MaxFaces { get; set; }
        }
        
    }
}
