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
    /// Deletes an existing replication group. By default, this operation deletes the entire
    /// replication group, including the primary/primaries and all of the read replicas. If
    /// the replication group has only one primary, you can optionally delete only the read
    /// replicas, while retaining the primary by setting <code>RetainPrimaryCluster=true</code>.
    /// 
    ///  
    /// <para>
    /// When you receive a successful response from this operation, Amazon ElastiCache immediately
    /// begins deleting the selected resources; you cannot cancel or revert this operation.
    /// </para><note><para>
    /// This operation is valid for Redis only.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Invokes the DeleteReplicationGroup operation against Amazon ElastiCache.", Operation = new[] {"DeleteReplicationGroup"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.DeleteReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter FinalSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of a final node group (shard) snapshot. ElastiCache creates the snapshot
        /// from the primary node in the cluster, rather than one of the replicas; this is to
        /// ensure that it captures the freshest data. After the final snapshot is taken, the
        /// replication group is immediately deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FinalSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster to be deleted. This parameter is not case sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter RetainPrimaryCluster
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, all of the read replicas are deleted, but the primary
        /// node is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RetainPrimaryCluster { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FinalSnapshotIdentifier = this.FinalSnapshotIdentifier;
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (ParameterWasBound("RetainPrimaryCluster"))
                context.RetainPrimaryCluster = this.RetainPrimaryCluster;
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.ElastiCache.Model.DeleteReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DeleteReplicationGroupRequest request)
        {
            #if DESKTOP
            return client.DeleteReplicationGroup(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DeleteReplicationGroupAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
