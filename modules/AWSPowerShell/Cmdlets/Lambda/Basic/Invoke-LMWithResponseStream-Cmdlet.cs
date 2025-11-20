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
    /// Configure your Lambda functions to stream response payloads back to clients. For more
    /// information, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-response-streaming.html">Configuring
    /// a Lambda function to stream responses</a>.
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/list_awslambda.html">lambda:InvokeFunction</a>
    /// action. For details on how to set up permissions for cross-account invocations, see
    /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/access-control-resource-based.html#permissions-resource-xaccountinvoke">Granting
    /// function access to other accounts</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "LMWithResponseStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.InvokeWithResponseStreamResponse")]
    [AWSCmdlet("Calls the AWS Lambda InvokeWithResponseStream API operation.", Operation = new[] {"InvokeWithResponseStream"}, SelectReturnType = typeof(Amazon.Lambda.Model.InvokeWithResponseStreamResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.InvokeWithResponseStreamResponse",
        "This cmdlet returns an Amazon.Lambda.Model.InvokeWithResponseStreamResponse object containing multiple properties."
    )]
    public partial class InvokeLMWithResponseStreamCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientContext
        /// <summary>
        /// <para>
        /// <para>Up to 3,583 bytes of base64-encoded data about the invoking client to pass to the
        /// function in the context object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientContext { get; set; }
        #endregion
        
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
        
        #region Parameter InvocationType
        /// <summary>
        /// <para>
        /// <para>Use one of the following options:</para><ul><li><para><c>RequestResponse</c> (default) – Invoke the function synchronously. Keep the connection
        /// open until the function returns a response or times out. The API operation response
        /// includes the function response and additional data.</para></li><li><para><c>DryRun</c> – Validate parameter values and verify that the IAM user or role has
        /// permission to invoke the function.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.ResponseStreamingInvocationType")]
        public Amazon.Lambda.ResponseStreamingInvocationType InvocationType { get; set; }
        #endregion
        
        #region Parameter LogType
        /// <summary>
        /// <para>
        /// <para>Set to <c>Tail</c> to include the execution log in the response. Applies to synchronously
        /// invoked functions only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.LogType")]
        public Amazon.Lambda.LogType LogType { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>The JSON that you want to provide to your Lambda function as input.</para><para>You can enter the JSON directly. For example, <c>--payload '{ "key": "value" }'</c>.
        /// You can also specify a file path. For example, <c>--payload file://payload.json</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Payload { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>The alias name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the tenant in a multi-tenant Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TenantId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.InvokeWithResponseStreamResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.InvokeWithResponseStreamResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LMWithResponseStream (InvokeWithResponseStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.InvokeWithResponseStreamResponse, InvokeLMWithResponseStreamCmdlet>(Select) ??
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
            context.ClientContext = this.ClientContext;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvocationType = this.InvocationType;
            context.LogType = this.LogType;
            context.Payload = this.Payload;
            context.Qualifier = this.Qualifier;
            context.TenantId = this.TenantId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _PayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Lambda.Model.InvokeWithResponseStreamRequest();
                
                if (cmdletContext.ClientContext != null)
                {
                    request.ClientContext = cmdletContext.ClientContext;
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
                if (cmdletContext.Payload != null)
                {
                    _PayloadStream = new System.IO.MemoryStream(cmdletContext.Payload);
                    request.Payload = _PayloadStream;
                }
                if (cmdletContext.Qualifier != null)
                {
                    request.Qualifier = cmdletContext.Qualifier;
                }
                if (cmdletContext.TenantId != null)
                {
                    request.TenantId = cmdletContext.TenantId;
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
                if( _PayloadStream != null)
                {
                    _PayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.InvokeWithResponseStreamResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.InvokeWithResponseStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "InvokeWithResponseStream");
            try
            {
                #if DESKTOP
                return client.InvokeWithResponseStream(request);
                #elif CORECLR
                return client.InvokeWithResponseStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientContext { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.ResponseStreamingInvocationType InvocationType { get; set; }
            public Amazon.Lambda.LogType LogType { get; set; }
            public byte[] Payload { get; set; }
            public System.String Qualifier { get; set; }
            public System.String TenantId { get; set; }
            public System.Func<Amazon.Lambda.Model.InvokeWithResponseStreamResponse, InvokeLMWithResponseStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
