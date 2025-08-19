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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Detects instances of real-world entities within an image (JPEG or PNG) provided as
    /// input. This includes objects like flower, tree, and table; events like wedding, graduation,
    /// and birthday party; and concepts like landscape, evening, and nature. 
    /// 
    ///  
    /// <para>
    /// For an example, see Analyzing images stored in an Amazon S3 bucket in the Amazon Rekognition
    /// Developer Guide.
    /// </para><para>
    /// You pass the input image as base64-encoded image bytes or as a reference to an image
    /// in an Amazon S3 bucket. If you use the AWS CLI to call Amazon Rekognition operations,
    /// passing image bytes is not supported. The image must be either a PNG or JPEG formatted
    /// file. 
    /// </para><para><b>Optional Parameters</b></para><para>
    /// You can specify one or both of the <c>GENERAL_LABELS</c> and <c>IMAGE_PROPERTIES</c>
    /// feature types when calling the DetectLabels API. Including <c>GENERAL_LABELS</c> will
    /// ensure the response includes the labels detected in the input image, while including
    /// <c>IMAGE_PROPERTIES </c>will ensure the response includes information about the image
    /// quality and color.
    /// </para><para>
    /// When using <c>GENERAL_LABELS</c> and/or <c>IMAGE_PROPERTIES</c> you can provide filtering
    /// criteria to the Settings parameter. You can filter with sets of individual labels
    /// or with label categories. You can specify inclusive filters, exclusive filters, or
    /// a combination of inclusive and exclusive filters. For more information on filtering
    /// see <a href="https://docs.aws.amazon.com/rekognition/latest/dg/labels-detect-labels-image.html">Detecting
    /// Labels in an Image</a>.
    /// </para><para>
    /// When getting labels, you can specify <c>MinConfidence</c> to control the confidence
    /// threshold for the labels returned. The default is 55%. You can also add the <c>MaxLabels</c>
    /// parameter to limit the number of labels returned. The default and upper limit is 1000
    /// labels. These arguments are only valid when supplying GENERAL_LABELS as a feature
    /// type.
    /// </para><para><b>Response Elements</b></para><para>
    ///  For each object, scene, and concept the API returns one or more labels. The API returns
    /// the following types of information about labels:
    /// </para><ul><li><para>
    ///  Name - The name of the detected label. 
    /// </para></li><li><para>
    ///  Confidence - The level of confidence in the label assigned to a detected object.
    /// 
    /// </para></li><li><para>
    ///  Parents - The ancestor labels for a detected label. DetectLabels returns a hierarchical
    /// taxonomy of detected labels. For example, a detected car might be assigned the label
    /// car. The label car has two parent labels: Vehicle (its parent) and Transportation
    /// (its grandparent). The response includes the all ancestors for a label, where every
    /// ancestor is a unique label. In the previous example, Car, Vehicle, and Transportation
    /// are returned as unique labels in the response. 
    /// </para></li><li><para>
    ///  Aliases - Possible Aliases for the label. 
    /// </para></li><li><para>
    ///  Categories - The label categories that the detected label belongs to. 
    /// </para></li><li><para>
    ///  BoundingBox — Bounding boxes are described for all instances of detected common object
    /// labels, returned in an array of Instance objects. An Instance object contains a BoundingBox
    /// object, describing the location of the label on the input image. It also includes
    /// the confidence for the accuracy of the detected bounding box. 
    /// </para></li></ul><para>
    ///  The API returns the following information regarding the image, as part of the ImageProperties
    /// structure:
    /// </para><ul><li><para>
    /// Quality - Information about the Sharpness, Brightness, and Contrast of the input image,
    /// scored between 0 to 100. Image quality is returned for the entire image, as well as
    /// the background and the foreground. 
    /// </para></li><li><para>
    /// Dominant Color - An array of the dominant colors in the image. 
    /// </para></li><li><para>
    /// Foreground - Information about the sharpness, brightness, and dominant colors of the
    /// input image’s foreground. 
    /// </para></li><li><para>
    /// Background - Information about the sharpness, brightness, and dominant colors of the
    /// input image’s background.
    /// </para></li></ul><para>
    /// The list of returned labels will include at least one label for every detected object,
    /// along with information about that label. In the following example, suppose the input
    /// image has a lighthouse, the sea, and a rock. The response includes all three labels,
    /// one for each object, as well as the confidence in the label:
    /// </para><para><c>{Name: lighthouse, Confidence: 98.4629}</c></para><para><c>{Name: rock,Confidence: 79.2097}</c></para><para><c> {Name: sea,Confidence: 75.061}</c></para><para>
    /// The list of labels can include multiple labels for the same object. For example, if
    /// the input image shows a flower (for example, a tulip), the operation might return
    /// the following three labels. 
    /// </para><para><c>{Name: flower,Confidence: 99.0562}</c></para><para><c>{Name: plant,Confidence: 99.0562}</c></para><para><c>{Name: tulip,Confidence: 99.0562}</c></para><para>
    /// In this example, the detection algorithm more precisely identifies the flower as a
    /// tulip.
    /// </para><note><para>
    /// If the object detected is a person, the operation doesn't provide the same facial
    /// details that the <a>DetectFaces</a> operation provides.
    /// </para></note><para>
    /// This is a stateless API operation that doesn't return any data.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:DetectLabels</c>
    /// action. 
    /// </para>
    /// </summary>
    [Cmdlet("Find", "REKLabel")]
    [OutputType("Amazon.Rekognition.Model.DetectLabelsResponse")]
    [AWSCmdlet("Calls the Amazon Rekognition DetectLabels API operation.", Operation = new[] {"DetectLabels"}, SelectReturnType = typeof(Amazon.Rekognition.Model.DetectLabelsResponse))]
    [AWSCmdletOutput("Amazon.Rekognition.Model.DetectLabelsResponse",
        "This cmdlet returns an Amazon.Rekognition.Model.DetectLabelsResponse object containing multiple properties."
    )]
    public partial class FindREKLabelCmdlet : AmazonRekognitionClientCmdlet, IExecutor
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
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>A list of the types of analysis to perform. Specifying GENERAL_LABELS uses the label
        /// detection feature, while specifying IMAGE_PROPERTIES returns information regarding
        /// image color and quality. If no option is specified GENERAL_LABELS is used by default.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public System.String[] Feature { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelCategoryExclusionFilter
        /// <summary>
        /// <para>
        /// <para>The label categories that should be excluded from the return from DetectLabels.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelCategoryExclusionFilters")]
        public System.String[] GeneralLabels_LabelCategoryExclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelCategoryInclusionFilter
        /// <summary>
        /// <para>
        /// <para>The label categories that should be included in the return from DetectLabels.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelCategoryInclusionFilters")]
        public System.String[] GeneralLabels_LabelCategoryInclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelExclusionFilter
        /// <summary>
        /// <para>
        /// <para>The labels that should be excluded from the return from DetectLabels.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelExclusionFilters")]
        public System.String[] GeneralLabels_LabelExclusionFilter { get; set; }
        #endregion
        
        #region Parameter GeneralLabels_LabelInclusionFilter
        /// <summary>
        /// <para>
        /// <para>The labels that should be included in the return from DetectLabels.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_GeneralLabels_LabelInclusionFilters")]
        public System.String[] GeneralLabels_LabelInclusionFilter { get; set; }
        #endregion
        
        #region Parameter ImageProperties_MaxDominantColor
        /// <summary>
        /// <para>
        /// <para>The maximum number of dominant colors to return when detecting labels in an image.
        /// The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ImageProperties_MaxDominantColors")]
        public System.Int32? ImageProperties_MaxDominantColor { get; set; }
        #endregion
        
        #region Parameter MaxLabel
        /// <summary>
        /// <para>
        /// <para>Maximum number of labels you want the service to return in the response. The service
        /// returns the specified number of highest confidence labels. Only valid when GENERAL_LABELS
        /// is specified as a feature type in the Feature input parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxLabels")]
        public System.Int32? MaxLabel { get; set; }
        #endregion
        
        #region Parameter MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence level for the labels to return. Amazon Rekognition
        /// doesn't return any labels with confidence lower than this specified value.</para><para>If <c>MinConfidence</c> is not specified, the operation returns labels with a confidence
        /// values greater than or equal to 55 percent. Only valid when GENERAL_LABELS is specified
        /// as a feature type in the Feature input parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? MinConfidence { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.DetectLabelsResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.DetectLabelsResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.DetectLabelsResponse, FindREKLabelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Feature != null)
            {
                context.Feature = new List<System.String>(this.Feature);
            }
            context.ImageContent = this.ImageContent;
            context.ImageBucket = this.ImageBucket;
            context.ImageName = this.ImageName;
            context.ImageVersion = this.ImageVersion;
            context.MaxLabel = this.MaxLabel;
            context.MinConfidence = this.MinConfidence;
            if (this.GeneralLabels_LabelCategoryExclusionFilter != null)
            {
                context.GeneralLabels_LabelCategoryExclusionFilter = new List<System.String>(this.GeneralLabels_LabelCategoryExclusionFilter);
            }
            if (this.GeneralLabels_LabelCategoryInclusionFilter != null)
            {
                context.GeneralLabels_LabelCategoryInclusionFilter = new List<System.String>(this.GeneralLabels_LabelCategoryInclusionFilter);
            }
            if (this.GeneralLabels_LabelExclusionFilter != null)
            {
                context.GeneralLabels_LabelExclusionFilter = new List<System.String>(this.GeneralLabels_LabelExclusionFilter);
            }
            if (this.GeneralLabels_LabelInclusionFilter != null)
            {
                context.GeneralLabels_LabelInclusionFilter = new List<System.String>(this.GeneralLabels_LabelInclusionFilter);
            }
            context.ImageProperties_MaxDominantColor = this.ImageProperties_MaxDominantColor;
            
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
                var request = new Amazon.Rekognition.Model.DetectLabelsRequest();
                
                if (cmdletContext.Feature != null)
                {
                    request.Features = cmdletContext.Feature;
                }
                
                 // populate Image
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
                }
                if (cmdletContext.MaxLabel != null)
                {
                    request.MaxLabels = cmdletContext.MaxLabel.Value;
                }
                if (cmdletContext.MinConfidence != null)
                {
                    request.MinConfidence = cmdletContext.MinConfidence.Value;
                }
                
                 // populate Settings
                var requestSettingsIsNull = true;
                request.Settings = new Amazon.Rekognition.Model.DetectLabelsSettings();
                Amazon.Rekognition.Model.DetectLabelsImagePropertiesSettings requestSettings_settings_ImageProperties = null;
                
                 // populate ImageProperties
                var requestSettings_settings_ImagePropertiesIsNull = true;
                requestSettings_settings_ImageProperties = new Amazon.Rekognition.Model.DetectLabelsImagePropertiesSettings();
                System.Int32? requestSettings_settings_ImageProperties_imageProperties_MaxDominantColor = null;
                if (cmdletContext.ImageProperties_MaxDominantColor != null)
                {
                    requestSettings_settings_ImageProperties_imageProperties_MaxDominantColor = cmdletContext.ImageProperties_MaxDominantColor.Value;
                }
                if (requestSettings_settings_ImageProperties_imageProperties_MaxDominantColor != null)
                {
                    requestSettings_settings_ImageProperties.MaxDominantColors = requestSettings_settings_ImageProperties_imageProperties_MaxDominantColor.Value;
                    requestSettings_settings_ImagePropertiesIsNull = false;
                }
                 // determine if requestSettings_settings_ImageProperties should be set to null
                if (requestSettings_settings_ImagePropertiesIsNull)
                {
                    requestSettings_settings_ImageProperties = null;
                }
                if (requestSettings_settings_ImageProperties != null)
                {
                    request.Settings.ImageProperties = requestSettings_settings_ImageProperties;
                    requestSettingsIsNull = false;
                }
                Amazon.Rekognition.Model.GeneralLabelsSettings requestSettings_settings_GeneralLabels = null;
                
                 // populate GeneralLabels
                var requestSettings_settings_GeneralLabelsIsNull = true;
                requestSettings_settings_GeneralLabels = new Amazon.Rekognition.Model.GeneralLabelsSettings();
                List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter = null;
                if (cmdletContext.GeneralLabels_LabelCategoryExclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter = cmdletContext.GeneralLabels_LabelCategoryExclusionFilter;
                }
                if (requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels.LabelCategoryExclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryExclusionFilter;
                    requestSettings_settings_GeneralLabelsIsNull = false;
                }
                List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter = null;
                if (cmdletContext.GeneralLabels_LabelCategoryInclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter = cmdletContext.GeneralLabels_LabelCategoryInclusionFilter;
                }
                if (requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels.LabelCategoryInclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelCategoryInclusionFilter;
                    requestSettings_settings_GeneralLabelsIsNull = false;
                }
                List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter = null;
                if (cmdletContext.GeneralLabels_LabelExclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter = cmdletContext.GeneralLabels_LabelExclusionFilter;
                }
                if (requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels.LabelExclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelExclusionFilter;
                    requestSettings_settings_GeneralLabelsIsNull = false;
                }
                List<System.String> requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter = null;
                if (cmdletContext.GeneralLabels_LabelInclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter = cmdletContext.GeneralLabels_LabelInclusionFilter;
                }
                if (requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter != null)
                {
                    requestSettings_settings_GeneralLabels.LabelInclusionFilters = requestSettings_settings_GeneralLabels_generalLabels_LabelInclusionFilter;
                    requestSettings_settings_GeneralLabelsIsNull = false;
                }
                 // determine if requestSettings_settings_GeneralLabels should be set to null
                if (requestSettings_settings_GeneralLabelsIsNull)
                {
                    requestSettings_settings_GeneralLabels = null;
                }
                if (requestSettings_settings_GeneralLabels != null)
                {
                    request.Settings.GeneralLabels = requestSettings_settings_GeneralLabels;
                    requestSettingsIsNull = false;
                }
                 // determine if request.Settings should be set to null
                if (requestSettingsIsNull)
                {
                    request.Settings = null;
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
        
        private Amazon.Rekognition.Model.DetectLabelsResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.DetectLabelsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "DetectLabels");
            try
            {
                return client.DetectLabelsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Feature { get; set; }
            public byte[] ImageContent { get; set; }
            public System.String ImageBucket { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageVersion { get; set; }
            public System.Int32? MaxLabel { get; set; }
            public System.Single? MinConfidence { get; set; }
            public List<System.String> GeneralLabels_LabelCategoryExclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelCategoryInclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelExclusionFilter { get; set; }
            public List<System.String> GeneralLabels_LabelInclusionFilter { get; set; }
            public System.Int32? ImageProperties_MaxDominantColor { get; set; }
            public System.Func<Amazon.Rekognition.Model.DetectLabelsResponse, FindREKLabelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
