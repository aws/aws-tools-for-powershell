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
    /// Describes the specified services running in your cluster.
    /// </summary>
    [Cmdlet("Get", "ECSService")]
    [OutputType("Amazon.ECS.Model.DescribeServicesResponse")]
    [AWSCmdlet("Invokes the DescribeServices operation against Amazon EC2 Container Service.", Operation = new[] {"DescribeServices"})]
    [AWSCmdletOutput("Amazon.ECS.Model.DescribeServicesResponse",
        "This cmdlet returns a Amazon.ECS.Model.DescribeServicesResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The name of the cluster that hosts the service to describe. If you do not specify
        /// a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>A list of services to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Services")]
        public System.String[] Service { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Cluster = this.Cluster;
            if (this.Service != null)
            {
                context.Services = new List<System.String>(this.Service);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECS.Model.DescribeServicesRequest();
            
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            if (cmdletContext.Services != null)
            {
                request.Services = cmdletContext.Services;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeServices(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Cluster { get; set; }
            public List<System.String> Services { get; set; }
        }
        
    }
}
