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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Updates the routing configuration of a global inference gateway. To add or remove
    /// in-cluster inference gateways, use `AddInferenceGateway` and `RemoveInferenceGateway`.
    /// This operation is asynchronous: the global inference gateway moves to the `UPDATING`
    /// status. The operation fails with `ConflictException` while another operation is in
    /// progress on the global inference gateway.
    /// </summary>
    [Cmdlet("Update", "SMGlobalInferenceGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateGlobalInferenceGateway API operation.", Operation = new[] {"UpdateGlobalInferenceGateway"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse object containing multiple properties."
    )]
    public partial class UpdateSMGlobalInferenceGatewayCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Routing_Weights_ErrorRate
        /// <summary>
        /// <para>
        /// <para>The weight of the recent error rate of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Routing_Weights_ErrorRate { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The name, Amazon Resource Name (ARN), or ID of the global inference gateway to update.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Routing_Weights_KVHeadroom
        /// <summary>
        /// <para>
        /// <para>The weight of the free key-value (KV) cache capacity on the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Routing_Weights_KVHeadroom { get; set; }
        #endregion
        
        #region Parameter Routing_Weights_QueueDepth
        /// <summary>
        /// <para>
        /// <para>The weight of the number of requests that are waiting on the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Routing_Weights_QueueDepth { get; set; }
        #endregion
        
        #region Parameter Routing_Weights_RegionProximity
        /// <summary>
        /// <para>
        /// <para>The weight of how close the cluster is to the caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Routing_Weights_RegionProximity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMGlobalInferenceGateway (UpdateGlobalInferenceGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse, UpdateSMGlobalInferenceGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Routing_Weights_ErrorRate = this.Routing_Weights_ErrorRate;
            context.Routing_Weights_KVHeadroom = this.Routing_Weights_KVHeadroom;
            context.Routing_Weights_QueueDepth = this.Routing_Weights_QueueDepth;
            context.Routing_Weights_RegionProximity = this.Routing_Weights_RegionProximity;
            
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
            var request = new Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayRequest();
            
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate Routing
            var requestRoutingIsNull = true;
            request.Routing = new Amazon.SageMaker.Model.GlobalInferenceGatewayRouting();
            Amazon.SageMaker.Model.GlobalInferenceGatewayRoutingWeights requestRouting_routing_Weights = null;
            
             // populate Weights
            var requestRouting_routing_WeightsIsNull = true;
            requestRouting_routing_Weights = new Amazon.SageMaker.Model.GlobalInferenceGatewayRoutingWeights();
            System.Single? requestRouting_routing_Weights_routing_Weights_ErrorRate = null;
            if (cmdletContext.Routing_Weights_ErrorRate != null)
            {
                requestRouting_routing_Weights_routing_Weights_ErrorRate = cmdletContext.Routing_Weights_ErrorRate.Value;
            }
            if (requestRouting_routing_Weights_routing_Weights_ErrorRate != null)
            {
                requestRouting_routing_Weights.ErrorRate = requestRouting_routing_Weights_routing_Weights_ErrorRate.Value;
                requestRouting_routing_WeightsIsNull = false;
            }
            System.Single? requestRouting_routing_Weights_routing_Weights_KVHeadroom = null;
            if (cmdletContext.Routing_Weights_KVHeadroom != null)
            {
                requestRouting_routing_Weights_routing_Weights_KVHeadroom = cmdletContext.Routing_Weights_KVHeadroom.Value;
            }
            if (requestRouting_routing_Weights_routing_Weights_KVHeadroom != null)
            {
                requestRouting_routing_Weights.KVHeadroom = requestRouting_routing_Weights_routing_Weights_KVHeadroom.Value;
                requestRouting_routing_WeightsIsNull = false;
            }
            System.Single? requestRouting_routing_Weights_routing_Weights_QueueDepth = null;
            if (cmdletContext.Routing_Weights_QueueDepth != null)
            {
                requestRouting_routing_Weights_routing_Weights_QueueDepth = cmdletContext.Routing_Weights_QueueDepth.Value;
            }
            if (requestRouting_routing_Weights_routing_Weights_QueueDepth != null)
            {
                requestRouting_routing_Weights.QueueDepth = requestRouting_routing_Weights_routing_Weights_QueueDepth.Value;
                requestRouting_routing_WeightsIsNull = false;
            }
            System.Single? requestRouting_routing_Weights_routing_Weights_RegionProximity = null;
            if (cmdletContext.Routing_Weights_RegionProximity != null)
            {
                requestRouting_routing_Weights_routing_Weights_RegionProximity = cmdletContext.Routing_Weights_RegionProximity.Value;
            }
            if (requestRouting_routing_Weights_routing_Weights_RegionProximity != null)
            {
                requestRouting_routing_Weights.RegionProximity = requestRouting_routing_Weights_routing_Weights_RegionProximity.Value;
                requestRouting_routing_WeightsIsNull = false;
            }
             // determine if requestRouting_routing_Weights should be set to null
            if (requestRouting_routing_WeightsIsNull)
            {
                requestRouting_routing_Weights = null;
            }
            if (requestRouting_routing_Weights != null)
            {
                request.Routing.Weights = requestRouting_routing_Weights;
                requestRoutingIsNull = false;
            }
             // determine if request.Routing should be set to null
            if (requestRoutingIsNull)
            {
                request.Routing = null;
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
        
        private Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateGlobalInferenceGateway");
            try
            {
                return client.UpdateGlobalInferenceGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Identifier { get; set; }
            public System.Single? Routing_Weights_ErrorRate { get; set; }
            public System.Single? Routing_Weights_KVHeadroom { get; set; }
            public System.Single? Routing_Weights_QueueDepth { get; set; }
            public System.Single? Routing_Weights_RegionProximity { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateGlobalInferenceGatewayResponse, UpdateSMGlobalInferenceGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
