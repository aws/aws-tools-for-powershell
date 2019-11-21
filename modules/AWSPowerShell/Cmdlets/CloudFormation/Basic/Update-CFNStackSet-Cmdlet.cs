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
    /// Updates the stack set, and associated stack instances in the specified accounts and
    /// regions.
    /// 
    ///  
    /// <para>
    /// Even if the stack set operation created by updating the stack set fails (completely
    /// or partially, below or above a specified failure tolerance), the stack set is updated
    /// with your changes. Subsequent <a>CreateStackInstances</a> calls on the specified stack
    /// set use the updated stack set.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CFNStackSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS CloudFormation UpdateStackSet API operation.", Operation = new[] {"UpdateStackSet"}, SelectReturnType = typeof(Amazon.CloudFormation.Model.UpdateStackSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudFormation.Model.UpdateStackSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudFormation.Model.UpdateStackSetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCFNStackSetCmdlet : AmazonCloudFormationClientCmdlet, IExecutor
    {
        
        #region Parameter Account
        /// <summary>
        /// <para>
        /// <para>The accounts in which to update associated stack instances. If you specify accounts,
        /// you must also specify the regions in which to update stack set instances.</para><para>To update <i>all</i> the stack instances associated with this stack set, do not specify
        /// the <code>Accounts</code> or <code>Regions</code> properties.</para><para>If the stack set update includes changes to the template (that is, if the <code>TemplateBody</code>
        /// or <code>TemplateURL</code> properties are specified), or the <code>Parameters</code>
        /// property, AWS CloudFormation marks all stack instances with a status of <code>OUTDATED</code>
        /// prior to updating the stack instances in the specified accounts and regions. If the
        /// stack set update does not include changes to the template or parameters, AWS CloudFormation
        /// updates the stack instances in the specified accounts and regions, while leaving all
        /// other stack instances with their existing stack instance status. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Accounts")]
        public System.String[] Account { get; set; }
        #endregion
        
        #region Parameter AdministrationRoleARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the IAM role to use to update this stack set.</para><para>Specify an IAM role only if you are using customized administrator roles to control
        /// which users or groups can manage specific stack sets within the same administrator
        /// account. For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/stacksets-prereqs.html">Granting
        /// Permissions for Stack Set Operations</a> in the <i>AWS CloudFormation User Guide</i>.</para><para>If you specified a customized administrator role when you created the stack set, you
        /// must specify a customized administrator role, even if it is the same customized administrator
        /// role used with this stack set previously.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdministrationRoleARN { get; set; }
        #endregion
        
        #region Parameter Capability
        /// <summary>
        /// <para>
        /// <para>In some cases, you must explicity acknowledge that your stack template contains certain
        /// capabilities in order for AWS CloudFormation to update the stack set and its associated
        /// stack instances.</para><ul><li><para><code>CAPABILITY_IAM</code> and <code>CAPABILITY_NAMED_IAM</code></para><para>Some stack templates might include resources that can affect permissions in your AWS
        /// account; for example, by creating new AWS Identity and Access Management (IAM) users.
        /// For those stacks sets, you must explicitly acknowledge this by specifying one of these
        /// capabilities.</para><para>The following IAM resources require you to specify either the <code>CAPABILITY_IAM</code>
        /// or <code>CAPABILITY_NAMED_IAM</code> capability.</para><ul><li><para>If you have IAM resources, you can specify either capability. </para></li><li><para>If you have IAM resources with custom names, you <i>must</i> specify <code>CAPABILITY_NAMED_IAM</code>.
        /// </para></li><li><para>If you don't specify either of these capabilities, AWS CloudFormation returns an <code>InsufficientCapabilities</code>
        /// error.</para></li></ul><para>If your stack template contains these resources, we recommend that you review all
        /// permissions associated with them and edit their permissions if necessary.</para><ul><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-accesskey.html">
        /// AWS::IAM::AccessKey</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-group.html">
        /// AWS::IAM::Group</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-instanceprofile.html">
        /// AWS::IAM::InstanceProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-policy.html">
        /// AWS::IAM::Policy</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-resource-iam-role.html">
        /// AWS::IAM::Role</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-user.html">
        /// AWS::IAM::User</a></para></li><li><para><a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/aws-properties-iam-addusertogroup.html">
        /// AWS::IAM::UserToGroupAddition</a></para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/using-iam-template.html#capabilities">Acknowledging
        /// IAM Resources in AWS CloudFormation Templates</a>.</para></li><li><para><code>CAPABILITY_AUTO_EXPAND</code></para><para>Some templates contain macros. If your stack template contains one or more macros,
        /// and you choose to update a stack directly from the processed template, without first
        /// reviewing the resulting changes in a change set, you must acknowledge this capability.
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-macros.html">Using
        /// AWS CloudFormation Macros to Perform Custom Processing on Templates</a>.</para><important><para>Stack sets do not currently support macros in stack templates. (This includes the
        /// <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/create-reusable-transform-function-snippets-and-add-to-your-template-with-aws-include-transform.html">AWS::Include</a>
        /// and <a href="http://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/transform-aws-serverless.html">AWS::Serverless</a>
        /// transforms, which are macros hosted by AWS CloudFormation.) Even if you specify this
        /// capability, if you include a macro in your template the stack set operation will fail.</para></important></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capabilities")]
        public System.String[] Capability { get; set; }
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
        
        #region Parameter ExecutionRoleName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM execution role to use to update the stack set. If you do not specify
        /// an execution role, AWS CloudFormation uses the <code>AWSCloudFormationStackSetExecutionRole</code>
        /// role for the stack set operation.</para><para>Specify an IAM role only if you are using customized execution roles to control which
        /// stack resources users and groups can include in their stack sets. </para><para> If you specify a customized execution role, AWS CloudFormation uses that role to
        /// update the stack. If you do not specify a customized execution role, AWS CloudFormation
        /// performs the update using the role previously associated with the stack set, so long
        /// as you have permissions to perform operations on the stack set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleName { get; set; }
        #endregion
        
        #region Parameter OperationId
        /// <summary>
        /// <para>
        /// <para>The unique ID for this stack set operation. </para><para>The operation ID also functions as an idempotency token, to ensure that AWS CloudFormation
        /// performs the stack set operation only once, even if you retry the request multiple
        /// times. You might retry stack set operation requests to ensure that AWS CloudFormation
        /// successfully received them.</para><para>If you don't specify an operation ID, AWS CloudFormation generates one automatically.</para><para>Repeating this stack set operation with a new operation ID retries all stack instances
        /// whose status is <code>OUTDATED</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OperationId { get; set; }
        #endregion
        
        #region Parameter OperationPreference
        /// <summary>
        /// <para>
        /// <para>Preferences for how AWS CloudFormation performs this stack set operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationPreferences")]
        public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of input parameters for the stack set template. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public Amazon.CloudFormation.Model.Parameter[] Parameter { get; set; }
        #endregion
        
        #region Parameter StackRegion
        /// <summary>
        /// <para>
        /// <para>The regions in which to update associated stack instances. If you specify regions,
        /// you must also specify accounts in which to update stack set instances.</para><para>To update <i>all</i> the stack instances associated with this stack set, do not specify
        /// the <code>Accounts</code> or <code>Regions</code> properties.</para><para>If the stack set update includes changes to the template (that is, if the <code>TemplateBody</code>
        /// or <code>TemplateURL</code> properties are specified), or the <code>Parameters</code>
        /// property, AWS CloudFormation marks all stack instances with a status of <code>OUTDATED</code>
        /// prior to updating the stack instances in the specified accounts and regions. If the
        /// stack set update does not include changes to the template or parameters, AWS CloudFormation
        /// updates the stack instances in the specified accounts and regions, while leaving all
        /// other stack instances with their existing stack instance status. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] StackRegion { get; set; }
        #endregion
        
        #region Parameter StackSetName
        /// <summary>
        /// <para>
        /// <para>The name or unique ID of the stack set that you want to update.</para>
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
        /// AWS CloudFormation also propagates these tags to supported resources that are created
        /// in the stacks. You can specify a maximum number of 50 tags.</para><para>If you specify tags for this parameter, those tags replace any list of tags that are
        /// currently associated with this stack set. This means:</para><ul><li><para>If you don't specify this parameter, AWS CloudFormation doesn't modify the stack's
        /// tags. </para></li><li><para>If you specify <i>any</i> tags using this parameter, you must specify <i>all</i> the
        /// tags that you want associated with this stack set, even tags you've specifed before
        /// (for example, when creating the stack set or during a previous update of the stack
        /// set.). Any tags that you don't include in the updated list of tags are removed from
        /// the stack set, and therefore from the stacks and resources as well. </para></li><li><para>If you specify an empty value, AWS CloudFormation removes all currently associated
        /// tags.</para></li></ul><para>If you specify new tags as part of an <code>UpdateStackSet</code> action, AWS CloudFormation
        /// checks to see if you have the required IAM permission to tag resources. If you omit
        /// tags that are currently associated with the stack set from the list of tags you specify,
        /// AWS CloudFormation assumes that you want to remove those tags from the stack set,
        /// and checks to see if you have permission to untag resources. If you don't have the
        /// necessary permission(s), the entire <code>UpdateStackSet</code> action fails with
        /// an <code>access denied</code> error, and the stack set is not updated.</para>
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
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateURL
        /// <summary>
        /// <para>
        /// <para>The location of the file that contains the template body. The URL must point to a
        /// template (maximum size: 460,800 bytes) that is located in an Amazon S3 bucket. For
        /// more information, see <a href="https://docs.aws.amazon.com/AWSCloudFormation/latest/UserGuide/template-anatomy.html">Template
        /// Anatomy</a> in the AWS CloudFormation User Guide.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateURL { get; set; }
        #endregion
        
        #region Parameter UsePreviousTemplate
        /// <summary>
        /// <para>
        /// <para>Use the existing template that's associated with the stack set that you're updating.</para><para>Conditional: You must specify only one of the following parameters: <code>TemplateBody</code>
        /// or <code>TemplateURL</code>—or set <code>UsePreviousTemplate</code> to true. </para>
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
            if (this.Capability != null)
            {
                context.Capability = new List<System.String>(this.Capability);
            }
            context.Description = this.Description;
            context.ExecutionRoleName = this.ExecutionRoleName;
            context.OperationId = this.OperationId;
            context.OperationPreference = this.OperationPreference;
            if (this.Parameter != null)
            {
                context.Parameter = new List<Amazon.CloudFormation.Model.Parameter>(this.Parameter);
            }
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
            if (cmdletContext.Capability != null)
            {
                request.Capabilities = cmdletContext.Capability;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleName != null)
            {
                request.ExecutionRoleName = cmdletContext.ExecutionRoleName;
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
            public List<System.String> Capability { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleName { get; set; }
            public System.String OperationId { get; set; }
            public Amazon.CloudFormation.Model.StackSetOperationPreferences OperationPreference { get; set; }
            public List<Amazon.CloudFormation.Model.Parameter> Parameter { get; set; }
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
