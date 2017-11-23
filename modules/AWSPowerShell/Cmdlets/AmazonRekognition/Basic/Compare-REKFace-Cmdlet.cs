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
    /// Compares a face in the <i>source</i> input image with each of the 100 largest faces
    /// detected in the <i>target</i> input image. 
    /// 
    ///  <note><para>
    ///  If the source image contains multiple faces, the service detects the largest face
    /// and compares it with each face detected in the target image. 
    /// </para></note><para>
    /// You pass the input and target images either as base64-encoded image bytes or as a
    /// references to images in an Amazon S3 bucket. If you use the Amazon CLI to call Amazon
    /// Rekognition operations, passing image bytes is not supported. The image must be either
    /// a PNG or JPEG formatted file. 
    /// </para><para>
    /// In response, the operation returns an array of face matches ordered by similarity
    /// score in descending order. For each face match, the response provides a bounding box
    /// of the face, facial landmarks, pose details (pitch, role, and yaw), quality (brightness
    /// and sharpness), and confidence value (indicating the level of confidence that the
    /// bounding box contains a face). The response also provides a similarity score, which
    /// indicates how closely the faces match. 
    /// </para><note><para>
    /// By default, only faces with a similarity score of greater than or equal to 80% are
    /// returned in the response. You can change this value by specifying the <code>SimilarityThreshold</code>
    /// parameter.
    /// </para></note><para><code>CompareFaces</code> also returns an array of faces that don't match the source
    /// image. For each face, it returns a bounding box, confidence value, landmarks, pose
    /// details, and quality. The response also returns information about the face in the
    /// source image, including the bounding box of the face and confidence value.
    /// </para><para>
    /// If the image doesn't contain Exif metadata, <code>CompareFaces</code> returns orientation
    /// information for the source and target images. Use these values to display the images
    /// with the correct image orientation.
    /// </para><para>
    /// If no faces are detected in the source or target images, <code>CompareFaces</code>
    /// returns an <code>InvalidParameterException</code> error. 
    /// </para><note><para>
    ///  This is a stateless API operation. That is, data returned by this operation doesn't
    /// persist.
    /// </para></note><para>
    /// For an example, see <a>get-started-exercise-compare-faces</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:CompareFaces</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Compare", "REKFace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Rekognition.Model.CompareFacesResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition CompareFaces API operation.", Operation = new[] {"CompareFaces"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.CompareFacesResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.CompareFacesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class CompareREKFaceCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter SourceImageBucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceImageBucket { get; set; }
        #endregion
        
        #region Parameter TargetImageBucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetImageBucket { get; set; }
        #endregion
        
        #region Parameter SourceImageContent
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] SourceImageContent { get; set; }
        #endregion
        
        #region Parameter TargetImageContent
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public byte[] TargetImageContent { get; set; }
        #endregion
        
        #region Parameter SourceImageName
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceImageName { get; set; }
        #endregion
        
        #region Parameter TargetImageName
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetImageName { get; set; }
        #endregion
        
        #region Parameter SimilarityThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum level of confidence in the face matches that a match must meet to be included
        /// in the <code>FaceMatches</code> array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Single SimilarityThreshold { get; set; }
        #endregion
        
        #region Parameter SourceImageVersion
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceImageVersion { get; set; }
        #endregion
        
        #region Parameter TargetImageVersion
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetImageVersion { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Compare-REKFace (CompareFaces)"))
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
            
            if (ParameterWasBound("SimilarityThreshold"))
                context.SimilarityThreshold = this.SimilarityThreshold;
            context.SourceImageContent = this.SourceImageContent;
            context.SourceImageBucket = this.SourceImageBucket;
            context.SourceImageName = this.SourceImageName;
            context.SourceImageVersion = this.SourceImageVersion;
            context.TargetImageContent = this.TargetImageContent;
            context.TargetImageBucket = this.TargetImageBucket;
            context.TargetImageName = this.TargetImageName;
            context.TargetImageVersion = this.TargetImageVersion;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _SourceImageContentStream = null;
            System.IO.MemoryStream _TargetImageContentStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.CompareFacesRequest();
                
                if (cmdletContext.SimilarityThreshold != null)
                {
                    request.SimilarityThreshold = cmdletContext.SimilarityThreshold.Value;
                }
                
                 // populate SourceImage
                bool requestSourceImageIsNull = true;
                request.SourceImage = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestSourceImage_sourceImageContent = null;
                if (cmdletContext.SourceImageContent != null)
                {
                    _SourceImageContentStream = new System.IO.MemoryStream(cmdletContext.SourceImageContent);
                    requestSourceImage_sourceImageContent = _SourceImageContentStream;
                }
                if (requestSourceImage_sourceImageContent != null)
                {
                    request.SourceImage.Bytes = requestSourceImage_sourceImageContent;
                    requestSourceImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestSourceImage_sourceImage_S3Object = null;
                
                 // populate S3Object
                bool requestSourceImage_sourceImage_S3ObjectIsNull = true;
                requestSourceImage_sourceImage_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestSourceImage_sourceImage_S3Object_sourceImageBucket = null;
                if (cmdletContext.SourceImageBucket != null)
                {
                    requestSourceImage_sourceImage_S3Object_sourceImageBucket = cmdletContext.SourceImageBucket;
                }
                if (requestSourceImage_sourceImage_S3Object_sourceImageBucket != null)
                {
                    requestSourceImage_sourceImage_S3Object.Bucket = requestSourceImage_sourceImage_S3Object_sourceImageBucket;
                    requestSourceImage_sourceImage_S3ObjectIsNull = false;
                }
                System.String requestSourceImage_sourceImage_S3Object_sourceImageName = null;
                if (cmdletContext.SourceImageName != null)
                {
                    requestSourceImage_sourceImage_S3Object_sourceImageName = cmdletContext.SourceImageName;
                }
                if (requestSourceImage_sourceImage_S3Object_sourceImageName != null)
                {
                    requestSourceImage_sourceImage_S3Object.Name = requestSourceImage_sourceImage_S3Object_sourceImageName;
                    requestSourceImage_sourceImage_S3ObjectIsNull = false;
                }
                System.String requestSourceImage_sourceImage_S3Object_sourceImageVersion = null;
                if (cmdletContext.SourceImageVersion != null)
                {
                    requestSourceImage_sourceImage_S3Object_sourceImageVersion = cmdletContext.SourceImageVersion;
                }
                if (requestSourceImage_sourceImage_S3Object_sourceImageVersion != null)
                {
                    requestSourceImage_sourceImage_S3Object.Version = requestSourceImage_sourceImage_S3Object_sourceImageVersion;
                    requestSourceImage_sourceImage_S3ObjectIsNull = false;
                }
                 // determine if requestSourceImage_sourceImage_S3Object should be set to null
                if (requestSourceImage_sourceImage_S3ObjectIsNull)
                {
                    requestSourceImage_sourceImage_S3Object = null;
                }
                if (requestSourceImage_sourceImage_S3Object != null)
                {
                    request.SourceImage.S3Object = requestSourceImage_sourceImage_S3Object;
                    requestSourceImageIsNull = false;
                }
                 // determine if request.SourceImage should be set to null
                if (requestSourceImageIsNull)
                {
                    request.SourceImage = null;
                }
                
                 // populate TargetImage
                bool requestTargetImageIsNull = true;
                request.TargetImage = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestTargetImage_targetImageContent = null;
                if (cmdletContext.TargetImageContent != null)
                {
                    _TargetImageContentStream = new System.IO.MemoryStream(cmdletContext.TargetImageContent);
                    requestTargetImage_targetImageContent = _TargetImageContentStream;
                }
                if (requestTargetImage_targetImageContent != null)
                {
                    request.TargetImage.Bytes = requestTargetImage_targetImageContent;
                    requestTargetImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestTargetImage_targetImage_S3Object = null;
                
                 // populate S3Object
                bool requestTargetImage_targetImage_S3ObjectIsNull = true;
                requestTargetImage_targetImage_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestTargetImage_targetImage_S3Object_targetImageBucket = null;
                if (cmdletContext.TargetImageBucket != null)
                {
                    requestTargetImage_targetImage_S3Object_targetImageBucket = cmdletContext.TargetImageBucket;
                }
                if (requestTargetImage_targetImage_S3Object_targetImageBucket != null)
                {
                    requestTargetImage_targetImage_S3Object.Bucket = requestTargetImage_targetImage_S3Object_targetImageBucket;
                    requestTargetImage_targetImage_S3ObjectIsNull = false;
                }
                System.String requestTargetImage_targetImage_S3Object_targetImageName = null;
                if (cmdletContext.TargetImageName != null)
                {
                    requestTargetImage_targetImage_S3Object_targetImageName = cmdletContext.TargetImageName;
                }
                if (requestTargetImage_targetImage_S3Object_targetImageName != null)
                {
                    requestTargetImage_targetImage_S3Object.Name = requestTargetImage_targetImage_S3Object_targetImageName;
                    requestTargetImage_targetImage_S3ObjectIsNull = false;
                }
                System.String requestTargetImage_targetImage_S3Object_targetImageVersion = null;
                if (cmdletContext.TargetImageVersion != null)
                {
                    requestTargetImage_targetImage_S3Object_targetImageVersion = cmdletContext.TargetImageVersion;
                }
                if (requestTargetImage_targetImage_S3Object_targetImageVersion != null)
                {
                    requestTargetImage_targetImage_S3Object.Version = requestTargetImage_targetImage_S3Object_targetImageVersion;
                    requestTargetImage_targetImage_S3ObjectIsNull = false;
                }
                 // determine if requestTargetImage_targetImage_S3Object should be set to null
                if (requestTargetImage_targetImage_S3ObjectIsNull)
                {
                    requestTargetImage_targetImage_S3Object = null;
                }
                if (requestTargetImage_targetImage_S3Object != null)
                {
                    request.TargetImage.S3Object = requestTargetImage_targetImage_S3Object;
                    requestTargetImageIsNull = false;
                }
                 // determine if request.TargetImage should be set to null
                if (requestTargetImageIsNull)
                {
                    request.TargetImage = null;
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
                if( _SourceImageContentStream != null)
                {
                    _SourceImageContentStream.Dispose();
                }
                if( _TargetImageContentStream != null)
                {
                    _TargetImageContentStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.CompareFacesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CompareFacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CompareFaces");
            try
            {
                #if DESKTOP
                return client.CompareFaces(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CompareFacesAsync(request);
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
            public System.Single? SimilarityThreshold { get; set; }
            public byte[] SourceImageContent { get; set; }
            public System.String SourceImageBucket { get; set; }
            public System.String SourceImageName { get; set; }
            public System.String SourceImageVersion { get; set; }
            public byte[] TargetImageContent { get; set; }
            public System.String TargetImageBucket { get; set; }
            public System.String TargetImageName { get; set; }
            public System.String TargetImageVersion { get; set; }
        }
        
    }
}
