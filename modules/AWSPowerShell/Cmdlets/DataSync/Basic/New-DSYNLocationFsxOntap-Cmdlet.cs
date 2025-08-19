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
    /// Creates a transfer <i>location</i> for an Amazon FSx for NetApp ONTAP file system.
    /// DataSync can use this location as a source or destination for transferring data.
    /// 
    ///  
    /// <para>
    /// Before you begin, make sure that you understand how DataSync <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-ontap-location.html#create-ontap-location-access">accesses
    /// FSx for ONTAP file systems</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationFsxOntap", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationFsxOntap API operation.", Operation = new[] {"CreateLocationFsxOntap"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationFsxOntapResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationFsxOntapResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationFsxOntapResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSYNLocationFsxOntapCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SMB_Domain
        /// <summary>
        /// <para>
        /// <para>Specifies the name of the Windows domain that your storage virtual machine (SVM) belongs
        /// to.</para><para>If you have multiple domains in your environment, configuring this setting makes sure
        /// that DataSync connects to the right SVM.</para><para>If you have multiple Active Directory domains in your environment, configuring this
        /// parameter makes sure that DataSync connects to the right SVM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_SMB_Domain")]
        public System.String SMB_Domain { get; set; }
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
        /// <para>Specifies the Amazon EC2 security groups that provide access to your file system's
        /// preferred subnet.</para><para>The security groups must allow outbound traffic on the following ports (depending
        /// on the protocol you use):</para><ul><li><para><b>Network File System (NFS)</b>: TCP ports 111, 635, and 2049</para></li><li><para><b>Server Message Block (SMB)</b>: TCP port 445</para></li></ul><para>Your file system's security groups must also allow inbound traffic on the same ports.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter StorageVirtualMachineArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of the storage virtual machine (SVM) in your file system where you
        /// want to copy data to or from.</para>
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
        public System.String StorageVirtualMachineArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a path to the file share in the SVM where you want to transfer data to or
        /// from.</para><para>You can specify a junction path (also known as a mount point), qtree path (for NFS
        /// file shares), or share name (for SMB file shares). For example, your mount path might
        /// be <c>/vol1</c>, <c>/vol1/tree1</c>, or <c>/share1</c>.</para><note><para>Don't specify a junction path in the SVM's root volume. For more information, see
        /// <a href="https://docs.aws.amazon.com/fsx/latest/ONTAPGuide/managing-svms.html">Managing
        /// FSx for ONTAP storage virtual machines</a> in the <i>Amazon FSx for NetApp ONTAP User
        /// Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies labels that help you categorize, filter, and search for your Amazon Web
        /// Services resources. We recommend creating at least a name tag for your location.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter SMB_User
        /// <summary>
        /// <para>
        /// <para>Specifies a user that can mount and access the files, folders, and metadata in your
        /// SVM.</para><para>For information about choosing a user with the right level of access for your transfer,
        /// see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-ontap-location.html#create-ontap-location-smb">Using
        /// the SMB protocol</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Protocol_SMB_User")]
        public System.String SMB_User { get; set; }
        #endregion
        
        #region Parameter Protocol_NFS_MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>Specifies the NFS version that you want DataSync to use when mounting your NFS share.
        /// If the server refuses to use the version specified, the task fails.</para><para>You can specify the following options:</para><ul><li><para><c>AUTOMATIC</c> (default): DataSync chooses NFS version 4.1.</para></li><li><para><c>NFS3</c>: Stateless protocol version that allows for asynchronous writes on the
        /// server.</para></li><li><para><c>NFSv4_0</c>: Stateful, firewall-friendly protocol version that supports delegations
        /// and pseudo file systems.</para></li><li><para><c>NFSv4_1</c>: Stateful protocol version that supports sessions, directory delegations,
        /// and parallel data processing. NFS version 4.1 also includes all features available
        /// in version 4.0.</para></li></ul><note><para>DataSync currently only supports NFS version 3 with Amazon FSx for NetApp ONTAP locations.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.NfsVersion")]
        public Amazon.DataSync.NfsVersion Protocol_NFS_MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Protocol_SMB_MountOptions_Version
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
        public Amazon.DataSync.SmbVersion Protocol_SMB_MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationFsxOntapResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationFsxOntapResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StorageVirtualMachineArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationFsxOntap (CreateLocationFsxOntap)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationFsxOntapResponse, NewDSYNLocationFsxOntapCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Protocol_NFS_MountOptions_Version = this.Protocol_NFS_MountOptions_Version;
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
            context.StorageVirtualMachineArn = this.StorageVirtualMachineArn;
            #if MODULAR
            if (this.StorageVirtualMachineArn == null && ParameterWasBound(nameof(this.StorageVirtualMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageVirtualMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DataSync.Model.CreateLocationFsxOntapRequest();
            
            
             // populate Protocol
            request.Protocol = new Amazon.DataSync.Model.FsxProtocol();
            Amazon.DataSync.Model.FsxProtocolNfs requestProtocol_protocol_NFS = null;
            
             // populate NFS
            var requestProtocol_protocol_NFSIsNull = true;
            requestProtocol_protocol_NFS = new Amazon.DataSync.Model.FsxProtocolNfs();
            Amazon.DataSync.Model.NfsMountOptions requestProtocol_protocol_NFS_protocol_NFS_MountOptions = null;
            
             // populate MountOptions
            var requestProtocol_protocol_NFS_protocol_NFS_MountOptionsIsNull = true;
            requestProtocol_protocol_NFS_protocol_NFS_MountOptions = new Amazon.DataSync.Model.NfsMountOptions();
            Amazon.DataSync.NfsVersion requestProtocol_protocol_NFS_protocol_NFS_MountOptions_protocol_NFS_MountOptions_Version = null;
            if (cmdletContext.Protocol_NFS_MountOptions_Version != null)
            {
                requestProtocol_protocol_NFS_protocol_NFS_MountOptions_protocol_NFS_MountOptions_Version = cmdletContext.Protocol_NFS_MountOptions_Version;
            }
            if (requestProtocol_protocol_NFS_protocol_NFS_MountOptions_protocol_NFS_MountOptions_Version != null)
            {
                requestProtocol_protocol_NFS_protocol_NFS_MountOptions.Version = requestProtocol_protocol_NFS_protocol_NFS_MountOptions_protocol_NFS_MountOptions_Version;
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
            }
            if (cmdletContext.SecurityGroupArn != null)
            {
                request.SecurityGroupArns = cmdletContext.SecurityGroupArn;
            }
            if (cmdletContext.StorageVirtualMachineArn != null)
            {
                request.StorageVirtualMachineArn = cmdletContext.StorageVirtualMachineArn;
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
        
        private Amazon.DataSync.Model.CreateLocationFsxOntapResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationFsxOntapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationFsxOntap");
            try
            {
                return client.CreateLocationFsxOntapAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.DataSync.NfsVersion Protocol_NFS_MountOptions_Version { get; set; }
            public System.String SMB_Domain { get; set; }
            public Amazon.DataSync.SmbVersion Protocol_SMB_MountOptions_Version { get; set; }
            public System.String SMB_Password { get; set; }
            public System.String SMB_User { get; set; }
            public List<System.String> SecurityGroupArn { get; set; }
            public System.String StorageVirtualMachineArn { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationFsxOntapResponse, NewDSYNLocationFsxOntapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
