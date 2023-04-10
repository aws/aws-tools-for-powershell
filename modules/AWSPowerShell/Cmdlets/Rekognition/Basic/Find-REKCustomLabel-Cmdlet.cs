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
    /// Detects custom labels in a supplied image by using an Amazon Rekognition Custom Labels
    /// model. 
    /// 
    ///  
    /// <para>
    /// You specify which version of a model version to use by using the <code>ProjectVersionArn</code>
    /// input parameter. 
    /// </para><para>
    /// You pass the input image as base64-encoded image bytes or as a reference to an image
    /// in an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition operations,
    /// passing image bytes is not supported. The image must be either a PNG or JPEG formatted
    /// file. 
    /// </para><para>
    ///  For each object that the model version detects on an image, the API returns a (<code>CustomLabel</code>)
    /// object in an array (<code>CustomLabels</code>). Each <code>CustomLabel</code> object
    /// provides the label name (<code>Name</code>), the level of confidence that the image
    /// contains the object (<code>Confidence</code>), and object location information, if
    /// it exists, for the label on the image (<code>Geometry</code>). 
    /// </para><para>
    /// To filter labels that are returned, specify a value for <code>MinConfidence</code>.
    /// <code>DetectCustomLabelsLabels</code> only returns labels with a confidence that's
    /// higher than the specified value. The value of <code>MinConfidence</code> maps to the
    /// assumed threshold values created during training. For more information, see <i>Assumed
    /// threshold</i> in the Amazon Rekognition Custom Labels Developer Guide. Amazon Rekognition
    /// Custom Labels metrics expresses an assumed threshold as a floating point value between
    /// 0-1. The range of <code>MinConfidence</code> normalizes the threshold value to a percentage
    /// value (0-100). Confidence responses from <code>DetectCustomLabels</code> are also
    /// returned as a percentage. You can use <code>MinConfidence</code> to change the precision
    /// and recall or your model. For more information, see <i>Analyzing an image</i> in the
    /// Amazon Rekognition Custom Labels Developer Guide. 
    /// </para><para>
    /// If you don't specify a value for <code>MinConfidence</code>, <code>DetectCustomLabels</code>
    /// returns labels based on the assumed threshold of each label.
    /// </para><para>
    /// This is a stateless API operation. That is, the operation does not persist any data.
    /// </para><para>
    /// This operation requires permissions to perform the <code>rekognition:DetectCustomLabels</code>
    /// action. 
    /// </para><para>
    /// For more information, see <i>Analyzing an image</i> in the Amazon Rekognition Custom
    /// Labels Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKCustomLabel")]
    [OutputType("Amazon.Rekognition.Model.CustomLabel")]
    [AWSCmdlet("Calls the Amazon Rekognition DetectCustomLabels API operation.", Operation = new[] {"DetectCustomLabels"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DetectCustomLabelsResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.CustomLabel or Amazon.Rekognition.Model.DetectCustomLabelsResponse",
        "This cmdlet returns a collection of Amazon.Rekognition.Model.CustomLabel objects.",
        "The service call response (type Amazon.Rekognition.Model.DetectCustomLabelsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class FindREKCustomLabelCmdlet : AmazonRekognitionClientCmdlet, IExecutor
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
        /// <para>Blob of image bytes up to 5 MBs. Note that the maximum image size you can pass to
        /// <code>DetectCustomLabels</code> is 4MB. </para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Image_Bytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Image_Byte { get; set; }
        #endregion
        
        #region Parameter MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence level for the labels to return. <code>DetectCustomLabels</code>
        /// doesn't return any labels with a confidence value that's lower than this specified
        /// value. If you specify a value of 0, <code>DetectCustomLabels</code> returns all labels,
        /// regardless of the assumed threshold applied to each label. If you don't specify a
        /// value for <code>MinConfidence</code>, <code>DetectCustomLabels</code> returns labels
        /// based on the assumed threshold of each label.</para>
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
        
        #region Parameter ProjectVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the model version that you want to use.</para>
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
        public System.String ProjectVersionArn { get; set; }
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Maximum number of results you want the service to return in the response. The service
        /// returns the specified number of highest confidence labels ranked from highest confidence
        /// to lowest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomLabels'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DetectCustomLabelsResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.DetectCustomLabelsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomLabels";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectVersionArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectVersionArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectVersionArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DetectCustomLabelsResponse, FindREKCustomLabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectVersionArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Image_Byte = this.Image_Byte;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            context.MaxResult = this.MaxResult;
            context.MinConfidence = this.MinConfidence;
            context.ProjectVersionArn = this.ProjectVersionArn;
            #if MODULAR
            if (this.ProjectVersionArn == null && ParameterWasBound(nameof(this.ProjectVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
                var request = new Amazon.Rekognition.Model.DetectCustomLabelsRequest();
                
                
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
                if (cmdletContext.MaxResult != null)
                {
                    request.MaxResults = cmdletContext.MaxResult.Value;
                }
                if (cmdletContext.MinConfidence != null)
                {
                    request.MinConfidence = cmdletContext.MinConfidence.Value;
                }
                if (cmdletContext.ProjectVersionArn != null)
                {
                    request.ProjectVersionArn = cmdletContext.ProjectVersionArn;
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
        
        private Amazon.Rekognition.Model.DetectCustomLabelsResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectCustomLabelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DetectCustomLabels");
            try
            {
                #if DESKTOP
                return client.DetectCustomLabels(request);
                #elif CORECLR
                return client.DetectCustomLabelsAsync(request).GetAwaiter().GetResult();
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
            public byte[] Image_Byte { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.Single? MinConfidence { get; set; }
            public System.String ProjectVersionArn { get; set; }
            public System.Func<Amazon.Rekognition.Model.DetectCustomLabelsResponse, FindREKCustomLabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomLabels;
        }
        
    }
}
