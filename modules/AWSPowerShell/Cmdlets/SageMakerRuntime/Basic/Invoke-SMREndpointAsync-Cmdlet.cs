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
using Amazon.SageMakerRuntime;
using Amazon.SageMakerRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMR
{
    /// <summary>
    /// After you deploy a model into production using Amazon SageMaker hosting services,
    /// your client applications use this API to get inferences from the model hosted at the
    /// specified endpoint in an asynchronous manner.
    /// 
    ///  
    /// <para>
    /// Inference requests sent to this API are enqueued for asynchronous processing. The
    /// processing of the inference request may or may not complete before you receive a response
    /// from this API. The response from this API will not contain the result of the inference
    /// request but contain information about where you can locate it.
    /// </para><para>
    /// Amazon SageMaker strips all POST headers except those supported by the API. Amazon
    /// SageMaker might add additional headers. You should not rely on the behavior of headers
    /// outside those enumerated in the request syntax. 
    /// </para><para>
    /// Calls to <c>InvokeEndpointAsync</c> are authenticated by using Amazon Web Services
    /// Signature Version 4. For information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sig-v4-authenticating-requests.html">Authenticating
    /// Requests (Amazon Web Services Signature Version 4)</a> in the <i>Amazon S3 API Reference</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "SMREndpointAsync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Runtime InvokeEndpointAsync API operation.", Operation = new[] {"InvokeEndpointAsync"}, SelectReturnType = typeof(Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse))]
    [AWSCmdletOutput("Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse",
        "This cmdlet returns an Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse object containing multiple properties."
    )]
    public partial class InvokeSMREndpointAsyncCmdlet : AmazonSageMakerRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The desired MIME type of the inference response from the model container.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>The MIME type of the input data in the request body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContentType { get; set; }
        #endregion
        
        #region Parameter CustomAttribute
        /// <summary>
        /// <para>
        /// <para>Provides additional information about a request for an inference submitted to a model
        /// hosted at an Amazon SageMaker endpoint. The information is an opaque value that is
        /// forwarded verbatim. You could use this value, for example, to provide an ID that you
        /// can use to track a request or to provide other metadata that a service endpoint was
        /// programmed to process. The value must consist of no more than 1024 visible US-ASCII
        /// characters as specified in <a href="https://datatracker.ietf.org/doc/html/rfc7230#section-3.2.6">Section
        /// 3.3.6. Field Value Components</a> of the Hypertext Transfer Protocol (HTTP/1.1). </para><para>The code in your model is responsible for setting or updating any custom attributes
        /// in the response. If your code does not set this value in the response, an empty value
        /// is returned. For example, if a custom attribute represents the trace ID, your model
        /// can prepend the custom attribute with <c>Trace ID:</c> in your post-processing function.
        /// </para><para>This feature is currently supported in the Amazon Web Services SDKs but not in the
        /// Amazon SageMaker Python SDK. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CustomAttributes")]
        public System.String CustomAttribute { get; set; }
        #endregion
        
        #region Parameter EndpointName
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint that you specified when you created the endpoint using the
        /// <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/API_CreateEndpoint.html">CreateEndpoint</a>
        /// API.</para>
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
        public System.String EndpointName { get; set; }
        #endregion
        
        #region Parameter InferenceId
        /// <summary>
        /// <para>
        /// <para>The identifier for the inference request. Amazon SageMaker will generate an identifier
        /// for you if none is specified. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InferenceId { get; set; }
        #endregion
        
        #region Parameter InputLocation
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where the inference request payload is stored.</para>
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
        /// <para>Maximum amount of time in seconds a request can be processed before it is marked as
        /// expired. The default is 15 minutes, or 900 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InvocationTimeoutSeconds")]
        public System.Int32? InvocationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RequestTTLSecond
        /// <summary>
        /// <para>
        /// <para>Maximum age in seconds a request can be in the queue before it is marked as expired.
        /// The default is 6 hours, or 21,600 seconds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestTTLSeconds")]
        public System.Int32? RequestTTLSecond { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse).
        /// Specifying the name of a property of type Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMREndpointAsync (InvokeEndpointAsync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse, InvokeSMREndpointAsyncCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.ContentType = this.ContentType;
            context.CustomAttribute = this.CustomAttribute;
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InferenceId = this.InferenceId;
            context.InputLocation = this.InputLocation;
            #if MODULAR
            if (this.InputLocation == null && ParameterWasBound(nameof(this.InputLocation)))
            {
                WriteWarning("You are passing $null as a value for parameter InputLocation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationTimeoutSecond = this.InvocationTimeoutSecond;
            context.RequestTTLSecond = this.RequestTTLSecond;
            
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
            var request = new Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncRequest();
            
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
            if (cmdletContext.EndpointName != null)
            {
                request.EndpointName = cmdletContext.EndpointName;
            }
            if (cmdletContext.InferenceId != null)
            {
                request.InferenceId = cmdletContext.InferenceId;
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
        
        private Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse CallAWSServiceOperation(IAmazonSageMakerRuntime client, Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Runtime", "InvokeEndpointAsync");
            try
            {
                return client.InvokeEndpointAsyncAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EndpointName { get; set; }
            public System.String InferenceId { get; set; }
            public System.String InputLocation { get; set; }
            public System.Int32? InvocationTimeoutSecond { get; set; }
            public System.Int32? RequestTTLSecond { get; set; }
            public System.Func<Amazon.SageMakerRuntime.Model.InvokeEndpointAsyncResponse, InvokeSMREndpointAsyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
