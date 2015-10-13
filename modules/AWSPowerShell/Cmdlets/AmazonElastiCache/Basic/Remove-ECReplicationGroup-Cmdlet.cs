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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// The <i>DeleteReplicationGroup</i> action deletes an existing replication group. By
    /// default, this action deletes the entire replication group, including the primary cluster
    /// and all of the read replicas. You can optionally delete only the read replicas, while
    /// retaining the primary cluster.
    /// 
    ///  
    /// <para>
    /// When you receive a successful response from this action, Amazon ElastiCache immediately
    /// begins deleting the selected resources; you cannot cancel or revert this action.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Invokes the DeleteReplicationGroup operation against Amazon ElastiCache.", Operation = new[] {"DeleteReplicationGroup"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.DeleteReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of a final node group snapshot. ElastiCache creates the snapshot from the
        /// primary node in the cluster, rather than one of the replicas; this is to ensure that
        /// it captures the freshest data. After the final snapshot is taken, the cluster is immediately
        /// deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FinalSnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster to be deleted. This parameter is not case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationGroupId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>If set to <i>true</i>, all of the read replicas will be deleted, but the primary node
        /// will be retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RetainPrimaryCluster { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReplicationGroupId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECReplicationGroup (DeleteReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FinalSnapshotIdentifier = this.FinalSnapshotIdentifier;
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (ParameterWasBound("RetainPrimaryCluster"))
                context.RetainPrimaryCluster = this.RetainPrimaryCluster;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElastiCache.Model.DeleteReplicationGroupRequest();
            
            if (cmdletContext.FinalSnapshotIdentifier != null)
            {
                request.FinalSnapshotIdentifier = cmdletContext.FinalSnapshotIdentifier;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.RetainPrimaryCluster != null)
            {
                request.RetainPrimaryCluster = cmdletContext.RetainPrimaryCluster.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeleteReplicationGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReplicationGroup;
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
            public System.String FinalSnapshotIdentifier { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public System.Boolean? RetainPrimaryCluster { get; set; }
        }
        
    }
}
