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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// The DeleteDBInstance action deletes a previously provisioned DB instance. When you
    /// delete a DB instance, all automated backups for that instance are deleted and can't
    /// be recovered. Manual DB snapshots of the DB instance to be deleted by <code>DeleteDBInstance</code>
    /// are not deleted.
    /// 
    ///  
    /// <para>
    ///  If you request a final DB snapshot the status of the Amazon RDS DB instance is <code>deleting</code>
    /// until the DB snapshot is created. The API action <code>DescribeDBInstance</code> is
    /// used to monitor the status of this operation. The action can't be canceled or reverted
    /// once submitted. 
    /// </para><para>
    /// Note that when a DB instance is in a failure state and has a status of <code>failed</code>,
    /// <code>incompatible-restore</code>, or <code>incompatible-network</code>, you can only
    /// delete it when the <code>SkipFinalSnapshot</code> parameter is set to <code>true</code>.
    /// </para><para>
    /// If the specified DB instance is part of an Amazon Aurora DB cluster, you can't delete
    /// the DB instance if both of the following conditions are true:
    /// </para><ul><li><para>
    /// The DB cluster is a Read Replica of another Amazon Aurora DB cluster.
    /// </para></li><li><para>
    /// The DB instance is the only instance in the DB cluster.
    /// </para></li></ul><para>
    /// To delete a DB instance in this case, first call the <a>PromoteReadReplicaDBCluster</a>
    /// API action to promote the DB cluster so it's no longer a Read Replica. After the promotion
    /// completes, then call the <code>DeleteDBInstance</code> API action to delete the final
    /// instance in the DB cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBInstance API operation.", Operation = new[] {"DeleteDBInstance"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance",
        "This cmdlet returns a DBInstance object.",
        "The service call response (type Amazon.RDS.Model.DeleteDBInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRDSDBInstanceCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier for the DB instance to be deleted. This parameter isn't
        /// case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the name of an existing DB instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DeleteAutomatedBackup
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to remove automated backups immediately after the DB
        /// instance is deleted. This parameter isn't case-sensitive. This parameter defaults
        /// to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeleteAutomatedBackups")]
        public System.Boolean DeleteAutomatedBackup { get; set; }
        #endregion
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The <code>DBSnapshotIdentifier</code> of the new DB snapshot created when <code>SkipFinalSnapshot</code>
        /// is set to <code>false</code>. </para><note><para>Specifying this parameter and also setting the <code>SkipFinalShapshot</code> parameter
        /// to <code>true</code> results in an error.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Can't be specified when deleting a Read Replica.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para> A value that indicates whether a final DB snapshot is created before the DB instance
        /// is deleted. If <code>true</code> is specified, no DB snapshot is created. If <code>false</code>
        /// is specified, a DB snapshot is created before the DB instance is deleted. </para><para>When a DB instance is in a failure state and has a status of <code>failed</code>,
        /// <code>incompatible-restore</code>, or <code>incompatible-network</code>, you can only
        /// delete it when the <code>SkipFinalSnapshot</code> parameter is set to <code>true</code>.</para><para>Specify <code>true</code> when deleting a Read Replica.</para><note><para>The <code>FinalDBSnapshotIdentifier</code> parameter must be specified if <code>SkipFinalSnapshot</code>
        /// is <code>false</code>.</para></note><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SkipFinalSnapshot { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBInstanceIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBInstance (DeleteDBInstance)"))
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
            
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            if (ParameterWasBound("DeleteAutomatedBackup"))
                context.DeleteAutomatedBackups = this.DeleteAutomatedBackup;
            context.FinalDBSnapshotIdentifier = this.FinalDBSnapshotIdentifier;
            if (ParameterWasBound("SkipFinalSnapshot"))
                context.SkipFinalSnapshot = this.SkipFinalSnapshot;
            
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
            var request = new Amazon.RDS.Model.DeleteDBInstanceRequest();
            
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.DeleteAutomatedBackups != null)
            {
                request.DeleteAutomatedBackups = cmdletContext.DeleteAutomatedBackups.Value;
            }
            if (cmdletContext.FinalDBSnapshotIdentifier != null)
            {
                request.FinalDBSnapshotIdentifier = cmdletContext.FinalDBSnapshotIdentifier;
            }
            if (cmdletContext.SkipFinalSnapshot != null)
            {
                request.SkipFinalSnapshot = cmdletContext.SkipFinalSnapshot.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.RDS.Model.DeleteDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBInstance");
            try
            {
                #if DESKTOP
                return client.DeleteDBInstance(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteDBInstanceAsync(request);
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
            public System.String DBInstanceIdentifier { get; set; }
            public System.Boolean? DeleteAutomatedBackups { get; set; }
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
        }
        
    }
}
