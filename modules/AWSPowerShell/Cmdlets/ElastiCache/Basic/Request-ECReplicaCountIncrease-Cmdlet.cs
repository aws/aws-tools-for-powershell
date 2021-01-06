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
    /// Dynamically increases the number of replicas in a Redis (cluster mode disabled) replication
    /// group or the number of replica nodes in one or more node groups (shards) of a Redis
    /// (cluster mode enabled) replication group. This operation is performed with no cluster
    /// down time.
    /// </summary>
    [Cmdlet("Request", "ECReplicaCountIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache IncreaseReplicaCount API operation.", Operation = new[] {"IncreaseReplicaCount"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.IncreaseReplicaCountResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.IncreaseReplicaCountResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.IncreaseReplicaCountResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestECReplicaCountIncreaseCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>If <code>True</code>, the number of replica nodes is increased immediately. <code>ApplyImmediately=False</code>
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
        /// Redis (cluster mode disabled) replication groups, this is the number of replica nodes
        /// in the replication group. For Redis (cluster mode enabled) replication groups, this
        /// is the number of replica nodes in each of the replication group's node groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? NewReplicaCount { get; set; }
        #endregion
        
        #region Parameter ReplicaConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of <code>ConfigureShard</code> objects that can be used to configure each shard
        /// in a Redis (cluster mode enabled) replication group. The <code>ConfigureShard</code>
        /// has three members: <code>NewReplicaCount</code>, <code>NodeGroupId</code>, and <code>PreferredAvailabilityZones</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElastiCache.Model.ConfigureShard[] ReplicaConfiguration { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The id of the replication group to which you want to add replica nodes.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.IncreaseReplicaCountResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.IncreaseReplicaCountResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECReplicaCountIncrease (IncreaseReplicaCount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.IncreaseReplicaCountResponse, RequestECReplicaCountIncreaseCmdlet>(Select) ??
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
            context.NewReplicaCount = this.NewReplicaCount;
            if (this.ReplicaConfiguration != null)
            {
                context.ReplicaConfiguration = new List<Amazon.ElastiCache.Model.ConfigureShard>(this.ReplicaConfiguration);
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
        
        private Amazon.ElastiCache.Model.IncreaseReplicaCountResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.IncreaseReplicaCountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "IncreaseReplicaCount");
            try
            {
                #if DESKTOP
                return client.IncreaseReplicaCount(request);
                #elif CORECLR
                return client.IncreaseReplicaCountAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ElastiCache.Model.IncreaseReplicaCountResponse, RequestECReplicaCountIncreaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
