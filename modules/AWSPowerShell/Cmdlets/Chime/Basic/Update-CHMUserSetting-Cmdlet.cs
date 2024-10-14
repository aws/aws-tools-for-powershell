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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Updates the settings for the specified user, such as phone number settings.
    /// </summary>
    [Cmdlet("Update", "CHMUserSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime UpdateUserSettings API operation.", Operation = new[] {"UpdateUserSettings"}, SelectReturnType = typeof(Amazon.Chime.Model.UpdateUserSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.Chime.Model.UpdateUserSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Chime.Model.UpdateUserSettingsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMUserSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime account ID.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Telephony_InboundCalling
        /// <summary>
        /// <para>
        /// <para>Allows or denies inbound calling.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UserSettings_Telephony_InboundCalling")]
        public System.Boolean? Telephony_InboundCalling { get; set; }
        #endregion
        
        #region Parameter Telephony_OutboundCalling
        /// <summary>
        /// <para>
        /// <para>Allows or denies outbound calling.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UserSettings_Telephony_OutboundCalling")]
        public System.Boolean? Telephony_OutboundCalling { get; set; }
        #endregion
        
        #region Parameter Telephony_SMS
        /// <summary>
        /// <para>
        /// <para>Allows or denies SMS messaging.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("UserSettings_Telephony_SMS")]
        public System.Boolean? Telephony_SMS { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The user ID.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.UpdateUserSettingsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMUserSetting (UpdateUserSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.UpdateUserSettingsResponse, UpdateCHMUserSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Telephony_InboundCalling = this.Telephony_InboundCalling;
            #if MODULAR
            if (this.Telephony_InboundCalling == null && ParameterWasBound(nameof(this.Telephony_InboundCalling)))
            {
                WriteWarning("You are passing $null as a value for parameter Telephony_InboundCalling which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Telephony_OutboundCalling = this.Telephony_OutboundCalling;
            #if MODULAR
            if (this.Telephony_OutboundCalling == null && ParameterWasBound(nameof(this.Telephony_OutboundCalling)))
            {
                WriteWarning("You are passing $null as a value for parameter Telephony_OutboundCalling which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Telephony_SMS = this.Telephony_SMS;
            #if MODULAR
            if (this.Telephony_SMS == null && ParameterWasBound(nameof(this.Telephony_SMS)))
            {
                WriteWarning("You are passing $null as a value for parameter Telephony_SMS which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var requestUserSettingsIsNull = true;
            request.UserSettings = new Amazon.Chime.Model.UserSettings();
            Amazon.Chime.Model.TelephonySettings requestUserSettings_userSettings_Telephony = null;
            
             // populate Telephony
            var requestUserSettings_userSettings_TelephonyIsNull = true;
            requestUserSettings_userSettings_Telephony = new Amazon.Chime.Model.TelephonySettings();
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_InboundCalling = null;
            if (cmdletContext.Telephony_InboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_InboundCalling = cmdletContext.Telephony_InboundCalling.Value;
            }
            if (requestUserSettings_userSettings_Telephony_telephony_InboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony.InboundCalling = requestUserSettings_userSettings_Telephony_telephony_InboundCalling.Value;
                requestUserSettings_userSettings_TelephonyIsNull = false;
            }
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_OutboundCalling = null;
            if (cmdletContext.Telephony_OutboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_OutboundCalling = cmdletContext.Telephony_OutboundCalling.Value;
            }
            if (requestUserSettings_userSettings_Telephony_telephony_OutboundCalling != null)
            {
                requestUserSettings_userSettings_Telephony.OutboundCalling = requestUserSettings_userSettings_Telephony_telephony_OutboundCalling.Value;
                requestUserSettings_userSettings_TelephonyIsNull = false;
            }
            System.Boolean? requestUserSettings_userSettings_Telephony_telephony_SMS = null;
            if (cmdletContext.Telephony_SMS != null)
            {
                requestUserSettings_userSettings_Telephony_telephony_SMS = cmdletContext.Telephony_SMS.Value;
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
            public System.Boolean? Telephony_InboundCalling { get; set; }
            public System.Boolean? Telephony_OutboundCalling { get; set; }
            public System.Boolean? Telephony_SMS { get; set; }
            public System.Func<Amazon.Chime.Model.UpdateUserSettingsResponse, UpdateCHMUserSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
