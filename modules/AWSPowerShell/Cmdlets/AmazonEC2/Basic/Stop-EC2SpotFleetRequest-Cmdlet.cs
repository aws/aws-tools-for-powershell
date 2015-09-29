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
    /// Cancels the specified Spot fleet requests.
    /// 
    ///  
    /// <para>
    /// After you cancel a Spot fleet request, the Spot fleet launches no new Spot instances.
    /// You must specify whether the Spot fleet should also terminate its Spot instances.
    /// If you terminate the instances, the Spot fleet request enters the <code>cancelled_terminating</code>
    /// state. Otherwise, the Spot fleet request enters the <code>cancelled_running</code>
    /// state and the instances continue to run until they are interrupted or you terminate
    /// them manually.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CancelSpotFleetRequestsResponse")]
    [AWSCmdlet("Invokes the CancelSpotFleetRequests operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CancelSpotFleetRequests"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CancelSpotFleetRequestsResponse",
        "This cmdlet returns a CancelSpotFleetRequestsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StopEC2SpotFleetRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The IDs of the Spot fleet requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("SpotFleetRequestIds")]
        public System.String[] SpotFleetRequestId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate instances for a Spot fleet request if it is canceled
        /// successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean TerminateInstances { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotFleetRequestId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EC2SpotFleetRequest (CancelSpotFleetRequests)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.SpotFleetRequestId != null)
            {
                context.SpotFleetRequestIds = new List<String>(this.SpotFleetRequestId);
            }
            if (ParameterWasBound("TerminateInstances"))
                context.TerminateInstances = this.TerminateInstances;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CancelSpotFleetRequestsRequest();
            
            if (cmdletContext.SpotFleetRequestIds != null)
            {
                request.SpotFleetRequestIds = cmdletContext.SpotFleetRequestIds;
            }
            if (cmdletContext.TerminateInstances != null)
            {
                request.TerminateInstances = cmdletContext.TerminateInstances.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CancelSpotFleetRequests(request);
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
            public List<String> SpotFleetRequestIds { get; set; }
            public Boolean? TerminateInstances { get; set; }
        }
        
    }
}
