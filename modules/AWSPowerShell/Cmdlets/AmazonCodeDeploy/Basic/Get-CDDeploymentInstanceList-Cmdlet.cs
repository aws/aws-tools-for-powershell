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
    /// Lists the instances for a deployment associated with the applicable IAM user or AWS
    /// account.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentInstanceList")]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the ListDeploymentInstances operation against Amazon CodeDeploy.", Operation = new[] {"ListDeploymentInstances"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a collection of String objects.",
        "The service call response (type ListDeploymentInstancesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type String)"
    )]
    public class GetCDDeploymentInstanceListCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
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
        /// <para>A subset of instances to list, by status:</para><ul><li>Pending: Include in the resulting list those instances with pending deployments.</li><li>InProgress: Include in the resulting list those instances with in-progress deployments.</li><li>Succeeded: Include in the resulting list those instances with succeeded deployments.</li><li>Failed: Include in the resulting list those instances with failed deployments.</li><li>Skipped: Include in the resulting list those instances with skipped deployments.</li><li>Unknown: Include in the resulting list those instances with deployments in an
        /// unknown state.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] InstanceStatusFilter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>An identifier that was returned from the previous list deployment instances call,
        /// which can be used to return the next set of deployment instances in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeploymentId = this.DeploymentId;
            if (this.InstanceStatusFilter != null)
            {
                context.InstanceStatusFilter = new List<String>(this.InstanceStatusFilter);
            }
            context.NextToken = this.NextToken;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ListDeploymentInstancesRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.InstanceStatusFilter != null)
            {
                request.InstanceStatusFilter = cmdletContext.InstanceStatusFilter;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListDeploymentInstances(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstancesList;
                notes = new Dictionary<string, object>();
                notes["NextToken"] = response.NextToken;
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
            public List<String> InstanceStatusFilter { get; set; }
            public String NextToken { get; set; }
        }
        
    }
}
