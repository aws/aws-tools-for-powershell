/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Creates a new DB cluster from a DB cluster snapshot. The target DB cluster is created
    /// from the source DB cluster restore point with the same configuration as the original
    /// source DB cluster, except that the new DB cluster is created with the default security
    /// group. 
    /// 
    ///  
    /// <para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Restore", "RDSDBClusterFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Invokes the RestoreDBClusterFromSnapshot operation against Amazon Relational Database Service.", Operation = new[] {"RestoreDBClusterFromSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.RestoreDBClusterFromSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RestoreRDSDBClusterFromSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Provides the list of EC2 Availability Zones that instances in the restored DB cluster
        /// can be created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The database name for the restored DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DatabaseName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster to create from the DB cluster snapshot. This parameter
        /// isn't case-sensitive. </para><para>Constraints:</para><ul><li>Must contain from 1 to 255 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul><para>Example: <code>my-snapshot-id</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the DB subnet group to use for the new DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBSubnetGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The database engine to use for the new DB cluster. </para><para>Default: The same as source</para><para>Constraint: Must be compatible with the engine of the source</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The version of the database engine to use for the new DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The KMS key identifier to use when restoring an encrypted DB cluster.</para><para>The KMS key identifier is the Amazon Resource Name (ARN) for the KMS encryption key.
        /// If you are restoring a DB cluster with the same AWS account that owns the KMS encryption
        /// key used to encrypt the new DB cluster, then you can use the KMS key alias instead
        /// of the ARN for the KMS encryption key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the option group to use for the restored DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The port number on which the new DB cluster accepts connections. </para><para>Constraints: Value must be <code>1150-65535</code></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB cluster snapshot to restore from. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the restored DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A list of VPC security groups that the new DB cluster will belong to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-RDSDBClusterFromSnapshot (RestoreDBClusterFromSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            context.DatabaseName = this.DatabaseName;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.KmsKeyId = this.KmsKeyId;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<System.String>(this.VpcSecurityGroupId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.RestoreDBClusterFromSnapshotRequest();
            
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.DatabaseName != null)
            {
                request.DatabaseName = cmdletContext.DatabaseName;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.SnapshotIdentifier != null)
            {
                request.SnapshotIdentifier = cmdletContext.SnapshotIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.VpcSecurityGroupIds != null)
            {
                request.VpcSecurityGroupIds = cmdletContext.VpcSecurityGroupIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RestoreDBClusterFromSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBCluster;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AvailabilityZones { get; set; }
            public System.String DatabaseName { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
