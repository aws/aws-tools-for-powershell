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
using Amazon.MTurk;
using Amazon.MTurk.Model;

namespace Amazon.PowerShell.Cmdlets.MTR
{
    /// <summary>
    /// The <code>SendTestEventNotification</code> operation causes Amazon Mechanical Turk
    /// to send a notification message as if a HIT event occurred, according to the provided
    /// notification specification. This allows you to test notifications without setting
    /// up notifications for a real HIT type and trying to trigger them using the website.
    /// When you call this operation, the service attempts to send the test notification immediately.
    /// </summary>
    [Cmdlet("Send", "MTRTestEventNotification")]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon MTurk Service SendTestEventNotification API operation.", Operation = new[] {"SendTestEventNotification"})]
    [AWSCmdletOutput("None",
        "This cmdlet does not generate any output. " +
        "The service response (type Amazon.MTurk.Model.SendTestEventNotificationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendMTRTestEventNotificationCmdlet : AmazonMTurkClientCmdlet, IExecutor
    {
        
        #region Parameter Notification_Destination
        /// <summary>
        /// <para>
        /// <para> The target for notification messages. The Destination’s format is determined by the
        /// specified Transport: </para><ul><li><para>When Transport is Email, the Destination is your email address.</para></li><li><para>When Transport is SQS, the Destination is your queue URL.</para></li><li><para>When Transport is SNS, the Destination is the ARN of your topic.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notification_Destination { get; set; }
        #endregion
        
        #region Parameter Notification_EventType
        /// <summary>
        /// <para>
        /// <para> The list of events that should cause notifications to be sent. Valid Values: AssignmentAccepted
        /// | AssignmentAbandoned | AssignmentReturned | AssignmentSubmitted | AssignmentRejected
        /// | AssignmentApproved | HITCreated | HITExtended | HITDisposed | HITReviewable | HITExpired
        /// | Ping. The Ping event is only valid for the SendTestEventNotification operation.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Notification_EventTypes")]
        public System.String[] Notification_EventType { get; set; }
        #endregion
        
        #region Parameter TestEventType
        /// <summary>
        /// <para>
        /// <para> The event to simulate to test the notification specification. This event is included
        /// in the test message even if the notification specification does not include the event
        /// type. The notification specification does not filter out the test event. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MTurk.EventType")]
        public Amazon.MTurk.EventType TestEventType { get; set; }
        #endregion
        
        #region Parameter Notification_Transport
        /// <summary>
        /// <para>
        /// <para> The method Amazon Mechanical Turk uses to send the notification. Valid Values: Email
        /// | SQS | SNS. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MTurk.NotificationTransport")]
        public Amazon.MTurk.NotificationTransport Notification_Transport { get; set; }
        #endregion
        
        #region Parameter Notification_Version
        /// <summary>
        /// <para>
        /// <para>The version of the Notification API to use. Valid value is 2006-05-05.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notification_Version { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Notification_Destination = this.Notification_Destination;
            if (this.Notification_EventType != null)
            {
                context.Notification_EventTypes = new List<System.String>(this.Notification_EventType);
            }
            context.Notification_Transport = this.Notification_Transport;
            context.Notification_Version = this.Notification_Version;
            context.TestEventType = this.TestEventType;
            
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
            var request = new Amazon.MTurk.Model.SendTestEventNotificationRequest();
            
            
             // populate Notification
            bool requestNotificationIsNull = true;
            request.Notification = new Amazon.MTurk.Model.NotificationSpecification();
            System.String requestNotification_notification_Destination = null;
            if (cmdletContext.Notification_Destination != null)
            {
                requestNotification_notification_Destination = cmdletContext.Notification_Destination;
            }
            if (requestNotification_notification_Destination != null)
            {
                request.Notification.Destination = requestNotification_notification_Destination;
                requestNotificationIsNull = false;
            }
            List<System.String> requestNotification_notification_EventType = null;
            if (cmdletContext.Notification_EventTypes != null)
            {
                requestNotification_notification_EventType = cmdletContext.Notification_EventTypes;
            }
            if (requestNotification_notification_EventType != null)
            {
                request.Notification.EventTypes = requestNotification_notification_EventType;
                requestNotificationIsNull = false;
            }
            Amazon.MTurk.NotificationTransport requestNotification_notification_Transport = null;
            if (cmdletContext.Notification_Transport != null)
            {
                requestNotification_notification_Transport = cmdletContext.Notification_Transport;
            }
            if (requestNotification_notification_Transport != null)
            {
                request.Notification.Transport = requestNotification_notification_Transport;
                requestNotificationIsNull = false;
            }
            System.String requestNotification_notification_Version = null;
            if (cmdletContext.Notification_Version != null)
            {
                requestNotification_notification_Version = cmdletContext.Notification_Version;
            }
            if (requestNotification_notification_Version != null)
            {
                request.Notification.Version = requestNotification_notification_Version;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            if (cmdletContext.TestEventType != null)
            {
                request.TestEventType = cmdletContext.TestEventType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
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
        
        private Amazon.MTurk.Model.SendTestEventNotificationResponse CallAWSServiceOperation(IAmazonMTurk client, Amazon.MTurk.Model.SendTestEventNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon MTurk Service", "SendTestEventNotification");
            try
            {
                #if DESKTOP
                return client.SendTestEventNotification(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SendTestEventNotificationAsync(request);
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
            public System.String Notification_Destination { get; set; }
            public List<System.String> Notification_EventTypes { get; set; }
            public Amazon.MTurk.NotificationTransport Notification_Transport { get; set; }
            public System.String Notification_Version { get; set; }
            public Amazon.MTurk.EventType TestEventType { get; set; }
        }
        
    }
}
