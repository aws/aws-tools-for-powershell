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
    /// Creates a stack set.
    /// </summary>
    [Cmdlet("New", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateStackSet operation against AWS CloudFormation.", Operation = new[] {"CreateStackSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.CreateStackSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>A list of values that you must specify before AWS CloudFormation can create certain
        /// stack sets. Some stack set templates might include resources that can affect permissions
        /// in your AWS account—for example, by creating new AWS Identity and Access Management
        /// (IAM) users. For those stack sets, you must explicitly acknowledge their capabilities
        /// by specifying this parameter.</para><para>The only valid values are CAPABILITY_IAM and CAPABILITY_NAMED_IAM. The following resources
        /// require you to specify this parameter: </para><ul><li><para>AWS::IAM::AccessKey</para></li><li><para>AWS::IAM::Group</para></li><li><para>AWS::IAM::InstanceProfile</para></li><li><para>AWS::IAM::Policy</para></li><li><para>AWS::IAM::Role</para></li><li><para>AWS::IAM::User</para></li><li><para>AWS::IAM::UserToGroupAddition</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions that are associated with them and edit their permissions if necessary.</para><para>If you have IAM resources, you can specify either capability. If you have IAM resources
        /// with custom names, you must specify CAPABILITY_NAMED_IAM. If you don't specify this
        /// parameter, this action returns an <code>InsufficientCapabilities</code> error.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in AWS CloudFormation Templates.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <code>CreateStackSet</code> request. Specify this token
        /// if you plan to retry requests so that AWS CloudFormation knows that you're not attempting
        /// to create another stack set with the same name. You might retry <code>CreateStackSet</code>
        /// requests to ensure that AWS CloudFormation successfully received them.</para><para>If you don't specify an operation ID, the SDK generates one automatically. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the stack set. You can use the description to identify the stack
        /// set's purpose or other important information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The input parameters for the stack set template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name to associate with the stack set. The name must be unique in the region where
        /// you create your stack set.</para><note><para>A stack name can contain only alphanumeric characters (case-sensitive) and hyphens.
        /// It must start with an alphabetic character and can't be longer than 128 characters.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with this stack set and the stacks created from it.
        /// AWS CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. A maximum number of 50 tags can be specified.</para><para>If you specify tags as part of a <code>CreateStackSet</code> action, AWS CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you don't,
        /// the entire <code>CreateStackSet</code> action fails with an <code>access denied</code>
        /// error, and the stack set is not created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The structure that contains the template body, with a minimum length of 1 byte and
        /// a maximum length of 51,200 bytes. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify either the TemplateBody or the TemplateURL parameter,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the template body. The URL must point to a
        /// template (maximum size: 460,800 bytes) that's located in an Amazon S3 bucket. For
        /// more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify either the TemplateBody or the TemplateURL parameter,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateURL { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFNStackSet (CreateStackSet)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Capability != null)
            {
                context.Capabilities = new List<System.String>(this.Capability);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            if (this.Parameter != null)
            {
                context.Parameters = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            context.StackSetName = this.StackSetName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
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
            var request = new Amazon.CloudFormation.Model.CreateStackSetRequest();
            
            if (cmdletContext.Capabilities != null)
            {
                request.Capabilities = cmdletContext.Capabilities;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
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
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackSetId;
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
        
        private Amazon.CloudFormation.Model.CreateStackSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.CreateStackSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "CreateStackSet");
            try
            {
                #if DESKTOP
                return client.CreateStackSet(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateStackSetAsync(request);
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
            public List<System.String> Capabilities { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameters { get; set; }
            public System.String StackSetName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tags { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
        }
        
    }
}
