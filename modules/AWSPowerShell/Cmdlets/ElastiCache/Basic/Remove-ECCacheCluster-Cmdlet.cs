/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes a previously provisioned cluster. <c>DeleteCacheCluster</c> deletes all associated
    /// cache nodes, node endpoints and the cluster itself. When you receive a successful
    /// response from this operation, Amazon ElastiCache immediately begins deleting the cluster;
    /// you cannot cancel or revert this operation.
    /// 
    ///  
    /// <para>
    /// This operation is not valid for:
    /// </para><ul><li><para>
    /// Valkey or Redis OSS (cluster mode enabled) clusters
    /// </para></li><li><para>
    /// Valkey or Redis OSS (cluster mode disabled) clusters
    /// </para></li><li><para>
    /// A cluster that is the last read replica of a replication group
    /// </para></li><li><para>
    /// A cluster that is the primary node of a replication group
    /// </para></li><li><para>
    /// A node group (shard) that has Multi-AZ mode enabled
    /// </para></li><li><para>
    /// A cluster from a Valkey or Redis OSS (cluster mode enabled) replication group
    /// </para></li><li><para>
    /// A cluster that is not in the <c>available</c> state
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "ECCacheCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElastiCache.Model.CacheCluster")]
    [AWSCmdlet("Calls the Amazon ElastiCache DeleteCacheCluster API operation.", Operation = new[] {"DeleteCacheCluster"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DeleteCacheClusterResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.CacheCluster or Amazon.ElastiCache.Model.DeleteCacheClusterResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.CacheCluster object.",
        "The service call response (type Amazon.ElastiCache.Model.DeleteCacheClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveECCacheClusterCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cluster identifier for the cluster to be deleted. This parameter is not case sensitive.</para>
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
        public System.String CacheClusterId { get; set; }
        #endregion
        
        #region Parameter FinalSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The user-supplied name of a final cluster snapshot. This is the unique name that identifies
        /// the snapshot. ElastiCache creates the snapshot, and then deletes the cluster immediately
        /// afterward.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CacheCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DeleteCacheClusterResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DeleteCacheClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CacheCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CacheClusterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECCacheCluster (DeleteCacheCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DeleteCacheClusterResponse, RemoveECCacheClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CacheClusterId = this.CacheClusterId;
            #if MODULAR
            if (this.CacheClusterId == null && ParameterWasBound(nameof(this.CacheClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter CacheClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FinalSnapshotIdentifier = this.FinalSnapshotIdentifier;
            
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
            var request = new Amazon.ElastiCache.Model.DeleteCacheClusterRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterId = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.FinalSnapshotIdentifier != null)
            {
                request.FinalSnapshotIdentifier = cmdletContext.FinalSnapshotIdentifier;
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
        
        private Amazon.ElastiCache.Model.DeleteCacheClusterResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DeleteCacheClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DeleteCacheCluster");
            try
            {
                #if DESKTOP
                return client.DeleteCacheCluster(request);
                #elif CORECLR
                return client.DeleteCacheClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String FinalSnapshotIdentifier { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DeleteCacheClusterResponse, RemoveECCacheClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CacheCluster;
        }
        
    }
}
