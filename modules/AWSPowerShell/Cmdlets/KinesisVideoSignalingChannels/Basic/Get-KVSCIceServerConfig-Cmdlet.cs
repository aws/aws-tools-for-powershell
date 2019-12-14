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
    /// Gets the Interactive Connectivity Establishment (ICE) server configuration information,
    /// including URIs, username, and password which can be used to configure the WebRTC connection.
    /// The ICE component uses this configuration information to setup the WebRTC connection,
    /// including authenticating with the Traversal Using Relays around NAT (TURN) relay server.
    /// 
    /// 
    ///  
    /// <para>
    /// TURN is a protocol that is used to improve the connectivity of peer-to-peer applications.
    /// By providing a cloud-based relay service, TURN ensures that a connection can be established
    /// even when one or more peers are incapable of a direct peer-to-peer connection. For
    /// more information, see <a href="https://tools.ietf.org/html/draft-uberti-rtcweb-turn-rest-00">A
    /// REST API For Access To TURN Services</a>.
    /// </para><para>
    ///  You can invoke this API to establish a fallback mechanism in case either of the peers
    /// is unable to establish a direct peer-to-peer connection over a signaling channel.
    /// You must specify either a signaling channel ARN or the client ID in order to invoke
    /// this API.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KVSCIceServerConfig")]
    [OutputType("Amazon.KinesisVideoSignalingChannels.Model.IceServer")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Signaling Channels GetIceServerConfig API operation.", Operation = new[] {"GetIceServerConfig"}, SelectReturnType = typeof(Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideoSignalingChannels.Model.IceServer or Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse",
        "This cmdlet returns a collection of Amazon.KinesisVideoSignalingChannels.Model.IceServer objects.",
        "The service call response (type Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKVSCIceServerConfigCmdlet : AmazonKinesisVideoSignalingChannelsClientCmdlet, IExecutor
    {
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the signaling channel to be used for the peer-to-peer connection between
        /// configured peers. </para>
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
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for the viewer. Must be unique within the signaling channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>Specifies the desired service. Currently, <code>TURN</code> is the only valid value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideoSignalingChannels.Service")]
        public Amazon.KinesisVideoSignalingChannels.Service Service { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>An optional user ID to be associated with the credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IceServerList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IceServerList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelARN' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse, GetKVSCIceServerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientId = this.ClientId;
            context.Service = this.Service;
            context.Username = this.Username;
            
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
            var request = new Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse CallAWSServiceOperation(IAmazonKinesisVideoSignalingChannels client, Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Signaling Channels", "GetIceServerConfig");
            try
            {
                #if DESKTOP
                return client.GetIceServerConfig(request);
                #elif CORECLR
                return client.GetIceServerConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientId { get; set; }
            public Amazon.KinesisVideoSignalingChannels.Service Service { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.KinesisVideoSignalingChannels.Model.GetIceServerConfigResponse, GetKVSCIceServerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IceServerList;
        }
        
    }
}
