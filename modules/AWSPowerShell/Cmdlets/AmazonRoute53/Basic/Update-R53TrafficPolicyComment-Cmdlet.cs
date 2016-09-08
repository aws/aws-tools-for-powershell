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
    /// Updates the comment for a specified traffic policy version.
    /// 
    ///  
    /// <para>
    /// Send a <code>POST</code> request to the <code>/<i>Amazon Route 53 API version</i>/trafficpolicy/</code>
    /// resource.
    /// </para><para>
    /// The request body must include a document with an <code>UpdateTrafficPolicyCommentRequest</code>
    /// element.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "R53TrafficPolicyComment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53.Model.TrafficPolicy")]
    [AWSCmdlet("Invokes the UpdateTrafficPolicyComment operation against Amazon Route 53.", Operation = new[] {"UpdateTrafficPolicyComment"})]
    [AWSCmdletOutput("Amazon.Route53.Model.TrafficPolicy",
        "This cmdlet returns a TrafficPolicy object.",
        "The service call response (type Amazon.Route53.Model.UpdateTrafficPolicyCommentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateR53TrafficPolicyCommentCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>The new comment for the specified traffic policy and version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The value of <code>Id</code> for the traffic policy for which you want to update the
        /// comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The value of <code>Version</code> for the traffic policy for which you want to update
        /// the comment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Version { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-R53TrafficPolicyComment (UpdateTrafficPolicyComment)"))
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
            
            context.Id = this.Id;
            if (ParameterWasBound("Version"))
                context.Version = this.Version;
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
            var request = new Amazon.Route53.Model.UpdateTrafficPolicyCommentRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version.Value;
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
                object pipelineOutput = response.TrafficPolicy;
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
        
        private static Amazon.Route53.Model.UpdateTrafficPolicyCommentResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.UpdateTrafficPolicyCommentRequest request)
        {
            #if DESKTOP
            return client.UpdateTrafficPolicyComment(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateTrafficPolicyCommentAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Id { get; set; }
            public System.Int32? Version { get; set; }
            public System.String Comment { get; set; }
        }
        
    }
}
