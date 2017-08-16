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
    /// Returns an array of celebrities recognized in the input image. The image is passed
    /// either as base64-encoded image bytes or as a reference to an image in an Amazon S3
    /// bucket. The image must be either a PNG or JPEG formatted file. For more information,
    /// see <a>celebrity-recognition</a>. 
    /// 
    ///  
    /// <para><code>RecognizeCelebrities</code> returns the 15 largest faces in the image. It lists
    /// recognized celebrities in the <code>CelebrityFaces</code> list and unrecognized faces
    /// in the <code>UnrecognizedFaces</code> list. The operation doesn't return celebrities
    /// whose face sizes are smaller than the largest 15 faces in the image.
    /// </para><para>
    /// For each celebrity recognized, the API returns a <code>Celebrity</code> object. The
    /// <code>Celebrity</code> object contains the celebrity name, ID, URL links to additional
    /// information, match confidence, and a <code>ComparedFace</code> object that you can
    /// use to locate the celebrity's face on the image.
    /// </para><para>
    /// Rekognition does not retain information about which images a celebrity has been recognized
    /// in. Your application must store this information and use the <code>Celebrity</code>
    /// ID property as a unique identifier for the celebrity. If you don't store the celebrity
    /// name or additional information URLs returned by <code>RecognizeCelebrities</code>,
    /// you will need the ID to identify the celebrity in a call to the operation.
    /// </para><para>
    /// For an example, see <a>recognize-celebrities-tutorial</a>.
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:RecognizeCelebrities</code>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKCelebrity")]
    [OutputType("Amazon.Rekognition.Model.RecognizeCelebritiesResponse")]
    [AWSCmdlet("Invokes the RecognizeCelebrities operation against Amazon Rekognition.", Operation = new[] {"RecognizeCelebrities"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.RecognizeCelebritiesResponse",
        "This cmdlet returns a Amazon.Rekognition.Model.RecognizeCelebritiesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindREKCelebrityCmdlet : AmazonRekognitionClientCmdlet, IExecutor
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            
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
                var request = new Amazon.Rekognition.Model.RecognizeCelebritiesRequest();
                
                
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
        
        private Amazon.Rekognition.Model.RecognizeCelebritiesResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.RecognizeCelebritiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "RecognizeCelebrities");
            try
            {
                #if DESKTOP
                return client.RecognizeCelebrities(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RecognizeCelebritiesAsync(request);
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
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
        }
        
    }
}
