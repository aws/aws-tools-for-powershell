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
    /// Updates an Amazon QuickSight user.
    /// </summary>
    [Cmdlet("Update", "QSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.User")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateUserResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.User or Amazon.QuickSight.Model.UpdateUserResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.User object.",
        "The service call response (type Amazon.QuickSight.Model.UpdateUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateQSUserCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that the user is in. Currently, you use
        /// the ID for the Amazon Web Services account that contains your Amazon QuickSight account.</para>
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
        
        #region Parameter CustomFederationProviderUrl
        /// <summary>
        /// <para>
        /// <para>The URL of the custom OpenID Connect (OIDC) provider that provides identity to let
        /// a user federate into Amazon QuickSight with an associated Identity and Access Management(IAM)
        /// role. This parameter should only be used when <c>ExternalLoginFederationProviderType</c>
        /// parameter is set to <c>CUSTOM_OIDC</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomFederationProviderUrl { get; set; }
        #endregion
        
        #region Parameter CustomPermissionsName
        /// <summary>
        /// <para>
        /// <para>(Enterprise edition only) The name of the custom permissions profile that you want
        /// to assign to this user. Customized permissions allows you to control a user's access
        /// by restricting access the following operations:</para><ul><li><para>Create and update data sources</para></li><li><para>Create and update datasets</para></li><li><para>Create and update email reports</para></li><li><para>Subscribe to email reports</para></li></ul><para>A set of custom permissions includes any combination of these restrictions. Currently,
        /// you need to create the profile names for custom permission sets by using the Amazon
        /// QuickSight console. Then, you use the <c>RegisterUser</c> API operation to assign
        /// the named set of permissions to a Amazon QuickSight user. </para><para>Amazon QuickSight custom permissions are applied through IAM policies. Therefore,
        /// they override the permissions typically granted by assigning Amazon QuickSight users
        /// to one of the default security cohorts in Amazon QuickSight (admin, author, reader).</para><para>This feature is available only to Amazon QuickSight Enterprise edition subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPermissionsName { get; set; }
        #endregion
        
        #region Parameter Email
        /// <summary>
        /// <para>
        /// <para>The email address of the user that you want to update.</para>
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
        public System.String Email { get; set; }
        #endregion
        
        #region Parameter ExternalLoginFederationProviderType
        /// <summary>
        /// <para>
        /// <para>The type of supported external login provider that provides identity to let a user
        /// federate into Amazon QuickSight with an associated Identity and Access Management(IAM)
        /// role. The type of supported external login provider can be one of the following.</para><ul><li><para><c>COGNITO</c>: Amazon Cognito. The provider URL is cognito-identity.amazonaws.com.
        /// When choosing the <c>COGNITO</c> provider type, don’t use the "CustomFederationProviderUrl"
        /// parameter which is only needed when the external provider is custom.</para></li><li><para><c>CUSTOM_OIDC</c>: Custom OpenID Connect (OIDC) provider. When choosing <c>CUSTOM_OIDC</c>
        /// type, use the <c>CustomFederationProviderUrl</c> parameter to provide the custom OIDC
        /// provider URL.</para></li><li><para><c>NONE</c>: This clears all the previously saved external login information for
        /// a user. Use the <c><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_DescribeUser.html">DescribeUser</a></c> API operation to check the external login information.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalLoginFederationProviderType { get; set; }
        #endregion
        
        #region Parameter ExternalLoginId
        /// <summary>
        /// <para>
        /// <para>The identity ID for a user in the external login provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalLoginId { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace. Currently, you should set this to <c>default</c>.</para>
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
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight role of the user. The role can be one of the following default
        /// security cohorts:</para><ul><li><para><c>READER</c>: A user who has read-only access to dashboards.</para></li><li><para><c>AUTHOR</c>: A user who can create data sources, datasets, analyses, and dashboards.</para></li><li><para><c>ADMIN</c>: A user who is an author, who can also manage Amazon QuickSight settings.</para></li><li><para><c>READER_PRO</c>: Reader Pro adds Generative BI capabilities to the Reader role.
        /// Reader Pros have access to Amazon Q in Amazon QuickSight, can build stories with Amazon
        /// Q, and can generate executive summaries from dashboards.</para></li><li><para><c>AUTHOR_PRO</c>: Author Pro adds Generative BI capabilities to the Author role.
        /// Author Pros can author dashboards with natural language with Amazon Q, build stories
        /// with Amazon Q, create Topics for Q&amp;A, and generate executive summaries from dashboards.</para></li><li><para><c>ADMIN_PRO</c>: Admin Pros are Author Pros who can also manage Amazon QuickSight
        /// administrative settings. Admin Pro users are billed at Author Pro pricing.</para></li></ul><para>The name of the Amazon QuickSight role is invisible to the user except for the console
        /// screens dealing with permissions.</para>
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
        public Amazon.QuickSight.UserRole Role { get; set; }
        #endregion
        
        #region Parameter UnapplyCustomPermission
        /// <summary>
        /// <para>
        /// <para>A flag that you use to indicate that you want to remove all custom permissions from
        /// this user. Using this parameter resets the user to the state it was in before a custom
        /// permissions profile was applied. This parameter defaults to NULL and it doesn't accept
        /// any other value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UnapplyCustomPermissions")]
        public System.Boolean? UnapplyCustomPermission { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The Amazon QuickSight user name that you want to update.</para>
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
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'User'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateUserResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "User";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateUserResponse, UpdateQSUserCmdlet>(Select) ??
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
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomFederationProviderUrl = this.CustomFederationProviderUrl;
            context.CustomPermissionsName = this.CustomPermissionsName;
            context.Email = this.Email;
            #if MODULAR
            if (this.Email == null && ParameterWasBound(nameof(this.Email)))
            {
                WriteWarning("You are passing $null as a value for parameter Email which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalLoginFederationProviderType = this.ExternalLoginFederationProviderType;
            context.ExternalLoginId = this.ExternalLoginId;
            context.Namespace = this.Namespace;
            #if MODULAR
            if (this.Namespace == null && ParameterWasBound(nameof(this.Namespace)))
            {
                WriteWarning("You are passing $null as a value for parameter Namespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UnapplyCustomPermission = this.UnapplyCustomPermission;
            context.UserName = this.UserName;
            #if MODULAR
            if (this.UserName == null && ParameterWasBound(nameof(this.UserName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateUserRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.CustomFederationProviderUrl != null)
            {
                request.CustomFederationProviderUrl = cmdletContext.CustomFederationProviderUrl;
            }
            if (cmdletContext.CustomPermissionsName != null)
            {
                request.CustomPermissionsName = cmdletContext.CustomPermissionsName;
            }
            if (cmdletContext.Email != null)
            {
                request.Email = cmdletContext.Email;
            }
            if (cmdletContext.ExternalLoginFederationProviderType != null)
            {
                request.ExternalLoginFederationProviderType = cmdletContext.ExternalLoginFederationProviderType;
            }
            if (cmdletContext.ExternalLoginId != null)
            {
                request.ExternalLoginId = cmdletContext.ExternalLoginId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.UnapplyCustomPermission != null)
            {
                request.UnapplyCustomPermissions = cmdletContext.UnapplyCustomPermission.Value;
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
        
        private Amazon.QuickSight.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateUser");
            try
            {
                #if DESKTOP
                return client.UpdateUser(request);
                #elif CORECLR
                return client.UpdateUserAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomFederationProviderUrl { get; set; }
            public System.String CustomPermissionsName { get; set; }
            public System.String Email { get; set; }
            public System.String ExternalLoginFederationProviderType { get; set; }
            public System.String ExternalLoginId { get; set; }
            public System.String Namespace { get; set; }
            public Amazon.QuickSight.UserRole Role { get; set; }
            public System.Boolean? UnapplyCustomPermission { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateUserResponse, UpdateQSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.User;
        }
        
    }
}
