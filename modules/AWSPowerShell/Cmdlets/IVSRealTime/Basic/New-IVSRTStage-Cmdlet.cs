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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Creates a new stage (and optionally participant tokens).
    /// </summary>
    [Cmdlet("New", "IVSRTStage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVSRealTime.Model.CreateStageResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime CreateStage API operation.", Operation = new[] {"CreateStage"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.CreateStageResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.CreateStageResponse",
        "This cmdlet returns an Amazon.IVSRealTime.Model.CreateStageResponse object containing multiple properties."
    )]
    public partial class NewIVSRTStageCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AutoParticipantRecordingConfiguration_MediaType
        /// <summary>
        /// <para>
        /// <para>Types of media to be recorded. Default: <c>AUDIO_VIDEO</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_MediaTypes")]
        public System.String[] AutoParticipantRecordingConfiguration_MediaType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Optional name that can be specified for the stage being created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParticipantTokenConfiguration
        /// <summary>
        /// <para>
        /// <para>Array of participant token configuration objects to attach to the new stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParticipantTokenConfigurations")]
        public Amazon.IVSRealTime.Model.ParticipantTokenConfiguration[] ParticipantTokenConfiguration { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_RecordingMode
        /// <summary>
        /// <para>
        /// <para>Thumbnail recording mode. Default: <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_ThumbnailConfiguration_RecordingMode")]
        [AWSConstantClassSource("Amazon.IVSRealTime.ThumbnailRecordingMode")]
        public Amazon.IVSRealTime.ThumbnailRecordingMode ThumbnailConfiguration_RecordingMode { get; set; }
        #endregion
        
        #region Parameter AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond
        /// <summary>
        /// <para>
        /// <para>If a stage publisher disconnects and then reconnects within the specified interval,
        /// the multiple recordings will be considered a single recording and merged together.</para><para>The default value is 0, which disables merging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_RecordingReconnectWindowSeconds")]
        public System.Int32? AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_Storage
        /// <summary>
        /// <para>
        /// <para>Indicates the format in which thumbnails are recorded. <c>SEQUENTIAL</c> records all
        /// generated thumbnails in a serial manner, to the media/thumbnails/high directory. <c>LATEST</c>
        /// saves the latest thumbnail in media/latest_thumbnail/high/thumb.jpg and overwrites
        /// it at the interval specified by <c>targetIntervalSeconds</c>. You can enable both
        /// <c>SEQUENTIAL</c> and <c>LATEST</c>. Default: <c>SEQUENTIAL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_ThumbnailConfiguration_Storage")]
        public System.String[] ThumbnailConfiguration_Storage { get; set; }
        #endregion
        
        #region Parameter AutoParticipantRecordingConfiguration_StorageConfigurationArn
        /// <summary>
        /// <para>
        /// <para>ARN of the <a>StorageConfiguration</a> resource to use for individual participant
        /// recording. Default: <c>""</c> (empty string, no storage configuration is specified).
        /// Individual participant recording cannot be started unless a storage configuration
        /// is specified, when a <a>Stage</a> is created or updated. To disable individual participant
        /// recording, set this to <c>""</c>; other fields in this object will get reset to their
        /// defaults when sending <c>""</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoParticipantRecordingConfiguration_StorageConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags attached to the resource. Array of maps, each of the form <c>string:string (key:value)</c>.
        /// See <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/best-practices-and-strats.html">Best
        /// practices and strategies</a> in <i>Tagging AWS Resources and Tag Editor</i> for details,
        /// including restrictions that apply to tags and "Tag naming limits and requirements";
        /// Amazon IVS has no constraints on tags beyond what is documented there. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ThumbnailConfiguration_TargetIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The targeted thumbnail-generation interval in seconds. This is configurable only if
        /// <c>recordingMode</c> is <c>INTERVAL</c>. Default: 60.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_ThumbnailConfiguration_TargetIntervalSeconds")]
        public System.Int32? ThumbnailConfiguration_TargetIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HlsConfiguration_TargetSegmentDurationSecond
        /// <summary>
        /// <para>
        /// <para>Defines the target duration for recorded segments generated when recording a stage
        /// participant. Segments may have durations longer than the specified value when needed
        /// to ensure each segment begins with a keyframe. Default: 6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoParticipantRecordingConfiguration_HlsConfiguration_TargetSegmentDurationSeconds")]
        public System.Int32? HlsConfiguration_TargetSegmentDurationSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.CreateStageResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.CreateStageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSRTStage (CreateStage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.CreateStageResponse, NewIVSRTStageCmdlet>(Select) ??
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
            context.HlsConfiguration_TargetSegmentDurationSecond = this.HlsConfiguration_TargetSegmentDurationSecond;
            if (this.AutoParticipantRecordingConfiguration_MediaType != null)
            {
                context.AutoParticipantRecordingConfiguration_MediaType = new List<System.String>(this.AutoParticipantRecordingConfiguration_MediaType);
            }
            context.AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond = this.AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond;
            context.AutoParticipantRecordingConfiguration_StorageConfigurationArn = this.AutoParticipantRecordingConfiguration_StorageConfigurationArn;
            context.ThumbnailConfiguration_RecordingMode = this.ThumbnailConfiguration_RecordingMode;
            if (this.ThumbnailConfiguration_Storage != null)
            {
                context.ThumbnailConfiguration_Storage = new List<System.String>(this.ThumbnailConfiguration_Storage);
            }
            context.ThumbnailConfiguration_TargetIntervalSecond = this.ThumbnailConfiguration_TargetIntervalSecond;
            context.Name = this.Name;
            if (this.ParticipantTokenConfiguration != null)
            {
                context.ParticipantTokenConfiguration = new List<Amazon.IVSRealTime.Model.ParticipantTokenConfiguration>(this.ParticipantTokenConfiguration);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.IVSRealTime.Model.CreateStageRequest();
            
            
             // populate AutoParticipantRecordingConfiguration
            var requestAutoParticipantRecordingConfigurationIsNull = true;
            request.AutoParticipantRecordingConfiguration = new Amazon.IVSRealTime.Model.AutoParticipantRecordingConfiguration();
            List<System.String> requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType = null;
            if (cmdletContext.AutoParticipantRecordingConfiguration_MediaType != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType = cmdletContext.AutoParticipantRecordingConfiguration_MediaType;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType != null)
            {
                request.AutoParticipantRecordingConfiguration.MediaTypes = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_MediaType;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
            System.Int32? requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_RecordingReconnectWindowSecond = null;
            if (cmdletContext.AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_RecordingReconnectWindowSecond = cmdletContext.AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond.Value;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_RecordingReconnectWindowSecond != null)
            {
                request.AutoParticipantRecordingConfiguration.RecordingReconnectWindowSeconds = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_RecordingReconnectWindowSecond.Value;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
            System.String requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn = null;
            if (cmdletContext.AutoParticipantRecordingConfiguration_StorageConfigurationArn != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn = cmdletContext.AutoParticipantRecordingConfiguration_StorageConfigurationArn;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn != null)
            {
                request.AutoParticipantRecordingConfiguration.StorageConfigurationArn = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_StorageConfigurationArn;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
            Amazon.IVSRealTime.Model.ParticipantRecordingHlsConfiguration requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration = null;
            
             // populate HlsConfiguration
            var requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfigurationIsNull = true;
            requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration = new Amazon.IVSRealTime.Model.ParticipantRecordingHlsConfiguration();
            System.Int32? requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration_hlsConfiguration_TargetSegmentDurationSecond = null;
            if (cmdletContext.HlsConfiguration_TargetSegmentDurationSecond != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration_hlsConfiguration_TargetSegmentDurationSecond = cmdletContext.HlsConfiguration_TargetSegmentDurationSecond.Value;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration_hlsConfiguration_TargetSegmentDurationSecond != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration.TargetSegmentDurationSeconds = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration_hlsConfiguration_TargetSegmentDurationSecond.Value;
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfigurationIsNull = false;
            }
             // determine if requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration should be set to null
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfigurationIsNull)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration = null;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration != null)
            {
                request.AutoParticipantRecordingConfiguration.HlsConfiguration = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_HlsConfiguration;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
            Amazon.IVSRealTime.Model.ParticipantThumbnailConfiguration requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration = null;
            
             // populate ThumbnailConfiguration
            var requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfigurationIsNull = true;
            requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration = new Amazon.IVSRealTime.Model.ParticipantThumbnailConfiguration();
            Amazon.IVSRealTime.ThumbnailRecordingMode requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_RecordingMode = null;
            if (cmdletContext.ThumbnailConfiguration_RecordingMode != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_RecordingMode = cmdletContext.ThumbnailConfiguration_RecordingMode;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_RecordingMode != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration.RecordingMode = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_RecordingMode;
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfigurationIsNull = false;
            }
            List<System.String> requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_Storage = null;
            if (cmdletContext.ThumbnailConfiguration_Storage != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_Storage = cmdletContext.ThumbnailConfiguration_Storage;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_Storage != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration.Storage = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_Storage;
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfigurationIsNull = false;
            }
            System.Int32? requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond = null;
            if (cmdletContext.ThumbnailConfiguration_TargetIntervalSecond != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond = cmdletContext.ThumbnailConfiguration_TargetIntervalSecond.Value;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond != null)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration.TargetIntervalSeconds = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration_thumbnailConfiguration_TargetIntervalSecond.Value;
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfigurationIsNull = false;
            }
             // determine if requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration should be set to null
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfigurationIsNull)
            {
                requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration = null;
            }
            if (requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration != null)
            {
                request.AutoParticipantRecordingConfiguration.ThumbnailConfiguration = requestAutoParticipantRecordingConfiguration_autoParticipantRecordingConfiguration_ThumbnailConfiguration;
                requestAutoParticipantRecordingConfigurationIsNull = false;
            }
             // determine if request.AutoParticipantRecordingConfiguration should be set to null
            if (requestAutoParticipantRecordingConfigurationIsNull)
            {
                request.AutoParticipantRecordingConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParticipantTokenConfiguration != null)
            {
                request.ParticipantTokenConfigurations = cmdletContext.ParticipantTokenConfiguration;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IVSRealTime.Model.CreateStageResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.CreateStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "CreateStage");
            try
            {
                #if DESKTOP
                return client.CreateStage(request);
                #elif CORECLR
                return client.CreateStageAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? HlsConfiguration_TargetSegmentDurationSecond { get; set; }
            public List<System.String> AutoParticipantRecordingConfiguration_MediaType { get; set; }
            public System.Int32? AutoParticipantRecordingConfiguration_RecordingReconnectWindowSecond { get; set; }
            public System.String AutoParticipantRecordingConfiguration_StorageConfigurationArn { get; set; }
            public Amazon.IVSRealTime.ThumbnailRecordingMode ThumbnailConfiguration_RecordingMode { get; set; }
            public List<System.String> ThumbnailConfiguration_Storage { get; set; }
            public System.Int32? ThumbnailConfiguration_TargetIntervalSecond { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.IVSRealTime.Model.ParticipantTokenConfiguration> ParticipantTokenConfiguration { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.CreateStageResponse, NewIVSRTStageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
