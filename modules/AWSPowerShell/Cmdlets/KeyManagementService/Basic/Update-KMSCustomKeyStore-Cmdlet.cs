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
    /// Changes the properties of a custom key store. You can use this operation to change
    /// the properties of an CloudHSM key store or an external key store.
    /// 
    ///  
    /// <para>
    /// Use the required <c>CustomKeyStoreId</c> parameter to identify the custom key store.
    /// Use the remaining optional parameters to change its properties. This operation does
    /// not return any property values. To verify the updated property values, use the <a>DescribeCustomKeyStores</a>
    /// operation.
    /// </para><para>
    ///  This operation is part of the <a href="https://docs.aws.amazon.com/kms/latest/developerguide/custom-key-store-overview.html">custom
    /// key stores</a> feature in KMS, which combines the convenience and extensive integration
    /// of KMS with the isolation and control of a key store that you own and manage.
    /// </para><important><para>
    /// When updating the properties of an external key store, verify that the updated settings
    /// connect your key store, via the external key store proxy, to the same external key
    /// manager as the previous settings, or to a backup or snapshot of the external key manager
    /// with the same cryptographic keys. If the updated connection settings fail, you can
    /// fix them and retry, although an extended delay might disrupt Amazon Web Services services.
    /// However, if KMS permanently loses its access to cryptographic keys, ciphertext encrypted
    /// under those keys is unrecoverable.
    /// </para></important><note><para>
    /// For external key stores:
    /// </para><para>
    /// Some external key managers provide a simpler method for updating an external key store.
    /// For details, see your external key manager documentation.
    /// </para><para>
    /// When updating an external key store in the KMS console, you can upload a JSON-based
    /// proxy configuration file with the desired values. You cannot upload the proxy configuration
    /// file to the <c>UpdateCustomKeyStore</c> operation. However, you can use the file to
    /// help you determine the correct values for the <c>UpdateCustomKeyStore</c> parameters.
    /// </para></note><para>
    /// For an CloudHSM key store, you can use this operation to change the custom key store
    /// friendly name (<c>NewCustomKeyStoreName</c>), to tell KMS about a change to the <c>kmsuser</c>
    /// crypto user password (<c>KeyStorePassword</c>), or to associate the custom key store
    /// with a different, but related, CloudHSM cluster (<c>CloudHsmClusterId</c>). To update
    /// any property of an CloudHSM key store, the <c>ConnectionState</c> of the CloudHSM
    /// key store must be <c>DISCONNECTED</c>. 
    /// </para><para>
    /// For an external key store, you can use this operation to change the custom key store
    /// friendly name (<c>NewCustomKeyStoreName</c>), or to tell KMS about a change to the
    /// external key store proxy authentication credentials (<c>XksProxyAuthenticationCredential</c>),
    /// connection method (<c>XksProxyConnectivity</c>), external proxy endpoint (<c>XksProxyUriEndpoint</c>)
    /// and path (<c>XksProxyUriPath</c>). For external key stores with an <c>XksProxyConnectivity</c>
    /// of <c>VPC_ENDPOINT_SERVICE</c>, you can also update the Amazon VPC endpoint service
    /// name (<c>XksProxyVpcEndpointServiceName</c>). To update most properties of an external
    /// key store, the <c>ConnectionState</c> of the external key store must be <c>DISCONNECTED</c>.
    /// However, you can update the <c>CustomKeyStoreName</c>, <c>XksProxyAuthenticationCredential</c>,
    /// and <c>XksProxyUriPath</c> of an external key store when it is in the CONNECTED or
    /// DISCONNECTED state. 
    /// </para><para>
    /// If your update requires a <c>DISCONNECTED</c> state, before using <c>UpdateCustomKeyStore</c>,
    /// use the <a>DisconnectCustomKeyStore</a> operation to disconnect the custom key store.
    /// After the <c>UpdateCustomKeyStore</c> operation completes, use the <a>ConnectCustomKeyStore</a>
    /// to reconnect the custom key store. To find the <c>ConnectionState</c> of the custom
    /// key store, use the <a>DescribeCustomKeyStores</a> operation. 
    /// </para><para></para><para>
    /// Before updating the custom key store, verify that the new values allow KMS to connect
    /// the custom key store to its backing key store. For example, before you change the
    /// <c>XksProxyUriPath</c> value, verify that the external key store proxy is reachable
    /// at the new path.
    /// </para><para>
    /// If the operation succeeds, it returns a JSON object with no properties.
    /// </para><para><b>Cross-account use</b>: No. You cannot perform this operation on a custom key store
    /// in a different Amazon Web Services account.
    /// </para><para><b>Required permissions</b>: <a href="https://docs.aws.amazon.com/kms/latest/developerguide/kms-api-permissions-reference.html">kms:UpdateCustomKeyStore</a>
    /// (IAM policy)
    /// </para><para><b>Related operations:</b></para><ul><li><para><a>ConnectCustomKeyStore</a></para></li><li><para><a>CreateCustomKeyStore</a></para></li><li><para><a>DeleteCustomKeyStore</a></para></li><li><para><a>DescribeCustomKeyStores</a></para></li><li><para><a>DisconnectCustomKeyStore</a></para></li></ul><para><b>Eventual consistency</b>: The KMS API follows an eventual consistency model. For
    /// more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/programming-eventual-consistency.html">KMS
    /// eventual consistency</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KMSCustomKeyStore", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Key Management Service UpdateCustomKeyStore API operation.", Operation = new[] {"UpdateCustomKeyStore"}, SelectReturnType = typeof(Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse))]
    [AWSCmdletOutput("None or Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKMSCustomKeyStoreCmdlet : AmazonKeyManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>Associates the custom key store with a related CloudHSM cluster. This parameter is
        /// valid only for custom key stores with a <c>CustomKeyStoreType</c> of <c>AWS_CLOUDHSM</c>.</para><para>Enter the cluster ID of the cluster that you used to create the custom key store or
        /// a cluster that shares a backup history and has the same cluster certificate as the
        /// original cluster. You cannot use this parameter to associate a custom key store with
        /// an unrelated cluster. In addition, the replacement cluster must <a href="https://docs.aws.amazon.com/kms/latest/developerguide/create-keystore.html#before-keystore">fulfill
        /// the requirements</a> for a cluster associated with a custom key store. To view the
        /// cluster certificate of a cluster, use the <a href="https://docs.aws.amazon.com/cloudhsm/latest/APIReference/API_DescribeClusters.html">DescribeClusters</a>
        /// operation.</para><para>To change this value, the CloudHSM key store must be disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudHsmClusterId { get; set; }
        #endregion
        
        #region Parameter CustomKeyStoreId
        /// <summary>
        /// <para>
        /// <para>Identifies the custom key store that you want to update. Enter the ID of the custom
        /// key store. To find the ID of a custom key store, use the <a>DescribeCustomKeyStores</a>
        /// operation.</para>
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
        public System.String CustomKeyStoreId { get; set; }
        #endregion
        
        #region Parameter KeyStorePassword
        /// <summary>
        /// <para>
        /// <para>Enter the current password of the <c>kmsuser</c> crypto user (CU) in the CloudHSM
        /// cluster that is associated with the custom key store. This parameter is valid only
        /// for custom key stores with a <c>CustomKeyStoreType</c> of <c>AWS_CLOUDHSM</c>.</para><para>This parameter tells KMS the current password of the <c>kmsuser</c> crypto user (CU).
        /// It does not set or change the password of any users in the CloudHSM cluster.</para><para>To change this value, the CloudHSM key store must be disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyStorePassword { get; set; }
        #endregion
        
        #region Parameter NewCustomKeyStoreName
        /// <summary>
        /// <para>
        /// <para>Changes the friendly name of the custom key store to the value that you specify. The
        /// custom key store name must be unique in the Amazon Web Services account.</para><important><para>Do not include confidential or sensitive information in this field. This field may
        /// be displayed in plaintext in CloudTrail logs and other output.</para></important><para>To change this value, an CloudHSM key store must be disconnected. An external key
        /// store can be connected or disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NewCustomKeyStoreName { get; set; }
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
        
        #region Parameter XksProxyConnectivity
        /// <summary>
        /// <para>
        /// <para>Changes the connectivity setting for the external key store. To indicate that the
        /// external key store proxy uses a Amazon VPC endpoint service to communicate with KMS,
        /// specify <c>VPC_ENDPOINT_SERVICE</c>. Otherwise, specify <c>PUBLIC_ENDPOINT</c>.</para><para>If you change the <c>XksProxyConnectivity</c> to <c>VPC_ENDPOINT_SERVICE</c>, you
        /// must also change the <c>XksProxyUriEndpoint</c> and add an <c>XksProxyVpcEndpointServiceName</c>
        /// value. </para><para>If you change the <c>XksProxyConnectivity</c> to <c>PUBLIC_ENDPOINT</c>, you must
        /// also change the <c>XksProxyUriEndpoint</c> and specify a null or empty string for
        /// the <c>XksProxyVpcEndpointServiceName</c> value.</para><para>To change this value, the external key store must be disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KeyManagementService.XksProxyConnectivityType")]
        public Amazon.KeyManagementService.XksProxyConnectivityType XksProxyConnectivity { get; set; }
        #endregion
        
        #region Parameter XksProxyUriEndpoint
        /// <summary>
        /// <para>
        /// <para>Changes the URI endpoint that KMS uses to connect to your external key store proxy
        /// (XKS proxy). This parameter is valid only for custom key stores with a <c>CustomKeyStoreType</c>
        /// of <c>EXTERNAL_KEY_STORE</c>.</para><para>For external key stores with an <c>XksProxyConnectivity</c> value of <c>PUBLIC_ENDPOINT</c>,
        /// the protocol must be HTTPS.</para><para>For external key stores with an <c>XksProxyConnectivity</c> value of <c>VPC_ENDPOINT_SERVICE</c>,
        /// specify <c>https://</c> followed by the private DNS name associated with the VPC endpoint
        /// service. Each external key store must use a different private DNS name.</para><para>The combined <c>XksProxyUriEndpoint</c> and <c>XksProxyUriPath</c> values must be
        /// unique in the Amazon Web Services account and Region.</para><para>To change this value, the external key store must be disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyUriEndpoint { get; set; }
        #endregion
        
        #region Parameter XksProxyUriPath
        /// <summary>
        /// <para>
        /// <para>Changes the base path to the proxy APIs for this external key store. To find this
        /// value, see the documentation for your external key manager and external key store
        /// proxy (XKS proxy). This parameter is valid only for custom key stores with a <c>CustomKeyStoreType</c>
        /// of <c>EXTERNAL_KEY_STORE</c>.</para><para>The value must start with <c>/</c> and must end with <c>/kms/xks/v1</c>, where <c>v1</c>
        /// represents the version of the KMS external key store proxy API. You can include an
        /// optional prefix between the required elements such as <c>/<i>example</i>/kms/xks/v1</c>.</para><para>The combined <c>XksProxyUriEndpoint</c> and <c>XksProxyUriPath</c> values must be
        /// unique in the Amazon Web Services account and Region.</para><para>You can change this value when the external key store is connected or disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyUriPath { get; set; }
        #endregion
        
        #region Parameter XksProxyVpcEndpointServiceName
        /// <summary>
        /// <para>
        /// <para>Changes the name that KMS uses to identify the Amazon VPC endpoint service for your
        /// external key store proxy (XKS proxy). This parameter is valid when the <c>CustomKeyStoreType</c>
        /// is <c>EXTERNAL_KEY_STORE</c> and the <c>XksProxyConnectivity</c> is <c>VPC_ENDPOINT_SERVICE</c>.</para><para>To change this value, the external key store must be disconnected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String XksProxyVpcEndpointServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CustomKeyStoreId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CustomKeyStoreId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CustomKeyStoreId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KMSCustomKeyStore (UpdateCustomKeyStore)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse, UpdateKMSCustomKeyStoreCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CustomKeyStoreId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudHsmClusterId = this.CloudHsmClusterId;
            context.CustomKeyStoreId = this.CustomKeyStoreId;
            #if MODULAR
            if (this.CustomKeyStoreId == null && ParameterWasBound(nameof(this.CustomKeyStoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomKeyStoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyStorePassword = this.KeyStorePassword;
            context.NewCustomKeyStoreName = this.NewCustomKeyStoreName;
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
            var request = new Amazon.KeyManagementService.Model.UpdateCustomKeyStoreRequest();
            
            if (cmdletContext.CloudHsmClusterId != null)
            {
                request.CloudHsmClusterId = cmdletContext.CloudHsmClusterId;
            }
            if (cmdletContext.CustomKeyStoreId != null)
            {
                request.CustomKeyStoreId = cmdletContext.CustomKeyStoreId;
            }
            if (cmdletContext.KeyStorePassword != null)
            {
                request.KeyStorePassword = cmdletContext.KeyStorePassword;
            }
            if (cmdletContext.NewCustomKeyStoreName != null)
            {
                request.NewCustomKeyStoreName = cmdletContext.NewCustomKeyStoreName;
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
        
        private Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse CallAWSServiceOperation(IAmazonKeyManagementService client, Amazon.KeyManagementService.Model.UpdateCustomKeyStoreRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Key Management Service", "UpdateCustomKeyStore");
            try
            {
                #if DESKTOP
                return client.UpdateCustomKeyStore(request);
                #elif CORECLR
                return client.UpdateCustomKeyStoreAsync(request).GetAwaiter().GetResult();
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
            public System.String CustomKeyStoreId { get; set; }
            public System.String KeyStorePassword { get; set; }
            public System.String NewCustomKeyStoreName { get; set; }
            public System.String XksProxyAuthenticationCredential_AccessKeyId { get; set; }
            public System.String XksProxyAuthenticationCredential_RawSecretAccessKey { get; set; }
            public Amazon.KeyManagementService.XksProxyConnectivityType XksProxyConnectivity { get; set; }
            public System.String XksProxyUriEndpoint { get; set; }
            public System.String XksProxyUriPath { get; set; }
            public System.String XksProxyVpcEndpointServiceName { get; set; }
            public System.Func<Amazon.KeyManagementService.Model.UpdateCustomKeyStoreResponse, UpdateKMSCustomKeyStoreCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
