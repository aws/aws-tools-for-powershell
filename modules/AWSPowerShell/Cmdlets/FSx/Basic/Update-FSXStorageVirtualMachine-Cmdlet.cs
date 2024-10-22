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
    /// Updates an FSx for ONTAP storage virtual machine (SVM).
    /// </summary>
    [Cmdlet("Update", "FSXStorageVirtualMachine", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.StorageVirtualMachine")]
    [AWSCmdlet("Calls the Amazon FSx UpdateStorageVirtualMachine API operation.", Operation = new[] {"UpdateStorageVirtualMachine"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateStorageVirtualMachineResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.StorageVirtualMachine or Amazon.FSx.Model.UpdateStorageVirtualMachineResponse",
        "This cmdlet returns an Amazon.FSx.Model.StorageVirtualMachine object.",
        "The service call response (type Amazon.FSx.Model.UpdateStorageVirtualMachineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateFSXStorageVirtualMachineCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
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
        /// <para>A list of up to three DNS server or domain controller IP addresses in your self-managed
        /// Active Directory domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_DnsIps")]
        public System.String[] SelfManagedActiveDirectoryConfiguration_DnsIp { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_DomainName
        /// <summary>
        /// <para>
        /// <para>Specifies an updated fully qualified domain name of your self-managed Active Directory
        /// configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_DomainName")]
        public System.String SelfManagedActiveDirectoryConfiguration_DomainName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup
        /// <summary>
        /// <para>
        /// <para>For FSx for ONTAP file systems only - Specifies the updated name of the self-managed
        /// Active Directory domain group whose members are granted administrative privileges
        /// for the Amazon FSx resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup")]
        public System.String SelfManagedActiveDirectoryConfiguration_FileSystemAdministratorsGroup { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfiguration_NetBiosName
        /// <summary>
        /// <para>
        /// <para>Specifies an updated NetBIOS name of the AD computer object <c>NetBiosName</c> to
        /// which an SVM is joined.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ActiveDirectoryConfiguration_NetBiosName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>Specifies an updated fully qualified distinguished name of the organization unit within
        /// your self-managed Active Directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName")]
        public System.String SelfManagedActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_Password
        /// <summary>
        /// <para>
        /// <para>Specifies the updated password for the service account on your self-managed Active
        /// Directory domain. Amazon FSx uses this account to join to your self-managed Active
        /// Directory domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_Password")]
        public System.String SelfManagedActiveDirectoryConfiguration_Password { get; set; }
        #endregion
        
        #region Parameter StorageVirtualMachineId
        /// <summary>
        /// <para>
        /// <para>The ID of the SVM that you want to update, in the format <c>svm-0123456789abcdef0</c>.</para>
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
        public System.String StorageVirtualMachineId { get; set; }
        #endregion
        
        #region Parameter SvmAdminPassword
        /// <summary>
        /// <para>
        /// <para>Specifies a new SvmAdminPassword.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SvmAdminPassword { get; set; }
        #endregion
        
        #region Parameter SelfManagedActiveDirectoryConfiguration_UserName
        /// <summary>
        /// <para>
        /// <para>Specifies the updated user name for the service account on your self-managed Active
        /// Directory domain. Amazon FSx uses this account to join to your self-managed Active
        /// Directory domain.</para><para>This account must have the permissions required to join computers to the domain in
        /// the organizational unit provided in <c>OrganizationalUnitDistinguishedName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ActiveDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration_UserName")]
        public System.String SelfManagedActiveDirectoryConfiguration_UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StorageVirtualMachine'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateStorageVirtualMachineResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateStorageVirtualMachineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StorageVirtualMachine";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StorageVirtualMachineId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXStorageVirtualMachine (UpdateStorageVirtualMachine)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateStorageVirtualMachineResponse, UpdateFSXStorageVirtualMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.StorageVirtualMachineId = this.StorageVirtualMachineId;
            #if MODULAR
            if (this.StorageVirtualMachineId == null && ParameterWasBound(nameof(this.StorageVirtualMachineId)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageVirtualMachineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SvmAdminPassword = this.SvmAdminPassword;
            
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
            var request = new Amazon.FSx.Model.UpdateStorageVirtualMachineRequest();
            
            
             // populate ActiveDirectoryConfiguration
            var requestActiveDirectoryConfigurationIsNull = true;
            request.ActiveDirectoryConfiguration = new Amazon.FSx.Model.UpdateSvmActiveDirectoryConfiguration();
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
            Amazon.FSx.Model.SelfManagedActiveDirectoryConfigurationUpdates requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration = null;
            
             // populate SelfManagedActiveDirectoryConfiguration
            var requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfigurationIsNull = true;
            requestActiveDirectoryConfiguration_activeDirectoryConfiguration_SelfManagedActiveDirectoryConfiguration = new Amazon.FSx.Model.SelfManagedActiveDirectoryConfigurationUpdates();
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
            if (cmdletContext.StorageVirtualMachineId != null)
            {
                request.StorageVirtualMachineId = cmdletContext.StorageVirtualMachineId;
            }
            if (cmdletContext.SvmAdminPassword != null)
            {
                request.SvmAdminPassword = cmdletContext.SvmAdminPassword;
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
        
        private Amazon.FSx.Model.UpdateStorageVirtualMachineResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateStorageVirtualMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateStorageVirtualMachine");
            try
            {
                #if DESKTOP
                return client.UpdateStorageVirtualMachine(request);
                #elif CORECLR
                return client.UpdateStorageVirtualMachineAsync(request).GetAwaiter().GetResult();
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
            public System.String StorageVirtualMachineId { get; set; }
            public System.String SvmAdminPassword { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateStorageVirtualMachineResponse, UpdateFSXStorageVirtualMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StorageVirtualMachine;
        }
        
    }
}
