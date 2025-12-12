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
using Amazon.DataSync;
using Amazon.DataSync.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Modifies the following configuration parameters of the Server Message Block (SMB)
    /// transfer location that you're using with DataSync.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html">Configuring
    /// DataSync transfers with an SMB file server</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DSYNLocationSmb", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateLocationSmb API operation.", Operation = new[] {"UpdateLocationSmb"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateLocationSmbResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateLocationSmbResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateLocationSmbResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSYNLocationSmbCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentArn
        /// <summary>
        /// <para>
        /// <para>Specifies the DataSync agent (or agents) that can connect to your SMB file server.
        /// You specify an agent by using its Amazon Resource Name (ARN).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentArns")]
        public System.String[] AgentArn { get; set; }
        #endregion
        
        #region Parameter AuthenticationType
        /// <summary>
        /// <para>
        /// <para>Specifies the authentication protocol that DataSync uses to connect to your SMB file
        /// server. DataSync supports <c>NTLM</c> (default) and <c>KERBEROS</c> authentication.</para><para>For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">Providing
        /// DataSync access to SMB file servers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.SmbAuthenticationType")]
        public Amazon.DataSync.SmbAuthenticationType AuthenticationType { get; set; }
        #endregion
        
        #region Parameter DnsIpAddress
        /// <summary>
        /// <para>
        /// <para>Specifies the IP addresses (IPv4 or IPv6) for the DNS servers that your SMB file server
        /// belongs to. This parameter applies only if <c>AuthenticationType</c> is set to <c>KERBEROS</c>.</para><para>If you have multiple domains in your environment, configuring this parameter makes
        /// sure that DataSync connects to the right SMB file server. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DnsIpAddresses")]
        public System.String[] DnsIpAddress { get; set; }
        #endregion
        
        #region Parameter Domain
        /// <summary>
        /// <para>
        /// <para>Specifies the Windows domain name that your SMB file server belongs to. This parameter
        /// applies only if <c>AuthenticationType</c> is set to <c>NTLM</c>.</para><para>If you have multiple domains in your environment, configuring this parameter makes
        /// sure that DataSync connects to the right file server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Domain { get; set; }
        #endregion
        
        #region Parameter KerberosKeytab
        /// <summary>
        /// <para>
        /// <para>Specifies your Kerberos key table (keytab) file, which includes mappings between your
        /// Kerberos principal and encryption keys.</para><para>To avoid task execution errors, make sure that the Kerberos principal that you use
        /// to create the keytab file matches exactly what you specify for <c>KerberosPrincipal</c>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] KerberosKeytab { get; set; }
        #endregion
        
        #region Parameter KerberosKrb5Conf
        /// <summary>
        /// <para>
        /// <para>Specifies a Kerberos configuration file (<c>krb5.conf</c>) that defines your Kerberos
        /// realm configuration.</para><para>The file must be base64 encoded. If you're using the CLI, the encoding is done for
        /// you.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] KerberosKrb5Conf { get; set; }
        #endregion
        
        #region Parameter KerberosPrincipal
        /// <summary>
        /// <para>
        /// <para>Specifies a Kerberos prinicpal, which is an identity in your Kerberos realm that has
        /// permission to access the files, folders, and file metadata in your SMB file server.</para><para>A Kerberos principal might look like <c>HOST/kerberosuser@MYDOMAIN.ORG</c>.</para><para>Principal names are case sensitive. Your DataSync task execution will fail if the
        /// principal that you specify for this parameter doesn’t exactly match the principal
        /// that you use to create the keytab file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KerberosPrincipal { get; set; }
        #endregion
        
        #region Parameter CmkSecretConfig_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the customer-managed KMS key that DataSync uses to encrypt the
        /// DataSync-managed secret stored for <c>SecretArn</c>. DataSync provides this key to
        /// Secrets Manager.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CmkSecretConfig_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter LocationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the SMB location that you want to update.</para>
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
        public System.String LocationArn { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>Specifies the password of the user who can mount your SMB file server and has permission
        /// to access the files and folders involved in your transfer. This parameter applies
        /// only if <c>AuthenticationType</c> is set to <c>NTLM</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter CustomSecretConfig_SecretAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the Identity and Access Management role that DataSync uses to
        /// access the secret specified for <c>SecretArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomSecretConfig_SecretAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter CmkSecretConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for the DataSync-managed Secrets Manager secret that that is used
        /// to access a specific storage location. This property is generated by DataSync and
        /// is read-only. DataSync encrypts this secret with the KMS key that you specify for
        /// <c>KmsKeyArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CmkSecretConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter CustomSecretConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for an Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomSecretConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter ServerHostname
        /// <summary>
        /// <para>
        /// <para>Specifies the domain name or IP address (IPv4 or IPv6) of the SMB file server that
        /// your DataSync agent connects to.</para><note><para>If you're using Kerberos authentication, you must specify a domain name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerHostname { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the share exported by your SMB file server where DataSync will
        /// read or write data. You can include a subdirectory in the share path (for example,
        /// <c>/path/to/subdirectory</c>). Make sure that other SMB clients in your network can
        /// also mount this path.</para><para>To copy all data in the specified subdirectory, DataSync must be able to mount the
        /// SMB share and access all of its data. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">Providing
        /// DataSync access to SMB file servers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter User
        /// <summary>
        /// <para>
        /// <para>Specifies the user name that can mount your SMB file server and has permission to
        /// access the files and folders involved in your transfer. This parameter applies only
        /// if <c>AuthenticationType</c> is set to <c>NTLM</c>.</para><para>For information about choosing a user with the right level of access for your transfer,
        /// see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-smb-location.html#configuring-smb-permissions">Providing
        /// DataSync access to SMB file servers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String User { get; set; }
        #endregion
        
        #region Parameter MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>By default, DataSync automatically chooses an SMB protocol version based on negotiation
        /// with your SMB file server. You also can configure DataSync to use a specific SMB version,
        /// but we recommend doing this only if DataSync has trouble negotiating with the SMB
        /// file server automatically.</para><para>These are the following options for configuring the SMB version:</para><ul><li><para><c>AUTOMATIC</c> (default): DataSync and the SMB file server negotiate the highest
        /// version of SMB that they mutually support between 2.1 and 3.1.1.</para><para>This is the recommended option. If you instead choose a specific version that your
        /// file server doesn't support, you may get an <c>Operation Not Supported</c> error.</para></li><li><para><c>SMB3</c>: Restricts the protocol negotiation to only SMB version 3.0.2.</para></li><li><para><c>SMB2</c>: Restricts the protocol negotiation to only SMB version 2.1.</para></li><li><para><c>SMB2_0</c>: Restricts the protocol negotiation to only SMB version 2.0.</para></li><li><para><c>SMB1</c>: Restricts the protocol negotiation to only SMB version 1.0.</para><note><para>The <c>SMB1</c> option isn't available when <a href="https://docs.aws.amazon.com/datasync/latest/userguide/API_CreateLocationFsxOntap.html">creating
        /// an Amazon FSx for NetApp ONTAP location</a>.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.SmbVersion")]
        public Amazon.DataSync.SmbVersion MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateLocationSmbResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNLocationSmb (UpdateLocationSmb)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateLocationSmbResponse, UpdateDSYNLocationSmbCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentArn != null)
            {
                context.AgentArn = new List<System.String>(this.AgentArn);
            }
            context.AuthenticationType = this.AuthenticationType;
            context.CmkSecretConfig_KmsKeyArn = this.CmkSecretConfig_KmsKeyArn;
            context.CmkSecretConfig_SecretArn = this.CmkSecretConfig_SecretArn;
            context.CustomSecretConfig_SecretAccessRoleArn = this.CustomSecretConfig_SecretAccessRoleArn;
            context.CustomSecretConfig_SecretArn = this.CustomSecretConfig_SecretArn;
            if (this.DnsIpAddress != null)
            {
                context.DnsIpAddress = new List<System.String>(this.DnsIpAddress);
            }
            context.Domain = this.Domain;
            context.KerberosKeytab = this.KerberosKeytab;
            context.KerberosKrb5Conf = this.KerberosKrb5Conf;
            context.KerberosPrincipal = this.KerberosPrincipal;
            context.LocationArn = this.LocationArn;
            #if MODULAR
            if (this.LocationArn == null && ParameterWasBound(nameof(this.LocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MountOptions_Version = this.MountOptions_Version;
            context.Password = this.Password;
            context.ServerHostname = this.ServerHostname;
            context.Subdirectory = this.Subdirectory;
            context.User = this.User;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _KerberosKeytabStream = null;
            System.IO.MemoryStream _KerberosKrb5ConfStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.DataSync.Model.UpdateLocationSmbRequest();
                
                if (cmdletContext.AgentArn != null)
                {
                    request.AgentArns = cmdletContext.AgentArn;
                }
                if (cmdletContext.AuthenticationType != null)
                {
                    request.AuthenticationType = cmdletContext.AuthenticationType;
                }
                
                 // populate CmkSecretConfig
                var requestCmkSecretConfigIsNull = true;
                request.CmkSecretConfig = new Amazon.DataSync.Model.CmkSecretConfig();
                System.String requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn = null;
                if (cmdletContext.CmkSecretConfig_KmsKeyArn != null)
                {
                    requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn = cmdletContext.CmkSecretConfig_KmsKeyArn;
                }
                if (requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn != null)
                {
                    request.CmkSecretConfig.KmsKeyArn = requestCmkSecretConfig_cmkSecretConfig_KmsKeyArn;
                    requestCmkSecretConfigIsNull = false;
                }
                System.String requestCmkSecretConfig_cmkSecretConfig_SecretArn = null;
                if (cmdletContext.CmkSecretConfig_SecretArn != null)
                {
                    requestCmkSecretConfig_cmkSecretConfig_SecretArn = cmdletContext.CmkSecretConfig_SecretArn;
                }
                if (requestCmkSecretConfig_cmkSecretConfig_SecretArn != null)
                {
                    request.CmkSecretConfig.SecretArn = requestCmkSecretConfig_cmkSecretConfig_SecretArn;
                    requestCmkSecretConfigIsNull = false;
                }
                 // determine if request.CmkSecretConfig should be set to null
                if (requestCmkSecretConfigIsNull)
                {
                    request.CmkSecretConfig = null;
                }
                
                 // populate CustomSecretConfig
                var requestCustomSecretConfigIsNull = true;
                request.CustomSecretConfig = new Amazon.DataSync.Model.CustomSecretConfig();
                System.String requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn = null;
                if (cmdletContext.CustomSecretConfig_SecretAccessRoleArn != null)
                {
                    requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn = cmdletContext.CustomSecretConfig_SecretAccessRoleArn;
                }
                if (requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn != null)
                {
                    request.CustomSecretConfig.SecretAccessRoleArn = requestCustomSecretConfig_customSecretConfig_SecretAccessRoleArn;
                    requestCustomSecretConfigIsNull = false;
                }
                System.String requestCustomSecretConfig_customSecretConfig_SecretArn = null;
                if (cmdletContext.CustomSecretConfig_SecretArn != null)
                {
                    requestCustomSecretConfig_customSecretConfig_SecretArn = cmdletContext.CustomSecretConfig_SecretArn;
                }
                if (requestCustomSecretConfig_customSecretConfig_SecretArn != null)
                {
                    request.CustomSecretConfig.SecretArn = requestCustomSecretConfig_customSecretConfig_SecretArn;
                    requestCustomSecretConfigIsNull = false;
                }
                 // determine if request.CustomSecretConfig should be set to null
                if (requestCustomSecretConfigIsNull)
                {
                    request.CustomSecretConfig = null;
                }
                if (cmdletContext.DnsIpAddress != null)
                {
                    request.DnsIpAddresses = cmdletContext.DnsIpAddress;
                }
                if (cmdletContext.Domain != null)
                {
                    request.Domain = cmdletContext.Domain;
                }
                if (cmdletContext.KerberosKeytab != null)
                {
                    _KerberosKeytabStream = new System.IO.MemoryStream(cmdletContext.KerberosKeytab);
                    request.KerberosKeytab = _KerberosKeytabStream;
                }
                if (cmdletContext.KerberosKrb5Conf != null)
                {
                    _KerberosKrb5ConfStream = new System.IO.MemoryStream(cmdletContext.KerberosKrb5Conf);
                    request.KerberosKrb5Conf = _KerberosKrb5ConfStream;
                }
                if (cmdletContext.KerberosPrincipal != null)
                {
                    request.KerberosPrincipal = cmdletContext.KerberosPrincipal;
                }
                if (cmdletContext.LocationArn != null)
                {
                    request.LocationArn = cmdletContext.LocationArn;
                }
                
                 // populate MountOptions
                var requestMountOptionsIsNull = true;
                request.MountOptions = new Amazon.DataSync.Model.SmbMountOptions();
                Amazon.DataSync.SmbVersion requestMountOptions_mountOptions_Version = null;
                if (cmdletContext.MountOptions_Version != null)
                {
                    requestMountOptions_mountOptions_Version = cmdletContext.MountOptions_Version;
                }
                if (requestMountOptions_mountOptions_Version != null)
                {
                    request.MountOptions.Version = requestMountOptions_mountOptions_Version;
                    requestMountOptionsIsNull = false;
                }
                 // determine if request.MountOptions should be set to null
                if (requestMountOptionsIsNull)
                {
                    request.MountOptions = null;
                }
                if (cmdletContext.Password != null)
                {
                    request.Password = cmdletContext.Password;
                }
                if (cmdletContext.ServerHostname != null)
                {
                    request.ServerHostname = cmdletContext.ServerHostname;
                }
                if (cmdletContext.Subdirectory != null)
                {
                    request.Subdirectory = cmdletContext.Subdirectory;
                }
                if (cmdletContext.User != null)
                {
                    request.User = cmdletContext.User;
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
            finally
            {
                if( _KerberosKeytabStream != null)
                {
                    _KerberosKeytabStream.Dispose();
                }
                if( _KerberosKrb5ConfStream != null)
                {
                    _KerberosKrb5ConfStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DataSync.Model.UpdateLocationSmbResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateLocationSmbRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateLocationSmb");
            try
            {
                return client.UpdateLocationSmbAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AgentArn { get; set; }
            public Amazon.DataSync.SmbAuthenticationType AuthenticationType { get; set; }
            public System.String CmkSecretConfig_KmsKeyArn { get; set; }
            public System.String CmkSecretConfig_SecretArn { get; set; }
            public System.String CustomSecretConfig_SecretAccessRoleArn { get; set; }
            public System.String CustomSecretConfig_SecretArn { get; set; }
            public List<System.String> DnsIpAddress { get; set; }
            public System.String Domain { get; set; }
            public byte[] KerberosKeytab { get; set; }
            public byte[] KerberosKrb5Conf { get; set; }
            public System.String KerberosPrincipal { get; set; }
            public System.String LocationArn { get; set; }
            public Amazon.DataSync.SmbVersion MountOptions_Version { get; set; }
            public System.String Password { get; set; }
            public System.String ServerHostname { get; set; }
            public System.String Subdirectory { get; set; }
            public System.String User { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateLocationSmbResponse, UpdateDSYNLocationSmbCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
