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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates the source of a flow.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Source")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowSource API operation.", Operation = new[] {"UpdateFlowSource"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowSourceResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Source or Amazon.MediaConnect.Model.UpdateFlowSourceResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Source object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNFlowSourceCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GatewayBridgeSource_BridgeArn
        /// <summary>
        /// <para>
        /// The ARN of the bridge feeding this flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatewayBridgeSource_BridgeArn { get; set; }
        #endregion
        
        #region Parameter Decryption
        /// <summary>
        /// <para>
        /// The type of encryption used on the content
        /// ingested from this source. Allowable encryption types: static-key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.UpdateEncryption Decryption { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description for the source. This value is
        /// not used or seen outside of the current AWS Elemental MediaConnect account.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntitlementArn
        /// <summary>
        /// <para>
        /// The ARN of the entitlement that allows
        /// you to subscribe to this flow. The entitlement is set by the flow originator, and
        /// the ARN is generated as part of the originator's flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitlementArn { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that is associated with the source that
        /// you want to update.
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
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter IngestPort
        /// <summary>
        /// <para>
        /// The port that the flow will be listening on
        /// for incoming content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IngestPort { get; set; }
        #endregion
        
        #region Parameter MaxBitrate
        /// <summary>
        /// <para>
        /// The smoothing max bitrate (in bps) for RIST,
        /// RTP, and RTP-FEC streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxBitrate { get; set; }
        #endregion
        
        #region Parameter MaxLatency
        /// <summary>
        /// <para>
        /// The maximum latency in milliseconds. This parameter
        /// applies only to RIST-based, Zixi-based, and Fujitsu-based streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxLatency { get; set; }
        #endregion
        
        #region Parameter MaxSyncBuffer
        /// <summary>
        /// <para>
        /// The size of the buffer (in milliseconds)
        /// to use to sync incoming source data.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSyncBuffer { get; set; }
        #endregion
        
        #region Parameter MediaStreamSourceConfiguration
        /// <summary>
        /// <para>
        /// The media streams that
        /// are associated with the source, and the parameters for those associations.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaStreamSourceConfigurations")]
        public Amazon.MediaConnect.Model.MediaStreamSourceConfigurationRequest[] MediaStreamSourceConfiguration { get; set; }
        #endregion
        
        #region Parameter MinLatency
        /// <summary>
        /// <para>
        /// The minimum latency in milliseconds for SRT-based
        /// streams. In streams that use the SRT protocol, this value that you set on your MediaConnect
        /// source or output represents the minimal potential latency of that connection. The
        /// latency of the stream is set to the highest number between the sender’s minimum latency
        /// and the receiver’s minimum latency.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinLatency { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// The protocol that is used by the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter SenderControlPort
        /// <summary>
        /// <para>
        /// The port that the flow uses to send
        /// outbound requests to initiate connection with the sender.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SenderControlPort { get; set; }
        #endregion
        
        #region Parameter SenderIpAddress
        /// <summary>
        /// <para>
        /// The IP address that the flow communicates
        /// with to initiate connection with the sender.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SenderIpAddress { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// The ARN of the source that you want to update.
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
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter SourceListenerAddress
        /// <summary>
        /// <para>
        /// Source IP or domain name for SRT-caller
        /// protocol.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceListenerAddress { get; set; }
        #endregion
        
        #region Parameter SourceListenerPort
        /// <summary>
        /// <para>
        /// Source port for SRT-caller protocol.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourceListenerPort { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// The stream ID that you want to use for this transport.
        /// This parameter applies only to Zixi and SRT caller-based streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter VpcInterfaceAttachment_VpcInterfaceName
        /// <summary>
        /// <para>
        /// The name of the VPC interface to use
        /// for this resource.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayBridgeSource_VpcInterfaceAttachment_VpcInterfaceName")]
        public System.String VpcInterfaceAttachment_VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter VpcInterfaceName
        /// <summary>
        /// <para>
        /// The name of the VPC interface to use
        /// for this source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter WhitelistCidr
        /// <summary>
        /// <para>
        /// The range of IP addresses that should be
        /// allowed to contribute content to your source. These IP addresses should be in the
        /// form of a Classless Inter-Domain Routing (CIDR) block; for example, 10.0.0.0/16.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WhitelistCidr { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Source'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowSourceResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Source";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowSource (UpdateFlowSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowSourceResponse, UpdateEMCNFlowSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Decryption = this.Decryption;
            context.Description = this.Description;
            context.EntitlementArn = this.EntitlementArn;
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayBridgeSource_BridgeArn = this.GatewayBridgeSource_BridgeArn;
            context.VpcInterfaceAttachment_VpcInterfaceName = this.VpcInterfaceAttachment_VpcInterfaceName;
            context.IngestPort = this.IngestPort;
            context.MaxBitrate = this.MaxBitrate;
            context.MaxLatency = this.MaxLatency;
            context.MaxSyncBuffer = this.MaxSyncBuffer;
            if (this.MediaStreamSourceConfiguration != null)
            {
                context.MediaStreamSourceConfiguration = new List<Amazon.MediaConnect.Model.MediaStreamSourceConfigurationRequest>(this.MediaStreamSourceConfiguration);
            }
            context.MinLatency = this.MinLatency;
            context.Protocol = this.Protocol;
            context.SenderControlPort = this.SenderControlPort;
            context.SenderIpAddress = this.SenderIpAddress;
            context.SourceArn = this.SourceArn;
            #if MODULAR
            if (this.SourceArn == null && ParameterWasBound(nameof(this.SourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceListenerAddress = this.SourceListenerAddress;
            context.SourceListenerPort = this.SourceListenerPort;
            context.StreamId = this.StreamId;
            context.VpcInterfaceName = this.VpcInterfaceName;
            context.WhitelistCidr = this.WhitelistCidr;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowSourceRequest();
            
            if (cmdletContext.Decryption != null)
            {
                request.Decryption = cmdletContext.Decryption;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EntitlementArn != null)
            {
                request.EntitlementArn = cmdletContext.EntitlementArn;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            
             // populate GatewayBridgeSource
            var requestGatewayBridgeSourceIsNull = true;
            request.GatewayBridgeSource = new Amazon.MediaConnect.Model.UpdateGatewayBridgeSourceRequest();
            System.String requestGatewayBridgeSource_gatewayBridgeSource_BridgeArn = null;
            if (cmdletContext.GatewayBridgeSource_BridgeArn != null)
            {
                requestGatewayBridgeSource_gatewayBridgeSource_BridgeArn = cmdletContext.GatewayBridgeSource_BridgeArn;
            }
            if (requestGatewayBridgeSource_gatewayBridgeSource_BridgeArn != null)
            {
                request.GatewayBridgeSource.BridgeArn = requestGatewayBridgeSource_gatewayBridgeSource_BridgeArn;
                requestGatewayBridgeSourceIsNull = false;
            }
            Amazon.MediaConnect.Model.VpcInterfaceAttachment requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment = null;
            
             // populate VpcInterfaceAttachment
            var requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachmentIsNull = true;
            requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment = new Amazon.MediaConnect.Model.VpcInterfaceAttachment();
            System.String requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName = null;
            if (cmdletContext.VpcInterfaceAttachment_VpcInterfaceName != null)
            {
                requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName = cmdletContext.VpcInterfaceAttachment_VpcInterfaceName;
            }
            if (requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName != null)
            {
                requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment.VpcInterfaceName = requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName;
                requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachmentIsNull = false;
            }
             // determine if requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment should be set to null
            if (requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachmentIsNull)
            {
                requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment = null;
            }
            if (requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment != null)
            {
                request.GatewayBridgeSource.VpcInterfaceAttachment = requestGatewayBridgeSource_gatewayBridgeSource_VpcInterfaceAttachment;
                requestGatewayBridgeSourceIsNull = false;
            }
             // determine if request.GatewayBridgeSource should be set to null
            if (requestGatewayBridgeSourceIsNull)
            {
                request.GatewayBridgeSource = null;
            }
            if (cmdletContext.IngestPort != null)
            {
                request.IngestPort = cmdletContext.IngestPort.Value;
            }
            if (cmdletContext.MaxBitrate != null)
            {
                request.MaxBitrate = cmdletContext.MaxBitrate.Value;
            }
            if (cmdletContext.MaxLatency != null)
            {
                request.MaxLatency = cmdletContext.MaxLatency.Value;
            }
            if (cmdletContext.MaxSyncBuffer != null)
            {
                request.MaxSyncBuffer = cmdletContext.MaxSyncBuffer.Value;
            }
            if (cmdletContext.MediaStreamSourceConfiguration != null)
            {
                request.MediaStreamSourceConfigurations = cmdletContext.MediaStreamSourceConfiguration;
            }
            if (cmdletContext.MinLatency != null)
            {
                request.MinLatency = cmdletContext.MinLatency.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SenderControlPort != null)
            {
                request.SenderControlPort = cmdletContext.SenderControlPort.Value;
            }
            if (cmdletContext.SenderIpAddress != null)
            {
                request.SenderIpAddress = cmdletContext.SenderIpAddress;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.SourceListenerAddress != null)
            {
                request.SourceListenerAddress = cmdletContext.SourceListenerAddress;
            }
            if (cmdletContext.SourceListenerPort != null)
            {
                request.SourceListenerPort = cmdletContext.SourceListenerPort.Value;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            if (cmdletContext.VpcInterfaceName != null)
            {
                request.VpcInterfaceName = cmdletContext.VpcInterfaceName;
            }
            if (cmdletContext.WhitelistCidr != null)
            {
                request.WhitelistCidr = cmdletContext.WhitelistCidr;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowSourceResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowSource");
            try
            {
                #if DESKTOP
                return client.UpdateFlowSource(request);
                #elif CORECLR
                return client.UpdateFlowSourceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaConnect.Model.UpdateEncryption Decryption { get; set; }
            public System.String Description { get; set; }
            public System.String EntitlementArn { get; set; }
            public System.String FlowArn { get; set; }
            public System.String GatewayBridgeSource_BridgeArn { get; set; }
            public System.String VpcInterfaceAttachment_VpcInterfaceName { get; set; }
            public System.Int32? IngestPort { get; set; }
            public System.Int32? MaxBitrate { get; set; }
            public System.Int32? MaxLatency { get; set; }
            public System.Int32? MaxSyncBuffer { get; set; }
            public List<Amazon.MediaConnect.Model.MediaStreamSourceConfigurationRequest> MediaStreamSourceConfiguration { get; set; }
            public System.Int32? MinLatency { get; set; }
            public Amazon.MediaConnect.Protocol Protocol { get; set; }
            public System.Int32? SenderControlPort { get; set; }
            public System.String SenderIpAddress { get; set; }
            public System.String SourceArn { get; set; }
            public System.String SourceListenerAddress { get; set; }
            public System.Int32? SourceListenerPort { get; set; }
            public System.String StreamId { get; set; }
            public System.String VpcInterfaceName { get; set; }
            public System.String WhitelistCidr { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowSourceResponse, UpdateEMCNFlowSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Source;
        }
        
    }
}
