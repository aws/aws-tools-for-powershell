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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Configures threat protection for a user pool or app client. Sets configuration for
    /// the following.
    /// 
    ///  <ul><li><para>
    /// Responses to risks with adaptive authentication
    /// </para></li><li><para>
    /// Responses to vulnerable passwords with compromised-credentials detection
    /// </para></li><li><para>
    /// Notifications to users who have had risky activity detected
    /// </para></li><li><para>
    /// IP-address denylist and allowlist
    /// </para></li></ul><para>
    /// To set the risk configuration for the user pool to defaults, send this request with
    /// only the <c>UserPoolId</c> parameter. To reset the threat protection settings of an
    /// app client to be inherited from the user pool, send <c>UserPoolId</c> and <c>ClientId</c>
    /// parameters only. To change threat protection to audit-only or off, update the value
    /// of <c>UserPoolAddOns</c> in an <c>UpdateUserPool</c> request. To activate this setting,
    /// your user pool must be on the <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/feature-plans-features-plus.html">
    /// Plus tier</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "CGIPRiskConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RiskConfigurationType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetRiskConfiguration API operation.", Operation = new[] {"SetRiskConfiguration"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RiskConfigurationType or Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.RiskConfigurationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SetCGIPRiskConfigurationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RiskExceptionConfiguration_BlockedIPRangeList
        /// <summary>
        /// <para>
        /// <para>An always-block IP address list. Overrides the risk decision and always blocks authentication
        /// requests. This parameter is displayed and set in CIDR notation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RiskExceptionConfiguration_BlockedIPRangeList { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the app client where you want to set a risk configuration. If <c>ClientId</c>
        /// is null, then the risk configuration is mapped to <c>UserPoolId</c>. When the client
        /// ID is null, the same risk configuration is applied to all the clients in the userPool.</para><para>When you include a <c>ClientId</c> parameter, Amazon Cognito maps the configuration
        /// to the app client. When you include both <c>ClientId</c> and <c>UserPoolId</c>, Amazon
        /// Cognito maps the configuration to the app client only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter HighAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The action to take for the attempted account takeover action for the associated risk
        /// level. Valid values are as follows:</para><ul><li><para><c>BLOCK</c>: Block the request.</para></li><li><para><c>MFA_IF_CONFIGURED</c>: Present an MFA challenge if possible. MFA is possible if
        /// the user pool has active MFA methods that the user can set up. For example, if the
        /// user pool only supports SMS message MFA but the user doesn't have a phone number attribute,
        /// MFA setup isn't possible. If MFA setup isn't possible, allow the request.</para></li><li><para><c>MFA_REQUIRED</c>: Present an MFA challenge if possible. Block the request if a
        /// user hasn't set up MFA. To sign in with required MFA, users must have an email address
        /// or phone number attribute, or a registered TOTP factor.</para></li><li><para><c>NO_ACTION</c>: Take no action. Permit sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType HighAction_EventAction { get; set; }
        #endregion
        
        #region Parameter LowAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The action to take for the attempted account takeover action for the associated risk
        /// level. Valid values are as follows:</para><ul><li><para><c>BLOCK</c>: Block the request.</para></li><li><para><c>MFA_IF_CONFIGURED</c>: Present an MFA challenge if possible. MFA is possible if
        /// the user pool has active MFA methods that the user can set up. For example, if the
        /// user pool only supports SMS message MFA but the user doesn't have a phone number attribute,
        /// MFA setup isn't possible. If MFA setup isn't possible, allow the request.</para></li><li><para><c>MFA_REQUIRED</c>: Present an MFA challenge if possible. Block the request if a
        /// user hasn't set up MFA. To sign in with required MFA, users must have an email address
        /// or phone number attribute, or a registered TOTP factor.</para></li><li><para><c>NO_ACTION</c>: Take no action. Permit sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType LowAction_EventAction { get; set; }
        #endregion
        
        #region Parameter MediumAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The action to take for the attempted account takeover action for the associated risk
        /// level. Valid values are as follows:</para><ul><li><para><c>BLOCK</c>: Block the request.</para></li><li><para><c>MFA_IF_CONFIGURED</c>: Present an MFA challenge if possible. MFA is possible if
        /// the user pool has active MFA methods that the user can set up. For example, if the
        /// user pool only supports SMS message MFA but the user doesn't have a phone number attribute,
        /// MFA setup isn't possible. If MFA setup isn't possible, allow the request.</para></li><li><para><c>MFA_REQUIRED</c>: Present an MFA challenge if possible. Block the request if a
        /// user hasn't set up MFA. To sign in with required MFA, users must have an email address
        /// or phone number attribute, or a registered TOTP factor.</para></li><li><para><c>NO_ACTION</c>: Take no action. Permit sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType MediumAction_EventAction { get; set; }
        #endregion
        
        #region Parameter Actions_EventAction
        /// <summary>
        /// <para>
        /// <para>The action that Amazon Cognito takes when it detects compromised credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CompromisedCredentialsRiskConfiguration_Actions_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType")]
        public Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType Actions_EventAction { get; set; }
        #endregion
        
        #region Parameter CompromisedCredentialsRiskConfiguration_EventFilter
        /// <summary>
        /// <para>
        /// <para>Settings for the sign-in activity where you want to configure compromised-credentials
        /// actions. Defaults to all events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CompromisedCredentialsRiskConfiguration_EventFilter { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_From
        /// <summary>
        /// <para>
        /// <para>The email address that sends the email message. The address must be either individually
        /// verified with Amazon Simple Email Service, or from a domain that has been verified
        /// with Amazon SES.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_From")]
        public System.String NotifyConfiguration_From { get; set; }
        #endregion
        
        #region Parameter BlockEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in HTML. Choose an <c>HtmlBody</c> or
        /// a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody")]
        public System.String BlockEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter MfaEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in HTML. Choose an <c>HtmlBody</c> or
        /// a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody")]
        public System.String MfaEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in HTML. Choose an <c>HtmlBody</c> or
        /// a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody")]
        public System.String NoActionEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter HighAction_Notify
        /// <summary>
        /// <para>
        /// <para>Determines whether Amazon Cognito sends a user a notification message when your user
        /// pools assesses a user's session at the associated risk level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_HighAction_Notify")]
        public System.Boolean? HighAction_Notify { get; set; }
        #endregion
        
        #region Parameter LowAction_Notify
        /// <summary>
        /// <para>
        /// <para>Determines whether Amazon Cognito sends a user a notification message when your user
        /// pools assesses a user's session at the associated risk level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_LowAction_Notify")]
        public System.Boolean? LowAction_Notify { get; set; }
        #endregion
        
        #region Parameter MediumAction_Notify
        /// <summary>
        /// <para>
        /// <para>Determines whether Amazon Cognito sends a user a notification message when your user
        /// pools assesses a user's session at the associated risk level.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify")]
        public System.Boolean? MediumAction_Notify { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_ReplyTo
        /// <summary>
        /// <para>
        /// <para>The reply-to email address of an email template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo")]
        public System.String NotifyConfiguration_ReplyTo { get; set; }
        #endregion
        
        #region Parameter RiskExceptionConfiguration_SkippedIPRangeList
        /// <summary>
        /// <para>
        /// <para>An always-allow IP address list. Risk detection isn't performed on the IP addresses
        /// in this range list. This parameter is displayed and set in CIDR notation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RiskExceptionConfiguration_SkippedIPRangeList { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the identity that is associated with the sending
        /// authorization policy. This identity permits Amazon Cognito to send for the email address
        /// specified in the <c>From</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn")]
        public System.String NotifyConfiguration_SourceArn { get; set; }
        #endregion
        
        #region Parameter BlockEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject of the threat protection email notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject")]
        public System.String BlockEmail_Subject { get; set; }
        #endregion
        
        #region Parameter MfaEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject of the threat protection email notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject")]
        public System.String MfaEmail_Subject { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject of the threat protection email notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject")]
        public System.String NoActionEmail_Subject { get; set; }
        #endregion
        
        #region Parameter BlockEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in plaintext. Choose an <c>HtmlBody</c>
        /// or a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody")]
        public System.String BlockEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter MfaEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in plaintext. Choose an <c>HtmlBody</c>
        /// or a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody")]
        public System.String MfaEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The body of an email notification formatted in plaintext. Choose an <c>HtmlBody</c>
        /// or a <c>TextBody</c> to send an HTML-formatted or plaintext message, respectively.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody")]
        public System.String NoActionEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool where you want to set a risk configuration. If you include
        /// <c>UserPoolId</c> in your request, don't include <c>ClientId</c>. When the client
        /// ID is null, the same risk configuration is applied to all the clients in the userPool.
        /// When you include both <c>ClientId</c> and <c>UserPoolId</c>, Amazon Cognito maps the
        /// configuration to the app client only.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RiskConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RiskConfiguration";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPRiskConfiguration (SetRiskConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse, SetCGIPRiskConfigurationCmdlet>(Select) ??
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
            context.HighAction_EventAction = this.HighAction_EventAction;
            context.HighAction_Notify = this.HighAction_Notify;
            context.LowAction_EventAction = this.LowAction_EventAction;
            context.LowAction_Notify = this.LowAction_Notify;
            context.MediumAction_EventAction = this.MediumAction_EventAction;
            context.MediumAction_Notify = this.MediumAction_Notify;
            context.BlockEmail_HtmlBody = this.BlockEmail_HtmlBody;
            context.BlockEmail_Subject = this.BlockEmail_Subject;
            context.BlockEmail_TextBody = this.BlockEmail_TextBody;
            context.NotifyConfiguration_From = this.NotifyConfiguration_From;
            context.MfaEmail_HtmlBody = this.MfaEmail_HtmlBody;
            context.MfaEmail_Subject = this.MfaEmail_Subject;
            context.MfaEmail_TextBody = this.MfaEmail_TextBody;
            context.NoActionEmail_HtmlBody = this.NoActionEmail_HtmlBody;
            context.NoActionEmail_Subject = this.NoActionEmail_Subject;
            context.NoActionEmail_TextBody = this.NoActionEmail_TextBody;
            context.NotifyConfiguration_ReplyTo = this.NotifyConfiguration_ReplyTo;
            context.NotifyConfiguration_SourceArn = this.NotifyConfiguration_SourceArn;
            context.ClientId = this.ClientId;
            context.Actions_EventAction = this.Actions_EventAction;
            if (this.CompromisedCredentialsRiskConfiguration_EventFilter != null)
            {
                context.CompromisedCredentialsRiskConfiguration_EventFilter = new List<System.String>(this.CompromisedCredentialsRiskConfiguration_EventFilter);
            }
            if (this.RiskExceptionConfiguration_BlockedIPRangeList != null)
            {
                context.RiskExceptionConfiguration_BlockedIPRangeList = new List<System.String>(this.RiskExceptionConfiguration_BlockedIPRangeList);
            }
            if (this.RiskExceptionConfiguration_SkippedIPRangeList != null)
            {
                context.RiskExceptionConfiguration_SkippedIPRangeList = new List<System.String>(this.RiskExceptionConfiguration_SkippedIPRangeList);
            }
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
            var request = new Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationRequest();
            
            
             // populate AccountTakeoverRiskConfiguration
            var requestAccountTakeoverRiskConfigurationIsNull = true;
            request.AccountTakeoverRiskConfiguration = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverRiskConfigurationType();
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionsType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions = null;
            
             // populate Actions
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionsType();
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction = null;
            
             // populate HighAction
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction = null;
            if (cmdletContext.HighAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction = cmdletContext.HighAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify = null;
            if (cmdletContext.HighAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify = cmdletContext.HighAction_Notify.Value;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction.Notify = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify.Value;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions.HighAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction = null;
            
             // populate LowAction
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction = null;
            if (cmdletContext.LowAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction = cmdletContext.LowAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify = null;
            if (cmdletContext.LowAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify = cmdletContext.LowAction_Notify.Value;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction.Notify = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify.Value;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions.LowAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction = null;
            
             // populate MediumAction
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction = null;
            if (cmdletContext.MediumAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction = cmdletContext.MediumAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify = null;
            if (cmdletContext.MediumAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify = cmdletContext.MediumAction_Notify.Value;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction.Notify = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify.Value;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions.MediumAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions != null)
            {
                request.AccountTakeoverRiskConfiguration.Actions = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions;
                requestAccountTakeoverRiskConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.NotifyConfigurationType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration = null;
            
             // populate NotifyConfiguration
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration = new Amazon.CognitoIdentityProvider.Model.NotifyConfigurationType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From = null;
            if (cmdletContext.NotifyConfiguration_From != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From = cmdletContext.NotifyConfiguration_From;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.From = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo = null;
            if (cmdletContext.NotifyConfiguration_ReplyTo != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo = cmdletContext.NotifyConfiguration_ReplyTo;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.ReplyTo = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn = null;
            if (cmdletContext.NotifyConfiguration_SourceArn != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn = cmdletContext.NotifyConfiguration_SourceArn;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.SourceArn = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.NotifyEmailType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail = null;
            
             // populate BlockEmail
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody = null;
            if (cmdletContext.BlockEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody = cmdletContext.BlockEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject = null;
            if (cmdletContext.BlockEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject = cmdletContext.BlockEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody = null;
            if (cmdletContext.BlockEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody = cmdletContext.BlockEmail_TextBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail.TextBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.BlockEmail = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.NotifyEmailType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail = null;
            
             // populate MfaEmail
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody = null;
            if (cmdletContext.MfaEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody = cmdletContext.MfaEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject = null;
            if (cmdletContext.MfaEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject = cmdletContext.MfaEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody = null;
            if (cmdletContext.MfaEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody = cmdletContext.MfaEmail_TextBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail.TextBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.MfaEmail = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.NotifyEmailType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail = null;
            
             // populate NoActionEmail
            var requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody = null;
            if (cmdletContext.NoActionEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody = cmdletContext.NoActionEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject = null;
            if (cmdletContext.NoActionEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject = cmdletContext.NoActionEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody = null;
            if (cmdletContext.NoActionEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody = cmdletContext.NoActionEmail_TextBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail.TextBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.NoActionEmail = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
             // determine if requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration should be set to null
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration = null;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration != null)
            {
                request.AccountTakeoverRiskConfiguration.NotifyConfiguration = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration;
                requestAccountTakeoverRiskConfigurationIsNull = false;
            }
             // determine if request.AccountTakeoverRiskConfiguration should be set to null
            if (requestAccountTakeoverRiskConfigurationIsNull)
            {
                request.AccountTakeoverRiskConfiguration = null;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            
             // populate CompromisedCredentialsRiskConfiguration
            var requestCompromisedCredentialsRiskConfigurationIsNull = true;
            request.CompromisedCredentialsRiskConfiguration = new Amazon.CognitoIdentityProvider.Model.CompromisedCredentialsRiskConfigurationType();
            List<System.String> requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_EventFilter = null;
            if (cmdletContext.CompromisedCredentialsRiskConfiguration_EventFilter != null)
            {
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_EventFilter = cmdletContext.CompromisedCredentialsRiskConfiguration_EventFilter;
            }
            if (requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_EventFilter != null)
            {
                request.CompromisedCredentialsRiskConfiguration.EventFilter = requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_EventFilter;
                requestCompromisedCredentialsRiskConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.CompromisedCredentialsActionsType requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions = null;
            
             // populate Actions
            var requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_ActionsIsNull = true;
            requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions = new Amazon.CognitoIdentityProvider.Model.CompromisedCredentialsActionsType();
            Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction = null;
            if (cmdletContext.Actions_EventAction != null)
            {
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction = cmdletContext.Actions_EventAction;
            }
            if (requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction != null)
            {
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions.EventAction = requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction;
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_ActionsIsNull = false;
            }
             // determine if requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions should be set to null
            if (requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_ActionsIsNull)
            {
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions = null;
            }
            if (requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions != null)
            {
                request.CompromisedCredentialsRiskConfiguration.Actions = requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions;
                requestCompromisedCredentialsRiskConfigurationIsNull = false;
            }
             // determine if request.CompromisedCredentialsRiskConfiguration should be set to null
            if (requestCompromisedCredentialsRiskConfigurationIsNull)
            {
                request.CompromisedCredentialsRiskConfiguration = null;
            }
            
             // populate RiskExceptionConfiguration
            var requestRiskExceptionConfigurationIsNull = true;
            request.RiskExceptionConfiguration = new Amazon.CognitoIdentityProvider.Model.RiskExceptionConfigurationType();
            List<System.String> requestRiskExceptionConfiguration_riskExceptionConfiguration_BlockedIPRangeList = null;
            if (cmdletContext.RiskExceptionConfiguration_BlockedIPRangeList != null)
            {
                requestRiskExceptionConfiguration_riskExceptionConfiguration_BlockedIPRangeList = cmdletContext.RiskExceptionConfiguration_BlockedIPRangeList;
            }
            if (requestRiskExceptionConfiguration_riskExceptionConfiguration_BlockedIPRangeList != null)
            {
                request.RiskExceptionConfiguration.BlockedIPRangeList = requestRiskExceptionConfiguration_riskExceptionConfiguration_BlockedIPRangeList;
                requestRiskExceptionConfigurationIsNull = false;
            }
            List<System.String> requestRiskExceptionConfiguration_riskExceptionConfiguration_SkippedIPRangeList = null;
            if (cmdletContext.RiskExceptionConfiguration_SkippedIPRangeList != null)
            {
                requestRiskExceptionConfiguration_riskExceptionConfiguration_SkippedIPRangeList = cmdletContext.RiskExceptionConfiguration_SkippedIPRangeList;
            }
            if (requestRiskExceptionConfiguration_riskExceptionConfiguration_SkippedIPRangeList != null)
            {
                request.RiskExceptionConfiguration.SkippedIPRangeList = requestRiskExceptionConfiguration_riskExceptionConfiguration_SkippedIPRangeList;
                requestRiskExceptionConfigurationIsNull = false;
            }
             // determine if request.RiskExceptionConfiguration should be set to null
            if (requestRiskExceptionConfigurationIsNull)
            {
                request.RiskExceptionConfiguration = null;
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
        
        private Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SetRiskConfiguration");
            try
            {
                #if DESKTOP
                return client.SetRiskConfiguration(request);
                #elif CORECLR
                return client.SetRiskConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType HighAction_EventAction { get; set; }
            public System.Boolean? HighAction_Notify { get; set; }
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType LowAction_EventAction { get; set; }
            public System.Boolean? LowAction_Notify { get; set; }
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType MediumAction_EventAction { get; set; }
            public System.Boolean? MediumAction_Notify { get; set; }
            public System.String BlockEmail_HtmlBody { get; set; }
            public System.String BlockEmail_Subject { get; set; }
            public System.String BlockEmail_TextBody { get; set; }
            public System.String NotifyConfiguration_From { get; set; }
            public System.String MfaEmail_HtmlBody { get; set; }
            public System.String MfaEmail_Subject { get; set; }
            public System.String MfaEmail_TextBody { get; set; }
            public System.String NoActionEmail_HtmlBody { get; set; }
            public System.String NoActionEmail_Subject { get; set; }
            public System.String NoActionEmail_TextBody { get; set; }
            public System.String NotifyConfiguration_ReplyTo { get; set; }
            public System.String NotifyConfiguration_SourceArn { get; set; }
            public System.String ClientId { get; set; }
            public Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType Actions_EventAction { get; set; }
            public List<System.String> CompromisedCredentialsRiskConfiguration_EventFilter { get; set; }
            public List<System.String> RiskExceptionConfiguration_BlockedIPRangeList { get; set; }
            public List<System.String> RiskExceptionConfiguration_SkippedIPRangeList { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse, SetCGIPRiskConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RiskConfiguration;
        }
        
    }
}
