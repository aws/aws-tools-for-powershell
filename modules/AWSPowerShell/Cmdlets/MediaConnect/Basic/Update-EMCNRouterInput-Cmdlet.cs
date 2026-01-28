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
    /// Updates the configuration of an existing router input in AWS Elemental MediaConnect.
    /// </summary>
    [Cmdlet("Update", "EMCNRouterInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.RouterInput")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateRouterInput API operation.", Operation = new[] {"UpdateRouterInput"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateRouterInputResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.RouterInput or Amazon.MediaConnect.Model.UpdateRouterInputResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.RouterInput object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateRouterInputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEMCNRouterInputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the router input that you want to update.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter SourceTransitDecryption_EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_Automatic")]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration SourceTransitDecryption_EncryptionKeyConfiguration_Automatic { get; set; }
        #endregion
        
        #region Parameter TransitEncryption_EncryptionKeyConfiguration_Automatic
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration TransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
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
        
        #region Parameter SourceTransitDecryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>The type of encryption key to use for flow transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyType")]
        [AWSConstantClassSource("Amazon.MediaConnect.FlowTransitEncryptionKeyType")]
        public Amazon.MediaConnect.FlowTransitEncryptionKeyType SourceTransitDecryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter TransitEncryption_EncryptionKeyType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of encryption key to use for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.RouterInputTransitEncryptionKeyType")]
        public Amazon.MediaConnect.RouterInputTransitEncryptionKeyType TransitEncryption_EncryptionKeyType { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_FlowArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the flow to connect to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_FlowArn")]
        public System.String MediaConnectFlow_FlowArn { get; set; }
        #endregion
        
        #region Parameter MediaConnectFlow_FlowOutputArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the flow output to connect to this router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_FlowOutputArn")]
        public System.String MediaConnectFlow_FlowOutputArn { get; set; }
        #endregion
        
        #region Parameter Rtp_ForwardErrorCorrection
        /// <summary>
        /// <para>
        /// <para>The state of forward error correction for the RTP protocol in the router input configuration.</para>
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
        /// <para>The updated maximum bitrate for the router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MaximumBitrate { get; set; }
        #endregion
        
        #region Parameter Merge_MergeRecoveryWindowMillisecond
        /// <summary>
        /// <para>
        /// <para>The time window in milliseconds for merging the two input sources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Merge_MergeRecoveryWindowMilliseconds")]
        public System.Int64? Merge_MergeRecoveryWindowMillisecond { get; set; }
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
        /// <para>The updated name for the router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Failover_NetworkInterfaceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the network interface to use for this failover router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Failover_NetworkInterfaceArn")]
        public System.String Failover_NetworkInterfaceArn { get; set; }
        #endregion
        
        #region Parameter Merge_NetworkInterfaceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the network interface to use for this merge router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Merge_NetworkInterfaceArn")]
        public System.String Merge_NetworkInterfaceArn { get; set; }
        #endregion
        
        #region Parameter Standard_NetworkInterfaceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network interface associated with the standard
        /// router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_NetworkInterfaceArn")]
        public System.String Standard_NetworkInterfaceArn { get; set; }
        #endregion
        
        #region Parameter Rist_Port
        /// <summary>
        /// <para>
        /// <para>The port number used for the RIST protocol in the router input configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rist_Port")]
        public System.Int32? Rist_Port { get; set; }
        #endregion
        
        #region Parameter Rtp_Port
        /// <summary>
        /// <para>
        /// <para>The port number used for the RTP protocol in the router input configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rtp_Port")]
        public System.Int32? Rtp_Port { get; set; }
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
        
        #region Parameter Failover_PrimarySourceIndex
        /// <summary>
        /// <para>
        /// <para>The index (0 or 1) that specifies which source in the protocol configurations list
        /// is currently active. Used to control which of the two failover sources is currently
        /// selected. This field is ignored when sourcePriorityMode is set to NO_PRIORITY</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Failover_PrimarySourceIndex")]
        public System.Int32? Failover_PrimarySourceIndex { get; set; }
        #endregion
        
        #region Parameter Standard_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used by the standard router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_Protocol")]
        [AWSConstantClassSource("Amazon.MediaConnect.RouterInputProtocol")]
        public Amazon.MediaConnect.RouterInputProtocol Standard_Protocol { get; set; }
        #endregion
        
        #region Parameter Failover_ProtocolConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of exactly two protocol configurations for the failover input sources. Both
        /// must use the same protocol type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Failover_ProtocolConfigurations")]
        public Amazon.MediaConnect.Model.FailoverRouterInputProtocolConfiguration[] Failover_ProtocolConfiguration { get; set; }
        #endregion
        
        #region Parameter Merge_ProtocolConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of exactly two protocol configurations for the merge input sources. Both must
        /// use the same protocol type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Merge_ProtocolConfigurations")]
        public Amazon.MediaConnect.Model.MergeRouterInputProtocolConfiguration[] Merge_ProtocolConfiguration { get; set; }
        #endregion
        
        #region Parameter Rist_RecoveryLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The recovery latency in milliseconds for the RIST protocol in the router input configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMilliseconds")]
        public System.Int64? Rist_RecoveryLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn")]
        public System.String SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn")]
        public System.String SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn { get; set; }
        #endregion
        
        #region Parameter SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn")]
        public System.String SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn { get; set; }
        #endregion
        
        #region Parameter TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role assumed by MediaConnect to access the Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
        #endregion
        
        #region Parameter RoutingScope
        /// <summary>
        /// <para>
        /// <para>Specifies whether the router input can be assigned to outputs in different Regions.
        /// REGIONAL (default) - can be assigned only to outputs in the same Region. GLOBAL -
        /// can be assigned to outputs in any Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.RoutingScope")]
        public Amazon.MediaConnect.RoutingScope RoutingScope { get; set; }
        #endregion
        
        #region Parameter SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn")]
        public System.String SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn")]
        public System.String SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn")]
        public System.String SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn { get; set; }
        #endregion
        
        #region Parameter TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret used for transit encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
        #endregion
        
        #region Parameter SrtCaller_SourceAddress
        /// <summary>
        /// <para>
        /// <para>The source IP address for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceAddress")]
        public System.String SrtCaller_SourceAddress { get; set; }
        #endregion
        
        #region Parameter SrtCaller_SourcePort
        /// <summary>
        /// <para>
        /// <para>The source port number for the SRT protocol in caller mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_SourcePort")]
        public System.Int32? SrtCaller_SourcePort { get; set; }
        #endregion
        
        #region Parameter Failover_SourcePriorityMode
        /// <summary>
        /// <para>
        /// <para>The mode for determining source priority in failover configurations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Failover_SourcePriorityMode")]
        [AWSConstantClassSource("Amazon.MediaConnect.FailoverInputSourcePriorityMode")]
        public Amazon.MediaConnect.FailoverInputSourcePriorityMode Failover_SourcePriorityMode { get; set; }
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
        
        #region Parameter Tier
        /// <summary>
        /// <para>
        /// <para>The updated tier level for the router input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.RouterInputTier")]
        public Amazon.MediaConnect.RouterInputTier Tier { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RouterInput'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateRouterInputResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateRouterInputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RouterInput";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNRouterInput (UpdateRouterInput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateRouterInputResponse, UpdateEMCNRouterInputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Failover_NetworkInterfaceArn = this.Failover_NetworkInterfaceArn;
            context.Failover_PrimarySourceIndex = this.Failover_PrimarySourceIndex;
            if (this.Failover_ProtocolConfiguration != null)
            {
                context.Failover_ProtocolConfiguration = new List<Amazon.MediaConnect.Model.FailoverRouterInputProtocolConfiguration>(this.Failover_ProtocolConfiguration);
            }
            context.Failover_SourcePriorityMode = this.Failover_SourcePriorityMode;
            context.MediaConnectFlow_FlowArn = this.MediaConnectFlow_FlowArn;
            context.MediaConnectFlow_FlowOutputArn = this.MediaConnectFlow_FlowOutputArn;
            context.SourceTransitDecryption_EncryptionKeyConfiguration_Automatic = this.SourceTransitDecryption_EncryptionKeyConfiguration_Automatic;
            context.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = this.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            context.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = this.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            context.SourceTransitDecryption_EncryptionKeyType = this.SourceTransitDecryption_EncryptionKeyType;
            context.Merge_MergeRecoveryWindowMillisecond = this.Merge_MergeRecoveryWindowMillisecond;
            context.Merge_NetworkInterfaceArn = this.Merge_NetworkInterfaceArn;
            if (this.Merge_ProtocolConfiguration != null)
            {
                context.Merge_ProtocolConfiguration = new List<Amazon.MediaConnect.Model.MergeRouterInputProtocolConfiguration>(this.Merge_ProtocolConfiguration);
            }
            context.Standard_NetworkInterfaceArn = this.Standard_NetworkInterfaceArn;
            context.Standard_Protocol = this.Standard_Protocol;
            context.Rist_Port = this.Rist_Port;
            context.Rist_RecoveryLatencyMillisecond = this.Rist_RecoveryLatencyMillisecond;
            context.Rtp_ForwardErrorCorrection = this.Rtp_ForwardErrorCorrection;
            context.Rtp_Port = this.Rtp_Port;
            context.SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn = this.SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn;
            context.SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn = this.SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn;
            context.SrtCaller_MinimumLatencyMillisecond = this.SrtCaller_MinimumLatencyMillisecond;
            context.SrtCaller_SourceAddress = this.SrtCaller_SourceAddress;
            context.SrtCaller_SourcePort = this.SrtCaller_SourcePort;
            context.SrtCaller_StreamId = this.SrtCaller_StreamId;
            context.SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn = this.SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn;
            context.SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn = this.SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn;
            context.SrtListener_MinimumLatencyMillisecond = this.SrtListener_MinimumLatencyMillisecond;
            context.SrtListener_Port = this.SrtListener_Port;
            context.MaintenanceConfiguration_Default = this.MaintenanceConfiguration_Default;
            context.PreferredDayTime_Day = this.PreferredDayTime_Day;
            context.PreferredDayTime_Time = this.PreferredDayTime_Time;
            context.MaximumBitrate = this.MaximumBitrate;
            context.Name = this.Name;
            context.RoutingScope = this.RoutingScope;
            context.Tier = this.Tier;
            context.TransitEncryption_EncryptionKeyConfiguration_Automatic = this.TransitEncryption_EncryptionKeyConfiguration_Automatic;
            context.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = this.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            context.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = this.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            context.TransitEncryption_EncryptionKeyType = this.TransitEncryption_EncryptionKeyType;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateRouterInputRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MediaConnect.Model.RouterInputConfiguration();
            Amazon.MediaConnect.Model.MediaConnectFlowRouterInputConfiguration requestConfiguration_configuration_MediaConnectFlow = null;
            
             // populate MediaConnectFlow
            var requestConfiguration_configuration_MediaConnectFlowIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow = new Amazon.MediaConnect.Model.MediaConnectFlowRouterInputConfiguration();
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
            System.String requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowOutputArn = null;
            if (cmdletContext.MediaConnectFlow_FlowOutputArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowOutputArn = cmdletContext.MediaConnectFlow_FlowOutputArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowOutputArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow.FlowOutputArn = requestConfiguration_configuration_MediaConnectFlow_mediaConnectFlow_FlowOutputArn;
                requestConfiguration_configuration_MediaConnectFlowIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryption requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption = null;
            
             // populate SourceTransitDecryption
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryptionIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption = new Amazon.MediaConnect.Model.FlowTransitEncryption();
            Amazon.MediaConnect.FlowTransitEncryptionKeyType requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_sourceTransitDecryption_EncryptionKeyType = null;
            if (cmdletContext.SourceTransitDecryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_sourceTransitDecryption_EncryptionKeyType = cmdletContext.SourceTransitDecryption_EncryptionKeyType;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_sourceTransitDecryption_EncryptionKeyType != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption.EncryptionKeyType = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_sourceTransitDecryption_EncryptionKeyType;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfigurationIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.FlowTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_sourceTransitDecryption_EncryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_sourceTransitDecryption_EncryptionKeyConfiguration_Automatic = cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_Automatic;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_sourceTransitDecryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration.Automatic = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_sourceTransitDecryption_EncryptionKeyConfiguration_Automatic;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = null;
            if (cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = null;
            if (cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = cmdletContext.SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_sourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration.SecretsManager = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfigurationIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration != null)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption.EncryptionKeyConfiguration = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption_configuration_MediaConnectFlow_SourceTransitDecryption_EncryptionKeyConfiguration;
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryptionIsNull = false;
            }
             // determine if requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption should be set to null
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryptionIsNull)
            {
                requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption = null;
            }
            if (requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption != null)
            {
                requestConfiguration_configuration_MediaConnectFlow.SourceTransitDecryption = requestConfiguration_configuration_MediaConnectFlow_configuration_MediaConnectFlow_SourceTransitDecryption;
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
            Amazon.MediaConnect.Model.MergeRouterInputConfiguration requestConfiguration_configuration_Merge = null;
            
             // populate Merge
            var requestConfiguration_configuration_MergeIsNull = true;
            requestConfiguration_configuration_Merge = new Amazon.MediaConnect.Model.MergeRouterInputConfiguration();
            System.Int64? requestConfiguration_configuration_Merge_merge_MergeRecoveryWindowMillisecond = null;
            if (cmdletContext.Merge_MergeRecoveryWindowMillisecond != null)
            {
                requestConfiguration_configuration_Merge_merge_MergeRecoveryWindowMillisecond = cmdletContext.Merge_MergeRecoveryWindowMillisecond.Value;
            }
            if (requestConfiguration_configuration_Merge_merge_MergeRecoveryWindowMillisecond != null)
            {
                requestConfiguration_configuration_Merge.MergeRecoveryWindowMilliseconds = requestConfiguration_configuration_Merge_merge_MergeRecoveryWindowMillisecond.Value;
                requestConfiguration_configuration_MergeIsNull = false;
            }
            System.String requestConfiguration_configuration_Merge_merge_NetworkInterfaceArn = null;
            if (cmdletContext.Merge_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Merge_merge_NetworkInterfaceArn = cmdletContext.Merge_NetworkInterfaceArn;
            }
            if (requestConfiguration_configuration_Merge_merge_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Merge.NetworkInterfaceArn = requestConfiguration_configuration_Merge_merge_NetworkInterfaceArn;
                requestConfiguration_configuration_MergeIsNull = false;
            }
            List<Amazon.MediaConnect.Model.MergeRouterInputProtocolConfiguration> requestConfiguration_configuration_Merge_merge_ProtocolConfiguration = null;
            if (cmdletContext.Merge_ProtocolConfiguration != null)
            {
                requestConfiguration_configuration_Merge_merge_ProtocolConfiguration = cmdletContext.Merge_ProtocolConfiguration;
            }
            if (requestConfiguration_configuration_Merge_merge_ProtocolConfiguration != null)
            {
                requestConfiguration_configuration_Merge.ProtocolConfigurations = requestConfiguration_configuration_Merge_merge_ProtocolConfiguration;
                requestConfiguration_configuration_MergeIsNull = false;
            }
             // determine if requestConfiguration_configuration_Merge should be set to null
            if (requestConfiguration_configuration_MergeIsNull)
            {
                requestConfiguration_configuration_Merge = null;
            }
            if (requestConfiguration_configuration_Merge != null)
            {
                request.Configuration.Merge = requestConfiguration_configuration_Merge;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardRouterInputConfiguration requestConfiguration_configuration_Standard = null;
            
             // populate Standard
            var requestConfiguration_configuration_StandardIsNull = true;
            requestConfiguration_configuration_Standard = new Amazon.MediaConnect.Model.StandardRouterInputConfiguration();
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
            Amazon.MediaConnect.RouterInputProtocol requestConfiguration_configuration_Standard_standard_Protocol = null;
            if (cmdletContext.Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard_standard_Protocol = cmdletContext.Standard_Protocol;
            }
            if (requestConfiguration_configuration_Standard_standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard.Protocol = requestConfiguration_configuration_Standard_standard_Protocol;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.RouterInputProtocolConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = null;
            
             // populate ProtocolConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = new Amazon.MediaConnect.Model.RouterInputProtocolConfiguration();
            Amazon.MediaConnect.Model.RistRouterInputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = null;
            
             // populate Rist
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = new Amazon.MediaConnect.Model.RistRouterInputConfiguration();
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_Port = null;
            if (cmdletContext.Rist_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_Port = cmdletContext.Rist_Port.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.Port = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_Port.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = false;
            }
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_RecoveryLatencyMillisecond = null;
            if (cmdletContext.Rist_RecoveryLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_RecoveryLatencyMillisecond = cmdletContext.Rist_RecoveryLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_RecoveryLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.RecoveryLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_rist_RecoveryLatencyMillisecond.Value;
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
            Amazon.MediaConnect.Model.RtpRouterInputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = null;
            
             // populate Rtp
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = new Amazon.MediaConnect.Model.RtpRouterInputConfiguration();
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
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_Port = null;
            if (cmdletContext.Rtp_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_Port = cmdletContext.Rtp_Port.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_Port != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.Port = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_rtp_Port.Value;
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
            Amazon.MediaConnect.Model.SrtListenerRouterInputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = null;
            
             // populate SrtListener
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = new Amazon.MediaConnect.Model.SrtListenerRouterInputConfiguration();
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
            Amazon.MediaConnect.Model.SrtDecryptionConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration = null;
            
             // populate DecryptionConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration = new Amazon.MediaConnect.Model.SrtDecryptionConfiguration();
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey = null;
            
             // populate EncryptionKey
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKeyIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_RoleArn = null;
            if (cmdletContext.SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_RoleArn = cmdletContext.SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey.RoleArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_RoleArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKeyIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_SecretArn = null;
            if (cmdletContext.SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_SecretArn = cmdletContext.SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey_srtListener_DecryptionConfiguration_EncryptionKey_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKeyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKeyIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration.EncryptionKey = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration_EncryptionKey;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.DecryptionConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DecryptionConfiguration;
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
            Amazon.MediaConnect.Model.SrtCallerRouterInputConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = null;
            
             // populate SrtCaller
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = new Amazon.MediaConnect.Model.SrtCallerRouterInputConfiguration();
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
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourceAddress = null;
            if (cmdletContext.SrtCaller_SourceAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourceAddress = cmdletContext.SrtCaller_SourceAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourceAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.SourceAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourceAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourcePort = null;
            if (cmdletContext.SrtCaller_SourcePort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourcePort = cmdletContext.SrtCaller_SourcePort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourcePort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.SourcePort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_srtCaller_SourcePort.Value;
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
            Amazon.MediaConnect.Model.SrtDecryptionConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration = null;
            
             // populate DecryptionConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration = new Amazon.MediaConnect.Model.SrtDecryptionConfiguration();
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey = null;
            
             // populate EncryptionKey
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKeyIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_RoleArn = null;
            if (cmdletContext.SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_RoleArn = cmdletContext.SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_RoleArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey.RoleArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_RoleArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKeyIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_SecretArn = null;
            if (cmdletContext.SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_SecretArn = cmdletContext.SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey_srtCaller_DecryptionConfiguration_EncryptionKey_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKeyIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKeyIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration.EncryptionKey = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration_EncryptionKey;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.DecryptionConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DecryptionConfiguration;
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
            Amazon.MediaConnect.Model.FailoverRouterInputConfiguration requestConfiguration_configuration_Failover = null;
            
             // populate Failover
            var requestConfiguration_configuration_FailoverIsNull = true;
            requestConfiguration_configuration_Failover = new Amazon.MediaConnect.Model.FailoverRouterInputConfiguration();
            System.String requestConfiguration_configuration_Failover_failover_NetworkInterfaceArn = null;
            if (cmdletContext.Failover_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Failover_failover_NetworkInterfaceArn = cmdletContext.Failover_NetworkInterfaceArn;
            }
            if (requestConfiguration_configuration_Failover_failover_NetworkInterfaceArn != null)
            {
                requestConfiguration_configuration_Failover.NetworkInterfaceArn = requestConfiguration_configuration_Failover_failover_NetworkInterfaceArn;
                requestConfiguration_configuration_FailoverIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Failover_failover_PrimarySourceIndex = null;
            if (cmdletContext.Failover_PrimarySourceIndex != null)
            {
                requestConfiguration_configuration_Failover_failover_PrimarySourceIndex = cmdletContext.Failover_PrimarySourceIndex.Value;
            }
            if (requestConfiguration_configuration_Failover_failover_PrimarySourceIndex != null)
            {
                requestConfiguration_configuration_Failover.PrimarySourceIndex = requestConfiguration_configuration_Failover_failover_PrimarySourceIndex.Value;
                requestConfiguration_configuration_FailoverIsNull = false;
            }
            List<Amazon.MediaConnect.Model.FailoverRouterInputProtocolConfiguration> requestConfiguration_configuration_Failover_failover_ProtocolConfiguration = null;
            if (cmdletContext.Failover_ProtocolConfiguration != null)
            {
                requestConfiguration_configuration_Failover_failover_ProtocolConfiguration = cmdletContext.Failover_ProtocolConfiguration;
            }
            if (requestConfiguration_configuration_Failover_failover_ProtocolConfiguration != null)
            {
                requestConfiguration_configuration_Failover.ProtocolConfigurations = requestConfiguration_configuration_Failover_failover_ProtocolConfiguration;
                requestConfiguration_configuration_FailoverIsNull = false;
            }
            Amazon.MediaConnect.FailoverInputSourcePriorityMode requestConfiguration_configuration_Failover_failover_SourcePriorityMode = null;
            if (cmdletContext.Failover_SourcePriorityMode != null)
            {
                requestConfiguration_configuration_Failover_failover_SourcePriorityMode = cmdletContext.Failover_SourcePriorityMode;
            }
            if (requestConfiguration_configuration_Failover_failover_SourcePriorityMode != null)
            {
                requestConfiguration_configuration_Failover.SourcePriorityMode = requestConfiguration_configuration_Failover_failover_SourcePriorityMode;
                requestConfiguration_configuration_FailoverIsNull = false;
            }
             // determine if requestConfiguration_configuration_Failover should be set to null
            if (requestConfiguration_configuration_FailoverIsNull)
            {
                requestConfiguration_configuration_Failover = null;
            }
            if (requestConfiguration_configuration_Failover != null)
            {
                request.Configuration.Failover = requestConfiguration_configuration_Failover;
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
            if (cmdletContext.RoutingScope != null)
            {
                request.RoutingScope = cmdletContext.RoutingScope;
            }
            if (cmdletContext.Tier != null)
            {
                request.Tier = cmdletContext.Tier;
            }
            
             // populate TransitEncryption
            var requestTransitEncryptionIsNull = true;
            request.TransitEncryption = new Amazon.MediaConnect.Model.RouterInputTransitEncryption();
            Amazon.MediaConnect.RouterInputTransitEncryptionKeyType requestTransitEncryption_transitEncryption_EncryptionKeyType = null;
            if (cmdletContext.TransitEncryption_EncryptionKeyType != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyType = cmdletContext.TransitEncryption_EncryptionKeyType;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyType != null)
            {
                request.TransitEncryption.EncryptionKeyType = requestTransitEncryption_transitEncryption_EncryptionKeyType;
                requestTransitEncryptionIsNull = false;
            }
            Amazon.MediaConnect.Model.RouterInputTransitEncryptionKeyConfiguration requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration = null;
            
             // populate EncryptionKeyConfiguration
            var requestTransitEncryption_transitEncryption_EncryptionKeyConfigurationIsNull = true;
            requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration = new Amazon.MediaConnect.Model.RouterInputTransitEncryptionKeyConfiguration();
            Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_Automatic = null;
            if (cmdletContext.TransitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_Automatic = cmdletContext.TransitEncryption_EncryptionKeyConfiguration_Automatic;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_Automatic != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration.Automatic = requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_Automatic;
                requestTransitEncryption_transitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            
             // populate SecretsManager
            var requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = true;
            requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager = new Amazon.MediaConnect.Model.SecretsManagerEncryptionKeyConfiguration();
            System.String requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = null;
            if (cmdletContext.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn = cmdletContext.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager.RoleArn = requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn;
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
            System.String requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = null;
            if (cmdletContext.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn = cmdletContext.TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager.SecretArn = requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager_transitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn;
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull = false;
            }
             // determine if requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager should be set to null
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManagerIsNull)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager = null;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager != null)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration.SecretsManager = requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration_transitEncryption_EncryptionKeyConfiguration_SecretsManager;
                requestTransitEncryption_transitEncryption_EncryptionKeyConfigurationIsNull = false;
            }
             // determine if requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration should be set to null
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfigurationIsNull)
            {
                requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration = null;
            }
            if (requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration != null)
            {
                request.TransitEncryption.EncryptionKeyConfiguration = requestTransitEncryption_transitEncryption_EncryptionKeyConfiguration;
                requestTransitEncryptionIsNull = false;
            }
             // determine if request.TransitEncryption should be set to null
            if (requestTransitEncryptionIsNull)
            {
                request.TransitEncryption = null;
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
        
        private Amazon.MediaConnect.Model.UpdateRouterInputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateRouterInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateRouterInput");
            try
            {
                #if DESKTOP
                return client.UpdateRouterInput(request);
                #elif CORECLR
                return client.UpdateRouterInputAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String Failover_NetworkInterfaceArn { get; set; }
            public System.Int32? Failover_PrimarySourceIndex { get; set; }
            public List<Amazon.MediaConnect.Model.FailoverRouterInputProtocolConfiguration> Failover_ProtocolConfiguration { get; set; }
            public Amazon.MediaConnect.FailoverInputSourcePriorityMode Failover_SourcePriorityMode { get; set; }
            public System.String MediaConnectFlow_FlowArn { get; set; }
            public System.String MediaConnectFlow_FlowOutputArn { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration SourceTransitDecryption_EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
            public System.String SourceTransitDecryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.FlowTransitEncryptionKeyType SourceTransitDecryption_EncryptionKeyType { get; set; }
            public System.Int64? Merge_MergeRecoveryWindowMillisecond { get; set; }
            public System.String Merge_NetworkInterfaceArn { get; set; }
            public List<Amazon.MediaConnect.Model.MergeRouterInputProtocolConfiguration> Merge_ProtocolConfiguration { get; set; }
            public System.String Standard_NetworkInterfaceArn { get; set; }
            public Amazon.MediaConnect.RouterInputProtocol Standard_Protocol { get; set; }
            public System.Int32? Rist_Port { get; set; }
            public System.Int64? Rist_RecoveryLatencyMillisecond { get; set; }
            public Amazon.MediaConnect.ForwardErrorCorrectionState Rtp_ForwardErrorCorrection { get; set; }
            public System.Int32? Rtp_Port { get; set; }
            public System.String SrtCaller_DecryptionConfiguration_EncryptionKey_RoleArn { get; set; }
            public System.String SrtCaller_DecryptionConfiguration_EncryptionKey_SecretArn { get; set; }
            public System.Int64? SrtCaller_MinimumLatencyMillisecond { get; set; }
            public System.String SrtCaller_SourceAddress { get; set; }
            public System.Int32? SrtCaller_SourcePort { get; set; }
            public System.String SrtCaller_StreamId { get; set; }
            public System.String SrtListener_DecryptionConfiguration_EncryptionKey_RoleArn { get; set; }
            public System.String SrtListener_DecryptionConfiguration_EncryptionKey_SecretArn { get; set; }
            public System.Int64? SrtListener_MinimumLatencyMillisecond { get; set; }
            public System.Int32? SrtListener_Port { get; set; }
            public Amazon.MediaConnect.Model.DefaultMaintenanceConfiguration MaintenanceConfiguration_Default { get; set; }
            public Amazon.MediaConnect.Day PreferredDayTime_Day { get; set; }
            public System.String PreferredDayTime_Time { get; set; }
            public System.Int64? MaximumBitrate { get; set; }
            public System.String Name { get; set; }
            public Amazon.MediaConnect.RoutingScope RoutingScope { get; set; }
            public Amazon.MediaConnect.RouterInputTier Tier { get; set; }
            public Amazon.MediaConnect.Model.AutomaticEncryptionKeyConfiguration TransitEncryption_EncryptionKeyConfiguration_Automatic { get; set; }
            public System.String TransitEncryption_EncryptionKeyConfiguration_SecretsManager_RoleArn { get; set; }
            public System.String TransitEncryption_EncryptionKeyConfiguration_SecretsManager_SecretArn { get; set; }
            public Amazon.MediaConnect.RouterInputTransitEncryptionKeyType TransitEncryption_EncryptionKeyType { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateRouterInputResponse, UpdateEMCNRouterInputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RouterInput;
        }
        
    }
}
