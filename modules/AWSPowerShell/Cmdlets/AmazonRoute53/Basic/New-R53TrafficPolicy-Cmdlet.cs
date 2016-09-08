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
    /// Creates a traffic policy, which you use to create multiple DNS resource record sets
    /// for one domain name (such as example.com) or one subdomain name (such as www.example.com).
    /// 
    ///  
    /// <para>
    /// Send a <code>POST</code> request to the <code>/<i>Amazon Route 53 API version</i>/trafficpolicy</code>
    /// resource. The request body must include a document with a <code>CreateTrafficPolicyRequest</code>
    /// element. The response includes the <code>CreateTrafficPolicyResponse</code> element,
    /// which contains information about the new traffic policy.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53TrafficPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.CreateTrafficPolicyResponse")]
    [AWSCmdlet("Invokes the CreateTrafficPolicy operation against Amazon Route 53.", Operation = new[] {"CreateTrafficPolicy"})]
    [AWSCmdletOutput("Amazon.Route53.Model.CreateTrafficPolicyResponse",
        "This cmdlet returns a Amazon.Route53.Model.CreateTrafficPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewR53TrafficPolicyCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>(Optional) Any comments that you want to include about the traffic policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Document
        /// <summary>
        /// <para>
        /// <para>The definition of this traffic policy in JSON format. For more information, see <a href="http://docs.aws.amazon.com/Route53/latest/DeveloperGuide/api-policies-traffic-policy-document-format.html">Traffic
        /// Policy Document Format</a> in the <i>Amazon Route 53 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Document { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the traffic policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53TrafficPolicy (CreateTrafficPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Name = this.Name;
            context.Document = this.Document;
            context.Comment = this.Comment;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Route53.Model.CreateTrafficPolicyRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private static Amazon.Route53.Model.CreateTrafficPolicyResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.CreateTrafficPolicyRequest request)
        {
            #if DESKTOP
            return client.CreateTrafficPolicy(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateTrafficPolicyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Name { get; set; }
            public System.String Document { get; set; }
            public System.String Comment { get; set; }
        }
        
    }
}
