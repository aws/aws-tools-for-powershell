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
using Amazon.Drs;
using Amazon.Drs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EDRS
{
    /// <summary>
    /// Updates a ReplicationConfigurationTemplate by ID.
    /// </summary>
    [Cmdlet("Update", "EDRSReplicationConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse")]
    [AWSCmdlet("Calls the Elastic Disaster Recovery Service UpdateReplicationConfigurationTemplate API operation.", Operation = new[] {"UpdateReplicationConfigurationTemplate"}, SelectReturnType = typeof(Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse))]
    [AWSCmdletOutput("Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse",
        "This cmdlet returns an Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse object containing multiple properties."
    )]
    public partial class UpdateEDRSReplicationConfigurationTemplateCmdlet : AmazonDrsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Replication Configuration Template ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter AssociateDefaultSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Whether to associate the default Elastic Disaster Recovery Security group with the
        /// Replication Configuration Template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
        #endregion
        
        #region Parameter AutoReplicateNewDisk
        /// <summary>
        /// <para>
        /// <para>Whether to allow the AWS replication agent to automatically replicate newly added
        /// disks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoReplicateNewDisks")]
        public System.Boolean? AutoReplicateNewDisk { get; set; }
        #endregion
        
        #region Parameter BandwidthThrottling
        /// <summary>
        /// <para>
        /// <para>Configure bandwidth throttling for the outbound data transfer rate of the Source Server
        /// in Mbps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BandwidthThrottling { get; set; }
        #endregion
        
        #region Parameter CreatePublicIP
        /// <summary>
        /// <para>
        /// <para>Whether to create a Public IP for the Recovery Instance by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreatePublicIP { get; set; }
        #endregion
        
        #region Parameter DataPlaneRouting
        /// <summary>
        /// <para>
        /// <para>The data plane routing mechanism that will be used for replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.ReplicationConfigurationDataPlaneRouting")]
        public Amazon.Drs.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
        #endregion
        
        #region Parameter DefaultLargeStagingDiskType
        /// <summary>
        /// <para>
        /// <para>The Staging Disk EBS volume type to be used during replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.ReplicationConfigurationDefaultLargeStagingDiskType")]
        public Amazon.Drs.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
        #endregion
        
        #region Parameter EbsEncryption
        /// <summary>
        /// <para>
        /// <para>The type of EBS encryption to be used during replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Drs.ReplicationConfigurationEbsEncryption")]
        public Amazon.Drs.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
        #endregion
        
        #region Parameter EbsEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the EBS encryption key to be used during replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EbsEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter PitPolicy
        /// <summary>
        /// <para>
        /// <para>The Point in time (PIT) policy to manage snapshots taken during replication.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Drs.Model.PITPolicyRule[] PitPolicy { get; set; }
        #endregion
        
        #region Parameter ReplicationConfigurationTemplateID
        /// <summary>
        /// <para>
        /// <para>The Replication Configuration Template ID.</para>
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
        public System.String ReplicationConfigurationTemplateID { get; set; }
        #endregion
        
        #region Parameter ReplicationServerInstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type to be used for the replication server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationServerInstanceType { get; set; }
        #endregion
        
        #region Parameter ReplicationServersSecurityGroupsIDs
        /// <summary>
        /// <para>
        /// <para>The security group IDs that will be used by the replication server.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicationServersSecurityGroupsIDs { get; set; }
        #endregion
        
        #region Parameter StagingAreaSubnetId
        /// <summary>
        /// <para>
        /// <para>The subnet to be used by the replication staging area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StagingAreaSubnetId { get; set; }
        #endregion
        
        #region Parameter StagingAreaTag
        /// <summary>
        /// <para>
        /// <para>A set of tags to be associated with all resources created in the replication staging
        /// area: EC2 replication server, EBS volumes, EBS snapshots, etc.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StagingAreaTags")]
        public System.Collections.Hashtable StagingAreaTag { get; set; }
        #endregion
        
        #region Parameter UseDedicatedReplicationServer
        /// <summary>
        /// <para>
        /// <para>Whether to use a dedicated Replication Server in the replication staging area.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseDedicatedReplicationServer { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse).
        /// Specifying the name of a property of type Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationConfigurationTemplateID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EDRSReplicationConfigurationTemplate (UpdateReplicationConfigurationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse, UpdateEDRSReplicationConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            context.AssociateDefaultSecurityGroup = this.AssociateDefaultSecurityGroup;
            context.AutoReplicateNewDisk = this.AutoReplicateNewDisk;
            context.BandwidthThrottling = this.BandwidthThrottling;
            context.CreatePublicIP = this.CreatePublicIP;
            context.DataPlaneRouting = this.DataPlaneRouting;
            context.DefaultLargeStagingDiskType = this.DefaultLargeStagingDiskType;
            context.EbsEncryption = this.EbsEncryption;
            context.EbsEncryptionKeyArn = this.EbsEncryptionKeyArn;
            if (this.PitPolicy != null)
            {
                context.PitPolicy = new List<Amazon.Drs.Model.PITPolicyRule>(this.PitPolicy);
            }
            context.ReplicationConfigurationTemplateID = this.ReplicationConfigurationTemplateID;
            #if MODULAR
            if (this.ReplicationConfigurationTemplateID == null && ParameterWasBound(nameof(this.ReplicationConfigurationTemplateID)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfigurationTemplateID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationServerInstanceType = this.ReplicationServerInstanceType;
            if (this.ReplicationServersSecurityGroupsIDs != null)
            {
                context.ReplicationServersSecurityGroupsIDs = new List<System.String>(this.ReplicationServersSecurityGroupsIDs);
            }
            context.StagingAreaSubnetId = this.StagingAreaSubnetId;
            if (this.StagingAreaTag != null)
            {
                context.StagingAreaTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StagingAreaTag.Keys)
                {
                    context.StagingAreaTag.Add((String)hashKey, (System.String)(this.StagingAreaTag[hashKey]));
                }
            }
            context.UseDedicatedReplicationServer = this.UseDedicatedReplicationServer;
            
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
            var request = new Amazon.Drs.Model.UpdateReplicationConfigurationTemplateRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.AssociateDefaultSecurityGroup != null)
            {
                request.AssociateDefaultSecurityGroup = cmdletContext.AssociateDefaultSecurityGroup.Value;
            }
            if (cmdletContext.AutoReplicateNewDisk != null)
            {
                request.AutoReplicateNewDisks = cmdletContext.AutoReplicateNewDisk.Value;
            }
            if (cmdletContext.BandwidthThrottling != null)
            {
                request.BandwidthThrottling = cmdletContext.BandwidthThrottling.Value;
            }
            if (cmdletContext.CreatePublicIP != null)
            {
                request.CreatePublicIP = cmdletContext.CreatePublicIP.Value;
            }
            if (cmdletContext.DataPlaneRouting != null)
            {
                request.DataPlaneRouting = cmdletContext.DataPlaneRouting;
            }
            if (cmdletContext.DefaultLargeStagingDiskType != null)
            {
                request.DefaultLargeStagingDiskType = cmdletContext.DefaultLargeStagingDiskType;
            }
            if (cmdletContext.EbsEncryption != null)
            {
                request.EbsEncryption = cmdletContext.EbsEncryption;
            }
            if (cmdletContext.EbsEncryptionKeyArn != null)
            {
                request.EbsEncryptionKeyArn = cmdletContext.EbsEncryptionKeyArn;
            }
            if (cmdletContext.PitPolicy != null)
            {
                request.PitPolicy = cmdletContext.PitPolicy;
            }
            if (cmdletContext.ReplicationConfigurationTemplateID != null)
            {
                request.ReplicationConfigurationTemplateID = cmdletContext.ReplicationConfigurationTemplateID;
            }
            if (cmdletContext.ReplicationServerInstanceType != null)
            {
                request.ReplicationServerInstanceType = cmdletContext.ReplicationServerInstanceType;
            }
            if (cmdletContext.ReplicationServersSecurityGroupsIDs != null)
            {
                request.ReplicationServersSecurityGroupsIDs = cmdletContext.ReplicationServersSecurityGroupsIDs;
            }
            if (cmdletContext.StagingAreaSubnetId != null)
            {
                request.StagingAreaSubnetId = cmdletContext.StagingAreaSubnetId;
            }
            if (cmdletContext.StagingAreaTag != null)
            {
                request.StagingAreaTags = cmdletContext.StagingAreaTag;
            }
            if (cmdletContext.UseDedicatedReplicationServer != null)
            {
                request.UseDedicatedReplicationServer = cmdletContext.UseDedicatedReplicationServer.Value;
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
        
        private Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse CallAWSServiceOperation(IAmazonDrs client, Amazon.Drs.Model.UpdateReplicationConfigurationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Disaster Recovery Service", "UpdateReplicationConfigurationTemplate");
            try
            {
                return client.UpdateReplicationConfigurationTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
            public System.Boolean? AutoReplicateNewDisk { get; set; }
            public System.Int64? BandwidthThrottling { get; set; }
            public System.Boolean? CreatePublicIP { get; set; }
            public Amazon.Drs.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
            public Amazon.Drs.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
            public Amazon.Drs.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
            public System.String EbsEncryptionKeyArn { get; set; }
            public List<Amazon.Drs.Model.PITPolicyRule> PitPolicy { get; set; }
            public System.String ReplicationConfigurationTemplateID { get; set; }
            public System.String ReplicationServerInstanceType { get; set; }
            public List<System.String> ReplicationServersSecurityGroupsIDs { get; set; }
            public System.String StagingAreaSubnetId { get; set; }
            public Dictionary<System.String, System.String> StagingAreaTag { get; set; }
            public System.Boolean? UseDedicatedReplicationServer { get; set; }
            public System.Func<Amazon.Drs.Model.UpdateReplicationConfigurationTemplateResponse, UpdateEDRSReplicationConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
