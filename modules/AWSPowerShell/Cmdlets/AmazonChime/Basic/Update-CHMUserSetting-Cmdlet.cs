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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates the settings for the specified user, such as phone number settings.
    /// </summary>
    [Cmdlet("Update", "CHMUserSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Chime UpdateUserSettings API operation.", Operation = new[] {"UpdateUserSettings"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the UserId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Chime.Model.UpdateUserSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHMUserSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Telephony_InboundCalling
        /// <summary>
        /// <para>
        /// <para>Allows or denies inbound calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserSettings_Telephony_InboundCalling")]
        public System.Boolean Telephony_InboundCalling { get; set; }
        #endregion
        
        #region Parameter Telephony_OutboundCalling
        /// <summary>
        /// <para>
        /// <para>Allows or denies outbound calling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserSettings_Telephony_OutboundCalling")]
        public System.Boolean Telephony_OutboundCalling { get; set; }
        #endregion
        
        #region Parameter Telephony_SMS
        /// <summary>
        /// <para>
        /// <para>Allows or denies SMS messaging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserSettings_Telephony_SMS")]
        public System.Boolean Telephony_SMS { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the UserId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMUserSetting (UpdateUserSettings)"))
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
            
            context.AccountId = this.AccountId;
            context.UserId = this.UserId;
            if (ParameterWasBound("Telephony_InboundCalling"))
                context.UserSettings_Telephony_InboundCalling = this.Telephony_InboundCalling;
            if (ParameterWasBound("Telephony_OutboundCalling"))
                context.UserSettings_Telephony_OutboundCalling = this.Telephony_OutboundCalling;
            if (ParameterWasBound("Telephony_SMS"))
                context.UserSettings_Telephony_SMS = this.Telephony_SMS;
            
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
            var request = new Amazon.Chime.Model.UpdateUserSettingsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            
             // populate UserSettings
            bool requestUserSettingsIsNull = true;
            request.UserSettings = new Amazon.Chime.Model.UserSettings();
            Amazon.Chime.Model.TelephonySettings requestUserSettings_userSettings_Telephony = null;
            
             // populate Telephony
            bool requestUserSettings_userSettings_TelephonyIsNull = true;
            requestUserSettings_userSettings_Telephony = new Amazon.Chime.Model.TelephonySettings();
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_InboundCalling = null;
            if (cmdletContext.UserSettings_Telephony_InboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_InboundCalling = cmdletContext.UserSettings_Telephony_InboundCalling.Value;
            }
            if (requestUserSettings_userSettings_Telephony_telephony_InboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony.InboundCalling = requestUserSettings_userSettings_Telephony_telephony_InboundCalling.Value;
                requestUserSettings_userSettings_TelephonyIsNull = false;
            }
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_OutboundCalling = null;
            if (cmdletContext.UserSettings_Telephony_OutboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_OutboundCalling = cmdletContext.UserSettings_Telephony_OutboundCalling.Value;
            }
            if (requestUserSettings_userSettings_Telephony_telephony_OutboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony.OutboundCalling = requestUserSettings_userSettings_Telephony_telephony_OutboundCalling.Value;
                requestUserSettings_userSettings_TelephonyIsNull = false;
            }
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_SMS = null;
            if (cmdletContext.UserSettings_Telephony_SMS != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_SMS = cmdletContext.UserSettings_Telephony_SMS.Value;
            }
            if (requestUserSettings_userSettings_Telephony_telephony_SMS != null)
            {
                requestUserSettings_userSettings_Telephony.SMS = requestUserSettings_userSettings_Telephony_telephony_SMS.Value;
                requestUserSettings_userSettings_TelephonyIsNull = false;
            }
             // determine if requestUserSettings_userSettings_Telephony should be set to null
            if (requestUserSettings_userSettings_TelephonyIsNull)
            {
                requestUserSettings_userSettings_Telephony = null;
            }
            if (requestUserSettings_userSettings_Telephony != null)
            {
                request.UserSettings.Telephony = requestUserSettings_userSettings_Telephony;
                requestUserSettingsIsNull = false;
            }
             // determine if request.UserSettings should be set to null
            if (requestUserSettingsIsNull)
            {
                request.UserSettings = null;
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
                    pipelineOutput = this.UserId;
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
        
        private Amazon.Chime.Model.UpdateUserSettingsResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateUserSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateUserSettings");
            try
            {
                #if DESKTOP
                return client.UpdateUserSettings(request);
                #elif CORECLR
                return client.UpdateUserSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String UserId { get; set; }
            public System.Boolean? UserSettings_Telephony_InboundCalling { get; set; }
            public System.Boolean? UserSettings_Telephony_OutboundCalling { get; set; }
            public System.Boolean? UserSettings_Telephony_SMS { get; set; }
        }
        
    }
}
