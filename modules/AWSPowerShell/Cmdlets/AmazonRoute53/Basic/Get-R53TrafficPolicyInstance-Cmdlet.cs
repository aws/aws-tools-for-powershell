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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Gets information about a specified traffic policy instance.
    /// 
    ///  
    /// <para>
    /// To get information about the traffic policy instance, send a <code>GET</code> request
    /// to the <code>2013-04-01/trafficpolicyinstance</code> resource.
    /// </para><note>After you submit a <code>CreateTrafficPolicyInstance</code> or an <code>UpdateTrafficPolicyInstance</code>
    /// request, there's a brief delay while Amazon Route 53 creates the resource record sets
    /// that are specified in the traffic policy definition. For more information, see the
    /// <a>State</a> response element. </note>
    /// </summary>
    [Cmdlet("Get", "R53TrafficPolicyInstance")]
    [OutputType("Amazon.Route53.Model.TrafficPolicyInstance")]
    [AWSCmdlet("Invokes the GetTrafficPolicyInstance operation against Amazon Route 53.", Operation = new[] {"GetTrafficPolicyInstance"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicyInstance",
        "This cmdlet returns a TrafficPolicyInstance object.",
        "The service call response (type Amazon.Route53.Model.GetTrafficPolicyInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53TrafficPolicyInstanceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy instance that you want to get information about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.GetTrafficPolicyInstanceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetTrafficPolicyInstance(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TrafficPolicyInstance;
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
            public System.String Id { get; set; }
        }
        
    }
}
