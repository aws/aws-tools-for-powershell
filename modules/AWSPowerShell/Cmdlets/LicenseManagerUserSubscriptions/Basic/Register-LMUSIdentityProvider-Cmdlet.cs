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
using Amazon.LicenseManagerUserSubscriptions;
using Amazon.LicenseManagerUserSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LMUS
{
    /// <summary>
    /// Registers an identity provider for user-based subscriptions.
    /// </summary>
    [Cmdlet("Register", "LMUSIdentityProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.IdentityProviderSummary")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription RegisterIdentityProvider API operation.", Operation = new[] {"RegisterIdentityProvider"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.IdentityProviderSummary or Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.IdentityProviderSummary object.",
        "The service call response (type Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterLMUSIdentityProviderCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        #region Parameter ActiveDirectoryIdentityProvider_DirectoryId
        /// <summary>
        /// <para>
        /// <para>The directory ID for an Active Directory identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_DirectoryId")]
        public System.String ActiveDirectoryIdentityProvider_DirectoryId { get; set; }
        #endregion
        
        #region Parameter Product
        /// <summary>
        /// <para>
        /// <para>The name of the user-based subscription product.</para>
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
        public System.String Product { get; set; }
        #endregion
        
        #region Parameter Settings_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A security group ID that allows inbound TCP port 1688 communication between resources
        /// in your VPC and the VPC endpoint for activation servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Settings_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Settings_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets defined for the registered identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_Subnets")]
        public System.String[] Settings_Subnet { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IdentityProviderSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IdentityProviderSummary";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Product parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Product' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Product' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActiveDirectoryIdentityProvider_DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-LMUSIdentityProvider (RegisterIdentityProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse, RegisterLMUSIdentityProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Product;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActiveDirectoryIdentityProvider_DirectoryId = this.ActiveDirectoryIdentityProvider_DirectoryId;
            context.Product = this.Product;
            #if MODULAR
            if (this.Product == null && ParameterWasBound(nameof(this.Product)))
            {
                WriteWarning("You are passing $null as a value for parameter Product which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_SecurityGroupId = this.Settings_SecurityGroupId;
            if (this.Settings_Subnet != null)
            {
                context.Settings_Subnet = new List<System.String>(this.Settings_Subnet);
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderRequest();
            
            
             // populate IdentityProvider
            var requestIdentityProviderIsNull = true;
            request.IdentityProvider = new Amazon.LicenseManagerUserSubscriptions.Model.IdentityProvider();
            Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectoryIdentityProvider requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider = null;
            
             // populate ActiveDirectoryIdentityProvider
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider = new Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectoryIdentityProvider();
            System.String requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_DirectoryId = null;
            if (cmdletContext.ActiveDirectoryIdentityProvider_DirectoryId != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_DirectoryId = cmdletContext.ActiveDirectoryIdentityProvider_DirectoryId;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_DirectoryId != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider.DirectoryId = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_DirectoryId;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull = false;
            }
             // determine if requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider should be set to null
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider = null;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider != null)
            {
                request.IdentityProvider.ActiveDirectoryIdentityProvider = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider;
                requestIdentityProviderIsNull = false;
            }
             // determine if request.IdentityProvider should be set to null
            if (requestIdentityProviderIsNull)
            {
                request.IdentityProvider = null;
            }
            if (cmdletContext.Product != null)
            {
                request.Product = cmdletContext.Product;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.LicenseManagerUserSubscriptions.Model.Settings();
            System.String requestSettings_settings_SecurityGroupId = null;
            if (cmdletContext.Settings_SecurityGroupId != null)
            {
                requestSettings_settings_SecurityGroupId = cmdletContext.Settings_SecurityGroupId;
            }
            if (requestSettings_settings_SecurityGroupId != null)
            {
                request.Settings.SecurityGroupId = requestSettings_settings_SecurityGroupId;
                requestSettingsIsNull = false;
            }
            List<System.String> requestSettings_settings_Subnet = null;
            if (cmdletContext.Settings_Subnet != null)
            {
                requestSettings_settings_Subnet = cmdletContext.Settings_Subnet;
            }
            if (requestSettings_settings_Subnet != null)
            {
                request.Settings.Subnets = requestSettings_settings_Subnet;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "RegisterIdentityProvider");
            try
            {
                #if DESKTOP
                return client.RegisterIdentityProvider(request);
                #elif CORECLR
                return client.RegisterIdentityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String ActiveDirectoryIdentityProvider_DirectoryId { get; set; }
            public System.String Product { get; set; }
            public System.String Settings_SecurityGroupId { get; set; }
            public List<System.String> Settings_Subnet { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.RegisterIdentityProviderResponse, RegisterLMUSIdentityProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IdentityProviderSummary;
        }
        
    }
}
