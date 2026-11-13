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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Creates an Network Firewall <a>Firewall</a> and accompanying <a>FirewallStatus</a>
    /// for a VPC. 
    /// 
    ///  
    /// <para>
    /// The firewall defines the configuration settings for an Network Firewall firewall.
    /// The settings that you can define at creation include the firewall policy, the subnets
    /// in your VPC to use for the firewall endpoints, and any tags that are attached to the
    /// firewall Amazon Web Services resource. 
    /// </para><para>
    /// After you create a firewall, you can provide additional settings, like the logging
    /// configuration. 
    /// </para><para>
    /// To update the settings for a firewall, you use the operations that apply to the settings
    /// themselves, for example <a>UpdateLoggingConfiguration</a>, <a>AssociateSubnets</a>,
    /// and <a>UpdateFirewallDeleteProtection</a>. 
    /// </para><para>
    /// To manage a firewall's tags, use the standard Amazon Web Services resource tagging
    /// operations, <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about firewalls, use <a>ListFirewalls</a> and <a>DescribeFirewall</a>.
    /// </para><para>
    /// To generate a report on the last 30 days of traffic monitored by a firewall, use <a>StartAnalysisReport</a>.
    /// </para><para>
    /// To create a proxy mode firewall, specify <c>VpcEndpoint</c> and <c>NatGatewayCreateMappings</c>
    /// instead of <c>VpcId</c> and <c>SubnetMappings</c>. A proxy mode firewall is an explicit
    /// forward proxy. Your clients send HTTP and HTTPS proxy requests to the firewall's proxy
    /// DNS name, which <c>DescribeFirewall</c> returns in each Availability Zone's <c>Attachment</c>.
    /// The firewall evaluates proxy traffic with the stateful rules in its firewall policy,
    /// and sends allowed traffic out through the NAT gateway in the same Availability Zone.
    /// Your clients don't need route table changes. In each Availability Zone, the firewall
    /// has one endpoint and one NAT gateway, which Network Firewall creates for you. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWFirewall", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateFirewallResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateFirewall API operation.", Operation = new[] {"CreateFirewall"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateFirewallResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateFirewallResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateFirewallResponse object containing multiple properties."
    )]
    public partial class NewNWFWFirewallCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZoneChangeProtection
        /// <summary>
        /// <para>
        /// <para>Optional. A setting indicating whether the firewall is protected against changes to
        /// its Availability Zone configuration. When set to <c>TRUE</c>, you cannot add or remove
        /// Availability Zones without first disabling this protection using <a>UpdateAvailabilityZoneChangeProtection</a>.</para><para>Default value: <c>FALSE</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AvailabilityZoneChangeProtection { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneMapping
        /// <summary>
        /// <para>
        /// <para>Required. The Availability Zones where you want to create firewall endpoints for a
        /// transit gateway-attached firewall. You must specify at least one Availability Zone.
        /// Consider enabling the firewall in every Availability Zone where you have workloads
        /// to maintain Availability Zone isolation.</para><para>You can modify Availability Zones later using <a>AssociateAvailabilityZones</a> or
        /// <a>DisassociateAvailabilityZones</a>, but this may briefly disrupt traffic. The <c>AvailabilityZoneChangeProtection</c>
        /// setting controls whether you can make these modifications.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AvailabilityZoneMappings")]
        public Amazon.NetworkFirewall.Model.AvailabilityZoneMapping[] AvailabilityZoneMapping { get; set; }
        #endregion
        
        #region Parameter ProxySettings_CertificateArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the certificate that the firewall's HTTPS proxy
        /// listener presents to clients. The certificate must be an Certificate Manager (ACM)
        /// certificate in the same account and Region as the firewall. Its subject alternative
        /// names must cover <c>DomainName</c>, either exactly or with a wildcard that matches
        /// exactly one label. For example, <c>*.example.com</c> covers <c>proxy.example.com</c>.
        /// If you don't specify this, Network Firewall uses a certificate that it manages for
        /// a domain name that it generates.</para><para>You manage and renew the certificate in ACM, and Network Firewall uses renewed certificates
        /// automatically. While the firewall uses the certificate, you can't delete it from ACM.
        /// Your clients must trust the certificate's certificate authority.</para><para>If you specify <c>CertificateArn</c>, you must also specify <c>DomainName</c>. You
        /// can set them only when you create the firewall. When you call <c>UpdateProxySettings</c>,
        /// specify the same values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxySettings_CertificateArn { get; set; }
        #endregion
        
        #region Parameter DeleteProtection
        /// <summary>
        /// <para>
        /// <para>A flag indicating whether it is possible to delete the firewall. A setting of <c>TRUE</c>
        /// indicates that the firewall is protected against deletion. Use this setting to protect
        /// against accidentally deleting a firewall that is in use. When you create a firewall,
        /// the operation initializes this flag to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteProtection { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ProxySettings_DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name that your clients use to reach the firewall's proxy. The name must
        /// have at least two labels and at most 253 characters. It can't contain a wildcard or
        /// use the <c>proxy-<i>id</i>.nfw.<i>region</i>.amazonaws.com</c> format, and the certificate
        /// in <c>CertificateArn</c> must cover it. If you don't specify this, Network Firewall
        /// generates a domain name.</para><para>Network Firewall creates the Route 53 private hosted zones that resolve this name
        /// to the firewall endpoints, so you don't need to configure DNS. A VPC can have only
        /// one private hosted zone with a given name. If a VPC that the firewall serves already
        /// has one with this name, Network Firewall can't set up the Availability Zones in that
        /// VPC.</para><para>If you specify <c>DomainName</c>, you must also specify <c>CertificateArn</c>. You
        /// can set them only when you create the firewall. When you call <c>UpdateProxySettings</c>,
        /// specify the same values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProxySettings_DomainName { get; set; }
        #endregion
        
        #region Parameter EnabledAnalysisType
        /// <summary>
        /// <para>
        /// <para>An optional setting indicating the specific traffic analysis types to enable on the
        /// firewall. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnabledAnalysisTypes")]
        public System.String[] EnabledAnalysisType { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para>
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
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <a>FirewallPolicy</a> that you want to use for
        /// the firewall.</para>
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
        public System.String FirewallPolicyArn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyChangeProtection
        /// <summary>
        /// <para>
        /// <para>A setting indicating whether the firewall is protected against a change to the firewall
        /// policy association. Use this setting to protect against accidentally modifying the
        /// firewall policy for a firewall that is in use. When you create a firewall, the operation
        /// initializes this setting to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FirewallPolicyChangeProtection { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service (KMS) customer managed key.
        /// You can use any of the key identifiers that KMS supports, unless you're using a key
        /// that's managed by another account. If you're using a key managed by another account,
        /// then specify the key ARN. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// ID</a> in the <i>Amazon Web Services KMS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter ProxySettings_ListenerProperty
        /// <summary>
        /// <para>
        /// <para>The listeners of the firewall's proxy. Specify at least one listener, and at most
        /// one HTTP listener and one HTTPS listener. Each listener needs a port from 1 to 65535,
        /// and the two listeners must use different ports.</para><para>If you don't specify listeners when you create the firewall, the firewall listens
        /// for HTTP on port 3128 and HTTPS on port 8443.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProxySettings_ListenerProperties")]
        public Amazon.NetworkFirewall.Model.ListenerProperty[] ProxySettings_ListenerProperty { get; set; }
        #endregion
        
        #region Parameter NatGatewayCreateMapping
        /// <summary>
        /// <para>
        /// <para>The NAT gateways that Network Firewall creates for a proxy mode firewall, one for
        /// each Availability Zone. When you specify this, you create a proxy mode firewall. Destinations
        /// see the IP address of the NAT gateway in the client's Availability Zone as the source
        /// of the traffic.</para><para>Specify one mapping for each Availability Zone in <c>VpcEndpoint</c>, and no other
        /// Availability Zones. Each NAT gateway subnet must be in the <c>VpcEndpoint</c> VPC
        /// and can't be one of the firewall endpoint subnets.</para><para>You need permission to call the Amazon EC2 <c>CreateNatGateway</c> action.</para><para>If Network Firewall can't set up an Availability Zone, for example because Amazon
        /// EC2 rejects the NAT gateway, it removes the Availability Zone from the firewall. It
        /// also deletes the NAT gateway that it created there. The Availability Zone's <c>Attachment</c>
        /// status is <c>FAILED</c>, and its status message explains why. You can add the Availability
        /// Zone again with <c>AssociateSubnets</c>. If no Availability Zone can be set up, the
        /// firewall status is <c>FAILED</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NatGatewayCreateMappings")]
        public Amazon.NetworkFirewall.Model.NatGatewayCreateMapping[] NatGatewayCreateMapping { get; set; }
        #endregion
        
        #region Parameter SubnetChangeProtection
        /// <summary>
        /// <para>
        /// <para>A setting indicating whether the firewall is protected against changes to the subnet
        /// associations. Use this setting to protect against accidentally modifying the subnet
        /// associations for a firewall that is in use. When you create a firewall, the operation
        /// initializes this setting to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SubnetChangeProtection { get; set; }
        #endregion
        
        #region Parameter SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The public subnets to use for your Network Firewall firewalls. Each subnet must belong
        /// to a different Availability Zone in the VPC. Network Firewall creates a firewall endpoint
        /// in each subnet. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetMappings")]
        public Amazon.NetworkFirewall.Model.SubnetMapping[] SubnetMapping { get; set; }
        #endregion
        
        #region Parameter VpcEndpoint_SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The subnets where Network Firewall creates the firewall endpoints of a proxy mode
        /// firewall. Specify one subnet for each Availability Zone, and a NAT gateway mapping
        /// in each of those Availability Zones.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcEndpoint_SubnetMappings")]
        public Amazon.NetworkFirewall.Model.SubnetMapping[] VpcEndpoint_SubnetMapping { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TransitGatewayId
        /// <summary>
        /// <para>
        /// <para>Required when creating a transit gateway-attached firewall. The unique identifier
        /// of the transit gateway to attach to this firewall. You can provide either a transit
        /// gateway from your account or one that has been shared with you through Resource Access
        /// Manager.</para><important><para>After creating the firewall, you cannot change the transit gateway association. To
        /// use a different transit gateway, you must create a new firewall.</para></important><para>For information about creating firewalls, see <a>CreateFirewall</a>. For specific
        /// guidance about transit gateway-attached firewalls, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/tgw-firewall-considerations.html">Considerations
        /// for transit gateway-attached firewalls</a> in the <i>Network Firewall Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TransitGatewayId { get; set; }
        #endregion
        
        #region Parameter TransparentFilteringNatScope
        /// <summary>
        /// <para>
        /// <para>How a proxy mode firewall handles traffic that isn't sent to its proxy listener. If
        /// you don't specify a value, the firewall uses <c>NAT_ALL</c>. You can choose from the
        /// following values:</para><ul><li><para><c>NAT_ALL</c> - After inspection, the firewall sends this traffic out through its
        /// NAT gateway, which translates the source address.</para></li><li><para><c>NAT_NONE</c> - After inspection, the firewall returns this traffic to the firewall
        /// endpoint without address translation.</para></li></ul><para>You can specify this only for a proxy mode firewall, and you can't change it after
        /// you create the firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.TransparentFilteringNatScope")]
        public Amazon.NetworkFirewall.TransparentFilteringNatScope TransparentFilteringNatScope { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services KMS key to use for encryption of your Network Firewall
        /// resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.EncryptionType")]
        public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter VpcEndpoint_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC where Network Firewall creates the endpoints and NAT gateways of
        /// a proxy mode firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpoint_VpcId { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the VPC where Network Firewall should create the firewall.
        /// </para><para>You can't change this setting after you create the firewall. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateFirewallResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateFirewallResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWFirewall (CreateFirewall)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateFirewallResponse, NewNWFWFirewallCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZoneChangeProtection = this.AvailabilityZoneChangeProtection;
            if (this.AvailabilityZoneMapping != null)
            {
                context.AvailabilityZoneMapping = new List<Amazon.NetworkFirewall.Model.AvailabilityZoneMapping>(this.AvailabilityZoneMapping);
            }
            context.DeleteProtection = this.DeleteProtection;
            context.Description = this.Description;
            if (this.EnabledAnalysisType != null)
            {
                context.EnabledAnalysisType = new List<System.String>(this.EnabledAnalysisType);
            }
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            context.FirewallName = this.FirewallName;
            #if MODULAR
            if (this.FirewallName == null && ParameterWasBound(nameof(this.FirewallName)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallPolicyArn = this.FirewallPolicyArn;
            #if MODULAR
            if (this.FirewallPolicyArn == null && ParameterWasBound(nameof(this.FirewallPolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallPolicyChangeProtection = this.FirewallPolicyChangeProtection;
            if (this.NatGatewayCreateMapping != null)
            {
                context.NatGatewayCreateMapping = new List<Amazon.NetworkFirewall.Model.NatGatewayCreateMapping>(this.NatGatewayCreateMapping);
            }
            context.ProxySettings_CertificateArn = this.ProxySettings_CertificateArn;
            context.ProxySettings_DomainName = this.ProxySettings_DomainName;
            if (this.ProxySettings_ListenerProperty != null)
            {
                context.ProxySettings_ListenerProperty = new List<Amazon.NetworkFirewall.Model.ListenerProperty>(this.ProxySettings_ListenerProperty);
            }
            context.SubnetChangeProtection = this.SubnetChangeProtection;
            if (this.SubnetMapping != null)
            {
                context.SubnetMapping = new List<Amazon.NetworkFirewall.Model.SubnetMapping>(this.SubnetMapping);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
            }
            context.TransitGatewayId = this.TransitGatewayId;
            context.TransparentFilteringNatScope = this.TransparentFilteringNatScope;
            if (this.VpcEndpoint_SubnetMapping != null)
            {
                context.VpcEndpoint_SubnetMapping = new List<Amazon.NetworkFirewall.Model.SubnetMapping>(this.VpcEndpoint_SubnetMapping);
            }
            context.VpcEndpoint_VpcId = this.VpcEndpoint_VpcId;
            context.VpcId = this.VpcId;
            
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
            var request = new Amazon.NetworkFirewall.Model.CreateFirewallRequest();
            
            if (cmdletContext.AvailabilityZoneChangeProtection != null)
            {
                request.AvailabilityZoneChangeProtection = cmdletContext.AvailabilityZoneChangeProtection.Value;
            }
            if (cmdletContext.AvailabilityZoneMapping != null)
            {
                request.AvailabilityZoneMappings = cmdletContext.AvailabilityZoneMapping;
            }
            if (cmdletContext.DeleteProtection != null)
            {
                request.DeleteProtection = cmdletContext.DeleteProtection.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnabledAnalysisType != null)
            {
                request.EnabledAnalysisTypes = cmdletContext.EnabledAnalysisType;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.NetworkFirewall.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KeyId = null;
            if (cmdletContext.EncryptionConfiguration_KeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyId = cmdletContext.EncryptionConfiguration_KeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyId != null)
            {
                request.EncryptionConfiguration.KeyId = requestEncryptionConfiguration_encryptionConfiguration_KeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.NetworkFirewall.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            if (cmdletContext.FirewallPolicyArn != null)
            {
                request.FirewallPolicyArn = cmdletContext.FirewallPolicyArn;
            }
            if (cmdletContext.FirewallPolicyChangeProtection != null)
            {
                request.FirewallPolicyChangeProtection = cmdletContext.FirewallPolicyChangeProtection.Value;
            }
            if (cmdletContext.NatGatewayCreateMapping != null)
            {
                request.NatGatewayCreateMappings = cmdletContext.NatGatewayCreateMapping;
            }
            
             // populate ProxySettings
            var requestProxySettingsIsNull = true;
            request.ProxySettings = new Amazon.NetworkFirewall.Model.ProxySettings();
            System.String requestProxySettings_proxySettings_CertificateArn = null;
            if (cmdletContext.ProxySettings_CertificateArn != null)
            {
                requestProxySettings_proxySettings_CertificateArn = cmdletContext.ProxySettings_CertificateArn;
            }
            if (requestProxySettings_proxySettings_CertificateArn != null)
            {
                request.ProxySettings.CertificateArn = requestProxySettings_proxySettings_CertificateArn;
                requestProxySettingsIsNull = false;
            }
            System.String requestProxySettings_proxySettings_DomainName = null;
            if (cmdletContext.ProxySettings_DomainName != null)
            {
                requestProxySettings_proxySettings_DomainName = cmdletContext.ProxySettings_DomainName;
            }
            if (requestProxySettings_proxySettings_DomainName != null)
            {
                request.ProxySettings.DomainName = requestProxySettings_proxySettings_DomainName;
                requestProxySettingsIsNull = false;
            }
            List<Amazon.NetworkFirewall.Model.ListenerProperty> requestProxySettings_proxySettings_ListenerProperty = null;
            if (cmdletContext.ProxySettings_ListenerProperty != null)
            {
                requestProxySettings_proxySettings_ListenerProperty = cmdletContext.ProxySettings_ListenerProperty;
            }
            if (requestProxySettings_proxySettings_ListenerProperty != null)
            {
                request.ProxySettings.ListenerProperties = requestProxySettings_proxySettings_ListenerProperty;
                requestProxySettingsIsNull = false;
            }
             // determine if request.ProxySettings should be set to null
            if (requestProxySettingsIsNull)
            {
                request.ProxySettings = null;
            }
            if (cmdletContext.SubnetChangeProtection != null)
            {
                request.SubnetChangeProtection = cmdletContext.SubnetChangeProtection.Value;
            }
            if (cmdletContext.SubnetMapping != null)
            {
                request.SubnetMappings = cmdletContext.SubnetMapping;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TransitGatewayId != null)
            {
                request.TransitGatewayId = cmdletContext.TransitGatewayId;
            }
            if (cmdletContext.TransparentFilteringNatScope != null)
            {
                request.TransparentFilteringNatScope = cmdletContext.TransparentFilteringNatScope;
            }
            
             // populate VpcEndpoint
            var requestVpcEndpointIsNull = true;
            request.VpcEndpoint = new Amazon.NetworkFirewall.Model.VpcEndpoint();
            List<Amazon.NetworkFirewall.Model.SubnetMapping> requestVpcEndpoint_vpcEndpoint_SubnetMapping = null;
            if (cmdletContext.VpcEndpoint_SubnetMapping != null)
            {
                requestVpcEndpoint_vpcEndpoint_SubnetMapping = cmdletContext.VpcEndpoint_SubnetMapping;
            }
            if (requestVpcEndpoint_vpcEndpoint_SubnetMapping != null)
            {
                request.VpcEndpoint.SubnetMappings = requestVpcEndpoint_vpcEndpoint_SubnetMapping;
                requestVpcEndpointIsNull = false;
            }
            System.String requestVpcEndpoint_vpcEndpoint_VpcId = null;
            if (cmdletContext.VpcEndpoint_VpcId != null)
            {
                requestVpcEndpoint_vpcEndpoint_VpcId = cmdletContext.VpcEndpoint_VpcId;
            }
            if (requestVpcEndpoint_vpcEndpoint_VpcId != null)
            {
                request.VpcEndpoint.VpcId = requestVpcEndpoint_vpcEndpoint_VpcId;
                requestVpcEndpointIsNull = false;
            }
             // determine if request.VpcEndpoint should be set to null
            if (requestVpcEndpointIsNull)
            {
                request.VpcEndpoint = null;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.NetworkFirewall.Model.CreateFirewallResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateFirewallRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateFirewall");
            try
            {
                return client.CreateFirewallAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AvailabilityZoneChangeProtection { get; set; }
            public List<Amazon.NetworkFirewall.Model.AvailabilityZoneMapping> AvailabilityZoneMapping { get; set; }
            public System.Boolean? DeleteProtection { get; set; }
            public System.String Description { get; set; }
            public List<System.String> EnabledAnalysisType { get; set; }
            public System.String EncryptionConfiguration_KeyId { get; set; }
            public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
            public System.String FirewallName { get; set; }
            public System.String FirewallPolicyArn { get; set; }
            public System.Boolean? FirewallPolicyChangeProtection { get; set; }
            public List<Amazon.NetworkFirewall.Model.NatGatewayCreateMapping> NatGatewayCreateMapping { get; set; }
            public System.String ProxySettings_CertificateArn { get; set; }
            public System.String ProxySettings_DomainName { get; set; }
            public List<Amazon.NetworkFirewall.Model.ListenerProperty> ProxySettings_ListenerProperty { get; set; }
            public System.Boolean? SubnetChangeProtection { get; set; }
            public List<Amazon.NetworkFirewall.Model.SubnetMapping> SubnetMapping { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.String TransitGatewayId { get; set; }
            public Amazon.NetworkFirewall.TransparentFilteringNatScope TransparentFilteringNatScope { get; set; }
            public List<Amazon.NetworkFirewall.Model.SubnetMapping> VpcEndpoint_SubnetMapping { get; set; }
            public System.String VpcEndpoint_VpcId { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateFirewallResponse, NewNWFWFirewallCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
