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
    /// Updates the routing targets of an inference router. The routing targets that you specify
    /// replace all of the router's existing routing targets. To change one routing target,
    /// call <a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_DescribeInferenceRouter.html">DescribeInferenceRouter</a>,
    /// edit the routing targets, and send all of them.
    /// 
    ///  
    /// <para>
    /// The update is applied in full or not at all, and each request uses either the previous
    /// configuration or the new one. Updates typically take effect within about 2 minutes.
    /// </para><para>
    /// If the router is being created, updated, or deleted, or another request changes it
    /// at the same time, you get a <c>ConflictException</c>. Describe the router, and then
    /// send your update again.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMInferenceRouter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateInferenceRouter API operation.", Operation = new[] {"UpdateInferenceRouter"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateInferenceRouterResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.UpdateInferenceRouterResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.UpdateInferenceRouterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateSMInferenceRouterCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InferenceRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the inference router to update.</para>
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
        /// <para>The complete list of routing targets for the inference router. To remove the last
        /// routing target, delete the router.</para><para />
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InferenceRouterArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateInferenceRouterResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateInferenceRouterResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMInferenceRouter (UpdateInferenceRouter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateInferenceRouterResponse, UpdateSMInferenceRouterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.SageMaker.Model.UpdateInferenceRouterRequest();
            
            if (cmdletContext.InferenceRouterName != null)
            {
                request.InferenceRouterName = cmdletContext.InferenceRouterName;
            }
            if (cmdletContext.RoutingTarget != null)
            {
                request.RoutingTargets = cmdletContext.RoutingTarget;
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
        
        private Amazon.SageMaker.Model.UpdateInferenceRouterResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateInferenceRouterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateInferenceRouter");
            try
            {
                return client.UpdateInferenceRouterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InferenceRouterName { get; set; }
            public List<Amazon.SageMaker.Model.RoutingTarget> RoutingTarget { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateInferenceRouterResponse, UpdateSMInferenceRouterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InferenceRouterArn;
        }
        
    }
}
