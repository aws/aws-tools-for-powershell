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
using Amazon.Mgn;
using Amazon.Mgn.Model;

namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Allows you to update multiple ReplicationConfigurations by Source Server ID.
    /// </summary>
    [Cmdlet("Update", "MGNReplicationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.UpdateReplicationConfigurationResponse")]
    [AWSCmdlet("Calls the Application Migration Service UpdateReplicationConfiguration API operation.", Operation = new[] {"UpdateReplicationConfiguration"}, SelectReturnType = typeof(Amazon.Mgn.Model.UpdateReplicationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.UpdateReplicationConfigurationResponse",
        "This cmdlet returns an Amazon.Mgn.Model.UpdateReplicationConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateMGNReplicationConfigurationCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Account ID request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter AssociateDefaultSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Update replication configuration associate default Application Migration Service Security
        /// group request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
        #endregion
        
        #region Parameter BandwidthThrottling
        /// <summary>
        /// <para>
        /// <para>Update replication configuration bandwidth throttling request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? BandwidthThrottling { get; set; }
        #endregion
        
        #region Parameter CreatePublicIP
        /// <summary>
        /// <para>
        /// <para>Update replication configuration create Public IP request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreatePublicIP { get; set; }
        #endregion
        
        #region Parameter DataPlaneRouting
        /// <summary>
        /// <para>
        /// <para>Update replication configuration data plane routing request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationDataPlaneRouting")]
        public Amazon.Mgn.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
        #endregion
        
        #region Parameter DefaultLargeStagingDiskType
        /// <summary>
        /// <para>
        /// <para>Update replication configuration use default large Staging Disk type request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType")]
        public Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
        #endregion
        
        #region Parameter EbsEncryption
        /// <summary>
        /// <para>
        /// <para>Update replication configuration EBS encryption request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationEbsEncryption")]
        public Amazon.Mgn.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
        #endregion
        
        #region Parameter EbsEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>Update replication configuration EBS encryption key ARN request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EbsEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter InternetProtocol
        /// <summary>
        /// <para>
        /// <para>Update replication configuration internet protocol.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Mgn.InternetProtocol")]
        public Amazon.Mgn.InternetProtocol InternetProtocol { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Update replication configuration name request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReplicatedDisk
        /// <summary>
        /// <para>
        /// <para>Update replication configuration replicated disks request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicatedDisks")]
        public Amazon.Mgn.Model.ReplicationConfigurationReplicatedDisk[] ReplicatedDisk { get; set; }
        #endregion
        
        #region Parameter ReplicationServerInstanceType
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Replication Server instance type request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationServerInstanceType { get; set; }
        #endregion
        
        #region Parameter ReplicationServersSecurityGroupsIDs
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Replication Server Security Groups IDs request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicationServersSecurityGroupsIDs { get; set; }
        #endregion
        
        #region Parameter SourceServerID
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Source Server ID request.</para>
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
        public System.String SourceServerID { get; set; }
        #endregion
        
        #region Parameter StagingAreaSubnetId
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Staging Area subnet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StagingAreaSubnetId { get; set; }
        #endregion
        
        #region Parameter StagingAreaTag
        /// <summary>
        /// <para>
        /// <para>Update replication configuration Staging Area Tags request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StagingAreaTags")]
        public System.Collections.Hashtable StagingAreaTag { get; set; }
        #endregion
        
        #region Parameter UseDedicatedReplicationServer
        /// <summary>
        /// <para>
        /// <para>Update replication configuration use dedicated Replication Server request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseDedicatedReplicationServer { get; set; }
        #endregion
        
        #region Parameter UseFipsEndpoint
        /// <summary>
        /// <para>
        /// <para>Update replication configuration use Fips Endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseFipsEndpoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.UpdateReplicationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.UpdateReplicationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceServerID parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceServerID' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceServerID), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGNReplicationConfiguration (UpdateReplicationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.UpdateReplicationConfigurationResponse, UpdateMGNReplicationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceServerID;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountID = this.AccountID;
            context.AssociateDefaultSecurityGroup = this.AssociateDefaultSecurityGroup;
            context.BandwidthThrottling = this.BandwidthThrottling;
            context.CreatePublicIP = this.CreatePublicIP;
            context.DataPlaneRouting = this.DataPlaneRouting;
            context.DefaultLargeStagingDiskType = this.DefaultLargeStagingDiskType;
            context.EbsEncryption = this.EbsEncryption;
            context.EbsEncryptionKeyArn = this.EbsEncryptionKeyArn;
            context.InternetProtocol = this.InternetProtocol;
            context.Name = this.Name;
            if (this.ReplicatedDisk != null)
            {
                context.ReplicatedDisk = new List<Amazon.Mgn.Model.ReplicationConfigurationReplicatedDisk>(this.ReplicatedDisk);
            }
            context.ReplicationServerInstanceType = this.ReplicationServerInstanceType;
            if (this.ReplicationServersSecurityGroupsIDs != null)
            {
                context.ReplicationServersSecurityGroupsIDs = new List<System.String>(this.ReplicationServersSecurityGroupsIDs);
            }
            context.SourceServerID = this.SourceServerID;
            #if MODULAR
            if (this.SourceServerID == null && ParameterWasBound(nameof(this.SourceServerID)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceServerID which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.UseFipsEndpoint = this.UseFipsEndpoint;
            
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
            var request = new Amazon.Mgn.Model.UpdateReplicationConfigurationRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            if (cmdletContext.AssociateDefaultSecurityGroup != null)
            {
                request.AssociateDefaultSecurityGroup = cmdletContext.AssociateDefaultSecurityGroup.Value;
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
            if (cmdletContext.InternetProtocol != null)
            {
                request.InternetProtocol = cmdletContext.InternetProtocol;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ReplicatedDisk != null)
            {
                request.ReplicatedDisks = cmdletContext.ReplicatedDisk;
            }
            if (cmdletContext.ReplicationServerInstanceType != null)
            {
                request.ReplicationServerInstanceType = cmdletContext.ReplicationServerInstanceType;
            }
            if (cmdletContext.ReplicationServersSecurityGroupsIDs != null)
            {
                request.ReplicationServersSecurityGroupsIDs = cmdletContext.ReplicationServersSecurityGroupsIDs;
            }
            if (cmdletContext.SourceServerID != null)
            {
                request.SourceServerID = cmdletContext.SourceServerID;
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
            if (cmdletContext.UseFipsEndpoint != null)
            {
                request.UseFipsEndpoint = cmdletContext.UseFipsEndpoint.Value;
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
        
        private Amazon.Mgn.Model.UpdateReplicationConfigurationResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.UpdateReplicationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "UpdateReplicationConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateReplicationConfiguration(request);
                #elif CORECLR
                return client.UpdateReplicationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
            public System.Int64? BandwidthThrottling { get; set; }
            public System.Boolean? CreatePublicIP { get; set; }
            public Amazon.Mgn.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
            public Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
            public Amazon.Mgn.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
            public System.String EbsEncryptionKeyArn { get; set; }
            public Amazon.Mgn.InternetProtocol InternetProtocol { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Mgn.Model.ReplicationConfigurationReplicatedDisk> ReplicatedDisk { get; set; }
            public System.String ReplicationServerInstanceType { get; set; }
            public List<System.String> ReplicationServersSecurityGroupsIDs { get; set; }
            public System.String SourceServerID { get; set; }
            public System.String StagingAreaSubnetId { get; set; }
            public Dictionary<System.String, System.String> StagingAreaTag { get; set; }
            public System.Boolean? UseDedicatedReplicationServer { get; set; }
            public System.Boolean? UseFipsEndpoint { get; set; }
            public System.Func<Amazon.Mgn.Model.UpdateReplicationConfigurationResponse, UpdateMGNReplicationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
