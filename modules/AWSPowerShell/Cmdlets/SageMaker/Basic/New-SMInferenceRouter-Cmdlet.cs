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
    /// Creates an inference router. An inference router is a Regional SageMaker AI resource
    /// that sends each inference request to one of the endpoints or inference components
    /// that you list for a routing target. These destinations can be in any Amazon Web Services
    /// account, and in any Amazon Web Services Region in the same partition as the router.
    /// 
    ///  
    /// <para>
    /// The router's status is <c>Creating</c> until it's ready to use. SageMaker AI checks
    /// that each endpoint is a real-time or asynchronous endpoint, as the routing target
    /// requires, and rejects one of the wrong type. It checks endpoints in other accounts
    /// with your credentials, so the endpoint policy must allow <c>sagemaker:DescribeEndpoint</c>.
    /// SageMaker AI accepts an endpoint that it can't check, for example one that doesn't
    /// exist. Requests to it fail if it's the wrong type or doesn't exist. To see the status
    /// of each destination, call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeInferenceRouter.html">DescribeInferenceRouter</a>
    /// and see the <c>RoutingStatus</c> of each destination.
    /// </para><para>
    /// To invoke the router, use <c>InvokeInferenceRouter</c> or <c>InvokeInferenceRouterAsync</c>.
    /// For information about inference routers, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/inference-router.html">Route
    /// requests across Regions with inference routers</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "SMInferenceRouter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateInferenceRouter API operation.", Operation = new[] {"CreateInferenceRouter"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateInferenceRouterResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreateInferenceRouterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreateInferenceRouterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSMInferenceRouterCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InferenceRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the inference router. The name must be unique within your account in the
        /// current Amazon Web Services Region. The name is case sensitive.</para>
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
        public System.String InferenceRouterName { get; set; }
        #endregion
        
        #region Parameter RoutingTarget
        /// <summary>
        /// <para>
        /// <para>The routing targets of the inference router. Each routing target is a model that callers
        /// name when they invoke the router, and the destinations that serve it.</para><para />
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
        [Alias("RoutingTargets")]
        public Amazon.SageMaker.Model.RoutingTarget[] RoutingTarget { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to apply to the inference router. For information about
        /// tagging, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a> in the <i>Amazon Web Services General Reference</i>.</para><para />
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
        /// the request. If you reuse a client token, use the same request parameters. Otherwise,
        /// the request fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceRouterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateInferenceRouterResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateInferenceRouterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InferenceRouterArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InferenceRouterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMInferenceRouter (CreateInferenceRouter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateInferenceRouterResponse, NewSMInferenceRouterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.InferenceRouterName = this.InferenceRouterName;
            #if MODULAR
            if (this.InferenceRouterName == null && ParameterWasBound(nameof(this.InferenceRouterName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceRouterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RoutingTarget != null)
            {
                context.RoutingTarget = new List<Amazon.SageMaker.Model.RoutingTarget>(this.RoutingTarget);
            }
            #if MODULAR
            if (this.RoutingTarget == null && ParameterWasBound(nameof(this.RoutingTarget)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingTarget which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMaker.Model.CreateInferenceRouterRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InferenceRouterName != null)
            {
                request.InferenceRouterName = cmdletContext.InferenceRouterName;
            }
            if (cmdletContext.RoutingTarget != null)
            {
                request.RoutingTargets = cmdletContext.RoutingTarget;
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
        
        private Amazon.SageMaker.Model.CreateInferenceRouterResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateInferenceRouterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateInferenceRouter");
            try
            {
                return client.CreateInferenceRouterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InferenceRouterName { get; set; }
            public List<Amazon.SageMaker.Model.RoutingTarget> RoutingTarget { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateInferenceRouterResponse, NewSMInferenceRouterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceRouterArn;
        }
        
    }
}
