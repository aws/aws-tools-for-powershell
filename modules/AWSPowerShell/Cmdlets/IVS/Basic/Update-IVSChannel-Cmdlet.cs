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
using Amazon.IVS;
using Amazon.IVS.Model;

namespace Amazon.PowerShell.Cmdlets.IVS
{
    /// <summary>
    /// Updates a channel's configuration. Live channels cannot be updated. You must stop
    /// the ongoing stream, update the channel, and restart the stream for the changes to
    /// take effect.
    /// </summary>
    [Cmdlet("Update", "IVSChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.Channel")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service UpdateChannel API operation.", Operation = new[] {"UpdateChannel"}, SelectReturnType = typeof(Amazon.IVS.Model.UpdateChannelResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.Channel or Amazon.IVS.Model.UpdateChannelResponse",
        "This cmdlet returns an Amazon.IVS.Model.Channel object.",
        "The service call response (type Amazon.IVS.Model.UpdateChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIVSChannelCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the channel to be updated.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Authorized
        /// <summary>
        /// <para>
        /// <para>Whether the channel is private (enabled for playback authorization).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Authorized { get; set; }
        #endregion
        
        #region Parameter ContainerFormat
        /// <summary>
        /// <para>
        /// <para>Indicates which content-packaging format is used (MPEG-TS or fMP4). If <c>multitrackInputConfiguration</c>
        /// is specified and <c>enabled</c> is <c>true</c>, then <c>containerFormat</c> is required
        /// and must be set to <c>FRAGMENTED_MP4</c>. Otherwise, <c>containerFormat</c> may be
        /// set to <c>TS</c> or <c>FRAGMENTED_MP4</c>. Default: <c>TS</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ContainerFormat")]
        public Amazon.IVS.ContainerFormat ContainerFormat { get; set; }
        #endregion
        
        #region Parameter MultitrackInputConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether multitrack input is enabled. Can be set to <c>true</c> only if channel
        /// type is <c>STANDARD</c>. Setting <c>enabled</c> to <c>true</c> with any other channel
        /// type will cause an exception. If <c>true</c>, then <c>policy</c>, <c>maximumResolution</c>,
        /// and <c>containerFormat</c> are required, and <c>containerFormat</c> must be set to
        /// <c>FRAGMENTED_MP4</c>. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MultitrackInputConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter InsecureIngest
        /// <summary>
        /// <para>
        /// <para>Whether the channel allows insecure RTMP and SRT ingest. Default: <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InsecureIngest { get; set; }
        #endregion
        
        #region Parameter LatencyMode
        /// <summary>
        /// <para>
        /// <para>Channel latency mode. Use <c>NORMAL</c> to broadcast and deliver live video up to
        /// Full HD. Use <c>LOW</c> for near-real-time interaction with viewers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ChannelLatencyMode")]
        public Amazon.IVS.ChannelLatencyMode LatencyMode { get; set; }
        #endregion
        
        #region Parameter MultitrackInputConfiguration_MaximumResolution
        /// <summary>
        /// <para>
        /// <para>Maximum resolution for multitrack input. Required if <c>enabled</c> is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.MultitrackMaximumResolution")]
        public Amazon.IVS.MultitrackMaximumResolution MultitrackInputConfiguration_MaximumResolution { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Channel name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlaybackRestrictionPolicyArn
        /// <summary>
        /// <para>
        /// <para>Playback-restriction-policy ARN. A valid ARN value here both specifies the ARN and
        /// enables playback restriction. If this is set to an empty string, playback restriction
        /// policy is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlaybackRestrictionPolicyArn { get; set; }
        #endregion
        
        #region Parameter MultitrackInputConfiguration_Policy
        /// <summary>
        /// <para>
        /// <para>Indicates whether multitrack input is allowed or required. Required if <c>enabled</c>
        /// is <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.MultitrackPolicy")]
        public Amazon.IVS.MultitrackPolicy MultitrackInputConfiguration_Policy { get; set; }
        #endregion
        
        #region Parameter Preset
        /// <summary>
        /// <para>
        /// <para>Optional transcode preset for the channel. This is selectable only for <c>ADVANCED_HD</c>
        /// and <c>ADVANCED_SD</c> channel types. For those channel types, the default <c>preset</c>
        /// is <c>HIGHER_BANDWIDTH_DELIVERY</c>. For other channel types (<c>BASIC</c> and <c>STANDARD</c>),
        /// <c>preset</c> is the empty string (<c>""</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.TranscodePreset")]
        public Amazon.IVS.TranscodePreset Preset { get; set; }
        #endregion
        
        #region Parameter RecordingConfigurationArn
        /// <summary>
        /// <para>
        /// <para>Recording-configuration ARN. A valid ARN value here both specifies the ARN and enables
        /// recording. If this is set to an empty string, recording is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordingConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Channel type, which determines the allowable resolution and bitrate. <i>If you exceed
        /// the allowable input resolution or bitrate, the stream probably will disconnect immediately.</i>
        /// Default: <c>STANDARD</c>. For details, see <a href="https://docs.aws.amazon.com/ivs/latest/LowLatencyAPIReference/channel-types.html">Channel
        /// Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ChannelType")]
        public Amazon.IVS.ChannelType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Channel'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.UpdateChannelResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.UpdateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Channel";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IVSChannel (UpdateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.UpdateChannelResponse, UpdateIVSChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Authorized = this.Authorized;
            context.ContainerFormat = this.ContainerFormat;
            context.InsecureIngest = this.InsecureIngest;
            context.LatencyMode = this.LatencyMode;
            context.MultitrackInputConfiguration_Enabled = this.MultitrackInputConfiguration_Enabled;
            context.MultitrackInputConfiguration_MaximumResolution = this.MultitrackInputConfiguration_MaximumResolution;
            context.MultitrackInputConfiguration_Policy = this.MultitrackInputConfiguration_Policy;
            context.Name = this.Name;
            context.PlaybackRestrictionPolicyArn = this.PlaybackRestrictionPolicyArn;
            context.Preset = this.Preset;
            context.RecordingConfigurationArn = this.RecordingConfigurationArn;
            context.Type = this.Type;
            
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
            var request = new Amazon.IVS.Model.UpdateChannelRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.Authorized != null)
            {
                request.Authorized = cmdletContext.Authorized.Value;
            }
            if (cmdletContext.ContainerFormat != null)
            {
                request.ContainerFormat = cmdletContext.ContainerFormat;
            }
            if (cmdletContext.InsecureIngest != null)
            {
                request.InsecureIngest = cmdletContext.InsecureIngest.Value;
            }
            if (cmdletContext.LatencyMode != null)
            {
                request.LatencyMode = cmdletContext.LatencyMode;
            }
            
             // populate MultitrackInputConfiguration
            var requestMultitrackInputConfigurationIsNull = true;
            request.MultitrackInputConfiguration = new Amazon.IVS.Model.MultitrackInputConfiguration();
            System.Boolean? requestMultitrackInputConfiguration_multitrackInputConfiguration_Enabled = null;
            if (cmdletContext.MultitrackInputConfiguration_Enabled != null)
            {
                requestMultitrackInputConfiguration_multitrackInputConfiguration_Enabled = cmdletContext.MultitrackInputConfiguration_Enabled.Value;
            }
            if (requestMultitrackInputConfiguration_multitrackInputConfiguration_Enabled != null)
            {
                request.MultitrackInputConfiguration.Enabled = requestMultitrackInputConfiguration_multitrackInputConfiguration_Enabled.Value;
                requestMultitrackInputConfigurationIsNull = false;
            }
            Amazon.IVS.MultitrackMaximumResolution requestMultitrackInputConfiguration_multitrackInputConfiguration_MaximumResolution = null;
            if (cmdletContext.MultitrackInputConfiguration_MaximumResolution != null)
            {
                requestMultitrackInputConfiguration_multitrackInputConfiguration_MaximumResolution = cmdletContext.MultitrackInputConfiguration_MaximumResolution;
            }
            if (requestMultitrackInputConfiguration_multitrackInputConfiguration_MaximumResolution != null)
            {
                request.MultitrackInputConfiguration.MaximumResolution = requestMultitrackInputConfiguration_multitrackInputConfiguration_MaximumResolution;
                requestMultitrackInputConfigurationIsNull = false;
            }
            Amazon.IVS.MultitrackPolicy requestMultitrackInputConfiguration_multitrackInputConfiguration_Policy = null;
            if (cmdletContext.MultitrackInputConfiguration_Policy != null)
            {
                requestMultitrackInputConfiguration_multitrackInputConfiguration_Policy = cmdletContext.MultitrackInputConfiguration_Policy;
            }
            if (requestMultitrackInputConfiguration_multitrackInputConfiguration_Policy != null)
            {
                request.MultitrackInputConfiguration.Policy = requestMultitrackInputConfiguration_multitrackInputConfiguration_Policy;
                requestMultitrackInputConfigurationIsNull = false;
            }
             // determine if request.MultitrackInputConfiguration should be set to null
            if (requestMultitrackInputConfigurationIsNull)
            {
                request.MultitrackInputConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlaybackRestrictionPolicyArn != null)
            {
                request.PlaybackRestrictionPolicyArn = cmdletContext.PlaybackRestrictionPolicyArn;
            }
            if (cmdletContext.Preset != null)
            {
                request.Preset = cmdletContext.Preset;
            }
            if (cmdletContext.RecordingConfigurationArn != null)
            {
                request.RecordingConfigurationArn = cmdletContext.RecordingConfigurationArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.IVS.Model.UpdateChannelResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.UpdateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "UpdateChannel");
            try
            {
                #if DESKTOP
                return client.UpdateChannel(request);
                #elif CORECLR
                return client.UpdateChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.Boolean? Authorized { get; set; }
            public Amazon.IVS.ContainerFormat ContainerFormat { get; set; }
            public System.Boolean? InsecureIngest { get; set; }
            public Amazon.IVS.ChannelLatencyMode LatencyMode { get; set; }
            public System.Boolean? MultitrackInputConfiguration_Enabled { get; set; }
            public Amazon.IVS.MultitrackMaximumResolution MultitrackInputConfiguration_MaximumResolution { get; set; }
            public Amazon.IVS.MultitrackPolicy MultitrackInputConfiguration_Policy { get; set; }
            public System.String Name { get; set; }
            public System.String PlaybackRestrictionPolicyArn { get; set; }
            public Amazon.IVS.TranscodePreset Preset { get; set; }
            public System.String RecordingConfigurationArn { get; set; }
            public Amazon.IVS.ChannelType Type { get; set; }
            public System.Func<Amazon.IVS.Model.UpdateChannelResponse, UpdateIVSChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Channel;
        }
        
    }
}
