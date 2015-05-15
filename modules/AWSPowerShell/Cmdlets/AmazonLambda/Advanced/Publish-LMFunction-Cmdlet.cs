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
    /// Creates a new cloud function or updates an existing function. The function metadata
    /// is created from the request parameters and the code for the function is provided by
    /// a .zip file in the request body. If the function name already exists, the existing
    /// cloud function is updated with the new code and metadata. 
    /// 
    ///  
    /// <para>
    /// This operation requires permission for the <code>lambda:CreateFunction</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "LMFunction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.CreateFunctionResult")]
    [AWSCmdlet("Invokes the CreateFunction operation against Amazon Lambda.", Operation = new [] {"CreateFunction"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.CreateFunctionResult",
        "This cmdlet returns a CreateFunctionResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// Gets and sets the property Description. 
        /// <para>
        /// A short user-defined function description. Lambda does not use this value. Assign
        /// a meaningful description as you see fit.
        /// </para>
        /// </para>
        /// </summary>
        [Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property FunctionName. 
        /// <para>
        /// The name you want to assign to the function you are uploading. The function names
        /// appear in the console, and are returned in the <a>ListFunctions</a> API. Function
        /// names are used to specify cloud functions to other Lambda APIs, such as <a>InvokeAsync</a>.
        /// 
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String FunctionName { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property FunctionZip. 
        /// <para>
        /// A file path to the zip file containing your packaged source code.
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(Position = 1)]
        public string FunctionZip { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property Handler. 
        /// <para>
        /// The function that Lambda calls to begin executing your cloud function. For Node.js,
        /// it is the <i>module-name</i>.<i>export</i> value in your function. 
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(Position = 2)]
        public String Handler { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property MemorySize. 
        /// <para>
        /// The amount of memory, in MB, your cloud function is given. Lambda uses this memory
        /// size to infer the amount of CPU allocated to your function. Your function use-case
        /// determines your CPU and memory requirements. For example, database operation might
        /// need less memory compared to image processing function. The default value is 128 MB.
        /// The value must be a multiple of 64 MB.
        /// </para>
        /// </para>
        /// </summary>
        [Parameter]
        public Int32? MemorySize { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property Role. 
        /// <para>
        /// The Amazon Resource Name (ARN) of the IAM role that Lambda assumes when it executes
        /// your cloud function to access any other Amazon Web Services (AWS) resources. 
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(Position = 4)]
        public String Role { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property Runtime. 
        /// <para>
        /// The runtime environment for the cloud function you are uploading. Currently, Lambda
        /// supports only "nodejs" as the runtime.
        /// </para>
        /// </para>
        /// </summary>
        [Parameter(Position = 3)]
        public Amazon.Lambda.Runtime Runtime { get; set; }
        
        /// <summary>
        /// <para>
        /// Gets and sets the property Timeout. 
        /// <para>
        /// The function execution time at which Lambda should terminate the function. Because
        /// the execution time has cost implications, we recommend you set this value based on
        /// your expected execution time. The default is 3 seconds. 
        /// </para>
        /// </para>
        /// </summary>
        [Parameter]
        public Int32? Timeout { get; set; }

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
