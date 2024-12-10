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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates registration for a device token and a chat contact to receive real-time push
    /// notifications. For more information about push notifications, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/set-up-push-notifications-for-mobile-chat.html">Set
    /// up push notifications in Amazon Connect for mobile chat</a> in the <i>Amazon Connect
    /// Administrator Guide</i>.
    /// </summary>
    [Cmdlet("New", "CONNPushNotificationRegistration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service CreatePushNotificationRegistration API operation.", Operation = new[] {"CreatePushNotificationRegistration"}, SelectReturnType = typeof(Amazon.Connect.Model.CreatePushNotificationRegistrationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.CreatePushNotificationRegistrationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.CreatePushNotificationRegistrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCONNPushNotificationRegistrationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactConfiguration_ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact within the Amazon Connect instance.</para>
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
        public System.String ContactConfiguration_ContactId { get; set; }
        #endregion
        
        #region Parameter DeviceToken
        /// <summary>
        /// <para>
        /// <para>The push notification token issued by the Apple or Google gateways.</para>
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
        public System.String DeviceToken { get; set; }
        #endregion
        
        #region Parameter DeviceType
        /// <summary>
        /// <para>
        /// <para>The device type to use when sending the message.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.DeviceType")]
        public Amazon.Connect.DeviceType DeviceType { get; set; }
        #endregion
        
        #region Parameter ContactConfiguration_IncludeRawMessage
        /// <summary>
        /// <para>
        /// <para>Whether to include raw connect message in the push notification payload. Default is
        /// <c>False</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ContactConfiguration_IncludeRawMessage { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ContactConfiguration_ParticipantRole
        /// <summary>
        /// <para>
        /// <para>The role of the participant in the chat conversation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.ParticipantRole")]
        public Amazon.Connect.ParticipantRole ContactConfiguration_ParticipantRole { get; set; }
        #endregion
        
        #region Parameter PinpointAppArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Pinpoint application.</para>
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
        public System.String PinpointAppArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RegistrationId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreatePushNotificationRegistrationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreatePushNotificationRegistrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RegistrationId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNPushNotificationRegistration (CreatePushNotificationRegistration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreatePushNotificationRegistrationResponse, NewCONNPushNotificationRegistrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ContactConfiguration_ContactId = this.ContactConfiguration_ContactId;
            #if MODULAR
            if (this.ContactConfiguration_ContactId == null && ParameterWasBound(nameof(this.ContactConfiguration_ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactConfiguration_ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ContactConfiguration_IncludeRawMessage = this.ContactConfiguration_IncludeRawMessage;
            context.ContactConfiguration_ParticipantRole = this.ContactConfiguration_ParticipantRole;
            context.DeviceToken = this.DeviceToken;
            #if MODULAR
            if (this.DeviceToken == null && ParameterWasBound(nameof(this.DeviceToken)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceType = this.DeviceType;
            #if MODULAR
            if (this.DeviceType == null && ParameterWasBound(nameof(this.DeviceType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PinpointAppArn = this.PinpointAppArn;
            #if MODULAR
            if (this.PinpointAppArn == null && ParameterWasBound(nameof(this.PinpointAppArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PinpointAppArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.CreatePushNotificationRegistrationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ContactConfiguration
            var requestContactConfigurationIsNull = true;
            request.ContactConfiguration = new Amazon.Connect.Model.ContactConfiguration();
            System.String requestContactConfiguration_contactConfiguration_ContactId = null;
            if (cmdletContext.ContactConfiguration_ContactId != null)
            {
                requestContactConfiguration_contactConfiguration_ContactId = cmdletContext.ContactConfiguration_ContactId;
            }
            if (requestContactConfiguration_contactConfiguration_ContactId != null)
            {
                request.ContactConfiguration.ContactId = requestContactConfiguration_contactConfiguration_ContactId;
                requestContactConfigurationIsNull = false;
            }
            System.Boolean? requestContactConfiguration_contactConfiguration_IncludeRawMessage = null;
            if (cmdletContext.ContactConfiguration_IncludeRawMessage != null)
            {
                requestContactConfiguration_contactConfiguration_IncludeRawMessage = cmdletContext.ContactConfiguration_IncludeRawMessage.Value;
            }
            if (requestContactConfiguration_contactConfiguration_IncludeRawMessage != null)
            {
                request.ContactConfiguration.IncludeRawMessage = requestContactConfiguration_contactConfiguration_IncludeRawMessage.Value;
                requestContactConfigurationIsNull = false;
            }
            Amazon.Connect.ParticipantRole requestContactConfiguration_contactConfiguration_ParticipantRole = null;
            if (cmdletContext.ContactConfiguration_ParticipantRole != null)
            {
                requestContactConfiguration_contactConfiguration_ParticipantRole = cmdletContext.ContactConfiguration_ParticipantRole;
            }
            if (requestContactConfiguration_contactConfiguration_ParticipantRole != null)
            {
                request.ContactConfiguration.ParticipantRole = requestContactConfiguration_contactConfiguration_ParticipantRole;
                requestContactConfigurationIsNull = false;
            }
             // determine if request.ContactConfiguration should be set to null
            if (requestContactConfigurationIsNull)
            {
                request.ContactConfiguration = null;
            }
            if (cmdletContext.DeviceToken != null)
            {
                request.DeviceToken = cmdletContext.DeviceToken;
            }
            if (cmdletContext.DeviceType != null)
            {
                request.DeviceType = cmdletContext.DeviceType;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PinpointAppArn != null)
            {
                request.PinpointAppArn = cmdletContext.PinpointAppArn;
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
        
        private Amazon.Connect.Model.CreatePushNotificationRegistrationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreatePushNotificationRegistrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreatePushNotificationRegistration");
            try
            {
                #if DESKTOP
                return client.CreatePushNotificationRegistration(request);
                #elif CORECLR
                return client.CreatePushNotificationRegistrationAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ContactConfiguration_ContactId { get; set; }
            public System.Boolean? ContactConfiguration_IncludeRawMessage { get; set; }
            public Amazon.Connect.ParticipantRole ContactConfiguration_ParticipantRole { get; set; }
            public System.String DeviceToken { get; set; }
            public Amazon.Connect.DeviceType DeviceType { get; set; }
            public System.String InstanceId { get; set; }
            public System.String PinpointAppArn { get; set; }
            public System.Func<Amazon.Connect.Model.CreatePushNotificationRegistrationResponse, NewCONNPushNotificationRegistrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RegistrationId;
        }
        
    }
}
