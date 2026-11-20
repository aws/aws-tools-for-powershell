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
    /// Creates a global inference gateway. This operation is asynchronous: the global inference
    /// gateway starts in the `CREATING` status. To check its status, call `DescribeGlobalInferenceGateway`
    /// until the status is `ACTIVE` or `FAILED`. The operation fails with `ResourceInUse`
    /// if the name is already in use, or if one of the in-cluster inference gateways in `Gateways`
    /// already belongs to another global inference gateway.
    /// </summary>
    [Cmdlet("New", "SMGlobalInferenceGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateGlobalInferenceGateway API operation.", Operation = new[] {"CreateGlobalInferenceGateway"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse object containing multiple properties."
    )]
    public partial class NewSMGlobalInferenceGatewayCmdlet : AmazonSageMakerClientCmdlet, IExecutor
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
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that the global inference gateway assumes
        /// to access your SageMaker HyperPod clusters. The role must be in your account and partition,
        /// and you must have <c>iam:PassRole</c> permission for it. You can't change the role
        /// after you create the global inference gateway.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Gateway
        /// <summary>
        /// <para>
        /// The 1 to 10 in-cluster inference gateways to
        /// add to the global inference gateway. A global inference gateway must always have at
        /// least one in-cluster inference gateway, so `RemoveInferenceGateway` can't remove the
        /// last one.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Gateways")]
        public Amazon.SageMaker.Model.GlobalInferenceGatewayMember[] Gateway { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the global inference gateway. The name must be unique in your account
        /// in the current Region, and is case-sensitive. The name can't be exactly 12 lowercase
        /// letters or digits, because the global inference gateway ID uses that format.</para>
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
        public System.String Name { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Custom tags for managing the global inference gateway as an Amazon Web Services resource.
        /// You can add tags to your global inference gateway in the same way you add them in
        /// other Amazon Web Services services that support tagging. For more information about
        /// tagging Amazon Web Services resources, see <a href="https://docs.aws.amazon.com/tag-editor/latest/userguide/tagging.html">Tagging
        /// your Amazon Web Services resources</a> in the <i>Tagging Amazon Web Services Resources
        /// User Guide</i>.</para><para>The global inference gateway doesn't return tags in its responses. To read the tags,
        /// use <c>ListTags</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. An idempotent operation completes no more than one time. If you don't
        /// specify a client token, the Amazon Web Services SDKs and the Amazon Web Services CLI
        /// generate one for you.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.ExecutionRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMGlobalInferenceGateway (CreateGlobalInferenceGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse, NewSMGlobalInferenceGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Gateway != null)
            {
                context.Gateway = new List<Amazon.SageMaker.Model.GlobalInferenceGatewayMember>(this.Gateway);
            }
            #if MODULAR
            if (this.Gateway == null && ParameterWasBound(nameof(this.Gateway)))
            {
                WriteWarning("You are passing $null as a value for parameter Gateway which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Routing_Weights_ErrorRate = this.Routing_Weights_ErrorRate;
            context.Routing_Weights_KVHeadroom = this.Routing_Weights_KVHeadroom;
            context.Routing_Weights_QueueDepth = this.Routing_Weights_QueueDepth;
            context.Routing_Weights_RegionProximity = this.Routing_Weights_RegionProximity;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateGlobalInferenceGatewayRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.Gateway != null)
            {
                request.Gateways = cmdletContext.Gateway;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateGlobalInferenceGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateGlobalInferenceGateway");
            try
            {
                return client.CreateGlobalInferenceGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public List<Amazon.SageMaker.Model.GlobalInferenceGatewayMember> Gateway { get; set; }
            public System.String Name { get; set; }
            public System.Single? Routing_Weights_ErrorRate { get; set; }
            public System.Single? Routing_Weights_KVHeadroom { get; set; }
            public System.Single? Routing_Weights_QueueDepth { get; set; }
            public System.Single? Routing_Weights_RegionProximity { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateGlobalInferenceGatewayResponse, NewSMGlobalInferenceGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
