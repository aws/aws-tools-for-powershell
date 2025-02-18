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

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the APNs sandbox channel for an application or updates the status and settings
    /// of the APNs sandbox channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINApnsSandboxChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSSandboxChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsSandboxChannel API operation.", Operation = new[] {"UpdateApnsSandboxChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSSandboxChannelResponse or Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.APNSSandboxChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINApnsSandboxChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSSandboxChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle identifier that's assigned to your iOS app. This identifier is used for
        /// APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// <para>The APNs client certificate that you received from Apple, if you want Amazon Pinpoint
        /// to communicate with the APNs sandbox environment by using an APNs certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The default authentication method that you want Amazon Pinpoint to use when authenticating
        /// with the APNs sandbox environment, key or certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the APNs sandbox channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? APNSSandboxChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key for the APNs client certificate that you want Amazon Pinpoint to use
        /// to communicate with the APNs sandbox environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// <para>The identifier that's assigned to your Apple developer account team. This identifier
        /// is used for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// <para>The authentication key to use for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSSandboxChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// <para>The key identifier that's assigned to your APNs signing key, if you want Amazon Pinpoint
        /// to communicate with the APNs sandbox environment by using APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSSandboxChannelRequest_TokenKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'APNSSandboxChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "APNSSandboxChannelResponse";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsSandboxChannel (UpdateApnsSandboxChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse, UpdatePINApnsSandboxChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.APNSSandboxChannelRequest_BundleId = this.APNSSandboxChannelRequest_BundleId;
            context.APNSSandboxChannelRequest_Certificate = this.APNSSandboxChannelRequest_Certificate;
            context.APNSSandboxChannelRequest_DefaultAuthenticationMethod = this.APNSSandboxChannelRequest_DefaultAuthenticationMethod;
            context.APNSSandboxChannelRequest_Enabled = this.APNSSandboxChannelRequest_Enabled;
            context.APNSSandboxChannelRequest_PrivateKey = this.APNSSandboxChannelRequest_PrivateKey;
            context.APNSSandboxChannelRequest_TeamId = this.APNSSandboxChannelRequest_TeamId;
            context.APNSSandboxChannelRequest_TokenKey = this.APNSSandboxChannelRequest_TokenKey;
            context.APNSSandboxChannelRequest_TokenKeyId = this.APNSSandboxChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsSandboxChannelRequest();
            
            
             // populate APNSSandboxChannelRequest
            var requestAPNSSandboxChannelRequestIsNull = true;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsSandboxChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsSandboxChannel");
            try
            {
                return client.UpdateApnsSandboxChannelAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Pinpoint.Model.UpdateApnsSandboxChannelResponse, UpdatePINApnsSandboxChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.APNSSandboxChannelResponse;
        }
        
    }
}
