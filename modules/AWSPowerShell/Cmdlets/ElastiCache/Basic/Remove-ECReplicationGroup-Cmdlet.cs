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
    /// Deletes an existing replication group. By default, this operation deletes the entire
    /// replication group, including the primary/primaries and all of the read replicas. If
    /// the replication group has only one primary, you can optionally delete only the read
    /// replicas, while retaining the primary by setting <c>RetainPrimaryCluster=true</c>.
    /// 
    ///  
    /// <para>
    /// When you receive a successful response from this operation, Amazon ElastiCache immediately
    /// begins deleting the selected resources; you cannot cancel or revert this operation.
    /// </para><note><ul><li><para><c>CreateSnapshot</c> permission is required to create a final snapshot. Without
    /// this permission, the API call will fail with an <c>Access Denied</c> exception.
    /// </para></li><li><para>
    /// This operation is valid for Redis OSS only.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Remove", "ECReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache DeleteReplicationGroup API operation.", Operation = new[] {"DeleteReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.DeleteReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.DeleteReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.DeleteReplicationGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveECReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FinalSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of a final node group (shard) snapshot. ElastiCache creates the snapshot
        /// from the primary node in the cluster, rather than one of the replicas; this is to
        /// ensure that it captures the freshest data. After the final snapshot is taken, the
        /// replication group is immediately deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FinalSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The identifier for the cluster to be deleted. This parameter is not case sensitive.</para>
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
        
        #region Parameter RetainPrimaryCluster
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, all of the read replicas are deleted, but the primary node
        /// is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetainPrimaryCluster { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.DeleteReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.DeleteReplicationGroupResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECReplicationGroup (DeleteReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.DeleteReplicationGroupResponse, RemoveECReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FinalSnapshotIdentifier = this.FinalSnapshotIdentifier;
            context.ReplicationGroupId = this.ReplicationGroupId;
            #if MODULAR
            if (this.ReplicationGroupId == null && ParameterWasBound(nameof(this.ReplicationGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
        
        private Amazon.ElastiCache.Model.DeleteReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.DeleteReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "DeleteReplicationGroup");
            try
            {
                #if DESKTOP
                return client.DeleteReplicationGroup(request);
                #elif CORECLR
                return client.DeleteReplicationGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String FinalSnapshotIdentifier { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public System.Boolean? RetainPrimaryCluster { get; set; }
            public System.Func<Amazon.ElastiCache.Model.DeleteReplicationGroupResponse, RemoveECReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
