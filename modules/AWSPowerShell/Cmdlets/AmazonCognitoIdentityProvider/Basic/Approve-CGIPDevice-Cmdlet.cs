/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Invokes the ConfirmDevice operation against Amazon Cognito Identity Provider.", Operation = new[] {"ConfirmDevice"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ApproveCGIPDeviceCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>The access token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter DeviceKey
        /// <summary>
        /// <para>
        /// <para>The device key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DeviceKey { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The device name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter DeviceSecretVerifierConfig_PasswordVerifier
        /// <summary>
        /// <para>
        /// <para>The password verifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceSecretVerifierConfig_PasswordVerifier { get; set; }
        #endregion
        
        #region Parameter DeviceSecretVerifierConfig_Salt
        /// <summary>
        /// <para>
        /// <para>The salt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceSecretVerifierConfig_Salt { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeviceName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Approve-CGIPDevice (ConfirmDevice)"))
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
            
            context.AccessToken = this.AccessToken;
            context.DeviceKey = this.DeviceKey;
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
            bool requestDeviceSecretVerifierConfigIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.UserConfirmationNecessary;
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
        
        private Amazon.CognitoIdentityProvider.Model.ConfirmDeviceResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.ConfirmDeviceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "ConfirmDevice");
            #if DESKTOP
            return client.ConfirmDevice(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ConfirmDeviceAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AccessToken { get; set; }
            public System.String DeviceKey { get; set; }
            public System.String DeviceName { get; set; }
            public System.String DeviceSecretVerifierConfig_PasswordVerifier { get; set; }
            public System.String DeviceSecretVerifierConfig_Salt { get; set; }
        }
        
    }
}
