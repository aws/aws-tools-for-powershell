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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>NotifyWorkers</code> operation sends an email to one or more Workers that
    /// you specify with the Worker ID. You can specify up to 100 Worker IDs to send the same
    /// message with a single call to the NotifyWorkers operation. The NotifyWorkers operation
    /// will send a notification email to a Worker only if you have previously approved or
    /// rejected work from the Worker.
    /// </summary>
    [Cmdlet("Send", "MTRWorkerNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MTurk.Model.NotifyWorkersFailureStatus")]
    [AWSCmdlet("Invokes the NotifyWorkers operation against Amazon MTurk Service.", Operation = new[] {"NotifyWorkers"})]
    [AWSCmdletOutput("Amazon.MTurk.Model.NotifyWorkersFailureStatus",
        "This cmdlet returns a collection of NotifyWorkersFailureStatus objects.",
        "The service call response (type Amazon.MTurk.Model.NotifyWorkersResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMTRWorkerNotificationCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter MessageText
        /// <summary>
        /// <para>
        /// <para>The text of the email message to send. Can include up to 4,096 characters</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MessageText { get; set; }
        #endregion
        
        #region Parameter Subject
        /// <summary>
        /// <para>
        /// <para>The subject line of the email message to send. Can include up to 200 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Subject { get; set; }
        #endregion
        
        #region Parameter WorkerId
        /// <summary>
        /// <para>
        /// <para>A list of Worker IDs you wish to notify. You can notify upto 100 Workers at a time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WorkerIds")]
        public System.String[] WorkerId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WorkerId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-MTRWorkerNotification (NotifyWorkers)"))
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
            
            context.MessageText = this.MessageText;
            context.Subject = this.Subject;
            if (this.WorkerId != null)
            {
                context.WorkerIds = new List<System.String>(this.WorkerId);
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
            var request = new Amazon.MTurk.Model.NotifyWorkersRequest();
            
            if (cmdletContext.MessageText != null)
            {
                request.MessageText = cmdletContext.MessageText;
            }
            if (cmdletContext.Subject != null)
            {
                request.Subject = cmdletContext.Subject;
            }
            if (cmdletContext.WorkerIds != null)
            {
                request.WorkerIds = cmdletContext.WorkerIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.NotifyWorkersFailureStatuses;
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
        
        private Amazon.MTurk.Model.NotifyWorkersResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.NotifyWorkersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "NotifyWorkers");
            #if DESKTOP
            return client.NotifyWorkers(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.NotifyWorkersAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String MessageText { get; set; }
            public System.String Subject { get; set; }
            public List<System.String> WorkerIds { get; set; }
        }
        
    }
}
