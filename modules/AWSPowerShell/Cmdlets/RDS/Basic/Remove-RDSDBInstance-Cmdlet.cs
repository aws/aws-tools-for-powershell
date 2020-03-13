/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// When a DB instance is in a failure state and has a status of <code>failed</code>,
    /// <code>incompatible-restore</code>, or <code>incompatible-network</code>, you can only
    /// delete it when you skip creation of the final snapshot with the <code>SkipFinalSnapshot</code>
    /// parameter.
    /// </para><para>
    /// If the specified DB instance is part of an Amazon Aurora DB cluster, you can't delete
    /// the DB instance if both of the following conditions are true:
    /// </para><ul><li><para>
    /// The DB cluster is a read replica of another Amazon Aurora DB cluster.
    /// </para></li><li><para>
    /// The DB instance is the only instance in the DB cluster.
    /// </para></li></ul><para>
    /// To delete a DB instance in this case, first call the <code>PromoteReadReplicaDBCluster</code>
    /// API action to promote the DB cluster so it's no longer a read replica. After the promotion
    /// completes, then call the <code>DeleteDBInstance</code> API action to delete the final
    /// instance in the DB cluster.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RDSDBInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBInstance API operation.", Operation = new[] {"DeleteDBInstance"}, SelectReturnType = typeof(Amazon.RDS.Model.DeleteDBInstanceResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.DeleteDBInstanceResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter DeleteAutomatedBackup
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to remove automated backups immediately after the DB
        /// instance is deleted. This parameter isn't case-sensitive. The default is to remove
        /// automated backups immediately after the DB instance is deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAutomatedBackups")]
        public System.Boolean? DeleteAutomatedBackup { get; set; }
        #endregion
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The <code>DBSnapshotIdentifier</code> of the new <code>DBSnapshot</code> created
        /// when the <code>SkipFinalSnapshot</code> parameter is disabled. </para><note><para>Specifying this parameter and also specifying to skip final DB snapshot creation in
        /// SkipFinalShapshot results in an error.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters or numbers.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Can't be specified when deleting a read replica.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether to skip the creation of a final DB snapshot before
        /// the DB instance is deleted. If skip is specified, no DB snapshot is created. If skip
        /// isn't specified, a DB snapshot is created before the DB instance is deleted. By default,
        /// skip isn't specified, and the DB snapshot is created.</para><para>When a DB instance is in a failure state and has a status of 'failed', 'incompatible-restore',
        /// or 'incompatible-network', it can only be deleted when skip is specified.</para><para>Specify skip when deleting a read replica.</para><note><para>The FinalDBSnapshotIdentifier parameter must be specified if skip isn't specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipFinalSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DeleteDBInstanceResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DeleteDBInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBInstance (DeleteDBInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DeleteDBInstanceResponse, RemoveRDSDBInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeleteAutomatedBackup = this.DeleteAutomatedBackup;
            context.FinalDBSnapshotIdentifier = this.FinalDBSnapshotIdentifier;
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
            if (cmdletContext.DeleteAutomatedBackup != null)
            {
                request.DeleteAutomatedBackups = cmdletContext.DeleteAutomatedBackup.Value;
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
        
        private Amazon.RDS.Model.DeleteDBInstanceResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBInstance");
            try
            {
                #if DESKTOP
                return client.DeleteDBInstance(request);
                #elif CORECLR
                return client.DeleteDBInstanceAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteAutomatedBackup { get; set; }
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
            public System.Func<Amazon.RDS.Model.DeleteDBInstanceResponse, RemoveRDSDBInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
