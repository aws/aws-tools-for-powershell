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
using Amazon.OpsWorksCM;
using Amazon.OpsWorksCM.Model;

namespace Amazon.PowerShell.Cmdlets.OWCM
{
    /// <summary>
    /// Creates and immedately starts a new server. The server is ready to use when it is
    /// in the <code>HEALTHY</code> state. By default, you can create a maximum of 10 servers.
    /// 
    /// 
    ///  
    /// <para>
    ///  This operation is asynchronous. 
    /// </para><para>
    ///  A <code>LimitExceededException</code> is thrown when you have created the maximum
    /// number of servers (10). A <code>ResourceAlreadyExistsException</code> is thrown when
    /// a server with the same name already exists in the account. A <code>ResourceNotFoundException</code>
    /// is thrown when you specify a backup ID that is not valid or is for a backup that does
    /// not exist. A <code>ValidationException</code> is thrown when parameters of the request
    /// are not valid. 
    /// </para><para>
    ///  If you do not specify a security group by adding the <code>SecurityGroupIds</code>
    /// parameter, AWS OpsWorks creates a new security group. 
    /// </para><para><i>Chef Automate:</i> The default security group opens the Chef server to the world
    /// on TCP port 443. If a KeyName is present, AWS OpsWorks enables SSH access. SSH is
    /// also open to the world on TCP port 22. 
    /// </para><para><i>Puppet Enterprise:</i> The default security group opens TCP ports 22, 443, 4433,
    /// 8140, 8142, 8143, and 8170. If a KeyName is present, AWS OpsWorks enables SSH access.
    /// SSH is also open to the world on TCP port 22. 
    /// </para><para>
    /// By default, your server is accessible from any IP address. We recommend that you update
    /// your security group rules to allow access from known IP addresses and address ranges
    /// only. To edit security group rules, open Security Groups in the navigation pane of
    /// the EC2 management console. 
    /// </para><para>
    /// To specify your own domain for a server, and provide your own self-signed or CA-signed
    /// certificate and private key, specify values for <code>CustomDomain</code>, <code>CustomCertificate</code>,
    /// and <code>CustomPrivateKey</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OWCMServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpsWorksCM.Model.CMServer")]
    [AWSCmdlet("Calls the AWS OpsWorksCM CreateServer API operation.", Operation = new[] {"CreateServer"}, SelectReturnType = typeof(Amazon.OpsWorksCM.Model.CreateServerResponse))]
    [AWSCmdletOutput("Amazon.OpsWorksCM.Model.CMServer or Amazon.OpsWorksCM.Model.CreateServerResponse",
        "This cmdlet returns an Amazon.OpsWorksCM.Model.CMServer object.",
        "The service call response (type Amazon.OpsWorksCM.Model.CreateServerResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewOWCMServerCmdlet : AmazonOpsWorksCMClientCmdlet, IExecutor
    {
        
        #region Parameter AssociatePublicIpAddress
        /// <summary>
        /// <para>
        /// <para> Associate a public IP address with a server that you are launching. Valid values
        /// are <code>true</code> or <code>false</code>. The default value is <code>true</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AssociatePublicIpAddress { get; set; }
        #endregion
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// <para> If you specify this field, AWS OpsWorks CM creates the server by using the backup
        /// represented by BackupId. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter BackupRetentionCount
        /// <summary>
        /// <para>
        /// <para> The number of automated backups that you want to keep. Whenever a new backup is created,
        /// AWS OpsWorks CM deletes the oldest backups if this number is exceeded. The default
        /// value is <code>1</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionCount { get; set; }
        #endregion
        
        #region Parameter CustomCertificate
        /// <summary>
        /// <para>
        /// <para>A PEM-formatted HTTPS certificate. The value can be be a single, self-signed certificate,
        /// or a certificate chain. If you specify a custom certificate, you must also specify
        /// values for <code>CustomDomain</code> and <code>CustomPrivateKey</code>. The following
        /// are requirements for the <code>CustomCertificate</code> value:</para><ul><li><para>You can provide either a self-signed, custom certificate, or the full certificate
        /// chain.</para></li><li><para>The certificate must be a valid X509 certificate, or a certificate chain in PEM format.</para></li><li><para>The certificate must be valid at the time of upload. A certificate can't be used before
        /// its validity period begins (the certificate's <code>NotBefore</code> date), or after
        /// it expires (the certificate's <code>NotAfter</code> date).</para></li><li><para>The certificate’s common name or subject alternative names (SANs), if present, must
        /// match the value of <code>CustomDomain</code>.</para></li><li><para>The certificate must match the value of <code>CustomPrivateKey</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCertificate { get; set; }
        #endregion
        
        #region Parameter CustomDomain
        /// <summary>
        /// <para>
        /// <para>An optional public endpoint of a server, such as <code>https://aws.my-company.com</code>.
        /// To access the server, create a CNAME DNS record in your preferred DNS service that
        /// points the custom domain to the endpoint that is generated when the server is created
        /// (the value of the CreateServer Endpoint attribute). You cannot access the server by
        /// using the generated <code>Endpoint</code> value if the server is using a custom domain.
        /// If you specify a custom domain, you must also specify values for <code>CustomCertificate</code>
        /// and <code>CustomPrivateKey</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDomain { get; set; }
        #endregion
        
        #region Parameter CustomPrivateKey
        /// <summary>
        /// <para>
        /// <para>A private key in PEM format for connecting to the server by using HTTPS. The private
        /// key must not be encrypted; it cannot be protected by a password or passphrase. If
        /// you specify a custom private key, you must also specify values for <code>CustomDomain</code>
        /// and <code>CustomCertificate</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomPrivateKey { get; set; }
        #endregion
        
        #region Parameter DisableAutomatedBackup
        /// <summary>
        /// <para>
        /// <para> Enable or disable scheduled backups. Valid values are <code>true</code> or <code>false</code>.
        /// The default value is <code>true</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DisableAutomatedBackup { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para> The configuration management engine to use. Valid values include <code>ChefAutomate</code>
        /// and <code>Puppet</code>. </para>
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
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineAttribute
        /// <summary>
        /// <para>
        /// Amazon.OpsWorksCM.Model.CreateServerRequest.EngineAttributes
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EngineAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] EngineAttribute { get; set; }
        #endregion
        
        #region Parameter EngineModel
        /// <summary>
        /// <para>
        /// <para> The engine model of the server. Valid values in this release include <code>Monolithic</code>
        /// for Puppet and <code>Single</code> for Chef. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineModel { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para> The major release version of the engine that you want to use. For a Chef server,
        /// the valid value for EngineVersion is currently <code>2</code>. For a Puppet server,
        /// valid values are <code>2019</code> or <code>2017</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the instance profile that your Amazon EC2 instances use. Although the
        /// AWS OpsWorks console typically creates the instance profile for you, if you are using
        /// API commands instead, run the service-role-creation.yaml AWS CloudFormation template,
        /// located at https://s3.amazonaws.com/opsworks-cm-us-east-1-prod-default-assets/misc/opsworks-cm-roles.yaml.
        /// This template creates a CloudFormation stack that includes the instance profile you
        /// need. </para>
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
        public System.String InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The Amazon EC2 instance type to use. For example, <code>m5.large</code>. </para>
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
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter KeyPair
        /// <summary>
        /// <para>
        /// <para> The Amazon EC2 key pair to set for the instance. This parameter is optional; if desired,
        /// you may specify this parameter to connect to your instances by using SSH. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyPair { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The start time for a one-hour period during which AWS OpsWorks CM backs up application-level
        /// data on your server if automated backups are enabled. Valid values must be specified
        /// in one of the following formats: </para><ul><li><para><code>HH:MM</code> for daily backups</para></li><li><para><code>DDD:HH:MM</code> for weekly backups</para></li></ul><para><code>MM</code> must be specified as <code>00</code>. The specified time is in coordinated
        /// universal time (UTC). The default value is a random, daily start time.</para><para><b>Example:</b><code>08:00</code>, which represents a daily start time of 08:00
        /// UTC.</para><para><b>Example:</b><code>Mon:08:00</code>, which represents a start time of every Monday
        /// at 08:00 UTC. (8:00 a.m.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para> The start time for a one-hour period each week during which AWS OpsWorks CM performs
        /// maintenance on the instance. Valid values must be specified in the following format:
        /// <code>DDD:HH:MM</code>. <code>MM</code> must be specified as <code>00</code>. The
        /// specified time is in coordinated universal time (UTC). The default value is a random
        /// one-hour period on Tuesday, Wednesday, or Friday. See <code>TimeWindowDefinition</code>
        /// for more information. </para><para><b>Example:</b><code>Mon:08:00</code>, which represents a start time of every Monday
        /// at 08:00 UTC. (8:00 a.m.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para> A list of security group IDs to attach to the Amazon EC2 instance. If you add this
        /// parameter, the specified security groups must be within the VPC that is specified
        /// by <code>SubnetIds</code>. </para><para> If you do not specify this parameter, AWS OpsWorks CM creates one new security group
        /// that uses TCP ports 22 and 443, open to 0.0.0.0/0 (everyone). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServerName
        /// <summary>
        /// <para>
        /// <para> The name of the server. The server name must be unique within your AWS account, within
        /// each region. Server names must start with a letter; then letters, numbers, or hyphens
        /// (-) are allowed, up to a maximum of 40 characters. </para>
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
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para> The service role that the AWS OpsWorks CM service backend uses to work with your
        /// account. Although the AWS OpsWorks management console typically creates the service
        /// role for you, if you are using the AWS CLI or API commands, run the service-role-creation.yaml
        /// AWS CloudFormation template, located at https://s3.amazonaws.com/opsworks-cm-us-east-1-prod-default-assets/misc/opsworks-cm-roles.yaml.
        /// This template creates a CloudFormation stack that includes the service role and instance
        /// profile that you need. </para>
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
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para> The IDs of subnets in which to launch the server EC2 instance. </para><para> Amazon EC2-Classic customers: This field is required. All servers must run within
        /// a VPC. The VPC must have "Auto Assign Public IP" enabled. </para><para> EC2-VPC customers: This field is optional. If you do not specify subnet IDs, your
        /// EC2 instances are created in a default subnet that is selected by Amazon EC2. If you
        /// specify subnet IDs, the VPC must have "Auto Assign Public IP" enabled. </para><para>For more information about supported Amazon EC2 platforms, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map that contains tag keys and tag values to attach to an AWS OpsWorks for Chef
        /// Automate or AWS OpsWorks for Puppet Enterprise server.</para><ul><li><para>The key cannot be empty.</para></li><li><para>The key can be a maximum of 127 characters, and can contain only Unicode letters,
        /// numbers, or separators, or the following special characters: <code>+ - = . _ : / @</code></para></li><li><para>The value can be a maximum 255 characters, and contain only Unicode letters, numbers,
        /// or separators, or the following special characters: <code>+ - = . _ : / @</code></para></li><li><para>Leading and trailing white spaces are trimmed from both the key and value.</para></li><li><para>A maximum of 50 user-applied tags is allowed for any AWS OpsWorks-CM server.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.OpsWorksCM.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Server'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorksCM.Model.CreateServerResponse).
        /// Specifying the name of a property of type Amazon.OpsWorksCM.Model.CreateServerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Server";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OWCMServer (CreateServer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorksCM.Model.CreateServerResponse, NewOWCMServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AssociatePublicIpAddress = this.AssociatePublicIpAddress;
            context.BackupId = this.BackupId;
            context.BackupRetentionCount = this.BackupRetentionCount;
            context.CustomCertificate = this.CustomCertificate;
            context.CustomDomain = this.CustomDomain;
            context.CustomPrivateKey = this.CustomPrivateKey;
            context.DisableAutomatedBackup = this.DisableAutomatedBackup;
            context.Engine = this.Engine;
            #if MODULAR
            if (this.Engine == null && ParameterWasBound(nameof(this.Engine)))
            {
                WriteWarning("You are passing $null as a value for parameter Engine which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EngineAttribute != null)
            {
                context.EngineAttribute = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.EngineAttribute);
            }
            context.EngineModel = this.EngineModel;
            context.EngineVersion = this.EngineVersion;
            context.InstanceProfileArn = this.InstanceProfileArn;
            #if MODULAR
            if (this.InstanceProfileArn == null && ParameterWasBound(nameof(this.InstanceProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyPair = this.KeyPair;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupId = new List<System.String>(this.SecurityGroupId);
            }
            context.ServerName = this.ServerName;
            #if MODULAR
            if (this.ServerName == null && ParameterWasBound(nameof(this.ServerName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceRoleArn = this.ServiceRoleArn;
            #if MODULAR
            if (this.ServiceRoleArn == null && ParameterWasBound(nameof(this.ServiceRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.OpsWorksCM.Model.Tag>(this.Tag);
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
            var request = new Amazon.OpsWorksCM.Model.CreateServerRequest();
            
            if (cmdletContext.AssociatePublicIpAddress != null)
            {
                request.AssociatePublicIpAddress = cmdletContext.AssociatePublicIpAddress.Value;
            }
            if (cmdletContext.BackupId != null)
            {
                request.BackupId = cmdletContext.BackupId;
            }
            if (cmdletContext.BackupRetentionCount != null)
            {
                request.BackupRetentionCount = cmdletContext.BackupRetentionCount.Value;
            }
            if (cmdletContext.CustomCertificate != null)
            {
                request.CustomCertificate = cmdletContext.CustomCertificate;
            }
            if (cmdletContext.CustomDomain != null)
            {
                request.CustomDomain = cmdletContext.CustomDomain;
            }
            if (cmdletContext.CustomPrivateKey != null)
            {
                request.CustomPrivateKey = cmdletContext.CustomPrivateKey;
            }
            if (cmdletContext.DisableAutomatedBackup != null)
            {
                request.DisableAutomatedBackup = cmdletContext.DisableAutomatedBackup.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineAttribute != null)
            {
                request.EngineAttributes = cmdletContext.EngineAttribute;
            }
            if (cmdletContext.EngineModel != null)
            {
                request.EngineModel = cmdletContext.EngineModel;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.InstanceProfileArn != null)
            {
                request.InstanceProfileArn = cmdletContext.InstanceProfileArn;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.KeyPair != null)
            {
                request.KeyPair = cmdletContext.KeyPair;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.SecurityGroupId != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupId;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
        
        private Amazon.OpsWorksCM.Model.CreateServerResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.CreateServerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorksCM", "CreateServer");
            try
            {
                #if DESKTOP
                return client.CreateServer(request);
                #elif CORECLR
                return client.CreateServerAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AssociatePublicIpAddress { get; set; }
            public System.String BackupId { get; set; }
            public System.Int32? BackupRetentionCount { get; set; }
            public System.String CustomCertificate { get; set; }
            public System.String CustomDomain { get; set; }
            public System.String CustomPrivateKey { get; set; }
            public System.Boolean? DisableAutomatedBackup { get; set; }
            public System.String Engine { get; set; }
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> EngineAttribute { get; set; }
            public System.String EngineModel { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String InstanceProfileArn { get; set; }
            public System.String InstanceType { get; set; }
            public System.String KeyPair { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<System.String> SecurityGroupId { get; set; }
            public System.String ServerName { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<System.String> SubnetId { get; set; }
            public List<Amazon.OpsWorksCM.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.OpsWorksCM.Model.CreateServerResponse, NewOWCMServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Server;
        }
        
    }
}
