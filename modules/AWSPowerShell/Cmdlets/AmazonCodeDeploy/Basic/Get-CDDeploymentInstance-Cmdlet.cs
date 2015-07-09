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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Gets information about an instance as part of a deployment.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentInstance")]
    [OutputType("Amazon.CodeDeploy.Model.InstanceSummary")]
    [AWSCmdlet("Invokes the GetDeploymentInstance operation against AWS CodeDeploy.", Operation = new[] {"GetDeploymentInstance"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.InstanceSummary",
        "This cmdlet returns a InstanceSummary object.",
        "The service call response (type GetDeploymentInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCDDeploymentInstanceCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The unique ID of a deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeploymentId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The unique ID of an instance in the deployment's deployment group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String InstanceId { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeploymentId = this.DeploymentId;
            context.InstanceId = this.InstanceId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetDeploymentInstanceRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetDeploymentInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceSummary;
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
            public String DeploymentId { get; set; }
            public String InstanceId { get; set; }
        }
        
    }
}
