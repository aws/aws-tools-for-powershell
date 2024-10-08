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
    /// Decreases the number of node groups in a Global datastore
    /// </summary>
    [Cmdlet("Request", "ECNodeGroupDecreaseInGlobalReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.GlobalReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache DecreaseNodeGroupsInGlobalReplicationGroup API operation.", Operation = new[] {"DecreaseNodeGroupsInGlobalReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.GlobalReplicationGroup or Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.GlobalReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestECNodeGroupDecreaseInGlobalReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Indicates that the shard reconfiguration process begins immediately. At present, the
        /// only permitted value for this parameter is true. </para>
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
        
        #region Parameter GlobalNodeGroupsToRemove
        /// <summary>
        /// <para>
        /// <para>If the value of NodeGroupCount is less than the current number of node groups (shards),
        /// then either NodeGroupsToRemove or NodeGroupsToRetain is required. GlobalNodeGroupsToRemove
        /// is a list of NodeGroupIds to remove from the cluster. ElastiCache will attempt to
        /// remove all node groups listed by GlobalNodeGroupsToRemove from the cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] GlobalNodeGroupsToRemove { get; set; }
        #endregion
        
        #region Parameter GlobalNodeGroupsToRetain
        /// <summary>
        /// <para>
        /// <para>If the value of NodeGroupCount is less than the current number of node groups (shards),
        /// then either NodeGroupsToRemove or NodeGroupsToRetain is required. GlobalNodeGroupsToRetain
        /// is a list of NodeGroupIds to retain from the cluster. ElastiCache will attempt to
        /// retain all node groups listed by GlobalNodeGroupsToRetain from the cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] GlobalNodeGroupsToRetain { get; set; }
        #endregion
        
        #region Parameter GlobalReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the Global datastore</para>
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
        public System.String GlobalReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter NodeGroupCount
        /// <summary>
        /// <para>
        /// <para>The number of node groups (shards) that results from the modification of the shard
        /// configuration</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalReplicationGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalReplicationGroupId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalReplicationGroupId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalReplicationGroupId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECNodeGroupDecreaseInGlobalReplicationGroup (DecreaseNodeGroupsInGlobalReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse, RequestECNodeGroupDecreaseInGlobalReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalReplicationGroupId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplyImmediately = this.ApplyImmediately;
            #if MODULAR
            if (this.ApplyImmediately == null && ParameterWasBound(nameof(this.ApplyImmediately)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyImmediately which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GlobalNodeGroupsToRemove != null)
            {
                context.GlobalNodeGroupsToRemove = new List<System.String>(this.GlobalNodeGroupsToRemove);
            }
            if (this.GlobalNodeGroupsToRetain != null)
            {
                context.GlobalNodeGroupsToRetain = new List<System.String>(this.GlobalNodeGroupsToRetain);
            }
            context.GlobalReplicationGroupId = this.GlobalReplicationGroupId;
            #if MODULAR
            if (this.GlobalReplicationGroupId == null && ParameterWasBound(nameof(this.GlobalReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeGroupCount = this.NodeGroupCount;
            #if MODULAR
            if (this.NodeGroupCount == null && ParameterWasBound(nameof(this.NodeGroupCount)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeGroupCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.GlobalNodeGroupsToRemove != null)
            {
                request.GlobalNodeGroupsToRemove = cmdletContext.GlobalNodeGroupsToRemove;
            }
            if (cmdletContext.GlobalNodeGroupsToRetain != null)
            {
                request.GlobalNodeGroupsToRetain = cmdletContext.GlobalNodeGroupsToRetain;
            }
            if (cmdletContext.GlobalReplicationGroupId != null)
            {
                request.GlobalReplicationGroupId = cmdletContext.GlobalReplicationGroupId;
            }
            if (cmdletContext.NodeGroupCount != null)
            {
                request.NodeGroupCount = cmdletContext.NodeGroupCount.Value;
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
        
        private Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DecreaseNodeGroupsInGlobalReplicationGroup");
            try
            {
                #if DESKTOP
                return client.DecreaseNodeGroupsInGlobalReplicationGroup(request);
                #elif CORECLR
                return client.DecreaseNodeGroupsInGlobalReplicationGroupAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> GlobalNodeGroupsToRemove { get; set; }
            public List<System.String> GlobalNodeGroupsToRetain { get; set; }
            public System.String GlobalReplicationGroupId { get; set; }
            public System.Int32? NodeGroupCount { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DecreaseNodeGroupsInGlobalReplicationGroupResponse, RequestECNodeGroupDecreaseInGlobalReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalReplicationGroup;
        }
        
    }
}
