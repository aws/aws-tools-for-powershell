/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// parameter, AWS OpsWorks creates a new security group. The default security group opens
    /// the Chef server to the world on TCP port 443. If a KeyName is present, AWS OpsWorks
    /// enables SSH access. SSH is also open to the world on TCP port 22. 
    /// </para><para>
    /// By default, the Chef Server is accessible from any IP address. We recommend that you
    /// update your security group rules to allow access from known IP addresses and address
    /// ranges only. To edit security group rules, open Security Groups in the navigation
    /// pane of the EC2 management console. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "OWCMServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpsWorksCM.Model.CMServer")]
    [AWSCmdlet("Invokes the CreateServer operation against AWS OpsWorksCM.", Operation = new[] {"CreateServer"})]
    [AWSCmdletOutput("Amazon.OpsWorksCM.Model.CMServer",
        "This cmdlet returns a CMServer object.",
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
        [System.Management.Automation.Parameter]
        public System.Boolean AssociatePublicIpAddress { get; set; }
        #endregion
        
        #region Parameter BackupId
        /// <summary>
        /// <para>
        /// <para> If you specify this field, AWS OpsWorks for Chef Automate creates the server by using
        /// the backup represented by BackupId. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BackupId { get; set; }
        #endregion
        
        #region Parameter BackupRetentionCount
        /// <summary>
        /// <para>
        /// <para> The number of automated backups that you want to keep. Whenever a new backup is created,
        /// AWS OpsWorks for Chef Automate deletes the oldest backups if this number is exceeded.
        /// The default value is <code>1</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 BackupRetentionCount { get; set; }
        #endregion
        
        #region Parameter DisableAutomatedBackup
        /// <summary>
        /// <para>
        /// <para> Enable or disable scheduled backups. Valid values are <code>true</code> or <code>false</code>.
        /// The default value is <code>true</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DisableAutomatedBackup { get; set; }
        #endregion
        
        #region Parameter Engine
        /// <summary>
        /// <para>
        /// <para> The configuration management engine to use. Valid values include <code>Chef</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Engine { get; set; }
        #endregion
        
        #region Parameter EngineAttribute
        /// <summary>
        /// <para>
        /// Amazon.OpsWorksCM.Model.CreateServerRequest.EngineAttributes
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EngineAttributes")]
        public Amazon.OpsWorksCM.Model.EngineAttribute[] EngineAttribute { get; set; }
        #endregion
        
        #region Parameter EngineModel
        /// <summary>
        /// <para>
        /// <para> The engine model, or option. Valid values include <code>Single</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineModel { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// <para> The major release version of the engine that you want to use. Values depend on the
        /// engine that you choose. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter InstanceProfileArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the instance profile that your Amazon EC2 instances use. Although the
        /// AWS OpsWorks console typically creates the instance profile for you, if you are using
        /// API commands instead, run the service-role-creation.yaml AWS CloudFormation template,
        /// located at https://s3.amazonaws.com/opsworks-stuff/latest/service-role-creation.yaml.
        /// This template creates a CloudFormation stack that includes the instance profile you
        /// need. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para> The Amazon EC2 instance type to use. Valid values must be specified in the following
        /// format: <code>^([cm][34]|t2).*</code> For example, <code>m4.large</code>. Valid values
        /// are <code>t2.medium</code>, <code>m4.large</code>, or <code>m4.2xlarge</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter KeyPair
        /// <summary>
        /// <para>
        /// <para> The Amazon EC2 key pair to set for the instance. This parameter is optional; if desired,
        /// you may specify this parameter to connect to your instances by using SSH. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyPair { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The start time for a one-hour period during which AWS OpsWorks for Chef Automate
        /// backs up application-level data on your server if automated backups are enabled. Valid
        /// values must be specified in one of the following formats: </para><ul><li><para><code>HH:MM</code> for daily backups</para></li><li><para><code>DDD:HH:MM</code> for weekly backups</para></li></ul><para>The specified time is in coordinated universal time (UTC). The default value is a
        /// random, daily start time.</para><para><b>Example:</b><code>08:00</code>, which represents a daily start time of 08:00
        /// UTC.</para><para><b>Example:</b><code>Mon:08:00</code>, which represents a start time of every Monday
        /// at 08:00 UTC. (8:00 a.m.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para> The start time for a one-hour period each week during which AWS OpsWorks for Chef
        /// Automate performs maintenance on the instance. Valid values must be specified in the
        /// following format: <code>DDD:HH:MM</code>. The specified time is in coordinated universal
        /// time (UTC). The default value is a random one-hour period on Tuesday, Wednesday, or
        /// Friday. See <code>TimeWindowDefinition</code> for more information. </para><para><b>Example:</b><code>Mon:08:00</code>, which represents a start time of every Monday
        /// at 08:00 UTC. (8:00 a.m.) </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para> A list of security group IDs to attach to the Amazon EC2 instance. If you add this
        /// parameter, the specified security groups must be within the VPC that is specified
        /// by <code>SubnetIds</code>. </para><para> If you do not specify this parameter, AWS OpsWorks for Chef Automate creates one
        /// new security group that uses TCP ports 22 and 443, open to 0.0.0.0/0 (everyone). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ServerName { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para> The service role that the AWS OpsWorks for Chef Automate service backend uses to
        /// work with your account. Although the AWS OpsWorks management console typically creates
        /// the service role for you, if you are using the AWS CLI or API commands, run the service-role-creation.yaml
        /// AWS CloudFormation template, located at https://s3.amazonaws.com/opsworks-stuff/latest/service-role-creation.yaml.
        /// This template creates a CloudFormation stack that includes the service role that you
        /// need. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para> The IDs of subnets in which to launch the server EC2 instance. </para><para> Amazon EC2-Classic customers: This field is required. All servers must run within
        /// a VPC. The VPC must have "Auto Assign Public IP" enabled. </para><para> EC2-VPC customers: This field is optional. If you do not specify subnet IDs, your
        /// EC2 instances are created in a default subnet that is selected by Amazon EC2. If you
        /// specify subnet IDs, the VPC must have "Auto Assign Public IP" enabled. </para><para>For more information about supported Amazon EC2 platforms, see <a href="http://docs.aws.amazon.com/https:/docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ServerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OWCMServer (CreateServer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AssociatePublicIpAddress"))
                context.AssociatePublicIpAddress = this.AssociatePublicIpAddress;
            context.BackupId = this.BackupId;
            if (ParameterWasBound("BackupRetentionCount"))
                context.BackupRetentionCount = this.BackupRetentionCount;
            if (ParameterWasBound("DisableAutomatedBackup"))
                context.DisableAutomatedBackup = this.DisableAutomatedBackup;
            context.Engine = this.Engine;
            if (this.EngineAttribute != null)
            {
                context.EngineAttributes = new List<Amazon.OpsWorksCM.Model.EngineAttribute>(this.EngineAttribute);
            }
            context.EngineModel = this.EngineModel;
            context.EngineVersion = this.EngineVersion;
            context.InstanceProfileArn = this.InstanceProfileArn;
            context.InstanceType = this.InstanceType;
            context.KeyPair = this.KeyPair;
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            context.ServerName = this.ServerName;
            context.ServiceRoleArn = this.ServiceRoleArn;
            if (this.SubnetId != null)
            {
                context.SubnetIds = new List<System.String>(this.SubnetId);
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
            if (cmdletContext.DisableAutomatedBackup != null)
            {
                request.DisableAutomatedBackup = cmdletContext.DisableAutomatedBackup.Value;
            }
            if (cmdletContext.Engine != null)
            {
                request.Engine = cmdletContext.Engine;
            }
            if (cmdletContext.EngineAttributes != null)
            {
                request.EngineAttributes = cmdletContext.EngineAttributes;
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
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.ServerName != null)
            {
                request.ServerName = cmdletContext.ServerName;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.SubnetIds != null)
            {
                request.SubnetIds = cmdletContext.SubnetIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Server;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private static Amazon.OpsWorksCM.Model.CreateServerResponse CallAWSServiceOperation(IAmazonOpsWorksCM client, Amazon.OpsWorksCM.Model.CreateServerRequest request)
        {
            #if DESKTOP
            return client.CreateServer(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateServerAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? AssociatePublicIpAddress { get; set; }
            public System.String BackupId { get; set; }
            public System.Int32? BackupRetentionCount { get; set; }
            public System.Boolean? DisableAutomatedBackup { get; set; }
            public System.String Engine { get; set; }
            public List<Amazon.OpsWorksCM.Model.EngineAttribute> EngineAttributes { get; set; }
            public System.String EngineModel { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String InstanceProfileArn { get; set; }
            public System.String InstanceType { get; set; }
            public System.String KeyPair { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public System.String ServerName { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public List<System.String> SubnetIds { get; set; }
        }
        
    }
}
