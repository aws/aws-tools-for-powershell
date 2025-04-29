/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Threading;
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the APNs VoIP sandbox channel for an application or updates the status and
    /// settings of the APNs VoIP sandbox channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINApnsVoipSandboxChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSVoipSandboxChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsVoipSandboxChannel API operation.", Operation = new[] {"UpdateApnsVoipSandboxChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSVoipSandboxChannelResponse or Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.APNSVoipSandboxChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINApnsVoipSandboxChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle identifier that's assigned to your iOS app. This identifier is used for
        /// APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// <para>The APNs client certificate that you received from Apple, if you want Amazon Pinpoint
        /// to communicate with the APNs sandbox environment by using an APNs certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The default authentication method that you want Amazon Pinpoint to use when authenticating
        /// with the APNs sandbox environment for this channel, key or certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the APNs VoIP sandbox channel is enabled for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? APNSVoipSandboxChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key for the APNs client certificate that you want Amazon Pinpoint to use
        /// to communicate with the APNs sandbox environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// <para>The identifier that's assigned to your Apple developer account team. This identifier
        /// is used for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// <para>The authentication key to use for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipSandboxChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// <para>The key identifier that's assigned to your APNs signing key, if you want Amazon Pinpoint
        /// to communicate with the APNs sandbox environment by using APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipSandboxChannelRequest_TokenKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'APNSVoipSandboxChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "APNSVoipSandboxChannelResponse";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsVoipSandboxChannel (UpdateApnsVoipSandboxChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse, UpdatePINApnsVoipSandboxChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.APNSVoipSandboxChannelRequest_BundleId = this.APNSVoipSandboxChannelRequest_BundleId;
            context.APNSVoipSandboxChannelRequest_Certificate = this.APNSVoipSandboxChannelRequest_Certificate;
            context.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod = this.APNSVoipSandboxChannelRequest_DefaultAuthenticationMethod;
            context.APNSVoipSandboxChannelRequest_Enabled = this.APNSVoipSandboxChannelRequest_Enabled;
            context.APNSVoipSandboxChannelRequest_PrivateKey = this.APNSVoipSandboxChannelRequest_PrivateKey;
            context.APNSVoipSandboxChannelRequest_TeamId = this.APNSVoipSandboxChannelRequest_TeamId;
            context.APNSVoipSandboxChannelRequest_TokenKey = this.APNSVoipSandboxChannelRequest_TokenKey;
            context.APNSVoipSandboxChannelRequest_TokenKeyId = this.APNSVoipSandboxChannelRequest_TokenKeyId;
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var requestAPNSVoipSandboxChannelRequestIsNull = true;
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
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
                return client.UpdateApnsVoipSandboxChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Pinpoint.Model.UpdateApnsVoipSandboxChannelResponse, UpdatePINApnsVoipSandboxChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.APNSVoipSandboxChannelResponse;
        }
        
    }
}
