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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the GCM channel for an application or updates the status and settings of the
    /// GCM channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINGcmChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.GCMChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateGcmChannel API operation.", Operation = new[] {"UpdateGcmChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateGcmChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.GCMChannelResponse or Amazon.Pinpoint.Model.UpdateGcmChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.GCMChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateGcmChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINGcmChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GCMChannelRequest_ApiKey
        /// <summary>
        /// <para>
        /// <para>The Web API Key, also referred to as an <i>API_KEY</i> or <i>server key</i>, that
        /// you received from Google to communicate with Google services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GCMChannelRequest_ApiKey { get; set; }
        #endregion
        
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
        
        #region Parameter GCMChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The default authentication method used for GCM. Values are either "TOKEN" or "KEY".
        /// Defaults to "KEY".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GCMChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter GCMChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the GCM channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GCMChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter GCMChannelRequest_ServiceJson
        /// <summary>
        /// <para>
        /// <para>The contents of the JSON file provided by Google during registration in order to generate
        /// an access token for authentication. For more information see <a href="https://firebase.google.com/docs/cloud-messaging/migrate-v1">Migrate
        /// from legacy FCM APIs to HTTP v1</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GCMChannelRequest_ServiceJson { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GCMChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateGcmChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateGcmChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GCMChannelResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINGcmChannel (UpdateGcmChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateGcmChannelResponse, UpdatePINGcmChannelCmdlet>(Select) ??
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
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GCMChannelRequest_ApiKey = this.GCMChannelRequest_ApiKey;
            context.GCMChannelRequest_DefaultAuthenticationMethod = this.GCMChannelRequest_DefaultAuthenticationMethod;
            context.GCMChannelRequest_Enabled = this.GCMChannelRequest_Enabled;
            context.GCMChannelRequest_ServiceJson = this.GCMChannelRequest_ServiceJson;
            
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
            request.GCMChannelRequest = new Amazon.Pinpoint.Model.GCMChannelRequest();
            System.String requestGCMChannelRequest_gCMChannelRequest_ApiKey = null;
            if (cmdletContext.GCMChannelRequest_ApiKey != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_ApiKey = cmdletContext.GCMChannelRequest_ApiKey;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_ApiKey != null)
            {
                request.GCMChannelRequest.ApiKey = requestGCMChannelRequest_gCMChannelRequest_ApiKey;
            }
            System.String requestGCMChannelRequest_gCMChannelRequest_DefaultAuthenticationMethod = null;
            if (cmdletContext.GCMChannelRequest_DefaultAuthenticationMethod != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_DefaultAuthenticationMethod = cmdletContext.GCMChannelRequest_DefaultAuthenticationMethod;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_DefaultAuthenticationMethod != null)
            {
                request.GCMChannelRequest.DefaultAuthenticationMethod = requestGCMChannelRequest_gCMChannelRequest_DefaultAuthenticationMethod;
            }
            System.Boolean? requestGCMChannelRequest_gCMChannelRequest_Enabled = null;
            if (cmdletContext.GCMChannelRequest_Enabled != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_Enabled = cmdletContext.GCMChannelRequest_Enabled.Value;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_Enabled != null)
            {
                request.GCMChannelRequest.Enabled = requestGCMChannelRequest_gCMChannelRequest_Enabled.Value;
            }
            System.String requestGCMChannelRequest_gCMChannelRequest_ServiceJson = null;
            if (cmdletContext.GCMChannelRequest_ServiceJson != null)
            {
                requestGCMChannelRequest_gCMChannelRequest_ServiceJson = cmdletContext.GCMChannelRequest_ServiceJson;
            }
            if (requestGCMChannelRequest_gCMChannelRequest_ServiceJson != null)
            {
                request.GCMChannelRequest.ServiceJson = requestGCMChannelRequest_gCMChannelRequest_ServiceJson;
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
        
        private Amazon.Pinpoint.Model.UpdateGcmChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateGcmChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateGcmChannel");
            try
            {
                #if DESKTOP
                return client.UpdateGcmChannel(request);
                #elif CORECLR
                return client.UpdateGcmChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String GCMChannelRequest_DefaultAuthenticationMethod { get; set; }
            public System.Boolean? GCMChannelRequest_Enabled { get; set; }
            public System.String GCMChannelRequest_ServiceJson { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateGcmChannelResponse, UpdatePINGcmChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GCMChannelResponse;
        }
        
    }
}
