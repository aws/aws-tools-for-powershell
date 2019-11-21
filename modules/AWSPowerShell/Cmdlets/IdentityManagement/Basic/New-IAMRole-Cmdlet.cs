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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Creates a new role for your AWS account. For more information about roles, go to <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/WorkingWithRoles.html">IAM
    /// Roles</a>. For information about limitations on role names and the number of roles
    /// you can create, go to <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/LimitationsOnEntities.html">Limitations
    /// on IAM Entities</a> in the <i>IAM User Guide</i>.
    /// </summary>
    [Cmdlet("New", "IAMRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.Role")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateRole API operation.", Operation = new[] {"CreateRole"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateRoleResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.Role or Amazon.IdentityManagement.Model.CreateRoleResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.Role object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateRoleResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIAMRoleCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AssumeRolePolicyDocument
        /// <summary>
        /// <para>
        /// <para>The trust relationship policy document that grants an entity permission to assume
        /// the role.</para><para>In IAM, you must provide a JSON policy that has been converted to a string. However,
        /// for AWS CloudFormation templates formatted in YAML, you can provide the policy in
        /// JSON or YAML format. AWS CloudFormation always converts a YAML policy to JSON format
        /// before submitting it to IAM.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> used to validate this
        /// parameter is a string of characters consisting of the following:</para><ul><li><para>Any printable ASCII character ranging from the space character (\u0020) through the
        /// end of the ASCII character range</para></li><li><para>The printable characters in the Basic Latin and Latin-1 Supplement character set (through
        /// \u00FF)</para></li><li><para>The special characters tab (\u0009), line feed (\u000A), and carriage return (\u000D)</para></li></ul><para> Upon success, the response includes the same trust policy in JSON format.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AssumeRolePolicyDocument { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MaxSessionDuration
        /// <summary>
        /// <para>
        /// <para>The maximum session duration (in seconds) that you want to set for the specified role.
        /// If you do not specify a value for this setting, the default maximum of one hour is
        /// applied. This setting can have a value from 1 hour to 12 hours.</para><para>Anyone who assumes the role from the AWS CLI or API can use the <code>DurationSeconds</code>
        /// API parameter or the <code>duration-seconds</code> CLI parameter to request a longer
        /// session. The <code>MaxSessionDuration</code> setting determines the maximum duration
        /// that can be requested using the <code>DurationSeconds</code> parameter. If users don't
        /// specify a value for the <code>DurationSeconds</code> parameter, their security credentials
        /// are valid for one hour by default. This applies when you use the <code>AssumeRole*</code>
        /// API operations or the <code>assume-role*</code> CLI operations but does not apply
        /// when you use those operations to create a console URL. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_roles_use.html">Using IAM
        /// Roles</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxSessionDuration { get; set; }
        #endregion
        
        #region Parameter Path
        /// <summary>
        /// <para>
        /// <para> The path to the role. For more information about paths, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">IAM
        /// Identifiers</a> in the <i>IAM User Guide</i>.</para><para>This parameter is optional. If it is not included, it defaults to a slash (/).</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of either a forward slash (/) by itself
        /// or a string that must begin and end with forward slashes. In addition, it can contain
        /// any ASCII character from the ! (\u0021) through the DEL character (\u007F), including
        /// most punctuation characters, digits, and upper and lowercased letters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Path { get; set; }
        #endregion
        
        #region Parameter PermissionsBoundary
        /// <summary>
        /// <para>
        /// <para>The ARN of the policy that is used to set the permissions boundary for the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PermissionsBoundary { get; set; }
        #endregion
        
        #region Parameter RoleName
        /// <summary>
        /// <para>
        /// <para>The name of the role to create.</para><para>IAM user, group, role, and policy names must be unique within the account. Names are
        /// not distinguished by case. For example, you cannot create resources named both "MyResource"
        /// and "myresource".</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags that you want to attach to the newly created role. Each tag consists
        /// of a key name and an associated value. For more information about tagging, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_tags.html">Tagging IAM Identities</a>
        /// in the <i>IAM User Guide</i>.</para><note><para>If any one of the tags is invalid or if you exceed the allowed number of tags per
        /// role, then the entire request fails and the role is not created.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.IdentityManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Role'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateRoleResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateRoleResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Role";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Path parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Path' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoleName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMRole (CreateRole)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateRoleResponse, NewIAMRoleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Path;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssumeRolePolicyDocument = this.AssumeRolePolicyDocument;
            #if MODULAR
            if (this.AssumeRolePolicyDocument == null && ParameterWasBound(nameof(this.AssumeRolePolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter AssumeRolePolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.MaxSessionDuration = this.MaxSessionDuration;
            context.Path = this.Path;
            context.PermissionsBoundary = this.PermissionsBoundary;
            context.RoleName = this.RoleName;
            #if MODULAR
            if (this.RoleName == null && ParameterWasBound(nameof(this.RoleName)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.IdentityManagement.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.IdentityManagement.Model.CreateRoleRequest();
            
            if (cmdletContext.AssumeRolePolicyDocument != null)
            {
                request.AssumeRolePolicyDocument = cmdletContext.AssumeRolePolicyDocument;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.MaxSessionDuration != null)
            {
                request.MaxSessionDuration = cmdletContext.MaxSessionDuration.Value;
            }
            if (cmdletContext.Path != null)
            {
                request.Path = cmdletContext.Path;
            }
            if (cmdletContext.PermissionsBoundary != null)
            {
                request.PermissionsBoundary = cmdletContext.PermissionsBoundary;
            }
            if (cmdletContext.RoleName != null)
            {
                request.RoleName = cmdletContext.RoleName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IdentityManagement.Model.CreateRoleResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateRoleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateRole");
            try
            {
                #if DESKTOP
                return client.CreateRole(request);
                #elif CORECLR
                return client.CreateRoleAsync(request).GetAwaiter().GetResult();
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
            public System.String AssumeRolePolicyDocument { get; set; }
            public System.String Description { get; set; }
            public System.Int32? MaxSessionDuration { get; set; }
            public System.String Path { get; set; }
            public System.String PermissionsBoundary { get; set; }
            public System.String RoleName { get; set; }
            public List<Amazon.IdentityManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateRoleResponse, NewIAMRoleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Role;
        }
        
    }
}
