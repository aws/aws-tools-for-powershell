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
    /// Lists all available node types that you can scale your Redis cluster's or replication
    /// group's current node type up to.
    /// 
    ///  
    /// <para>
    /// When you use the <code>ModifyCacheCluster</code> or <code>ModifyReplicationGroup</code>
    /// operations to scale up your cluster or replication group, the value of the <code>CacheNodeType</code>
    /// parameter must be one of the node types returned by this operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECAllowedNodeTypeModification")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon ElastiCache ListAllowedNodeTypeModifications API operation.", Operation = new[] {"ListAllowedNodeTypeModifications"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetECAllowedNodeTypeModificationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The name of the cluster you want to scale up to a larger node instanced type. ElastiCache
        /// uses the cluster id to identify the current node type of this cluster and from that
        /// to create a list of node types you can scale up to.</para><important><para>You must provide a value for either the <code>CacheClusterId</code> or the <code>ReplicationGroupId</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the replication group want to scale up to a larger node type. ElastiCache
        /// uses the replication group id to identify the current node type being used by this
        /// replication group, and from that to create a list of node types you can scale up to.</para><important><para>You must provide a value for either the <code>CacheClusterId</code> or the <code>ReplicationGroupId</code>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CacheClusterId = this.CacheClusterId;
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
            var request = new Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
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
                object pipelineOutput = response.ScaleUpModifications;
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
        
        private Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ListAllowedNodeTypeModifications");
            try
            {
                #if DESKTOP
                return client.ListAllowedNodeTypeModifications(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListAllowedNodeTypeModificationsAsync(request);
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
            public System.String CacheClusterId { get; set; }
            public System.String ReplicationGroupId { get; set; }
        }
        
    }
}
