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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Registers an endpoint under an Amazon Chime <c>AppInstanceUser</c>. The endpoint receives
    /// messages for a user. For push notifications, the endpoint is a mobile device used
    /// to receive mobile push notifications for a user.
    /// </summary>
    [Cmdlet("Register", "CHMIDAppInstanceUserEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity RegisterAppInstanceUserEndpoint API operation.", Operation = new[] {"RegisterAppInstanceUserEndpoint"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse",
        "This cmdlet returns an Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterCHMIDAppInstanceUserEndpointCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowMessage
        /// <summary>
        /// <para>
        /// <para>Boolean that controls whether the AppInstanceUserEndpoint is opted in to receive messages.
        /// <c>ALL</c> indicates the endpoint receives all messages. <c>NONE</c> indicates the
        /// endpoint receives no messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowMessages")]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.AllowMessages")]
        public Amazon.ChimeSDKIdentity.AllowMessages AllowMessage { get; set; }
        #endregion
        
        #region Parameter AppInstanceUserArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AppInstanceUserArn { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique ID assigned to the request. Use different tokens to register other endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter EndpointAttributes_DeviceToken
        /// <summary>
        /// <para>
        /// <para>The device token for the GCM, APNS, and APNS_SANDBOX endpoint types.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String EndpointAttributes_DeviceToken { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>AppInstanceUserEndpoint</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the resource to which the endpoint belongs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the <c>AppInstanceUserEndpoint</c>. Supported types:</para><ul><li><para><c>APNS</c>: The mobile notification service for an Apple device.</para></li><li><para><c>APNS_SANDBOX</c>: The sandbox environment of the mobile notification service for
        /// an Apple device.</para></li><li><para><c>GCM</c>: The mobile notification service for an Android device.</para></li></ul><para>Populate the <c>ResourceArn</c> value of each type as <c>PinpointAppArn</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKIdentity.AppInstanceUserEndpointType")]
        public Amazon.ChimeSDKIdentity.AppInstanceUserEndpointType Type { get; set; }
        #endregion
        
        #region Parameter EndpointAttributes_VoipDeviceToken
        /// <summary>
        /// <para>
        /// <para>The VOIP device token for the APNS and APNS_SANDBOX endpoint types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EndpointAttributes_VoipDeviceToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CHMIDAppInstanceUserEndpoint (RegisterAppInstanceUserEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse, RegisterCHMIDAppInstanceUserEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowMessage = this.AllowMessage;
            context.AppInstanceUserArn = this.AppInstanceUserArn;
            #if MODULAR
            if (this.AppInstanceUserArn == null && ParameterWasBound(nameof(this.AppInstanceUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.EndpointAttributes_DeviceToken = this.EndpointAttributes_DeviceToken;
            #if MODULAR
            if (this.EndpointAttributes_DeviceToken == null && ParameterWasBound(nameof(this.EndpointAttributes_DeviceToken)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointAttributes_DeviceToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndpointAttributes_VoipDeviceToken = this.EndpointAttributes_VoipDeviceToken;
            context.Name = this.Name;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointRequest();
            
            if (cmdletContext.AllowMessage != null)
            {
                request.AllowMessages = cmdletContext.AllowMessage;
            }
            if (cmdletContext.AppInstanceUserArn != null)
            {
                request.AppInstanceUserArn = cmdletContext.AppInstanceUserArn;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate EndpointAttributes
            var requestEndpointAttributesIsNull = true;
            request.EndpointAttributes = new Amazon.ChimeSDKIdentity.Model.EndpointAttributes();
            System.String requestEndpointAttributes_endpointAttributes_DeviceToken = null;
            if (cmdletContext.EndpointAttributes_DeviceToken != null)
            {
                requestEndpointAttributes_endpointAttributes_DeviceToken = cmdletContext.EndpointAttributes_DeviceToken;
            }
            if (requestEndpointAttributes_endpointAttributes_DeviceToken != null)
            {
                request.EndpointAttributes.DeviceToken = requestEndpointAttributes_endpointAttributes_DeviceToken;
                requestEndpointAttributesIsNull = false;
            }
            System.String requestEndpointAttributes_endpointAttributes_VoipDeviceToken = null;
            if (cmdletContext.EndpointAttributes_VoipDeviceToken != null)
            {
                requestEndpointAttributes_endpointAttributes_VoipDeviceToken = cmdletContext.EndpointAttributes_VoipDeviceToken;
            }
            if (requestEndpointAttributes_endpointAttributes_VoipDeviceToken != null)
            {
                request.EndpointAttributes.VoipDeviceToken = requestEndpointAttributes_endpointAttributes_VoipDeviceToken;
                requestEndpointAttributesIsNull = false;
            }
             // determine if request.EndpointAttributes should be set to null
            if (requestEndpointAttributesIsNull)
            {
                request.EndpointAttributes = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "RegisterAppInstanceUserEndpoint");
            try
            {
                #if DESKTOP
                return client.RegisterAppInstanceUserEndpoint(request);
                #elif CORECLR
                return client.RegisterAppInstanceUserEndpointAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKIdentity.AllowMessages AllowMessage { get; set; }
            public System.String AppInstanceUserArn { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String EndpointAttributes_DeviceToken { get; set; }
            public System.String EndpointAttributes_VoipDeviceToken { get; set; }
            public System.String Name { get; set; }
            public System.String ResourceArn { get; set; }
            public Amazon.ChimeSDKIdentity.AppInstanceUserEndpointType Type { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.RegisterAppInstanceUserEndpointResponse, RegisterCHMIDAppInstanceUserEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
