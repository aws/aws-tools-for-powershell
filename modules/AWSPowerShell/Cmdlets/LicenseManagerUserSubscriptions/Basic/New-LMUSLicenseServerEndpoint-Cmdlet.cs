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
    /// Creates a network endpoint for the Remote Desktop Services (RDS) license server.
    /// </summary>
    [Cmdlet("New", "LMUSLicenseServerEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription CreateLicenseServerEndpoint API operation.", Operation = new[] {"CreateLicenseServerEndpoint"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse object containing multiple properties."
    )]
    public partial class NewLMUSLicenseServerEndpointCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IdentityProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that identifies the <c>IdentityProvider</c> resource
        /// that contains details about a registered identity provider. In the case of Active
        /// Directory, that can be a self-managed Active Directory or an Amazon Web Services Managed
        /// Active Directory that contains user identity details.</para>
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
        public System.String IdentityProviderArn { get; set; }
        #endregion
        
        #region Parameter SecretsManagerCredentialsProvider_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Secrets Manager secret that contains credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LicenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider_SecretId")]
        public System.String SecretsManagerCredentialsProvider_SecretId { get; set; }
        #endregion
        
        #region Parameter LicenseServerSettings_ServerType
        /// <summary>
        /// <para>
        /// <para>The type of license server.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LicenseManagerUserSubscriptions.ServerType")]
        public Amazon.LicenseManagerUserSubscriptions.ServerType LicenseServerSettings_ServerType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that apply for the license server endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IdentityProviderArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IdentityProviderArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IdentityProviderArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IdentityProviderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMUSLicenseServerEndpoint (CreateLicenseServerEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse, NewLMUSLicenseServerEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IdentityProviderArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IdentityProviderArn = this.IdentityProviderArn;
            #if MODULAR
            if (this.IdentityProviderArn == null && ParameterWasBound(nameof(this.IdentityProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentityProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecretsManagerCredentialsProvider_SecretId = this.SecretsManagerCredentialsProvider_SecretId;
            context.LicenseServerSettings_ServerType = this.LicenseServerSettings_ServerType;
            #if MODULAR
            if (this.LicenseServerSettings_ServerType == null && ParameterWasBound(nameof(this.LicenseServerSettings_ServerType)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseServerSettings_ServerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointRequest();
            
            if (cmdletContext.IdentityProviderArn != null)
            {
                request.IdentityProviderArn = cmdletContext.IdentityProviderArn;
            }
            
             // populate LicenseServerSettings
            var requestLicenseServerSettingsIsNull = true;
            request.LicenseServerSettings = new Amazon.LicenseManagerUserSubscriptions.Model.LicenseServerSettings();
            Amazon.LicenseManagerUserSubscriptions.ServerType requestLicenseServerSettings_licenseServerSettings_ServerType = null;
            if (cmdletContext.LicenseServerSettings_ServerType != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerType = cmdletContext.LicenseServerSettings_ServerType;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerType != null)
            {
                request.LicenseServerSettings.ServerType = requestLicenseServerSettings_licenseServerSettings_ServerType;
                requestLicenseServerSettingsIsNull = false;
            }
            Amazon.LicenseManagerUserSubscriptions.Model.ServerSettings requestLicenseServerSettings_licenseServerSettings_ServerSettings = null;
            
             // populate ServerSettings
            var requestLicenseServerSettings_licenseServerSettings_ServerSettingsIsNull = true;
            requestLicenseServerSettings_licenseServerSettings_ServerSettings = new Amazon.LicenseManagerUserSubscriptions.Model.ServerSettings();
            Amazon.LicenseManagerUserSubscriptions.Model.RdsSalSettings requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings = null;
            
             // populate RdsSalSettings
            var requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettingsIsNull = true;
            requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings = new Amazon.LicenseManagerUserSubscriptions.Model.RdsSalSettings();
            Amazon.LicenseManagerUserSubscriptions.Model.CredentialsProvider requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider = null;
            
             // populate RdsSalCredentialsProvider
            var requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProviderIsNull = true;
            requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider = new Amazon.LicenseManagerUserSubscriptions.Model.CredentialsProvider();
            Amazon.LicenseManagerUserSubscriptions.Model.SecretsManagerCredentialsProvider requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider = null;
            
             // populate SecretsManagerCredentialsProvider
            var requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProviderIsNull = true;
            requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider = new Amazon.LicenseManagerUserSubscriptions.Model.SecretsManagerCredentialsProvider();
            System.String requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId = null;
            if (cmdletContext.SecretsManagerCredentialsProvider_SecretId != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId = cmdletContext.SecretsManagerCredentialsProvider_SecretId;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider.SecretId = requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId;
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProviderIsNull = false;
            }
             // determine if requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider should be set to null
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProviderIsNull)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider = null;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider.SecretsManagerCredentialsProvider = requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider_SecretsManagerCredentialsProvider;
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProviderIsNull = false;
            }
             // determine if requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider should be set to null
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProviderIsNull)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider = null;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings.RdsSalCredentialsProvider = requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings_licenseServerSettings_ServerSettings_RdsSalSettings_RdsSalCredentialsProvider;
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettingsIsNull = false;
            }
             // determine if requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings should be set to null
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettingsIsNull)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings = null;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings != null)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings.RdsSalSettings = requestLicenseServerSettings_licenseServerSettings_ServerSettings_licenseServerSettings_ServerSettings_RdsSalSettings;
                requestLicenseServerSettings_licenseServerSettings_ServerSettingsIsNull = false;
            }
             // determine if requestLicenseServerSettings_licenseServerSettings_ServerSettings should be set to null
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettingsIsNull)
            {
                requestLicenseServerSettings_licenseServerSettings_ServerSettings = null;
            }
            if (requestLicenseServerSettings_licenseServerSettings_ServerSettings != null)
            {
                request.LicenseServerSettings.ServerSettings = requestLicenseServerSettings_licenseServerSettings_ServerSettings;
                requestLicenseServerSettingsIsNull = false;
            }
             // determine if request.LicenseServerSettings should be set to null
            if (requestLicenseServerSettingsIsNull)
            {
                request.LicenseServerSettings = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "CreateLicenseServerEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateLicenseServerEndpoint(request);
                #elif CORECLR
                return client.CreateLicenseServerEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String IdentityProviderArn { get; set; }
            public System.String SecretsManagerCredentialsProvider_SecretId { get; set; }
            public Amazon.LicenseManagerUserSubscriptions.ServerType LicenseServerSettings_ServerType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.CreateLicenseServerEndpointResponse, NewLMUSLicenseServerEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
