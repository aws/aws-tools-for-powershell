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
    /// Deletes a specified service within a cluster. You can delete a service if you have
    /// no running tasks in it and the desired task count is zero. If the service is actively
    /// maintaining tasks, you cannot delete it, and you must update the service to a desired
    /// task count of zero. For more information, see <a>UpdateService</a>.
    /// 
    ///  <note><para>
    /// When you delete a service, if there are still running tasks that require cleanup,
    /// the service status moves from <code>ACTIVE</code> to <code>DRAINING</code>, and the
    /// service is no longer visible in the console or in <a>ListServices</a> API operations.
    /// After the tasks have stopped, then the service status moves from <code>DRAINING</code>
    /// to <code>INACTIVE</code>. Services in the <code>DRAINING</code> or <code>INACTIVE</code>
    /// status can still be viewed with <a>DescribeServices</a> API operations; however, in
    /// the future, <code>INACTIVE</code> services may be cleaned up and purged from Amazon
    /// ECS record keeping, and <a>DescribeServices</a> API operations on those services will
    /// return a <code>ServiceNotFoundException</code> error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Remove", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Invokes the DeleteService operation against Amazon EC2 Container Service.", Operation = new[] {"DeleteService"})]
    [AWSCmdletOutput("Amazon.ECS.Model.Service",
        "This cmdlet returns a Service object.",
        "The service call response (type Amazon.ECS.Model.DeleteServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the cluster that hosts the service to delete. If you do not specify a
        /// cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the service to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Service { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Service", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-ECSService (DeleteService)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Cluster = this.Cluster;
            context.Service = this.Service;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECS.Model.DeleteServiceRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeleteService(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Service;
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
            public System.String Cluster { get; set; }
            public System.String Service { get; set; }
        }
        
    }
}
