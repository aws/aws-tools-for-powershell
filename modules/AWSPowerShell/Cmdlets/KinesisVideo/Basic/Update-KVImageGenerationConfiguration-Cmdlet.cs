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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Updates the <code>StreamInfo</code> and <code>ImageProcessingConfiguration</code>
    /// fields.
    /// </summary>
    [Cmdlet("Update", "KVImageGenerationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams UpdateImageGenerationConfiguration API operation.", Operation = new[] {"UpdateImageGenerationConfiguration"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateKVImageGenerationConfigurationCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        #region Parameter DestinationConfig_DestinationRegion
        /// <summary>
        /// <para>
        /// <para>The AWS Region of the S3 bucket where images will be delivered. This <code>DestinationRegion</code>
        /// must match the Region where the stream is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageGenerationConfiguration_DestinationConfig_DestinationRegion")]
        public System.String DestinationConfig_DestinationRegion { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_Format
        /// <summary>
        /// <para>
        /// <para>The accepted image format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.Format")]
        public Amazon.KinesisVideo.Format ImageGenerationConfiguration_Format { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_FormatConfig
        /// <summary>
        /// <para>
        /// <para>The list of a key-value pair structure that contains extra parameters that can be
        /// applied when the image is generated. The <code>FormatConfig</code> key is the <code>JPEGQuality</code>,
        /// which indicates the JPEG quality key to be used to generate the image. The <code>FormatConfig</code>
        /// value accepts ints from 1 to 100. If the value is 1, the image will be generated with
        /// less quality and the best compression. If the value is 100, the image will be generated
        /// with the best quality and less compression. If no value is provided, the default value
        /// of the <code>JPEGQuality</code> key will be set to 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ImageGenerationConfiguration_FormatConfig { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_HeightPixel
        /// <summary>
        /// <para>
        /// <para>The height of the output image that is used in conjunction with the <code>WidthPixels</code>
        /// parameter. When both <code>HeightPixels</code> and <code>WidthPixels</code> parameters
        /// are provided, the image will be stretched to fit the specified aspect ratio. If only
        /// the <code>HeightPixels</code> parameter is provided, its original aspect ratio will
        /// be used to calculate the <code>WidthPixels</code> ratio. If neither parameter is provided,
        /// the original image size will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageGenerationConfiguration_HeightPixels")]
        public System.Int32? ImageGenerationConfiguration_HeightPixel { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_ImageSelectorType
        /// <summary>
        /// <para>
        /// <para>The origin of the Server or Producer timestamps to use to generate the images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ImageSelectorType")]
        public Amazon.KinesisVideo.ImageSelectorType ImageGenerationConfiguration_ImageSelectorType { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_SamplingInterval
        /// <summary>
        /// <para>
        /// <para>The time interval in milliseconds (ms) at which the images need to be generated from
        /// the stream. The minimum value that can be provided is 33 ms, because a camera that
        /// generates content at 30 FPS would create a frame every 33.3 ms. If the timestamp range
        /// is less than the sampling interval, the Image from the <code>StartTimestamp</code>
        /// will be returned if available. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ImageGenerationConfiguration_SamplingInterval { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>Indicates whether the <code>ContinuousImageGenerationConfigurations</code> API is
        /// enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ConfigurationStatus")]
        public Amazon.KinesisVideo.ConfigurationStatus ImageGenerationConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Kinesis video stream from where you want to
        /// update the image generation configuration. You must specify either the <code>StreamName</code>
        /// or the <code>StreamARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream from which to update the image generation configuration. You
        /// must specify either the <code>StreamName</code> or the <code>StreamARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter DestinationConfig_Uri
        /// <summary>
        /// <para>
        /// <para>The Uniform Resource Identifier (URI) that identifies where the images will be delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageGenerationConfiguration_DestinationConfig_Uri")]
        public System.String DestinationConfig_Uri { get; set; }
        #endregion
        
        #region Parameter ImageGenerationConfiguration_WidthPixel
        /// <summary>
        /// <para>
        /// <para>The width of the output image that is used in conjunction with the <code>HeightPixels</code>
        /// parameter. When both <code>WidthPixels</code> and <code>HeightPixels</code> parameters
        /// are provided, the image will be stretched to fit the specified aspect ratio. If only
        /// the <code>WidthPixels</code> parameter is provided, its original aspect ratio will
        /// be used to calculate the <code>HeightPixels</code> ratio. If neither parameter is
        /// provided, the original image size will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageGenerationConfiguration_WidthPixels")]
        public System.Int32? ImageGenerationConfiguration_WidthPixel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KVImageGenerationConfiguration (UpdateImageGenerationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse, UpdateKVImageGenerationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DestinationConfig_DestinationRegion = this.DestinationConfig_DestinationRegion;
            context.DestinationConfig_Uri = this.DestinationConfig_Uri;
            context.ImageGenerationConfiguration_Format = this.ImageGenerationConfiguration_Format;
            if (this.ImageGenerationConfiguration_FormatConfig != null)
            {
                context.ImageGenerationConfiguration_FormatConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ImageGenerationConfiguration_FormatConfig.Keys)
                {
                    context.ImageGenerationConfiguration_FormatConfig.Add((String)hashKey, (String)(this.ImageGenerationConfiguration_FormatConfig[hashKey]));
                }
            }
            context.ImageGenerationConfiguration_HeightPixel = this.ImageGenerationConfiguration_HeightPixel;
            context.ImageGenerationConfiguration_ImageSelectorType = this.ImageGenerationConfiguration_ImageSelectorType;
            context.ImageGenerationConfiguration_SamplingInterval = this.ImageGenerationConfiguration_SamplingInterval;
            context.ImageGenerationConfiguration_Status = this.ImageGenerationConfiguration_Status;
            context.ImageGenerationConfiguration_WidthPixel = this.ImageGenerationConfiguration_WidthPixel;
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationRequest();
            
            
             // populate ImageGenerationConfiguration
            var requestImageGenerationConfigurationIsNull = true;
            request.ImageGenerationConfiguration = new Amazon.KinesisVideo.Model.ImageGenerationConfiguration();
            Amazon.KinesisVideo.Format requestImageGenerationConfiguration_imageGenerationConfiguration_Format = null;
            if (cmdletContext.ImageGenerationConfiguration_Format != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_Format = cmdletContext.ImageGenerationConfiguration_Format;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_Format != null)
            {
                request.ImageGenerationConfiguration.Format = requestImageGenerationConfiguration_imageGenerationConfiguration_Format;
                requestImageGenerationConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestImageGenerationConfiguration_imageGenerationConfiguration_FormatConfig = null;
            if (cmdletContext.ImageGenerationConfiguration_FormatConfig != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_FormatConfig = cmdletContext.ImageGenerationConfiguration_FormatConfig;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_FormatConfig != null)
            {
                request.ImageGenerationConfiguration.FormatConfig = requestImageGenerationConfiguration_imageGenerationConfiguration_FormatConfig;
                requestImageGenerationConfigurationIsNull = false;
            }
            System.Int32? requestImageGenerationConfiguration_imageGenerationConfiguration_HeightPixel = null;
            if (cmdletContext.ImageGenerationConfiguration_HeightPixel != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_HeightPixel = cmdletContext.ImageGenerationConfiguration_HeightPixel.Value;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_HeightPixel != null)
            {
                request.ImageGenerationConfiguration.HeightPixels = requestImageGenerationConfiguration_imageGenerationConfiguration_HeightPixel.Value;
                requestImageGenerationConfigurationIsNull = false;
            }
            Amazon.KinesisVideo.ImageSelectorType requestImageGenerationConfiguration_imageGenerationConfiguration_ImageSelectorType = null;
            if (cmdletContext.ImageGenerationConfiguration_ImageSelectorType != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_ImageSelectorType = cmdletContext.ImageGenerationConfiguration_ImageSelectorType;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_ImageSelectorType != null)
            {
                request.ImageGenerationConfiguration.ImageSelectorType = requestImageGenerationConfiguration_imageGenerationConfiguration_ImageSelectorType;
                requestImageGenerationConfigurationIsNull = false;
            }
            System.Int32? requestImageGenerationConfiguration_imageGenerationConfiguration_SamplingInterval = null;
            if (cmdletContext.ImageGenerationConfiguration_SamplingInterval != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_SamplingInterval = cmdletContext.ImageGenerationConfiguration_SamplingInterval.Value;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_SamplingInterval != null)
            {
                request.ImageGenerationConfiguration.SamplingInterval = requestImageGenerationConfiguration_imageGenerationConfiguration_SamplingInterval.Value;
                requestImageGenerationConfigurationIsNull = false;
            }
            Amazon.KinesisVideo.ConfigurationStatus requestImageGenerationConfiguration_imageGenerationConfiguration_Status = null;
            if (cmdletContext.ImageGenerationConfiguration_Status != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_Status = cmdletContext.ImageGenerationConfiguration_Status;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_Status != null)
            {
                request.ImageGenerationConfiguration.Status = requestImageGenerationConfiguration_imageGenerationConfiguration_Status;
                requestImageGenerationConfigurationIsNull = false;
            }
            System.Int32? requestImageGenerationConfiguration_imageGenerationConfiguration_WidthPixel = null;
            if (cmdletContext.ImageGenerationConfiguration_WidthPixel != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_WidthPixel = cmdletContext.ImageGenerationConfiguration_WidthPixel.Value;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_WidthPixel != null)
            {
                request.ImageGenerationConfiguration.WidthPixels = requestImageGenerationConfiguration_imageGenerationConfiguration_WidthPixel.Value;
                requestImageGenerationConfigurationIsNull = false;
            }
            Amazon.KinesisVideo.Model.ImageGenerationDestinationConfig requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig = null;
            
             // populate DestinationConfig
            var requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfigIsNull = true;
            requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig = new Amazon.KinesisVideo.Model.ImageGenerationDestinationConfig();
            System.String requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_DestinationRegion = null;
            if (cmdletContext.DestinationConfig_DestinationRegion != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_DestinationRegion = cmdletContext.DestinationConfig_DestinationRegion;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_DestinationRegion != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig.DestinationRegion = requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_DestinationRegion;
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfigIsNull = false;
            }
            System.String requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_Uri = null;
            if (cmdletContext.DestinationConfig_Uri != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_Uri = cmdletContext.DestinationConfig_Uri;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_Uri != null)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig.Uri = requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig_destinationConfig_Uri;
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfigIsNull = false;
            }
             // determine if requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig should be set to null
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfigIsNull)
            {
                requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig = null;
            }
            if (requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig != null)
            {
                request.ImageGenerationConfiguration.DestinationConfig = requestImageGenerationConfiguration_imageGenerationConfiguration_DestinationConfig;
                requestImageGenerationConfigurationIsNull = false;
            }
             // determine if request.ImageGenerationConfiguration should be set to null
            if (requestImageGenerationConfigurationIsNull)
            {
                request.ImageGenerationConfiguration = null;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "UpdateImageGenerationConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateImageGenerationConfiguration(request);
                #elif CORECLR
                return client.UpdateImageGenerationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationConfig_DestinationRegion { get; set; }
            public System.String DestinationConfig_Uri { get; set; }
            public Amazon.KinesisVideo.Format ImageGenerationConfiguration_Format { get; set; }
            public Dictionary<System.String, System.String> ImageGenerationConfiguration_FormatConfig { get; set; }
            public System.Int32? ImageGenerationConfiguration_HeightPixel { get; set; }
            public Amazon.KinesisVideo.ImageSelectorType ImageGenerationConfiguration_ImageSelectorType { get; set; }
            public System.Int32? ImageGenerationConfiguration_SamplingInterval { get; set; }
            public Amazon.KinesisVideo.ConfigurationStatus ImageGenerationConfiguration_Status { get; set; }
            public System.Int32? ImageGenerationConfiguration_WidthPixel { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.UpdateImageGenerationConfigurationResponse, UpdateKVImageGenerationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
