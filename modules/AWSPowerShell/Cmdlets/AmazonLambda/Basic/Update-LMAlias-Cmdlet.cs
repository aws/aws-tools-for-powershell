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
    /// Using this API you can update function version to which the alias points to and alias
    /// description. For more information, see <a href="http://docs.aws.amazon.com/lambda/latest/dg/versioning-v2-intro-aliases.html">Introduction
    /// to AWS Lambda Aliases</a><para>
    /// This requires permission for the lambda:UpdateAlias action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "LMAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Lambda.Model.UpdateAliasResponse")]
    [AWSCmdlet("Invokes the UpdateAlias operation against Amazon Lambda.", Operation = new[] {"UpdateAlias"})]
    [AWSCmdletOutput("Amazon.Lambda.Model.UpdateAliasResponse",
        "This cmdlet returns a UpdateAliasResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateLMAliasCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>You can optionally change the description of the alias using this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The function name for which the alias is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String FunctionName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Using this parameter you can optionally change the Lambda function version to which
        /// the alias to points to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String FunctionVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The alias name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Name { get; set; }
        
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMAlias (UpdateAlias)"))
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
            context.FunctionVersion = this.FunctionVersion;
            context.Name = this.Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateAliasRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.FunctionVersion != null)
            {
                request.FunctionVersion = cmdletContext.FunctionVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateAlias(request);
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
            public String Description { get; set; }
            public String FunctionName { get; set; }
            public String FunctionVersion { get; set; }
            public String Name { get; set; }
        }
        
    }
}
