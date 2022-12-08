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
    /// Detects unsafe content in a specified JPEG or PNG format image. Use <code>DetectModerationLabels</code>
    /// to moderate images depending on your requirements. For example, you might want to
    /// filter images that contain nudity, but not images containing suggestive content.
    /// 
    ///  
    /// <para>
    /// To filter images, use the labels returned by <code>DetectModerationLabels</code> to
    /// determine which types of content are appropriate.
    /// </para><para>
    /// For information about moderation labels, see Detecting Unsafe Content in the Amazon
    /// Rekognition Developer Guide.
    /// </para><para>
    /// You pass the input image either as base64-encoded image bytes or as a reference to
    /// an image in an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition
    /// operations, passing image bytes is not supported. The image must be either a PNG or
    /// JPEG formatted file. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKModerationLabel")]
    [OutputType("Amazon.Rekognition.Model.DetectModerationLabelsResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition DetectModerationLabels API operation.", Operation = new[] {"DetectModerationLabels"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DetectModerationLabelsResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.DetectModerationLabelsResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.DetectModerationLabelsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindREKModerationLabelCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Image_Byte
        /// <summary>
        /// <para>
        /// <para>Blob of image bytes up to 5 MBs.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Image_Byte { get; set; }
        #endregion
        
        #region Parameter DataAttributes_ContentClassifier
        /// <summary>
        /// <para>
        /// <para>Sets whether the input image is free of personally identifiable information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HumanLoopConfig_DataAttributes_ContentClassifiers")]
        public System.String[] DataAttributes_ContentClassifier { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_FlowDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the flow definition. You can create a flow definition
        /// by using the Amazon Sagemaker <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_CreateFlowDefinition.html">CreateFlowDefinition</a>
        /// Operation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_FlowDefinitionArn { get; set; }
        #endregion
        
        #region Parameter HumanLoopConfig_HumanLoopName
        /// <summary>
        /// <para>
        /// <para>The name of the human review used for this image. This should be kept unique within
        /// a region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HumanLoopConfig_HumanLoopName { get; set; }
        #endregion
        
        #region Parameter MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence level for the labels to return. Amazon Rekognition
        /// doesn't return any labels with a confidence level lower than this specified value.</para><para>If you don't specify <code>MinConfidence</code>, the operation returns labels with
        /// confidence values greater than or equal to 50 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? MinConfidence { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DetectModerationLabelsResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.DetectModerationLabelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DetectModerationLabelsResponse, FindREKModerationLabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DataAttributes_ContentClassifier != null)
            {
                context.DataAttributes_ContentClassifier = new List<System.String>(this.DataAttributes_ContentClassifier);
            }
            context.HumanLoopConfig_FlowDefinitionArn = this.HumanLoopConfig_FlowDefinitionArn;
            context.HumanLoopConfig_HumanLoopName = this.HumanLoopConfig_HumanLoopName;
            context.Image_Byte = this.Image_Byte;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            context.MinConfidence = this.MinConfidence;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Image_ByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Rekognition.Model.DetectModerationLabelsRequest();
                
                
                 // populate HumanLoopConfig
                var requestHumanLoopConfigIsNull = true;
                request.HumanLoopConfig = new Amazon.Rekognition.Model.HumanLoopConfig();
                System.String requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn = null;
                if (cmdletContext.HumanLoopConfig_FlowDefinitionArn != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn = cmdletContext.HumanLoopConfig_FlowDefinitionArn;
                }
                if (requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn != null)
                {
                    request.HumanLoopConfig.FlowDefinitionArn = requestHumanLoopConfig_humanLoopConfig_FlowDefinitionArn;
                    requestHumanLoopConfigIsNull = false;
                }
                System.String requestHumanLoopConfig_humanLoopConfig_HumanLoopName = null;
                if (cmdletContext.HumanLoopConfig_HumanLoopName != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_HumanLoopName = cmdletContext.HumanLoopConfig_HumanLoopName;
                }
                if (requestHumanLoopConfig_humanLoopConfig_HumanLoopName != null)
                {
                    request.HumanLoopConfig.HumanLoopName = requestHumanLoopConfig_humanLoopConfig_HumanLoopName;
                    requestHumanLoopConfigIsNull = false;
                }
                Amazon.Rekognition.Model.HumanLoopDataAttributes requestHumanLoopConfig_humanLoopConfig_DataAttributes = null;
                
                 // populate DataAttributes
                var requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull = true;
                requestHumanLoopConfig_humanLoopConfig_DataAttributes = new Amazon.Rekognition.Model.HumanLoopDataAttributes();
                List<System.String> requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier = null;
                if (cmdletContext.DataAttributes_ContentClassifier != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier = cmdletContext.DataAttributes_ContentClassifier;
                }
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier != null)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes.ContentClassifiers = requestHumanLoopConfig_humanLoopConfig_DataAttributes_dataAttributes_ContentClassifier;
                    requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull = false;
                }
                 // determine if requestHumanLoopConfig_humanLoopConfig_DataAttributes should be set to null
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributesIsNull)
                {
                    requestHumanLoopConfig_humanLoopConfig_DataAttributes = null;
                }
                if (requestHumanLoopConfig_humanLoopConfig_DataAttributes != null)
                {
                    request.HumanLoopConfig.DataAttributes = requestHumanLoopConfig_humanLoopConfig_DataAttributes;
                    requestHumanLoopConfigIsNull = false;
                }
                 // determine if request.HumanLoopConfig should be set to null
                if (requestHumanLoopConfigIsNull)
                {
                    request.HumanLoopConfig = null;
                }
                
                 // populate Image
                var requestImageIsNull = true;
                request.Image = new Amazon.Rekognition.Model.Image();
                System.IO.MemoryStream requestImage_image_Byte = null;
                if (cmdletContext.Image_Byte != null)
                {
                    _Image_ByteStream = new System.IO.MemoryStream(cmdletContext.Image_Byte);
                    requestImage_image_Byte = _Image_ByteStream;
                }
                if (requestImage_image_Byte != null)
                {
                    request.Image.Bytes = requestImage_image_Byte;
                    requestImageIsNull = false;
                }
                Amazon.Rekognition.Model.S3Object requestImage_image_S3Object = null;
                
                 // populate S3Object
                var requestImage_image_S3ObjectIsNull = true;
                requestImage_image_S3Object = new Amazon.Rekognition.Model.S3Object();
                System.String requestImage_image_S3Object_s3Object_Bucket = null;
                if (cmdletContext.S3Object_Bucket != null)
                {
                    requestImage_image_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
                }
                if (requestImage_image_S3Object_s3Object_Bucket != null)
                {
                    requestImage_image_S3Object.Bucket = requestImage_image_S3Object_s3Object_Bucket;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Name = null;
                if (cmdletContext.S3Object_Name != null)
                {
                    requestImage_image_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
                }
                if (requestImage_image_S3Object_s3Object_Name != null)
                {
                    requestImage_image_S3Object.Name = requestImage_image_S3Object_s3Object_Name;
                    requestImage_image_S3ObjectIsNull = false;
                }
                System.String requestImage_image_S3Object_s3Object_Version = null;
                if (cmdletContext.S3Object_Version != null)
                {
                    requestImage_image_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
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
                if( _Image_ByteStream != null)
                {
                    _Image_ByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Rekognition.Model.DetectModerationLabelsResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectModerationLabelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DetectModerationLabels");
            try
            {
                #if DESKTOP
                return client.DetectModerationLabels(request);
                #elif CORECLR
                return client.DetectModerationLabelsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DataAttributes_ContentClassifier { get; set; }
            public System.String HumanLoopConfig_FlowDefinitionArn { get; set; }
            public System.String HumanLoopConfig_HumanLoopName { get; set; }
            public byte[] Image_Byte { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.Single? MinConfidence { get; set; }
            public System.Func<Amazon.Rekognition.Model.DetectModerationLabelsResponse, FindREKModerationLabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
