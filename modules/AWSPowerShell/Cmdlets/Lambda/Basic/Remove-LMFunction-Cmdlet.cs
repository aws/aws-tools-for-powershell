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
    /// Deletes a Lambda function. To delete a specific function version, use the <c>Qualifier</c>
    /// parameter. Otherwise, all versions and aliases are deleted. This doesn't require the
    /// user to have explicit permissions for <a>DeleteAlias</a>.
    /// 
    ///  <note><para>
    /// A deleted Lambda function cannot be recovered. Ensure that you specify the correct
    /// function name and version before deleting.
    /// </para></note><para>
    /// To delete Lambda event source mappings that invoke a function, use <a>DeleteEventSourceMapping</a>.
    /// For Amazon Web Services services and resources that invoke your function directly,
    /// delete the trigger in the service where you originally configured it.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lambda DeleteFunction API operation.", Operation = new[] {"DeleteFunction"}, SelectReturnType = typeof(Amazon.Lambda.Model.DeleteFunctionResponse))]
    [AWSCmdletOutput("None or Amazon.Lambda.Model.DeleteFunctionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Lambda.Model.DeleteFunctionResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function or version.</para><para><b>Name formats</b></para><ul><li><para><b>Function name</b> – <c>my-function</c> (name-only), <c>my-function:1</c> (with
        /// version).</para></li><li><para><b>Function ARN</b> – <c>arn:aws:lambda:us-west-2:123456789012:function:my-function</c>.</para></li><li><para><b>Partial ARN</b> – <c>123456789012:function:my-function</c>.</para></li></ul><para>You can append a version number or alias to any of the formats. The length constraint
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
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Specify a version to delete. You can't delete a version that an alias references.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.DeleteFunctionResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LMFunction (DeleteFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.DeleteFunctionResponse, RemoveLMFunctionCmdlet>(Select) ??
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
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Lambda.Model.DeleteFunctionRequest();
            
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
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
        
        private Amazon.Lambda.Model.DeleteFunctionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.DeleteFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "DeleteFunction");
            try
            {
                #if DESKTOP
                return client.DeleteFunction(request);
                #elif CORECLR
                return client.DeleteFunctionAsync(request).GetAwaiter().GetResult();
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
            public System.String Qualifier { get; set; }
            public System.Func<Amazon.Lambda.Model.DeleteFunctionResponse, RemoveLMFunctionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
