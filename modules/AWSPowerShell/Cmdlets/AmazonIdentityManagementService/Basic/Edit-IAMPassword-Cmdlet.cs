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
    /// Changes the password of the IAM user who is calling this action. The root account
    /// password is not affected by this action.
    /// 
    ///  
    /// <para>
    /// To change the password for a different user, see <a>UpdateLoginProfile</a>. For more
    /// information about modifying passwords, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_ManagingLogins.html">Managing
    /// Passwords</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "IAMPassword", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ChangePassword operation against AWS Identity and Access Management.", Operation = new[] {"ChangePassword"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the OldPassword parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IdentityManagement.Model.ChangePasswordResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditIAMPasswordCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter NewPassword
        /// <summary>
        /// <para>
        /// <para>The new password. The new password must conform to the AWS account's password policy,
        /// if one exists.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> for this parameter
        /// is a string of characters consisting of almost any printable ASCII character from
        /// the space (\u0020) through the end of the ASCII character range (\u00FF). You can
        /// also include the tab (\u0009), line feed (\u000A), and carriage return (\u000D) characters.
        /// Although any of these characters are valid in a password, note that many tools, such
        /// as the AWS Management Console, might restrict the ability to enter certain characters
        /// because they have special meaning within that tool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String NewPassword { get; set; }
        #endregion
        
        #region Parameter OldPassword
        /// <summary>
        /// <para>
        /// <para>The IAM user's current password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OldPassword { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the OldPassword parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OldPassword", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-IAMPassword (ChangePassword)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.NewPassword = this.NewPassword;
            context.OldPassword = this.OldPassword;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.ChangePasswordRequest();
            
            if (cmdletContext.NewPassword != null)
            {
                request.NewPassword = cmdletContext.NewPassword;
            }
            if (cmdletContext.OldPassword != null)
            {
                request.OldPassword = cmdletContext.OldPassword;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ChangePassword(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.OldPassword;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String NewPassword { get; set; }
            public System.String OldPassword { get; set; }
        }
        
    }
}
