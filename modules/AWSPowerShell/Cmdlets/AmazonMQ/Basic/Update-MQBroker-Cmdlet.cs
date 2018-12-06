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
    /// Adds a pending configuration change to a broker.
    /// </summary>
    [Cmdlet("Update", "MQBroker", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MQ.Model.UpdateBrokerResponse")]
    [AWSCmdlet("Calls the Amazon MQ UpdateBroker API operation.", Operation = new[] {"UpdateBroker"})]
    [AWSCmdletOutput("Amazon.MQ.Model.UpdateBrokerResponse",
        "This cmdlet returns a Amazon.MQ.Model.UpdateBrokerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMQBrokerCmdlet : AmazonMQClientCmdlet, IExecutor
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
        /// Enables automatic upgrades to
        /// new minor versions for brokers, as Apache releases the versions. The automatic upgrades
        /// occur during the maintenance window of the broker or after a manual broker reboot.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoMinorVersionUpgrade { get; set; }
        #endregion
        
        #region Parameter BrokerId
        /// <summary>
        /// <para>
        /// The name of the broker. This value must be unique
        /// in your AWS account, 1-50 characters long, must contain only letters, numbers, dashes,
        /// and underscores, and must not contain whitespaces, brackets, wildcard characters,
        /// or special characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrokerId { get; set; }
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
        
        #region Parameter EngineVersion
        /// <summary>
        /// <para>
        /// The version of the broker engine. For a
        /// list of supported engine versions, see https://docs.aws.amazon.com/amazon-mq/latest/developer-guide/broker-engine.html
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BrokerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MQBroker (UpdateBroker)"))
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
            context.BrokerId = this.BrokerId;
            context.Configuration = this.Configuration;
            context.EngineVersion = this.EngineVersion;
            if (ParameterWasBound("Logs_Audit"))
                context.Logs_Audit = this.Logs_Audit;
            if (ParameterWasBound("Logs_General"))
                context.Logs_General = this.Logs_General;
            
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
            var request = new Amazon.MQ.Model.UpdateBrokerRequest();
            
            if (cmdletContext.AutoMinorVersionUpgrade != null)
            {
                request.AutoMinorVersionUpgrade = cmdletContext.AutoMinorVersionUpgrade.Value;
            }
            if (cmdletContext.BrokerId != null)
            {
                request.BrokerId = cmdletContext.BrokerId;
            }
            if (cmdletContext.Configuration != null)
            {
                request.Configuration = cmdletContext.Configuration;
            }
            if (cmdletContext.EngineVersion != null)
            {
                request.EngineVersion = cmdletContext.EngineVersion;
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
        
        private Amazon.MQ.Model.UpdateBrokerResponse CallAWSServiceOperation(IAmazonMQ client, Amazon.MQ.Model.UpdateBrokerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MQ", "UpdateBroker");
            try
            {
                #if DESKTOP
                return client.UpdateBroker(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateBrokerAsync(request);
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
            public System.String BrokerId { get; set; }
            public Amazon.MQ.Model.ConfigurationId Configuration { get; set; }
            public System.String EngineVersion { get; set; }
            public System.Boolean? Logs_Audit { get; set; }
            public System.Boolean? Logs_General { get; set; }
        }
        
    }
}
