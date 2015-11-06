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
    /// Modify a setting for an Amazon Aurora DB cluster. You can change one or more database
    /// configuration parameters by specifying these parameters and the new values in the
    /// request. For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i>
    /// </summary>
    [Cmdlet("Edit", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Invokes the ModifyDBCluster operation against Amazon Relational Database Service.", Operation = new[] {"ModifyDBCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A value that specifies whether the modifications in this request and any pending modifications
        /// are asynchronously applied as soon as possible, regardless of the <code>PreferredMaintenanceWindow</code>
        /// setting for the DB cluster. </para><para>If this parameter is set to <code>false</code>, changes to the DB cluster are applied
        /// during the next maintenance window.</para><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. You must specify a minimum
        /// value of 1. </para><para>Default: 1 </para><para>Constraints:</para><ul><li>Must be a value from 1 to 35</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BackupRetentionPeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier for the cluster being modified. This parameter is not case-sensitive.
        /// </para><para>Constraints:</para><ul><li>Must be the identifier for an existing DB cluster.</li><li>Must contain
        /// from 1 to 63 alphanumeric characters or hyphens.</li><li>First character must be
        /// a letter.</li><li>Cannot end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the DB cluster parameter group to use for the DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBClusterParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The new password for the master database user. This password can contain any printable
        /// ASCII character except "/", """, or "@". </para><para>Constraints: Must contain from 8 to 41 characters. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MasterUserPassword { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The new DB cluster identifier for the DB cluster when renaming a DB cluster. This
        /// value is stored as a lowercase string. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens</li><li>First
        /// character must be a letter</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens</li></ul><para>Example: <code>my-cluster2</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewDBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A value that indicates that the DB cluster should be associated with the specified
        /// option group. Changing this parameter does not result in an outage except in the following
        /// case, and the change is applied during the next maintenance window unless the <code>ApplyImmediately</code>
        /// parameter is set to <code>true</code> for this request. If the parameter change results
        /// in an option group that enables OEM, this change can cause a brief (sub-second) period
        /// during which new connections are rejected but existing connections are not interrupted.
        /// </para><para>Permanent options cannot be removed from an option group. The option group cannot
        /// be removed from a DB cluster once it is associated with a DB cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptionGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The port number on which the DB cluster accepts connections. </para><para>Constraints: Value must be <code>1150-65535</code></para><para>Default: The same port as the original DB cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. </para><para>Default: A 30-minute window selected at random from an 8-hour block of time per region.
        /// To see the time blocks available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints:</para><ul><li>Must be in the format <code>hh24:mi-hh24:mi</code>.</li><li>Times should
        /// be in Universal Coordinated Time (UTC).</li><li>Must not conflict with the preferred
        /// maintenance window.</li><li>Must be at least 30 minutes.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The weekly time range during which system maintenance can occur, in Universal Coordinated
        /// Time (UTC). </para><para> Format: <code>ddd:hh24:mi-ddd:hh24:mi</code></para><para>Default: A 30-minute window selected at random from an 8-hour block of time per region,
        /// occurring on a random day of the week. To see the time blocks available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Valid Days: Mon, Tue, Wed, Thu, Fri, Sat, Sun</para><para>Constraints: Minimum 30-minute window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> A lst of VPC security groups that the DB cluster will belong to. </para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBCluster (ModifyDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.MasterUserPassword = this.MasterUserPassword;
            context.NewDBClusterIdentifier = this.NewDBClusterIdentifier;
            context.OptionGroupName = this.OptionGroupName;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
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
            var request = new Amazon.RDS.Model.ModifyDBClusterRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.MasterUserPassword != null)
            {
                request.MasterUserPassword = cmdletContext.MasterUserPassword;
            }
            if (cmdletContext.NewDBClusterIdentifier != null)
            {
                request.NewDBClusterIdentifier = cmdletContext.NewDBClusterIdentifier;
            }
            if (cmdletContext.OptionGroupName != null)
            {
                request.OptionGroupName = cmdletContext.OptionGroupName;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
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
                var response = client.ModifyDBCluster(request);
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String MasterUserPassword { get; set; }
            public System.String NewDBClusterIdentifier { get; set; }
            public System.String OptionGroupName { get; set; }
            public System.Int32? Port { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<System.String> VpcSecurityGroupIds { get; set; }
        }
        
    }
}
