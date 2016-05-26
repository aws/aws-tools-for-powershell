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
    /// Returns the configuration information of the Lambda function and a presigned URL link
    /// to the .zip file you uploaded with <a>CreateFunction</a> so you can download the .zip
    /// file. Note that the URL is valid for up to 10 minutes. The configuration information
    /// is the same information you provided as parameters when uploading the function.
    /// 
    ///  
    /// <para>
    /// Using the optional <code>Qualifier</code> parameter, you can specify a specific function
    /// version for which you want this information. If you don't specify this parameter,
    /// the API uses unqualified function ARN which return information about the <code>$LATEST</code>
    /// version of the Lambda function. For more information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases.html">AWS
    /// Lambda Function Versioning and Aliases</a>.
    /// </para><para>
    /// This operation requires permission for the <code>lambda:GetFunction</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMFunction")]
    [OutputType("Amazon.Lambda.Model.GetFunctionResponse")]
    [AWSCmdlet("Invokes the GetFunction operation against Amazon Lambda.", Operation = new[] {"GetFunction"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.GetFunctionResponse",
        "This cmdlet returns a Amazon.Lambda.Model.GetFunctionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetLMFunctionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The Lambda function name. </para><para> You can specify a function name (for example, <code>Thumbnail</code>) or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, <code>arn:aws:lambda:us-west-2:account-id:function:ThumbNail</code>).
        /// AWS Lambda also allows you to specify a partial ARN (for example, <code>account-id:Thumbnail</code>).
        /// Note that the length constraint applies only to the ARN. If you specify only the function
        /// name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>Using this optional parameter to specify a function version or an alias name. If you
        /// specify function version, the API uses qualified function ARN for the request and
        /// returns information about the specific Lambda function version. If you specify an
        /// alias name, the API uses the alias ARN and returns information about the function
        /// version to which the alias points. If you don't provide this parameter, the API uses
        /// unqualified function ARN and returns information about the <code>$LATEST</code> version
        /// of the Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Qualifier { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.FunctionName = this.FunctionName;
            context.Qualifier = this.Qualifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Lambda.Model.GetFunctionRequest();
            
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
        
        #region AWS Service Operation Call
        
        private static Amazon.Lambda.Model.GetFunctionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.GetFunctionRequest request)
        {
            return client.GetFunction(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String FunctionName { get; set; }
            public System.String Qualifier { get; set; }
        }
        
    }
}
