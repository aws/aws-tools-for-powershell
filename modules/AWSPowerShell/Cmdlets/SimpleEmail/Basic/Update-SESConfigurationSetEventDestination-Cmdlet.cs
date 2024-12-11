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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Updates the event destination of a configuration set. Event destinations are associated
    /// with configuration sets, which enable you to publish email sending events to Amazon
    /// CloudWatch, Amazon Kinesis Firehose, or Amazon Simple Notification Service (Amazon
    /// SNS). For information about using configuration sets, see <a href="https://docs.aws.amazon.com/ses/latest/dg/monitor-sending-activity.html">Monitoring
    /// Your Amazon SES Sending Activity</a> in the <i>Amazon SES Developer Guide.</i><note><para>
    /// When you create or update an event destination, you must provide one, and only one,
    /// destination. The destination can be Amazon CloudWatch, Amazon Kinesis Firehose, or
    /// Amazon Simple Notification Service (Amazon SNS).
    /// </para></note><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SESConfigurationSetEventDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Simple Email Service (SES) UpdateConfigurationSetEventDestination API operation.", Operation = new[] {"UpdateConfigurationSetEventDestination"}, SelectReturnType = typeof(Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSESConfigurationSetEventDestinationCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set that contains the event destination.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_DeliveryStreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Kinesis Firehose stream that email sending events should be
        /// published to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_KinesisFirehoseDestination_DeliveryStreamARN")]
        public System.String KinesisFirehoseDestination_DeliveryStreamARN { get; set; }
        #endregion
        
        #region Parameter CloudWatchDestination_DimensionConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of dimensions upon which to categorize your emails when you publish email sending
        /// events to Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_CloudWatchDestination_DimensionConfigurations")]
        public Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration[] CloudWatchDestination_DimensionConfiguration { get; set; }
        #endregion
        
        #region Parameter EventDestination_Enabled
        /// <summary>
        /// <para>
        /// <para>Sets whether Amazon SES publishes events to this destination when you send an email
        /// with the associated configuration set. Set to <c>true</c> to enable publishing to
        /// this destination; set to <c>false</c> to prevent publishing to this destination. The
        /// default value is <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EventDestination_Enabled { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_IAMRoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role under which Amazon SES publishes email sending events to the
        /// Amazon Kinesis Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_KinesisFirehoseDestination_IAMRoleARN")]
        public System.String KinesisFirehoseDestination_IAMRoleARN { get; set; }
        #endregion
        
        #region Parameter EventDestination_MatchingEventType
        /// <summary>
        /// <para>
        /// <para>The type of email sending events to publish to the event destination.</para><ul><li><para><c>send</c> - The call was successful and Amazon SES is attempting to deliver the
        /// email.</para></li><li><para><c>reject</c> - Amazon SES determined that the email contained a virus and rejected
        /// it.</para></li><li><para><c>bounce</c> - The recipient's mail server permanently rejected the email. This
        /// corresponds to a hard bounce.</para></li><li><para><c>complaint</c> - The recipient marked the email as spam.</para></li><li><para><c>delivery</c> - Amazon SES successfully delivered the email to the recipient's
        /// mail server.</para></li><li><para><c>open</c> - The recipient received the email and opened it in their email client.</para></li><li><para><c>click</c> - The recipient clicked one or more links in the email.</para></li><li><para><c>renderingFailure</c> - Amazon SES did not send the email because of a template
        /// rendering issue.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("EventDestination_MatchingEventTypes")]
        public System.String[] EventDestination_MatchingEventType { get; set; }
        #endregion
        
        #region Parameter EventDestination_Name
        /// <summary>
        /// <para>
        /// <para>The name of the event destination. The name must meet the following requirements:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), underscores (_), or dashes (-).</para></li><li><para>Contain 64 characters or fewer.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EventDestination_Name { get; set; }
        #endregion
        
        #region Parameter SNSDestination_TopicARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon SNS topic for email sending events. You can find the ARN of
        /// a topic by using the <a href="https://docs.aws.amazon.com/sns/latest/api/API_ListTopics.html">ListTopics</a>
        /// Amazon SNS operation.</para><para>For more information about Amazon SNS topics, see the <a href="https://docs.aws.amazon.com/sns/latest/dg/CreateTopic.html">Amazon
        /// SNS Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_SNSDestination_TopicARN")]
        public System.String SNSDestination_TopicARN { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SESConfigurationSetEventDestination (UpdateConfigurationSetEventDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse, UpdateSESConfigurationSetEventDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudWatchDestination_DimensionConfiguration != null)
            {
                context.CloudWatchDestination_DimensionConfiguration = new List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration>(this.CloudWatchDestination_DimensionConfiguration);
            }
            context.EventDestination_Enabled = this.EventDestination_Enabled;
            context.KinesisFirehoseDestination_DeliveryStreamARN = this.KinesisFirehoseDestination_DeliveryStreamARN;
            context.KinesisFirehoseDestination_IAMRoleARN = this.KinesisFirehoseDestination_IAMRoleARN;
            if (this.EventDestination_MatchingEventType != null)
            {
                context.EventDestination_MatchingEventType = new List<System.String>(this.EventDestination_MatchingEventType);
            }
            #if MODULAR
            if (this.EventDestination_MatchingEventType == null && ParameterWasBound(nameof(this.EventDestination_MatchingEventType)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDestination_MatchingEventType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventDestination_Name = this.EventDestination_Name;
            #if MODULAR
            if (this.EventDestination_Name == null && ParameterWasBound(nameof(this.EventDestination_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDestination_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SNSDestination_TopicARN = this.SNSDestination_TopicARN;
            
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
            var request = new Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate EventDestination
            var requestEventDestinationIsNull = true;
            request.EventDestination = new Amazon.SimpleEmail.Model.EventDestination();
            System.Boolean? requestEventDestination_eventDestination_Enabled = null;
            if (cmdletContext.EventDestination_Enabled != null)
            {
                requestEventDestination_eventDestination_Enabled = cmdletContext.EventDestination_Enabled.Value;
            }
            if (requestEventDestination_eventDestination_Enabled != null)
            {
                request.EventDestination.Enabled = requestEventDestination_eventDestination_Enabled.Value;
                requestEventDestinationIsNull = false;
            }
            List<System.String> requestEventDestination_eventDestination_MatchingEventType = null;
            if (cmdletContext.EventDestination_MatchingEventType != null)
            {
                requestEventDestination_eventDestination_MatchingEventType = cmdletContext.EventDestination_MatchingEventType;
            }
            if (requestEventDestination_eventDestination_MatchingEventType != null)
            {
                request.EventDestination.MatchingEventTypes = requestEventDestination_eventDestination_MatchingEventType;
                requestEventDestinationIsNull = false;
            }
            System.String requestEventDestination_eventDestination_Name = null;
            if (cmdletContext.EventDestination_Name != null)
            {
                requestEventDestination_eventDestination_Name = cmdletContext.EventDestination_Name;
            }
            if (requestEventDestination_eventDestination_Name != null)
            {
                request.EventDestination.Name = requestEventDestination_eventDestination_Name;
                requestEventDestinationIsNull = false;
            }
            Amazon.SimpleEmail.Model.CloudWatchDestination requestEventDestination_eventDestination_CloudWatchDestination = null;
            
             // populate CloudWatchDestination
            var requestEventDestination_eventDestination_CloudWatchDestinationIsNull = true;
            requestEventDestination_eventDestination_CloudWatchDestination = new Amazon.SimpleEmail.Model.CloudWatchDestination();
            List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration> requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = null;
            if (cmdletContext.CloudWatchDestination_DimensionConfiguration != null)
            {
                requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = cmdletContext.CloudWatchDestination_DimensionConfiguration;
            }
            if (requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration != null)
            {
                requestEventDestination_eventDestination_CloudWatchDestination.DimensionConfigurations = requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration;
                requestEventDestination_eventDestination_CloudWatchDestinationIsNull = false;
            }
             // determine if requestEventDestination_eventDestination_CloudWatchDestination should be set to null
            if (requestEventDestination_eventDestination_CloudWatchDestinationIsNull)
            {
                requestEventDestination_eventDestination_CloudWatchDestination = null;
            }
            if (requestEventDestination_eventDestination_CloudWatchDestination != null)
            {
                request.EventDestination.CloudWatchDestination = requestEventDestination_eventDestination_CloudWatchDestination;
                requestEventDestinationIsNull = false;
            }
            Amazon.SimpleEmail.Model.SNSDestination requestEventDestination_eventDestination_SNSDestination = null;
            
             // populate SNSDestination
            var requestEventDestination_eventDestination_SNSDestinationIsNull = true;
            requestEventDestination_eventDestination_SNSDestination = new Amazon.SimpleEmail.Model.SNSDestination();
            System.String requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN = null;
            if (cmdletContext.SNSDestination_TopicARN != null)
            {
                requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN = cmdletContext.SNSDestination_TopicARN;
            }
            if (requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN != null)
            {
                requestEventDestination_eventDestination_SNSDestination.TopicARN = requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN;
                requestEventDestination_eventDestination_SNSDestinationIsNull = false;
            }
             // determine if requestEventDestination_eventDestination_SNSDestination should be set to null
            if (requestEventDestination_eventDestination_SNSDestinationIsNull)
            {
                requestEventDestination_eventDestination_SNSDestination = null;
            }
            if (requestEventDestination_eventDestination_SNSDestination != null)
            {
                request.EventDestination.SNSDestination = requestEventDestination_eventDestination_SNSDestination;
                requestEventDestinationIsNull = false;
            }
            Amazon.SimpleEmail.Model.KinesisFirehoseDestination requestEventDestination_eventDestination_KinesisFirehoseDestination = null;
            
             // populate KinesisFirehoseDestination
            var requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = true;
            requestEventDestination_eventDestination_KinesisFirehoseDestination = new Amazon.SimpleEmail.Model.KinesisFirehoseDestination();
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN = null;
            if (cmdletContext.KinesisFirehoseDestination_DeliveryStreamARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN = cmdletContext.KinesisFirehoseDestination_DeliveryStreamARN;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.DeliveryStreamARN = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN;
                requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = false;
            }
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN = null;
            if (cmdletContext.KinesisFirehoseDestination_IAMRoleARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN = cmdletContext.KinesisFirehoseDestination_IAMRoleARN;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.IAMRoleARN = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN;
                requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = false;
            }
             // determine if requestEventDestination_eventDestination_KinesisFirehoseDestination should be set to null
            if (requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination = null;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination != null)
            {
                request.EventDestination.KinesisFirehoseDestination = requestEventDestination_eventDestination_KinesisFirehoseDestination;
                requestEventDestinationIsNull = false;
            }
             // determine if request.EventDestination should be set to null
            if (requestEventDestinationIsNull)
            {
                request.EventDestination = null;
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
        
        private Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service (SES)", "UpdateConfigurationSetEventDestination");
            try
            {
                #if DESKTOP
                return client.UpdateConfigurationSetEventDestination(request);
                #elif CORECLR
                return client.UpdateConfigurationSetEventDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationSetName { get; set; }
            public List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration> CloudWatchDestination_DimensionConfiguration { get; set; }
            public System.Boolean? EventDestination_Enabled { get; set; }
            public System.String KinesisFirehoseDestination_DeliveryStreamARN { get; set; }
            public System.String KinesisFirehoseDestination_IAMRoleARN { get; set; }
            public List<System.String> EventDestination_MatchingEventType { get; set; }
            public System.String EventDestination_Name { get; set; }
            public System.String SNSDestination_TopicARN { get; set; }
            public System.Func<Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse, UpdateSESConfigurationSetEventDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
