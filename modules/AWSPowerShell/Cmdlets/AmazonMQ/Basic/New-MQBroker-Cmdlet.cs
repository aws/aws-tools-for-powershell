/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MQ;
using Amazon.MQ.Model;

namespace Amazon.PowerShell.Cmdlets.MQ
{
    /// <summary>
    /// Creates a broker. Note: This API is asynchronous.
    /// </summary>
    [Cmdlet("New", "MQBroker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MQ.Model.CreateBrokerResponse")]
    [AWSCmdlet("Calls the Amazon MQ CreateBroker API operation.", Operation = new[] {"CreateBroker"})]
    [AWSCmdletOutput("Amazon.MQ.Model.CreateBrokerResponse",
        "This cmdlet returns a Amazon.MQ.Model.CreateBrokerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMQBrokerCmdlet : AmazonMQClientCmdlet, IExecutor
    {
        
        #region Parameter Logs_Audit
        /// <summary>
        /// <para>
        /// Enables audit logging. Every user management action
        /// made using JMX or the ActiveMQ Web Console is logged.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Logs_Audit { get; set; }
        #endregion
        
        #region Parameter AutoMinorVersionUpgrade
        /// <summary>
        /// <para>
        /// Required. Enables automatic upgrades
        /// to new minor versions for brokers, as Apache releases the versions. The automatic
        /// upgrades occur during the maintenance window of the broker or after a manual broker
        /// reboot.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter BrokerName
        /// <summary>
        /// <para>
        /// Required. The name of the broker. This value
        /// must be unique in your AWS account, 1-50 characters long, must contain only letters,
        /// numbers, dashes, and underscores, and must not contain whitespaces, brackets, wildcard
        /// characters, or special characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String BrokerName { get; set; }
        #endregion
        
        #region Parameter Configuration
        /// <summary>
        /// <para>
        /// A list of information about the configuration.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MQ.Model.ConfigurationId Configuration { get; set; }
        #endregion
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// The unique ID that the requester receives
        /// for the created broker. Amazon MQ passes your ID with the API action. Note: We recommend
        /// using a Universally Unique Identifier (UUID) for the creatorRequestId. You may omit
        /// the creatorRequestId if your application doesn't require idempotency.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter DeploymentMode
        /// <summary>
        /// <para>
        /// Required. The deployment mode of the broker.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MQ.DeploymentMode")]
        public Amazon.MQ.DeploymentMode DeploymentMode { get; set; }
        #endregion
        
        #region Parameter EngineType
        /// <summary>
        /// <para>
        /// Required. The type of broker engine. Note:
        /// Currently, Amazon MQ supports only ACTIVEMQ.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MQ.EngineType")]
        public Amazon.MQ.EngineType EngineType { get; set; }
        #endregion
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// Required. The version of the broker engine.
        /// Note: Currently, Amazon MQ supports only 5.15.0.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EngineVersion { get; set; }
        #endregion
        
        #region Parameter Logs_General
        /// <summary>
        /// <para>
        /// Enables general logging.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Logs_General { get; set; }
        #endregion
        
        #region Parameter HostInstanceType
        /// <summary>
        /// <para>
        /// Required. The broker's instance type.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HostInstanceType { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindowStartTime
        /// <summary>
        /// <para>
        /// The parameters that determine
        /// the WeeklyStartTime.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MQ.Model.WeeklyStartTime MaintenanceWindowStartTime { get; set; }
        #endregion
        
        #region Parameter PubliclyAccessible
        /// <summary>
        /// <para>
        /// Required. Enables connections from
        /// applications outside of the VPC that hosts the broker's subnets.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PubliclyAccessible { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// The list of rules (1 minimum, 125 maximum)
        /// that authorize connections to brokers.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// The list of groups (2 maximum) that define which
        /// subnets and IP ranges the broker can use from different Availability Zones. A SINGLE_INSTANCE
        /// deployment requires one subnet (for example, the default subnet). An ACTIVE_STANDBY_MULTI_AZ
        /// deployment requires two subnets.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter User
        /// <summary>
        /// <para>
        /// Required. The list of ActiveMQ users (persons or
        /// applications) who can access queues and topics. This value can contain only alphanumeric
        /// characters, dashes, periods, underscores, and tildes (- . _ ~). This value must be
        /// 2-100 characters long.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Users")]
        public Amazon.MQ.Model.User[] User { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BrokerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MQBroker (CreateBroker)"))
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
            
            if (ParameterWasBound("AutoMinorVersionUpgrade"))
                context.AutoMinorVersionUpgrade = this.AutoMinorVersionUpgrade;
            context.BrokerName = this.BrokerName;
            context.Configuration = this.Configuration;
            context.CreatorRequestId = this.CreatorRequestId;
            context.DeploymentMode = this.DeploymentMode;
            context.EngineType = this.EngineType;
            context.EngineVersion = this.EngineVersion;
            context.HostInstanceType = this.HostInstanceType;
            if (ParameterWasBound("Logs_Audit"))
                context.Logs_Audit = this.Logs_Audit;
            if (ParameterWasBound("Logs_General"))
                context.Logs_General = this.Logs_General;
            context.MaintenanceWindowStartTime = this.MaintenanceWindowStartTime;
            if (ParameterWasBound("PubliclyAccessible"))
                context.PubliclyAccessible = this.PubliclyAccessible;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroups = new List<System.String>(this.SecurityGroup);
            }
            if (this.SubnetId != null)
            {
                context.SubnetIds = new List<System.String>(this.SubnetId);
            }
            if (this.User != null)
            {
                context.Users = new List<Amazon.MQ.Model.User>(this.User);
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
            var request = new Amazon.MQ.Model.CreateBrokerRequest();
            
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.BrokerName != null)
            {
                request.BrokerName = cmdletContext.BrokerName;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            if (cmdletContext.DeploymentMode != null)
            {
                request.DeploymentMode = cmdletContext.DeploymentMode;
            }
            if (cmdletContext.EngineType != null)
            {
                request.EngineType = cmdletContext.EngineType;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
            }
            if (cmdletContext.HostInstanceType != null)
            {
                request.HostInstanceType = cmdletContext.HostInstanceType;
            }
            
             // populate Logs
            bool requestLogsIsNull = true;
            request.Logs = new Amazon.MQ.Model.Logs();
            System.Boolean? requestLogs_logs_Audit = null;
            if (cmdletContext.Logs_Audit != null)
            {
                requestLogs_logs_Audit = cmdletContext.Logs_Audit.Value;
            }
            if (requestLogs_logs_Audit != null)
            {
                request.Logs.Audit = requestLogs_logs_Audit.Value;
                requestLogsIsNull = false;
            }
            System.Boolean? requestLogs_logs_General = null;
            if (cmdletContext.Logs_General != null)
            {
                requestLogs_logs_General = cmdletContext.Logs_General.Value;
            }
            if (requestLogs_logs_General != null)
            {
                request.Logs.General = requestLogs_logs_General.Value;
                requestLogsIsNull = false;
            }
             // determine if request.Logs should be set to null
            if (requestLogsIsNull)
            {
                request.Logs = null;
            }
            if (cmdletContext.MaintenanceWindowStartTime != null)
            {
                request.MaintenanceWindowStartTime = cmdletContext.MaintenanceWindowStartTime;
            }
            if (cmdletContext.PubliclyAccessible != null)
            {
                request.PubliclyAccessible = cmdletContext.PubliclyAccessible.Value;
            }
            if (cmdletContext.SecurityGroups != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroups;
            }
            if (cmdletContext.SubnetIds != null)
            {
                request.SubnetIds = cmdletContext.SubnetIds;
            }
            if (cmdletContext.Users != null)
            {
                request.Users = cmdletContext.Users;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.MQ.Model.CreateBrokerResponse CallAWSServiceOperation(IAmazonMQ client, Amazon.MQ.Model.CreateBrokerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MQ", "CreateBroker");
            try
            {
                #if DESKTOP
                return client.CreateBroker(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateBrokerAsync(request);
                return task.Result;
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
            public System.Boolean? AutoMinorVersionUpgrade { get; set; }
            public System.String BrokerName { get; set; }
            public Amazon.MQ.Model.ConfigurationId Configuration { get; set; }
            public System.String CreatorRequestId { get; set; }
            public Amazon.MQ.DeploymentMode DeploymentMode { get; set; }
            public Amazon.MQ.EngineType EngineType { get; set; }
            public System.String EngineVersion { get; set; }
            public System.String HostInstanceType { get; set; }
            public System.Boolean? Logs_Audit { get; set; }
            public System.Boolean? Logs_General { get; set; }
            public Amazon.MQ.Model.WeeklyStartTime MaintenanceWindowStartTime { get; set; }
            public System.Boolean? PubliclyAccessible { get; set; }
            public List<System.String> SecurityGroups { get; set; }
            public List<System.String> SubnetIds { get; set; }
            public List<Amazon.MQ.Model.User> Users { get; set; }
        }
        
    }
}
