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
    /// Creates a new channel and an associated stream key to start streaming.
    /// </summary>
    [Cmdlet("New", "IVSChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVS.Model.CreateChannelResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.IVS.Model.CreateChannelResponse))]
    [AWSCmdletOutput("Amazon.IVS.Model.CreateChannelResponse",
        "This cmdlet returns an Amazon.IVS.Model.CreateChannelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIVSChannelCmdlet : AmazonIVSClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter Authorized
        /// <summary>
        /// <para>
        /// <para>Whether the channel is private (enabled for playback authorization). Default: <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Authorized { get; set; }
        #endregion
        
        #region Parameter InsecureIngest
        /// <summary>
        /// <para>
        /// <para>Whether the channel allows insecure RTMP ingest. Default: <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InsecureIngest { get; set; }
        #endregion
        
        #region Parameter LatencyMode
        /// <summary>
        /// <para>
        /// <para>Channel latency mode. Use <code>NORMAL</code> to broadcast and deliver live video
        /// up to Full HD. Use <code>LOW</code> for near-real-time interaction with viewers. (Note:
        /// In the Amazon IVS console, <code>LOW</code> and <code>NORMAL</code> correspond to
        /// Ultra-low and Standard, respectively.) Default: <code>LOW</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ChannelLatencyMode")]
        public Amazon.IVS.ChannelLatencyMode LatencyMode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Channel name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Preset
        /// <summary>
        /// <para>
        /// <para>Optional transcode preset for the channel. This is selectable only for <code>ADVANCED_HD</code>
        /// and <code>ADVANCED_SD</code> channel types. For those channel types, the default <code>preset</code>
        /// is <code>HIGHER_BANDWIDTH_DELIVERY</code>. For other channel types (<code>BASIC</code>
        /// and <code>STANDARD</code>), <code>preset</code> is the empty string (<code>""</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.TranscodePreset")]
        public Amazon.IVS.TranscodePreset Preset { get; set; }
        #endregion
        
        #region Parameter RecordingConfigurationArn
        /// <summary>
        /// <para>
        /// <para>Recording-configuration ARN. Default: "" (empty string, recording is disabled).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordingConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Array of 1-50 maps, each of the form <code>string:string (key:value)</code>. See <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging Amazon
        /// Web Services Resources</a> for more information, including restrictions that apply
        /// to tags and "Tag naming limits and requirements"; Amazon IVS has no service-specific
        /// constraints beyond what is documented there.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>Channel type, which determines the allowable resolution and bitrate. <i>If you exceed
        /// the allowable input resolution or bitrate, the stream probably will disconnect immediately.</i>
        /// Default: <code>STANDARD</code>. For details, see <a href="https://docs.aws.amazon.com/ivs/latest/LowLatencyAPIReference/channel-types.html">Channel
        /// Types</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IVS.ChannelType")]
        public Amazon.IVS.ChannelType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVS.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.IVS.Model.CreateChannelResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IVSChannel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVS.Model.CreateChannelResponse, NewIVSChannelCmdlet>(Select) ??
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
            context.Authorized = this.Authorized;
            context.InsecureIngest = this.InsecureIngest;
            context.LatencyMode = this.LatencyMode;
            context.Name = this.Name;
            context.Preset = this.Preset;
            context.RecordingConfigurationArn = this.RecordingConfigurationArn;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
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
            var request = new Amazon.IVS.Model.CreateChannelRequest();
            
            if (cmdletContext.Authorized != null)
            {
                request.Authorized = cmdletContext.Authorized.Value;
            }
            if (cmdletContext.InsecureIngest != null)
            {
                request.InsecureIngest = cmdletContext.InsecureIngest.Value;
            }
            if (cmdletContext.LatencyMode != null)
            {
                request.LatencyMode = cmdletContext.LatencyMode;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Preset != null)
            {
                request.Preset = cmdletContext.Preset;
            }
            if (cmdletContext.RecordingConfigurationArn != null)
            {
                request.RecordingConfigurationArn = cmdletContext.RecordingConfigurationArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IVS.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonIVS client, Amazon.IVS.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service", "CreateChannel");
            try
            {
                #if DESKTOP
                return client.CreateChannel(request);
                #elif CORECLR
                return client.CreateChannelAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Authorized { get; set; }
            public System.Boolean? InsecureIngest { get; set; }
            public Amazon.IVS.ChannelLatencyMode LatencyMode { get; set; }
            public System.String Name { get; set; }
            public Amazon.IVS.TranscodePreset Preset { get; set; }
            public System.String RecordingConfigurationArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.IVS.ChannelType Type { get; set; }
            public System.Func<Amazon.IVS.Model.CreateChannelResponse, NewIVSChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
