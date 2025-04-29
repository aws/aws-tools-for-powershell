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
using System.Threading;
using Amazon.ManagedGrafana;
using Amazon.ManagedGrafana.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGRF
{
    /// <summary>
    /// Use this operation to define the identity provider (IdP) that this workspace authenticates
    /// users from, using SAML. You can also map SAML assertion attributes to workspace user
    /// information and define which groups in the assertion attribute are to have the <c>Admin</c>
    /// and <c>Editor</c> roles in the workspace.
    /// 
    ///  <note><para>
    /// Changes to the authentication method for a workspace may take a few minutes to take
    /// effect.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "MGRFWorkspaceAuthentication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedGrafana.Model.AuthenticationDescription")]
    [AWSCmdlet("Calls the Amazon Managed Grafana UpdateWorkspaceAuthentication API operation.", Operation = new[] {"UpdateWorkspaceAuthentication"}, SelectReturnType = typeof(Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse))]
    [AWSCmdletOutput("Amazon.ManagedGrafana.Model.AuthenticationDescription or Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse",
        "This cmdlet returns an Amazon.ManagedGrafana.Model.AuthenticationDescription object.",
        "The service call response (type Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateMGRFWorkspaceAuthenticationCmdlet : AmazonManagedGrafanaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RoleValues_Admin
        /// <summary>
        /// <para>
        /// <para>A list of groups from the SAML assertion attribute to grant the Grafana <c>Admin</c>
        /// role to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_RoleValues_Admin")]
        public System.String[] RoleValues_Admin { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_AllowedOrganization
        /// <summary>
        /// <para>
        /// <para>Lists which organizations defined in the SAML assertion are allowed to use the Amazon
        /// Managed Grafana workspace. If this is empty, all organizations in the assertion attribute
        /// have access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AllowedOrganizations")]
        public System.String[] SamlConfiguration_AllowedOrganization { get; set; }
        #endregion
        
        #region Parameter AuthenticationProvider
        /// <summary>
        /// <para>
        /// <para>Specifies whether this workspace uses SAML 2.0, IAM Identity Center, or both to authenticate
        /// users for using the Grafana console within a workspace. For more information, see
        /// <a href="https://docs.aws.amazon.com/grafana/latest/userguide/authentication-in-AMG.html">User
        /// authentication in Amazon Managed Grafana</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AuthenticationProviders")]
        public System.String[] AuthenticationProvider { get; set; }
        #endregion
        
        #region Parameter RoleValues_Editor
        /// <summary>
        /// <para>
        /// <para>A list of groups from the SAML assertion attribute to grant the Grafana <c>Editor</c>
        /// role to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_RoleValues_Editor")]
        public System.String[] RoleValues_Editor { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Email
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the email names for
        /// SAML users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Email")]
        public System.String AssertionAttributes_Email { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Group
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the user full "friendly"
        /// names for user groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Groups")]
        public System.String AssertionAttributes_Group { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Login
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the login names for
        /// SAML users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Login")]
        public System.String AssertionAttributes_Login { get; set; }
        #endregion
        
        #region Parameter SamlConfiguration_LoginValidityDuration
        /// <summary>
        /// <para>
        /// <para>How long a sign-on session by a SAML user is valid, before the user has to sign on
        /// again.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SamlConfiguration_LoginValidityDuration { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Name
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the user full "friendly"
        /// names for SAML users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Name")]
        public System.String AssertionAttributes_Name { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Org
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the user full "friendly"
        /// names for the users' organizations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Org")]
        public System.String AssertionAttributes_Org { get; set; }
        #endregion
        
        #region Parameter AssertionAttributes_Role
        /// <summary>
        /// <para>
        /// <para>The name of the attribute within the SAML assertion to use as the user roles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_AssertionAttributes_Role")]
        public System.String AssertionAttributes_Role { get; set; }
        #endregion
        
        #region Parameter IdpMetadata_Url
        /// <summary>
        /// <para>
        /// <para>The URL of the location containing the IdP metadata.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_IdpMetadata_Url")]
        public System.String IdpMetadata_Url { get; set; }
        #endregion
        
        #region Parameter WorkspaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the workspace to update the authentication for.</para>
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
        public System.String WorkspaceId { get; set; }
        #endregion
        
        #region Parameter IdpMetadata_Xml
        /// <summary>
        /// <para>
        /// <para>The full IdP metadata, in XML format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SamlConfiguration_IdpMetadata_Xml")]
        public System.String IdpMetadata_Xml { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Authentication'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse).
        /// Specifying the name of a property of type Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Authentication";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkspaceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MGRFWorkspaceAuthentication (UpdateWorkspaceAuthentication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse, UpdateMGRFWorkspaceAuthenticationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AuthenticationProvider != null)
            {
                context.AuthenticationProvider = new List<System.String>(this.AuthenticationProvider);
            }
            #if MODULAR
            if (this.AuthenticationProvider == null && ParameterWasBound(nameof(this.AuthenticationProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SamlConfiguration_AllowedOrganization != null)
            {
                context.SamlConfiguration_AllowedOrganization = new List<System.String>(this.SamlConfiguration_AllowedOrganization);
            }
            context.AssertionAttributes_Email = this.AssertionAttributes_Email;
            context.AssertionAttributes_Group = this.AssertionAttributes_Group;
            context.AssertionAttributes_Login = this.AssertionAttributes_Login;
            context.AssertionAttributes_Name = this.AssertionAttributes_Name;
            context.AssertionAttributes_Org = this.AssertionAttributes_Org;
            context.AssertionAttributes_Role = this.AssertionAttributes_Role;
            context.IdpMetadata_Url = this.IdpMetadata_Url;
            context.IdpMetadata_Xml = this.IdpMetadata_Xml;
            context.SamlConfiguration_LoginValidityDuration = this.SamlConfiguration_LoginValidityDuration;
            if (this.RoleValues_Admin != null)
            {
                context.RoleValues_Admin = new List<System.String>(this.RoleValues_Admin);
            }
            if (this.RoleValues_Editor != null)
            {
                context.RoleValues_Editor = new List<System.String>(this.RoleValues_Editor);
            }
            context.WorkspaceId = this.WorkspaceId;
            #if MODULAR
            if (this.WorkspaceId == null && ParameterWasBound(nameof(this.WorkspaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkspaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationRequest();
            
            if (cmdletContext.AuthenticationProvider != null)
            {
                request.AuthenticationProviders = cmdletContext.AuthenticationProvider;
            }
            
             // populate SamlConfiguration
            var requestSamlConfigurationIsNull = true;
            request.SamlConfiguration = new Amazon.ManagedGrafana.Model.SamlConfiguration();
            List<System.String> requestSamlConfiguration_samlConfiguration_AllowedOrganization = null;
            if (cmdletContext.SamlConfiguration_AllowedOrganization != null)
            {
                requestSamlConfiguration_samlConfiguration_AllowedOrganization = cmdletContext.SamlConfiguration_AllowedOrganization;
            }
            if (requestSamlConfiguration_samlConfiguration_AllowedOrganization != null)
            {
                request.SamlConfiguration.AllowedOrganizations = requestSamlConfiguration_samlConfiguration_AllowedOrganization;
                requestSamlConfigurationIsNull = false;
            }
            System.Int32? requestSamlConfiguration_samlConfiguration_LoginValidityDuration = null;
            if (cmdletContext.SamlConfiguration_LoginValidityDuration != null)
            {
                requestSamlConfiguration_samlConfiguration_LoginValidityDuration = cmdletContext.SamlConfiguration_LoginValidityDuration.Value;
            }
            if (requestSamlConfiguration_samlConfiguration_LoginValidityDuration != null)
            {
                request.SamlConfiguration.LoginValidityDuration = requestSamlConfiguration_samlConfiguration_LoginValidityDuration.Value;
                requestSamlConfigurationIsNull = false;
            }
            Amazon.ManagedGrafana.Model.IdpMetadata requestSamlConfiguration_samlConfiguration_IdpMetadata = null;
            
             // populate IdpMetadata
            var requestSamlConfiguration_samlConfiguration_IdpMetadataIsNull = true;
            requestSamlConfiguration_samlConfiguration_IdpMetadata = new Amazon.ManagedGrafana.Model.IdpMetadata();
            System.String requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Url = null;
            if (cmdletContext.IdpMetadata_Url != null)
            {
                requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Url = cmdletContext.IdpMetadata_Url;
            }
            if (requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Url != null)
            {
                requestSamlConfiguration_samlConfiguration_IdpMetadata.Url = requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Url;
                requestSamlConfiguration_samlConfiguration_IdpMetadataIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Xml = null;
            if (cmdletContext.IdpMetadata_Xml != null)
            {
                requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Xml = cmdletContext.IdpMetadata_Xml;
            }
            if (requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Xml != null)
            {
                requestSamlConfiguration_samlConfiguration_IdpMetadata.Xml = requestSamlConfiguration_samlConfiguration_IdpMetadata_idpMetadata_Xml;
                requestSamlConfiguration_samlConfiguration_IdpMetadataIsNull = false;
            }
             // determine if requestSamlConfiguration_samlConfiguration_IdpMetadata should be set to null
            if (requestSamlConfiguration_samlConfiguration_IdpMetadataIsNull)
            {
                requestSamlConfiguration_samlConfiguration_IdpMetadata = null;
            }
            if (requestSamlConfiguration_samlConfiguration_IdpMetadata != null)
            {
                request.SamlConfiguration.IdpMetadata = requestSamlConfiguration_samlConfiguration_IdpMetadata;
                requestSamlConfigurationIsNull = false;
            }
            Amazon.ManagedGrafana.Model.RoleValues requestSamlConfiguration_samlConfiguration_RoleValues = null;
            
             // populate RoleValues
            var requestSamlConfiguration_samlConfiguration_RoleValuesIsNull = true;
            requestSamlConfiguration_samlConfiguration_RoleValues = new Amazon.ManagedGrafana.Model.RoleValues();
            List<System.String> requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Admin = null;
            if (cmdletContext.RoleValues_Admin != null)
            {
                requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Admin = cmdletContext.RoleValues_Admin;
            }
            if (requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Admin != null)
            {
                requestSamlConfiguration_samlConfiguration_RoleValues.Admin = requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Admin;
                requestSamlConfiguration_samlConfiguration_RoleValuesIsNull = false;
            }
            List<System.String> requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Editor = null;
            if (cmdletContext.RoleValues_Editor != null)
            {
                requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Editor = cmdletContext.RoleValues_Editor;
            }
            if (requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Editor != null)
            {
                requestSamlConfiguration_samlConfiguration_RoleValues.Editor = requestSamlConfiguration_samlConfiguration_RoleValues_roleValues_Editor;
                requestSamlConfiguration_samlConfiguration_RoleValuesIsNull = false;
            }
             // determine if requestSamlConfiguration_samlConfiguration_RoleValues should be set to null
            if (requestSamlConfiguration_samlConfiguration_RoleValuesIsNull)
            {
                requestSamlConfiguration_samlConfiguration_RoleValues = null;
            }
            if (requestSamlConfiguration_samlConfiguration_RoleValues != null)
            {
                request.SamlConfiguration.RoleValues = requestSamlConfiguration_samlConfiguration_RoleValues;
                requestSamlConfigurationIsNull = false;
            }
            Amazon.ManagedGrafana.Model.AssertionAttributes requestSamlConfiguration_samlConfiguration_AssertionAttributes = null;
            
             // populate AssertionAttributes
            var requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = true;
            requestSamlConfiguration_samlConfiguration_AssertionAttributes = new Amazon.ManagedGrafana.Model.AssertionAttributes();
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Email = null;
            if (cmdletContext.AssertionAttributes_Email != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Email = cmdletContext.AssertionAttributes_Email;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Email != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Email = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Email;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Group = null;
            if (cmdletContext.AssertionAttributes_Group != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Group = cmdletContext.AssertionAttributes_Group;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Group != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Groups = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Group;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Login = null;
            if (cmdletContext.AssertionAttributes_Login != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Login = cmdletContext.AssertionAttributes_Login;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Login != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Login = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Login;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Name = null;
            if (cmdletContext.AssertionAttributes_Name != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Name = cmdletContext.AssertionAttributes_Name;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Name != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Name = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Name;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Org = null;
            if (cmdletContext.AssertionAttributes_Org != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Org = cmdletContext.AssertionAttributes_Org;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Org != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Org = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Org;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
            System.String requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Role = null;
            if (cmdletContext.AssertionAttributes_Role != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Role = cmdletContext.AssertionAttributes_Role;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Role != null)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes.Role = requestSamlConfiguration_samlConfiguration_AssertionAttributes_assertionAttributes_Role;
                requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull = false;
            }
             // determine if requestSamlConfiguration_samlConfiguration_AssertionAttributes should be set to null
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributesIsNull)
            {
                requestSamlConfiguration_samlConfiguration_AssertionAttributes = null;
            }
            if (requestSamlConfiguration_samlConfiguration_AssertionAttributes != null)
            {
                request.SamlConfiguration.AssertionAttributes = requestSamlConfiguration_samlConfiguration_AssertionAttributes;
                requestSamlConfigurationIsNull = false;
            }
             // determine if request.SamlConfiguration should be set to null
            if (requestSamlConfigurationIsNull)
            {
                request.SamlConfiguration = null;
            }
            if (cmdletContext.WorkspaceId != null)
            {
                request.WorkspaceId = cmdletContext.WorkspaceId;
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
        
        private Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse CallAWSServiceOperation(IAmazonManagedGrafana client, Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Grafana", "UpdateWorkspaceAuthentication");
            try
            {
                return client.UpdateWorkspaceAuthenticationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AuthenticationProvider { get; set; }
            public List<System.String> SamlConfiguration_AllowedOrganization { get; set; }
            public System.String AssertionAttributes_Email { get; set; }
            public System.String AssertionAttributes_Group { get; set; }
            public System.String AssertionAttributes_Login { get; set; }
            public System.String AssertionAttributes_Name { get; set; }
            public System.String AssertionAttributes_Org { get; set; }
            public System.String AssertionAttributes_Role { get; set; }
            public System.String IdpMetadata_Url { get; set; }
            public System.String IdpMetadata_Xml { get; set; }
            public System.Int32? SamlConfiguration_LoginValidityDuration { get; set; }
            public List<System.String> RoleValues_Admin { get; set; }
            public List<System.String> RoleValues_Editor { get; set; }
            public System.String WorkspaceId { get; set; }
            public System.Func<Amazon.ManagedGrafana.Model.UpdateWorkspaceAuthenticationResponse, UpdateMGRFWorkspaceAuthenticationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Authentication;
        }
        
    }
}
