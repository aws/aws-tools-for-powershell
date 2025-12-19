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
using Amazon.Wickr;
using Amazon.Wickr.Model;

namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Updates network-level settings for a Wickr network. You can modify settings such as
    /// client metrics, data retention, and other network-wide options.
    /// </summary>
    [Cmdlet("Update", "WICNetworkSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.Setting")]
    [AWSCmdlet("Calls the AWS Wickr Admin API UpdateNetworkSettings API operation.", Operation = new[] {"UpdateNetworkSettings"}, SelectReturnType = typeof(Amazon.Wickr.Model.UpdateNetworkSettingsResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.Setting or Amazon.Wickr.Model.UpdateNetworkSettingsResponse",
        "This cmdlet returns a collection of Amazon.Wickr.Model.Setting objects.",
        "The service call response (type Amazon.Wickr.Model.UpdateNetworkSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWICNetworkSettingCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Settings_DataRetention
        /// <summary>
        /// <para>
        /// <para>Indicates whether the data retention feature is enabled for the network. When true,
        /// messages are captured by the data retention bot for compliance and archiving purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Settings_DataRetention { get; set; }
        #endregion
        
        #region Parameter Settings_EnableClientMetric
        /// <summary>
        /// <para>
        /// <para>Allows Wickr clients to send anonymized performance and usage metrics to the Wickr
        /// backend server for service improvement and troubleshooting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_EnableClientMetrics")]
        public System.Boolean? Settings_EnableClientMetric { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network whose settings will be updated.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter Settings_ReadReceiptConfig_Status
        /// <summary>
        /// <para>
        /// <para>The read receipt status mode for the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Wickr.Status")]
        public Amazon.Wickr.Status Settings_ReadReceiptConfig_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Settings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.UpdateNetworkSettingsResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.UpdateNetworkSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Settings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WICNetworkSetting (UpdateNetworkSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.UpdateNetworkSettingsResponse, UpdateWICNetworkSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Settings_DataRetention = this.Settings_DataRetention;
            context.Settings_EnableClientMetric = this.Settings_EnableClientMetric;
            context.Settings_ReadReceiptConfig_Status = this.Settings_ReadReceiptConfig_Status;
            
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
            var request = new Amazon.Wickr.Model.UpdateNetworkSettingsRequest();
            
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.Wickr.Model.NetworkSettings();
            System.Boolean? requestSettings_settings_DataRetention = null;
            if (cmdletContext.Settings_DataRetention != null)
            {
                requestSettings_settings_DataRetention = cmdletContext.Settings_DataRetention.Value;
            }
            if (requestSettings_settings_DataRetention != null)
            {
                request.Settings.DataRetention = requestSettings_settings_DataRetention.Value;
                requestSettingsIsNull = false;
            }
            System.Boolean? requestSettings_settings_EnableClientMetric = null;
            if (cmdletContext.Settings_EnableClientMetric != null)
            {
                requestSettings_settings_EnableClientMetric = cmdletContext.Settings_EnableClientMetric.Value;
            }
            if (requestSettings_settings_EnableClientMetric != null)
            {
                request.Settings.EnableClientMetrics = requestSettings_settings_EnableClientMetric.Value;
                requestSettingsIsNull = false;
            }
            Amazon.Wickr.Model.ReadReceiptConfig requestSettings_settings_ReadReceiptConfig = null;
            
             // populate ReadReceiptConfig
            var requestSettings_settings_ReadReceiptConfigIsNull = true;
            requestSettings_settings_ReadReceiptConfig = new Amazon.Wickr.Model.ReadReceiptConfig();
            Amazon.Wickr.Status requestSettings_settings_ReadReceiptConfig_settings_ReadReceiptConfig_Status = null;
            if (cmdletContext.Settings_ReadReceiptConfig_Status != null)
            {
                requestSettings_settings_ReadReceiptConfig_settings_ReadReceiptConfig_Status = cmdletContext.Settings_ReadReceiptConfig_Status;
            }
            if (requestSettings_settings_ReadReceiptConfig_settings_ReadReceiptConfig_Status != null)
            {
                requestSettings_settings_ReadReceiptConfig.Status = requestSettings_settings_ReadReceiptConfig_settings_ReadReceiptConfig_Status;
                requestSettings_settings_ReadReceiptConfigIsNull = false;
            }
             // determine if requestSettings_settings_ReadReceiptConfig should be set to null
            if (requestSettings_settings_ReadReceiptConfigIsNull)
            {
                requestSettings_settings_ReadReceiptConfig = null;
            }
            if (requestSettings_settings_ReadReceiptConfig != null)
            {
                request.Settings.ReadReceiptConfig = requestSettings_settings_ReadReceiptConfig;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.Wickr.Model.UpdateNetworkSettingsResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.UpdateNetworkSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "UpdateNetworkSettings");
            try
            {
                #if DESKTOP
                return client.UpdateNetworkSettings(request);
                #elif CORECLR
                return client.UpdateNetworkSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String NetworkId { get; set; }
            public System.Boolean? Settings_DataRetention { get; set; }
            public System.Boolean? Settings_EnableClientMetric { get; set; }
            public Amazon.Wickr.Status Settings_ReadReceiptConfig_Status { get; set; }
            public System.Func<Amazon.Wickr.Model.UpdateNetworkSettingsResponse, UpdateWICNetworkSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Settings;
        }
        
    }
}
