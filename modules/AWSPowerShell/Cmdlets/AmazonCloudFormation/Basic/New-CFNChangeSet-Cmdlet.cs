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
    /// Creates a list of changes for a stack. AWS CloudFormation generates the change set
    /// by comparing the stack's information with the information that you submit. A change
    /// set can help you understand which resources AWS CloudFormation will change and how
    /// it will change them before you update your stack. Change sets allow you to check before
    /// you make a change so that you don't delete or replace critical resources.
    /// 
    ///  
    /// <para>
    /// AWS CloudFormation doesn't make any changes to the stack when you create a change
    /// set. To make the specified changes, you must execute the change set by using the <a>ExecuteChangeSet</a>
    /// action.
    /// </para><para>
    /// After the call successfully completes, AWS CloudFormation starts creating the change
    /// set. To check the status of the change set, use the <a>DescribeChangeSet</a> action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFNChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreateChangeSet operation against AWS CloudFormation.", Operation = new[] {"CreateChangeSet"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CloudFormation.Model.CreateChangeSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFNChangeSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
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
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name of the change set. The name must be unique among all change sets that are
        /// associated with the specified stack.</para><para>A change set name can contain only alphanumeric, case sensitive characters and hyphens.
        /// It must start with an alphabetic character and cannot exceed 128 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <code>CreateChangeSet</code> request. Specify this token
        /// if you plan to retry requests so that AWS CloudFormation knows that you're not attempting
        /// to create another change set with the same name. You might retry <code>CreateChangeSet</code>
        /// requests to ensure that AWS CloudFormation successfully received them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description to help you identify this change set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter NotificationARNs
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Amazon Simple Notification Service (Amazon SNS)
        /// topics that AWS CloudFormation associates with the stack. To remove all associated
        /// notification topics, specify an empty list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] NotificationARNs { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of <code>Parameter</code> structures that specify input parameters for the
        /// change set. For more information, see the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_Parameter.html">Parameter</a>
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
        /// <para>The template resource types that you have permissions to work with if you execute
        /// this change set, such as <code>AWS::EC2::Instance</code>, <code>AWS::EC2::*</code>,
        /// or <code>Custom::MyCustomInstance</code>.</para><para>If the list of resource types doesn't include a resource type that you're updating,
        /// the stack update fails. By default, AWS CloudFormation grants permissions to all resource
        /// types. AWS Identity and Access Management (IAM) uses this parameter for condition
        /// keys in IAM policies for AWS CloudFormation. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html">Controlling
        /// Access with AWS Identity and Access Management</a> in the AWS CloudFormation User
        /// Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an AWS Identity and Access Management (IAM) role
        /// that AWS CloudFormation assumes when executing the change set. AWS CloudFormation
        /// uses the role's credentials to make calls on your behalf. AWS CloudFormation always
        /// uses this role for all future operations on the stack. As long as users have permission
        /// to operate on the stack, AWS CloudFormation uses this role even if the users don't
        /// have permission to pass it. Ensure that the role grants least privilege.</para><para>If you don't specify a value, AWS CloudFormation uses the role that was previously
        /// associated with the stack. If no role is available, AWS CloudFormation uses a temporary
        /// session that is generated from your user credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the unique ID of the stack for which you are creating a change set. AWS
        /// CloudFormation generates the change set by comparing this stack's information with
        /// the information that you submit, such as a modified template or different parameter
        /// input values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with this stack. AWS CloudFormation also propagates these
        /// tags to resources in the stack. You can specify a maximum of 10 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>A structure that contains the body of the revised template, with a minimum length
        /// of 1 byte and a maximum length of 51,200 bytes. AWS CloudFormation generates the change
        /// set by comparing this template with the template of the stack that you specified.</para><para>Conditional: You must specify only <code>TemplateBody</code> or <code>TemplateURL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the revised template. The URL must point to
        /// a template (max size: 460,800 bytes) that is located in an S3 bucket. AWS CloudFormation
        /// generates the change set by comparing this template with the stack that you specified.</para><para>Conditional: You must specify only <code>TemplateBody</code> or <code>TemplateURL</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Whether to reuse the template that is associated with the stack to create the change
        /// set.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFNChangeSet (CreateChangeSet)"))
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
            context.ChangeSetName = this.ChangeSetName;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
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
            context.RoleARN = this.RoleARN;
            context.StackName = this.StackName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            if (ParameterWasBound("UsePreviousTemplate"))
                context.UsePreviousTemplate = this.UsePreviousTemplate;
            
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
            var request = new Amazon.CloudFormation.Model.CreateChangeSetRequest();
            
            if (cmdletContext.Capabilities != null)
            {
                request.Capabilities = cmdletContext.Capabilities;
            }
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
                object pipelineOutput = response.Id;
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
        
        private static Amazon.CloudFormation.Model.CreateChangeSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.CreateChangeSetRequest request)
        {
            #if DESKTOP
            return client.CreateChangeSet(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateChangeSetAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> Capabilities { get; set; }
            public System.String ChangeSetName { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<System.String> NotificationARNs { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameters { get; set; }
            public List<System.String> ResourceTypes { get; set; }
            public System.String RoleARN { get; set; }
            public System.String StackName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tags { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
        }
        
    }
}
