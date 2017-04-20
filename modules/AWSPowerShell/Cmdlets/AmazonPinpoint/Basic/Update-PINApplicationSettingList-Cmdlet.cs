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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Used to update the settings for an app.
    /// </summary>
    [Cmdlet("Update", "PINApplicationSettingList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.ApplicationSettingsResource")]
    [AWSCmdlet("Invokes the UpdateApplicationSettings operation against Amazon Pinpoint.", Operation = new[] {"UpdateApplicationSettings"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.ApplicationSettingsResource",
        "This cmdlet returns a ApplicationSettingsResource object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApplicationSettingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApplicationSettingListCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Limits_Daily
        /// <summary>
        /// <para>
        /// The maximum number of messages that the campaign
        /// can send daily.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_Daily")]
        public System.Int32 Limits_Daily { get; set; }
        #endregion
        
        #region Parameter QuietTime_End
        /// <summary>
        /// <para>
        /// The default end time for quiet time in ISO 8601 format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_QuietTime_End")]
        public System.String QuietTime_End { get; set; }
        #endregion
        
        #region Parameter QuietTime_Start
        /// <summary>
        /// <para>
        /// The default start time for quiet time in ISO 8601
        /// format.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_QuietTime_Start")]
        public System.String QuietTime_Start { get; set; }
        #endregion
        
        #region Parameter Limits_Total
        /// <summary>
        /// <para>
        /// The maximum total number of messages that the campaign
        /// can send.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("WriteApplicationSettingsRequest_Limits_Total")]
        public System.Int32 Limits_Total { get; set; }
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
            if (ParameterWasBound("Limits_Daily"))
                context.WriteApplicationSettingsRequest_Limits_Daily = this.Limits_Daily;
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
            #if DESKTOP
            return client.UpdateApplicationSettings(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateApplicationSettingsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationId { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_Daily { get; set; }
            public System.Int32? WriteApplicationSettingsRequest_Limits_Total { get; set; }
            public System.String WriteApplicationSettingsRequest_QuietTime_End { get; set; }
            public System.String WriteApplicationSettingsRequest_QuietTime_Start { get; set; }
        }
        
    }
}
