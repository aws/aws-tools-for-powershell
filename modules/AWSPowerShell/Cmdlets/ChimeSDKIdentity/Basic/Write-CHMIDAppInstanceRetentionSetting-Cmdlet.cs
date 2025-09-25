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
using Amazon.ChimeSDKIdentity;
using Amazon.ChimeSDKIdentity.Model;

namespace Amazon.PowerShell.Cmdlets.CHMID
{
    /// <summary>
    /// Sets the amount of time in days that a given <c>AppInstance</c> retains data.
    /// </summary>
    [Cmdlet("Write", "CHMIDAppInstanceRetentionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Identity PutAppInstanceRetentionSettings API operation.", Operation = new[] {"PutAppInstanceRetentionSettings"}, SelectReturnType = typeof(Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse",
        "This cmdlet returns an Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse object containing multiple properties."
    )]
    public partial class WriteCHMIDAppInstanceRetentionSettingCmdlet : AmazonChimeSDKIdentityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppInstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the <c>AppInstance</c>.</para>
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
        public System.String AppInstanceArn { get; set; }
        #endregion
        
        #region Parameter ChannelRetentionSettings_RetentionDay
        /// <summary>
        /// <para>
        /// <para>The time in days to retain the messages in a channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AppInstanceRetentionSettings_ChannelRetentionSettings_RetentionDays")]
        public System.Int32? ChannelRetentionSettings_RetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppInstanceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppInstanceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppInstanceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMIDAppInstanceRetentionSetting (PutAppInstanceRetentionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse, WriteCHMIDAppInstanceRetentionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppInstanceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppInstanceArn = this.AppInstanceArn;
            #if MODULAR
            if (this.AppInstanceArn == null && ParameterWasBound(nameof(this.AppInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelRetentionSettings_RetentionDay = this.ChannelRetentionSettings_RetentionDay;
            
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
            var request = new Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsRequest();
            
            if (cmdletContext.AppInstanceArn != null)
            {
                request.AppInstanceArn = cmdletContext.AppInstanceArn;
            }
            
             // populate AppInstanceRetentionSettings
            var requestAppInstanceRetentionSettingsIsNull = true;
            request.AppInstanceRetentionSettings = new Amazon.ChimeSDKIdentity.Model.AppInstanceRetentionSettings();
            Amazon.ChimeSDKIdentity.Model.ChannelRetentionSettings requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings = null;
            
             // populate ChannelRetentionSettings
            var requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettingsIsNull = true;
            requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings = new Amazon.ChimeSDKIdentity.Model.ChannelRetentionSettings();
            System.Int32? requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings_channelRetentionSettings_RetentionDay = null;
            if (cmdletContext.ChannelRetentionSettings_RetentionDay != null)
            {
                requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings_channelRetentionSettings_RetentionDay = cmdletContext.ChannelRetentionSettings_RetentionDay.Value;
            }
            if (requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings_channelRetentionSettings_RetentionDay != null)
            {
                requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings.RetentionDays = requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings_channelRetentionSettings_RetentionDay.Value;
                requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettingsIsNull = false;
            }
             // determine if requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings should be set to null
            if (requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettingsIsNull)
            {
                requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings = null;
            }
            if (requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings != null)
            {
                request.AppInstanceRetentionSettings.ChannelRetentionSettings = requestAppInstanceRetentionSettings_appInstanceRetentionSettings_ChannelRetentionSettings;
                requestAppInstanceRetentionSettingsIsNull = false;
            }
             // determine if request.AppInstanceRetentionSettings should be set to null
            if (requestAppInstanceRetentionSettingsIsNull)
            {
                request.AppInstanceRetentionSettings = null;
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
        
        private Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse CallAWSServiceOperation(IAmazonChimeSDKIdentity client, Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Identity", "PutAppInstanceRetentionSettings");
            try
            {
                #if DESKTOP
                return client.PutAppInstanceRetentionSettings(request);
                #elif CORECLR
                return client.PutAppInstanceRetentionSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceArn { get; set; }
            public System.Int32? ChannelRetentionSettings_RetentionDay { get; set; }
            public System.Func<Amazon.ChimeSDKIdentity.Model.PutAppInstanceRetentionSettingsResponse, WriteCHMIDAppInstanceRetentionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
