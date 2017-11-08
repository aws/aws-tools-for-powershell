/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes the specified Lambda function code and configuration.
    /// 
    ///  
    /// <para>
    /// If you are using the versioning feature and you don't specify a function version in
    /// your <code>DeleteFunction</code> request, AWS Lambda will delete the function, including
    /// all its versions, and any aliases pointing to the function versions. To delete a specific
    /// function version, you must provide the function version via the <code>Qualifier</code>
    /// parameter. For information about function versioning, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>. 
    /// </para><para>
    /// When you delete a function the associated resource policy is also deleted. You will
    /// need to delete the event source mappings explicitly.
    /// </para><para>
    /// This operation requires permission for the <code>lambda:DeleteFunction</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Lambda DeleteFunction API operation.", Operation = new[] {"DeleteFunction"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the FunctionName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Lambda.Model.DeleteFunctionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The Lambda function to delete.</para><para> You can specify the function name (for example, <code>Thumbnail</code>) or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, <code>arn:aws:lambda:us-west-2:account-id:function:ThumbNail</code>).
        /// If you are using versioning, you can also provide a qualified function ARN (ARN that
        /// is qualified with function version or alias name as suffix). AWS Lambda also allows
        /// you to specify only the function name with the account ID qualifier (for example,
        /// <code>account-id:Thumbnail</code>). Note that the length constraint applies only to
        /// the ARN. If you specify only the function name, it is limited to 64 characters in
        /// length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Using this optional parameter you can specify a function version (but not the <code>$LATEST</code>
        /// version) to direct AWS Lambda to delete a specific function version. If the function
        /// version has one or more aliases pointing to it, you will get an error because you
        /// cannot have aliases pointing to it. You can delete any function version but not the
        /// <code>$LATEST</code>, that is, you cannot specify <code>$LATEST</code> as the value
        /// of this parameter. The <code>$LATEST</code> version can be deleted only when you want
        /// to delete all the function versions and aliases.</para><para>You can only specify a function version, not an alias name, using this parameter.
        /// You cannot delete a function version using its alias.</para><para>If you don't specify this parameter, AWS Lambda will delete the function, including
        /// all of its versions and aliases.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the FunctionName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LMFunction (DeleteFunction)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.FunctionName = this.FunctionName;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.FunctionName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lambda", "DeleteFunction");
            try
            {
                #if DESKTOP
                return client.DeleteFunction(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteFunctionAsync(request);
                return task.Result;
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
        }
        
    }
}
