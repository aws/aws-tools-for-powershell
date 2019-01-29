/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Creates a new DB cluster from a DB snapshot or DB cluster snapshot.
    /// 
    ///  
    /// <para>
    /// If a DB snapshot is specified, the target DB cluster is created from the source DB
    /// snapshot with a default configuration and default security group.
    /// </para><para>
    /// If a DB cluster snapshot is specified, the target DB cluster is created from the source
    /// DB cluster restore point with the same configuration as the original source DB cluster,
    /// except that the new DB cluster is created with the default security group.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "DOCDBClusterFromSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB RestoreDBClusterFromSnapshot API operation.", Operation = new[] {"RestoreDBClusterFromSnapshot"})]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.DocDB.Model.RestoreDBClusterFromSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreDOCDBClusterFromSnapshotCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>Provides the list of Amazon EC2 Availability Zones that instances in the restored
        /// DB cluster can be created in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster to create from the DB snapshot or DB cluster snapshot.
        /// This parameter isn't case sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-snapshot-id</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DBSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the DB subnet group to use for the new DB cluster.</para><para>Constraints: If provided, must match the name of an existing <code>DBSubnetGroup</code>.</para><para>Example: <code>mySubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter EnableCloudwatchLogsExport
        /// <summary>
        /// <para>
        /// <para>A list of log types that must be enabled for exporting to Amazon CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EnableCloudwatchLogsExports")]
        public System.String[] EnableCloudwatchLogsExport { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The database engine to use for the new DB cluster.</para><para>Default: The same as source.</para><para>Constraint: Must be compatible with the engine of the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the database engine to use for the new DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS KMS key identifier to use when restoring an encrypted DB cluster from a DB
        /// snapshot or DB cluster snapshot.</para><para>The AWS KMS key identifier is the Amazon Resource Name (ARN) for the AWS KMS encryption
        /// key. If you are restoring a DB cluster with the same AWS account that owns the AWS
        /// KMS encryption key used to encrypt the new DB cluster, then you can use the AWS KMS
        /// key alias instead of the ARN for the AWS KMS encryption key.</para><para>If you do not specify a value for the <code>KmsKeyId</code> parameter, then the following
        /// occurs:</para><ul><li><para>If the DB snapshot or DB cluster snapshot in <code>SnapshotIdentifier</code> is encrypted,
        /// then the restored DB cluster is encrypted using the AWS KMS key that was used to encrypt
        /// the DB snapshot or the DB cluster snapshot.</para></li><li><para>If the DB snapshot or the DB cluster snapshot in <code>SnapshotIdentifier</code> is
        /// not encrypted, then the restored DB cluster is not encrypted.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// <para>The port number on which the new DB cluster accepts connections.</para><para>Constraints: Must be a value from <code>1150</code> to <code>65535</code>.</para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB snapshot or DB cluster snapshot to restore from.</para><para>You can use either the name or the Amazon Resource Name (ARN) to specify a DB cluster
        /// snapshot. However, you can use only the ARN to specify a DB snapshot.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing snapshot.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the restored DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DocDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter VpcSecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of virtual private cloud (VPC) security groups that the new DB cluster will
        /// belong to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcSecurityGroupIds")]
        public System.String[] VpcSecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SnapshotIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DOCDBClusterFromSnapshot (RestoreDBClusterFromSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBSubnetGroupName = this.DBSubnetGroupName;
            if (this.EnableCloudwatchLogsExport != null)
            {
                context.EnableCloudwatchLogsExports = new List<System.String>(this.EnableCloudwatchLogsExport);
            }
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.KmsKeyId = this.KmsKeyId;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.SnapshotIdentifier = this.SnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DocDB.Model.Tag>(this.Tag);
            }
            if (this.VpcSecurityGroupId != null)
            {
                context.VpcSecurityGroupIds = new List<System.String>(this.VpcSecurityGroupId);
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
            var request = new Amazon.DocDB.Model.RestoreDBClusterFromSnapshotRequest();
            
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBSubnetGroupName != null)
            {
                request.DBSubnetGroupName = cmdletContext.DBSubnetGroupName;
            }
            if (cmdletContext.EnableCloudwatchLogsExports != null)
            {
                request.EnableCloudwatchLogsExports = cmdletContext.EnableCloudwatchLogsExports;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.DocDB.Model.RestoreDBClusterFromSnapshotResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.RestoreDBClusterFromSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB", "RestoreDBClusterFromSnapshot");
            try
            {
                #if DESKTOP
                return client.RestoreDBClusterFromSnapshot(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RestoreDBClusterFromSnapshotAsync(request);
                return task.Result;
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
            public List<System.String> AvailabilityZones { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBSubnetGroupName { get; set; }
            public List<System.String> EnableCloudwatchLogsExports { get; set; }
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Int32? Port { get; set; }
            public System.String SnapshotIdentifier { get; set; }
            public List<Amazon.DocDB.Model.Tag> Tags { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
