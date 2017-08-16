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
    /// The DeleteDBInstance action deletes a previously provisioned DB instance. When you
    /// delete a DB instance, all automated backups for that instance are deleted and cannot
    /// be recovered. Manual DB snapshots of the DB instance to be deleted by <code>DeleteDBInstance</code>
    /// are not deleted.
    /// 
    ///  
    /// <para>
    ///  If you request a final DB snapshot the status of the Amazon RDS DB instance is <code>deleting</code>
    /// until the DB snapshot is created. The API action <code>DescribeDBInstance</code> is
    /// used to monitor the status of this operation. The action cannot be canceled or reverted
    /// once submitted. 
    /// </para><para>
    /// Note that when a DB instance is in a failure state and has a status of <code>failed</code>,
    /// <code>incompatible-restore</code>, or <code>incompatible-network</code>, you can only
    /// delete it when the <code>SkipFinalSnapshot</code> parameter is set to <code>true</code>.
    /// </para><para>
    /// If the specified DB instance is part of an Amazon Aurora DB cluster, you cannot delete
    /// the DB instance if the following are true:
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
    [AWSCmdlet("Invokes the DeleteDBInstance operation against Amazon Relational Database Service.", Operation = new[] {"DeleteDBInstance"})]
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
        /// case-sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The DBSnapshotIdentifier of the new DBSnapshot created when SkipFinalSnapshot is
        /// set to <code>false</code>. </para><note><para>Specifying this parameter and also setting the SkipFinalShapshot parameter to true
        /// results in an error.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li><li><para>Cannot be specified when deleting a Read Replica.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para> Determines whether a final DB snapshot is created before the DB instance is deleted.
        /// If <code>true</code> is specified, no DBSnapshot is created. If <code>false</code>
        /// is specified, a DB snapshot is created before the DB instance is deleted. </para><para>Note that when a DB instance is in a failure state and has a status of 'failed', 'incompatible-restore',
        /// or 'incompatible-network', it can only be deleted when the SkipFinalSnapshot parameter
        /// is set to "true".</para><para>Specify <code>true</code> when deleting a Read Replica.</para><note><para>The FinalDBSnapshotIdentifier parameter must be specified if SkipFinalSnapshot is
        /// <code>false</code>.</para></note><para>Default: <code>false</code></para>
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
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
        }
        
    }
}
