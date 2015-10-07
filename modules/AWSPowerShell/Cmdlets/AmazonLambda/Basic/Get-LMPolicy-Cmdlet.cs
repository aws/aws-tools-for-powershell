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
    /// Returns the resource policy, containing a list of permissions that apply to a specific
    /// to an ARN that you specify via the <code>Qualifier</code> paramter. 
    /// 
    ///  
    /// <para>
    /// For informration about adding permissions, see <a>AddPermission</a>.
    /// </para><para>
    /// You need permission for the <code>lambda:GetPolicy action.</code></para>
    /// </summary>
    [Cmdlet("Get", "LMPolicy")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the GetPolicy operation against Amazon Lambda.", Operation = new[] {"GetPolicy"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type GetPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetLMPolicyCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Function name whose resource policy you want to retrieve. </para><para> You can specify an unqualified function name (for example, "Thumbnail") or you can
        /// specify Amazon Resource Name (ARN) of the function (for example, "arn:aws:lambda:us-west-2:account-id:function:ThumbNail").
        /// AWS Lambda also allows you to specify only the account ID qualifier (for example,
        /// "account-id:Thumbnail"). Note that the length constraint applies only to the ARN.
        /// If you specify only the function name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String FunctionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>You can specify this optional query parameter to specify function version or alias
        /// name in which case this API will return all permissions associated with the specific
        /// ARN. If you don't provide this parameter, the API will return permissions that apply
        /// to the unqualified function ARN. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Qualifier { get; set; }
        
        
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
            var request = new GetPolicyRequest();
            
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
                var response = client.GetPolicy(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Policy;
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
            public String FunctionName { get; set; }
            public String Qualifier { get; set; }
        }
        
    }
}
