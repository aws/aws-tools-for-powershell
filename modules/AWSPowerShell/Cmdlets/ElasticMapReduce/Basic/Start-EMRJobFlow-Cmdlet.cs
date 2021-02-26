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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// RunJobFlow creates and starts running a new cluster (job flow). The cluster runs the
    /// steps specified. After the steps complete, the cluster stops and the HDFS partition
    /// is lost. To prevent loss of data, configure the last step of the job flow to store
    /// results in Amazon S3. If the <a>JobFlowInstancesConfig</a><code>KeepJobFlowAliveWhenNoSteps</code>
    /// parameter is set to <code>TRUE</code>, the cluster transitions to the WAITING state
    /// rather than shutting down after the steps have completed. 
    /// 
    ///  
    /// <para>
    /// For additional protection, you can set the <a>JobFlowInstancesConfig</a><code>TerminationProtected</code>
    /// parameter to <code>TRUE</code> to lock the cluster and prevent it from being terminated
    /// by API call, user intervention, or in the event of a job flow error.
    /// </para><para>
    /// A maximum of 256 steps are allowed in each job flow.
    /// </para><para>
    /// If your cluster is long-running (such as a Hive data warehouse) or complex, you may
    /// require more than 256 steps to process your data. You can bypass the 256-step limitation
    /// in various ways, including using the SSH shell to connect to the master node and submitting
    /// queries directly to the software running on the master node, such as Hive and Hadoop.
    /// For more information on how to do this, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/AddMoreThan256Steps.html">Add
    /// More than 256 Steps to a Cluster</a> in the <i>Amazon EMR Management Guide</i>.
    /// </para><para>
    /// For long running clusters, we recommend that you periodically store your results.
    /// </para><note><para>
    /// The instance fleets configuration is available only in Amazon EMR versions 4.8.0 and
    /// later, excluding 5.0.x versions. The RunJobFlow request can contain InstanceFleets
    /// parameters or InstanceGroups parameters, but not both.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "EMRJobFlow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce RunJobFlow API operation.", Operation = new[] {"RunJobFlow"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.RunJobFlowResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElasticMapReduce.Model.RunJobFlowResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ElasticMapReduce.Model.RunJobFlowResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartEMRJobFlowCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>A JSON string for selecting additional features.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter Instances_AdditionalMasterSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of additional Amazon EC2 security group IDs for the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Instances_AdditionalMasterSecurityGroups")]
        public System.String[] Instances_AdditionalMasterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Instances_AdditionalSlaveSecurityGroup
        /// <summary>
        /// <para>
        /// <para>A list of additional Amazon EC2 security group IDs for the core and task nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Instances_AdditionalSlaveSecurityGroups")]
        public System.String[] Instances_AdditionalSlaveSecurityGroup { get; set; }
        #endregion
        
        #region Parameter KerberosAttributes_ADDomainJoinPassword
        /// <summary>
        /// <para>
        /// <para>The Active Directory password for <code>ADDomainJoinUser</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAttributes_ADDomainJoinPassword { get; set; }
        #endregion
        
        #region Parameter KerberosAttributes_ADDomainJoinUser
        /// <summary>
        /// <para>
        /// <para>Required only when establishing a cross-realm trust with an Active Directory domain.
        /// A user with sufficient privileges to join resources to the domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAttributes_ADDomainJoinUser { get; set; }
        #endregion
        
        #region Parameter AmiVersion
        /// <summary>
        /// <para>
        /// <para>Applies only to Amazon EMR AMI versions 3.x and 2.x. For Amazon EMR releases 4.0 and
        /// later, <code>ReleaseLabel</code> is used. To specify a custom AMI, use <code>CustomAmiID</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AmiVersion { get; set; }
        #endregion
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>Applies to Amazon EMR releases 4.0 and later. A case-insensitive list of applications
        /// for Amazon EMR to install and configure when launching the cluster. For a list of
        /// applications available for each Amazon EMR release version, see the <a href="https://docs.aws.amazon.com/emr/latest/ReleaseGuide/">Amazon
        /// EMR Release Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public Amazon.ElasticMapReduce.Model.Application[] Application { get; set; }
        #endregion
        
        #region Parameter AutoScalingRole
        /// <summary>
        /// <para>
        /// <para>An IAM role for automatic scaling policies. The default role is <code>EMR_AutoScaling_DefaultRole</code>.
        /// The IAM role provides permissions that the automatic scaling feature requires to launch
        /// and terminate EC2 instances in an instance group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AutoScalingRole { get; set; }
        #endregion
        
        #region Parameter Instances_Placement_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 Availability Zone for the cluster. <code>AvailabilityZone</code> is
        /// used for uniform instance groups, while <code>AvailabilityZones</code> (plural) is
        /// used for instance fleets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_Placement_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Instances_Placement_AvailabilityZones
        /// <summary>
        /// <para>
        /// <para>When multiple Availability Zones are specified, Amazon EMR evaluates them and launches
        /// instances in the optimal Availability Zone. <code>AvailabilityZones</code> is used
        /// for instance fleets, while <code>AvailabilityZone</code> (singular) is used for uniform
        /// instance groups.</para><note><para>The instance fleet configuration is available only in Amazon EMR versions 4.8.0 and
        /// later, excluding 5.0.x versions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Instances_Placement_AvailabilityZones { get; set; }
        #endregion
        
        #region Parameter BootstrapAction
        /// <summary>
        /// <para>
        /// <para>A list of bootstrap actions to run before Hadoop starts on the cluster nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BootstrapActions")]
        public Amazon.ElasticMapReduce.Model.BootstrapActionConfig[] BootstrapAction { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// <para>For Amazon EMR releases 4.0 and later. The list of configurations supplied for the
        /// EMR cluster you are creating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configurations")]
        public Amazon.ElasticMapReduce.Model.Configuration[] Configuration { get; set; }
        #endregion
        
        #region Parameter KerberosAttributes_CrossRealmTrustPrincipalPassword
        /// <summary>
        /// <para>
        /// <para>Required only when establishing a cross-realm trust with a KDC in a different realm.
        /// The cross-realm principal password, which must be identical across realms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAttributes_CrossRealmTrustPrincipalPassword { get; set; }
        #endregion
        
        #region Parameter CustomAmiId
        /// <summary>
        /// <para>
        /// <para>Available only in Amazon EMR version 5.7.0 and later. The ID of a custom Amazon EBS-backed
        /// Linux AMI. If specified, Amazon EMR uses this AMI when it launches cluster EC2 instances.
        /// For more information about custom AMIs in Amazon EMR, see <a href="https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-custom-ami.html">Using
        /// a Custom AMI</a> in the <i>Amazon EMR Management Guide</i>. If omitted, the cluster
        /// uses the base Linux AMI for the <code>ReleaseLabel</code> specified. For Amazon EMR
        /// versions 2.x and 3.x, use <code>AmiVersion</code> instead.</para><para>For information about creating a custom AMI, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-ebs.html">Creating
        /// an Amazon EBS-Backed Linux AMI</a> in the <i>Amazon Elastic Compute Cloud User Guide
        /// for Linux Instances</i>. For information about finding an AMI ID, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/finding-an-ami.html">Finding
        /// a Linux AMI</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomAmiId { get; set; }
        #endregion
        
        #region Parameter EbsRootVolumeSize
        /// <summary>
        /// <para>
        /// <para>The size, in GiB, of the Amazon EBS root device volume of the Linux AMI that is used
        /// for each EC2 instance. Available in Amazon EMR version 4.x and later.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? EbsRootVolumeSize { get; set; }
        #endregion
        
        #region Parameter Instances_Ec2KeyName
        /// <summary>
        /// <para>
        /// <para>The name of the EC2 key pair that can be used to connect to the master node using
        /// SSH as the user called "hadoop."</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_Ec2KeyName { get; set; }
        #endregion
        
        #region Parameter Instances_Ec2SubnetId
        /// <summary>
        /// <para>
        /// <para>Applies to clusters that use the uniform instance group configuration. To launch the
        /// cluster in Amazon Virtual Private Cloud (Amazon VPC), set this parameter to the identifier
        /// of the Amazon VPC subnet where you want the cluster to launch. If you do not specify
        /// this value and your account supports EC2-Classic, the cluster launches in EC2-Classic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_Ec2SubnetId { get; set; }
        #endregion
        
        #region Parameter Instances_Ec2SubnetIds
        /// <summary>
        /// <para>
        /// <para>Applies to clusters that use the instance fleet configuration. When multiple EC2 subnet
        /// IDs are specified, Amazon EMR evaluates them and launches instances in the optimal
        /// subnet.</para><note><para>The instance fleet configuration is available only in Amazon EMR versions 4.8.0 and
        /// later, excluding 5.0.x versions.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Instances_Ec2SubnetIds { get; set; }
        #endregion
        
        #region Parameter Instances_EmrManagedMasterSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon EC2 security group for the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_EmrManagedMasterSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Instances_EmrManagedSlaveSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon EC2 security group for the core and task nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_EmrManagedSlaveSecurityGroup { get; set; }
        #endregion
        
        #region Parameter Instances_HadoopVersion
        /// <summary>
        /// <para>
        /// <para>Applies only to Amazon EMR release versions earlier than 4.0. The Hadoop version for
        /// the cluster. Valid inputs are "0.18" (no longer maintained), "0.20" (no longer maintained),
        /// "0.20.205" (no longer maintained), "1.0.3", "2.2.0", or "2.4.0". If you do not set
        /// this value, the default of 0.18 is used, unless the <code>AmiVersion</code> parameter
        /// is set in the RunJobFlow call, in which case the default version of Hadoop for that
        /// AMI version is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_HadoopVersion { get; set; }
        #endregion
        
        #region Parameter Instances_InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of EC2 instances in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Instances_InstanceCount { get; set; }
        #endregion
        
        #region Parameter Instances_InstanceFleet
        /// <summary>
        /// <para>
        /// <note><para>The instance fleet configuration is available only in Amazon EMR versions 4.8.0 and
        /// later, excluding 5.0.x versions.</para></note><para>Describes the EC2 instances and instance configurations for clusters that use the
        /// instance fleet configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Instances_InstanceFleets")]
        public Amazon.ElasticMapReduce.Model.InstanceFleetConfig[] Instances_InstanceFleet { get; set; }
        #endregion
        
        #region Parameter Instances_InstanceGroup
        /// <summary>
        /// <para>
        /// <para>Configuration for the instance groups in a cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Instances_InstanceGroups")]
        public Amazon.ElasticMapReduce.Model.InstanceGroupConfig[] Instances_InstanceGroup { get; set; }
        #endregion
        
        #region Parameter JobFlowRole
        /// <summary>
        /// <para>
        /// <para>Also called instance profile and EC2 role. An IAM role for an EMR cluster. The EC2
        /// instances of the cluster assume this role. The default role is <code>EMR_EC2_DefaultRole</code>.
        /// In order to use the default role, you must have already created it using the CLI or
        /// console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobFlowRole { get; set; }
        #endregion
        
        #region Parameter KerberosAttributes_KdcAdminPassword
        /// <summary>
        /// <para>
        /// <para>The password used within the cluster for the kadmin service on the cluster-dedicated
        /// KDC, which maintains Kerberos principals, password policies, and keytabs for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAttributes_KdcAdminPassword { get; set; }
        #endregion
        
        #region Parameter Instances_KeepJobFlowAliveWhenNoStep
        /// <summary>
        /// <para>
        /// <para>Specifies whether the cluster should remain available after completing all steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Instances_KeepJobFlowAliveWhenNoSteps")]
        public System.Boolean? Instances_KeepJobFlowAliveWhenNoStep { get; set; }
        #endregion
        
        #region Parameter LogEncryptionKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS customer master key (CMK) used for encrypting log files. If a value is
        /// not provided, the logs remain encrypted by AES-256. This attribute is only available
        /// with Amazon EMR version 5.30.0 and later, excluding Amazon EMR 6.0.0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogEncryptionKmsKeyId { get; set; }
        #endregion
        
        #region Parameter LogUri
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 to write the log files of the job flow. If a value is not
        /// provided, logs are not created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String LogUri { get; set; }
        #endregion
        
        #region Parameter Instances_MasterInstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type of the master node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_MasterInstanceType { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of EC2 units. It is measured through vCPU cores or instances for
        /// instance groups and measured through units for instance fleets. Managed scaling activities
        /// are not allowed beyond this boundary. The limit only applies to the core and task
        /// nodes. The master node cannot be scaled after initial configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumCoreCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of EC2 units for core node type in a cluster. It is measured through
        /// vCPU cores or instances for instance groups and measured through units for instance
        /// fleets. The core units are not allowed to scale beyond this boundary. The parameter
        /// is used to split capacity allocation between core and task nodes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumCoreCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumCoreCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MaximumOnDemandCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The upper boundary of On-Demand EC2 units. It is measured through vCPU cores or instances
        /// for instance groups and measured through units for instance fleets. The On-Demand
        /// units are not allowed to scale beyond this boundary. The parameter is used to split
        /// capacity allocation between On-Demand and Spot Instances. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MaximumOnDemandCapacityUnits")]
        public System.Int32? ComputeLimits_MaximumOnDemandCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_MinimumCapacityUnit
        /// <summary>
        /// <para>
        /// <para> The lower boundary of EC2 units. It is measured through vCPU cores or instances for
        /// instance groups and measured through units for instance fleets. Managed scaling activities
        /// are not allowed beyond this boundary. The limit only applies to the core and task
        /// nodes. The master node cannot be scaled after initial configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_MinimumCapacityUnits")]
        public System.Int32? ComputeLimits_MinimumCapacityUnit { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the job flow.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NewSupportedProduct
        /// <summary>
        /// <para>
        /// <note><para>For Amazon EMR releases 3.x and 2.x. For Amazon EMR releases 4.x and later, use Applications.</para></note><para>A list of strings that indicates third-party software to use with the job flow that
        /// accepts a user argument list. EMR accepts and forwards the argument list to the corresponding
        /// installation script as bootstrap action arguments. For more information, see "Launch
        /// a Job Flow on the MapR Distribution for Hadoop" in the <a href="https://docs.aws.amazon.com/emr/latest/DeveloperGuide/emr-dg.pdf">Amazon
        /// EMR Developer Guide</a>. Supported values are:</para><ul><li><para>"mapr-m3" - launch the cluster using MapR M3 Edition.</para></li><li><para>"mapr-m5" - launch the cluster using MapR M5 Edition.</para></li><li><para>"mapr" with the user arguments specifying "--edition,m3" or "--edition,m5" - launch
        /// the job flow using MapR M3 or M5 Edition respectively.</para></li><li><para>"mapr-m7" - launch the cluster using MapR M7 Edition.</para></li><li><para>"hunk" - launch the cluster with the Hunk Big Data Analytics Platform.</para></li><li><para>"hue"- launch the cluster with Hue installed.</para></li><li><para>"spark" - launch the cluster with Apache Spark installed.</para></li><li><para>"ganglia" - launch the cluster with the Ganglia Monitoring System installed.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NewSupportedProducts")]
        public Amazon.ElasticMapReduce.Model.SupportedProductConfig[] NewSupportedProduct { get; set; }
        #endregion
        
        #region Parameter PlacementGroupConfig
        /// <summary>
        /// <para>
        /// <para>The specified placement group configuration for an Amazon EMR cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementGroupConfigs")]
        public Amazon.ElasticMapReduce.Model.PlacementGroupConfig[] PlacementGroupConfig { get; set; }
        #endregion
        
        #region Parameter KerberosAttributes_Realm
        /// <summary>
        /// <para>
        /// <para>The name of the Kerberos realm to which all nodes in a cluster belong. For example,
        /// <code>EC2.INTERNAL</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosAttributes_Realm { get; set; }
        #endregion
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The Amazon EMR release label, which determines the version of open-source application
        /// packages installed on the cluster. Release labels are in the form <code>emr-x.x.x</code>,
        /// where x.x.x is an Amazon EMR release version such as <code>emr-5.14.0</code>. For
        /// more information about Amazon EMR release versions and included application versions
        /// and features, see <a href="https://docs.aws.amazon.com/emr/latest/ReleaseGuide/">https://docs.aws.amazon.com/emr/latest/ReleaseGuide/</a>.
        /// The release label applies only to Amazon EMR releases version 4.0 and later. Earlier
        /// versions use <code>AmiVersion</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter RepoUpgradeOnBoot
        /// <summary>
        /// <para>
        /// <para>Applies only when <code>CustomAmiID</code> is used. Specifies which updates from the
        /// Amazon Linux AMI package repositories to apply automatically when the instance boots
        /// using the AMI. If omitted, the default is <code>SECURITY</code>, which indicates that
        /// only security updates are applied. If <code>NONE</code> is specified, no updates are
        /// applied, and all updates must be applied manually.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.RepoUpgradeOnBoot")]
        public Amazon.ElasticMapReduce.RepoUpgradeOnBoot RepoUpgradeOnBoot { get; set; }
        #endregion
        
        #region Parameter ScaleDownBehavior
        /// <summary>
        /// <para>
        /// <para>Specifies the way that individual Amazon EC2 instances terminate when an automatic
        /// scale-in activity occurs or an instance group is resized. <code>TERMINATE_AT_INSTANCE_HOUR</code>
        /// indicates that Amazon EMR terminates nodes at the instance-hour boundary, regardless
        /// of when the request to terminate the instance was submitted. This option is only available
        /// with Amazon EMR 5.1.0 and later and is the default for clusters created using that
        /// version. <code>TERMINATE_AT_TASK_COMPLETION</code> indicates that Amazon EMR adds
        /// nodes to a deny list and drains tasks from nodes before terminating the Amazon EC2
        /// instances, regardless of the instance-hour boundary. With either behavior, Amazon
        /// EMR removes the least active nodes first and blocks instance termination if it could
        /// lead to HDFS corruption. <code>TERMINATE_AT_TASK_COMPLETION</code> available only
        /// in Amazon EMR version 4.1.0 and later, and is the default for versions of Amazon EMR
        /// earlier than 5.1.0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.ScaleDownBehavior")]
        public Amazon.ElasticMapReduce.ScaleDownBehavior ScaleDownBehavior { get; set; }
        #endregion
        
        #region Parameter SecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The name of a security configuration to apply to the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Instances_ServiceAccessSecurityGroup
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon EC2 security group for the Amazon EMR service to access
        /// clusters in VPC private subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_ServiceAccessSecurityGroup { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The IAM role that will be assumed by the Amazon EMR service to access AWS resources
        /// on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter Instances_SlaveInstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type of the core and task nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Instances_SlaveInstanceType { get; set; }
        #endregion
        
        #region Parameter StepConcurrencyLevel
        /// <summary>
        /// <para>
        /// <para>Specifies the number of steps that can be executed concurrently. The default value
        /// is <code>1</code>. The maximum value is <code>256</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? StepConcurrencyLevel { get; set; }
        #endregion
        
        #region Parameter Step
        /// <summary>
        /// <para>
        /// <para>A list of steps to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Steps")]
        public Amazon.ElasticMapReduce.Model.StepConfig[] Step { get; set; }
        #endregion
        
        #region Parameter SupportedProduct
        /// <summary>
        /// <para>
        /// <note><para>For Amazon EMR releases 3.x and 2.x. For Amazon EMR releases 4.x and later, use Applications.</para></note><para>A list of strings that indicates third-party software to use. For more information,
        /// see the <a href="https://docs.aws.amazon.com/emr/latest/DeveloperGuide/emr-dg.pdf">Amazon
        /// EMR Developer Guide</a>. Currently supported values are:</para><ul><li><para>"mapr-m3" - launch the job flow using MapR M3 Edition.</para></li><li><para>"mapr-m5" - launch the job flow using MapR M5 Edition.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupportedProducts")]
        public System.String[] SupportedProduct { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with a cluster and propagate to Amazon EC2 instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticMapReduce.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Instances_TerminationProtected
        /// <summary>
        /// <para>
        /// <para>Specifies whether to lock the cluster to prevent the Amazon EC2 instances from being
        /// terminated by API call, user intervention, or in the event of a job-flow error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Instances_TerminationProtected { get; set; }
        #endregion
        
        #region Parameter ComputeLimits_UnitType
        /// <summary>
        /// <para>
        /// <para> The unit type used for specifying a managed scaling policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ManagedScalingPolicy_ComputeLimits_UnitType")]
        [AWSConstantClassSource("Amazon.ElasticMapReduce.ComputeLimitsUnitType")]
        public Amazon.ElasticMapReduce.ComputeLimitsUnitType ComputeLimits_UnitType { get; set; }
        #endregion
        
        #region Parameter VisibleToAllUser
        /// <summary>
        /// <para>
        /// <para>A value of <code>true</code> indicates that all IAM users in the AWS account can perform
        /// cluster actions if they have the proper IAM policy permissions. This is the default.
        /// A value of <code>false</code> indicates that only the IAM user who created the cluster
        /// can perform actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisibleToAllUsers")]
        public System.Boolean? VisibleToAllUser { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobFlowId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.RunJobFlowResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.RunJobFlowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobFlowId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EMRJobFlow (RunJobFlow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.RunJobFlowResponse, StartEMRJobFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdditionalInfo = this.AdditionalInfo;
            context.AmiVersion = this.AmiVersion;
            if (this.Application != null)
            {
                context.Application = new List<Amazon.ElasticMapReduce.Model.Application>(this.Application);
            }
            context.AutoScalingRole = this.AutoScalingRole;
            if (this.BootstrapAction != null)
            {
                context.BootstrapAction = new List<Amazon.ElasticMapReduce.Model.BootstrapActionConfig>(this.BootstrapAction);
            }
            if (this.Configuration != null)
            {
                context.Configuration = new List<Amazon.ElasticMapReduce.Model.Configuration>(this.Configuration);
            }
            context.CustomAmiId = this.CustomAmiId;
            context.EbsRootVolumeSize = this.EbsRootVolumeSize;
            if (this.Instances_AdditionalMasterSecurityGroup != null)
            {
                context.Instances_AdditionalMasterSecurityGroup = new List<System.String>(this.Instances_AdditionalMasterSecurityGroup);
            }
            if (this.Instances_AdditionalSlaveSecurityGroup != null)
            {
                context.Instances_AdditionalSlaveSecurityGroup = new List<System.String>(this.Instances_AdditionalSlaveSecurityGroup);
            }
            context.Instances_Ec2KeyName = this.Instances_Ec2KeyName;
            context.Instances_Ec2SubnetId = this.Instances_Ec2SubnetId;
            if (this.Instances_Ec2SubnetIds != null)
            {
                context.Instances_Ec2SubnetIds = new List<System.String>(this.Instances_Ec2SubnetIds);
            }
            context.Instances_EmrManagedMasterSecurityGroup = this.Instances_EmrManagedMasterSecurityGroup;
            context.Instances_EmrManagedSlaveSecurityGroup = this.Instances_EmrManagedSlaveSecurityGroup;
            context.Instances_HadoopVersion = this.Instances_HadoopVersion;
            context.Instances_InstanceCount = this.Instances_InstanceCount;
            if (this.Instances_InstanceFleet != null)
            {
                context.Instances_InstanceFleet = new List<Amazon.ElasticMapReduce.Model.InstanceFleetConfig>(this.Instances_InstanceFleet);
            }
            if (this.Instances_InstanceGroup != null)
            {
                context.Instances_InstanceGroup = new List<Amazon.ElasticMapReduce.Model.InstanceGroupConfig>(this.Instances_InstanceGroup);
            }
            context.Instances_KeepJobFlowAliveWhenNoStep = this.Instances_KeepJobFlowAliveWhenNoStep;
            context.Instances_MasterInstanceType = this.Instances_MasterInstanceType;
            context.Instances_Placement_AvailabilityZone = this.Instances_Placement_AvailabilityZone;
            if (this.Instances_Placement_AvailabilityZones != null)
            {
                context.Instances_Placement_AvailabilityZones = new List<System.String>(this.Instances_Placement_AvailabilityZones);
            }
            context.Instances_ServiceAccessSecurityGroup = this.Instances_ServiceAccessSecurityGroup;
            context.Instances_SlaveInstanceType = this.Instances_SlaveInstanceType;
            context.Instances_TerminationProtected = this.Instances_TerminationProtected;
            context.JobFlowRole = this.JobFlowRole;
            context.KerberosAttributes_ADDomainJoinPassword = this.KerberosAttributes_ADDomainJoinPassword;
            context.KerberosAttributes_ADDomainJoinUser = this.KerberosAttributes_ADDomainJoinUser;
            context.KerberosAttributes_CrossRealmTrustPrincipalPassword = this.KerberosAttributes_CrossRealmTrustPrincipalPassword;
            context.KerberosAttributes_KdcAdminPassword = this.KerberosAttributes_KdcAdminPassword;
            context.KerberosAttributes_Realm = this.KerberosAttributes_Realm;
            context.LogEncryptionKmsKeyId = this.LogEncryptionKmsKeyId;
            context.LogUri = this.LogUri;
            context.ComputeLimits_MaximumCapacityUnit = this.ComputeLimits_MaximumCapacityUnit;
            context.ComputeLimits_MaximumCoreCapacityUnit = this.ComputeLimits_MaximumCoreCapacityUnit;
            context.ComputeLimits_MaximumOnDemandCapacityUnit = this.ComputeLimits_MaximumOnDemandCapacityUnit;
            context.ComputeLimits_MinimumCapacityUnit = this.ComputeLimits_MinimumCapacityUnit;
            context.ComputeLimits_UnitType = this.ComputeLimits_UnitType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NewSupportedProduct != null)
            {
                context.NewSupportedProduct = new List<Amazon.ElasticMapReduce.Model.SupportedProductConfig>(this.NewSupportedProduct);
            }
            if (this.PlacementGroupConfig != null)
            {
                context.PlacementGroupConfig = new List<Amazon.ElasticMapReduce.Model.PlacementGroupConfig>(this.PlacementGroupConfig);
            }
            context.ReleaseLabel = this.ReleaseLabel;
            context.RepoUpgradeOnBoot = this.RepoUpgradeOnBoot;
            context.ScaleDownBehavior = this.ScaleDownBehavior;
            context.SecurityConfiguration = this.SecurityConfiguration;
            context.ServiceRole = this.ServiceRole;
            context.StepConcurrencyLevel = this.StepConcurrencyLevel;
            if (this.Step != null)
            {
                context.Step = new List<Amazon.ElasticMapReduce.Model.StepConfig>(this.Step);
            }
            if (this.SupportedProduct != null)
            {
                context.SupportedProduct = new List<System.String>(this.SupportedProduct);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticMapReduce.Model.Tag>(this.Tag);
            }
            context.VisibleToAllUser = this.VisibleToAllUser;
            
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
            var request = new Amazon.ElasticMapReduce.Model.RunJobFlowRequest();
            
            if (cmdletContext.AdditionalInfo != null)
            {
                request.AdditionalInfo = cmdletContext.AdditionalInfo;
            }
            if (cmdletContext.AmiVersion != null)
            {
                request.AmiVersion = cmdletContext.AmiVersion;
            }
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.AutoScalingRole != null)
            {
                request.AutoScalingRole = cmdletContext.AutoScalingRole;
            }
            if (cmdletContext.BootstrapAction != null)
            {
                request.BootstrapActions = cmdletContext.BootstrapAction;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configurations = cmdletContext.Configuration;
            }
            if (cmdletContext.CustomAmiId != null)
            {
                request.CustomAmiId = cmdletContext.CustomAmiId;
            }
            if (cmdletContext.EbsRootVolumeSize != null)
            {
                request.EbsRootVolumeSize = cmdletContext.EbsRootVolumeSize.Value;
            }
            
             // populate Instances
            var requestInstancesIsNull = true;
            request.Instances = new Amazon.ElasticMapReduce.Model.JobFlowInstancesConfig();
            List<System.String> requestInstances_instances_AdditionalMasterSecurityGroup = null;
            if (cmdletContext.Instances_AdditionalMasterSecurityGroup != null)
            {
                requestInstances_instances_AdditionalMasterSecurityGroup = cmdletContext.Instances_AdditionalMasterSecurityGroup;
            }
            if (requestInstances_instances_AdditionalMasterSecurityGroup != null)
            {
                request.Instances.AdditionalMasterSecurityGroups = requestInstances_instances_AdditionalMasterSecurityGroup;
                requestInstancesIsNull = false;
            }
            List<System.String> requestInstances_instances_AdditionalSlaveSecurityGroup = null;
            if (cmdletContext.Instances_AdditionalSlaveSecurityGroup != null)
            {
                requestInstances_instances_AdditionalSlaveSecurityGroup = cmdletContext.Instances_AdditionalSlaveSecurityGroup;
            }
            if (requestInstances_instances_AdditionalSlaveSecurityGroup != null)
            {
                request.Instances.AdditionalSlaveSecurityGroups = requestInstances_instances_AdditionalSlaveSecurityGroup;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_Ec2KeyName = null;
            if (cmdletContext.Instances_Ec2KeyName != null)
            {
                requestInstances_instances_Ec2KeyName = cmdletContext.Instances_Ec2KeyName;
            }
            if (requestInstances_instances_Ec2KeyName != null)
            {
                request.Instances.Ec2KeyName = requestInstances_instances_Ec2KeyName;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_Ec2SubnetId = null;
            if (cmdletContext.Instances_Ec2SubnetId != null)
            {
                requestInstances_instances_Ec2SubnetId = cmdletContext.Instances_Ec2SubnetId;
            }
            if (requestInstances_instances_Ec2SubnetId != null)
            {
                request.Instances.Ec2SubnetId = requestInstances_instances_Ec2SubnetId;
                requestInstancesIsNull = false;
            }
            List<System.String> requestInstances_instances_Ec2SubnetIds = null;
            if (cmdletContext.Instances_Ec2SubnetIds != null)
            {
                requestInstances_instances_Ec2SubnetIds = cmdletContext.Instances_Ec2SubnetIds;
            }
            if (requestInstances_instances_Ec2SubnetIds != null)
            {
                request.Instances.Ec2SubnetIds = requestInstances_instances_Ec2SubnetIds;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_EmrManagedMasterSecurityGroup = null;
            if (cmdletContext.Instances_EmrManagedMasterSecurityGroup != null)
            {
                requestInstances_instances_EmrManagedMasterSecurityGroup = cmdletContext.Instances_EmrManagedMasterSecurityGroup;
            }
            if (requestInstances_instances_EmrManagedMasterSecurityGroup != null)
            {
                request.Instances.EmrManagedMasterSecurityGroup = requestInstances_instances_EmrManagedMasterSecurityGroup;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_EmrManagedSlaveSecurityGroup = null;
            if (cmdletContext.Instances_EmrManagedSlaveSecurityGroup != null)
            {
                requestInstances_instances_EmrManagedSlaveSecurityGroup = cmdletContext.Instances_EmrManagedSlaveSecurityGroup;
            }
            if (requestInstances_instances_EmrManagedSlaveSecurityGroup != null)
            {
                request.Instances.EmrManagedSlaveSecurityGroup = requestInstances_instances_EmrManagedSlaveSecurityGroup;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_HadoopVersion = null;
            if (cmdletContext.Instances_HadoopVersion != null)
            {
                requestInstances_instances_HadoopVersion = cmdletContext.Instances_HadoopVersion;
            }
            if (requestInstances_instances_HadoopVersion != null)
            {
                request.Instances.HadoopVersion = requestInstances_instances_HadoopVersion;
                requestInstancesIsNull = false;
            }
            System.Int32? requestInstances_instances_InstanceCount = null;
            if (cmdletContext.Instances_InstanceCount != null)
            {
                requestInstances_instances_InstanceCount = cmdletContext.Instances_InstanceCount.Value;
            }
            if (requestInstances_instances_InstanceCount != null)
            {
                request.Instances.InstanceCount = requestInstances_instances_InstanceCount.Value;
                requestInstancesIsNull = false;
            }
            List<Amazon.ElasticMapReduce.Model.InstanceFleetConfig> requestInstances_instances_InstanceFleet = null;
            if (cmdletContext.Instances_InstanceFleet != null)
            {
                requestInstances_instances_InstanceFleet = cmdletContext.Instances_InstanceFleet;
            }
            if (requestInstances_instances_InstanceFleet != null)
            {
                request.Instances.InstanceFleets = requestInstances_instances_InstanceFleet;
                requestInstancesIsNull = false;
            }
            List<Amazon.ElasticMapReduce.Model.InstanceGroupConfig> requestInstances_instances_InstanceGroup = null;
            if (cmdletContext.Instances_InstanceGroup != null)
            {
                requestInstances_instances_InstanceGroup = cmdletContext.Instances_InstanceGroup;
            }
            if (requestInstances_instances_InstanceGroup != null)
            {
                request.Instances.InstanceGroups = requestInstances_instances_InstanceGroup;
                requestInstancesIsNull = false;
            }
            System.Boolean? requestInstances_instances_KeepJobFlowAliveWhenNoStep = null;
            if (cmdletContext.Instances_KeepJobFlowAliveWhenNoStep != null)
            {
                requestInstances_instances_KeepJobFlowAliveWhenNoStep = cmdletContext.Instances_KeepJobFlowAliveWhenNoStep.Value;
            }
            if (requestInstances_instances_KeepJobFlowAliveWhenNoStep != null)
            {
                request.Instances.KeepJobFlowAliveWhenNoSteps = requestInstances_instances_KeepJobFlowAliveWhenNoStep.Value;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_MasterInstanceType = null;
            if (cmdletContext.Instances_MasterInstanceType != null)
            {
                requestInstances_instances_MasterInstanceType = cmdletContext.Instances_MasterInstanceType;
            }
            if (requestInstances_instances_MasterInstanceType != null)
            {
                request.Instances.MasterInstanceType = requestInstances_instances_MasterInstanceType;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_ServiceAccessSecurityGroup = null;
            if (cmdletContext.Instances_ServiceAccessSecurityGroup != null)
            {
                requestInstances_instances_ServiceAccessSecurityGroup = cmdletContext.Instances_ServiceAccessSecurityGroup;
            }
            if (requestInstances_instances_ServiceAccessSecurityGroup != null)
            {
                request.Instances.ServiceAccessSecurityGroup = requestInstances_instances_ServiceAccessSecurityGroup;
                requestInstancesIsNull = false;
            }
            System.String requestInstances_instances_SlaveInstanceType = null;
            if (cmdletContext.Instances_SlaveInstanceType != null)
            {
                requestInstances_instances_SlaveInstanceType = cmdletContext.Instances_SlaveInstanceType;
            }
            if (requestInstances_instances_SlaveInstanceType != null)
            {
                request.Instances.SlaveInstanceType = requestInstances_instances_SlaveInstanceType;
                requestInstancesIsNull = false;
            }
            System.Boolean? requestInstances_instances_TerminationProtected = null;
            if (cmdletContext.Instances_TerminationProtected != null)
            {
                requestInstances_instances_TerminationProtected = cmdletContext.Instances_TerminationProtected.Value;
            }
            if (requestInstances_instances_TerminationProtected != null)
            {
                request.Instances.TerminationProtected = requestInstances_instances_TerminationProtected.Value;
                requestInstancesIsNull = false;
            }
            Amazon.ElasticMapReduce.Model.PlacementType requestInstances_instances_Placement = null;
            
             // populate Placement
            var requestInstances_instances_PlacementIsNull = true;
            requestInstances_instances_Placement = new Amazon.ElasticMapReduce.Model.PlacementType();
            System.String requestInstances_instances_Placement_instances_Placement_AvailabilityZone = null;
            if (cmdletContext.Instances_Placement_AvailabilityZone != null)
            {
                requestInstances_instances_Placement_instances_Placement_AvailabilityZone = cmdletContext.Instances_Placement_AvailabilityZone;
            }
            if (requestInstances_instances_Placement_instances_Placement_AvailabilityZone != null)
            {
                requestInstances_instances_Placement.AvailabilityZone = requestInstances_instances_Placement_instances_Placement_AvailabilityZone;
                requestInstances_instances_PlacementIsNull = false;
            }
            List<System.String> requestInstances_instances_Placement_instances_Placement_AvailabilityZones = null;
            if (cmdletContext.Instances_Placement_AvailabilityZones != null)
            {
                requestInstances_instances_Placement_instances_Placement_AvailabilityZones = cmdletContext.Instances_Placement_AvailabilityZones;
            }
            if (requestInstances_instances_Placement_instances_Placement_AvailabilityZones != null)
            {
                requestInstances_instances_Placement.AvailabilityZones = requestInstances_instances_Placement_instances_Placement_AvailabilityZones;
                requestInstances_instances_PlacementIsNull = false;
            }
             // determine if requestInstances_instances_Placement should be set to null
            if (requestInstances_instances_PlacementIsNull)
            {
                requestInstances_instances_Placement = null;
            }
            if (requestInstances_instances_Placement != null)
            {
                request.Instances.Placement = requestInstances_instances_Placement;
                requestInstancesIsNull = false;
            }
             // determine if request.Instances should be set to null
            if (requestInstancesIsNull)
            {
                request.Instances = null;
            }
            if (cmdletContext.JobFlowRole != null)
            {
                request.JobFlowRole = cmdletContext.JobFlowRole;
            }
            
             // populate KerberosAttributes
            var requestKerberosAttributesIsNull = true;
            request.KerberosAttributes = new Amazon.ElasticMapReduce.Model.KerberosAttributes();
            System.String requestKerberosAttributes_kerberosAttributes_ADDomainJoinPassword = null;
            if (cmdletContext.KerberosAttributes_ADDomainJoinPassword != null)
            {
                requestKerberosAttributes_kerberosAttributes_ADDomainJoinPassword = cmdletContext.KerberosAttributes_ADDomainJoinPassword;
            }
            if (requestKerberosAttributes_kerberosAttributes_ADDomainJoinPassword != null)
            {
                request.KerberosAttributes.ADDomainJoinPassword = requestKerberosAttributes_kerberosAttributes_ADDomainJoinPassword;
                requestKerberosAttributesIsNull = false;
            }
            System.String requestKerberosAttributes_kerberosAttributes_ADDomainJoinUser = null;
            if (cmdletContext.KerberosAttributes_ADDomainJoinUser != null)
            {
                requestKerberosAttributes_kerberosAttributes_ADDomainJoinUser = cmdletContext.KerberosAttributes_ADDomainJoinUser;
            }
            if (requestKerberosAttributes_kerberosAttributes_ADDomainJoinUser != null)
            {
                request.KerberosAttributes.ADDomainJoinUser = requestKerberosAttributes_kerberosAttributes_ADDomainJoinUser;
                requestKerberosAttributesIsNull = false;
            }
            System.String requestKerberosAttributes_kerberosAttributes_CrossRealmTrustPrincipalPassword = null;
            if (cmdletContext.KerberosAttributes_CrossRealmTrustPrincipalPassword != null)
            {
                requestKerberosAttributes_kerberosAttributes_CrossRealmTrustPrincipalPassword = cmdletContext.KerberosAttributes_CrossRealmTrustPrincipalPassword;
            }
            if (requestKerberosAttributes_kerberosAttributes_CrossRealmTrustPrincipalPassword != null)
            {
                request.KerberosAttributes.CrossRealmTrustPrincipalPassword = requestKerberosAttributes_kerberosAttributes_CrossRealmTrustPrincipalPassword;
                requestKerberosAttributesIsNull = false;
            }
            System.String requestKerberosAttributes_kerberosAttributes_KdcAdminPassword = null;
            if (cmdletContext.KerberosAttributes_KdcAdminPassword != null)
            {
                requestKerberosAttributes_kerberosAttributes_KdcAdminPassword = cmdletContext.KerberosAttributes_KdcAdminPassword;
            }
            if (requestKerberosAttributes_kerberosAttributes_KdcAdminPassword != null)
            {
                request.KerberosAttributes.KdcAdminPassword = requestKerberosAttributes_kerberosAttributes_KdcAdminPassword;
                requestKerberosAttributesIsNull = false;
            }
            System.String requestKerberosAttributes_kerberosAttributes_Realm = null;
            if (cmdletContext.KerberosAttributes_Realm != null)
            {
                requestKerberosAttributes_kerberosAttributes_Realm = cmdletContext.KerberosAttributes_Realm;
            }
            if (requestKerberosAttributes_kerberosAttributes_Realm != null)
            {
                request.KerberosAttributes.Realm = requestKerberosAttributes_kerberosAttributes_Realm;
                requestKerberosAttributesIsNull = false;
            }
             // determine if request.KerberosAttributes should be set to null
            if (requestKerberosAttributesIsNull)
            {
                request.KerberosAttributes = null;
            }
            if (cmdletContext.LogEncryptionKmsKeyId != null)
            {
                request.LogEncryptionKmsKeyId = cmdletContext.LogEncryptionKmsKeyId;
            }
            if (cmdletContext.LogUri != null)
            {
                request.LogUri = cmdletContext.LogUri;
            }
            
             // populate ManagedScalingPolicy
            var requestManagedScalingPolicyIsNull = true;
            request.ManagedScalingPolicy = new Amazon.ElasticMapReduce.Model.ManagedScalingPolicy();
            Amazon.ElasticMapReduce.Model.ComputeLimits requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = null;
            
             // populate ComputeLimits
            var requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = true;
            requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = new Amazon.ElasticMapReduce.Model.ComputeLimits();
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit = cmdletContext.ComputeLimits_MaximumCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumCoreCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit = cmdletContext.ComputeLimits_MaximumCoreCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumCoreCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumCoreCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MaximumOnDemandCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit = cmdletContext.ComputeLimits_MaximumOnDemandCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MaximumOnDemandCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MaximumOnDemandCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            System.Int32? requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit = null;
            if (cmdletContext.ComputeLimits_MinimumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit = cmdletContext.ComputeLimits_MinimumCapacityUnit.Value;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.MinimumCapacityUnits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_MinimumCapacityUnit.Value;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
            Amazon.ElasticMapReduce.ComputeLimitsUnitType requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType = null;
            if (cmdletContext.ComputeLimits_UnitType != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType = cmdletContext.ComputeLimits_UnitType;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType != null)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits.UnitType = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits_computeLimits_UnitType;
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull = false;
            }
             // determine if requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits should be set to null
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimitsIsNull)
            {
                requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits = null;
            }
            if (requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits != null)
            {
                request.ManagedScalingPolicy.ComputeLimits = requestManagedScalingPolicy_managedScalingPolicy_ComputeLimits;
                requestManagedScalingPolicyIsNull = false;
            }
             // determine if request.ManagedScalingPolicy should be set to null
            if (requestManagedScalingPolicyIsNull)
            {
                request.ManagedScalingPolicy = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NewSupportedProduct != null)
            {
                request.NewSupportedProducts = cmdletContext.NewSupportedProduct;
            }
            if (cmdletContext.PlacementGroupConfig != null)
            {
                request.PlacementGroupConfigs = cmdletContext.PlacementGroupConfig;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            if (cmdletContext.RepoUpgradeOnBoot != null)
            {
                request.RepoUpgradeOnBoot = cmdletContext.RepoUpgradeOnBoot;
            }
            if (cmdletContext.ScaleDownBehavior != null)
            {
                request.ScaleDownBehavior = cmdletContext.ScaleDownBehavior;
            }
            if (cmdletContext.SecurityConfiguration != null)
            {
                request.SecurityConfiguration = cmdletContext.SecurityConfiguration;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            if (cmdletContext.StepConcurrencyLevel != null)
            {
                request.StepConcurrencyLevel = cmdletContext.StepConcurrencyLevel.Value;
            }
            if (cmdletContext.Step != null)
            {
                request.Steps = cmdletContext.Step;
            }
            if (cmdletContext.SupportedProduct != null)
            {
                request.SupportedProducts = cmdletContext.SupportedProduct;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VisibleToAllUser != null)
            {
                request.VisibleToAllUsers = cmdletContext.VisibleToAllUser.Value;
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
        
        private Amazon.ElasticMapReduce.Model.RunJobFlowResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.RunJobFlowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "RunJobFlow");
            try
            {
                #if DESKTOP
                return client.RunJobFlow(request);
                #elif CORECLR
                return client.RunJobFlowAsync(request).GetAwaiter().GetResult();
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
            public System.String AdditionalInfo { get; set; }
            public System.String AmiVersion { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Application> Application { get; set; }
            public System.String AutoScalingRole { get; set; }
            public List<Amazon.ElasticMapReduce.Model.BootstrapActionConfig> BootstrapAction { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Configuration> Configuration { get; set; }
            public System.String CustomAmiId { get; set; }
            public System.Int32? EbsRootVolumeSize { get; set; }
            public List<System.String> Instances_AdditionalMasterSecurityGroup { get; set; }
            public List<System.String> Instances_AdditionalSlaveSecurityGroup { get; set; }
            public System.String Instances_Ec2KeyName { get; set; }
            public System.String Instances_Ec2SubnetId { get; set; }
            public List<System.String> Instances_Ec2SubnetIds { get; set; }
            public System.String Instances_EmrManagedMasterSecurityGroup { get; set; }
            public System.String Instances_EmrManagedSlaveSecurityGroup { get; set; }
            public System.String Instances_HadoopVersion { get; set; }
            public System.Int32? Instances_InstanceCount { get; set; }
            public List<Amazon.ElasticMapReduce.Model.InstanceFleetConfig> Instances_InstanceFleet { get; set; }
            public List<Amazon.ElasticMapReduce.Model.InstanceGroupConfig> Instances_InstanceGroup { get; set; }
            public System.Boolean? Instances_KeepJobFlowAliveWhenNoStep { get; set; }
            public System.String Instances_MasterInstanceType { get; set; }
            public System.String Instances_Placement_AvailabilityZone { get; set; }
            public List<System.String> Instances_Placement_AvailabilityZones { get; set; }
            public System.String Instances_ServiceAccessSecurityGroup { get; set; }
            public System.String Instances_SlaveInstanceType { get; set; }
            public System.Boolean? Instances_TerminationProtected { get; set; }
            public System.String JobFlowRole { get; set; }
            public System.String KerberosAttributes_ADDomainJoinPassword { get; set; }
            public System.String KerberosAttributes_ADDomainJoinUser { get; set; }
            public System.String KerberosAttributes_CrossRealmTrustPrincipalPassword { get; set; }
            public System.String KerberosAttributes_KdcAdminPassword { get; set; }
            public System.String KerberosAttributes_Realm { get; set; }
            public System.String LogEncryptionKmsKeyId { get; set; }
            public System.String LogUri { get; set; }
            public System.Int32? ComputeLimits_MaximumCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MaximumCoreCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MaximumOnDemandCapacityUnit { get; set; }
            public System.Int32? ComputeLimits_MinimumCapacityUnit { get; set; }
            public Amazon.ElasticMapReduce.ComputeLimitsUnitType ComputeLimits_UnitType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.ElasticMapReduce.Model.SupportedProductConfig> NewSupportedProduct { get; set; }
            public List<Amazon.ElasticMapReduce.Model.PlacementGroupConfig> PlacementGroupConfig { get; set; }
            public System.String ReleaseLabel { get; set; }
            public Amazon.ElasticMapReduce.RepoUpgradeOnBoot RepoUpgradeOnBoot { get; set; }
            public Amazon.ElasticMapReduce.ScaleDownBehavior ScaleDownBehavior { get; set; }
            public System.String SecurityConfiguration { get; set; }
            public System.String ServiceRole { get; set; }
            public System.Int32? StepConcurrencyLevel { get; set; }
            public List<Amazon.ElasticMapReduce.Model.StepConfig> Step { get; set; }
            public List<System.String> SupportedProduct { get; set; }
            public List<Amazon.ElasticMapReduce.Model.Tag> Tag { get; set; }
            public System.Boolean? VisibleToAllUser { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.RunJobFlowResponse, StartEMRJobFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobFlowId;
        }
        
    }
}
