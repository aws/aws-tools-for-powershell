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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Used to update the settings for an app.
    /// </summary>
    [Cmdlet("Update", "PINApplicationSettingList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ApplicationSettingsResource")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApplicationSettings API operation.", Operation = new[] {"UpdateApplicationSettings"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ApplicationSettingsResource",
        "This cmdlet returns a ApplicationSettingsResource object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApplicationSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApplicationSettingListCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// The unique ID of your Amazon Pinpoint application.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter WriteApplicationSettingsRequest_CloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// The CloudWatchMetrics settings
        /// for the app.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean WriteApplicationSettingsRequest_CloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter Limits_Daily
        /// <summary>
        /// <para>
        /// The maximum number of messages that each campaign
        /// can send to a single endpoint in a 24-hour period.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_Daily")]
        public System.Int32 Limits_Daily { get; set; }
        #endregion
        
        #region Parameter QuietTime_End
        /// <summary>
        /// <para>
        /// The time at which quiet time should end. The value
        /// that you specify has to be in HH:mm format, where HH is the hour in 24-hour format
        /// (with a leading zero, if applicable), and mm is the minutes. For example, use 02:30
        /// to represent 2:30 AM, or 14:30 to represent 2:30 PM.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_QuietTime_End")]
        public System.String QuietTime_End { get; set; }
        #endregion
        
        #region Parameter CampaignHook_LambdaFunctionName
        /// <summary>
        /// <para>
        /// Lambda function name or arn to be called
        /// for delivery
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_CampaignHook_LambdaFunctionName")]
        public System.String CampaignHook_LambdaFunctionName { get; set; }
        #endregion
        
        #region Parameter Limits_MaximumDuration
        /// <summary>
        /// <para>
        /// The length of time (in seconds) that the
        /// campaign can run before it ends and message deliveries stop. This duration begins
        /// at the scheduled start time for the campaign. The minimum value is 60.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_MaximumDuration")]
        public System.Int32 Limits_MaximumDuration { get; set; }
        #endregion
        
        #region Parameter Limits_MessagesPerSecond
        /// <summary>
        /// <para>
        /// The number of messages that the campaign
        /// can send per second. The minimum value is 50, and the maximum is 20000.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_MessagesPerSecond")]
        public System.Int32 Limits_MessagesPerSecond { get; set; }
        #endregion
        
        #region Parameter CampaignHook_Mode
        /// <summary>
        /// <para>
        /// What mode Lambda should be invoked in.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_CampaignHook_Mode")]
        [AWSConstantClassSource("Amazon.Pinpoint.Mode")]
        public Amazon.Pinpoint.Mode CampaignHook_Mode { get; set; }
        #endregion
        
        #region Parameter QuietTime_Start
        /// <summary>
        /// <para>
        /// The time at which quiet time should begin. The value
        /// that you specify has to be in HH:mm format, where HH is the hour in 24-hour format
        /// (with a leading zero, if applicable), and mm is the minutes. For example, use 02:30
        /// to represent 2:30 AM, or 14:30 to represent 2:30 PM.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_QuietTime_Start")]
        public System.String QuietTime_Start { get; set; }
        #endregion
        
        #region Parameter Limits_Total
        /// <summary>
        /// <para>
        /// The maximum number of messages that an individual
        /// campaign can send to a single endpoint over the course of the campaign.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_Total")]
        public System.Int32 Limits_Total { get; set; }
        #endregion
        
        #region Parameter CampaignHook_WebUrl
        /// <summary>
        /// <para>
        /// Web URL to call for hook. If the URL has authentication
        /// specified it will be added as authentication to the request
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_CampaignHook_WebUrl")]
        public System.String CampaignHook_WebUrl { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApplicationSettingList (UpdateApplicationSettings)"))
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
            
            context.ApplicationId = this.ApplicationId;
            context.WriteApplicationSettingsRequest_CampaignHook_LambdaFunctionName = this.CampaignHook_LambdaFunctionName;
            context.WriteApplicationSettingsRequest_CampaignHook_Mode = this.CampaignHook_Mode;
            context.WriteApplicationSettingsRequest_CampaignHook_WebUrl = this.CampaignHook_WebUrl;
            if (ParameterWasBound("WriteApplicationSettingsRequest_CloudWatchMetricsEnabled"))
                context.WriteApplicationSettingsRequest_CloudWatchMetricsEnabled = this.WriteApplicationSettingsRequest_CloudWatchMetricsEnabled;
            if (ParameterWasBound("Limits_Daily"))
                context.WriteApplicationSettingsRequest_Limits_Daily = this.Limits_Daily;
            if (ParameterWasBound("Limits_MaximumDuration"))
                context.WriteApplicationSettingsRequest_Limits_MaximumDuration = this.Limits_MaximumDuration;
            if (ParameterWasBound("Limits_MessagesPerSecond"))
                context.WriteApplicationSettingsRequest_Limits_MessagesPerSecond = this.Limits_MessagesPerSecond;
            if (ParameterWasBound("Limits_Total"))
                context.WriteApplicationSettingsRequest_Limits_Total = this.Limits_Total;
            context.WriteApplicationSettingsRequest_QuietTime_End = this.QuietTime_End;
            context.WriteApplicationSettingsRequest_QuietTime_Start = this.QuietTime_Start;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateApplicationSettingsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteApplicationSettingsRequest
            bool requestWriteApplicationSettingsRequestIsNull = true;
            request.WriteApplicationSettingsRequest = new Amazon.Pinpoint.Model.WriteApplicationSettingsRequest();
            System.Boolean? requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CloudWatchMetricsEnabled = null;
            if (cmdletContext.WriteApplicationSettingsRequest_CloudWatchMetricsEnabled != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CloudWatchMetricsEnabled = cmdletContext.WriteApplicationSettingsRequest_CloudWatchMetricsEnabled.Value;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CloudWatchMetricsEnabled != null)
            {
                request.WriteApplicationSettingsRequest.CloudWatchMetricsEnabled = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CloudWatchMetricsEnabled.Value;
                requestWriteApplicationSettingsRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.QuietTime requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime = null;
            
             // populate QuietTime
            bool requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTimeIsNull = true;
            requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime = new Amazon.Pinpoint.Model.QuietTime();
            System.String requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_End = null;
            if (cmdletContext.WriteApplicationSettingsRequest_QuietTime_End != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_End = cmdletContext.WriteApplicationSettingsRequest_QuietTime_End;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_End != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime.End = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_End;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTimeIsNull = false;
            }
            System.String requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_Start = null;
            if (cmdletContext.WriteApplicationSettingsRequest_QuietTime_Start != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_Start = cmdletContext.WriteApplicationSettingsRequest_QuietTime_Start;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_Start != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime.Start = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime_quietTime_Start;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTimeIsNull = false;
            }
             // determine if requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime should be set to null
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTimeIsNull)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime = null;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime != null)
            {
                request.WriteApplicationSettingsRequest.QuietTime = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_QuietTime;
                requestWriteApplicationSettingsRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignHook requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook = null;
            
             // populate CampaignHook
            bool requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHookIsNull = true;
            requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook = new Amazon.Pinpoint.Model.CampaignHook();
            System.String requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_LambdaFunctionName = null;
            if (cmdletContext.WriteApplicationSettingsRequest_CampaignHook_LambdaFunctionName != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_LambdaFunctionName = cmdletContext.WriteApplicationSettingsRequest_CampaignHook_LambdaFunctionName;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_LambdaFunctionName != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook.LambdaFunctionName = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_LambdaFunctionName;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHookIsNull = false;
            }
            Amazon.Pinpoint.Mode requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_Mode = null;
            if (cmdletContext.WriteApplicationSettingsRequest_CampaignHook_Mode != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_Mode = cmdletContext.WriteApplicationSettingsRequest_CampaignHook_Mode;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_Mode != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook.Mode = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_Mode;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHookIsNull = false;
            }
            System.String requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_WebUrl = null;
            if (cmdletContext.WriteApplicationSettingsRequest_CampaignHook_WebUrl != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_WebUrl = cmdletContext.WriteApplicationSettingsRequest_CampaignHook_WebUrl;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_WebUrl != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook.WebUrl = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook_campaignHook_WebUrl;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHookIsNull = false;
            }
             // determine if requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook should be set to null
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHookIsNull)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook = null;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook != null)
            {
                request.WriteApplicationSettingsRequest.CampaignHook = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_CampaignHook;
                requestWriteApplicationSettingsRequestIsNull = false;
            }
            Amazon.Pinpoint.Model.CampaignLimits requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits = null;
            
             // populate Limits
            bool requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull = true;
            requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits = new Amazon.Pinpoint.Model.CampaignLimits();
            System.Int32? requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Daily = null;
            if (cmdletContext.WriteApplicationSettingsRequest_Limits_Daily != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Daily = cmdletContext.WriteApplicationSettingsRequest_Limits_Daily.Value;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Daily != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits.Daily = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Daily.Value;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MaximumDuration = null;
            if (cmdletContext.WriteApplicationSettingsRequest_Limits_MaximumDuration != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MaximumDuration = cmdletContext.WriteApplicationSettingsRequest_Limits_MaximumDuration.Value;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MaximumDuration != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits.MaximumDuration = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MaximumDuration.Value;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MessagesPerSecond = null;
            if (cmdletContext.WriteApplicationSettingsRequest_Limits_MessagesPerSecond != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MessagesPerSecond = cmdletContext.WriteApplicationSettingsRequest_Limits_MessagesPerSecond.Value;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MessagesPerSecond != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits.MessagesPerSecond = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_MessagesPerSecond.Value;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull = false;
            }
            System.Int32? requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Total = null;
            if (cmdletContext.WriteApplicationSettingsRequest_Limits_Total != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Total = cmdletContext.WriteApplicationSettingsRequest_Limits_Total.Value;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Total != null)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits.Total = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits_limits_Total.Value;
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull = false;
            }
             // determine if requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits should be set to null
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_LimitsIsNull)
            {
                requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits = null;
            }
            if (requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits != null)
            {
                request.WriteApplicationSettingsRequest.Limits = requestWriteApplicationSettingsRequest_writeApplicationSettingsRequest_Limits;
                requestWriteApplicationSettingsRequestIsNull = false;
            }
             // determine if request.WriteApplicationSettingsRequest should be set to null
            if (requestWriteApplicationSettingsRequestIsNull)
            {
                request.WriteApplicationSettingsRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationSettingsResource;
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
        
        private Amazon.Pinpoint.Model.UpdateApplicationSettingsResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApplicationSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApplicationSettings");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationSettings(request);
                #elif CORECLR
                return client.UpdateApplicationSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String WriteApplicationSettingsRequest_CampaignHook_LambdaFunctionName { get; set; }
            public Amazon.Pinpoint.Mode WriteApplicationSettingsRequest_CampaignHook_Mode { get; set; }
            public System.String WriteApplicationSettingsRequest_CampaignHook_WebUrl { get; set; }
            public System.Boolean? WriteApplicationSettingsRequest_CloudWatchMetricsEnabled { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_Daily { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_MaximumDuration { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_MessagesPerSecond { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_Total { get; set; }
            public System.String WriteApplicationSettingsRequest_QuietTime_End { get; set; }
            public System.String WriteApplicationSettingsRequest_QuietTime_Start { get; set; }
        }
        
    }
}
