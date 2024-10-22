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
    /// Represents the input of a <c>TestFailover</c> operation which tests automatic failover
    /// on a specified node group (called shard in the console) in a replication group (called
    /// cluster in the console).
    /// 
    ///  
    /// <para>
    /// This API is designed for testing the behavior of your application in case of ElastiCache
    /// failover. It is not designed to be an operational tool for initiating a failover to
    /// overcome a problem you may have with the cluster. Moreover, in certain conditions
    /// such as large-scale operational events, Amazon may block this API. 
    /// </para><para><b>Note the following</b></para><ul><li><para>
    /// A customer can use this operation to test automatic failover on up to 15 shards (called
    /// node groups in the ElastiCache API and Amazon CLI) in any rolling 24-hour period.
    /// </para></li><li><para>
    /// If calling this operation on shards in different clusters (called replication groups
    /// in the API and CLI), the calls can be made concurrently.
    /// </para><para></para></li><li><para>
    /// If calling this operation multiple times on different shards in the same Redis OSS
    /// (cluster mode enabled) replication group, the first node replacement must complete
    /// before a subsequent call can be made.
    /// </para></li><li><para>
    /// To determine whether the node replacement is complete you can check Events using the
    /// Amazon ElastiCache console, the Amazon CLI, or the ElastiCache API. Look for the following
    /// automatic failover related events, listed here in order of occurrance:
    /// </para><ol><li><para>
    /// Replication group message: <c>Test Failover API called for node group &lt;node-group-id&gt;</c></para></li><li><para>
    /// Cache cluster message: <c>Failover from primary node &lt;primary-node-id&gt; to replica
    /// node &lt;node-id&gt; completed</c></para></li><li><para>
    /// Replication group message: <c>Failover from primary node &lt;primary-node-id&gt; to
    /// replica node &lt;node-id&gt; completed</c></para></li><li><para>
    /// Cache cluster message: <c>Recovering cache nodes &lt;node-id&gt;</c></para></li><li><para>
    /// Cache cluster message: <c>Finished recovery for cache nodes &lt;node-id&gt;</c></para></li></ol><para>
    /// For more information see:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/ECEvents.Viewing.html">Viewing
    /// ElastiCache Events</a> in the <i>ElastiCache User Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/APIReference/API_DescribeEvents.html">DescribeEvents</a>
    /// in the ElastiCache API Reference
    /// </para></li></ul></li></ul><para>
    /// Also see, <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/AutoFailover.html#auto-failover-test">Testing
    /// Multi-AZ </a> in the <i>ElastiCache User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "ECFailover")]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache TestFailover API operation.", Operation = new[] {"TestFailover"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.TestFailoverResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.TestFailoverResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.TestFailoverResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestECFailoverCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NodeGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the node group (called shard in the console) in this replication group
        /// on which automatic failover is to be tested. You may test automatic failover on up
        /// to 15 node groups in any rolling 24-hour period.</para>
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
        public System.String NodeGroupId { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The name of the replication group (console: cluster) whose automatic failover is being
        /// tested by this operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.TestFailoverResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.TestFailoverResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationGroup";
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
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.TestFailoverResponse, TestECFailoverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NodeGroupId = this.NodeGroupId;
            #if MODULAR
            if (this.NodeGroupId == null && ParameterWasBound(nameof(this.NodeGroupId)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeGroupId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ElastiCache.Model.TestFailoverRequest();
            
            if (cmdletContext.NodeGroupId != null)
            {
                request.NodeGroupId = cmdletContext.NodeGroupId;
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
        
        private Amazon.ElastiCache.Model.TestFailoverResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.TestFailoverRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "TestFailover");
            try
            {
                #if DESKTOP
                return client.TestFailover(request);
                #elif CORECLR
                return client.TestFailoverAsync(request).GetAwaiter().GetResult();
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
            public System.String NodeGroupId { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public System.Func<Amazon.ElastiCache.Model.TestFailoverResponse, TestECFailoverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
