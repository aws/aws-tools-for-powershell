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
    /// Creates a stack set.
    /// </summary>
    [Cmdlet("New", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation CreateStackSet API operation.", Operation = new[] {"CreateStackSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.CreateStackSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.CreateStackSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.CreateStackSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter ManagedExecution_Active
        /// <summary>
        /// <para>
        /// <para>When <code>true</code>, StackSets performs non-conflicting operations concurrently
        /// and queues conflicting operations. After conflicting operations finish, StackSets
        /// starts queued operations in request order.</para><note><para>If there are already running or queued operations, StackSets queues all incoming operations
        /// even if they are non-conflicting.</para><para>You can't modify your stack set's execution configuration while there are running
        /// or queued operations for that stack set.</para></note><para>When <code>false</code> (default), StackSets performs one operation at a time in request
        /// order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ManagedExecution_Active { get; set; }
        #endregion
        
        #region Parameter AdministrationRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role to use to create this stack set.</para><para>Specify an IAM role only if you are using customized administrator roles to control
        /// which users or groups can manage specific stack sets within the same administrator
        /// account. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs.html">Prerequisites:
        /// Granting Permissions for Stack Set Operations</a> in the <i>CloudFormation User Guide</i>.</para>
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
        /// account.</para><para>By default, <code>SELF</code> is specified. Use <code>SELF</code> for stack sets with
        /// self-managed permissions.</para><ul><li><para>To create a stack set with service-managed permissions while signed in to the management
        /// account, specify <code>SELF</code>.</para></li><li><para>To create a stack set with service-managed permissions while signed in to a delegated
        /// administrator account, specify <code>DELEGATED_ADMIN</code>.</para><para>Your Amazon Web Services account must be registered as a delegated admin in the management
        /// account. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-orgs-delegated-admin.html">Register
        /// a delegated administrator</a> in the <i>CloudFormation User Guide</i>.</para></li></ul><para>Stack sets with service-managed permissions are created in the management account,
        /// including stack sets that are created by delegated administrators.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.CallAs")]
        public Amazon.CloudFormation.CallAs CallAs { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicitly acknowledge that your stack set template contains
        /// certain capabilities in order for CloudFormation to create the stack set and related
        /// stack instances.</para><ul><li><para><code>CAPABILITY_IAM</code> and <code>CAPABILITY_NAMED_IAM</code></para><para>Some stack templates might include resources that can affect permissions in your Amazon
        /// Web Services account; for example, by creating new Identity and Access Management
        /// (IAM) users. For those stack sets, you must explicitly acknowledge this by specifying
        /// one of these capabilities.</para><para>The following IAM resources require you to specify either the <code>CAPABILITY_IAM</code>
        /// or <code>CAPABILITY_NAMED_IAM</code> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability.</para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <code>CAPABILITY_NAMED_IAM</code>.</para></li><li><para>If you don't specify either of these capabilities, CloudFormation returns an <code>InsufficientCapabilities</code>
        /// error.</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-group.html">
        /// AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-policy.html">
        /// AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-user.html">
        /// AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-addusertogroup.html">AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in CloudFormation Templates</a>.</para></li><li><para><code>CAPABILITY_AUTO_EXPAND</code></para><para>Some templates reference macros. If your stack set template references one or more
        /// macros, you must create the stack set directly from the processed template, without
        /// first reviewing the resulting changes in a change set. To create the stack set directly,
        /// you must acknowledge this capability. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Using
        /// CloudFormation Macros to Perform Custom Processing on Templates</a>.</para><important><para>Stack sets with service-managed permissions don't currently support the use of macros
        /// in templates. (This includes the <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by CloudFormation.) Even if you specify this capability
        /// for a stack set with service-managed permissions, if you reference a macro in your
        /// template the stack set operation will fail.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this <code>CreateStackSet</code> request. Specify this token
        /// if you plan to retry requests so that CloudFormation knows that you're not attempting
        /// to create another stack set with the same name. You might retry <code>CreateStackSet</code>
        /// requests to ensure that CloudFormation successfully received them.</para><para>If you don't specify an operation ID, the SDK generates one automatically.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the stack set. You can use the description to identify the stack
        /// set's purpose or other important information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_Enabled
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, StackSets automatically deploys additional stack instances
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
        /// <para>The name of the IAM execution role to use to create the stack set. If you do not specify
        /// an execution role, CloudFormation uses the <code>AWSCloudFormationStackSetExecutionRole</code>
        /// role for the stack set operation.</para><para>Specify an IAM role only if you are using customized execution roles to control which
        /// stack resources users and groups can include in their stack sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleName { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>The input parameters for the stack set template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter PermissionModel
        /// <summary>
        /// <para>
        /// <para>Describes how the IAM roles required for stack set operations are created. By default,
        /// <code>SELF-MANAGED</code> is specified.</para><ul><li><para>With <code>self-managed</code> permissions, you must create the administrator and
        /// execution roles required to deploy to target accounts. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-self-managed.html">Grant
        /// Self-Managed Stack Set Permissions</a>.</para></li><li><para>With <code>service-managed</code> permissions, StackSets automatically creates the
        /// IAM roles required to deploy to accounts managed by Organizations. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs-service-managed.html">Grant
        /// Service-Managed Stack Set Permissions</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudFormation.PermissionModels")]
        public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
        #endregion
        
        #region Parameter AutoDeployment_RetainStacksOnAccountRemoval
        /// <summary>
        /// <para>
        /// <para>If set to <code>true</code>, stack resources are retained when an account is removed
        /// from a target organization or OU. If set to <code>false</code>, stack resources are
        /// deleted. Specify only if <code>Enabled</code> is set to <code>True</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID you are importing into a new stack set. Specify the Amazon Resource Name
        /// (ARN) of the stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name to associate with the stack set. The name must be unique in the Region where
        /// you create your stack set.</para><note><para>A stack name can contain only alphanumeric characters (case-sensitive) and hyphens.
        /// It must start with an alphabetic character and can't be longer than 128 characters.</para></note>
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
        /// <para>The key-value pairs to associate with this stack set and the stacks created from it.
        /// CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. A maximum number of 50 tags can be specified.</para><para>If you specify tags as part of a <code>CreateStackSet</code> action, CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you don't,
        /// the entire <code>CreateStackSet</code> action fails with an <code>access denied</code>
        /// error, and the stack set is not created.</para>
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
        /// a maximum length of 51,200 bytes. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.</para><para>Conditional: You must specify either the TemplateBody or the TemplateURL parameter,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the template body. The URL must point to a
        /// template (maximum size: 460,800 bytes) that's located in an Amazon S3 bucket or a
        /// Systems Manager document. For more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the CloudFormation User Guide.</para><para>Conditional: You must specify either the TemplateBody or the TemplateURL parameter,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StackSetId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudFormation.Model.CreateStackSetResponse).
        /// Specifying the name of a property of type Amazon.CloudFormation.Model.CreateStackSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StackSetId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CFNStackSet (CreateStackSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudFormation.Model.CreateStackSetResponse, NewCFNStackSetCmdlet>(Select) ??
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
            context.AdministrationRoleARN = this.AdministrationRoleARN;
            context.AutoDeployment_Enabled = this.AutoDeployment_Enabled;
            context.AutoDeployment_RetainStacksOnAccountRemoval = this.AutoDeployment_RetainStacksOnAccountRemoval;
            context.CallAs = this.CallAs;
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Description = this.Description;
            context.ExecutionRoleName = this.ExecutionRoleName;
            context.ManagedExecution_Active = this.ManagedExecution_Active;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
            context.PermissionModel = this.PermissionModel;
            context.StackId = this.StackId;
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
            
            if (cmdletContext.AdministrationRoleARN != null)
            {
                request.AdministrationRoleARN = cmdletContext.AdministrationRoleARN;
            }
            
             // populate AutoDeployment
            var requestAutoDeploymentIsNull = true;
            request.AutoDeployment = new Amazon.CloudFormation.Model.AutoDeployment();
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
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
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
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.PermissionModel != null)
            {
                request.PermissionModel = cmdletContext.PermissionModel;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
        
        private Amazon.CloudFormation.Model.CreateStackSetResponse CallAWSServiceOperation(IAmazonCloudFormation client, Amazon.CloudFormation.Model.CreateStackSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudFormation", "CreateStackSet");
            try
            {
                #if DESKTOP
                return client.CreateStackSet(request);
                #elif CORECLR
                return client.CreateStackSetAsync(request).GetAwaiter().GetResult();
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
            public System.String AdministrationRoleARN { get; set; }
            public System.Boolean? AutoDeployment_Enabled { get; set; }
            public System.Boolean? AutoDeployment_RetainStacksOnAccountRemoval { get; set; }
            public Amazon.CloudFormation.CallAs CallAs { get; set; }
            public List<System.String> Capability { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleName { get; set; }
            public System.Boolean? ManagedExecution_Active { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
            public Amazon.CloudFormation.PermissionModels PermissionModel { get; set; }
            public System.String StackId { get; set; }
            public System.String StackSetName { get; set; }
            public List<Amazon.CloudFormation.Model.Tag> Tag { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateURL { get; set; }
            public System.Func<Amazon.CloudFormation.Model.CreateStackSetResponse, NewCFNStackSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StackSetId;
        }
        
    }
}
