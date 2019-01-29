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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Create an event destination. In Amazon Pinpoint, <i>events</i> include message sends,
    /// deliveries, opens, clicks, bounces, and complaints. <i>Event destinations</i> are
    /// places that you can send information about these events to. For example, you can send
    /// event data to Amazon SNS to receive notifications when you receive bounces or complaints,
    /// or you can use Amazon Kinesis Data Firehose to stream data to Amazon S3 for long-term
    /// storage.
    /// 
    ///  
    /// <para>
    /// A single configuration set can include more than one event destination.
    /// </para>
    /// </summary>
    [Cmdlet("New", "PINEConfigurationSetEventDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateConfigurationSetEventDestination API operation.", Operation = new[] {"CreateConfigurationSetEventDestination"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the EventDestinationName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPINEConfigurationSetEventDestinationCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter PinpointDestination_ApplicationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Pinpoint project that you want to send
        /// email events to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_PinpointDestination_ApplicationArn")]
        public System.String PinpointDestination_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set that you want to add an event destination to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_DeliveryStreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kinesis Data Firehose stream that Amazon
        /// Pinpoint sends email events to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_KinesisFirehoseDestination_DeliveryStreamArn")]
        public System.String KinesisFirehoseDestination_DeliveryStreamArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchDestination_DimensionConfiguration
        /// <summary>
        /// <para>
        /// <para>An array of objects that define the dimensions to use when you send email events to
        /// Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_CloudWatchDestination_DimensionConfigurations")]
        public Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration[] CloudWatchDestination_DimensionConfiguration { get; set; }
        #endregion
        
        #region Parameter EventDestination_Enabled
        /// <summary>
        /// <para>
        /// <para>If <code>true</code>, the event destination is enabled. When the event destination
        /// is enabled, the specified event types are sent to the destinations in this <code>EventDestinationDefinition</code>.</para><para>If <code>false</code>, the event destination is disabled. When the event destination
        /// is disabled, events aren't sent to the specified destinations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EventDestination_Enabled { get; set; }
        #endregion
        
        #region Parameter EventDestinationName
        /// <summary>
        /// <para>
        /// <para>A name that identifies the event destination within the configuration set.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String EventDestinationName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon Pinpoint uses when sending
        /// email events to the Amazon Kinesis Data Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_KinesisFirehoseDestination_IamRoleArn")]
        public System.String KinesisFirehoseDestination_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter EventDestination_MatchingEventType
        /// <summary>
        /// <para>
        /// <para>An array that specifies which events Amazon Pinpoint should send to the destinations
        /// in this <code>EventDestinationDefinition</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_MatchingEventTypes")]
        public System.String[] EventDestination_MatchingEventType { get; set; }
        #endregion
        
        #region Parameter SnsDestination_TopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic that you want to publish email
        /// events to. For more information about Amazon SNS topics, see the <a href="http://docs.aws.amazon.com/sns/latest/dg/CreateTopic.html">Amazon
        /// SNS Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("EventDestination_SnsDestination_TopicArn")]
        public System.String SnsDestination_TopicArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the EventDestinationName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EventDestinationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEConfigurationSetEventDestination (CreateConfigurationSetEventDestination)"))
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
                context.EventDestination_CloudWatchDestination_DimensionConfigurations = new List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration>(this.CloudWatchDestination_DimensionConfiguration);
            }
            if (ParameterWasBound("EventDestination_Enabled"))
                context.EventDestination_Enabled = this.EventDestination_Enabled;
            context.EventDestination_KinesisFirehoseDestination_DeliveryStreamArn = this.KinesisFirehoseDestination_DeliveryStreamArn;
            context.EventDestination_KinesisFirehoseDestination_IamRoleArn = this.KinesisFirehoseDestination_IamRoleArn;
            if (this.EventDestination_MatchingEventType != null)
            {
                context.EventDestination_MatchingEventTypes = new List<System.String>(this.EventDestination_MatchingEventType);
            }
            context.EventDestination_PinpointDestination_ApplicationArn = this.PinpointDestination_ApplicationArn;
            context.EventDestination_SnsDestination_TopicArn = this.SnsDestination_TopicArn;
            context.EventDestinationName = this.EventDestinationName;
            
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
            var request = new Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationRequest();
            
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            
             // populate EventDestination
            bool requestEventDestinationIsNull = true;
            request.EventDestination = new Amazon.PinpointEmail.Model.EventDestinationDefinition();
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
            Amazon.PinpointEmail.Model.CloudWatchDestination requestEventDestination_eventDestination_CloudWatchDestination = null;
            
             // populate CloudWatchDestination
            bool requestEventDestination_eventDestination_CloudWatchDestinationIsNull = true;
            requestEventDestination_eventDestination_CloudWatchDestination = new Amazon.PinpointEmail.Model.CloudWatchDestination();
            List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration> requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = null;
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
            Amazon.PinpointEmail.Model.PinpointDestination requestEventDestination_eventDestination_PinpointDestination = null;
            
             // populate PinpointDestination
            bool requestEventDestination_eventDestination_PinpointDestinationIsNull = true;
            requestEventDestination_eventDestination_PinpointDestination = new Amazon.PinpointEmail.Model.PinpointDestination();
            System.String requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn = null;
            if (cmdletContext.EventDestination_PinpointDestination_ApplicationArn != null)
            {
                requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn = cmdletContext.EventDestination_PinpointDestination_ApplicationArn;
            }
            if (requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn != null)
            {
                requestEventDestination_eventDestination_PinpointDestination.ApplicationArn = requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn;
                requestEventDestination_eventDestination_PinpointDestinationIsNull = false;
            }
             // determine if requestEventDestination_eventDestination_PinpointDestination should be set to null
            if (requestEventDestination_eventDestination_PinpointDestinationIsNull)
            {
                requestEventDestination_eventDestination_PinpointDestination = null;
            }
            if (requestEventDestination_eventDestination_PinpointDestination != null)
            {
                request.EventDestination.PinpointDestination = requestEventDestination_eventDestination_PinpointDestination;
                requestEventDestinationIsNull = false;
            }
            Amazon.PinpointEmail.Model.SnsDestination requestEventDestination_eventDestination_SnsDestination = null;
            
             // populate SnsDestination
            bool requestEventDestination_eventDestination_SnsDestinationIsNull = true;
            requestEventDestination_eventDestination_SnsDestination = new Amazon.PinpointEmail.Model.SnsDestination();
            System.String requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn = null;
            if (cmdletContext.EventDestination_SnsDestination_TopicArn != null)
            {
                requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn = cmdletContext.EventDestination_SnsDestination_TopicArn;
            }
            if (requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn != null)
            {
                requestEventDestination_eventDestination_SnsDestination.TopicArn = requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn;
                requestEventDestination_eventDestination_SnsDestinationIsNull = false;
            }
             // determine if requestEventDestination_eventDestination_SnsDestination should be set to null
            if (requestEventDestination_eventDestination_SnsDestinationIsNull)
            {
                requestEventDestination_eventDestination_SnsDestination = null;
            }
            if (requestEventDestination_eventDestination_SnsDestination != null)
            {
                request.EventDestination.SnsDestination = requestEventDestination_eventDestination_SnsDestination;
                requestEventDestinationIsNull = false;
            }
            Amazon.PinpointEmail.Model.KinesisFirehoseDestination requestEventDestination_eventDestination_KinesisFirehoseDestination = null;
            
             // populate KinesisFirehoseDestination
            bool requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = true;
            requestEventDestination_eventDestination_KinesisFirehoseDestination = new Amazon.PinpointEmail.Model.KinesisFirehoseDestination();
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = null;
            if (cmdletContext.EventDestination_KinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = cmdletContext.EventDestination_KinesisFirehoseDestination_DeliveryStreamArn;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.DeliveryStreamArn = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn;
                requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = false;
            }
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = null;
            if (cmdletContext.EventDestination_KinesisFirehoseDestination_IamRoleArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = cmdletContext.EventDestination_KinesisFirehoseDestination_IamRoleArn;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.IamRoleArn = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn;
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
            if (cmdletContext.EventDestinationName != null)
            {
                request.EventDestinationName = cmdletContext.EventDestinationName;
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
                    pipelineOutput = this.EventDestinationName;
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
        
        private Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "CreateConfigurationSetEventDestination");
            try
            {
                #if DESKTOP
                return client.CreateConfigurationSetEventDestination(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateConfigurationSetEventDestinationAsync(request);
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
            public List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration> EventDestination_CloudWatchDestination_DimensionConfigurations { get; set; }
            public System.Boolean? EventDestination_Enabled { get; set; }
            public System.String EventDestination_KinesisFirehoseDestination_DeliveryStreamArn { get; set; }
            public System.String EventDestination_KinesisFirehoseDestination_IamRoleArn { get; set; }
            public List<System.String> EventDestination_MatchingEventTypes { get; set; }
            public System.String EventDestination_PinpointDestination_ApplicationArn { get; set; }
            public System.String EventDestination_SnsDestination_TopicArn { get; set; }
            public System.String EventDestinationName { get; set; }
        }
        
    }
}
