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
    /// Streaming inference. Returns an AWS event stream of PayloadPart events that carry
    /// the model server's server-sent event (SSE) bytes, so SDKs decode the stream into events
    /// for you. The errors listed for this operation, other than ModelStreamError and InternalStreamFailure,
    /// are returned before the response starts (before the 200 status), so they end the request,
    /// not the stream. None of them can occur after the 200. ModelStreamError and InternalStreamFailure
    /// appear only as events in the stream, after the 200. Once the 200 is sent, the stream
    /// carries the response as PayloadPart events. If reading the inference gateway's response
    /// fails, the stream carries one InternalStreamFailure event and then ends. ModelStreamError
    /// is reserved and is not currently sent. Errors carry their origin in the `Message`
    /// prefix. Every typed error's text is in the `Message` member (JSON key `Message`),
    /// and starts with one of these prefixes: * `Global Inference Gateway: ` -- the gateway
    /// rejected or failed the request itself: validation, authorization, throttling, routing
    /// (the gateway or model was not found, or no capacity is available), a gateway limit
    /// or time limit, or failing to reach the inference gateway (`Global Inference Gateway:
    /// could not reach the inference gateway: &lt;reason&gt;`, or `Global Inference Gateway:
    /// timed out waiting for the inference gateway`). This includes the 400 for an invalid
    /// request and the 413 for a request body that is too large. * `inference gateway: `
    /// -- the inference gateway serving the model returned an error status. The message gives
    /// that status code and up to 256 bytes of its error message, for example `inference
    /// gateway: 503 &lt;message&gt;`. * `inference gateway (&lt;component&gt;): ` -- the
    /// same, when the inference gateway reports which of its components produced the error,
    /// for example `inference gateway (model server): 502 &lt;message&gt;`. The component
    /// is one of: * `config` -- the inference gateway's configuration and proxy layer. *
    /// `scheduler` -- the inference gateway's request scheduler. * `model selector` -- the
    /// inference gateway's model selector. * `model server` -- the model server. An InternalStreamFailure
    /// event's `Message` uses the same prefixes, with the same text the buffered operation
    /// uses for the same failure. Its `inference gateway: ` message carries no status: `inference
    /// gateway: response ended unexpectedly` when the inference gateway's connection failed
    /// while it was sending the response. Every error status the inference gateway returns
    /// before the 200 is a typed error, chosen by that status as for InvokeGlobalInferenceGateway:
    /// * 400 and any other 4xx not listed here -- a 400 validation error. * 401 and 403 --
    /// AccessDeniedException (403). * 404 -- ResourceNotFoundException. * 408 -- GatewayTimeoutException
    /// (504). * 429 -- ThrottlingException, with the `Retry-After` header. * 502, and 500,
    /// 503 or any other 5xx not listed here -- BadGatewayException (502). A 500 or 503 from
    /// the inference gateway comes after the request was dispatched, so it is not modeled
    /// as retryable, and the gateway may already have tried another inference gateway. Standard
    /// SDK retry modes may still retry a 5xx status; set max attempts to 1 if a repeated
    /// inference is unacceptable. * 504 -- GatewayTimeoutException.
    /// </summary>
    [Cmdlet("Invoke", "SMGWRGlobalInferenceGatewayWithResponseStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerGatewayRuntime.Model.ResponseStream")]
    [AWSCmdlet("Calls the Amazon SageMaker Gateway Runtime InvokeGlobalInferenceGatewayWithResponseStream API operation.", Operation = new[] {"InvokeGlobalInferenceGatewayWithResponseStream"}, SelectReturnType = typeof(Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGatewayRuntime.Model.ResponseStream or Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse",
        "This cmdlet returns an Amazon.SageMakerGatewayRuntime.Model.ResponseStream object.",
        "The service call response (type Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InvokeSMGWRGlobalInferenceGatewayWithResponseStreamCmdlet : AmazonSageMakerGatewayRuntimeClientCmdlet, IExecutor
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
        /// The inference request body, as for InvokeGlobalInferenceGateway,
        /// except that the request is always sent with `"stream": true`: this operation returns
        /// an event stream, so a `"stream": false` in the body (or no `stream` key) is overridden.
        /// A body larger than 10 MiB is rejected with PayloadTooLargeException (413).
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
        /// The MIME type of the request body, as for
        /// InvokeGlobalInferenceGateway. Pass `application/json`.
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
        /// The customer identity token (a JWT),
        /// as for InvokeGlobalInferenceGateway. It is passed unchanged to the inference gateway,
        /// which validates it.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerIdentityToken { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// The ID of the Global Inference Gateway to invoke,
        /// as for InvokeGlobalInferenceGateway.
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMGWRGlobalInferenceGatewayWithResponseStream (InvokeGlobalInferenceGatewayWithResponseStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse, InvokeSMGWRGlobalInferenceGatewayWithResponseStreamCmdlet>(Select) ??
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
                var request = new Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamRequest();
                
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
        
        private Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse CallAWSServiceOperation(IAmazonSageMakerGatewayRuntime client, Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Gateway Runtime", "InvokeGlobalInferenceGatewayWithResponseStream");
            try
            {
                return client.InvokeGlobalInferenceGatewayWithResponseStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SageMakerGatewayRuntime.Model.InvokeGlobalInferenceGatewayWithResponseStreamResponse, InvokeSMGWRGlobalInferenceGatewayWithResponseStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Body;
        }
        
    }
}
