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

namespace Amazon.PowerShell.Cmdlets.SMR
{
    /// <summary>
    /// After you deploy a model into production using Amazon SageMaker hosting services,
    /// your client applications use this API to get inferences from the model hosted at the
    /// specified endpoint. 
    /// 
    ///  
    /// <para>
    /// For an overview of Amazon SageMaker, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/how-it-works.html">How
    /// It Works</a>. 
    /// </para><para>
    /// Amazon SageMaker strips all POST headers except those supported by the API. Amazon
    /// SageMaker might add additional headers. You should not rely on the behavior of headers
    /// outside those enumerated in the request syntax. 
    /// </para><para>
    /// Calls to <c>InvokeEndpoint</c> are authenticated by using Amazon Web Services Signature
    /// Version 4. For information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/API/sig-v4-authenticating-requests.html">Authenticating
    /// Requests (Amazon Web Services Signature Version 4)</a> in the <i>Amazon S3 API Reference</i>.
    /// </para><para>
    /// A customer's model containers must respond to requests within 60 seconds. The model
    /// itself can have a maximum processing time of 60 seconds before responding to invocations.
    /// If your model is going to take 50-60 seconds of processing time, the SDK socket timeout
    /// should be set to be 70 seconds.
    /// </para><note><para>
    /// Endpoints are scoped to an individual account, and are not public. The URL does not
    /// contain the account ID, but Amazon SageMaker determines the account ID from the authentication
    /// token that is supplied by the caller.
    /// </para></note>
    /// </summary>
    [Cmdlet("Invoke", "SMREndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerRuntime.Model.InvokeEndpointResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Runtime InvokeEndpoint API operation.", Operation = new[] {"InvokeEndpoint"}, SelectReturnType = typeof(Amazon.SageMakerRuntime.Model.InvokeEndpointResponse))]
    [AWSCmdletOutput("Amazon.SageMakerRuntime.Model.InvokeEndpointResponse",
        "This cmdlet returns an Amazon.SageMakerRuntime.Model.InvokeEndpointResponse object containing multiple properties."
    )]
    public partial class InvokeSMREndpointCmdlet : AmazonSageMakerRuntimeClientCmdlet, IExecutor
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
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>Provides input data, in the format specified in the <c>ContentType</c> request header.
        /// Amazon SageMaker passes all of the data in the body to the model. </para><para>For information about the format of the request body, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/cdf-inference.html">Common
        /// Data Formats-Inference</a>.</para>
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
        
        #region Parameter EnableExplanation
        /// <summary>
        /// <para>
        /// <para>An optional JMESPath expression used to override the <c>EnableExplanations</c> parameter
        /// of the <c>ClarifyExplainerConfig</c> API. See the <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/clarify-online-explainability-create-endpoint.html#clarify-online-explainability-create-endpoint-enable">EnableExplanations</a>
        /// section in the developer guide for more information. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableExplanations")]
        public System.String EnableExplanation { get; set; }
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
        
        #region Parameter InferenceComponentName
        /// <summary>
        /// <para>
        /// <para>If the endpoint hosts one or more inference components, this parameter specifies the
        /// name of inference component to invoke.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InferenceComponentName { get; set; }
        #endregion
        
        #region Parameter InferenceId
        /// <summary>
        /// <para>
        /// <para>If you provide a value, it is added to the captured data when you enable data capture
        /// on the endpoint. For information about data capture, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-monitor-data-capture.html">Capture
        /// Data</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InferenceId { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>Creates a stateful session or identifies an existing one. You can do one of the following:</para><ul><li><para>Create a stateful session by specifying the value <c>NEW_SESSION</c>.</para></li><li><para>Send your request to an existing stateful session by specifying the ID of that session.</para></li></ul><para>With a stateful session, you can send multiple requests to a stateful model. When
        /// you create a session with a stateful model, the model must create the session ID and
        /// set the expiration time. The model must also provide that information in the response
        /// to your request. You can get the ID and timestamp from the <c>NewSessionId</c> response
        /// parameter. For any subsequent request where you specify that session ID, SageMaker
        /// routes the request to the same instance that supports the session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter TargetContainerHostname
        /// <summary>
        /// <para>
        /// <para>If the endpoint hosts multiple containers and is configured to use direct invocation,
        /// this parameter specifies the host name of the container to invoke.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetContainerHostname { get; set; }
        #endregion
        
