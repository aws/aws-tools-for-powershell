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
    /// Starts the migration of data.
    /// </summary>
    [Cmdlet("Start", "ECMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ReplicationGroup")]
    [AWSCmdlet("Calls the Amazon ElastiCache StartMigration API operation.", Operation = new[] {"StartMigration"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.StartMigrationResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ReplicationGroup or Amazon.ElastiCache.Model.StartMigrationResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ReplicationGroup object.",
        "The service call response (type Amazon.ElastiCache.Model.StartMigrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartECMigrationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoCutover
        /// <summary>
        /// <para>
        /// <para>Specifies whether ElastiCache automatically attempts to complete the migration after
        /// data sync is established.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoCutover { get; set; }
        #endregion
        
        #region Parameter ClearTargetCacheData
        /// <summary>
        /// <para>
        /// <para>Specifies whether ElastiCache deletes existing data in the serverless cache before
        /// migration begins. After <c>StopMigration</c>, <c>StartMigration</c> requires this
        /// option to restart the data sync.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ClearTargetCacheData { get; set; }
        #endregion
        
        #region Parameter CustomerNodeEndpointList
        /// <summary>
        /// <para>
        /// <para>The list of endpoints from which to migrate data. For Valkey or Redis OSS (cluster
        /// mode disabled), the list should have only one element. For serverless cache migrations,
        /// ElastiCache uses the endpoint that you provided in <c>PrepareMigration</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ElastiCache.Model.CustomerNodeEndpoint[] CustomerNodeEndpointList { get; set; }
        #endregion
        
        #region Parameter ReplicationGroupId
        /// <summary>
        /// <para>
        /// <para>The ID of the replication group to which data should be migrated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationGroupId { get; set; }
        #endregion
        
        #region Parameter ServerlessCacheName
        /// <summary>
        /// <para>
        /// <para>The name of the serverless cache to which data is being migrated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerlessCacheName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.StartMigrationResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.StartMigrationResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationGroupId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ECMigration (StartMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.StartMigrationResponse, StartECMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoCutover = this.AutoCutover;
            context.ClearTargetCacheData = this.ClearTargetCacheData;
            if (this.CustomerNodeEndpointList != null)
            {
                context.CustomerNodeEndpointList = new List<Amazon.ElastiCache.Model.CustomerNodeEndpoint>(this.CustomerNodeEndpointList);
            }
            context.ReplicationGroupId = this.ReplicationGroupId;
            context.ServerlessCacheName = this.ServerlessCacheName;
            
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
            var request = new Amazon.ElastiCache.Model.StartMigrationRequest();
            
            if (cmdletContext.AutoCutover != null)
            {
                request.AutoCutover = cmdletContext.AutoCutover.Value;
            }
            if (cmdletContext.ClearTargetCacheData != null)
            {
                request.ClearTargetCacheData = cmdletContext.ClearTargetCacheData.Value;
            }
            if (cmdletContext.CustomerNodeEndpointList != null)
            {
                request.CustomerNodeEndpointList = cmdletContext.CustomerNodeEndpointList;
            }
            if (cmdletContext.ReplicationGroupId != null)
            {
                request.ReplicationGroupId = cmdletContext.ReplicationGroupId;
            }
            if (cmdletContext.ServerlessCacheName != null)
            {
                request.ServerlessCacheName = cmdletContext.ServerlessCacheName;
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
        
        private Amazon.ElastiCache.Model.StartMigrationResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.StartMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "StartMigration");
            try
            {
                return client.StartMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoCutover { get; set; }
            public System.Boolean? ClearTargetCacheData { get; set; }
            public List<Amazon.ElastiCache.Model.CustomerNodeEndpoint> CustomerNodeEndpointList { get; set; }
            public System.String ReplicationGroupId { get; set; }
            public System.String ServerlessCacheName { get; set; }
            public System.Func<Amazon.ElastiCache.Model.StartMigrationResponse, StartECMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationGroup;
        }
        
    }
}
