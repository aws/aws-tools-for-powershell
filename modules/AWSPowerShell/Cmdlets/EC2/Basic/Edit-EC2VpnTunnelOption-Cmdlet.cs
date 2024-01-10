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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the options for a VPN tunnel in an Amazon Web Services Site-to-Site VPN connection.
    /// You can modify multiple options for a tunnel in a single request, but you can only
    /// modify one tunnel at a time. For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPNTunnels.html">Site-to-Site
    /// VPN tunnel options for your Site-to-Site VPN connection</a> in the <i>Amazon Web Services
    /// Site-to-Site VPN User Guide</i>.
    /// </summary>
    [Cmdlet("Edit", "EC2VpnTunnelOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.VpnConnection")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyVpnTunnelOptions API operation.", Operation = new[] {"ModifyVpnTunnelOptions"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VpnConnection or Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse",
        "This cmdlet returns an Amazon.EC2.Model.VpnConnection object.",
        "The service call response (type Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2VpnTunnelOptionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TunnelOptions_DPDTimeoutAction
        /// <summary>
        /// <para>
        /// <para>The action to take after DPD timeout occurs. Specify <c>restart</c> to restart the
        /// IKE initiation. Specify <c>clear</c> to end the IKE session.</para><para>Valid Values: <c>clear</c> | <c>none</c> | <c>restart</c></para><para>Default: <c>clear</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_DPDTimeoutAction { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_DPDTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds after which a DPD timeout occurs. A DPD timeout of 40 seconds
        /// means that the VPN endpoint will consider the peer dead 30 seconds after the first
        /// failed keep-alive.</para><para>Constraints: A value greater than or equal to 30.</para><para>Default: <c>40</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_DPDTimeoutSeconds")]
        public System.Int32? TunnelOptions_DPDTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_EnableTunnelLifecycleControl
        /// <summary>
        /// <para>
        /// <para>Turn on or off tunnel endpoint lifecycle control feature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TunnelOptions_EnableTunnelLifecycleControl { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_IKEVersion
        /// <summary>
        /// <para>
        /// <para>The IKE versions that are permitted for the VPN tunnel.</para><para>Valid values: <c>ikev1</c> | <c>ikev2</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_IKEVersions")]
        public Amazon.EC2.Model.IKEVersionsRequestListValue[] TunnelOptions_IKEVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogOptions_LogEnabled
        /// <summary>
        /// <para>
        /// <para>Enable or disable VPN tunnel logging feature. Default value is <c>False</c>.</para><para>Valid values: <c>True</c> | <c>False</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_LogOptions_CloudWatchLogOptions_LogEnabled")]
        public System.Boolean? CloudWatchLogOptions_LogEnabled { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogOptions_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the CloudWatch log group to send logs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_LogOptions_CloudWatchLogOptions_LogGroupArn")]
        public System.String CloudWatchLogOptions_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogOptions_LogOutputFormat
        /// <summary>
        /// <para>
        /// <para>Set log format. Default format is <c>json</c>.</para><para>Valid values: <c>json</c> | <c>text</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_LogOptions_CloudWatchLogOptions_LogOutputFormat")]
        public System.String CloudWatchLogOptions_LogOutputFormat { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1DHGroupNumber
        /// <summary>
        /// <para>
        /// <para>One or more Diffie-Hellman group numbers that are permitted for the VPN tunnel for
        /// phase 1 IKE negotiations.</para><para>Valid values: <c>2</c> | <c>14</c> | <c>15</c> | <c>16</c> | <c>17</c> | <c>18</c>
        /// | <c>19</c> | <c>20</c> | <c>21</c> | <c>22</c> | <c>23</c> | <c>24</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase1DHGroupNumbers")]
        public Amazon.EC2.Model.Phase1DHGroupNumbersRequestListValue[] TunnelOptions_Phase1DHGroupNumber { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>One or more encryption algorithms that are permitted for the VPN tunnel for phase
        /// 1 IKE negotiations.</para><para>Valid values: <c>AES128</c> | <c>AES256</c> | <c>AES128-GCM-16</c> | <c>AES256-GCM-16</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase1EncryptionAlgorithms")]
        public Amazon.EC2.Model.Phase1EncryptionAlgorithmsRequestListValue[] TunnelOptions_Phase1EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1IntegrityAlgorithm
        /// <summary>
        /// <para>
        /// <para>One or more integrity algorithms that are permitted for the VPN tunnel for phase 1
        /// IKE negotiations.</para><para>Valid values: <c>SHA1</c> | <c>SHA2-256</c> | <c>SHA2-384</c> | <c>SHA2-512</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase1IntegrityAlgorithms")]
        public Amazon.EC2.Model.Phase1IntegrityAlgorithmsRequestListValue[] TunnelOptions_Phase1IntegrityAlgorithm { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1LifetimeSecond
        /// <summary>
        /// <para>
        /// <para>The lifetime for phase 1 of the IKE negotiation, in seconds.</para><para>Constraints: A value between 900 and 28,800.</para><para>Default: <c>28800</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase1LifetimeSeconds")]
        public System.Int32? TunnelOptions_Phase1LifetimeSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase2DHGroupNumber
        /// <summary>
        /// <para>
        /// <para>One or more Diffie-Hellman group numbers that are permitted for the VPN tunnel for
        /// phase 2 IKE negotiations.</para><para>Valid values: <c>2</c> | <c>5</c> | <c>14</c> | <c>15</c> | <c>16</c> | <c>17</c>
        /// | <c>18</c> | <c>19</c> | <c>20</c> | <c>21</c> | <c>22</c> | <c>23</c> | <c>24</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase2DHGroupNumbers")]
        public Amazon.EC2.Model.Phase2DHGroupNumbersRequestListValue[] TunnelOptions_Phase2DHGroupNumber { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase2EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>One or more encryption algorithms that are permitted for the VPN tunnel for phase
        /// 2 IKE negotiations.</para><para>Valid values: <c>AES128</c> | <c>AES256</c> | <c>AES128-GCM-16</c> | <c>AES256-GCM-16</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase2EncryptionAlgorithms")]
        public Amazon.EC2.Model.Phase2EncryptionAlgorithmsRequestListValue[] TunnelOptions_Phase2EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase2IntegrityAlgorithm
        /// <summary>
        /// <para>
        /// <para>One or more integrity algorithms that are permitted for the VPN tunnel for phase 2
        /// IKE negotiations.</para><para>Valid values: <c>SHA1</c> | <c>SHA2-256</c> | <c>SHA2-384</c> | <c>SHA2-512</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase2IntegrityAlgorithms")]
        public Amazon.EC2.Model.Phase2IntegrityAlgorithmsRequestListValue[] TunnelOptions_Phase2IntegrityAlgorithm { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase2LifetimeSecond
        /// <summary>
        /// <para>
        /// <para>The lifetime for phase 2 of the IKE negotiation, in seconds.</para><para>Constraints: A value between 900 and 3,600. The value must be less than the value
        /// for <c>Phase1LifetimeSeconds</c>.</para><para>Default: <c>3600</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase2LifetimeSeconds")]
        public System.Int32? TunnelOptions_Phase2LifetimeSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_PreSharedKey
        /// <summary>
        /// <para>
        /// <para>The pre-shared key (PSK) to establish initial authentication between the virtual private
        /// gateway and the customer gateway.</para><para>Constraints: Allowed characters are alphanumeric characters, periods (.), and underscores
        /// (_). Must be between 8 and 64 characters in length and cannot start with zero (0).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_PreSharedKey { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_RekeyFuzzPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of the rekey window (determined by <c>RekeyMarginTimeSeconds</c>) during
        /// which the rekey time is randomly selected.</para><para>Constraints: A value between 0 and 100.</para><para>Default: <c>100</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TunnelOptions_RekeyFuzzPercentage { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_RekeyMarginTimeSecond
        /// <summary>
        /// <para>
        /// <para>The margin time, in seconds, before the phase 2 lifetime expires, during which the
        /// Amazon Web Services side of the VPN connection performs an IKE rekey. The exact time
        /// of the rekey is randomly selected based on the value for <c>RekeyFuzzPercentage</c>.</para><para>Constraints: A value between 60 and half of <c>Phase2LifetimeSeconds</c>.</para><para>Default: <c>540</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_RekeyMarginTimeSeconds")]
        public System.Int32? TunnelOptions_RekeyMarginTimeSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_ReplayWindowSize
        /// <summary>
        /// <para>
        /// <para>The number of packets in an IKE replay window.</para><para>Constraints: A value between 64 and 2048.</para><para>Default: <c>1024</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TunnelOptions_ReplayWindowSize { get; set; }
        #endregion
        
        #region Parameter SkipTunnelReplacement
        /// <summary>
        /// <para>
        /// <para>Choose whether or not to trigger immediate tunnel replacement. This is only applicable
        /// when turning on or off <c>EnableTunnelLifecycleControl</c>.</para><para>Valid values: <c>True</c> | <c>False</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipTunnelReplacement { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_StartupAction
        /// <summary>
        /// <para>
        /// <para>The action to take when the establishing the tunnel for the VPN connection. By default,
        /// your customer gateway device must initiate the IKE negotiation and bring up the tunnel.
        /// Specify <c>start</c> for Amazon Web Services to initiate the IKE negotiation.</para><para>Valid Values: <c>add</c> | <c>start</c></para><para>Default: <c>add</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_StartupAction { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_TunnelInsideCidr
        /// <summary>
        /// <para>
        /// <para>The range of inside IPv4 addresses for the tunnel. Any specified CIDR blocks must
        /// be unique across all VPN connections that use the same virtual private gateway. </para><para>Constraints: A size /30 CIDR block from the <c>169.254.0.0/16</c> range. The following
        /// CIDR blocks are reserved and cannot be used:</para><ul><li><para><c>169.254.0.0/30</c></para></li><li><para><c>169.254.1.0/30</c></para></li><li><para><c>169.254.2.0/30</c></para></li><li><para><c>169.254.3.0/30</c></para></li><li><para><c>169.254.4.0/30</c></para></li><li><para><c>169.254.5.0/30</c></para></li><li><para><c>169.254.169.252/30</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_TunnelInsideCidr { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_TunnelInsideIpv6Cidr
        /// <summary>
        /// <para>
        /// <para>The range of inside IPv6 addresses for the tunnel. Any specified CIDR blocks must
        /// be unique across all VPN connections that use the same transit gateway.</para><para>Constraints: A size /126 CIDR block from the local <c>fd00::/8</c> range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_TunnelInsideIpv6Cidr { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Site-to-Site VPN connection.</para>
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
        public System.String VpnConnectionId { get; set; }
        #endregion
        
        #region Parameter VpnTunnelOutsideIpAddress
        /// <summary>
        /// <para>
        /// <para>The external IP address of the VPN tunnel.</para>
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
        public System.String VpnTunnelOutsideIpAddress { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VpnConnection'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VpnConnection";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VpnConnectionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VpnConnectionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VpnConnectionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VpnConnectionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2VpnTunnelOption (ModifyVpnTunnelOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse, EditEC2VpnTunnelOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VpnConnectionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SkipTunnelReplacement = this.SkipTunnelReplacement;
            context.TunnelOptions_DPDTimeoutAction = this.TunnelOptions_DPDTimeoutAction;
            context.TunnelOptions_DPDTimeoutSecond = this.TunnelOptions_DPDTimeoutSecond;
            context.TunnelOptions_EnableTunnelLifecycleControl = this.TunnelOptions_EnableTunnelLifecycleControl;
            if (this.TunnelOptions_IKEVersion != null)
            {
                context.TunnelOptions_IKEVersion = new List<Amazon.EC2.Model.IKEVersionsRequestListValue>(this.TunnelOptions_IKEVersion);
            }
            context.CloudWatchLogOptions_LogEnabled = this.CloudWatchLogOptions_LogEnabled;
            context.CloudWatchLogOptions_LogGroupArn = this.CloudWatchLogOptions_LogGroupArn;
            context.CloudWatchLogOptions_LogOutputFormat = this.CloudWatchLogOptions_LogOutputFormat;
            if (this.TunnelOptions_Phase1DHGroupNumber != null)
            {
                context.TunnelOptions_Phase1DHGroupNumber = new List<Amazon.EC2.Model.Phase1DHGroupNumbersRequestListValue>(this.TunnelOptions_Phase1DHGroupNumber);
            }
            if (this.TunnelOptions_Phase1EncryptionAlgorithm != null)
            {
                context.TunnelOptions_Phase1EncryptionAlgorithm = new List<Amazon.EC2.Model.Phase1EncryptionAlgorithmsRequestListValue>(this.TunnelOptions_Phase1EncryptionAlgorithm);
            }
            if (this.TunnelOptions_Phase1IntegrityAlgorithm != null)
            {
                context.TunnelOptions_Phase1IntegrityAlgorithm = new List<Amazon.EC2.Model.Phase1IntegrityAlgorithmsRequestListValue>(this.TunnelOptions_Phase1IntegrityAlgorithm);
            }
            context.TunnelOptions_Phase1LifetimeSecond = this.TunnelOptions_Phase1LifetimeSecond;
            if (this.TunnelOptions_Phase2DHGroupNumber != null)
            {
                context.TunnelOptions_Phase2DHGroupNumber = new List<Amazon.EC2.Model.Phase2DHGroupNumbersRequestListValue>(this.TunnelOptions_Phase2DHGroupNumber);
            }
            if (this.TunnelOptions_Phase2EncryptionAlgorithm != null)
            {
                context.TunnelOptions_Phase2EncryptionAlgorithm = new List<Amazon.EC2.Model.Phase2EncryptionAlgorithmsRequestListValue>(this.TunnelOptions_Phase2EncryptionAlgorithm);
            }
            if (this.TunnelOptions_Phase2IntegrityAlgorithm != null)
            {
                context.TunnelOptions_Phase2IntegrityAlgorithm = new List<Amazon.EC2.Model.Phase2IntegrityAlgorithmsRequestListValue>(this.TunnelOptions_Phase2IntegrityAlgorithm);
            }
            context.TunnelOptions_Phase2LifetimeSecond = this.TunnelOptions_Phase2LifetimeSecond;
            context.TunnelOptions_PreSharedKey = this.TunnelOptions_PreSharedKey;
            context.TunnelOptions_RekeyFuzzPercentage = this.TunnelOptions_RekeyFuzzPercentage;
            context.TunnelOptions_RekeyMarginTimeSecond = this.TunnelOptions_RekeyMarginTimeSecond;
            context.TunnelOptions_ReplayWindowSize = this.TunnelOptions_ReplayWindowSize;
            context.TunnelOptions_StartupAction = this.TunnelOptions_StartupAction;
            context.TunnelOptions_TunnelInsideCidr = this.TunnelOptions_TunnelInsideCidr;
            context.TunnelOptions_TunnelInsideIpv6Cidr = this.TunnelOptions_TunnelInsideIpv6Cidr;
            context.VpnConnectionId = this.VpnConnectionId;
            #if MODULAR
            if (this.VpnConnectionId == null && ParameterWasBound(nameof(this.VpnConnectionId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnConnectionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpnTunnelOutsideIpAddress = this.VpnTunnelOutsideIpAddress;
            #if MODULAR
            if (this.VpnTunnelOutsideIpAddress == null && ParameterWasBound(nameof(this.VpnTunnelOutsideIpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter VpnTunnelOutsideIpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyVpnTunnelOptionsRequest();
            
            if (cmdletContext.SkipTunnelReplacement != null)
            {
                request.SkipTunnelReplacement = cmdletContext.SkipTunnelReplacement.Value;
            }
            
             // populate TunnelOptions
            var requestTunnelOptionsIsNull = true;
            request.TunnelOptions = new Amazon.EC2.Model.ModifyVpnTunnelOptionsSpecification();
            System.String requestTunnelOptions_tunnelOptions_DPDTimeoutAction = null;
            if (cmdletContext.TunnelOptions_DPDTimeoutAction != null)
            {
                requestTunnelOptions_tunnelOptions_DPDTimeoutAction = cmdletContext.TunnelOptions_DPDTimeoutAction;
            }
            if (requestTunnelOptions_tunnelOptions_DPDTimeoutAction != null)
            {
                request.TunnelOptions.DPDTimeoutAction = requestTunnelOptions_tunnelOptions_DPDTimeoutAction;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_DPDTimeoutSecond = null;
            if (cmdletContext.TunnelOptions_DPDTimeoutSecond != null)
            {
                requestTunnelOptions_tunnelOptions_DPDTimeoutSecond = cmdletContext.TunnelOptions_DPDTimeoutSecond.Value;
            }
            if (requestTunnelOptions_tunnelOptions_DPDTimeoutSecond != null)
            {
                request.TunnelOptions.DPDTimeoutSeconds = requestTunnelOptions_tunnelOptions_DPDTimeoutSecond.Value;
                requestTunnelOptionsIsNull = false;
            }
            System.Boolean? requestTunnelOptions_tunnelOptions_EnableTunnelLifecycleControl = null;
            if (cmdletContext.TunnelOptions_EnableTunnelLifecycleControl != null)
            {
                requestTunnelOptions_tunnelOptions_EnableTunnelLifecycleControl = cmdletContext.TunnelOptions_EnableTunnelLifecycleControl.Value;
            }
            if (requestTunnelOptions_tunnelOptions_EnableTunnelLifecycleControl != null)
            {
                request.TunnelOptions.EnableTunnelLifecycleControl = requestTunnelOptions_tunnelOptions_EnableTunnelLifecycleControl.Value;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.IKEVersionsRequestListValue> requestTunnelOptions_tunnelOptions_IKEVersion = null;
            if (cmdletContext.TunnelOptions_IKEVersion != null)
            {
                requestTunnelOptions_tunnelOptions_IKEVersion = cmdletContext.TunnelOptions_IKEVersion;
            }
            if (requestTunnelOptions_tunnelOptions_IKEVersion != null)
            {
                request.TunnelOptions.IKEVersions = requestTunnelOptions_tunnelOptions_IKEVersion;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase1DHGroupNumbersRequestListValue> requestTunnelOptions_tunnelOptions_Phase1DHGroupNumber = null;
            if (cmdletContext.TunnelOptions_Phase1DHGroupNumber != null)
            {
                requestTunnelOptions_tunnelOptions_Phase1DHGroupNumber = cmdletContext.TunnelOptions_Phase1DHGroupNumber;
            }
            if (requestTunnelOptions_tunnelOptions_Phase1DHGroupNumber != null)
            {
                request.TunnelOptions.Phase1DHGroupNumbers = requestTunnelOptions_tunnelOptions_Phase1DHGroupNumber;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase1EncryptionAlgorithmsRequestListValue> requestTunnelOptions_tunnelOptions_Phase1EncryptionAlgorithm = null;
            if (cmdletContext.TunnelOptions_Phase1EncryptionAlgorithm != null)
            {
                requestTunnelOptions_tunnelOptions_Phase1EncryptionAlgorithm = cmdletContext.TunnelOptions_Phase1EncryptionAlgorithm;
            }
            if (requestTunnelOptions_tunnelOptions_Phase1EncryptionAlgorithm != null)
            {
                request.TunnelOptions.Phase1EncryptionAlgorithms = requestTunnelOptions_tunnelOptions_Phase1EncryptionAlgorithm;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase1IntegrityAlgorithmsRequestListValue> requestTunnelOptions_tunnelOptions_Phase1IntegrityAlgorithm = null;
            if (cmdletContext.TunnelOptions_Phase1IntegrityAlgorithm != null)
            {
                requestTunnelOptions_tunnelOptions_Phase1IntegrityAlgorithm = cmdletContext.TunnelOptions_Phase1IntegrityAlgorithm;
            }
            if (requestTunnelOptions_tunnelOptions_Phase1IntegrityAlgorithm != null)
            {
                request.TunnelOptions.Phase1IntegrityAlgorithms = requestTunnelOptions_tunnelOptions_Phase1IntegrityAlgorithm;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_Phase1LifetimeSecond = null;
            if (cmdletContext.TunnelOptions_Phase1LifetimeSecond != null)
            {
                requestTunnelOptions_tunnelOptions_Phase1LifetimeSecond = cmdletContext.TunnelOptions_Phase1LifetimeSecond.Value;
            }
            if (requestTunnelOptions_tunnelOptions_Phase1LifetimeSecond != null)
            {
                request.TunnelOptions.Phase1LifetimeSeconds = requestTunnelOptions_tunnelOptions_Phase1LifetimeSecond.Value;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase2DHGroupNumbersRequestListValue> requestTunnelOptions_tunnelOptions_Phase2DHGroupNumber = null;
            if (cmdletContext.TunnelOptions_Phase2DHGroupNumber != null)
            {
                requestTunnelOptions_tunnelOptions_Phase2DHGroupNumber = cmdletContext.TunnelOptions_Phase2DHGroupNumber;
            }
            if (requestTunnelOptions_tunnelOptions_Phase2DHGroupNumber != null)
            {
                request.TunnelOptions.Phase2DHGroupNumbers = requestTunnelOptions_tunnelOptions_Phase2DHGroupNumber;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase2EncryptionAlgorithmsRequestListValue> requestTunnelOptions_tunnelOptions_Phase2EncryptionAlgorithm = null;
            if (cmdletContext.TunnelOptions_Phase2EncryptionAlgorithm != null)
            {
                requestTunnelOptions_tunnelOptions_Phase2EncryptionAlgorithm = cmdletContext.TunnelOptions_Phase2EncryptionAlgorithm;
            }
            if (requestTunnelOptions_tunnelOptions_Phase2EncryptionAlgorithm != null)
            {
                request.TunnelOptions.Phase2EncryptionAlgorithms = requestTunnelOptions_tunnelOptions_Phase2EncryptionAlgorithm;
                requestTunnelOptionsIsNull = false;
            }
            List<Amazon.EC2.Model.Phase2IntegrityAlgorithmsRequestListValue> requestTunnelOptions_tunnelOptions_Phase2IntegrityAlgorithm = null;
            if (cmdletContext.TunnelOptions_Phase2IntegrityAlgorithm != null)
            {
                requestTunnelOptions_tunnelOptions_Phase2IntegrityAlgorithm = cmdletContext.TunnelOptions_Phase2IntegrityAlgorithm;
            }
            if (requestTunnelOptions_tunnelOptions_Phase2IntegrityAlgorithm != null)
            {
                request.TunnelOptions.Phase2IntegrityAlgorithms = requestTunnelOptions_tunnelOptions_Phase2IntegrityAlgorithm;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_Phase2LifetimeSecond = null;
            if (cmdletContext.TunnelOptions_Phase2LifetimeSecond != null)
            {
                requestTunnelOptions_tunnelOptions_Phase2LifetimeSecond = cmdletContext.TunnelOptions_Phase2LifetimeSecond.Value;
            }
            if (requestTunnelOptions_tunnelOptions_Phase2LifetimeSecond != null)
            {
                request.TunnelOptions.Phase2LifetimeSeconds = requestTunnelOptions_tunnelOptions_Phase2LifetimeSecond.Value;
                requestTunnelOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_PreSharedKey = null;
            if (cmdletContext.TunnelOptions_PreSharedKey != null)
            {
                requestTunnelOptions_tunnelOptions_PreSharedKey = cmdletContext.TunnelOptions_PreSharedKey;
            }
            if (requestTunnelOptions_tunnelOptions_PreSharedKey != null)
            {
                request.TunnelOptions.PreSharedKey = requestTunnelOptions_tunnelOptions_PreSharedKey;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_RekeyFuzzPercentage = null;
            if (cmdletContext.TunnelOptions_RekeyFuzzPercentage != null)
            {
                requestTunnelOptions_tunnelOptions_RekeyFuzzPercentage = cmdletContext.TunnelOptions_RekeyFuzzPercentage.Value;
            }
            if (requestTunnelOptions_tunnelOptions_RekeyFuzzPercentage != null)
            {
                request.TunnelOptions.RekeyFuzzPercentage = requestTunnelOptions_tunnelOptions_RekeyFuzzPercentage.Value;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_RekeyMarginTimeSecond = null;
            if (cmdletContext.TunnelOptions_RekeyMarginTimeSecond != null)
            {
                requestTunnelOptions_tunnelOptions_RekeyMarginTimeSecond = cmdletContext.TunnelOptions_RekeyMarginTimeSecond.Value;
            }
            if (requestTunnelOptions_tunnelOptions_RekeyMarginTimeSecond != null)
            {
                request.TunnelOptions.RekeyMarginTimeSeconds = requestTunnelOptions_tunnelOptions_RekeyMarginTimeSecond.Value;
                requestTunnelOptionsIsNull = false;
            }
            System.Int32? requestTunnelOptions_tunnelOptions_ReplayWindowSize = null;
            if (cmdletContext.TunnelOptions_ReplayWindowSize != null)
            {
                requestTunnelOptions_tunnelOptions_ReplayWindowSize = cmdletContext.TunnelOptions_ReplayWindowSize.Value;
            }
            if (requestTunnelOptions_tunnelOptions_ReplayWindowSize != null)
            {
                request.TunnelOptions.ReplayWindowSize = requestTunnelOptions_tunnelOptions_ReplayWindowSize.Value;
                requestTunnelOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_StartupAction = null;
            if (cmdletContext.TunnelOptions_StartupAction != null)
            {
                requestTunnelOptions_tunnelOptions_StartupAction = cmdletContext.TunnelOptions_StartupAction;
            }
            if (requestTunnelOptions_tunnelOptions_StartupAction != null)
            {
                request.TunnelOptions.StartupAction = requestTunnelOptions_tunnelOptions_StartupAction;
                requestTunnelOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_TunnelInsideCidr = null;
            if (cmdletContext.TunnelOptions_TunnelInsideCidr != null)
            {
                requestTunnelOptions_tunnelOptions_TunnelInsideCidr = cmdletContext.TunnelOptions_TunnelInsideCidr;
            }
            if (requestTunnelOptions_tunnelOptions_TunnelInsideCidr != null)
            {
                request.TunnelOptions.TunnelInsideCidr = requestTunnelOptions_tunnelOptions_TunnelInsideCidr;
                requestTunnelOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_TunnelInsideIpv6Cidr = null;
            if (cmdletContext.TunnelOptions_TunnelInsideIpv6Cidr != null)
            {
                requestTunnelOptions_tunnelOptions_TunnelInsideIpv6Cidr = cmdletContext.TunnelOptions_TunnelInsideIpv6Cidr;
            }
            if (requestTunnelOptions_tunnelOptions_TunnelInsideIpv6Cidr != null)
            {
                request.TunnelOptions.TunnelInsideIpv6Cidr = requestTunnelOptions_tunnelOptions_TunnelInsideIpv6Cidr;
                requestTunnelOptionsIsNull = false;
            }
            Amazon.EC2.Model.VpnTunnelLogOptionsSpecification requestTunnelOptions_tunnelOptions_LogOptions = null;
            
             // populate LogOptions
            var requestTunnelOptions_tunnelOptions_LogOptionsIsNull = true;
            requestTunnelOptions_tunnelOptions_LogOptions = new Amazon.EC2.Model.VpnTunnelLogOptionsSpecification();
            Amazon.EC2.Model.CloudWatchLogOptionsSpecification requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions = null;
            
             // populate CloudWatchLogOptions
            var requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptionsIsNull = true;
            requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions = new Amazon.EC2.Model.CloudWatchLogOptionsSpecification();
            System.Boolean? requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogEnabled = null;
            if (cmdletContext.CloudWatchLogOptions_LogEnabled != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogEnabled = cmdletContext.CloudWatchLogOptions_LogEnabled.Value;
            }
            if (requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogEnabled != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions.LogEnabled = requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogEnabled.Value;
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogGroupArn = null;
            if (cmdletContext.CloudWatchLogOptions_LogGroupArn != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogGroupArn = cmdletContext.CloudWatchLogOptions_LogGroupArn;
            }
            if (requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogGroupArn != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions.LogGroupArn = requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogGroupArn;
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptionsIsNull = false;
            }
            System.String requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogOutputFormat = null;
            if (cmdletContext.CloudWatchLogOptions_LogOutputFormat != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogOutputFormat = cmdletContext.CloudWatchLogOptions_LogOutputFormat;
            }
            if (requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogOutputFormat != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions.LogOutputFormat = requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions_cloudWatchLogOptions_LogOutputFormat;
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptionsIsNull = false;
            }
             // determine if requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions should be set to null
            if (requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptionsIsNull)
            {
                requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions = null;
            }
            if (requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions != null)
            {
                requestTunnelOptions_tunnelOptions_LogOptions.CloudWatchLogOptions = requestTunnelOptions_tunnelOptions_LogOptions_tunnelOptions_LogOptions_CloudWatchLogOptions;
                requestTunnelOptions_tunnelOptions_LogOptionsIsNull = false;
            }
             // determine if requestTunnelOptions_tunnelOptions_LogOptions should be set to null
            if (requestTunnelOptions_tunnelOptions_LogOptionsIsNull)
            {
                requestTunnelOptions_tunnelOptions_LogOptions = null;
            }
            if (requestTunnelOptions_tunnelOptions_LogOptions != null)
            {
                request.TunnelOptions.LogOptions = requestTunnelOptions_tunnelOptions_LogOptions;
                requestTunnelOptionsIsNull = false;
            }
             // determine if request.TunnelOptions should be set to null
            if (requestTunnelOptionsIsNull)
            {
                request.TunnelOptions = null;
            }
            if (cmdletContext.VpnConnectionId != null)
            {
                request.VpnConnectionId = cmdletContext.VpnConnectionId;
            }
            if (cmdletContext.VpnTunnelOutsideIpAddress != null)
            {
                request.VpnTunnelOutsideIpAddress = cmdletContext.VpnTunnelOutsideIpAddress;
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
        
        private Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyVpnTunnelOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyVpnTunnelOptions");
            try
            {
                #if DESKTOP
                return client.ModifyVpnTunnelOptions(request);
                #elif CORECLR
                return client.ModifyVpnTunnelOptionsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? SkipTunnelReplacement { get; set; }
            public System.String TunnelOptions_DPDTimeoutAction { get; set; }
            public System.Int32? TunnelOptions_DPDTimeoutSecond { get; set; }
            public System.Boolean? TunnelOptions_EnableTunnelLifecycleControl { get; set; }
            public List<Amazon.EC2.Model.IKEVersionsRequestListValue> TunnelOptions_IKEVersion { get; set; }
            public System.Boolean? CloudWatchLogOptions_LogEnabled { get; set; }
            public System.String CloudWatchLogOptions_LogGroupArn { get; set; }
            public System.String CloudWatchLogOptions_LogOutputFormat { get; set; }
            public List<Amazon.EC2.Model.Phase1DHGroupNumbersRequestListValue> TunnelOptions_Phase1DHGroupNumber { get; set; }
            public List<Amazon.EC2.Model.Phase1EncryptionAlgorithmsRequestListValue> TunnelOptions_Phase1EncryptionAlgorithm { get; set; }
            public List<Amazon.EC2.Model.Phase1IntegrityAlgorithmsRequestListValue> TunnelOptions_Phase1IntegrityAlgorithm { get; set; }
            public System.Int32? TunnelOptions_Phase1LifetimeSecond { get; set; }
            public List<Amazon.EC2.Model.Phase2DHGroupNumbersRequestListValue> TunnelOptions_Phase2DHGroupNumber { get; set; }
            public List<Amazon.EC2.Model.Phase2EncryptionAlgorithmsRequestListValue> TunnelOptions_Phase2EncryptionAlgorithm { get; set; }
            public List<Amazon.EC2.Model.Phase2IntegrityAlgorithmsRequestListValue> TunnelOptions_Phase2IntegrityAlgorithm { get; set; }
            public System.Int32? TunnelOptions_Phase2LifetimeSecond { get; set; }
            public System.String TunnelOptions_PreSharedKey { get; set; }
            public System.Int32? TunnelOptions_RekeyFuzzPercentage { get; set; }
            public System.Int32? TunnelOptions_RekeyMarginTimeSecond { get; set; }
            public System.Int32? TunnelOptions_ReplayWindowSize { get; set; }
            public System.String TunnelOptions_StartupAction { get; set; }
            public System.String TunnelOptions_TunnelInsideCidr { get; set; }
            public System.String TunnelOptions_TunnelInsideIpv6Cidr { get; set; }
            public System.String VpnConnectionId { get; set; }
            public System.String VpnTunnelOutsideIpAddress { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse, EditEC2VpnTunnelOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
