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
    /// Update an APNS VoIP channel
    /// </summary>
    [Cmdlet("Update", "PINApnsVoipChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSVoipChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsVoipChannel API operation.", Operation = new[] {"UpdateApnsVoipChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSVoipChannelResponse",
        "This cmdlet returns a APNSVoipChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApnsVoipChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSVoipChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// The bundle id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// The distribution certificate from Apple.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// The default authentication
        /// method used for APNs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean APNSVoipChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// The certificate private key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// The team id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSVoipChannelRequest_TokenKeyId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsVoipChannel (UpdateApnsVoipChannel)"))
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
            
            context.APNSVoipChannelRequest_BundleId = this.APNSVoipChannelRequest_BundleId;
            context.APNSVoipChannelRequest_Certificate = this.APNSVoipChannelRequest_Certificate;
            context.APNSVoipChannelRequest_DefaultAuthenticationMethod = this.APNSVoipChannelRequest_DefaultAuthenticationMethod;
            if (ParameterWasBound("APNSVoipChannelRequest_Enabled"))
                context.APNSVoipChannelRequest_Enabled = this.APNSVoipChannelRequest_Enabled;
            context.APNSVoipChannelRequest_PrivateKey = this.APNSVoipChannelRequest_PrivateKey;
            context.APNSVoipChannelRequest_TeamId = this.APNSVoipChannelRequest_TeamId;
            context.APNSVoipChannelRequest_TokenKey = this.APNSVoipChannelRequest_TokenKey;
            context.APNSVoipChannelRequest_TokenKeyId = this.APNSVoipChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsVoipChannelRequest();
            
            
             // populate APNSVoipChannelRequest
            bool requestAPNSVoipChannelRequestIsNull = true;
            request.APNSVoipChannelRequest = new Amazon.Pinpoint.Model.APNSVoipChannelRequest();
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_BundleId = null;
            if (cmdletContext.APNSVoipChannelRequest_BundleId != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_BundleId = cmdletContext.APNSVoipChannelRequest_BundleId;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_BundleId != null)
            {
                request.APNSVoipChannelRequest.BundleId = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_BundleId;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Certificate = null;
            if (cmdletContext.APNSVoipChannelRequest_Certificate != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Certificate = cmdletContext.APNSVoipChannelRequest_Certificate;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Certificate != null)
            {
                request.APNSVoipChannelRequest.Certificate = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Certificate;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_DefaultAuthenticationMethod = null;
            if (cmdletContext.APNSVoipChannelRequest_DefaultAuthenticationMethod != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_DefaultAuthenticationMethod = cmdletContext.APNSVoipChannelRequest_DefaultAuthenticationMethod;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_DefaultAuthenticationMethod != null)
            {
                request.APNSVoipChannelRequest.DefaultAuthenticationMethod = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_DefaultAuthenticationMethod;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.Boolean? requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Enabled = null;
            if (cmdletContext.APNSVoipChannelRequest_Enabled != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Enabled = cmdletContext.APNSVoipChannelRequest_Enabled.Value;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Enabled != null)
            {
                request.APNSVoipChannelRequest.Enabled = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_Enabled.Value;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_PrivateKey = null;
            if (cmdletContext.APNSVoipChannelRequest_PrivateKey != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_PrivateKey = cmdletContext.APNSVoipChannelRequest_PrivateKey;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_PrivateKey != null)
            {
                request.APNSVoipChannelRequest.PrivateKey = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_PrivateKey;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TeamId = null;
            if (cmdletContext.APNSVoipChannelRequest_TeamId != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TeamId = cmdletContext.APNSVoipChannelRequest_TeamId;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TeamId != null)
            {
                request.APNSVoipChannelRequest.TeamId = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TeamId;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKey = null;
            if (cmdletContext.APNSVoipChannelRequest_TokenKey != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKey = cmdletContext.APNSVoipChannelRequest_TokenKey;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKey != null)
            {
                request.APNSVoipChannelRequest.TokenKey = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKey;
                requestAPNSVoipChannelRequestIsNull = false;
            }
            System.String requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKeyId = null;
            if (cmdletContext.APNSVoipChannelRequest_TokenKeyId != null)
            {
                requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKeyId = cmdletContext.APNSVoipChannelRequest_TokenKeyId;
            }
            if (requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKeyId != null)
            {
                request.APNSVoipChannelRequest.TokenKeyId = requestAPNSVoipChannelRequest_aPNSVoipChannelRequest_TokenKeyId;
                requestAPNSVoipChannelRequestIsNull = false;
            }
             // determine if request.APNSVoipChannelRequest should be set to null
            if (requestAPNSVoipChannelRequestIsNull)
            {
                request.APNSVoipChannelRequest = null;
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
                object pipelineOutput = response.APNSVoipChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsVoipChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsVoipChannel");
            try
            {
                #if DESKTOP
                return client.UpdateApnsVoipChannel(request);
                #elif CORECLR
                return client.UpdateApnsVoipChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String APNSVoipChannelRequest_BundleId { get; set; }
            public System.String APNSVoipChannelRequest_Certificate { get; set; }
            public System.String APNSVoipChannelRequest_DefaultAuthenticationMethod { get; set; }
            public System.Boolean? APNSVoipChannelRequest_Enabled { get; set; }
            public System.String APNSVoipChannelRequest_PrivateKey { get; set; }
            public System.String APNSVoipChannelRequest_TeamId { get; set; }
            public System.String APNSVoipChannelRequest_TokenKey { get; set; }
            public System.String APNSVoipChannelRequest_TokenKeyId { get; set; }
            public System.String ApplicationId { get; set; }
        }
        
    }
}
