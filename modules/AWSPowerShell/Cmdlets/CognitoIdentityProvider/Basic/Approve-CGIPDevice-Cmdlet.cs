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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Confirms tracking of the device. This API call is the call that begins device tracking.
    /// </summary>
    [Cmdlet("Approve", "CGIPDevice", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider ConfirmDevice API operation.", Operation = new[] {"ConfirmDevice"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveCGIPDeviceCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>A valid access token that Amazon Cognito issued to the user whose device you want
        /// to confirm.</para>
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
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter DeviceKey
        /// <summary>
        /// <para>
        /// <para>The device key.</para>
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
        public System.String DeviceKey { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The device name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter DeviceSecretVerifierConfig_PasswordVerifier
        /// <summary>
        /// <para>
        /// <para>The password verifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceSecretVerifierConfig_PasswordVerifier { get; set; }
        #endregion
        
        #region Parameter DeviceSecretVerifierConfig_Salt
        /// <summary>
        /// <para>
        /// <para>The <a href="https://en.wikipedia.org/wiki/Salt_(cryptography)">salt</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceSecretVerifierConfig_Salt { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserConfirmationNecessary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserConfirmationNecessary";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DeviceKey parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DeviceKey' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DeviceKey' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DeviceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-CGIPDevice (ConfirmDevice)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse, ApproveCGIPDeviceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DeviceKey;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessToken = this.AccessToken;
            #if MODULAR
            if (this.AccessToken == null && ParameterWasBound(nameof(this.AccessToken)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceKey = this.DeviceKey;
            #if MODULAR
            if (this.DeviceKey == null && ParameterWasBound(nameof(this.DeviceKey)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DeviceName = this.DeviceName;
            context.DeviceSecretVerifierConfig_PasswordVerifier = this.DeviceSecretVerifierConfig_PasswordVerifier;
            context.DeviceSecretVerifierConfig_Salt = this.DeviceSecretVerifierConfig_Salt;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.ConfirmDeviceRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            if (cmdletContext.DeviceKey != null)
            {
                request.DeviceKey = cmdletContext.DeviceKey;
            }
            if (cmdletContext.DeviceName != null)
            {
                request.DeviceName = cmdletContext.DeviceName;
            }
            
             // populate DeviceSecretVerifierConfig
            var requestDeviceSecretVerifierConfigIsNull = true;
            request.DeviceSecretVerifierConfig = new Amazon.CognitoIdentityProvider.Model.DeviceSecretVerifierConfigType();
            System.String requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_PasswordVerifier = null;
            if (cmdletContext.DeviceSecretVerifierConfig_PasswordVerifier != null)
            {
                requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_PasswordVerifier = cmdletContext.DeviceSecretVerifierConfig_PasswordVerifier;
            }
            if (requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_PasswordVerifier != null)
            {
                request.DeviceSecretVerifierConfig.PasswordVerifier = requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_PasswordVerifier;
                requestDeviceSecretVerifierConfigIsNull = false;
            }
            System.String requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_Salt = null;
            if (cmdletContext.DeviceSecretVerifierConfig_Salt != null)
            {
                requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_Salt = cmdletContext.DeviceSecretVerifierConfig_Salt;
            }
            if (requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_Salt != null)
            {
                request.DeviceSecretVerifierConfig.Salt = requestDeviceSecretVerifierConfig_deviceSecretVerifierConfig_Salt;
                requestDeviceSecretVerifierConfigIsNull = false;
            }
             // determine if request.DeviceSecretVerifierConfig should be set to null
            if (requestDeviceSecretVerifierConfigIsNull)
            {
                request.DeviceSecretVerifierConfig = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.ConfirmDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "ConfirmDevice");
            try
            {
                #if DESKTOP
                return client.ConfirmDevice(request);
                #elif CORECLR
                return client.ConfirmDeviceAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessToken { get; set; }
            public System.String DeviceKey { get; set; }
            public System.String DeviceName { get; set; }
            public System.String DeviceSecretVerifierConfig_PasswordVerifier { get; set; }
            public System.String DeviceSecretVerifierConfig_Salt { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse, ApproveCGIPDeviceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserConfirmationNecessary;
        }
        
    }
}
