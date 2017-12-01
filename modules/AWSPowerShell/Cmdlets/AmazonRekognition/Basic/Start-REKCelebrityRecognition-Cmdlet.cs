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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Starts asynchronous recognition of celebrities in a stored video.
    /// 
    ///  
    /// <para>
    /// Rekognition Video can detect celebrities in a video must be stored in an Amazon S3
    /// bucket. Use <a>Video</a> to specify the bucket name and the filename of the video.
    /// <code>StartCelebrityRecognition</code> returns a job identifier (<code>JobId</code>)
    /// which you use to get the results of the analysis. When celebrity recognition analysis
    /// is finished, Rekognition Video publishes a completion status to the Amazon Simple
    /// Notification Service topic that you specify in <code>NotificationChannel</code>. To
    /// get the results of the celebrity recognition analysis, first check that the status
    /// value published to the Amazon SNS topic is <code>SUCCEEDED</code>. If so, call and
    /// pass the job identifier (<code>JobId</code>) from the initial call to <code>StartCelebrityRecognition</code>.
    /// For more information, see <a>celebrities</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKCelebrityRecognition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartCelebrityRecognition API operation.", Operation = new[] {"StartCelebrityRecognition"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Rekognition.Model.StartCelebrityRecognitionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartREKCelebrityRecognitionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token used to identify the start request. If you use the same token with
        /// multiple <code>StartCelebrityRecognition</code> requests, the same <code>JobId</code>
        /// is returned. Use <code>ClientRequestToken</code> to prevent the same job from being
        /// accidently started more than once. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter JobTag
        /// <summary>
        /// <para>
        /// <para>Unique identifier you specify to identify the job in the completion status published
        /// to the Amazon Simple Notification Service topic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String JobTag { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that gives Amazon Rekognition publishing permissions to the
        /// Amazon SNS topic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationChannel_RoleArn { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_SNSTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon SNS topic to which Amazon Rekognition to posts the completion status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationChannel_SNSTopicArn { get; set; }
        #endregion
        
        #region Parameter Video
        /// <summary>
        /// <para>
        /// <para>The video in which you want to recognize celebrities. The video must be stored in
        /// an Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.Rekognition.Model.Video Video { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKCelebrityRecognition (StartCelebrityRecognition)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.JobTag = this.JobTag;
            context.NotificationChannel_RoleArn = this.NotificationChannel_RoleArn;
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            context.Video = this.Video;
            
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
            var request = new Amazon.Rekognition.Model.StartCelebrityRecognitionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.JobTag != null)
            {
                request.JobTag = cmdletContext.JobTag;
            }
            
             // populate NotificationChannel
            bool requestNotificationChannelIsNull = true;
            request.NotificationChannel = new Amazon.Rekognition.Model.NotificationChannel();
            System.String requestNotificationChannel_notificationChannel_RoleArn = null;
            if (cmdletContext.NotificationChannel_RoleArn != null)
            {
                requestNotificationChannel_notificationChannel_RoleArn = cmdletContext.NotificationChannel_RoleArn;
            }
            if (requestNotificationChannel_notificationChannel_RoleArn != null)
            {
                request.NotificationChannel.RoleArn = requestNotificationChannel_notificationChannel_RoleArn;
                requestNotificationChannelIsNull = false;
            }
            System.String requestNotificationChannel_notificationChannel_SNSTopicArn = null;
            if (cmdletContext.NotificationChannel_SNSTopicArn != null)
            {
                requestNotificationChannel_notificationChannel_SNSTopicArn = cmdletContext.NotificationChannel_SNSTopicArn;
            }
            if (requestNotificationChannel_notificationChannel_SNSTopicArn != null)
            {
                request.NotificationChannel.SNSTopicArn = requestNotificationChannel_notificationChannel_SNSTopicArn;
                requestNotificationChannelIsNull = false;
            }
             // determine if request.NotificationChannel should be set to null
            if (requestNotificationChannelIsNull)
            {
                request.NotificationChannel = null;
            }
            if (cmdletContext.Video != null)
            {
                request.Video = cmdletContext.Video;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.JobId;
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
        
        private Amazon.Rekognition.Model.StartCelebrityRecognitionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartCelebrityRecognitionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartCelebrityRecognition");
            try
            {
                #if DESKTOP
                return client.StartCelebrityRecognition(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartCelebrityRecognitionAsync(request);
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
            public System.String ClientRequestToken { get; set; }
            public System.String JobTag { get; set; }
            public System.String NotificationChannel_RoleArn { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public Amazon.Rekognition.Model.Video Video { get; set; }
        }
        
    }
}
