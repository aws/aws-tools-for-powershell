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
    /// Updates the configuration parameters for the specified Lambda function by using the
    /// values provided in the request. You provide only the parameters you want to change.
    /// This operation must only be used on an existing Lambda function and cannot be used
    /// to update the function's code. 
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>lambda:UpdateFunctionConfiguration</code>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMFunctionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse")]
    [AWSCmdlet("Invokes the UpdateFunctionConfiguration operation against Amazon Lambda.", Operation = new[] {"UpdateFunctionConfiguration"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateFunctionConfigurationResponse",
        "This cmdlet returns a Amazon.Lambda.Model.UpdateFunctionConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateLMFunctionConfigurationCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A short user-defined function description. AWS Lambda does not use this value. Assign
        /// a meaningful description as you see fit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name of the Lambda function.</para><para> You can specify an unqualified function name (for example, "Thumbnail") or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, "arn:aws:lambda:us-west-2:account-id:function:ThumbNail").
        /// AWS Lambda also allows you to specify only the account ID qualifier (for example,
        /// "account-id:Thumbnail"). Note that the length constraint applies only to the ARN.
        /// If you specify only the function name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Handler
        /// <summary>
        /// <para>
        /// <para>The function that Lambda calls to begin executing your function. For Node.js, it is
        /// the <i>module-name.export</i> value in your function. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Handler { get; set; }
        #endregion
        
        #region Parameter MemorySize
        /// <summary>
        /// <para>
        /// <para>The amount of memory, in MB, your Lambda function is given. AWS Lambda uses this memory
        /// size to infer the amount of CPU allocated to your function. Your function use-case
        /// determines your CPU and memory requirements. For example, a database operation might
        /// need less memory compared to an image processing function. The default value is 128
        /// MB. The value must be a multiple of 64 MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MemorySize { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Lambda will assume when it executes
        /// your function. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The function execution time at which AWS Lambda should terminate the function. Because
        /// the execution time has cost implications, we recommend you set this value based on
        /// your expected execution time. The default is 3 seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Timeout { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMFunctionConfiguration (UpdateFunctionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.FunctionName = this.FunctionName;
            context.Handler = this.Handler;
            if (ParameterWasBound("MemorySize"))
                context.MemorySize = this.MemorySize;
            context.Role = this.Role;
            if (ParameterWasBound("Timeout"))
                context.Timeout = this.Timeout;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.UpdateFunctionConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.Handler != null)
            {
                request.Handler = cmdletContext.Handler;
            }
            if (cmdletContext.MemorySize != null)
            {
                request.MemorySize = cmdletContext.MemorySize.Value;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateFunctionConfiguration(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Description { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Handler { get; set; }
            public System.Int32? MemorySize { get; set; }
            public System.String Role { get; set; }
            public System.Int32? Timeout { get; set; }
        }
        
    }
}
