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
    /// Creates a new ReplicationConfigurationTemplate.
    /// </summary>
    [Cmdlet("New", "MGNReplicationConfigurationTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse")]
    [AWSCmdlet("Calls the Application Migration Service CreateReplicationConfigurationTemplate API operation.", Operation = new[] {"CreateReplicationConfigurationTemplate"}, SelectReturnType = typeof(Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse",
        "This cmdlet returns an Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse object containing multiple properties."
    )]
    public partial class NewMGNReplicationConfigurationTemplateCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociateDefaultSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Request to associate the default Application Migration Service Security group with
        /// the Replication Settings template.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
        #endregion
        
        #region Parameter BandwidthThrottling
        /// <summary>
        /// <para>
        /// <para>Request to configure bandwidth throttling during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? BandwidthThrottling { get; set; }
        #endregion
        
        #region Parameter CreatePublicIP
        /// <summary>
        /// <para>
        /// <para>Request to create Public IP during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? CreatePublicIP { get; set; }
        #endregion
        
        #region Parameter DataPlaneRouting
        /// <summary>
        /// <para>
        /// <para>Request to configure data plane routing during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationDataPlaneRouting")]
        public Amazon.Mgn.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
        #endregion
        
        #region Parameter DefaultLargeStagingDiskType
        /// <summary>
        /// <para>
        /// <para>Request to configure the default large staging disk EBS volume type during Replication
        /// Settings template creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType")]
        public Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
        #endregion
        
        #region Parameter EbsEncryption
        /// <summary>
        /// <para>
        /// <para>Request to configure EBS encryption during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Mgn.ReplicationConfigurationEbsEncryption")]
        public Amazon.Mgn.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
        #endregion
        
        #region Parameter EbsEncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>Request to configure an EBS encryption key during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EbsEncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter ReplicationServerInstanceType
        /// <summary>
        /// <para>
        /// <para>Request to configure the Replication Server instance type during Replication Settings
        /// template creation.</para>
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
        public System.String ReplicationServerInstanceType { get; set; }
        #endregion
        
        #region Parameter ReplicationServersSecurityGroupsIDs
        /// <summary>
        /// <para>
        /// <para>Request to configure the Replication Server Security group ID during Replication Settings
        /// template creation.</para>
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
        public System.String[] ReplicationServersSecurityGroupsIDs { get; set; }
        #endregion
        
        #region Parameter StagingAreaSubnetId
        /// <summary>
        /// <para>
        /// <para>Request to configure the Staging Area subnet ID during Replication Settings template
        /// creation.</para>
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
        public System.String StagingAreaSubnetId { get; set; }
        #endregion
        
        #region Parameter StagingAreaTag
        /// <summary>
        /// <para>
        /// <para>Request to configure Staging Area tags during Replication Settings template creation.</para>
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
        [Alias("StagingAreaTags")]
        public System.Collections.Hashtable StagingAreaTag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Request to configure tags during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UseDedicatedReplicationServer
        /// <summary>
        /// <para>
        /// <para>Request to use Dedicated Replication Servers during Replication Settings template
        /// creation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? UseDedicatedReplicationServer { get; set; }
        #endregion
        
        #region Parameter UseFipsEndpoint
        /// <summary>
        /// <para>
        /// <para>Request to use Fips Endpoint during Replication Settings template creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseFipsEndpoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MGNReplicationConfigurationTemplate (CreateReplicationConfigurationTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse, NewMGNReplicationConfigurationTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AssociateDefaultSecurityGroup = this.AssociateDefaultSecurityGroup;
            #if MODULAR
            if (this.AssociateDefaultSecurityGroup == null && ParameterWasBound(nameof(this.AssociateDefaultSecurityGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociateDefaultSecurityGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BandwidthThrottling = this.BandwidthThrottling;
            #if MODULAR
            if (this.BandwidthThrottling == null && ParameterWasBound(nameof(this.BandwidthThrottling)))
            {
                WriteWarning("You are passing $null as a value for parameter BandwidthThrottling which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CreatePublicIP = this.CreatePublicIP;
            #if MODULAR
            if (this.CreatePublicIP == null && ParameterWasBound(nameof(this.CreatePublicIP)))
            {
                WriteWarning("You are passing $null as a value for parameter CreatePublicIP which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataPlaneRouting = this.DataPlaneRouting;
            #if MODULAR
            if (this.DataPlaneRouting == null && ParameterWasBound(nameof(this.DataPlaneRouting)))
            {
                WriteWarning("You are passing $null as a value for parameter DataPlaneRouting which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultLargeStagingDiskType = this.DefaultLargeStagingDiskType;
            #if MODULAR
            if (this.DefaultLargeStagingDiskType == null && ParameterWasBound(nameof(this.DefaultLargeStagingDiskType)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultLargeStagingDiskType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EbsEncryption = this.EbsEncryption;
            #if MODULAR
            if (this.EbsEncryption == null && ParameterWasBound(nameof(this.EbsEncryption)))
            {
                WriteWarning("You are passing $null as a value for parameter EbsEncryption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EbsEncryptionKeyArn = this.EbsEncryptionKeyArn;
            context.ReplicationServerInstanceType = this.ReplicationServerInstanceType;
            #if MODULAR
            if (this.ReplicationServerInstanceType == null && ParameterWasBound(nameof(this.ReplicationServerInstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationServerInstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReplicationServersSecurityGroupsIDs != null)
            {
                context.ReplicationServersSecurityGroupsIDs = new List<System.String>(this.ReplicationServersSecurityGroupsIDs);
            }
            #if MODULAR
            if (this.ReplicationServersSecurityGroupsIDs == null && ParameterWasBound(nameof(this.ReplicationServersSecurityGroupsIDs)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationServersSecurityGroupsIDs which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StagingAreaSubnetId = this.StagingAreaSubnetId;
            #if MODULAR
            if (this.StagingAreaSubnetId == null && ParameterWasBound(nameof(this.StagingAreaSubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter StagingAreaSubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StagingAreaTag != null)
            {
                context.StagingAreaTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StagingAreaTag.Keys)
                {
                    context.StagingAreaTag.Add((String)hashKey, (System.String)(this.StagingAreaTag[hashKey]));
                }
            }
            #if MODULAR
            if (this.StagingAreaTag == null && ParameterWasBound(nameof(this.StagingAreaTag)))
            {
                WriteWarning("You are passing $null as a value for parameter StagingAreaTag which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.UseDedicatedReplicationServer = this.UseDedicatedReplicationServer;
            #if MODULAR
            if (this.UseDedicatedReplicationServer == null && ParameterWasBound(nameof(this.UseDedicatedReplicationServer)))
            {
                WriteWarning("You are passing $null as a value for parameter UseDedicatedReplicationServer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Mgn.Model.CreateReplicationConfigurationTemplateRequest();
            
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.CreateReplicationConfigurationTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "CreateReplicationConfigurationTemplate");
            try
            {
                #if DESKTOP
                return client.CreateReplicationConfigurationTemplate(request);
                #elif CORECLR
                return client.CreateReplicationConfigurationTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AssociateDefaultSecurityGroup { get; set; }
            public System.Int64? BandwidthThrottling { get; set; }
            public System.Boolean? CreatePublicIP { get; set; }
            public Amazon.Mgn.ReplicationConfigurationDataPlaneRouting DataPlaneRouting { get; set; }
            public Amazon.Mgn.ReplicationConfigurationDefaultLargeStagingDiskType DefaultLargeStagingDiskType { get; set; }
            public Amazon.Mgn.ReplicationConfigurationEbsEncryption EbsEncryption { get; set; }
            public System.String EbsEncryptionKeyArn { get; set; }
            public System.String ReplicationServerInstanceType { get; set; }
            public List<System.String> ReplicationServersSecurityGroupsIDs { get; set; }
            public System.String StagingAreaSubnetId { get; set; }
            public Dictionary<System.String, System.String> StagingAreaTag { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? UseDedicatedReplicationServer { get; set; }
            public System.Boolean? UseFipsEndpoint { get; set; }
            public System.Func<Amazon.Mgn.Model.CreateReplicationConfigurationTemplateResponse, NewMGNReplicationConfigurationTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
