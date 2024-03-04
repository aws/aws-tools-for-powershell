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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates a storage virtual machine (SVM) for an Amazon FSx for ONTAP file system.
    /// </summary>
    [Cmdlet("New", "FSXStorageVirtualMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.StorageVirtualMachine")]
    [AWSCmdlet("Calls the Amazon FSx CreateStorageVirtualMachine API operation.", Operation = new[] {"CreateStorageVirtualMachine"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateStorageVirtualMachineResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.StorageVirtualMachine or Amazon.FSx.Model.CreateStorageVirtualMachineResponse",
        "This cmdlet returns an Amazon.FSx.Model.StorageVirtualMachine object.",
        "The service call response (type Amazon.FSx.Model.CreateStorageVirtualMachineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewFSXStorageVirtualMachineCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_DnsIp
        /// <summary>
        /// <para>
        /// <para>A list of up to three IP addresses of DNS servers or domain controllers in the self-managed
        /// AD directory. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_DnsIps")]
        public System.String[] SelfManagedActiveDirectoryConfiguration_DnsIp { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_DomainName
        /// <summary>
        /// <para>
        /// <para>The fully qualified domain name of the self-managed AD directory, such as <c>corp.example.com</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_DomainName")]
        public System.String SelfManagedActiveDirectoryConfiguration_DomainName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup
        /// <summary>
        /// <para>
        /// <para>(Optional) The name of the domain group whose members are granted administrative privileges
        /// for the file system. Administrative privileges include taking ownership of files and
        /// folders, setting audit controls (audit ACLs) on files and folders, and administering
        /// the file system remotely by using the FSx Remote PowerShell. The group that you specify
        /// must already exist in your domain. If you don't provide one, your AD domain's Domain
        /// Admins group is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup")]
        public System.String SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the SVM.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfiguration_NetBiosName
        /// <summary>
        /// <para>
        /// <para>The NetBIOS name of the Active Directory computer object that will be created for
        /// your SVM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveDirectoryConfiguration_NetBiosName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>(Optional) The fully qualified distinguished name of the organizational unit within
        /// your self-managed AD directory. Amazon FSx only accepts OU as the direct parent of
        /// the file system. An example is <c>OU=FSx,DC=yourdomain,DC=corp,DC=com</c>. To learn
        /// more, see <a href="https://tools.ietf.org/html/rfc2253">RFC 2253</a>. If none is provided,
        /// the FSx file system is created in the default location of your self-managed AD directory.
        /// </para><important><para>Only Organizational Unit (OU) objects can be the direct parent of the file system
        /// that you're creating.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName")]
        public System.String SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_Password
        /// <summary>
        /// <para>
        /// <para>The password for the service account on your self-managed AD domain that Amazon FSx
        /// will use to join to your AD domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_Password")]
        public System.String SelfManagedActiveDirectoryConfiguration_Password { get; set; }
        #endregion
        
        #region Parameter RootVolumeSecurityStyle
        /// <summary>
        /// <para>
        /// <para>The security style of the root volume of the SVM. Specify one of the following values:</para><ul><li><para><c>UNIX</c> if the file system is managed by a UNIX administrator, the majority of
        /// users are NFS clients, and an application accessing the data uses a UNIX user as the
        /// service account.</para></li><li><para><c>NTFS</c> if the file system is managed by a Microsoft Windows administrator, the
        /// majority of users are SMB clients, and an application accessing the data uses a Microsoft
        /// Windows user as the service account.</para></li><li><para><c>MIXED</c> This is an advanced setting. For more information, see <a href="fsx/latest/ONTAPGuide/volume-security-style.html">Volume
        /// security style</a> in the Amazon FSx for NetApp ONTAP User Guide.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.FSx.StorageVirtualMachineRootVolumeSecurityStyle")]
        public Amazon.FSx.StorageVirtualMachineRootVolumeSecurityStyle RootVolumeSecurityStyle { get; set; }
        #endregion
        
        #region Parameter SvmAdminPassword
        /// <summary>
        /// <para>
        /// <para>The password to use when managing the SVM using the NetApp ONTAP CLI or REST API.
        /// If you do not specify a password, you can still use the file system's <c>fsxadmin</c>
        /// user to manage the SVM.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SvmAdminPassword { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.FSx.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_UserName
        /// <summary>
        /// <para>
        /// <para>The user name for the service account on your self-managed AD domain that Amazon FSx
        /// will use to join to your AD domain. This account must have the permission to join
        /// computers to the domain in the organizational unit provided in <c>OrganizationalUnitDistinguishedName</c>,
        /// or in the default location of your AD domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_UserName")]
        public System.String SelfManagedActiveDirectoryConfiguration_UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorageVirtualMachine'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateStorageVirtualMachineResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateStorageVirtualMachineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StorageVirtualMachine";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXStorageVirtualMachine (CreateStorageVirtualMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateStorageVirtualMachineResponse, NewFSXStorageVirtualMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ActiveDirectoryConfiguration_NetBiosName = this.ActiveDirectoryConfiguration_NetBiosName;
            if (this.SelfManagedActiveDirectoryConfiguration_DnsIp != null)
            {
                context.SelfManagedActiveDirectoryConfiguration_DnsIp = new List<System.String>(this.SelfManagedActiveDirectoryConfiguration_DnsIp);
            }
            context.SelfManagedActiveDirectoryConfiguration_DomainName = this.SelfManagedActiveDirectoryConfiguration_DomainName;
            context.SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup = this.SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup;
            context.SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName = this.SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName;
            context.SelfManagedActiveDirectoryConfiguration_Password = this.SelfManagedActiveDirectoryConfiguration_Password;
            context.SelfManagedActiveDirectoryConfiguration_UserName = this.SelfManagedActiveDirectoryConfiguration_UserName;
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RootVolumeSecurityStyle = this.RootVolumeSecurityStyle;
            context.SvmAdminPassword = this.SvmAdminPassword;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.FSx.Model.Tag>(this.Tag);
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
            var request = new Amazon.FSx.Model.CreateStorageVirtualMachineRequest();
            
            
             // populate ActiveDirectoryConfiguration
            var requestActiveDirectoryConfigurationIsNull = true;
            request.ActiveDirectoryConfiguration = new Amazon.FSx.Model.CreateSvmActiveDirectoryConfiguration();
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_NetBiosName = null;
            if (cmdletContext.ActiveDirectoryConfiguration_NetBiosName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_NetBiosName = cmdletContext.ActiveDirectoryConfiguration_NetBiosName;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_NetBiosName != null)
            {
                request.ActiveDirectoryConfiguration.NetBiosName = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_NetBiosName;
                requestActiveDirectoryConfigurationIsNull = false;
            }
            Amazon.FSx.Model.SelfManagedActiveDirectoryConfiguration requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration = null;
            
             // populate SelfManagedActiveDirectoryConfiguration
            var requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = true;
            requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration = new Amazon.FSx.Model.SelfManagedActiveDirectoryConfiguration();
            List<System.String> requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DnsIp = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_DnsIp != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DnsIp = cmdletContext.SelfManagedActiveDirectoryConfiguration_DnsIp;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DnsIp != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.DnsIps = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DnsIp;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DomainName = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_DomainName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DomainName = cmdletContext.SelfManagedActiveDirectoryConfiguration_DomainName;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DomainName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.DomainName = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_DomainName;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup = cmdletContext.SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.FileSystemAdministratorsGroup = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName = cmdletContext.SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.OrganizationalUnitDistinguishedName = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_Password = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_Password != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_Password = cmdletContext.SelfManagedActiveDirectoryConfiguration_Password;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_Password != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.Password = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_Password;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_UserName = null;
            if (cmdletContext.SelfManagedActiveDirectoryConfiguration_UserName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_UserName = cmdletContext.SelfManagedActiveDirectoryConfiguration_UserName;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_UserName != null)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration.UserName = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_selfManagedActiveDirectoryConfiguration_UserName;
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = false;
            }
             // determine if requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration should be set to null
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull)
            {
                requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration = null;
            }
            if (requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration != null)
            {
                request.ActiveDirectoryConfiguration.SelfManagedActiveDirectoryConfiguration = requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration;
                requestActiveDirectoryConfigurationIsNull = false;
            }
             // determine if request.ActiveDirectoryConfiguration should be set to null
            if (requestActiveDirectoryConfigurationIsNull)
            {
                request.ActiveDirectoryConfiguration = null;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RootVolumeSecurityStyle != null)
            {
                request.RootVolumeSecurityStyle = cmdletContext.RootVolumeSecurityStyle;
            }
            if (cmdletContext.SvmAdminPassword != null)
            {
                request.SvmAdminPassword = cmdletContext.SvmAdminPassword;
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
        
        private Amazon.FSx.Model.CreateStorageVirtualMachineResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateStorageVirtualMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateStorageVirtualMachine");
            try
            {
                #if DESKTOP
                return client.CreateStorageVirtualMachine(request);
                #elif CORECLR
                return client.CreateStorageVirtualMachineAsync(request).GetAwaiter().GetResult();
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
            public System.String ActiveDirectoryConfiguration_NetBiosName { get; set; }
            public List<System.String> SelfManagedActiveDirectoryConfiguration_DnsIp { get; set; }
            public System.String SelfManagedActiveDirectoryConfiguration_DomainName { get; set; }
            public System.String SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup { get; set; }
            public System.String SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName { get; set; }
            public System.String SelfManagedActiveDirectoryConfiguration_Password { get; set; }
            public System.String SelfManagedActiveDirectoryConfiguration_UserName { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String Name { get; set; }
            public Amazon.FSx.StorageVirtualMachineRootVolumeSecurityStyle RootVolumeSecurityStyle { get; set; }
            public System.String SvmAdminPassword { get; set; }
            public List<Amazon.FSx.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.FSx.Model.CreateStorageVirtualMachineResponse, NewFSXStorageVirtualMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorageVirtualMachine;
        }
        
    }
}
