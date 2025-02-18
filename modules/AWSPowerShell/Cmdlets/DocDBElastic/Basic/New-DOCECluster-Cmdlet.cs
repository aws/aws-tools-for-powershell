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
using Amazon.DocDBElastic;
using Amazon.DocDBElastic.Model;

namespace Amazon.PowerShell.Cmdlets.DOCE
{
    /// <summary>
    /// Creates a new Amazon DocumentDB elastic cluster and returns its cluster structure.
    /// </summary>
    [Cmdlet("New", "DOCECluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDBElastic.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB Elastic Clusters CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.DocDBElastic.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.DocDBElastic.Model.Cluster or Amazon.DocDBElastic.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.DocDBElastic.Model.Cluster object.",
        "The service call response (type Amazon.DocDBElastic.Model.CreateClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDOCEClusterCmdlet : AmazonDocDBElasticClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdminUserName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon DocumentDB elastic clusters administrator.</para><para><i>Constraints</i>:</para><ul><li><para>Must be from 1 to 63 letters or numbers.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot be a reserved word.</para></li></ul>
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
        public System.String AdminUserName { get; set; }
        #endregion
        
        #region Parameter AdminUserPassword
        /// <summary>
        /// <para>
        /// <para>The password for the Amazon DocumentDB elastic clusters administrator. The password
        /// can contain any printable ASCII characters.</para><para><i>Constraints</i>:</para><ul><li><para>Must contain from 8 to 100 characters.</para></li><li><para>Cannot contain a forward slash (/), double quote ("), or the "at" symbol (@).</para></li></ul>
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
        public System.String AdminUserPassword { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The authentication type used to determine where to fetch the password used for accessing
        /// the elastic cluster. Valid types are <c>PLAIN_TEXT</c> or <c>SECRET_ARN</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DocDBElastic.Auth")]
        public Amazon.DocDBElastic.Auth AuthType { get; set; }
        #endregion
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automatic snapshots are retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the new elastic cluster. This parameter is stored as a lowercase string.</para><para><i>Constraints</i>:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para><i>Example</i>: <c>my-cluster</c></para>
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
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier to use to encrypt the new elastic cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are creating a cluster using the same Amazon account that owns this KMS encryption
        /// key, you can use the KMS key alias instead of the ARN as the KMS encryption key.</para><para>If an encryption key is not specified, Amazon DocumentDB uses the default encryption
        /// key that KMS creates for your account. Your account has a different default encryption
        /// key for each Amazon Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, as determined by the <c>backupRetentionPeriod</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC).</para><para><i>Format</i>: <c>ddd:hh24:mi-ddd:hh24:mi</c></para><para><i>Default</i>: a 30-minute window selected at random from an 8-hour block of time
        /// for each Amazon Web Services Region, occurring on a random day of the week.</para><para><i>Valid days</i>: Mon, Tue, Wed, Thu, Fri, Sat, Sun</para><para><i>Constraints</i>: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ShardCapacity
        /// <summary>
        /// <para>
        /// <para>The number of vCPUs assigned to each elastic cluster shard. Maximum is 64. Allowed
        /// values are 2, 4, 8, 16, 32, 64.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ShardCapacity { get; set; }
        #endregion
        
        #region Parameter ShardCount
        /// <summary>
        /// <para>
        /// <para>The number of shards assigned to the elastic cluster. Maximum is 32.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ShardCount { get; set; }
        #endregion
        
        #region Parameter ShardInstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of replica instances applying to all shards in the elastic cluster. A <c>shardInstanceCount</c>
        /// value of 1 means there is one writer instance, and any additional instances are replicas
        /// that can be used for reads and to improve availability.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ShardInstanceCount { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The Amazon EC2 subnet IDs for the new elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the new elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of EC2 VPC security groups to associate with the new elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token for the elastic cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Cluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDBElastic.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.DocDBElastic.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Cluster";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DOCECluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDBElastic.Model.CreateClusterResponse, NewDOCEClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminUserName = this.AdminUserName;
            #if MODULAR
            if (this.AdminUserName == null && ParameterWasBound(nameof(this.AdminUserName)))
            {
                WriteWarning("You are passing $null as a value for parameter AdminUserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AdminUserPassword = this.AdminUserPassword;
            #if MODULAR
            if (this.AdminUserPassword == null && ParameterWasBound(nameof(this.AdminUserPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter AdminUserPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthType = this.AuthType;
            #if MODULAR
            if (this.AuthType == null && ParameterWasBound(nameof(this.AuthType)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.ClientToken = this.ClientToken;
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KmsKeyId = this.KmsKeyId;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            context.ShardCapacity = this.ShardCapacity;
            #if MODULAR
            if (this.ShardCapacity == null && ParameterWasBound(nameof(this.ShardCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardCount = this.ShardCount;
            #if MODULAR
            if (this.ShardCount == null && ParameterWasBound(nameof(this.ShardCount)))
            {
                WriteWarning("You are passing $null as a value for parameter ShardCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ShardInstanceCount = this.ShardInstanceCount;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupId = new List<System.String>(this.VpcSecurityGroupId);
            }
            
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
            var request = new Amazon.DocDBElastic.Model.CreateClusterRequest();
            
            if (cmdletContext.AdminUserName != null)
            {
                request.AdminUserName = cmdletContext.AdminUserName;
            }
            if (cmdletContext.AdminUserPassword != null)
            {
                request.AdminUserPassword = cmdletContext.AdminUserPassword;
            }
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.ShardCapacity != null)
            {
                request.ShardCapacity = cmdletContext.ShardCapacity.Value;
            }
            if (cmdletContext.ShardCount != null)
            {
                request.ShardCount = cmdletContext.ShardCount.Value;
            }
            if (cmdletContext.ShardInstanceCount != null)
            {
                request.ShardInstanceCount = cmdletContext.ShardInstanceCount.Value;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VpcSecurityGroupId != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupId;
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
        
        private Amazon.DocDBElastic.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonDocDBElastic client, Amazon.DocDBElastic.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB Elastic Clusters", "CreateCluster");
            try
            {
                return client.CreateClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AdminUserName { get; set; }
            public System.String AdminUserPassword { get; set; }
            public Amazon.DocDBElastic.Auth AuthType { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ClusterName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Int32? ShardCapacity { get; set; }
            public System.Int32? ShardCount { get; set; }
            public System.Int32? ShardInstanceCount { get; set; }
            public List<System.String> SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcSecurityGroupId { get; set; }
            public System.Func<Amazon.DocDBElastic.Model.CreateClusterResponse, NewDOCEClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Cluster;
        }
        
    }
}
