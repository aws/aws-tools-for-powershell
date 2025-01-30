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
    /// Creates a list of changes that will be applied to a stack so that you can review the
    /// changes before executing them. You can create a change set for a stack that doesn't
    /// exist or an existing stack. If you create a change set for a stack that doesn't exist,
    /// the change set shows all of the resources that CloudFormation will create. If you
    /// create a change set for an existing stack, CloudFormation compares the stack's information
    /// with the information that you submit in the change set and lists the differences.
    /// Use change sets to understand which resources CloudFormation will create or change,
    /// and how it will change resources in an existing stack, before you create or update
    /// a stack.
    /// 
    ///  
    /// <para>
    /// To create a change set for a stack that doesn't exist, for the <c>ChangeSetType</c>
    /// parameter, specify <c>CREATE</c>. To create a change set for an existing stack, specify
    /// <c>UPDATE</c> for the <c>ChangeSetType</c> parameter. To create a change set for an
    /// import operation, specify <c>IMPORT</c> for the <c>ChangeSetType</c> parameter. After
    /// the <c>CreateChangeSet</c> call successfully completes, CloudFormation starts creating
    /// the change set. To check the status of the change set or to review it, use the <a>DescribeChangeSet</a>
    /// action.
    /// </para><para>
    /// When you are satisfied with the changes the change set will make, execute the change
    /// set by using the <a>ExecuteChangeSet</a> action. CloudFormation doesn't make changes
    /// until you execute the change set.
    /// </para><para>
    /// To create a change set for the entire stack hierarchy, set <c>IncludeNestedStacks</c>
    /// to <c>True</c>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CFNChangeSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation CreateChangeSet API operation.", Operation = new[] {"CreateChangeSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.CreateChangeSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.CreateChangeSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.CreateChangeSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCFNChangeSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
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
        /// error.</para></li></ul><para>If your stack template contains these resources, we suggest that you review all permissions
        /// associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-group.html">
        /// AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-policy.html">
        /// AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-user.html">
        /// AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-usertogroupaddition.html">AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#using-iam-capabilities">Acknowledging
        /// IAM resources in CloudFormation templates</a>.</para></li><li><para><c>CAPABILITY_AUTO_EXPAND</c></para><para>Some template contain macros. Macros perform custom processing on templates; this
        /// can include simple actions like find-and-replace operations, all the way to extensive
        /// transformations of entire templates. Because of this, users typically create a change
        /// set from the processed template, so that they can review the changes resulting from
        /// the macros before actually creating the stack. If your stack template contains one
        /// or more macros, and you choose to create a stack directly from the processed template,
        /// without first reviewing the resulting changes in a change set, you must acknowledge
        /// this capability. This includes the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.</para><note><para>This capacity doesn't apply to creating change sets, and specifying it when creating
        /// change sets has no effect.</para><para>If you want to create a stack from a stack template that contains macros <i>and</i>
        /// nested stacks, you must create or update the stack directly from the template using
        /// the <a>CreateStack</a> or <a>UpdateStack</a> action, and specifying this capability.</para></note><para>For more information about macros, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Perform
        /// custom processing on CloudFormation templates with template macros</a>.</para></li></ul><note><para>Only one of the <c>Capabilities</c> and <c>ResourceType</c> parameters can be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ChangeSetName
        /// <summary>
        /// <para>
        /// <para>The name of the change set. The name must be unique among all change sets that are
        /// associated with the specified stack.</para><para>A change set name can contain only alphanumeric, case sensitive characters, and hyphens.
        /// It must start with an alphabetical character and can't exceed 128 characters.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ChangeSetName { get; set; }
        #endregion
        
        #region Parameter ChangeSetType
        /// <summary>
        /// <para>
        /// <para>The type of change set operation. To create a change set for a new stack, specify
        /// <c>CREATE</c>. To create a change set for an existing stack, specify <c>UPDATE</c>.
        /// To create a change set for an import operation, specify <c>IMPORT</c>.</para><para>If you create a change set for a new stack, CloudFormation creates a stack with a
        /// unique stack ID, but no template or resources. The stack will be in the <c>REVIEW_IN_PROGRESS</c>
        /// state until you execute the change set.</para><para>By default, CloudFormation specifies <c>UPDATE</c>. You can't use the <c>UPDATE</c>
        /// type to create a change set for a new stack or the <c>CREATE</c> type to create a
        /// change set for an existing stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.ChangeSetType")]
        public Amazon.CloudFormation.ChangeSetType ChangeSetType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description to help you identify this change set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ImportExistingResource
        /// <summary>
        /// <para>
        /// <para>Indicates if the change set imports resources that already exist.</para><note><para>This parameter can only import resources that have custom names in templates. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-name.html">name
        /// type</a> in the <i>CloudFormation User Guide</i>. To import resources that do not
        /// accept custom names, such as EC2 instances, use the resource import feature instead.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/resource-import.html">Import
        /// Amazon Web Services resources into a CloudFormation stack with a resource import</a>
        /// in the <i>CloudFormation User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImportExistingResources")]
        public System.Boolean? ImportExistingResource { get; set; }
        #endregion
        
        #region Parameter IncludeNestedStack
        /// <summary>
        /// <para>
        /// <para>Creates a change set for the all nested stacks specified in the template. The default
        /// behavior of this action is set to <c>False</c>. To include nested sets in a change
        /// set, specify <c>True</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeNestedStacks")]
        public System.Boolean? IncludeNestedStack { get; set; }
        #endregion
        
        #region Parameter NotificationARNs
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of Amazon SNS topics that CloudFormation associates
        /// with the stack. To remove all associated notification topics, specify an empty list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NotificationARNs { get; set; }
        #endregion
        
        #region Parameter OnStackFailure
        /// <summary>
        /// <para>
        /// <para>Determines what action will be taken if stack creation fails. If this parameter is
        /// specified, the <c>DisableRollback</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_ExecuteChangeSet.html">ExecuteChangeSet</a>
        /// API operation must not be specified. This must be one of these values:</para><ul><li><para><c>DELETE</c> - Deletes the change set if the stack creation fails. This is only
        /// valid when the <c>ChangeSetType</c> parameter is set to <c>CREATE</c>. If the deletion
        /// of the stack fails, the status of the stack is <c>DELETE_FAILED</c>.</para></li><li><para><c>DO_NOTHING</c> - if the stack creation fails, do nothing. This is equivalent to
        /// specifying <c>true</c> for the <c>DisableRollback</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_ExecuteChangeSet.html">ExecuteChangeSet</a>
        /// API operation.</para></li><li><para><c>ROLLBACK</c> - if the stack creation fails, roll back the stack. This is equivalent
        /// to specifying <c>false</c> for the <c>DisableRollback</c> parameter to the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/APIReference/API_ExecuteChangeSet.html">ExecuteChangeSet</a>
        /// API operation.</para></li></ul><para>For nested stacks, when the <c>OnStackFailure</c> parameter is set to <c>DELETE</c>
        /// for the change set for the parent stack, any failure in a child stack will cause the
        /// parent stack creation to fail and all stacks to be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.OnStackFailure")]
        public Amazon.CloudFormation.OnStackFailure OnStackFailure { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of <c>Parameter</c> structures that specify input parameters for the change
        /// set. For more information, see the <a>Parameter</a> data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter ResourcesToImport
        /// <summary>
        /// <para>
        /// <para>The resources to import into your stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CloudFormation.Model.ResourceToImport[] ResourcesToImport { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The template resource types that you have permissions to work with if you execute
        /// this change set, such as <c>AWS::EC2::Instance</c>, <c>AWS::EC2::*</c>, or <c>Custom::MyCustomInstance</c>.</para><para>If the list of resource types doesn't include a resource type that you're updating,
        /// the stack update fails. By default, CloudFormation grants permissions to all resource
        /// types. IAM uses this parameter for condition keys in IAM policies for CloudFormation.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html">Control
        /// access with Identity and Access Management</a> in the <i>CloudFormation User Guide</i>.</para><note><para>Only one of the <c>Capabilities</c> and <c>ResourceType</c> parameters can be specified.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTypes")]
        public System.String[] ResourceType { get; set; }
        #endregion
        
        #region Parameter RoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that CloudFormation assumes when executing
        /// the change set. CloudFormation uses the role's credentials to make calls on your behalf.
        /// CloudFormation uses this role for all future operations on the stack. Provided that
        /// users have permission to operate on the stack, CloudFormation uses this role even
        /// if the users don't have permission to pass it. Ensure that the role grants least permission.</para><para>If you don't specify a value, CloudFormation uses the role that was previously associated
        /// with the stack. If no role is available, CloudFormation uses a temporary session that
        /// is generated from your user credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleARN { get; set; }
        #endregion
        
        #region Parameter RollbackConfiguration
        /// <summary>
        /// <para>
        /// <para>The rollback triggers for CloudFormation to monitor during stack creation and updating
        /// operations, and for the specified monitoring period afterwards.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CloudFormation.Model.RollbackConfiguration RollbackConfiguration { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name or the unique ID of the stack for which you are creating a change set. CloudFormation
        /// generates the change set by comparing this stack's information with the information
        /// that you submit, such as a modified template or different parameter input values.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with this stack. CloudFormation also propagates these
        /// tags to resources in the stack. You can specify a maximum of 50 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>A structure that contains the body of the revised template, with a minimum length
        /// of 1 byte and a maximum length of 51,200 bytes. CloudFormation generates the change
        /// set by comparing this template with the template of the stack that you specified.</para><para>Conditional: You must specify only <c>TemplateBody</c> or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the revised template. The URL must point to
        /// a template (max size: 460,800 bytes) that's located in an Amazon S3 bucket or a Systems
        /// Manager document. CloudFormation generates the change set by comparing this template
        /// with the stack that you specified. The location for an Amazon S3 bucket must start
        /// with <c>https://</c>.</para><para>Conditional: You must specify only <c>TemplateBody</c> or <c>TemplateURL</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Whether to reuse the template that's associated with the stack to create the change
        /// set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UsePreviousTemplate { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <c>CreateChangeSet</c> request. Specify this token if
        /// you plan to retry requests so that CloudFormation knows that you're not attempting
        /// to create another change set with the same name. You might retry <c>CreateChangeSet</c>
        /// requests to ensure that CloudFormation successfully received them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.CreateChangeSetResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.CreateChangeSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFNChangeSet (CreateChangeSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.CreateChangeSetResponse, NewCFNChangeSetCmdlet>(Select) ??
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
            context.ChangeSetName = this.ChangeSetName;
            #if MODULAR
            if (this.ChangeSetName == null && ParameterWasBound(nameof(this.ChangeSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChangeSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChangeSetType = this.ChangeSetType;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ImportExistingResource = this.ImportExistingResource;
            context.IncludeNestedStack = this.IncludeNestedStack;
            if (this.NotificationARNs != null)
            {
                context.NotificationARNs = new List<System.String>(this.NotificationARNs);
            }
            context.OnStackFailure = this.OnStackFailure;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            if (this.ResourcesToImport != null)
            {
                context.ResourcesToImport = new List<Amazon.CloudFormation.Model.ResourceToImport>(this.ResourcesToImport);
            }
            if (this.ResourceType != null)
            {
                context.ResourceType = new List<System.String>(this.ResourceType);
            }
            context.RoleARN = this.RoleARN;
            context.RollbackConfiguration = this.RollbackConfiguration;
            context.StackName = this.StackName;
            #if MODULAR
            if (this.StackName == null && ParameterWasBound(nameof(this.StackName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CloudFormation.Model.CreateChangeSetRequest();
            
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.ChangeSetName != null)
            {
                request.ChangeSetName = cmdletContext.ChangeSetName;
            }
            if (cmdletContext.ChangeSetType != null)
            {
                request.ChangeSetType = cmdletContext.ChangeSetType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ImportExistingResource != null)
            {
                request.ImportExistingResources = cmdletContext.ImportExistingResource.Value;
            }
            if (cmdletContext.IncludeNestedStack != null)
            {
                request.IncludeNestedStacks = cmdletContext.IncludeNestedStack.Value;
            }
            if (cmdletContext.NotificationARNs != null)
            {
                request.NotificationARNs = cmdletContext.NotificationARNs;
            }
            if (cmdletContext.OnStackFailure != null)
            {
                request.OnStackFailure = cmdletContext.OnStackFailure;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.ResourcesToImport != null)
            {
                request.ResourcesToImport = cmdletContext.ResourcesToImport;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceTypes = cmdletContext.ResourceType;
            }
            if (cmdletContext.RoleARN != null)
            {
                request.RoleARN = cmdletContext.RoleARN;
            }
            if (cmdletContext.RollbackConfiguration != null)
            {
                request.RollbackConfiguration = cmdletContext.RollbackConfiguration;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
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
        
        private Amazon.CloudFormation.Model.CreateChangeSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.CreateChangeSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "CreateChangeSet");
            try
            {
                #if DESKTOP
                return client.CreateChangeSet(request);
                #elif CORECLR
                return client.CreateChangeSetAsync(request).GetAwaiter().GetResult();
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
            public System.String ChangeSetName { get; set; }
            public Amazon.CloudFormation.ChangeSetType ChangeSetType { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? ImportExistingResource { get; set; }
            public System.Boolean? IncludeNestedStack { get; set; }
            public List<System.String> NotificationARNs { get; set; }
            public Amazon.CloudFormation.OnStackFailure OnStackFailure { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public List<Amazon.CloudFormation.Model.ResourceToImport> ResourcesToImport { get; set; }
            public List<System.String> ResourceType { get; set; }
            public System.String RoleARN { get; set; }
            public Amazon.CloudFormation.Model.RollbackConfiguration RollbackConfiguration { get; set; }
            public System.String StackName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
            public System.Func<Amazon.CloudFormation.Model.CreateChangeSetResponse, NewCFNChangeSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
