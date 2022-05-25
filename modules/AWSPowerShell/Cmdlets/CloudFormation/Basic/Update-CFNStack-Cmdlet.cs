/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// the stack update starts. You can check the status of the stack through the <a>DescribeStacks</a>
    /// action.
    /// 
    ///  
    /// <para>
    /// To get a copy of the template for an existing stack, you can use the <a>GetTemplate</a>
    /// action.
    /// </para><para>
    /// For more information about creating an update template, updating a stack, and monitoring
    /// the progress of the update, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-cfn-updating-stacks.html">Updating
    /// a Stack</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStack API operation.", Operation = new[] {"UpdateStack"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateStackResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateStackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNStackCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicitly acknowledge that your stack template contains certain
        /// capabilities in order for CloudFormation to update the stack.</para><ul><li><para><code>CAPABILITY_IAM</code> and <code>CAPABILITY_NAMED_IAM</code></para><para>Some stack templates might include resources that can affect permissions in your Amazon
        /// Web Services account; for example, by creating new Identity and Access Management
        /// (IAM) users. For those stacks, you must explicitly acknowledge this by specifying
        /// one of these capabilities.</para><para>The following IAM resources require you to specify either the <code>CAPABILITY_IAM</code>
        /// or <code>CAPABILITY_NAMED_IAM</code> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability.</para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <code>CAPABILITY_NAMED_IAM</code>.</para></li><li><para>If you don't specify either of these capabilities, CloudFormation returns an <code>InsufficientCapabilities</code>
        /// error.</para></li></ul><para>If your stack template contains these resources, we suggest that you review all permissions
        /// associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-group.html">
        /// AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-policy.html">
        /// AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-user.html">
        /// AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-addusertogroup.html">AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in CloudFormation Templates</a>.</para></li><li><para><code>CAPABILITY_AUTO_EXPAND</code></para><para>Some template contain macros. Macros perform custom processing on templates; this
        /// can include simple actions like find-and-replace operations, all the way to extensive
        /// transformations of entire templates. Because of this, users typically create a change
        /// set from the processed template, so that they can review the changes resulting from
        /// the macros before actually updating the stack. If your stack template contains one
        /// or more macros, and you choose to update a stack directly from the processed template,
        /// without first reviewing the resulting changes in a change set, you must acknowledge
        /// this capability. This includes the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.</para><para>If you want to update a stack from a stack template that contains macros <i>and</i>
        /// nested stacks, you must update the stack directly from the template using this capability.</para><important><para>You should only update stacks directly from a stack template that contains macros
        /// if you know what processing the macro performs.</para><para>Each macro relies on an underlying Lambda service function for processing stack templates.
        /// Be aware that the Lambda function owner can update the function operation without
        /// CloudFormation being notified.</para></important><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Using
        /// CloudFormation Macros to Perform Custom Processing on Templates</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <code>UpdateStack</code> request. Specify this token
        /// if you plan to retry requests so that CloudFormation knows that you're not attempting
        /// to update a stack with the same name. You might retry <code>UpdateStack</code> requests
        /// to ensure that CloudFormation successfully received them.</para><para>All events triggered by a given stack operation are assigned the same client request
        /// token, which you can use to track operations. For example, if you execute a <code>CreateStack</code>
        /// operation with the token <code>token1</code>, then all the <code>StackEvents</code>
        /// generated by that operation will have <code>ClientRequestToken</code> set as <code>token1</code>.</para><para>In the console, stack operations display the client request token on the Events tab.
        /// Stack operations that are initiated from the console use the token format <i>Console-StackOperation-ID</i>,
        /// which helps you easily identify the stack operation . For example, if you create a
        /// stack using the console, each stack event would be assigned the same token in the
        /// following format: <code>Console-CreateStack-7f59c3cf-00d2-40c7-b2ff-e75db0987002</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter DisableRollback
        /// <summary>
        /// <para>
        /// <para>Preserve the state of previously provisioned resources when an operation fails.</para><para>Default: <code>False</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableRollback { get; set; }
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
        /// <para>Amazon Simple Notification Service topic Amazon Resource Names (ARNs) that CloudFormation
        /// associates with the stack. Specify an empty list to remove all notification topics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NotificationARNs { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of <code>Parameter</code> structures that specify input parameters for the
        /// stack. For more information, see the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_Parameter.html">Parameter</a>
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
        /// <para>The template resource types that you have permissions to work with for this update
        /// stack action, such as <code>AWS::EC2::Instance</code>, <code>AWS::EC2::*</code>, or
        /// <code>Custom::MyCustomInstance</code>.</para><para>If the list of resource types doesn't include a resource that you're updating, the
        /// stack update fails. By default, CloudFormation grants permissions to all resource
        /// types. Identity and Access Management (IAM) uses this parameter for CloudFormation-specific
        /// condition keys in IAM policies. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html">Controlling
        /// Access with Identity and Access Management</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Identity and Access Management (IAM) role that
        /// CloudFormation assumes to update the stack. CloudFormation uses the role's credentials
        /// to make calls on your behalf. CloudFormation always uses this role for all future
        /// operations on the stack. Provided that users have permission to operate on the stack,
        /// CloudFormation uses this role even if the users don't have permission to pass it.
        /// Ensure that the role grants least privilege.</para><para>If you don't specify a value, CloudFormation uses the role that was previously associated
        /// with the stack. If no role is available, CloudFormation uses a temporary session that
        /// is generated from your user credentials.</para>
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
        /// <para>The name or unique stack ID of the stack to update.</para>
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
        /// <para>Structure containing a new stack policy body. You can specify either the <code>StackPolicyBody</code>
        /// or the <code>StackPolicyURL</code> parameter, but not both.</para><para>You might update the stack policy, for example, in order to protect a new resource
        /// that you created during a stack update. If you don't specify a stack policy, the current
        /// policy that is associated with the stack is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyBody { get; set; }
        #endregion
        
        #region Parameter StackPolicyDuringUpdateBody
        /// <summary>
        /// <para>
        /// <para>Structure containing the temporary overriding stack policy body. You can specify either
        /// the <code>StackPolicyDuringUpdateBody</code> or the <code>StackPolicyDuringUpdateURL</code>
        /// parameter, but not both.</para><para>If you want to update protected resources, specify a temporary overriding stack policy
        /// during this update. If you don't specify a stack policy, the current policy that is
        /// associated with the stack will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyDuringUpdateBody { get; set; }
        #endregion
        
        #region Parameter StackPolicyDuringUpdateURL
        /// <summary>
        /// <para>
        /// <para>Location of a file containing the temporary overriding stack policy. The URL must
        /// point to a policy (max size: 16KB) located in an S3 bucket in the same Region as the
        /// stack. You can specify either the <code>StackPolicyDuringUpdateBody</code> or the
        /// <code>StackPolicyDuringUpdateURL</code> parameter, but not both.</para><para>If you want to update protected resources, specify a temporary overriding stack policy
        /// during this update. If you don't specify a stack policy, the current policy that is
        /// associated with the stack will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyDuringUpdateURL { get; set; }
        #endregion
        
        #region Parameter StackPolicyURL
        /// <summary>
        /// <para>
        /// <para>Location of a file containing the updated stack policy. The URL must point to a policy
        /// (max size: 16KB) located in an S3 bucket in the same Region as the stack. You can
        /// specify either the <code>StackPolicyBody</code> or the <code>StackPolicyURL</code>
        /// parameter, but not both.</para><para>You might update the stack policy, for example, in order to protect a new resource
        /// that you created during a stack update. If you don't specify a stack policy, the current
        /// policy that is associated with the stack is unchanged.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackPolicyURL { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with this stack. CloudFormation also propagates these
        /// tags to supported resources in the stack. You can specify a maximum number of 50 tags.</para><para>If you don't specify this parameter, CloudFormation doesn't modify the stack's tags.
        /// If you specify an empty value, CloudFormation removes all associated tags.</para>
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
        /// length of 51,200 bytes. (For more information, go to <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.)</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>,
        /// <code>TemplateURL</code>, or set the <code>UsePreviousTemplate</code> to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>Location of file containing the template body. The URL must point to a template that's
        /// located in an Amazon S3 bucket or a Systems Manager document. For more information,
        /// go to <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>,
        /// <code>TemplateURL</code>, or set the <code>UsePreviousTemplate</code> to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Reuse the existing template that is associated with the stack that you are updating.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>,
        /// <code>TemplateURL</code>, or set the <code>UsePreviousTemplate</code> to <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UsePreviousTemplate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StackId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.UpdateStackResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.UpdateStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StackId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStack (UpdateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.UpdateStackResponse, UpdateCFNStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.DisableRollback = this.DisableRollback;
            if (this.NotificationARNs != null)
            {
                context.NotificationARNs = new List<System.String>(this.NotificationARNs);
            }
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
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
            context.StackPolicyDuringUpdateBody = this.StackPolicyDuringUpdateBody;
            context.StackPolicyDuringUpdateURL = this.StackPolicyDuringUpdateURL;
            context.StackPolicyURL = this.StackPolicyURL;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudFormation.Model.Tag>(this.Tag);
            }
            context.TemplateBody = this.TemplateBody;
            context.TemplateURL = this.TemplateURL;
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
            var request = new Amazon.CloudFormation.Model.UpdateStackRequest();
            
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
            if (cmdletContext.NotificationARNs != null)
            {
                request.NotificationARNs = cmdletContext.NotificationARNs;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
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
            if (cmdletContext.UsePreviousTemplate != null)
            {
                request.UsePreviousTemplate = cmdletContext.UsePreviousTemplate.Value;
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
        
        private Amazon.CloudFormation.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStack");
            try
            {
                #if DESKTOP
                return client.UpdateStack(request);
                #elif CORECLR
                return client.UpdateStackAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> NotificationARNs { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public List<System.String> ResourceType { get; set; }
            public System.String RoleARN { get; set; }
            public System.Int32? RollbackConfiguration_MonitoringTimeInMinute { get; set; }
            public List<Amazon.CloudFormation.Model.RollbackTrigger> RollbackConfiguration_RollbackTrigger { get; set; }
            public System.String StackName { get; set; }
            public System.String StackPolicyBody { get; set; }
            public System.String StackPolicyDuringUpdateBody { get; set; }
            public System.String StackPolicyDuringUpdateURL { get; set; }
            public System.String StackPolicyURL { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
            public System.Func<Amazon.CloudFormation.Model.UpdateStackResponse, UpdateCFNStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StackId;
        }
        
    }
}
