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
    /// Validates a specified template. AWS CloudFormation first checks if the template is
    /// valid JSON. If it isn't, AWS CloudFormation checks if the template is valid YAML.
    /// If both these checks fail, AWS CloudFormation returns a template validation error.
    /// </summary>
    [Cmdlet("Test", "CFNTemplate")]
    [OutputType("Amazon.CloudFormation.Model.ValidateTemplateResponse")]
    [AWSCmdlet("Invokes the ValidateTemplate operation against AWS CloudFormation.", Operation = new[] {"ValidateTemplate"})]
    [AWSCmdletOutput("Amazon.CloudFormation.Model.ValidateTemplateResponse",
        "This cmdlet returns a Amazon.CloudFormation.Model.ValidateTemplateResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCFNTemplateCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the template body with a minimum length of 1 byte and a maximum
        /// length of 51,200 bytes. For more information, go to <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must pass <code>TemplateURL</code> or <code>TemplateBody</code>.
        /// If both are passed, only <code>TemplateBody</code> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template (max
        /// size: 460,800 bytes) that is located in an Amazon S3 bucket. For more information,
        /// go to <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must pass <code>TemplateURL</code> or <code>TemplateBody</code>.
        /// If both are passed, only <code>TemplateBody</code> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateURL { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            
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
            var request = new Amazon.CloudFormation.Model.ValidateTemplateRequest();
            
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
        
        private Amazon.CloudFormation.Model.ValidateTemplateResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.ValidateTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "ValidateTemplate");
            try
            {
                #if DESKTOP
                return client.ValidateTemplate(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ValidateTemplateAsync(request);
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
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
        }
        
    }
}
