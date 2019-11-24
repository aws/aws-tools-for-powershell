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
    /// Updates the specified user pool with the specified attributes. You can get a list
    /// of the current user pool settings with .
    /// 
    ///  <important><para>
    /// If you don't provide a value for an attribute, it will be set to the default value.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "CGIPUserPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider UpdateUserPool API operation.", Operation = new[] {"UpdateUserPool"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse))]
    [AWSCmdletOutput("None or Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCGIPUserPoolCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter UserPoolAddOns_AdvancedSecurityMode
        /// <summary>
        /// <para>
        /// <para>The advanced security mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AdvancedSecurityModeType")]
        public Amazon.CognitoIdentityProvider.AdvancedSecurityModeType UserPoolAddOns_AdvancedSecurityMode { get; set; }
        #endregion
        
        #region Parameter AdminCreateUserConfig_AllowAdminCreateUserOnly
        /// <summary>
        /// <para>
        /// <para>Set to <code>True</code> if only the administrator is allowed to create user profiles.
        /// Set to <code>False</code> if users can sign themselves up via an app.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
        #endregion
        
        #region Parameter AutoVerifiedAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes that are automatically verified when the Amazon Cognito service makes
        /// a request to update user pools.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_ConfigurationSet
        /// <summary>
        /// <para>
        /// <para>The set of configuration rules that can be applied to emails sent using Amazon SES.
        /// A configuration set is applied to an email by including a reference to the configuration
        /// set in the headers of the email. Once applied, all of the rules in that configuration
        /// set are applied to the email. Configuration sets can be used to apply the following
        /// types of rules to emails: </para><ul><li><para>Event publishing – Amazon SES can track the number of send, delivery, open, click,
        /// bounce, and complaint events for each email sent. Use event publishing to send information
        /// about these events to other AWS services such as SNS and CloudWatch.</para></li><li><para>IP pool management – When leasing dedicated IP addresses with Amazon SES, you can
        /// create groups of IP addresses, called dedicated IP pools. You can then associate the
        /// dedicated IP pools with configuration sets.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_ConfigurationSet { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CreateAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Creates an authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_CreateAuthChallenge { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_CustomMessage
        /// <summary>
        /// <para>
        /// <para>A custom Message AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_CustomMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_DefaultEmailOption
        /// <summary>
        /// <para>
        /// <para>The default email option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.DefaultEmailOptionType")]
        public Amazon.CognitoIdentityProvider.DefaultEmailOptionType VerificationMessageTemplate_DefaultEmailOption { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_DefineAuthChallenge
        /// <summary>
        /// <para>
        /// <para>Defines the authentication challenge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_DefineAuthChallenge { get; set; }
        #endregion
        
        #region Parameter DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt
        /// <summary>
        /// <para>
        /// <para>If true, a device is only remembered on user prompt.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The message template for email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailMessage")]
        public System.String InviteMessageTemplate_EmailMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailMessage
        /// <summary>
        /// <para>
        /// <para>The email message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailMessageByLink
        /// <summary>
        /// <para>
        /// <para>The email message template for sending a confirmation link to the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailMessageByLink { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_EmailSendingAccount
        /// <summary>
        /// <para>
        /// <para>Specifies whether Amazon Cognito emails your users by using its built-in email functionality
        /// or your Amazon SES email configuration. Specify one of the following values:</para><dl><dt>COGNITO_DEFAULT</dt><dd><para>When Amazon Cognito emails your users, it uses its built-in email functionality. When
        /// you use the default option, Amazon Cognito allows only a limited number of emails
        /// each day for your user pool. For typical production environments, the default email
        /// limit is below the required delivery volume. To achieve a higher delivery volume,
        /// specify DEVELOPER to use your Amazon SES email configuration.</para><para>To look up the email delivery limit for the default option, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/limits.html">Limits
        /// in Amazon Cognito</a> in the <i>Amazon Cognito Developer Guide</i>.</para><para>The default FROM address is no-reply@verificationemail.com. To customize the FROM
        /// address, provide the ARN of an Amazon SES verified email address for the <code>SourceArn</code>
        /// parameter.</para></dd><dt>DEVELOPER</dt><dd><para>When Amazon Cognito emails your users, it uses your Amazon SES configuration. Amazon
        /// Cognito calls Amazon SES on your behalf to send email from your verified email address.
        /// When you use this option, the email delivery limits are the same limits that apply
        /// to your Amazon SES verified email address in your AWS account.</para><para>If you use this option, you must provide the ARN of an Amazon SES verified email address
        /// for the <code>SourceArn</code> parameter.</para><para>Before Amazon Cognito can email your users, it requires additional permissions to
        /// call Amazon SES on your behalf. When you update your user pool with this option, Amazon
        /// Cognito creates a <i>service-linked role</i>, which is a type of IAM role, in your
        /// AWS account. This role contains the permissions that allow Amazon Cognito to access
        /// Amazon SES and send email messages with your address. For more information about the
        /// service-linked role that Amazon Cognito creates, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/using-service-linked-roles.html">Using
        /// Service-Linked Roles for Amazon Cognito</a> in the <i>Amazon Cognito Developer Guide</i>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.EmailSendingAccountType")]
        public Amazon.CognitoIdentityProvider.EmailSendingAccountType EmailConfiguration_EmailSendingAccount { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The subject line for email messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_EmailSubject")]
        public System.String InviteMessageTemplate_EmailSubject { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailSubject
        /// <summary>
        /// <para>
        /// <para>The subject line for the email message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailSubject { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_EmailSubjectByLink
        /// <summary>
        /// <para>
        /// <para>The subject line for the email message template for sending a confirmation link to
        /// the user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_EmailSubjectByLink { get; set; }
        #endregion
        
        #region Parameter EmailVerificationMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the email verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailVerificationMessage { get; set; }
        #endregion
        
        #region Parameter EmailVerificationSubject
        /// <summary>
        /// <para>
        /// <para>The subject of the email verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailVerificationSubject { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID is a value that we recommend you use to add security to your IAM role
        /// which is used to call Amazon SNS to send SMS messages for your user pool. If you provide
        /// an <code>ExternalId</code>, the Cognito User Pool will include it when attempting
        /// to assume your IAM role, so that you can set your roles trust policy to require the
        /// <code>ExternalID</code>. If you use the Cognito Management Console to create a role
        /// for SMS MFA, Cognito will create a role with the required permissions and a trust
        /// policy that demonstrates use of the <code>ExternalId</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsConfiguration_ExternalId { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_From
        /// <summary>
        /// <para>
        /// <para>Identifies either the sender’s email address or the sender’s name with their email
        /// address. For example, <code>testuser@example.com</code> or <code>Test User &lt;testuser@example.com&gt;</code>.
        /// This address will appear before the body of the email.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_From { get; set; }
        #endregion
        
        #region Parameter MfaConfiguration
        /// <summary>
        /// <para>
        /// <para>Can be one of the following values:</para><ul><li><para><code>OFF</code> - MFA tokens are not required and cannot be specified during user
        /// registration.</para></li><li><para><code>ON</code> - MFA tokens are required for all user registrations. You can only
        /// specify required when you are initially creating a user pool.</para></li><li><para><code>OPTIONAL</code> - Users have the option when registering to create an MFA token.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.UserPoolMfaType")]
        public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_MinimumLength
        /// <summary>
        /// <para>
        /// <para>The minimum length of the password policy that you have set. Cannot be less than 6.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_MinimumLength")]
        public System.Int32? PasswordPolicy_MinimumLength { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostAuthentication
        /// <summary>
        /// <para>
        /// <para>A post-authentication AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PostAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PostConfirmation
        /// <summary>
        /// <para>
        /// <para>A post-confirmation AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PostConfirmation { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreAuthentication
        /// <summary>
        /// <para>
        /// <para>A pre-authentication AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreAuthentication { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreSignUp
        /// <summary>
        /// <para>
        /// <para>A pre-registration AWS Lambda trigger.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreSignUp { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_PreTokenGeneration
        /// <summary>
        /// <para>
        /// <para>A Lambda trigger that is invoked before token generation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_PreTokenGeneration { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_ReplyToEmailAddress
        /// <summary>
        /// <para>
        /// <para>The destination to which the receiver of the email should reply to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_ReplyToEmailAddress { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireLowercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one lowercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireLowercase")]
        public System.Boolean? PasswordPolicy_RequireLowercase { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireNumber
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one number in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireNumbers")]
        public System.Boolean? PasswordPolicy_RequireNumber { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireSymbol
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one symbol in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireSymbols")]
        public System.Boolean? PasswordPolicy_RequireSymbol { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_RequireUppercase
        /// <summary>
        /// <para>
        /// <para>In the password policy that you have set, refers to whether you have required users
        /// to use at least one uppercase letter in their password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_RequireUppercase")]
        public System.Boolean? PasswordPolicy_RequireUppercase { get; set; }
        #endregion
        
        #region Parameter SmsAuthenticationMessage
        /// <summary>
        /// <para>
        /// <para>The contents of the SMS authentication message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsAuthenticationMessage { get; set; }
        #endregion
        
        #region Parameter VerificationMessageTemplate_SmsMessage
        /// <summary>
        /// <para>
        /// <para>The SMS message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VerificationMessageTemplate_SmsMessage { get; set; }
        #endregion
        
        #region Parameter InviteMessageTemplate_SMSMessage
        /// <summary>
        /// <para>
        /// <para>The message template for SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_InviteMessageTemplate_SMSMessage")]
        public System.String InviteMessageTemplate_SMSMessage { get; set; }
        #endregion
        
        #region Parameter SmsVerificationMessage
        /// <summary>
        /// <para>
        /// <para>A container with information about the SMS verification message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsVerificationMessage { get; set; }
        #endregion
        
        #region Parameter SmsConfiguration_SnsCallerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) caller.
        /// This is the ARN of the IAM role in your AWS account which Cognito will use to send
        /// SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SmsConfiguration_SnsCallerArn { get; set; }
        #endregion
        
        #region Parameter EmailConfiguration_SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a verified email address in Amazon SES. This email
        /// address is used in one of the following ways, depending on the value that you specify
        /// for the <code>EmailSendingAccount</code> parameter:</para><ul><li><para>If you specify <code>COGNITO_DEFAULT</code>, Amazon Cognito uses this address as the
        /// custom FROM address when it emails your users by using its built-in email account.</para></li><li><para>If you specify <code>DEVELOPER</code>, Amazon Cognito emails your users with this
        /// address by calling Amazon SES on your behalf.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailConfiguration_SourceArn { get; set; }
        #endregion
        
        #region Parameter PasswordPolicy_TemporaryPasswordValidityDay
        /// <summary>
        /// <para>
        /// <para>In the password policy you have set, refers to the number of days a temporary password
        /// is valid. If the user does not sign-in during this time, their password will need
        /// to be reset by an administrator.</para><note><para>When you set <code>TemporaryPasswordValidityDays</code> for a user pool, you will
        /// no longer be able to set the deprecated <code>UnusedAccountValidityDays</code> value
        /// for that user pool.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Policies_PasswordPolicy_TemporaryPasswordValidityDays")]
        public System.Int32? PasswordPolicy_TemporaryPasswordValidityDay { get; set; }
        #endregion
        
        #region Parameter AdminCreateUserConfig_UnusedAccountValidityDay
        /// <summary>
        /// <para>
        /// <para>The user account expiration limit, in days, after which the account is no longer usable.
        /// To reset the account after that time limit, you must call <code>AdminCreateUser</code>
        /// again, specifying <code>"RESEND"</code> for the <code>MessageAction</code> parameter.
        /// The default value for this parameter is 7. </para><note><para>If you set a value for <code>TemporaryPasswordValidityDays</code> in <code>PasswordPolicy</code>,
        /// that value will be used and <code>UnusedAccountValidityDays</code> will be deprecated
        /// for that user pool. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminCreateUserConfig_UnusedAccountValidityDays")]
        public System.Int32? AdminCreateUserConfig_UnusedAccountValidityDay { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_UserMigration
        /// <summary>
        /// <para>
        /// <para>The user migration Lambda config type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_UserMigration { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool you want to update.</para>
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
        
        #region Parameter UserPoolTag
        /// <summary>
        /// <para>
        /// <para>The tag keys and values to assign to the user pool. A tag is a label that you can
        /// use to categorize and manage user pools in different ways, such as by purpose, owner,
        /// environment, or other criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserPoolTags")]
        public System.Collections.Hashtable UserPoolTag { get; set; }
        #endregion
        
        #region Parameter LambdaConfig_VerifyAuthChallengeResponse
        /// <summary>
        /// <para>
        /// <para>Verifies the authentication challenge response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CGIPUserPool (UpdateUserPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse, UpdateCGIPUserPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AdminCreateUserConfig_AllowAdminCreateUserOnly = this.AdminCreateUserConfig_AllowAdminCreateUserOnly;
            context.InviteMessageTemplate_EmailMessage = this.InviteMessageTemplate_EmailMessage;
            context.InviteMessageTemplate_EmailSubject = this.InviteMessageTemplate_EmailSubject;
            context.InviteMessageTemplate_SMSMessage = this.InviteMessageTemplate_SMSMessage;
            context.AdminCreateUserConfig_UnusedAccountValidityDay = this.AdminCreateUserConfig_UnusedAccountValidityDay;
            if (this.AutoVerifiedAttribute != null)
            {
                context.AutoVerifiedAttribute = new List<System.String>(this.AutoVerifiedAttribute);
            }
            context.DeviceConfiguration_ChallengeRequiredOnNewDevice = this.DeviceConfiguration_ChallengeRequiredOnNewDevice;
            context.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt = this.DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt;
            context.EmailConfiguration_ConfigurationSet = this.EmailConfiguration_ConfigurationSet;
            context.EmailConfiguration_EmailSendingAccount = this.EmailConfiguration_EmailSendingAccount;
            context.EmailConfiguration_From = this.EmailConfiguration_From;
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
            context.LambdaConfig_PreTokenGeneration = this.LambdaConfig_PreTokenGeneration;
            context.LambdaConfig_UserMigration = this.LambdaConfig_UserMigration;
            context.LambdaConfig_VerifyAuthChallengeResponse = this.LambdaConfig_VerifyAuthChallengeResponse;
            context.MfaConfiguration = this.MfaConfiguration;
            context.PasswordPolicy_MinimumLength = this.PasswordPolicy_MinimumLength;
            context.PasswordPolicy_RequireLowercase = this.PasswordPolicy_RequireLowercase;
            context.PasswordPolicy_RequireNumber = this.PasswordPolicy_RequireNumber;
            context.PasswordPolicy_RequireSymbol = this.PasswordPolicy_RequireSymbol;
            context.PasswordPolicy_RequireUppercase = this.PasswordPolicy_RequireUppercase;
            context.PasswordPolicy_TemporaryPasswordValidityDay = this.PasswordPolicy_TemporaryPasswordValidityDay;
            context.SmsAuthenticationMessage = this.SmsAuthenticationMessage;
            context.SmsConfiguration_ExternalId = this.SmsConfiguration_ExternalId;
            context.SmsConfiguration_SnsCallerArn = this.SmsConfiguration_SnsCallerArn;
            context.SmsVerificationMessage = this.SmsVerificationMessage;
            context.UserPoolAddOns_AdvancedSecurityMode = this.UserPoolAddOns_AdvancedSecurityMode;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.UserPoolTag != null)
            {
                context.UserPoolTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.UserPoolTag.Keys)
                {
                    context.UserPoolTag.Add((String)hashKey, (String)(this.UserPoolTag[hashKey]));
                }
            }
            context.VerificationMessageTemplate_DefaultEmailOption = this.VerificationMessageTemplate_DefaultEmailOption;
            context.VerificationMessageTemplate_EmailMessage = this.VerificationMessageTemplate_EmailMessage;
            context.VerificationMessageTemplate_EmailMessageByLink = this.VerificationMessageTemplate_EmailMessageByLink;
            context.VerificationMessageTemplate_EmailSubject = this.VerificationMessageTemplate_EmailSubject;
            context.VerificationMessageTemplate_EmailSubjectByLink = this.VerificationMessageTemplate_EmailSubjectByLink;
            context.VerificationMessageTemplate_SmsMessage = this.VerificationMessageTemplate_SmsMessage;
            
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
            var requestAdminCreateUserConfigIsNull = true;
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
            if (cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDay != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay = cmdletContext.AdminCreateUserConfig_UnusedAccountValidityDay.Value;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay != null)
            {
                request.AdminCreateUserConfig.UnusedAccountValidityDays = requestAdminCreateUserConfig_adminCreateUserConfig_UnusedAccountValidityDay.Value;
                requestAdminCreateUserConfigIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.MessageTemplateType requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = null;
            
             // populate InviteMessageTemplate
            var requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = true;
            requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate = new Amazon.CognitoIdentityProvider.Model.MessageTemplateType();
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = null;
            if (cmdletContext.InviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage = cmdletContext.InviteMessageTemplate_EmailMessage;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailMessage = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailMessage;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = null;
            if (cmdletContext.InviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject = cmdletContext.InviteMessageTemplate_EmailSubject;
            }
            if (requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate.EmailSubject = requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_EmailSubject;
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplateIsNull = false;
            }
            System.String requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = null;
            if (cmdletContext.InviteMessageTemplate_SMSMessage != null)
            {
                requestAdminCreateUserConfig_adminCreateUserConfig_InviteMessageTemplate_inviteMessageTemplate_SMSMessage = cmdletContext.InviteMessageTemplate_SMSMessage;
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
            if (cmdletContext.AutoVerifiedAttribute != null)
            {
                request.AutoVerifiedAttributes = cmdletContext.AutoVerifiedAttribute;
            }
            
             // populate DeviceConfiguration
            var requestDeviceConfigurationIsNull = true;
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
            var requestEmailConfigurationIsNull = true;
            request.EmailConfiguration = new Amazon.CognitoIdentityProvider.Model.EmailConfigurationType();
            System.String requestEmailConfiguration_emailConfiguration_ConfigurationSet = null;
            if (cmdletContext.EmailConfiguration_ConfigurationSet != null)
            {
                requestEmailConfiguration_emailConfiguration_ConfigurationSet = cmdletContext.EmailConfiguration_ConfigurationSet;
            }
            if (requestEmailConfiguration_emailConfiguration_ConfigurationSet != null)
            {
                request.EmailConfiguration.ConfigurationSet = requestEmailConfiguration_emailConfiguration_ConfigurationSet;
                requestEmailConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.EmailSendingAccountType requestEmailConfiguration_emailConfiguration_EmailSendingAccount = null;
            if (cmdletContext.EmailConfiguration_EmailSendingAccount != null)
            {
                requestEmailConfiguration_emailConfiguration_EmailSendingAccount = cmdletContext.EmailConfiguration_EmailSendingAccount;
            }
            if (requestEmailConfiguration_emailConfiguration_EmailSendingAccount != null)
            {
                request.EmailConfiguration.EmailSendingAccount = requestEmailConfiguration_emailConfiguration_EmailSendingAccount;
                requestEmailConfigurationIsNull = false;
            }
            System.String requestEmailConfiguration_emailConfiguration_From = null;
            if (cmdletContext.EmailConfiguration_From != null)
            {
                requestEmailConfiguration_emailConfiguration_From = cmdletContext.EmailConfiguration_From;
            }
            if (requestEmailConfiguration_emailConfiguration_From != null)
            {
                request.EmailConfiguration.From = requestEmailConfiguration_emailConfiguration_From;
                requestEmailConfigurationIsNull = false;
            }
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
            var requestLambdaConfigIsNull = true;
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
            System.String requestLambdaConfig_lambdaConfig_PreTokenGeneration = null;
            if (cmdletContext.LambdaConfig_PreTokenGeneration != null)
            {
                requestLambdaConfig_lambdaConfig_PreTokenGeneration = cmdletContext.LambdaConfig_PreTokenGeneration;
            }
            if (requestLambdaConfig_lambdaConfig_PreTokenGeneration != null)
            {
                request.LambdaConfig.PreTokenGeneration = requestLambdaConfig_lambdaConfig_PreTokenGeneration;
                requestLambdaConfigIsNull = false;
            }
            System.String requestLambdaConfig_lambdaConfig_UserMigration = null;
            if (cmdletContext.LambdaConfig_UserMigration != null)
            {
                requestLambdaConfig_lambdaConfig_UserMigration = cmdletContext.LambdaConfig_UserMigration;
            }
            if (requestLambdaConfig_lambdaConfig_UserMigration != null)
            {
                request.LambdaConfig.UserMigration = requestLambdaConfig_lambdaConfig_UserMigration;
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
            var requestPoliciesIsNull = true;
            request.Policies = new Amazon.CognitoIdentityProvider.Model.UserPoolPolicyType();
            Amazon.CognitoIdentityProvider.Model.PasswordPolicyType requestPolicies_policies_PasswordPolicy = null;
            
             // populate PasswordPolicy
            var requestPolicies_policies_PasswordPolicyIsNull = true;
            requestPolicies_policies_PasswordPolicy = new Amazon.CognitoIdentityProvider.Model.PasswordPolicyType();
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = null;
            if (cmdletContext.PasswordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength = cmdletContext.PasswordPolicy_MinimumLength.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength != null)
            {
                requestPolicies_policies_PasswordPolicy.MinimumLength = requestPolicies_policies_PasswordPolicy_passwordPolicy_MinimumLength.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = null;
            if (cmdletContext.PasswordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase = cmdletContext.PasswordPolicy_RequireLowercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireLowercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireLowercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = null;
            if (cmdletContext.PasswordPolicy_RequireNumber != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber = cmdletContext.PasswordPolicy_RequireNumber.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireNumbers = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireNumber.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = null;
            if (cmdletContext.PasswordPolicy_RequireSymbol != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol = cmdletContext.PasswordPolicy_RequireSymbol.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireSymbols = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireSymbol.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Boolean? requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = null;
            if (cmdletContext.PasswordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase = cmdletContext.PasswordPolicy_RequireUppercase.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase != null)
            {
                requestPolicies_policies_PasswordPolicy.RequireUppercase = requestPolicies_policies_PasswordPolicy_passwordPolicy_RequireUppercase.Value;
                requestPolicies_policies_PasswordPolicyIsNull = false;
            }
            System.Int32? requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay = null;
            if (cmdletContext.PasswordPolicy_TemporaryPasswordValidityDay != null)
            {
                requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay = cmdletContext.PasswordPolicy_TemporaryPasswordValidityDay.Value;
            }
            if (requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay != null)
            {
                requestPolicies_policies_PasswordPolicy.TemporaryPasswordValidityDays = requestPolicies_policies_PasswordPolicy_passwordPolicy_TemporaryPasswordValidityDay.Value;
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
            var requestSmsConfigurationIsNull = true;
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
            
             // populate UserPoolAddOns
            var requestUserPoolAddOnsIsNull = true;
            request.UserPoolAddOns = new Amazon.CognitoIdentityProvider.Model.UserPoolAddOnsType();
            Amazon.CognitoIdentityProvider.AdvancedSecurityModeType requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode = null;
            if (cmdletContext.UserPoolAddOns_AdvancedSecurityMode != null)
            {
                requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode = cmdletContext.UserPoolAddOns_AdvancedSecurityMode;
            }
            if (requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode != null)
            {
                request.UserPoolAddOns.AdvancedSecurityMode = requestUserPoolAddOns_userPoolAddOns_AdvancedSecurityMode;
                requestUserPoolAddOnsIsNull = false;
            }
             // determine if request.UserPoolAddOns should be set to null
            if (requestUserPoolAddOnsIsNull)
            {
                request.UserPoolAddOns = null;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.UserPoolTag != null)
            {
                request.UserPoolTags = cmdletContext.UserPoolTag;
            }
            
             // populate VerificationMessageTemplate
            var requestVerificationMessageTemplateIsNull = true;
            request.VerificationMessageTemplate = new Amazon.CognitoIdentityProvider.Model.VerificationMessageTemplateType();
            Amazon.CognitoIdentityProvider.DefaultEmailOptionType requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption = null;
            if (cmdletContext.VerificationMessageTemplate_DefaultEmailOption != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption = cmdletContext.VerificationMessageTemplate_DefaultEmailOption;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption != null)
            {
                request.VerificationMessageTemplate.DefaultEmailOption = requestVerificationMessageTemplate_verificationMessageTemplate_DefaultEmailOption;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage = null;
            if (cmdletContext.VerificationMessageTemplate_EmailMessage != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage = cmdletContext.VerificationMessageTemplate_EmailMessage;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage != null)
            {
                request.VerificationMessageTemplate.EmailMessage = requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessage;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink = null;
            if (cmdletContext.VerificationMessageTemplate_EmailMessageByLink != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink = cmdletContext.VerificationMessageTemplate_EmailMessageByLink;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink != null)
            {
                request.VerificationMessageTemplate.EmailMessageByLink = requestVerificationMessageTemplate_verificationMessageTemplate_EmailMessageByLink;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject = null;
            if (cmdletContext.VerificationMessageTemplate_EmailSubject != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject = cmdletContext.VerificationMessageTemplate_EmailSubject;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject != null)
            {
                request.VerificationMessageTemplate.EmailSubject = requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubject;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink = null;
            if (cmdletContext.VerificationMessageTemplate_EmailSubjectByLink != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink = cmdletContext.VerificationMessageTemplate_EmailSubjectByLink;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink != null)
            {
                request.VerificationMessageTemplate.EmailSubjectByLink = requestVerificationMessageTemplate_verificationMessageTemplate_EmailSubjectByLink;
                requestVerificationMessageTemplateIsNull = false;
            }
            System.String requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage = null;
            if (cmdletContext.VerificationMessageTemplate_SmsMessage != null)
            {
                requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage = cmdletContext.VerificationMessageTemplate_SmsMessage;
            }
            if (requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage != null)
            {
                request.VerificationMessageTemplate.SmsMessage = requestVerificationMessageTemplate_verificationMessageTemplate_SmsMessage;
                requestVerificationMessageTemplateIsNull = false;
            }
             // determine if request.VerificationMessageTemplate should be set to null
            if (requestVerificationMessageTemplateIsNull)
            {
                request.VerificationMessageTemplate = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.UpdateUserPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "UpdateUserPool");
            try
            {
                #if DESKTOP
                return client.UpdateUserPool(request);
                #elif CORECLR
                return client.UpdateUserPoolAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AdminCreateUserConfig_AllowAdminCreateUserOnly { get; set; }
            public System.String InviteMessageTemplate_EmailMessage { get; set; }
            public System.String InviteMessageTemplate_EmailSubject { get; set; }
            public System.String InviteMessageTemplate_SMSMessage { get; set; }
            public System.Int32? AdminCreateUserConfig_UnusedAccountValidityDay { get; set; }
            public List<System.String> AutoVerifiedAttribute { get; set; }
            public System.Boolean? DeviceConfiguration_ChallengeRequiredOnNewDevice { get; set; }
            public System.Boolean? DeviceConfiguration_DeviceOnlyRememberedOnUserPrompt { get; set; }
            public System.String EmailConfiguration_ConfigurationSet { get; set; }
            public Amazon.CognitoIdentityProvider.EmailSendingAccountType EmailConfiguration_EmailSendingAccount { get; set; }
            public System.String EmailConfiguration_From { get; set; }
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
            public System.String LambdaConfig_PreTokenGeneration { get; set; }
            public System.String LambdaConfig_UserMigration { get; set; }
            public System.String LambdaConfig_VerifyAuthChallengeResponse { get; set; }
            public Amazon.CognitoIdentityProvider.UserPoolMfaType MfaConfiguration { get; set; }
            public System.Int32? PasswordPolicy_MinimumLength { get; set; }
            public System.Boolean? PasswordPolicy_RequireLowercase { get; set; }
            public System.Boolean? PasswordPolicy_RequireNumber { get; set; }
            public System.Boolean? PasswordPolicy_RequireSymbol { get; set; }
            public System.Boolean? PasswordPolicy_RequireUppercase { get; set; }
            public System.Int32? PasswordPolicy_TemporaryPasswordValidityDay { get; set; }
            public System.String SmsAuthenticationMessage { get; set; }
            public System.String SmsConfiguration_ExternalId { get; set; }
            public System.String SmsConfiguration_SnsCallerArn { get; set; }
            public System.String SmsVerificationMessage { get; set; }
            public Amazon.CognitoIdentityProvider.AdvancedSecurityModeType UserPoolAddOns_AdvancedSecurityMode { get; set; }
            public System.String UserPoolId { get; set; }
            public Dictionary<System.String, System.String> UserPoolTag { get; set; }
            public Amazon.CognitoIdentityProvider.DefaultEmailOptionType VerificationMessageTemplate_DefaultEmailOption { get; set; }
            public System.String VerificationMessageTemplate_EmailMessage { get; set; }
            public System.String VerificationMessageTemplate_EmailMessageByLink { get; set; }
            public System.String VerificationMessageTemplate_EmailSubject { get; set; }
            public System.String VerificationMessageTemplate_EmailSubjectByLink { get; set; }
            public System.String VerificationMessageTemplate_SmsMessage { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.UpdateUserPoolResponse, UpdateCGIPUserPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
