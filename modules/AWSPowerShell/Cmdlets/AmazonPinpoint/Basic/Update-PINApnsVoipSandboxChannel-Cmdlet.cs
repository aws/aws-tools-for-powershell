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
    /// Update an APNS VoIP sandbox channel
    /// </summary>
    [Cmdlet("Update", "PINApnsVoipSandboxChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSVoipSandboxChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsVoipSandboxChannel API operation.", Operation = new[] {"UpdateApnsVoipSandboxChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSVoipSandboxChannelResponse",
        "This cmdlet returns a APNSVoipSandboxChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApnsVoipSandboxChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSVoipSandboxChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// The bundle id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// The distribution certificate from Apple.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// The default authentication
        /// method used for APNs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean APNSVoipSandboxChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// The certificate private key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// The team id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipSandboxChannelRequest_TokenKeyId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsVoipSandboxChannel (UpdateApnsVoipSandboxChannel)"))
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
            
            context.APNSVoipSandboxChannelRequest_BundleId = this.APNSVoipSandboxChannelRequest_BundleId;
            context.APNSVoipSandboxChannelRequest_Certificate = this.APNSVoipSandboxChannelRequest_Certificate;
            context.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod = this.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod;
            if (ParameterWasBound("APNSVoipSandboxChannelRequest_Enabled"))
                context.APNSVoipSandboxChannelRequest_Enabled = this.APNSVoipSandboxChannelRequest_Enabled;
            context.APNSVoipSandboxChannelRequest_PrivateKey = this.APNSVoipSandboxChannelRequest_PrivateKey;
            context.APNSVoipSandboxChannelRequest_TeamId = this.APNSVoipSandboxChannelRequest_TeamId;
            context.APNSVoipSandboxChannelRequest_TokenKey = this.APNSVoipSandboxChannelRequest_TokenKey;
            context.APNSVoipSandboxChannelRequest_TokenKeyId = this.APNSVoipSandboxChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelRequest();
            
            
             // populate APNSVoipSandboxChannelRequest
            bool requestAPNSVoipSandboxChannelRequestIsNull = true;
            request.APNSVoipSandboxChannelRequest = new Amazon.Pinpoint.Model.APNSVoipSandboxChannelRequest();
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_BundleId = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_BundleId != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_BundleId = cmdletContext.APNSVoipSandboxChannelRequest_BundleId;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_BundleId != null)
            {
                request.APNSVoipSandboxChannelRequest.BundleId = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_BundleId;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Certificate = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_Certificate != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Certificate = cmdletContext.APNSVoipSandboxChannelRequest_Certificate;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Certificate != null)
            {
                request.APNSVoipSandboxChannelRequest.Certificate = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Certificate;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_DefaultAuthenticationMethod = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_DefaultAuthenticationMethod = cmdletContext.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_DefaultAuthenticationMethod != null)
            {
                request.APNSVoipSandboxChannelRequest.DefaultAuthenticationMethod = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_DefaultAuthenticationMethod;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.Boolean? requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Enabled = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_Enabled != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Enabled = cmdletContext.APNSVoipSandboxChannelRequest_Enabled.Value;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Enabled != null)
            {
                request.APNSVoipSandboxChannelRequest.Enabled = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_Enabled.Value;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_PrivateKey = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_PrivateKey != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_PrivateKey = cmdletContext.APNSVoipSandboxChannelRequest_PrivateKey;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_PrivateKey != null)
            {
                request.APNSVoipSandboxChannelRequest.PrivateKey = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_PrivateKey;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TeamId = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_TeamId != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TeamId = cmdletContext.APNSVoipSandboxChannelRequest_TeamId;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TeamId != null)
            {
                request.APNSVoipSandboxChannelRequest.TeamId = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TeamId;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKey = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_TokenKey != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKey = cmdletContext.APNSVoipSandboxChannelRequest_TokenKey;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKey != null)
            {
                request.APNSVoipSandboxChannelRequest.TokenKey = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKey;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKeyId = null;
            if (cmdletContext.APNSVoipSandboxChannelRequest_TokenKeyId != null)
            {
                requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKeyId = cmdletContext.APNSVoipSandboxChannelRequest_TokenKeyId;
            }
            if (requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKeyId != null)
            {
                request.APNSVoipSandboxChannelRequest.TokenKeyId = requestAPNSVoipSandboxChannelRequest_aPNSVoipSandboxChannelRequest_TokenKeyId;
                requestAPNSVoipSandboxChannelRequestIsNull = false;
            }
             // determine if request.APNSVoipSandboxChannelRequest should be set to null
            if (requestAPNSVoipSandboxChannelRequestIsNull)
            {
                request.APNSVoipSandboxChannelRequest = null;
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
                object pipelineOutput = response.APNSVoipSandboxChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsVoipSandboxChannel");
            try
            {
                #if DESKTOP
                return client.UpdateApnsVoipSandboxChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateApnsVoipSandboxChannelAsync(request);
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
            public System.String APNSVoipSandboxChannelRequest_BundleId { get; set; }
            public System.String APNSVoipSandboxChannelRequest_Certificate { get; set; }
            public System.String APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
            public System.Boolean? APNSVoipSandboxChannelRequest_Enabled { get; set; }
            public System.String APNSVoipSandboxChannelRequest_PrivateKey { get; set; }
            public System.String APNSVoipSandboxChannelRequest_TeamId { get; set; }
            public System.String APNSVoipSandboxChannelRequest_TokenKey { get; set; }
            public System.String APNSVoipSandboxChannelRequest_TokenKeyId { get; set; }
            public System.String ApplicationId { get; set; }
        }
        
    }
}
