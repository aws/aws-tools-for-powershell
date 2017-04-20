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
    /// Use to update the APNs channel for an app.
    /// </summary>
    [Cmdlet("Update", "PINApnsChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSChannelResponse")]
    [AWSCmdlet("Invokes the UpdateApnsChannel operation against Amazon Pinpoint.", Operation = new[] {"UpdateApnsChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSChannelResponse",
        "This cmdlet returns a APNSChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApnsChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// The distribution certificate from Apple.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// The certificate private key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSChannelRequest_PrivateKey { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsChannel (UpdateApnsChannel)"))
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
            
            context.APNSChannelRequest_Certificate = this.APNSChannelRequest_Certificate;
            context.APNSChannelRequest_PrivateKey = this.APNSChannelRequest_PrivateKey;
            context.ApplicationId = this.ApplicationId;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsChannelRequest();
            
            
             // populate APNSChannelRequest
            bool requestAPNSChannelRequestIsNull = true;
            request.APNSChannelRequest = new Amazon.Pinpoint.Model.APNSChannelRequest();
            System.String requestAPNSChannelRequest_aPNSChannelRequest_Certificate = null;
            if (cmdletContext.APNSChannelRequest_Certificate != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_Certificate = cmdletContext.APNSChannelRequest_Certificate;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_Certificate != null)
            {
                request.APNSChannelRequest.Certificate = requestAPNSChannelRequest_aPNSChannelRequest_Certificate;
                requestAPNSChannelRequestIsNull = false;
            }
            System.String requestAPNSChannelRequest_aPNSChannelRequest_PrivateKey = null;
            if (cmdletContext.APNSChannelRequest_PrivateKey != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_PrivateKey = cmdletContext.APNSChannelRequest_PrivateKey;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_PrivateKey != null)
            {
                request.APNSChannelRequest.PrivateKey = requestAPNSChannelRequest_aPNSChannelRequest_PrivateKey;
                requestAPNSChannelRequestIsNull = false;
            }
             // determine if request.APNSChannelRequest should be set to null
            if (requestAPNSChannelRequestIsNull)
            {
                request.APNSChannelRequest = null;
            }
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.APNSChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsChannel");
            #if DESKTOP
            return client.UpdateApnsChannel(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateApnsChannelAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String APNSChannelRequest_Certificate { get; set; }
            public System.String APNSChannelRequest_PrivateKey { get; set; }
            public System.String ApplicationId { get; set; }
        }
        
    }
}
