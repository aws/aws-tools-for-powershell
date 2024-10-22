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
    /// Sets your function's <a href="https://docs.aws.amazon.com/lambda/latest/dg/invocation-recursion.html">recursive
    /// loop detection</a> configuration.
    /// 
    ///  
    /// <para>
    /// When you configure a Lambda function to output to the same service or resource that
    /// invokes the function, it's possible to create an infinite recursive loop. For example,
    /// a Lambda function might write a message to an Amazon Simple Queue Service (Amazon
    /// SQS) queue, which then invokes the same function. This invocation causes the function
    /// to write another message to the queue, which in turn invokes the function again.
    /// </para><para>
    /// Lambda can detect certain types of recursive loops shortly after they occur. When
    /// Lambda detects a recursive loop and your function's recursive loop detection configuration
    /// is set to <c>Terminate</c>, it stops your function being invoked and notifies you.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "LMFunctionRecursionConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.RecursiveLoop")]
    [AWSCmdlet("Calls the AWS Lambda PutFunctionRecursionConfig API operation.", Operation = new[] {"PutFunctionRecursionConfig"}, SelectReturnType = typeof(Amazon.Lambda.Model.PutFunctionRecursionConfigResponse))]
    [AWSCmdletOutput("Amazon.Lambda.RecursiveLoop or Amazon.Lambda.Model.PutFunctionRecursionConfigResponse",
        "This cmdlet returns an Amazon.Lambda.RecursiveLoop object.",
        "The service call response (type Amazon.Lambda.Model.PutFunctionRecursionConfigResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteLMFunctionRecursionConfigCmdlet : AmazonLambdaClientCmdlet, IExecutor
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
        
        #region Parameter RecursiveLoop
        /// <summary>
        /// <para>
        /// <para>If you set your function's recursive loop detection configuration to <c>Allow</c>,
        /// Lambda doesn't take any action when it detects your function being invoked as part
        /// of a recursive loop. We recommend that you only use this setting if your design intentionally
        /// uses a Lambda function to write data back to the same Amazon Web Services resource
        /// that invokes it.</para><para>If you set your function's recursive loop detection configuration to <c>Terminate</c>,
        /// Lambda stops your function being invoked and notifies you when it detects your function
        /// being invoked as part of a recursive loop.</para><para>By default, Lambda sets your function's configuration to <c>Terminate</c>.</para><important><para>If your design intentionally uses a Lambda function to write data back to the same
        /// Amazon Web Services resource that invokes the function, then use caution and implement
        /// suitable guard rails to prevent unexpected charges being billed to your Amazon Web
        /// Services account. To learn more about best practices for using recursive invocation
        /// patterns, see <a href="https://serverlessland.com/content/service/lambda/guides/aws-lambda-operator-guide/recursive-runaway">Recursive
        /// patterns that cause run-away Lambda functions</a> in Serverless Land.</para></important>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Lambda.RecursiveLoop")]
        public Amazon.Lambda.RecursiveLoop RecursiveLoop { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RecursiveLoop'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.PutFunctionRecursionConfigResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.PutFunctionRecursionConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RecursiveLoop";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-LMFunctionRecursionConfig (PutFunctionRecursionConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.PutFunctionRecursionConfigResponse, WriteLMFunctionRecursionConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecursiveLoop = this.RecursiveLoop;
            #if MODULAR
            if (this.RecursiveLoop == null && ParameterWasBound(nameof(this.RecursiveLoop)))
            {
                WriteWarning("You are passing $null as a value for parameter RecursiveLoop which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.PutFunctionRecursionConfigRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.RecursiveLoop != null)
            {
                request.RecursiveLoop = cmdletContext.RecursiveLoop;
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
        
        private Amazon.Lambda.Model.PutFunctionRecursionConfigResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.PutFunctionRecursionConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "PutFunctionRecursionConfig");
            try
            {
                #if DESKTOP
                return client.PutFunctionRecursionConfig(request);
                #elif CORECLR
                return client.PutFunctionRecursionConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String FunctionName { get; set; }
            public Amazon.Lambda.RecursiveLoop RecursiveLoop { get; set; }
            public System.Func<Amazon.Lambda.Model.PutFunctionRecursionConfigResponse, WriteLMFunctionRecursionConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RecursiveLoop;
        }
        
    }
}
