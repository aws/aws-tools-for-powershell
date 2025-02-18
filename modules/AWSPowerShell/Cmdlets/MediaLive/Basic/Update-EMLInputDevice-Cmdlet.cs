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
using Amazon.MediaLive;
using Amazon.MediaLive.Model;

namespace Amazon.PowerShell.Cmdlets.EML
{
    /// <summary>
    /// Updates the parameters for the input device.
    /// </summary>
    [Cmdlet("Update", "EMLInputDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaLive.Model.UpdateInputDeviceResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaLive UpdateInputDevice API operation.", Operation = new[] {"UpdateInputDevice"}, SelectReturnType = typeof(Amazon.MediaLive.Model.UpdateInputDeviceResponse))]
    [AWSCmdletOutput("Amazon.MediaLive.Model.UpdateInputDeviceResponse",
        "This cmdlet returns an Amazon.MediaLive.Model.UpdateInputDeviceResponse object containing multiple properties."
    )]
    public partial class UpdateEMLInputDeviceCmdlet : AmazonMediaLiveClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HdDeviceSettings_AudioChannelPair
        /// <summary>
        /// <para>
        /// An array of eight audio configurations,
        /// one for each audio pair in the source. Set up each audio configuration either to exclude
        /// the pair, or to format it and include it in the output from the device. This parameter
        /// applies only to UHD devices, and only when the device is configured as the source
        /// for a MediaConnect flow. For an HD device, you configure the audio by setting up audio
        /// selectors in the channel configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HdDeviceSettings_AudioChannelPairs")]
        public Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig[] HdDeviceSettings_AudioChannelPair { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_AudioChannelPair
        /// <summary>
        /// <para>
        /// An array of eight audio configurations,
        /// one for each audio pair in the source. Set up each audio configuration either to exclude
        /// the pair, or to format it and include it in the output from the device. This parameter
        /// applies only to UHD devices, and only when the device is configured as the source
        /// for a MediaConnect flow. For an HD device, you configure the audio by setting up audio
        /// selectors in the channel configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UhdDeviceSettings_AudioChannelPairs")]
        public Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig[] UhdDeviceSettings_AudioChannelPair { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// The Availability Zone you want associated
        /// with this input device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_Codec
        /// <summary>
        /// <para>
        /// Choose the codec for the video that the device produces.
        /// Only UHD devices can specify this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceCodec")]
        public Amazon.MediaLive.InputDeviceCodec HdDeviceSettings_Codec { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_Codec
        /// <summary>
        /// <para>
        /// Choose the codec for the video that the device produces.
        /// Only UHD devices can specify this parameter.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceCodec")]
        public Amazon.MediaLive.InputDeviceCodec UhdDeviceSettings_Codec { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_ConfiguredInput
        /// <summary>
        /// <para>
        /// The input source that you want to use.
        /// If the device has a source connected to only one of its input ports, or if you don't
        /// care which source the device sends, specify Auto. If the device has sources connected
        /// to both its input ports, and you want to use a specific source, specify the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceConfiguredInput")]
        public Amazon.MediaLive.InputDeviceConfiguredInput HdDeviceSettings_ConfiguredInput { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_ConfiguredInput
        /// <summary>
        /// <para>
        /// The input source that you want to use.
        /// If the device has a source connected to only one of its input ports, or if you don't
        /// care which source the device sends, specify Auto. If the device has sources connected
        /// to both its input ports, and you want to use a specific source, specify the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaLive.InputDeviceConfiguredInput")]
        public Amazon.MediaLive.InputDeviceConfiguredInput UhdDeviceSettings_ConfiguredInput { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MediaconnectSettings_FlowArn
        /// <summary>
        /// <para>
        /// The ARN of the MediaConnect flow to attach this
        /// device to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HdDeviceSettings_MediaconnectSettings_FlowArn { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MediaconnectSettings_FlowArn
        /// <summary>
        /// <para>
        /// The ARN of the MediaConnect flow to attach this
        /// device to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UhdDeviceSettings_MediaconnectSettings_FlowArn { get; set; }
        #endregion
        
        #region Parameter InputDeviceId
        /// <summary>
        /// <para>
        /// The unique ID of the input device. For example,
        /// hd-123456789abcdef.
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
        public System.String InputDeviceId { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_LatencyMs
        /// <summary>
        /// <para>
        /// The Link device's buffer size (latency) in milliseconds
        /// (ms).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HdDeviceSettings_LatencyMs { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_LatencyMs
        /// <summary>
        /// <para>
        /// The Link device's buffer size (latency) in milliseconds
        /// (ms).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UhdDeviceSettings_LatencyMs { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum bitrate in bits per second. Set
        /// a value here to throttle the bitrate of the source video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HdDeviceSettings_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MaxBitrate
        /// <summary>
        /// <para>
        /// The maximum bitrate in bits per second. Set
        /// a value here to throttle the bitrate of the source video.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? UhdDeviceSettings_MaxBitrate { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name that you assigned to this input device (not
        /// the unique ID).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MediaconnectSettings_RoleArn
        /// <summary>
        /// <para>
        /// The ARN for the role that MediaLive assumes to
        /// access the attached flow and secret. For more information about how to create this
        /// role, see the MediaLive user guide.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HdDeviceSettings_MediaconnectSettings_RoleArn { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MediaconnectSettings_RoleArn
        /// <summary>
        /// <para>
        /// The ARN for the role that MediaLive assumes to
        /// access the attached flow and secret. For more information about how to create this
        /// role, see the MediaLive user guide.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UhdDeviceSettings_MediaconnectSettings_RoleArn { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MediaconnectSettings_SecretArn
        /// <summary>
        /// <para>
        /// The ARN for the secret that holds the encryption
        /// key to encrypt the content output by the device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HdDeviceSettings_MediaconnectSettings_SecretArn { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MediaconnectSettings_SecretArn
        /// <summary>
        /// <para>
        /// The ARN for the secret that holds the encryption
        /// key to encrypt the content output by the device.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UhdDeviceSettings_MediaconnectSettings_SecretArn { get; set; }
        #endregion
        
        #region Parameter HdDeviceSettings_MediaconnectSettings_SourceName
        /// <summary>
        /// <para>
        /// The name of the MediaConnect Flow source to
        /// stream to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HdDeviceSettings_MediaconnectSettings_SourceName { get; set; }
        #endregion
        
        #region Parameter UhdDeviceSettings_MediaconnectSettings_SourceName
        /// <summary>
        /// <para>
        /// The name of the MediaConnect Flow source to
        /// stream to.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UhdDeviceSettings_MediaconnectSettings_SourceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaLive.Model.UpdateInputDeviceResponse).
        /// Specifying the name of a property of type Amazon.MediaLive.Model.UpdateInputDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputDeviceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMLInputDevice (UpdateInputDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaLive.Model.UpdateInputDeviceResponse, UpdateEMLInputDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            if (this.HdDeviceSettings_AudioChannelPair != null)
            {
                context.HdDeviceSettings_AudioChannelPair = new List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig>(this.HdDeviceSettings_AudioChannelPair);
            }
            context.HdDeviceSettings_Codec = this.HdDeviceSettings_Codec;
            context.HdDeviceSettings_ConfiguredInput = this.HdDeviceSettings_ConfiguredInput;
            context.HdDeviceSettings_LatencyMs = this.HdDeviceSettings_LatencyMs;
            context.HdDeviceSettings_MaxBitrate = this.HdDeviceSettings_MaxBitrate;
            context.HdDeviceSettings_MediaconnectSettings_FlowArn = this.HdDeviceSettings_MediaconnectSettings_FlowArn;
            context.HdDeviceSettings_MediaconnectSettings_RoleArn = this.HdDeviceSettings_MediaconnectSettings_RoleArn;
            context.HdDeviceSettings_MediaconnectSettings_SecretArn = this.HdDeviceSettings_MediaconnectSettings_SecretArn;
            context.HdDeviceSettings_MediaconnectSettings_SourceName = this.HdDeviceSettings_MediaconnectSettings_SourceName;
            context.InputDeviceId = this.InputDeviceId;
            #if MODULAR
            if (this.InputDeviceId == null && ParameterWasBound(nameof(this.InputDeviceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDeviceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.UhdDeviceSettings_AudioChannelPair != null)
            {
                context.UhdDeviceSettings_AudioChannelPair = new List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig>(this.UhdDeviceSettings_AudioChannelPair);
            }
            context.UhdDeviceSettings_Codec = this.UhdDeviceSettings_Codec;
            context.UhdDeviceSettings_ConfiguredInput = this.UhdDeviceSettings_ConfiguredInput;
            context.UhdDeviceSettings_LatencyMs = this.UhdDeviceSettings_LatencyMs;
            context.UhdDeviceSettings_MaxBitrate = this.UhdDeviceSettings_MaxBitrate;
            context.UhdDeviceSettings_MediaconnectSettings_FlowArn = this.UhdDeviceSettings_MediaconnectSettings_FlowArn;
            context.UhdDeviceSettings_MediaconnectSettings_RoleArn = this.UhdDeviceSettings_MediaconnectSettings_RoleArn;
            context.UhdDeviceSettings_MediaconnectSettings_SecretArn = this.UhdDeviceSettings_MediaconnectSettings_SecretArn;
            context.UhdDeviceSettings_MediaconnectSettings_SourceName = this.UhdDeviceSettings_MediaconnectSettings_SourceName;
            
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
            var request = new Amazon.MediaLive.Model.UpdateInputDeviceRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            
             // populate HdDeviceSettings
            var requestHdDeviceSettingsIsNull = true;
            request.HdDeviceSettings = new Amazon.MediaLive.Model.InputDeviceConfigurableSettings();
            List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig> requestHdDeviceSettings_hdDeviceSettings_AudioChannelPair = null;
            if (cmdletContext.HdDeviceSettings_AudioChannelPair != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_AudioChannelPair = cmdletContext.HdDeviceSettings_AudioChannelPair;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_AudioChannelPair != null)
            {
                request.HdDeviceSettings.AudioChannelPairs = requestHdDeviceSettings_hdDeviceSettings_AudioChannelPair;
                requestHdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.InputDeviceCodec requestHdDeviceSettings_hdDeviceSettings_Codec = null;
            if (cmdletContext.HdDeviceSettings_Codec != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_Codec = cmdletContext.HdDeviceSettings_Codec;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_Codec != null)
            {
                request.HdDeviceSettings.Codec = requestHdDeviceSettings_hdDeviceSettings_Codec;
                requestHdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.InputDeviceConfiguredInput requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput = null;
            if (cmdletContext.HdDeviceSettings_ConfiguredInput != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput = cmdletContext.HdDeviceSettings_ConfiguredInput;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput != null)
            {
                request.HdDeviceSettings.ConfiguredInput = requestHdDeviceSettings_hdDeviceSettings_ConfiguredInput;
                requestHdDeviceSettingsIsNull = false;
            }
            System.Int32? requestHdDeviceSettings_hdDeviceSettings_LatencyMs = null;
            if (cmdletContext.HdDeviceSettings_LatencyMs != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_LatencyMs = cmdletContext.HdDeviceSettings_LatencyMs.Value;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_LatencyMs != null)
            {
                request.HdDeviceSettings.LatencyMs = requestHdDeviceSettings_hdDeviceSettings_LatencyMs.Value;
                requestHdDeviceSettingsIsNull = false;
            }
            System.Int32? requestHdDeviceSettings_hdDeviceSettings_MaxBitrate = null;
            if (cmdletContext.HdDeviceSettings_MaxBitrate != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MaxBitrate = cmdletContext.HdDeviceSettings_MaxBitrate.Value;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MaxBitrate != null)
            {
                request.HdDeviceSettings.MaxBitrate = requestHdDeviceSettings_hdDeviceSettings_MaxBitrate.Value;
                requestHdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.InputDeviceMediaConnectConfigurableSettings requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings = null;
            
             // populate MediaconnectSettings
            var requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull = true;
            requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings = new Amazon.MediaLive.Model.InputDeviceMediaConnectConfigurableSettings();
            System.String requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_FlowArn = null;
            if (cmdletContext.HdDeviceSettings_MediaconnectSettings_FlowArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_FlowArn = cmdletContext.HdDeviceSettings_MediaconnectSettings_FlowArn;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_FlowArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings.FlowArn = requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_FlowArn;
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_RoleArn = null;
            if (cmdletContext.HdDeviceSettings_MediaconnectSettings_RoleArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_RoleArn = cmdletContext.HdDeviceSettings_MediaconnectSettings_RoleArn;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_RoleArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings.RoleArn = requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_RoleArn;
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SecretArn = null;
            if (cmdletContext.HdDeviceSettings_MediaconnectSettings_SecretArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SecretArn = cmdletContext.HdDeviceSettings_MediaconnectSettings_SecretArn;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SecretArn != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings.SecretArn = requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SecretArn;
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SourceName = null;
            if (cmdletContext.HdDeviceSettings_MediaconnectSettings_SourceName != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SourceName = cmdletContext.HdDeviceSettings_MediaconnectSettings_SourceName;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SourceName != null)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings.SourceName = requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings_hdDeviceSettings_MediaconnectSettings_SourceName;
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
             // determine if requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings should be set to null
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettingsIsNull)
            {
                requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings = null;
            }
            if (requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings != null)
            {
                request.HdDeviceSettings.MediaconnectSettings = requestHdDeviceSettings_hdDeviceSettings_MediaconnectSettings;
                requestHdDeviceSettingsIsNull = false;
            }
             // determine if request.HdDeviceSettings should be set to null
            if (requestHdDeviceSettingsIsNull)
            {
                request.HdDeviceSettings = null;
            }
            if (cmdletContext.InputDeviceId != null)
            {
                request.InputDeviceId = cmdletContext.InputDeviceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate UhdDeviceSettings
            var requestUhdDeviceSettingsIsNull = true;
            request.UhdDeviceSettings = new Amazon.MediaLive.Model.InputDeviceConfigurableSettings();
            List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig> requestUhdDeviceSettings_uhdDeviceSettings_AudioChannelPair = null;
            if (cmdletContext.UhdDeviceSettings_AudioChannelPair != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_AudioChannelPair = cmdletContext.UhdDeviceSettings_AudioChannelPair;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_AudioChannelPair != null)
            {
                request.UhdDeviceSettings.AudioChannelPairs = requestUhdDeviceSettings_uhdDeviceSettings_AudioChannelPair;
                requestUhdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.InputDeviceCodec requestUhdDeviceSettings_uhdDeviceSettings_Codec = null;
            if (cmdletContext.UhdDeviceSettings_Codec != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_Codec = cmdletContext.UhdDeviceSettings_Codec;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_Codec != null)
            {
                request.UhdDeviceSettings.Codec = requestUhdDeviceSettings_uhdDeviceSettings_Codec;
                requestUhdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.InputDeviceConfiguredInput requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput = null;
            if (cmdletContext.UhdDeviceSettings_ConfiguredInput != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput = cmdletContext.UhdDeviceSettings_ConfiguredInput;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput != null)
            {
                request.UhdDeviceSettings.ConfiguredInput = requestUhdDeviceSettings_uhdDeviceSettings_ConfiguredInput;
                requestUhdDeviceSettingsIsNull = false;
            }
            System.Int32? requestUhdDeviceSettings_uhdDeviceSettings_LatencyMs = null;
            if (cmdletContext.UhdDeviceSettings_LatencyMs != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_LatencyMs = cmdletContext.UhdDeviceSettings_LatencyMs.Value;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_LatencyMs != null)
            {
                request.UhdDeviceSettings.LatencyMs = requestUhdDeviceSettings_uhdDeviceSettings_LatencyMs.Value;
                requestUhdDeviceSettingsIsNull = false;
            }
            System.Int32? requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate = null;
            if (cmdletContext.UhdDeviceSettings_MaxBitrate != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate = cmdletContext.UhdDeviceSettings_MaxBitrate.Value;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate != null)
            {
                request.UhdDeviceSettings.MaxBitrate = requestUhdDeviceSettings_uhdDeviceSettings_MaxBitrate.Value;
                requestUhdDeviceSettingsIsNull = false;
            }
            Amazon.MediaLive.Model.InputDeviceMediaConnectConfigurableSettings requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings = null;
            
             // populate MediaconnectSettings
            var requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull = true;
            requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings = new Amazon.MediaLive.Model.InputDeviceMediaConnectConfigurableSettings();
            System.String requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_FlowArn = null;
            if (cmdletContext.UhdDeviceSettings_MediaconnectSettings_FlowArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_FlowArn = cmdletContext.UhdDeviceSettings_MediaconnectSettings_FlowArn;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_FlowArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings.FlowArn = requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_FlowArn;
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_RoleArn = null;
            if (cmdletContext.UhdDeviceSettings_MediaconnectSettings_RoleArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_RoleArn = cmdletContext.UhdDeviceSettings_MediaconnectSettings_RoleArn;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_RoleArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings.RoleArn = requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_RoleArn;
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SecretArn = null;
            if (cmdletContext.UhdDeviceSettings_MediaconnectSettings_SecretArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SecretArn = cmdletContext.UhdDeviceSettings_MediaconnectSettings_SecretArn;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SecretArn != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings.SecretArn = requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SecretArn;
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
            System.String requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SourceName = null;
            if (cmdletContext.UhdDeviceSettings_MediaconnectSettings_SourceName != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SourceName = cmdletContext.UhdDeviceSettings_MediaconnectSettings_SourceName;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SourceName != null)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings.SourceName = requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings_uhdDeviceSettings_MediaconnectSettings_SourceName;
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull = false;
            }
             // determine if requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings should be set to null
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettingsIsNull)
            {
                requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings = null;
            }
            if (requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings != null)
            {
                request.UhdDeviceSettings.MediaconnectSettings = requestUhdDeviceSettings_uhdDeviceSettings_MediaconnectSettings;
                requestUhdDeviceSettingsIsNull = false;
            }
             // determine if request.UhdDeviceSettings should be set to null
            if (requestUhdDeviceSettingsIsNull)
            {
                request.UhdDeviceSettings = null;
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
        
        private Amazon.MediaLive.Model.UpdateInputDeviceResponse CallAWSServiceOperation(IAmazonMediaLive client, Amazon.MediaLive.Model.UpdateInputDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaLive", "UpdateInputDevice");
            try
            {
                return client.UpdateInputDeviceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig> HdDeviceSettings_AudioChannelPair { get; set; }
            public Amazon.MediaLive.InputDeviceCodec HdDeviceSettings_Codec { get; set; }
            public Amazon.MediaLive.InputDeviceConfiguredInput HdDeviceSettings_ConfiguredInput { get; set; }
            public System.Int32? HdDeviceSettings_LatencyMs { get; set; }
            public System.Int32? HdDeviceSettings_MaxBitrate { get; set; }
            public System.String HdDeviceSettings_MediaconnectSettings_FlowArn { get; set; }
            public System.String HdDeviceSettings_MediaconnectSettings_RoleArn { get; set; }
            public System.String HdDeviceSettings_MediaconnectSettings_SecretArn { get; set; }
            public System.String HdDeviceSettings_MediaconnectSettings_SourceName { get; set; }
            public System.String InputDeviceId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.MediaLive.Model.InputDeviceConfigurableAudioChannelPairConfig> UhdDeviceSettings_AudioChannelPair { get; set; }
            public Amazon.MediaLive.InputDeviceCodec UhdDeviceSettings_Codec { get; set; }
            public Amazon.MediaLive.InputDeviceConfiguredInput UhdDeviceSettings_ConfiguredInput { get; set; }
            public System.Int32? UhdDeviceSettings_LatencyMs { get; set; }
            public System.Int32? UhdDeviceSettings_MaxBitrate { get; set; }
            public System.String UhdDeviceSettings_MediaconnectSettings_FlowArn { get; set; }
            public System.String UhdDeviceSettings_MediaconnectSettings_RoleArn { get; set; }
            public System.String UhdDeviceSettings_MediaconnectSettings_SecretArn { get; set; }
            public System.String UhdDeviceSettings_MediaconnectSettings_SourceName { get; set; }
            public System.Func<Amazon.MediaLive.Model.UpdateInputDeviceResponse, UpdateEMLInputDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
