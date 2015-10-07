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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Updates the Amazon ECS container agent on a specified container instance. Updating
    /// the Amazon ECS container agent does not interrupt running tasks or services on the
    /// container instance. The process for updating the agent differs depending on whether
    /// your container instance was launched with the Amazon ECS-optimized AMI or another
    /// operating system.
    /// 
    ///  
    /// <para><code>UpdateContainerAgent</code> requires the Amazon ECS-optimized AMI or Amazon
    /// Linux with the <code>ecs-init</code> service installed and running. For help updating
    /// the Amazon ECS container agent on other operating systems, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-agent-update.html#manually_update_agent">Manually
    /// Updating the Amazon ECS Container Agent</a> in the <i>Amazon EC2 Container Service
    /// Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ECSContainerAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.ContainerInstance")]
    [AWSCmdlet("Invokes the UpdateContainerAgent operation against Amazon EC2 Container Service.", Operation = new[] {"UpdateContainerAgent"})]
    [AWSCmdletOutput("Amazon.ECS.Model.ContainerInstance",
        "This cmdlet returns a ContainerInstance object.",
        "The service call response (type UpdateContainerAgentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateECSContainerAgentCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that your container
        /// instance is running on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The container instance ID or full Amazon Resource Name (ARN) entries for the container
        /// instance on which you would like to update the Amazon ECS container agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ContainerInstance { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Cluster", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSContainerAgent (UpdateContainerAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Cluster = this.Cluster;
            context.ContainerInstance = this.ContainerInstance;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateContainerAgentRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.ContainerInstance != null)
            {
                request.ContainerInstance = cmdletContext.ContainerInstance;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateContainerAgent(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ContainerInstance;
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
            public String Cluster { get; set; }
            public String ContainerInstance { get; set; }
        }
        
    }
}
