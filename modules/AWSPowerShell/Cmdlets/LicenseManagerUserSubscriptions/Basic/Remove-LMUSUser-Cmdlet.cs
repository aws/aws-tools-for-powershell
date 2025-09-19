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
using Amazon.LicenseManagerUserSubscriptions;
using Amazon.LicenseManagerUserSubscriptions.Model;

namespace Amazon.PowerShell.Cmdlets.LMUS
{
    /// <summary>
    /// Disassociates the user from an EC2 instance providing user-based subscriptions.
    /// </summary>
    [Cmdlet("Remove", "LMUSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription DisassociateUser API operation.", Operation = new[] {"DisassociateUser"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary or Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary object.",
        "The service call response (type Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveLMUSUserCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActiveDirectoryIdentityProvider_ActiveDirectoryType
        /// <summary>
        /// <para>
        /// <para>The type of Active Directory – either a self-managed Active Directory or an Amazon
        /// Web Services Managed Active Directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectoryType")]
        [AWSConstantClassSource("Amazon.LicenseManagerUserSubscriptions.ActiveDirectoryType")]
        public Amazon.LicenseManagerUserSubscriptions.ActiveDirectoryType ActiveDirectoryIdentityProvider_ActiveDirectoryType { get; set; }
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
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>The domain name of the Active Directory that contains information for the user to
        /// disassociate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ActiveDirectorySettings_DomainIpv4List
        /// <summary>
        /// <para>
        /// <para>A list of domain IPv4 addresses that are used for the Active Directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainIpv4List")]
        public System.String[] ActiveDirectorySettings_DomainIpv4List { get; set; }
        #endregion
        
        #region Parameter ActiveDirectorySettings_DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name for the Active Directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainName")]
        public System.String ActiveDirectorySettings_DomainName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 instance which provides user-based subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter InstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the user to disassociate from the EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceUserArn { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryIdentityProvider_IsSharedActiveDirectory
        /// <summary>
        /// <para>
        /// <para>Whether this directory is shared from an Amazon Web Services Managed Active Directory.
        /// The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_IsSharedActiveDirectory")]
        public System.Boolean? ActiveDirectoryIdentityProvider_IsSharedActiveDirectory { get; set; }
        #endregion
        
        #region Parameter SecretsManagerCredentialsProvider_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Secrets Manager secret that contains credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider_SecretId")]
        public System.String SecretsManagerCredentialsProvider_SecretId { get; set; }
        #endregion
        
        #region Parameter DomainNetworkSettings_Subnet
        /// <summary>
        /// <para>
        /// <para>Contains a list of subnets that apply for the Active Directory domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_Subnets")]
        public System.String[] DomainNetworkSettings_Subnet { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name from the Active Directory identity provider for the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceUserSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceUserSummary";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-LMUSUser (DisassociateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse, RemoveLMUSUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Domain = this.Domain;
            context.SecretsManagerCredentialsProvider_SecretId = this.SecretsManagerCredentialsProvider_SecretId;
            if (this.ActiveDirectorySettings_DomainIpv4List != null)
            {
                context.ActiveDirectorySettings_DomainIpv4List = new List<System.String>(this.ActiveDirectorySettings_DomainIpv4List);
            }
            context.ActiveDirectorySettings_DomainName = this.ActiveDirectorySettings_DomainName;
            if (this.DomainNetworkSettings_Subnet != null)
            {
                context.DomainNetworkSettings_Subnet = new List<System.String>(this.DomainNetworkSettings_Subnet);
            }
            context.ActiveDirectoryIdentityProvider_ActiveDirectoryType = this.ActiveDirectoryIdentityProvider_ActiveDirectoryType;
            context.ActiveDirectoryIdentityProvider_DirectoryId = this.ActiveDirectoryIdentityProvider_DirectoryId;
            context.ActiveDirectoryIdentityProvider_IsSharedActiveDirectory = this.ActiveDirectoryIdentityProvider_IsSharedActiveDirectory;
            context.InstanceId = this.InstanceId;
            context.InstanceUserArn = this.InstanceUserArn;
            context.Username = this.Username;
            
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate IdentityProvider
            var requestIdentityProviderIsNull = true;
            request.IdentityProvider = new Amazon.LicenseManagerUserSubscriptions.Model.IdentityProvider();
            Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectoryIdentityProvider requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider = null;
            
             // populate ActiveDirectoryIdentityProvider
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider = new Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectoryIdentityProvider();
            Amazon.LicenseManagerUserSubscriptions.ActiveDirectoryType requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_ActiveDirectoryType = null;
            if (cmdletContext.ActiveDirectoryIdentityProvider_ActiveDirectoryType != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_ActiveDirectoryType = cmdletContext.ActiveDirectoryIdentityProvider_ActiveDirectoryType;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_ActiveDirectoryType != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider.ActiveDirectoryType = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_ActiveDirectoryType;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull = false;
            }
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
            System.Boolean? requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_IsSharedActiveDirectory = null;
            if (cmdletContext.ActiveDirectoryIdentityProvider_IsSharedActiveDirectory != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_IsSharedActiveDirectory = cmdletContext.ActiveDirectoryIdentityProvider_IsSharedActiveDirectory.Value;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_IsSharedActiveDirectory != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider.IsSharedActiveDirectory = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_activeDirectoryIdentityProvider_IsSharedActiveDirectory.Value;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProviderIsNull = false;
            }
            Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectorySettings requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings = null;
            
             // populate ActiveDirectorySettings
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings = new Amazon.LicenseManagerUserSubscriptions.Model.ActiveDirectorySettings();
            List<System.String> requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv4List = null;
            if (cmdletContext.ActiveDirectorySettings_DomainIpv4List != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv4List = cmdletContext.ActiveDirectorySettings_DomainIpv4List;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv4List != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings.DomainIpv4List = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv4List;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull = false;
            }
            System.String requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainName = null;
            if (cmdletContext.ActiveDirectorySettings_DomainName != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainName = cmdletContext.ActiveDirectorySettings_DomainName;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainName != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings.DomainName = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainName;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull = false;
            }
            Amazon.LicenseManagerUserSubscriptions.Model.CredentialsProvider requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider = null;
            
             // populate DomainCredentialsProvider
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProviderIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider = new Amazon.LicenseManagerUserSubscriptions.Model.CredentialsProvider();
            Amazon.LicenseManagerUserSubscriptions.Model.SecretsManagerCredentialsProvider requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider = null;
            
             // populate SecretsManagerCredentialsProvider
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProviderIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider = new Amazon.LicenseManagerUserSubscriptions.Model.SecretsManagerCredentialsProvider();
            System.String requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId = null;
            if (cmdletContext.SecretsManagerCredentialsProvider_SecretId != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId = cmdletContext.SecretsManagerCredentialsProvider_SecretId;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider.SecretId = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider_secretsManagerCredentialsProvider_SecretId;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProviderIsNull = false;
            }
             // determine if requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider should be set to null
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProviderIsNull)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider = null;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider.SecretsManagerCredentialsProvider = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider_SecretsManagerCredentialsProvider;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProviderIsNull = false;
            }
             // determine if requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider should be set to null
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProviderIsNull)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider = null;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings.DomainCredentialsProvider = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainCredentialsProvider;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull = false;
            }
            Amazon.LicenseManagerUserSubscriptions.Model.DomainNetworkSettings requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings = null;
            
             // populate DomainNetworkSettings
            var requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettingsIsNull = true;
            requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings = new Amazon.LicenseManagerUserSubscriptions.Model.DomainNetworkSettings();
            List<System.String> requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_domainNetworkSettings_Subnet = null;
            if (cmdletContext.DomainNetworkSettings_Subnet != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_domainNetworkSettings_Subnet = cmdletContext.DomainNetworkSettings_Subnet;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_domainNetworkSettings_Subnet != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings.Subnets = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_domainNetworkSettings_Subnet;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettingsIsNull = false;
            }
             // determine if requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings should be set to null
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettingsIsNull)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings = null;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings.DomainNetworkSettings = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings;
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull = false;
            }
             // determine if requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings should be set to null
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettingsIsNull)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings = null;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider.ActiveDirectorySettings = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings;
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
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.InstanceUserArn != null)
            {
                request.InstanceUserArn = cmdletContext.InstanceUserArn;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "DisassociateUser");
            try
            {
                #if DESKTOP
                return client.DisassociateUser(request);
                #elif CORECLR
                return client.DisassociateUserAsync(request).GetAwaiter().GetResult();
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
            public System.String Domain { get; set; }
            public System.String SecretsManagerCredentialsProvider_SecretId { get; set; }
            public List<System.String> ActiveDirectorySettings_DomainIpv4List { get; set; }
            public System.String ActiveDirectorySettings_DomainName { get; set; }
            public List<System.String> DomainNetworkSettings_Subnet { get; set; }
            public Amazon.LicenseManagerUserSubscriptions.ActiveDirectoryType ActiveDirectoryIdentityProvider_ActiveDirectoryType { get; set; }
            public System.String ActiveDirectoryIdentityProvider_DirectoryId { get; set; }
            public System.Boolean? ActiveDirectoryIdentityProvider_IsSharedActiveDirectory { get; set; }
            public System.String InstanceId { get; set; }
            public System.String InstanceUserArn { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.DisassociateUserResponse, RemoveLMUSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceUserSummary;
        }
        
    }
}
