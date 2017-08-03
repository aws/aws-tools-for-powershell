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
    /// Updates the specified user pool with the specified attributes.
    /// </summary>
    [Cmdlet("Update", "CGIPUserPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateUserPool operation against Amazon Cognito Identity Provider.", Operation = new[] {"UpdateUserPool"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the UserPoolId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCGIPUserPoolCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AdminCreateUserConfig_AllowAdminCreateUserOnly
        /// <summary>
        /// <para>
        /// <para>Set to <code>True</code> if only the administrator is allowed to create user profiles.
        /// Set to <code>False</code> if users can sign themselves up via an app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
        #endregion
        
        #region Parameter AutoVerifiedAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes that are automatically verified when the Amazon Cognito service makes
        /// a request to update user pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AutoVerifiedAttributes")]
        public System.String[] AutoVerifiedAttribute { get; set; }
        #endregion
        
        #region Parameter DeviceConfiguration_ChallengeRequiredOnNewDevice
        /// <summary>
        /// <para>
        /// <para>Indicates whether a challenge is required on a new device. Only applicable to a new
        /// device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CreateAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Creates an authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_CreateAuthChallenge { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CustomMessage
        /// <summary>
        /// <para>
        /// <para>A custom Message AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_CustomMessage { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_DefineAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Defines the authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_DefineAuthChallenge { get; set; }
        #endregion
        
        #region Parameter DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt
        /// <summary>
        /// <para>
        /// <para>If true, a device is only remembered on user prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The message template for email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailMessage")]
        public System.String InviteMessageTemplate_EmailMessage { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The subject line for email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailSubject")]
        public System.String InviteMessageTemplate_EmailSubject { get; set; }
        #endregion
        
        #region Parameter EmailVerificationMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the email verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailVerificationMessage { get; set; }
        #endregion
        
        #region Parameter EmailVerificationSubject
        /// <summary>
        /// <para>
        /// <para>The subject of the email verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailVerificationSubject { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SmsConfiguration_ExternalId { get; set; }
        #endregion
        
        #region Parameter MfaConfiguration
        /// <summary>
        /// <para>
        /// <para>Can be one of the following values:</para><ul><li><para><code>OFF</code> - MFA tokens are not required and cannot be specified during user
        /// registration.</para></li><li><para><code>ON</code> - MFA tokens are required for all user registrations. You can only
        /// specify required when you are initially creating a user pool.</para></li><li><para><code>OPTIONAL</code> - Users have the option when registering to create an MFA token.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.UserPoolMfaType")]
        public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_MinimumLength
        /// <summary>
        /// <para>
        /// <para>The minimum length of the password policy that you have set. Cannot be less than 6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Policies_PasswordPolicy_MinimumLength")]
        public System.Int32 PasswordPolicy_MinimumLength { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostAuthentication
        /// <summary>
        /// <para>
        /// <para>A post-authentication AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_PostAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostConfirmation
        /// <summary>
        /// <para>
        /// <para>A post-confirmation AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_PostConfirmation { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreAuthentication
        /// <summary>
        /// <para>
        /// <para>A pre-authentication AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_PreAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreSignUp
        /// <summary>
        /// <para>
        /// <para>A pre-registration AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_PreSignUp { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_ReplyToEmailAddress
        /// <summary>
        /// <para>
        /// <para>The REPLY-TO email address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailConfiguration_ReplyToEmailAddress { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireLowercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one lowercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Policies_PasswordPolicy_RequireLowercase")]
        public System.Boolean PasswordPolicy_RequireLowercase { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireNumber
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one number in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Policies_PasswordPolicy_RequireNumbers")]
        public System.Boolean PasswordPolicy_RequireNumber { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireSymbol
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one symbol in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Policies_PasswordPolicy_RequireSymbols")]
        public System.Boolean PasswordPolicy_RequireSymbol { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireUppercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one uppercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Policies_PasswordPolicy_RequireUppercase")]
        public System.Boolean PasswordPolicy_RequireUppercase { get; set; }
        #endregion
        
        #region Parameter SmsAuthenticationMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the SMS authentication message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SmsAuthenticationMessage { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_SMSMessage
        /// <summary>
        /// <para>
        /// <para>The message template for SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_SMSMessage")]
        public System.String InviteMessageTemplate_SMSMessage { get; set; }
        #endregion
        
        #region Parameter SmsVerificationMessage
        /// <summary>
        /// <para>
        /// <para>A container with information about the SMS verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SmsVerificationMessage { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_SnsCallerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) caller.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SmsConfiguration_SnsCallerArn { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the email source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailConfiguration_SourceArn { get; set; }
        #endregion
        
        #region Parameter AdminCreateUserConfig_UnusedAccountValidityDay
        /// <summary>
        /// <para>
        /// <para>The user account expiration limit, in days, after which the account is no longer usable.
        /// To reset the account after that time limit, you must call <code>AdminCreateUser</code>
        /// again, specifying <code>"RESEND"</code> for the <code>MessageAction</code> parameter.
        /// The default value for this parameter is 7.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AdminCreateUserConfig_UnusedAccountValidityDays")]
        public System.Int32 AdminCreateUserConfig_UnusedAccountValidityDay { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter UserPoolTag
        /// <summary>
        /// <para>
        /// <para>The cost allocation tags for the user pool. For more information, see <a href="http://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-pools-cost-allocation-tagging.html">Adding
        /// Cost Allocation Tags to Your User Pool</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserPoolTags")]
        public System.Collections.Hashtable UserPoolTag { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_VerifyAuthChallengeResponse
        /// <summary>
        /// <para>
        /// <para>Verifies the authentication challenge response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the UserPoolId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPUserPool (UpdateUserPool)"))
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
            
            if (ParameterWasBound("AdminCreateUserConfig_AllowAdminCreateUserOnly"))
                context.AdminCreateUserConfig_AllowAdminCreateUserOnly = this.AdminCreateUserConfig_AllowAdminCreateUserOnly;
            context.AdminCreateUserConfig_InviteMessageTemplate_EmailMessage = this.InviteMessageTemplate_EmailMessage;
            context.AdminCreateUserConfig_InviteMessageTemplate_EmailSubject = this.InviteMessageTemplate_EmailSubject;
            context.AdminCreateUserConfig_InviteMessageTemplate_SMSMessage = this.InviteMessageTemplate_SMSMessage;
            if (ParameterWasBound("AdminCreateUserConfig_UnusedAccountValidityDay"))
                context.AdminCreateUserConfig_UnusedAccountValidityDays = this.AdminCreateUserConfig_UnusedAccountValidityDay;
            if (this.AutoVerifiedAttribute != null)
            {
                context.AutoVerifiedAttributes = new List<System.String>(this.AutoVerifiedAttribute);
            }
            if (ParameterWasBound("DeviceConfiguration_ChallengeRequiredOnNewDevice"))
                context.DeviceConfiguration_ChallengeRequiredOnNewDevice = this.DeviceConfiguration_ChallengeRequiredOnNewDevice;
            if (ParameterWasBound("DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt"))
                context.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt = this.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt;
            context.EmailConfiguration_ReplyToEmailAddress = this.EmailConfiguration_ReplyToEmailAddress;
            context.EmailConfiguration_SourceArn = this.EmailConfiguration_SourceArn;
            context.EmailVerificationMessage = this.EmailVerificationMessage;
            context.EmailVerificationSubject = this.EmailVerificationSubject;
            context.LambdaConfig_CreateAuthChallenge = this.LambdaConfig_CreateAuthChallenge;
            context.LambdaConfig_CustomMessage = this.LambdaConfig_CustomMessage;
            context.LambdaConfig_DefineAuthChallenge = this.LambdaConfig_DefineAuthChallenge;
            context.LambdaConfig_PostAuthentication = this.LambdaConfig_PostAuthentication;
            context.LambdaConfig_PostConfirmation = this.LambdaConfig_PostConfirmation;
            context.LambdaConfig_PreAuthentication = this.LambdaConfig_PreAuthentication;
            context.LambdaConfig_PreSignUp = this.LambdaConfig_PreSignUp;
            context.LambdaConfig_VerifyAuthChallengeResponse = this.LambdaConfig_VerifyAuthChallengeResponse;
            context.MfaConfiguration = this.MfaConfiguration;
            if (ParameterWasBound("PasswordPolicy_MinimumLength"))
                context.Policies_PasswordPolicy_MinimumLength = this.PasswordPolicy_MinimumLength;
            if (ParameterWasBound("PasswordPolicy_RequireLowercase"))
                context.Policies_PasswordPolicy_RequireLowercase = this.PasswordPolicy_RequireLowercase;
            if (ParameterWasBound("PasswordPolicy_RequireNumber"))
                context.Policies_PasswordPolicy_RequireNumbers = this.PasswordPolicy_RequireNumber;
            if (ParameterWasBound("PasswordPolicy_RequireSymbol"))
                context.Policies_PasswordPolicy_RequireSymbols = this.PasswordPolicy_RequireSymbol;
            if (ParameterWasBound("PasswordPolicy_RequireUppercase"))
                context.Policies_PasswordPolicy_RequireUppercase = this.PasswordPolicy_RequireUppercase;
            context.SmsAuthenticationMessage = this.SmsAuthenticationMessage;
            context.SmsConfiguration_ExternalId = this.SmsConfiguration_ExternalId;
            context.SmsConfiguration_SnsCallerArn = this.SmsConfiguration_SnsCallerArn;
            context.SmsVerificationMessage = this.SmsVerificationMessage;
            context.UserPoolId = this.UserPoolId;
            if (this.UserPoolTag != null)
            {
                context.UserPoolTags = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserPoolTag.Keys)
                {
                    context.UserPoolTags.Add((String)hashKey, (String)(this.UserPoolTag[hashKey]));
                }
            }
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.UpdateUserPoolRequest();
            
            
             // populate AdminCreateUserConfig
            bool requestAdminCreateUserConfigIsNull = true;
            request.AdminCreateUserConfig = new Amazon.CognitoIdentityProvider.Model.AdminCreateUserConfigType();
            System.Boolean? requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly = null;
            if (cmdletContext.AdminCreateUserConfig_AllowAdminCreateUserOnly != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly = cmdletContext.AdminCreateUserConfig_AllowAdminCreateUserOnly.Value;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly != null)
            {
                request.AdminCreateUserConfig.AllowAdminCreateUserOnly = requestAdminCreateUserConfig_adminCreateUserConfig_AllowAdminCreateUserOnly.Value;
                requestAdminCreateUserConfigIsNull = false;
            }
            System.Int32? requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay = null;
            if (cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDays != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay = cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDays.Value;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay != null)
            {
                request.AdminCreateUserConfig.UnusedAccountValidityDays = requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay.Value;
                requestAdminCreateUserConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.MessageTemplateType requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = null;
            
             // populate InviteMessageTemplate
            bool requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = true;
            requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = new Amazon.CognitoIdentityProvider.Model.MessageTemplateType();
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = null;
            if (cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_EmailMessage;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailMessage = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = null;
            if (cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_EmailSubject;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailSubject = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = null;
            if (cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_SMSMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = cmdletContext.AdminCreateUserConfig_InviteMessageTemplate_SMSMessage;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.SMSMessage = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
             // determine if requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate should be set to null
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = null;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate != null)
            {
                request.AdminCreateUserConfig.InviteMessageTemplate = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate;
                requestAdminCreateUserConfigIsNull = false;
            }
             // determine if request.AdminCreateUserConfig should be set to null
            if (requestAdminCreateUserConfigIsNull)
            {
                request.AdminCreateUserConfig = null;
            }
            if (cmdletContext.AutoVerifiedAttributes != null)
            {
                request.AutoVerifiedAttributes = cmdletContext.AutoVerifiedAttributes;
            }
            
             // populate DeviceConfiguration
            bool requestDeviceConfigurationIsNull = true;
            request.DeviceConfiguration = new Amazon.CognitoIdentityProvider.Model.DeviceConfigurationType();
            System.Boolean? requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice = null;
            if (cmdletContext.DeviceConfiguration_ChallengeRequiredOnNewDevice != null)
            {
                requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice = cmdletContext.DeviceConfiguration_ChallengeRequiredOnNewDevice.Value;
            }
            if (requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice != null)
            {
                request.DeviceConfiguration.ChallengeRequiredOnNewDevice = requestDeviceConfiguration_deviceConfiguration_ChallengeRequiredOnNewDevice.Value;
                requestDeviceConfigurationIsNull = false;
            }
            System.Boolean? requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt = null;
            if (cmdletContext.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt != null)
            {
                requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt = cmdletContext.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt.Value;
            }
            if (requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt != null)
            {
                request.DeviceConfiguration.DeviceOnlyRememberedOnUserPrompt = requestDeviceConfiguration_deviceConfiguration_DeviceOnlyRememberedOnUserPrompt.Value;
                requestDeviceConfigurationIsNull = false;
            }
             // determine if request.DeviceConfiguration should be set to null
            if (requestDeviceConfigurationIsNull)
            {
                request.DeviceConfiguration = null;
            }
            
             // populate EmailConfiguration
            bool requestEmailConfigurationIsNull = true;
            request.EmailConfiguration = new Amazon.CognitoIdentityProvider.Model.EmailConfigurationType();
            System.String requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress = null;
            if (cmdletContext.EmailConfiguration_ReplyToEmailAddress != null)
            {
                requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress = cmdletContext.EmailConfiguration_ReplyToEmailAddress;
            }
            if (requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress != null)
            {
                request.EmailConfiguration.ReplyToEmailAddress = requestEmailConfiguration_emailConfiguration_ReplyToEmailAddress;
                requestEmailConfigurationIsNull = false;
            }
            System.String requestEmailConfiguration_emailConfiguration_SourceArn = null;
            if (cmdletContext.EmailConfiguration_SourceArn != null)
            {
                requestEmailConfiguration_emailConfiguration_SourceArn = cmdletContext.EmailConfiguration_SourceArn;
            }
            if (requestEmailConfiguration_emailConfiguration_SourceArn != null)
            {
                request.EmailConfiguration.SourceArn = requestEmailConfiguration_emailConfiguration_SourceArn;
                requestEmailConfigurationIsNull = false;
            }
             // determine if request.EmailConfiguration should be set to null
            if (requestEmailConfigurationIsNull)
            {
                request.EmailConfiguration = null;
            }
            if (cmdletContext.EmailVerificationMessage != null)
            {
                request.EmailVerificationMessage = cmdletContext.EmailVerificationMessage;
            }
            if (cmdletContext.EmailVerificationSubject != null)
            {
                request.EmailVerificationSubject = cmdletContext.EmailVerificationSubject;
            }
            
             // populate LambdaConfig
            bool requestLambdaConfigIsNull = true;
            request.LambdaConfig = new Amazon.CognitoIdentityProvider.Model.LambdaConfigType();
            System.String requestLambdaConfig_lambdaConfig_CreateAuthChallenge = null;
            if (cmdletContext.LambdaConfig_CreateAuthChallenge != null)
            {
                requestLambdaConfig_lambdaConfig_CreateAuthChallenge = cmdletContext.LambdaConfig_CreateAuthChallenge;
            }
            if (requestLambdaConfig_lambdaConfig_CreateAuthChallenge != null)
            {
                request.LambdaConfig.CreateAuthChallenge = requestLambdaConfig_lambdaConfig_CreateAuthChallenge;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_CustomMessage = null;
            if (cmdletContext.LambdaConfig_CustomMessage != null)
            {
                requestLambdaConfig_lambdaConfig_CustomMessage = cmdletContext.LambdaConfig_CustomMessage;
            }
            if (requestLambdaConfig_lambdaConfig_CustomMessage != null)
            {
                request.LambdaConfig.CustomMessage = requestLambdaConfig_lambdaConfig_CustomMessage;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_DefineAuthChallenge = null;
            if (cmdletContext.LambdaConfig_DefineAuthChallenge != null)
            {
                requestLambdaConfig_lambdaConfig_DefineAuthChallenge = cmdletContext.LambdaConfig_DefineAuthChallenge;
            }
            if (requestLambdaConfig_lambdaConfig_DefineAuthChallenge != null)
            {
                request.LambdaConfig.DefineAuthChallenge = requestLambdaConfig_lambdaConfig_DefineAuthChallenge;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PostAuthentication = null;
            if (cmdletContext.LambdaConfig_PostAuthentication != null)
            {
                requestLambdaConfig_lambdaConfig_PostAuthentication = cmdletContext.LambdaConfig_PostAuthentication;
            }
            if (requestLambdaConfig_lambdaConfig_PostAuthentication != null)
            {
                request.LambdaConfig.PostAuthentication = requestLambdaConfig_lambdaConfig_PostAuthentication;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PostConfirmation = null;
            if (cmdletContext.LambdaConfig_PostConfirmation != null)
            {
                requestLambdaConfig_lambdaConfig_PostConfirmation = cmdletContext.LambdaConfig_PostConfirmation;
            }
            if (requestLambdaConfig_lambdaConfig_PostConfirmation != null)
            {
                request.LambdaConfig.PostConfirmation = requestLambdaConfig_lambdaConfig_PostConfirmation;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PreAuthentication = null;
            if (cmdletContext.LambdaConfig_PreAuthentication != null)
            {
                requestLambdaConfig_lambdaConfig_PreAuthentication = cmdletContext.LambdaConfig_PreAuthentication;
            }
            if (requestLambdaConfig_lambdaConfig_PreAuthentication != null)
            {
                request.LambdaConfig.PreAuthentication = requestLambdaConfig_lambdaConfig_PreAuthentication;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_PreSignUp = null;
            if (cmdletContext.LambdaConfig_PreSignUp != null)
            {
                requestLambdaConfig_lambdaConfig_PreSignUp = cmdletContext.LambdaConfig_PreSignUp;
            }
            if (requestLambdaConfig_lambdaConfig_PreSignUp != null)
            {
                request.LambdaConfig.PreSignUp = requestLambdaConfig_lambdaConfig_PreSignUp;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse = null;
            if (cmdletContext.LambdaConfig_VerifyAuthChallengeResponse != null)
            {
                requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse = cmdletContext.LambdaConfig_VerifyAuthChallengeResponse;
            }
            if (requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse != null)
            {
                request.LambdaConfig.VerifyAuthChallengeResponse = requestLambdaConfig_lambdaConfig_VerifyAuthChallengeResponse;
                requestLambdaConfigIsNull = false;
            }
             // determine if request.LambdaConfig should be set to null
            if (requestLambdaConfigIsNull)
            {
                request.LambdaConfig = null;
            }
            if (cmdletContext.MfaConfiguration != null)
            {
                request.MfaConfiguration = cmdletContext.MfaConfiguration;
            }
            
             // populate Policies
            bool requestPoliciesIsNull = true;
            request.Policies = new Amazon.CognitoIdentityProvider.Model.UserPoolPolicyType();
            Amazon.CognitoIdentityProvider.Model.PasswordPolicyType requestPolicies_policies_PasswordPolicy = null;
            
             // populate PasswordPolicy
            bool requestPolicies_policies_PasswordPolicyIsNull = true;
            requestPolicies_policies_PasswordPolicy = new Amazon.CognitoIdentityProvider.Model.PasswordPolicyType();
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = null;
            if (cmdletContext.Policies_PasswordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = cmdletContext.Policies_PasswordPolicy_MinimumLength.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy.MinimumLength = requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = null;
            if (cmdletContext.Policies_PasswordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = cmdletContext.Policies_PasswordPolicy_RequireLowercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireLowercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = null;
            if (cmdletContext.Policies_PasswordPolicy_RequireNumbers != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = cmdletContext.Policies_PasswordPolicy_RequireNumbers.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireNumbers = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = null;
            if (cmdletContext.Policies_PasswordPolicy_RequireSymbols != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = cmdletContext.Policies_PasswordPolicy_RequireSymbols.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireSymbols = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = null;
            if (cmdletContext.Policies_PasswordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = cmdletContext.Policies_PasswordPolicy_RequireUppercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireUppercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
             // determine if requestPolicies_policies_PasswordPolicy should be set to null
            if (requestPolicies_policies_PasswordPolicyIsNull)
            {
                requestPolicies_policies_PasswordPolicy = null;
            }
            if (requestPolicies_policies_PasswordPolicy != null)
            {
                request.Policies.PasswordPolicy = requestPolicies_policies_PasswordPolicy;
                requestPoliciesIsNull = false;
            }
             // determine if request.Policies should be set to null
            if (requestPoliciesIsNull)
            {
                request.Policies = null;
            }
            if (cmdletContext.SmsAuthenticationMessage != null)
            {
                request.SmsAuthenticationMessage = cmdletContext.SmsAuthenticationMessage;
            }
            
             // populate SmsConfiguration
            bool requestSmsConfigurationIsNull = true;
            request.SmsConfiguration = new Amazon.CognitoIdentityProvider.Model.SmsConfigurationType();
            System.String requestSmsConfiguration_smsConfiguration_ExternalId = null;
            if (cmdletContext.SmsConfiguration_ExternalId != null)
            {
                requestSmsConfiguration_smsConfiguration_ExternalId = cmdletContext.SmsConfiguration_ExternalId;
            }
            if (requestSmsConfiguration_smsConfiguration_ExternalId != null)
            {
                request.SmsConfiguration.ExternalId = requestSmsConfiguration_smsConfiguration_ExternalId;
                requestSmsConfigurationIsNull = false;
            }
            System.String requestSmsConfiguration_smsConfiguration_SnsCallerArn = null;
            if (cmdletContext.SmsConfiguration_SnsCallerArn != null)
            {
                requestSmsConfiguration_smsConfiguration_SnsCallerArn = cmdletContext.SmsConfiguration_SnsCallerArn;
            }
            if (requestSmsConfiguration_smsConfiguration_SnsCallerArn != null)
            {
                request.SmsConfiguration.SnsCallerArn = requestSmsConfiguration_smsConfiguration_SnsCallerArn;
                requestSmsConfigurationIsNull = false;
            }
             // determine if request.SmsConfiguration should be set to null
            if (requestSmsConfigurationIsNull)
            {
                request.SmsConfiguration = null;
            }
            if (cmdletContext.SmsVerificationMessage != null)
            {
                request.SmsVerificationMessage = cmdletContext.SmsVerificationMessage;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.UserPoolTags != null)
            {
                request.UserPoolTags = cmdletContext.UserPoolTags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateUserPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateUserPool");
            #if DESKTOP
            return client.UpdateUserPool(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateUserPoolAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.Boolean? AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
            public System.String AdminCreateUserConfig_InviteMessageTemplate_EmailMessage { get; set; }
            public System.String AdminCreateUserConfig_InviteMessageTemplate_EmailSubject { get; set; }
            public System.String AdminCreateUserConfig_InviteMessageTemplate_SMSMessage { get; set; }
            public System.Int32? AdminCreateUserConfig_UnusedAccountValidityDays { get; set; }
            public List<System.String> AutoVerifiedAttributes { get; set; }
            public System.Boolean? DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
            public System.Boolean? DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
            public System.String EmailConfiguration_ReplyToEmailAddress { get; set; }
            public System.String EmailConfiguration_SourceArn { get; set; }
            public System.String EmailVerificationMessage { get; set; }
            public System.String EmailVerificationSubject { get; set; }
            public System.String LambdaConfig_CreateAuthChallenge { get; set; }
            public System.String LambdaConfig_CustomMessage { get; set; }
            public System.String LambdaConfig_DefineAuthChallenge { get; set; }
            public System.String LambdaConfig_PostAuthentication { get; set; }
            public System.String LambdaConfig_PostConfirmation { get; set; }
            public System.String LambdaConfig_PreAuthentication { get; set; }
            public System.String LambdaConfig_PreSignUp { get; set; }
            public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
            public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
            public System.Int32? Policies_PasswordPolicy_MinimumLength { get; set; }
            public System.Boolean? Policies_PasswordPolicy_RequireLowercase { get; set; }
            public System.Boolean? Policies_PasswordPolicy_RequireNumbers { get; set; }
            public System.Boolean? Policies_PasswordPolicy_RequireSymbols { get; set; }
            public System.Boolean? Policies_PasswordPolicy_RequireUppercase { get; set; }
            public System.String SmsAuthenticationMessage { get; set; }
            public System.String SmsConfiguration_ExternalId { get; set; }
            public System.String SmsConfiguration_SnsCallerArn { get; set; }
            public System.String SmsVerificationMessage { get; set; }
            public System.String UserPoolId { get; set; }
            public Dictionary<System.String, System.String> UserPoolTags { get; set; }
        }
        
    }
}
