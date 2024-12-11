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
    /// Stop the service update. For more information on service updates and stopping them,
    /// see <a href="https://docs.aws.amazon.com/AmazonElastiCache/latest/red-ug/stopping-self-service-updates.html">Stopping
    /// Service Updates</a>.
    /// </summary>
    [Cmdlet("Stop", "ECUpdateActionBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.BatchStopUpdateActionResponse")]
    [AWSCmdlet("Calls the Amazon ElastiCache BatchStopUpdateAction API operation.", Operation = new[] {"BatchStopUpdateAction"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.BatchStopUpdateActionResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.BatchStopUpdateActionResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.BatchStopUpdateActionResponse object containing multiple properties."
    )]
    public partial class StopECUpdateActionBatchCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CacheClusterId
        /// <summary>
        /// <para>
        /// <para>The cache cluster IDs</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CacheClusterIds")]
        public System.String[] CacheClusterId { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The replication group IDs</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicationGroupIds")]
        public System.String[] ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceUpdateName
        /// <summary>
        /// <para>
        /// <para>The unique ID of the service update</para>
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
        public System.String ServiceUpdateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.BatchStopUpdateActionResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.BatchStopUpdateActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceUpdateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-ECUpdateActionBatch (BatchStopUpdateAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.BatchStopUpdateActionResponse, StopECUpdateActionBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CacheClusterId != null)
            {
                context.CacheClusterId = new List<System.String>(this.CacheClusterId);
            }
            if (this.ReplicationGroupId != null)
            {
                context.ReplicationGroupId = new List<System.String>(this.ReplicationGroupId);
            }
            context.ServiceUpdateName = this.ServiceUpdateName;
            #if MODULAR
            if (this.ServiceUpdateName == null && ParameterWasBound(nameof(this.ServiceUpdateName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceUpdateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElastiCache.Model.BatchStopUpdateActionRequest();
            
            if (cmdletContext.CacheClusterId != null)
            {
                request.CacheClusterIds = cmdletContext.CacheClusterId;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupIds = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.ServiceUpdateName != null)
            {
                request.ServiceUpdateName = cmdletContext.ServiceUpdateName;
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
        
        private Amazon.ElastiCache.Model.BatchStopUpdateActionResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.BatchStopUpdateActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "BatchStopUpdateAction");
            try
            {
                #if DESKTOP
                return client.BatchStopUpdateAction(request);
                #elif CORECLR
                return client.BatchStopUpdateActionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> CacheClusterId { get; set; }
            public List<System.String> ReplicationGroupId { get; set; }
            public System.String ServiceUpdateName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.BatchStopUpdateActionResponse, StopECUpdateActionBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
