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
        
        #region Parameter EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouterIntegrationTransitDecryption_EncryptionKeyConfiguration_Automatic")]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration EncryptionKeyConfiguration_Automatic { get; set; }
        #endregion
        
        #region Parameter GatewayBridgeSource_BridgeArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the bridge feeding this flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatewayBridgeSource_BridgeArn { get; set; }
        #endregion
        
        #region Parameter Decryption
        /// <summary>
        /// <para>
        /// <para>The type of encryption that is used on the content ingested from the source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.UpdateEncryption Decryption { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the source. This description is not visible outside of the current
        /// Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter RouterIntegrationTransitDecryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>The type of encryption key to use for flow transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.FlowTransitEncryptionKeyType")]
        public Amazon.MediaConnect.FlowTransitEncryptionKeyType RouterIntegrationTransitDecryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter EntitlementArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the entitlement that allows you to subscribe to
        /// the flow. The entitlement is set by the content originator, and the ARN is generated
        /// as part of the originator's flow. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitlementArn { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the flow that you want to update. </para>
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
        /// <para>The port that the flow listens on for incoming content. If the protocol of the source
        /// is Zixi, the port must be set to 2088. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? IngestPort { get; set; }
        #endregion
        
        #region Parameter MaxBitrate
        /// <summary>
        /// <para>
        /// <para>The maximum bitrate for RIST, RTP, and RTP-FEC streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxBitrate { get; set; }
        #endregion
        
        #region Parameter MaxLatency
        /// <summary>
        /// <para>
        /// <para>The maximum latency in milliseconds. This parameter applies only to RIST-based and
        /// Zixi-based streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxLatency { get; set; }
        #endregion
        
        #region Parameter MaxSyncBuffer
        /// <summary>
        /// <para>
        /// <para>The size of the buffer (in milliseconds) to use to sync incoming source data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSyncBuffer { get; set; }
        #endregion
        
        #region Parameter MediaStreamSourceConfiguration
        /// <summary>
        /// <para>
        /// <para>The media stream that is associated with the source, and the parameters for that association.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaStreamSourceConfigurations")]
        public Amazon.MediaConnect.Model.MediaStreamSourceConfigurationRequest[] MediaStreamSourceConfiguration { get; set; }
        #endregion
        
        #region Parameter MinLatency
        /// <summary>
        /// <para>
        /// <para>The minimum latency in milliseconds for SRT-based streams. In streams that use the
        /// SRT protocol, this value that you set on your MediaConnect source or output represents
        /// the minimal potential latency of that connection. The latency of the stream is set
        /// to the highest number between the sender’s minimum latency and the receiver’s minimum
        /// latency. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinLatency { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol that the source uses to deliver the content to MediaConnect. </para><note><para>Elemental MediaConnect no longer supports the Fujitsu QoS protocol. This reference
        /// is maintained for legacy purposes only.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouterIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn")]
        public System.String SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter RouterIntegrationState
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable router integration for this flow source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.State")]
        public Amazon.MediaConnect.State RouterIntegrationState { get; set; }
        #endregion
        
        #region Parameter SecretsManager_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouterIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn")]
        public System.String SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter SenderControlPort
        /// <summary>
        /// <para>
        /// <para>The port that the flow uses to send outbound requests to initiate connection with
        /// the sender. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SenderControlPort { get; set; }
        #endregion
        
        #region Parameter SenderIpAddress
        /// <summary>
        /// <para>
        /// <para>The IP address that the flow communicates with to initiate connection with the sender.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SenderIpAddress { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the source that you want to update. </para>
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
        /// <para>The source IP or domain name for SRT-caller protocol. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceListenerAddress { get; set; }
        #endregion
        
        #region Parameter SourceListenerPort
        /// <summary>
        /// <para>
        /// <para>Source port for SRT-caller protocol. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SourceListenerPort { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para>The stream ID that you want to use for this transport. This parameter applies only
        /// to Zixi and SRT caller-based streams. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter VpcInterfaceAttachment_VpcInterfaceName
        /// <summary>
        /// <para>
        /// <para> The name of the VPC interface to use for this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayBridgeSource_VpcInterfaceAttachment_VpcInterfaceName")]
        public System.String VpcInterfaceAttachment_VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter VpcInterfaceName
        /// <summary>
        /// <para>
        /// <para>The name of the VPC interface that you want to send your output to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter WhitelistCidr
        /// <summary>
        /// <para>
        /// <para>The range of IP addresses that are allowed to contribute content to your source. Format
        /// the IP addresses as a Classless Inter-Domain Routing (CIDR) block; for example, 10.0.0.0/16.
        /// </para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowSource (UpdateFlowSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowSourceResponse, UpdateEMCNFlowSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.RouterIntegrationState = this.RouterIntegrationState;
            context.EncryptionKeyConfiguration_Automatic = this.EncryptionKeyConfiguration_Automatic;
            context.SecretsManager_RoleArn = this.SecretsManager_RoleArn;
            context.SecretsManager_SecretArn = this.SecretsManager_SecretArn;
            context.RouterIntegrationTransitDecryption_EncryptionKeyType = this.RouterIntegrationTransitDecryption_EncryptionKeyType;
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
            if (cmdletContext.RouterIntegrationState != null)
            {
                request.RouterIntegrationState = cmdletContext.RouterIntegrationState;
            }
            
             // populate RouterIntegrationTransitDecryption
            var requestRouterIntegrationTransitDecryptionIsNull = true;
            request.RouterIntegrationTransitDecryption = new Amazon.MediaConnect.Model.FlowTransitEncryption();
            Amazon.MediaConnect.FlowTransitEncryptionKeyType requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyType = null;
            if (cmdletContext.RouterIntegrationTransitDecryption_EncryptionKeyType != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyType = cmdletContext.RouterIntegrationTransitDecryption_EncryptionKeyType;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyType != null)
            {
                request.RouterIntegrationTransitDecryption.EncryptionKeyType = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyType;
                requestRouterIntegrationTransitDecryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfigurationIsNull = true;
            requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.EncryptionKeyConfiguration_Automatic != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic = cmdletContext.EncryptionKeyConfiguration_Automatic;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration.Automatic = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic;
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn = null;
            if (cmdletContext.SecretsManager_RoleArn != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn = cmdletContext.SecretsManager_RoleArn;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn;
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn = null;
            if (cmdletContext.SecretsManager_SecretArn != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn = cmdletContext.SecretsManager_SecretArn;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn;
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration.SecretsManager = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_routerIntegrationTransitDecryption_EncryptionKeyConfiguration_SecretsManager;
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration should be set to null
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfigurationIsNull)
            {
                requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration = null;
            }
            if (requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration != null)
            {
                request.RouterIntegrationTransitDecryption.EncryptionKeyConfiguration = requestRouterIntegrationTransitDecryption_routerIntegrationTransitDecryption_EncryptionKeyConfiguration;
                requestRouterIntegrationTransitDecryptionIsNull = false;
            }
             // determine if request.RouterIntegrationTransitDecryption should be set to null
            if (requestRouterIntegrationTransitDecryptionIsNull)
            {
                request.RouterIntegrationTransitDecryption = null;
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
            public Amazon.MediaConnect.State RouterIntegrationState { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String SecretsManager_RoleArn { get; set; }
            public System.String SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.FlowTransitEncryptionKeyType RouterIntegrationTransitDecryption_EncryptionKeyType { get; set; }
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
