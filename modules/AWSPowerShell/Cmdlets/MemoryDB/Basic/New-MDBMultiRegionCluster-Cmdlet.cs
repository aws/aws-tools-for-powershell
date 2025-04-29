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
using Amazon.MemoryDB;
using Amazon.MemoryDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MDB
{
    /// <summary>
    /// Creates a new multi-Region cluster.
    /// </summary>
    [Cmdlet("New", "MDBMultiRegionCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MemoryDB.Model.MultiRegionCluster")]
    [AWSCmdlet("Calls the Amazon MemoryDB CreateMultiRegionCluster API operation.", Operation = new[] {"CreateMultiRegionCluster"}, SelectReturnType = typeof(Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse))]
    [AWSCmdletOutput("Amazon.MemoryDB.Model.MultiRegionCluster or Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse",
        "This cmdlet returns an Amazon.MemoryDB.Model.MultiRegionCluster object.",
        "The service call response (type Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewMDBMultiRegionClusterCmdlet : AmazonMemoryDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para>The name of the engine to be used for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para>The version of the engine to be used for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter MultiRegionClusterNameSuffix
        /// <summary>
        /// <para>
        /// <para>A suffix to be added to the Multi-Region cluster name. Amazon MemoryDB automatically
        /// applies a prefix to the Multi-Region cluster Name when it is created. Each Amazon
        /// Region has its own prefix. For instance, a Multi-Region cluster Name created in the
        /// US-West-1 region will begin with "virxk", along with the suffix name you provide.
        /// The suffix guarantees uniqueness of the Multi-Region cluster name across multiple
        /// regions.</para>
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
        public System.String MultiRegionClusterNameSuffix { get; set; }
        #endregion
        
        #region Parameter MultiRegionParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the multi-Region parameter group to be associated with the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MultiRegionParameterGroupName { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The node type to be used for the multi-Region cluster.</para>
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
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NumShard
        /// <summary>
        /// <para>
        /// <para>The number of shards for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumShards")]
        public System.Int32? NumShard { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to be applied to the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.MemoryDB.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TLSEnabled
        /// <summary>
        /// <para>
        /// <para>Whether to enable TLS encryption for the multi-Region cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TLSEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MultiRegionCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse).
        /// Specifying the name of a property of type Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MultiRegionCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MultiRegionClusterNameSuffix), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MDBMultiRegionCluster (CreateMultiRegionCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse, NewMDBMultiRegionClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.Engine = this.Engine;
            context.EngineVersion = this.EngineVersion;
            context.MultiRegionClusterNameSuffix = this.MultiRegionClusterNameSuffix;
            #if MODULAR
            if (this.MultiRegionClusterNameSuffix == null && ParameterWasBound(nameof(this.MultiRegionClusterNameSuffix)))
            {
                WriteWarning("You are passing $null as a value for parameter MultiRegionClusterNameSuffix which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MultiRegionParameterGroupName = this.MultiRegionParameterGroupName;
            context.NodeType = this.NodeType;
            #if MODULAR
            if (this.NodeType == null && ParameterWasBound(nameof(this.NodeType)))
            {
                WriteWarning("You are passing $null as a value for parameter NodeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumShard = this.NumShard;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.MemoryDB.Model.Tag>(this.Tag);
            }
            context.TLSEnabled = this.TLSEnabled;
            
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
            var request = new Amazon.MemoryDB.Model.CreateMultiRegionClusterRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.MultiRegionClusterNameSuffix != null)
            {
                request.MultiRegionClusterNameSuffix = cmdletContext.MultiRegionClusterNameSuffix;
            }
            if (cmdletContext.MultiRegionParameterGroupName != null)
            {
                request.MultiRegionParameterGroupName = cmdletContext.MultiRegionParameterGroupName;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NumShard != null)
            {
                request.NumShards = cmdletContext.NumShard.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TLSEnabled != null)
            {
                request.TLSEnabled = cmdletContext.TLSEnabled.Value;
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
        
        private Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse CallAWSServiceOperation(IAmazonMemoryDB client, Amazon.MemoryDB.Model.CreateMultiRegionClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MemoryDB", "CreateMultiRegionCluster");
            try
            {
                return client.CreateMultiRegionClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Engine { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String MultiRegionClusterNameSuffix { get; set; }
            public System.String MultiRegionParameterGroupName { get; set; }
            public System.String NodeType { get; set; }
            public System.Int32? NumShard { get; set; }
            public List<Amazon.MemoryDB.Model.Tag> Tag { get; set; }
            public System.Boolean? TLSEnabled { get; set; }
            public System.Func<Amazon.MemoryDB.Model.CreateMultiRegionClusterResponse, NewMDBMultiRegionClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MultiRegionCluster;
        }
        
    }
}
