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
using Amazon.ELBProxy;
using Amazon.ELBProxy.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ELBP
{
    /// <summary>
    /// Creates a proxy. A proxy is a fully managed, Envoy-based proxy that runs your Envoy
    /// configuration on Amazon EC2 instances inside your own virtual private cloud (VPC).
    /// AWS provisions and scales the proxy, upgrades the Envoy version, patches the operating
    /// system, and monitors its health.
    /// </summary>
    [Cmdlet("New", "ELBPProxy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ELBProxy.Model.CreateProxyResponse")]
    [AWSCmdlet("Calls the Elastic Load Balancing for Envoy CreateProxy API operation.", Operation = new[] {"CreateProxy"}, SelectReturnType = typeof(Amazon.ELBProxy.Model.CreateProxyResponse))]
    [AWSCmdletOutput("Amazon.ELBProxy.Model.CreateProxyResponse",
        "This cmdlet returns an Amazon.ELBProxy.Model.CreateProxyResponse object containing multiple properties."
    )]
    public partial class NewELBPProxyCmdlet : AmazonELBProxyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// The attributes for the proxy. Attributes can
        /// be changed after creation. Attributes that you don't specify are set to their default
        /// values.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public Amazon.ELBProxy.Model.Attribute[] Attribute { get; set; }
        #endregion
        
        #region Parameter Configuration_ConfigurationArchive_ConfigurationByte
        /// <summary>
        /// <para>
        /// The contents of the configuration archive.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ConfigurationArchive_ConfigurationBytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Configuration_ConfigurationArchive_ConfigurationByte { get; set; }
        #endregion
        
        #region Parameter Configuration_ConfigurationFile_ConfigurationByte
        /// <summary>
        /// <para>
        /// The contents of the configuration file.
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ConfigurationFile_ConfigurationBytes")]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Configuration_ConfigurationFile_ConfigurationByte { get; set; }
        #endregion
        
        #region Parameter CustomerKmsKeyArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the
        /// customer managed KMS key used to encrypt the proxy's configuration content. If you
        /// don't specify a key, the default service-owned key is used.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerKmsKeyArn { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability
        /// <summary>
        /// <para>
        /// The IPv4 addressability setting for
        /// the proxy.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ELBProxy.ProxyIpv4Addressability")]
        public Amazon.ELBProxy.ProxyIpv4Addressability NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability
        /// <summary>
        /// <para>
        /// The IPv6 addressability setting for
        /// the proxy.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ELBProxy.ProxyIpv6Addressability")]
        public Amazon.ELBProxy.ProxyIpv6Addressability NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The name of the proxy. The name must be unique within
        /// your account for the Region. The valid characters are a-z, 0-9, and hyphens (-). You
        /// can't use a hyphen as the first or last character.
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
        
        #region Parameter ProxyVersion
        /// <summary>
        /// <para>
        /// The version of the proxy software, in `major.minor`
        /// format.
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
        public System.String ProxyVersion { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of the IAM role
        /// that provides permissions to the code that your Envoy configuration runs on the proxy,
        /// such as filters and extensions. These are the permissions that this code needs when
        /// it calls AWS services.
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_VpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// The security groups used by the proxy.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("NetworkConfiguration_VpcConfiguration_SecurityGroups")]
        public Amazon.ELBProxy.Model.SecurityGroupDetails[] NetworkConfiguration_VpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_VpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// The subnets used by the proxy.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
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
        [Alias("NetworkConfiguration_VpcConfiguration_Subnets")]
        public Amazon.ELBProxy.Model.SubnetDetails[] NetworkConfiguration_VpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The tags for the proxy.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// The type of proxy.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ELBProxy.ProxyType")]
        public Amazon.ELBProxy.ProxyType Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// A unique, case-sensitive identifier that you
        /// provide to ensure the idempotency of the request.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ELBProxy.Model.CreateProxyResponse).
        /// Specifying the name of a property of type Amazon.ELBProxy.Model.CreateProxyResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.RoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ELBPProxy (CreateProxy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ELBProxy.Model.CreateProxyResponse, NewELBPProxyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new List<Amazon.ELBProxy.Model.Attribute>(this.Attribute);
            }
            context.ClientToken = this.ClientToken;
            context.Configuration_ConfigurationArchive_ConfigurationByte = this.Configuration_ConfigurationArchive_ConfigurationByte;
            context.Configuration_ConfigurationFile_ConfigurationByte = this.Configuration_ConfigurationFile_ConfigurationByte;
            context.CustomerKmsKeyArn = this.CustomerKmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability = this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability;
            #if MODULAR
            if (this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability == null && ParameterWasBound(nameof(this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability = this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability;
            #if MODULAR
            if (this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability == null && ParameterWasBound(nameof(this.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NetworkConfiguration_VpcConfiguration_SecurityGroup != null)
            {
                context.NetworkConfiguration_VpcConfiguration_SecurityGroup = new List<Amazon.ELBProxy.Model.SecurityGroupDetails>(this.NetworkConfiguration_VpcConfiguration_SecurityGroup);
            }
            #if MODULAR
            if (this.NetworkConfiguration_VpcConfiguration_SecurityGroup == null && ParameterWasBound(nameof(this.NetworkConfiguration_VpcConfiguration_SecurityGroup)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_VpcConfiguration_SecurityGroup which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.NetworkConfiguration_VpcConfiguration_Subnet != null)
            {
                context.NetworkConfiguration_VpcConfiguration_Subnet = new List<Amazon.ELBProxy.Model.SubnetDetails>(this.NetworkConfiguration_VpcConfiguration_Subnet);
            }
            #if MODULAR
            if (this.NetworkConfiguration_VpcConfiguration_Subnet == null && ParameterWasBound(nameof(this.NetworkConfiguration_VpcConfiguration_Subnet)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_VpcConfiguration_Subnet which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProxyVersion = this.ProxyVersion;
            #if MODULAR
            if (this.ProxyVersion == null && ParameterWasBound(nameof(this.ProxyVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ProxyVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            System.IO.MemoryStream _Configuration_ConfigurationArchive_ConfigurationByteStream = null;
            System.IO.MemoryStream _Configuration_ConfigurationFile_ConfigurationByteStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ELBProxy.Model.CreateProxyRequest();
                
                if (cmdletContext.Attribute != null)
                {
                    request.Attributes = cmdletContext.Attribute;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                
                 // populate Configuration
                var requestConfigurationIsNull = true;
                request.Configuration = new Amazon.ELBProxy.Model.ProxyConfiguration();
                Amazon.ELBProxy.Model.ConfigurationArchive requestConfiguration_configuration_ConfigurationArchive = null;
                
                 // populate ConfigurationArchive
                var requestConfiguration_configuration_ConfigurationArchiveIsNull = true;
                requestConfiguration_configuration_ConfigurationArchive = new Amazon.ELBProxy.Model.ConfigurationArchive();
                System.IO.MemoryStream requestConfiguration_configuration_ConfigurationArchive_configuration_ConfigurationArchive_ConfigurationByte = null;
                if (cmdletContext.Configuration_ConfigurationArchive_ConfigurationByte != null)
                {
                    _Configuration_ConfigurationArchive_ConfigurationByteStream = new System.IO.MemoryStream(cmdletContext.Configuration_ConfigurationArchive_ConfigurationByte);
                    requestConfiguration_configuration_ConfigurationArchive_configuration_ConfigurationArchive_ConfigurationByte = _Configuration_ConfigurationArchive_ConfigurationByteStream;
                }
                if (requestConfiguration_configuration_ConfigurationArchive_configuration_ConfigurationArchive_ConfigurationByte != null)
                {
                    requestConfiguration_configuration_ConfigurationArchive.ConfigurationBytes = requestConfiguration_configuration_ConfigurationArchive_configuration_ConfigurationArchive_ConfigurationByte;
                    requestConfiguration_configuration_ConfigurationArchiveIsNull = false;
                }
                 // determine if requestConfiguration_configuration_ConfigurationArchive should be set to null
                if (requestConfiguration_configuration_ConfigurationArchiveIsNull)
                {
                    requestConfiguration_configuration_ConfigurationArchive = null;
                }
                if (requestConfiguration_configuration_ConfigurationArchive != null)
                {
                    request.Configuration.ConfigurationArchive = requestConfiguration_configuration_ConfigurationArchive;
                    requestConfigurationIsNull = false;
                }
                Amazon.ELBProxy.Model.ConfigurationFile requestConfiguration_configuration_ConfigurationFile = null;
                
                 // populate ConfigurationFile
                var requestConfiguration_configuration_ConfigurationFileIsNull = true;
                requestConfiguration_configuration_ConfigurationFile = new Amazon.ELBProxy.Model.ConfigurationFile();
                System.IO.MemoryStream requestConfiguration_configuration_ConfigurationFile_configuration_ConfigurationFile_ConfigurationByte = null;
                if (cmdletContext.Configuration_ConfigurationFile_ConfigurationByte != null)
                {
                    _Configuration_ConfigurationFile_ConfigurationByteStream = new System.IO.MemoryStream(cmdletContext.Configuration_ConfigurationFile_ConfigurationByte);
                    requestConfiguration_configuration_ConfigurationFile_configuration_ConfigurationFile_ConfigurationByte = _Configuration_ConfigurationFile_ConfigurationByteStream;
                }
                if (requestConfiguration_configuration_ConfigurationFile_configuration_ConfigurationFile_ConfigurationByte != null)
                {
                    requestConfiguration_configuration_ConfigurationFile.ConfigurationBytes = requestConfiguration_configuration_ConfigurationFile_configuration_ConfigurationFile_ConfigurationByte;
                    requestConfiguration_configuration_ConfigurationFileIsNull = false;
                }
                 // determine if requestConfiguration_configuration_ConfigurationFile should be set to null
                if (requestConfiguration_configuration_ConfigurationFileIsNull)
                {
                    requestConfiguration_configuration_ConfigurationFile = null;
                }
                if (requestConfiguration_configuration_ConfigurationFile != null)
                {
                    request.Configuration.ConfigurationFile = requestConfiguration_configuration_ConfigurationFile;
                    requestConfigurationIsNull = false;
                }
                 // determine if request.Configuration should be set to null
                if (requestConfigurationIsNull)
                {
                    request.Configuration = null;
                }
                if (cmdletContext.CustomerKmsKeyArn != null)
                {
                    request.CustomerKmsKeyArn = cmdletContext.CustomerKmsKeyArn;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                
                 // populate NetworkConfiguration
                var requestNetworkConfigurationIsNull = true;
                request.NetworkConfiguration = new Amazon.ELBProxy.Model.ProxyNetworkUserConfiguration();
                Amazon.ELBProxy.Model.ProxyIpConfiguration requestNetworkConfiguration_networkConfiguration_IpConfiguration = null;
                
                 // populate IpConfiguration
                var requestNetworkConfiguration_networkConfiguration_IpConfigurationIsNull = true;
                requestNetworkConfiguration_networkConfiguration_IpConfiguration = new Amazon.ELBProxy.Model.ProxyIpConfiguration();
                Amazon.ELBProxy.Model.ProxyIpAddressingConfiguration requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration = null;
                
                 // populate IpAddressingConfiguration
                var requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfigurationIsNull = true;
                requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration = new Amazon.ELBProxy.Model.ProxyIpAddressingConfiguration();
                Amazon.ELBProxy.ProxyIpv4Addressability requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability = null;
                if (cmdletContext.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability != null)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability = cmdletContext.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability;
                }
                if (requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability != null)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration.Ipv4Addressability = requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability;
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfigurationIsNull = false;
                }
                Amazon.ELBProxy.ProxyIpv6Addressability requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability = null;
                if (cmdletContext.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability != null)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability = cmdletContext.NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability;
                }
                if (requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability != null)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration.Ipv6Addressability = requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability;
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfigurationIsNull = false;
                }
                 // determine if requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration should be set to null
                if (requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfigurationIsNull)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration = null;
                }
                if (requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration != null)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration.IpAddressingConfiguration = requestNetworkConfiguration_networkConfiguration_IpConfiguration_networkConfiguration_IpConfiguration_IpAddressingConfiguration;
                    requestNetworkConfiguration_networkConfiguration_IpConfigurationIsNull = false;
                }
                 // determine if requestNetworkConfiguration_networkConfiguration_IpConfiguration should be set to null
                if (requestNetworkConfiguration_networkConfiguration_IpConfigurationIsNull)
                {
                    requestNetworkConfiguration_networkConfiguration_IpConfiguration = null;
                }
                if (requestNetworkConfiguration_networkConfiguration_IpConfiguration != null)
                {
                    request.NetworkConfiguration.IpConfiguration = requestNetworkConfiguration_networkConfiguration_IpConfiguration;
                    requestNetworkConfigurationIsNull = false;
                }
                Amazon.ELBProxy.Model.ProxyVpcUserConfiguration requestNetworkConfiguration_networkConfiguration_VpcConfiguration = null;
                
                 // populate VpcConfiguration
                var requestNetworkConfiguration_networkConfiguration_VpcConfigurationIsNull = true;
                requestNetworkConfiguration_networkConfiguration_VpcConfiguration = new Amazon.ELBProxy.Model.ProxyVpcUserConfiguration();
                List<Amazon.ELBProxy.Model.SecurityGroupDetails> requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_SecurityGroup = null;
                if (cmdletContext.NetworkConfiguration_VpcConfiguration_SecurityGroup != null)
                {
                    requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_SecurityGroup = cmdletContext.NetworkConfiguration_VpcConfiguration_SecurityGroup;
                }
                if (requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_SecurityGroup != null)
                {
                    requestNetworkConfiguration_networkConfiguration_VpcConfiguration.SecurityGroups = requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_SecurityGroup;
                    requestNetworkConfiguration_networkConfiguration_VpcConfigurationIsNull = false;
                }
                List<Amazon.ELBProxy.Model.SubnetDetails> requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_Subnet = null;
                if (cmdletContext.NetworkConfiguration_VpcConfiguration_Subnet != null)
                {
                    requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_Subnet = cmdletContext.NetworkConfiguration_VpcConfiguration_Subnet;
                }
                if (requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_Subnet != null)
                {
                    requestNetworkConfiguration_networkConfiguration_VpcConfiguration.Subnets = requestNetworkConfiguration_networkConfiguration_VpcConfiguration_networkConfiguration_VpcConfiguration_Subnet;
                    requestNetworkConfiguration_networkConfiguration_VpcConfigurationIsNull = false;
                }
                 // determine if requestNetworkConfiguration_networkConfiguration_VpcConfiguration should be set to null
                if (requestNetworkConfiguration_networkConfiguration_VpcConfigurationIsNull)
                {
                    requestNetworkConfiguration_networkConfiguration_VpcConfiguration = null;
                }
                if (requestNetworkConfiguration_networkConfiguration_VpcConfiguration != null)
                {
                    request.NetworkConfiguration.VpcConfiguration = requestNetworkConfiguration_networkConfiguration_VpcConfiguration;
                    requestNetworkConfigurationIsNull = false;
                }
                 // determine if request.NetworkConfiguration should be set to null
                if (requestNetworkConfigurationIsNull)
                {
                    request.NetworkConfiguration = null;
                }
                if (cmdletContext.ProxyVersion != null)
                {
                    request.ProxyVersion = cmdletContext.ProxyVersion;
                }
                if (cmdletContext.RoleArn != null)
                {
                    request.RoleArn = cmdletContext.RoleArn;
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
            finally
            {
                if( _Configuration_ConfigurationArchive_ConfigurationByteStream != null)
                {
                    _Configuration_ConfigurationArchive_ConfigurationByteStream.Dispose();
                }
                if( _Configuration_ConfigurationFile_ConfigurationByteStream != null)
                {
                    _Configuration_ConfigurationFile_ConfigurationByteStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ELBProxy.Model.CreateProxyResponse CallAWSServiceOperation(IAmazonELBProxy client, Amazon.ELBProxy.Model.CreateProxyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing for Envoy", "CreateProxy");
            try
            {
                return client.CreateProxyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ELBProxy.Model.Attribute> Attribute { get; set; }
            public System.String ClientToken { get; set; }
            public byte[] Configuration_ConfigurationArchive_ConfigurationByte { get; set; }
            public byte[] Configuration_ConfigurationFile_ConfigurationByte { get; set; }
            public System.String CustomerKmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public Amazon.ELBProxy.ProxyIpv4Addressability NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv4Addressability { get; set; }
            public Amazon.ELBProxy.ProxyIpv6Addressability NetworkConfiguration_IpConfiguration_IpAddressingConfiguration_Ipv6Addressability { get; set; }
            public List<Amazon.ELBProxy.Model.SecurityGroupDetails> NetworkConfiguration_VpcConfiguration_SecurityGroup { get; set; }
            public List<Amazon.ELBProxy.Model.SubnetDetails> NetworkConfiguration_VpcConfiguration_Subnet { get; set; }
            public System.String ProxyVersion { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.ELBProxy.ProxyType Type { get; set; }
            public System.Func<Amazon.ELBProxy.Model.CreateProxyResponse, NewELBPProxyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
