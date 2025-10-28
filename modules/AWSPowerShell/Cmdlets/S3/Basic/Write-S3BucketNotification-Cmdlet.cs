/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// <note><para>
    /// This operation is not supported for directory buckets.
    /// </para></note><para>
    /// Enables notifications of specified events for a bucket. For more information about
    /// event notifications, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/NotificationHowTo.html">Configuring
    /// Event Notifications</a>.
    /// </para><para>
    /// Using this API, you can replace an existing notification configuration. The configuration
    /// is an XML file that defines the event types that you want Amazon S3 to publish and
    /// the destination where you want Amazon S3 to publish an event notification when it
    /// detects an event of the specified type.
    /// </para><para>
    /// By default, your bucket has no event notifications configured. That is, the notification
    /// configuration will be an empty <c>NotificationConfiguration</c>.
    /// </para><para><c>&lt;NotificationConfiguration&gt;</c></para><para><c>&lt;/NotificationConfiguration&gt;</c></para><para>
    /// This action replaces the existing notification configuration with the configuration
    /// you include in the request body.
    /// </para><para>
    /// After Amazon S3 receives this request, it first verifies that any Amazon Simple Notification
    /// Service (Amazon SNS) or Amazon Simple Queue Service (Amazon SQS) destination exists,
    /// and that the bucket owner has permission to publish to it by sending a test notification.
    /// In the case of Lambda destinations, Amazon S3 verifies that the Lambda function permissions
    /// grant Amazon S3 permission to invoke the function from the Amazon S3 bucket. For more
    /// information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/NotificationHowTo.html">Configuring
    /// Notifications for Amazon S3 Events</a>.
    /// </para><para>
    /// You can disable notifications by adding the empty NotificationConfiguration element.
    /// </para><para>
    /// For more information about the number of event notification configurations that you
    /// can create per bucket, see <a href="https://docs.aws.amazon.com/general/latest/gr/s3.html#limits_s3">Amazon
    /// S3 service quotas</a> in <i>Amazon Web Services General Reference</i>.
    /// </para><para>
    /// By default, only the bucket owner can configure notifications on a bucket. However,
    /// bucket owners can use a bucket policy to grant permission to other users to set this
    /// configuration with the required <c>s3:PutBucketNotification</c> permission.
    /// </para><note><para>
    /// The PUT notification is an atomic operation. For example, suppose your notification
    /// configuration includes SNS topic, SQS queue, and Lambda function configurations. When
    /// you send a PUT request with this configuration, Amazon S3 sends test messages to your
    /// SNS topic. If the message fails, the entire PUT action will fail, and Amazon S3 will
    /// not add the configuration to your bucket.
    /// </para></note><para>
    /// If the configuration in the request body includes only one <c>TopicConfiguration</c>
    /// specifying only the <c>s3:ReducedRedundancyLostObject</c> event type, the response
    /// will also include the <c>x-amz-sns-test-message-id</c> header containing the message
    /// ID of the test notification sent to the topic.
    /// </para><para>
    /// The following action is related to <c>PutBucketNotificationConfiguration</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/AmazonS3/latest/API/API_GetBucketNotificationConfiguration.html">GetBucketNotificationConfiguration</a></para></li></ul><important><para>
    /// You must URL encode any signed header values that contain spaces. For example, if
    /// your header value is <c>my file.txt</c>, containing two spaces after <c>my</c>, you
    /// must URL encode this value to <c>my%20%20file.txt</c>.
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "S3BucketNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Storage Service (S3) PutBucketNotification API operation.", Operation = new[] {"PutBucketNotification"}, SelectReturnType = typeof(Amazon.S3.Model.PutBucketNotificationResponse))]
    [AWSCmdletOutput("None or Amazon.S3.Model.PutBucketNotificationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.S3.Model.PutBucketNotificationResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteS3BucketNotificationCmdlet : AmazonS3ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BucketName { get; set; }
        #endregion
        
        #region Parameter ChecksumAlgorithm
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.S3.ChecksumAlgorithm")]
        public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
        #endregion
        
        #region Parameter EventBridgeConfiguration
        /// <summary>
        /// <para>
        /// <para>Enables delivery of all bucket events to Amazon EventBridge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.S3.Model.EventBridgeConfiguration EventBridgeConfiguration { get; set; }
        #endregion
        
        #region Parameter ExpectedBucketOwner
        /// <summary>
        /// <para>
        /// <para>The account ID of the expected bucket owner. If the account ID that you provide does
        /// not match the actual owner of the bucket, the request fails with the HTTP status code
        /// <code>403 Forbidden</code> (access denied).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExpectedBucketOwner { get; set; }
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
        
        #region Parameter SkipDestinationValidation
        /// <summary>
        /// <para>
        /// <para>Skips validation of Amazon SQS, Amazon SNS, and Lambda destinations</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SkipDestinationValidation { get; set; }
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
            this._AWSSignerType = "s3";
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
            context.ChecksumAlgorithm = this.ChecksumAlgorithm;
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
            context.ExpectedBucketOwner = this.ExpectedBucketOwner;
            context.SkipDestinationValidation = this.SkipDestinationValidation;
            context.EventBridgeConfiguration = this.EventBridgeConfiguration;
            
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
            if (cmdletContext.ChecksumAlgorithm != null)
            {
                request.ChecksumAlgorithm = cmdletContext.ChecksumAlgorithm;
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
            if (cmdletContext.ExpectedBucketOwner != null)
            {
                request.ExpectedBucketOwner = cmdletContext.ExpectedBucketOwner;
            }
            if (cmdletContext.SkipDestinationValidation != null)
            {
                request.SkipDestinationValidation = cmdletContext.SkipDestinationValidation.Value;
            }
            if (cmdletContext.EventBridgeConfiguration != null)
            {
                request.EventBridgeConfiguration = cmdletContext.EventBridgeConfiguration;
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
            public Amazon.S3.ChecksumAlgorithm ChecksumAlgorithm { get; set; }
            public List<Amazon.S3.Model.TopicConfiguration> TopicConfiguration { get; set; }
            public List<Amazon.S3.Model.QueueConfiguration> QueueConfiguration { get; set; }
            public List<Amazon.S3.Model.LambdaFunctionConfiguration> LambdaFunctionConfiguration { get; set; }
            public System.String ExpectedBucketOwner { get; set; }
            public System.Boolean? SkipDestinationValidation { get; set; }
            public Amazon.S3.Model.EventBridgeConfiguration EventBridgeConfiguration { get; set; }
            public System.Func<Amazon.S3.Model.PutBucketNotificationResponse, WriteS3BucketNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
