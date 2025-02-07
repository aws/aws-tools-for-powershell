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
    /// Detects text in the input image and converts it into machine-readable text.
    /// 
    ///  
    /// <para>
    /// Pass the input image as base64-encoded image bytes or as a reference to an image in
    /// an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition operations,
    /// you must pass it as a reference to an image in an Amazon S3 bucket. For the AWS CLI,
    /// passing image bytes is not supported. The image must be either a .png or .jpeg formatted
    /// file. 
    /// </para><para>
    /// The <c>DetectText</c> operation returns text in an array of <a>TextDetection</a> elements,
    /// <c>TextDetections</c>. Each <c>TextDetection</c> element provides information about
    /// a single word or line of text that was detected in the image. 
    /// </para><para>
    /// A word is one or more script characters that are not separated by spaces. <c>DetectText</c>
    /// can detect up to 100 words in an image.
    /// </para><para>
    /// A line is a string of equally spaced words. A line isn't necessarily a complete sentence.
    /// For example, a driver's license number is detected as a line. A line ends when there
    /// is no aligned text after it. Also, a line ends when there is a large gap between words,
    /// relative to the length of the words. This means, depending on the gap between words,
    /// Amazon Rekognition may detect multiple lines in text aligned in the same direction.
    /// Periods don't represent the end of a line. If a sentence spans multiple lines, the
    /// <c>DetectText</c> operation returns multiple lines.
    /// </para><para>
    /// To determine whether a <c>TextDetection</c> element is a line of text or a word, use
    /// the <c>TextDetection</c> object <c>Type</c> field. 
    /// </para><para>
    /// To be detected, text must be within +/- 90 degrees orientation of the horizontal axis.
    /// </para><para>
    /// For more information, see Detecting text in the Amazon Rekognition Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKText")]
    [OutputType("Amazon.Rekognition.Model.TextDetection")]
    [AWSCmdlet("Calls the Amazon Rekognition DetectText API operation.", Operation = new[] {"DetectText"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DetectTextResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.TextDetection or Amazon.Rekognition.Model.DetectTextResponse",
        "This cmdlet returns a collection of Amazon.Rekognition.Model.TextDetection objects.",
        "The service call response (type Amazon.Rekognition.Model.DetectTextResponse) can be returned by specifying '-Select *'."
    )]
    public partial class FindREKTextCmdlet : AmazonRekognitionClientCmdlet, IExecutor
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
        
        #region Parameter WordFilter_MinBoundingBoxHeight
        /// <summary>
        /// <para>
        /// <para>Sets the minimum height of the word bounding box. Words with bounding box heights
        /// lesser than this value will be excluded from the result. Value is relative to the
        /// video frame height.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinBoundingBoxHeight")]
        public System.Single? WordFilter_MinBoundingBoxHeight { get; set; }
        #endregion
        
        #region Parameter WordFilter_MinBoundingBoxWidth
        /// <summary>
        /// <para>
        /// <para>Sets the minimum width of the word bounding box. Words with bounding boxes widths
        /// lesser than this value will be excluded from the result. Value is relative to the
        /// video frame width.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinBoundingBoxWidth")]
        public System.Single? WordFilter_MinBoundingBoxWidth { get; set; }
        #endregion
        
        #region Parameter WordFilter_MinConfidence
        /// <summary>
        /// <para>
        /// <para>Sets the confidence of word detection. Words with detection confidence below this
        /// will be excluded from the result. Values should be between 0 and 100. The default
        /// MinConfidence is 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_WordFilter_MinConfidence")]
        public System.Single? WordFilter_MinConfidence { get; set; }
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
        
        #region Parameter Filters_RegionsOfInterest
        /// <summary>
        /// <para>
        /// <para> A Filter focusing on a certain area of the image. Uses a <c>BoundingBox</c> object
        /// to set the region of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Rekognition.Model.RegionOfInterest[] Filters_RegionsOfInterest { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TextDetections'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DetectTextResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.DetectTextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TextDetections";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DetectTextResponse, FindREKTextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_RegionsOfInterest != null)
            {
                context.Filters_RegionsOfInterest = new List<Amazon.Rekognition.Model.RegionOfInterest>(this.Filters_RegionsOfInterest);
            }
            context.WordFilter_MinBoundingBoxHeight = this.WordFilter_MinBoundingBoxHeight;
            context.WordFilter_MinBoundingBoxWidth = this.WordFilter_MinBoundingBoxWidth;
            context.WordFilter_MinConfidence = this.WordFilter_MinConfidence;
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
                var request = new Amazon.Rekognition.Model.DetectTextRequest();
                
                
                 // populate Filters
                var requestFiltersIsNull = true;
                request.Filters = new Amazon.Rekognition.Model.DetectTextFilters();
                List<Amazon.Rekognition.Model.RegionOfInterest> requestFilters_filters_RegionsOfInterest = null;
                if (cmdletContext.Filters_RegionsOfInterest != null)
                {
                    requestFilters_filters_RegionsOfInterest = cmdletContext.Filters_RegionsOfInterest;
                }
                if (requestFilters_filters_RegionsOfInterest != null)
                {
                    request.Filters.RegionsOfInterest = requestFilters_filters_RegionsOfInterest;
                    requestFiltersIsNull = false;
                }
                Amazon.Rekognition.Model.DetectionFilter requestFilters_filters_WordFilter = null;
                
                 // populate WordFilter
                var requestFilters_filters_WordFilterIsNull = true;
                requestFilters_filters_WordFilter = new Amazon.Rekognition.Model.DetectionFilter();
                System.Single? requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight = null;
                if (cmdletContext.WordFilter_MinBoundingBoxHeight != null)
                {
                    requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight = cmdletContext.WordFilter_MinBoundingBoxHeight.Value;
                }
                if (requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight != null)
                {
                    requestFilters_filters_WordFilter.MinBoundingBoxHeight = requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxHeight.Value;
                    requestFilters_filters_WordFilterIsNull = false;
                }
                System.Single? requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth = null;
                if (cmdletContext.WordFilter_MinBoundingBoxWidth != null)
                {
                    requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth = cmdletContext.WordFilter_MinBoundingBoxWidth.Value;
                }
                if (requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth != null)
                {
                    requestFilters_filters_WordFilter.MinBoundingBoxWidth = requestFilters_filters_WordFilter_wordFilter_MinBoundingBoxWidth.Value;
                    requestFilters_filters_WordFilterIsNull = false;
                }
                System.Single? requestFilters_filters_WordFilter_wordFilter_MinConfidence = null;
                if (cmdletContext.WordFilter_MinConfidence != null)
                {
                    requestFilters_filters_WordFilter_wordFilter_MinConfidence = cmdletContext.WordFilter_MinConfidence.Value;
                }
                if (requestFilters_filters_WordFilter_wordFilter_MinConfidence != null)
                {
                    requestFilters_filters_WordFilter.MinConfidence = requestFilters_filters_WordFilter_wordFilter_MinConfidence.Value;
                    requestFilters_filters_WordFilterIsNull = false;
                }
                 // determine if requestFilters_filters_WordFilter should be set to null
                if (requestFilters_filters_WordFilterIsNull)
                {
                    requestFilters_filters_WordFilter = null;
                }
                if (requestFilters_filters_WordFilter != null)
                {
                    request.Filters.WordFilter = requestFilters_filters_WordFilter;
                    requestFiltersIsNull = false;
                }
                 // determine if request.Filters should be set to null
                if (requestFiltersIsNull)
                {
                    request.Filters = null;
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
        
        private Amazon.Rekognition.Model.DetectTextResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DetectText");
            try
            {
                #if DESKTOP
                return client.DetectText(request);
                #elif CORECLR
                return client.DetectTextAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Rekognition.Model.RegionOfInterest> Filters_RegionsOfInterest { get; set; }
            public System.Single? WordFilter_MinBoundingBoxHeight { get; set; }
            public System.Single? WordFilter_MinBoundingBoxWidth { get; set; }
            public System.Single? WordFilter_MinConfidence { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Func<Amazon.Rekognition.Model.DetectTextResponse, FindREKTextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TextDetections;
        }
        
    }
}
