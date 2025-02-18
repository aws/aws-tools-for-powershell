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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Detects Personal Protective Equipment (PPE) worn by people detected in an image. Amazon
    /// Rekognition can detect the following types of PPE.
    /// 
    ///  <ul><li><para>
    /// Face cover
    /// </para></li><li><para>
    /// Hand cover
    /// </para></li><li><para>
    /// Head cover
    /// </para></li></ul><para>
    /// You pass the input image as base64-encoded image bytes or as a reference to an image
    /// in an Amazon S3 bucket. The image must be either a PNG or JPG formatted file. 
    /// </para><para><c>DetectProtectiveEquipment</c> detects PPE worn by up to 15 persons detected in
    /// an image.
    /// </para><para>
    /// For each person detected in the image the API returns an array of body parts (face,
    /// head, left-hand, right-hand). For each body part, an array of detected items of PPE
    /// is returned, including an indicator of whether or not the PPE covers the body part.
    /// The API returns the confidence it has in each detection (person, PPE, body part and
    /// body part coverage). It also returns a bounding box (<a>BoundingBox</a>) for each
    /// detected person and each detected item of PPE. 
    /// </para><para>
    /// You can optionally request a summary of detected PPE items with the <c>SummarizationAttributes</c>
    /// input parameter. The summary provides the following information. 
    /// </para><ul><li><para>
    /// The persons detected as wearing all of the types of PPE that you specify.
    /// </para></li><li><para>
    /// The persons detected as not wearing all of the types PPE that you specify.
    /// </para></li><li><para>
    /// The persons detected where PPE adornment could not be determined. 
    /// </para></li></ul><para>
    /// This is a stateless API operation. That is, the operation does not persist any data.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:DetectProtectiveEquipment</c>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKProtectiveEquipment")]
    [OutputType("Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition DetectProtectiveEquipment API operation.", Operation = new[] {"DetectProtectiveEquipment"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse object containing multiple properties."
    )]
    public partial class FindREKProtectiveEquipmentCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter SummarizationAttributes_MinConfidence
        /// <summary>
        /// <para>
        /// <para>The minimum confidence level for which you want summary information. The confidence
        /// level applies to person detection, body part detection, equipment detection, and body
        /// part coverage. Amazon Rekognition doesn't return summary information with a confidence
        /// than this specified value. There isn't a default value.</para><para>Specify a <c>MinConfidence</c> value that is between 50-100% as <c>DetectProtectiveEquipment</c>
        /// returns predictions only where the detection confidence is between 50% - 100%. If
        /// you specify a value that is less than 50%, the results are the same specifying a value
        /// of 50%.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? SummarizationAttributes_MinConfidence { get; set; }
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
        
        #region Parameter SummarizationAttributes_RequiredEquipmentType
        /// <summary>
        /// <para>
        /// <para>An array of personal protective equipment types for which you want summary information.
        /// If a person is detected wearing a required requipment type, the person's ID is added
        /// to the <c>PersonsWithRequiredEquipment</c> array field returned in <a>ProtectiveEquipmentSummary</a>
        /// by <c>DetectProtectiveEquipment</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SummarizationAttributes_RequiredEquipmentTypes")]
        public System.String[] SummarizationAttributes_RequiredEquipmentType { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse, FindREKProtectiveEquipmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            context.SummarizationAttributes_MinConfidence = this.SummarizationAttributes_MinConfidence;
            if (this.SummarizationAttributes_RequiredEquipmentType != null)
            {
                context.SummarizationAttributes_RequiredEquipmentType = new List<System.String>(this.SummarizationAttributes_RequiredEquipmentType);
            }
            
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
                var request = new Amazon.Rekognition.Model.DetectProtectiveEquipmentRequest();
                
                
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
                
                 // populate SummarizationAttributes
                var requestSummarizationAttributesIsNull = true;
                request.SummarizationAttributes = new Amazon.Rekognition.Model.ProtectiveEquipmentSummarizationAttributes();
                System.Single? requestSummarizationAttributes_summarizationAttributes_MinConfidence = null;
                if (cmdletContext.SummarizationAttributes_MinConfidence != null)
                {
                    requestSummarizationAttributes_summarizationAttributes_MinConfidence = cmdletContext.SummarizationAttributes_MinConfidence.Value;
                }
                if (requestSummarizationAttributes_summarizationAttributes_MinConfidence != null)
                {
                    request.SummarizationAttributes.MinConfidence = requestSummarizationAttributes_summarizationAttributes_MinConfidence.Value;
                    requestSummarizationAttributesIsNull = false;
                }
                List<System.String> requestSummarizationAttributes_summarizationAttributes_RequiredEquipmentType = null;
                if (cmdletContext.SummarizationAttributes_RequiredEquipmentType != null)
                {
                    requestSummarizationAttributes_summarizationAttributes_RequiredEquipmentType = cmdletContext.SummarizationAttributes_RequiredEquipmentType;
                }
                if (requestSummarizationAttributes_summarizationAttributes_RequiredEquipmentType != null)
                {
                    request.SummarizationAttributes.RequiredEquipmentTypes = requestSummarizationAttributes_summarizationAttributes_RequiredEquipmentType;
                    requestSummarizationAttributesIsNull = false;
                }
                 // determine if request.SummarizationAttributes should be set to null
                if (requestSummarizationAttributesIsNull)
                {
                    request.SummarizationAttributes = null;
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
        
        private Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectProtectiveEquipmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DetectProtectiveEquipment");
            try
            {
                return client.DetectProtectiveEquipmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Single? SummarizationAttributes_MinConfidence { get; set; }
            public List<System.String> SummarizationAttributes_RequiredEquipmentType { get; set; }
            public System.Func<Amazon.Rekognition.Model.DetectProtectiveEquipmentResponse, FindREKProtectiveEquipmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
