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
using Amazon.Finspace;
using Amazon.Finspace.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FINSP
{
    /// <summary>
    /// Creates a new kdb cluster.
    /// </summary>
    [Cmdlet("New", "FINSPKxCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Finspace.Model.CreateKxClusterResponse")]
    [AWSCmdlet("Calls the FinSpace User Environment Management Service CreateKxCluster API operation.", Operation = new[] {"CreateKxCluster"}, SelectReturnType = typeof(Amazon.Finspace.Model.CreateKxClusterResponse))]
    [AWSCmdletOutput("Amazon.Finspace.Model.CreateKxClusterResponse",
        "This cmdlet returns an Amazon.Finspace.Model.CreateKxClusterResponse object containing multiple properties."
    )]
    public partial class NewFINSPKxClusterCmdlet : AmazonFinspaceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoScalingConfiguration_AutoScalingMetric
        /// <summary>
        /// <para>
        /// <para> The metric your cluster will track in order to scale in and out. For example, <c>CPU_UTILIZATION_PERCENTAGE</c>
        /// is the average CPU usage across all the nodes in a cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.AutoScalingMetric")]
        public Amazon.Finspace.AutoScalingMetric AutoScalingConfiguration_AutoScalingMetric { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The availability zone identifiers for the requested regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter AzMode
        /// <summary>
        /// <para>
        /// <para>The number of availability zones you want to assign per cluster. This can be one of
        /// the following </para><ul><li><para><c>SINGLE</c> – Assigns one availability zone per cluster.</para></li><li><para><c>MULTI</c> – Assigns all the availability zones per cluster.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Finspace.KxAzMode")]
        public Amazon.Finspace.KxAzMode AzMode { get; set; }
        #endregion
        
        #region Parameter CacheStorageConfiguration
        /// <summary>
        /// <para>
        /// <para>The configurations for a read only cache storage associated with a cluster. This cache
        /// will be stored as an FSx Lustre that reads from the S3 store. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheStorageConfigurations")]
        public Amazon.Finspace.Model.KxCacheStorageConfiguration[] CacheStorageConfiguration { get; set; }
        #endregion
        
        #region Parameter ClusterDescription
        /// <summary>
        /// <para>
        /// <para>A description of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClusterDescription { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>A unique name for the cluster that you want to create.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter ClusterType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of KDB database that is being created. The following types are
        /// available: </para><ul><li><para>HDB – A Historical Database. The data is only accessible with read-only permissions
        /// from one of the FinSpace managed kdb databases mounted to the cluster.</para></li><li><para>RDB – A Realtime Database. This type of database captures all the data from a ticker
        /// plant and stores it in memory until the end of day, after which it writes all of its
        /// data to a disk and reloads the HDB. This cluster type requires local storage for temporary
        /// storage of data during the savedown process. If you specify this field in your request,
        /// you must provide the <c>savedownStorageConfiguration</c> parameter.</para></li><li><para>GATEWAY – A gateway cluster allows you to access data across processes in kdb systems.
        /// It allows you to create your own routing logic using the initialization scripts and
        /// custom code. This type of cluster does not require a writable local storage.</para></li><li><para>GP – A general purpose cluster allows you to quickly iterate on code during development
        /// by granting greater access to system commands and enabling a fast reload of custom
        /// code. This cluster type can optionally mount databases including cache and savedown
        /// storage. For this cluster type, the node count is fixed at 1. It does not support
        /// autoscaling and supports only <c>SINGLE</c> AZ mode.</para></li><li><para>Tickerplant – A tickerplant cluster allows you to subscribe to feed handlers based
        /// on IAM permissions. It can publish to RDBs, other Tickerplants, and real-time subscribers
        /// (RTS). Tickerplants can persist messages to log, which is readable by any RDB environment.
        /// It supports only single-node that is only one kdb process.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Finspace.KxClusterType")]
        public Amazon.Finspace.KxClusterType ClusterType { get; set; }
        #endregion
        
        #region Parameter CommandLineArgument
        /// <summary>
        /// <para>
        /// <para>Defines the key-value pairs to make them available inside the cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CommandLineArguments")]
        public Amazon.Finspace.Model.KxCommandLineArgument[] CommandLineArgument { get; set; }
        #endregion
        
        #region Parameter ScalingGroupConfiguration_Cpu
        /// <summary>
        /// <para>
        /// <para> The number of vCPUs that you want to reserve for each node of this kdb cluster on
        /// the scaling group host. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? ScalingGroupConfiguration_Cpu { get; set; }
        #endregion
        
        #region Parameter Databases
        /// <summary>
        /// <para>
        /// <para>A list of databases that will be available for querying.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Finspace.Model.KxDatabaseConfiguration[] Databases { get; set; }
        #endregion
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb environment.</para>
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>An IAM role that defines a set of permissions associated with a cluster. These permissions
        /// are assumed when a cluster attempts to access another cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter InitializationScript
        /// <summary>
        /// <para>
        /// <para>Specifies a Q program that will be run at launch of a cluster. It is a relative path
        /// within <i>.zip</i> file that contains the custom code, which will be loaded on the
        /// cluster. It must include the file name itself. For example, <c>somedir/init.q</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InitializationScript { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_IpAddressType
        /// <summary>
        /// <para>
        /// <para>The IP address type for cluster network configuration parameters. The following type
        /// is available:</para><ul><li><para>IP_V4 – IP address version 4</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.IPAddressType")]
        public Amazon.Finspace.IPAddressType VpcConfiguration_IpAddressType { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfiguration_MaxNodeCount
        /// <summary>
        /// <para>
        /// <para>The highest number of nodes to scale. This value cannot be greater than 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoScalingConfiguration_MaxNodeCount { get; set; }
        #endregion
        
        #region Parameter ScalingGroupConfiguration_MemoryLimit
        /// <summary>
        /// <para>
        /// <para> An optional hard limit on the amount of memory a kdb cluster can use. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingGroupConfiguration_MemoryLimit { get; set; }
        #endregion
        
        #region Parameter ScalingGroupConfiguration_MemoryReservation
        /// <summary>
        /// <para>
        /// <para> A reservation of the minimum amount of memory that should be available on the scaling
        /// group for a kdb cluster to be successfully placed in a scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingGroupConfiguration_MemoryReservation { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfiguration_MetricTarget
        /// <summary>
        /// <para>
        /// <para>The desired value of the chosen <c>autoScalingMetric</c>. When the metric drops below
        /// this value, the cluster will scale in. When the metric goes above this value, the
        /// cluster will scale out. You can set the target value between 1 and 100 percent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AutoScalingConfiguration_MetricTarget { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfiguration_MinNodeCount
        /// <summary>
        /// <para>
        /// <para>The lowest number of nodes to scale. This value must be at least 1 and less than the
        /// <c>maxNodeCount</c>. If the nodes in a cluster belong to multiple availability zones,
        /// then <c>minNodeCount</c> must be at least 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoScalingConfiguration_MinNodeCount { get; set; }
        #endregion
        
        #region Parameter CapacityConfiguration_NodeCount
        /// <summary>
        /// <para>
        /// <para>The number of instances running in a cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityConfiguration_NodeCount { get; set; }
        #endregion
        
        #region Parameter ScalingGroupConfiguration_NodeCount
        /// <summary>
        /// <para>
        /// <para> The number of kdb cluster nodes. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ScalingGroupConfiguration_NodeCount { get; set; }
        #endregion
        
        #region Parameter CapacityConfiguration_NodeType
        /// <summary>
        /// <para>
        /// <para>The type that determines the hardware of the host computer used for your cluster instance.
        /// Each node type offers different memory and storage capabilities. Choose a node type
        /// based on the requirements of the application or software that you plan to run on your
        /// instance.</para><para>You can only specify one of the following values:</para><ul><li><para><c>kx.s.large</c> – The node type with a configuration of 12 GiB memory and 2 vCPUs.</para></li><li><para><c>kx.s.xlarge</c> – The node type with a configuration of 27 GiB memory and 4 vCPUs.</para></li><li><para><c>kx.s.2xlarge</c> – The node type with a configuration of 54 GiB memory and 8 vCPUs.</para></li><li><para><c>kx.s.4xlarge</c> – The node type with a configuration of 108 GiB memory and 16
        /// vCPUs.</para></li><li><para><c>kx.s.8xlarge</c> – The node type with a configuration of 216 GiB memory and 32
        /// vCPUs.</para></li><li><para><c>kx.s.16xlarge</c> – The node type with a configuration of 432 GiB memory and 64
        /// vCPUs.</para></li><li><para><c>kx.s.32xlarge</c> – The node type with a configuration of 864 GiB memory and 128
        /// vCPUs.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CapacityConfiguration_NodeType { get; set; }
        #endregion
        
        #region Parameter ReleaseLabel
        /// <summary>
        /// <para>
        /// <para>The version of FinSpace managed kdb to run.</para>
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
        public System.String ReleaseLabel { get; set; }
        #endregion
        
        #region Parameter Code_S3Bucket
        /// <summary>
        /// <para>
        /// <para>A unique name for the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Code_S3Key
        /// <summary>
        /// <para>
        /// <para>The full S3 path (excluding bucket) to the .zip file. This file contains the code
        /// that is loaded onto the cluster when it's started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Key { get; set; }
        #endregion
        
        #region Parameter Code_S3ObjectVersion
        /// <summary>
        /// <para>
        /// <para>The version of an S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3ObjectVersion { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfiguration_ScaleInCooldownSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that FinSpace will wait after a scale in event before initiating
        /// another scaling event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingConfiguration_ScaleInCooldownSeconds")]
        public System.Double? AutoScalingConfiguration_ScaleInCooldownSecond { get; set; }
        #endregion
        
        #region Parameter AutoScalingConfiguration_ScaleOutCooldownSecond
        /// <summary>
        /// <para>
        /// <para>The duration in seconds that FinSpace will wait after a scale out event before initiating
        /// another scaling event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoScalingConfiguration_ScaleOutCooldownSeconds")]
        public System.Double? AutoScalingConfiguration_ScaleOutCooldownSecond { get; set; }
        #endregion
        
        #region Parameter ScalingGroupConfiguration_ScalingGroupName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the kdb scaling group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScalingGroupConfiguration_ScalingGroupName { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the VPC security group applied to the VPC endpoint ENI for
        /// the cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SecurityGroupIds")]
        public System.String[] VpcConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SavedownStorageConfiguration_Size
        /// <summary>
        /// <para>
        /// <para>The size of temporary storage in gibibytes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SavedownStorageConfiguration_Size { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the subnet that the Privatelink VPC endpoint uses to connect to
        /// the cluster.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfiguration_SubnetIds")]
        public System.String[] VpcConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to label the cluster. You can add up to 50 tags to a cluster.</para><para />
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
        
        #region Parameter TickerplantLogConfiguration_TickerplantLogVolume
        /// <summary>
        /// <para>
        /// <para> The name of the volumes for tickerplant logs. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TickerplantLogConfiguration_TickerplantLogVolumes")]
        public System.String[] TickerplantLogConfiguration_TickerplantLogVolume { get; set; }
        #endregion
        
        #region Parameter SavedownStorageConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of writeable storage space for temporarily storing your savedown data. The
        /// valid values are:</para><ul><li><para>SDS01 – This type represents 3000 IOPS and io2 ebs volume type.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Finspace.KxSavedownStorageType")]
        public Amazon.Finspace.KxSavedownStorageType SavedownStorageConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter SavedownStorageConfiguration_VolumeName
        /// <summary>
        /// <para>
        /// <para> The name of the kdb volume that you want to use as writeable save-down storage for
        /// clusters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SavedownStorageConfiguration_VolumeName { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures idempotency. This token expires in 10 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Finspace.Model.CreateKxClusterResponse).
        /// Specifying the name of a property of type Amazon.Finspace.Model.CreateKxClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FINSPKxCluster (CreateKxCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Finspace.Model.CreateKxClusterResponse, NewFINSPKxClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoScalingConfiguration_AutoScalingMetric = this.AutoScalingConfiguration_AutoScalingMetric;
            context.AutoScalingConfiguration_MaxNodeCount = this.AutoScalingConfiguration_MaxNodeCount;
            context.AutoScalingConfiguration_MetricTarget = this.AutoScalingConfiguration_MetricTarget;
            context.AutoScalingConfiguration_MinNodeCount = this.AutoScalingConfiguration_MinNodeCount;
            context.AutoScalingConfiguration_ScaleInCooldownSecond = this.AutoScalingConfiguration_ScaleInCooldownSecond;
            context.AutoScalingConfiguration_ScaleOutCooldownSecond = this.AutoScalingConfiguration_ScaleOutCooldownSecond;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.AzMode = this.AzMode;
            #if MODULAR
            if (this.AzMode == null && ParameterWasBound(nameof(this.AzMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AzMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CacheStorageConfiguration != null)
            {
                context.CacheStorageConfiguration = new List<Amazon.Finspace.Model.KxCacheStorageConfiguration>(this.CacheStorageConfiguration);
            }
            context.CapacityConfiguration_NodeCount = this.CapacityConfiguration_NodeCount;
            context.CapacityConfiguration_NodeType = this.CapacityConfiguration_NodeType;
            context.ClientToken = this.ClientToken;
            context.ClusterDescription = this.ClusterDescription;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClusterType = this.ClusterType;
            #if MODULAR
            if (this.ClusterType == null && ParameterWasBound(nameof(this.ClusterType)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code_S3Bucket = this.Code_S3Bucket;
            context.Code_S3Key = this.Code_S3Key;
            context.Code_S3ObjectVersion = this.Code_S3ObjectVersion;
            if (this.CommandLineArgument != null)
            {
                context.CommandLineArgument = new List<Amazon.Finspace.Model.KxCommandLineArgument>(this.CommandLineArgument);
            }
            if (this.Databases != null)
            {
                context.Databases = new List<Amazon.Finspace.Model.KxDatabaseConfiguration>(this.Databases);
            }
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionRole = this.ExecutionRole;
            context.InitializationScript = this.InitializationScript;
            context.ReleaseLabel = this.ReleaseLabel;
            #if MODULAR
            if (this.ReleaseLabel == null && ParameterWasBound(nameof(this.ReleaseLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter ReleaseLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SavedownStorageConfiguration_Size = this.SavedownStorageConfiguration_Size;
            context.SavedownStorageConfiguration_Type = this.SavedownStorageConfiguration_Type;
            context.SavedownStorageConfiguration_VolumeName = this.SavedownStorageConfiguration_VolumeName;
            context.ScalingGroupConfiguration_Cpu = this.ScalingGroupConfiguration_Cpu;
            context.ScalingGroupConfiguration_MemoryLimit = this.ScalingGroupConfiguration_MemoryLimit;
            context.ScalingGroupConfiguration_MemoryReservation = this.ScalingGroupConfiguration_MemoryReservation;
            context.ScalingGroupConfiguration_NodeCount = this.ScalingGroupConfiguration_NodeCount;
            context.ScalingGroupConfiguration_ScalingGroupName = this.ScalingGroupConfiguration_ScalingGroupName;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.TickerplantLogConfiguration_TickerplantLogVolume != null)
            {
                context.TickerplantLogConfiguration_TickerplantLogVolume = new List<System.String>(this.TickerplantLogConfiguration_TickerplantLogVolume);
            }
            context.VpcConfiguration_IpAddressType = this.VpcConfiguration_IpAddressType;
            if (this.VpcConfiguration_SecurityGroupId != null)
            {
                context.VpcConfiguration_SecurityGroupId = new List<System.String>(this.VpcConfiguration_SecurityGroupId);
            }
            if (this.VpcConfiguration_SubnetId != null)
            {
                context.VpcConfiguration_SubnetId = new List<System.String>(this.VpcConfiguration_SubnetId);
            }
            context.VpcConfiguration_VpcId = this.VpcConfiguration_VpcId;
            
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
            var request = new Amazon.Finspace.Model.CreateKxClusterRequest();
            
            
             // populate AutoScalingConfiguration
            var requestAutoScalingConfigurationIsNull = true;
            request.AutoScalingConfiguration = new Amazon.Finspace.Model.AutoScalingConfiguration();
            Amazon.Finspace.AutoScalingMetric requestAutoScalingConfiguration_autoScalingConfiguration_AutoScalingMetric = null;
            if (cmdletContext.AutoScalingConfiguration_AutoScalingMetric != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_AutoScalingMetric = cmdletContext.AutoScalingConfiguration_AutoScalingMetric;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_AutoScalingMetric != null)
            {
                request.AutoScalingConfiguration.AutoScalingMetric = requestAutoScalingConfiguration_autoScalingConfiguration_AutoScalingMetric;
                requestAutoScalingConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingConfiguration_autoScalingConfiguration_MaxNodeCount = null;
            if (cmdletContext.AutoScalingConfiguration_MaxNodeCount != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_MaxNodeCount = cmdletContext.AutoScalingConfiguration_MaxNodeCount.Value;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_MaxNodeCount != null)
            {
                request.AutoScalingConfiguration.MaxNodeCount = requestAutoScalingConfiguration_autoScalingConfiguration_MaxNodeCount.Value;
                requestAutoScalingConfigurationIsNull = false;
            }
            System.Double? requestAutoScalingConfiguration_autoScalingConfiguration_MetricTarget = null;
            if (cmdletContext.AutoScalingConfiguration_MetricTarget != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_MetricTarget = cmdletContext.AutoScalingConfiguration_MetricTarget.Value;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_MetricTarget != null)
            {
                request.AutoScalingConfiguration.MetricTarget = requestAutoScalingConfiguration_autoScalingConfiguration_MetricTarget.Value;
                requestAutoScalingConfigurationIsNull = false;
            }
            System.Int32? requestAutoScalingConfiguration_autoScalingConfiguration_MinNodeCount = null;
            if (cmdletContext.AutoScalingConfiguration_MinNodeCount != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_MinNodeCount = cmdletContext.AutoScalingConfiguration_MinNodeCount.Value;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_MinNodeCount != null)
            {
                request.AutoScalingConfiguration.MinNodeCount = requestAutoScalingConfiguration_autoScalingConfiguration_MinNodeCount.Value;
                requestAutoScalingConfigurationIsNull = false;
            }
            System.Double? requestAutoScalingConfiguration_autoScalingConfiguration_ScaleInCooldownSecond = null;
            if (cmdletContext.AutoScalingConfiguration_ScaleInCooldownSecond != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_ScaleInCooldownSecond = cmdletContext.AutoScalingConfiguration_ScaleInCooldownSecond.Value;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_ScaleInCooldownSecond != null)
            {
                request.AutoScalingConfiguration.ScaleInCooldownSeconds = requestAutoScalingConfiguration_autoScalingConfiguration_ScaleInCooldownSecond.Value;
                requestAutoScalingConfigurationIsNull = false;
            }
            System.Double? requestAutoScalingConfiguration_autoScalingConfiguration_ScaleOutCooldownSecond = null;
            if (cmdletContext.AutoScalingConfiguration_ScaleOutCooldownSecond != null)
            {
                requestAutoScalingConfiguration_autoScalingConfiguration_ScaleOutCooldownSecond = cmdletContext.AutoScalingConfiguration_ScaleOutCooldownSecond.Value;
            }
            if (requestAutoScalingConfiguration_autoScalingConfiguration_ScaleOutCooldownSecond != null)
            {
                request.AutoScalingConfiguration.ScaleOutCooldownSeconds = requestAutoScalingConfiguration_autoScalingConfiguration_ScaleOutCooldownSecond.Value;
                requestAutoScalingConfigurationIsNull = false;
            }
             // determine if request.AutoScalingConfiguration should be set to null
            if (requestAutoScalingConfigurationIsNull)
            {
                request.AutoScalingConfiguration = null;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.AzMode != null)
            {
                request.AzMode = cmdletContext.AzMode;
            }
            if (cmdletContext.CacheStorageConfiguration != null)
            {
                request.CacheStorageConfigurations = cmdletContext.CacheStorageConfiguration;
            }
            
             // populate CapacityConfiguration
            var requestCapacityConfigurationIsNull = true;
            request.CapacityConfiguration = new Amazon.Finspace.Model.CapacityConfiguration();
            System.Int32? requestCapacityConfiguration_capacityConfiguration_NodeCount = null;
            if (cmdletContext.CapacityConfiguration_NodeCount != null)
            {
                requestCapacityConfiguration_capacityConfiguration_NodeCount = cmdletContext.CapacityConfiguration_NodeCount.Value;
            }
            if (requestCapacityConfiguration_capacityConfiguration_NodeCount != null)
            {
                request.CapacityConfiguration.NodeCount = requestCapacityConfiguration_capacityConfiguration_NodeCount.Value;
                requestCapacityConfigurationIsNull = false;
            }
            System.String requestCapacityConfiguration_capacityConfiguration_NodeType = null;
            if (cmdletContext.CapacityConfiguration_NodeType != null)
            {
                requestCapacityConfiguration_capacityConfiguration_NodeType = cmdletContext.CapacityConfiguration_NodeType;
            }
            if (requestCapacityConfiguration_capacityConfiguration_NodeType != null)
            {
                request.CapacityConfiguration.NodeType = requestCapacityConfiguration_capacityConfiguration_NodeType;
                requestCapacityConfigurationIsNull = false;
            }
             // determine if request.CapacityConfiguration should be set to null
            if (requestCapacityConfigurationIsNull)
            {
                request.CapacityConfiguration = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterDescription != null)
            {
                request.ClusterDescription = cmdletContext.ClusterDescription;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.ClusterType != null)
            {
                request.ClusterType = cmdletContext.ClusterType;
            }
            
             // populate Code
            var requestCodeIsNull = true;
            request.Code = new Amazon.Finspace.Model.CodeConfiguration();
            System.String requestCode_code_S3Bucket = null;
            if (cmdletContext.Code_S3Bucket != null)
            {
                requestCode_code_S3Bucket = cmdletContext.Code_S3Bucket;
            }
            if (requestCode_code_S3Bucket != null)
            {
                request.Code.S3Bucket = requestCode_code_S3Bucket;
                requestCodeIsNull = false;
            }
            System.String requestCode_code_S3Key = null;
            if (cmdletContext.Code_S3Key != null)
            {
                requestCode_code_S3Key = cmdletContext.Code_S3Key;
            }
            if (requestCode_code_S3Key != null)
            {
                request.Code.S3Key = requestCode_code_S3Key;
                requestCodeIsNull = false;
            }
            System.String requestCode_code_S3ObjectVersion = null;
            if (cmdletContext.Code_S3ObjectVersion != null)
            {
                requestCode_code_S3ObjectVersion = cmdletContext.Code_S3ObjectVersion;
            }
            if (requestCode_code_S3ObjectVersion != null)
            {
                request.Code.S3ObjectVersion = requestCode_code_S3ObjectVersion;
                requestCodeIsNull = false;
            }
             // determine if request.Code should be set to null
            if (requestCodeIsNull)
            {
                request.Code = null;
            }
            if (cmdletContext.CommandLineArgument != null)
            {
                request.CommandLineArguments = cmdletContext.CommandLineArgument;
            }
            if (cmdletContext.Databases != null)
            {
                request.Databases = cmdletContext.Databases;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            if (cmdletContext.InitializationScript != null)
            {
                request.InitializationScript = cmdletContext.InitializationScript;
            }
            if (cmdletContext.ReleaseLabel != null)
            {
                request.ReleaseLabel = cmdletContext.ReleaseLabel;
            }
            
             // populate SavedownStorageConfiguration
            var requestSavedownStorageConfigurationIsNull = true;
            request.SavedownStorageConfiguration = new Amazon.Finspace.Model.KxSavedownStorageConfiguration();
            System.Int32? requestSavedownStorageConfiguration_savedownStorageConfiguration_Size = null;
            if (cmdletContext.SavedownStorageConfiguration_Size != null)
            {
                requestSavedownStorageConfiguration_savedownStorageConfiguration_Size = cmdletContext.SavedownStorageConfiguration_Size.Value;
            }
            if (requestSavedownStorageConfiguration_savedownStorageConfiguration_Size != null)
            {
                request.SavedownStorageConfiguration.Size = requestSavedownStorageConfiguration_savedownStorageConfiguration_Size.Value;
                requestSavedownStorageConfigurationIsNull = false;
            }
            Amazon.Finspace.KxSavedownStorageType requestSavedownStorageConfiguration_savedownStorageConfiguration_Type = null;
            if (cmdletContext.SavedownStorageConfiguration_Type != null)
            {
                requestSavedownStorageConfiguration_savedownStorageConfiguration_Type = cmdletContext.SavedownStorageConfiguration_Type;
            }
            if (requestSavedownStorageConfiguration_savedownStorageConfiguration_Type != null)
            {
                request.SavedownStorageConfiguration.Type = requestSavedownStorageConfiguration_savedownStorageConfiguration_Type;
                requestSavedownStorageConfigurationIsNull = false;
            }
            System.String requestSavedownStorageConfiguration_savedownStorageConfiguration_VolumeName = null;
            if (cmdletContext.SavedownStorageConfiguration_VolumeName != null)
            {
                requestSavedownStorageConfiguration_savedownStorageConfiguration_VolumeName = cmdletContext.SavedownStorageConfiguration_VolumeName;
            }
            if (requestSavedownStorageConfiguration_savedownStorageConfiguration_VolumeName != null)
            {
                request.SavedownStorageConfiguration.VolumeName = requestSavedownStorageConfiguration_savedownStorageConfiguration_VolumeName;
                requestSavedownStorageConfigurationIsNull = false;
            }
             // determine if request.SavedownStorageConfiguration should be set to null
            if (requestSavedownStorageConfigurationIsNull)
            {
                request.SavedownStorageConfiguration = null;
            }
            
             // populate ScalingGroupConfiguration
            var requestScalingGroupConfigurationIsNull = true;
            request.ScalingGroupConfiguration = new Amazon.Finspace.Model.KxScalingGroupConfiguration();
            System.Double? requestScalingGroupConfiguration_scalingGroupConfiguration_Cpu = null;
            if (cmdletContext.ScalingGroupConfiguration_Cpu != null)
            {
                requestScalingGroupConfiguration_scalingGroupConfiguration_Cpu = cmdletContext.ScalingGroupConfiguration_Cpu.Value;
            }
            if (requestScalingGroupConfiguration_scalingGroupConfiguration_Cpu != null)
            {
                request.ScalingGroupConfiguration.Cpu = requestScalingGroupConfiguration_scalingGroupConfiguration_Cpu.Value;
                requestScalingGroupConfigurationIsNull = false;
            }
            System.Int32? requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryLimit = null;
            if (cmdletContext.ScalingGroupConfiguration_MemoryLimit != null)
            {
                requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryLimit = cmdletContext.ScalingGroupConfiguration_MemoryLimit.Value;
            }
            if (requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryLimit != null)
            {
                request.ScalingGroupConfiguration.MemoryLimit = requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryLimit.Value;
                requestScalingGroupConfigurationIsNull = false;
            }
            System.Int32? requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryReservation = null;
            if (cmdletContext.ScalingGroupConfiguration_MemoryReservation != null)
            {
                requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryReservation = cmdletContext.ScalingGroupConfiguration_MemoryReservation.Value;
            }
            if (requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryReservation != null)
            {
                request.ScalingGroupConfiguration.MemoryReservation = requestScalingGroupConfiguration_scalingGroupConfiguration_MemoryReservation.Value;
                requestScalingGroupConfigurationIsNull = false;
            }
            System.Int32? requestScalingGroupConfiguration_scalingGroupConfiguration_NodeCount = null;
            if (cmdletContext.ScalingGroupConfiguration_NodeCount != null)
            {
                requestScalingGroupConfiguration_scalingGroupConfiguration_NodeCount = cmdletContext.ScalingGroupConfiguration_NodeCount.Value;
            }
            if (requestScalingGroupConfiguration_scalingGroupConfiguration_NodeCount != null)
            {
                request.ScalingGroupConfiguration.NodeCount = requestScalingGroupConfiguration_scalingGroupConfiguration_NodeCount.Value;
                requestScalingGroupConfigurationIsNull = false;
            }
            System.String requestScalingGroupConfiguration_scalingGroupConfiguration_ScalingGroupName = null;
            if (cmdletContext.ScalingGroupConfiguration_ScalingGroupName != null)
            {
                requestScalingGroupConfiguration_scalingGroupConfiguration_ScalingGroupName = cmdletContext.ScalingGroupConfiguration_ScalingGroupName;
            }
            if (requestScalingGroupConfiguration_scalingGroupConfiguration_ScalingGroupName != null)
            {
                request.ScalingGroupConfiguration.ScalingGroupName = requestScalingGroupConfiguration_scalingGroupConfiguration_ScalingGroupName;
                requestScalingGroupConfigurationIsNull = false;
            }
             // determine if request.ScalingGroupConfiguration should be set to null
            if (requestScalingGroupConfigurationIsNull)
            {
                request.ScalingGroupConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TickerplantLogConfiguration
            var requestTickerplantLogConfigurationIsNull = true;
            request.TickerplantLogConfiguration = new Amazon.Finspace.Model.TickerplantLogConfiguration();
            List<System.String> requestTickerplantLogConfiguration_tickerplantLogConfiguration_TickerplantLogVolume = null;
            if (cmdletContext.TickerplantLogConfiguration_TickerplantLogVolume != null)
            {
                requestTickerplantLogConfiguration_tickerplantLogConfiguration_TickerplantLogVolume = cmdletContext.TickerplantLogConfiguration_TickerplantLogVolume;
            }
            if (requestTickerplantLogConfiguration_tickerplantLogConfiguration_TickerplantLogVolume != null)
            {
                request.TickerplantLogConfiguration.TickerplantLogVolumes = requestTickerplantLogConfiguration_tickerplantLogConfiguration_TickerplantLogVolume;
                requestTickerplantLogConfigurationIsNull = false;
            }
             // determine if request.TickerplantLogConfiguration should be set to null
            if (requestTickerplantLogConfigurationIsNull)
            {
                request.TickerplantLogConfiguration = null;
            }
            
             // populate VpcConfiguration
            var requestVpcConfigurationIsNull = true;
            request.VpcConfiguration = new Amazon.Finspace.Model.VpcConfiguration();
            Amazon.Finspace.IPAddressType requestVpcConfiguration_vpcConfiguration_IpAddressType = null;
            if (cmdletContext.VpcConfiguration_IpAddressType != null)
            {
                requestVpcConfiguration_vpcConfiguration_IpAddressType = cmdletContext.VpcConfiguration_IpAddressType;
            }
            if (requestVpcConfiguration_vpcConfiguration_IpAddressType != null)
            {
                request.VpcConfiguration.IpAddressType = requestVpcConfiguration_vpcConfiguration_IpAddressType;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SecurityGroupId = null;
            if (cmdletContext.VpcConfiguration_SecurityGroupId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SecurityGroupId = cmdletContext.VpcConfiguration_SecurityGroupId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SecurityGroupId != null)
            {
                request.VpcConfiguration.SecurityGroupIds = requestVpcConfiguration_vpcConfiguration_SecurityGroupId;
                requestVpcConfigurationIsNull = false;
            }
            List<System.String> requestVpcConfiguration_vpcConfiguration_SubnetId = null;
            if (cmdletContext.VpcConfiguration_SubnetId != null)
            {
                requestVpcConfiguration_vpcConfiguration_SubnetId = cmdletContext.VpcConfiguration_SubnetId;
            }
            if (requestVpcConfiguration_vpcConfiguration_SubnetId != null)
            {
                request.VpcConfiguration.SubnetIds = requestVpcConfiguration_vpcConfiguration_SubnetId;
                requestVpcConfigurationIsNull = false;
            }
            System.String requestVpcConfiguration_vpcConfiguration_VpcId = null;
            if (cmdletContext.VpcConfiguration_VpcId != null)
            {
                requestVpcConfiguration_vpcConfiguration_VpcId = cmdletContext.VpcConfiguration_VpcId;
            }
            if (requestVpcConfiguration_vpcConfiguration_VpcId != null)
            {
                request.VpcConfiguration.VpcId = requestVpcConfiguration_vpcConfiguration_VpcId;
                requestVpcConfigurationIsNull = false;
            }
             // determine if request.VpcConfiguration should be set to null
            if (requestVpcConfigurationIsNull)
            {
                request.VpcConfiguration = null;
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
        
        private Amazon.Finspace.Model.CreateKxClusterResponse CallAWSServiceOperation(IAmazonFinspace client, Amazon.Finspace.Model.CreateKxClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "FinSpace User Environment Management Service", "CreateKxCluster");
            try
            {
                return client.CreateKxClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Finspace.AutoScalingMetric AutoScalingConfiguration_AutoScalingMetric { get; set; }
            public System.Int32? AutoScalingConfiguration_MaxNodeCount { get; set; }
            public System.Double? AutoScalingConfiguration_MetricTarget { get; set; }
            public System.Int32? AutoScalingConfiguration_MinNodeCount { get; set; }
            public System.Double? AutoScalingConfiguration_ScaleInCooldownSecond { get; set; }
            public System.Double? AutoScalingConfiguration_ScaleOutCooldownSecond { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public Amazon.Finspace.KxAzMode AzMode { get; set; }
            public List<Amazon.Finspace.Model.KxCacheStorageConfiguration> CacheStorageConfiguration { get; set; }
            public System.Int32? CapacityConfiguration_NodeCount { get; set; }
            public System.String CapacityConfiguration_NodeType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ClusterDescription { get; set; }
            public System.String ClusterName { get; set; }
            public Amazon.Finspace.KxClusterType ClusterType { get; set; }
            public System.String Code_S3Bucket { get; set; }
            public System.String Code_S3Key { get; set; }
            public System.String Code_S3ObjectVersion { get; set; }
            public List<Amazon.Finspace.Model.KxCommandLineArgument> CommandLineArgument { get; set; }
            public List<Amazon.Finspace.Model.KxDatabaseConfiguration> Databases { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.String InitializationScript { get; set; }
            public System.String ReleaseLabel { get; set; }
            public System.Int32? SavedownStorageConfiguration_Size { get; set; }
            public Amazon.Finspace.KxSavedownStorageType SavedownStorageConfiguration_Type { get; set; }
            public System.String SavedownStorageConfiguration_VolumeName { get; set; }
            public System.Double? ScalingGroupConfiguration_Cpu { get; set; }
            public System.Int32? ScalingGroupConfiguration_MemoryLimit { get; set; }
            public System.Int32? ScalingGroupConfiguration_MemoryReservation { get; set; }
            public System.Int32? ScalingGroupConfiguration_NodeCount { get; set; }
            public System.String ScalingGroupConfiguration_ScalingGroupName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> TickerplantLogConfiguration_TickerplantLogVolume { get; set; }
            public Amazon.Finspace.IPAddressType VpcConfiguration_IpAddressType { get; set; }
            public List<System.String> VpcConfiguration_SecurityGroupId { get; set; }
            public List<System.String> VpcConfiguration_SubnetId { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public System.Func<Amazon.Finspace.Model.CreateKxClusterResponse, NewFINSPKxClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
