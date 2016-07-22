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
    /// Updates a stack as specified in the template. After the call completes successfully,
    /// the stack update starts. You can check the status of the stack via the <a>DescribeStacks</a>
    /// action.
    /// 
    ///  
    /// <para>
    /// To get a copy of the template for an existing stack, you can use the <a>GetTemplate</a>
    /// action.
    /// </para><para>
    /// For more information about creating an update template, updating a stack, and monitoring
    /// the progress of the update, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-updating-stacks.html">Updating
    /// a Stack</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the UpdateStack operation against AWS CloudFormation.", Operation = new[] {"UpdateStack"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>A list of values that you must specify before AWS CloudFormation can update certain
        /// stacks. Some stack templates might include resources that can affect permissions in
        /// your AWS account, for example, by creating new AWS Identity and Access Management
        /// (IAM) users. For those stacks, you must explicitly acknowledge their capabilities
        /// by specifying this parameter.</para><para>The only valid values are <code>CAPABILITY_IAM</code> and <code>CAPABILITY_NAMED_IAM</code>.
        /// The following resources require you to specify this parameter: <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a>, <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-group.html">
        /// AWS::IAM::Group</a>, <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">
        /// AWS::IAM::InstanceProfile</a>, <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-policy.html">
        /// AWS::IAM::Policy</a>, <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a>, <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-user.html">
        /// AWS::IAM::User</a>, and <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-addusertogroup.html">
        /// AWS::IAM::UserToGroupAddition</a>. If your stack template contains these resources,
        /// we recommend that you review all permissions associated with them and edit their permissions
        /// if necessary.</para><para>If you have IAM resources, you can specify either capability. If you have IAM resources
        /// with custom names, you must specify <code>CAPABILITY_NAMED_IAM</code>. If you don't
        /// specify this parameter, this action returns an <code>InsufficientCapabilities</code>
        /// error.</para><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in AWS CloudFormation Templates</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter NotificationARNs
        /// <summary>
        /// <para>
        /// <para>Amazon Simple Notification Service topic Amazon Resource Names (ARNs) that AWS CloudFormation
        /// associates with the stack. Specify an empty list to remove all notification topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] NotificationARNs { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of <code>Parameter</code> structures that specify input parameters for the
        /// stack. For more information, see the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_Parameter.html">Parameter</a>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The template resource types that you have permissions to work with for this update
        /// stack action, such as <code>AWS::EC2::Instance</code>, <code>AWS::EC2::*</code>, or
        /// <code>Custom::MyCustomInstance</code>.</para><para>If the list of resource types doesn't include a resource that you're updating, the
        /// stack update fails. By default, AWS CloudFormation grants permissions to all resource
        /// types. AWS Identity and Access Management (IAM) uses this parameter for AWS CloudFormation-specific
        /// condition keys in IAM policies. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html">Controlling
        /// Access with AWS Identity and Access Management</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or unique stack ID of the stack to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter StackPolicyBody
        /// <summary>
        /// <para>
        /// <para>Structure containing a new stack policy body. You can specify either the <code>StackPolicyBody</code>
        /// or the <code>StackPolicyURL</code> parameter, but not both.</para><para>You might update the stack policy, for example, in order to protect a new resource
        /// that you created during a stack update. If you do not specify a stack policy, the
        /// current policy that is associated with the stack is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackPolicyBody { get; set; }
        #endregion
        
        #region Parameter StackPolicyDuringUpdateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the temporary overriding stack policy body. You can specify either
        /// the <code>StackPolicyDuringUpdateBody</code> or the <code>StackPolicyDuringUpdateURL</code>
        /// parameter, but not both.</para><para>If you want to update protected resources, specify a temporary overriding stack policy
        /// during this update. If you do not specify a stack policy, the current policy that
        /// is associated with the stack will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackPolicyDuringUpdateBody { get; set; }
        #endregion
        
        #region Parameter StackPolicyDuringUpdateURL
        /// <summary>
        /// <para>
        /// <para>Location of a file containing the temporary overriding stack policy. The URL must
        /// point to a policy (max size: 16KB) located in an S3 bucket in the same region as the
        /// stack. You can specify either the <code>StackPolicyDuringUpdateBody</code> or the
        /// <code>StackPolicyDuringUpdateURL</code> parameter, but not both.</para><para>If you want to update protected resources, specify a temporary overriding stack policy
        /// during this update. If you do not specify a stack policy, the current policy that
        /// is associated with the stack will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackPolicyDuringUpdateURL { get; set; }
        #endregion
        
        #region Parameter StackPolicyURL
        /// <summary>
        /// <para>
        /// <para>Location of a file containing the updated stack policy. The URL must point to a policy
        /// (max size: 16KB) located in an S3 bucket in the same region as the stack. You can
        /// specify either the <code>StackPolicyBody</code> or the <code>StackPolicyURL</code>
        /// parameter, but not both.</para><para>You might update the stack policy, for example, in order to protect a new resource
        /// that you created during a stack update. If you do not specify a stack policy, the
        /// current policy that is associated with the stack is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StackPolicyURL { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with this stack. AWS CloudFormation also propagates these
        /// tags to supported resources in the stack. You can specify a maximum number of 10 tags.</para><para>If you don't specify this parameter, AWS CloudFormation doesn't modify the stack's
        /// tags. If you specify an empty value, AWS CloudFormation removes all associated tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the template body with a minimum length of 1 byte and a maximum
        /// length of 51,200 bytes. (For more information, go to <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.)</para><para>Conditional: You must specify either the <code>TemplateBody</code> or the <code>TemplateURL</code>
        /// parameter, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template that
        /// is located in an Amazon S3 bucket. For more information, go to <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify either the <code>TemplateBody</code> or the <code>TemplateURL</code>
        /// parameter, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Reuse the existing template that is associated with the stack that you are updating.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UsePreviousTemplate { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStack (UpdateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Capability != null)
            {
                context.Capabilities = new List<System.String>(this.Capability);
            }
            if (this.NotificationARNs != null)
            {
                context.NotificationARNs = new List<System.String>(this.NotificationARNs);
            }
            if (this.Parameter != null)
            {
                context.Parameters = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            if (this.ResourceType != null)
            {
                context.ResourceTypes = new List<System.String>(this.ResourceType);
            }
            context.StackName = this.StackName;
            context.StackPolicyBody = this.StackPolicyBody;
            context.StackPolicyDuringUpdateBody = this.StackPolicyDuringUpdateBody;
            context.StackPolicyDuringUpdateURL = this.StackPolicyDuringUpdateURL;
            context.StackPolicyURL = this.StackPolicyURL;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            if (ParameterWasBound("UsePreviousTemplate"))
                context.UsePreviousTemplate = this.UsePreviousTemplate;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CloudFormation.Model.UpdateStackRequest();
            
            if (cmdletContext.Capabilities != null)
            {
                request.Capabilities = cmdletContext.Capabilities;
            }
            if (cmdletContext.NotificationARNs != null)
            {
                request.NotificationARNs = cmdletContext.NotificationARNs;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.ResourceTypes != null)
            {
                request.ResourceTypes = cmdletContext.ResourceTypes;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.StackPolicyBody != null)
            {
                request.StackPolicyBody = cmdletContext.StackPolicyBody;
            }
            if (cmdletContext.StackPolicyDuringUpdateBody != null)
            {
                request.StackPolicyDuringUpdateBody = cmdletContext.StackPolicyDuringUpdateBody;
            }
            if (cmdletContext.StackPolicyDuringUpdateURL != null)
            {
                request.StackPolicyDuringUpdateURL = cmdletContext.StackPolicyDuringUpdateURL;
            }
            if (cmdletContext.StackPolicyURL != null)
            {
                request.StackPolicyURL = cmdletContext.StackPolicyURL;
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
            if (cmdletContext.UsePreviousTemplate != null)
            {
                request.UsePreviousTemplate = cmdletContext.UsePreviousTemplate.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackId;
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
        
        private static Amazon.CloudFormation.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackRequest request)
        {
            return client.UpdateStack(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> Capabilities { get; set; }
            public List<System.String> NotificationARNs { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameters { get; set; }
            public List<System.String> ResourceTypes { get; set; }
            public System.String StackName { get; set; }
            public System.String StackPolicyBody { get; set; }
            public System.String StackPolicyDuringUpdateBody { get; set; }
            public System.String StackPolicyDuringUpdateURL { get; set; }
            public System.String StackPolicyURL { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tags { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
        }
        
    }
}
