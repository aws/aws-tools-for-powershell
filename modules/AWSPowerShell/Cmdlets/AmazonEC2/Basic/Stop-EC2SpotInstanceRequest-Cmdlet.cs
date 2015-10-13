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
    /// Cancels one or more Spot instance requests. Spot instances are instances that Amazon
    /// EC2 starts on your behalf when the bid price that you specify exceeds the current
    /// Spot price. Amazon EC2 periodically sets the Spot price based on available Spot instance
    /// capacity and current Spot instance requests. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-requests.html">Spot
    /// Instance Requests</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// 
    ///  <important><para>
    /// Canceling a Spot instance request does not terminate running Spot instances associated
    /// with the request.
    /// </para></important>
    /// </summary>
    [Cmdlet("Stop", "EC2SpotInstanceRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CancelledSpotInstanceRequest")]
    [AWSCmdlet("Invokes the CancelSpotInstanceRequests operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CancelSpotInstanceRequests"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CancelledSpotInstanceRequest",
        "This cmdlet returns a collection of CancelledSpotInstanceRequest objects.",
        "The service call response (type Amazon.EC2.Model.CancelSpotInstanceRequestsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StopEC2SpotInstanceRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>One or more Spot instance request IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SpotInstanceRequestIds")]
        public System.String[] SpotInstanceRequestId { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotInstanceRequestId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EC2SpotInstanceRequest (CancelSpotInstanceRequests)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.SpotInstanceRequestId != null)
            {
                context.SpotInstanceRequestIds = new List<System.String>(this.SpotInstanceRequestId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.CancelSpotInstanceRequestsRequest();
            
            if (cmdletContext.SpotInstanceRequestIds != null)
            {
                request.SpotInstanceRequestIds = cmdletContext.SpotInstanceRequestIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CancelSpotInstanceRequests(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CancelledSpotInstanceRequests;
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
            public List<System.String> SpotInstanceRequestIds { get; set; }
        }
        
    }
}
