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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// With the UpdatePipelineNotifications operation, you can update Amazon Simple Notification
    /// Service (Amazon SNS) notifications for a pipeline.
    /// 
    ///  
    /// <para>
    /// When you update notifications for a pipeline, Elastic Transcoder returns the values
    /// that you specified in the request.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "ETSPipelineNotifications", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticTranscoder.Model.Pipeline")]
    [AWSCmdlet("Invokes the UpdatePipelineNotifications operation against Amazon Elastic Transcoder.", Operation = new[] {"UpdatePipelineNotifications"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Pipeline",
        "This cmdlet returns a Pipeline object.",
        "The service call response (type Amazon.ElasticTranscoder.Model.UpdatePipelineNotificationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateETSPipelineNotificationsCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        #region Parameter Notifications_Completed
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic that you want to notify when Elastic Transcoder has finished
        /// processing the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notifications_Completed { get; set; }
        #endregion
        
        #region Parameter Notifications_Error
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic that you want to notify when Elastic Transcoder encounters an
        /// error condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notifications_Error { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the pipeline for which you want to change notification settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Notifications_Progressing
        /// <summary>
        /// <para>
        /// <para>The Amazon Simple Notification Service (Amazon SNS) topic that you want to notify
        /// when Elastic Transcoder has started to process the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notifications_Progressing { get; set; }
        #endregion
        
        #region Parameter Notifications_Warning
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic that you want to notify when Elastic Transcoder encounters a
        /// warning condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Notifications_Warning { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ETSPipelineNotifications (UpdatePipelineNotifications)"))
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
            context.Notifications_Completed = this.Notifications_Completed;
            context.Notifications_Error = this.Notifications_Error;
            context.Notifications_Progressing = this.Notifications_Progressing;
            context.Notifications_Warning = this.Notifications_Warning;
            
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
            var request = new Amazon.ElasticTranscoder.Model.UpdatePipelineNotificationsRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate Notifications
            bool requestNotificationsIsNull = true;
            request.Notifications = new Amazon.ElasticTranscoder.Model.Notifications();
            System.String requestNotifications_notifications_Completed = null;
            if (cmdletContext.Notifications_Completed != null)
            {
                requestNotifications_notifications_Completed = cmdletContext.Notifications_Completed;
            }
            if (requestNotifications_notifications_Completed != null)
            {
                request.Notifications.Completed = requestNotifications_notifications_Completed;
                requestNotificationsIsNull = false;
            }
            System.String requestNotifications_notifications_Error = null;
            if (cmdletContext.Notifications_Error != null)
            {
                requestNotifications_notifications_Error = cmdletContext.Notifications_Error;
            }
            if (requestNotifications_notifications_Error != null)
            {
                request.Notifications.Error = requestNotifications_notifications_Error;
                requestNotificationsIsNull = false;
            }
            System.String requestNotifications_notifications_Progressing = null;
            if (cmdletContext.Notifications_Progressing != null)
            {
                requestNotifications_notifications_Progressing = cmdletContext.Notifications_Progressing;
            }
            if (requestNotifications_notifications_Progressing != null)
            {
                request.Notifications.Progressing = requestNotifications_notifications_Progressing;
                requestNotificationsIsNull = false;
            }
            System.String requestNotifications_notifications_Warning = null;
            if (cmdletContext.Notifications_Warning != null)
            {
                requestNotifications_notifications_Warning = cmdletContext.Notifications_Warning;
            }
            if (requestNotifications_notifications_Warning != null)
            {
                request.Notifications.Warning = requestNotifications_notifications_Warning;
                requestNotificationsIsNull = false;
            }
             // determine if request.Notifications should be set to null
            if (requestNotificationsIsNull)
            {
                request.Notifications = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Pipeline;
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
        
        private static Amazon.ElasticTranscoder.Model.UpdatePipelineNotificationsResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.UpdatePipelineNotificationsRequest request)
        {
            #if DESKTOP
            return client.UpdatePipelineNotifications(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdatePipelineNotificationsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Id { get; set; }
            public System.String Notifications_Completed { get; set; }
            public System.String Notifications_Error { get; set; }
            public System.String Notifications_Progressing { get; set; }
            public System.String Notifications_Warning { get; set; }
        }
        
    }
}
