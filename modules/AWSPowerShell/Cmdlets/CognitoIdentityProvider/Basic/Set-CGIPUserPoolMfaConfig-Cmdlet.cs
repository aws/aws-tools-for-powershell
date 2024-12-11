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
    /// Sets the user pool multi-factor authentication (MFA) configuration.
    /// 
    ///  <note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, US telecom
    /// carriers require you to register an origination phone number before you can send SMS
    /// messages to US phone numbers. If you use SMS text messages in Amazon Cognito, you
    /// must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Amazon Cognito uses the registered number automatically. Otherwise,
    /// Amazon Cognito users who must receive SMS messages might not be able to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other Amazon Web
    /// Servicesservice, Amazon Simple Notification Service might place your account in the
    /// SMS sandbox. In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you can send messages only to verified phone numbers. After you test
    /// your app while in the sandbox environment, you can move out of the sandbox and into
    /// production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-sms-settings.html">
    /// SMS message settings for Amazon Cognito user pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "CGIPUserPoolMfaConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetUserPoolMfaConfig API operation.", Operation = new[] {"SetUserPoolMfaConfig"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse object containing multiple properties."
    )]
    public partial class SetCGIPUserPoolMfaConfigCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmailMfaConfiguration_Message
        /// <summary>
        /// <para>
        /// <para>The template for the email message that your user pool sends to users with an MFA
        /// code. The message must contain the <c>{####}</c> placeholder. In the message, Amazon
        /// Cognito replaces this placeholder with the code. If you don't provide this parameter,
        /// Amazon Cognito sends messages in the default format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailMfaConfiguration_Message { get; set; }
        #endregion
        
        #region Parameter MfaConfiguration
        /// <summary>
        /// <para>
        /// <para>The MFA configuration. If you set the MfaConfiguration value to ‘ON’, only users who
        /// have set up an MFA factor can sign in. To learn more, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-settings-mfa.html">Adding
        /// Multi-Factor Authentication (MFA) to a user pool</a>. Valid values include:</para><ul><li><para><c>OFF</c> MFA won't be used for any users.</para></li><li><para><c>ON</c> MFA is required for all users to sign in.</para></li><li><para><c>OPTIONAL</c> MFA will be required only for individual users who have an MFA factor
        /// activated.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.UserPoolMfaType")]
        public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
        #endregion
        
        #region Parameter SmsMfaConfiguration
        /// <summary>
        /// <para>
        /// <para>Configures user pool SMS messages for MFA. Sets the message template and the SMS message
        /// sending configuration for Amazon SNS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CognitoIdentityProvider.Model.SmsMfaConfigType SmsMfaConfiguration { get; set; }
        #endregion
        
        #region Parameter SoftwareTokenMfaConfiguration
        /// <summary>
        /// <para>
        /// <para>Configures a user pool for time-based one-time password (TOTP) MFA. Enables or disables
        /// TOTP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CognitoIdentityProvider.Model.SoftwareTokenMfaConfigType SoftwareTokenMfaConfiguration { get; set; }
        #endregion
        
        #region Parameter EmailMfaConfiguration_Subject
        /// <summary>
        /// <para>
        /// <para>The subject of the email message that your user pool sends to users with an MFA code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailMfaConfiguration_Subject { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUserPoolMfaConfig (SetUserPoolMfaConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse, SetCGIPUserPoolMfaConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EmailMfaConfiguration_Message = this.EmailMfaConfiguration_Message;
            context.EmailMfaConfiguration_Subject = this.EmailMfaConfiguration_Subject;
            context.MfaConfiguration = this.MfaConfiguration;
            context.SmsMfaConfiguration = this.SmsMfaConfiguration;
            context.SoftwareTokenMfaConfiguration = this.SoftwareTokenMfaConfiguration;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigRequest();
            
            
             // populate EmailMfaConfiguration
            var requestEmailMfaConfigurationIsNull = true;
            request.EmailMfaConfiguration = new Amazon.CognitoIdentityProvider.Model.EmailMfaConfigType();
            System.String requestEmailMfaConfiguration_emailMfaConfiguration_Message = null;
            if (cmdletContext.EmailMfaConfiguration_Message != null)
            {
                requestEmailMfaConfiguration_emailMfaConfiguration_Message = cmdletContext.EmailMfaConfiguration_Message;
            }
            if (requestEmailMfaConfiguration_emailMfaConfiguration_Message != null)
            {
                request.EmailMfaConfiguration.Message = requestEmailMfaConfiguration_emailMfaConfiguration_Message;
                requestEmailMfaConfigurationIsNull = false;
            }
            System.String requestEmailMfaConfiguration_emailMfaConfiguration_Subject = null;
            if (cmdletContext.EmailMfaConfiguration_Subject != null)
            {
                requestEmailMfaConfiguration_emailMfaConfiguration_Subject = cmdletContext.EmailMfaConfiguration_Subject;
            }
            if (requestEmailMfaConfiguration_emailMfaConfiguration_Subject != null)
            {
                request.EmailMfaConfiguration.Subject = requestEmailMfaConfiguration_emailMfaConfiguration_Subject;
                requestEmailMfaConfigurationIsNull = false;
            }
             // determine if request.EmailMfaConfiguration should be set to null
            if (requestEmailMfaConfigurationIsNull)
            {
                request.EmailMfaConfiguration = null;
            }
            if (cmdletContext.MfaConfiguration != null)
            {
                request.MfaConfiguration = cmdletContext.MfaConfiguration;
            }
            if (cmdletContext.SmsMfaConfiguration != null)
            {
                request.SmsMfaConfiguration = cmdletContext.SmsMfaConfiguration;
            }
            if (cmdletContext.SoftwareTokenMfaConfiguration != null)
            {
                request.SoftwareTokenMfaConfiguration = cmdletContext.SoftwareTokenMfaConfiguration;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetUserPoolMfaConfig");
            try
            {
                #if DESKTOP
                return client.SetUserPoolMfaConfig(request);
                #elif CORECLR
                return client.SetUserPoolMfaConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String EmailMfaConfiguration_Message { get; set; }
            public System.String EmailMfaConfiguration_Subject { get; set; }
            public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
            public Amazon.CognitoIdentityProvider.Model.SmsMfaConfigType SmsMfaConfiguration { get; set; }
            public Amazon.CognitoIdentityProvider.Model.SoftwareTokenMfaConfigType SoftwareTokenMfaConfiguration { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetUserPoolMfaConfigResponse, SetCGIPUserPoolMfaConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
