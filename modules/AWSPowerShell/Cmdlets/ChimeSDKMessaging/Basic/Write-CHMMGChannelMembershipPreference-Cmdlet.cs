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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Sets the membership preferences of an <c>AppInstanceUser</c> or <c>AppInstanceBot</c>
    /// for the specified channel. The user or bot must be a member of the channel. Only the
    /// user or bot who owns the membership can set preferences. Users or bots in the <c>AppInstanceAdmin</c>
    /// and channel moderator roles can't set preferences for other users. Banned users or
    /// bots can't set membership preferences for the channel from which they are banned.
    /// 
    ///  <note><para>
    /// The x-amz-chime-bearer request header is mandatory. Use the ARN of an <c>AppInstanceUser</c>
    /// or <c>AppInstanceBot</c> that makes the API call as the value in the header.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CHMMGChannelMembershipPreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging PutChannelMembershipPreferences API operation.", Operation = new[] {"PutChannelMembershipPreferences"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse object containing multiple properties."
    )]
    public partial class WriteCHMMGChannelMembershipPreferenceCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PushNotifications_AllowNotification
        /// <summary>
        /// <para>
        /// <para>Enum value that indicates which push notifications to send to the requested member
        /// of a channel. <c>ALL</c> sends all push notifications, <c>NONE</c> sends no push notifications,
        /// <c>FILTERED</c> sends only filtered push notifications. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_PushNotifications_AllowNotifications")]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.AllowNotifications")]
        public Amazon.ChimeSDKMessaging.AllowNotifications PushNotifications_AllowNotification { get; set; }
        #endregion
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstanceUser</c> or <c>AppInstanceBot</c> that makes the API
        /// call.</para>
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
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter PushNotifications_FilterRule
        /// <summary>
        /// <para>
        /// <para>The simple JSON object used to send a subset of a push notification to the requested
        /// member.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Preferences_PushNotifications_FilterRule")]
        public System.String PushNotifications_FilterRule { get; set; }
        #endregion
        
        #region Parameter MemberArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the member setting the preferences.</para>
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
        public System.String MemberArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMMGChannelMembershipPreference (PutChannelMembershipPreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse, WriteCHMMGChannelMembershipPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChimeBearer = this.ChimeBearer;
            #if MODULAR
            if (this.ChimeBearer == null && ParameterWasBound(nameof(this.ChimeBearer)))
            {
                WriteWarning("You are passing $null as a value for parameter ChimeBearer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberArn = this.MemberArn;
            #if MODULAR
            if (this.MemberArn == null && ParameterWasBound(nameof(this.MemberArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MemberArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PushNotifications_AllowNotification = this.PushNotifications_AllowNotification;
            context.PushNotifications_FilterRule = this.PushNotifications_FilterRule;
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.MemberArn != null)
            {
                request.MemberArn = cmdletContext.MemberArn;
            }
            
             // populate Preferences
            var requestPreferencesIsNull = true;
            request.Preferences = new Amazon.ChimeSDKMessaging.Model.ChannelMembershipPreferences();
            Amazon.ChimeSDKMessaging.Model.PushNotificationPreferences requestPreferences_preferences_PushNotifications = null;
            
             // populate PushNotifications
            var requestPreferences_preferences_PushNotificationsIsNull = true;
            requestPreferences_preferences_PushNotifications = new Amazon.ChimeSDKMessaging.Model.PushNotificationPreferences();
            Amazon.ChimeSDKMessaging.AllowNotifications requestPreferences_preferences_PushNotifications_pushNotifications_AllowNotification = null;
            if (cmdletContext.PushNotifications_AllowNotification != null)
            {
                requestPreferences_preferences_PushNotifications_pushNotifications_AllowNotification = cmdletContext.PushNotifications_AllowNotification;
            }
            if (requestPreferences_preferences_PushNotifications_pushNotifications_AllowNotification != null)
            {
                requestPreferences_preferences_PushNotifications.AllowNotifications = requestPreferences_preferences_PushNotifications_pushNotifications_AllowNotification;
                requestPreferences_preferences_PushNotificationsIsNull = false;
            }
            System.String requestPreferences_preferences_PushNotifications_pushNotifications_FilterRule = null;
            if (cmdletContext.PushNotifications_FilterRule != null)
            {
                requestPreferences_preferences_PushNotifications_pushNotifications_FilterRule = cmdletContext.PushNotifications_FilterRule;
            }
            if (requestPreferences_preferences_PushNotifications_pushNotifications_FilterRule != null)
            {
                requestPreferences_preferences_PushNotifications.FilterRule = requestPreferences_preferences_PushNotifications_pushNotifications_FilterRule;
                requestPreferences_preferences_PushNotificationsIsNull = false;
            }
             // determine if requestPreferences_preferences_PushNotifications should be set to null
            if (requestPreferences_preferences_PushNotificationsIsNull)
            {
                requestPreferences_preferences_PushNotifications = null;
            }
            if (requestPreferences_preferences_PushNotifications != null)
            {
                request.Preferences.PushNotifications = requestPreferences_preferences_PushNotifications;
                requestPreferencesIsNull = false;
            }
             // determine if request.Preferences should be set to null
            if (requestPreferencesIsNull)
            {
                request.Preferences = null;
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
        
        private Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "PutChannelMembershipPreferences");
            try
            {
                return client.PutChannelMembershipPreferencesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ChimeBearer { get; set; }
            public System.String MemberArn { get; set; }
            public Amazon.ChimeSDKMessaging.AllowNotifications PushNotifications_AllowNotification { get; set; }
            public System.String PushNotifications_FilterRule { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.PutChannelMembershipPreferencesResponse, WriteCHMMGChannelMembershipPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
