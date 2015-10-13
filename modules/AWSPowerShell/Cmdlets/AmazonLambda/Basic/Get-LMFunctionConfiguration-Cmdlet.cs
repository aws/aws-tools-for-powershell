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
    /// Returns the configuration information of the Lambda function. This the same information
    /// you provided as parameters when uploading the function by using <a>CreateFunction</a>.
    /// 
    ///  
    /// <para>
    /// You can use the optional <code>Qualifier</code> parameter to retrieve configuration
    /// information for a specific Lambda function version. If you don't provide it, the API
    /// returns information about the $LATEST version of the function. For more information
    /// about versioning, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-aliases-v2.html">AWS
    /// Lambda Function Versioning and Aliases</a>.
    /// </para><para>
    /// This operation requires permission for the <code>lambda:GetFunctionConfiguration</code>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LMFunctionConfiguration")]
    [OutputType("Amazon.Lambda.Model.GetFunctionConfigurationResponse")]
    [AWSCmdlet("Invokes the GetFunctionConfiguration operation against Amazon Lambda.", Operation = new[] {"GetFunctionConfiguration"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.GetFunctionConfigurationResponse",
        "This cmdlet returns a Amazon.Lambda.Model.GetFunctionConfigurationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetLMFunctionConfigurationCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the Lambda function for which you want to retrieve the configuration information.</para><para> You can specify an unqualified function name (for example, "Thumbnail") or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, "arn:aws:lambda:us-west-2:account-id:function:ThumbNail").
        /// AWS Lambda also allows you to specify only the account ID qualifier (for example,
        /// "account-id:Thumbnail"). Note that the length constraint applies only to the ARN.
        /// If you specify only the function name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String FunctionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Using this optional parameter you can specify function version or alias name. If you
        /// specify function version, the API uses qualified function ARN and returns information
        /// about the specific function version. if you specify alias name, the API uses alias
        /// ARN and returns information about the function version to which the alias points.</para><para>If you don't specify this parameter, the API uses unqualified function ARN, and returns
        /// information about the $LATEST function version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Qualifier { get; set; }
        
        
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
            var request = new Amazon.Lambda.Model.GetFunctionConfigurationRequest();
            
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
                var response = client.GetFunctionConfiguration(request);
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
            public System.String FunctionName { get; set; }
            public System.String Qualifier { get; set; }
        }
        
    }
}
