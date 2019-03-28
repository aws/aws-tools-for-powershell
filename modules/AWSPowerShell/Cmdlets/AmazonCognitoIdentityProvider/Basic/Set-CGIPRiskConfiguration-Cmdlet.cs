/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Configures actions on detected risks. To delete the risk configuration for <code>UserPoolId</code>
    /// or <code>ClientId</code>, pass null values for all four configuration types.
    /// 
    ///  
    /// <para>
    /// To enable Amazon Cognito advanced security features, update the user pool to include
    /// the <code>UserPoolAddOns</code> key<code>AdvancedSecurityMode</code>.
    /// </para><para>
    /// See .
    /// </para>
    /// </summary>
    [Cmdlet("Set", "CGIPRiskConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RiskConfigurationType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SetRiskConfiguration API operation.", Operation = new[] {"SetRiskConfiguration"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RiskConfigurationType",
        "This cmdlet returns a RiskConfigurationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.SetRiskConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetCGIPRiskConfigurationCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter RiskExceptionConfiguration_BlockedIPRangeList
        /// <summary>
        /// <para>
        /// <para>Overrides the risk decision to always block the pre-authentication requests. The IP
        /// range is in CIDR notation: a compact representation of an IP address and its associated
        /// routing prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] RiskExceptionConfiguration_BlockedIPRangeList { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The app client ID. If <code>ClientId</code> is null, then the risk configuration is
        /// mapped to <code>userPoolId</code>. When the client ID is null, the same risk configuration
        /// is applied to all the clients in the userPool.</para><para>Otherwise, <code>ClientId</code> is mapped to the client. When the client ID is not
        /// null, the user pool configuration is overridden and the risk configuration for the
        /// client is used instead.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter HighAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The event action.</para><ul><li><para><code>BLOCK</code> Choosing this action will block the request.</para></li><li><para><code>MFA_IF_CONFIGURED</code> Throw MFA challenge if user has configured it, else
        /// allow the request.</para></li><li><para><code>MFA_REQUIRED</code> Throw MFA challenge if user has configured it, else block
        /// the request.</para></li><li><para><code>NO_ACTION</code> Allow the user sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType HighAction_EventAction { get; set; }
        #endregion
        
        #region Parameter LowAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The event action.</para><ul><li><para><code>BLOCK</code> Choosing this action will block the request.</para></li><li><para><code>MFA_IF_CONFIGURED</code> Throw MFA challenge if user has configured it, else
        /// allow the request.</para></li><li><para><code>MFA_REQUIRED</code> Throw MFA challenge if user has configured it, else block
        /// the request.</para></li><li><para><code>NO_ACTION</code> Allow the user sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType LowAction_EventAction { get; set; }
        #endregion
        
        #region Parameter MediumAction_EventAction
        /// <summary>
        /// <para>
        /// <para>The event action.</para><ul><li><para><code>BLOCK</code> Choosing this action will block the request.</para></li><li><para><code>MFA_IF_CONFIGURED</code> Throw MFA challenge if user has configured it, else
        /// allow the request.</para></li><li><para><code>MFA_REQUIRED</code> Throw MFA challenge if user has configured it, else block
        /// the request.</para></li><li><para><code>NO_ACTION</code> Allow the user sign-in.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType")]
        public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType MediumAction_EventAction { get; set; }
        #endregion
        
        #region Parameter Actions_EventAction
        /// <summary>
        /// <para>
        /// <para>The event action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CompromisedCredentialsRiskConfiguration_Actions_EventAction")]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType")]
        public Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType Actions_EventAction { get; set; }
        #endregion
        
        #region Parameter CompromisedCredentialsRiskConfiguration_EventFilter
        /// <summary>
        /// <para>
        /// <para>Perform the action for these events. The default is to perform all events if no event
        /// filter is specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] CompromisedCredentialsRiskConfiguration_EventFilter { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_From
        /// <summary>
        /// <para>
        /// <para>The email address that is sending the email. It must be either individually verified
        /// with Amazon SES, or from a domain that has been verified with Amazon SES.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_From")]
        public System.String NotifyConfiguration_From { get; set; }
        #endregion
        
        #region Parameter BlockEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The HTML body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody")]
        public System.String BlockEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter MfaEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The HTML body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody")]
        public System.String MfaEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_HtmlBody
        /// <summary>
        /// <para>
        /// <para>The HTML body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody")]
        public System.String NoActionEmail_HtmlBody { get; set; }
        #endregion
        
        #region Parameter HighAction_Notify
        /// <summary>
        /// <para>
        /// <para>Flag specifying whether to send a notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_HighAction_Notify")]
        public System.Boolean HighAction_Notify { get; set; }
        #endregion
        
        #region Parameter LowAction_Notify
        /// <summary>
        /// <para>
        /// <para>Flag specifying whether to send a notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_LowAction_Notify")]
        public System.Boolean LowAction_Notify { get; set; }
        #endregion
        
        #region Parameter MediumAction_Notify
        /// <summary>
        /// <para>
        /// <para>Flag specifying whether to send a notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify")]
        public System.Boolean MediumAction_Notify { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_ReplyTo
        /// <summary>
        /// <para>
        /// <para>The destination to which the receiver of an email should reply to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo")]
        public System.String NotifyConfiguration_ReplyTo { get; set; }
        #endregion
        
        #region Parameter RiskExceptionConfiguration_SkippedIPRangeList
        /// <summary>
        /// <para>
        /// <para>Risk detection is not performed on the IP addresses in the range list. The IP range
        /// is in CIDR notation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] RiskExceptionConfiguration_SkippedIPRangeList { get; set; }
        #endregion
        
        #region Parameter NotifyConfiguration_SourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the identity that is associated with the sending
        /// authorization policy. It permits Amazon Cognito to send for the email address specified
        /// in the <code>From</code> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn")]
        public System.String NotifyConfiguration_SourceArn { get; set; }
        #endregion
        
        #region Parameter BlockEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject")]
        public System.String BlockEmail_Subject { get; set; }
        #endregion
        
        #region Parameter MfaEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject")]
        public System.String MfaEmail_Subject { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_Subject
        /// <summary>
        /// <para>
        /// <para>The subject.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject")]
        public System.String NoActionEmail_Subject { get; set; }
        #endregion
        
        #region Parameter BlockEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The text body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody")]
        public System.String BlockEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter MfaEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The text body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody")]
        public System.String MfaEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter NoActionEmail_TextBody
        /// <summary>
        /// <para>
        /// <para>The text body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody")]
        public System.String NoActionEmail_TextBody { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-CGIPRiskConfiguration (SetRiskConfiguration)"))
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
            
            context.AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction = this.HighAction_EventAction;
            if (ParameterWasBound("HighAction_Notify"))
                context.AccountTakeoverRiskConfiguration_Actions_HighAction_Notify = this.HighAction_Notify;
            context.AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction = this.LowAction_EventAction;
            if (ParameterWasBound("LowAction_Notify"))
                context.AccountTakeoverRiskConfiguration_Actions_LowAction_Notify = this.LowAction_Notify;
            context.AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction = this.MediumAction_EventAction;
            if (ParameterWasBound("MediumAction_Notify"))
                context.AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify = this.MediumAction_Notify;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody = this.BlockEmail_HtmlBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject = this.BlockEmail_Subject;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody = this.BlockEmail_TextBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_From = this.NotifyConfiguration_From;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody = this.MfaEmail_HtmlBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject = this.MfaEmail_Subject;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody = this.MfaEmail_TextBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody = this.NoActionEmail_HtmlBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject = this.NoActionEmail_Subject;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody = this.NoActionEmail_TextBody;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo = this.NotifyConfiguration_ReplyTo;
            context.AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn = this.NotifyConfiguration_SourceArn;
            context.ClientId = this.ClientId;
            context.CompromisedCredentialsRiskConfiguration_Actions_EventAction = this.Actions_EventAction;
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
            bool requestAccountTakeoverRiskConfigurationIsNull = true;
            request.AccountTakeoverRiskConfiguration = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverRiskConfigurationType();
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionsType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions = null;
            
             // populate Actions
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_ActionsIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionsType();
            Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction = null;
            
             // populate HighAction
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction = cmdletContext.AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_HighAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_HighAction_highAction_Notify = cmdletContext.AccountTakeoverRiskConfiguration_Actions_HighAction_Notify.Value;
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
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction = cmdletContext.AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_LowAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_LowAction_lowAction_Notify = cmdletContext.AccountTakeoverRiskConfiguration_Actions_LowAction_Notify.Value;
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
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction = new Amazon.CognitoIdentityProvider.Model.AccountTakeoverActionType();
            Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction = cmdletContext.AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction.EventAction = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_EventAction;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumActionIsNull = false;
            }
            System.Boolean? requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_Actions_accountTakeoverRiskConfiguration_Actions_MediumAction_mediumAction_Notify = cmdletContext.AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify.Value;
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
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration = new Amazon.CognitoIdentityProvider.Model.NotifyConfigurationType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_From != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_From;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.From = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_From;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.ReplyTo = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_ReplyTo;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration.SourceArn = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_notifyConfiguration_SourceArn;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfigurationIsNull = false;
            }
            Amazon.CognitoIdentityProvider.Model.NotifyEmailType requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail = null;
            
             // populate BlockEmail
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_blockEmail_TextBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody;
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
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_mfaEmail_TextBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody;
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
            bool requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = true;
            requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail = new Amazon.CognitoIdentityProvider.Model.NotifyEmailType();
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail.HtmlBody = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_HtmlBody;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject;
            }
            if (requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail.Subject = requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_Subject;
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmailIsNull = false;
            }
            System.String requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody = null;
            if (cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody != null)
            {
                requestAccountTakeoverRiskConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_accountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_noActionEmail_TextBody = cmdletContext.AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody;
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
            bool requestCompromisedCredentialsRiskConfigurationIsNull = true;
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
            bool requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_ActionsIsNull = true;
            requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions = new Amazon.CognitoIdentityProvider.Model.CompromisedCredentialsActionsType();
            Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction = null;
            if (cmdletContext.CompromisedCredentialsRiskConfiguration_Actions_EventAction != null)
            {
                requestCompromisedCredentialsRiskConfiguration_compromisedCredentialsRiskConfiguration_Actions_actions_EventAction = cmdletContext.CompromisedCredentialsRiskConfiguration_Actions_EventAction;
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
            bool requestRiskExceptionConfigurationIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RiskConfiguration;
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
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType AccountTakeoverRiskConfiguration_Actions_HighAction_EventAction { get; set; }
            public System.Boolean? AccountTakeoverRiskConfiguration_Actions_HighAction_Notify { get; set; }
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType AccountTakeoverRiskConfiguration_Actions_LowAction_EventAction { get; set; }
            public System.Boolean? AccountTakeoverRiskConfiguration_Actions_LowAction_Notify { get; set; }
            public Amazon.CognitoIdentityProvider.AccountTakeoverEventActionType AccountTakeoverRiskConfiguration_Actions_MediumAction_EventAction { get; set; }
            public System.Boolean? AccountTakeoverRiskConfiguration_Actions_MediumAction_Notify { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_HtmlBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_Subject { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_BlockEmail_TextBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_From { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_HtmlBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_Subject { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_MfaEmail_TextBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_HtmlBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_Subject { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_NoActionEmail_TextBody { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_ReplyTo { get; set; }
            public System.String AccountTakeoverRiskConfiguration_NotifyConfiguration_SourceArn { get; set; }
            public System.String ClientId { get; set; }
            public Amazon.CognitoIdentityProvider.CompromisedCredentialsEventActionType CompromisedCredentialsRiskConfiguration_Actions_EventAction { get; set; }
            public List<System.String> CompromisedCredentialsRiskConfiguration_EventFilter { get; set; }
            public List<System.String> RiskExceptionConfiguration_BlockedIPRangeList { get; set; }
            public List<System.String> RiskExceptionConfiguration_SkippedIPRangeList { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}
