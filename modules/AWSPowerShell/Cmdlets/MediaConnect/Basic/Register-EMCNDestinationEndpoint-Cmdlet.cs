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
    /// Registers a new destination endpoint in MediaConnect.
    /// </summary>
    [Cmdlet("Register", "EMCNDestinationEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.DestinationEndpoint")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect RegisterDestinationEndpoint API operation.", Operation = new[] {"RegisterDestinationEndpoint"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.DestinationEndpoint or Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.DestinationEndpoint object.",
        "The service call response (type Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEMCNDestinationEndpointCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description to help you identify the destination endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The IP address on which the destination endpoint receives content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The IP address on which the destination endpoint receives content.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress
        /// <summary>
        /// <para>
        /// <para>The IP address on which the destination endpoint listens for incoming connections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule
        /// <summary>
        /// <para>
        /// <para>The rules that specify which CIDR blocks can connect to the destination endpoint.
        /// You can specify up to 10 rules.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRules")]
        public Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfigurationAllowRule[] Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on which the destination endpoint receives content. The valid range is 1024
        /// to 65531.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on which the destination endpoint receives content. The valid range is 1024
        /// to 65531.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort
        /// <summary>
        /// <para>
        /// <para>The port on which the destination endpoint listens for incoming connections. The valid
        /// range is 0 to 65531.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_DestinationNetworkingType
        /// <summary>
        /// <para>
        /// <para>The networking type of the destination endpoint. Valid values include the following:</para><ul><li><para><c>PUBLIC</c> – The destination endpoint is publicly accessible.</para></li><li><para><c>VPC</c> – The destination endpoint is in a virtual private cloud (VPC).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.DestinationEndpointNetworkingType")]
        public Amazon.MediaConnect.DestinationEndpointNetworkingType Configuration_Standard_DestinationNetworkingType { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState
        /// <summary>
        /// <para>
        /// <para>Indicates whether forward error correction (FEC) is enabled for the destination endpoint.</para>
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
        /// <para>The name of the destination endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_Name { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol used by the destination endpoint. Valid values include the following:</para><ul><li><para><c>RTP</c> – Real-time Transport Protocol.</para></li><li><para><c>RIST</c> – Reliable Internet Stream Transport.</para></li><li><para><c>SRT_CALLER</c> – Secure Reliable Transport (SRT) in caller mode.</para></li><li><para><c>SRT_LISTENER</c> – Secure Reliable Transport (SRT) in listener mode.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.DestinationEndpointProtocol")]
        public Amazon.MediaConnect.DestinationEndpointProtocol Configuration_Standard_Protocol { get; set; }
        #endregion
        
        #region Parameter RegionName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Web Services Region in which to register the destination endpoint.
        /// Defaults to the current region if not specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegionName { get; set; }
        #endregion
        
        #region Parameter Configuration_RouterInput_RouterInputArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the router input that the destination endpoint represents.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_RouterInput_RouterInputArn { get; set; }
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
        
        #region Parameter Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups to associate with the destination endpoint. You can
        /// specify from 1 to 5 security groups.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupIds")]
        public System.String[] Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort
        /// <summary>
        /// <para>
        /// <para>The port on which the source listens for the connection. The valid range is 3000 to
        /// 30000.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort { get; set; }
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
        
        #region Parameter Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to use for the destination endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the destination endpoint. Each tag is a key-value pair.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DestinationEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DestinationEndpoint";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EMCNDestinationEndpoint (RegisterDestinationEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse, RegisterEMCNDestinationEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Configuration_RouterInput_RouterInputArn = this.Configuration_RouterInput_RouterInputArn;
            if (this.Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule != null)
            {
                context.Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule = new List<Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfigurationAllowRule>(this.Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule);
            }
            if (this.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                context.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId = new List<System.String>(this.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId);
            }
            context.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId = this.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId;
            context.Configuration_Standard_DestinationNetworkingType = this.Configuration_Standard_DestinationNetworkingType;
            context.Configuration_Standard_Name = this.Configuration_Standard_Name;
            context.Configuration_Standard_Protocol = this.Configuration_Standard_Protocol;
            context.Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress = this.Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress;
            context.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress = this.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress;
            context.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState = this.Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond;
            context.Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort = this.Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress = this.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort = this.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn = this.Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond = this.Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond;
            context.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId = this.Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId;
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
            var request = new Amazon.MediaConnect.Model.RegisterDestinationEndpointRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MediaConnect.Model.DestinationEndpointConfiguration();
            Amazon.MediaConnect.Model.RouterInputDestinationEndpointConfiguration requestConfiguration_configuration_RouterInput = null;
            
             // populate RouterInput
            var requestConfiguration_configuration_RouterInputIsNull = true;
            requestConfiguration_configuration_RouterInput = new Amazon.MediaConnect.Model.RouterInputDestinationEndpointConfiguration();
            System.String requestConfiguration_configuration_RouterInput_configuration_RouterInput_RouterInputArn = null;
            if (cmdletContext.Configuration_RouterInput_RouterInputArn != null)
            {
                requestConfiguration_configuration_RouterInput_configuration_RouterInput_RouterInputArn = cmdletContext.Configuration_RouterInput_RouterInputArn;
            }
            if (requestConfiguration_configuration_RouterInput_configuration_RouterInput_RouterInputArn != null)
            {
                requestConfiguration_configuration_RouterInput.RouterInputArn = requestConfiguration_configuration_RouterInput_configuration_RouterInput_RouterInputArn;
                requestConfiguration_configuration_RouterInputIsNull = false;
            }
             // determine if requestConfiguration_configuration_RouterInput should be set to null
            if (requestConfiguration_configuration_RouterInputIsNull)
            {
                requestConfiguration_configuration_RouterInput = null;
            }
            if (requestConfiguration_configuration_RouterInput != null)
            {
                request.Configuration.RouterInput = requestConfiguration_configuration_RouterInput;
                requestConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardDestinationEndpointConfiguration requestConfiguration_configuration_Standard = null;
            
             // populate Standard
            var requestConfiguration_configuration_StandardIsNull = true;
            requestConfiguration_configuration_Standard = new Amazon.MediaConnect.Model.StandardDestinationEndpointConfiguration();
            Amazon.MediaConnect.DestinationEndpointNetworkingType requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingType = null;
            if (cmdletContext.Configuration_Standard_DestinationNetworkingType != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingType = cmdletContext.Configuration_Standard_DestinationNetworkingType;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingType != null)
            {
                requestConfiguration_configuration_Standard.DestinationNetworkingType = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingType;
                requestConfiguration_configuration_StandardIsNull = false;
            }
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
            Amazon.MediaConnect.DestinationEndpointProtocol requestConfiguration_configuration_Standard_configuration_Standard_Protocol = null;
            if (cmdletContext.Configuration_Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_Protocol = cmdletContext.Configuration_Standard_Protocol;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_Protocol != null)
            {
                requestConfiguration_configuration_Standard.Protocol = requestConfiguration_configuration_Standard_configuration_Standard_Protocol;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardDestinationEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration = null;
            
             // populate DestinationNetworkingConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration = new Amazon.MediaConnect.Model.StandardDestinationEndpointNetworkingConfiguration();
            Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public = null;
            
             // populate Public
            var requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_PublicIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public = new Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfiguration();
            List<Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfigurationAllowRule> requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public_configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule = null;
            if (cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public_configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule = cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public_configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public.DestinationAllowRules = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public_configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule;
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_PublicIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_PublicIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration.Public = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Public;
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfigurationIsNull = false;
            }
            Amazon.MediaConnect.Model.VpcDestinationEndpointNetworkingConfiguration requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc = null;
            
             // populate Vpc
            var requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_VpcIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc = new Amazon.MediaConnect.Model.VpcDestinationEndpointNetworkingConfiguration();
            List<System.String> requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId = null;
            if (cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId = cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc.SecurityGroupIds = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId;
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_VpcIsNull = false;
            }
            System.String requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId = null;
            if (cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId = cmdletContext.Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc.SubnetId = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc_configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId;
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_VpcIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_VpcIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration.Vpc = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration_configuration_Standard_DestinationNetworkingConfiguration_Vpc;
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration should be set to null
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfigurationIsNull)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration = null;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration != null)
            {
                requestConfiguration_configuration_Standard.DestinationNetworkingConfiguration = requestConfiguration_configuration_Standard_configuration_Standard_DestinationNetworkingConfiguration;
                requestConfiguration_configuration_StandardIsNull = false;
            }
            Amazon.MediaConnect.Model.StandardDestinationEndpointProtocolConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = null;
            
             // populate ProtocolConfiguration
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfigurationIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration = new Amazon.MediaConnect.Model.StandardDestinationEndpointProtocolConfiguration();
            Amazon.MediaConnect.Model.RistStandardDestinationEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = null;
            
             // populate Rist
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist = new Amazon.MediaConnect.Model.RistStandardDestinationEndpointConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rist_configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RistIsNull = false;
            }
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
            Amazon.MediaConnect.Model.RtpStandardDestinationEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = null;
            
             // populate Rtp
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp = new Amazon.MediaConnect.Model.RtpStandardDestinationEndpointConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress = cmdletContext.Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_Rtp_configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_RtpIsNull = false;
            }
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
            Amazon.MediaConnect.Model.SrtCallerStandardDestinationEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = null;
            
             // populate SrtCaller
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCallerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller = new Amazon.MediaConnect.Model.SrtCallerStandardDestinationEndpointConfiguration();
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
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller.SourceListenerPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtCaller_configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort.Value;
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
            Amazon.MediaConnect.Model.SrtListenerStandardDestinationEndpointConfiguration requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = null;
            
             // populate SrtListener
            var requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = true;
            requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener = new Amazon.MediaConnect.Model.SrtListenerStandardDestinationEndpointConfiguration();
            System.String requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.DestinationAddress = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
            System.Int32? requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort = null;
            if (cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort = cmdletContext.Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort.Value;
            }
            if (requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort != null)
            {
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener.DestinationIngestPort = requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListener_configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort.Value;
                requestConfiguration_configuration_Standard_configuration_Standard_ProtocolConfiguration_configuration_Standard_ProtocolConfiguration_SrtListenerIsNull = false;
            }
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
        
        private Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.RegisterDestinationEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "RegisterDestinationEndpoint");
            try
            {
                return client.RegisterDestinationEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_RouterInput_RouterInputArn { get; set; }
            public List<Amazon.MediaConnect.Model.PublicDestinationEndpointNetworkingConfigurationAllowRule> Configuration_Standard_DestinationNetworkingConfiguration_Public_DestinationAllowRule { get; set; }
            public List<System.String> Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SecurityGroupId { get; set; }
            public System.String Configuration_Standard_DestinationNetworkingConfiguration_Vpc_SubnetId { get; set; }
            public Amazon.MediaConnect.DestinationEndpointNetworkingType Configuration_Standard_DestinationNetworkingType { get; set; }
            public System.String Configuration_Standard_Name { get; set; }
            public Amazon.MediaConnect.DestinationEndpointProtocol Configuration_Standard_Protocol { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_Rist_DestinationAddress { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_Rist_DestinationIngestPort { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_Rtp_DestinationAddress { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_Rtp_DestinationIngestPort { get; set; }
            public Amazon.MediaConnect.ForwardErrorCorrectionState Configuration_Standard_ProtocolConfiguration_Rtp_ForwardErrorCorrectionState { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtCaller_EncryptionPassphrase_SecretArn { get; set; }
            public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtCaller_MinimumLatencyMillisecond { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtCaller_SourceListenerPort { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationAddress { get; set; }
            public System.Int32? Configuration_Standard_ProtocolConfiguration_SrtListener_DestinationIngestPort { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_EncryptionPassphrase_SecretArn { get; set; }
            public System.Int64? Configuration_Standard_ProtocolConfiguration_SrtListener_MinimumLatencyMillisecond { get; set; }
            public System.String Configuration_Standard_ProtocolConfiguration_SrtListener_StreamId { get; set; }
            public System.String Description { get; set; }
            public System.String RegionName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaConnect.Model.RegisterDestinationEndpointResponse, RegisterEMCNDestinationEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DestinationEndpoint;
        }
        
    }
}
