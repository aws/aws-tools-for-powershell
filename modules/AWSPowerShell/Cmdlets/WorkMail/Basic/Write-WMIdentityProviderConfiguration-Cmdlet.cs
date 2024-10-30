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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Enables integration between IAM Identity Center (IdC) and WorkMail to proxy authentication
    /// requests for mailbox users. You can connect your IdC directory or your external directory
    /// to WorkMail through IdC and manage access to WorkMail mailboxes in a single place.
    /// For enhanced protection, you could enable Multifactor Authentication (MFA) and Personal
    /// Access Tokens.
    /// </summary>
    [Cmdlet("Write", "WMIdentityProviderConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon WorkMail PutIdentityProviderConfiguration API operation.", Operation = new[] {"PutIdentityProviderConfiguration"}, SelectReturnType = typeof(Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteWMIdentityProviderConfigurationCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityCenterConfiguration_ApplicationArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of IAMIdentity Center Application for WorkMail. Must
        /// be created by the WorkMail API, see CreateIdentityCenterApplication.</para>
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
        public System.String IdentityCenterConfiguration_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationMode
        /// <summary>
        /// <para>
        /// <para> The authentication mode used in WorkMail.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkMail.IdentityProviderAuthenticationMode")]
        public Amazon.WorkMail.IdentityProviderAuthenticationMode AuthenticationMode { get; set; }
        #endregion
        
        #region Parameter IdentityCenterConfiguration_InstanceArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the of IAM Identity Center instance. Must be in
        /// the same AWS account and region as WorkMail organization.</para>
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
        public System.String IdentityCenterConfiguration_InstanceArn { get; set; }
        #endregion
        
        #region Parameter PersonalAccessTokenConfiguration_LifetimeInDay
        /// <summary>
        /// <para>
        /// <para> The validity of the Personal Access Token status in days. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PersonalAccessTokenConfiguration_LifetimeInDays")]
        public System.Int32? PersonalAccessTokenConfiguration_LifetimeInDay { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para> The ID of the WorkMail Organization. </para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter PersonalAccessTokenConfiguration_Status
        /// <summary>
        /// <para>
        /// <para> The status of the Personal Access Token allowed for the organization. </para><ul><li><para><i>Active</i> - Mailbox users can login to the web application and choose <i>Settings</i>
        /// to see the new <i>Personal Access Tokens</i> page to create and delete the Personal
        /// Access Tokens. Mailbox users can use the Personal Access Tokens to set up mailbox
        /// connection from desktop or mobile email clients.</para></li><li><para><i>Inactive</i> - Personal Access Tokens are disabled for your organization. Mailbox
        /// users can’t create, list, or delete Personal Access Tokens and can’t use them to connect
        /// to their mailboxes from desktop or mobile email clients.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkMail.PersonalAccessTokenConfigurationStatus")]
        public Amazon.WorkMail.PersonalAccessTokenConfigurationStatus PersonalAccessTokenConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OrganizationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OrganizationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OrganizationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OrganizationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-WMIdentityProviderConfiguration (PutIdentityProviderConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse, WriteWMIdentityProviderConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OrganizationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthenticationMode = this.AuthenticationMode;
            #if MODULAR
            if (this.AuthenticationMode == null && ParameterWasBound(nameof(this.AuthenticationMode)))
            {
                WriteWarning("You are passing $null as a value for parameter AuthenticationMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityCenterConfiguration_ApplicationArn = this.IdentityCenterConfiguration_ApplicationArn;
            #if MODULAR
            if (this.IdentityCenterConfiguration_ApplicationArn == null && ParameterWasBound(nameof(this.IdentityCenterConfiguration_ApplicationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityCenterConfiguration_ApplicationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentityCenterConfiguration_InstanceArn = this.IdentityCenterConfiguration_InstanceArn;
            #if MODULAR
            if (this.IdentityCenterConfiguration_InstanceArn == null && ParameterWasBound(nameof(this.IdentityCenterConfiguration_InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityCenterConfiguration_InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PersonalAccessTokenConfiguration_LifetimeInDay = this.PersonalAccessTokenConfiguration_LifetimeInDay;
            context.PersonalAccessTokenConfiguration_Status = this.PersonalAccessTokenConfiguration_Status;
            #if MODULAR
            if (this.PersonalAccessTokenConfiguration_Status == null && ParameterWasBound(nameof(this.PersonalAccessTokenConfiguration_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter PersonalAccessTokenConfiguration_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.PutIdentityProviderConfigurationRequest();
            
            if (cmdletContext.AuthenticationMode != null)
            {
                request.AuthenticationMode = cmdletContext.AuthenticationMode;
            }
            
             // populate IdentityCenterConfiguration
            var requestIdentityCenterConfigurationIsNull = true;
            request.IdentityCenterConfiguration = new Amazon.WorkMail.Model.IdentityCenterConfiguration();
            System.String requestIdentityCenterConfiguration_identityCenterConfiguration_ApplicationArn = null;
            if (cmdletContext.IdentityCenterConfiguration_ApplicationArn != null)
            {
                requestIdentityCenterConfiguration_identityCenterConfiguration_ApplicationArn = cmdletContext.IdentityCenterConfiguration_ApplicationArn;
            }
            if (requestIdentityCenterConfiguration_identityCenterConfiguration_ApplicationArn != null)
            {
                request.IdentityCenterConfiguration.ApplicationArn = requestIdentityCenterConfiguration_identityCenterConfiguration_ApplicationArn;
                requestIdentityCenterConfigurationIsNull = false;
            }
            System.String requestIdentityCenterConfiguration_identityCenterConfiguration_InstanceArn = null;
            if (cmdletContext.IdentityCenterConfiguration_InstanceArn != null)
            {
                requestIdentityCenterConfiguration_identityCenterConfiguration_InstanceArn = cmdletContext.IdentityCenterConfiguration_InstanceArn;
            }
            if (requestIdentityCenterConfiguration_identityCenterConfiguration_InstanceArn != null)
            {
                request.IdentityCenterConfiguration.InstanceArn = requestIdentityCenterConfiguration_identityCenterConfiguration_InstanceArn;
                requestIdentityCenterConfigurationIsNull = false;
            }
             // determine if request.IdentityCenterConfiguration should be set to null
            if (requestIdentityCenterConfigurationIsNull)
            {
                request.IdentityCenterConfiguration = null;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            
             // populate PersonalAccessTokenConfiguration
            var requestPersonalAccessTokenConfigurationIsNull = true;
            request.PersonalAccessTokenConfiguration = new Amazon.WorkMail.Model.PersonalAccessTokenConfiguration();
            System.Int32? requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_LifetimeInDay = null;
            if (cmdletContext.PersonalAccessTokenConfiguration_LifetimeInDay != null)
            {
                requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_LifetimeInDay = cmdletContext.PersonalAccessTokenConfiguration_LifetimeInDay.Value;
            }
            if (requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_LifetimeInDay != null)
            {
                request.PersonalAccessTokenConfiguration.LifetimeInDays = requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_LifetimeInDay.Value;
                requestPersonalAccessTokenConfigurationIsNull = false;
            }
            Amazon.WorkMail.PersonalAccessTokenConfigurationStatus requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_Status = null;
            if (cmdletContext.PersonalAccessTokenConfiguration_Status != null)
            {
                requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_Status = cmdletContext.PersonalAccessTokenConfiguration_Status;
            }
            if (requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_Status != null)
            {
                request.PersonalAccessTokenConfiguration.Status = requestPersonalAccessTokenConfiguration_personalAccessTokenConfiguration_Status;
                requestPersonalAccessTokenConfigurationIsNull = false;
            }
             // determine if request.PersonalAccessTokenConfiguration should be set to null
            if (requestPersonalAccessTokenConfigurationIsNull)
            {
                request.PersonalAccessTokenConfiguration = null;
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
        
        private Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.PutIdentityProviderConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "PutIdentityProviderConfiguration");
            try
            {
                #if DESKTOP
                return client.PutIdentityProviderConfiguration(request);
                #elif CORECLR
                return client.PutIdentityProviderConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WorkMail.IdentityProviderAuthenticationMode AuthenticationMode { get; set; }
            public System.String IdentityCenterConfiguration_ApplicationArn { get; set; }
            public System.String IdentityCenterConfiguration_InstanceArn { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Int32? PersonalAccessTokenConfiguration_LifetimeInDay { get; set; }
            public Amazon.WorkMail.PersonalAccessTokenConfigurationStatus PersonalAccessTokenConfiguration_Status { get; set; }
            public System.Func<Amazon.WorkMail.Model.PutIdentityProviderConfigurationResponse, WriteWMIdentityProviderConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
