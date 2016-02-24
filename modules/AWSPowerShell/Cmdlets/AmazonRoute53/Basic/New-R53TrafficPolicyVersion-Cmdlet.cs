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
    /// Creates a new version of an existing traffic policy. When you create a new version
    /// of a traffic policy, you specify the ID of the traffic policy that you want to update
    /// and a JSON-formatted document that describes the new version.
    /// 
    ///  
    /// <para>
    /// You use traffic policies to create multiple DNS resource record sets for one domain
    /// name (such as example.com) or one subdomain name (such as www.example.com).
    /// </para><para>
    /// To create a new version, send a <code>POST</code> request to the <code>/<i>Route 53
    /// API version</i>/trafficpolicy/</code> resource. The request body includes a document
    /// with a <code>CreateTrafficPolicyVersionRequest</code> element. The response returns
    /// the <code>CreateTrafficPolicyVersionResponse</code> element, which contains information
    /// about the new version of the traffic policy.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53TrafficPolicyVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateTrafficPolicyVersionResponse")]
    [AWSCmdlet("Invokes the CreateTrafficPolicyVersion operation against Amazon Route 53.", Operation = new[] {"CreateTrafficPolicyVersion"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateTrafficPolicyVersionResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateTrafficPolicyVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewR53TrafficPolicyVersionCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>Any comments that you want to include about the new traffic policy version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Document
        /// <summary>
        /// <para>
        /// <para>The definition of a new traffic policy version, in JSON format. You must specify the
        /// full definition of the new traffic policy. You cannot specify just the differences
        /// between the new version and a previous version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Document { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the traffic policy for which you want to create a new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53TrafficPolicyVersion (CreateTrafficPolicyVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Id = this.Id;
            context.Document = this.Document;
            context.Comment = this.Comment;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.CreateTrafficPolicyVersionRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Document != null)
            {
                request.Document = cmdletContext.Document;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comment = cmdletContext.Comment;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateTrafficPolicyVersion(request);
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
            public System.String Id { get; set; }
            public System.String Document { get; set; }
            public System.String Comment { get; set; }
        }
        
    }
}
