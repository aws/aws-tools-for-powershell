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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Creates a studio component resource.
    /// </summary>
    [Cmdlet("New", "NSStudioComponent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.StudioComponent")]
    [AWSCmdlet("Calls the Amazon Nimble Studio CreateStudioComponent API operation.", Operation = new[] {"CreateStudioComponent"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.CreateStudioComponentResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.StudioComponent or Amazon.NimbleStudio.Model.CreateStudioComponentResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.StudioComponent object.",
        "The service call response (type Amazon.NimbleStudio.Model.CreateStudioComponentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewNSStudioComponentCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        #region Parameter ComputeFarmConfiguration_ActiveDirectoryUser
        /// <summary>
        /// <para>
        /// <para>The name of an Active Directory user that is used on ComputeFarm worker instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ComputeFarmConfiguration_ActiveDirectoryUser")]
        public System.String ComputeFarmConfiguration_ActiveDirectoryUser { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfiguration_ComputerAttribute
        /// <summary>
        /// <para>
        /// <para>A collection of custom attributes for an Active Directory computer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ActiveDirectoryConfiguration_ComputerAttributes")]
        public Amazon.NimbleStudio.Model.ActiveDirectoryComputerAttribute[] ActiveDirectoryConfiguration_ComputerAttribute { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ActiveDirectoryConfiguration_DirectoryId
        /// <summary>
        /// <para>
        /// <para>The directory ID of the Directory Service for Microsoft Active Directory to access
        /// using this studio component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ActiveDirectoryConfiguration_DirectoryId")]
        public System.String ActiveDirectoryConfiguration_DirectoryId { get; set; }
        #endregion
        
        #region Parameter Ec2SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The EC2 security groups that control access to the studio component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ec2SecurityGroupIds")]
        public System.String[] Ec2SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ComputeFarmConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of the ComputeFarm that is accessed by the studio component resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ComputeFarmConfiguration_Endpoint")]
        public System.String ComputeFarmConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter LicenseServiceConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of the license service that is accessed by the studio component resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_LicenseServiceConfiguration_Endpoint")]
        public System.String LicenseServiceConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter SharedFileSystemConfiguration_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint of the shared file system that is accessed by the studio component resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SharedFileSystemConfiguration_Endpoint")]
        public System.String SharedFileSystemConfiguration_Endpoint { get; set; }
        #endregion
        
        #region Parameter SharedFileSystemConfiguration_FileSystemId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for a file system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SharedFileSystemConfiguration_FileSystemId")]
        public System.String SharedFileSystemConfiguration_FileSystemId { get; set; }
        #endregion
        
        #region Parameter InitializationScript
        /// <summary>
        /// <para>
        /// <para>Initialization scripts for studio components.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InitializationScripts")]
        public Amazon.NimbleStudio.Model.StudioComponentInitializationScript[] InitializationScript { get; set; }
        #endregion
        
        #region Parameter SharedFileSystemConfiguration_LinuxMountPoint
        /// <summary>
        /// <para>
        /// <para>The mount location for a shared file system on a Linux virtual workstation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SharedFileSystemConfiguration_LinuxMountPoint")]
        public System.String SharedFileSystemConfiguration_LinuxMountPoint { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the studio component.</para>
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
        
        #region Parameter ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName
        /// <summary>
        /// <para>
        /// <para>The distinguished name (DN) and organizational unit (OU) of an Active Directory computer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName")]
        public System.String ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName { get; set; }
        #endregion
        
        #region Parameter ScriptParameter
        /// <summary>
        /// <para>
        /// <para>Parameters for the studio component scripts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScriptParameters")]
        public Amazon.NimbleStudio.Model.ScriptParameterKeyValue[] ScriptParameter { get; set; }
        #endregion
        
        #region Parameter SharedFileSystemConfiguration_ShareName
        /// <summary>
        /// <para>
        /// <para>The name of the file share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SharedFileSystemConfiguration_ShareName")]
        public System.String SharedFileSystemConfiguration_ShareName { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studio ID.</para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter Subtype
        /// <summary>
        /// <para>
        /// <para>The specific subtype of a studio component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.StudioComponentSubtype")]
        public Amazon.NimbleStudio.StudioComponentSubtype Subtype { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of labels, in the form of key:value pairs, that apply to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the studio component.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.NimbleStudio.StudioComponentType")]
        public Amazon.NimbleStudio.StudioComponentType Type { get; set; }
        #endregion
        
        #region Parameter SharedFileSystemConfiguration_WindowsMountDrive
        /// <summary>
        /// <para>
        /// <para>The mount location for a shared file system on a Windows virtual workstation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_SharedFileSystemConfiguration_WindowsMountDrive")]
        public System.String SharedFileSystemConfiguration_WindowsMountDrive { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>To make an idempotent API request using one of these actions, specify a client token
        /// in the request. You should not reuse the same client token for other API requests.
        /// If you retry a request that completed successfully using the same client token and
        /// the same parameters, the retry succeeds without performing any further actions. If
        /// you retry a successful request using the same client token, but one or more of the
        /// parameters are different, the retry fails with a ValidationException error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StudioComponent'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.CreateStudioComponentResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.CreateStudioComponentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StudioComponent";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StudioId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StudioId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSStudioComponent (CreateStudioComponent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.CreateStudioComponentResponse, NewNSStudioComponentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StudioId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.ActiveDirectoryConfiguration_ComputerAttribute != null)
            {
                context.ActiveDirectoryConfiguration_ComputerAttribute = new List<Amazon.NimbleStudio.Model.ActiveDirectoryComputerAttribute>(this.ActiveDirectoryConfiguration_ComputerAttribute);
            }
            context.ActiveDirectoryConfiguration_DirectoryId = this.ActiveDirectoryConfiguration_DirectoryId;
            context.ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName = this.ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName;
            context.ComputeFarmConfiguration_ActiveDirectoryUser = this.ComputeFarmConfiguration_ActiveDirectoryUser;
            context.ComputeFarmConfiguration_Endpoint = this.ComputeFarmConfiguration_Endpoint;
            context.LicenseServiceConfiguration_Endpoint = this.LicenseServiceConfiguration_Endpoint;
            context.SharedFileSystemConfiguration_Endpoint = this.SharedFileSystemConfiguration_Endpoint;
            context.SharedFileSystemConfiguration_FileSystemId = this.SharedFileSystemConfiguration_FileSystemId;
            context.SharedFileSystemConfiguration_LinuxMountPoint = this.SharedFileSystemConfiguration_LinuxMountPoint;
            context.SharedFileSystemConfiguration_ShareName = this.SharedFileSystemConfiguration_ShareName;
            context.SharedFileSystemConfiguration_WindowsMountDrive = this.SharedFileSystemConfiguration_WindowsMountDrive;
            context.Description = this.Description;
            if (this.Ec2SecurityGroupId != null)
            {
                context.Ec2SecurityGroupId = new List<System.String>(this.Ec2SecurityGroupId);
            }
            if (this.InitializationScript != null)
            {
                context.InitializationScript = new List<Amazon.NimbleStudio.Model.StudioComponentInitializationScript>(this.InitializationScript);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ScriptParameter != null)
            {
                context.ScriptParameter = new List<Amazon.NimbleStudio.Model.ScriptParameterKeyValue>(this.ScriptParameter);
            }
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Subtype = this.Subtype;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NimbleStudio.Model.CreateStudioComponentRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.NimbleStudio.Model.StudioComponentConfiguration();
            Amazon.NimbleStudio.Model.LicenseServiceConfiguration requestConfiguration_configuration_LicenseServiceConfiguration = null;
            
             // populate LicenseServiceConfiguration
            var requestConfiguration_configuration_LicenseServiceConfigurationIsNull = true;
            requestConfiguration_configuration_LicenseServiceConfiguration = new Amazon.NimbleStudio.Model.LicenseServiceConfiguration();
            System.String requestConfiguration_configuration_LicenseServiceConfiguration_licenseServiceConfiguration_Endpoint = null;
            if (cmdletContext.LicenseServiceConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_LicenseServiceConfiguration_licenseServiceConfiguration_Endpoint = cmdletContext.LicenseServiceConfiguration_Endpoint;
            }
            if (requestConfiguration_configuration_LicenseServiceConfiguration_licenseServiceConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_LicenseServiceConfiguration.Endpoint = requestConfiguration_configuration_LicenseServiceConfiguration_licenseServiceConfiguration_Endpoint;
                requestConfiguration_configuration_LicenseServiceConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_LicenseServiceConfiguration should be set to null
            if (requestConfiguration_configuration_LicenseServiceConfigurationIsNull)
            {
                requestConfiguration_configuration_LicenseServiceConfiguration = null;
            }
            if (requestConfiguration_configuration_LicenseServiceConfiguration != null)
            {
                request.Configuration.LicenseServiceConfiguration = requestConfiguration_configuration_LicenseServiceConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.ComputeFarmConfiguration requestConfiguration_configuration_ComputeFarmConfiguration = null;
            
             // populate ComputeFarmConfiguration
            var requestConfiguration_configuration_ComputeFarmConfigurationIsNull = true;
            requestConfiguration_configuration_ComputeFarmConfiguration = new Amazon.NimbleStudio.Model.ComputeFarmConfiguration();
            System.String requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_ActiveDirectoryUser = null;
            if (cmdletContext.ComputeFarmConfiguration_ActiveDirectoryUser != null)
            {
                requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_ActiveDirectoryUser = cmdletContext.ComputeFarmConfiguration_ActiveDirectoryUser;
            }
            if (requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_ActiveDirectoryUser != null)
            {
                requestConfiguration_configuration_ComputeFarmConfiguration.ActiveDirectoryUser = requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_ActiveDirectoryUser;
                requestConfiguration_configuration_ComputeFarmConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_Endpoint = null;
            if (cmdletContext.ComputeFarmConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_Endpoint = cmdletContext.ComputeFarmConfiguration_Endpoint;
            }
            if (requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_ComputeFarmConfiguration.Endpoint = requestConfiguration_configuration_ComputeFarmConfiguration_computeFarmConfiguration_Endpoint;
                requestConfiguration_configuration_ComputeFarmConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ComputeFarmConfiguration should be set to null
            if (requestConfiguration_configuration_ComputeFarmConfigurationIsNull)
            {
                requestConfiguration_configuration_ComputeFarmConfiguration = null;
            }
            if (requestConfiguration_configuration_ComputeFarmConfiguration != null)
            {
                request.Configuration.ComputeFarmConfiguration = requestConfiguration_configuration_ComputeFarmConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.ActiveDirectoryConfiguration requestConfiguration_configuration_ActiveDirectoryConfiguration = null;
            
             // populate ActiveDirectoryConfiguration
            var requestConfiguration_configuration_ActiveDirectoryConfigurationIsNull = true;
            requestConfiguration_configuration_ActiveDirectoryConfiguration = new Amazon.NimbleStudio.Model.ActiveDirectoryConfiguration();
            List<Amazon.NimbleStudio.Model.ActiveDirectoryComputerAttribute> requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_ComputerAttribute = null;
            if (cmdletContext.ActiveDirectoryConfiguration_ComputerAttribute != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_ComputerAttribute = cmdletContext.ActiveDirectoryConfiguration_ComputerAttribute;
            }
            if (requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_ComputerAttribute != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration.ComputerAttributes = requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_ComputerAttribute;
                requestConfiguration_configuration_ActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_DirectoryId = null;
            if (cmdletContext.ActiveDirectoryConfiguration_DirectoryId != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_DirectoryId = cmdletContext.ActiveDirectoryConfiguration_DirectoryId;
            }
            if (requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_DirectoryId != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration.DirectoryId = requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_DirectoryId;
                requestConfiguration_configuration_ActiveDirectoryConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_OrganizationalUnitDistinguishedName = null;
            if (cmdletContext.ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_OrganizationalUnitDistinguishedName = cmdletContext.ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName;
            }
            if (requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_OrganizationalUnitDistinguishedName != null)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration.OrganizationalUnitDistinguishedName = requestConfiguration_configuration_ActiveDirectoryConfiguration_activeDirectoryConfiguration_OrganizationalUnitDistinguishedName;
                requestConfiguration_configuration_ActiveDirectoryConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ActiveDirectoryConfiguration should be set to null
            if (requestConfiguration_configuration_ActiveDirectoryConfigurationIsNull)
            {
                requestConfiguration_configuration_ActiveDirectoryConfiguration = null;
            }
            if (requestConfiguration_configuration_ActiveDirectoryConfiguration != null)
            {
                request.Configuration.ActiveDirectoryConfiguration = requestConfiguration_configuration_ActiveDirectoryConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.SharedFileSystemConfiguration requestConfiguration_configuration_SharedFileSystemConfiguration = null;
            
             // populate SharedFileSystemConfiguration
            var requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = true;
            requestConfiguration_configuration_SharedFileSystemConfiguration = new Amazon.NimbleStudio.Model.SharedFileSystemConfiguration();
            System.String requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_Endpoint = null;
            if (cmdletContext.SharedFileSystemConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_Endpoint = cmdletContext.SharedFileSystemConfiguration_Endpoint;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_Endpoint != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration.Endpoint = requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_Endpoint;
                requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_FileSystemId = null;
            if (cmdletContext.SharedFileSystemConfiguration_FileSystemId != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_FileSystemId = cmdletContext.SharedFileSystemConfiguration_FileSystemId;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_FileSystemId != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration.FileSystemId = requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_FileSystemId;
                requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_LinuxMountPoint = null;
            if (cmdletContext.SharedFileSystemConfiguration_LinuxMountPoint != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_LinuxMountPoint = cmdletContext.SharedFileSystemConfiguration_LinuxMountPoint;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_LinuxMountPoint != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration.LinuxMountPoint = requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_LinuxMountPoint;
                requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_ShareName = null;
            if (cmdletContext.SharedFileSystemConfiguration_ShareName != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_ShareName = cmdletContext.SharedFileSystemConfiguration_ShareName;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_ShareName != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration.ShareName = requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_ShareName;
                requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_WindowsMountDrive = null;
            if (cmdletContext.SharedFileSystemConfiguration_WindowsMountDrive != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_WindowsMountDrive = cmdletContext.SharedFileSystemConfiguration_WindowsMountDrive;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_WindowsMountDrive != null)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration.WindowsMountDrive = requestConfiguration_configuration_SharedFileSystemConfiguration_sharedFileSystemConfiguration_WindowsMountDrive;
                requestConfiguration_configuration_SharedFileSystemConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_SharedFileSystemConfiguration should be set to null
            if (requestConfiguration_configuration_SharedFileSystemConfigurationIsNull)
            {
                requestConfiguration_configuration_SharedFileSystemConfiguration = null;
            }
            if (requestConfiguration_configuration_SharedFileSystemConfiguration != null)
            {
                request.Configuration.SharedFileSystemConfiguration = requestConfiguration_configuration_SharedFileSystemConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Ec2SecurityGroupId != null)
            {
                request.Ec2SecurityGroupIds = cmdletContext.Ec2SecurityGroupId;
            }
            if (cmdletContext.InitializationScript != null)
            {
                request.InitializationScripts = cmdletContext.InitializationScript;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ScriptParameter != null)
            {
                request.ScriptParameters = cmdletContext.ScriptParameter;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
            }
            if (cmdletContext.Subtype != null)
            {
                request.Subtype = cmdletContext.Subtype;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.NimbleStudio.Model.CreateStudioComponentResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.CreateStudioComponentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "CreateStudioComponent");
            try
            {
                #if DESKTOP
                return client.CreateStudioComponent(request);
                #elif CORECLR
                return client.CreateStudioComponentAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.NimbleStudio.Model.ActiveDirectoryComputerAttribute> ActiveDirectoryConfiguration_ComputerAttribute { get; set; }
            public System.String ActiveDirectoryConfiguration_DirectoryId { get; set; }
            public System.String ActiveDirectoryConfiguration_OrganizationalUnitDistinguishedName { get; set; }
            public System.String ComputeFarmConfiguration_ActiveDirectoryUser { get; set; }
            public System.String ComputeFarmConfiguration_Endpoint { get; set; }
            public System.String LicenseServiceConfiguration_Endpoint { get; set; }
            public System.String SharedFileSystemConfiguration_Endpoint { get; set; }
            public System.String SharedFileSystemConfiguration_FileSystemId { get; set; }
            public System.String SharedFileSystemConfiguration_LinuxMountPoint { get; set; }
            public System.String SharedFileSystemConfiguration_ShareName { get; set; }
            public System.String SharedFileSystemConfiguration_WindowsMountDrive { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Ec2SecurityGroupId { get; set; }
            public List<Amazon.NimbleStudio.Model.StudioComponentInitializationScript> InitializationScript { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.NimbleStudio.Model.ScriptParameterKeyValue> ScriptParameter { get; set; }
            public System.String StudioId { get; set; }
            public Amazon.NimbleStudio.StudioComponentSubtype Subtype { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.NimbleStudio.StudioComponentType Type { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.CreateStudioComponentResponse, NewNSStudioComponentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StudioComponent;
        }
        
    }
}
