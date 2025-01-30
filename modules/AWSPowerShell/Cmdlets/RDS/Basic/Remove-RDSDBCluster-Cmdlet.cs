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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// The DeleteDBCluster action deletes a previously provisioned DB cluster. When you delete
    /// a DB cluster, all automated backups for that DB cluster are deleted and can't be recovered.
    /// Manual DB cluster snapshots of the specified DB cluster are not deleted.
    /// 
    ///  
    /// <para>
    /// If you're deleting a Multi-AZ DB cluster with read replicas, all cluster members are
    /// terminated and read replicas are promoted to standalone instances.
    /// </para><para>
    /// For more information on Amazon Aurora, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBCluster API operation.", Operation = new[] {"DeleteDBCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.DeleteDBClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster or Amazon.RDS.Model.DeleteDBClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCluster object.",
        "The service call response (type Amazon.RDS.Model.DeleteDBClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier for the DB cluster to be deleted. This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match an existing DBClusterIdentifier.</para></li></ul>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter DeleteAutomatedBackup
        /// <summary>
        /// <para>
        /// <para>Specifies whether to remove automated backups immediately after the DB cluster is
        /// deleted. This parameter isn't case-sensitive. The default is to remove automated backups
        /// immediately after the DB cluster is deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeleteAutomatedBackups")]
        public System.Boolean? DeleteAutomatedBackup { get; set; }
        #endregion
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster snapshot identifier of the new DB cluster snapshot created when <c>SkipFinalSnapshot</c>
        /// is disabled.</para><note><para>If you specify this parameter and also skip the creation of a final DB cluster snapshot
        /// with the <c>SkipFinalShapshot</c> parameter, the request results in an error.</para></note><para>Constraints:</para><ul><li><para>Must be 1 to 255 letters, numbers, or hyphens.</para></li><li><para>First character must be a letter</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether to skip the creation of a final DB cluster snapshot before RDS deletes
        /// the DB cluster. If you set this value to <c>true</c>, RDS doesn't create a final DB
        /// cluster snapshot. If you set this value to <c>false</c> or don't specify it, RDS creates
        /// a DB cluster snapshot before it deletes the DB cluster. By default, this parameter
        /// is disabled, so RDS creates a final DB cluster snapshot.</para><note><para>If <c>SkipFinalSnapshot</c> is disabled, you must specify a value for the <c>FinalDBSnapshotIdentifier</c>
        /// parameter.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipFinalSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DeleteDBClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DeleteDBClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBClusterIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBClusterIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBCluster (DeleteDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DeleteDBClusterResponse, RemoveRDSDBClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBClusterIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.DeleteDBClusterRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
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
        
        private Amazon.RDS.Model.DeleteDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBCluster");
            try
            {
                #if DESKTOP
                return client.DeleteDBCluster(request);
                #elif CORECLR
                return client.DeleteDBClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterIdentifier { get; set; }
            public System.Boolean? DeleteAutomatedBackup { get; set; }
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
            public System.Func<Amazon.RDS.Model.DeleteDBClusterResponse, RemoveRDSDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
