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
using Amazon.KinesisVideoSignalingChannels;
using Amazon.KinesisVideoSignalingChannels.Model;

namespace Amazon.PowerShell.Cmdlets.KVSC
{
    /// <summary>
    /// This API allows you to connect WebRTC-enabled devices with Alexa display devices.
    /// When invoked, it sends the Alexa Session Description Protocol (SDP) offer to the master
    /// peer. The offer is delivered as soon as the master is connected to the specified signaling
    /// channel. This API returns the SDP answer from the connected master. If the master
    /// is not connected to the signaling channel, redelivery requests are made until the
    /// message expires.
    /// </summary>
    [Cmdlet("Send", "KVSCAlexaOfferToMaster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Signaling Channels SendAlexaOfferToMaster API operation.", Operation = new[] {"SendAlexaOfferToMaster"}, SelectReturnType = typeof(Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendKVSCAlexaOfferToMasterCmdlet : AmazonKinesisVideoSignalingChannelsClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the signaling channel by which Alexa and the master peer communicate.</para>
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
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter MessagePayload
        /// <summary>
        /// <para>
        /// <para>The base64-encoded SDP offer content.</para>
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
        public System.String MessagePayload { get; set; }
        #endregion
        
        #region Parameter SenderClientId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the sender client.</para>
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
        public System.String SenderClientId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Answer'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Answer";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MessagePayload parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MessagePayload' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MessagePayload' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SenderClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-KVSCAlexaOfferToMaster (SendAlexaOfferToMaster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse, SendKVSCAlexaOfferToMasterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MessagePayload;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessagePayload = this.MessagePayload;
            #if MODULAR
            if (this.MessagePayload == null && ParameterWasBound(nameof(this.MessagePayload)))
            {
                WriteWarning("You are passing $null as a value for parameter MessagePayload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SenderClientId = this.SenderClientId;
            #if MODULAR
            if (this.SenderClientId == null && ParameterWasBound(nameof(this.SenderClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter SenderClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            if (cmdletContext.MessagePayload != null)
            {
                request.MessagePayload = cmdletContext.MessagePayload;
            }
            if (cmdletContext.SenderClientId != null)
            {
                request.SenderClientId = cmdletContext.SenderClientId;
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
        
        private Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse CallAWSServiceOperation(IAmazonKinesisVideoSignalingChannels client, Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Signaling Channels", "SendAlexaOfferToMaster");
            try
            {
                #if DESKTOP
                return client.SendAlexaOfferToMaster(request);
                #elif CORECLR
                return client.SendAlexaOfferToMasterAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelARN { get; set; }
            public System.String MessagePayload { get; set; }
            public System.String SenderClientId { get; set; }
            public System.Func<Amazon.KinesisVideoSignalingChannels.Model.SendAlexaOfferToMasterResponse, SendKVSCAlexaOfferToMasterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Answer;
        }
        
    }
}
