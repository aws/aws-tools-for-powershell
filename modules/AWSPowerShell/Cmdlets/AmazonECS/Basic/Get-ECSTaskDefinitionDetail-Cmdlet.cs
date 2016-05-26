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
    /// Describes a task definition. You can specify a <code>family</code> and <code>revision</code>
    /// to find information about a specific task definition, or you can simply specify the
    /// family to find the latest <code>ACTIVE</code> revision in that family.
    /// 
    ///  <note><para>
    /// You can only describe <code>INACTIVE</code> task definitions while an active task
    /// or service references them.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "ECSTaskDefinitionDetail")]
    [OutputType("Amazon.ECS.Model.TaskDefinition")]
    [AWSCmdlet("Invokes the DescribeTaskDefinition operation against Amazon EC2 Container Service.", Operation = new[] {"DescribeTaskDefinition"})]
    [AWSCmdletOutput("Amazon.ECS.Model.TaskDefinition",
        "This cmdlet returns a TaskDefinition object.",
        "The service call response (type Amazon.ECS.Model.DescribeTaskDefinitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetECSTaskDefinitionDetailCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <code>family</code> for the latest <code>ACTIVE</code> revision, <code>family</code>
        /// and <code>revision</code> (<code>family:revision</code>) for a specific revision in
        /// the family, or full Amazon Resource Name (ARN) of the task definition to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TaskDefinition { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.TaskDefinition = this.TaskDefinition;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECS.Model.DescribeTaskDefinitionRequest();
            
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.ECS.Model.DescribeTaskDefinitionResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.DescribeTaskDefinitionRequest request)
        {
            return client.DescribeTaskDefinition(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String TaskDefinition { get; set; }
        }
        
    }
}
