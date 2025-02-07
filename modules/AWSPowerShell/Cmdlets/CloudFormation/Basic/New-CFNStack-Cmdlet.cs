/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a stack as specified in the template. After the call completes successfully,
    /// the stack creation starts. You can check the status of the stack through the <a>DescribeStacks</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// For more information about creating a stack and monitoring stack progress, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacks.html">Managing
    /// Amazon Web Services resources as a single unit with CloudFormation stacks</a> in the
    /// <i>CloudFormation User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFNStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation CreateStack API operation.", Operation = new[] {"CreateStack"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.CreateStackResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.CreateStackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.CreateStackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicitly acknowledge that your stack template contains certain
        /// capabilities in order for CloudFormation to create the stack.</para><ul><li><para><c>CAPABILITY_IAM</c> and <c>CAPABILITY_NAMED_IAM</c></para><para>Some stack templates might include resources that can affect permissions in your Amazon
        /// Web Services account; for example, by creating new IAM users. For those stacks, you
        /// must explicitly acknowledge this by specifying one of these capabilities.</para><para>The following IAM resources require you to specify either the <c>CAPABILITY_IAM</c>
        /// or <c>CAPABILITY_NAMED_IAM</c> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability.</para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <c>CAPABILITY_NAMED_IAM</c>.</para></li><li><para>If you don't specify either of these capabilities, CloudFormation returns an <c>InsufficientCapabilities</c>
        /// error.</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-accesskey.html">AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-group.html">AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-policy.html">AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-user.html">AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-usertogroupaddition.html">AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#using-iam-capabilities">Acknowledging
        /// IAM resources in CloudFormation templates</a>.</para></li><li><para><c>CAPABILITY_AUTO_EXPAND</c></para><para>Some template contain macros. Macros perform custom processing on templates; this
        /// can include simple actions like find-and-replace operations, all the way to extensive
        /// transformations of entire templates. Because of this, users typically create a change
        /// set from the processed template, so that they can review the changes resulting from
        /// the macros before actually creating the stack. If your stack template contains one
        /// or more macros, and you choose to create a stack directly from the processed template,
        /// without first reviewing the resulting changes in a change set, you must acknowledge
        /// this capability. This includes the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.</para><para>If you want to create a stack from a stack template that contains macros <i>and</i>
        /// nested stacks, you must create the stack directly from the template using this capability.</para><important><para>You should only create stacks directly from a stack template that contains macros
        /// if you know what processing the macro performs.</para><para>Each macro relies on an underlying Lambda service function for processing stack templates.
        /// Be aware that the Lambda function owner can update the function operation without
        /// CloudFormation being notified.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Perform
        /// custom processing on CloudFormation templates with template macros</a>.</para></li></ul><note><para>Only one of the <c>Capabilities</c> and <c>ResourceType</c> parameters can be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <c>CreateStack</c> request. Specify this token if you
        /// plan to retry requests so that CloudFormation knows that you're not attempting to
        /// create a stack with the same name. You might retry <c>CreateStack</c> requests to
        /// ensure that CloudFormation successfully received them.</para><para>All events initiated by a given stack operation are assigned the same client request
        /// token, which you can use to track operations. For example, if you execute a <c>CreateStack</c>
        /// operation with the token <c>token1</c>, then all the <c>StackEvents</c> generated
        /// by that operation will have <c>ClientRequestToken</c> set as <c>token1</c>.</para><para>In the console, stack operations display the client request token on the Events tab.
        /// Stack operations that are initiated from the console use the token format <i>Console-StackOperation-ID</i>,
        /// which helps you easily identify the stack operation . For example, if you create a
        /// stack using the console, each stack event would be assigned the same token in the
        /// following format: <c>Console-CreateStack-7f59c3cf-00d2-40c7-b2ff-e75db0987002</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DisableRollback
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to disable rollback of the stack if stack creation failed. You
        /// can specify either <c>DisableRollback</c> or <c>OnFailure</c>, but not both.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableRollback { get; set; }
        #endregion
        
        #region Parameter EnableTerminationProtection
        /// <summary>
        /// <para>
        /// <para>Whether to enable termination protection on the specified stack. If a user attempts
        /// to delete a stack with termination protection enabled, the operation fails and the
        /// stack remains unchanged. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-protect-stacks.html">Protect
        /// CloudFormation stacks from being deleted</a> in the <i>CloudFormation User Guide</i>.
        /// Termination protection is deactivated on stacks by default.</para><para>For <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-nested-stacks.html">nested
        /// stacks</a>, termination protection is set on the root stack and can't be changed directly
        /// on the nested stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableTerminationProtection { get; set; }
        #endregion
        
        #region Parameter RollbackConfiguration_MonitoringTimeInMinute
        /// <summary>
        /// <para>
        /// <para>The amount of time, in minutes, during which CloudFormation should monitor all the
        /// rollback triggers after the stack creation or update operation deploys all necessary
        /// resources.</para><para>The default is 0 minutes.</para><para>If you specify a monitoring period but don't specify any rollback triggers, CloudFormation
        /// still waits the specified period of time before cleaning up old resources after update
        /// operations. You can use this monitoring period to perform any manual stack validation
        /// desired, and manually cancel the stack creation or update (using <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_CancelUpdateStack.html">CancelUpdateStack</a>,
        /// for example) as necessary.</para><para>If you specify 0 for this parameter, CloudFormation still monitors the specified rollback
        /// triggers during stack creation and update operations. Then, for update operations,
        /// it begins disposing of old resources immediately once the operation completes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RollbackConfiguration_MonitoringTimeInMinutes")]
        public System.Int32? RollbackConfiguration_MonitoringTimeInMinute { get; set; }
        #endregion
        
        #region Parameter NotificationARNs
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic ARNs to publish stack related events. You can find your Amazon
        /// SNS topic ARNs using the Amazon SNS console or your Command Line Interface (CLI).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NotificationARNs { get; set; }
        #endregion
        
        #region Parameter OnFailure
        /// <summary>
        /// <para>
        /// <para>Determines what action will be taken if stack creation fails. This must be one of:
        /// <c>DO_NOTHING</c>, <c>ROLLBACK</c>, or <c>DELETE</c>. You can specify either <c>OnFailure</c>
        /// or <c>DisableRollback</c>, but not both.</para><para>Default: <c>ROLLBACK</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.OnFailure")]
        public Amazon.CloudFormation.OnFailure OnFailure { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of <c>Parameter</c> structures that specify input parameters for the stack.
        /// For more information, see the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_Parameter.html">Parameter</a>
        /// data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The template resource types that you have permissions to work with for this create
        /// stack action, such as <c>AWS::EC2::Instance</c>, <c>AWS::EC2::*</c>, or <c>Custom::MyCustomInstance</c>.
        /// Use the following syntax to describe template resource types: <c>AWS::*</c> (for all
        /// Amazon Web Services resources), <c>Custom::*</c> (for all custom resources), <c>Custom::<i>logical_ID</i></c> (for a specific custom resource), <c>AWS::<i>service_name</i>::*</c> (for all
        /// resources of a particular Amazon Web Services service), and <c>AWS::<i>service_name</i>::<i>resource_logical_ID</i></c> (for a specific Amazon Web Services resource).</para><para>If the list of resource types doesn't include a resource that you're creating, the
        /// stack creation fails. By default, CloudFormation grants permissions to all resource
        /// types. IAM uses this parameter for CloudFormation-specific condition keys in IAM policies.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html">Control
        /// access with Identity and Access Management</a>.</para><note><para>Only one of the <c>Capabilities</c> and <c>ResourceType</c> parameters can be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter RetainExceptOnCreate
        /// <summary>
        /// <para>
        /// <para>When set to <c>true</c>, newly created resources are deleted when the operation rolls
        /// back. This includes newly created resources marked with a deletion policy of <c>Retain</c>.</para><para>Default: <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RetainExceptOnCreate { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that CloudFormation assumes to create
        /// the stack. CloudFormation uses the role's credentials to make calls on your behalf.
        /// CloudFormation always uses this role for all future operations on the stack. Provided
        /// that users have permission to operate on the stack, CloudFormation uses this role
        /// even if the users don't have permission to pass it. Ensure that the role grants least
        /// privilege.</para><para>If you don't specify a value, CloudFormation uses the role that was previously associated
        /// with the stack. If no role is available, CloudFormation uses a temporary session that's
        /// generated from your user credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter RollbackConfiguration_RollbackTrigger
        /// <summary>
        /// <para>
        /// <para>The triggers to monitor during stack creation or update actions.</para><para>By default, CloudFormation saves the rollback triggers specified for a stack and applies
        /// them to any subsequent update operations for the stack, unless you specify otherwise.
        /// If you do specify rollback triggers for this parameter, those triggers replace any
        /// list of triggers previously specified for the stack. This means:</para><ul><li><para>To use the rollback triggers previously specified for this stack, if any, don't specify
        /// this parameter.</para></li><li><para>To specify new or updated rollback triggers, you must specify <i>all</i> the triggers
        /// that you want used for this stack, even triggers you've specified before (for example,
        /// when creating the stack or during a previous stack update). Any triggers that you
        /// don't include in the updated list of triggers are no longer applied to the stack.</para></li><li><para>To remove all currently specified triggers, specify an empty list for this parameter.</para></li></ul><para>If a specified trigger is missing, the entire stack operation fails and is rolled
        /// back.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RollbackConfiguration_RollbackTriggers")]
        public Amazon.CloudFormation.Model.RollbackTrigger[] RollbackConfiguration_RollbackTrigger { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name that's associated with the stack. The name must be unique in the Region in
        /// which you are creating the stack.</para><note><para>A stack name can contain only alphanumeric characters (case sensitive) and hyphens.
        /// It must start with an alphabetical character and can't be longer than 128 characters.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter StackPolicyBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the stack policy body. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/protect-stack-resources.html">Prevent
        /// updates to stack resources</a> in the <i>CloudFormation User Guide</i>. You can specify
        /// either the <c>StackPolicyBody</c> or the <c>StackPolicyURL</c> parameter, but not
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyBody { get; set; }
        #endregion
        
        #region Parameter StackPolicyURL
        /// <summary>
        /// <para>
        /// <para>Location of a file containing the stack policy. The URL must point to a policy (maximum
        /// size: 16 KB) located in an S3 bucket in the same Region as the stack. The location
        /// for an Amazon S3 bucket must start with <c>https://</c>. You can specify either the
        /// <c>StackPolicyBody</c> or the <c>StackPolicyURL</c> parameter, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyURL { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with this stack. CloudFormation also propagates these
        /// tags to the resources created in the stack. A maximum number of 50 tags can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the template body with a minimum length of 1 byte and a maximum
        /// length of 51,200 bytes.</para><para>Conditional: You must specify either the <c>TemplateBody</c> or the <c>TemplateURL</c>
        /// parameter, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template (max
        /// size: 460,800 bytes) that's located in an Amazon S3 bucket or a Systems Manager document.
        /// The location for an Amazon S3 bucket must start with <c>https://</c>.</para><para>Conditional: You must specify either the <c>TemplateBody</c> or the <c>TemplateURL</c>
        /// parameter, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter TimeoutInMinutes
        /// <summary>
        /// <para>
        /// <para>The amount of time that can pass before the stack status becomes <c>CREATE_FAILED</c>;
        /// if <c>DisableRollback</c> is not set or is set to <c>false</c>, the stack will be
        /// rolled back.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TimeoutInMinutes { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StackId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.CreateStackResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.CreateStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StackId";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFNStack (CreateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.CreateStackResponse, NewCFNStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.DisableRollback = this.DisableRollback;
            context.EnableTerminationProtection = this.EnableTerminationProtection;
            if (this.NotificationARNs != null)
            {
                context.NotificationARNs = new List<System.String>(this.NotificationARNs);
            }
            context.OnFailure = this.OnFailure;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            context.RetainExceptOnCreate = this.RetainExceptOnCreate;
            context.RoleARN = this.RoleARN;
            context.RollbackConfiguration_MonitoringTimeInMinute = this.RollbackConfiguration_MonitoringTimeInMinute;
            if (this.RollbackConfiguration_RollbackTrigger != null)
            {
                context.RollbackConfiguration_RollbackTrigger = new List<Amazon.CloudFormation.Model.RollbackTrigger>(this.RollbackConfiguration_RollbackTrigger);
            }
            context.StackName = this.StackName;
            #if MODULAR
            if (this.StackName == null && ParameterWasBound(nameof(this.StackName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackPolicyBody = this.StackPolicyBody;
            context.StackPolicyURL = this.StackPolicyURL;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
            context.TimeoutInMinutes = this.TimeoutInMinutes;
            
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
            var request = new Amazon.CloudFormation.Model.CreateStackRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.DisableRollback != null)
            {
                request.DisableRollback = cmdletContext.DisableRollback.Value;
            }
            if (cmdletContext.EnableTerminationProtection != null)
            {
                request.EnableTerminationProtection = cmdletContext.EnableTerminationProtection.Value;
            }
            if (cmdletContext.NotificationARNs != null)
            {
                request.NotificationARNs = cmdletContext.NotificationARNs;
            }
            if (cmdletContext.OnFailure != null)
            {
                request.OnFailure = cmdletContext.OnFailure;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
            }
            if (cmdletContext.RetainExceptOnCreate != null)
            {
                request.RetainExceptOnCreate = cmdletContext.RetainExceptOnCreate.Value;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            
             // populate RollbackConfiguration
            var requestRollbackConfigurationIsNull = true;
            request.RollbackConfiguration = new Amazon.CloudFormation.Model.RollbackConfiguration();
            System.Int32? requestRollbackConfiguration_rollbackConfiguration_MonitoringTimeInMinute = null;
            if (cmdletContext.RollbackConfiguration_MonitoringTimeInMinute != null)
            {
                requestRollbackConfiguration_rollbackConfiguration_MonitoringTimeInMinute = cmdletContext.RollbackConfiguration_MonitoringTimeInMinute.Value;
            }
            if (requestRollbackConfiguration_rollbackConfiguration_MonitoringTimeInMinute != null)
            {
                request.RollbackConfiguration.MonitoringTimeInMinutes = requestRollbackConfiguration_rollbackConfiguration_MonitoringTimeInMinute.Value;
                requestRollbackConfigurationIsNull = false;
            }
            List<Amazon.CloudFormation.Model.RollbackTrigger> requestRollbackConfiguration_rollbackConfiguration_RollbackTrigger = null;
            if (cmdletContext.RollbackConfiguration_RollbackTrigger != null)
            {
                requestRollbackConfiguration_rollbackConfiguration_RollbackTrigger = cmdletContext.RollbackConfiguration_RollbackTrigger;
            }
            if (requestRollbackConfiguration_rollbackConfiguration_RollbackTrigger != null)
            {
                request.RollbackConfiguration.RollbackTriggers = requestRollbackConfiguration_rollbackConfiguration_RollbackTrigger;
                requestRollbackConfigurationIsNull = false;
            }
             // determine if request.RollbackConfiguration should be set to null
            if (requestRollbackConfigurationIsNull)
            {
                request.RollbackConfiguration = null;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.StackPolicyBody != null)
            {
                request.StackPolicyBody = cmdletContext.StackPolicyBody;
            }
            if (cmdletContext.StackPolicyURL != null)
            {
                request.StackPolicyURL = cmdletContext.StackPolicyURL;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateURL != null)
            {
                request.TemplateURL = cmdletContext.TemplateURL;
            }
            if (cmdletContext.TimeoutInMinutes != null)
            {
                request.TimeoutInMinutes = cmdletContext.TimeoutInMinutes.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.CloudFormation.Model.CreateStackResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.CreateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "CreateStack");
            try
            {
                #if DESKTOP
                return client.CreateStack(request);
                #elif CORECLR
                return client.CreateStackAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Capability { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? DisableRollback { get; set; }
            public System.Boolean? EnableTerminationProtection { get; set; }
            public List<System.String> NotificationARNs { get; set; }
            public Amazon.CloudFormation.OnFailure OnFailure { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public List<System.String> ResourceType { get; set; }
            public System.Boolean? RetainExceptOnCreate { get; set; }
            public System.String RoleARN { get; set; }
            public System.Int32? RollbackConfiguration_MonitoringTimeInMinute { get; set; }
            public List<Amazon.CloudFormation.Model.RollbackTrigger> RollbackConfiguration_RollbackTrigger { get; set; }
            public System.String StackName { get; set; }
            public System.String StackPolicyBody { get; set; }
            public System.String StackPolicyURL { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Int32? TimeoutInMinutes { get; set; }
            public System.Func<Amazon.CloudFormation.Model.CreateStackResponse, NewCFNStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StackId;
        }
        
    }
}
