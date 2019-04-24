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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Deletes a previously provisioned cluster. A successful response from the web service
    /// indicates that the request was received correctly. Use <a>DescribeClusters</a> to
    /// monitor the status of the deletion. The delete operation cannot be canceled or reverted
    /// once submitted. For more information about managing clusters, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    ///  
    /// <para>
    /// If you want to shut down the cluster and retain it for future use, set <i>SkipFinalClusterSnapshot</i>
    /// to <code>false</code> and specify a name for <i>FinalClusterSnapshotIdentifier</i>.
    /// You can later restore this snapshot to resume using the cluster. If a final cluster
    /// snapshot is requested, the status of the cluster will be "final-snapshot" while the
    /// snapshot is being taken, then it's "deleting" once Amazon Redshift begins deleting
    /// the cluster. 
    /// </para><para>
    ///  For more information about managing clusters, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Calls the Amazon Redshift DeleteCluster API operation.", Operation = new[] {"DeleteCluster"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.DeleteClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveRSClusterCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster to be deleted.</para><para>Constraints:</para><ul><li><para>Must contain lowercase characters.</para></li><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter FinalClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the final snapshot that is to be created immediately before deleting
        /// the cluster. If this parameter is provided, <i>SkipFinalClusterSnapshot</i> must be
        /// <code>false</code>. </para><para>Constraints:</para><ul><li><para>Must be 1 to 255 alphanumeric characters.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FinalClusterSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter FinalClusterSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that a manual snapshot is retained. If the value is -1, the manual
        /// snapshot is retained indefinitely.</para><para>The value must be either -1 or an integer between 1 and 3,653.</para><para>The default value is -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 FinalClusterSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter SkipFinalClusterSnapshot
        /// <summary>
        /// <para>
        /// <para>Determines whether a final snapshot of the cluster is created before Amazon Redshift
        /// deletes the cluster. If <code>true</code>, a final cluster snapshot is not created.
        /// If <code>false</code>, a final cluster snapshot is created before the cluster is deleted.
        /// </para><note><para>The <i>FinalClusterSnapshotIdentifier</i> parameter must be specified if <i>SkipFinalClusterSnapshot</i>
        /// is <code>false</code>.</para></note><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SkipFinalClusterSnapshot { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RSCluster (DeleteCluster)"))
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
            
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.FinalClusterSnapshotIdentifier = this.FinalClusterSnapshotIdentifier;
            if (ParameterWasBound("FinalClusterSnapshotRetentionPeriod"))
                context.FinalClusterSnapshotRetentionPeriod = this.FinalClusterSnapshotRetentionPeriod;
            if (ParameterWasBound("SkipFinalClusterSnapshot"))
                context.SkipFinalClusterSnapshot = this.SkipFinalClusterSnapshot;
            
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
            var request = new Amazon.Redshift.Model.DeleteClusterRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.FinalClusterSnapshotIdentifier != null)
            {
                request.FinalClusterSnapshotIdentifier = cmdletContext.FinalClusterSnapshotIdentifier;
            }
            if (cmdletContext.FinalClusterSnapshotRetentionPeriod != null)
            {
                request.FinalClusterSnapshotRetentionPeriod = cmdletContext.FinalClusterSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.SkipFinalClusterSnapshot != null)
            {
                request.SkipFinalClusterSnapshot = cmdletContext.SkipFinalClusterSnapshot.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
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
        
        private Amazon.Redshift.Model.DeleteClusterResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.DeleteClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "DeleteCluster");
            try
            {
                #if DESKTOP
                return client.DeleteCluster(request);
                #elif CORECLR
                return client.DeleteClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterIdentifier { get; set; }
            public System.String FinalClusterSnapshotIdentifier { get; set; }
            public System.Int32? FinalClusterSnapshotRetentionPeriod { get; set; }
            public System.Boolean? SkipFinalClusterSnapshot { get; set; }
        }
        
    }
}
