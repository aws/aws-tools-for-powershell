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
using Amazon.CloudFormation;
using Amazon.CloudFormation.Model;

namespace Amazon.PowerShell.Cmdlets.CFN
{
    /// <summary>
    /// Returns information about a new or existing template. The <code>GetTemplateSummary</code>
    /// action is useful for viewing parameter information, such as default parameter values
    /// and parameter types, before you create or update a stack.
    /// 
    ///  
    /// <para>
    /// You can use the <code>GetTemplateSummary</code> action when you submit a template,
    /// or you can get template information for a running or deleted stack.
    /// </para><para>
    /// For deleted stacks, <code>GetTemplateSummary</code> returns the template information
    /// for up to 90 days after the stack has been deleted. If the template does not exist,
    /// a <code>ValidationError</code> is returned.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CFNTemplateSummary")]
    [OutputType("Amazon.CloudFormation.Model.GetTemplateSummaryResult")]
    [AWSCmdlet("Invokes the GetTemplateSummary operation against AWS CloudFormation.", Operation = new[] {"GetTemplateSummary"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.GetTemplateSummaryResult",
        "This cmdlet returns a GetTemplateSummaryResult object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCFNTemplateSummaryCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name or the stack ID that is associated with the stack, which are not always interchangeable.
        /// For running stacks, you can specify either the stack's name or its unique stack ID.
        /// For deleted stack, you must specify the unique stack ID.</para><para>Conditional: You must specify only one of the following parameters: <code>StackName</code>,
        /// <code>TemplateBody</code>, or <code>TemplateURL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String StackName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Structure containing the template body with a minimum length of 1 byte and a maximum
        /// length of 51,200 bytes. For more information about templates, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>StackName</code>,
        /// <code>TemplateBody</code>, or <code>TemplateURL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TemplateBody { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template (max
        /// size: 460,800 bytes) located in an Amazon S3 bucket. For more information about templates,
        /// see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>StackName</code>,
        /// <code>TemplateBody</code>, or <code>TemplateURL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String TemplateURL { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.StackName = this.StackName;
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetTemplateSummaryRequest();
            
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateURL != null)
            {
                request.TemplateURL = cmdletContext.TemplateURL;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetTemplateSummary(request);
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
            public String StackName { get; set; }
            public String TemplateBody { get; set; }
            public String TemplateURL { get; set; }
        }
        
    }
}
