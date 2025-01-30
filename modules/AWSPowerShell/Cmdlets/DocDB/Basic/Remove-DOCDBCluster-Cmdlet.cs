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
using Amazon.DocDB;
using Amazon.DocDB.Model;

namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Deletes a previously provisioned cluster. When you delete a cluster, all automated
    /// backups for that cluster are deleted and can't be recovered. Manual DB cluster snapshots
    /// of the specified cluster are not deleted.
    /// </summary>
    [Cmdlet("Remove", "DOCDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.DocDB.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) DeleteDBCluster API operation.", Operation = new[] {"DeleteDBCluster"}, SelectReturnType = typeof(Amazon.DocDB.Model.DeleteDBClusterResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.DBCluster or Amazon.DocDB.Model.DeleteDBClusterResponse",
        "This cmdlet returns an Amazon.DocDB.Model.DBCluster object.",
        "The service call response (type Amazon.DocDB.Model.DeleteDBClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveDOCDBClusterCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The cluster identifier for the cluster to be deleted. This parameter isn't case sensitive.</para><para>Constraints:</para><ul><li><para>Must match an existing <c>DBClusterIdentifier</c>.</para></li></ul>
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
        
        #region Parameter FinalDBSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para> The cluster snapshot identifier of the new cluster snapshot created when <c>SkipFinalSnapshot</c>
        /// is set to <c>false</c>. </para><note><para> Specifying this parameter and also setting the <c>SkipFinalShapshot</c> parameter
        /// to <c>true</c> results in an error. </para></note><para>Constraints:</para><ul><li><para>Must be from 1 to 255 letters, numbers, or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalDBSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter SkipFinalSnapshot
        /// <summary>
        /// <para>
        /// <para> Determines whether a final cluster snapshot is created before the cluster is deleted.
        /// If <c>true</c> is specified, no cluster snapshot is created. If <c>false</c> is specified,
        /// a cluster snapshot is created before the DB cluster is deleted. </para><note><para>If <c>SkipFinalSnapshot</c> is <c>false</c>, you must specify a <c>FinalDBSnapshotIdentifier</c>
        /// parameter.</para></note><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipFinalSnapshot { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.DeleteDBClusterResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.DeleteDBClusterResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DOCDBCluster (DeleteDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.DeleteDBClusterResponse, RemoveDOCDBClusterCmdlet>(Select) ??
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
            var request = new Amazon.DocDB.Model.DeleteDBClusterRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
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
        
        private Amazon.DocDB.Model.DeleteDBClusterResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.DeleteDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "DeleteDBCluster");
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
            public System.String FinalDBSnapshotIdentifier { get; set; }
            public System.Boolean? SkipFinalSnapshot { get; set; }
            public System.Func<Amazon.DocDB.Model.DeleteDBClusterResponse, RemoveDOCDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
