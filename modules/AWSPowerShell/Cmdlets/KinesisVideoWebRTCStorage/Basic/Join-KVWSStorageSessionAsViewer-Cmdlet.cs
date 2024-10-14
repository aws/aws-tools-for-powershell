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
using Amazon.KinesisVideoWebRTCStorage;
using Amazon.KinesisVideoWebRTCStorage.Model;

namespace Amazon.PowerShell.Cmdlets.KVWS
{
    /// <summary>
    /// Join the ongoing one way-video and/or multi-way audio WebRTC session as a viewer
    /// for an input channel. If there’s no existing session for the channel, create a new
    /// streaming session and provide the Amazon Resource Name (ARN) of the signaling channel
    /// (<c>channelArn</c>) and client id (<c>clientId</c>). 
    /// 
    ///  
    /// <para>
    /// Currently for <c>SINGLE_MASTER</c> type, a video producing device is able to ingest
    /// both audio and video media into a stream, while viewers can only ingest audio. Both
    /// a video producing device and viewers can join a session first and wait for other participants.
    /// While participants are having peer to peer conversations through WebRTC, the ingested
    /// media session will be stored into the Kinesis Video Stream. Multiple viewers are able
    /// to playback real-time media. 
    /// </para><para>
    /// Customers can also use existing Kinesis Video Streams features like <c>HLS</c> or
    /// <c>DASH</c> playback, Image generation, and more with ingested WebRTC media. If there’s
    /// an existing session with the same <c>clientId</c> that's found in the join session
    /// request, the new request takes precedence.
    /// </para>
    /// </summary>
    [Cmdlet("Join", "KVWSStorageSessionAsViewer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video WebRTC Storage JoinStorageSessionAsViewer API operation.", Operation = new[] {"JoinStorageSessionAsViewer"}, SelectReturnType = typeof(Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse) be returned by specifying '-Select *'."
    )]
    public partial class JoinKVWSStorageSessionAsViewerCmdlet : AmazonKinesisVideoWebRTCStorageClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the signaling channel. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para> The unique identifier for the sender client. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Join-KVWSStorageSessionAsViewer (JoinStorageSessionAsViewer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse, JoinKVWSStorageSessionAsViewerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
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
        
        private Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse CallAWSServiceOperation(IAmazonKinesisVideoWebRTCStorage client, Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video WebRTC Storage", "JoinStorageSessionAsViewer");
            try
            {
                #if DESKTOP
                return client.JoinStorageSessionAsViewer(request);
                #elif CORECLR
                return client.JoinStorageSessionAsViewerAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ClientId { get; set; }
            public System.Func<Amazon.KinesisVideoWebRTCStorage.Model.JoinStorageSessionAsViewerResponse, JoinKVWSStorageSessionAsViewerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
