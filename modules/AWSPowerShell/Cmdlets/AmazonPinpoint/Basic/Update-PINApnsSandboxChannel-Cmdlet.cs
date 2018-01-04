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
    /// Update an APNS sandbox channel
    /// </summary>
    [Cmdlet("Update", "PINApnsSandboxChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSSandboxChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsSandboxChannel API operation.", Operation = new[] {"UpdateApnsSandboxChannel"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSSandboxChannelResponse",
        "This cmdlet returns a APNSSandboxChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApnsSandboxChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSSandboxChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// The bundle id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// The distribution certificate from Apple.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// The default authentication
        /// method used for APNs.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// If the channel is enabled for sending messages.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean APNSSandboxChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// The certificate private key.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// The team id used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// The token key used for APNs Tokens.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String APNSSandboxChannelRequest_TokenKeyId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsSandboxChannel (UpdateApnsSandboxChannel)"))
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
            
            context.APNSSandboxChannelRequest_BundleId = this.APNSSandboxChannelRequest_BundleId;
            context.APNSSandboxChannelRequest_Certificate = this.APNSSandboxChannelRequest_Certificate;
            context.APNSSandboxChannelRequest_DefaultAuthenticationMethod = this.APNSSandboxChannelRequest_DefaultAuthenticationMethod;
            if (ParameterWasBound("APNSSandboxChannelRequest_Enabled"))
                context.APNSSandboxChannelRequest_Enabled = this.APNSSandboxChannelRequest_Enabled;
            context.APNSSandboxChannelRequest_PrivateKey = this.APNSSandboxChannelRequest_PrivateKey;
            context.APNSSandboxChannelRequest_TeamId = this.APNSSandboxChannelRequest_TeamId;
            context.APNSSandboxChannelRequest_TokenKey = this.APNSSandboxChannelRequest_TokenKey;
            context.APNSSandboxChannelRequest_TokenKeyId = this.APNSSandboxChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsSandboxChannelRequest();
            
            
             // populate APNSSandboxChannelRequest
            bool requestAPNSSandboxChannelRequestIsNull = true;
            request.APNSSandboxChannelRequest = new Amazon.Pinpoint.Model.APNSSandboxChannelRequest();
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_BundleId = null;
            if (cmdletContext.APNSSandboxChannelRequest_BundleId != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_BundleId = cmdletContext.APNSSandboxChannelRequest_BundleId;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_BundleId != null)
            {
                request.APNSSandboxChannelRequest.BundleId = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_BundleId;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Certificate = null;
            if (cmdletContext.APNSSandboxChannelRequest_Certificate != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Certificate = cmdletContext.APNSSandboxChannelRequest_Certificate;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Certificate != null)
            {
                request.APNSSandboxChannelRequest.Certificate = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Certificate;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_DefaultAuthenticationMethod = null;
            if (cmdletContext.APNSSandboxChannelRequest_DefaultAuthenticationMethod != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_DefaultAuthenticationMethod = cmdletContext.APNSSandboxChannelRequest_DefaultAuthenticationMethod;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_DefaultAuthenticationMethod != null)
            {
                request.APNSSandboxChannelRequest.DefaultAuthenticationMethod = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_DefaultAuthenticationMethod;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.Boolean? requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Enabled = null;
            if (cmdletContext.APNSSandboxChannelRequest_Enabled != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Enabled = cmdletContext.APNSSandboxChannelRequest_Enabled.Value;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Enabled != null)
            {
                request.APNSSandboxChannelRequest.Enabled = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_Enabled.Value;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_PrivateKey = null;
            if (cmdletContext.APNSSandboxChannelRequest_PrivateKey != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_PrivateKey = cmdletContext.APNSSandboxChannelRequest_PrivateKey;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_PrivateKey != null)
            {
                request.APNSSandboxChannelRequest.PrivateKey = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_PrivateKey;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TeamId = null;
            if (cmdletContext.APNSSandboxChannelRequest_TeamId != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TeamId = cmdletContext.APNSSandboxChannelRequest_TeamId;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TeamId != null)
            {
                request.APNSSandboxChannelRequest.TeamId = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TeamId;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKey = null;
            if (cmdletContext.APNSSandboxChannelRequest_TokenKey != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKey = cmdletContext.APNSSandboxChannelRequest_TokenKey;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKey != null)
            {
                request.APNSSandboxChannelRequest.TokenKey = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKey;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
            System.String requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKeyId = null;
            if (cmdletContext.APNSSandboxChannelRequest_TokenKeyId != null)
            {
                requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKeyId = cmdletContext.APNSSandboxChannelRequest_TokenKeyId;
            }
            if (requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKeyId != null)
            {
                request.APNSSandboxChannelRequest.TokenKeyId = requestAPNSSandboxChannelRequest_aPNSSandboxChannelRequest_TokenKeyId;
                requestAPNSSandboxChannelRequestIsNull = false;
            }
             // determine if request.APNSSandboxChannelRequest should be set to null
            if (requestAPNSSandboxChannelRequestIsNull)
            {
                request.APNSSandboxChannelRequest = null;
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
                object pipelineOutput = response.APNSSandboxChannelResponse;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsSandboxChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsSandboxChannel");
            try
            {
                #if DESKTOP
                return client.UpdateApnsSandboxChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateApnsSandboxChannelAsync(request);
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
            public System.String APNSSandboxChannelRequest_BundleId { get; set; }
            public System.String APNSSandboxChannelRequest_Certificate { get; set; }
            public System.String APNSSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
            public System.Boolean? APNSSandboxChannelRequest_Enabled { get; set; }
            public System.String APNSSandboxChannelRequest_PrivateKey { get; set; }
            public System.String APNSSandboxChannelRequest_TeamId { get; set; }
            public System.String APNSSandboxChannelRequest_TokenKey { get; set; }
            public System.String APNSSandboxChannelRequest_TokenKeyId { get; set; }
            public System.String ApplicationId { get; set; }
        }
        
    }
}
