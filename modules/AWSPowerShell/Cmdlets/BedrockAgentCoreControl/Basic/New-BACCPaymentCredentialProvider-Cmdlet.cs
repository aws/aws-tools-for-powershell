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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a new payment credential provider for storing authentication credentials used
    /// by payment connectors to communicate with external payment providers.
    /// </summary>
    [Cmdlet("New", "BACCPaymentCredentialProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreatePaymentCredentialProvider API operation.", Operation = new[] {"CreatePaymentCredentialProvider"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse object containing multiple properties."
    )]
    public partial class NewBACCPaymentCredentialProviderCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId
        /// <summary>
        /// <para>
        /// <para>The API key identifier provided by Coinbase Developer Platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret
        /// <summary>
        /// <para>
        /// <para>The API key secret provided by Coinbase Developer Platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the API key secret for the Coinbase Developer Platform. Use <c>MANAGED</c>
        /// if the secret is managed by the service, or <c>EXTERNAL</c> if you manage the secret
        /// yourself in Amazon Web Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AppId
        /// <summary>
        /// <para>
        /// <para>The app ID provided by Privy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AppSecret
        /// <summary>
        /// <para>
        /// <para>The app secret provided by Privy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecret { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the app secret. Use <c>MANAGED</c> if the secret is managed by
        /// the service, or <c>EXTERNAL</c> if you manage the secret yourself in Amazon Web Services
        /// Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId
        /// <summary>
        /// <para>
        /// <para>The authorization ID for the Stripe Privy integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey
        /// <summary>
        /// <para>
        /// <para>The authorization private key for the Stripe Privy integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource
        /// <summary>
        /// <para>
        /// <para>The source type of the authorization private key. Use <c>MANAGED</c> if the secret
        /// is managed by the service, or <c>EXTERNAL</c> if you manage the secret yourself in
        /// Amazon Web Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource { get; set; }
        #endregion
        
        #region Parameter CredentialProviderVendor
        /// <summary>
        /// <para>
        /// <para>The vendor type for the payment credential provider (e.g., CoinbaseCDP, StripePrivy).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.PaymentCredentialProviderVendorType")]
        public Amazon.BedrockAgentCoreControl.PaymentCredentialProviderVendorType CredentialProviderVendor { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the Amazon Web Services Secrets
        /// Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the Amazon Web Services Secrets
        /// Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the Amazon Web Services Secrets
        /// Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey
        /// <summary>
        /// <para>
        /// <para>The JSON key used to extract the secret value from the Amazon Web Services Secrets
        /// Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Unique name for the payment credential provider.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Secrets Manager secret that stores the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional tags for resource organization.</para><para />
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
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret
        /// <summary>
        /// <para>
        /// <para>The wallet secret provided by Coinbase Developer Platform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret { get; set; }
        #endregion
        
        #region Parameter ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource
        /// <summary>
        /// <para>
        /// <para>The source type of the wallet secret for the Coinbase Developer Platform. Use <c>MANAGED</c>
        /// if the secret is managed by the service, or <c>EXTERNAL</c> if you manage the secret
        /// yourself in Amazon Web Services Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.SecretSourceType")]
        public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCPaymentCredentialProvider (CreatePaymentCredentialProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse, NewBACCPaymentCredentialProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CredentialProviderVendor = this.CredentialProviderVendor;
            #if MODULAR
            if (this.CredentialProviderVendor == null && ParameterWasBound(nameof(this.CredentialProviderVendor)))
            {
                WriteWarning("You are passing $null as a value for parameter CredentialProviderVendor which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId;
            context.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource = this.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AppId = this.ProviderConfigurationInput_StripePrivyConfiguration_AppId;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AppSecret = this.ProviderConfigurationInput_StripePrivyConfiguration_AppSecret;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey = this.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId = this.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource = this.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId = this.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey = this.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey = this.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId = this.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId;
            context.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource = this.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource;
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderRequest();
            
            if (cmdletContext.CredentialProviderVendor != null)
            {
                request.CredentialProviderVendor = cmdletContext.CredentialProviderVendor;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProviderConfigurationInput
            var requestProviderConfigurationInputIsNull = true;
            request.ProviderConfigurationInput = new Amazon.BedrockAgentCoreControl.Model.PaymentProviderConfigurationInput();
            Amazon.BedrockAgentCoreControl.Model.CoinbaseCdpConfigurationInput requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration = null;
            
             // populate CoinbaseCdpConfiguration
            var requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration = new Amazon.BedrockAgentCoreControl.Model.CoinbaseCdpConfigurationInput();
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.ApiKeyId = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.ApiKeySecret = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.ApiKeySecretSource = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecret = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecret = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.WalletSecret = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecret;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.WalletSecretSource = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig = null;
            
             // populate ApiKeySecretConfig
            var requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfigIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig.JsonKey = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfigIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig.SecretId = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfigIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfigIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.ApiKeySecretConfig = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig = null;
            
             // populate WalletSecretConfig
            var requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfigIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig.JsonKey = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfigIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId = null;
            if (cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId = cmdletContext.ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig.SecretId = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfigIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfigIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration.WalletSecretConfig = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration_providerConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig;
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfigurationIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration != null)
            {
                request.ProviderConfigurationInput.CoinbaseCdpConfiguration = requestProviderConfigurationInput_providerConfigurationInput_CoinbaseCdpConfiguration;
                requestProviderConfigurationInputIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.StripePrivyConfigurationInput requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration = null;
            
             // populate StripePrivyConfiguration
            var requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration = new Amazon.BedrockAgentCoreControl.Model.StripePrivyConfigurationInput();
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppId = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppId = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AppId = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppId;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecret = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecret = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecret;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecret != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AppSecret = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecret;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretSource = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretSource = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretSource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AppSecretSource = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretSource;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationId = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationId = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AuthorizationId = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationId;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AuthorizationPrivateKey = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.SecretSourceType requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AuthorizationPrivateKeySource = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig = null;
            
             // populate AppSecretConfig
            var requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfigIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig.JsonKey = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfigIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig.SecretId = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfigIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfigIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AppSecretConfig = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AppSecretConfig;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.SecretReference requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig = null;
            
             // populate AuthorizationPrivateKeyConfig
            var requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfigIsNull = true;
            requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig = new Amazon.BedrockAgentCoreControl.Model.SecretReference();
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig.JsonKey = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfigIsNull = false;
            }
            System.String requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId = null;
            if (cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId = cmdletContext.ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig.SecretId = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfigIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfigIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig != null)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration.AuthorizationPrivateKeyConfig = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration_providerConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig;
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull = false;
            }
             // determine if requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration should be set to null
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfigurationIsNull)
            {
                requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration = null;
            }
            if (requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration != null)
            {
                request.ProviderConfigurationInput.StripePrivyConfiguration = requestProviderConfigurationInput_providerConfigurationInput_StripePrivyConfiguration;
                requestProviderConfigurationInputIsNull = false;
            }
             // determine if request.ProviderConfigurationInput should be set to null
            if (requestProviderConfigurationInputIsNull)
            {
                request.ProviderConfigurationInput = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreatePaymentCredentialProvider");
            try
            {
                return client.CreatePaymentCredentialProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.BedrockAgentCoreControl.PaymentCredentialProviderVendorType CredentialProviderVendor { get; set; }
            public System.String Name { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeyId { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecret { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_JsonKey { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_CoinbaseCdpConfiguration_ApiKeySecretSource { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecret { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_JsonKey { get; set; }
            public System.String ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_CoinbaseCdpConfiguration_WalletSecretSource { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppId { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecret { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_JsonKey { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AppSecretConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_StripePrivyConfiguration_AppSecretSource { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationId { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKey { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_JsonKey { get; set; }
            public System.String ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeyConfig_SecretId { get; set; }
            public Amazon.BedrockAgentCoreControl.SecretSourceType ProviderConfigurationInput_StripePrivyConfiguration_AuthorizationPrivateKeySource { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreatePaymentCredentialProviderResponse, NewBACCPaymentCredentialProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
