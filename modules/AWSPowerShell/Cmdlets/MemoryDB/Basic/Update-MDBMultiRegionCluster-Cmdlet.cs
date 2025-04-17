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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Updates the configuration of an existing multi-Region cluster.
    /// </summary>
    [Cmdlet("Update", "MDBMultiRegionCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.MultiRegionCluster")]
    [AWSCmdlet("Calls the Amazon MemoryDB UpdateMultiRegionCluster API operation.", Operation = new[] {"UpdateMultiRegionCluster"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.MultiRegionCluster or Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.MultiRegionCluster object.",
        "The service call response (type Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMDBMultiRegionClusterCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The new engine version to be used for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter MultiRegionClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the multi-Region cluster to be updated.</para>
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
        public System.String MultiRegionClusterName { get; set; }
        #endregion
        
        #region Parameter MultiRegionParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The new multi-Region parameter group to be associated with the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MultiRegionParameterGroupName { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The new node type to be used for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter ShardConfiguration_ShardCount
        /// <summary>
        /// <para>
        /// <para>The number of shards in the cluster</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ShardConfiguration_ShardCount { get; set; }
        #endregion
        
        #region Parameter UpdateStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy to use for the update operation. Supported values are "coordinated" or
        /// "uncoordinated".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MemoryDB.UpdateStrategy")]
        public Amazon.MemoryDB.UpdateStrategy UpdateStrategy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MultiRegionCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MultiRegionCluster";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MultiRegionClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MultiRegionClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MultiRegionClusterName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MultiRegionClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MDBMultiRegionCluster (UpdateMultiRegionCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse, UpdateMDBMultiRegionClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MultiRegionClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.EngineVersion = this.EngineVersion;
            context.MultiRegionClusterName = this.MultiRegionClusterName;
            #if MODULAR
            if (this.MultiRegionClusterName == null && ParameterWasBound(nameof(this.MultiRegionClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiRegionClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiRegionParameterGroupName = this.MultiRegionParameterGroupName;
            context.NodeType = this.NodeType;
            context.ShardConfiguration_ShardCount = this.ShardConfiguration_ShardCount;
            context.UpdateStrategy = this.UpdateStrategy;
            
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
            var request = new Amazon.MemoryDB.Model.UpdateMultiRegionClusterRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.MultiRegionClusterName != null)
            {
                request.MultiRegionClusterName = cmdletContext.MultiRegionClusterName;
            }
            if (cmdletContext.MultiRegionParameterGroupName != null)
            {
                request.MultiRegionParameterGroupName = cmdletContext.MultiRegionParameterGroupName;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            
             // populate ShardConfiguration
            var requestShardConfigurationIsNull = true;
            request.ShardConfiguration = new Amazon.MemoryDB.Model.ShardConfigurationRequest();
            System.Int32? requestShardConfiguration_shardConfiguration_ShardCount = null;
            if (cmdletContext.ShardConfiguration_ShardCount != null)
            {
                requestShardConfiguration_shardConfiguration_ShardCount = cmdletContext.ShardConfiguration_ShardCount.Value;
            }
            if (requestShardConfiguration_shardConfiguration_ShardCount != null)
            {
                request.ShardConfiguration.ShardCount = requestShardConfiguration_shardConfiguration_ShardCount.Value;
                requestShardConfigurationIsNull = false;
            }
             // determine if request.ShardConfiguration should be set to null
            if (requestShardConfigurationIsNull)
            {
                request.ShardConfiguration = null;
            }
            if (cmdletContext.UpdateStrategy != null)
            {
                request.UpdateStrategy = cmdletContext.UpdateStrategy;
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
        
        private Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.UpdateMultiRegionClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "UpdateMultiRegionCluster");
            try
            {
                #if DESKTOP
                return client.UpdateMultiRegionCluster(request);
                #elif CORECLR
                return client.UpdateMultiRegionClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String MultiRegionClusterName { get; set; }
            public System.String MultiRegionParameterGroupName { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? ShardConfiguration_ShardCount { get; set; }
            public Amazon.MemoryDB.UpdateStrategy UpdateStrategy { get; set; }
            public System.Func<Amazon.MemoryDB.Model.UpdateMultiRegionClusterResponse, UpdateMDBMultiRegionClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MultiRegionCluster;
        }
        
    }
}
