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
using Amazon.NeptuneGraph;
using Amazon.NeptuneGraph.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NEPTG
{
    /// <summary>
    /// Updates the configuration of a specified Neptune Analytics graph
    /// </summary>
    [Cmdlet("Update", "NEPTGGraph", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NeptuneGraph.Model.UpdateGraphResponse")]
    [AWSCmdlet("Calls the Amazon Neptune Graph UpdateGraph API operation.", Operation = new[] {"UpdateGraph"}, SelectReturnType = typeof(Amazon.NeptuneGraph.Model.UpdateGraphResponse))]
    [AWSCmdletOutput("Amazon.NeptuneGraph.Model.UpdateGraphResponse",
        "This cmdlet returns an Amazon.NeptuneGraph.Model.UpdateGraphResponse object containing multiple properties."
    )]
    public partial class UpdateNEPTGGraphCmdlet : AmazonNeptuneGraphClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>A value that indicates whether the graph has deletion protection enabled. The graph
        /// can't be deleted when deletion protection is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter GraphIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Neptune Analytics graph.</para>
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
        public System.String GraphIdentifier { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_ProvisionedGraph_Memory
        /// <summary>
        /// <para>
        /// <para>The provisioned memory-optimized Neptune Capacity Units (m-NCUs) to use for the graph.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_ProvisionedGraph_Memory { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_GraphSession_MinMemory
        /// <summary>
        /// <para>
        /// <para>The minimum Session Neptune Capacity Units (s-NCUs) available to the graph session.</para><para>A graph session can burst up to 2x the configured min memory. For example, a <c>minMemory</c>
        /// of 4 can burst up to 8 s-NCUs, and a <c>minMemory</c> of 8 can burst up to 16 s-NCUs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeConfiguration_GraphSession_MinMemory { get; set; }
        #endregion
        
        #region Parameter PublicConnectivity
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not the graph can be reachable over the internet. All access
        /// to graphs is IAM authenticated. (<c>true</c> to enable, or <c>false</c> to disable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PublicConnectivity { get; set; }
        #endregion
        
        #region Parameter ProvisionedMemory
        /// <summary>
        /// <para>
        /// <para>The provisioned memory-optimized Neptune Capacity Units (m-NCUs) to use for the graph.</para><para>Min = 16</para><note><para>This field is deprecated. We recommend using <c>computeConfiguration</c> instead.</para></note>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("ProvisionedMemory is deprecated. Use ComputeConfiguration instead.")]
        public System.Int32? ProvisionedMemory { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NeptuneGraph.Model.UpdateGraphResponse).
        /// Specifying the name of a property of type Amazon.NeptuneGraph.Model.UpdateGraphResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GraphIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NEPTGGraph (UpdateGraph)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NeptuneGraph.Model.UpdateGraphResponse, UpdateNEPTGGraphCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComputeConfiguration_GraphSession_MinMemory = this.ComputeConfiguration_GraphSession_MinMemory;
            context.ComputeConfiguration_ProvisionedGraph_Memory = this.ComputeConfiguration_ProvisionedGraph_Memory;
            context.DeletionProtection = this.DeletionProtection;
            context.GraphIdentifier = this.GraphIdentifier;
            #if MODULAR
            if (this.GraphIdentifier == null && ParameterWasBound(nameof(this.GraphIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GraphIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedMemory = this.ProvisionedMemory;
            context.PublicConnectivity = this.PublicConnectivity;
            
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
            var request = new Amazon.NeptuneGraph.Model.UpdateGraphRequest();
            
            
             // populate ComputeConfiguration
            var requestComputeConfigurationIsNull = true;
            request.ComputeConfiguration = new Amazon.NeptuneGraph.Model.ComputeConfiguration();
            Amazon.NeptuneGraph.Model.GraphSessionConfiguration requestComputeConfiguration_computeConfiguration_GraphSession = null;
            
             // populate GraphSession
            var requestComputeConfiguration_computeConfiguration_GraphSessionIsNull = true;
            requestComputeConfiguration_computeConfiguration_GraphSession = new Amazon.NeptuneGraph.Model.GraphSessionConfiguration();
            System.Int32? requestComputeConfiguration_computeConfiguration_GraphSession_computeConfiguration_GraphSession_MinMemory = null;
            if (cmdletContext.ComputeConfiguration_GraphSession_MinMemory != null)
            {
                requestComputeConfiguration_computeConfiguration_GraphSession_computeConfiguration_GraphSession_MinMemory = cmdletContext.ComputeConfiguration_GraphSession_MinMemory.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_GraphSession_computeConfiguration_GraphSession_MinMemory != null)
            {
                requestComputeConfiguration_computeConfiguration_GraphSession.MinMemory = requestComputeConfiguration_computeConfiguration_GraphSession_computeConfiguration_GraphSession_MinMemory.Value;
                requestComputeConfiguration_computeConfiguration_GraphSessionIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_GraphSession should be set to null
            if (requestComputeConfiguration_computeConfiguration_GraphSessionIsNull)
            {
                requestComputeConfiguration_computeConfiguration_GraphSession = null;
            }
            if (requestComputeConfiguration_computeConfiguration_GraphSession != null)
            {
                request.ComputeConfiguration.GraphSession = requestComputeConfiguration_computeConfiguration_GraphSession;
                requestComputeConfigurationIsNull = false;
            }
            Amazon.NeptuneGraph.Model.ProvisionedGraphConfiguration requestComputeConfiguration_computeConfiguration_ProvisionedGraph = null;
            
             // populate ProvisionedGraph
            var requestComputeConfiguration_computeConfiguration_ProvisionedGraphIsNull = true;
            requestComputeConfiguration_computeConfiguration_ProvisionedGraph = new Amazon.NeptuneGraph.Model.ProvisionedGraphConfiguration();
            System.Int32? requestComputeConfiguration_computeConfiguration_ProvisionedGraph_computeConfiguration_ProvisionedGraph_Memory = null;
            if (cmdletContext.ComputeConfiguration_ProvisionedGraph_Memory != null)
            {
                requestComputeConfiguration_computeConfiguration_ProvisionedGraph_computeConfiguration_ProvisionedGraph_Memory = cmdletContext.ComputeConfiguration_ProvisionedGraph_Memory.Value;
            }
            if (requestComputeConfiguration_computeConfiguration_ProvisionedGraph_computeConfiguration_ProvisionedGraph_Memory != null)
            {
                requestComputeConfiguration_computeConfiguration_ProvisionedGraph.Memory = requestComputeConfiguration_computeConfiguration_ProvisionedGraph_computeConfiguration_ProvisionedGraph_Memory.Value;
                requestComputeConfiguration_computeConfiguration_ProvisionedGraphIsNull = false;
            }
             // determine if requestComputeConfiguration_computeConfiguration_ProvisionedGraph should be set to null
            if (requestComputeConfiguration_computeConfiguration_ProvisionedGraphIsNull)
            {
                requestComputeConfiguration_computeConfiguration_ProvisionedGraph = null;
            }
            if (requestComputeConfiguration_computeConfiguration_ProvisionedGraph != null)
            {
                request.ComputeConfiguration.ProvisionedGraph = requestComputeConfiguration_computeConfiguration_ProvisionedGraph;
                requestComputeConfigurationIsNull = false;
            }
             // determine if request.ComputeConfiguration should be set to null
            if (requestComputeConfigurationIsNull)
            {
                request.ComputeConfiguration = null;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.GraphIdentifier != null)
            {
                request.GraphIdentifier = cmdletContext.GraphIdentifier;
            }
            if (cmdletContext.ProvisionedMemory != null)
            {
                request.ProvisionedMemory = cmdletContext.ProvisionedMemory.Value;
            }
            if (cmdletContext.PublicConnectivity != null)
            {
                request.PublicConnectivity = cmdletContext.PublicConnectivity.Value;
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
        
        private Amazon.NeptuneGraph.Model.UpdateGraphResponse CallAWSServiceOperation(IAmazonNeptuneGraph client, Amazon.NeptuneGraph.Model.UpdateGraphRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Neptune Graph", "UpdateGraph");
            try
            {
                return client.UpdateGraphAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ComputeConfiguration_GraphSession_MinMemory { get; set; }
            public System.Int32? ComputeConfiguration_ProvisionedGraph_Memory { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String GraphIdentifier { get; set; }
            [System.ObsoleteAttribute]
            public System.Int32? ProvisionedMemory { get; set; }
            public System.Boolean? PublicConnectivity { get; set; }
            public System.Func<Amazon.NeptuneGraph.Model.UpdateGraphResponse, UpdateNEPTGGraphCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
