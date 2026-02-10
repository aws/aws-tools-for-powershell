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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the configuration settings for the specified user, including per-channel auto-accept
    /// and after contact work (ACW) timeout settings.
    /// 
    ///  <note><para>
    /// This operation replaces the UpdateUserPhoneConfig API. While UpdateUserPhoneConfig
    /// applies the same ACW timeout to all channels, UpdateUserConfig allows you to set different
    /// auto-accept and ACW timeout values for each channel type.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CONNUserConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateUserConfig API operation.", Operation = new[] {"UpdateUserConfig"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateUserConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateUserConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateUserConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNUserConfigCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AfterContactWorkConfig
        /// <summary>
        /// <para>
        /// <para>The list of after contact work (ACW) timeout configuration settings for each channel.
        /// ACW timeout specifies how many seconds agents have for after contact work, such as
        /// entering notes about the contact. The minimum setting is 1 second, and the maximum
        /// is 2,000,000 seconds (24 days). Enter 0 for an indefinite amount of time, meaning
        /// agents must manually choose to end ACW.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AfterContactWorkConfigs")]
        public Amazon.Connect.Model.AfterContactWorkConfigPerChannel[] AfterContactWorkConfig { get; set; }
        #endregion
        
        #region Parameter AutoAcceptConfig
        /// <summary>
        /// <para>
        /// <para>The list of auto-accept configuration settings for each channel. When auto-accept
        /// is enabled for a channel, available agents are automatically connected to contacts
        /// from that channel without needing to manually accept. Auto-accept connects agents
        /// to contacts in less than one second.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoAcceptConfigs")]
        public Amazon.Connect.Model.AutoAcceptConfig[] AutoAcceptConfig { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PersistentConnectionConfig
        /// <summary>
        /// <para>
        /// <para>The list of persistent connection configuration settings for each channel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PersistentConnectionConfigs")]
        public Amazon.Connect.Model.PersistentConnectionConfig[] PersistentConnectionConfig { get; set; }
        #endregion
        
        #region Parameter PhoneNumberConfig
        /// <summary>
        /// <para>
        /// <para>The list of phone number configuration settings for each channel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PhoneNumberConfigs")]
        public Amazon.Connect.Model.PhoneNumberConfig[] PhoneNumberConfig { get; set; }
        #endregion
        
        #region Parameter UserId
        /// <summary>
        /// <para>
        /// <para>The identifier of the user account.</para>
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
        public System.String UserId { get; set; }
        #endregion
        
        #region Parameter VoiceEnhancementConfig
        /// <summary>
        /// <para>
        /// <para>The list of voice enhancement configuration settings for each channel.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VoiceEnhancementConfigs")]
        public Amazon.Connect.Model.VoiceEnhancementConfig[] VoiceEnhancementConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateUserConfigResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.InstanceId),
                nameof(this.UserId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNUserConfig (UpdateUserConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateUserConfigResponse, UpdateCONNUserConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AfterContactWorkConfig != null)
            {
                context.AfterContactWorkConfig = new List<Amazon.Connect.Model.AfterContactWorkConfigPerChannel>(this.AfterContactWorkConfig);
            }
            if (this.AutoAcceptConfig != null)
            {
                context.AutoAcceptConfig = new List<Amazon.Connect.Model.AutoAcceptConfig>(this.AutoAcceptConfig);
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PersistentConnectionConfig != null)
            {
                context.PersistentConnectionConfig = new List<Amazon.Connect.Model.PersistentConnectionConfig>(this.PersistentConnectionConfig);
            }
            if (this.PhoneNumberConfig != null)
            {
                context.PhoneNumberConfig = new List<Amazon.Connect.Model.PhoneNumberConfig>(this.PhoneNumberConfig);
            }
            context.UserId = this.UserId;
            #if MODULAR
            if (this.UserId == null && ParameterWasBound(nameof(this.UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VoiceEnhancementConfig != null)
            {
                context.VoiceEnhancementConfig = new List<Amazon.Connect.Model.VoiceEnhancementConfig>(this.VoiceEnhancementConfig);
            }
            
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
            var request = new Amazon.Connect.Model.UpdateUserConfigRequest();
            
            if (cmdletContext.AfterContactWorkConfig != null)
            {
                request.AfterContactWorkConfigs = cmdletContext.AfterContactWorkConfig;
            }
            if (cmdletContext.AutoAcceptConfig != null)
            {
                request.AutoAcceptConfigs = cmdletContext.AutoAcceptConfig;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PersistentConnectionConfig != null)
            {
                request.PersistentConnectionConfigs = cmdletContext.PersistentConnectionConfig;
            }
            if (cmdletContext.PhoneNumberConfig != null)
            {
                request.PhoneNumberConfigs = cmdletContext.PhoneNumberConfig;
            }
            if (cmdletContext.UserId != null)
            {
                request.UserId = cmdletContext.UserId;
            }
            if (cmdletContext.VoiceEnhancementConfig != null)
            {
                request.VoiceEnhancementConfigs = cmdletContext.VoiceEnhancementConfig;
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
        
        private Amazon.Connect.Model.UpdateUserConfigResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateUserConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateUserConfig");
            try
            {
                return client.UpdateUserConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.AfterContactWorkConfigPerChannel> AfterContactWorkConfig { get; set; }
            public List<Amazon.Connect.Model.AutoAcceptConfig> AutoAcceptConfig { get; set; }
            public System.String InstanceId { get; set; }
            public List<Amazon.Connect.Model.PersistentConnectionConfig> PersistentConnectionConfig { get; set; }
            public List<Amazon.Connect.Model.PhoneNumberConfig> PhoneNumberConfig { get; set; }
            public System.String UserId { get; set; }
            public List<Amazon.Connect.Model.VoiceEnhancementConfig> VoiceEnhancementConfig { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateUserConfigResponse, UpdateCONNUserConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
