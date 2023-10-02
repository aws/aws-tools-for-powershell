/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Enables the APNs VoIP channel for an application or updates the status and settings
    /// of the APNs VoIP channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINApnsVoipChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSVoipChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsVoipChannel API operation.", Operation = new[] {"UpdateApnsVoipChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSVoipChannelResponse or Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.APNSVoipChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINApnsVoipChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter APNSVoipChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle identifier that's assigned to your iOS app. This identifier is used for
        /// APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// <para>The APNs client certificate that you received from Apple, if you want Amazon Pinpoint
        /// to communicate with APNs by using an APNs certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The default authentication method that you want Amazon Pinpoint to use when authenticating
        /// with APNs, key or certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the APNs VoIP channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? APNSVoipChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key for the APNs client certificate that you want Amazon Pinpoint to use
        /// to communicate with APNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// <para>The identifier that's assigned to your Apple developer account team. This identifier
        /// is used for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// <para>The authentication key to use for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSVoipChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// <para>The key identifier that's assigned to your APNs signing key, if you want Amazon Pinpoint
        /// to communicate with APNs by using APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSVoipChannelRequest_TokenKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'APNSVoipChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "APNSVoipChannelResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsVoipChannel (UpdateApnsVoipChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse, UpdatePINApnsVoipChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.APNSVoipChannelRequest_BundleId = this.APNSVoipChannelRequest_BundleId;
            context.APNSVoipChannelRequest_Certificate = this.APNSVoipChannelRequest_Certificate;
            context.APNSVoipChannelRequest_DefaultAuthenticationMethod = this.APNSVoipChannelRequest_DefaultAuthenticationMethod;
            context.APNSVoipChannelRequest_Enabled = this.APNSVoipChannelRequest_Enabled;
            context.APNSVoipChannelRequest_PrivateKey = this.APNSVoipChannelRequest_PrivateKey;
            context.APNSVoipChannelRequest_TeamId = this.APNSVoipChannelRequest_TeamId;
            context.APNSVoipChannelRequest_TokenKey = this.APNSVoipChannelRequest_TokenKey;
            context.APNSVoipChannelRequest_TokenKeyId = this.APNSVoipChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsVoipChannelRequest();
            
            
             // populate APNSVoipChannelRequest
            var requestAPNSVoipChannelRequestIsNull = true;
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
            public System.Func<Amazon.Pinpoint.Model.UpdateApnsVoipChannelResponse, UpdatePINApnsVoipChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.APNSVoipChannelResponse;
        }
        
    }
}
