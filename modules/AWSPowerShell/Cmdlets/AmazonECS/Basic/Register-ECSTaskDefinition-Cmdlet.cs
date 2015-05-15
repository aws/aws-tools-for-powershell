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
    /// Registers a new task definition from the supplied <code>family</code> and <code>containerDefinitions</code>.
    /// Optionally, you can add data volumes to your containers with the <code>volumes</code>
    /// parameter. For more information on task definition parameters and defaults, see <a href="http://docs.aws.amazon.com/AmazonECS/latest/developerguide/task_defintions.html">Amazon
    /// ECS Task Definitions</a> in the <i>Amazon EC2 Container Service Developer Guide</i>.
    /// </summary>
    [Cmdlet("Register", "ECSTaskDefinition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.TaskDefinition")]
    [AWSCmdlet("Invokes the RegisterTaskDefinition operation against Amazon EC2 Container Service.", Operation = new[] {"RegisterTaskDefinition"})]
    [AWSCmdletOutput("Amazon.ECS.Model.TaskDefinition",
        "This cmdlet returns a TaskDefinition object.",
        "The service call response (type RegisterTaskDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RegisterECSTaskDefinitionCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of container definitions in JSON format that describe the different containers
        /// that make up your task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContainerDefinitions")]
        public Amazon.ECS.Model.ContainerDefinition[] ContainerDefinition { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>You must specify a <code>family</code> for a task definition, which allows you to
        /// track multiple versions of the same task definition. You can think of the <code>family</code>
        /// as a name for your task definition. Up to 255 letters (uppercase and lowercase), numbers,
        /// hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String Family { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of volume definitions in JSON format that containers in your task may use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Volumes")]
        public Amazon.ECS.Model.Volume[] Volume { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Family", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-ECSTaskDefinition (RegisterTaskDefinition)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.ContainerDefinition != null)
            {
                context.ContainerDefinitions = new List<ContainerDefinition>(this.ContainerDefinition);
            }
            context.Family = this.Family;
            if (this.Volume != null)
            {
                context.Volumes = new List<Volume>(this.Volume);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new RegisterTaskDefinitionRequest();
            
            if (cmdletContext.ContainerDefinitions != null)
            {
                request.ContainerDefinitions = cmdletContext.ContainerDefinitions;
            }
            if (cmdletContext.Family != null)
            {
                request.Family = cmdletContext.Family;
            }
            if (cmdletContext.Volumes != null)
            {
                request.Volumes = cmdletContext.Volumes;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.RegisterTaskDefinition(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TaskDefinition;
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
            public List<ContainerDefinition> ContainerDefinitions { get; set; }
            public String Family { get; set; }
            public List<Volume> Volumes { get; set; }
        }
        
    }
}
