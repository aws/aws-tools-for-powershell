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
    /// Updates the StackSet and associated stack instances in the specified accounts and
    /// Amazon Web Services Regions.
    /// 
    ///  
    /// <para>
    /// Even if the StackSet operation created by updating the StackSet fails (completely
    /// or partially, below or above a specified failure tolerance), the StackSet is updated
    /// with your changes. Subsequent <a>CreateStackInstances</a> calls on the specified StackSet
    /// use the updated StackSet.
    /// </para><note><para>
    /// The maximum number of organizational unit (OUs) supported by a <c>UpdateStackSet</c>
    /// operation is 50.
    /// </para><para>
    /// If you need more than 50, consider the following options:
    /// </para><ul><li><para><i>Batch processing:</i> If you don't want to expose your OU hierarchy, split up
    /// the operations into multiple calls with less than 50 OUs each.
    /// </para></li><li><para><i>Parent OU strategy:</i> If you don't mind exposing the OU hierarchy, target a
    /// parent OU that contains all desired child OUs.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Update", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStackSet API operation.", Operation = new[] {"UpdateStackSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateStackSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateStackSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeploymentTargets_AccountFilterType
        /// <summary>
        /// <para>
        /// <para>Refines which accounts will have stack operations performed on them by specifying
        /// how to use the <c>Accounts</c> and <c>OrganizationalUnitIds</c> properties together.</para><para>The following values determine how CloudFormation selects target accounts:</para><ul><li><para><c>INTERSECTION</c>: Performs stack operations only on specific individual accounts
        /// within the selected OUs. Only accounts that are both specified in the <c>Accounts</c>
        /// property and belong to the specified OUs will be targeted.</para></li><li><para><c>DIFFERENCE</c>: Performs stack operations on all accounts in the selected OUs
        /// except for specific accounts listed in the <c>Accounts</c> property. This enables
        /// you to exclude certain accounts within an OU, such as suspended accounts.</para></li><li><para><c>UNION</c>: Performs stack operations on the specified OUs plus additional individual
        /// accounts listed in the <c>Accounts</c> property. This is the default value if <c>AccountFilterType</c>
        /// is not provided. This lets you target an entire OU and individual accounts from a
        /// different OU in one request. Note that <c>UNION</c> is not supported for <c>CreateStackInstances</c>
        /// operations.</para></li><li><para><c>NONE</c>: Performs stack operations on all accounts in the specified organizational
        /// units (OUs).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.AccountFilterType")]
        public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
        #endregion
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The accounts in which to update associated stack instances.
        /// If you specify accounts, you must also specify the Amazon Web Services Regions in
        /// which to update StackSet instances.</para><para>To update <i>all</i> the stack instances associated with this StackSet, don't specify
        /// the <c>Accounts</c> or <c>Regions</c> properties.</para><para>If the StackSet update includes changes to the template (that is, if the <c>TemplateBody</c>
        /// or <c>TemplateURL</c> properties are specified), or the <c>Parameters</c> property,
        /// CloudFormation marks all stack instances with a status of <c>OUTDATED</c> prior to
        /// updating the stack instances in the specified accounts and Amazon Web Services Regions.
        /// If the StackSet update does not include changes to the template or parameters, CloudFormation
        /// updates the stack instances in the specified accounts and Amazon Web Services Regions,
        /// while leaving all other stack instances with their existing stack instance status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_Account
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account IDs where you want to perform stack operations. How
        /// these accounts are used depends on the <c>AccountFilterType</c> property.</para><para>If you have many account numbers, you can provide those accounts using the <c>AccountsUrl</c>
        /// property instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_Accounts")]
        public System.String[] DeploymentTargets_Account { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_AccountsUrl
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URL path to a file that contains a list of Amazon Web Services account
        /// IDs. The file format must be either <c>.csv</c> or <c>.txt</c>, and the data can be
        /// comma-separated or new-line-separated. There is currently a 10MB limit for the data
        /// (approximately 800,000 accounts).</para><para>This property serves the same purpose as <c>Accounts</c> but allows you to specify
        /// a large number of accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentTargets_AccountsUrl { get; set; }
        #endregion
        
        #region Parameter ManagedExecution_Active
        /// <summary>
        /// <para>
        /// <para>When <c>true</c>, CloudFormation performs non-conflicting operations concurrently
        /// and queues conflicting operations. After conflicting operations finish, CloudFormation
        /// starts queued operations in request order.</para><note><para>If there are already running or queued operations, CloudFormation queues all incoming
        /// operations even if they are non-conflicting.</para><para>You can't modify your StackSet's execution configuration while there are running or
        /// queued operations for that StackSet.</para></note><para>When <c>false</c> (default), StackSets performs one operation at a time in request
        /// order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedExecution_Active { get; set; }
        #endregion
        
        #region Parameter AdministrationRoleARN
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The Amazon Resource Name (ARN) of the IAM role to use to
        /// update this StackSet.</para><para>Specify an IAM role only if you are using customized administrator roles to control
        /// which users or groups can manage specific StackSets within the same administrator
        /// account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-self-managed.html">Grant
        /// self-managed permissions</a> in the <i>CloudFormation User Guide</i>.</para><para>If you specified a customized administrator role when you created the StackSet, you
        /// must specify a customized administrator role, even if it is the same customized administrator
        /// role used with this StackSet previously.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdministrationRoleARN { get; set; }
        #endregion
        
        #region Parameter CallAs
        /// <summary>
        /// <para>
        /// <para>[Service-managed permissions] Specifies whether you are acting as an account administrator
        /// in the organization's management account or as a delegated administrator in a member
        /// account.</para><para>By default, <c>SELF</c> is specified. Use <c>SELF</c> for StackSets with self-managed
        /// permissions.</para><ul><li><para>If you are signed in to the management account, specify <c>SELF</c>.</para></li><li><para>If you are signed in to a delegated administrator account, specify <c>DELEGATED_ADMIN</c>.</para><para>Your Amazon Web Services account must be registered as a delegated administrator in
        /// the management account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicitly acknowledge that your stack template contains certain
        /// capabilities in order for CloudFormation to update the StackSet and its associated
        /// stack instances.</para><ul><li><para><c>CAPABILITY_IAM</c> and <c>CAPABILITY_NAMED_IAM</c></para><para>Some stack templates might include resources that can affect permissions in your Amazon
        /// Web Services account, for example, by creating new IAM users. For those stacks sets,
        /// you must explicitly acknowledge this by specifying one of these capabilities.</para><para>The following IAM resources require you to specify either the <c>CAPABILITY_IAM</c>
        /// or <c>CAPABILITY_NAMED_IAM</c> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability.</para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <c>CAPABILITY_NAMED_IAM</c>.</para></li><li><para>If you don't specify either of these capabilities, CloudFormation returns an <c>InsufficientCapabilities</c>
        /// error.</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-accesskey.html">AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-group.html">AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-instanceprofile.html">AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-policy.html">AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-role.html">AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-user.html">AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/TemplateReference/aws-resource-iam-usertogroupaddition.html">AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/control-access-with-iam.html#using-iam-capabilities">Acknowledging
        /// IAM resources in CloudFormation templates</a>.</para></li><li><para><c>CAPABILITY_AUTO_EXPAND</c></para><para>Some templates reference macros. If your StackSet template references one or more
        /// macros, you must update the StackSet directly from the processed template, without
        /// first reviewing the resulting changes in a change set. To update the StackSet directly,
        /// you must acknowledge this capability. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Perform
        /// custom processing on CloudFormation templates with template macros</a>.</para><important><para>StackSets with service-managed permissions do not currently support the use of macros
        /// in templates. (This includes the <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-include.html">AWS::Include</a>
        /// and <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.) Even if you specify this capability
        /// for a StackSet with service-managed permissions, if you reference a macro in your
        /// template the StackSet operation will fail.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_DependsOn
        /// <summary>
        /// <para>
        /// <para>A list of StackSet ARNs that this StackSet depends on for auto-deployment operations.
        /// When auto-deployment is triggered, operations will be sequenced to ensure all dependencies
        /// complete successfully before this StackSet's operation begins.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AutoDeployment_DependsOn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A brief description of updates that you are making.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_Enabled
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, StackSets automatically deploys additional stack instances
        /// to Organizations accounts that are added to a target organization or organizational
        /// unit (OU) in the specified Regions. If an account is removed from a target organization
        /// or OU, StackSets deletes stack instances from the account in the specified Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeployment_Enabled { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleName
        /// <summary>
        /// <para>
        /// <para>[Self-managed permissions] The name of the IAM execution role to use to update the
        /// stack set. If you do not specify an execution role, CloudFormation uses the <c>AWSCloudFormationStackSetExecutionRole</c>
        /// role for the StackSet operation.</para><para>Specify an IAM role only if you are using customized execution roles to control which
        /// stack resources users and groups can include in their StackSets.</para><para>If you specify a customized execution role, CloudFormation uses that role to update
        /// the stack. If you do not specify a customized execution role, CloudFormation performs
        /// the update using the role previously associated with the StackSet, so long as you
        /// have permissions to perform operations on the StackSet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleName { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID for this StackSet operation.</para><para>The operation ID also functions as an idempotency token, to ensure that CloudFormation
        /// performs the StackSet operation only once, even if you retry the request multiple
        /// times. You might retry StackSet operation requests to ensure that CloudFormation successfully
        /// received them.</para><para>If you don't specify an operation ID, CloudFormation generates one automatically.</para><para>Repeating this StackSet operation with a new operation ID retries all stack instances
        /// whose status is <c>OUTDATED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how CloudFormation performs this StackSet operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter DeploymentTargets_OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The organization root ID or organizational unit (OU) IDs where you want to perform
        /// stack operations. CloudFormation will perform operations on accounts within these
        /// OUs and their child OUs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentTargets_OrganizationalUnitIds")]
        public System.String[] DeploymentTargets_OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of input parameters for the StackSet template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter PermissionModel
        /// <summary>
        /// <para>
        /// <para>Describes how the IAM roles required for StackSet operations are created. You cannot
        /// modify <c>PermissionModel</c> if there are stack instances associated with your stack
        /// set.</para><ul><li><para>With <c>self-managed</c> permissions, you must create the administrator and execution
        /// roles required to deploy to target accounts. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-self-managed.html">Grant
        /// self-managed permissions</a>.</para></li><li><para>With <c>service-managed</c> permissions, StackSets automatically creates the IAM roles
        /// required to deploy to accounts managed by Organizations. For more information, see
        /// <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-activate-trusted-access.html">Activate
        /// trusted access for StackSets with Organizations</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.PermissionModels")]
        public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
        #endregion
        
        #region Parameter StackRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Regions in which to update associated stack instances. If
        /// you specify Regions, you must also specify accounts in which to update StackSet instances.</para><para>To update <i>all</i> the stack instances associated with this StackSet, do not specify
        /// the <c>Accounts</c> or <c>Regions</c> properties.</para><para>If the StackSet update includes changes to the template (that is, if the <c>TemplateBody</c>
        /// or <c>TemplateURL</c> properties are specified), or the <c>Parameters</c> property,
        /// CloudFormation marks all stack instances with a status of <c>OUTDATED</c> prior to
        /// updating the stack instances in the specified accounts and Regions. If the StackSet
        /// update does not include changes to the template or parameters, CloudFormation updates
        /// the stack instances in the specified accounts and Regions, while leaving all other
        /// stack instances with their existing stack instance status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StackRegion { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_RetainStacksOnAccountRemoval
        /// <summary>
        /// <para>
        /// <para>If set to <c>true</c>, stack resources are retained when an account is removed from
        /// a target organization or OU. If set to <c>false</c>, stack resources are deleted.
        /// Specify only if <c>Enabled</c> is set to <c>True</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the StackSet that you want to update.</para>
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
        public System.String StackSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with this StackSet and the stacks created from it.
        /// CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. You can specify a maximum number of 50 tags.</para><para>If you specify tags for this parameter, those tags replace any list of tags that are
        /// currently associated with this StackSet. This means:</para><ul><li><para>If you don't specify this parameter, CloudFormation doesn't modify the stack's tags.</para></li><li><para>If you specify <i>any</i> tags using this parameter, you must specify <i>all</i> the
        /// tags that you want associated with this StackSet, even tags you've specified before
        /// (for example, when creating the StackSet or during a previous update of the StackSet.).
        /// Any tags that you don't include in the updated list of tags are removed from the StackSet,
        /// and therefore from the stacks and resources as well.</para></li><li><para>If you specify an empty value, CloudFormation removes all currently associated tags.</para></li></ul><para>If you specify new tags as part of an <c>UpdateStackSet</c> action, CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you omit
        /// tags that are currently associated with the StackSet from the list of tags you specify,
        /// CloudFormation assumes that you want to remove those tags from the StackSet, and checks
        /// to see if you have permission to untag resources. If you don't have the necessary
        /// permission(s), the entire <c>UpdateStackSet</c> action fails with an <c>access denied</c>
        /// error, and the StackSet is not updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudFormation.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The structure that contains the template body, with a minimum length of 1 byte and
        /// a maximum length of 51,200 bytes.</para><para>Conditional: You must specify only one of the following parameters: <c>TemplateBody</c>
        /// or <c>TemplateURL</c>—or set <c>UsePreviousTemplate</c> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The URL of a file that contains the template body. The URL must point to a template
        /// (maximum size: 1 MB) that is located in an Amazon S3 bucket or a Systems Manager document.
        /// The location for an Amazon S3 bucket must start with <c>https://</c>. S3 static website
        /// URLs are not supported.</para><para>Conditional: You must specify only one of the following parameters: <c>TemplateBody</c>
        /// or <c>TemplateURL</c>—or set <c>UsePreviousTemplate</c> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Use the existing template that's associated with the StackSet that you're updating.</para><para>Conditional: You must specify only one of the following parameters: <c>TemplateBody</c>
        /// or <c>TemplateURL</c>—or set <c>UsePreviousTemplate</c> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UsePreviousTemplate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OperationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.UpdateStackSetResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.UpdateStackSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OperationId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackSetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackSetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CFNStackSet (UpdateStackSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.UpdateStackSetResponse, UpdateCFNStackSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackSetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Account != null)
            {
                context.Account = new List<System.String>(this.Account);
            }
            context.AdministrationRoleARN = this.AdministrationRoleARN;
            if (this.AutoDeployment_DependsOn != null)
            {
                context.AutoDeployment_DependsOn = new List<System.String>(this.AutoDeployment_DependsOn);
            }
            context.AutoDeployment_Enabled = this.AutoDeployment_Enabled;
            context.AutoDeployment_RetainStacksOnAccountRemoval = this.AutoDeployment_RetainStacksOnAccountRemoval;
            context.CallAs = this.CallAs;
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.DeploymentTargets_AccountFilterType = this.DeploymentTargets_AccountFilterType;
            if (this.DeploymentTargets_Account != null)
            {
                context.DeploymentTargets_Account = new List<System.String>(this.DeploymentTargets_Account);
            }
            context.DeploymentTargets_AccountsUrl = this.DeploymentTargets_AccountsUrl;
            if (this.DeploymentTargets_OrganizationalUnitId != null)
            {
                context.DeploymentTargets_OrganizationalUnitId = new List<System.String>(this.DeploymentTargets_OrganizationalUnitId);
            }
            context.Description = this.Description;
            context.ExecutionRoleName = this.ExecutionRoleName;
            context.ManagedExecution_Active = this.ManagedExecution_Active;
            context.OperationId = this.OperationId;
            context.OperationPreference = this.OperationPreference;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            context.PermissionModel = this.PermissionModel;
            if (this.StackRegion != null)
            {
                context.StackRegion = new List<System.String>(this.StackRegion);
            }
            context.StackSetName = this.StackSetName;
            #if MODULAR
            if (this.StackSetName == null && ParameterWasBound(nameof(this.StackSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudFormation.Model.UpdateStackSetRequest();
            
            if (cmdletContext.Account != null)
            {
                request.Accounts = cmdletContext.Account;
            }
            if (cmdletContext.AdministrationRoleARN != null)
            {
                request.AdministrationRoleARN = cmdletContext.AdministrationRoleARN;
            }
            
             // populate AutoDeployment
            var requestAutoDeploymentIsNull = true;
            request.AutoDeployment = new Amazon.CloudFormation.Model.AutoDeployment();
            List<System.String> requestAutoDeployment_autoDeployment_DependsOn = null;
            if (cmdletContext.AutoDeployment_DependsOn != null)
            {
                requestAutoDeployment_autoDeployment_DependsOn = cmdletContext.AutoDeployment_DependsOn;
            }
            if (requestAutoDeployment_autoDeployment_DependsOn != null)
            {
                request.AutoDeployment.DependsOn = requestAutoDeployment_autoDeployment_DependsOn;
                requestAutoDeploymentIsNull = false;
            }
            System.Boolean? requestAutoDeployment_autoDeployment_Enabled = null;
            if (cmdletContext.AutoDeployment_Enabled != null)
            {
                requestAutoDeployment_autoDeployment_Enabled = cmdletContext.AutoDeployment_Enabled.Value;
            }
            if (requestAutoDeployment_autoDeployment_Enabled != null)
            {
                request.AutoDeployment.Enabled = requestAutoDeployment_autoDeployment_Enabled.Value;
                requestAutoDeploymentIsNull = false;
            }
            System.Boolean? requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval = null;
            if (cmdletContext.AutoDeployment_RetainStacksOnAccountRemoval != null)
            {
                requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval = cmdletContext.AutoDeployment_RetainStacksOnAccountRemoval.Value;
            }
            if (requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval != null)
            {
                request.AutoDeployment.RetainStacksOnAccountRemoval = requestAutoDeployment_autoDeployment_RetainStacksOnAccountRemoval.Value;
                requestAutoDeploymentIsNull = false;
            }
             // determine if request.AutoDeployment should be set to null
            if (requestAutoDeploymentIsNull)
            {
                request.AutoDeployment = null;
            }
            if (cmdletContext.CallAs != null)
            {
                request.CallAs = cmdletContext.CallAs;
            }
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            
             // populate DeploymentTargets
            var requestDeploymentTargetsIsNull = true;
            request.DeploymentTargets = new Amazon.CloudFormation.Model.DeploymentTargets();
            Amazon.CloudFormation.AccountFilterType requestDeploymentTargets_deploymentTargets_AccountFilterType = null;
            if (cmdletContext.DeploymentTargets_AccountFilterType != null)
            {
                requestDeploymentTargets_deploymentTargets_AccountFilterType = cmdletContext.DeploymentTargets_AccountFilterType;
            }
            if (requestDeploymentTargets_deploymentTargets_AccountFilterType != null)
            {
                request.DeploymentTargets.AccountFilterType = requestDeploymentTargets_deploymentTargets_AccountFilterType;
                requestDeploymentTargetsIsNull = false;
            }
            List<System.String> requestDeploymentTargets_deploymentTargets_Account = null;
            if (cmdletContext.DeploymentTargets_Account != null)
            {
                requestDeploymentTargets_deploymentTargets_Account = cmdletContext.DeploymentTargets_Account;
            }
            if (requestDeploymentTargets_deploymentTargets_Account != null)
            {
                request.DeploymentTargets.Accounts = requestDeploymentTargets_deploymentTargets_Account;
                requestDeploymentTargetsIsNull = false;
            }
            System.String requestDeploymentTargets_deploymentTargets_AccountsUrl = null;
            if (cmdletContext.DeploymentTargets_AccountsUrl != null)
            {
                requestDeploymentTargets_deploymentTargets_AccountsUrl = cmdletContext.DeploymentTargets_AccountsUrl;
            }
            if (requestDeploymentTargets_deploymentTargets_AccountsUrl != null)
            {
                request.DeploymentTargets.AccountsUrl = requestDeploymentTargets_deploymentTargets_AccountsUrl;
                requestDeploymentTargetsIsNull = false;
            }
            List<System.String> requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = null;
            if (cmdletContext.DeploymentTargets_OrganizationalUnitId != null)
            {
                requestDeploymentTargets_deploymentTargets_OrganizationalUnitId = cmdletContext.DeploymentTargets_OrganizationalUnitId;
            }
            if (requestDeploymentTargets_deploymentTargets_OrganizationalUnitId != null)
            {
                request.DeploymentTargets.OrganizationalUnitIds = requestDeploymentTargets_deploymentTargets_OrganizationalUnitId;
                requestDeploymentTargetsIsNull = false;
            }
             // determine if request.DeploymentTargets should be set to null
            if (requestDeploymentTargetsIsNull)
            {
                request.DeploymentTargets = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleName != null)
            {
                request.ExecutionRoleName = cmdletContext.ExecutionRoleName;
            }
            
             // populate ManagedExecution
            var requestManagedExecutionIsNull = true;
            request.ManagedExecution = new Amazon.CloudFormation.Model.ManagedExecution();
            System.Boolean? requestManagedExecution_managedExecution_Active = null;
            if (cmdletContext.ManagedExecution_Active != null)
            {
                requestManagedExecution_managedExecution_Active = cmdletContext.ManagedExecution_Active.Value;
            }
            if (requestManagedExecution_managedExecution_Active != null)
            {
                request.ManagedExecution.Active = requestManagedExecution_managedExecution_Active.Value;
                requestManagedExecutionIsNull = false;
            }
             // determine if request.ManagedExecution should be set to null
            if (requestManagedExecutionIsNull)
            {
                request.ManagedExecution = null;
            }
            if (cmdletContext.OperationId != null)
            {
                request.OperationId = cmdletContext.OperationId;
            }
            if (cmdletContext.OperationPreference != null)
            {
                request.OperationPreferences = cmdletContext.OperationPreference;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.PermissionModel != null)
            {
                request.PermissionModel = cmdletContext.PermissionModel;
            }
            if (cmdletContext.StackRegion != null)
            {
                request.Regions = cmdletContext.StackRegion;
            }
            if (cmdletContext.StackSetName != null)
            {
                request.StackSetName = cmdletContext.StackSetName;
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
        
        private Amazon.CloudFormation.Model.UpdateStackSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.UpdateStackSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "UpdateStackSet");
            try
            {
                #if DESKTOP
                return client.UpdateStackSet(request);
                #elif CORECLR
                return client.UpdateStackSetAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Account { get; set; }
            public System.String AdministrationRoleARN { get; set; }
            public List<System.String> AutoDeployment_DependsOn { get; set; }
            public System.Boolean? AutoDeployment_Enabled { get; set; }
            public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public List<System.String> Capability { get; set; }
            public Amazon.CloudFormation.AccountFilterType DeploymentTargets_AccountFilterType { get; set; }
            public List<System.String> DeploymentTargets_Account { get; set; }
            public System.String DeploymentTargets_AccountsUrl { get; set; }
            public List<System.String> DeploymentTargets_OrganizationalUnitId { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleName { get; set; }
            public System.Boolean? ManagedExecution_Active { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
            public List<System.String> StackRegion { get; set; }
            public System.String StackSetName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Boolean? UsePreviousTemplate { get; set; }
            public System.Func<Amazon.CloudFormation.Model.UpdateStackSetResponse, UpdateCFNStackSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OperationId;
        }
        
    }
}
