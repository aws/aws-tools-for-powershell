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
    /// Creates a password for the specified IAM user. A password allows an IAM user to access
    /// Amazon Web Services services through the Amazon Web Services Management Console.
    /// 
    ///  
    /// <para>
    /// You can use the CLI, the Amazon Web Services API, or the <b>Users</b> page in the
    /// IAM console to create a password for any IAM user. Use <a>ChangePassword</a> to update
    /// your own existing password in the <b>My Security Credentials</b> page in the Amazon
    /// Web Services Management Console.
    /// </para><para>
    /// For more information about managing passwords, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_ManagingLogins.html">Managing
    /// passwords</a> in the <i>IAM User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMLoginProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.LoginProfile")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateLoginProfile API operation.", Operation = new[] {"CreateLoginProfile"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateLoginProfileResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.LoginProfile or Amazon.IdentityManagement.Model.CreateLoginProfileResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.LoginProfile object.",
        "The service call response (type Amazon.IdentityManagement.Model.CreateLoginProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIAMLoginProfileCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The new password for the user.</para><para>This parameter must be omitted when you make the request with an <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRoot.html">AssumeRoot</a>
        /// session. It is required in all other cases.</para><para>The <a href="http://wikipedia.org/wiki/regex">regex pattern</a> that is used to validate
        /// this parameter is a string of characters. That string can include almost any printable
        /// ASCII character from the space (<c>\u0020</c>) through the end of the ASCII character
        /// range (<c>\u00FF</c>). You can also include the tab (<c>\u0009</c>), line feed (<c>\u000A</c>),
        /// and carriage return (<c>\u000D</c>) characters. Any of these characters are valid
        /// in a password. However, many tools, such as the Amazon Web Services Management Console,
        /// might restrict the ability to type certain characters because they have special meaning
        /// within that tool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter PasswordResetRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether the user is required to set a new password on next sign-in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PasswordResetRequired { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The name of the IAM user to create a password for. The user must already exist.</para><para>This parameter is optional. If no user name is included, it defaults to the principal
        /// making the request. When you make this request with root user credentials, you must
        /// use an <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRoot.html">AssumeRoot</a>
        /// session to omit the user name.</para><para>This parameter allows (through its <a href="http://wikipedia.org/wiki/regex">regex
        /// pattern</a>) a string of characters consisting of upper and lowercase alphanumeric
        /// characters with no spaces. You can also include any of the following characters: _+=,.@-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoginProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateLoginProfileResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateLoginProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoginProfile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMLoginProfile (CreateLoginProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateLoginProfileResponse, NewIAMLoginProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Password = this.Password;
            context.PasswordResetRequired = this.PasswordResetRequired;
            context.UserName = this.UserName;
            
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
            var request = new Amazon.IdentityManagement.Model.CreateLoginProfileRequest();
            
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.PasswordResetRequired != null)
            {
                request.PasswordResetRequired = cmdletContext.PasswordResetRequired.Value;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
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
        
        private Amazon.IdentityManagement.Model.CreateLoginProfileResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateLoginProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateLoginProfile");
            try
            {
                #if DESKTOP
                return client.CreateLoginProfile(request);
                #elif CORECLR
                return client.CreateLoginProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String Password { get; set; }
            public System.Boolean? PasswordResetRequired { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateLoginProfileResponse, NewIAMLoginProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoginProfile;
        }
        
    }
}
