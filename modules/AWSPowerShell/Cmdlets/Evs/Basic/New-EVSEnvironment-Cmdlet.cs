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
using Amazon.Evs;
using Amazon.Evs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVS
{
    /// <summary>
    /// Creates an Amazon EVS environment that runs VCF software, such as SDDC Manager, NSX
    /// Manager, and vCenter Server.
    /// 
    ///  
    /// <para>
    /// During environment creation, Amazon EVS performs validations on DNS settings, provisions
    /// VLAN subnets and hosts, and deploys the supplied version of VCF.
    /// </para><para>
    /// It can take several hours to create an environment. After the deployment completes,
    /// you can configure VCF in the vSphere user interface according to your needs.
    /// </para><note><para>
    /// You cannot use the <c>dedicatedHostId</c> and <c>placementGroupId</c> parameters together
    /// in the same <c>CreateEnvironment</c> action. This results in a <c>ValidationException</c>
    /// response.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EVSEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Evs.Model.Environment")]
    [AWSCmdlet("Calls the Amazon Elastic VMware Service CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.Evs.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Evs.Model.Environment or Amazon.Evs.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.Evs.Model.Environment object.",
        "The service call response (type Amazon.Evs.Model.CreateEnvironmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEVSEnvironmentCmdlet : AmazonEvsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EdgeVTep_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_EdgeVTep_Cidr")]
        public System.String EdgeVTep_Cidr { get; set; }
        #endregion
        
        #region Parameter ExpansionVlan1_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_ExpansionVlan1_Cidr")]
        public System.String ExpansionVlan1_Cidr { get; set; }
        #endregion
        
        #region Parameter ExpansionVlan2_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_ExpansionVlan2_Cidr")]
        public System.String ExpansionVlan2_Cidr { get; set; }
        #endregion
        
        #region Parameter Hcx_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_Hcx_Cidr")]
        public System.String Hcx_Cidr { get; set; }
        #endregion
        
        #region Parameter NsxUplink_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_NsxUplink_Cidr")]
        public System.String NsxUplink_Cidr { get; set; }
        #endregion
        
        #region Parameter VmkManagement_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_VmkManagement_Cidr")]
        public System.String VmkManagement_Cidr { get; set; }
        #endregion
        
        #region Parameter VmManagement_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_VmManagement_Cidr")]
        public System.String VmManagement_Cidr { get; set; }
        #endregion
        
        #region Parameter VMotion_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_VMotion_Cidr")]
        public System.String VMotion_Cidr { get; set; }
        #endregion
        
        #region Parameter VSan_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_VSan_Cidr")]
        public System.String VSan_Cidr { get; set; }
        #endregion
        
        #region Parameter VTep_Cidr
        /// <summary>
        /// <para>
        /// <para> The CIDR block that you provide to create an Amazon EVS VLAN subnet. Amazon EVS VLAN
        /// subnets have a minimum CIDR block size of /28 and a maximum size of /24. Amazon EVS
        /// VLAN subnet CIDR blocks must not overlap with other subnets in the VPC.</para>
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
        [Alias("InitialVlans_VTep_Cidr")]
        public System.String VTep_Cidr { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_CloudBuilder
        /// <summary>
        /// <para>
        /// <para>The hostname for VMware Cloud Builder.</para>
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
        public System.String VcfHostnames_CloudBuilder { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name to give to your environment. The name can contain only alphanumeric characters
        /// (case-sensitive), hyphens, and underscores. It must start with an alphanumeric character,
        /// and can't be longer than 100 characters. The name must be unique within the Amazon
        /// Web Services Region and Amazon Web Services account that you're creating the environment
        /// in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter InitialVlans_HcxNetworkAclId
        /// <summary>
        /// <para>
        /// <para>A unique ID for a network access control list that the HCX VLAN uses. Required when
        /// <c>isHcxPublic</c> is set to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitialVlans_HcxNetworkAclId { get; set; }
        #endregion
        
        #region Parameter Hosts
        /// <summary>
        /// <para>
        /// <para>The ESXi hosts to add to the environment. Amazon EVS requires that you provide details
        /// for a minimum of 4 hosts during environment creation.</para><para>For each host, you must provide the desired hostname, EC2 SSH keypair name, and EC2
        /// instance type. Optionally, you can also provide a partition or cluster placement group
        /// to use, or use Amazon EC2 Dedicated Hosts.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Evs.Model.HostInfoForCreate[] Hosts { get; set; }
        #endregion
        
        #region Parameter InitialVlans_IsHcxPublic
        /// <summary>
        /// <para>
        /// <para>Determines if the HCX VLAN that Amazon EVS provisions is public or private.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InitialVlans_IsHcxPublic { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the customer-managed KMS key that is used to encrypt the VCF credential
        /// pairs for SDDC Manager, NSX Manager, and vCenter appliances. These credentials are
        /// stored in Amazon Web Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LicenseInfo
        /// <summary>
        /// <para>
        /// <para>The license information that Amazon EVS requires to create an environment. Amazon
        /// EVS requires two license keys: a VCF solution key and a vSAN license key. The VCF
        /// solution key must cover a minimum of 256 cores. The vSAN license key must provide
        /// at least 110 TiB of vSAN capacity.</para><para>VCF licenses can be used for only one Amazon EVS environment. Amazon EVS does not
        /// support reuse of VCF licenses for multiple environments.</para><para>VCF license information can be retrieved from the Broadcom portal.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Evs.Model.LicenseInfo[] LicenseInfo { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_Nsx
        /// <summary>
        /// <para>
        /// <para>The VMware NSX hostname.</para>
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
        public System.String VcfHostnames_Nsx { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_NsxEdge1
        /// <summary>
        /// <para>
        /// <para>The hostname for the first NSX Edge node.</para>
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
        public System.String VcfHostnames_NsxEdge1 { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_NsxEdge2
        /// <summary>
        /// <para>
        /// <para>The hostname for the second NSX Edge node.</para>
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
        public System.String VcfHostnames_NsxEdge2 { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_NsxManager1
        /// <summary>
        /// <para>
        /// <para>The hostname for the first VMware NSX Manager virtual machine (VM).</para>
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
        public System.String VcfHostnames_NsxManager1 { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_NsxManager2
        /// <summary>
        /// <para>
        /// <para>The hostname for the second VMware NSX Manager virtual machine (VM).</para>
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
        public System.String VcfHostnames_NsxManager2 { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_NsxManager3
        /// <summary>
        /// <para>
        /// <para>The hostname for the third VMware NSX Manager virtual machine (VM).</para>
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
        public System.String VcfHostnames_NsxManager3 { get; set; }
        #endregion
        
        #region Parameter ConnectivityInfo_PrivateRouteServerPeering
        /// <summary>
        /// <para>
        /// <para>The unique IDs for private route server peers.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ConnectivityInfo_PrivateRouteServerPeerings")]
        public System.String[] ConnectivityInfo_PrivateRouteServerPeering { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_SddcManager
        /// <summary>
        /// <para>
        /// <para>The hostname for SDDC Manager.</para>
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
        public System.String VcfHostnames_SddcManager { get; set; }
        #endregion
        
        #region Parameter ServiceAccessSecurityGroups_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups that allow service access.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceAccessSecurityGroups_SecurityGroups")]
        public System.String[] ServiceAccessSecurityGroups_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceAccessSubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet that is used to establish connectivity between the Amazon EVS control plane
        /// and VPC. Amazon EVS uses this subnet to validate mandatory DNS records for your VCF
        /// appliances and hosts and create the environment.</para>
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
        public System.String ServiceAccessSubnetId { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para>The Broadcom Site ID that is allocated to you as part of your electronic software
        /// delivery. This ID allows customer access to the Broadcom portal, and is provided to
        /// you by Broadcom at the close of your software contract or contract renewal. Amazon
        /// EVS uses the Broadcom Site ID that you provide to meet Broadcom VCF license usage
        /// reporting requirements for Amazon EVS.</para>
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
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Metadata that assists with categorization and organization. Each tag consists of a
        /// key and an optional value. You define both. Tags don't propagate to any other cluster
        /// or Amazon Web Services resources.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TermsAccepted
        /// <summary>
        /// <para>
        /// <para>Customer confirmation that the customer has purchased and will continue to maintain
        /// the required number of VCF software licenses to cover all physical processor cores
        /// in the Amazon EVS environment. Information about your VCF software in Amazon EVS will
        /// be shared with Broadcom to verify license compliance. Amazon EVS does not validate
        /// license keys. To validate license keys, visit the Broadcom support portal.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? TermsAccepted { get; set; }
        #endregion
        
        #region Parameter VcfHostnames_VCenter
        /// <summary>
        /// <para>
        /// <para>The VMware vCenter hostname.</para>
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
        public System.String VcfHostnames_VCenter { get; set; }
        #endregion
        
        #region Parameter VcfVersion
        /// <summary>
        /// <para>
        /// <para> The VCF version to use for the environment. Amazon EVS only supports VCF version
        /// 5.2.1 at this time.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Evs.VcfVersion")]
        public Amazon.Evs.VcfVersion VcfVersion { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the VPC that the environment is deployed inside.</para><para>Amazon EVS requires that all VPC subnets exist in a single Availability Zone in a
        /// Region where the service is available.</para><para>The VPC that you specify must have a valid DHCP option set with domain name, at least
        /// two DNS servers, and an NTP server. These settings are used to configure your VCF
        /// appliances and hosts. The VPC cannot be used with any other deployed Amazon EVS environment.
        /// Amazon EVS does not provide multi-VPC support for environments at this time.</para><para>Amazon EVS does not support the following Amazon Web Services networking options for
        /// NSX overlay connectivity: cross-Region VPC peering, Amazon S3 gateway endpoints, or
        /// Amazon Web Services Direct Connect virtual private gateway associations.</para><note><para>Ensure that you specify a VPC that is adequately sized to accommodate the {evws} subnets.</para></note>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para><note><para>This parameter is not used in Amazon EVS currently. If you supply input for this parameter,
        /// it will have no effect.</para></note><para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the environment creation request. If you do not specify a client token, a randomly
        /// generated token is used for the request to ensure idempotency.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Environment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Evs.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Evs.Model.CreateEnvironmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Environment";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVSEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Evs.Model.CreateEnvironmentResponse, NewEVSEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.ConnectivityInfo_PrivateRouteServerPeering != null)
            {
                context.ConnectivityInfo_PrivateRouteServerPeering = new List<System.String>(this.ConnectivityInfo_PrivateRouteServerPeering);
            }
            #if MODULAR
            if (this.ConnectivityInfo_PrivateRouteServerPeering == null && ParameterWasBound(nameof(this.ConnectivityInfo_PrivateRouteServerPeering)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectivityInfo_PrivateRouteServerPeering which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnvironmentName = this.EnvironmentName;
            if (this.Hosts != null)
            {
                context.Hosts = new List<Amazon.Evs.Model.HostInfoForCreate>(this.Hosts);
            }
            #if MODULAR
            if (this.Hosts == null && ParameterWasBound(nameof(this.Hosts)))
            {
                WriteWarning("You are passing $null as a value for parameter Hosts which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EdgeVTep_Cidr = this.EdgeVTep_Cidr;
            #if MODULAR
            if (this.EdgeVTep_Cidr == null && ParameterWasBound(nameof(this.EdgeVTep_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter EdgeVTep_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpansionVlan1_Cidr = this.ExpansionVlan1_Cidr;
            #if MODULAR
            if (this.ExpansionVlan1_Cidr == null && ParameterWasBound(nameof(this.ExpansionVlan1_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpansionVlan1_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpansionVlan2_Cidr = this.ExpansionVlan2_Cidr;
            #if MODULAR
            if (this.ExpansionVlan2_Cidr == null && ParameterWasBound(nameof(this.ExpansionVlan2_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpansionVlan2_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Hcx_Cidr = this.Hcx_Cidr;
            #if MODULAR
            if (this.Hcx_Cidr == null && ParameterWasBound(nameof(this.Hcx_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter Hcx_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InitialVlans_HcxNetworkAclId = this.InitialVlans_HcxNetworkAclId;
            context.InitialVlans_IsHcxPublic = this.InitialVlans_IsHcxPublic;
            context.NsxUplink_Cidr = this.NsxUplink_Cidr;
            #if MODULAR
            if (this.NsxUplink_Cidr == null && ParameterWasBound(nameof(this.NsxUplink_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter NsxUplink_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VmkManagement_Cidr = this.VmkManagement_Cidr;
            #if MODULAR
            if (this.VmkManagement_Cidr == null && ParameterWasBound(nameof(this.VmkManagement_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter VmkManagement_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VmManagement_Cidr = this.VmManagement_Cidr;
            #if MODULAR
            if (this.VmManagement_Cidr == null && ParameterWasBound(nameof(this.VmManagement_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter VmManagement_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VMotion_Cidr = this.VMotion_Cidr;
            #if MODULAR
            if (this.VMotion_Cidr == null && ParameterWasBound(nameof(this.VMotion_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter VMotion_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VSan_Cidr = this.VSan_Cidr;
            #if MODULAR
            if (this.VSan_Cidr == null && ParameterWasBound(nameof(this.VSan_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter VSan_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VTep_Cidr = this.VTep_Cidr;
            #if MODULAR
            if (this.VTep_Cidr == null && ParameterWasBound(nameof(this.VTep_Cidr)))
            {
                WriteWarning("You are passing $null as a value for parameter VTep_Cidr which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            if (this.LicenseInfo != null)
            {
                context.LicenseInfo = new List<Amazon.Evs.Model.LicenseInfo>(this.LicenseInfo);
            }
            #if MODULAR
            if (this.LicenseInfo == null && ParameterWasBound(nameof(this.LicenseInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ServiceAccessSecurityGroups_SecurityGroup != null)
            {
                context.ServiceAccessSecurityGroups_SecurityGroup = new List<System.String>(this.ServiceAccessSecurityGroups_SecurityGroup);
            }
            context.ServiceAccessSubnetId = this.ServiceAccessSubnetId;
            #if MODULAR
            if (this.ServiceAccessSubnetId == null && ParameterWasBound(nameof(this.ServiceAccessSubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceAccessSubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SiteId = this.SiteId;
            #if MODULAR
            if (this.SiteId == null && ParameterWasBound(nameof(this.SiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.TermsAccepted = this.TermsAccepted;
            #if MODULAR
            if (this.TermsAccepted == null && ParameterWasBound(nameof(this.TermsAccepted)))
            {
                WriteWarning("You are passing $null as a value for parameter TermsAccepted which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_CloudBuilder = this.VcfHostnames_CloudBuilder;
            #if MODULAR
            if (this.VcfHostnames_CloudBuilder == null && ParameterWasBound(nameof(this.VcfHostnames_CloudBuilder)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_CloudBuilder which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_Nsx = this.VcfHostnames_Nsx;
            #if MODULAR
            if (this.VcfHostnames_Nsx == null && ParameterWasBound(nameof(this.VcfHostnames_Nsx)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_Nsx which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_NsxEdge1 = this.VcfHostnames_NsxEdge1;
            #if MODULAR
            if (this.VcfHostnames_NsxEdge1 == null && ParameterWasBound(nameof(this.VcfHostnames_NsxEdge1)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_NsxEdge1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_NsxEdge2 = this.VcfHostnames_NsxEdge2;
            #if MODULAR
            if (this.VcfHostnames_NsxEdge2 == null && ParameterWasBound(nameof(this.VcfHostnames_NsxEdge2)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_NsxEdge2 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_NsxManager1 = this.VcfHostnames_NsxManager1;
            #if MODULAR
            if (this.VcfHostnames_NsxManager1 == null && ParameterWasBound(nameof(this.VcfHostnames_NsxManager1)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_NsxManager1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_NsxManager2 = this.VcfHostnames_NsxManager2;
            #if MODULAR
            if (this.VcfHostnames_NsxManager2 == null && ParameterWasBound(nameof(this.VcfHostnames_NsxManager2)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_NsxManager2 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_NsxManager3 = this.VcfHostnames_NsxManager3;
            #if MODULAR
            if (this.VcfHostnames_NsxManager3 == null && ParameterWasBound(nameof(this.VcfHostnames_NsxManager3)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_NsxManager3 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_SddcManager = this.VcfHostnames_SddcManager;
            #if MODULAR
            if (this.VcfHostnames_SddcManager == null && ParameterWasBound(nameof(this.VcfHostnames_SddcManager)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_SddcManager which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfHostnames_VCenter = this.VcfHostnames_VCenter;
            #if MODULAR
            if (this.VcfHostnames_VCenter == null && ParameterWasBound(nameof(this.VcfHostnames_VCenter)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfHostnames_VCenter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VcfVersion = this.VcfVersion;
            #if MODULAR
            if (this.VcfVersion == null && ParameterWasBound(nameof(this.VcfVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter VcfVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Evs.Model.CreateEnvironmentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectivityInfo
            var requestConnectivityInfoIsNull = true;
            request.ConnectivityInfo = new Amazon.Evs.Model.ConnectivityInfo();
            List<System.String> requestConnectivityInfo_connectivityInfo_PrivateRouteServerPeering = null;
            if (cmdletContext.ConnectivityInfo_PrivateRouteServerPeering != null)
            {
                requestConnectivityInfo_connectivityInfo_PrivateRouteServerPeering = cmdletContext.ConnectivityInfo_PrivateRouteServerPeering;
            }
            if (requestConnectivityInfo_connectivityInfo_PrivateRouteServerPeering != null)
            {
                request.ConnectivityInfo.PrivateRouteServerPeerings = requestConnectivityInfo_connectivityInfo_PrivateRouteServerPeering;
                requestConnectivityInfoIsNull = false;
            }
             // determine if request.ConnectivityInfo should be set to null
            if (requestConnectivityInfoIsNull)
            {
                request.ConnectivityInfo = null;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            if (cmdletContext.Hosts != null)
            {
                request.Hosts = cmdletContext.Hosts;
            }
            
             // populate InitialVlans
            var requestInitialVlansIsNull = true;
            request.InitialVlans = new Amazon.Evs.Model.InitialVlans();
            System.String requestInitialVlans_initialVlans_HcxNetworkAclId = null;
            if (cmdletContext.InitialVlans_HcxNetworkAclId != null)
            {
                requestInitialVlans_initialVlans_HcxNetworkAclId = cmdletContext.InitialVlans_HcxNetworkAclId;
            }
            if (requestInitialVlans_initialVlans_HcxNetworkAclId != null)
            {
                request.InitialVlans.HcxNetworkAclId = requestInitialVlans_initialVlans_HcxNetworkAclId;
                requestInitialVlansIsNull = false;
            }
            System.Boolean? requestInitialVlans_initialVlans_IsHcxPublic = null;
            if (cmdletContext.InitialVlans_IsHcxPublic != null)
            {
                requestInitialVlans_initialVlans_IsHcxPublic = cmdletContext.InitialVlans_IsHcxPublic.Value;
            }
            if (requestInitialVlans_initialVlans_IsHcxPublic != null)
            {
                request.InitialVlans.IsHcxPublic = requestInitialVlans_initialVlans_IsHcxPublic.Value;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_EdgeVTep = null;
            
             // populate EdgeVTep
            var requestInitialVlans_initialVlans_EdgeVTepIsNull = true;
            requestInitialVlans_initialVlans_EdgeVTep = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_EdgeVTep_edgeVTep_Cidr = null;
            if (cmdletContext.EdgeVTep_Cidr != null)
            {
                requestInitialVlans_initialVlans_EdgeVTep_edgeVTep_Cidr = cmdletContext.EdgeVTep_Cidr;
            }
            if (requestInitialVlans_initialVlans_EdgeVTep_edgeVTep_Cidr != null)
            {
                requestInitialVlans_initialVlans_EdgeVTep.Cidr = requestInitialVlans_initialVlans_EdgeVTep_edgeVTep_Cidr;
                requestInitialVlans_initialVlans_EdgeVTepIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_EdgeVTep should be set to null
            if (requestInitialVlans_initialVlans_EdgeVTepIsNull)
            {
                requestInitialVlans_initialVlans_EdgeVTep = null;
            }
            if (requestInitialVlans_initialVlans_EdgeVTep != null)
            {
                request.InitialVlans.EdgeVTep = requestInitialVlans_initialVlans_EdgeVTep;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_ExpansionVlan1 = null;
            
             // populate ExpansionVlan1
            var requestInitialVlans_initialVlans_ExpansionVlan1IsNull = true;
            requestInitialVlans_initialVlans_ExpansionVlan1 = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_ExpansionVlan1_expansionVlan1_Cidr = null;
            if (cmdletContext.ExpansionVlan1_Cidr != null)
            {
                requestInitialVlans_initialVlans_ExpansionVlan1_expansionVlan1_Cidr = cmdletContext.ExpansionVlan1_Cidr;
            }
            if (requestInitialVlans_initialVlans_ExpansionVlan1_expansionVlan1_Cidr != null)
            {
                requestInitialVlans_initialVlans_ExpansionVlan1.Cidr = requestInitialVlans_initialVlans_ExpansionVlan1_expansionVlan1_Cidr;
                requestInitialVlans_initialVlans_ExpansionVlan1IsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_ExpansionVlan1 should be set to null
            if (requestInitialVlans_initialVlans_ExpansionVlan1IsNull)
            {
                requestInitialVlans_initialVlans_ExpansionVlan1 = null;
            }
            if (requestInitialVlans_initialVlans_ExpansionVlan1 != null)
            {
                request.InitialVlans.ExpansionVlan1 = requestInitialVlans_initialVlans_ExpansionVlan1;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_ExpansionVlan2 = null;
            
             // populate ExpansionVlan2
            var requestInitialVlans_initialVlans_ExpansionVlan2IsNull = true;
            requestInitialVlans_initialVlans_ExpansionVlan2 = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_ExpansionVlan2_expansionVlan2_Cidr = null;
            if (cmdletContext.ExpansionVlan2_Cidr != null)
            {
                requestInitialVlans_initialVlans_ExpansionVlan2_expansionVlan2_Cidr = cmdletContext.ExpansionVlan2_Cidr;
            }
            if (requestInitialVlans_initialVlans_ExpansionVlan2_expansionVlan2_Cidr != null)
            {
                requestInitialVlans_initialVlans_ExpansionVlan2.Cidr = requestInitialVlans_initialVlans_ExpansionVlan2_expansionVlan2_Cidr;
                requestInitialVlans_initialVlans_ExpansionVlan2IsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_ExpansionVlan2 should be set to null
            if (requestInitialVlans_initialVlans_ExpansionVlan2IsNull)
            {
                requestInitialVlans_initialVlans_ExpansionVlan2 = null;
            }
            if (requestInitialVlans_initialVlans_ExpansionVlan2 != null)
            {
                request.InitialVlans.ExpansionVlan2 = requestInitialVlans_initialVlans_ExpansionVlan2;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_Hcx = null;
            
             // populate Hcx
            var requestInitialVlans_initialVlans_HcxIsNull = true;
            requestInitialVlans_initialVlans_Hcx = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_Hcx_hcx_Cidr = null;
            if (cmdletContext.Hcx_Cidr != null)
            {
                requestInitialVlans_initialVlans_Hcx_hcx_Cidr = cmdletContext.Hcx_Cidr;
            }
            if (requestInitialVlans_initialVlans_Hcx_hcx_Cidr != null)
            {
                requestInitialVlans_initialVlans_Hcx.Cidr = requestInitialVlans_initialVlans_Hcx_hcx_Cidr;
                requestInitialVlans_initialVlans_HcxIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_Hcx should be set to null
            if (requestInitialVlans_initialVlans_HcxIsNull)
            {
                requestInitialVlans_initialVlans_Hcx = null;
            }
            if (requestInitialVlans_initialVlans_Hcx != null)
            {
                request.InitialVlans.Hcx = requestInitialVlans_initialVlans_Hcx;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_NsxUplink = null;
            
             // populate NsxUplink
            var requestInitialVlans_initialVlans_NsxUplinkIsNull = true;
            requestInitialVlans_initialVlans_NsxUplink = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_NsxUplink_nsxUplink_Cidr = null;
            if (cmdletContext.NsxUplink_Cidr != null)
            {
                requestInitialVlans_initialVlans_NsxUplink_nsxUplink_Cidr = cmdletContext.NsxUplink_Cidr;
            }
            if (requestInitialVlans_initialVlans_NsxUplink_nsxUplink_Cidr != null)
            {
                requestInitialVlans_initialVlans_NsxUplink.Cidr = requestInitialVlans_initialVlans_NsxUplink_nsxUplink_Cidr;
                requestInitialVlans_initialVlans_NsxUplinkIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_NsxUplink should be set to null
            if (requestInitialVlans_initialVlans_NsxUplinkIsNull)
            {
                requestInitialVlans_initialVlans_NsxUplink = null;
            }
            if (requestInitialVlans_initialVlans_NsxUplink != null)
            {
                request.InitialVlans.NsxUplink = requestInitialVlans_initialVlans_NsxUplink;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_VmkManagement = null;
            
             // populate VmkManagement
            var requestInitialVlans_initialVlans_VmkManagementIsNull = true;
            requestInitialVlans_initialVlans_VmkManagement = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_VmkManagement_vmkManagement_Cidr = null;
            if (cmdletContext.VmkManagement_Cidr != null)
            {
                requestInitialVlans_initialVlans_VmkManagement_vmkManagement_Cidr = cmdletContext.VmkManagement_Cidr;
            }
            if (requestInitialVlans_initialVlans_VmkManagement_vmkManagement_Cidr != null)
            {
                requestInitialVlans_initialVlans_VmkManagement.Cidr = requestInitialVlans_initialVlans_VmkManagement_vmkManagement_Cidr;
                requestInitialVlans_initialVlans_VmkManagementIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_VmkManagement should be set to null
            if (requestInitialVlans_initialVlans_VmkManagementIsNull)
            {
                requestInitialVlans_initialVlans_VmkManagement = null;
            }
            if (requestInitialVlans_initialVlans_VmkManagement != null)
            {
                request.InitialVlans.VmkManagement = requestInitialVlans_initialVlans_VmkManagement;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_VmManagement = null;
            
             // populate VmManagement
            var requestInitialVlans_initialVlans_VmManagementIsNull = true;
            requestInitialVlans_initialVlans_VmManagement = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_VmManagement_vmManagement_Cidr = null;
            if (cmdletContext.VmManagement_Cidr != null)
            {
                requestInitialVlans_initialVlans_VmManagement_vmManagement_Cidr = cmdletContext.VmManagement_Cidr;
            }
            if (requestInitialVlans_initialVlans_VmManagement_vmManagement_Cidr != null)
            {
                requestInitialVlans_initialVlans_VmManagement.Cidr = requestInitialVlans_initialVlans_VmManagement_vmManagement_Cidr;
                requestInitialVlans_initialVlans_VmManagementIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_VmManagement should be set to null
            if (requestInitialVlans_initialVlans_VmManagementIsNull)
            {
                requestInitialVlans_initialVlans_VmManagement = null;
            }
            if (requestInitialVlans_initialVlans_VmManagement != null)
            {
                request.InitialVlans.VmManagement = requestInitialVlans_initialVlans_VmManagement;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_VMotion = null;
            
             // populate VMotion
            var requestInitialVlans_initialVlans_VMotionIsNull = true;
            requestInitialVlans_initialVlans_VMotion = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_VMotion_vMotion_Cidr = null;
            if (cmdletContext.VMotion_Cidr != null)
            {
                requestInitialVlans_initialVlans_VMotion_vMotion_Cidr = cmdletContext.VMotion_Cidr;
            }
            if (requestInitialVlans_initialVlans_VMotion_vMotion_Cidr != null)
            {
                requestInitialVlans_initialVlans_VMotion.Cidr = requestInitialVlans_initialVlans_VMotion_vMotion_Cidr;
                requestInitialVlans_initialVlans_VMotionIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_VMotion should be set to null
            if (requestInitialVlans_initialVlans_VMotionIsNull)
            {
                requestInitialVlans_initialVlans_VMotion = null;
            }
            if (requestInitialVlans_initialVlans_VMotion != null)
            {
                request.InitialVlans.VMotion = requestInitialVlans_initialVlans_VMotion;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_VSan = null;
            
             // populate VSan
            var requestInitialVlans_initialVlans_VSanIsNull = true;
            requestInitialVlans_initialVlans_VSan = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_VSan_vSan_Cidr = null;
            if (cmdletContext.VSan_Cidr != null)
            {
                requestInitialVlans_initialVlans_VSan_vSan_Cidr = cmdletContext.VSan_Cidr;
            }
            if (requestInitialVlans_initialVlans_VSan_vSan_Cidr != null)
            {
                requestInitialVlans_initialVlans_VSan.Cidr = requestInitialVlans_initialVlans_VSan_vSan_Cidr;
                requestInitialVlans_initialVlans_VSanIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_VSan should be set to null
            if (requestInitialVlans_initialVlans_VSanIsNull)
            {
                requestInitialVlans_initialVlans_VSan = null;
            }
            if (requestInitialVlans_initialVlans_VSan != null)
            {
                request.InitialVlans.VSan = requestInitialVlans_initialVlans_VSan;
                requestInitialVlansIsNull = false;
            }
            Amazon.Evs.Model.InitialVlanInfo requestInitialVlans_initialVlans_VTep = null;
            
             // populate VTep
            var requestInitialVlans_initialVlans_VTepIsNull = true;
            requestInitialVlans_initialVlans_VTep = new Amazon.Evs.Model.InitialVlanInfo();
            System.String requestInitialVlans_initialVlans_VTep_vTep_Cidr = null;
            if (cmdletContext.VTep_Cidr != null)
            {
                requestInitialVlans_initialVlans_VTep_vTep_Cidr = cmdletContext.VTep_Cidr;
            }
            if (requestInitialVlans_initialVlans_VTep_vTep_Cidr != null)
            {
                requestInitialVlans_initialVlans_VTep.Cidr = requestInitialVlans_initialVlans_VTep_vTep_Cidr;
                requestInitialVlans_initialVlans_VTepIsNull = false;
            }
             // determine if requestInitialVlans_initialVlans_VTep should be set to null
            if (requestInitialVlans_initialVlans_VTepIsNull)
            {
                requestInitialVlans_initialVlans_VTep = null;
            }
            if (requestInitialVlans_initialVlans_VTep != null)
            {
                request.InitialVlans.VTep = requestInitialVlans_initialVlans_VTep;
                requestInitialVlansIsNull = false;
            }
             // determine if request.InitialVlans should be set to null
            if (requestInitialVlansIsNull)
            {
                request.InitialVlans = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LicenseInfo != null)
            {
                request.LicenseInfo = cmdletContext.LicenseInfo;
            }
            
             // populate ServiceAccessSecurityGroups
            var requestServiceAccessSecurityGroupsIsNull = true;
            request.ServiceAccessSecurityGroups = new Amazon.Evs.Model.ServiceAccessSecurityGroups();
            List<System.String> requestServiceAccessSecurityGroups_serviceAccessSecurityGroups_SecurityGroup = null;
            if (cmdletContext.ServiceAccessSecurityGroups_SecurityGroup != null)
            {
                requestServiceAccessSecurityGroups_serviceAccessSecurityGroups_SecurityGroup = cmdletContext.ServiceAccessSecurityGroups_SecurityGroup;
            }
            if (requestServiceAccessSecurityGroups_serviceAccessSecurityGroups_SecurityGroup != null)
            {
                request.ServiceAccessSecurityGroups.SecurityGroups = requestServiceAccessSecurityGroups_serviceAccessSecurityGroups_SecurityGroup;
                requestServiceAccessSecurityGroupsIsNull = false;
            }
             // determine if request.ServiceAccessSecurityGroups should be set to null
            if (requestServiceAccessSecurityGroupsIsNull)
            {
                request.ServiceAccessSecurityGroups = null;
            }
            if (cmdletContext.ServiceAccessSubnetId != null)
            {
                request.ServiceAccessSubnetId = cmdletContext.ServiceAccessSubnetId;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TermsAccepted != null)
            {
                request.TermsAccepted = cmdletContext.TermsAccepted.Value;
            }
            
             // populate VcfHostnames
            var requestVcfHostnamesIsNull = true;
            request.VcfHostnames = new Amazon.Evs.Model.VcfHostnames();
            System.String requestVcfHostnames_vcfHostnames_CloudBuilder = null;
            if (cmdletContext.VcfHostnames_CloudBuilder != null)
            {
                requestVcfHostnames_vcfHostnames_CloudBuilder = cmdletContext.VcfHostnames_CloudBuilder;
            }
            if (requestVcfHostnames_vcfHostnames_CloudBuilder != null)
            {
                request.VcfHostnames.CloudBuilder = requestVcfHostnames_vcfHostnames_CloudBuilder;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_Nsx = null;
            if (cmdletContext.VcfHostnames_Nsx != null)
            {
                requestVcfHostnames_vcfHostnames_Nsx = cmdletContext.VcfHostnames_Nsx;
            }
            if (requestVcfHostnames_vcfHostnames_Nsx != null)
            {
                request.VcfHostnames.Nsx = requestVcfHostnames_vcfHostnames_Nsx;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_NsxEdge1 = null;
            if (cmdletContext.VcfHostnames_NsxEdge1 != null)
            {
                requestVcfHostnames_vcfHostnames_NsxEdge1 = cmdletContext.VcfHostnames_NsxEdge1;
            }
            if (requestVcfHostnames_vcfHostnames_NsxEdge1 != null)
            {
                request.VcfHostnames.NsxEdge1 = requestVcfHostnames_vcfHostnames_NsxEdge1;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_NsxEdge2 = null;
            if (cmdletContext.VcfHostnames_NsxEdge2 != null)
            {
                requestVcfHostnames_vcfHostnames_NsxEdge2 = cmdletContext.VcfHostnames_NsxEdge2;
            }
            if (requestVcfHostnames_vcfHostnames_NsxEdge2 != null)
            {
                request.VcfHostnames.NsxEdge2 = requestVcfHostnames_vcfHostnames_NsxEdge2;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_NsxManager1 = null;
            if (cmdletContext.VcfHostnames_NsxManager1 != null)
            {
                requestVcfHostnames_vcfHostnames_NsxManager1 = cmdletContext.VcfHostnames_NsxManager1;
            }
            if (requestVcfHostnames_vcfHostnames_NsxManager1 != null)
            {
                request.VcfHostnames.NsxManager1 = requestVcfHostnames_vcfHostnames_NsxManager1;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_NsxManager2 = null;
            if (cmdletContext.VcfHostnames_NsxManager2 != null)
            {
                requestVcfHostnames_vcfHostnames_NsxManager2 = cmdletContext.VcfHostnames_NsxManager2;
            }
            if (requestVcfHostnames_vcfHostnames_NsxManager2 != null)
            {
                request.VcfHostnames.NsxManager2 = requestVcfHostnames_vcfHostnames_NsxManager2;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_NsxManager3 = null;
            if (cmdletContext.VcfHostnames_NsxManager3 != null)
            {
                requestVcfHostnames_vcfHostnames_NsxManager3 = cmdletContext.VcfHostnames_NsxManager3;
            }
            if (requestVcfHostnames_vcfHostnames_NsxManager3 != null)
            {
                request.VcfHostnames.NsxManager3 = requestVcfHostnames_vcfHostnames_NsxManager3;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_SddcManager = null;
            if (cmdletContext.VcfHostnames_SddcManager != null)
            {
                requestVcfHostnames_vcfHostnames_SddcManager = cmdletContext.VcfHostnames_SddcManager;
            }
            if (requestVcfHostnames_vcfHostnames_SddcManager != null)
            {
                request.VcfHostnames.SddcManager = requestVcfHostnames_vcfHostnames_SddcManager;
                requestVcfHostnamesIsNull = false;
            }
            System.String requestVcfHostnames_vcfHostnames_VCenter = null;
            if (cmdletContext.VcfHostnames_VCenter != null)
            {
                requestVcfHostnames_vcfHostnames_VCenter = cmdletContext.VcfHostnames_VCenter;
            }
            if (requestVcfHostnames_vcfHostnames_VCenter != null)
            {
                request.VcfHostnames.VCenter = requestVcfHostnames_vcfHostnames_VCenter;
                requestVcfHostnamesIsNull = false;
            }
             // determine if request.VcfHostnames should be set to null
            if (requestVcfHostnamesIsNull)
            {
                request.VcfHostnames = null;
            }
            if (cmdletContext.VcfVersion != null)
            {
                request.VcfVersion = cmdletContext.VcfVersion;
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
        
        private Amazon.Evs.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonEvs client, Amazon.Evs.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic VMware Service", "CreateEnvironment");
            try
            {
                return client.CreateEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ConnectivityInfo_PrivateRouteServerPeering { get; set; }
            public System.String EnvironmentName { get; set; }
            public List<Amazon.Evs.Model.HostInfoForCreate> Hosts { get; set; }
            public System.String EdgeVTep_Cidr { get; set; }
            public System.String ExpansionVlan1_Cidr { get; set; }
            public System.String ExpansionVlan2_Cidr { get; set; }
            public System.String Hcx_Cidr { get; set; }
            public System.String InitialVlans_HcxNetworkAclId { get; set; }
            public System.Boolean? InitialVlans_IsHcxPublic { get; set; }
            public System.String NsxUplink_Cidr { get; set; }
            public System.String VmkManagement_Cidr { get; set; }
            public System.String VmManagement_Cidr { get; set; }
            public System.String VMotion_Cidr { get; set; }
            public System.String VSan_Cidr { get; set; }
            public System.String VTep_Cidr { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<Amazon.Evs.Model.LicenseInfo> LicenseInfo { get; set; }
            public List<System.String> ServiceAccessSecurityGroups_SecurityGroup { get; set; }
            public System.String ServiceAccessSubnetId { get; set; }
            public System.String SiteId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? TermsAccepted { get; set; }
            public System.String VcfHostnames_CloudBuilder { get; set; }
            public System.String VcfHostnames_Nsx { get; set; }
            public System.String VcfHostnames_NsxEdge1 { get; set; }
            public System.String VcfHostnames_NsxEdge2 { get; set; }
            public System.String VcfHostnames_NsxManager1 { get; set; }
            public System.String VcfHostnames_NsxManager2 { get; set; }
            public System.String VcfHostnames_NsxManager3 { get; set; }
            public System.String VcfHostnames_SddcManager { get; set; }
            public System.String VcfHostnames_VCenter { get; set; }
            public Amazon.Evs.VcfVersion VcfVersion { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.Evs.Model.CreateEnvironmentResponse, NewEVSEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Environment;
        }
        
    }
}
