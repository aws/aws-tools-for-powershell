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
    /// Publishes a version of your function from the current snapshot of HEAD. That is, AWS
    /// Lambda takes a snapshot of the function code and configuration information from HEAD
    /// and publishes a new version. The code and <code>handler</code> of this specific Lambda
    /// function version cannot be modified after publication, but you can modify the configuration
    /// information.
    /// </summary>
    [Cmdlet("Publish", "LMVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.PublishVersionResponse")]
    [AWSCmdlet("Invokes the PublishVersion operation against Amazon Lambda.", Operation = new[] {"PublishVersion"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.PublishVersionResponse",
        "This cmdlet returns a PublishVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class PublishLMVersionCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The SHA256 hash of the deployment package you want to publish. This provides validation
        /// on the code you are publishing. If you provide this parameter value must match the
        /// SHA256 of the HEAD version for the publication to succeed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CodeSha256 { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The description for the version you are publishing. If not provided, AWS Lambda copies
        /// the description from the HEAD version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Lambda function name. You can specify an unqualified function name (for example,
        /// "Thumbnail") or you can specify Amazon Resource Name (ARN) of the function (for example,
        /// "arn:aws:lambda:us-west-2:account-id:function:ThumbNail"). AWS Lambda also allows
        /// you to specify only the account ID qualifier (for example, "account-id:Thumbnail").
        /// Note that the length constraint applies only to the ARN. If you specify only the function
        /// name, it is limited to 64 character in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String FunctionName { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FunctionName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-LMVersion (PublishVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.CodeSha256 = this.CodeSha256;
            context.Description = this.Description;
            context.FunctionName = this.FunctionName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PublishVersionRequest();
            
            if (cmdletContext.CodeSha256 != null)
            {
                request.CodeSha256 = cmdletContext.CodeSha256;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PublishVersion(request);
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
            public String CodeSha256 { get; set; }
            public String Description { get; set; }
            public String FunctionName { get; set; }
        }
        
    }
}
