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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Modifies a replication group's shards (node groups) by allowing you to add shards,
    /// remove shards, or rebalance the keyspaces among exisiting shards.
    /// </summary>
    [Cmdlet("Edit", "ECReplicationGroupShardConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyReplicationGroupShardConfiguration API operation.", Operation = new[] {"ModifyReplicationGroupShardConfiguration"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditECReplicationGroupShardConfigurationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Indicates that the shard reconfiguration process begins immediately. At present, the
        /// only permitted value for this parameter is <code>true</code>.</para><para>Value: true</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter NodeGroupCount
        /// <summary>
        /// <para>
        /// <para>The number of node groups (shards) that results from the modification of the shard
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NodeGroupCount { get; set; }
        #endregion
        
        #region Parameter NodeGroupsToRemove
        /// <summary>
        /// <para>
        /// <para>If the value of <code>NodeGroupCount</code> is less than the current number of node
        /// groups (shards), the <code>NodeGroupsToRemove</code> or <code>NodeGroupsToRetain</code>
        /// is a required list of node group ids to remove from or retain in the cluster.</para><para>ElastiCache for Redis will attempt to remove all node groups listed by <code>NodeGroupsToRemove</code>
        /// from the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] NodeGroupsToRemove { get; set; }
        #endregion
        
        #region Parameter NodeGroupsToRetain
        /// <summary>
        /// <para>
        /// <para>If the value of <code>NodeGroupCount</code> is less than the current number of node
        /// groups (shards), the <code>NodeGroupsToRemove</code> or <code>NodeGroupsToRetain</code>
        /// is a required list of node group ids to remove from or retain in the cluster.</para><para>ElastiCache for Redis will attempt to remove all node groups except those listed by
        /// <code>NodeGroupsToRetain</code> from the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] NodeGroupsToRetain { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the Redis (cluster mode enabled) cluster (replication group) on which
        /// the shards are to be configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter ReshardingConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies the preferred availability zones for each node group in the cluster. If
        /// the value of <code>NodeGroupCount</code> is greater than the current number of node
        /// groups (shards), you can use this parameter to specify the preferred availability
        /// zones of the cluster's shards. If you omit this parameter ElastiCache selects availability
        /// zones for you.</para><para>You can specify this parameter only if the value of <code>NodeGroupCount</code> is
        /// greater than the current number of node groups (shards).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ElastiCache.Model.ReshardingConfiguration[] ReshardingConfiguration { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECReplicationGroupShardConfiguration (ModifyReplicationGroupShardConfiguration)"))
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
            
            if (ParameterWasBound("ApplyImmediately"))
                context.ApplyImmediately = this.ApplyImmediately;
            if (ParameterWasBound("NodeGroupCount"))
                context.NodeGroupCount = this.NodeGroupCount;
            if (this.NodeGroupsToRemove != null)
            {
                context.NodeGroupsToRemove = new List<System.String>(this.NodeGroupsToRemove);
            }
            if (this.NodeGroupsToRetain != null)
            {
                context.NodeGroupsToRetain = new List<System.String>(this.NodeGroupsToRetain);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
            if (this.ReshardingConfiguration != null)
            {
                context.ReshardingConfiguration = new List<Amazon.ElastiCache.Model.ReshardingConfiguration>(this.ReshardingConfiguration);
            }
            
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
            var request = new Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.NodeGroupCount != null)
            {
                request.NodeGroupCount = cmdletContext.NodeGroupCount.Value;
            }
            if (cmdletContext.NodeGroupsToRemove != null)
            {
                request.NodeGroupsToRemove = cmdletContext.NodeGroupsToRemove;
            }
            if (cmdletContext.NodeGroupsToRetain != null)
            {
                request.NodeGroupsToRetain = cmdletContext.NodeGroupsToRetain;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.ReshardingConfiguration != null)
            {
                request.ReshardingConfiguration = cmdletContext.ReshardingConfiguration;
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
        
        private Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyReplicationGroupShardConfiguration");
            try
            {
                #if DESKTOP
                return client.ModifyReplicationGroupShardConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyReplicationGroupShardConfigurationAsync(request);
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
            public System.Boolean? ApplyImmediately { get; set; }
            public System.Int32? NodeGroupCount { get; set; }
            public List<System.String> NodeGroupsToRemove { get; set; }
            public List<System.String> NodeGroupsToRetain { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public List<Amazon.ElastiCache.Model.ReshardingConfiguration> ReshardingConfiguration { get; set; }
        }
        
    }
}
