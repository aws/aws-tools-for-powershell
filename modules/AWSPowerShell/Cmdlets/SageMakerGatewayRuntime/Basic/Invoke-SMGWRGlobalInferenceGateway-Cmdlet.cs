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
using Amazon.SageMakerGatewayRuntime;
using Amazon.SageMakerGatewayRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMGWR
{
    /// <summary>
    /// Buffered (non-streaming) inference. Returns the full OpenAI completion body. Errors
    /// carry their origin in the `Message` prefix. Every typed error's text is in the `Message`
    /// member (JSON key `Message`), and starts with one of these prefixes: * `Global Inference
    /// Gateway: ` -- the gateway rejected or failed the request itself: validation, authorization,
    /// throttling, routing (the gateway or model was not found, or no capacity is available),
    /// a gateway limit or time limit, or failing to reach the inference gateway (`Global
    /// Inference Gateway: could not reach the inference gateway: &lt;reason&gt;`, or `Global
    /// Inference Gateway: timed out waiting for the inference gateway`). This includes the
    /// 400 for an invalid request and the 413 for a request body that is too large. * `inference
    /// gateway: ` -- the inference gateway serving the model returned an error status. The
    /// message gives that status code and up to 256 bytes of its error message, for example
    /// `inference gateway: 503 &lt;message&gt;`. A BadGatewayException can instead read `inference
    /// gateway: response ended unexpectedly`, with no status, when the inference gateway's
    /// connection failed while it was sending the response. * `inference gateway (&lt;component&gt;):
    /// ` -- the same, when the inference gateway reports which of its components produced
    /// the error, for example `inference gateway (model server): 502 &lt;message&gt;`. The
    /// component is one of: * `config` -- the inference gateway's configuration and proxy
    /// layer. * `scheduler` -- the inference gateway's request scheduler. * `model selector`
    /// -- the inference gateway's model selector. * `model server` -- the model server. Every
    /// error status the inference gateway returns is a typed error, chosen by that status:
    /// * 400 and any other 4xx not listed here -- a 400 validation error. * 401 and 403 --
    /// AccessDeniedException (403). * 404 -- ResourceNotFoundException. * 408 -- GatewayTimeoutException
    /// (504). * 429 -- ThrottlingException, with the `Retry-After` header. * 502, and 500,
    /// 503 or any other 5xx not listed here -- BadGatewayException (502). A 500 or 503 from
    /// the inference gateway comes after the request was dispatched, so it is not modeled
    /// as retryable, and the gateway may already have tried another inference gateway. Standard
    /// SDK retry modes may still retry a 5xx status; set max attempts to 1 if a repeated
    /// inference is unacceptable. * 504 -- GatewayTimeoutException.
    /// </summary>
    [Cmdlet("Invoke", "SMGWRGlobalInferenceGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the Amazon SageMaker Gateway Runtime InvokeGlobalInferenceGateway API operation.", Operation = new[] {"InvokeGlobalInferenceGateway"}, SelectReturnType = typeof(Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeSMGWRGlobalInferenceGatewayCmdlet : AmazonSageMakerGatewayRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// The MIME type you want for the response. It is
        /// passed to the model server.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// The inference request body: one OpenAI JSON object,
        /// at most 10 MiB. Its content is passed to the model server unchanged, except that the
        /// request is always sent with `"stream": false`: this operation returns one JSON document,
        /// so a `"stream": true` in the body is overridden (use InvokeGlobalInferenceGatewayWithResponseStream
        /// to stream). A body that is not one JSON object, or that repeats the top-level `model`
        /// key with different values, is rejected with a 400 validation error. A body larger
        /// than 10 MiB is rejected with PayloadTooLargeException (413). The gateway reads only
        /// `model` and `stream`, and does not store the body.
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
        /// The MIME type of the request body. Pass `application/json`
        /// (parameters such as `charset=utf-8` are allowed): the body is one OpenAI JSON object.
        /// The Global Inference Gateway rejects other content types with a 415 error.
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
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter CustomerIdentityToken
        /// <summary>
        /// <para>
        /// Per-caller customer identity token
        /// (a JWT), forwarded unchanged to the inference gateway, which validates it. The gateway
        /// does not use it to authorize the request. Include it in the SigV4 signed headers so
        /// it cannot be altered in transit. Redacted from logs, metrics and traces.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerIdentityToken { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// The ID of the Global Inference Gateway to invoke.
        /// IAM policies refer to the gateway by its ARN, `arn:&lt;partition&gt;:sagemaker:&lt;region&gt;:&lt;account&gt;:global-inference-gateway/&lt;id&gt;`.
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Body'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Body";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMGWRGlobalInferenceGateway (InvokeGlobalInferenceGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse, InvokeSMGWRGlobalInferenceGatewayCmdlet>(Select) ??
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
            #if MODULAR
            if (this.ContentType == null && ParameterWasBound(nameof(this.ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerIdentityToken = this.CustomerIdentityToken;
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
                var request = new Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayRequest();
                
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
                if (cmdletContext.CustomerIdentityToken != null)
                {
                    request.CustomerIdentityToken = cmdletContext.CustomerIdentityToken;
                }
                if (cmdletContext.GatewayId != null)
                {
                    request.GatewayId = cmdletContext.GatewayId;
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
        
        private Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse CallAWSServiceOperation(IAmazonSageMakerGatewayRuntime client, Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Gateway Runtime", "InvokeGlobalInferenceGateway");
            try
            {
                return client.InvokeGlobalInferenceGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomerIdentityToken { get; set; }
            public System.String GatewayId { get; set; }
            public System.Func<Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayResponse, InvokeSMGWRGlobalInferenceGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => Amazon.PowerShell.Common.SensitiveOutput.TagForHost(response.Body, cmdlet, "Body");
        }
        
    }
}
