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
    /// Updates an existing flow output.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Output")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowOutput API operation.", Operation = new[] {"UpdateFlowOutput"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowOutputResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Output or Amazon.MediaConnect.Model.UpdateFlowOutputResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Output object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowOutputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNFlowOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouterIntegrationTransitEncryption_EncryptionKeyConfiguration_Automatic")]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration EncryptionKeyConfiguration_Automatic { get; set; }
        #endregion
        
        #region Parameter CidrAllowList
        /// <summary>
        /// <para>
        /// <para> The range of IP addresses that should be allowed to initiate output requests to this
        /// flow. These IP addresses should be in the form of a Classless Inter-Domain Routing
        /// (CIDR) block; for example, 10.0.0.0/16.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CidrAllowList { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> A description of the output. This description appears only on the MediaConnect console
        /// and will not be seen by the end user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// <para> The IP address where you want to send the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter Encryption
        /// <summary>
        /// <para>
        /// <para> The type of key used for the encryption. If no <c>keyType</c> is provided, the service
        /// will use the default setting (static-key). Allowable encryption types: static-key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
        #endregion
        
        #region Parameter RouterIntegrationTransitEncryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>The type of encryption key to use for flow transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.FlowTransitEncryptionKeyType")]
        public Amazon.MediaConnect.FlowTransitEncryptionKeyType RouterIntegrationTransitEncryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the flow that is associated with the output that
        /// you want to update.</para>
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
        
        #region Parameter MaxLatency
        /// <summary>
        /// <para>
        /// <para> The maximum latency in milliseconds. This parameter applies only to RIST-based and
        /// Zixi-based streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxLatency { get; set; }
        #endregion
        
        #region Parameter MediaStreamOutputConfiguration
        /// <summary>
        /// <para>
        /// <para> The media streams that are associated with the output, and the parameters for those
        /// associations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MediaStreamOutputConfigurations")]
        public Amazon.MediaConnect.Model.MediaStreamOutputConfigurationRequest[] MediaStreamOutputConfiguration { get; set; }
        #endregion
        
        #region Parameter MinLatency
        /// <summary>
        /// <para>
        /// <para> The minimum latency in milliseconds for SRT-based streams. In streams that use the
        /// SRT protocol, this value that you set on your MediaConnect source or output represents
        /// the minimal potential latency of that connection. The latency of the stream is set
        /// to the highest number between the sender’s minimum latency and the receiver’s minimum
        /// latency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinLatency { get; set; }
        #endregion
        
        #region Parameter NdiProgramName
        /// <summary>
        /// <para>
        /// <para> A suffix for the names of the NDI sources that the flow creates. If a custom name
        /// isn't specified, MediaConnect uses the output name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NdiProgramName { get; set; }
        #endregion
        
        #region Parameter NdiSpeedHqQuality
        /// <summary>
        /// <para>
        /// <para>A quality setting for the NDI Speed HQ encoder. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NdiSpeedHqQuality { get; set; }
        #endregion
        
        #region Parameter OutputArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the output that you want to update.</para>
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
        public System.String OutputArn { get; set; }
        #endregion
        
        #region Parameter OutputStatus
        /// <summary>
        /// <para>
        /// <para> An indication of whether the output should transmit data or not. If you don't specify
        /// the <c>outputStatus</c> field in your request, MediaConnect leaves the value unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.OutputStatus")]
        public Amazon.MediaConnect.OutputStatus OutputStatus { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para> The port to use when content is distributed to this output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para> The protocol to use for the output.</para><note><para>Elemental MediaConnect no longer supports the Fujitsu QoS protocol. This reference
        /// is maintained for legacy purposes only.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter RemoteId
        /// <summary>
        /// <para>
        /// <para> The remote ID for the Zixi-pull stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteId { get; set; }
        #endregion
        
        #region Parameter SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouterIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn")]
        public System.String SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter RouterIntegrationState
        /// <summary>
        /// <para>
        /// <para>Indicates whether to enable or disable router integration for this flow output.</para>
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
        [Alias("RouterIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn")]
        public System.String SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter SenderControlPort
        /// <summary>
        /// <para>
        /// <para> The port that the flow uses to send outbound requests to initiate connection with
        /// the sender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SenderControlPort { get; set; }
        #endregion
        
        #region Parameter SenderIpAddress
        /// <summary>
        /// <para>
        /// <para> The IP address that the flow communicates with to initiate connection with the sender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SenderIpAddress { get; set; }
        #endregion
        
        #region Parameter SmoothingLatency
        /// <summary>
        /// <para>
        /// <para> The smoothing latency in milliseconds for RIST, RTP, and RTP-FEC streams.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SmoothingLatency { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// <para> The stream ID that you want to use for this transport. This parameter applies only
        /// to Zixi and SRT caller-based streams.</para>
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
        public System.String VpcInterfaceAttachment_VpcInterfaceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Output'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowOutputResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowOutputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Output";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OutputArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OutputArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OutputArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowOutput (UpdateFlowOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowOutputResponse, UpdateEMCNFlowOutputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OutputArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CidrAllowList != null)
            {
                context.CidrAllowList = new List<System.String>(this.CidrAllowList);
            }
            context.Description = this.Description;
            context.Destination = this.Destination;
            context.Encryption = this.Encryption;
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxLatency = this.MaxLatency;
            if (this.MediaStreamOutputConfiguration != null)
            {
                context.MediaStreamOutputConfiguration = new List<Amazon.MediaConnect.Model.MediaStreamOutputConfigurationRequest>(this.MediaStreamOutputConfiguration);
            }
            context.MinLatency = this.MinLatency;
            context.NdiProgramName = this.NdiProgramName;
            context.NdiSpeedHqQuality = this.NdiSpeedHqQuality;
            context.OutputArn = this.OutputArn;
            #if MODULAR
            if (this.OutputArn == null && ParameterWasBound(nameof(this.OutputArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputStatus = this.OutputStatus;
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.RemoteId = this.RemoteId;
            context.RouterIntegrationState = this.RouterIntegrationState;
            context.EncryptionKeyConfiguration_Automatic = this.EncryptionKeyConfiguration_Automatic;
            context.SecretsManager_RoleArn = this.SecretsManager_RoleArn;
            context.SecretsManager_SecretArn = this.SecretsManager_SecretArn;
            context.RouterIntegrationTransitEncryption_EncryptionKeyType = this.RouterIntegrationTransitEncryption_EncryptionKeyType;
            context.SenderControlPort = this.SenderControlPort;
            context.SenderIpAddress = this.SenderIpAddress;
            context.SmoothingLatency = this.SmoothingLatency;
            context.StreamId = this.StreamId;
            context.VpcInterfaceAttachment_VpcInterfaceName = this.VpcInterfaceAttachment_VpcInterfaceName;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowOutputRequest();
            
            if (cmdletContext.CidrAllowList != null)
            {
                request.CidrAllowList = cmdletContext.CidrAllowList;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.Encryption != null)
            {
                request.Encryption = cmdletContext.Encryption;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.MaxLatency != null)
            {
                request.MaxLatency = cmdletContext.MaxLatency.Value;
            }
            if (cmdletContext.MediaStreamOutputConfiguration != null)
            {
                request.MediaStreamOutputConfigurations = cmdletContext.MediaStreamOutputConfiguration;
            }
            if (cmdletContext.MinLatency != null)
            {
                request.MinLatency = cmdletContext.MinLatency.Value;
            }
            if (cmdletContext.NdiProgramName != null)
            {
                request.NdiProgramName = cmdletContext.NdiProgramName;
            }
            if (cmdletContext.NdiSpeedHqQuality != null)
            {
                request.NdiSpeedHqQuality = cmdletContext.NdiSpeedHqQuality.Value;
            }
            if (cmdletContext.OutputArn != null)
            {
                request.OutputArn = cmdletContext.OutputArn;
            }
            if (cmdletContext.OutputStatus != null)
            {
                request.OutputStatus = cmdletContext.OutputStatus;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.RemoteId != null)
            {
                request.RemoteId = cmdletContext.RemoteId;
            }
            if (cmdletContext.RouterIntegrationState != null)
            {
                request.RouterIntegrationState = cmdletContext.RouterIntegrationState;
            }
            
             // populate RouterIntegrationTransitEncryption
            var requestRouterIntegrationTransitEncryptionIsNull = true;
            request.RouterIntegrationTransitEncryption = new Amazon.MediaConnect.Model.FlowTransitEncryption();
            Amazon.MediaConnect.FlowTransitEncryptionKeyType requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyType = null;
            if (cmdletContext.RouterIntegrationTransitEncryption_EncryptionKeyType != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyType = cmdletContext.RouterIntegrationTransitEncryption_EncryptionKeyType;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyType != null)
            {
                request.RouterIntegrationTransitEncryption.EncryptionKeyType = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyType;
                requestRouterIntegrationTransitEncryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfigurationIsNull = true;
            requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.EncryptionKeyConfiguration_Automatic != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic = cmdletContext.EncryptionKeyConfiguration_Automatic;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration.Automatic = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_encryptionKeyConfiguration_Automatic;
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn = null;
            if (cmdletContext.SecretsManager_RoleArn != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn = cmdletContext.SecretsManager_RoleArn;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_RoleArn;
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn = null;
            if (cmdletContext.SecretsManager_SecretArn != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn = cmdletContext.SecretsManager_SecretArn;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_secretsManager_SecretArn;
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration.SecretsManager = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_routerIntegrationTransitEncryption_EncryptionKeyConfiguration_SecretsManager;
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration should be set to null
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfigurationIsNull)
            {
                requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration = null;
            }
            if (requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration != null)
            {
                request.RouterIntegrationTransitEncryption.EncryptionKeyConfiguration = requestRouterIntegrationTransitEncryption_routerIntegrationTransitEncryption_EncryptionKeyConfiguration;
                requestRouterIntegrationTransitEncryptionIsNull = false;
            }
             // determine if request.RouterIntegrationTransitEncryption should be set to null
            if (requestRouterIntegrationTransitEncryptionIsNull)
            {
                request.RouterIntegrationTransitEncryption = null;
            }
            if (cmdletContext.SenderControlPort != null)
            {
                request.SenderControlPort = cmdletContext.SenderControlPort.Value;
            }
            if (cmdletContext.SenderIpAddress != null)
            {
                request.SenderIpAddress = cmdletContext.SenderIpAddress;
            }
            if (cmdletContext.SmoothingLatency != null)
            {
                request.SmoothingLatency = cmdletContext.SmoothingLatency.Value;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            
             // populate VpcInterfaceAttachment
            var requestVpcInterfaceAttachmentIsNull = true;
            request.VpcInterfaceAttachment = new Amazon.MediaConnect.Model.VpcInterfaceAttachment();
            System.String requestVpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName = null;
            if (cmdletContext.VpcInterfaceAttachment_VpcInterfaceName != null)
            {
                requestVpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName = cmdletContext.VpcInterfaceAttachment_VpcInterfaceName;
            }
            if (requestVpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName != null)
            {
                request.VpcInterfaceAttachment.VpcInterfaceName = requestVpcInterfaceAttachment_vpcInterfaceAttachment_VpcInterfaceName;
                requestVpcInterfaceAttachmentIsNull = false;
            }
             // determine if request.VpcInterfaceAttachment should be set to null
            if (requestVpcInterfaceAttachmentIsNull)
            {
                request.VpcInterfaceAttachment = null;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowOutputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowOutput");
            try
            {
                #if DESKTOP
                return client.UpdateFlowOutput(request);
                #elif CORECLR
                return client.UpdateFlowOutputAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CidrAllowList { get; set; }
            public System.String Description { get; set; }
            public System.String Destination { get; set; }
            public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
            public System.String FlowArn { get; set; }
            public System.Int32? MaxLatency { get; set; }
            public List<Amazon.MediaConnect.Model.MediaStreamOutputConfigurationRequest> MediaStreamOutputConfiguration { get; set; }
            public System.Int32? MinLatency { get; set; }
            public System.String NdiProgramName { get; set; }
            public System.Int32? NdiSpeedHqQuality { get; set; }
            public System.String OutputArn { get; set; }
            public Amazon.MediaConnect.OutputStatus OutputStatus { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.MediaConnect.Protocol Protocol { get; set; }
            public System.String RemoteId { get; set; }
            public Amazon.MediaConnect.State RouterIntegrationState { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String SecretsManager_RoleArn { get; set; }
            public System.String SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.FlowTransitEncryptionKeyType RouterIntegrationTransitEncryption_EncryptionKeyType { get; set; }
            public System.Int32? SenderControlPort { get; set; }
            public System.String SenderIpAddress { get; set; }
            public System.Int32? SmoothingLatency { get; set; }
            public System.String StreamId { get; set; }
            public System.String VpcInterfaceAttachment_VpcInterfaceName { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowOutputResponse, UpdateEMCNFlowOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Output;
        }
        
    }
}
