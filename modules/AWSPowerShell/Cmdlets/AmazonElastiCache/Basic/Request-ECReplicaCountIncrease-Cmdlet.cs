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
    /// Dynamically increases the number of replics in a Redis (cluster mode disabled) replication
    /// group or the number of replica nodes in one or more node groups (shards) of a Redis
    /// (cluster mode enabled) replication group. This operation is performed with no cluster
    /// down time.
    /// </summary>
    [Cmdlet("Request", "ECReplicaCountIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache IncreaseReplicaCount API operation.", Operation = new[] {"IncreaseReplicaCount"})]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup",
        "This cmdlet returns a ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.IncreaseReplicaCountResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestECReplicaCountIncreaseCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <code>True</code>, the number of replica nodes is increased immediately. If <code>False</code>,
        /// the number of replica nodes is increased during the next maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter NewReplicaCount
        /// <summary>
        /// <para>
        /// <para>The number of read replica nodes you want at the completion of this operation. For
        /// Redis (cluster mode disabled) replication groups, this is the number of replica nodes
        /// in the replication group. For Redis (cluster mode enabled) replication groups, this
        /// is the number of replica nodes in each of the replication group's node groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 NewReplicaCount { get; set; }
        #endregion
        
        #region Parameter ReplicaConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of <code>ConfigureShard</code> objects that can be used to configure each shard
        /// in a Redis (cluster mode enabled) replication group. The <code>ConfigureShard</code>
        /// has three members: <code>NewReplicaCount</code>, <code>NodeGroupId</code>, and <code>PreferredAvailabilityZones</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.ElastiCache.Model.ConfigureShard[] ReplicaConfiguration { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The id of the replication group to which you want to add replica nodes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationGroupId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECReplicaCountIncrease (IncreaseReplicaCount)"))
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
            if (ParameterWasBound("NewReplicaCount"))
                context.NewReplicaCount = this.NewReplicaCount;
            if (this.ReplicaConfiguration != null)
            {
                context.ReplicaConfiguration = new List<Amazon.ElastiCache.Model.ConfigureShard>(this.ReplicaConfiguration);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
            
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
            var request = new Amazon.ElastiCache.Model.IncreaseReplicaCountRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.NewReplicaCount != null)
            {
                request.NewReplicaCount = cmdletContext.NewReplicaCount.Value;
            }
            if (cmdletContext.ReplicaConfiguration != null)
            {
                request.ReplicaConfiguration = cmdletContext.ReplicaConfiguration;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
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
        
        private Amazon.ElastiCache.Model.IncreaseReplicaCountResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.IncreaseReplicaCountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "IncreaseReplicaCount");
            try
            {
                #if DESKTOP
                return client.IncreaseReplicaCount(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.IncreaseReplicaCountAsync(request);
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
            public System.Int32? NewReplicaCount { get; set; }
            public List<Amazon.ElastiCache.Model.ConfigureShard> ReplicaConfiguration { get; set; }
            public System.String ReplicationGroupId { get; set; }
        }
        
    }
}
