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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Set the user's multi-factor authentication (MFA) method preference, including which
    /// MFA factors are activated and if any are preferred. Only one factor can be set as
    /// preferred. The preferred MFA factor will be used to authenticate a user if multiple
    /// factors are activated. If multiple options are activated and no preference is set,
    /// a challenge to choose an MFA option will be returned during sign-in. If an MFA type
    /// is activated for a user, the user will be prompted for MFA during all sign-in attempts
    /// unless device tracking is turned on and the device has been trusted. If you want MFA
    /// to be applied selectively based on the assessed risk level of sign-in attempts, deactivate
    /// MFA for users and turn on Adaptive Authentication for the user pool.
    /// 
    ///  
    /// <para>
    /// Authorize this action with a signed-in user's access token. It must include the scope
    /// <c>aws.cognito.signin.user.admin</c>.
    /// </para><note><para>
    /// Amazon Cognito doesn't evaluate Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you can't use IAM credentials to authorize
    /// requests, and you can't grant IAM permissions in policies. For more information about
    /// authorization models in Amazon Cognito, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Set", "CGIPUserMFAPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetUserMFAPreference API operation.", Operation = new[] {"SetUserMFAPreference"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetCGIPUserMFAPreferenceCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>A valid access token that Amazon Cognito issued to the currently signed-in user. Must
        /// include a scope claim for <c>aws.cognito.signin.user.admin</c>.</para>
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
        
        #region Parameter EmailMfaSettings_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether email message MFA is active for a user. When the value of this parameter
        /// is <c>Enabled</c>, the user will be prompted for MFA during all sign-in attempts,
        /// unless device tracking is turned on and the device has been trusted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EmailMfaSettings_Enabled { get; set; }
        #endregion
        
        #region Parameter EmailMfaSettings_PreferredMfa
        /// <summary>
        /// <para>
        /// <para>Specifies whether email message MFA is the user's preferred method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EmailMfaSettings_PreferredMfa { get; set; }
        #endregion
        
        #region Parameter SMSMfaSetting
        /// <summary>
        /// <para>
        /// <para>User preferences for SMS message MFA. Activates or deactivates SMS MFA and sets it
        /// as the preferred MFA method when multiple methods are available.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SMSMfaSettings")]
        public Amazon.CognitoIdentityProvider.Model.SMSMfaSettingsType SMSMfaSetting { get; set; }
        #endregion
        
        #region Parameter SoftwareTokenMfaSetting
        /// <summary>
        /// <para>
        /// <para>User preferences for time-based one-time password (TOTP) MFA. Activates or deactivates
        /// TOTP MFA and sets it as the preferred MFA method when multiple methods are available.
        /// Users must register a TOTP authenticator before they set this as their preferred MFA
        /// method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SoftwareTokenMfaSettings")]
        public Amazon.CognitoIdentityProvider.Model.SoftwareTokenMfaSettingsType SoftwareTokenMfaSetting { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPUserMFAPreference (SetUserMFAPreference)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse, SetCGIPUserMFAPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessToken = this.AccessToken;
            #if MODULAR
            if (this.AccessToken == null && ParameterWasBound(nameof(this.AccessToken)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMfaSettings_Enabled = this.EmailMfaSettings_Enabled;
            context.EmailMfaSettings_PreferredMfa = this.EmailMfaSettings_PreferredMfa;
            context.SMSMfaSetting = this.SMSMfaSetting;
            context.SoftwareTokenMfaSetting = this.SoftwareTokenMfaSetting;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            
             // populate EmailMfaSettings
            var requestEmailMfaSettingsIsNull = true;
            request.EmailMfaSettings = new Amazon.CognitoIdentityProvider.Model.EmailMfaSettingsType();
            System.Boolean? requestEmailMfaSettings_emailMfaSettings_Enabled = null;
            if (cmdletContext.EmailMfaSettings_Enabled != null)
            {
                requestEmailMfaSettings_emailMfaSettings_Enabled = cmdletContext.EmailMfaSettings_Enabled.Value;
            }
            if (requestEmailMfaSettings_emailMfaSettings_Enabled != null)
            {
                request.EmailMfaSettings.Enabled = requestEmailMfaSettings_emailMfaSettings_Enabled.Value;
                requestEmailMfaSettingsIsNull = false;
            }
            System.Boolean? requestEmailMfaSettings_emailMfaSettings_PreferredMfa = null;
            if (cmdletContext.EmailMfaSettings_PreferredMfa != null)
            {
                requestEmailMfaSettings_emailMfaSettings_PreferredMfa = cmdletContext.EmailMfaSettings_PreferredMfa.Value;
            }
            if (requestEmailMfaSettings_emailMfaSettings_PreferredMfa != null)
            {
                request.EmailMfaSettings.PreferredMfa = requestEmailMfaSettings_emailMfaSettings_PreferredMfa.Value;
                requestEmailMfaSettingsIsNull = false;
            }
             // determine if request.EmailMfaSettings should be set to null
            if (requestEmailMfaSettingsIsNull)
            {
                request.EmailMfaSettings = null;
            }
            if (cmdletContext.SMSMfaSetting != null)
            {
                request.SMSMfaSettings = cmdletContext.SMSMfaSetting;
            }
            if (cmdletContext.SoftwareTokenMfaSetting != null)
            {
                request.SoftwareTokenMfaSettings = cmdletContext.SoftwareTokenMfaSetting;
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
        
        private Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetUserMFAPreference");
            try
            {
                return client.SetUserMFAPreferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? EmailMfaSettings_Enabled { get; set; }
            public System.Boolean? EmailMfaSettings_PreferredMfa { get; set; }
            public Amazon.CognitoIdentityProvider.Model.SMSMfaSettingsType SMSMfaSetting { get; set; }
            public Amazon.CognitoIdentityProvider.Model.SoftwareTokenMfaSettingsType SoftwareTokenMfaSetting { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetUserMFAPreferenceResponse, SetCGIPUserMFAPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
