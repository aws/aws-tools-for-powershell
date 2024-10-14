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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Creates a new recording configuration, used to enable recording to Amazon S3.
    /// 
    ///  
    /// <para><b>Known issue:</b> In the us-east-1 region, if you use the Amazon Web Services CLI
    /// to create a recording configuration, it returns success even if the S3 bucket is in
    /// a different region. In this case, the <c>state</c> of the recording configuration
    /// is <c>CREATE_FAILED</c> (instead of <c>ACTIVE</c>). (In other regions, the CLI correctly
    /// returns failure if the bucket is in a different region.)
    /// </para><para><b>Workaround:</b> Ensure that your S3 bucket is in the same region as the recording
    /// configuration. If you create a recording configuration in a different region as your
    /// S3 bucket, delete that recording configuration and create a new one with an S3 bucket
    /// from the correct region.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IVSRecordingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.RecordingConfiguration")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service CreateRecordingConfiguration API operation.", Operation = new[] {"CreateRecordingConfiguration"}, SelectReturnType = typeof(Amazon.IVS.Model.CreateRecordingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.RecordingConfiguration or Amazon.IVS.Model.CreateRecordingConfigurationResponse",
        "This cmdlet returns an Amazon.IVS.Model.RecordingConfiguration object.",
        "The service call response (type Amazon.IVS.Model.CreateRecordingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIVSRecordingConfigurationCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3_BucketName
        /// <summary>
        /// <para>
        /// <para>Location (S3 bucket name) where recorded videos will be stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_S3_BucketName")]
        public System.String S3_BucketName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Recording-configuration name. The value does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_RecordingMode
        /// <summary>
        /// <para>
        /// <para>Thumbnail recording mode. Default: <c>INTERVAL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.RecordingMode")]
        public Amazon.IVS.RecordingMode ThumbnailConfiguration_RecordingMode { get; set; }
        #endregion
        
        #region Parameter RecordingReconnectWindowSecond
        /// <summary>
        /// <para>
        /// <para>If a broadcast disconnects and then reconnects within the specified interval, the
        /// multiple streams will be considered a single broadcast and merged together. Default:
        /// 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecordingReconnectWindowSeconds")]
        public System.Int32? RecordingReconnectWindowSecond { get; set; }
        #endregion
        
        #region Parameter RenditionConfiguration_Rendition
        /// <summary>
        /// <para>
        /// <para>Indicates which renditions are recorded for a stream, if <c>renditionSelection</c>
        /// is <c>CUSTOM</c>; otherwise, this field is irrelevant. The selected renditions are
        /// recorded if they are available during the stream. If a selected rendition is unavailable,
        /// the best available rendition is recorded. For details on the resolution dimensions
        /// of each rendition, see <a href="https://docs.aws.amazon.com/ivs/latest/userguide/record-to-s3.html">Auto-Record
        /// to Amazon S3</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RenditionConfiguration_Renditions")]
        public System.String[] RenditionConfiguration_Rendition { get; set; }
        #endregion
        
        #region Parameter RenditionConfiguration_RenditionSelection
        /// <summary>
        /// <para>
        /// <para>Indicates which set of renditions are recorded for a stream. For <c>BASIC</c> channels,
        /// the <c>CUSTOM</c> value has no effect. If <c>CUSTOM</c> is specified, a set of renditions
        /// must be specified in the <c>renditions</c> field. Default: <c>ALL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.RenditionConfigurationRenditionSelection")]
        public Amazon.IVS.RenditionConfigurationRenditionSelection RenditionConfiguration_RenditionSelection { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_Resolution
        /// <summary>
        /// <para>
        /// <para>Indicates the desired resolution of recorded thumbnails. Thumbnails are recorded at
        /// the selected resolution if the corresponding rendition is available during the stream;
        /// otherwise, they are recorded at source resolution. For more information about resolution
        /// values and their corresponding height and width dimensions, see <a href="https://docs.aws.amazon.com/ivs/latest/userguide/record-to-s3.html">Auto-Record
        /// to Amazon S3</a>. Default: Null (source resolution is returned).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ThumbnailConfigurationResolution")]
        public Amazon.IVS.ThumbnailConfigurationResolution ThumbnailConfiguration_Resolution { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_Storage
        /// <summary>
        /// <para>
        /// <para>Indicates the format in which thumbnails are recorded. <c>SEQUENTIAL</c> records all
        /// generated thumbnails in a serial manner, to the media/thumbnails directory. <c>LATEST</c>
        /// saves the latest thumbnail in media/latest_thumbnail/thumb.jpg and overwrites it at
        /// the interval specified by <c>targetIntervalSeconds</c>. You can enable both <c>SEQUENTIAL</c>
        /// and <c>LATEST</c>. Default: <c>SEQUENTIAL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ThumbnailConfiguration_Storage { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Array of 1-50 maps, each of the form <c>string:string (key:value)</c>. See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging Amazon Web Services Resources and Tag Editor</i>
        /// for details, including restrictions that apply to tags and "Tag naming limits and
        /// requirements"; Amazon IVS has no service-specific constraints beyond what is documented
        /// there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_TargetIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The targeted thumbnail-generation interval in seconds. This is configurable (and required)
        /// only if <c>recordingMode</c> is <c>INTERVAL</c>. Default: 60.</para><para><b>Important:</b> For the <c>BASIC</c> channel type, setting a value for <c>targetIntervalSeconds</c>
        /// does not guarantee that thumbnails are generated at the specified interval. For thumbnails
        /// to be generated at the <c>targetIntervalSeconds</c> interval, the <c>IDR/Keyframe</c>
        /// value for the input video must be less than the <c>targetIntervalSeconds</c> value.
        /// See <a href="https://docs.aws.amazon.com/ivs/latest/userguide/streaming-config.html">
        /// Amazon IVS Streaming Configuration</a> for information on setting <c>IDR/Keyframe</c>
        /// to the recommended value in video-encoder settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThumbnailConfiguration_TargetIntervalSeconds")]
        public System.Int64? ThumbnailConfiguration_TargetIntervalSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecordingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.CreateRecordingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.CreateRecordingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecordingConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSRecordingConfiguration (CreateRecordingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.CreateRecordingConfigurationResponse, NewIVSRecordingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.S3_BucketName = this.S3_BucketName;
            context.Name = this.Name;
            context.RecordingReconnectWindowSecond = this.RecordingReconnectWindowSecond;
            if (this.RenditionConfiguration_Rendition != null)
            {
                context.RenditionConfiguration_Rendition = new List<System.String>(this.RenditionConfiguration_Rendition);
            }
            context.RenditionConfiguration_RenditionSelection = this.RenditionConfiguration_RenditionSelection;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.ThumbnailConfiguration_RecordingMode = this.ThumbnailConfiguration_RecordingMode;
            context.ThumbnailConfiguration_Resolution = this.ThumbnailConfiguration_Resolution;
            if (this.ThumbnailConfiguration_Storage != null)
            {
                context.ThumbnailConfiguration_Storage = new List<System.String>(this.ThumbnailConfiguration_Storage);
            }
            context.ThumbnailConfiguration_TargetIntervalSecond = this.ThumbnailConfiguration_TargetIntervalSecond;
            
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
            var request = new Amazon.IVS.Model.CreateRecordingConfigurationRequest();
            
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.IVS.Model.DestinationConfiguration();
            Amazon.IVS.Model.S3DestinationConfiguration requestDestinationConfiguration_destinationConfiguration_S3 = null;
            
             // populate S3
            var requestDestinationConfiguration_destinationConfiguration_S3IsNull = true;
            requestDestinationConfiguration_destinationConfiguration_S3 = new Amazon.IVS.Model.S3DestinationConfiguration();
            System.String requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = null;
            if (cmdletContext.S3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName = cmdletContext.S3_BucketName;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3.BucketName = requestDestinationConfiguration_destinationConfiguration_S3_s3_BucketName;
                requestDestinationConfiguration_destinationConfiguration_S3IsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_S3 should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_S3IsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_S3 = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3 != null)
            {
                request.DestinationConfiguration.S3 = requestDestinationConfiguration_destinationConfiguration_S3;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RecordingReconnectWindowSecond != null)
            {
                request.RecordingReconnectWindowSeconds = cmdletContext.RecordingReconnectWindowSecond.Value;
            }
            
             // populate RenditionConfiguration
            var requestRenditionConfigurationIsNull = true;
            request.RenditionConfiguration = new Amazon.IVS.Model.RenditionConfiguration();
            List<System.String> requestRenditionConfiguration_renditionConfiguration_Rendition = null;
            if (cmdletContext.RenditionConfiguration_Rendition != null)
            {
                requestRenditionConfiguration_renditionConfiguration_Rendition = cmdletContext.RenditionConfiguration_Rendition;
            }
            if (requestRenditionConfiguration_renditionConfiguration_Rendition != null)
            {
                request.RenditionConfiguration.Renditions = requestRenditionConfiguration_renditionConfiguration_Rendition;
                requestRenditionConfigurationIsNull = false;
            }
            Amazon.IVS.RenditionConfigurationRenditionSelection requestRenditionConfiguration_renditionConfiguration_RenditionSelection = null;
            if (cmdletContext.RenditionConfiguration_RenditionSelection != null)
            {
                requestRenditionConfiguration_renditionConfiguration_RenditionSelection = cmdletContext.RenditionConfiguration_RenditionSelection;
            }
            if (requestRenditionConfiguration_renditionConfiguration_RenditionSelection != null)
            {
                request.RenditionConfiguration.RenditionSelection = requestRenditionConfiguration_renditionConfiguration_RenditionSelection;
                requestRenditionConfigurationIsNull = false;
            }
             // determine if request.RenditionConfiguration should be set to null
            if (requestRenditionConfigurationIsNull)
            {
                request.RenditionConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate ThumbnailConfiguration
            var requestThumbnailConfigurationIsNull = true;
            request.ThumbnailConfiguration = new Amazon.IVS.Model.ThumbnailConfiguration();
            Amazon.IVS.RecordingMode requestThumbnailConfiguration_thumbnailConfiguration_RecordingMode = null;
            if (cmdletContext.ThumbnailConfiguration_RecordingMode != null)
            {
                requestThumbnailConfiguration_thumbnailConfiguration_RecordingMode = cmdletContext.ThumbnailConfiguration_RecordingMode;
            }
            if (requestThumbnailConfiguration_thumbnailConfiguration_RecordingMode != null)
            {
                request.ThumbnailConfiguration.RecordingMode = requestThumbnailConfiguration_thumbnailConfiguration_RecordingMode;
                requestThumbnailConfigurationIsNull = false;
            }
            Amazon.IVS.ThumbnailConfigurationResolution requestThumbnailConfiguration_thumbnailConfiguration_Resolution = null;
            if (cmdletContext.ThumbnailConfiguration_Resolution != null)
            {
                requestThumbnailConfiguration_thumbnailConfiguration_Resolution = cmdletContext.ThumbnailConfiguration_Resolution;
            }
            if (requestThumbnailConfiguration_thumbnailConfiguration_Resolution != null)
            {
                request.ThumbnailConfiguration.Resolution = requestThumbnailConfiguration_thumbnailConfiguration_Resolution;
                requestThumbnailConfigurationIsNull = false;
            }
            List<System.String> requestThumbnailConfiguration_thumbnailConfiguration_Storage = null;
            if (cmdletContext.ThumbnailConfiguration_Storage != null)
            {
                requestThumbnailConfiguration_thumbnailConfiguration_Storage = cmdletContext.ThumbnailConfiguration_Storage;
            }
            if (requestThumbnailConfiguration_thumbnailConfiguration_Storage != null)
            {
                request.ThumbnailConfiguration.Storage = requestThumbnailConfiguration_thumbnailConfiguration_Storage;
                requestThumbnailConfigurationIsNull = false;
            }
            System.Int64? requestThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond = null;
            if (cmdletContext.ThumbnailConfiguration_TargetIntervalSecond != null)
            {
                requestThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond = cmdletContext.ThumbnailConfiguration_TargetIntervalSecond.Value;
            }
            if (requestThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond != null)
            {
                request.ThumbnailConfiguration.TargetIntervalSeconds = requestThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond.Value;
                requestThumbnailConfigurationIsNull = false;
            }
             // determine if request.ThumbnailConfiguration should be set to null
            if (requestThumbnailConfigurationIsNull)
            {
                request.ThumbnailConfiguration = null;
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
        
        private Amazon.IVS.Model.CreateRecordingConfigurationResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.CreateRecordingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "CreateRecordingConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateRecordingConfiguration(request);
                #elif CORECLR
                return client.CreateRecordingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String S3_BucketName { get; set; }
            public System.String Name { get; set; }
            public System.Int32? RecordingReconnectWindowSecond { get; set; }
            public List<System.String> RenditionConfiguration_Rendition { get; set; }
            public Amazon.IVS.RenditionConfigurationRenditionSelection RenditionConfiguration_RenditionSelection { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.IVS.RecordingMode ThumbnailConfiguration_RecordingMode { get; set; }
            public Amazon.IVS.ThumbnailConfigurationResolution ThumbnailConfiguration_Resolution { get; set; }
            public List<System.String> ThumbnailConfiguration_Storage { get; set; }
            public System.Int64? ThumbnailConfiguration_TargetIntervalSecond { get; set; }
            public System.Func<Amazon.IVS.Model.CreateRecordingConfigurationResponse, NewIVSRecordingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecordingConfiguration;
        }
        
    }
}
