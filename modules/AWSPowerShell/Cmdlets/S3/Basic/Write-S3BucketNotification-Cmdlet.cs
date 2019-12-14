/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.S3;
using Amazon.S3.Model;

namespace Amazon.PowerShell.Cmdlets.S3
{
    /// <summary>
    /// Enables notifications of specified events for a bucket. For more information about
    /// event notifications, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/NotificationHowTo.html">Configuring
    /// Event Notifications</a>.
    /// 
    ///  
    /// <para>
    /// Using this API, you can replace an existing notification configuration. The configuration
    /// is an XML file that defines the event types that you want Amazon S3 to publish and
    /// the destination where you want Amazon S3 to publish an event notification when it
    /// detects an event of the specified type.
    /// </para><para>
    /// By default, your bucket has no event notifications configured. That is, the notification
    /// configuration will be an empty <code>NotificationConfiguration</code>.
    /// </para><para><code>&lt;NotificationConfiguration&gt;</code></para><para><code>&lt;/NotificationConfiguration&gt;</code></para><para>
    /// This operation replaces the existing notification configuration with the configuration
    /// you include in the request body.
    /// </para><para>
    /// After Amazon S3 receives this request, it first verifies that any Amazon Simple Notification
    /// Service (Amazon SNS) or Amazon Simple Queue Service (Amazon SQS) destination exists,
    /// and that the bucket owner has permission to publish to it by sending a test notification.
    /// In the case of AWS Lambda destinations, Amazon S3 verifies that the Lambda function
    /// permissions grant Amazon S3 permission to invoke the function from the Amazon S3 bucket.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/NotificationHowTo.html">Configuring
    /// Notifications for Amazon S3 Events</a>.
    /// </para><para>
    /// You can disable notifications by adding the empty NotificationConfiguration element.
    /// </para><para>
    /// By default, only the bucket owner can configure notifications on a bucket. However,
    /// bucket owners can use a bucket policy to grant permission to other users to set this
    /// configuration with <code>s3:PutBucketNotification</code> permission.
    /// </para><note><para>
    /// The PUT notification is an atomic operation. For example, suppose your notification
    /// configuration includes SNS topic, SQS queue, and Lambda function configurations. When
    /// you send a PUT request with this configuration, Amazon S3 sends test messages to your
    /// SNS topic. If the message fails, the entire PUT operation will fail, and Amazon S3
    /// will not add the configuration to your bucket.
    /// </para></note><para><b>Responses</b></para><para>
    /// If the configuration in the request body includes only one <code>TopicConfiguration</code>
    /// specifying only the <code>s3:ReducedRedundancyLostObject</code> event type, the response
    /// will also include the <code>x-amz-sns-test-message-id</code> header containing the
    /// message ID of the test notification sent to the topic.
    /// </para><para>
    /// The following operation is related to <code>PutBucketNotificationConfiguration</code>:
    /// </para><ul><li><para><a>GetBucketNotificationConfiguration</a></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "S3BucketNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketNotification API operation.", Operation = new[] {"PutBucketNotification"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketNotificationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketNotificationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketNotificationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteS3BucketNotificationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter LambdaFunctionConfiguration
        /// <summary>
        /// <para>
        /// LambdaFunctionConfigurations are configuration for 
        /// Amazon S3 events to be sent to an Amazon Lambda cloud function.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LambdaFunctionConfigurations")]
        public Amazon.S3.Model.LambdaFunctionConfiguration[] LambdaFunctionConfiguration { get; set; }
        #endregion
        
        #region Parameter QueueConfiguration
        /// <summary>
        /// <para>
        /// QueueConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SQS queues.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueueConfigurations")]
        public Amazon.S3.Model.QueueConfiguration[] QueueConfiguration { get; set; }
        #endregion
        
        #region Parameter TopicConfiguration
        /// <summary>
        /// <para>
        /// TopicConfigurations are configuration for Amazon S3 
        /// events to be sent to Amazon SNS topics.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TopicConfigurations")]
        public Amazon.S3.Model.TopicConfiguration[] TopicConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.S3.Model.PutBucketNotificationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BucketName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BucketName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BucketName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-S3BucketNotification (PutBucketNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.S3.Model.PutBucketNotificationResponse, WriteS3BucketNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BucketName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BucketName = this.BucketName;
            if (this.TopicConfiguration != null)
            {
                context.TopicConfiguration = new List<Amazon.S3.Model.TopicConfiguration>(this.TopicConfiguration);
            }
            if (this.QueueConfiguration != null)
            {
                context.QueueConfiguration = new List<Amazon.S3.Model.QueueConfiguration>(this.QueueConfiguration);
            }
            if (this.LambdaFunctionConfiguration != null)
            {
                context.LambdaFunctionConfiguration = new List<Amazon.S3.Model.LambdaFunctionConfiguration>(this.LambdaFunctionConfiguration);
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
            var request = new Amazon.S3.Model.PutBucketNotificationRequest();
            
            if (cmdletContext.BucketName != null)
            {
                request.BucketName = cmdletContext.BucketName;
            }
            if (cmdletContext.TopicConfiguration != null)
            {
                request.TopicConfigurations = cmdletContext.TopicConfiguration;
            }
            if (cmdletContext.QueueConfiguration != null)
            {
                request.QueueConfigurations = cmdletContext.QueueConfiguration;
            }
            if (cmdletContext.LambdaFunctionConfiguration != null)
            {
                request.LambdaFunctionConfigurations = cmdletContext.LambdaFunctionConfiguration;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.S3.Model.PutBucketNotificationResponse CallAWSServiceOperation(IAmazonS3 client, Amazon.S3.Model.PutBucketNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Storage Service (S3)", "PutBucketNotification");
            try
            {
                #if DESKTOP
                return client.PutBucketNotification(request);
                #elif CORECLR
                return client.PutBucketNotificationAsync(request).GetAwaiter().GetResult();
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
            public System.String BucketName { get; set; }
            public List<Amazon.S3.Model.TopicConfiguration> TopicConfiguration { get; set; }
            public List<Amazon.S3.Model.QueueConfiguration> QueueConfiguration { get; set; }
            public List<Amazon.S3.Model.LambdaFunctionConfiguration> LambdaFunctionConfiguration { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketNotificationResponse, WriteS3BucketNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
