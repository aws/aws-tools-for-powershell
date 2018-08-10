/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Use to record events for endpoints. This method creates events and creates or updates
    /// the endpoints that those events are associated with.
    /// </summary>
    [Cmdlet("Write", "PINEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.EventsResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint PutEvents API operation.", Operation = new[] {"PutEvents"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.EventsResponse",
        "This cmdlet returns a EventsResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.PutEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WritePINEventCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The unique ID of your Amazon Pinpoint application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter EventsRequest_BatchItem
        /// <summary>
        /// <para>
        /// Batch of events with endpoint id as the key
        /// and an object of EventsBatch as value. The EventsBatch object has the PublicEndpoint
        /// and a map of event Id's to events
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable EventsRequest_BatchItem { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PINEvent (PutEvents)"))
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
            
            context.ApplicationId = this.ApplicationId;
            if (this.EventsRequest_BatchItem != null)
            {
                context.EventsRequest_BatchItem = new Dictionary<System.String, Amazon.Pinpoint.Model.EventsBatch>(StringComparer.Ordinal);
                foreach (var hashKey in this.EventsRequest_BatchItem.Keys)
                {
                    context.EventsRequest_BatchItem.Add((String)hashKey, (EventsBatch)(this.EventsRequest_BatchItem[hashKey]));
                }
            }
            
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
            var request = new Amazon.Pinpoint.Model.PutEventsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate EventsRequest
            bool requestEventsRequestIsNull = true;
            request.EventsRequest = new Amazon.Pinpoint.Model.EventsRequest();
            Dictionary<System.String, Amazon.Pinpoint.Model.EventsBatch> requestEventsRequest_eventsRequest_BatchItem = null;
            if (cmdletContext.EventsRequest_BatchItem != null)
            {
                requestEventsRequest_eventsRequest_BatchItem = cmdletContext.EventsRequest_BatchItem;
            }
            if (requestEventsRequest_eventsRequest_BatchItem != null)
            {
                request.EventsRequest.BatchItem = requestEventsRequest_eventsRequest_BatchItem;
                requestEventsRequestIsNull = false;
            }
             // determine if request.EventsRequest should be set to null
            if (requestEventsRequestIsNull)
            {
                request.EventsRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EventsResponse;
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
        
        private Amazon.Pinpoint.Model.PutEventsResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.PutEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "PutEvents");
            try
            {
                #if DESKTOP
                return client.PutEvents(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutEventsAsync(request);
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
            public System.String ApplicationId { get; set; }
            public Dictionary<System.String, Amazon.Pinpoint.Model.EventsBatch> EventsRequest_BatchItem { get; set; }
        }
        
    }
}
