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
    /// Updates the resource record sets in a specified hosted zone that were created based
    /// on the settings in a specified traffic policy version.
    /// 
    ///  <important>The DNS type of the resource record sets that you're updating must match
    /// the DNS type in the JSON document that is associated with the traffic policy version
    /// that you're using to update the traffic policy instance.</important><para>
    /// When you update a traffic policy instance, Amazon Route 53 continues to respond to
    /// DNS queries for the root resource record set name (such as example.com) while it replaces
    /// one group of resource record sets with another. Amazon Route 53 performs the following
    /// operations:
    /// </para><ol><li>Amazon Route 53 creates a new group of resource record sets based on the
    /// specified traffic policy. This is true regardless of how substantial the differences
    /// are between the existing resource record sets and the new resource record sets. </li><li>When all of the new resource record sets have been created, Amazon Route 53 starts
    /// to respond to DNS queries for the root resource record set name (such as example.com)
    /// by using the new resource record sets.</li><li>Amazon Route 53 deletes the old group
    /// of resource record sets that are associated with the root resource record set name.</li></ol><para>
    /// To update a traffic policy instance, send a <code>POST</code> request to the <code>/<i>Route
    /// 53 API version</i>/trafficpolicyinstance/<i>traffic policy ID</i></code> resource.
    /// The request body must include a document with an <code>UpdateTrafficPolicyInstanceRequest</code>
    /// element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53TrafficPolicyInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.TrafficPolicyInstance")]
    [AWSCmdlet("Invokes the UpdateTrafficPolicyInstance operation against Amazon Route 53.", Operation = new[] {"UpdateTrafficPolicyInstance"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicyInstance",
        "This cmdlet returns a TrafficPolicyInstance object.",
        "The service call response (type Amazon.Route53.Model.UpdateTrafficPolicyInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateR53TrafficPolicyInstanceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy instance that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy that you want Amazon Route 53 to use to update resource
        /// record sets for the specified traffic policy instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersion
        /// <summary>
        /// <para>
        /// <para>The version of the traffic policy that you want Amazon Route 53 to use to update resource
        /// record sets for the specified traffic policy instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TrafficPolicyVersion { get; set; }
        #endregion
        
        #region Parameter TTL
        /// <summary>
        /// <para>
        /// <para>The TTL that you want Amazon Route 53 to assign to all of the updated resource record
        /// sets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 TTL { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Id", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53TrafficPolicyInstance (UpdateTrafficPolicyInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            if (ParameterWasBound("TTL"))
                context.TTL = this.TTL;
            context.TrafficPolicyId = this.TrafficPolicyId;
            if (ParameterWasBound("TrafficPolicyVersion"))
                context.TrafficPolicyVersion = this.TrafficPolicyVersion;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.UpdateTrafficPolicyInstanceRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.TTL != null)
            {
                request.TTL = cmdletContext.TTL.Value;
            }
            if (cmdletContext.TrafficPolicyId != null)
            {
                request.TrafficPolicyId = cmdletContext.TrafficPolicyId;
            }
            if (cmdletContext.TrafficPolicyVersion != null)
            {
                request.TrafficPolicyVersion = cmdletContext.TrafficPolicyVersion.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateTrafficPolicyInstance(request);
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
            public System.Int64? TTL { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public System.Int32? TrafficPolicyVersion { get; set; }
        }
        
    }
}
