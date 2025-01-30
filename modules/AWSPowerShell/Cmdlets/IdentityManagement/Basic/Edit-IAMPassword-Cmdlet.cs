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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Changes the password of the IAM user who is calling this operation. This operation
    /// can be performed using the CLI, the Amazon Web Services API, or the <b>My Security
    /// Credentials</b> page in the Amazon Web Services Management Console. The Amazon Web
    /// Services account root user password is not affected by this operation.
    /// 
    ///  
    /// <para>
    /// Use <a>UpdateLoginProfile</a> to use the CLI, the Amazon Web Services API, or the
    /// <b>Users</b> page in the IAM console to change the password for any IAM user. For
    /// more information about modifying passwords, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_ManagingLogins.html">Managing
    /// passwords</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "IAMPassword", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management ChangePassword API operation.", Operation = new[] {"ChangePassword"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.ChangePasswordResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.ChangePasswordResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.ChangePasswordResponse) be returned by specifying '-Select *'."
    )]
    public partial class EditIAMPasswordCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NewPassword
        /// <summary>
        /// <para>
        /// <para>The new password. The new password must conform to the Amazon Web Services account's
        /// password policy, if one exists.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> that is used to validate
        /// this parameter is a string of characters. That string can include almost any printable
        /// ASCII character from the space (<c>\u0020</c>) through the end of the ASCII character
        /// range (<c>\u00FF</c>). You can also include the tab (<c>\u0009</c>), line feed (<c>\u000A</c>),
        /// and carriage return (<c>\u000D</c>) characters. Any of these characters are valid
        /// in a password. However, many tools, such as the Amazon Web Services Management Console,
        /// might restrict the ability to type certain characters because they have special meaning
        /// within that tool.</para>
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
        public System.String NewPassword { get; set; }
        #endregion
        
        #region Parameter OldPassword
        /// <summary>
        /// <para>
        /// <para>The IAM user's current password.</para>
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
        public System.String OldPassword { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.ChangePasswordResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OldPassword parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OldPassword' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OldPassword' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OldPassword), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-IAMPassword (ChangePassword)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.ChangePasswordResponse, EditIAMPasswordCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OldPassword;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NewPassword = this.NewPassword;
            #if MODULAR
            if (this.NewPassword == null && ParameterWasBound(nameof(this.NewPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter NewPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OldPassword = this.OldPassword;
            #if MODULAR
            if (this.OldPassword == null && ParameterWasBound(nameof(this.OldPassword)))
            {
                WriteWarning("You are passing $null as a value for parameter OldPassword which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
        
        private Amazon.IdentityManagement.Model.ChangePasswordResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.ChangePasswordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "ChangePassword");
            try
            {
                #if DESKTOP
                return client.ChangePassword(request);
                #elif CORECLR
                return client.ChangePasswordAsync(request).GetAwaiter().GetResult();
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
            public System.String NewPassword { get; set; }
            public System.String OldPassword { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.ChangePasswordResponse, EditIAMPasswordCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
