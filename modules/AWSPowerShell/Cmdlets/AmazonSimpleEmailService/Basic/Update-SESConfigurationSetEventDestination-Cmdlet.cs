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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Updates the event destination of a configuration set. Event destinations are associated
    /// with configuration sets, which enable you to publish email sending events to Amazon
    /// CloudWatch, Amazon Kinesis Firehose, or Amazon Simple Notification Service (Amazon
    /// SNS). For information about using configuration sets, see <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/monitor-sending-activity.html">Monitoring
    /// Your Amazon SES Sending Activity</a> in the <i>Amazon SES Developer Guide.</i><note><para>
    /// When you create or update an event destination, you must provide one, and only one,
    /// destination. The destination can be Amazon CloudWatch, Amazon Kinesis Firehose, or
    /// Amazon Simple Notification Service (Amazon SNS).
    /// </para></note><para>
    /// You can execute this operation no more than once per second.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SESConfigurationSetEventDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service UpdateConfigurationSetEventDestination API operation.", Operation = new[] {"UpdateConfigurationSetEventDestination"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ConfigurationSetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSESConfigurationSetEventDestinationCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set that contains the event destination that you want
        /// to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_DeliveryStreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Kinesis Firehose stream that email sending events should be
        /// published to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_CloudWatchDestination_DimensionConfigurations")]
        public Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration[] CloudWatchDestination_DimensionConfiguration { get; set; }
        #endregion
        
        #region Parameter EventDestination_Enabled
        /// <summary>
        /// <para>
        /// <para>Sets whether Amazon SES publishes events to this destination when you send an email
        /// with the associated configuration set. Set to <code>true</code> to enable publishing
        /// to this destination; set to <code>false</code> to prevent publishing to this destination.
        /// The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EventDestination_Enabled { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_IAMRoleARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role under which Amazon SES publishes email sending events to the
        /// Amazon Kinesis Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_KinesisFirehoseDestination_IAMRoleARN")]
        public System.String KinesisFirehoseDestination_IAMRoleARN { get; set; }
        #endregion
        
        #region Parameter EventDestination_MatchingEventType
        /// <summary>
        /// <para>
        /// <para>The type of email sending events to publish to the event destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_MatchingEventTypes")]
        public System.String[] EventDestination_MatchingEventType { get; set; }
        #endregion
        
        #region Parameter EventDestination_Name
        /// <summary>
        /// <para>
        /// <para>The name of the event destination. The name must:</para><ul><li><para>Contain only ASCII letters (a-z, A-Z), numbers (0-9), underscores (_), or dashes (-).</para></li><li><para>Contain less than 64 characters.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EventDestination_Name { get; set; }
        #endregion
        
        #region Parameter SNSDestination_TopicARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon SNS topic that email sending events will be published to. An
        /// example of an Amazon SNS topic ARN is <code>arn:aws:sns:us-west-2:123456789012:MyTopic</code>.
        /// For more information about Amazon SNS topics, see the <a href="http://docs.aws.amazon.com/sns/latest/dg/CreateTopic.html">Amazon
        /// SNS Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_SNSDestination_TopicARN")]
        public System.String SNSDestination_TopicARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ConfigurationSetName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ConfigurationSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SESConfigurationSetEventDestination (UpdateConfigurationSetEventDestination)"))
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
            
            context.ConfigurationSetName = this.ConfigurationSetName;
            if (this.CloudWatchDestination_DimensionConfiguration != null)
            {
                context.EventDestination_CloudWatchDestination_DimensionConfigurations = new List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration>(this.CloudWatchDestination_DimensionConfiguration);
            }
            if (ParameterWasBound("EventDestination_Enabled"))
                context.EventDestination_Enabled = this.EventDestination_Enabled;
            context.EventDestination_KinesisFirehoseDestination_DeliveryStreamARN = this.KinesisFirehoseDestination_DeliveryStreamARN;
            context.EventDestination_KinesisFirehoseDestination_IAMRoleARN = this.KinesisFirehoseDestination_IAMRoleARN;
            if (this.EventDestination_MatchingEventType != null)
            {
                context.EventDestination_MatchingEventTypes = new List<System.String>(this.EventDestination_MatchingEventType);
            }
            context.EventDestination_Name = this.EventDestination_Name;
            context.EventDestination_SNSDestination_TopicARN = this.SNSDestination_TopicARN;
            
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
            bool requestEventDestinationIsNull = true;
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
            if (cmdletContext.EventDestination_MatchingEventTypes != null)
            {
                requestEventDestination_eventDestination_MatchingEventType = cmdletContext.EventDestination_MatchingEventTypes;
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
            bool requestEventDestination_eventDestination_CloudWatchDestinationIsNull = true;
            requestEventDestination_eventDestination_CloudWatchDestination = new Amazon.SimpleEmail.Model.CloudWatchDestination();
            List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration> requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = null;
            if (cmdletContext.EventDestination_CloudWatchDestination_DimensionConfigurations != null)
            {
                requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = cmdletContext.EventDestination_CloudWatchDestination_DimensionConfigurations;
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
            bool requestEventDestination_eventDestination_SNSDestinationIsNull = true;
            requestEventDestination_eventDestination_SNSDestination = new Amazon.SimpleEmail.Model.SNSDestination();
            System.String requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN = null;
            if (cmdletContext.EventDestination_SNSDestination_TopicARN != null)
            {
                requestEventDestination_eventDestination_SNSDestination_sNSDestination_TopicARN = cmdletContext.EventDestination_SNSDestination_TopicARN;
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
            bool requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = true;
            requestEventDestination_eventDestination_KinesisFirehoseDestination = new Amazon.SimpleEmail.Model.KinesisFirehoseDestination();
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN = null;
            if (cmdletContext.EventDestination_KinesisFirehoseDestination_DeliveryStreamARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN = cmdletContext.EventDestination_KinesisFirehoseDestination_DeliveryStreamARN;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.DeliveryStreamARN = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamARN;
                requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = false;
            }
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN = null;
            if (cmdletContext.EventDestination_KinesisFirehoseDestination_IAMRoleARN != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IAMRoleARN = cmdletContext.EventDestination_KinesisFirehoseDestination_IAMRoleARN;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.ConfigurationSetName;
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
        
        private Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.UpdateConfigurationSetEventDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "UpdateConfigurationSetEventDestination");
            try
            {
                #if DESKTOP
                return client.UpdateConfigurationSetEventDestination(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateConfigurationSetEventDestinationAsync(request);
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
            public System.String ConfigurationSetName { get; set; }
            public List<Amazon.SimpleEmail.Model.CloudWatchDimensionConfiguration> EventDestination_CloudWatchDestination_DimensionConfigurations { get; set; }
            public System.Boolean? EventDestination_Enabled { get; set; }
            public System.String EventDestination_KinesisFirehoseDestination_DeliveryStreamARN { get; set; }
            public System.String EventDestination_KinesisFirehoseDestination_IAMRoleARN { get; set; }
            public List<System.String> EventDestination_MatchingEventTypes { get; set; }
            public System.String EventDestination_Name { get; set; }
            public System.String EventDestination_SNSDestination_TopicARN { get; set; }
        }
        
    }
}
