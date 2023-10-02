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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Updates an existing event destination in a configuration set. You can update the IAM
    /// role ARN for CloudWatch Logs and Kinesis Data Firehose. You can also enable or disable
    /// the event destination.
    /// 
    ///  
    /// <para>
    /// You may want to update an event destination to change its matching event types or
    /// updating the destination resource ARN. You can't change an event destination's type
    /// between CloudWatch Logs, Kinesis Data Firehose, and Amazon SNS.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SMSVEventDestination", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 UpdateEventDestination API operation.", Operation = new[] {"UpdateEventDestination"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSMSVEventDestinationCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigurationSetName
        /// <summary>
        /// <para>
        /// <para>The configuration set to update with the new event destination. Valid values for this
        /// can be the ConfigurationSetName or ConfigurationSetArn.</para>
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
        
        #region Parameter KinesisFirehoseDestination_DeliveryStreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the delivery stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisFirehoseDestination_DeliveryStreamArn { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>When set to true logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EventDestinationName
        /// <summary>
        /// <para>
        /// <para>The name to use for the event destination.</para>
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
        public System.String EventDestinationName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsDestination_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an Amazon Identity and Access Management (IAM) role
        /// that is able to write event data to an Amazon CloudWatch destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogsDestination_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter KinesisFirehoseDestination_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an Amazon Identity and Access Management (IAM) role that is able to write
        /// event data to an Amazon Firehose destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisFirehoseDestination_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogsDestination_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon CloudWatch log group that you want to record events in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogsDestination_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter MatchingEventType
        /// <summary>
        /// <para>
        /// <para>An array of event types that determine which events to log.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MatchingEventTypes")]
        public System.String[] MatchingEventType { get; set; }
        #endregion
        
        #region Parameter SnsDestination_TopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic that you want to publish events
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SnsDestination_TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationSetName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationSetName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationSetName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSVEventDestination (UpdateEventDestination)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse, UpdateSMSVEventDestinationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationSetName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogsDestination_IamRoleArn = this.CloudWatchLogsDestination_IamRoleArn;
            context.CloudWatchLogsDestination_LogGroupArn = this.CloudWatchLogsDestination_LogGroupArn;
            context.ConfigurationSetName = this.ConfigurationSetName;
            #if MODULAR
            if (this.ConfigurationSetName == null && ParameterWasBound(nameof(this.ConfigurationSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enabled = this.Enabled;
            context.EventDestinationName = this.EventDestinationName;
            #if MODULAR
            if (this.EventDestinationName == null && ParameterWasBound(nameof(this.EventDestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter EventDestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KinesisFirehoseDestination_DeliveryStreamArn = this.KinesisFirehoseDestination_DeliveryStreamArn;
            context.KinesisFirehoseDestination_IamRoleArn = this.KinesisFirehoseDestination_IamRoleArn;
            if (this.MatchingEventType != null)
            {
                context.MatchingEventType = new List<System.String>(this.MatchingEventType);
            }
            context.SnsDestination_TopicArn = this.SnsDestination_TopicArn;
            
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationRequest();
            
            
             // populate CloudWatchLogsDestination
            var requestCloudWatchLogsDestinationIsNull = true;
            request.CloudWatchLogsDestination = new Amazon.PinpointSMSVoiceV2.Model.CloudWatchLogsDestination();
            System.String requestCloudWatchLogsDestination_cloudWatchLogsDestination_IamRoleArn = null;
            if (cmdletContext.CloudWatchLogsDestination_IamRoleArn != null)
            {
                requestCloudWatchLogsDestination_cloudWatchLogsDestination_IamRoleArn = cmdletContext.CloudWatchLogsDestination_IamRoleArn;
            }
            if (requestCloudWatchLogsDestination_cloudWatchLogsDestination_IamRoleArn != null)
            {
                request.CloudWatchLogsDestination.IamRoleArn = requestCloudWatchLogsDestination_cloudWatchLogsDestination_IamRoleArn;
                requestCloudWatchLogsDestinationIsNull = false;
            }
            System.String requestCloudWatchLogsDestination_cloudWatchLogsDestination_LogGroupArn = null;
            if (cmdletContext.CloudWatchLogsDestination_LogGroupArn != null)
            {
                requestCloudWatchLogsDestination_cloudWatchLogsDestination_LogGroupArn = cmdletContext.CloudWatchLogsDestination_LogGroupArn;
            }
            if (requestCloudWatchLogsDestination_cloudWatchLogsDestination_LogGroupArn != null)
            {
                request.CloudWatchLogsDestination.LogGroupArn = requestCloudWatchLogsDestination_cloudWatchLogsDestination_LogGroupArn;
                requestCloudWatchLogsDestinationIsNull = false;
            }
             // determine if request.CloudWatchLogsDestination should be set to null
            if (requestCloudWatchLogsDestinationIsNull)
            {
                request.CloudWatchLogsDestination = null;
            }
            if (cmdletContext.ConfigurationSetName != null)
            {
                request.ConfigurationSetName = cmdletContext.ConfigurationSetName;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EventDestinationName != null)
            {
                request.EventDestinationName = cmdletContext.EventDestinationName;
            }
            
             // populate KinesisFirehoseDestination
            var requestKinesisFirehoseDestinationIsNull = true;
            request.KinesisFirehoseDestination = new Amazon.PinpointSMSVoiceV2.Model.KinesisFirehoseDestination();
            System.String requestKinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = null;
            if (cmdletContext.KinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                requestKinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn = cmdletContext.KinesisFirehoseDestination_DeliveryStreamArn;
            }
            if (requestKinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn != null)
            {
                request.KinesisFirehoseDestination.DeliveryStreamArn = requestKinesisFirehoseDestination_kinesisFirehoseDestination_DeliveryStreamArn;
                requestKinesisFirehoseDestinationIsNull = false;
            }
            System.String requestKinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = null;
            if (cmdletContext.KinesisFirehoseDestination_IamRoleArn != null)
            {
                requestKinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn = cmdletContext.KinesisFirehoseDestination_IamRoleArn;
            }
            if (requestKinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn != null)
            {
                request.KinesisFirehoseDestination.IamRoleArn = requestKinesisFirehoseDestination_kinesisFirehoseDestination_IamRoleArn;
                requestKinesisFirehoseDestinationIsNull = false;
            }
             // determine if request.KinesisFirehoseDestination should be set to null
            if (requestKinesisFirehoseDestinationIsNull)
            {
                request.KinesisFirehoseDestination = null;
            }
            if (cmdletContext.MatchingEventType != null)
            {
                request.MatchingEventTypes = cmdletContext.MatchingEventType;
            }
            
             // populate SnsDestination
            var requestSnsDestinationIsNull = true;
            request.SnsDestination = new Amazon.PinpointSMSVoiceV2.Model.SnsDestination();
            System.String requestSnsDestination_snsDestination_TopicArn = null;
            if (cmdletContext.SnsDestination_TopicArn != null)
            {
                requestSnsDestination_snsDestination_TopicArn = cmdletContext.SnsDestination_TopicArn;
            }
            if (requestSnsDestination_snsDestination_TopicArn != null)
            {
                request.SnsDestination.TopicArn = requestSnsDestination_snsDestination_TopicArn;
                requestSnsDestinationIsNull = false;
            }
             // determine if request.SnsDestination should be set to null
            if (requestSnsDestinationIsNull)
            {
                request.SnsDestination = null;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "UpdateEventDestination");
            try
            {
                #if DESKTOP
                return client.UpdateEventDestination(request);
                #elif CORECLR
                return client.UpdateEventDestinationAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogsDestination_IamRoleArn { get; set; }
            public System.String CloudWatchLogsDestination_LogGroupArn { get; set; }
            public System.String ConfigurationSetName { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String EventDestinationName { get; set; }
            public System.String KinesisFirehoseDestination_DeliveryStreamArn { get; set; }
            public System.String KinesisFirehoseDestination_IamRoleArn { get; set; }
            public List<System.String> MatchingEventType { get; set; }
            public System.String SnsDestination_TopicArn { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.UpdateEventDestinationResponse, UpdateSMSVEventDestinationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
