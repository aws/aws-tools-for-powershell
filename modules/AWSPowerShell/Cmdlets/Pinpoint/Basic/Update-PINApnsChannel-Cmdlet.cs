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
    /// Enables the APNs channel for an application or updates the status and settings of
    /// the APNs channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINApnsChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.APNSChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateApnsChannel API operation.", Operation = new[] {"UpdateApnsChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateApnsChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.APNSChannelResponse or Amazon.Pinpoint.Model.UpdateApnsChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.APNSChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateApnsChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINApnsChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
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
        
        #region Parameter APNSChannelRequest_BundleId
        /// <summary>
        /// <para>
        /// <para>The bundle identifier that's assigned to your iOS app. This identifier is used for
        /// APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_BundleId { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_Certificate
        /// <summary>
        /// <para>
        /// <para>The APNs client certificate that you received from Apple, if you want Amazon Pinpoint
        /// to communicate with APNs by using an APNs certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_Certificate { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_DefaultAuthenticationMethod
        /// <summary>
        /// <para>
        /// <para>The default authentication method that you want Amazon Pinpoint to use when authenticating
        /// with APNs, key or certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_DefaultAuthenticationMethod { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the APNs channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? APNSChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key for the APNs client certificate that you want Amazon Pinpoint to use
        /// to communicate with APNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_PrivateKey { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_TeamId
        /// <summary>
        /// <para>
        /// <para>The identifier that's assigned to your Apple developer account team. This identifier
        /// is used for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_TeamId { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_TokenKey
        /// <summary>
        /// <para>
        /// <para>The authentication key to use for APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_TokenKey { get; set; }
        #endregion
        
        #region Parameter APNSChannelRequest_TokenKeyId
        /// <summary>
        /// <para>
        /// <para>The key identifier that's assigned to your APNs signing key, if you want Amazon Pinpoint
        /// to communicate with APNs by using APNs tokens.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String APNSChannelRequest_TokenKeyId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'APNSChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateApnsChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateApnsChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "APNSChannelResponse";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINApnsChannel (UpdateApnsChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateApnsChannelResponse, UpdatePINApnsChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.APNSChannelRequest_BundleId = this.APNSChannelRequest_BundleId;
            context.APNSChannelRequest_Certificate = this.APNSChannelRequest_Certificate;
            context.APNSChannelRequest_DefaultAuthenticationMethod = this.APNSChannelRequest_DefaultAuthenticationMethod;
            context.APNSChannelRequest_Enabled = this.APNSChannelRequest_Enabled;
            context.APNSChannelRequest_PrivateKey = this.APNSChannelRequest_PrivateKey;
            context.APNSChannelRequest_TeamId = this.APNSChannelRequest_TeamId;
            context.APNSChannelRequest_TokenKey = this.APNSChannelRequest_TokenKey;
            context.APNSChannelRequest_TokenKeyId = this.APNSChannelRequest_TokenKeyId;
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
            var request = new Amazon.Pinpoint.Model.UpdateApnsChannelRequest();
            
            
             // populate APNSChannelRequest
            var requestAPNSChannelRequestIsNull = true;
            request.APNSChannelRequest = new Amazon.Pinpoint.Model.APNSChannelRequest();
            System.String requestAPNSChannelRequest_aPNSChannelRequest_BundleId = null;
            if (cmdletContext.APNSChannelRequest_BundleId != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_BundleId = cmdletContext.APNSChannelRequest_BundleId;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_BundleId != null)
            {
                request.APNSChannelRequest.BundleId = requestAPNSChannelRequest_aPNSChannelRequest_BundleId;
                requestAPNSChannelRequestIsNull = false;
            }
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
            System.String requestAPNSChannelRequest_aPNSChannelRequest_DefaultAuthenticationMethod = null;
            if (cmdletContext.APNSChannelRequest_DefaultAuthenticationMethod != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_DefaultAuthenticationMethod = cmdletContext.APNSChannelRequest_DefaultAuthenticationMethod;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_DefaultAuthenticationMethod != null)
            {
                request.APNSChannelRequest.DefaultAuthenticationMethod = requestAPNSChannelRequest_aPNSChannelRequest_DefaultAuthenticationMethod;
                requestAPNSChannelRequestIsNull = false;
            }
            System.Boolean? requestAPNSChannelRequest_aPNSChannelRequest_Enabled = null;
            if (cmdletContext.APNSChannelRequest_Enabled != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_Enabled = cmdletContext.APNSChannelRequest_Enabled.Value;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_Enabled != null)
            {
                request.APNSChannelRequest.Enabled = requestAPNSChannelRequest_aPNSChannelRequest_Enabled.Value;
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
            System.String requestAPNSChannelRequest_aPNSChannelRequest_TeamId = null;
            if (cmdletContext.APNSChannelRequest_TeamId != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_TeamId = cmdletContext.APNSChannelRequest_TeamId;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_TeamId != null)
            {
                request.APNSChannelRequest.TeamId = requestAPNSChannelRequest_aPNSChannelRequest_TeamId;
                requestAPNSChannelRequestIsNull = false;
            }
            System.String requestAPNSChannelRequest_aPNSChannelRequest_TokenKey = null;
            if (cmdletContext.APNSChannelRequest_TokenKey != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_TokenKey = cmdletContext.APNSChannelRequest_TokenKey;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_TokenKey != null)
            {
                request.APNSChannelRequest.TokenKey = requestAPNSChannelRequest_aPNSChannelRequest_TokenKey;
                requestAPNSChannelRequestIsNull = false;
            }
            System.String requestAPNSChannelRequest_aPNSChannelRequest_TokenKeyId = null;
            if (cmdletContext.APNSChannelRequest_TokenKeyId != null)
            {
                requestAPNSChannelRequest_aPNSChannelRequest_TokenKeyId = cmdletContext.APNSChannelRequest_TokenKeyId;
            }
            if (requestAPNSChannelRequest_aPNSChannelRequest_TokenKeyId != null)
            {
                request.APNSChannelRequest.TokenKeyId = requestAPNSChannelRequest_aPNSChannelRequest_TokenKeyId;
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
        
        private Amazon.Pinpoint.Model.UpdateApnsChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateApnsChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateApnsChannel");
            try
            {
                #if DESKTOP
                return client.UpdateApnsChannel(request);
                #elif CORECLR
                return client.UpdateApnsChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String APNSChannelRequest_BundleId { get; set; }
            public System.String APNSChannelRequest_Certificate { get; set; }
            public System.String APNSChannelRequest_DefaultAuthenticationMethod { get; set; }
            public System.Boolean? APNSChannelRequest_Enabled { get; set; }
            public System.String APNSChannelRequest_PrivateKey { get; set; }
            public System.String APNSChannelRequest_TeamId { get; set; }
            public System.String APNSChannelRequest_TokenKey { get; set; }
            public System.String APNSChannelRequest_TokenKeyId { get; set; }
            public System.String ApplicationId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateApnsChannelResponse, UpdatePINApnsChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.APNSChannelResponse;
        }
        
    }
}
