/*******************************************************************************
 *  Copyright 2012-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.IO;
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
    /// Creates a new Lambda function. If the function name already exists, the operation will fail. 
	/// Note that the function name is case-sensitive. 
    /// <para>
    /// This operation requires permission for the <code>lambda:CreateFunction</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateFunctionResult")]
    [AWSCmdlet("Invokes the CreateFunction operation against Amazon Lambda.", Operation = new [] {"CreateFunction"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateFunctionResult",
        "This cmdlet returns an Amazon.Lambda.Model.CreateFunctionResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// A short user-defined function description. Lambda does not use this value. Assign
        /// a meaningful description as you see fit.
        /// </summary>
        [Parameter]
        public System.String Description { get; set; }
        
        /// <summary>
        /// The name you want to assign to the function you are uploading. You can specify an
        /// unqualified function name (for example, "Thumbnail") or you can specify Amazon Resource
        /// Name (ARN) of the function (for example, "arn:aws:lambda:us-west-2:account-id:function:ThumbNail").
        /// AWS Lambda also allows you to specify only the account ID qualifier (for example,
        /// "account-id:Thumbnail"). Note that the length constraint applies only to the ARN.
        /// If you specify only the function name, it is limited to 64 character in length. The
        /// function names appear in the console and are returned in the <a>ListFunctions</a>
        /// API. Function names are used to specify functions to other AWS Lambda APIs, such as
        /// <a>Invoke</a>. 
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        
        /// <summary>
        /// A file path to the zip file containing your packaged source code.
        /// </summary>
        [Parameter(Position = 1)]
        public System.String FunctionZip { get; set; }
        
        /// <summary>
        /// The function within your code that Lambda calls to begin execution. For Node.js, it
        /// is the <i>module-name</i>.<i>export</i> value in your function. For Java, it can be
        /// <code>package.class-name::handler</code> or <code>package.class-name</code>. For more
        /// information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/java-programming-model-handler-types.html">Lambda
        /// Function Handler (Java)</a>. 
        /// </summary>
        [Parameter(Position = 2)]
        public System.String Handler { get; set; }
        
        /// <summary>
        /// The amount of memory, in MB, your Lambda function is given. Lambda uses this memory
        /// size to infer the amount of CPU and memory allocated to your function. Your function
        /// use-case determines your CPU and memory requirements. For example, a database operation
        /// might need less memory compared to an image processing function. The default value
        /// is 128 MB. The value must be a multiple of 64 MB.
        /// </summary>
        [Parameter]
        public System.Int32? MemorySize { get; set; }
        
        /// <summary>
        /// The Amazon Resource Name (ARN) of the IAM role that Lambda assumes when it executes
        /// your function to access any other Amazon Web Services (AWS) resources. For more information,
        /// see <a href="http://docs.aws.amazon.com/lambda/latest/dg/lambda-introduction.html">AWS
        /// Lambda: How it Works</a> 
        /// </summary>
        [Parameter(Position = 4)]
        public System.String Role { get; set; }
        
        /// <summary>
        /// The runtime environment for the Lambda function you are uploading. Currently, Lambda
        /// supports "java" and "nodejs" as the runtime.
        /// </summary>
        [Parameter(Position = 3)]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        
        /// <summary>
        /// The function execution time at which Lambda should terminate the function. Because
        /// the execution time has cost implications, we recommend you set this value based on
        /// your expected execution time. The default is 3 seconds. 
        /// </summary>
        [Parameter]
        public System.Int32? Timeout { get; set; }

        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [Parameter]
        public SwitchParameter Force { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if (!ConfirmShouldProceed(this.Force.IsPresent, this.FunctionName, "Publish-LMFunction (CreateFunction)"))
                return;

            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials, 
                Description = this.Description, 
                FunctionName = this.FunctionName, 
                FunctionZip = this.FunctionZip, 
                Handler = this.Handler, 
                MemorySize = this.MemorySize, 
                Role = this.Role, 
                Runtime = this.Runtime, 
                Timeout = this.Timeout
            };

            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateFunctionRequest();
            
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
            if (cmdletContext.Runtime != null)
            {
                request.Runtime = cmdletContext.Runtime;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }

            if (string.IsNullOrEmpty(cmdletContext.FunctionZip))
            {
                this.ThrowArgumentError("FunctionZip is a required parameter which should be a valid filepath to zip file containing the source code", this);
            }
            if (!File.Exists(cmdletContext.FunctionZip))
            {
                this.ThrowArgumentError(string.Format("\"{0}\" is not a valid file path for the FunctionZip parameter.", this.FunctionZip), this);
            }

            CmdletOutput output;

            using (var stream = new FileStream(cmdletContext.FunctionZip, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var ms = new MemoryStream();
                Amazon.PowerShell.Utils.Common.CopyStream(stream, ms);
                ms.Position = 0;

                request.Code = new FunctionCode
                {
                    ZipFile = ms
                };

                // issue call
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                try
                {
                    var response = client.CreateFunction(request);
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
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public String Description { get; set; }
            public String FunctionName { get; set; }
            public String FunctionZip { get; set; }
            public String Handler { get; set; }
            public Int32? MemorySize { get; set; }
            public String Role { get; set; }
            public Amazon.Lambda.Runtime Runtime { get; set; }
            public Int32? Timeout { get; set; }
        }
        
    }
}
