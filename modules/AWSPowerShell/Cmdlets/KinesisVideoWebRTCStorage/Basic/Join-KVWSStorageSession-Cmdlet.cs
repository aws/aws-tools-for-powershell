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
using Amazon.KinesisVideoWebRTCStorage;
using Amazon.KinesisVideoWebRTCStorage.Model;

namespace Amazon.PowerShell.Cmdlets.KVWS
{
    /// <summary>
    /// <note><para>
    /// Before using this API, you must call the <c>GetSignalingChannelEndpoint</c> API to
    /// request the WEBRTC endpoint. You then specify the endpoint and region in your <c>JoinStorageSession</c>
    /// API request.
    /// </para></note><para>
    /// Join the ongoing one way-video and/or multi-way audio WebRTC session as a video producing
    /// device for an input channel. If there’s no existing session for the channel, a new
    /// streaming session needs to be created, and the Amazon Resource Name (ARN) of the signaling
    /// channel must be provided. 
    /// </para><para>
    /// Currently for the <c>SINGLE_MASTER</c> type, a video producing device is able to ingest
    /// both audio and video media into a stream. Only video producing devices can join the
    /// session and record media.
    /// </para><important><para>
    /// Both audio and video tracks are currently required for WebRTC ingestion.
    /// </para><para>
    /// Current requirements:
    /// </para><ul><li><para>
    /// Video track: H.264
    /// </para></li><li><para>
    /// Audio track: Opus
    /// </para></li></ul></important><para>
    /// The resulting ingested video in the Kinesis video stream will have the following parameters:
    /// H.264 video and AAC audio.
    /// </para><para>
    /// Once a master participant has negotiated a connection through WebRTC, the ingested
    /// media session will be stored in the Kinesis video stream. Multiple viewers are then
    /// able to play back real-time media through our Playback APIs.
    /// </para><para>
    /// You can also use existing Kinesis Video Streams features like <c>HLS</c> or <c>DASH</c>
    /// playback, image generation via <a href="https://docs.aws.amazon.com/kinesisvideostreams/latest/dg/gs-getImages.html">GetImages</a>,
    /// and more with ingested WebRTC media.
    /// </para><note><para>
    /// S3 image delivery and notifications are not currently supported.
    /// </para></note><note><para>
    /// Assume that only one video producing device client can be associated with a session
    /// for the channel. If more than one client joins the session of a specific channel as
    /// a video producing device, the most recent client request takes precedence. 
    /// </para></note><para><b>Additional information</b></para><ul><li><para><b>Idempotent</b> - This API is not idempotent.
    /// </para></li><li><para><b>Retry behavior</b> - This is counted as a new API call.
    /// </para></li><li><para><b>Concurrent calls</b> - Concurrent calls are allowed. An offer is sent once per
    /// each call.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Join", "KVWSStorageSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video WebRTC Storage JoinStorageSession API operation.", Operation = new[] {"JoinStorageSession"}, SelectReturnType = typeof(Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse) be returned by specifying '-Select *'."
    )]
    public partial class JoinKVWSStorageSessionCmdlet : AmazonKinesisVideoWebRTCStorageClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the signaling channel. </para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Join-KVWSStorageSession (JoinStorageSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse, JoinKVWSStorageSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
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
        
        private Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse CallAWSServiceOperation(IAmazonKinesisVideoWebRTCStorage client, Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video WebRTC Storage", "JoinStorageSession");
            try
            {
                return client.JoinStorageSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.Func<Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionResponse, JoinKVWSStorageSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
