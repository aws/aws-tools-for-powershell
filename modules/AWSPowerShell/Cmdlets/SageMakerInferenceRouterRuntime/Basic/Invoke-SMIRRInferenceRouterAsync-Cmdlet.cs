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
    /// Submits an asynchronous inference request to an inference router. Before you call
    /// this operation, upload the input data to Amazon S3 in the router's Amazon Web Services
    /// Region. The router returns as soon as it accepts the request, and sends the request
    /// to one of the destinations of the routing target. The destination reads the input
    /// from Amazon S3, and the inference response is written to the Amazon S3 output path
    /// that the routing target specifies.
    /// 
    ///  
    /// <para>
    /// If a destination doesn't start the request within the routing target's <c>MaxTimeInBacklogSeconds</c>,
    /// the router moves the request to another destination. After your model starts processing
    /// the request, the request doesn't move. If no destination can take the request before
    /// <c>RequestTTLSeconds</c> runs out, or every destination has been tried, the router
    /// writes a failure object to the <c>FailureLocation</c> and publishes a notification
    /// to the routing target's error topic, if one is configured.
    /// </para><para>
    /// For information about the permissions that the caller and each destination need, see
    /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/inference-router-async.html">Send
    /// asynchronous requests through an inference router</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "SMIRRInferenceRouterAsync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Inference Router Runtime InvokeInferenceRouterAsync API operation.", Operation = new[] {"InvokeInferenceRouterAsync"}, SelectReturnType = typeof(Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse))]
    [AWSCmdletOutput("Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse",
        "This cmdlet returns an Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse object containing multiple properties."
    )]
    public partial class InvokeSMIRRInferenceRouterAsyncCmdlet : AmazonSageMakerInferenceRouterRuntimeClientCmdlet, IExecutor
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
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in Amazon S3. The router passes it to the destination.</para>
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
        
        #region Parameter Filename
        /// <summary>
        /// <para>
        /// <para>The file name of the inference response stored in Amazon S3. If you don't provide
        /// one, SageMaker AI generates one.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filename { get; set; }
        #endregion
        
        #region Parameter InferenceId
        /// <summary>
        /// <para>
        /// <para>An identifier for the inference request. If you don't provide one, SageMaker AI generates
        /// one and returns it in the response.</para>
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
        
        #region Parameter InputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI of the object that contains the input data for the inference. The
        /// bucket must be in the inference router's Amazon Web Services Region and owned by the
        /// router's account. The destination endpoint's execution role reads the object, and
        /// the destination's asynchronous inference limits apply to it.</para>
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
        public System.String InputLocation { get; set; }
        #endregion
        
        #region Parameter InvocationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum time, in seconds, that a destination can spend processing the request
        /// before the request is marked as expired. The default is 900 seconds (15 minutes).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvocationTimeoutSeconds")]
        public System.Int32? InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RequestTTLSecond
        /// <summary>
        /// <para>
        /// <para>The time to live of the request, in seconds, measured from when the router accepts
        /// it. If no destination starts the request in this time, the request fails. The default
        /// is 21,600 seconds (6 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestTTLSeconds")]
        public System.Int32? RequestTTLSecond { get; set; }
        #endregion
        
        #region Parameter RoutingTargetName
        /// <summary>
        /// <para>
        /// <para>The name of the routing target in the inference router. The routing target must be
        /// configured for asynchronous inference.</para>
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
        
        #region Parameter S3OutputPathExtension
        /// <summary>
        /// <para>
        /// <para>The path extension that is appended to the routing target's Amazon S3 output path
        /// where the inference response is stored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3OutputPathExtension { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse).
        /// Specifying the name of a property of type Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse will result in that property being returned.
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
                nameof(this.InferenceRouterName),
                nameof(this.RoutingTargetName)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMIRRInferenceRouterAsync (InvokeInferenceRouterAsync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse, InvokeSMIRRInferenceRouterAsyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.ContentType = this.ContentType;
            context.CustomAttribute = this.CustomAttribute;
            context.Filename = this.Filename;
            context.InferenceId = this.InferenceId;
            context.InferenceRouterName = this.InferenceRouterName;
            #if MODULAR
            if (this.InferenceRouterName == null && ParameterWasBound(nameof(this.InferenceRouterName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceRouterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputLocation = this.InputLocation;
            #if MODULAR
            if (this.InputLocation == null && ParameterWasBound(nameof(this.InputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter InputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationTimeoutSecond = this.InvocationTimeoutSecond;
            context.RequestTTLSecond = this.RequestTTLSecond;
            context.RoutingTargetName = this.RoutingTargetName;
            #if MODULAR
            if (this.RoutingTargetName == null && ParameterWasBound(nameof(this.RoutingTargetName)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingTargetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputPathExtension = this.S3OutputPathExtension;
            
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
            var request = new Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.ContentType != null)
            {
                request.ContentType = cmdletContext.ContentType;
            }
            if (cmdletContext.CustomAttribute != null)
            {
                request.CustomAttributes = cmdletContext.CustomAttribute;
            }
            if (cmdletContext.Filename != null)
            {
                request.Filename = cmdletContext.Filename;
            }
            if (cmdletContext.InferenceId != null)
            {
                request.InferenceId = cmdletContext.InferenceId;
            }
            if (cmdletContext.InferenceRouterName != null)
            {
                request.InferenceRouterName = cmdletContext.InferenceRouterName;
            }
            if (cmdletContext.InputLocation != null)
            {
                request.InputLocation = cmdletContext.InputLocation;
            }
            if (cmdletContext.InvocationTimeoutSecond != null)
            {
                request.InvocationTimeoutSeconds = cmdletContext.InvocationTimeoutSecond.Value;
            }
            if (cmdletContext.RequestTTLSecond != null)
            {
                request.RequestTTLSeconds = cmdletContext.RequestTTLSecond.Value;
            }
            if (cmdletContext.RoutingTargetName != null)
            {
                request.RoutingTargetName = cmdletContext.RoutingTargetName;
            }
            if (cmdletContext.S3OutputPathExtension != null)
            {
                request.S3OutputPathExtension = cmdletContext.S3OutputPathExtension;
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
        
        private Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse CallAWSServiceOperation(IAmazonSageMakerInferenceRouterRuntime client, Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Inference Router Runtime", "InvokeInferenceRouterAsync");
            try
            {
                return client.InvokeInferenceRouterAsyncAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContentType { get; set; }
            public System.String CustomAttribute { get; set; }
            public System.String Filename { get; set; }
            public System.String InferenceId { get; set; }
            public System.String InferenceRouterName { get; set; }
            public System.String InputLocation { get; set; }
            public System.Int32? InvocationTimeoutSecond { get; set; }
            public System.Int32? RequestTTLSecond { get; set; }
            public System.String RoutingTargetName { get; set; }
            public System.String S3OutputPathExtension { get; set; }
            public System.Func<Amazon.SageMakerInferenceRouterRuntime.Model.InvokeInferenceRouterAsyncResponse, InvokeSMIRRInferenceRouterAsyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
