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
    /// Updates the settings for the specified Amazon Chime account. You can update settings
    /// for remote control of shared screens, or for the dial-out option. For more information
    /// about these settings, see <a href="https://docs.aws.amazon.com/chime/latest/ag/policies.html">Use
    /// the Policies Page</a> in the <i>Amazon Chime Administration Guide</i>.
    /// </summary>
    [Cmdlet("Update", "CHMAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Chime UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AccountId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Chime.Model.UpdateAccountSettingsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCHMAccountSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime account ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AccountSettings_DisableRemoteControl
        /// <summary>
        /// <para>
        /// <para>Setting that stops or starts remote control of shared screens during meetings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AccountSettings_DisableRemoteControl { get; set; }
        #endregion
        
        #region Parameter AccountSettings_EnableDialOut
        /// <summary>
        /// <para>
        /// <para>Setting that allows meeting participants to choose the <b>Call me at a phone number</b>
        /// option. For more information, see <a href="https://docs.aws.amazon.com/chime/latest/ug/chime-join-meeting.html">Join
        /// a Meeting without the Amazon Chime App</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AccountSettings_EnableDialOut { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AccountId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AccountId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMAccountSetting (UpdateAccountSettings)"))
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
            if (ParameterWasBound("AccountSettings_DisableRemoteControl"))
                context.AccountSettings_DisableRemoteControl = this.AccountSettings_DisableRemoteControl;
            if (ParameterWasBound("AccountSettings_EnableDialOut"))
                context.AccountSettings_EnableDialOut = this.AccountSettings_EnableDialOut;
            
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
            var request = new Amazon.Chime.Model.UpdateAccountSettingsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate AccountSettings
            bool requestAccountSettingsIsNull = true;
            request.AccountSettings = new Amazon.Chime.Model.AccountSettings();
            System.Boolean? requestAccountSettings_accountSettings_DisableRemoteControl = null;
            if (cmdletContext.AccountSettings_DisableRemoteControl != null)
            {
                requestAccountSettings_accountSettings_DisableRemoteControl = cmdletContext.AccountSettings_DisableRemoteControl.Value;
            }
            if (requestAccountSettings_accountSettings_DisableRemoteControl != null)
            {
                request.AccountSettings.DisableRemoteControl = requestAccountSettings_accountSettings_DisableRemoteControl.Value;
                requestAccountSettingsIsNull = false;
            }
            System.Boolean? requestAccountSettings_accountSettings_EnableDialOut = null;
            if (cmdletContext.AccountSettings_EnableDialOut != null)
            {
                requestAccountSettings_accountSettings_EnableDialOut = cmdletContext.AccountSettings_EnableDialOut.Value;
            }
            if (requestAccountSettings_accountSettings_EnableDialOut != null)
            {
                request.AccountSettings.EnableDialOut = requestAccountSettings_accountSettings_EnableDialOut.Value;
                requestAccountSettingsIsNull = false;
            }
             // determine if request.AccountSettings should be set to null
            if (requestAccountSettingsIsNull)
            {
                request.AccountSettings = null;
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
                    pipelineOutput = this.AccountId;
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
        
        private Amazon.Chime.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateAccountSettings");
            try
            {
                #if DESKTOP
                return client.UpdateAccountSettings(request);
                #elif CORECLR
                return client.UpdateAccountSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AccountSettings_DisableRemoteControl { get; set; }
            public System.Boolean? AccountSettings_EnableDialOut { get; set; }
        }
        
    }
}
