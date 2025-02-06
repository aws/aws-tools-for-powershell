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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Sets the number of days before the channel is automatically deleted.
    /// 
    ///  <note><ul><li><para>
    /// A background process deletes expired channels within 6 hours of expiration. Actual
    /// deletion times may vary.
    /// </para></li><li><para>
    /// Expired channels that have not yet been deleted appear as active, and you can update
    /// their expiration settings. The system honors the new settings.
    /// </para></li><li><para>
    /// The <c>x-amz-chime-bearer</c> request header is mandatory. Use the ARN of the <c>AppInstanceUser</c>
    /// or <c>AppInstanceBot</c> that makes the API call as the value in the header.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Write", "CHMMGChannelExpirationSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging PutChannelExpirationSettings API operation.", Operation = new[] {"PutChannelExpirationSettings"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse",
        "This cmdlet returns an Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse object containing multiple properties."
    )]
    public partial class WriteCHMMGChannelExpirationSettingCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter ExpirationSettings_ExpirationCriterion
        /// <summary>
        /// <para>
        /// <para>The conditions that must be met for a channel to expire.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ExpirationCriterion")]
        public Amazon.ChimeSDKMessaging.ExpirationCriterion ExpirationSettings_ExpirationCriterion { get; set; }
        #endregion
        
        #region Parameter ExpirationSettings_ExpirationDay
        /// <summary>
        /// <para>
        /// <para>The period in days after which the system automatically deletes a channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpirationSettings_ExpirationDays")]
        public System.Int32? ExpirationSettings_ExpirationDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMMGChannelExpirationSetting (PutChannelExpirationSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse, WriteCHMMGChannelExpirationSettingCmdlet>(Select) ??
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
            context.ExpirationSettings_ExpirationCriterion = this.ExpirationSettings_ExpirationCriterion;
            context.ExpirationSettings_ExpirationDay = this.ExpirationSettings_ExpirationDay;
            
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
            var request = new Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            
             // populate ExpirationSettings
            var requestExpirationSettingsIsNull = true;
            request.ExpirationSettings = new Amazon.ChimeSDKMessaging.Model.ExpirationSettings();
            Amazon.ChimeSDKMessaging.ExpirationCriterion requestExpirationSettings_expirationSettings_ExpirationCriterion = null;
            if (cmdletContext.ExpirationSettings_ExpirationCriterion != null)
            {
                requestExpirationSettings_expirationSettings_ExpirationCriterion = cmdletContext.ExpirationSettings_ExpirationCriterion;
            }
            if (requestExpirationSettings_expirationSettings_ExpirationCriterion != null)
            {
                request.ExpirationSettings.ExpirationCriterion = requestExpirationSettings_expirationSettings_ExpirationCriterion;
                requestExpirationSettingsIsNull = false;
            }
            System.Int32? requestExpirationSettings_expirationSettings_ExpirationDay = null;
            if (cmdletContext.ExpirationSettings_ExpirationDay != null)
            {
                requestExpirationSettings_expirationSettings_ExpirationDay = cmdletContext.ExpirationSettings_ExpirationDay.Value;
            }
            if (requestExpirationSettings_expirationSettings_ExpirationDay != null)
            {
                request.ExpirationSettings.ExpirationDays = requestExpirationSettings_expirationSettings_ExpirationDay.Value;
                requestExpirationSettingsIsNull = false;
            }
             // determine if request.ExpirationSettings should be set to null
            if (requestExpirationSettingsIsNull)
            {
                request.ExpirationSettings = null;
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
        
        private Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "PutChannelExpirationSettings");
            try
            {
                #if DESKTOP
                return client.PutChannelExpirationSettings(request);
                #elif CORECLR
                return client.PutChannelExpirationSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String ChimeBearer { get; set; }
            public Amazon.ChimeSDKMessaging.ExpirationCriterion ExpirationSettings_ExpirationCriterion { get; set; }
            public System.Int32? ExpirationSettings_ExpirationDay { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.PutChannelExpirationSettingsResponse, WriteCHMMGChannelExpirationSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
