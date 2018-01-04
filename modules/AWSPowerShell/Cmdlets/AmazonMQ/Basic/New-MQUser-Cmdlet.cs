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
    /// Creates an ActiveMQ user.
    /// </summary>
    [Cmdlet("New", "MQUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon MQ CreateUser API operation.", Operation = new[] {"CreateUser"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Username parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.MQ.Model.CreateUserResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMQUserCmdlet : AmazonMQClientCmdlet, IExecutor
    {
        
        #region Parameter BrokerId
        /// <summary>
        /// <para>
        /// The unique ID that Amazon MQ generates for the
        /// broker.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrokerId { get; set; }
        #endregion
        
        #region Parameter ConsoleAccess
        /// <summary>
        /// <para>
        /// Enables access to the the ActiveMQ Web Console
        /// for the ActiveMQ user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ConsoleAccess { get; set; }
        #endregion
        
        #region Parameter Group
        /// <summary>
        /// <para>
        /// The list of groups (20 maximum) to which the ActiveMQ
        /// user belongs. This value can contain only alphanumeric characters, dashes, periods,
        /// underscores, and tildes (- . _ ~). This value must be 2-100 characters long.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Groups")]
        public System.String[] Group { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// Required. The password of the user. This value
        /// must be at least 12 characters long, must contain at least 4 unique characters, and
        /// must not contain commas.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// The username of the ActiveMQ user. This value
        /// can contain only alphanumeric characters, dashes, periods, underscores, and tildes
        /// (- . _ ~). This value must be 2-100 characters long.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Username parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MQUser (CreateUser)"))
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
            
            context.BrokerId = this.BrokerId;
            if (ParameterWasBound("ConsoleAccess"))
                context.ConsoleAccess = this.ConsoleAccess;
            if (this.Group != null)
            {
                context.Groups = new List<System.String>(this.Group);
            }
            context.Password = this.Password;
            context.Username = this.Username;
            
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
            var request = new Amazon.MQ.Model.CreateUserRequest();
            
            if (cmdletContext.BrokerId != null)
            {
                request.BrokerId = cmdletContext.BrokerId;
            }
            if (cmdletContext.ConsoleAccess != null)
            {
                request.ConsoleAccess = cmdletContext.ConsoleAccess.Value;
            }
            if (cmdletContext.Groups != null)
            {
                request.Groups = cmdletContext.Groups;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.Username;
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
        
        private Amazon.MQ.Model.CreateUserResponse CallAWSServiceOperation(IAmazonMQ client, Amazon.MQ.Model.CreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MQ", "CreateUser");
            try
            {
                #if DESKTOP
                return client.CreateUser(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateUserAsync(request);
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
            public System.String BrokerId { get; set; }
            public System.Boolean? ConsoleAccess { get; set; }
            public List<System.String> Groups { get; set; }
            public System.String Password { get; set; }
            public System.String Username { get; set; }
        }
        
    }
}
