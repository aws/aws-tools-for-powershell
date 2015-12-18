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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Causes the environment to restart the application container server running on each
    /// Amazon EC2 instance.
    /// </summary>
    [Cmdlet("Restart", "EBAppServer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the RestartAppServer operation against AWS Elastic Beanstalk.", Operation = new[] {"RestartAppServer"})]
    [AWSCmdletOutput("None or System.String",
        "Returns the id or name of the environment (depending on which parameter was supplied) when you use the PassThru parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticBeanstalk.Model.RestartAppServerResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RestartEBAppServerCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para> The ID of the environment to restart the server for. </para><para> Condition: You must specify either this or an EnvironmentName, or both. If you do
        /// not specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter EnvironmentName
        /// <summary>
        /// <para>
        /// <para> The name of the environment to restart the server for. </para><para> Condition: You must specify either this or an EnvironmentId, or both. If you do not
        /// specify either, AWS Elastic Beanstalk returns <code>MissingRequiredParameter</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String EnvironmentName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the id or name of the environment (depending on which parameter was supplied).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EnvironmentId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restart-EBAppServer (RestartAppServer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.EnvironmentId = this.EnvironmentId;
            context.EnvironmentName = this.EnvironmentName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ElasticBeanstalk.Model.RestartAppServerRequest();
            
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.EnvironmentName != null)
            {
                request.EnvironmentName = cmdletContext.EnvironmentName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RestartAppServer(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = GetFirstAssignedParameterValue("EnvironmentId", "EnvironmentName");
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String EnvironmentId { get; set; }
            public System.String EnvironmentName { get; set; }
        }
        
    }
}
