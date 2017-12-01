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
    /// Cancels the specified Spot Fleet requests.
    /// 
    ///  
    /// <para>
    /// After you cancel a Spot Fleet request, the Spot Fleet launches no new Spot Instances.
    /// You must specify whether the Spot Fleet should also terminate its Spot Instances.
    /// If you terminate the instances, the Spot Fleet request enters the <code>cancelled_terminating</code>
    /// state. Otherwise, the Spot Fleet request enters the <code>cancelled_running</code>
    /// state and the instances continue to run until they are interrupted or you terminate
    /// them manually.
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CancelSpotFleetRequestsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CancelSpotFleetRequests API operation.", Operation = new[] {"CancelSpotFleetRequests"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CancelSpotFleetRequestsResponse",
        "This cmdlet returns a Amazon.EC2.Model.CancelSpotFleetRequestsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopEC2SpotFleetRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter SpotFleetRequestId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Spot Fleet requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("SpotFleetRequestIds")]
        public System.String[] SpotFleetRequestId { get; set; }
        #endregion
        
        #region Parameter TerminateInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate instances for a Spot Fleet request if it is canceled
        /// successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TerminateInstances")]
        public System.Boolean TerminateInstance { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.SpotFleetRequestId != null)
            {
                context.SpotFleetRequestIds = new List<System.String>(this.SpotFleetRequestId);
            }
            if (ParameterWasBound("TerminateInstance"))
                context.TerminateInstances = this.TerminateInstance;
            
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
            var request = new Amazon.EC2.Model.CancelSpotFleetRequestsRequest();
            
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
        
        private Amazon.EC2.Model.CancelSpotFleetRequestsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CancelSpotFleetRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CancelSpotFleetRequests");
            try
            {
                #if DESKTOP
                return client.CancelSpotFleetRequests(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CancelSpotFleetRequestsAsync(request);
                return task.Result;
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> SpotFleetRequestIds { get; set; }
            public System.Boolean? TerminateInstances { get; set; }
        }
        
    }
}
