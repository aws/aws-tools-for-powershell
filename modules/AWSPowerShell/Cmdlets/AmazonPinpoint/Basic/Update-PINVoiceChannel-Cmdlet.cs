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
    /// Update an Voice channel
    /// </summary>
    [Cmdlet("Update", "PINVoiceChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.VoiceChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateVoiceChannel API operation.", Operation = new[] {"UpdateVoiceChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.VoiceChannelResponse",
        "This cmdlet returns a VoiceChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateVoiceChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINVoiceChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter VoiceChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean VoiceChannelRequest_Enabled { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINVoiceChannel (UpdateVoiceChannel)"))
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
            if (ParameterWasBound("VoiceChannelRequest_Enabled"))
                context.VoiceChannelRequest_Enabled = this.VoiceChannelRequest_Enabled;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateVoiceChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate VoiceChannelRequest
            bool requestVoiceChannelRequestIsNull = true;
            request.VoiceChannelRequest = new Amazon.Pinpoint.Model.VoiceChannelRequest();
            System.Boolean? requestVoiceChannelRequest_voiceChannelRequest_Enabled = null;
            if (cmdletContext.VoiceChannelRequest_Enabled != null)
            {
                requestVoiceChannelRequest_voiceChannelRequest_Enabled = cmdletContext.VoiceChannelRequest_Enabled.Value;
            }
            if (requestVoiceChannelRequest_voiceChannelRequest_Enabled != null)
            {
                request.VoiceChannelRequest.Enabled = requestVoiceChannelRequest_voiceChannelRequest_Enabled.Value;
                requestVoiceChannelRequestIsNull = false;
            }
             // determine if request.VoiceChannelRequest should be set to null
            if (requestVoiceChannelRequestIsNull)
            {
                request.VoiceChannelRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.VoiceChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateVoiceChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateVoiceChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateVoiceChannel");
            try
            {
                #if DESKTOP
                return client.UpdateVoiceChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateVoiceChannelAsync(request);
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
            public System.Boolean? VoiceChannelRequest_Enabled { get; set; }
        }
        
    }
}
