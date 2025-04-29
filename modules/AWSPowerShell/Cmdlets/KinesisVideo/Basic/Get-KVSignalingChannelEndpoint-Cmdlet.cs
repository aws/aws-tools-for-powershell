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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Provides an endpoint for the specified signaling channel to send and receive messages.
    /// This API uses the <c>SingleMasterChannelEndpointConfiguration</c> input parameter,
    /// which consists of the <c>Protocols</c> and <c>Role</c> properties.
    /// 
    ///  
    /// <para><c>Protocols</c> is used to determine the communication mechanism. For example, if
    /// you specify <c>WSS</c> as the protocol, this API produces a secure websocket endpoint.
    /// If you specify <c>HTTPS</c> as the protocol, this API generates an HTTPS endpoint.
    /// 
    /// </para><para><c>Role</c> determines the messaging permissions. A <c>MASTER</c> role results in
    /// this API generating an endpoint that a client can use to communicate with any of the
    /// viewers on the channel. A <c>VIEWER</c> role results in this API generating an endpoint
    /// that a client can use to communicate only with a <c>MASTER</c>. 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KVSignalingChannelEndpoint")]
    [OutputType("Amazon.KinesisVideo.Model.ResourceEndpointListItem")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams GetSignalingChannelEndpoint API operation.", Operation = new[] {"GetSignalingChannelEndpoint"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideo.Model.ResourceEndpointListItem or Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse",
        "This cmdlet returns a collection of Amazon.KinesisVideo.Model.ResourceEndpointListItem objects.",
        "The service call response (type Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKVSignalingChannelEndpointCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the signalling channel for which you want to get
        /// an endpoint.</para>
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
        
        #region Parameter SingleMasterChannelEndpointConfiguration_Protocol
        /// <summary>
        /// <para>
        /// <para>This property is used to determine the nature of communication over this <c>SINGLE_MASTER</c>
        /// signaling channel. If <c>WSS</c> is specified, this API returns a websocket endpoint.
        /// If <c>HTTPS</c> is specified, this API returns an <c>HTTPS</c> endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SingleMasterChannelEndpointConfiguration_Protocols")]
        public System.String[] SingleMasterChannelEndpointConfiguration_Protocol { get; set; }
        #endregion
        
        #region Parameter SingleMasterChannelEndpointConfiguration_Role
        /// <summary>
        /// <para>
        /// <para>This property is used to determine messaging permissions in this <c>SINGLE_MASTER</c>
        /// signaling channel. If <c>MASTER</c> is specified, this API returns an endpoint that
        /// a client can use to receive offers from and send answers to any of the viewers on
        /// this signaling channel. If <c>VIEWER</c> is specified, this API returns an endpoint
        /// that a client can use only to send offers to another <c>MASTER</c> client on this
        /// signaling channel. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ChannelRole")]
        public Amazon.KinesisVideo.ChannelRole SingleMasterChannelEndpointConfiguration_Role { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceEndpointList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceEndpointList";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse, GetKVSignalingChannelEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SingleMasterChannelEndpointConfiguration_Protocol != null)
            {
                context.SingleMasterChannelEndpointConfiguration_Protocol = new List<System.String>(this.SingleMasterChannelEndpointConfiguration_Protocol);
            }
            context.SingleMasterChannelEndpointConfiguration_Role = this.SingleMasterChannelEndpointConfiguration_Role;
            
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
            var request = new Amazon.KinesisVideo.Model.GetSignalingChannelEndpointRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            
             // populate SingleMasterChannelEndpointConfiguration
            var requestSingleMasterChannelEndpointConfigurationIsNull = true;
            request.SingleMasterChannelEndpointConfiguration = new Amazon.KinesisVideo.Model.SingleMasterChannelEndpointConfiguration();
            List<System.String> requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Protocol = null;
            if (cmdletContext.SingleMasterChannelEndpointConfiguration_Protocol != null)
            {
                requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Protocol = cmdletContext.SingleMasterChannelEndpointConfiguration_Protocol;
            }
            if (requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Protocol != null)
            {
                request.SingleMasterChannelEndpointConfiguration.Protocols = requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Protocol;
                requestSingleMasterChannelEndpointConfigurationIsNull = false;
            }
            Amazon.KinesisVideo.ChannelRole requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Role = null;
            if (cmdletContext.SingleMasterChannelEndpointConfiguration_Role != null)
            {
                requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Role = cmdletContext.SingleMasterChannelEndpointConfiguration_Role;
            }
            if (requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Role != null)
            {
                request.SingleMasterChannelEndpointConfiguration.Role = requestSingleMasterChannelEndpointConfiguration_singleMasterChannelEndpointConfiguration_Role;
                requestSingleMasterChannelEndpointConfigurationIsNull = false;
            }
             // determine if request.SingleMasterChannelEndpointConfiguration should be set to null
            if (requestSingleMasterChannelEndpointConfigurationIsNull)
            {
                request.SingleMasterChannelEndpointConfiguration = null;
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
        
        private Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.GetSignalingChannelEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "GetSignalingChannelEndpoint");
            try
            {
                return client.GetSignalingChannelEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> SingleMasterChannelEndpointConfiguration_Protocol { get; set; }
            public Amazon.KinesisVideo.ChannelRole SingleMasterChannelEndpointConfiguration_Role { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.GetSignalingChannelEndpointResponse, GetKVSignalingChannelEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceEndpointList;
        }
        
    }
}
