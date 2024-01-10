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
using Amazon.Panorama;
using Amazon.Panorama.Model;

namespace Amazon.PowerShell.Cmdlets.PAN
{
    /// <summary>
    /// Creates a device and returns a configuration archive. The configuration archive is
    /// a ZIP file that contains a provisioning certificate that is valid for 5 minutes. Name
    /// the configuration archive <c>certificates-omni_<i>device-name</i>.zip</c> and transfer
    /// it to the device within 5 minutes. Use the included USB storage device and connect
    /// it to the USB 3.0 port next to the HDMI output.
    /// </summary>
    [Cmdlet("Register", "PANDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Panorama.Model.ProvisionDeviceResponse")]
    [AWSCmdlet("Calls the AWS Panorama ProvisionDevice API operation.", Operation = new[] {"ProvisionDevice"}, SelectReturnType = typeof(Amazon.Panorama.Model.ProvisionDeviceResponse))]
    [AWSCmdletOutput("Amazon.Panorama.Model.ProvisionDeviceResponse",
        "This cmdlet returns an Amazon.Panorama.Model.ProvisionDeviceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterPANDeviceCmdlet : AmazonPanoramaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Ethernet0_ConnectionType
        /// <summary>
        /// <para>
        /// <para>How the device gets an IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkingConfiguration_Ethernet0_ConnectionType")]
        [AWSConstantClassSource("Amazon.Panorama.ConnectionType")]
        public Amazon.Panorama.ConnectionType Ethernet0_ConnectionType { get; set; }
        #endregion
        
        #region Parameter Ethernet1_ConnectionType
        /// <summary>
        /// <para>
        /// <para>How the device gets an IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkingConfiguration_Ethernet1_ConnectionType")]
        [AWSConstantClassSource("Amazon.Panorama.ConnectionType")]
        public Amazon.Panorama.ConnectionType Ethernet1_ConnectionType { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway
        /// <summary>
        /// <para>
        /// <para>The connection's default gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway
        /// <summary>
        /// <para>
        /// <para>The connection's default gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns
        /// <summary>
        /// <para>
        /// <para>The connection's DNS address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns
        /// <summary>
        /// <para>
        /// <para>The connection's DNS address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress
        /// <summary>
        /// <para>
        /// <para>The connection's IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress
        /// <summary>
        /// <para>
        /// <para>The connection's IP address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask
        /// <summary>
        /// <para>
        /// <para>The connection's DNS mask.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask { get; set; }
        #endregion
        
        #region Parameter NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask
        /// <summary>
        /// <para>
        /// <para>The connection's DNS mask.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the device.</para>
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
        
        #region Parameter Ntp_NtpServer
        /// <summary>
        /// <para>
        /// <para>NTP servers to use, in order of preference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkingConfiguration_Ntp_NtpServers")]
        public System.String[] Ntp_NtpServer { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags for the device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Panorama.Model.ProvisionDeviceResponse).
        /// Specifying the name of a property of type Amazon.Panorama.Model.ProvisionDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-PANDevice (ProvisionDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Panorama.Model.ProvisionDeviceResponse, RegisterPANDeviceCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ethernet0_ConnectionType = this.Ethernet0_ConnectionType;
            context.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway = this.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway;
            if (this.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns != null)
            {
                context.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns = new List<System.String>(this.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns);
            }
            context.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress = this.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress;
            context.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask = this.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask;
            context.Ethernet1_ConnectionType = this.Ethernet1_ConnectionType;
            context.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway = this.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway;
            if (this.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns != null)
            {
                context.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns = new List<System.String>(this.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns);
            }
            context.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress = this.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress;
            context.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask = this.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask;
            if (this.Ntp_NtpServer != null)
            {
                context.Ntp_NtpServer = new List<System.String>(this.Ntp_NtpServer);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Panorama.Model.ProvisionDeviceRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkingConfiguration
            var requestNetworkingConfigurationIsNull = true;
            request.NetworkingConfiguration = new Amazon.Panorama.Model.NetworkPayload();
            Amazon.Panorama.Model.NtpPayload requestNetworkingConfiguration_networkingConfiguration_Ntp = null;
            
             // populate Ntp
            var requestNetworkingConfiguration_networkingConfiguration_NtpIsNull = true;
            requestNetworkingConfiguration_networkingConfiguration_Ntp = new Amazon.Panorama.Model.NtpPayload();
            List<System.String> requestNetworkingConfiguration_networkingConfiguration_Ntp_ntp_NtpServer = null;
            if (cmdletContext.Ntp_NtpServer != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ntp_ntp_NtpServer = cmdletContext.Ntp_NtpServer;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ntp_ntp_NtpServer != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ntp.NtpServers = requestNetworkingConfiguration_networkingConfiguration_Ntp_ntp_NtpServer;
                requestNetworkingConfiguration_networkingConfiguration_NtpIsNull = false;
            }
             // determine if requestNetworkingConfiguration_networkingConfiguration_Ntp should be set to null
            if (requestNetworkingConfiguration_networkingConfiguration_NtpIsNull)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ntp = null;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ntp != null)
            {
                request.NetworkingConfiguration.Ntp = requestNetworkingConfiguration_networkingConfiguration_Ntp;
                requestNetworkingConfigurationIsNull = false;
            }
            Amazon.Panorama.Model.EthernetPayload requestNetworkingConfiguration_networkingConfiguration_Ethernet0 = null;
            
             // populate Ethernet0
            var requestNetworkingConfiguration_networkingConfiguration_Ethernet0IsNull = true;
            requestNetworkingConfiguration_networkingConfiguration_Ethernet0 = new Amazon.Panorama.Model.EthernetPayload();
            Amazon.Panorama.ConnectionType requestNetworkingConfiguration_networkingConfiguration_Ethernet0_ethernet0_ConnectionType = null;
            if (cmdletContext.Ethernet0_ConnectionType != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_ethernet0_ConnectionType = cmdletContext.Ethernet0_ConnectionType;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_ethernet0_ConnectionType != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0.ConnectionType = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_ethernet0_ConnectionType;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0IsNull = false;
            }
            Amazon.Panorama.Model.StaticIpConnectionInfo requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo = null;
            
             // populate StaticIpConnectionInfo
            var requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull = true;
            requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo = new Amazon.Panorama.Model.StaticIpConnectionInfo();
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway = cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo.DefaultGateway = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull = false;
            }
            List<System.String> requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns = cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo.Dns = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull = false;
            }
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress = cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo.IpAddress = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull = false;
            }
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask = cmdletContext.NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo.Mask = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_networkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull = false;
            }
             // determine if requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo should be set to null
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfoIsNull)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo = null;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0.StaticIpConnectionInfo = requestNetworkingConfiguration_networkingConfiguration_Ethernet0_networkingConfiguration_Ethernet0_StaticIpConnectionInfo;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0IsNull = false;
            }
             // determine if requestNetworkingConfiguration_networkingConfiguration_Ethernet0 should be set to null
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0IsNull)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet0 = null;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet0 != null)
            {
                request.NetworkingConfiguration.Ethernet0 = requestNetworkingConfiguration_networkingConfiguration_Ethernet0;
                requestNetworkingConfigurationIsNull = false;
            }
            Amazon.Panorama.Model.EthernetPayload requestNetworkingConfiguration_networkingConfiguration_Ethernet1 = null;
            
             // populate Ethernet1
            var requestNetworkingConfiguration_networkingConfiguration_Ethernet1IsNull = true;
            requestNetworkingConfiguration_networkingConfiguration_Ethernet1 = new Amazon.Panorama.Model.EthernetPayload();
            Amazon.Panorama.ConnectionType requestNetworkingConfiguration_networkingConfiguration_Ethernet1_ethernet1_ConnectionType = null;
            if (cmdletContext.Ethernet1_ConnectionType != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_ethernet1_ConnectionType = cmdletContext.Ethernet1_ConnectionType;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_ethernet1_ConnectionType != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1.ConnectionType = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_ethernet1_ConnectionType;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1IsNull = false;
            }
            Amazon.Panorama.Model.StaticIpConnectionInfo requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo = null;
            
             // populate StaticIpConnectionInfo
            var requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull = true;
            requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo = new Amazon.Panorama.Model.StaticIpConnectionInfo();
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway = cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo.DefaultGateway = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull = false;
            }
            List<System.String> requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns = cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo.Dns = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull = false;
            }
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress = cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo.IpAddress = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull = false;
            }
            System.String requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask = null;
            if (cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask = cmdletContext.NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo.Mask = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_networkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull = false;
            }
             // determine if requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo should be set to null
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfoIsNull)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo = null;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo != null)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1.StaticIpConnectionInfo = requestNetworkingConfiguration_networkingConfiguration_Ethernet1_networkingConfiguration_Ethernet1_StaticIpConnectionInfo;
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1IsNull = false;
            }
             // determine if requestNetworkingConfiguration_networkingConfiguration_Ethernet1 should be set to null
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1IsNull)
            {
                requestNetworkingConfiguration_networkingConfiguration_Ethernet1 = null;
            }
            if (requestNetworkingConfiguration_networkingConfiguration_Ethernet1 != null)
            {
                request.NetworkingConfiguration.Ethernet1 = requestNetworkingConfiguration_networkingConfiguration_Ethernet1;
                requestNetworkingConfigurationIsNull = false;
            }
             // determine if request.NetworkingConfiguration should be set to null
            if (requestNetworkingConfigurationIsNull)
            {
                request.NetworkingConfiguration = null;
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
        
        private Amazon.Panorama.Model.ProvisionDeviceResponse CallAWSServiceOperation(IAmazonPanorama client, Amazon.Panorama.Model.ProvisionDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Panorama", "ProvisionDevice");
            try
            {
                #if DESKTOP
                return client.ProvisionDevice(request);
                #elif CORECLR
                return client.ProvisionDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Amazon.Panorama.ConnectionType Ethernet0_ConnectionType { get; set; }
            public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_DefaultGateway { get; set; }
            public List<System.String> NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Dns { get; set; }
            public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_IpAddress { get; set; }
            public System.String NetworkingConfiguration_Ethernet0_StaticIpConnectionInfo_Mask { get; set; }
            public Amazon.Panorama.ConnectionType Ethernet1_ConnectionType { get; set; }
            public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_DefaultGateway { get; set; }
            public List<System.String> NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Dns { get; set; }
            public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_IpAddress { get; set; }
            public System.String NetworkingConfiguration_Ethernet1_StaticIpConnectionInfo_Mask { get; set; }
            public List<System.String> Ntp_NtpServer { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Panorama.Model.ProvisionDeviceResponse, RegisterPANDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
