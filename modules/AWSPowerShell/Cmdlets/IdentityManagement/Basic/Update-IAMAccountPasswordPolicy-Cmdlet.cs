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
    /// Updates the password policy settings for the Amazon Web Services account.
    /// 
    ///  <note><para>
    /// This operation does not support partial updates. No parameters are required, but if
    /// you do not specify a parameter, that parameter's value reverts to its default value.
    /// See the <b>Request Parameters</b> section for each parameter's default value. Also
    /// note that some parameters do not allow the default parameter to be explicitly set.
    /// Instead, to invoke the default value, do not include that parameter when you invoke
    /// the operation.
    /// </para></note><para>
    ///  For more information about using a password policy, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_ManagingPasswordPolicies.html">Managing
    /// an IAM password policy</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMAccountPasswordPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UpdateAccountPasswordPolicy API operation.", Operation = new[] {"UpdateAccountPasswordPolicy"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIAMAccountPasswordPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AllowUsersToChangePassword
        /// <summary>
        /// <para>
        /// <para> Allows all IAM users in your account to use the Amazon Web Services Management Console
        /// to change their own passwords. For more information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_passwords_enable-user-change.html">Permitting
        /// IAM users to change their own passwords</a> in the <i>IAM User Guide</i>.</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that IAM users in the account do not automatically
        /// have permissions to change their own password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowUsersToChangePassword { get; set; }
        #endregion
        
        #region Parameter HardExpiry
        /// <summary>
        /// <para>
        /// <para> Prevents IAM users who are accessing the account via the Amazon Web Services Management
        /// Console from setting a new console password after their password has expired. The
        /// IAM user cannot access the console until an administrator resets the password.</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that IAM users can change their passwords
        /// after they expire and continue to sign in as the user.</para><note><para> In the Amazon Web Services Management Console, the custom password policy option
        /// <b>Allow users to change their own password</b> gives IAM users permissions to <code>iam:ChangePassword</code>
        /// for only their user and to the <code>iam:GetAccountPasswordPolicy</code> action. This
        /// option does not attach a permissions policy to each user, rather the permissions are
        /// applied at the account-level for all users by IAM. IAM users with <code>iam:ChangePassword</code>
        /// permission and active access keys can reset their own expired console password using
        /// the CLI or API.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? HardExpiry { get; set; }
        #endregion
        
        #region Parameter MaxPasswordAge
        /// <summary>
        /// <para>
        /// <para>The number of days that an IAM user password is valid.</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>0</code>. The result is that IAM user passwords never expire.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxPasswordAge { get; set; }
        #endregion
        
        #region Parameter MinimumPasswordLength
        /// <summary>
        /// <para>
        /// <para>The minimum number of characters allowed in an IAM user password.</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>6</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MinimumPasswordLength { get; set; }
        #endregion
        
        #region Parameter PasswordReusePrevention
        /// <summary>
        /// <para>
        /// <para>Specifies the number of previous passwords that IAM users are prevented from reusing.</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>0</code>. The result is that IAM users are not prevented from reusing
        /// previous passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PasswordReusePrevention { get; set; }
        #endregion
        
        #region Parameter RequireLowercaseCharacter
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one lowercase character
        /// from the ISO basic Latin alphabet (a to z).</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that passwords do not require at least
        /// one lowercase character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequireLowercaseCharacters")]
        public System.Boolean? RequireLowercaseCharacter { get; set; }
        #endregion
        
        #region Parameter RequireNumber
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one numeric character (0
        /// to 9).</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that passwords do not require at least
        /// one numeric character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequireNumbers")]
        public System.Boolean? RequireNumber { get; set; }
        #endregion
        
        #region Parameter RequireSymbol
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one of the following non-alphanumeric
        /// characters:</para><para>! @ # $ % ^ &amp; * ( ) _ + - = [ ] { } | '</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that passwords do not require at least
        /// one symbol character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequireSymbols")]
        public System.Boolean? RequireSymbol { get; set; }
        #endregion
        
        #region Parameter RequireUppercaseCharacter
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one uppercase character
        /// from the ISO basic Latin alphabet (A to Z).</para><para>If you do not specify a value for this parameter, then the operation uses the default
        /// value of <code>false</code>. The result is that passwords do not require at least
        /// one uppercase character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequireUppercaseCharacters")]
        public System.Boolean? RequireUppercaseCharacter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMAccountPasswordPolicy (UpdateAccountPasswordPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse, UpdateIAMAccountPasswordPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowUsersToChangePassword = this.AllowUsersToChangePassword;
            context.HardExpiry = this.HardExpiry;
            context.MaxPasswordAge = this.MaxPasswordAge;
            context.MinimumPasswordLength = this.MinimumPasswordLength;
            context.PasswordReusePrevention = this.PasswordReusePrevention;
            context.RequireLowercaseCharacter = this.RequireLowercaseCharacter;
            context.RequireNumber = this.RequireNumber;
            context.RequireSymbol = this.RequireSymbol;
            context.RequireUppercaseCharacter = this.RequireUppercaseCharacter;
            
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
            var request = new Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyRequest();
            
            if (cmdletContext.AllowUsersToChangePassword != null)
            {
                request.AllowUsersToChangePassword = cmdletContext.AllowUsersToChangePassword.Value;
            }
            if (cmdletContext.HardExpiry != null)
            {
                request.HardExpiry = cmdletContext.HardExpiry.Value;
            }
            if (cmdletContext.MaxPasswordAge != null)
            {
                request.MaxPasswordAge = cmdletContext.MaxPasswordAge.Value;
            }
            if (cmdletContext.MinimumPasswordLength != null)
            {
                request.MinimumPasswordLength = cmdletContext.MinimumPasswordLength.Value;
            }
            if (cmdletContext.PasswordReusePrevention != null)
            {
                request.PasswordReusePrevention = cmdletContext.PasswordReusePrevention.Value;
            }
            if (cmdletContext.RequireLowercaseCharacter != null)
            {
                request.RequireLowercaseCharacters = cmdletContext.RequireLowercaseCharacter.Value;
            }
            if (cmdletContext.RequireNumber != null)
            {
                request.RequireNumbers = cmdletContext.RequireNumber.Value;
            }
            if (cmdletContext.RequireSymbol != null)
            {
                request.RequireSymbols = cmdletContext.RequireSymbol.Value;
            }
            if (cmdletContext.RequireUppercaseCharacter != null)
            {
                request.RequireUppercaseCharacters = cmdletContext.RequireUppercaseCharacter.Value;
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
        
        private Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UpdateAccountPasswordPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateAccountPasswordPolicy(request);
                #elif CORECLR
                return client.UpdateAccountPasswordPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowUsersToChangePassword { get; set; }
            public System.Boolean? HardExpiry { get; set; }
            public System.Int32? MaxPasswordAge { get; set; }
            public System.Int32? MinimumPasswordLength { get; set; }
            public System.Int32? PasswordReusePrevention { get; set; }
            public System.Boolean? RequireLowercaseCharacter { get; set; }
            public System.Boolean? RequireNumber { get; set; }
            public System.Boolean? RequireSymbol { get; set; }
            public System.Boolean? RequireUppercaseCharacter { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse, UpdateIAMAccountPasswordPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
