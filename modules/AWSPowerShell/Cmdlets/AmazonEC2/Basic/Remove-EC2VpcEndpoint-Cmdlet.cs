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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Deletes one or more specified VPC endpoints. Deleting the endpoint also deletes the
    /// endpoint routes in the route tables that were associated with the endpoint.
    /// </summary>
    [Cmdlet("Remove", "EC2VpcEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.EC2.Model.UnsuccessfulItem")]
    [AWSCmdlet("Invokes the DeleteVpcEndpoints operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DeleteVpcEndpoints"})]
    [AWSCmdletOutput("Amazon.EC2.Model.UnsuccessfulItem",
        "This cmdlet returns a collection of UnsuccessfulItem objects.",
        "The service call response (type Amazon.EC2.Model.DeleteVpcEndpointsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class RemoveEC2VpcEndpointCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>One or more endpoint IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("VpcEndpointIds")]
        public System.String[] VpcEndpointId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("VpcEndpointId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EC2VpcEndpoint (DeleteVpcEndpoints)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.VpcEndpointId != null)
            {
                context.VpcEndpointIds = new List<System.String>(this.VpcEndpointId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.DeleteVpcEndpointsRequest();
            
            if (cmdletContext.VpcEndpointIds != null)
            {
                request.VpcEndpointIds = cmdletContext.VpcEndpointIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DeleteVpcEndpoints(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Unsuccessful;
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
            public List<System.String> VpcEndpointIds { get; set; }
        }
        
    }
}
