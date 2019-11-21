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
    /// Modifies the options for a VPN tunnel in an AWS Site-to-Site VPN connection. You can
    /// modify multiple options for a tunnel in a single request, but you can only modify
    /// one tunnel at a time. For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/s2svpn/VPNTunnels.html">Site-to-Site
    /// VPN Tunnel Options for Your Site-to-Site VPN Connection</a> in the <i>AWS Site-to-Site
    /// VPN User Guide</i>.
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
        
        #region Parameter TunnelOptions_DPDTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds after which a DPD timeout occurs.</para><para>Constraints: A value between 0 and 30.</para><para>Default: <code>30</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_DPDTimeoutSeconds")]
        public System.Int32? TunnelOptions_DPDTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_IKEVersion
        /// <summary>
        /// <para>
        /// <para>The IKE versions that are permitted for the VPN tunnel.</para><para>Valid values: <code>ikev1</code> | <code>ikev2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_IKEVersions")]
        public Amazon.EC2.Model.IKEVersionsRequestListValue[] TunnelOptions_IKEVersion { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1DHGroupNumber
        /// <summary>
        /// <para>
        /// <para>One or more Diffie-Hellman group numbers that are permitted for the VPN tunnel for
        /// phase 1 IKE negotiations.</para><para>Valid values: <code>2</code> | <code>14</code> | <code>15</code> | <code>16</code>
        /// | <code>17</code> | <code>18</code> | <code>22</code> | <code>23</code> | <code>24</code></para>
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
        /// 1 IKE negotiations.</para><para>Valid values: <code>AES128</code> | <code>AES256</code></para>
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
        /// IKE negotiations.</para><para>Valid values: <code>SHA1</code> | <code>SHA2-256</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_Phase1IntegrityAlgorithms")]
        public Amazon.EC2.Model.Phase1IntegrityAlgorithmsRequestListValue[] TunnelOptions_Phase1IntegrityAlgorithm { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_Phase1LifetimeSecond
        /// <summary>
        /// <para>
        /// <para>The lifetime for phase 1 of the IKE negotiation, in seconds.</para><para>Constraints: A value between 900 and 28,800.</para><para>Default: <code>28800</code></para>
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
        /// phase 2 IKE negotiations.</para><para>Valid values: <code>2</code> | <code>5</code> | <code>14</code> | <code>15</code>
        /// | <code>16</code> | <code>17</code> | <code>18</code> | <code>22</code> | <code>23</code>
        /// | <code>24</code></para>
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
        /// 2 IKE negotiations.</para><para>Valid values: <code>AES128</code> | <code>AES256</code></para>
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
        /// IKE negotiations.</para><para>Valid values: <code>SHA1</code> | <code>SHA2-256</code></para>
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
        /// for <code>Phase1LifetimeSeconds</code>.</para><para>Default: <code>3600</code></para>
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
        /// <para>The percentage of the rekey window (determined by <code>RekeyMarginTimeSeconds</code>)
        /// during which the rekey time is randomly selected.</para><para>Constraints: A value between 0 and 100.</para><para>Default: <code>100</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TunnelOptions_RekeyFuzzPercentage { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_RekeyMarginTimeSecond
        /// <summary>
        /// <para>
        /// <para>The margin time, in seconds, before the phase 2 lifetime expires, during which the
        /// AWS side of the VPN connection performs an IKE rekey. The exact time of the rekey
        /// is randomly selected based on the value for <code>RekeyFuzzPercentage</code>.</para><para>Constraints: A value between 60 and half of <code>Phase2LifetimeSeconds</code>.</para><para>Default: <code>540</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TunnelOptions_RekeyMarginTimeSeconds")]
        public System.Int32? TunnelOptions_RekeyMarginTimeSecond { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_ReplayWindowSize
        /// <summary>
        /// <para>
        /// <para>The number of packets in an IKE replay window.</para><para>Constraints: A value between 64 and 2048.</para><para>Default: <code>1024</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TunnelOptions_ReplayWindowSize { get; set; }
        #endregion
        
        #region Parameter TunnelOptions_TunnelInsideCidr
        /// <summary>
        /// <para>
        /// <para>The range of inside IP addresses for the tunnel. Any specified CIDR blocks must be
        /// unique across all VPN connections that use the same virtual private gateway. </para><para>Constraints: A size /30 CIDR block from the <code>169.254.0.0/16</code> range. The
        /// following CIDR blocks are reserved and cannot be used:</para><ul><li><para><code>169.254.0.0/30</code></para></li><li><para><code>169.254.1.0/30</code></para></li><li><para><code>169.254.2.0/30</code></para></li><li><para><code>169.254.3.0/30</code></para></li><li><para><code>169.254.4.0/30</code></para></li><li><para><code>169.254.5.0/30</code></para></li><li><para><code>169.254.169.252/30</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TunnelOptions_TunnelInsideCidr { get; set; }
        #endregion
        
        #region Parameter VpnConnectionId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Site-to-Site VPN connection.</para>
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
            context.TunnelOptions_DPDTimeoutSecond = this.TunnelOptions_DPDTimeoutSecond;
            if (this.TunnelOptions_IKEVersion != null)
            {
                context.TunnelOptions_IKEVersion = new List<Amazon.EC2.Model.IKEVersionsRequestListValue>(this.TunnelOptions_IKEVersion);
            }
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
            context.TunnelOptions_TunnelInsideCidr = this.TunnelOptions_TunnelInsideCidr;
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
            
            
             // populate TunnelOptions
            var requestTunnelOptionsIsNull = true;
            request.TunnelOptions = new Amazon.EC2.Model.ModifyVpnTunnelOptionsSpecification();
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
            public System.Int32? TunnelOptions_DPDTimeoutSecond { get; set; }
            public List<Amazon.EC2.Model.IKEVersionsRequestListValue> TunnelOptions_IKEVersion { get; set; }
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
            public System.String TunnelOptions_TunnelInsideCidr { get; set; }
            public System.String VpnConnectionId { get; set; }
            public System.String VpnTunnelOutsideIpAddress { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyVpnTunnelOptionsResponse, EditEC2VpnTunnelOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VpnConnection;
        }
        
    }
}
