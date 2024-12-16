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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Updates the file transfer protocol-enabled server's properties after that server has
    /// been created.
    /// 
    ///  
    /// <para>
    /// The <c>UpdateServer</c> call returns the <c>ServerId</c> of the server you updated.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TFRServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateServer API operation.", Operation = new[] {"UpdateServer"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateServerResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.UpdateServerResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.UpdateServerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateTFRServerCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndpointDetails_AddressAllocationId
        /// <summary>
        /// <para>
        /// <para>A list of address allocation IDs that are required to attach an Elastic IP address
        /// to your server's endpoint.</para><para>An address allocation ID corresponds to the allocation ID of an Elastic IP address.
        /// This value can be retrieved from the <c>allocationId</c> field from the Amazon EC2
        /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_Address.html">Address</a>
        /// data type. One way to retrieve this value is by calling the EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeAddresses.html">DescribeAddresses</a>
        /// API.</para><para>This parameter is optional. Set this parameter if you want to make your VPC endpoint
        /// public-facing. For details, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/create-server-in-vpc.html#create-internet-facing-endpoint">Create
        /// an internet-facing endpoint for your server</a>.</para><note><para>This property can only be set as follows:</para><ul><li><para><c>EndpointType</c> must be set to <c>VPC</c></para></li><li><para>The Transfer Family server must be offline.</para></li><li><para>You cannot set this parameter for Transfer Family servers that use the FTP protocol.</para></li><li><para>The server must already have <c>SubnetIds</c> populated (<c>SubnetIds</c> and <c>AddressAllocationIds</c>
        /// cannot be updated simultaneously).</para></li><li><para><c>AddressAllocationIds</c> can't contain duplicates, and must be equal in length
        /// to <c>SubnetIds</c>. For example, if you have three subnet IDs, you must also specify
        /// three address allocation IDs.</para></li><li><para>Call the <c>UpdateServer</c> API to set or change this parameter.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_AddressAllocationIds")]
        public System.String[] EndpointDetails_AddressAllocationId { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_As2Transport
        /// <summary>
        /// <para>
        /// <para>Indicates the transport method for the AS2 messages. Currently, only HTTP is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProtocolDetails_As2Transports")]
        public System.String[] ProtocolDetails_As2Transport { get; set; }
        #endregion
        
        #region Parameter Certificate
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web ServicesCertificate Manager (ACM)
        /// certificate. Required when <c>Protocols</c> is set to <c>FTPS</c>.</para><para>To request a new public certificate, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-public.html">Request
        /// a public certificate</a> in the <i> Amazon Web ServicesCertificate Manager User Guide</i>.</para><para>To import an existing certificate into ACM, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/import-certificate.html">Importing
        /// certificates into ACM</a> in the <i> Amazon Web ServicesCertificate Manager User Guide</i>.</para><para>To request a private certificate to use FTPS through private IP addresses, see <a href="https://docs.aws.amazon.com/acm/latest/userguide/gs-acm-request-private.html">Request
        /// a private certificate</a> in the <i> Amazon Web ServicesCertificate Manager User Guide</i>.</para><para>Certificates with the following cryptographic algorithms and key sizes are supported:</para><ul><li><para>2048-bit RSA (RSA_2048)</para></li><li><para>4096-bit RSA (RSA_4096)</para></li><li><para>Elliptic Prime Curve 256 bit (EC_prime256v1)</para></li><li><para>Elliptic Prime Curve 384 bit (EC_secp384r1)</para></li><li><para>Elliptic Prime Curve 521 bit (EC_secp521r1)</para></li></ul><note><para>The certificate must be a valid SSL/TLS X.509 version 3 certificate with FQDN or IP
        /// address specified and information about the issuer.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Certificate { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Directory Service directory that you want to use as your identity
        /// provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_DirectoryId { get; set; }
        #endregion
        
        #region Parameter S3StorageOptions_DirectoryListingOptimization
        /// <summary>
        /// <para>
        /// <para>Specifies whether or not performance for your Amazon S3 directories is optimized.
        /// This is disabled by default.</para><para>By default, home directory mappings have a <c>TYPE</c> of <c>DIRECTORY</c>. If you
        /// enable this option, you would then need to explicitly set the <c>HomeDirectoryMapEntry</c><c>Type</c> to <c>FILE</c> if you want a mapping to have a file target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.DirectoryListingOptimization")]
        public Amazon.Transfer.DirectoryListingOptimization S3StorageOptions_DirectoryListingOptimization { get; set; }
        #endregion
        
        #region Parameter EndpointType
        /// <summary>
        /// <para>
        /// <para>The type of endpoint that you want your server to use. You can choose to make your
        /// server's endpoint publicly accessible (PUBLIC) or host it inside your VPC. With an
        /// endpoint that is hosted in a VPC, you can restrict access to your server and resources
        /// only within your VPC or choose to make it internet facing by attaching Elastic IP
        /// addresses directly to it.</para><note><para> After May 19, 2021, you won't be able to create a server using <c>EndpointType=VPC_ENDPOINT</c>
        /// in your Amazon Web Services account if your account hasn't already done so before
        /// May 19, 2021. If you have already created servers with <c>EndpointType=VPC_ENDPOINT</c>
        /// in your Amazon Web Services account on or before May 19, 2021, you will not be affected.
        /// After this date, use <c>EndpointType</c>=<c>VPC</c>.</para><para>For more information, see https://docs.aws.amazon.com/transfer/latest/userguide/create-server-in-vpc.html#deprecate-vpc-endpoint.</para><para>It is recommended that you use <c>VPC</c> as the <c>EndpointType</c>. With this endpoint
        /// type, you have the option to directly associate up to three Elastic IPv4 addresses
        /// (BYO IP included) with your server's endpoint and use VPC security groups to restrict
        /// traffic by the client's public IP address. This is not possible with <c>EndpointType</c>
        /// set to <c>VPC_ENDPOINT</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EndpointType")]
        public Amazon.Transfer.EndpointType EndpointType { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_Function
        /// <summary>
        /// <para>
        /// <para>The ARN for a Lambda function to use for the Identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_Function { get; set; }
        #endregion
        
        #region Parameter HostKey
        /// <summary>
        /// <para>
        /// <para>The RSA, ECDSA, or ED25519 private key to use for your SFTP-enabled server. You can
        /// add multiple host keys, in case you want to rotate keys, or have a set of active keys
        /// that use different algorithms.</para><para>Use the following command to generate an RSA 2048 bit key with no passphrase:</para><para><c>ssh-keygen -t rsa -b 2048 -N "" -m PEM -f my-new-server-key</c>.</para><para>Use a minimum value of 2048 for the <c>-b</c> option. You can create a stronger key
        /// by using 3072 or 4096.</para><para>Use the following command to generate an ECDSA 256 bit key with no passphrase:</para><para><c>ssh-keygen -t ecdsa -b 256 -N "" -m PEM -f my-new-server-key</c>.</para><para>Valid values for the <c>-b</c> option for ECDSA are 256, 384, and 521.</para><para>Use the following command to generate an ED25519 key with no passphrase:</para><para><c>ssh-keygen -t ed25519 -N "" -f my-new-server-key</c>.</para><para>For all of these commands, you can replace <i>my-new-server-key</i> with a string
        /// of your choice.</para><important><para>If you aren't planning to migrate existing users from an existing SFTP-enabled server
        /// to a new server, don't update the host key. Accidentally changing a server's host
        /// key can be disruptive.</para></important><para>For more information, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/edit-server-config.html#configuring-servers-change-host-key">Manage
        /// host keys for your SFTP-enabled server</a> in the <i>Transfer Family User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostKey { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_InvocationRole
        /// <summary>
        /// <para>
        /// <para>This parameter is only applicable if your <c>IdentityProviderType</c> is <c>API_GATEWAY</c>.
        /// Provides the type of <c>InvocationRole</c> used to authenticate the user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_InvocationRole { get; set; }
        #endregion
        
        #region Parameter LoggingRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// allows a server to turn on Amazon CloudWatch logging for Amazon S3 or Amazon EFSevents.
        /// When set, you can view user activity in your CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingRole { get; set; }
        #endregion
        
        #region Parameter WorkflowDetails_OnPartialUpload
        /// <summary>
        /// <para>
        /// <para>A trigger that starts a workflow if a file is only partially uploaded. You can attach
        /// a workflow to a server that executes whenever there is a partial upload.</para><para>A <i>partial upload</i> occurs when a file is open when the session disconnects.</para><note><para><c>OnPartialUpload</c> can contain a maximum of one <c>WorkflowDetail</c> object.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Transfer.Model.WorkflowDetail[] WorkflowDetails_OnPartialUpload { get; set; }
        #endregion
        
        #region Parameter WorkflowDetails_OnUpload
        /// <summary>
        /// <para>
        /// <para>A trigger that starts a workflow: the workflow begins to execute after a file is uploaded.</para><para>To remove an associated workflow from a server, you can provide an empty <c>OnUpload</c>
        /// object, as in the following example.</para><para><c>aws transfer update-server --server-id s-01234567890abcdef --workflow-details
        /// '{"OnUpload":[]}'</c></para><note><para><c>OnUpload</c> can contain a maximum of one <c>WorkflowDetail</c> object.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Transfer.Model.WorkflowDetail[] WorkflowDetails_OnUpload { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_PassiveIp
        /// <summary>
        /// <para>
        /// <para> Indicates passive mode, for FTP and FTPS protocols. Enter a single IPv4 address,
        /// such as the public IP address of a firewall, router, or load balancer. For example:
        /// </para><para><c>aws transfer update-server --protocol-details PassiveIp=0.0.0.0</c></para><para>Replace <c>0.0.0.0</c> in the example above with the actual IP address you want to
        /// use.</para><note><para> If you change the <c>PassiveIp</c> value, you must stop and then restart your Transfer
        /// Family server for the change to take effect. For details on using passive mode (PASV)
        /// in a NAT environment, see <a href="http://aws.amazon.com/blogs/storage/configuring-your-ftps-server-behind-a-firewall-or-nat-with-aws-transfer-family/">Configuring
        /// your FTPS server behind a firewall or NAT with Transfer Family</a>. </para></note><para><i>Special values</i></para><para>The <c>AUTO</c> and <c>0.0.0.0</c> are special values for the <c>PassiveIp</c> parameter.
        /// The value <c>PassiveIp=AUTO</c> is assigned by default to FTP and FTPS type servers.
        /// In this case, the server automatically responds with one of the endpoint IPs within
        /// the PASV response. <c>PassiveIp=0.0.0.0</c> has a more unique application for its
        /// usage. For example, if you have a High Availability (HA) Network Load Balancer (NLB)
        /// environment, where you have 3 subnets, you can only specify a single IP address using
        /// the <c>PassiveIp</c> parameter. This reduces the effectiveness of having High Availability.
        /// In this case, you can specify <c>PassiveIp=0.0.0.0</c>. This tells the client to use
        /// the same IP address as the Control connection and utilize all AZs for their connections.
        /// Note, however, that not all FTP clients support the <c>PassiveIp=0.0.0.0</c> response.
        /// FileZilla and WinSCP do support it. If you are using other clients, check to see if
        /// your client supports the <c>PassiveIp=0.0.0.0</c> response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProtocolDetails_PassiveIp { get; set; }
        #endregion
        
        #region Parameter PostAuthenticationLoginBanner
        /// <summary>
        /// <para>
        /// <para>Specifies a string to display when users connect to a server. This string is displayed
        /// after the user authenticates.</para><note><para>The SFTP protocol does not support post-authentication display banners.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PostAuthenticationLoginBanner { get; set; }
        #endregion
        
        #region Parameter PreAuthenticationLoginBanner
        /// <summary>
        /// <para>
        /// <para>Specifies a string to display when users connect to a server. This string is displayed
        /// before the user authenticates. For example, the following banner displays details
        /// about using the system:</para><para><c>This system is for the use of authorized users only. Individuals using this computer
        /// system without authority, or in excess of their authority, are subject to having all
        /// of their activities on this system monitored and recorded by system personnel.</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreAuthenticationLoginBanner { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>Specifies the file transfer protocol or protocols over which your file transfer protocol
        /// client can connect to your server's endpoint. The available protocols are:</para><ul><li><para><c>SFTP</c> (Secure Shell (SSH) File Transfer Protocol): File transfer over SSH</para></li><li><para><c>FTPS</c> (File Transfer Protocol Secure): File transfer with TLS encryption</para></li><li><para><c>FTP</c> (File Transfer Protocol): Unencrypted file transfer</para></li><li><para><c>AS2</c> (Applicability Statement 2): used for transporting structured business-to-business
        /// data</para></li></ul><note><ul><li><para>If you select <c>FTPS</c>, you must choose a certificate stored in Certificate Manager
        /// (ACM) which is used to identify your server when clients connect to it over FTPS.</para></li><li><para>If <c>Protocol</c> includes either <c>FTP</c> or <c>FTPS</c>, then the <c>EndpointType</c>
        /// must be <c>VPC</c> and the <c>IdentityProviderType</c> must be either <c>AWS_DIRECTORY_SERVICE</c>,
        /// <c>AWS_LAMBDA</c>, or <c>API_GATEWAY</c>.</para></li><li><para>If <c>Protocol</c> includes <c>FTP</c>, then <c>AddressAllocationIds</c> cannot be
        /// associated.</para></li><li><para>If <c>Protocol</c> is set only to <c>SFTP</c>, the <c>EndpointType</c> can be set
        /// to <c>PUBLIC</c> and the <c>IdentityProviderType</c> can be set any of the supported
        /// identity types: <c>SERVICE_MANAGED</c>, <c>AWS_DIRECTORY_SERVICE</c>, <c>AWS_LAMBDA</c>,
        /// or <c>API_GATEWAY</c>.</para></li><li><para>If <c>Protocol</c> includes <c>AS2</c>, then the <c>EndpointType</c> must be <c>VPC</c>,
        /// and domain must be Amazon S3.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocols")]
        public System.String[] Protocol { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security groups IDs that are available to attach to your server's endpoint.</para><note><para>This property can only be set when <c>EndpointType</c> is set to <c>VPC</c>.</para><para>You can edit the <c>SecurityGroupIds</c> property in the <a href="https://docs.aws.amazon.com/transfer/latest/userguide/API_UpdateServer.html">UpdateServer</a>
        /// API only if you are changing the <c>EndpointType</c> from <c>PUBLIC</c> or <c>VPC_ENDPOINT</c>
        /// to <c>VPC</c>. To change security groups associated with your server's VPC endpoint
        /// after creation, use the Amazon EC2 <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_ModifyVpcEndpoint.html">ModifyVpcEndpoint</a>
        /// API.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SecurityGroupIds")]
        public System.String[] EndpointDetails_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SecurityPolicyName
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the security policy for the server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecurityPolicyName { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a server instance that the Transfer Family
        /// user is assigned to.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_SetStatOption
        /// <summary>
        /// <para>
        /// <para>Use the <c>SetStatOption</c> to ignore the error that is generated when the client
        /// attempts to use <c>SETSTAT</c> on a file you are uploading to an S3 bucket.</para><para>Some SFTP file transfer clients can attempt to change the attributes of remote files,
        /// including timestamp and permissions, using commands, such as <c>SETSTAT</c> when uploading
        /// the file. However, these commands are not compatible with object storage systems,
        /// such as Amazon S3. Due to this incompatibility, file uploads from these clients can
        /// result in errors even when the file is otherwise successfully uploaded.</para><para>Set the value to <c>ENABLE_NO_OP</c> to have the Transfer Family server ignore the
        /// <c>SETSTAT</c> command, and upload files without needing to make any changes to your
        /// SFTP client. While the <c>SetStatOption</c><c>ENABLE_NO_OP</c> setting ignores the
        /// error, it does generate a log entry in Amazon CloudWatch Logs, so you can determine
        /// when the client is making a <c>SETSTAT</c> call.</para><note><para>If you want to preserve the original timestamp for your file, and modify other file
        /// attributes using <c>SETSTAT</c>, you can use Amazon EFS as backend storage with Transfer
        /// Family.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.SetStatOption")]
        public Amazon.Transfer.SetStatOption ProtocolDetails_SetStatOption { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_SftpAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>For SFTP-enabled servers, and for custom identity providers <i>only</i>, you can specify
        /// whether to authenticate using a password, SSH key pair, or both.</para><ul><li><para><c>PASSWORD</c> - users must provide their password to connect.</para></li><li><para><c>PUBLIC_KEY</c> - users must provide their private key to connect.</para></li><li><para><c>PUBLIC_KEY_OR_PASSWORD</c> - users can authenticate with either their password
        /// or their key. This is the default value.</para></li><li><para><c>PUBLIC_KEY_AND_PASSWORD</c> - users must provide both their private key and their
        /// password to connect. The server checks the key first, and then if the key is valid,
        /// the system prompts for a password. If the private key provided does not match the
        /// public key that is stored, authentication fails.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdentityProviderDetails_SftpAuthenticationMethods")]
        [AWSConstantClassSource("Amazon.Transfer.SftpAuthenticationMethods")]
        public Amazon.Transfer.SftpAuthenticationMethods IdentityProviderDetails_SftpAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter StructuredLogDestination
        /// <summary>
        /// <para>
        /// <para>Specifies the log groups to which your server logs are sent.</para><para>To specify a log group, you must provide the ARN for an existing log group. In this
        /// case, the format of the log group is as follows:</para><para><c>arn:aws:logs:region-name:amazon-account-id:log-group:log-group-name:*</c></para><para>For example, <c>arn:aws:logs:us-east-1:111122223333:log-group:mytestgroup:*</c></para><para>If you have previously specified a log group for a server, you can clear it, and in
        /// effect turn off structured logging, by providing an empty value for this parameter
        /// in an <c>update-server</c> call. For example:</para><para><c>update-server --server-id s-1234567890abcdef0 --structured-log-destinations</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StructuredLogDestinations")]
        public System.String[] StructuredLogDestination { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs that are required to host your server endpoint in your VPC.</para><note><para>This property can only be set when <c>EndpointType</c> is set to <c>VPC</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointDetails_SubnetIds")]
        public System.String[] EndpointDetails_SubnetId { get; set; }
        #endregion
        
        #region Parameter ProtocolDetails_TlsSessionResumptionMode
        /// <summary>
        /// <para>
        /// <para>A property used with Transfer Family servers that use the FTPS protocol. TLS Session
        /// Resumption provides a mechanism to resume or share a negotiated secret key between
        /// the control and data connection for an FTPS session. <c>TlsSessionResumptionMode</c>
        /// determines whether or not the server resumes recent, negotiated sessions through a
        /// unique session ID. This property is available during <c>CreateServer</c> and <c>UpdateServer</c>
        /// calls. If a <c>TlsSessionResumptionMode</c> value is not specified during <c>CreateServer</c>,
        /// it is set to <c>ENFORCED</c> by default.</para><ul><li><para><c>DISABLED</c>: the server does not process TLS session resumption client requests
        /// and creates a new TLS session for each request. </para></li><li><para><c>ENABLED</c>: the server processes and accepts clients that are performing TLS
        /// session resumption. The server doesn't reject client data connections that do not
        /// perform the TLS session resumption client processing.</para></li><li><para><c>ENFORCED</c>: the server processes and accepts clients that are performing TLS
        /// session resumption. The server rejects client data connections that do not perform
        /// the TLS session resumption client processing. Before you set the value to <c>ENFORCED</c>,
        /// test your clients.</para><note><para>Not all FTPS clients perform TLS session resumption. So, if you choose to enforce
        /// TLS session resumption, you prevent any connections from FTPS clients that don't perform
        /// the protocol negotiation. To determine whether or not you can use the <c>ENFORCED</c>
        /// value, you need to test your clients.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.TlsSessionResumptionMode")]
        public Amazon.Transfer.TlsSessionResumptionMode ProtocolDetails_TlsSessionResumptionMode { get; set; }
        #endregion
        
        #region Parameter IdentityProviderDetails_Url
        /// <summary>
        /// <para>
        /// <para>Provides the location of the service endpoint used to authenticate users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityProviderDetails_Url { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>The identifier of the VPC endpoint.</para><note><para>This property can only be set when <c>EndpointType</c> is set to <c>VPC_ENDPOINT</c>.</para><para>For more information, see https://docs.aws.amazon.com/transfer/latest/userguide/create-server-in-vpc.html#deprecate-vpc-endpoint.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter EndpointDetails_VpcId
        /// <summary>
        /// <para>
        /// <para>The VPC identifier of the VPC in which a server's endpoint will be hosted.</para><note><para>This property can only be set when <c>EndpointType</c> is set to <c>VPC</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointDetails_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateServerResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRServer (UpdateServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateServerResponse, UpdateTFRServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Certificate = this.Certificate;
            if (this.EndpointDetails_AddressAllocationId != null)
            {
                context.EndpointDetails_AddressAllocationId = new List<System.String>(this.EndpointDetails_AddressAllocationId);
            }
            if (this.EndpointDetails_SecurityGroupId != null)
            {
                context.EndpointDetails_SecurityGroupId = new List<System.String>(this.EndpointDetails_SecurityGroupId);
            }
            if (this.EndpointDetails_SubnetId != null)
            {
                context.EndpointDetails_SubnetId = new List<System.String>(this.EndpointDetails_SubnetId);
            }
            context.EndpointDetails_VpcEndpointId = this.EndpointDetails_VpcEndpointId;
            context.EndpointDetails_VpcId = this.EndpointDetails_VpcId;
            context.EndpointType = this.EndpointType;
            context.HostKey = this.HostKey;
            context.IdentityProviderDetails_DirectoryId = this.IdentityProviderDetails_DirectoryId;
            context.IdentityProviderDetails_Function = this.IdentityProviderDetails_Function;
            context.IdentityProviderDetails_InvocationRole = this.IdentityProviderDetails_InvocationRole;
            context.IdentityProviderDetails_SftpAuthenticationMethod = this.IdentityProviderDetails_SftpAuthenticationMethod;
            context.IdentityProviderDetails_Url = this.IdentityProviderDetails_Url;
            context.LoggingRole = this.LoggingRole;
            context.PostAuthenticationLoginBanner = this.PostAuthenticationLoginBanner;
            context.PreAuthenticationLoginBanner = this.PreAuthenticationLoginBanner;
            if (this.ProtocolDetails_As2Transport != null)
            {
                context.ProtocolDetails_As2Transport = new List<System.String>(this.ProtocolDetails_As2Transport);
            }
            context.ProtocolDetails_PassiveIp = this.ProtocolDetails_PassiveIp;
            context.ProtocolDetails_SetStatOption = this.ProtocolDetails_SetStatOption;
            context.ProtocolDetails_TlsSessionResumptionMode = this.ProtocolDetails_TlsSessionResumptionMode;
            if (this.Protocol != null)
            {
                context.Protocol = new List<System.String>(this.Protocol);
            }
            context.S3StorageOptions_DirectoryListingOptimization = this.S3StorageOptions_DirectoryListingOptimization;
            context.SecurityPolicyName = this.SecurityPolicyName;
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StructuredLogDestination != null)
            {
                context.StructuredLogDestination = new List<System.String>(this.StructuredLogDestination);
            }
            if (this.WorkflowDetails_OnPartialUpload != null)
            {
                context.WorkflowDetails_OnPartialUpload = new List<Amazon.Transfer.Model.WorkflowDetail>(this.WorkflowDetails_OnPartialUpload);
            }
            if (this.WorkflowDetails_OnUpload != null)
            {
                context.WorkflowDetails_OnUpload = new List<Amazon.Transfer.Model.WorkflowDetail>(this.WorkflowDetails_OnUpload);
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
            var request = new Amazon.Transfer.Model.UpdateServerRequest();
            
            if (cmdletContext.Certificate != null)
            {
                request.Certificate = cmdletContext.Certificate;
            }
            
             // populate EndpointDetails
            var requestEndpointDetailsIsNull = true;
            request.EndpointDetails = new Amazon.Transfer.Model.EndpointDetails();
            List<System.String> requestEndpointDetails_endpointDetails_AddressAllocationId = null;
            if (cmdletContext.EndpointDetails_AddressAllocationId != null)
            {
                requestEndpointDetails_endpointDetails_AddressAllocationId = cmdletContext.EndpointDetails_AddressAllocationId;
            }
            if (requestEndpointDetails_endpointDetails_AddressAllocationId != null)
            {
                request.EndpointDetails.AddressAllocationIds = requestEndpointDetails_endpointDetails_AddressAllocationId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SecurityGroupId = null;
            if (cmdletContext.EndpointDetails_SecurityGroupId != null)
            {
                requestEndpointDetails_endpointDetails_SecurityGroupId = cmdletContext.EndpointDetails_SecurityGroupId;
            }
            if (requestEndpointDetails_endpointDetails_SecurityGroupId != null)
            {
                request.EndpointDetails.SecurityGroupIds = requestEndpointDetails_endpointDetails_SecurityGroupId;
                requestEndpointDetailsIsNull = false;
            }
            List<System.String> requestEndpointDetails_endpointDetails_SubnetId = null;
            if (cmdletContext.EndpointDetails_SubnetId != null)
            {
                requestEndpointDetails_endpointDetails_SubnetId = cmdletContext.EndpointDetails_SubnetId;
            }
            if (requestEndpointDetails_endpointDetails_SubnetId != null)
            {
                request.EndpointDetails.SubnetIds = requestEndpointDetails_endpointDetails_SubnetId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcEndpointId = null;
            if (cmdletContext.EndpointDetails_VpcEndpointId != null)
            {
                requestEndpointDetails_endpointDetails_VpcEndpointId = cmdletContext.EndpointDetails_VpcEndpointId;
            }
            if (requestEndpointDetails_endpointDetails_VpcEndpointId != null)
            {
                request.EndpointDetails.VpcEndpointId = requestEndpointDetails_endpointDetails_VpcEndpointId;
                requestEndpointDetailsIsNull = false;
            }
            System.String requestEndpointDetails_endpointDetails_VpcId = null;
            if (cmdletContext.EndpointDetails_VpcId != null)
            {
                requestEndpointDetails_endpointDetails_VpcId = cmdletContext.EndpointDetails_VpcId;
            }
            if (requestEndpointDetails_endpointDetails_VpcId != null)
            {
                request.EndpointDetails.VpcId = requestEndpointDetails_endpointDetails_VpcId;
                requestEndpointDetailsIsNull = false;
            }
             // determine if request.EndpointDetails should be set to null
            if (requestEndpointDetailsIsNull)
            {
                request.EndpointDetails = null;
            }
            if (cmdletContext.EndpointType != null)
            {
                request.EndpointType = cmdletContext.EndpointType;
            }
            if (cmdletContext.HostKey != null)
            {
                request.HostKey = cmdletContext.HostKey;
            }
            
             // populate IdentityProviderDetails
            var requestIdentityProviderDetailsIsNull = true;
            request.IdentityProviderDetails = new Amazon.Transfer.Model.IdentityProviderDetails();
            System.String requestIdentityProviderDetails_identityProviderDetails_DirectoryId = null;
            if (cmdletContext.IdentityProviderDetails_DirectoryId != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_DirectoryId = cmdletContext.IdentityProviderDetails_DirectoryId;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_DirectoryId != null)
            {
                request.IdentityProviderDetails.DirectoryId = requestIdentityProviderDetails_identityProviderDetails_DirectoryId;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_Function = null;
            if (cmdletContext.IdentityProviderDetails_Function != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_Function = cmdletContext.IdentityProviderDetails_Function;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_Function != null)
            {
                request.IdentityProviderDetails.Function = requestIdentityProviderDetails_identityProviderDetails_Function;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_InvocationRole = null;
            if (cmdletContext.IdentityProviderDetails_InvocationRole != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_InvocationRole = cmdletContext.IdentityProviderDetails_InvocationRole;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_InvocationRole != null)
            {
                request.IdentityProviderDetails.InvocationRole = requestIdentityProviderDetails_identityProviderDetails_InvocationRole;
                requestIdentityProviderDetailsIsNull = false;
            }
            Amazon.Transfer.SftpAuthenticationMethods requestIdentityProviderDetails_identityProviderDetails_SftpAuthenticationMethod = null;
            if (cmdletContext.IdentityProviderDetails_SftpAuthenticationMethod != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_SftpAuthenticationMethod = cmdletContext.IdentityProviderDetails_SftpAuthenticationMethod;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_SftpAuthenticationMethod != null)
            {
                request.IdentityProviderDetails.SftpAuthenticationMethods = requestIdentityProviderDetails_identityProviderDetails_SftpAuthenticationMethod;
                requestIdentityProviderDetailsIsNull = false;
            }
            System.String requestIdentityProviderDetails_identityProviderDetails_Url = null;
            if (cmdletContext.IdentityProviderDetails_Url != null)
            {
                requestIdentityProviderDetails_identityProviderDetails_Url = cmdletContext.IdentityProviderDetails_Url;
            }
            if (requestIdentityProviderDetails_identityProviderDetails_Url != null)
            {
                request.IdentityProviderDetails.Url = requestIdentityProviderDetails_identityProviderDetails_Url;
                requestIdentityProviderDetailsIsNull = false;
            }
             // determine if request.IdentityProviderDetails should be set to null
            if (requestIdentityProviderDetailsIsNull)
            {
                request.IdentityProviderDetails = null;
            }
            if (cmdletContext.LoggingRole != null)
            {
                request.LoggingRole = cmdletContext.LoggingRole;
            }
            if (cmdletContext.PostAuthenticationLoginBanner != null)
            {
                request.PostAuthenticationLoginBanner = cmdletContext.PostAuthenticationLoginBanner;
            }
            if (cmdletContext.PreAuthenticationLoginBanner != null)
            {
                request.PreAuthenticationLoginBanner = cmdletContext.PreAuthenticationLoginBanner;
            }
            
             // populate ProtocolDetails
            var requestProtocolDetailsIsNull = true;
            request.ProtocolDetails = new Amazon.Transfer.Model.ProtocolDetails();
            List<System.String> requestProtocolDetails_protocolDetails_As2Transport = null;
            if (cmdletContext.ProtocolDetails_As2Transport != null)
            {
                requestProtocolDetails_protocolDetails_As2Transport = cmdletContext.ProtocolDetails_As2Transport;
            }
            if (requestProtocolDetails_protocolDetails_As2Transport != null)
            {
                request.ProtocolDetails.As2Transports = requestProtocolDetails_protocolDetails_As2Transport;
                requestProtocolDetailsIsNull = false;
            }
            System.String requestProtocolDetails_protocolDetails_PassiveIp = null;
            if (cmdletContext.ProtocolDetails_PassiveIp != null)
            {
                requestProtocolDetails_protocolDetails_PassiveIp = cmdletContext.ProtocolDetails_PassiveIp;
            }
            if (requestProtocolDetails_protocolDetails_PassiveIp != null)
            {
                request.ProtocolDetails.PassiveIp = requestProtocolDetails_protocolDetails_PassiveIp;
                requestProtocolDetailsIsNull = false;
            }
            Amazon.Transfer.SetStatOption requestProtocolDetails_protocolDetails_SetStatOption = null;
            if (cmdletContext.ProtocolDetails_SetStatOption != null)
            {
                requestProtocolDetails_protocolDetails_SetStatOption = cmdletContext.ProtocolDetails_SetStatOption;
            }
            if (requestProtocolDetails_protocolDetails_SetStatOption != null)
            {
                request.ProtocolDetails.SetStatOption = requestProtocolDetails_protocolDetails_SetStatOption;
                requestProtocolDetailsIsNull = false;
            }
            Amazon.Transfer.TlsSessionResumptionMode requestProtocolDetails_protocolDetails_TlsSessionResumptionMode = null;
            if (cmdletContext.ProtocolDetails_TlsSessionResumptionMode != null)
            {
                requestProtocolDetails_protocolDetails_TlsSessionResumptionMode = cmdletContext.ProtocolDetails_TlsSessionResumptionMode;
            }
            if (requestProtocolDetails_protocolDetails_TlsSessionResumptionMode != null)
            {
                request.ProtocolDetails.TlsSessionResumptionMode = requestProtocolDetails_protocolDetails_TlsSessionResumptionMode;
                requestProtocolDetailsIsNull = false;
            }
             // determine if request.ProtocolDetails should be set to null
            if (requestProtocolDetailsIsNull)
            {
                request.ProtocolDetails = null;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocols = cmdletContext.Protocol;
            }
            
             // populate S3StorageOptions
            var requestS3StorageOptionsIsNull = true;
            request.S3StorageOptions = new Amazon.Transfer.Model.S3StorageOptions();
            Amazon.Transfer.DirectoryListingOptimization requestS3StorageOptions_s3StorageOptions_DirectoryListingOptimization = null;
            if (cmdletContext.S3StorageOptions_DirectoryListingOptimization != null)
            {
                requestS3StorageOptions_s3StorageOptions_DirectoryListingOptimization = cmdletContext.S3StorageOptions_DirectoryListingOptimization;
            }
            if (requestS3StorageOptions_s3StorageOptions_DirectoryListingOptimization != null)
            {
                request.S3StorageOptions.DirectoryListingOptimization = requestS3StorageOptions_s3StorageOptions_DirectoryListingOptimization;
                requestS3StorageOptionsIsNull = false;
            }
             // determine if request.S3StorageOptions should be set to null
            if (requestS3StorageOptionsIsNull)
            {
                request.S3StorageOptions = null;
            }
            if (cmdletContext.SecurityPolicyName != null)
            {
                request.SecurityPolicyName = cmdletContext.SecurityPolicyName;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
            }
            if (cmdletContext.StructuredLogDestination != null)
            {
                request.StructuredLogDestinations = cmdletContext.StructuredLogDestination;
            }
            
             // populate WorkflowDetails
            var requestWorkflowDetailsIsNull = true;
            request.WorkflowDetails = new Amazon.Transfer.Model.WorkflowDetails();
            List<Amazon.Transfer.Model.WorkflowDetail> requestWorkflowDetails_workflowDetails_OnPartialUpload = null;
            if (cmdletContext.WorkflowDetails_OnPartialUpload != null)
            {
                requestWorkflowDetails_workflowDetails_OnPartialUpload = cmdletContext.WorkflowDetails_OnPartialUpload;
            }
            if (requestWorkflowDetails_workflowDetails_OnPartialUpload != null)
            {
                request.WorkflowDetails.OnPartialUpload = requestWorkflowDetails_workflowDetails_OnPartialUpload;
                requestWorkflowDetailsIsNull = false;
            }
            List<Amazon.Transfer.Model.WorkflowDetail> requestWorkflowDetails_workflowDetails_OnUpload = null;
            if (cmdletContext.WorkflowDetails_OnUpload != null)
            {
                requestWorkflowDetails_workflowDetails_OnUpload = cmdletContext.WorkflowDetails_OnUpload;
            }
            if (requestWorkflowDetails_workflowDetails_OnUpload != null)
            {
                request.WorkflowDetails.OnUpload = requestWorkflowDetails_workflowDetails_OnUpload;
                requestWorkflowDetailsIsNull = false;
            }
             // determine if request.WorkflowDetails should be set to null
            if (requestWorkflowDetailsIsNull)
            {
                request.WorkflowDetails = null;
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
        
        private Amazon.Transfer.Model.UpdateServerResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateServer");
            try
            {
                #if DESKTOP
                return client.UpdateServer(request);
                #elif CORECLR
                return client.UpdateServerAsync(request).GetAwaiter().GetResult();
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
            public System.String Certificate { get; set; }
            public List<System.String> EndpointDetails_AddressAllocationId { get; set; }
            public List<System.String> EndpointDetails_SecurityGroupId { get; set; }
            public List<System.String> EndpointDetails_SubnetId { get; set; }
            public System.String EndpointDetails_VpcEndpointId { get; set; }
            public System.String EndpointDetails_VpcId { get; set; }
            public Amazon.Transfer.EndpointType EndpointType { get; set; }
            public System.String HostKey { get; set; }
            public System.String IdentityProviderDetails_DirectoryId { get; set; }
            public System.String IdentityProviderDetails_Function { get; set; }
            public System.String IdentityProviderDetails_InvocationRole { get; set; }
            public Amazon.Transfer.SftpAuthenticationMethods IdentityProviderDetails_SftpAuthenticationMethod { get; set; }
            public System.String IdentityProviderDetails_Url { get; set; }
            public System.String LoggingRole { get; set; }
            public System.String PostAuthenticationLoginBanner { get; set; }
            public System.String PreAuthenticationLoginBanner { get; set; }
            public List<System.String> ProtocolDetails_As2Transport { get; set; }
            public System.String ProtocolDetails_PassiveIp { get; set; }
            public Amazon.Transfer.SetStatOption ProtocolDetails_SetStatOption { get; set; }
            public Amazon.Transfer.TlsSessionResumptionMode ProtocolDetails_TlsSessionResumptionMode { get; set; }
            public List<System.String> Protocol { get; set; }
            public Amazon.Transfer.DirectoryListingOptimization S3StorageOptions_DirectoryListingOptimization { get; set; }
            public System.String SecurityPolicyName { get; set; }
            public System.String ServerId { get; set; }
            public List<System.String> StructuredLogDestination { get; set; }
            public List<Amazon.Transfer.Model.WorkflowDetail> WorkflowDetails_OnPartialUpload { get; set; }
            public List<Amazon.Transfer.Model.WorkflowDetail> WorkflowDetails_OnUpload { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateServerResponse, UpdateTFRServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerId;
        }
        
    }
}
