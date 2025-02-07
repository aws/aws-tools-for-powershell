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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Lists all available node types that you can scale with your cluster's replication
    /// group's current node type.
    /// 
    ///  
    /// <para>
    /// When you use the <c>ModifyCacheCluster</c> or <c>ModifyReplicationGroup</c> operations
    /// to scale your cluster or replication group, the value of the <c>CacheNodeType</c>
    /// parameter must be one of the node types returned by this operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECAllowedNodeTypeModification")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon ElastiCache ListAllowedNodeTypeModifications API operation.", Operation = new[] {"ListAllowedNodeTypeModifications"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse))]
    [AWSCmdletOutput("System.String or Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECAllowedNodeTypeModificationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The name of the cluster you want to scale up to a larger node instanced type. ElastiCache
        /// uses the cluster id to identify the current node type of this cluster and from that
        /// to create a list of node types you can scale up to.</para><important><para>You must provide a value for either the <c>CacheClusterId</c> or the <c>ReplicationGroupId</c>.</para></important>
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
        /// replication group, and from that to create a list of node types you can scale up to.</para><important><para>You must provide a value for either the <c>CacheClusterId</c> or the <c>ReplicationGroupId</c>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScaleUpModifications'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScaleUpModifications";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse, GetECAllowedNodeTypeModificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
        
        private Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ListAllowedNodeTypeModifications");
            try
            {
                #if DESKTOP
                return client.ListAllowedNodeTypeModifications(request);
                #elif CORECLR
                return client.ListAllowedNodeTypeModificationsAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElastiCache.Model.ListAllowedNodeTypeModificationsResponse, GetECAllowedNodeTypeModificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScaleUpModifications;
        }
        
    }
}