        #region Parameter TargetModel
        /// <summary>
        /// <para>
        /// <para>The model to request for inference when invoking a multi-model endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetModel { get; set; }
        #endregion
        
        #region Parameter TargetVariant
        /// <summary>
        /// <para>
        /// <para>Specify the production variant to send the inference request to when invoking an endpoint
        /// that is running two or more variants. Note that this parameter overrides the default
        /// behavior for the endpoint, which is to distribute the invocation traffic based on
        /// the variant weights.</para><para>For information about how to use variant targeting to perform a/b testing, see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/model-ab-testing.html">Test
        /// models in production</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetVariant { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerRuntime.Model.InvokeEndpointResponse).
        /// Specifying the name of a property of type Amazon.SageMakerRuntime.Model.InvokeEndpointResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SMREndpoint (InvokeEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerRuntime.Model.InvokeEndpointResponse, InvokeSMREndpointCmdlet>(Select) ??
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
            context.EnableExplanation = this.EnableExplanation;
            context.EndpointName = this.EndpointName;
            #if MODULAR
            if (this.EndpointName == null && ParameterWasBound(nameof(this.EndpointName)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InferenceComponentName = this.InferenceComponentName;
            context.InferenceId = this.InferenceId;
            context.SessionId = this.SessionId;
            context.TargetContainerHostname = this.TargetContainerHostname;
            context.TargetModel = this.TargetModel;
            context.TargetVariant = this.TargetVariant;
            
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
                var request = new Amazon.SageMakerRuntime.Model.InvokeEndpointRequest();
                
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
                if (cmdletContext.EnableExplanation != null)
                {
                    request.EnableExplanations = cmdletContext.EnableExplanation;
                }
                if (cmdletContext.EndpointName != null)
                {
                    request.EndpointName = cmdletContext.EndpointName;
                }
                if (cmdletContext.InferenceComponentName != null)
                {
                    request.InferenceComponentName = cmdletContext.InferenceComponentName;
                }
                if (cmdletContext.InferenceId != null)
                {
                    request.InferenceId = cmdletContext.InferenceId;
                }
                if (cmdletContext.SessionId != null)
                {
                    request.SessionId = cmdletContext.SessionId;
                }
                if (cmdletContext.TargetContainerHostname != null)
                {
                    request.TargetContainerHostname = cmdletContext.TargetContainerHostname;
                }
                if (cmdletContext.TargetModel != null)
                {
                    request.TargetModel = cmdletContext.TargetModel;
                }
                if (cmdletContext.TargetVariant != null)
                {
                    request.TargetVariant = cmdletContext.TargetVariant;
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
        
        private Amazon.SageMakerRuntime.Model.InvokeEndpointResponse CallAWSServiceOperation(IAmazonSageMakerRuntime client, Amazon.SageMakerRuntime.Model.InvokeEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Runtime", "InvokeEndpoint");
            try
            {
                return client.InvokeEndpointAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EnableExplanation { get; set; }
            public System.String EndpointName { get; set; }
            public System.String InferenceComponentName { get; set; }
            public System.String InferenceId { get; set; }
            public System.String SessionId { get; set; }
            public System.String TargetContainerHostname { get; set; }
            public System.String TargetModel { get; set; }
            public System.String TargetVariant { get; set; }
            public System.Func<Amazon.SageMakerRuntime.Model.InvokeEndpointResponse, InvokeSMREndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
