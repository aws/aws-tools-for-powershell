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
using Amazon.KeyManagementService;
using Amazon.KeyManagementService.Model;

namespace Amazon.PowerShell.Cmdlets.KMS
{
    /// <summary>
    /// Creates a <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key store</a> backed by a key store that you own and manage. When you use a KMS key
    /// in a custom key store for a cryptographic operation, the cryptographic operation is
    /// actually performed in your key store using your keys. KMS supports <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-cloudhsm.html">CloudHSM
    /// key stores</a> backed by an <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/clusters.html">CloudHSM
    /// cluster</a> and <a href="https://docs.aws.amazon.com/kms/latest/developerguide/keystore-external.html">external
    /// key stores</a> backed by an external key store proxy and external key manager outside
    /// of Amazon Web Services.
    /// 
    ///  
    /// <para>
    ///  This operation is part of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key stores</a> feature in KMS, which combines the convenience and extensive integration
    /// of KMS with the isolation and control of a key store that you own and manage.
    /// </para><para>
    /// Before you create the custom key store, the required elements must be in place and
    /// operational. We recommend that you use the test tools that KMS provides to verify
    /// the configuration your external key store proxy. For details about the required elements
    /// and verification tests, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keystore.html#before-keystore">Assemble
    /// the prerequisites (for CloudHSM key stores)</a> or <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-xks-keystore.html#xks-requirements">Assemble
    /// the prerequisites (for external key stores)</a> in the <i>Key Management Service Developer
    /// Guide</i>.
    /// </para><para>
    /// To create a custom key store, use the following parameters.
    /// </para><ul><li><para>
    /// To create an CloudHSM key store, specify the <code>CustomKeyStoreName</code>, <code>CloudHsmClusterId</code>,
    /// <code>KeyStorePassword</code>, and <code>TrustAnchorCertificate</code>. The <code>CustomKeyStoreType</code>
    /// parameter is optional for CloudHSM key stores. If you include it, set it to the default
    /// value, <code>AWS_CLOUDHSM</code>. For help with failures, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshooting
    /// an CloudHSM key store</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para></li><li><para>
    /// To create an external key store, specify the <code>CustomKeyStoreName</code> and a
    /// <code>CustomKeyStoreType</code> of <code>EXTERNAL_KEY_STORE</code>. Also, specify
    /// values for <code>XksProxyConnectivity</code>, <code>XksProxyAuthenticationCredential</code>,
    /// <code>XksProxyUriEndpoint</code>, and <code>XksProxyUriPath</code>. If your <code>XksProxyConnectivity</code>
    /// value is <code>VPC_ENDPOINT_SERVICE</code>, specify the <code>XksProxyVpcEndpointServiceName</code>
    /// parameter. For help with failures, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/xks-troubleshooting.html">Troubleshooting
    /// an external key store</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para></li></ul><note><para>
    /// For external key stores:
    /// </para><para>
    /// Some external key managers provide a simpler method for creating an external key store.
    /// For details, see your external key manager documentation.
    /// </para><para>
    /// When creating an external key store in the KMS console, you can upload a JSON-based
    /// proxy configuration file with the desired values. You cannot use a proxy configuration
    /// with the <code>CreateCustomKeyStore</code> operation. However, you can use the values
    /// in the file to help you determine the correct values for the <code>CreateCustomKeyStore</code>
    /// parameters.
    /// </para></note><para>
    /// When the operation completes successfully, it returns the ID of the new custom key
    /// store. Before you can use your new custom key store, you need to use the <a>ConnectCustomKeyStore</a>
    /// operation to connect a new CloudHSM key store to its CloudHSM cluster, or to connect
    /// a new external key store to the external key store proxy for your external key manager.
    /// Even if you are not going to use your custom key store immediately, you might want
    /// to connect it to verify that all settings are correct and then disconnect it until
    /// you are ready to use it.
    /// </para><para>
    /// For help with failures, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/fix-keystore.html">Troubleshooting
    /// a custom key store</a> in the <i>Key Management Service Developer Guide</i>.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a custom key store
    /// in a different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:CreateCustomKeyStore</a>
    /// (IAM policy).
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ConnectCustomKeyStore</a></para></li><li><para><a>DeleteCustomKeyStore</a></para></li><li><para><a>DescribeCustomKeyStores</a></para></li><li><para><a>DisconnectCustomKeyStore</a></para></li><li><para><a>UpdateCustomKeyStore</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Key Management Service CreateCustomKeyStore API operation.", Operation = new[] {"CreateCustomKeyStore"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse))]
    [AWSCmdletOutput("System.String or Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter XksProxyAuthenticationCredential_AccessKeyId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the raw secret access key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyAuthenticationCredential_AccessKeyId { get; set; }
        #endregion
        
        #region Parameter CloudHsmClusterId
        /// <summary>
        /// <para>
        /// <para>Identifies the CloudHSM cluster for an CloudHSM key store. This parameter is required
        /// for custom key stores with <code>CustomKeyStoreType</code> of <code>AWS_CLOUDHSM</code>.</para><para>Enter the cluster ID of any active CloudHSM cluster that is not already associated
        /// with a custom key store. To find the cluster ID, use the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudHsmClusterId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Specifies a friendly name for the custom key store. The name must be unique in your
        /// Amazon Web Services account and Region. This parameter is required for all custom
        /// key stores.</para>
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
        public System.String CustomKeyStoreName { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreType
        /// <summary>
        /// <para>
        /// <para>Specifies the type of custom key store. The default value is <code>AWS_CLOUDHSM</code>.</para><para>For a custom key store backed by an CloudHSM cluster, omit the parameter or enter
        /// <code>AWS_CLOUDHSM</code>. For a custom key store backed by an external key manager
        /// outside of Amazon Web Services, enter <code>EXTERNAL_KEY_STORE</code>. You cannot
        /// change this property after the key store is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.CustomKeyStoreType")]
        public Amazon.KeyManagementService.CustomKeyStoreType CustomKeyStoreType { get; set; }
        #endregion
        
        #region Parameter KeyStorePassword
        /// <summary>
        /// <para>
        /// <para>Specifies the <code>kmsuser</code> password for an CloudHSM key store. This parameter
        /// is required for custom key stores with a <code>CustomKeyStoreType</code> of <code>AWS_CLOUDHSM</code>.</para><para>Enter the password of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/key-store-concepts.html#concept-kmsuser"><code>kmsuser</code> crypto user (CU) account</a> in the specified CloudHSM cluster.
        /// KMS logs into the cluster as this user to manage key material on your behalf.</para><para>The password must be a string of 7 to 32 characters. Its value is case sensitive.</para><para>This parameter tells KMS the <code>kmsuser</code> account password; it does not change
        /// the password in the CloudHSM cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyStorePassword { get; set; }
        #endregion
        
        #region Parameter XksProxyAuthenticationCredential_RawSecretAccessKey
        /// <summary>
        /// <para>
        /// <para>A secret string of 43-64 characters. Valid characters are a-z, A-Z, 0-9, /, +, and
        /// =.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyAuthenticationCredential_RawSecretAccessKey { get; set; }
        #endregion
        
        #region Parameter TrustAnchorCertificate
        /// <summary>
        /// <para>
        /// <para>* CreateCustom</para><para>Specifies the certificate for an CloudHSM key store. This parameter is required for
        /// custom key stores with a <code>CustomKeyStoreType</code> of <code>AWS_CLOUDHSM</code>.</para><para>Enter the content of the trust anchor certificate for the CloudHSM cluster. This is
        /// the content of the <code>customerCA.crt</code> file that you created when you <a href="https://docs.aws.amazon.com/cloudhsm/latest/userguide/initialize-cluster.html">initialized
        /// the cluster</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrustAnchorCertificate { get; set; }
        #endregion
        
        #region Parameter XksProxyConnectivity
        /// <summary>
        /// <para>
        /// <para>Indicates how KMS communicates with the external key store proxy. This parameter is
        /// required for custom key stores with a <code>CustomKeyStoreType</code> of <code>EXTERNAL_KEY_STORE</code>.</para><para>If the external key store proxy uses a public endpoint, specify <code>PUBLIC_ENDPOINT</code>.
        /// If the external key store proxy uses a Amazon VPC endpoint service for communication
        /// with KMS, specify <code>VPC_ENDPOINT_SERVICE</code>. For help making this choice,
        /// see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/plan-xks-keystore.html#choose-xks-connectivity">Choosing
        /// a connectivity option</a> in the <i>Key Management Service Developer Guide</i>.</para><para>An Amazon VPC endpoint service keeps your communication with KMS in a private address
        /// space entirely within Amazon Web Services, but it requires more configuration, including
        /// establishing a Amazon VPC with multiple subnets, a VPC endpoint service, a network
        /// load balancer, and a verified private DNS name. A public endpoint is simpler to set
        /// up, but it might be slower and might not fulfill your security requirements. You might
        /// consider testing with a public endpoint, and then establishing a VPC endpoint service
        /// for production tasks. Note that this choice does not determine the location of the
        /// external key store proxy. Even if you choose a VPC endpoint service, the proxy can
        /// be hosted within the VPC or outside of Amazon Web Services such as in your corporate
        /// data center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.XksProxyConnectivityType")]
        public Amazon.KeyManagementService.XksProxyConnectivityType XksProxyConnectivity { get; set; }
        #endregion
        
        #region Parameter XksProxyUriEndpoint
        /// <summary>
        /// <para>
        /// <para>Specifies the endpoint that KMS uses to send requests to the external key store proxy
        /// (XKS proxy). This parameter is required for custom key stores with a <code>CustomKeyStoreType</code>
        /// of <code>EXTERNAL_KEY_STORE</code>.</para><para>The protocol must be HTTPS. KMS communicates on port 443. Do not specify the port
        /// in the <code>XksProxyUriEndpoint</code> value.</para><para>For external key stores with <code>XksProxyConnectivity</code> value of <code>VPC_ENDPOINT_SERVICE</code>,
        /// specify <code>https://</code> followed by the private DNS name of the VPC endpoint
        /// service.</para><para>For external key stores with <code>PUBLIC_ENDPOINT</code> connectivity, this endpoint
        /// must be reachable before you create the custom key store. KMS connects to the external
        /// key store proxy while creating the custom key store. For external key stores with
        /// <code>VPC_ENDPOINT_SERVICE</code> connectivity, KMS connects when you call the <a>ConnectCustomKeyStore</a>
        /// operation.</para><para>The value of this parameter must begin with <code>https://</code>. The remainder can
        /// contain upper and lower case letters (A-Z and a-z), numbers (0-9), dots (<code>.</code>),
        /// and hyphens (<code>-</code>). Additional slashes (<code>/</code> and <code>\</code>)
        /// are not permitted.</para><para><b>Uniqueness requirements: </b></para><ul><li><para>The combined <code>XksProxyUriEndpoint</code> and <code>XksProxyUriPath</code> values
        /// must be unique in the Amazon Web Services account and Region.</para></li><li><para>An external key store with <code>PUBLIC_ENDPOINT</code> connectivity cannot use the
        /// same <code>XksProxyUriEndpoint</code> value as an external key store with <code>VPC_ENDPOINT_SERVICE</code>
        /// connectivity in the same Amazon Web Services Region.</para></li><li><para>Each external key store with <code>VPC_ENDPOINT_SERVICE</code> connectivity must have
        /// its own private DNS name. The <code>XksProxyUriEndpoint</code> value for external
        /// key stores with <code>VPC_ENDPOINT_SERVICE</code> connectivity (private DNS name)
        /// must be unique in the Amazon Web Services account and Region.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyUriEndpoint { get; set; }
        #endregion
        
        #region Parameter XksProxyUriPath
        /// <summary>
        /// <para>
        /// <para>Specifies the base path to the proxy APIs for this external key store. To find this
        /// value, see the documentation for your external key store proxy. This parameter is
        /// required for all custom key stores with a <code>CustomKeyStoreType</code> of <code>EXTERNAL_KEY_STORE</code>.</para><para>The value must start with <code>/</code> and must end with <code>/kms/xks/v1</code>
        /// where <code>v1</code> represents the version of the KMS external key store proxy API.
        /// This path can include an optional prefix between the required elements such as <code>/<i>prefix</i>/kms/xks/v1</code>.</para><para><b>Uniqueness requirements: </b></para><ul><li><para>The combined <code>XksProxyUriEndpoint</code> and <code>XksProxyUriPath</code> values
        /// must be unique in the Amazon Web Services account and Region.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyUriPath { get; set; }
        #endregion
        
        #region Parameter XksProxyVpcEndpointServiceName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Amazon VPC endpoint service for interface endpoints that
        /// is used to communicate with your external key store proxy (XKS proxy). This parameter
        /// is required when the value of <code>CustomKeyStoreType</code> is <code>EXTERNAL_KEY_STORE</code>
        /// and the value of <code>XksProxyConnectivity</code> is <code>VPC_ENDPOINT_SERVICE</code>.</para><para>The Amazon VPC endpoint service must <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-xks-keystore.html#xks-requirements">fulfill
        /// all requirements</a> for use with an external key store. </para><para><b>Uniqueness requirements:</b></para><ul><li><para>External key stores with <code>VPC_ENDPOINT_SERVICE</code> connectivity can share
        /// an Amazon VPC, but each external key store must have its own VPC endpoint service
        /// and private DNS name.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyVpcEndpointServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomKeyStoreId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse).
        /// Specifying the name of a property of type Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomKeyStoreId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomKeyStoreName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomKeyStoreName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KMSCustomKeyStore (CreateCustomKeyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse, NewKMSCustomKeyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomKeyStoreName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudHsmClusterId = this.CloudHsmClusterId;
            context.CustomKeyStoreName = this.CustomKeyStoreName;
            #if MODULAR
            if (this.CustomKeyStoreName == null && ParameterWasBound(nameof(this.CustomKeyStoreName)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomKeyStoreName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomKeyStoreType = this.CustomKeyStoreType;
            context.KeyStorePassword = this.KeyStorePassword;
            context.TrustAnchorCertificate = this.TrustAnchorCertificate;
            context.XksProxyAuthenticationCredential_AccessKeyId = this.XksProxyAuthenticationCredential_AccessKeyId;
            context.XksProxyAuthenticationCredential_RawSecretAccessKey = this.XksProxyAuthenticationCredential_RawSecretAccessKey;
            context.XksProxyConnectivity = this.XksProxyConnectivity;
            context.XksProxyUriEndpoint = this.XksProxyUriEndpoint;
            context.XksProxyUriPath = this.XksProxyUriPath;
            context.XksProxyVpcEndpointServiceName = this.XksProxyVpcEndpointServiceName;
            
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
            var request = new Amazon.KeyManagementService.Model.CreateCustomKeyStoreRequest();
            
            if (cmdletContext.CloudHsmClusterId != null)
            {
                request.CloudHsmClusterId = cmdletContext.CloudHsmClusterId;
            }
            if (cmdletContext.CustomKeyStoreName != null)
            {
                request.CustomKeyStoreName = cmdletContext.CustomKeyStoreName;
            }
            if (cmdletContext.CustomKeyStoreType != null)
            {
                request.CustomKeyStoreType = cmdletContext.CustomKeyStoreType;
            }
            if (cmdletContext.KeyStorePassword != null)
            {
                request.KeyStorePassword = cmdletContext.KeyStorePassword;
            }
            if (cmdletContext.TrustAnchorCertificate != null)
            {
                request.TrustAnchorCertificate = cmdletContext.TrustAnchorCertificate;
            }
            
             // populate XksProxyAuthenticationCredential
            var requestXksProxyAuthenticationCredentialIsNull = true;
            request.XksProxyAuthenticationCredential = new Amazon.KeyManagementService.Model.XksProxyAuthenticationCredentialType();
            System.String requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_AccessKeyId = null;
            if (cmdletContext.XksProxyAuthenticationCredential_AccessKeyId != null)
            {
                requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_AccessKeyId = cmdletContext.XksProxyAuthenticationCredential_AccessKeyId;
            }
            if (requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_AccessKeyId != null)
            {
                request.XksProxyAuthenticationCredential.AccessKeyId = requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_AccessKeyId;
                requestXksProxyAuthenticationCredentialIsNull = false;
            }
            System.String requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_RawSecretAccessKey = null;
            if (cmdletContext.XksProxyAuthenticationCredential_RawSecretAccessKey != null)
            {
                requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_RawSecretAccessKey = cmdletContext.XksProxyAuthenticationCredential_RawSecretAccessKey;
            }
            if (requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_RawSecretAccessKey != null)
            {
                request.XksProxyAuthenticationCredential.RawSecretAccessKey = requestXksProxyAuthenticationCredential_xksProxyAuthenticationCredential_RawSecretAccessKey;
                requestXksProxyAuthenticationCredentialIsNull = false;
            }
             // determine if request.XksProxyAuthenticationCredential should be set to null
            if (requestXksProxyAuthenticationCredentialIsNull)
            {
                request.XksProxyAuthenticationCredential = null;
            }
            if (cmdletContext.XksProxyConnectivity != null)
            {
                request.XksProxyConnectivity = cmdletContext.XksProxyConnectivity;
            }
            if (cmdletContext.XksProxyUriEndpoint != null)
            {
                request.XksProxyUriEndpoint = cmdletContext.XksProxyUriEndpoint;
            }
            if (cmdletContext.XksProxyUriPath != null)
            {
                request.XksProxyUriPath = cmdletContext.XksProxyUriPath;
            }
            if (cmdletContext.XksProxyVpcEndpointServiceName != null)
            {
                request.XksProxyVpcEndpointServiceName = cmdletContext.XksProxyVpcEndpointServiceName;
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
        
        private Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.CreateCustomKeyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "CreateCustomKeyStore");
            try
            {
                #if DESKTOP
                return client.CreateCustomKeyStore(request);
                #elif CORECLR
                return client.CreateCustomKeyStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudHsmClusterId { get; set; }
            public System.String CustomKeyStoreName { get; set; }
            public Amazon.KeyManagementService.CustomKeyStoreType CustomKeyStoreType { get; set; }
            public System.String KeyStorePassword { get; set; }
            public System.String TrustAnchorCertificate { get; set; }
            public System.String XksProxyAuthenticationCredential_AccessKeyId { get; set; }
            public System.String XksProxyAuthenticationCredential_RawSecretAccessKey { get; set; }
            public Amazon.KeyManagementService.XksProxyConnectivityType XksProxyConnectivity { get; set; }
            public System.String XksProxyUriEndpoint { get; set; }
            public System.String XksProxyUriPath { get; set; }
            public System.String XksProxyVpcEndpointServiceName { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.CreateCustomKeyStoreResponse, NewKMSCustomKeyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomKeyStoreId;
        }
        
    }
}
