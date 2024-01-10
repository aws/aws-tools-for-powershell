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
    /// Modifies a replication group's shards (node groups) by allowing you to add shards,
    /// remove shards, or rebalance the keyspaces among existing shards.
    /// </summary>
    [Cmdlet("Edit", "ECReplicationGroupShardConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache ModifyReplicationGroupShardConfiguration API operation.", Operation = new[] {"ModifyReplicationGroupShardConfiguration"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditECReplicationGroupShardConfigurationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Indicates that the shard reconfiguration process begins immediately. At present, the
        /// only permitted value for this parameter is <c>true</c>.</para><para>Value: true</para>
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
        
        #region Parameter NodeGroupCount
        /// <summary>
        /// <para>
        /// <para>The number of node groups (shards) that results from the modification of the shard
        /// configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? NodeGroupCount { get; set; }
        #endregion
        
        #region Parameter NodeGroupsToRemove
        /// <summary>
        /// <para>
        /// <para>If the value of <c>NodeGroupCount</c> is less than the current number of node groups
        /// (shards), then either <c>NodeGroupsToRemove</c> or <c>NodeGroupsToRetain</c> is required.
        /// <c>NodeGroupsToRemove</c> is a list of <c>NodeGroupId</c>s to remove from the cluster.</para><para>ElastiCache for Redis will attempt to remove all node groups listed by <c>NodeGroupsToRemove</c>
        /// from the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeGroupsToRemove { get; set; }
        #endregion
        
        #region Parameter NodeGroupsToRetain
        /// <summary>
        /// <para>
        /// <para>If the value of <c>NodeGroupCount</c> is less than the current number of node groups
        /// (shards), then either <c>NodeGroupsToRemove</c> or <c>NodeGroupsToRetain</c> is required.
        /// <c>NodeGroupsToRetain</c> is a list of <c>NodeGroupId</c>s to retain in the cluster.</para><para>ElastiCache for Redis will attempt to remove all node groups except those listed by
        /// <c>NodeGroupsToRetain</c> from the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NodeGroupsToRetain { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the Redis (cluster mode enabled) cluster (replication group) on which
        /// the shards are to be configured.</para>
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
        
        #region Parameter ReshardingConfiguration
        /// <summary>
        /// <para>
        /// <para>Specifies the preferred availability zones for each node group in the cluster. If
        /// the value of <c>NodeGroupCount</c> is greater than the current number of node groups
        /// (shards), you can use this parameter to specify the preferred availability zones of
        /// the cluster's shards. If you omit this parameter ElastiCache selects availability
        /// zones for you.</para><para>You can specify this parameter only if the value of <c>NodeGroupCount</c> is greater
        /// than the current number of node groups (shards).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElastiCache.Model.ReshardingConfiguration[] ReshardingConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationGroupId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ECReplicationGroupShardConfiguration (ModifyReplicationGroupShardConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse, EditECReplicationGroupShardConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyImmediately = this.ApplyImmediately;
            #if MODULAR
            if (this.ApplyImmediately == null && ParameterWasBound(nameof(this.ApplyImmediately)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyImmediately which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeGroupCount = this.NodeGroupCount;
            #if MODULAR
            if (this.NodeGroupCount == null && ParameterWasBound(nameof(this.NodeGroupCount)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeGroupCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NodeGroupsToRemove != null)
            {
                context.NodeGroupsToRemove = new List<System.String>(this.NodeGroupsToRemove);
            }
            if (this.NodeGroupsToRetain != null)
            {
                context.NodeGroupsToRetain = new List<System.String>(this.NodeGroupsToRetain);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
            #if MODULAR
            if (this.ReplicationGroupId == null && ParameterWasBound(nameof(this.ReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "ModifyReplicationGroupShardConfiguration");
            try
            {
                #if DESKTOP
                return client.ModifyReplicationGroupShardConfiguration(request);
                #elif CORECLR
                return client.ModifyReplicationGroupShardConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElastiCache.Model.ModifyReplicationGroupShardConfigurationResponse, EditECReplicationGroupShardConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
