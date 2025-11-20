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
    /// Creates a new router output in AWS Elemental MediaConnect.
    /// </summary>
    [Cmdlet("New", "EMCNRouterOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.RouterOutput")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect CreateRouterOutput API operation.", Operation = new[] {"CreateRouterOutput"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.CreateRouterOutputResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.RouterOutput or Amazon.MediaConnect.Model.CreateRouterOutputResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.RouterOutput object.",
        "The service call response (type Amazon.MediaConnect.Model.CreateRouterOutputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEMCNRouterOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic")]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic")]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
        #endregion
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where you want to create the router output. This must be a valid
        /// Availability Zone for the region specified by <c>regionName</c>, or the current region
        /// if no <c>regionName</c> is provided. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter PreferredDayTime_Day
        /// <summary>
        /// <para>
        /// <para>The preferred day for maintenance operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceConfiguration_PreferredDayTime_Day")]
        [AWSConstantClassSource("Amazon.MediaConnect.Day")]
        public Amazon.MediaConnect.Day PreferredDayTime_Day { get; set; }
        #endregion
        
        #region Parameter MaintenanceConfiguration_Default
        /// <summary>
        /// <para>
        /// <para>Default maintenance configuration settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.DefaultMaintenanceConfiguration MaintenanceConfiguration_Default { get; set; }
        #endregion
        
        #region Parameter Rist_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The destination IP address for the RIST protocol in the router output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress")]
        public System.String Rist_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter Rtp_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The destination IP address for the RTP protocol in the router output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress")]
        public System.String Rtp_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter SrtCaller_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The destination IP address for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationAddress")]
        public System.String SrtCaller_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter Rist_DestinationPort
        /// <summary>
        /// <para>
        /// <para>The destination port number for the RIST protocol in the router output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rist_DestinationPort")]
        public System.Int32? Rist_DestinationPort { get; set; }
        #endregion
        
        #region Parameter Rtp_DestinationPort
        /// <summary>
        /// <para>
        /// <para>The destination port number for the RTP protocol in the router output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rtp_DestinationPort")]
        public System.Int32? Rtp_DestinationPort { get; set; }
        #endregion
        
        #region Parameter SrtCaller_DestinationPort
        /// <summary>
        /// <para>
        /// <para>The destination port number for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationPort")]
        public System.Int32? SrtCaller_DestinationPort { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>The type of encryption key to use for flow transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType")]
        [AWSConstantClassSource("Amazon.MediaConnect.FlowTransitEncryptionKeyType")]
        public Amazon.MediaConnect.FlowTransitEncryptionKeyType MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>The type of encryption key to use for MediaLive transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType")]
        [AWSConstantClassSource("Amazon.MediaConnect.MediaLiveTransitEncryptionKeyType")]
        public Amazon.MediaConnect.MediaLiveTransitEncryptionKeyType MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_FlowArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the flow to connect to this router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_FlowArn")]
        public System.String MediaConnectFlow_FlowArn { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_FlowSourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the flow source to connect to this router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_FlowSourceArn")]
        public System.String MediaConnectFlow_FlowSourceArn { get; set; }
        #endregion
        
        #region Parameter Rtp_ForwardErrorCorrection
        /// <summary>
        /// <para>
        /// <para>The state of forward error correction for the RTP protocol in the router output configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrection")]
        [AWSConstantClassSource("Amazon.MediaConnect.ForwardErrorCorrectionState")]
        public Amazon.MediaConnect.ForwardErrorCorrectionState Rtp_ForwardErrorCorrection { get; set; }
        #endregion
        
        #region Parameter MaximumBitrate
        /// <summary>
        /// <para>
        /// <para>The maximum bitrate for the router output.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_MediaLiveInputArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the MediaLive input to connect to this router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_MediaLiveInputArn")]
        public System.String MediaLiveInput_MediaLiveInputArn { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_MediaLivePipelineId
        /// <summary>
        /// <para>
        /// <para>The index of the MediaLive pipeline to connect to this router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_MediaLivePipelineId")]
        [AWSConstantClassSource("Amazon.MediaConnect.MediaLiveInputPipelineId")]
        public Amazon.MediaConnect.MediaLiveInputPipelineId MediaLiveInput_MediaLivePipelineId { get; set; }
        #endregion
        
        #region Parameter SrtCaller_MinimumLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The minimum latency in milliseconds for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMilliseconds")]
        public System.Int64? SrtCaller_MinimumLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter SrtListener_MinimumLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The minimum latency in milliseconds for the SRT protocol in listener mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMilliseconds")]
        public System.Int64? SrtListener_MinimumLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the router output.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Standard_NetworkInterfaceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network interface associated with the standard
        /// router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_NetworkInterfaceArn")]
        public System.String Standard_NetworkInterfaceArn { get; set; }
        #endregion
        
        #region Parameter SrtListener_Port
        /// <summary>
        /// <para>
        /// <para>The port number for the SRT protocol in listener mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_Port")]
        public System.Int32? SrtListener_Port { get; set; }
        #endregion
        
        #region Parameter Standard_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used by the standard router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_Protocol")]
        [AWSConstantClassSource("Amazon.MediaConnect.RouterOutputProtocol")]
        public Amazon.MediaConnect.RouterOutputProtocol Standard_Protocol { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The AWS Region for the router output. Defaults to the current region if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn")]
        public System.String MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn")]
        public System.String MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn")]
        public System.String SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn { get; set; }
        #endregion
        
        #region Parameter SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the AWS Secrets Manager
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn")]
        public System.String SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn { get; set; }
        #endregion
        
        #region Parameter RoutingScope
        /// <summary>
        /// <para>
        /// <para>Specifies whether the router output can take inputs that are in different Regions.
        /// REGIONAL (default) - can only take inputs from same Region. GLOBAL - can take inputs
        /// from any Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaConnect.RoutingScope")]
        public Amazon.MediaConnect.RoutingScope RoutingScope { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn")]
        public System.String MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn")]
        public System.String MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn")]
        public System.String SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn")]
        public System.String SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_StreamId
        /// <summary>
        /// <para>
        /// <para>The stream ID for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_StreamId")]
        public System.String SrtCaller_StreamId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to tag this router output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The tier level for the router output.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MediaConnect.RouterOutputTier")]
        public Amazon.MediaConnect.RouterOutputTier Tier { get; set; }
        #endregion
        
        #region Parameter PreferredDayTime_Time
        /// <summary>
        /// <para>
        /// <para>The preferred time for maintenance operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceConfiguration_PreferredDayTime_Time")]
        public System.String PreferredDayTime_Time { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouterOutput'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.CreateRouterOutputResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.CreateRouterOutputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouterOutput";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMCNRouterOutput (CreateRouterOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.CreateRouterOutputResponse, NewEMCNRouterOutputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.ClientToken = this.ClientToken;
            context.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = this.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
            context.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = this.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            context.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = this.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            context.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType = this.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType;
            context.MediaConnectFlow_FlowArn = this.MediaConnectFlow_FlowArn;
            context.MediaConnectFlow_FlowSourceArn = this.MediaConnectFlow_FlowSourceArn;
            context.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = this.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
            context.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = this.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            context.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = this.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            context.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType = this.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType;
            context.MediaLiveInput_MediaLiveInputArn = this.MediaLiveInput_MediaLiveInputArn;
            context.MediaLiveInput_MediaLivePipelineId = this.MediaLiveInput_MediaLivePipelineId;
            context.Standard_NetworkInterfaceArn = this.Standard_NetworkInterfaceArn;
            context.Standard_Protocol = this.Standard_Protocol;
            context.Rist_DestinationAddress = this.Rist_DestinationAddress;
            context.Rist_DestinationPort = this.Rist_DestinationPort;
            context.Rtp_DestinationAddress = this.Rtp_DestinationAddress;
            context.Rtp_DestinationPort = this.Rtp_DestinationPort;
            context.Rtp_ForwardErrorCorrection = this.Rtp_ForwardErrorCorrection;
            context.SrtCaller_DestinationAddress = this.SrtCaller_DestinationAddress;
            context.SrtCaller_DestinationPort = this.SrtCaller_DestinationPort;
            context.SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn = this.SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn;
            context.SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn = this.SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn;
            context.SrtCaller_MinimumLatencyMillisecond = this.SrtCaller_MinimumLatencyMillisecond;
            context.SrtCaller_StreamId = this.SrtCaller_StreamId;
            context.SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn = this.SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn;
            context.SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn = this.SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn;
            context.SrtListener_MinimumLatencyMillisecond = this.SrtListener_MinimumLatencyMillisecond;
            context.SrtListener_Port = this.SrtListener_Port;
            context.MaintenanceConfiguration_Default = this.MaintenanceConfiguration_Default;
            context.PreferredDayTime_Day = this.PreferredDayTime_Day;
            context.PreferredDayTime_Time = this.PreferredDayTime_Time;
            context.MaximumBitrate = this.MaximumBitrate;
            #if MODULAR
            if (this.MaximumBitrate == null && ParameterWasBound(nameof(this.MaximumBitrate)))
            {
                WriteWarning("You are passing $null as a value for parameter MaximumBitrate which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegionName = this.RegionName;
            context.RoutingScope = this.RoutingScope;
            #if MODULAR
            if (this.RoutingScope == null && ParameterWasBound(nameof(this.RoutingScope)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingScope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Tier = this.Tier;
            #if MODULAR
            if (this.Tier == null && ParameterWasBound(nameof(this.Tier)))
            {
                WriteWarning("You are passing $null as a value for parameter Tier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MediaConnect.Model.CreateRouterOutputRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MediaConnect.Model.RouterOutputConfiguration();
            Amazon.MediaConnect.Model.MediaConnectFlowRouterOutputConfiguration requestConfiguration_configuration_MediaConnectFlow = null;
            
             // populate MediaConnectFlow
            var requestConfiguration_configuration_MediaConnectFlowIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow = new Amazon.MediaConnect.Model.MediaConnectFlowRouterOutputConfiguration();
            System.String requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowArn = null;
            if (cmdletContext.MediaConnectFlow_FlowArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowArn = cmdletContext.MediaConnectFlow_FlowArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow.FlowArn = requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowArn;
                requestConfiguration_configuration_MediaConnectFlowIsNull = false;
            }
            System.String requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowSourceArn = null;
            if (cmdletContext.MediaConnectFlow_FlowSourceArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowSourceArn = cmdletContext.MediaConnectFlow_FlowSourceArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowSourceArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow.FlowSourceArn = requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowSourceArn;
                requestConfiguration_configuration_MediaConnectFlowIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryption requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption = null;
            
             // populate DestinationTransitEncryption
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryptionIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption = new Amazon.MediaConnect.Model.FlowTransitEncryption();
            Amazon.MediaConnect.FlowTransitEncryptionKeyType requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType = null;
            if (cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType = cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption.EncryptionKeyType = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration.Automatic = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = null;
            if (cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = null;
            if (cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = cmdletContext.MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration.SecretsManager = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption.EncryptionKeyConfiguration = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption_configuration_MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryptionIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryptionIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption != null)
            {
                requestConfiguration_configuration_MediaConnectFlow.DestinationTransitEncryption = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_DestinationTransitEncryption;
                requestConfiguration_configuration_MediaConnectFlowIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow should be set to null
            if (requestConfiguration_configuration_MediaConnectFlowIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow != null)
            {
                request.Configuration.MediaConnectFlow = requestConfiguration_configuration_MediaConnectFlow;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.MediaLiveInputRouterOutputConfiguration requestConfiguration_configuration_MediaLiveInput = null;
            
             // populate MediaLiveInput
            var requestConfiguration_configuration_MediaLiveInputIsNull = true;
            requestConfiguration_configuration_MediaLiveInput = new Amazon.MediaConnect.Model.MediaLiveInputRouterOutputConfiguration();
            System.String requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLiveInputArn = null;
            if (cmdletContext.MediaLiveInput_MediaLiveInputArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLiveInputArn = cmdletContext.MediaLiveInput_MediaLiveInputArn;
            }
            if (requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLiveInputArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput.MediaLiveInputArn = requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLiveInputArn;
                requestConfiguration_configuration_MediaLiveInputIsNull = false;
            }
            Amazon.MediaConnect.MediaLiveInputPipelineId requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLivePipelineId = null;
            if (cmdletContext.MediaLiveInput_MediaLivePipelineId != null)
            {
                requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLivePipelineId = cmdletContext.MediaLiveInput_MediaLivePipelineId;
            }
            if (requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLivePipelineId != null)
            {
                requestConfiguration_configuration_MediaLiveInput.MediaLivePipelineId = requestConfiguration_configuration_MediaLiveInput_mediaLiveInput_MediaLivePipelineId;
                requestConfiguration_configuration_MediaLiveInputIsNull = false;
            }
            Amazon.MediaConnect.Model.MediaLiveTransitEncryption requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption = null;
            
             // populate DestinationTransitEncryption
            var requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryptionIsNull = true;
            requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption = new Amazon.MediaConnect.Model.MediaLiveTransitEncryption();
            Amazon.MediaConnect.MediaLiveTransitEncryptionKeyType requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyType = null;
            if (cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyType = cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption.EncryptionKeyType = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyType;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.MediaLiveTransitEncryptionKeyConfiguration requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = true;
            requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.MediaLiveTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic = cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration.Automatic = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = null;
            if (cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = null;
            if (cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = cmdletContext.MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_mediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration.SecretsManager = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration should be set to null
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfigurationIsNull)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration = null;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration != null)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption.EncryptionKeyConfiguration = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption_configuration_MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration;
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryptionIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption should be set to null
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryptionIsNull)
            {
                requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption = null;
            }
            if (requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption != null)
            {
                requestConfiguration_configuration_MediaLiveInput.DestinationTransitEncryption = requestConfiguration_configuration_MediaLiveInput_configuration_MediaLiveInput_DestinationTransitEncryption;
                requestConfiguration_configuration_MediaLiveInputIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaLiveInput should be set to null
            if (requestConfiguration_configuration_MediaLiveInputIsNull)
            {
                requestConfiguration_configuration_MediaLiveInput = null;
            }
            if (requestConfiguration_configuration_MediaLiveInput != null)
            {
                request.Configuration.MediaLiveInput = requestConfiguration_configuration_MediaLiveInput;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardRouterOutputConfiguration requestConfiguration_configuration_Standard = null;
            
             // populate Standard
            var requestConfiguration_configuration_StandardIsNull = true;
            requestConfiguration_configuration_Standard = new Amazon.MediaConnect.Model.StandardRouterOutputConfiguration();
            System.String requestConfiguration_configuration_Standard_standard_NetworkInterfaceArn = null;
            if (cmdletContext.Standard_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Standard_standard_NetworkInterfaceArn = cmdletContext.Standard_NetworkInterfaceArn;
            }
            if (requestConfiguration_configuration_Standard_standard_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Standard.NetworkInterfaceArn = requestConfiguration_configuration_Standard_standard_NetworkInterfaceArn;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.RouterOutputProtocol requestConfiguration_configuration_Standard_standard_Protocol = null;
            if (cmdletContext.Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard_standard_Protocol = cmdletContext.Standard_Protocol;
            }
            if (requestConfiguration_configuration_Standard_standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard.Protocol = requestConfiguration_configuration_Standard_standard_Protocol;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.RouterOutputProtocolConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = null;
            
             // populate ProtocolConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = new Amazon.MediaConnect.Model.RouterOutputProtocolConfiguration();
            Amazon.MediaConnect.Model.RistRouterOutputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = null;
            
             // populate Rist
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = new Amazon.MediaConnect.Model.RistRouterOutputConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationAddress = null;
            if (cmdletContext.Rist_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationAddress = cmdletContext.Rist_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationPort = null;
            if (cmdletContext.Rist_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationPort = cmdletContext.Rist_DestinationPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.DestinationPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_DestinationPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration.Rist = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.RtpRouterOutputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = null;
            
             // populate Rtp
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = new Amazon.MediaConnect.Model.RtpRouterOutputConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationAddress = null;
            if (cmdletContext.Rtp_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationAddress = cmdletContext.Rtp_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationPort = null;
            if (cmdletContext.Rtp_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationPort = cmdletContext.Rtp_DestinationPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.DestinationPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_DestinationPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = false;
            }
            Amazon.MediaConnect.ForwardErrorCorrectionState requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_ForwardErrorCorrection = null;
            if (cmdletContext.Rtp_ForwardErrorCorrection != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_ForwardErrorCorrection = cmdletContext.Rtp_ForwardErrorCorrection;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_ForwardErrorCorrection != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.ForwardErrorCorrection = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_ForwardErrorCorrection;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration.Rtp = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SrtListenerRouterOutputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = null;
            
             // populate SrtListener
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = new Amazon.MediaConnect.Model.SrtListenerRouterOutputConfiguration();
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_MinimumLatencyMillisecond = null;
            if (cmdletContext.SrtListener_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_MinimumLatencyMillisecond = cmdletContext.SrtListener_MinimumLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.MinimumLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_MinimumLatencyMillisecond.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_Port = null;
            if (cmdletContext.SrtListener_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_Port = cmdletContext.SrtListener_Port.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.Port = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_srtListener_Port.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            Amazon.MediaConnect.Model.SrtEncryptionConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration = new Amazon.MediaConnect.Model.SrtEncryptionConfiguration();
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey = null;
            
             // populate EncryptionKey
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKeyIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_RoleArn = null;
            if (cmdletContext.SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_RoleArn = cmdletContext.SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey.RoleArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_RoleArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKeyIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_SecretArn = null;
            if (cmdletContext.SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_SecretArn = cmdletContext.SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey_srtListener_EncryptionConfiguration_EncryptionKey_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKeyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKeyIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration.EncryptionKey = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration_EncryptionKey;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.EncryptionConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionConfiguration;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration.SrtListener = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SrtCallerRouterOutputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = null;
            
             // populate SrtCaller
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = new Amazon.MediaConnect.Model.SrtCallerRouterOutputConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationAddress = null;
            if (cmdletContext.SrtCaller_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationAddress = cmdletContext.SrtCaller_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationPort = null;
            if (cmdletContext.SrtCaller_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationPort = cmdletContext.SrtCaller_DestinationPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.DestinationPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_DestinationPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_MinimumLatencyMillisecond = null;
            if (cmdletContext.SrtCaller_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_MinimumLatencyMillisecond = cmdletContext.SrtCaller_MinimumLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.MinimumLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_MinimumLatencyMillisecond.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_StreamId = null;
            if (cmdletContext.SrtCaller_StreamId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_StreamId = cmdletContext.SrtCaller_StreamId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_StreamId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.StreamId = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_StreamId;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            Amazon.MediaConnect.Model.SrtEncryptionConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration = new Amazon.MediaConnect.Model.SrtEncryptionConfiguration();
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey = null;
            
             // populate EncryptionKey
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKeyIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_RoleArn = null;
            if (cmdletContext.SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_RoleArn = cmdletContext.SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey.RoleArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_RoleArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKeyIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_SecretArn = null;
            if (cmdletContext.SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_SecretArn = cmdletContext.SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey_srtCaller_EncryptionConfiguration_EncryptionKey_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKeyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKeyIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration.EncryptionKey = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration_EncryptionKey;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.EncryptionConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionConfiguration;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration.SrtCaller = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration != null)
            {
                requestConfiguration_configuration_Standard.ProtocolConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration;
                requestConfiguration_configuration_StandardIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard should be set to null
            if (requestConfiguration_configuration_StandardIsNull)
            {
                requestConfiguration_configuration_Standard = null;
            }
            if (requestConfiguration_configuration_Standard != null)
            {
                request.Configuration.Standard = requestConfiguration_configuration_Standard;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            
             // populate MaintenanceConfiguration
            var requestMaintenanceConfigurationIsNull = true;
            request.MaintenanceConfiguration = new Amazon.MediaConnect.Model.MaintenanceConfiguration();
            Amazon.MediaConnect.Model.DefaultMaintenanceConfiguration requestMaintenanceConfiguration_maintenanceConfiguration_Default = null;
            if (cmdletContext.MaintenanceConfiguration_Default != null)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_Default = cmdletContext.MaintenanceConfiguration_Default;
            }
            if (requestMaintenanceConfiguration_maintenanceConfiguration_Default != null)
            {
                request.MaintenanceConfiguration.Default = requestMaintenanceConfiguration_maintenanceConfiguration_Default;
                requestMaintenanceConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.PreferredDayTimeMaintenanceConfiguration requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime = null;
            
             // populate PreferredDayTime
            var requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTimeIsNull = true;
            requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime = new Amazon.MediaConnect.Model.PreferredDayTimeMaintenanceConfiguration();
            Amazon.MediaConnect.Day requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Day = null;
            if (cmdletContext.PreferredDayTime_Day != null)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Day = cmdletContext.PreferredDayTime_Day;
            }
            if (requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Day != null)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime.Day = requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Day;
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTimeIsNull = false;
            }
            System.String requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Time = null;
            if (cmdletContext.PreferredDayTime_Time != null)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Time = cmdletContext.PreferredDayTime_Time;
            }
            if (requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Time != null)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime.Time = requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime_preferredDayTime_Time;
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTimeIsNull = false;
            }
             // determine if requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime should be set to null
            if (requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTimeIsNull)
            {
                requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime = null;
            }
            if (requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime != null)
            {
                request.MaintenanceConfiguration.PreferredDayTime = requestMaintenanceConfiguration_maintenanceConfiguration_PreferredDayTime;
                requestMaintenanceConfigurationIsNull = false;
            }
             // determine if request.MaintenanceConfiguration should be set to null
            if (requestMaintenanceConfigurationIsNull)
            {
                request.MaintenanceConfiguration = null;
            }
            if (cmdletContext.MaximumBitrate != null)
            {
                request.MaximumBitrate = cmdletContext.MaximumBitrate.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionName = cmdletContext.RegionName;
            }
            if (cmdletContext.RoutingScope != null)
            {
                request.RoutingScope = cmdletContext.RoutingScope;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
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
        
        private Amazon.MediaConnect.Model.CreateRouterOutputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.CreateRouterOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "CreateRouterOutput");
            try
            {
                #if DESKTOP
                return client.CreateRouterOutput(request);
                #elif CORECLR
                return client.CreateRouterOutputAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String ClientToken { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
            public System.String MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.FlowTransitEncryptionKeyType MediaConnectFlow_DestinationTransitEncryption_EncryptionKeyType { get; set; }
            public System.String MediaConnectFlow_FlowArn { get; set; }
            public System.String MediaConnectFlow_FlowSourceArn { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
            public System.String MediaLiveInput_DestinationTransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.MediaLiveTransitEncryptionKeyType MediaLiveInput_DestinationTransitEncryption_EncryptionKeyType { get; set; }
            public System.String MediaLiveInput_MediaLiveInputArn { get; set; }
            public Amazon.MediaConnect.MediaLiveInputPipelineId MediaLiveInput_MediaLivePipelineId { get; set; }
            public System.String Standard_NetworkInterfaceArn { get; set; }
            public Amazon.MediaConnect.RouterOutputProtocol Standard_Protocol { get; set; }
            public System.String Rist_DestinationAddress { get; set; }
            public System.Int32? Rist_DestinationPort { get; set; }
            public System.String Rtp_DestinationAddress { get; set; }
            public System.Int32? Rtp_DestinationPort { get; set; }
            public Amazon.MediaConnect.ForwardErrorCorrectionState Rtp_ForwardErrorCorrection { get; set; }
            public System.String SrtCaller_DestinationAddress { get; set; }
            public System.Int32? SrtCaller_DestinationPort { get; set; }
            public System.String SrtCaller_EncryptionConfiguration_EncryptionKey_RoleArn { get; set; }
            public System.String SrtCaller_EncryptionConfiguration_EncryptionKey_SecretArn { get; set; }
            public System.Int64? SrtCaller_MinimumLatencyMillisecond { get; set; }
            public System.String SrtCaller_StreamId { get; set; }
            public System.String SrtListener_EncryptionConfiguration_EncryptionKey_RoleArn { get; set; }
            public System.String SrtListener_EncryptionConfiguration_EncryptionKey_SecretArn { get; set; }
            public System.Int64? SrtListener_MinimumLatencyMillisecond { get; set; }
            public System.Int32? SrtListener_Port { get; set; }
            public Amazon.MediaConnect.Model.DefaultMaintenanceConfiguration MaintenanceConfiguration_Default { get; set; }
            public Amazon.MediaConnect.Day PreferredDayTime_Day { get; set; }
            public System.String PreferredDayTime_Time { get; set; }
            public System.Int64? MaximumBitrate { get; set; }
            public System.String Name { get; set; }
            public System.String RegionName { get; set; }
            public Amazon.MediaConnect.RoutingScope RoutingScope { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.MediaConnect.RouterOutputTier Tier { get; set; }
            public System.Func<Amazon.MediaConnect.Model.CreateRouterOutputResponse, NewEMCNRouterOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouterOutput;
        }
        
    }
}
