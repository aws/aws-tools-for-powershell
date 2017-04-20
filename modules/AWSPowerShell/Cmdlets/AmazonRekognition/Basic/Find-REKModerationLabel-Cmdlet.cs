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
    /// Detects explicit or suggestive adult content in a specified .jpeg or .png image. Use
    /// <code>DetectModerationLabels</code> to moderate images depending on your requirements.
    /// For example, you might want to filter images that contain nudity, but not images containing
    /// suggestive content.
    /// 
    ///  
    /// <para>
    /// To filter images, use the labels returned by <code>DetectModerationLabels</code> to
    /// determine which types of content are appropriate. For information about moderation
    /// labels, see <a>howitworks-moderateimage</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKModerationLabel")]
    [OutputType("Amazon.Rekognition.Model.ModerationLabel")]
    [AWSCmdlet("Invokes the DetectModerationLabels operation against Amazon Rekognition.", Operation = new[] {"DetectModerationLabels"})]
    [AWSCmdletOutput("Amazon.Rekognition.Model.ModerationLabel",
        "This cmdlet returns a collection of ModerationLabel objects.",
        "The service call response (type Amazon.Rekognition.Model.DetectModerationLabelsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindREKModerationLabelCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Image_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Image_Byte
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Image_Bytes")]
        public byte[] Image_Byte { get; set; }
        #endregion
        
        #region Parameter MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence level for the labels to return. Amazon Rekognition
        /// doesn't return any labels with a confidence level lower than this specified value.</para><para>If you don't specify <code>MinConfidence</code>, the operation returns labels with
        /// confidence values greater than or equal to 50 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Single MinConfidence { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Image_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Image_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
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
            
            context.Image_Bytes = this.Image_Byte;
            context.Image_S3Object_Bucket = this.S3Object_Bucket;
            context.Image_S3Object_Name = this.S3Object_Name;
            context.Image_S3Object_Version = this.S3Object_Version;
            if (ParameterWasBound("MinConfidence"))
                context.MinConfidence = this.MinConfidence;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Image_BytesStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.DetectModerationLabelsRequest();
                
                
                 // populate Image
                bool requestImageIsNull = true;
                request.Image = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestImage_image_Byte = null;
                if (cmdletContext.Image_Bytes != null)
                {
                    _Image_BytesStream = new System.IO.MemoryStream(cmdletContext.Image_Bytes);
                    requestImage_image_Byte = _Image_BytesStream;
                }
                if (requestImage_image_Byte != null)
                {
                    request.Image.Bytes = requestImage_image_Byte;
                    requestImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestImage_image_S3Object = null;
                
                 // populate S3Object
                bool requestImage_image_S3ObjectIsNull = true;
                requestImage_image_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestImage_image_S3Object_s3Object_Bucket = null;
                if (cmdletContext.Image_S3Object_Bucket != null)
                {
                    requestImage_image_S3Object_s3Object_Bucket = cmdletContext.Image_S3Object_Bucket;
                }
                if (requestImage_image_S3Object_s3Object_Bucket != null)
                {
                    requestImage_image_S3Object.Bucket = requestImage_image_S3Object_s3Object_Bucket;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Name = null;
                if (cmdletContext.Image_S3Object_Name != null)
                {
                    requestImage_image_S3Object_s3Object_Name = cmdletContext.Image_S3Object_Name;
                }
                if (requestImage_image_S3Object_s3Object_Name != null)
                {
                    requestImage_image_S3Object.Name = requestImage_image_S3Object_s3Object_Name;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Version = null;
                if (cmdletContext.Image_S3Object_Version != null)
                {
                    requestImage_image_S3Object_s3Object_Version = cmdletContext.Image_S3Object_Version;
                }
                if (requestImage_image_S3Object_s3Object_Version != null)
                {
                    requestImage_image_S3Object.Version = requestImage_image_S3Object_s3Object_Version;
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
                if (cmdletContext.MinConfidence != null)
                {
                    request.MinConfidence = cmdletContext.MinConfidence.Value;
                }
                
                CmdletOutput output;
                
                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = CallAWSServiceOperation(client, request);
                    Dictionary<string, object> notes = null;
                    object pipelineOutput = response.ModerationLabels;
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
                if( _Image_BytesStream != null)
                {
                    _Image_BytesStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private static Amazon.Rekognition.Model.DetectModerationLabelsResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectModerationLabelsRequest request)
        {
            #if DESKTOP
            return client.DetectModerationLabels(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DetectModerationLabelsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public byte[] Image_Bytes { get; set; }
            public System.String Image_S3Object_Bucket { get; set; }
            public System.String Image_S3Object_Name { get; set; }
            public System.String Image_S3Object_Version { get; set; }
            public System.Single? MinConfidence { get; set; }
        }
        
    }
}
