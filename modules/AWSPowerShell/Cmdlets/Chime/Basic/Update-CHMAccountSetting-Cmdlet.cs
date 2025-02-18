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
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Chime UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.Chime.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("None or Amazon.Chime.Model.UpdateAccountSettingsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Chime.Model.UpdateAccountSettingsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMAccountSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime account ID.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AccountSettings_DisableRemoteControl
        /// <summary>
        /// <para>
        /// <para>Setting that stops or starts remote control of shared screens during meetings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccountSettings_DisableRemoteControl { get; set; }
        #endregion
        
        #region Parameter AccountSettings_EnableDialOut
        /// <summary>
        /// <para>
        /// <para>Setting that allows meeting participants to choose the <b>Call me at a phone number</b>
        /// option. For more information, see <a href="https://docs.aws.amazon.com/chime/latest/ug/chime-join-meeting.html">Join
        /// a Meeting without the Amazon Chime App</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccountSettings_EnableDialOut { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.UpdateAccountSettingsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.UpdateAccountSettingsResponse, UpdateCHMAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AccountSettings_DisableRemoteControl = this.AccountSettings_DisableRemoteControl;
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
            var requestAccountSettingsIsNull = true;
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
        
        private Amazon.Chime.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "UpdateAccountSettings");
            try
            {
                return client.UpdateAccountSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.Chime.Model.UpdateAccountSettingsResponse, UpdateCHMAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
