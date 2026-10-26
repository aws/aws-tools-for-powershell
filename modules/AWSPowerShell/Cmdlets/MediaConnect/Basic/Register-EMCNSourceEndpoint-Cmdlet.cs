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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Registers a new source endpoint in MediaConnect.
    /// </summary>
    [Cmdlet("Register", "EMCNSourceEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.SourceEndpoint")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect RegisterSourceEndpoint API operation.", Operation = new[] {"RegisterSourceEndpoint"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.RegisterSourceEndpointResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.SourceEndpoint or Amazon.MediaConnect.Model.RegisterSourceEndpointResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.SourceEndpoint object.",
        "The service call response (type Amazon.MediaConnect.Model.RegisterSourceEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEMCNSourceEndpointCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description to help you identify the source endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on the destination that receives the content. The valid range is 3000 to
        /// 30000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on the destination that receives the content. The valid range is 3000 to
        /// 30000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on which the destination listens for the connection. The valid range is 3000
        /// to 30000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState
        /// <summary>
        /// <para>
        /// <para>Indicates whether forward error correction (FEC) is enabled for the source endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.ForwardErrorCorrectionState")]
        public Amazon.MediaConnect.ForwardErrorCorrectionState Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The minimum latency, in milliseconds, for the SRT connection. The valid range is 10
        /// to 10000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMilliseconds")]
        public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The minimum latency, in milliseconds, for the SRT connection. The valid range is 10
        /// to 10000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMilliseconds")]
        public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_Name
        /// <summary>
        /// <para>
        /// <para>The name of the source endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used by the source endpoint. Valid values include the following:</para><ul><li><para><c>RTP</c> – Real-time Transport Protocol.</para></li><li><para><c>RIST</c> – Reliable Internet Stream Transport.</para></li><li><para><c>SRT_CALLER</c> – Secure Reliable Transport (SRT) in caller mode.</para></li><li><para><c>SRT_LISTENER</c> – Secure Reliable Transport (SRT) in listener mode.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.SourceEndpointProtocol")]
        public Amazon.MediaConnect.SourceEndpointProtocol Configuration_Standard_Protocol { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond
        /// <summary>
        /// <para>
        /// <para>The amount of time, in milliseconds, that the source endpoint allows for recovering
        /// lost packets. The valid range is 10 to 10000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMilliseconds")]
        public System.Int64? Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services Region in which to register the source endpoint.
        /// Defaults to the current region if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter Configuration_RouterOutput_RouterOutputArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the router output that the source endpoint represents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_RouterOutput_RouterOutputArn { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret that holds the key or passphrase. The secret
        /// must be encrypted with a customer managed Amazon Web Services KMS key that is enabled
        /// and symmetric; it cannot use the Amazon Web Services managed key <c>aws/secretsmanager</c>.
        /// The secret must be in the same Amazon Web Services account and Region as the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Secrets Manager secret that holds the key or passphrase. The secret
        /// must be encrypted with a customer managed Amazon Web Services KMS key that is enabled
        /// and symmetric; it cannot use the Amazon Web Services managed key <c>aws/secretsmanager</c>.
        /// The secret must be in the same Amazon Web Services account and Region as the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to associate with the source endpoint. You can specify
        /// from 1 to 5 security groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupIds")]
        public System.String[] Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress
        /// <summary>
        /// <para>
        /// <para>The IP address that the source endpoint listens on for incoming connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule
        /// <summary>
        /// <para>
        /// <para>The rules that specify which CIDR blocks can connect to the source endpoint. You can
        /// specify up to 10 rules.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRules")]
        public Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfigurationAllowRule[] Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort
        /// <summary>
        /// <para>
        /// <para>The port that the source endpoint listens on for incoming connections. The valid range
        /// is 1024 to 65535.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_SourceNetworkingType
        /// <summary>
        /// <para>
        /// <para>The networking type of the source endpoint. Valid values include the following:</para><ul><li><para><c>PUBLIC</c> – The source endpoint is publicly accessible.</para></li><li><para><c>VPC</c> – The source endpoint is in a virtual private cloud (VPC).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.SourceEndpointNetworkingType")]
        public Amazon.MediaConnect.SourceEndpointNetworkingType Configuration_Standard_SourceNetworkingType { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId
        /// <summary>
        /// <para>
        /// <para>The stream ID that identifies the content for the SRT connection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to use for the source endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the source endpoint. Each tag is a key-value pair.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If this token matches a previous request, the service ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SourceEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.RegisterSourceEndpointResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.RegisterSourceEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SourceEndpoint";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RegionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EMCNSourceEndpoint (RegisterSourceEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.RegisterSourceEndpointResponse, RegisterEMCNSourceEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Configuration_RouterOutput_RouterOutputArn = this.Configuration_RouterOutput_RouterOutputArn;
            context.Configuration_Standard_Name = this.Configuration_Standard_Name;
            context.Configuration_Standard_Protocol = this.Configuration_Standard_Protocol;
            context.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond = this.Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond;
            context.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState = this.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn = this.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond = this.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress = this.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort = this.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId = this.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId;
            if (this.Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule != null)
            {
                context.Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule = new List<Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfigurationAllowRule>(this.Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule);
            }
            if (this.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                context.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId = new List<System.String>(this.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId);
            }
            context.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId = this.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId;
            context.Configuration_Standard_SourceNetworkingType = this.Configuration_Standard_SourceNetworkingType;
            context.Description = this.Description;
            context.RegionName = this.RegionName;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.MediaConnect.Model.RegisterSourceEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MediaConnect.Model.SourceEndpointConfiguration();
            Amazon.MediaConnect.Model.RouterOutputSourceEndpointConfiguration requestConfiguration_configuration_RouterOutput = null;
            
             // populate RouterOutput
            var requestConfiguration_configuration_RouterOutputIsNull = true;
            requestConfiguration_configuration_RouterOutput = new Amazon.MediaConnect.Model.RouterOutputSourceEndpointConfiguration();
            System.String requestConfiguration_configuration_RouterOutput_configuration_RouterOutput_RouterOutputArn = null;
            if (cmdletContext.Configuration_RouterOutput_RouterOutputArn != null)
            {
                requestConfiguration_configuration_RouterOutput_configuration_RouterOutput_RouterOutputArn = cmdletContext.Configuration_RouterOutput_RouterOutputArn;
            }
            if (requestConfiguration_configuration_RouterOutput_configuration_RouterOutput_RouterOutputArn != null)
            {
                requestConfiguration_configuration_RouterOutput.RouterOutputArn = requestConfiguration_configuration_RouterOutput_configuration_RouterOutput_RouterOutputArn;
                requestConfiguration_configuration_RouterOutputIsNull = false;
            }
             // determine if requestConfiguration_configuration_RouterOutput should be set to null
            if (requestConfiguration_configuration_RouterOutputIsNull)
            {
                requestConfiguration_configuration_RouterOutput = null;
            }
            if (requestConfiguration_configuration_RouterOutput != null)
            {
                request.Configuration.RouterOutput = requestConfiguration_configuration_RouterOutput;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardSourceEndpointConfiguration requestConfiguration_configuration_Standard = null;
            
             // populate Standard
            var requestConfiguration_configuration_StandardIsNull = true;
            requestConfiguration_configuration_Standard = new Amazon.MediaConnect.Model.StandardSourceEndpointConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_Name = null;
            if (cmdletContext.Configuration_Standard_Name != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_Name = cmdletContext.Configuration_Standard_Name;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_Name != null)
            {
                requestConfiguration_configuration_Standard.Name = requestConfiguration_configuration_Standard_configuration_Standard_Name;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.SourceEndpointProtocol requestConfiguration_configuration_Standard_configuration_Standard_Protocol = null;
            if (cmdletContext.Configuration_Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_Protocol = cmdletContext.Configuration_Standard_Protocol;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard.Protocol = requestConfiguration_configuration_Standard_configuration_Standard_Protocol;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.SourceEndpointNetworkingType requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingType = null;
            if (cmdletContext.Configuration_Standard_SourceNetworkingType != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingType = cmdletContext.Configuration_Standard_SourceNetworkingType;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingType != null)
            {
                requestConfiguration_configuration_Standard.SourceNetworkingType = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingType;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardSourceEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration = null;
            
             // populate SourceNetworkingConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration = new Amazon.MediaConnect.Model.StandardSourceEndpointNetworkingConfiguration();
            Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public = null;
            
             // populate Public
            var requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_PublicIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public = new Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfiguration();
            List<Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfigurationAllowRule> requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public_configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule = null;
            if (cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public_configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule = cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public_configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public.SourceAllowRules = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public_configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule;
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_PublicIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_PublicIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration.Public = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Public;
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.VpcSourceEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc = null;
            
             // populate Vpc
            var requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_VpcIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc = new Amazon.MediaConnect.Model.VpcSourceEndpointNetworkingConfiguration();
            List<System.String> requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId = null;
            if (cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId = cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc.SecurityGroupIds = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId;
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_VpcIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId = null;
            if (cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId = cmdletContext.Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc.SubnetId = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc_configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId;
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_VpcIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_VpcIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration.Vpc = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration_configuration_Standard_SourceNetworkingConfiguration_Vpc;
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration != null)
            {
                requestConfiguration_configuration_Standard.SourceNetworkingConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_SourceNetworkingConfiguration;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardSourceEndpointProtocolConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = null;
            
             // populate ProtocolConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = new Amazon.MediaConnect.Model.StandardSourceEndpointProtocolConfiguration();
            Amazon.MediaConnect.Model.RistStandardSourceEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = null;
            
             // populate Rist
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = new Amazon.MediaConnect.Model.RistStandardSourceEndpointConfiguration();
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.DestinationIngestPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = false;
            }
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.RecoveryLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond.Value;
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
            Amazon.MediaConnect.Model.RtpStandardSourceEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = null;
            
             // populate Rtp
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = new Amazon.MediaConnect.Model.RtpStandardSourceEndpointConfiguration();
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.DestinationIngestPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = false;
            }
            Amazon.MediaConnect.ForwardErrorCorrectionState requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.ForwardErrorCorrectionState = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState;
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
            Amazon.MediaConnect.Model.SrtCallerStandardSourceEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = null;
            
             // populate SrtCaller
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = new Amazon.MediaConnect.Model.SrtCallerStandardSourceEndpointConfiguration();
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.DestinationIngestPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.MinimumLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = false;
            }
            Amazon.MediaConnect.Model.EndpointEncryptionSecretConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase = null;
            
             // populate EncryptionPassphrase
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphraseIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase = new Amazon.MediaConnect.Model.EndpointEncryptionSecretConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphraseIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphraseIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.EncryptionPassphrase = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase;
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
            Amazon.MediaConnect.Model.SrtListenerStandardSourceEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = null;
            
             // populate SrtListener
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = new Amazon.MediaConnect.Model.SrtListenerStandardSourceEndpointConfiguration();
            System.Int64? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.MinimumLatencyMilliseconds = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.SourceAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.SourceListenerPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_StreamId = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_StreamId = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_StreamId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.StreamId = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_StreamId;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            Amazon.MediaConnect.Model.EndpointEncryptionSecretConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase = null;
            
             // populate EncryptionPassphrase
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphraseIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase = new Amazon.MediaConnect.Model.EndpointEncryptionSecretConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase.SecretArn = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphraseIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphraseIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.EncryptionPassphrase = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase;
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
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RegionName != null)
            {
                request.RegionName = cmdletContext.RegionName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.MediaConnect.Model.RegisterSourceEndpointResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.RegisterSourceEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "RegisterSourceEndpoint");
            try
            {
                return client.RegisterSourceEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Configuration_RouterOutput_RouterOutputArn { get; set; }
            public System.String Configuration_Standard_Name { get; set; }
            public Amazon.MediaConnect.SourceEndpointProtocol Configuration_Standard_Protocol { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort { get; set; }
            public System.Int64? Configuration_Standard_ProtocolConfiguration_Rist_RecoveryLatencyMillisecond { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort { get; set; }
            public Amazon.MediaConnect.ForwardErrorCorrectionState Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtCaller_DestinationIngestPort { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn { get; set; }
            public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn { get; set; }
            public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_SourceAddress { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtListener_SourceListenerPort { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId { get; set; }
            public List<Amazon.MediaConnect.Model.PublicSourceEndpointNetworkingConfigurationAllowRule> Configuration_Standard_SourceNetworkingConfiguration_Public_SourceAllowRule { get; set; }
            public List<System.String> Configuration_Standard_SourceNetworkingConfiguration_Vpc_SecurityGroupId { get; set; }
            public System.String Configuration_Standard_SourceNetworkingConfiguration_Vpc_SubnetId { get; set; }
            public Amazon.MediaConnect.SourceEndpointNetworkingType Configuration_Standard_SourceNetworkingType { get; set; }
            public System.String Description { get; set; }
            public System.String RegionName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaConnect.Model.RegisterSourceEndpointResponse, RegisterEMCNSourceEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SourceEndpoint;
        }
        
    }
}
