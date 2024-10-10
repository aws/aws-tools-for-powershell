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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates a configuration that you can later provide to configure and start an DMS Serverless
    /// replication. You can also provide options to validate the configuration inputs before
    /// you start the replication.
    /// </summary>
    [Cmdlet("New", "DMSReplicationConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationConfig")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateReplicationConfig API operation.", Operation = new[] {"CreateReplicationConfig"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationConfig or Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationConfig object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDMSReplicationConfigCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputeConfig_AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone where the DMS Serverless replication using this configuration
        /// will run. The default value is a random, system-chosen Availability Zone in the configuration's
        /// Amazon Web Services Region, for example, <c>"us-west-2"</c>. You can't set this parameter
        /// if the <c>MultiAZ</c> parameter is set to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfig_AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_DnsNameServer
        /// <summary>
        /// <para>
        /// <para>A list of custom DNS name servers supported for the DMS Serverless replication to
        /// access your source or target database. This list overrides the default name servers
        /// supported by the DMS Serverless replication. You can specify a comma-separated list
        /// of internet addresses for up to four DNS name servers. For example: <c>"1.1.1.1,2.2.2.2,3.3.3.3,4.4.4.4"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfig_DnsNameServers")]
        public System.String ComputeConfig_DnsNameServer { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>An Key Management Service (KMS) key Amazon Resource Name (ARN) that is used to encrypt
        /// the data during DMS Serverless replication.</para><para>If you don't specify a value for the <c>KmsKeyId</c> parameter, DMS uses your default
        /// encryption key.</para><para>KMS creates the default encryption key for your Amazon Web Services account. Your
        /// Amazon Web Services account has a different default encryption key for each Amazon
        /// Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_MaxCapacityUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum value of the DMS capacity units (DCUs) for which a given DMS
        /// Serverless replication can be provisioned. A single DCU is 2GB of RAM, with 1 DCU
        /// as the minimum value allowed. The list of valid DCU values includes 1, 2, 4, 8, 16,
        /// 32, 64, 128, 192, 256, and 384. So, the maximum value that you can specify for DMS
        /// Serverless is 384. The <c>MaxCapacityUnits</c> parameter is the only DCU parameter
        /// you are required to specify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfig_MaxCapacityUnits")]
        public System.Int32? ComputeConfig_MaxCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_MinCapacityUnit
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum value of the DMS capacity units (DCUs) for which a given DMS
        /// Serverless replication can be provisioned. A single DCU is 2GB of RAM, with 1 DCU
        /// as the minimum value allowed. The list of valid DCU values includes 1, 2, 4, 8, 16,
        /// 32, 64, 128, 192, 256, and 384. So, the minimum DCU value that you can specify for
        /// DMS Serverless is 1. If you don't set this value, DMS sets this parameter to the minimum
        /// DCU value allowed, 1. If there is no current source activity, DMS scales down your
        /// replication until it reaches the value specified in <c>MinCapacityUnits</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfig_MinCapacityUnits")]
        public System.Int32? ComputeConfig_MinCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_MultiAZ
        /// <summary>
        /// <para>
        /// <para>Specifies whether the DMS Serverless replication is a Multi-AZ deployment. You can't
        /// set the <c>AvailabilityZone</c> parameter if the <c>MultiAZ</c> parameter is set to
        /// <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeConfig_MultiAZ { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur for the DMS Serverless
        /// replication, in Universal Coordinated Time (UTC). The format is <c>ddd:hh24:mi-ddd:hh24:mi</c>.</para><para>The default is a 30-minute window selected at random from an 8-hour block of time
        /// per Amazon Web Services Region. This maintenance occurs on a random day of the week.
        /// Valid values for days of the week include <c>Mon</c>, <c>Tue</c>, <c>Wed</c>, <c>Thu</c>,
        /// <c>Fri</c>, <c>Sat</c>, and <c>Sun</c>.</para><para>Constraints include a minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfig_PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ReplicationConfigIdentifier
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you want to use to create a <c>ReplicationConfigArn</c> that
        /// is returned as part of the output from this action. You can then pass this output
        /// <c>ReplicationConfigArn</c> as the value of the <c>ReplicationConfigArn</c> option
        /// for other actions to identify both DMS Serverless replications and replication configurations
        /// that you want those actions to operate on. For some actions, you can also use either
        /// this unique identifier or a corresponding ARN in action filters to identify the specific
        /// replication and replication configuration to operate on.</para>
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
        public System.String ReplicationConfigIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationSetting
        /// <summary>
        /// <para>
        /// <para>Optional JSON settings for DMS Serverless replications that are provisioned using
        /// this replication configuration. For example, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.CustomizingTasks.TaskSettings.ChangeProcessingTuning.html">
        /// Change processing tuning settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicationSettings")]
        public System.String ReplicationSetting { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_ReplicationSubnetGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies a subnet group identifier to associate with the DMS Serverless replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfig_ReplicationSubnetGroupId { get; set; }
        #endregion
        
        #region Parameter ReplicationType
        /// <summary>
        /// <para>
        /// <para>The type of DMS Serverless replication to provision using this replication configuration.</para><para>Possible values:</para><ul><li><para><c>"full-load"</c></para></li><li><para><c>"cdc"</c></para></li><li><para><c>"full-load-and-cdc"</c></para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue ReplicationType { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>Optional unique value or name that you set for a given resource that can be used to
        /// construct an Amazon Resource Name (ARN) for that resource. For more information, see
        /// <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Security.html#CHAP_Security.FineGrainedAccess">
        /// Fine-grained access control using resource names and tags</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source endpoint for this DMS Serverless replication
        /// configuration.</para>
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
        public System.String SourceEndpointArn { get; set; }
        #endregion
        
        #region Parameter SupplementalSetting
        /// <summary>
        /// <para>
        /// <para>Optional JSON settings for specifying supplemental data. For more information, see
        /// <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.TaskData.html">
        /// Specifying supplemental data for task settings</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SupplementalSettings")]
        public System.String SupplementalSetting { get; set; }
        #endregion
        
        #region Parameter TableMapping
        /// <summary>
        /// <para>
        /// <para>JSON table mappings for DMS Serverless replications that are provisioned using this
        /// replication configuration. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.CustomizingTasks.TableMapping.SelectionTransformation.html">
        /// Specifying table selection and transformations rules using JSON</a>.</para>
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
        [Alias("TableMappings")]
        public System.String TableMapping { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more optional tags associated with resources used by the DMS Serverless replication.
        /// For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tagging.html">
        /// Tagging resources in Database Migration Service</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target endpoint for this DMS serverless replication
        /// configuration.</para>
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
        public System.String TargetEndpointArn { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>Specifies the virtual private cloud (VPC) security group to use with the DMS Serverless
        /// replication. The VPC security group must work with the VPC containing the replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfig_VpcSecurityGroupIds")]
        public System.String[] ComputeConfig_VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationConfig'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationConfig";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationConfigIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationConfigIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationConfigIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationConfigIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSReplicationConfig (CreateReplicationConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse, NewDMSReplicationConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationConfigIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeConfig_AvailabilityZone = this.ComputeConfig_AvailabilityZone;
            context.ComputeConfig_DnsNameServer = this.ComputeConfig_DnsNameServer;
            context.ComputeConfig_KmsKeyId = this.ComputeConfig_KmsKeyId;
            context.ComputeConfig_MaxCapacityUnit = this.ComputeConfig_MaxCapacityUnit;
            context.ComputeConfig_MinCapacityUnit = this.ComputeConfig_MinCapacityUnit;
            context.ComputeConfig_MultiAZ = this.ComputeConfig_MultiAZ;
            context.ComputeConfig_PreferredMaintenanceWindow = this.ComputeConfig_PreferredMaintenanceWindow;
            context.ComputeConfig_ReplicationSubnetGroupId = this.ComputeConfig_ReplicationSubnetGroupId;
            if (this.ComputeConfig_VpcSecurityGroupId != null)
            {
                context.ComputeConfig_VpcSecurityGroupId = new List<System.String>(this.ComputeConfig_VpcSecurityGroupId);
            }
            context.ReplicationConfigIdentifier = this.ReplicationConfigIdentifier;
            #if MODULAR
            if (this.ReplicationConfigIdentifier == null && ParameterWasBound(nameof(this.ReplicationConfigIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfigIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationSetting = this.ReplicationSetting;
            context.ReplicationType = this.ReplicationType;
            #if MODULAR
            if (this.ReplicationType == null && ParameterWasBound(nameof(this.ReplicationType)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceIdentifier = this.ResourceIdentifier;
            context.SourceEndpointArn = this.SourceEndpointArn;
            #if MODULAR
            if (this.SourceEndpointArn == null && ParameterWasBound(nameof(this.SourceEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SupplementalSetting = this.SupplementalSetting;
            context.TableMapping = this.TableMapping;
            #if MODULAR
            if (this.TableMapping == null && ParameterWasBound(nameof(this.TableMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter TableMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            context.TargetEndpointArn = this.TargetEndpointArn;
            #if MODULAR
            if (this.TargetEndpointArn == null && ParameterWasBound(nameof(this.TargetEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateReplicationConfigRequest();
            
            
             // populate ComputeConfig
            var requestComputeConfigIsNull = true;
            request.ComputeConfig = new Amazon.DatabaseMigrationService.Model.ComputeConfig();
            System.String requestComputeConfig_computeConfig_AvailabilityZone = null;
            if (cmdletContext.ComputeConfig_AvailabilityZone != null)
            {
                requestComputeConfig_computeConfig_AvailabilityZone = cmdletContext.ComputeConfig_AvailabilityZone;
            }
            if (requestComputeConfig_computeConfig_AvailabilityZone != null)
            {
                request.ComputeConfig.AvailabilityZone = requestComputeConfig_computeConfig_AvailabilityZone;
                requestComputeConfigIsNull = false;
            }
            System.String requestComputeConfig_computeConfig_DnsNameServer = null;
            if (cmdletContext.ComputeConfig_DnsNameServer != null)
            {
                requestComputeConfig_computeConfig_DnsNameServer = cmdletContext.ComputeConfig_DnsNameServer;
            }
            if (requestComputeConfig_computeConfig_DnsNameServer != null)
            {
                request.ComputeConfig.DnsNameServers = requestComputeConfig_computeConfig_DnsNameServer;
                requestComputeConfigIsNull = false;
            }
            System.String requestComputeConfig_computeConfig_KmsKeyId = null;
            if (cmdletContext.ComputeConfig_KmsKeyId != null)
            {
                requestComputeConfig_computeConfig_KmsKeyId = cmdletContext.ComputeConfig_KmsKeyId;
            }
            if (requestComputeConfig_computeConfig_KmsKeyId != null)
            {
                request.ComputeConfig.KmsKeyId = requestComputeConfig_computeConfig_KmsKeyId;
                requestComputeConfigIsNull = false;
            }
            System.Int32? requestComputeConfig_computeConfig_MaxCapacityUnit = null;
            if (cmdletContext.ComputeConfig_MaxCapacityUnit != null)
            {
                requestComputeConfig_computeConfig_MaxCapacityUnit = cmdletContext.ComputeConfig_MaxCapacityUnit.Value;
            }
            if (requestComputeConfig_computeConfig_MaxCapacityUnit != null)
            {
                request.ComputeConfig.MaxCapacityUnits = requestComputeConfig_computeConfig_MaxCapacityUnit.Value;
                requestComputeConfigIsNull = false;
            }
            System.Int32? requestComputeConfig_computeConfig_MinCapacityUnit = null;
            if (cmdletContext.ComputeConfig_MinCapacityUnit != null)
            {
                requestComputeConfig_computeConfig_MinCapacityUnit = cmdletContext.ComputeConfig_MinCapacityUnit.Value;
            }
            if (requestComputeConfig_computeConfig_MinCapacityUnit != null)
            {
                request.ComputeConfig.MinCapacityUnits = requestComputeConfig_computeConfig_MinCapacityUnit.Value;
                requestComputeConfigIsNull = false;
            }
            System.Boolean? requestComputeConfig_computeConfig_MultiAZ = null;
            if (cmdletContext.ComputeConfig_MultiAZ != null)
            {
                requestComputeConfig_computeConfig_MultiAZ = cmdletContext.ComputeConfig_MultiAZ.Value;
            }
            if (requestComputeConfig_computeConfig_MultiAZ != null)
            {
                request.ComputeConfig.MultiAZ = requestComputeConfig_computeConfig_MultiAZ.Value;
                requestComputeConfigIsNull = false;
            }
            System.String requestComputeConfig_computeConfig_PreferredMaintenanceWindow = null;
            if (cmdletContext.ComputeConfig_PreferredMaintenanceWindow != null)
            {
                requestComputeConfig_computeConfig_PreferredMaintenanceWindow = cmdletContext.ComputeConfig_PreferredMaintenanceWindow;
            }
            if (requestComputeConfig_computeConfig_PreferredMaintenanceWindow != null)
            {
                request.ComputeConfig.PreferredMaintenanceWindow = requestComputeConfig_computeConfig_PreferredMaintenanceWindow;
                requestComputeConfigIsNull = false;
            }
            System.String requestComputeConfig_computeConfig_ReplicationSubnetGroupId = null;
            if (cmdletContext.ComputeConfig_ReplicationSubnetGroupId != null)
            {
                requestComputeConfig_computeConfig_ReplicationSubnetGroupId = cmdletContext.ComputeConfig_ReplicationSubnetGroupId;
            }
            if (requestComputeConfig_computeConfig_ReplicationSubnetGroupId != null)
            {
                request.ComputeConfig.ReplicationSubnetGroupId = requestComputeConfig_computeConfig_ReplicationSubnetGroupId;
                requestComputeConfigIsNull = false;
            }
            List<System.String> requestComputeConfig_computeConfig_VpcSecurityGroupId = null;
            if (cmdletContext.ComputeConfig_VpcSecurityGroupId != null)
            {
                requestComputeConfig_computeConfig_VpcSecurityGroupId = cmdletContext.ComputeConfig_VpcSecurityGroupId;
            }
            if (requestComputeConfig_computeConfig_VpcSecurityGroupId != null)
            {
                request.ComputeConfig.VpcSecurityGroupIds = requestComputeConfig_computeConfig_VpcSecurityGroupId;
                requestComputeConfigIsNull = false;
            }
             // determine if request.ComputeConfig should be set to null
            if (requestComputeConfigIsNull)
            {
                request.ComputeConfig = null;
            }
            if (cmdletContext.ReplicationConfigIdentifier != null)
            {
                request.ReplicationConfigIdentifier = cmdletContext.ReplicationConfigIdentifier;
            }
            if (cmdletContext.ReplicationSetting != null)
            {
                request.ReplicationSettings = cmdletContext.ReplicationSetting;
            }
            if (cmdletContext.ReplicationType != null)
            {
                request.ReplicationType = cmdletContext.ReplicationType;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.SourceEndpointArn != null)
            {
                request.SourceEndpointArn = cmdletContext.SourceEndpointArn;
            }
            if (cmdletContext.SupplementalSetting != null)
            {
                request.SupplementalSettings = cmdletContext.SupplementalSetting;
            }
            if (cmdletContext.TableMapping != null)
            {
                request.TableMappings = cmdletContext.TableMapping;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetEndpointArn != null)
            {
                request.TargetEndpointArn = cmdletContext.TargetEndpointArn;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateReplicationConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateReplicationConfig");
            try
            {
                #if DESKTOP
                return client.CreateReplicationConfig(request);
                #elif CORECLR
                return client.CreateReplicationConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ComputeConfig_AvailabilityZone { get; set; }
            public System.String ComputeConfig_DnsNameServer { get; set; }
            public System.String ComputeConfig_KmsKeyId { get; set; }
            public System.Int32? ComputeConfig_MaxCapacityUnit { get; set; }
            public System.Int32? ComputeConfig_MinCapacityUnit { get; set; }
            public System.Boolean? ComputeConfig_MultiAZ { get; set; }
            public System.String ComputeConfig_PreferredMaintenanceWindow { get; set; }
            public System.String ComputeConfig_ReplicationSubnetGroupId { get; set; }
            public List<System.String> ComputeConfig_VpcSecurityGroupId { get; set; }
            public System.String ReplicationConfigIdentifier { get; set; }
            public System.String ReplicationSetting { get; set; }
            public Amazon.DatabaseMigrationService.MigrationTypeValue ReplicationType { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.String SourceEndpointArn { get; set; }
            public System.String SupplementalSetting { get; set; }
            public System.String TableMapping { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public System.String TargetEndpointArn { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CreateReplicationConfigResponse, NewDMSReplicationConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationConfig;
        }
        
    }
}
