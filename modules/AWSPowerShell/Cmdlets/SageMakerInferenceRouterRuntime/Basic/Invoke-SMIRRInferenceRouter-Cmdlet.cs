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
using Amazon.SageMakerInferenceRouterRuntime;
using Amazon.SageMakerInferenceRouterRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMIRR
{
    /// <summary>
    /// Sends a real-time inference request to an inference router. In the request, you name
    /// the routing target, and the router sends the request to one of the routing target's
    /// destinations. The response includes the destination that served the request and the
    /// reason that the router chose it.
    /// 
    ///  
    /// <para>
    /// The following limits apply:
    /// </para><ul><li><para>
    /// The maximum request payload is 6 MB. A request with a larger body fails with HTTP
    /// status code 413.
    /// </para></li><li><para>
    /// Your model has up to 60 seconds for each attempt, the same limit as <c>InvokeEndpoint</c>.
    /// If your account has a higher model execution timeout for <c>InvokeEndpoint</c>, it
    /// doesn't apply through an inference router. For models that take longer, use <c>InvokeInferenceRouterAsync</c>.
    /// </para></li></ul><para>
    /// If a destination returns an error that the router can retry, such as a throttling
    /// error, before your model produces a response, the router retries the request once
    /// on another destination. A request that times out on a destination isn't retried. Because
    /// a request can make two attempts, set your client read timeout to at least 170 seconds.
    /// </para><para>
    /// The caller needs permission to invoke the inference router and every destination of
    /// the routing target. For information about permissions, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/inference-router.html">Route
    /// requests across Regions with inference routers</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "SMIRRInferenceRouter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Inference Router Runtime InvokeInferenceRouter API operation.", Operation = new[] {"InvokeInferenceRouter"}, SelectReturnType = typeof(Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse))]
    [AWSCmdletOutput("Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse",
        "This cmdlet returns an Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse object containing multiple properties."
    )]
    public partial class InvokeSMIRRInferenceRouterCmdlet : AmazonSageMakerInferenceRouterRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The MIME type that you want for the inference response. The router passes it to the
        /// destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>The input data for the inference, in the format that your model expects. The body
        /// can't be empty.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Body { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the request body. The router passes it to the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter CustomAttribute
        /// <summary>
        /// <para>
        /// <para>Provides additional information about the inference request. The value is an opaque
        /// string that the router passes, unchanged, to the model container of the destination
        /// that serves the request. The value can contain up to 1,024 visible US-ASCII characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomAttributes")]
        public System.String CustomAttribute { get; set; }
        #endregion
        
        #region Parameter InferenceId
        /// <summary>
        /// <para>
        /// <para>An identifier for the inference request. The router passes it to the destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InferenceId { get; set; }
        #endregion
        
        #region Parameter InferenceRouterName
        /// <summary>
        /// <para>
        /// <para>The name of the inference router to invoke.</para>
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
        public System.String InferenceRouterName { get; set; }
        #endregion
        
        #region Parameter PrefixAwareId
        /// <summary>
        /// <para>
        /// <para>An optional, stable identifier that serves as a routing hint for prefix-aware routing.
        /// The router passes it to the destination that serves the request. Within that destination,
        /// requests with the same prefix and the same identifier go to the same instance. If
        /// requests from different applications might have the same prompt prefix, set a different
        /// identifier for each application to differentiate their routing decisions.</para><para>Applies only to destination endpoints configured with a <c>RoutingStrategy</c> of
        /// <c>PREFIX_AWARE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrefixAwareId { get; set; }
        #endregion
        
        #region Parameter RoutingTargetName
        /// <summary>
        /// <para>
        /// <para>The name of the routing target in the inference router. The routing target lists the
        /// destinations that can serve the request.</para>
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
        public System.String RoutingTargetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse).
        /// Specifying the name of a property of type Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InferenceRouterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMIRRInferenceRouter (InvokeInferenceRouter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse, InvokeSMIRRInferenceRouterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.Body = this.Body;
            #if MODULAR
            if (this.Body == null && ParameterWasBound(nameof(this.Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContentType = this.ContentType;
            context.CustomAttribute = this.CustomAttribute;
            context.InferenceId = this.InferenceId;
            context.InferenceRouterName = this.InferenceRouterName;
            #if MODULAR
            if (this.InferenceRouterName == null && ParameterWasBound(nameof(this.InferenceRouterName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceRouterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrefixAwareId = this.PrefixAwareId;
            context.RoutingTargetName = this.RoutingTargetName;
            #if MODULAR
            if (this.RoutingTargetName == null && ParameterWasBound(nameof(this.RoutingTargetName)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingTargetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _BodyStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterRequest();
                
                if (cmdletContext.Accept != null)
                {
                    request.Accept = cmdletContext.Accept;
                }
                if (cmdletContext.Body != null)
                {
                    _BodyStream = new System.IO.MemoryStream(cmdletContext.Body);
                    request.Body = _BodyStream;
                }
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.CustomAttribute != null)
                {
                    request.CustomAttributes = cmdletContext.CustomAttribute;
                }
                if (cmdletContext.InferenceId != null)
                {
                    request.InferenceId = cmdletContext.InferenceId;
                }
                if (cmdletContext.InferenceRouterName != null)
                {
                    request.InferenceRouterName = cmdletContext.InferenceRouterName;
                }
                if (cmdletContext.PrefixAwareId != null)
                {
                    request.PrefixAwareId = cmdletContext.PrefixAwareId;
                }
                if (cmdletContext.RoutingTargetName != null)
                {
                    request.RoutingTargetName = cmdletContext.RoutingTargetName;
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
            finally
            {
                if( _BodyStream != null)
                {
                    _BodyStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse CallAWSServiceOperation(IAmazonSageMakerInferenceRouterRuntime client, Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Inference Router Runtime", "InvokeInferenceRouter");
            try
            {
                return client.InvokeInferenceRouterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public byte[] Body { get; set; }
            public System.String ContentType { get; set; }
            public System.String CustomAttribute { get; set; }
            public System.String InferenceId { get; set; }
            public System.String InferenceRouterName { get; set; }
            public System.String PrefixAwareId { get; set; }
            public System.String RoutingTargetName { get; set; }
            public System.Func<Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterResponse, InvokeSMIRRInferenceRouterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
