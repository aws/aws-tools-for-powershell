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
using System.Threading;
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Increase the number of node groups in the Global datastore
    /// </summary>
    [Cmdlet("Request", "ECNodeGroupIncreaseInGlobalReplicationGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.GlobalReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache IncreaseNodeGroupsInGlobalReplicationGroup API operation.", Operation = new[] {"IncreaseNodeGroupsInGlobalReplicationGroup"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.GlobalReplicationGroup or Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.GlobalReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestECNodeGroupIncreaseInGlobalReplicationGroupCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyImmediately
        /// <summary>
        /// <para>
        /// <para>Indicates that the process begins immediately. At present, the only permitted value
        /// for this parameter is true.</para>
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
        /// <para>Total number of node groups you want</para>
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
        
        #region Parameter RegionalConfiguration
        /// <summary>
        /// <para>
        /// <para>Describes the replication group IDs, the Amazon regions where they are stored and
        /// the shard configuration for each that comprise the Global datastore</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegionalConfigurations")]
        public Amazon.ElastiCache.Model.RegionalConfiguration[] RegionalConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalReplicationGroup";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-ECNodeGroupIncreaseInGlobalReplicationGroup (IncreaseNodeGroupsInGlobalReplicationGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse, RequestECNodeGroupIncreaseInGlobalReplicationGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyImmediately = this.ApplyImmediately;
            #if MODULAR
            if (this.ApplyImmediately == null && ParameterWasBound(nameof(this.ApplyImmediately)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplyImmediately which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.RegionalConfiguration != null)
            {
                context.RegionalConfiguration = new List<Amazon.ElastiCache.Model.RegionalConfiguration>(this.RegionalConfiguration);
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
            var request = new Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupRequest();
            
            if (cmdletContext.ApplyImmediately != null)
            {
                request.ApplyImmediately = cmdletContext.ApplyImmediately.Value;
            }
            if (cmdletContext.GlobalReplicationGroupId != null)
            {
                request.GlobalReplicationGroupId = cmdletContext.GlobalReplicationGroupId;
            }
            if (cmdletContext.NodeGroupCount != null)
            {
                request.NodeGroupCount = cmdletContext.NodeGroupCount.Value;
            }
            if (cmdletContext.RegionalConfiguration != null)
            {
                request.RegionalConfigurations = cmdletContext.RegionalConfiguration;
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
        
        private Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "IncreaseNodeGroupsInGlobalReplicationGroup");
            try
            {
                return client.IncreaseNodeGroupsInGlobalReplicationGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GlobalReplicationGroupId { get; set; }
            public System.Int32? NodeGroupCount { get; set; }
            public List<Amazon.ElastiCache.Model.RegionalConfiguration> RegionalConfiguration { get; set; }
            public System.Func<Amazon.ElastiCache.Model.IncreaseNodeGroupsInGlobalReplicationGroupResponse, RequestECNodeGroupIncreaseInGlobalReplicationGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalReplicationGroup;
        }
        
    }
}
