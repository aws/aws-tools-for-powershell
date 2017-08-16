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
    /// Update an SMS channel
    /// </summary>
    [Cmdlet("Update", "PINSmsChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.SMSChannelResponse")]
    [AWSCmdlet("Invokes the UpdateSmsChannel operation against Amazon Pinpoint.", Operation = new[] {"UpdateSmsChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SMSChannelResponse",
        "This cmdlet returns a SMSChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateSmsChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINSmsChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter SMSChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean SMSChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter SMSChannelRequest_SenderId
        /// <summary>
        /// <para>
        /// Sender identifier of your messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SMSChannelRequest_SenderId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINSmsChannel (UpdateSmsChannel)"))
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
            if (ParameterWasBound("SMSChannelRequest_Enabled"))
                context.SMSChannelRequest_Enabled = this.SMSChannelRequest_Enabled;
            context.SMSChannelRequest_SenderId = this.SMSChannelRequest_SenderId;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateSmsChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate SMSChannelRequest
            bool requestSMSChannelRequestIsNull = true;
            request.SMSChannelRequest = new Amazon.Pinpoint.Model.SMSChannelRequest();
            System.Boolean? requestSMSChannelRequest_sMSChannelRequest_Enabled = null;
            if (cmdletContext.SMSChannelRequest_Enabled != null)
            {
                requestSMSChannelRequest_sMSChannelRequest_Enabled = cmdletContext.SMSChannelRequest_Enabled.Value;
            }
            if (requestSMSChannelRequest_sMSChannelRequest_Enabled != null)
            {
                request.SMSChannelRequest.Enabled = requestSMSChannelRequest_sMSChannelRequest_Enabled.Value;
                requestSMSChannelRequestIsNull = false;
            }
            System.String requestSMSChannelRequest_sMSChannelRequest_SenderId = null;
            if (cmdletContext.SMSChannelRequest_SenderId != null)
            {
                requestSMSChannelRequest_sMSChannelRequest_SenderId = cmdletContext.SMSChannelRequest_SenderId;
            }
            if (requestSMSChannelRequest_sMSChannelRequest_SenderId != null)
            {
                request.SMSChannelRequest.SenderId = requestSMSChannelRequest_sMSChannelRequest_SenderId;
                requestSMSChannelRequestIsNull = false;
            }
             // determine if request.SMSChannelRequest should be set to null
            if (requestSMSChannelRequestIsNull)
            {
                request.SMSChannelRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.SMSChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateSmsChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateSmsChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateSmsChannel");
            try
            {
                #if DESKTOP
                return client.UpdateSmsChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateSmsChannelAsync(request);
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
            public System.String ApplicationId { get; set; }
            public System.Boolean? SMSChannelRequest_Enabled { get; set; }
            public System.String SMSChannelRequest_SenderId { get; set; }
        }
        
    }
}
