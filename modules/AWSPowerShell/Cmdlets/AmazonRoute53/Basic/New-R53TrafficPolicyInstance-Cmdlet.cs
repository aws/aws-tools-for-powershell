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
    /// Creates resource record sets in a specified hosted zone based on the settings in a
    /// specified traffic policy version. In addition, <code>CreateTrafficPolicyInstance</code>
    /// associates the resource record sets with a specified domain name (such as example.com)
    /// or subdomain name (such as www.example.com). Amazon Route 53 responds to DNS queries
    /// for the domain or subdomain name by using the resource record sets that <code>CreateTrafficPolicyInstance</code>
    /// created.
    /// 
    ///  
    /// <para>
    /// To create a traffic policy instance, send a <code>POST</code> request to the <code>/<i>Route
    /// 53 API version</i>/trafficpolicyinstance</code> resource. The request body must include
    /// a document with a <code>CreateTrafficPolicyRequest</code> element. The response returns
    /// the <code>CreateTrafficPolicyInstanceResponse</code> element, which contains information
    /// about the traffic policy instance.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53TrafficPolicyInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateTrafficPolicyInstanceResponse")]
    [AWSCmdlet("Invokes the CreateTrafficPolicyInstance operation against Amazon Route 53.", Operation = new[] {"CreateTrafficPolicyInstance"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateTrafficPolicyInstanceResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateTrafficPolicyInstanceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewR53TrafficPolicyInstanceCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone in which you want Amazon Route 53 to create resource record
        /// sets by using the configuration in a traffic policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The domain name (such as example.com) or subdomain name (such as www.example.com)
        /// for which Amazon Route 53 responds to DNS queries by using the resource record sets
        /// that Amazon Route 53 creates for this traffic policy instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyId
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy that you want to use to create resource record sets in
        /// the specified hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TrafficPolicyId { get; set; }
        #endregion
        
        #region Parameter TrafficPolicyVersion
        /// <summary>
        /// <para>
        /// <para>The version of the traffic policy that you want to use to create resource record sets
        /// in the specified hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TrafficPolicyVersion { get; set; }
        #endregion
        
        #region Parameter TTL
        /// <summary>
        /// <para>
        /// <para>The TTL that you want Amazon Route 53 to assign to all of the resource record sets
        /// that it creates in the specified hosted zone.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53TrafficPolicyInstance (CreateTrafficPolicyInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.HostedZoneId = this.HostedZoneId;
            context.Name = this.Name;
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
            var request = new Amazon.Route53.Model.CreateTrafficPolicyInstanceRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
                var response = client.CreateTrafficPolicyInstance(request);
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
            public System.String HostedZoneId { get; set; }
            public System.String Name { get; set; }
            public System.Int64? TTL { get; set; }
            public System.String TrafficPolicyId { get; set; }
            public System.Int32? TrafficPolicyVersion { get; set; }
        }
        
    }
}
