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
    /// Puts retention settings for the specified Amazon Chime Enterprise account. We recommend
    /// using AWS CloudTrail to monitor usage of this API for your account. For more information,
    /// see <a href="https://docs.aws.amazon.com/chime/latest/ag/cloudtrail.html">Logging
    /// Amazon Chime API Calls with AWS CloudTrail</a> in the <i>Amazon Chime Administration
    /// Guide</i>.
    /// 
    ///  
    /// <para>
    /// To turn off existing retention settings, remove the number of days from the corresponding
    /// <b>RetentionDays</b> field in the <b>RetentionSettings</b> object. For more information
    /// about retention settings, see <a href="https://docs.aws.amazon.com/chime/latest/ag/chat-retention.html">Managing
    /// Chat Retention Policies</a> in the <i>Amazon Chime Administration Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CHMRetentionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.PutRetentionSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Chime PutRetentionSettings API operation.", Operation = new[] {"PutRetentionSettings"}, SelectReturnType = typeof(Amazon.Chime.Model.PutRetentionSettingsResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.PutRetentionSettingsResponse",
        "This cmdlet returns an Amazon.Chime.Model.PutRetentionSettingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCHMRetentionSettingCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter ConversationRetentionSettings_RetentionDay
        /// <summary>
        /// <para>
        /// <para>The number of days for which to retain chat conversation messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionSettings_ConversationRetentionSettings_RetentionDays")]
        public System.Int32? ConversationRetentionSettings_RetentionDay { get; set; }
        #endregion
        
        #region Parameter RoomRetentionSettings_RetentionDay
        /// <summary>
        /// <para>
        /// <para>The number of days for which to retain chat room messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RetentionSettings_RoomRetentionSettings_RetentionDays")]
        public System.Int32? RoomRetentionSettings_RetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.PutRetentionSettingsResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.PutRetentionSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AccountId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMRetentionSetting (PutRetentionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.PutRetentionSettingsResponse, WriteCHMRetentionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConversationRetentionSettings_RetentionDay = this.ConversationRetentionSettings_RetentionDay;
            context.RoomRetentionSettings_RetentionDay = this.RoomRetentionSettings_RetentionDay;
            
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
            var request = new Amazon.Chime.Model.PutRetentionSettingsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate RetentionSettings
            var requestRetentionSettingsIsNull = true;
            request.RetentionSettings = new Amazon.Chime.Model.RetentionSettings();
            Amazon.Chime.Model.ConversationRetentionSettings requestRetentionSettings_retentionSettings_ConversationRetentionSettings = null;
            
             // populate ConversationRetentionSettings
            var requestRetentionSettings_retentionSettings_ConversationRetentionSettingsIsNull = true;
            requestRetentionSettings_retentionSettings_ConversationRetentionSettings = new Amazon.Chime.Model.ConversationRetentionSettings();
            System.Int32? requestRetentionSettings_retentionSettings_ConversationRetentionSettings_conversationRetentionSettings_RetentionDay = null;
            if (cmdletContext.ConversationRetentionSettings_RetentionDay != null)
            {
                requestRetentionSettings_retentionSettings_ConversationRetentionSettings_conversationRetentionSettings_RetentionDay = cmdletContext.ConversationRetentionSettings_RetentionDay.Value;
            }
            if (requestRetentionSettings_retentionSettings_ConversationRetentionSettings_conversationRetentionSettings_RetentionDay != null)
            {
                requestRetentionSettings_retentionSettings_ConversationRetentionSettings.RetentionDays = requestRetentionSettings_retentionSettings_ConversationRetentionSettings_conversationRetentionSettings_RetentionDay.Value;
                requestRetentionSettings_retentionSettings_ConversationRetentionSettingsIsNull = false;
            }
             // determine if requestRetentionSettings_retentionSettings_ConversationRetentionSettings should be set to null
            if (requestRetentionSettings_retentionSettings_ConversationRetentionSettingsIsNull)
            {
                requestRetentionSettings_retentionSettings_ConversationRetentionSettings = null;
            }
            if (requestRetentionSettings_retentionSettings_ConversationRetentionSettings != null)
            {
                request.RetentionSettings.ConversationRetentionSettings = requestRetentionSettings_retentionSettings_ConversationRetentionSettings;
                requestRetentionSettingsIsNull = false;
            }
            Amazon.Chime.Model.RoomRetentionSettings requestRetentionSettings_retentionSettings_RoomRetentionSettings = null;
            
             // populate RoomRetentionSettings
            var requestRetentionSettings_retentionSettings_RoomRetentionSettingsIsNull = true;
            requestRetentionSettings_retentionSettings_RoomRetentionSettings = new Amazon.Chime.Model.RoomRetentionSettings();
            System.Int32? requestRetentionSettings_retentionSettings_RoomRetentionSettings_roomRetentionSettings_RetentionDay = null;
            if (cmdletContext.RoomRetentionSettings_RetentionDay != null)
            {
                requestRetentionSettings_retentionSettings_RoomRetentionSettings_roomRetentionSettings_RetentionDay = cmdletContext.RoomRetentionSettings_RetentionDay.Value;
            }
            if (requestRetentionSettings_retentionSettings_RoomRetentionSettings_roomRetentionSettings_RetentionDay != null)
            {
                requestRetentionSettings_retentionSettings_RoomRetentionSettings.RetentionDays = requestRetentionSettings_retentionSettings_RoomRetentionSettings_roomRetentionSettings_RetentionDay.Value;
                requestRetentionSettings_retentionSettings_RoomRetentionSettingsIsNull = false;
            }
             // determine if requestRetentionSettings_retentionSettings_RoomRetentionSettings should be set to null
            if (requestRetentionSettings_retentionSettings_RoomRetentionSettingsIsNull)
            {
                requestRetentionSettings_retentionSettings_RoomRetentionSettings = null;
            }
            if (requestRetentionSettings_retentionSettings_RoomRetentionSettings != null)
            {
                request.RetentionSettings.RoomRetentionSettings = requestRetentionSettings_retentionSettings_RoomRetentionSettings;
                requestRetentionSettingsIsNull = false;
            }
             // determine if request.RetentionSettings should be set to null
            if (requestRetentionSettingsIsNull)
            {
                request.RetentionSettings = null;
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
        
        private Amazon.Chime.Model.PutRetentionSettingsResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.PutRetentionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "PutRetentionSettings");
            try
            {
                #if DESKTOP
                return client.PutRetentionSettings(request);
                #elif CORECLR
                return client.PutRetentionSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? ConversationRetentionSettings_RetentionDay { get; set; }
            public System.Int32? RoomRetentionSettings_RetentionDay { get; set; }
            public System.Func<Amazon.Chime.Model.PutRetentionSettingsResponse, WriteCHMRetentionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
