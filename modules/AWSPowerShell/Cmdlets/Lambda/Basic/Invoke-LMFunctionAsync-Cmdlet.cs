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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// <important><para>
    /// For asynchronous function invocation, use <a>Invoke</a>.
    /// </para></important><para>
    /// Invokes a function asynchronously.
    /// </para><note><para>
    /// If you do use the InvokeAsync action, note that it doesn't support the use of X-Ray
    /// active tracing. Trace ID is not propagated to the function, even if X-Ray active tracing
    /// is turned on.
    /// </para></note><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Invoke", "LMFunctionAsync", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Low)]
    [OutputType("System.Int32")]
    [AWSCmdlet("Calls the AWS Lambda InvokeAsync API operation.", Operation = new[] {"InvokeAsync"}, SelectReturnType = typeof(Amazon.Lambda.Model.InvokeAsyncResponse))]
    [AWSCmdletOutput("System.Int32 or Amazon.Lambda.Model.InvokeAsyncResponse",
        "This cmdlet returns a System.Int32 object.",
        "The service call response (type Amazon.Lambda.Model.InvokeAsyncResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This Cmdlet is deprecated. We recommend to use the Invoke-LMFunction Cmdlet instead.")]
    public partial class InvokeLMFunctionAsyncCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>my-function</c>.</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:my-function</c>.</para></li></ul><para>The length constraint applies only to the full ARN. If you specify only the function
        /// name, it is limited to 64 characters in length.</para>
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
        
        #region Parameter InvokeArg
        /// <summary>
        /// <para>
        /// When this property is set the InvokeArgsStream
        /// property is also set with a MemoryStream containing the contents InvokeArgs
        /// <para>JSON that you want to provide to your cloud function as input.</para>
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>{}</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("InvokeArgs")]
        public System.String InvokeArg { get; set; }
        #endregion
        
        #region Parameter InvokeArgsStream
        /// <summary>
        /// <para>
        /// <para>The JSON that you want to provide to your Lambda function as input.</para>
        /// </para>
        /// <para>The cmdlet accepts a parameter of type string, string[], System.IO.FileInfo or System.IO.Stream.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public object InvokeArgsStream { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.InvokeAsyncResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.InvokeAsyncResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LMFunctionAsync (InvokeAsync)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.InvokeAsyncResponse, InvokeLMFunctionAsyncCmdlet>(Select) ??
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
            context.InvokeArg = this.InvokeArg;
            if (!ParameterWasBound(nameof(this.InvokeArg)))
            {
                WriteVerbose("InvokeArg parameter unset, using default value of '{}'");
                context.InvokeArg = "{}";
            }
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvokeArgsStream = this.InvokeArgsStream;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.Stream _InvokeArgsStreamStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.InvokeAsyncRequest();
                
                if (cmdletContext.InvokeArg != null)
                {
                    request.InvokeArgs = cmdletContext.InvokeArg;
                }
                if (cmdletContext.FunctionName != null)
                {
                    request.FunctionName = cmdletContext.FunctionName;
                }
                if (cmdletContext.InvokeArgsStream != null)
                {
                    _InvokeArgsStreamStream = Amazon.PowerShell.Common.StreamParameterConverter.TransformToStream(cmdletContext.InvokeArgsStream);
                    request.InvokeArgsStream = _InvokeArgsStreamStream;
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
                if( _InvokeArgsStreamStream != null)
                {
                    _InvokeArgsStreamStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.InvokeAsyncResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.InvokeAsyncRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "InvokeAsync");
            try
            {
                #if DESKTOP
                return client.InvokeAsync(request);
                #elif CORECLR
                return client.InvokeAsyncAsync(request).GetAwaiter().GetResult();
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
            public System.String InvokeArg { get; set; }
            public System.String FunctionName { get; set; }
            public object InvokeArgsStream { get; set; }
            public System.Func<Amazon.Lambda.Model.InvokeAsyncResponse, InvokeLMFunctionAsyncCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
