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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Creates the connector, which captures the parameters for a connection for the AS2
    /// or SFTP protocol. For AS2, the connector is required for sending files to an externally
    /// hosted AS2 server. For SFTP, the connector is required when sending files to an SFTP
    /// server or receiving files from an SFTP server. For more details about connectors,
    /// see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/configure-as2-connector.html">Configure
    /// AS2 connectors</a> and <a href="https://docs.aws.amazon.com/transfer/latest/userguide/configure-sftp-connector.html">Create
    /// SFTP connectors</a>.
    /// 
    ///  <note><para>
    /// You must specify exactly one configuration object: either for AS2 (<c>As2Config</c>)
    /// or SFTP (<c>SftpConfig</c>).
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "TFRConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTFRConnectorCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessRole
        /// <summary>
        /// <para>
        /// <para>Connectors are used to send files using either the AS2 or SFTP protocol. For the access
        /// role, provide the Amazon Resource Name (ARN) of the Identity and Access Management
        /// role to use.</para><para><b>For AS2 connectors</b></para><para>With AS2, you can send files by calling <c>StartFileTransfer</c> and specifying the
        /// file paths in the request parameter, <c>SendFilePaths</c>. We use the file’s parent
        /// directory (for example, for <c>--send-file-paths /bucket/dir/file.txt</c>, parent
        /// directory is <c>/bucket/dir/</c>) to temporarily store a processed AS2 message file,
        /// store the MDN when we receive them from the partner, and write a final JSON file containing
        /// relevant metadata of the transmission. So, the <c>AccessRole</c> needs to provide
        /// read and write access to the parent directory of the file location used in the <c>StartFileTransfer</c>
        /// request. Additionally, you need to provide read and write access to the parent directory
        /// of the files that you intend to send with <c>StartFileTransfer</c>.</para><para>If you are using Basic authentication for your AS2 connector, the access role requires
        /// the <c>secretsmanager:GetSecretValue</c> permission for the secret. If the secret
        /// is encrypted using a customer-managed key instead of the Amazon Web Services managed
        /// key in Secrets Manager, then the role also needs the <c>kms:Decrypt</c> permission
        /// for that key.</para><para><b>For SFTP connectors</b></para><para>Make sure that the access role provides read and write access to the parent directory
        /// of the file location that's used in the <c>StartFileTransfer</c> request. Additionally,
        /// make sure that the role provides <c>secretsmanager:GetSecretValue</c> permission to
        /// Secrets Manager.</para>
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
        public System.String AccessRole { get; set; }
        #endregion
        
        #region Parameter As2Config_BasicAuthSecretId
        /// <summary>
        /// <para>
        /// <para>Provides Basic authentication support to the AS2 Connectors API. To use Basic authentication,
        /// you must provide the name or Amazon Resource Name (ARN) of a secret in Secrets Manager.</para><para>The default value for this parameter is <c>null</c>, which indicates that Basic authentication
        /// is not enabled for the connector.</para><para>If the connector should use Basic authentication, the secret needs to be in the following
        /// format:</para><para><c>{ "Username": "user-name", "Password": "user-password" }</c></para><para>Replace <c>user-name</c> and <c>user-password</c> with the credentials for the actual
        /// user that is being authenticated.</para><para>Note the following:</para><ul><li><para>You are storing these credentials in Secrets Manager, <i>not passing them directly</i>
        /// into this API.</para></li><li><para>If you are using the API, SDKs, or CloudFormation to configure your connector, then
        /// you must create the secret before you can enable Basic authentication. However, if
        /// you are using the Amazon Web Services management console, you can have the system
        /// create the secret for you.</para></li></ul><para>If you have previously enabled Basic authentication for a connector, you can disable
        /// it by using the <c>UpdateConnector</c> API call. For example, if you are using the
        /// CLI, you can run the following command to remove Basic authentication:</para><para><c>update-connector --connector-id my-connector-id --as2-config 'BasicAuthSecretId=""'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_BasicAuthSecretId { get; set; }
        #endregion
        
        #region Parameter As2Config_Compression
        /// <summary>
        /// <para>
        /// <para>Specifies whether the AS2 file is compressed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.CompressionEnum")]
        public Amazon.Transfer.CompressionEnum As2Config_Compression { get; set; }
        #endregion
        
        #region Parameter As2Config_EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that is used to encrypt the file.</para><para>Note the following:</para><ul><li><para>Do not use the <c>DES_EDE3_CBC</c> algorithm unless you must support a legacy client
        /// that requires it, as it is a weak encryption algorithm.</para></li><li><para>You can only specify <c>NONE</c> if the URL for your connector uses HTTPS. Using HTTPS
        /// ensures that no traffic is sent in clear text.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EncryptionAlg")]
        public Amazon.Transfer.EncryptionAlg As2Config_EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter As2Config_LocalProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the AS2 local profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_LocalProfileId { get; set; }
        #endregion
        
        #region Parameter LoggingRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// allows a connector to turn on CloudWatch logging for Amazon S3 events. When set, you
        /// can view connector activity in your CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingRole { get; set; }
        #endregion
        
        #region Parameter SftpConfig_MaxConcurrentConnection
        /// <summary>
        /// <para>
        /// <para>Specify the number of concurrent connections that your connector creates to the remote
        /// server. The default value is <c>5</c> (this is also the maximum value allowed).</para><para>This parameter specifies the number of active connections that your connector can
        /// establish with the remote server at the same time. Increasing this value can enhance
        /// connector performance when transferring large file batches by enabling parallel operations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SftpConfig_MaxConcurrentConnections")]
        public System.Int32? SftpConfig_MaxConcurrentConnection { get; set; }
        #endregion
        
        #region Parameter As2Config_MdnResponse
        /// <summary>
        /// <para>
        /// <para>Used for outbound requests (from an Transfer Family connector to a partner AS2 server)
        /// to determine whether the partner response for transfers is synchronous or asynchronous.
        /// Specify either of the following values:</para><ul><li><para><c>SYNC</c>: The system expects a synchronous MDN response, confirming that the file
        /// was transferred successfully (or not).</para></li><li><para><c>NONE</c>: Specifies that no MDN response is required.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.MdnResponse")]
        public Amazon.Transfer.MdnResponse As2Config_MdnResponse { get; set; }
        #endregion
        
        #region Parameter As2Config_MdnSigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The signing algorithm for the MDN response.</para><note><para>If set to DEFAULT (or not set at all), the value for <c>SigningAlgorithm</c> is used.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.MdnSigningAlg")]
        public Amazon.Transfer.MdnSigningAlg As2Config_MdnSigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter As2Config_MessageSubject
        /// <summary>
        /// <para>
        /// <para>Used as the <c>Subject</c> HTTP header attribute in AS2 messages that are being sent
        /// with the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_MessageSubject { get; set; }
        #endregion
        
        #region Parameter As2Config_PartnerProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the partner profile for the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_PartnerProfileId { get; set; }
        #endregion
        
        #region Parameter As2Config_PreserveContentType
        /// <summary>
        /// <para>
        /// <para>Allows you to use the Amazon S3 <c>Content-Type</c> that is associated with objects
        /// in S3 instead of having the content type mapped based on the file extension. This
        /// parameter is enabled by default when you create an AS2 connector from the console,
        /// but disabled by default when you create an AS2 connector by calling the API directly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.PreserveContentType")]
        public Amazon.Transfer.PreserveContentType As2Config_PreserveContentType { get; set; }
        #endregion
        
        #region Parameter SecurityPolicyName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the security policy for the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityPolicyName { get; set; }
        #endregion
        
        #region Parameter As2Config_SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that is used to sign the AS2 messages sent with the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.SigningAlg")]
        public Amazon.Transfer.SigningAlg As2Config_SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for connectors. Tags are metadata
        /// attached to connectors for any purpose.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SftpConfig_TrustedHostKey
        /// <summary>
        /// <para>
        /// <para>The public portion of the host key, or keys, that are used to identify the external
        /// server to which you are connecting. You can use the <c>ssh-keyscan</c> command against
        /// the SFTP server to retrieve the necessary key.</para><note><para><c>TrustedHostKeys</c> is optional for <c>CreateConnector</c>. If not provided, you
        /// can use <c>TestConnection</c> to retrieve the server host key during the initial connection
        /// attempt, and subsequently update the connector with the observed host key.</para></note><para>The three standard SSH public key format elements are <c>&lt;key type&gt;</c>, <c>&lt;body
        /// base64&gt;</c>, and an optional <c>&lt;comment&gt;</c>, with spaces between each element.
        /// Specify only the <c>&lt;key type&gt;</c> and <c>&lt;body base64&gt;</c>: do not enter
        /// the <c>&lt;comment&gt;</c> portion of the key.</para><para>For the trusted host key, Transfer Family accepts RSA and ECDSA keys.</para><ul><li><para>For RSA keys, the <c>&lt;key type&gt;</c> string is <c>ssh-rsa</c>.</para></li><li><para>For ECDSA keys, the <c>&lt;key type&gt;</c> string is either <c>ecdsa-sha2-nistp256</c>,
        /// <c>ecdsa-sha2-nistp384</c>, or <c>ecdsa-sha2-nistp521</c>, depending on the size of
        /// the key you generated.</para></li></ul><para>Run this command to retrieve the SFTP server host key, where your SFTP server name
        /// is <c>ftp.host.com</c>.</para><para><c>ssh-keyscan ftp.host.com</c></para><para>This prints the public host key to standard output.</para><para><c>ftp.host.com ssh-rsa AAAAB3Nza...&lt;long-string-for-public-key</c></para><para>Copy and paste this string into the <c>TrustedHostKeys</c> field for the <c>create-connector</c>
        /// command or into the <b>Trusted host keys</b> field in the console.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SftpConfig_TrustedHostKeys")]
        public System.String[] SftpConfig_TrustedHostKey { get; set; }
        #endregion
        
        #region Parameter Url
        /// <summary>
        /// <para>
        /// <para>The URL of the partner's AS2 or SFTP endpoint.</para>
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
        public System.String Url { get; set; }
        #endregion
        
        #region Parameter SftpConfig_UserSecretId
        /// <summary>
        /// <para>
        /// <para>The identifier for the secret (in Amazon Web Services Secrets Manager) that contains
        /// the SFTP user's private key, password, or both. The identifier must be the Amazon
        /// Resource Name (ARN) of the secret.</para><note><ul><li><para>Required when creating an SFTP connector</para></li><li><para>Optional when updating an existing SFTP connector</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SftpConfig_UserSecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.CreateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorId";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRConnector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateConnectorResponse, NewTFRConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessRole = this.AccessRole;
            #if MODULAR
            if (this.AccessRole == null && ParameterWasBound(nameof(this.AccessRole)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.As2Config_BasicAuthSecretId = this.As2Config_BasicAuthSecretId;
            context.As2Config_Compression = this.As2Config_Compression;
            context.As2Config_EncryptionAlgorithm = this.As2Config_EncryptionAlgorithm;
            context.As2Config_LocalProfileId = this.As2Config_LocalProfileId;
            context.As2Config_MdnResponse = this.As2Config_MdnResponse;
            context.As2Config_MdnSigningAlgorithm = this.As2Config_MdnSigningAlgorithm;
            context.As2Config_MessageSubject = this.As2Config_MessageSubject;
            context.As2Config_PartnerProfileId = this.As2Config_PartnerProfileId;
            context.As2Config_PreserveContentType = this.As2Config_PreserveContentType;
            context.As2Config_SigningAlgorithm = this.As2Config_SigningAlgorithm;
            context.LoggingRole = this.LoggingRole;
            context.SecurityPolicyName = this.SecurityPolicyName;
            context.SftpConfig_MaxConcurrentConnection = this.SftpConfig_MaxConcurrentConnection;
            if (this.SftpConfig_TrustedHostKey != null)
            {
                context.SftpConfig_TrustedHostKey = new List<System.String>(this.SftpConfig_TrustedHostKey);
            }
            context.SftpConfig_UserSecretId = this.SftpConfig_UserSecretId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
            }
            context.Url = this.Url;
            #if MODULAR
            if (this.Url == null && ParameterWasBound(nameof(this.Url)))
            {
                WriteWarning("You are passing $null as a value for parameter Url which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.CreateConnectorRequest();
            
            if (cmdletContext.AccessRole != null)
            {
                request.AccessRole = cmdletContext.AccessRole;
            }
            
             // populate As2Config
            var requestAs2ConfigIsNull = true;
            request.As2Config = new Amazon.Transfer.Model.As2ConnectorConfig();
            System.String requestAs2Config_as2Config_BasicAuthSecretId = null;
            if (cmdletContext.As2Config_BasicAuthSecretId != null)
            {
                requestAs2Config_as2Config_BasicAuthSecretId = cmdletContext.As2Config_BasicAuthSecretId;
            }
            if (requestAs2Config_as2Config_BasicAuthSecretId != null)
            {
                request.As2Config.BasicAuthSecretId = requestAs2Config_as2Config_BasicAuthSecretId;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.CompressionEnum requestAs2Config_as2Config_Compression = null;
            if (cmdletContext.As2Config_Compression != null)
            {
                requestAs2Config_as2Config_Compression = cmdletContext.As2Config_Compression;
            }
            if (requestAs2Config_as2Config_Compression != null)
            {
                request.As2Config.Compression = requestAs2Config_as2Config_Compression;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.EncryptionAlg requestAs2Config_as2Config_EncryptionAlgorithm = null;
            if (cmdletContext.As2Config_EncryptionAlgorithm != null)
            {
                requestAs2Config_as2Config_EncryptionAlgorithm = cmdletContext.As2Config_EncryptionAlgorithm;
            }
            if (requestAs2Config_as2Config_EncryptionAlgorithm != null)
            {
                request.As2Config.EncryptionAlgorithm = requestAs2Config_as2Config_EncryptionAlgorithm;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_LocalProfileId = null;
            if (cmdletContext.As2Config_LocalProfileId != null)
            {
                requestAs2Config_as2Config_LocalProfileId = cmdletContext.As2Config_LocalProfileId;
            }
            if (requestAs2Config_as2Config_LocalProfileId != null)
            {
                request.As2Config.LocalProfileId = requestAs2Config_as2Config_LocalProfileId;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.MdnResponse requestAs2Config_as2Config_MdnResponse = null;
            if (cmdletContext.As2Config_MdnResponse != null)
            {
                requestAs2Config_as2Config_MdnResponse = cmdletContext.As2Config_MdnResponse;
            }
            if (requestAs2Config_as2Config_MdnResponse != null)
            {
                request.As2Config.MdnResponse = requestAs2Config_as2Config_MdnResponse;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.MdnSigningAlg requestAs2Config_as2Config_MdnSigningAlgorithm = null;
            if (cmdletContext.As2Config_MdnSigningAlgorithm != null)
            {
                requestAs2Config_as2Config_MdnSigningAlgorithm = cmdletContext.As2Config_MdnSigningAlgorithm;
            }
            if (requestAs2Config_as2Config_MdnSigningAlgorithm != null)
            {
                request.As2Config.MdnSigningAlgorithm = requestAs2Config_as2Config_MdnSigningAlgorithm;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_MessageSubject = null;
            if (cmdletContext.As2Config_MessageSubject != null)
            {
                requestAs2Config_as2Config_MessageSubject = cmdletContext.As2Config_MessageSubject;
            }
            if (requestAs2Config_as2Config_MessageSubject != null)
            {
                request.As2Config.MessageSubject = requestAs2Config_as2Config_MessageSubject;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_PartnerProfileId = null;
            if (cmdletContext.As2Config_PartnerProfileId != null)
            {
                requestAs2Config_as2Config_PartnerProfileId = cmdletContext.As2Config_PartnerProfileId;
            }
            if (requestAs2Config_as2Config_PartnerProfileId != null)
            {
                request.As2Config.PartnerProfileId = requestAs2Config_as2Config_PartnerProfileId;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.PreserveContentType requestAs2Config_as2Config_PreserveContentType = null;
            if (cmdletContext.As2Config_PreserveContentType != null)
            {
                requestAs2Config_as2Config_PreserveContentType = cmdletContext.As2Config_PreserveContentType;
            }
            if (requestAs2Config_as2Config_PreserveContentType != null)
            {
                request.As2Config.PreserveContentType = requestAs2Config_as2Config_PreserveContentType;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.SigningAlg requestAs2Config_as2Config_SigningAlgorithm = null;
            if (cmdletContext.As2Config_SigningAlgorithm != null)
            {
                requestAs2Config_as2Config_SigningAlgorithm = cmdletContext.As2Config_SigningAlgorithm;
            }
            if (requestAs2Config_as2Config_SigningAlgorithm != null)
            {
                request.As2Config.SigningAlgorithm = requestAs2Config_as2Config_SigningAlgorithm;
                requestAs2ConfigIsNull = false;
            }
             // determine if request.As2Config should be set to null
            if (requestAs2ConfigIsNull)
            {
                request.As2Config = null;
            }
            if (cmdletContext.LoggingRole != null)
            {
                request.LoggingRole = cmdletContext.LoggingRole;
            }
            if (cmdletContext.SecurityPolicyName != null)
            {
                request.SecurityPolicyName = cmdletContext.SecurityPolicyName;
            }
            
             // populate SftpConfig
            var requestSftpConfigIsNull = true;
            request.SftpConfig = new Amazon.Transfer.Model.SftpConnectorConfig();
            System.Int32? requestSftpConfig_sftpConfig_MaxConcurrentConnection = null;
            if (cmdletContext.SftpConfig_MaxConcurrentConnection != null)
            {
                requestSftpConfig_sftpConfig_MaxConcurrentConnection = cmdletContext.SftpConfig_MaxConcurrentConnection.Value;
            }
            if (requestSftpConfig_sftpConfig_MaxConcurrentConnection != null)
            {
                request.SftpConfig.MaxConcurrentConnections = requestSftpConfig_sftpConfig_MaxConcurrentConnection.Value;
                requestSftpConfigIsNull = false;
            }
            List<System.String> requestSftpConfig_sftpConfig_TrustedHostKey = null;
            if (cmdletContext.SftpConfig_TrustedHostKey != null)
            {
                requestSftpConfig_sftpConfig_TrustedHostKey = cmdletContext.SftpConfig_TrustedHostKey;
            }
            if (requestSftpConfig_sftpConfig_TrustedHostKey != null)
            {
                request.SftpConfig.TrustedHostKeys = requestSftpConfig_sftpConfig_TrustedHostKey;
                requestSftpConfigIsNull = false;
            }
            System.String requestSftpConfig_sftpConfig_UserSecretId = null;
            if (cmdletContext.SftpConfig_UserSecretId != null)
            {
                requestSftpConfig_sftpConfig_UserSecretId = cmdletContext.SftpConfig_UserSecretId;
            }
            if (requestSftpConfig_sftpConfig_UserSecretId != null)
            {
                request.SftpConfig.UserSecretId = requestSftpConfig_sftpConfig_UserSecretId;
                requestSftpConfigIsNull = false;
            }
             // determine if request.SftpConfig should be set to null
            if (requestSftpConfigIsNull)
            {
                request.SftpConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Url != null)
            {
                request.Url = cmdletContext.Url;
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
        
        private Amazon.Transfer.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "CreateConnector");
            try
            {
                return client.CreateConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccessRole { get; set; }
            public System.String As2Config_BasicAuthSecretId { get; set; }
            public Amazon.Transfer.CompressionEnum As2Config_Compression { get; set; }
            public Amazon.Transfer.EncryptionAlg As2Config_EncryptionAlgorithm { get; set; }
            public System.String As2Config_LocalProfileId { get; set; }
            public Amazon.Transfer.MdnResponse As2Config_MdnResponse { get; set; }
            public Amazon.Transfer.MdnSigningAlg As2Config_MdnSigningAlgorithm { get; set; }
            public System.String As2Config_MessageSubject { get; set; }
            public System.String As2Config_PartnerProfileId { get; set; }
            public Amazon.Transfer.PreserveContentType As2Config_PreserveContentType { get; set; }
            public Amazon.Transfer.SigningAlg As2Config_SigningAlgorithm { get; set; }
            public System.String LoggingRole { get; set; }
            public System.String SecurityPolicyName { get; set; }
            public System.Int32? SftpConfig_MaxConcurrentConnection { get; set; }
            public List<System.String> SftpConfig_TrustedHostKey { get; set; }
            public System.String SftpConfig_UserSecretId { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public System.String Url { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateConnectorResponse, NewTFRConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorId;
        }
        
    }
}
