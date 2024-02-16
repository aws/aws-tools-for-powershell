/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Invokes a Lambda function. You can invoke a function synchronously (and wait for the
    /// response), or asynchronously. By default, Lambda invokes your function synchronously
    /// (i.e. the<c>InvocationType</c> is <c>RequestResponse</c>). To invoke a function asynchronously,
    /// set <c>InvocationType</c> to <c>Event</c>. Lambda passes the <c>ClientContext</c>
    /// object to your function for synchronous invocations only.
    /// 
    ///  
    /// <para>
    /// For <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-sync.html">synchronous
    /// invocation</a>, details about the function response, including errors, are included
    /// in the response body and headers. For either invocation type, you can find more information
    /// in the <a href="https://docs.aws.amazon.com/lambda/latest/dg/monitoring-functions.html">execution
    /// log</a> and <a href="https://docs.aws.amazon.com/lambda/latest/dg/lambda-x-ray.html">trace</a>.
    /// </para><para>
    /// When an error occurs, your function may be invoked multiple times. Retry behavior
    /// varies by error type, client, event source, and invocation type. For example, if you
    /// invoke a function asynchronously and it returns an error, Lambda executes the function
    /// up to two more times. For more information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-retries.html">Error
    /// handling and automatic retries in Lambda</a>.
    /// </para><para>
    /// For <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html">asynchronous
    /// invocation</a>, Lambda adds events to a queue before sending them to your function.
    /// If your function does not have enough capacity to keep up with the queue, events may
    /// be lost. Occasionally, your function may receive the same event multiple times, even
    /// if no error occurs. To retain events that were not processed, configure your function
    /// with a <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-async.html#invocation-dlq">dead-letter
    /// queue</a>.
    /// </para><para>
    /// The status code in the API response doesn't reflect function errors. Error codes are
    /// reserved for errors that prevent your function from executing, such as permissions
    /// errors, <a href="https://docs.aws.amazon.com/lambda/latest/dg/gettingstarted-limits.html">quota</a>
    /// errors, or issues with your function's code and configuration. For example, Lambda
    /// returns <c>TooManyRequestsException</c> if running the function would cause you to
    /// exceed a concurrency limit at either the account level (<c>ConcurrentInvocationLimitExceeded</c>)
    /// or function level (<c>ReservedFunctionConcurrentInvocationLimitExceeded</c>).
    /// </para><para>
    /// For functions with a long timeout, your client might disconnect during synchronous
    /// invocation while it waits for a response. Configure your HTTP client, SDK, firewall,
    /// proxy, or operating system to allow for long connections with timeout or keep-alive
    /// settings.
    /// </para><para>
    /// This operation requires permission for the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/list_awslambda.html">lambda:InvokeFunction</a>
    /// action. For details on how to set up permissions for cross-account invocations, see
    /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/access-control-resource-based.html#permissions-resource-xaccountinvoke">Granting
    /// function access to other accounts</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType("Amazon.Lambda.Model.InvokeResponse")]
    [AWSCmdlet("Calls the AWS Lambda Invoke API operation.", Operation = new[] {"Invoke"}, SelectReturnType = typeof(Amazon.Lambda.Model.InvokeResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.InvokeResponse",
        "This cmdlet returns an Amazon.Lambda.Model.InvokeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientContext
        /// <summary>
        /// <para>
        /// When this property is set the ClientContextBase64
        /// property is also set with a base64-encoded string containing the contents of ClientContext.
        /// <para>Using the <code>ClientContext</code> you can pass client-specific information to the
        /// Lambda function you are invoking. You can then process the client information in your
        /// Lambda function as you choose through the context variable. For an example of a ClientContext
        /// JSON, go to <a href="http://docs.aws.amazon.com/mobileanalytics/latest/ug/PutEvents.html">PutEvents</a>
        /// in the <i>Amazon Mobile Analytics API Reference and User Guide</i>.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>{}</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String ClientContext { get; set; }
        #endregion
        
        #region Parameter ClientContextBase64
        /// <summary>
        /// <para>
        /// <para>Up to 3,583 bytes of base64-encoded data about the invoking client to pass to the
        /// function in the context object. Lambda passes the <c>ClientContext</c> object to your
        /// function for synchronous invocations only.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter to Base64 before supplying to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.Base64StringParameterConverter]
        public System.String ClientContextBase64 { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the Lambda function, version, or alias.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>my-function</c> (name-only), <c>my-function:v1</c> (with
        /// alias).</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:my-function</c>.</para></li></ul><para>You can append a version number or alias to any of the formats. The length constraint
        /// applies only to the full ARN. If you specify only the function name, it is limited
        /// to 64 characters in length.</para>
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter InvocationType
        /// <summary>
        /// <para>
        /// <para>Choose from the following options.</para><ul><li><para><c>RequestResponse</c> (default) – Invoke the function synchronously. Keep the connection
        /// open until the function returns a response or times out. The API response includes
        /// the function response and additional data.</para></li><li><para><c>Event</c> – Invoke the function asynchronously. Send events that fail multiple
        /// times to the function's dead-letter queue (if one is configured). The API response
        /// only includes a status code.</para></li><li><para><c>DryRun</c> – Validate parameter values and verify that the user or role has permission
        /// to invoke the function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.InvocationType")]
        public Amazon.Lambda.InvocationType InvocationType { get; set; }
        #endregion
        
        #region Parameter LogType
        /// <summary>
        /// <para>
        /// <para>Set to <c>Tail</c> to include the execution log in the response. Applies to synchronously
        /// invoked functions only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.LogType")]
        public Amazon.Lambda.LogType LogType { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// When this property is set the PayloadStream
        /// property is also set with a MemoryStream containing the contents of Payload.
        /// <para>JSON that you want to provide to your cloud function as input.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>{}</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Payload { get; set; }
        #endregion
        
        #region Parameter PayloadStream
        /// <summary>
        /// <para>
        /// <para>The JSON that you want to provide to your Lambda function as input.</para><para>You can enter the JSON directly. For example, <c>--payload '{ "key": "value" }'</c>.
        /// You can also specify a file path. For example, <c>--payload file://payload.json</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] PayloadStream { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Specify a version or alias to invoke a published version of the function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.InvokeResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.InvokeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FunctionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FunctionName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FunctionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LMFunction (Invoke)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.InvokeResponse, InvokeLMFunctionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FunctionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Payload = this.Payload;
            if (!ParameterWasBound(nameof(this.Payload)))
            {
                WriteVerbose("Payload parameter unset, using default value of '{}'");
                context.Payload = "{}";
            }
            context.ClientContext = this.ClientContext;
            if (!ParameterWasBound(nameof(this.ClientContext)))
            {
                WriteVerbose("ClientContext parameter unset, using default value of '{}'");
                context.ClientContext = "{}";
            }
            context.ClientContextBase64 = this.ClientContextBase64;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationType = this.InvocationType;
            context.LogType = this.LogType;
            context.PayloadStream = this.PayloadStream;
            context.Qualifier = this.Qualifier;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _PayloadStreamStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.InvokeRequest();
                
                if (cmdletContext.Payload != null)
                {
                    request.Payload = cmdletContext.Payload;
                }
                if (cmdletContext.ClientContext != null)
                {
                    request.ClientContext = cmdletContext.ClientContext;
                }
                if (cmdletContext.ClientContextBase64 != null)
                {
                    request.ClientContextBase64 = cmdletContext.ClientContextBase64;
                }
                if (cmdletContext.FunctionName != null)
                {
                    request.FunctionName = cmdletContext.FunctionName;
                }
                if (cmdletContext.InvocationType != null)
                {
                    request.InvocationType = cmdletContext.InvocationType;
                }
                if (cmdletContext.LogType != null)
                {
                    request.LogType = cmdletContext.LogType;
                }
                if (cmdletContext.PayloadStream != null)
                {
                    _PayloadStreamStream = new System.IO.MemoryStream(cmdletContext.PayloadStream);
                    request.PayloadStream = _PayloadStreamStream;
                }
                if (cmdletContext.Qualifier != null)
                {
                    request.Qualifier = cmdletContext.Qualifier;
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
                if( _PayloadStreamStream != null)
                {
                    _PayloadStreamStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.InvokeResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.InvokeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "Invoke");
            try
            {
                #if DESKTOP
                return client.Invoke(request);
                #elif CORECLR
                return client.InvokeAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String Payload { get; set; }
            public System.String ClientContext { get; set; }
            public System.String ClientContextBase64 { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.InvocationType InvocationType { get; set; }
            public Amazon.Lambda.LogType LogType { get; set; }
            public byte[] PayloadStream { get; set; }
            public System.String Qualifier { get; set; }
            public System.Func<Amazon.Lambda.Model.InvokeResponse, InvokeLMFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
