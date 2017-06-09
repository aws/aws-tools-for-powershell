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
    /// Update an email channel
    /// </summary>
    [Cmdlet("Update", "PINEmailChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.EmailChannelResponse")]
    [AWSCmdlet("Invokes the UpdateEmailChannel operation against Amazon Pinpoint.", Operation = new[] {"UpdateEmailChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.EmailChannelResponse",
        "This cmdlet returns a EmailChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateEmailChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINEmailChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter EmailChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EmailChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_FromAddress
        /// <summary>
        /// <para>
        /// The email address used to send emails from.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailChannelRequest_FromAddress { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_Identity
        /// <summary>
        /// <para>
        /// The ARN of an identity verified with SES.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailChannelRequest_Identity { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_RoleArn
        /// <summary>
        /// <para>
        /// The ARN of an IAM Role used to submit events to
        /// Mobile Analytics' event ingestion service
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailChannelRequest_RoleArn { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINEmailChannel (UpdateEmailChannel)"))
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
            if (ParameterWasBound("EmailChannelRequest_Enabled"))
                context.EmailChannelRequest_Enabled = this.EmailChannelRequest_Enabled;
            context.EmailChannelRequest_FromAddress = this.EmailChannelRequest_FromAddress;
            context.EmailChannelRequest_Identity = this.EmailChannelRequest_Identity;
            context.EmailChannelRequest_RoleArn = this.EmailChannelRequest_RoleArn;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateEmailChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate EmailChannelRequest
            bool requestEmailChannelRequestIsNull = true;
            request.EmailChannelRequest = new Amazon.Pinpoint.Model.EmailChannelRequest();
            System.Boolean? requestEmailChannelRequest_emailChannelRequest_Enabled = null;
            if (cmdletContext.EmailChannelRequest_Enabled != null)
            {
                requestEmailChannelRequest_emailChannelRequest_Enabled = cmdletContext.EmailChannelRequest_Enabled.Value;
            }
            if (requestEmailChannelRequest_emailChannelRequest_Enabled != null)
            {
                request.EmailChannelRequest.Enabled = requestEmailChannelRequest_emailChannelRequest_Enabled.Value;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_FromAddress = null;
            if (cmdletContext.EmailChannelRequest_FromAddress != null)
            {
                requestEmailChannelRequest_emailChannelRequest_FromAddress = cmdletContext.EmailChannelRequest_FromAddress;
            }
            if (requestEmailChannelRequest_emailChannelRequest_FromAddress != null)
            {
                request.EmailChannelRequest.FromAddress = requestEmailChannelRequest_emailChannelRequest_FromAddress;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_Identity = null;
            if (cmdletContext.EmailChannelRequest_Identity != null)
            {
                requestEmailChannelRequest_emailChannelRequest_Identity = cmdletContext.EmailChannelRequest_Identity;
            }
            if (requestEmailChannelRequest_emailChannelRequest_Identity != null)
            {
                request.EmailChannelRequest.Identity = requestEmailChannelRequest_emailChannelRequest_Identity;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_RoleArn = null;
            if (cmdletContext.EmailChannelRequest_RoleArn != null)
            {
                requestEmailChannelRequest_emailChannelRequest_RoleArn = cmdletContext.EmailChannelRequest_RoleArn;
            }
            if (requestEmailChannelRequest_emailChannelRequest_RoleArn != null)
            {
                request.EmailChannelRequest.RoleArn = requestEmailChannelRequest_emailChannelRequest_RoleArn;
                requestEmailChannelRequestIsNull = false;
            }
             // determine if request.EmailChannelRequest should be set to null
            if (requestEmailChannelRequestIsNull)
            {
                request.EmailChannelRequest = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EmailChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateEmailChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateEmailChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateEmailChannel");
            #if DESKTOP
            return client.UpdateEmailChannel(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateEmailChannelAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ApplicationId { get; set; }
            public System.Boolean? EmailChannelRequest_Enabled { get; set; }
            public System.String EmailChannelRequest_FromAddress { get; set; }
            public System.String EmailChannelRequest_Identity { get; set; }
            public System.String EmailChannelRequest_RoleArn { get; set; }
        }
        
    }
}
