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
    /// Updates the configuration for a Lambda function URL.
    /// </summary>
    [Cmdlet("Update", "LMFunctionUrlConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse")]
    [AWSCmdlet("Calls the AWS Lambda UpdateFunctionUrlConfig API operation.", Operation = new[] {"UpdateFunctionUrlConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse",
        "This cmdlet returns an Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse object containing multiple properties."
    )]
    public partial class UpdateLMFunctionUrlConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Cors_AllowCredential
        /// <summary>
        /// <para>
        /// <para>Whether to allow cookies or other credentials in requests to your function URL. The
        /// default is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cors_AllowCredentials")]
        public System.Boolean? Cors_AllowCredential { get; set; }
        #endregion
        
        #region Parameter Cors_AllowHeader
        /// <summary>
        /// <para>
        /// <para>The HTTP headers that origins can include in requests to your function URL. For example:
        /// <c>Date</c>, <c>Keep-Alive</c>, <c>X-Custom-Header</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cors_AllowHeaders")]
        public System.String[] Cors_AllowHeader { get; set; }
        #endregion
        
        #region Parameter Cors_AllowMethod
        /// <summary>
        /// <para>
        /// <para>The HTTP methods that are allowed when calling your function URL. For example: <c>GET</c>,
        /// <c>POST</c>, <c>DELETE</c>, or the wildcard character (<c>*</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cors_AllowMethods")]
        public System.String[] Cors_AllowMethod { get; set; }
        #endregion
        
        #region Parameter Cors_AllowOrigin
        /// <summary>
        /// <para>
        /// <para>The origins that can access your function URL. You can list any number of specific
        /// origins, separated by a comma. For example: <c>https://www.example.com</c>, <c>http://localhost:60905</c>.</para><para>Alternatively, you can grant access to all origins using the wildcard character (<c>*</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cors_AllowOrigins")]
        public System.String[] Cors_AllowOrigin { get; set; }
        #endregion
        
        #region Parameter AuthType
        /// <summary>
        /// <para>
        /// <para>The type of authentication that your function URL uses. Set to <c>AWS_IAM</c> if you
        /// want to restrict access to authenticated users only. Set to <c>NONE</c> if you want
        /// to bypass IAM authentication to create a public endpoint. For more information, see
        /// <a href="https://docs.aws.amazon.com/lambda/latest/dg/urls-auth.html">Security and
        /// auth model for Lambda function URLs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.FunctionUrlAuthType")]
        public Amazon.Lambda.FunctionUrlAuthType AuthType { get; set; }
        #endregion
        
        #region Parameter Cors_ExposeHeader
        /// <summary>
        /// <para>
        /// <para>The HTTP headers in your function response that you want to expose to origins that
        /// call your function URL. For example: <c>Date</c>, <c>Keep-Alive</c>, <c>X-Custom-Header</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cors_ExposeHeaders")]
        public System.String[] Cors_ExposeHeader { get; set; }
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
        
        #region Parameter InvokeMode
        /// <summary>
        /// <para>
        /// <para>Use one of the following options:</para><ul><li><para><c>BUFFERED</c> – This is the default option. Lambda invokes your function using
        /// the <c>Invoke</c> API operation. Invocation results are available when the payload
        /// is complete. The maximum payload size is 6 MB.</para></li><li><para><c>RESPONSE_STREAM</c> – Your function streams payload results as they become available.
        /// Lambda invokes your function using the <c>InvokeWithResponseStream</c> API operation.
        /// The maximum response payload size is 200 MB.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Lambda.InvokeMode")]
        public Amazon.Lambda.InvokeMode InvokeMode { get; set; }
        #endregion
        
        #region Parameter Cors_MaxAge
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time, in seconds, that web browsers can cache results of a preflight
        /// request. By default, this is set to <c>0</c>, which means that the browser doesn't
        /// cache results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Cors_MaxAge { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionUrlConfig (UpdateFunctionUrlConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse, UpdateLMFunctionUrlConfigCmdlet>(Select) ??
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
            context.AuthType = this.AuthType;
            context.Cors_AllowCredential = this.Cors_AllowCredential;
            if (this.Cors_AllowHeader != null)
            {
                context.Cors_AllowHeader = new List<System.String>(this.Cors_AllowHeader);
            }
            if (this.Cors_AllowMethod != null)
            {
                context.Cors_AllowMethod = new List<System.String>(this.Cors_AllowMethod);
            }
            if (this.Cors_AllowOrigin != null)
            {
                context.Cors_AllowOrigin = new List<System.String>(this.Cors_AllowOrigin);
            }
            if (this.Cors_ExposeHeader != null)
            {
                context.Cors_ExposeHeader = new List<System.String>(this.Cors_ExposeHeader);
            }
            context.Cors_MaxAge = this.Cors_MaxAge;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InvokeMode = this.InvokeMode;
            context.Qualifier = this.Qualifier;
            
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
            var request = new Amazon.Lambda.Model.UpdateFunctionUrlConfigRequest();
            
            if (cmdletContext.AuthType != null)
            {
                request.AuthType = cmdletContext.AuthType;
            }
            
             // populate Cors
            var requestCorsIsNull = true;
            request.Cors = new Amazon.Lambda.Model.Cors();
            System.Boolean? requestCors_cors_AllowCredential = null;
            if (cmdletContext.Cors_AllowCredential != null)
            {
                requestCors_cors_AllowCredential = cmdletContext.Cors_AllowCredential.Value;
            }
            if (requestCors_cors_AllowCredential != null)
            {
                request.Cors.AllowCredentials = requestCors_cors_AllowCredential.Value;
                requestCorsIsNull = false;
            }
            List<System.String> requestCors_cors_AllowHeader = null;
            if (cmdletContext.Cors_AllowHeader != null)
            {
                requestCors_cors_AllowHeader = cmdletContext.Cors_AllowHeader;
            }
            if (requestCors_cors_AllowHeader != null)
            {
                request.Cors.AllowHeaders = requestCors_cors_AllowHeader;
                requestCorsIsNull = false;
            }
            List<System.String> requestCors_cors_AllowMethod = null;
            if (cmdletContext.Cors_AllowMethod != null)
            {
                requestCors_cors_AllowMethod = cmdletContext.Cors_AllowMethod;
            }
            if (requestCors_cors_AllowMethod != null)
            {
                request.Cors.AllowMethods = requestCors_cors_AllowMethod;
                requestCorsIsNull = false;
            }
            List<System.String> requestCors_cors_AllowOrigin = null;
            if (cmdletContext.Cors_AllowOrigin != null)
            {
                requestCors_cors_AllowOrigin = cmdletContext.Cors_AllowOrigin;
            }
            if (requestCors_cors_AllowOrigin != null)
            {
                request.Cors.AllowOrigins = requestCors_cors_AllowOrigin;
                requestCorsIsNull = false;
            }
            List<System.String> requestCors_cors_ExposeHeader = null;
            if (cmdletContext.Cors_ExposeHeader != null)
            {
                requestCors_cors_ExposeHeader = cmdletContext.Cors_ExposeHeader;
            }
            if (requestCors_cors_ExposeHeader != null)
            {
                request.Cors.ExposeHeaders = requestCors_cors_ExposeHeader;
                requestCorsIsNull = false;
            }
            System.Int32? requestCors_cors_MaxAge = null;
            if (cmdletContext.Cors_MaxAge != null)
            {
                requestCors_cors_MaxAge = cmdletContext.Cors_MaxAge.Value;
            }
            if (requestCors_cors_MaxAge != null)
            {
                request.Cors.MaxAge = requestCors_cors_MaxAge.Value;
                requestCorsIsNull = false;
            }
             // determine if request.Cors should be set to null
            if (requestCorsIsNull)
            {
                request.Cors = null;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.InvokeMode != null)
            {
                request.InvokeMode = cmdletContext.InvokeMode;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.UpdateFunctionUrlConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "UpdateFunctionUrlConfig");
            try
            {
                #if DESKTOP
                return client.UpdateFunctionUrlConfig(request);
                #elif CORECLR
                return client.UpdateFunctionUrlConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Lambda.FunctionUrlAuthType AuthType { get; set; }
            public System.Boolean? Cors_AllowCredential { get; set; }
            public List<System.String> Cors_AllowHeader { get; set; }
            public List<System.String> Cors_AllowMethod { get; set; }
            public List<System.String> Cors_AllowOrigin { get; set; }
            public List<System.String> Cors_ExposeHeader { get; set; }
            public System.Int32? Cors_MaxAge { get; set; }
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.InvokeMode InvokeMode { get; set; }
            public System.String Qualifier { get; set; }
            public System.Func<Amazon.Lambda.Model.UpdateFunctionUrlConfigResponse, UpdateLMFunctionUrlConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
