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
    /// Lists user associations for an identity provider.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LMUSUserAssociationList")]
    [OutputType("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary")]
    [AWSCmdlet("Calls the AWS License Manager User Subscription ListUserAssociations API operation.", Operation = new[] {"ListUserAssociations"}, SelectReturnType = typeof(Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse))]
    [AWSCmdletOutput("Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary or Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse",
        "This cmdlet returns a collection of Amazon.LicenseManagerUserSubscriptions.Model.InstanceUserSummary objects.",
        "The service call response (type Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLMUSUserAssociationListCmdlet : AmazonLicenseManagerUserSubscriptionsClientCmdlet, IExecutor
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
        
        #region Parameter ActiveDirectorySettings_DomainIpv6List
        /// <summary>
        /// <para>
        /// <para>A list of domain IPv6 addresses that are used for the Active Directory.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_DomainIpv6List")]
        public System.String[] ActiveDirectorySettings_DomainIpv6List { get; set; }
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
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>You can use the following filters to streamline results:</para><ul><li><para>Status</para></li><li><para>Username</para></li><li><para>Domain</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.LicenseManagerUserSubscriptions.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the EC2 instance, which provides user-based subscriptions.</para>
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
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return from a single request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to specify where to start paginating. This is the nextToken from a previously
        /// truncated response.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceUserSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse).
        /// Specifying the name of a property of type Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceUserSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse, GetLMUSUserAssociationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.LicenseManagerUserSubscriptions.Model.Filter>(this.Filter);
            }
            context.SecretsManagerCredentialsProvider_SecretId = this.SecretsManagerCredentialsProvider_SecretId;
            if (this.ActiveDirectorySettings_DomainIpv4List != null)
            {
                context.ActiveDirectorySettings_DomainIpv4List = new List<System.String>(this.ActiveDirectorySettings_DomainIpv4List);
            }
            if (this.ActiveDirectorySettings_DomainIpv6List != null)
            {
                context.ActiveDirectorySettings_DomainIpv6List = new List<System.String>(this.ActiveDirectorySettings_DomainIpv6List);
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
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
            List<System.String> requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv6List = null;
            if (cmdletContext.ActiveDirectorySettings_DomainIpv6List != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv6List = cmdletContext.ActiveDirectorySettings_DomainIpv6List;
            }
            if (requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv6List != null)
            {
                requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings.DomainIpv6List = requestIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_identityProvider_ActiveDirectoryIdentityProvider_ActiveDirectorySettings_activeDirectorySettings_DomainIpv6List;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse CallAWSServiceOperation(IAmazonLicenseManagerUserSubscriptions client, Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager User Subscription", "ListUserAssociations");
            try
            {
                return client.ListUserAssociationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.LicenseManagerUserSubscriptions.Model.Filter> Filter { get; set; }
            public System.String SecretsManagerCredentialsProvider_SecretId { get; set; }
            public List<System.String> ActiveDirectorySettings_DomainIpv4List { get; set; }
            public List<System.String> ActiveDirectorySettings_DomainIpv6List { get; set; }
            public System.String ActiveDirectorySettings_DomainName { get; set; }
            public List<System.String> DomainNetworkSettings_Subnet { get; set; }
            public Amazon.LicenseManagerUserSubscriptions.ActiveDirectoryType ActiveDirectoryIdentityProvider_ActiveDirectoryType { get; set; }
            public System.String ActiveDirectoryIdentityProvider_DirectoryId { get; set; }
            public System.Boolean? ActiveDirectoryIdentityProvider_IsSharedActiveDirectory { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LicenseManagerUserSubscriptions.Model.ListUserAssociationsResponse, GetLMUSUserAssociationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceUserSummaries;
        }
        
    }
}
