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
using Amazon.LicenseManagerUserSubscriptions;
using Amazon.LicenseManagerUserSubscriptions.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMUS
{
    /// <summary>
    /// Associates the user to an EC2 instance to utilize user-based subscriptions.
    /// 
    ///  <note><para>
    /// Your estimated bill for charges on the number of users and related costs will take
    /// 48 hours to appear for billing periods that haven't closed (marked as <b>Pending</b>
    /// billing status) in Amazon Web Services Billing. For more information, see <a href="https://docs.aws.amazon.com/awsaccountbilling/latest/aboutv2/invoice.html">Viewing
    /// your monthly charges</a> in the <i>Amazon Web Services Billing User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Add", "LMUSUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription AssociateUser API operation.", Operation = new[] {"AssociateUser"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary or Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse",
        "This cmdlet returns an Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary object.",
        "The service call response (type Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddLMUSUserCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// associate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter ActiveDirectorySettings_DomainIpv4List
        /// <summary>
        /// <para>
        /// <para>A list of domain IPv4 addresses that are used for the Active Directory.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// <para>The ID of the EC2 instance that provides the user-based subscription.</para>
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
        public System.String InstanceId { get; set; }
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
        /// <para>Contains a list of subnets that apply for the Active Directory domain.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainNetworkSettings_Subnets")]
        public System.String[] DomainNetworkSettings_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that apply for the user association.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name from the identity provider.</para>
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
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceUserSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceUserSummary";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-LMUSUser (AssociateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse, AddLMUSUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.Username = this.Username;
            #if MODULAR
            if (this.Username == null && ParameterWasBound(nameof(this.Username)))
            {
                WriteWarning("You are passing $null as a value for parameter Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserRequest();
            
            if (cmdletContext.Domain != null)
            {
                request.Domain = cmdletContext.Domain;
            }
            
             // populate IdentityProvider
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
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "AssociateUser");
            try
            {
                return client.AssociateUserAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Username { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.AssociateUserResponse, AddLMUSUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceUserSummary;
        }
        
    }
}
