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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Creates an Amazon QuickSight user, whose identity is associated with the AWS Identity
    /// and Access Management (IAM) identity or role specified in the request.
    /// </summary>
    [Cmdlet("Register", "QSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.RegisterUserResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight RegisterUser API operation.", Operation = new[] {"RegisterUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.RegisterUserResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.RegisterUserResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.RegisterUserResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterQSUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the AWS account that the user is in. Currently, you use the ID for the
        /// AWS account that contains your Amazon QuickSight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter CustomPermissionsName
        /// <summary>
        /// <para>
        /// <para>(Enterprise edition only) The name of the custom permissions profile that you want
        /// to assign to this user. Customized permissions allows you to control a user's access
        /// by restricting access the following operations:</para><ul><li><para>Create and update data sources</para></li><li><para>Create and update datasets</para></li><li><para>Create and update email reports</para></li><li><para>Subscribe to email reports</para></li></ul><para>To add custom permissions to an existing user, use <code><a>UpdateUser</a></code>
        /// instead.</para><para>A set of custom permissions includes any combination of these restrictions. Currently,
        /// you need to create the profile names for custom permission sets by using the QuickSight
        /// console. Then, you use the <code>RegisterUser</code> API operation to assign the named
        /// set of permissions to a QuickSight user. </para><para>QuickSight custom permissions are applied through IAM policies. Therefore, they override
        /// the permissions typically granted by assigning QuickSight users to one of the default
        /// security cohorts in QuickSight (admin, author, reader).</para><para>This feature is available only to QuickSight Enterprise edition subscriptions that
        /// use SAML 2.0-Based Federation for Single Sign-On (SSO).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPermissionsName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the user that you want to register.</para>
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
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter IamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM user or role that you are registering with Amazon QuickSight. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IamArn { get; set; }
        #endregion
        
        #region Parameter IdentityType
        /// <summary>
        /// <para>
        /// <para>Amazon QuickSight supports several ways of managing the identity of users. This parameter
        /// accepts two values:</para><ul><li><para><code>IAM</code>: A user whose identity maps to an existing IAM user or role. </para></li><li><para><code>QUICKSIGHT</code>: A user whose identity is owned and managed internally by
        /// Amazon QuickSight. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.IdentityType")]
        public Amazon.QuickSight.IdentityType IdentityType { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace. Currently, you should set this to <code>default</code>.</para>
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
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionName
        /// <summary>
        /// <para>
        /// <para>You need to use this parameter only when you register one or more users using an assumed
        /// IAM role. You don't need to provide the session name for other scenarios, for example
        /// when you are registering an IAM user or an Amazon QuickSight user. You can register
        /// multiple users using the same IAM role if each user has a different session name.
        /// For more information on assuming IAM roles, see <a href="https://awscli.amazonaws.com/v2/documentation/api/latest/reference/sts/assume-role.html"><code>assume-role</code></a> in the <i>AWS CLI Reference.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionName { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user name that you want to create for the user you are registering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserRole
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight role for the user. The user role can be one of the following:</para><ul><li><para><code>READER</code>: A user who has read-only access to dashboards.</para></li><li><para><code>AUTHOR</code>: A user who can create data sources, datasets, analyses, and
        /// dashboards.</para></li><li><para><code>ADMIN</code>: A user who is an author, who can also manage Amazon QuickSight
        /// settings.</para></li><li><para><code>RESTRICTED_READER</code>: This role isn't currently available for use.</para></li><li><para><code>RESTRICTED_AUTHOR</code>: This role isn't currently available for use.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.UserRole")]
        public Amazon.QuickSight.UserRole UserRole { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.RegisterUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.RegisterUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Email parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Email' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Email' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Email), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-QSUser (RegisterUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.RegisterUserResponse, RegisterQSUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Email;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomPermissionsName = this.CustomPermissionsName;
            context.Email = this.Email;
            #if MODULAR
            if (this.Email == null && ParameterWasBound(nameof(this.Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IamArn = this.IamArn;
            context.IdentityType = this.IdentityType;
            #if MODULAR
            if (this.IdentityType == null && ParameterWasBound(nameof(this.IdentityType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionName = this.SessionName;
            context.UserName = this.UserName;
            context.UserRole = this.UserRole;
            #if MODULAR
            if (this.UserRole == null && ParameterWasBound(nameof(this.UserRole)))
            {
                WriteWarning("You are passing $null as a value for parameter UserRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.RegisterUserRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.CustomPermissionsName != null)
            {
                request.CustomPermissionsName = cmdletContext.CustomPermissionsName;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.IamArn != null)
            {
                request.IamArn = cmdletContext.IamArn;
            }
            if (cmdletContext.IdentityType != null)
            {
                request.IdentityType = cmdletContext.IdentityType;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionName != null)
            {
                request.SessionName = cmdletContext.SessionName;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserRole != null)
            {
                request.UserRole = cmdletContext.UserRole;
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
        
        private Amazon.QuickSight.Model.RegisterUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.RegisterUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "RegisterUser");
            try
            {
                #if DESKTOP
                return client.RegisterUser(request);
                #elif CORECLR
                return client.RegisterUserAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String CustomPermissionsName { get; set; }
            public System.String Email { get; set; }
            public System.String IamArn { get; set; }
            public Amazon.QuickSight.IdentityType IdentityType { get; set; }
            public System.String Namespace { get; set; }
            public System.String SessionName { get; set; }
            public System.String UserName { get; set; }
            public Amazon.QuickSight.UserRole UserRole { get; set; }
            public System.Func<Amazon.QuickSight.Model.RegisterUserResponse, RegisterQSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
