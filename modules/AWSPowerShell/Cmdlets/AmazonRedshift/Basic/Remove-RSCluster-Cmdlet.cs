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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Deletes a previously provisioned cluster. A successful response from the web service
    /// indicates that the request was received correctly. Use <a>DescribeClusters</a> to
    /// monitor the status of the deletion. The delete operation cannot be canceled or reverted
    /// once submitted. For more information about managing clusters, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i> . 
    /// 
    ///  
    /// <para>
    ///  If you want to shut down the cluster and retain it for future use, set <i>SkipFinalClusterSnapshot</i>
    /// to <code>false</code> and specify a name for <i>FinalClusterSnapshotIdentifier</i>.
    /// You can later restore this snapshot to resume using the cluster. If a final cluster
    /// snapshot is requested, the status of the cluster will be "final-snapshot" while the
    /// snapshot is being taken, then it's "deleting" once Amazon Redshift begins deleting
    /// the cluster. 
    /// </para><para>
    ///  For more information about managing clusters, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-clusters.html">Amazon
    /// Redshift Clusters</a> in the <i>Amazon Redshift Cluster Management Guide</i> . 
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "RSCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Invokes the DeleteCluster operation against Amazon Redshift.", Operation = new[] {"DeleteCluster"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type DeleteClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveRSClusterCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The identifier of the cluster to be deleted. </para><para>Constraints:</para><ul><li>Must contain lowercase characters.</li><li>Must contain from 1 to 63 alphanumeric
        /// characters or hyphens.</li><li>First character must be a letter.</li><li>Cannot
        /// end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The identifier of the final snapshot that is to be created immediately before deleting
        /// the cluster. If this parameter is provided, <i>SkipFinalClusterSnapshot</i> must be
        /// <code>false</code>. </para><para>Constraints:</para><ul><li>Must be 1 to 255 alphanumeric characters.</li><li>First character must
        /// be a letter.</li><li>Cannot end with a hyphen or contain two consecutive hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String FinalClusterSnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> Determines whether a final snapshot of the cluster is created before Amazon Redshift
        /// deletes the cluster. If <code>true</code>, a final cluster snapshot is not created.
        /// If <code>false</code>, a final cluster snapshot is created before the cluster is deleted.
        /// </para><note>The <i>FinalClusterSnapshotIdentifier</i> parameter must be specified if <i>SkipFinalClusterSnapshot</i>
        /// is <code>false</code>.</note><para>Default: <code>false</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean SkipFinalClusterSnapshot { get; set; }
        
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
            
            context.ClusterIdentifier = this.ClusterIdentifier;
            context.FinalClusterSnapshotIdentifier = this.FinalClusterSnapshotIdentifier;
            if (ParameterWasBound("SkipFinalClusterSnapshot"))
                context.SkipFinalClusterSnapshot = this.SkipFinalClusterSnapshot;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new DeleteClusterRequest();
            
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.FinalClusterSnapshotIdentifier != null)
            {
                request.FinalClusterSnapshotIdentifier = cmdletContext.FinalClusterSnapshotIdentifier;
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
                var response = client.DeleteCluster(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String ClusterIdentifier { get; set; }
            public String FinalClusterSnapshotIdentifier { get; set; }
            public Boolean? SkipFinalClusterSnapshot { get; set; }
        }
        
    }
}
