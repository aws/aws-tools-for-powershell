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
    /// Dynamically decreases the number of replicas in a Valkey or Redis OSS (cluster mode
    /// disabled) replication group or the number of replica nodes in one or more node groups
    /// (shards) of a Valkey or Redis OSS (cluster mode enabled) replication group. This operation
    /// is performed with no cluster down time.
    /// </summary>
    [Cmdlet("Request", "ECReplicaCountDecrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache DecreaseReplicaCount API operation.", Operation = new[] {"DecreaseReplicaCount"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DecreaseReplicaCountResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.DecreaseReplicaCountResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.DecreaseReplicaCountResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestECReplicaCountDecreaseCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <c>True</c>, the number of replica nodes is decreased immediately. <c>ApplyImmediately=False</c>
        /// is not currently supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? ApplyImmediately { get; set; }
        #endregion
        
        #region Parameter NewReplicaCount
        /// <summary>
        /// <para>
        /// <para>The number of read replica nodes you want at the completion of this operation. For
        /// Valkey or Redis OSS (cluster mode disabled) replication groups, this is the number
        /// of replica nodes in the replication group. For Valkey or Redis OSS (cluster mode enabled)
        /// replication groups, this is the number of replica nodes in each of the replication
        /// group's node groups.</para><para>The minimum number of replicas in a shard or replication group is:</para><ul><li><para>Valkey or Redis OSS (cluster mode disabled)</para><ul><li><para>If Multi-AZ is enabled: 1</para></li><li><para>If Multi-AZ is not enabled: 0</para></li></ul></li><li><para>Valkey or Redis OSS (cluster mode enabled): 0 (though you will not be able to failover
        /// to a replica if your primary node fails)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewReplicaCount { get; set; }
        #endregion
        
        #region Parameter ReplicaConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of <c>ConfigureShard</c> objects that can be used to configure each shard in
        /// a Valkey or Redis OSS (cluster mode enabled) replication group. The <c>ConfigureShard</c>
        /// has three members: <c>NewReplicaCount</c>, <c>NodeGroupId</c>, and <c>PreferredAvailabilityZones</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElastiCache.Model.ConfigureShard[] ReplicaConfiguration { get; set; }
        #endregion
        
        #region Parameter ReplicasToRemove
        /// <summary>
        /// <para>
        /// <para>A list of the node ids to remove from the replication group or node group (shard).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ReplicasToRemove { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The id of the replication group from which you want to remove replica nodes.</para>
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
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DecreaseReplicaCountResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DecreaseReplicaCountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECReplicaCountDecrease (DecreaseReplicaCount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DecreaseReplicaCountResponse, RequestECReplicaCountDecreaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            #if MODULAR
            if (this.ApplyImmediately == null && ParameterWasBound(nameof(this.ApplyImmediately)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyImmediately which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NewReplicaCount = this.NewReplicaCount;
            if (this.ReplicaConfiguration != null)
            {
                context.ReplicaConfiguration = new List<Amazon.ElastiCache.Model.ConfigureShard>(this.ReplicaConfiguration);
            }
            if (this.ReplicasToRemove != null)
            {
                context.ReplicasToRemove = new List<System.String>(this.ReplicasToRemove);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
            #if MODULAR
            if (this.ReplicationGroupId == null && ParameterWasBound(nameof(this.ReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ElastiCache.Model.DecreaseReplicaCountRequest();
            
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
            if (cmdletContext.ReplicasToRemove != null)
            {
                request.ReplicasToRemove = cmdletContext.ReplicasToRemove;
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
        
        private Amazon.ElastiCache.Model.DecreaseReplicaCountResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DecreaseReplicaCountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DecreaseReplicaCount");
            try
            {
                #if DESKTOP
                return client.DecreaseReplicaCount(request);
                #elif CORECLR
                return client.DecreaseReplicaCountAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ReplicasToRemove { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DecreaseReplicaCountResponse, RequestECReplicaCountDecreaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
