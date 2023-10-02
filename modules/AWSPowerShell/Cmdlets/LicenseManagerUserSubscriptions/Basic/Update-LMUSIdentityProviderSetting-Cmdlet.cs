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
    /// Updates additional product configuration settings for the registered identity provider.
    /// </summary>
    [Cmdlet("Update", "LMUSIdentityProviderSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription UpdateIdentityProviderSettings API operation.", Operation = new[] {"UpdateIdentityProviderSettings"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateLMUSIdentityProviderSettingCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter UpdateSettings_AddSubnet
        /// <summary>
        /// <para>
        /// <para>The ID of one or more subnets in which License Manager will create a VPC endpoint
        /// for products that require connectivity to activation servers.</para>
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
        [Alias("UpdateSettings_AddSubnets")]
        public System.String[] UpdateSettings_AddSubnet { get; set; }
        #endregion
        
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Product { get; set; }
        #endregion
        
        #region Parameter UpdateSettings_RemoveSubnet
        /// <summary>
        /// <para>
        /// <para>The ID of one or more subnets to remove.</para>
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
        [Alias("UpdateSettings_RemoveSubnets")]
        public System.String[] UpdateSettings_RemoveSubnet { get; set; }
        #endregion
        
        #region Parameter UpdateSettings_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A security group ID that allows inbound TCP port 1688 communication between resources
        /// in your VPC and the VPC endpoints for activation servers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdateSettings_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ActiveDirectoryIdentityProvider_DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LMUSIdentityProviderSetting (UpdateIdentityProviderSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse, UpdateLMUSIdentityProviderSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActiveDirectoryIdentityProvider_DirectoryId = this.ActiveDirectoryIdentityProvider_DirectoryId;
            context.Product = this.Product;
            #if MODULAR
            if (this.Product == null && ParameterWasBound(nameof(this.Product)))
            {
                WriteWarning("You are passing $null as a value for parameter Product which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpdateSettings_AddSubnet != null)
            {
                context.UpdateSettings_AddSubnet = new List<System.String>(this.UpdateSettings_AddSubnet);
            }
            #if MODULAR
            if (this.UpdateSettings_AddSubnet == null && ParameterWasBound(nameof(this.UpdateSettings_AddSubnet)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateSettings_AddSubnet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UpdateSettings_RemoveSubnet != null)
            {
                context.UpdateSettings_RemoveSubnet = new List<System.String>(this.UpdateSettings_RemoveSubnet);
            }
            #if MODULAR
            if (this.UpdateSettings_RemoveSubnet == null && ParameterWasBound(nameof(this.UpdateSettings_RemoveSubnet)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateSettings_RemoveSubnet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UpdateSettings_SecurityGroupId = this.UpdateSettings_SecurityGroupId;
            
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsRequest();
            
            
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
            
             // populate UpdateSettings
            var requestUpdateSettingsIsNull = true;
            request.UpdateSettings = new Amazon.LicenseManagerUserSubscriptions.Model.UpdateSettings();
            List<System.String> requestUpdateSettings_updateSettings_AddSubnet = null;
            if (cmdletContext.UpdateSettings_AddSubnet != null)
            {
                requestUpdateSettings_updateSettings_AddSubnet = cmdletContext.UpdateSettings_AddSubnet;
            }
            if (requestUpdateSettings_updateSettings_AddSubnet != null)
            {
                request.UpdateSettings.AddSubnets = requestUpdateSettings_updateSettings_AddSubnet;
                requestUpdateSettingsIsNull = false;
            }
            List<System.String> requestUpdateSettings_updateSettings_RemoveSubnet = null;
            if (cmdletContext.UpdateSettings_RemoveSubnet != null)
            {
                requestUpdateSettings_updateSettings_RemoveSubnet = cmdletContext.UpdateSettings_RemoveSubnet;
            }
            if (requestUpdateSettings_updateSettings_RemoveSubnet != null)
            {
                request.UpdateSettings.RemoveSubnets = requestUpdateSettings_updateSettings_RemoveSubnet;
                requestUpdateSettingsIsNull = false;
            }
            System.String requestUpdateSettings_updateSettings_SecurityGroupId = null;
            if (cmdletContext.UpdateSettings_SecurityGroupId != null)
            {
                requestUpdateSettings_updateSettings_SecurityGroupId = cmdletContext.UpdateSettings_SecurityGroupId;
            }
            if (requestUpdateSettings_updateSettings_SecurityGroupId != null)
            {
                request.UpdateSettings.SecurityGroupId = requestUpdateSettings_updateSettings_SecurityGroupId;
                requestUpdateSettingsIsNull = false;
            }
             // determine if request.UpdateSettings should be set to null
            if (requestUpdateSettingsIsNull)
            {
                request.UpdateSettings = null;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "UpdateIdentityProviderSettings");
            try
            {
                #if DESKTOP
                return client.UpdateIdentityProviderSettings(request);
                #elif CORECLR
                return client.UpdateIdentityProviderSettingsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> UpdateSettings_AddSubnet { get; set; }
            public List<System.String> UpdateSettings_RemoveSubnet { get; set; }
            public System.String UpdateSettings_SecurityGroupId { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.UpdateIdentityProviderSettingsResponse, UpdateLMUSIdentityProviderSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
