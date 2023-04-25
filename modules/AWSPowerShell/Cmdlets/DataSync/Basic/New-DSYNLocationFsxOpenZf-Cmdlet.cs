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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates an endpoint for an Amazon FSx for OpenZFS file system that DataSync can access
    /// for a transfer. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-openzfs-location.html">Creating
    /// a location for FSx for OpenZFS</a>.
    /// 
    ///  <note><para>
    /// Request parameters related to <code>SMB</code> aren't supported with the <code>CreateLocationFsxOpenZfs</code>
    /// operation.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "DSYNLocationFsxOpenZf", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationFsxOpenZfs API operation.", Operation = new[] {"CreateLocationFsxOpenZfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDSYNLocationFsxOpenZfCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter SMB_Domain
        /// <summary>
        /// <para>
        /// <para>Specifies the fully qualified domain name (FQDN) of the Microsoft Active Directory
        /// that your storage virtual machine (SVM) belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_SMB_Domain")]
        public System.String SMB_Domain { get; set; }
        #endregion
        
        #region Parameter FsxFilesystemArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the FSx for OpenZFS file system.</para>
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
        public System.String FsxFilesystemArn { get; set; }
        #endregion
        
        #region Parameter SMB_Password
        /// <summary>
        /// <para>
        /// <para>Specifies the password of a user who has permission to access your SVM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_SMB_Password")]
        public System.String SMB_Password { get; set; }
        #endregion
        
        #region Parameter SecurityGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the security groups that are used to configure the FSx for OpenZFS file
        /// system.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SecurityGroupArns")]
        public System.String[] SecurityGroupArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>A subdirectory in the location's path that must begin with <code>/fsx</code>. DataSync
        /// uses this subdirectory to read or write data (depending on whether the file system
        /// is a source or destination location).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pair that represents a tag that you want to add to the resource. The
        /// value can be an empty string. This value helps you manage, filter, and search for
        /// your resources. We recommend that you create a name tag for your location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter SMB_User
        /// <summary>
        /// <para>
        /// <para>Specifies a user name that can mount the location and access the files, folders, and
        /// metadata that you need in the SVM.</para><para>If you provide a user in your Active Directory, note the following:</para><ul><li><para>If you're using Directory Service for Microsoft Active Directory, the user must be
        /// a member of the Amazon Web Services Delegated FSx Administrators group.</para></li><li><para>If you're using a self-managed Active Directory, the user must be a member of either
        /// the Domain Admins group or a custom group that you specified for file system administration
        /// when you created your file system.</para></li></ul><para>Make sure that the user has the permissions it needs to copy the data you want:</para><ul><li><para><code>SE_TCB_NAME</code>: Required to set object ownership and file metadata. With
        /// this privilege, you also can copy NTFS discretionary access lists (DACLs).</para></li><li><para><code>SE_SECURITY_NAME</code>: May be needed to copy NTFS system access control lists
        /// (SACLs). This operation specifically requires the Windows privilege, which is granted
        /// to members of the Domain Admins group. If you configure your task to copy SACLs, make
        /// sure that the user has the required privileges. For information about copying SACLs,
        /// see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-task.html#configure-ownership-and-permissions">Ownership
        /// and permissions-related options</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_SMB_User")]
        public System.String SMB_User { get; set; }
        #endregion
        
        #region Parameter MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>Specifies the NFS version that you want DataSync to use when mounting your NFS share.
        /// If the server refuses to use the version specified, the task fails.</para><para>You can specify the following options:</para><ul><li><para><code>AUTOMATIC</code> (default): DataSync chooses NFS version 4.1.</para></li><li><para><code>NFS3</code>: Stateless protocol version that allows for asynchronous writes
        /// on the server.</para></li><li><para><code>NFSv4_0</code>: Stateful, firewall-friendly protocol version that supports
        /// delegations and pseudo file systems.</para></li><li><para><code>NFSv4_1</code>: Stateful protocol version that supports sessions, directory
        /// delegations, and parallel data processing. NFS version 4.1 also includes all features
        /// available in version 4.0.</para></li></ul><note><para>DataSync currently only supports NFS version 3 with Amazon FSx for NetApp ONTAP locations.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_NFS_MountOptions_Version")]
        [AWSConstantClassSource("Amazon.DataSync.NfsVersion")]
        public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Protocol_SMB_MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>By default, DataSync automatically chooses an SMB protocol version based on negotiation
        /// with your SMB file server. You also can configure DataSync to use a specific SMB version,
        /// but we recommend doing this only if DataSync has trouble negotiating with the SMB
        /// file server automatically.</para><para>These are the following options for configuring the SMB version:</para><ul><li><para><code>AUTOMATIC</code> (default): DataSync and the SMB file server negotiate the
        /// highest version of SMB that they mutually support between 2.1 and 3.1.1.</para><para>This is the recommended option. If you instead choose a specific version that your
        /// file server doesn't support, you may get an <code>Operation Not Supported</code> error.</para></li><li><para><code>SMB3</code>: Restricts the protocol negotiation to only SMB version 3.0.2.</para></li><li><para><code>SMB2</code>: Restricts the protocol negotiation to only SMB version 2.1.</para></li><li><para><code>SMB2_0</code>: Restricts the protocol negotiation to only SMB version 2.0.</para></li><li><para><code>SMB1</code>: Restricts the protocol negotiation to only SMB version 1.0.</para><note><para>The <code>SMB1</code> option isn't available when <a href="https://docs.aws.amazon.com/datasync/latest/userguide/API_CreateLocationFsxOntap.html">creating
        /// an Amazon FSx for NetApp ONTAP location</a>.</para></note></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.SmbVersion")]
        public Amazon.DataSync.SmbVersion Protocol_SMB_MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FsxFilesystemArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FsxFilesystemArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FsxFilesystemArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FsxFilesystemArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationFsxOpenZf (CreateLocationFsxOpenZfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse, NewDSYNLocationFsxOpenZfCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FsxFilesystemArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FsxFilesystemArn = this.FsxFilesystemArn;
            #if MODULAR
            if (this.FsxFilesystemArn == null && ParameterWasBound(nameof(this.FsxFilesystemArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FsxFilesystemArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MountOptions_Version = this.MountOptions_Version;
            context.SMB_Domain = this.SMB_Domain;
            context.Protocol_SMB_MountOptions_Version = this.Protocol_SMB_MountOptions_Version;
            context.SMB_Password = this.SMB_Password;
            context.SMB_User = this.SMB_User;
            if (this.SecurityGroupArn != null)
            {
                context.SecurityGroupArn = new List<System.String>(this.SecurityGroupArn);
            }
            #if MODULAR
            if (this.SecurityGroupArn == null && ParameterWasBound(nameof(this.SecurityGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.CreateLocationFsxOpenZfsRequest();
            
            if (cmdletContext.FsxFilesystemArn != null)
            {
                request.FsxFilesystemArn = cmdletContext.FsxFilesystemArn;
            }
            
             // populate Protocol
            var requestProtocolIsNull = true;
            request.Protocol = new Amazon.DataSync.Model.FsxProtocol();
            Amazon.DataSync.Model.FsxProtocolNfs requestProtocol_protocol_NFS = null;
            
             // populate NFS
            var requestProtocol_protocol_NFSIsNull = true;
            requestProtocol_protocol_NFS = new Amazon.DataSync.Model.FsxProtocolNfs();
            Amazon.DataSync.Model.NfsMountOptions requestProtocol_protocol_NFS_protocol_NFS_MountOptions = null;
            
             // populate MountOptions
            var requestProtocol_protocol_NFS_protocol_NFS_MountOptionsIsNull = true;
            requestProtocol_protocol_NFS_protocol_NFS_MountOptions = new Amazon.DataSync.Model.NfsMountOptions();
            Amazon.DataSync.NfsVersion requestProtocol_protocol_NFS_protocol_NFS_MountOptions_mountOptions_Version = null;
            if (cmdletContext.MountOptions_Version != null)
            {
                requestProtocol_protocol_NFS_protocol_NFS_MountOptions_mountOptions_Version = cmdletContext.MountOptions_Version;
            }
            if (requestProtocol_protocol_NFS_protocol_NFS_MountOptions_mountOptions_Version != null)
            {
                requestProtocol_protocol_NFS_protocol_NFS_MountOptions.Version = requestProtocol_protocol_NFS_protocol_NFS_MountOptions_mountOptions_Version;
                requestProtocol_protocol_NFS_protocol_NFS_MountOptionsIsNull = false;
            }
             // determine if requestProtocol_protocol_NFS_protocol_NFS_MountOptions should be set to null
            if (requestProtocol_protocol_NFS_protocol_NFS_MountOptionsIsNull)
            {
                requestProtocol_protocol_NFS_protocol_NFS_MountOptions = null;
            }
            if (requestProtocol_protocol_NFS_protocol_NFS_MountOptions != null)
            {
                requestProtocol_protocol_NFS.MountOptions = requestProtocol_protocol_NFS_protocol_NFS_MountOptions;
                requestProtocol_protocol_NFSIsNull = false;
            }
             // determine if requestProtocol_protocol_NFS should be set to null
            if (requestProtocol_protocol_NFSIsNull)
            {
                requestProtocol_protocol_NFS = null;
            }
            if (requestProtocol_protocol_NFS != null)
            {
                request.Protocol.NFS = requestProtocol_protocol_NFS;
                requestProtocolIsNull = false;
            }
            Amazon.DataSync.Model.FsxProtocolSmb requestProtocol_protocol_SMB = null;
            
             // populate SMB
            var requestProtocol_protocol_SMBIsNull = true;
            requestProtocol_protocol_SMB = new Amazon.DataSync.Model.FsxProtocolSmb();
            System.String requestProtocol_protocol_SMB_sMB_Domain = null;
            if (cmdletContext.SMB_Domain != null)
            {
                requestProtocol_protocol_SMB_sMB_Domain = cmdletContext.SMB_Domain;
            }
            if (requestProtocol_protocol_SMB_sMB_Domain != null)
            {
                requestProtocol_protocol_SMB.Domain = requestProtocol_protocol_SMB_sMB_Domain;
                requestProtocol_protocol_SMBIsNull = false;
            }
            System.String requestProtocol_protocol_SMB_sMB_Password = null;
            if (cmdletContext.SMB_Password != null)
            {
                requestProtocol_protocol_SMB_sMB_Password = cmdletContext.SMB_Password;
            }
            if (requestProtocol_protocol_SMB_sMB_Password != null)
            {
                requestProtocol_protocol_SMB.Password = requestProtocol_protocol_SMB_sMB_Password;
                requestProtocol_protocol_SMBIsNull = false;
            }
            System.String requestProtocol_protocol_SMB_sMB_User = null;
            if (cmdletContext.SMB_User != null)
            {
                requestProtocol_protocol_SMB_sMB_User = cmdletContext.SMB_User;
            }
            if (requestProtocol_protocol_SMB_sMB_User != null)
            {
                requestProtocol_protocol_SMB.User = requestProtocol_protocol_SMB_sMB_User;
                requestProtocol_protocol_SMBIsNull = false;
            }
            Amazon.DataSync.Model.SmbMountOptions requestProtocol_protocol_SMB_protocol_SMB_MountOptions = null;
            
             // populate MountOptions
            var requestProtocol_protocol_SMB_protocol_SMB_MountOptionsIsNull = true;
            requestProtocol_protocol_SMB_protocol_SMB_MountOptions = new Amazon.DataSync.Model.SmbMountOptions();
            Amazon.DataSync.SmbVersion requestProtocol_protocol_SMB_protocol_SMB_MountOptions_protocol_SMB_MountOptions_Version = null;
            if (cmdletContext.Protocol_SMB_MountOptions_Version != null)
            {
                requestProtocol_protocol_SMB_protocol_SMB_MountOptions_protocol_SMB_MountOptions_Version = cmdletContext.Protocol_SMB_MountOptions_Version;
            }
            if (requestProtocol_protocol_SMB_protocol_SMB_MountOptions_protocol_SMB_MountOptions_Version != null)
            {
                requestProtocol_protocol_SMB_protocol_SMB_MountOptions.Version = requestProtocol_protocol_SMB_protocol_SMB_MountOptions_protocol_SMB_MountOptions_Version;
                requestProtocol_protocol_SMB_protocol_SMB_MountOptionsIsNull = false;
            }
             // determine if requestProtocol_protocol_SMB_protocol_SMB_MountOptions should be set to null
            if (requestProtocol_protocol_SMB_protocol_SMB_MountOptionsIsNull)
            {
                requestProtocol_protocol_SMB_protocol_SMB_MountOptions = null;
            }
            if (requestProtocol_protocol_SMB_protocol_SMB_MountOptions != null)
            {
                requestProtocol_protocol_SMB.MountOptions = requestProtocol_protocol_SMB_protocol_SMB_MountOptions;
                requestProtocol_protocol_SMBIsNull = false;
            }
             // determine if requestProtocol_protocol_SMB should be set to null
            if (requestProtocol_protocol_SMBIsNull)
            {
                requestProtocol_protocol_SMB = null;
            }
            if (requestProtocol_protocol_SMB != null)
            {
                request.Protocol.SMB = requestProtocol_protocol_SMB;
                requestProtocolIsNull = false;
            }
             // determine if request.Protocol should be set to null
            if (requestProtocolIsNull)
            {
                request.Protocol = null;
            }
            if (cmdletContext.SecurityGroupArn != null)
            {
                request.SecurityGroupArns = cmdletContext.SecurityGroupArn;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
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
        
        private Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationFsxOpenZfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationFsxOpenZfs");
            try
            {
                #if DESKTOP
                return client.CreateLocationFsxOpenZfs(request);
                #elif CORECLR
                return client.CreateLocationFsxOpenZfsAsync(request).GetAwaiter().GetResult();
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
            public System.String FsxFilesystemArn { get; set; }
            public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
            public System.String SMB_Domain { get; set; }
            public Amazon.DataSync.SmbVersion Protocol_SMB_MountOptions_Version { get; set; }
            public System.String SMB_Password { get; set; }
            public System.String SMB_User { get; set; }
            public List<System.String> SecurityGroupArn { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationFsxOpenZfsResponse, NewDSYNLocationFsxOpenZfCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
