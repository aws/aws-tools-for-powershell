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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Updates the password policy settings for the AWS account.
    /// 
    ///  <note><para>
    /// This action does not support partial updates. No parameters are required, but if you
    /// do not specify a parameter, that parameter's value reverts to its default value. See
    /// the <b>Request Parameters</b> section for each parameter's default value.
    /// </para></note><para>
    ///  For more information about using a password policy, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_ManagingPasswordPolicies.html">Managing
    /// an IAM Password Policy</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMAccountPasswordPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UpdateAccountPasswordPolicy API operation.", Operation = new[] {"UpdateAccountPasswordPolicy"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIAMAccountPasswordPolicyCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter AllowUsersToChangePassword
        /// <summary>
        /// <para>
        /// <para> Allows all IAM users in your account to use the AWS Management Console to change
        /// their own passwords. For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/HowToPwdIAMUser.html">Letting
        /// IAM Users Change Their Own Passwords</a> in the <i>IAM User Guide</i>.</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AllowUsersToChangePassword { get; set; }
        #endregion
        
        #region Parameter HardExpiry
        /// <summary>
        /// <para>
        /// <para>Prevents IAM users from setting a new password after their password has expired.</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean HardExpiry { get; set; }
        #endregion
        
        #region Parameter MaxPasswordAge
        /// <summary>
        /// <para>
        /// <para>The number of days that an IAM user password is valid. The default value of 0 means
        /// IAM user passwords never expire.</para><para>Default value: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxPasswordAge { get; set; }
        #endregion
        
        #region Parameter MinimumPasswordLength
        /// <summary>
        /// <para>
        /// <para>The minimum number of characters allowed in an IAM user password.</para><para>Default value: 6</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MinimumPasswordLength { get; set; }
        #endregion
        
        #region Parameter PasswordReusePrevention
        /// <summary>
        /// <para>
        /// <para>Specifies the number of previous passwords that IAM users are prevented from reusing.
        /// The default value of 0 means IAM users are not prevented from reusing previous passwords.</para><para>Default value: 0</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PasswordReusePrevention { get; set; }
        #endregion
        
        #region Parameter RequireLowercaseCharacter
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one lowercase character
        /// from the ISO basic Latin alphabet (a to z).</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequireLowercaseCharacters")]
        public System.Boolean RequireLowercaseCharacter { get; set; }
        #endregion
        
        #region Parameter RequireNumber
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one numeric character (0
        /// to 9).</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequireNumbers")]
        public System.Boolean RequireNumber { get; set; }
        #endregion
        
        #region Parameter RequireSymbol
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one of the following non-alphanumeric
        /// characters:</para><para>! @ # $ % ^ &amp;amp; * ( ) _ + - = [ ] { } | '</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequireSymbols")]
        public System.Boolean RequireSymbol { get; set; }
        #endregion
        
        #region Parameter RequireUppercaseCharacter
        /// <summary>
        /// <para>
        /// <para>Specifies whether IAM user passwords must contain at least one uppercase character
        /// from the ISO basic Latin alphabet (A to Z).</para><para>Default value: false</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequireUppercaseCharacters")]
        public System.Boolean RequireUppercaseCharacter { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMAccountPasswordPolicy (UpdateAccountPasswordPolicy)"))
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
            
            if (ParameterWasBound("AllowUsersToChangePassword"))
                context.AllowUsersToChangePassword = this.AllowUsersToChangePassword;
            if (ParameterWasBound("HardExpiry"))
                context.HardExpiry = this.HardExpiry;
            if (ParameterWasBound("MaxPasswordAge"))
                context.MaxPasswordAge = this.MaxPasswordAge;
            if (ParameterWasBound("MinimumPasswordLength"))
                context.MinimumPasswordLength = this.MinimumPasswordLength;
            if (ParameterWasBound("PasswordReusePrevention"))
                context.PasswordReusePrevention = this.PasswordReusePrevention;
            if (ParameterWasBound("RequireLowercaseCharacter"))
                context.RequireLowercaseCharacters = this.RequireLowercaseCharacter;
            if (ParameterWasBound("RequireNumber"))
                context.RequireNumbers = this.RequireNumber;
            if (ParameterWasBound("RequireSymbol"))
                context.RequireSymbols = this.RequireSymbol;
            if (ParameterWasBound("RequireUppercaseCharacter"))
                context.RequireUppercaseCharacters = this.RequireUppercaseCharacter;
            
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
            if (cmdletContext.RequireLowercaseCharacters != null)
            {
                request.RequireLowercaseCharacters = cmdletContext.RequireLowercaseCharacters.Value;
            }
            if (cmdletContext.RequireNumbers != null)
            {
                request.RequireNumbers = cmdletContext.RequireNumbers.Value;
            }
            if (cmdletContext.RequireSymbols != null)
            {
                request.RequireSymbols = cmdletContext.RequireSymbols.Value;
            }
            if (cmdletContext.RequireUppercaseCharacters != null)
            {
                request.RequireUppercaseCharacters = cmdletContext.RequireUppercaseCharacters.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UpdateAccountPasswordPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UpdateAccountPasswordPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateAccountPasswordPolicy(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAccountPasswordPolicyAsync(request);
                return task.Result;
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
            public System.Boolean? RequireLowercaseCharacters { get; set; }
            public System.Boolean? RequireNumbers { get; set; }
            public System.Boolean? RequireSymbols { get; set; }
            public System.Boolean? RequireUppercaseCharacters { get; set; }
        }
        
    }
}
