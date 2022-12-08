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
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email CreateConfigurationSetEventDestination API operation.", Operation = new[] {"CreateConfigurationSetEventDestination"}, SelectReturnType = typeof(Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse))]
    [AWSCmdletOutput("None or Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse",
        "This cmdlet does not generate any output." +
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_PinpointDestination_ApplicationArn")]
        public System.String PinpointDestination_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration set that you want to add an event destination to.</para>
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
        public System.String ConfigurationSetName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_DeliveryStreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kinesis Data Firehose stream that Amazon
        /// Pinpoint sends email events to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EventDestination_Enabled { get; set; }
        #endregion
        
        #region Parameter EventDestinationName
        /// <summary>
        /// <para>
        /// <para>A name that identifies the event destination within the configuration set.</para>
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
        public System.String EventDestinationName { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that Amazon Pinpoint uses when sending
        /// email events to the Amazon Kinesis Data Firehose stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_MatchingEventTypes")]
        public System.String[] EventDestination_MatchingEventType { get; set; }
        #endregion
        
        #region Parameter SnsDestination_TopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic that you want to publish email
        /// events to. For more information about Amazon SNS topics, see the <a href="https://docs.aws.amazon.com/sns/latest/dg/CreateTopic.html">Amazon
        /// SNS Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventDestination_SnsDestination_TopicArn")]
        public System.String SnsDestination_TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventDestinationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventDestinationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventDestinationName' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventDestinationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEConfigurationSetEventDestination (CreateConfigurationSetEventDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse, NewPINEConfigurationSetEventDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventDestinationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CloudWatchDestination_DimensionConfiguration != null)
            {
                context.CloudWatchDestination_DimensionConfiguration = new List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration>(this.CloudWatchDestination_DimensionConfiguration);
            }
            context.EventDestination_Enabled = this.EventDestination_Enabled;
            context.KinesisFirehoseDestination_DeliveryStreamArn = this.KinesisFirehoseDestination_DeliveryStreamArn;
            context.KinesisFirehoseDestination_IamRoleArn = this.KinesisFirehoseDestination_IamRoleArn;
            if (this.EventDestination_MatchingEventType != null)
            {
                context.EventDestination_MatchingEventType = new List<System.String>(this.EventDestination_MatchingEventType);
            }
            context.PinpointDestination_ApplicationArn = this.PinpointDestination_ApplicationArn;
            context.SnsDestination_TopicArn = this.SnsDestination_TopicArn;
            context.EventDestinationName = this.EventDestinationName;
            #if MODULAR
            if (this.EventDestinationName == null && ParameterWasBound(nameof(this.EventDestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var requestEventDestinationIsNull = true;
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
            if (cmdletContext.EventDestination_MatchingEventType != null)
            {
                requestEventDestination_eventDestination_MatchingEventType = cmdletContext.EventDestination_MatchingEventType;
            }
            if (requestEventDestination_eventDestination_MatchingEventType != null)
            {
                request.EventDestination.MatchingEventTypes = requestEventDestination_eventDestination_MatchingEventType;
                requestEventDestinationIsNull = false;
            }
            Amazon.PinpointEmail.Model.CloudWatchDestination requestEventDestination_eventDestination_CloudWatchDestination = null;
            
             // populate CloudWatchDestination
            var requestEventDestination_eventDestination_CloudWatchDestinationIsNull = true;
            requestEventDestination_eventDestination_CloudWatchDestination = new Amazon.PinpointEmail.Model.CloudWatchDestination();
            List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration> requestEventDestination_eventDestination_CloudWatchDestination_cloudWatchDestination_DimensionConfiguration = null;
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
            Amazon.PinpointEmail.Model.PinpointDestination requestEventDestination_eventDestination_PinpointDestination = null;
            
             // populate PinpointDestination
            var requestEventDestination_eventDestination_PinpointDestinationIsNull = true;
            requestEventDestination_eventDestination_PinpointDestination = new Amazon.PinpointEmail.Model.PinpointDestination();
            System.String requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn = null;
            if (cmdletContext.PinpointDestination_ApplicationArn != null)
            {
                requestEventDestination_eventDestination_PinpointDestination_pinpointDestination_ApplicationArn = cmdletContext.PinpointDestination_ApplicationArn;
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
            var requestEventDestination_eventDestination_SnsDestinationIsNull = true;
            requestEventDestination_eventDestination_SnsDestination = new Amazon.PinpointEmail.Model.SnsDestination();
            System.String requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn = null;
            if (cmdletContext.SnsDestination_TopicArn != null)
            {
                requestEventDestination_eventDestination_SnsDestination_snsDestination_TopicArn = cmdletContext.SnsDestination_TopicArn;
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
            var requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = true;
            requestEventDestination_eventDestination_KinesisFirehoseDestination = new Amazon.PinpointEmail.Model.KinesisFirehoseDestination();
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = null;
            if (cmdletContext.KinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = cmdletContext.KinesisFirehoseDestination_DeliveryStreamArn;
            }
            if (requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination.DeliveryStreamArn = requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn;
                requestEventDestination_eventDestination_KinesisFirehoseDestinationIsNull = false;
            }
            System.String requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = null;
            if (cmdletContext.KinesisFirehoseDestination_IamRoleArn != null)
            {
                requestEventDestination_eventDestination_KinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = cmdletContext.KinesisFirehoseDestination_IamRoleArn;
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
        
        private Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "CreateConfigurationSetEventDestination");
            try
            {
                #if DESKTOP
                return client.CreateConfigurationSetEventDestination(request);
                #elif CORECLR
                return client.CreateConfigurationSetEventDestinationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.PinpointEmail.Model.CloudWatchDimensionConfiguration> CloudWatchDestination_DimensionConfiguration { get; set; }
            public System.Boolean? EventDestination_Enabled { get; set; }
            public System.String KinesisFirehoseDestination_DeliveryStreamArn { get; set; }
            public System.String KinesisFirehoseDestination_IamRoleArn { get; set; }
            public List<System.String> EventDestination_MatchingEventType { get; set; }
            public System.String PinpointDestination_ApplicationArn { get; set; }
            public System.String SnsDestination_TopicArn { get; set; }
            public System.String EventDestinationName { get; set; }
            public System.Func<Amazon.PinpointEmail.Model.CreateConfigurationSetEventDestinationResponse, NewPINEConfigurationSetEventDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
