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
    /// Use to update the GCM channel for an app.
    /// </summary>
    [Cmdlet("Update", "PINGcmChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.GCMChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateGcmChannel API operation.", Operation = new[] {"UpdateGcmChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.GCMChannelResponse",
        "This cmdlet returns a GCMChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateGcmChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINGcmChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter GCMChannelRequest_ApiKey
        /// <summary>
        /// <para>
        /// Platform credential API key from Google.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GCMChannelRequest_ApiKey { get; set; }
        #endregion
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter GCMChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean GCMChannelRequest_Enabled { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINGcmChannel (UpdateGcmChannel)"))
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
            context.GCMChannelRequest_ApiKey = this.GCMChannelRequest_ApiKey;
            if (ParameterWasBound("GCMChannelRequest_Enabled"))
                context.GCMChannelRequest_Enabled = this.GCMChannelRequest_Enabled;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateGcmChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate GCMChannelRequest
            bool requestGCMChannelRequestIsNull = true;
            request.GCMChannelRequest = new Amazon.Pinpoint.Model.GCMChannelRequest();
            System.String requestGCMChannelRequest_gCMChannelRequest_ApiKey = null;
            if (cmdletContext.GCMChannelRequest_ApiKey != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_ApiKey = cmdletContext.GCMChannelRequest_ApiKey;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_ApiKey != null)
            {
                request.GCMChannelRequest.ApiKey = requestGCMChannelRequest_gCMChannelRequest_ApiKey;
                requestGCMChannelRequestIsNull = false;
            }
            System.Boolean? requestGCMChannelRequest_gCMChannelRequest_Enabled = null;
            if (cmdletContext.GCMChannelRequest_Enabled != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_Enabled = cmdletContext.GCMChannelRequest_Enabled.Value;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_Enabled != null)
            {
                request.GCMChannelRequest.Enabled = requestGCMChannelRequest_gCMChannelRequest_Enabled.Value;
                requestGCMChannelRequestIsNull = false;
            }
             // determine if request.GCMChannelRequest should be set to null
            if (requestGCMChannelRequestIsNull)
            {
                request.GCMChannelRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GCMChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateGcmChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateGcmChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateGcmChannel");
            try
            {
                #if DESKTOP
                return client.UpdateGcmChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateGcmChannelAsync(request);
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
            public System.String GCMChannelRequest_ApiKey { get; set; }
            public System.Boolean? GCMChannelRequest_Enabled { get; set; }
        }
        
    }
}
