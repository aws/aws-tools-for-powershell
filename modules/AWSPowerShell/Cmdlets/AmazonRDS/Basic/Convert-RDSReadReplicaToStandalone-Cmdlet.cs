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
    /// Promotes a Read Replica DB instance to a standalone DB instance. 
    /// 
    ///  <note><para>
    /// We recommend that you enable automated backups on your Read Replica before promoting
    /// the Read Replica. This ensures that no backup is taken during the promotion process.
    /// Once the instance is promoted to a primary instance, backups are taken based on your
    /// backup settings.
    /// </para></note>
    /// </summary>
    [Cmdlet("Convert", "RDSReadReplicaToStandalone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Invokes the PromoteReadReplica operation against Amazon Relational Database Service.", Operation = new[] {"PromoteReadReplica"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type PromoteReadReplicaResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class ConvertRDSReadReplicaToStandaloneCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The number of days to retain automated backups. Setting this parameter to a positive
        /// number enables backups. Setting this parameter to 0 disables automated backups. </para><para> Default: 1 </para><para>Constraints:</para><ul><li>Must be a value from 0 to 8</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 BackupRetentionPeriod { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The DB instance identifier. This value is stored as a lowercase string. </para><para>Constraints:</para><ul><li>Must be the identifier for an existing Read Replica DB instance</li><li>Must
        /// contain from 1 to 63 alphanumeric characters or hyphens</li><li>First character must
        /// be a letter</li><li>Cannot end with a hyphen or contain two consecutive hyphens</li></ul><para>Example: <code>mydbinstance</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String DBInstanceIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. </para><para> Default: A 30-minute window selected at random from an 8-hour block of time per region.
        /// To see the time blocks available, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints:</para><ul><li>Must be in the format <code>hh24:mi-hh24:mi</code>.</li><li>Times should
        /// be in Universal Coordinated Time (UTC).</li><li>Must not conflict with the preferred
        /// maintenance window.</li><li>Must be at least 30 minutes.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String PreferredBackupWindow { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-RDSReadReplicaToStandalone (PromoteReadReplica)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("BackupRetentionPeriod"))
                context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PromoteReadReplicaRequest();
            
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PromoteReadReplica(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBInstance;
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
            public Int32? BackupRetentionPeriod { get; set; }
            public String DBInstanceIdentifier { get; set; }
            public String PreferredBackupWindow { get; set; }
        }
        
    }
}
