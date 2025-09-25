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
    /// Updates timeouts for when human chat participants are to be considered idle, and when
    /// agents are automatically disconnected from a chat due to idleness. You can set four
    /// timers:
    /// 
    ///  <ul><li><para>
    /// Customer idle timeout
    /// </para></li><li><para>
    /// Customer auto-disconnect timeout
    /// </para></li><li><para>
    /// Agent idle timeout
    /// </para></li><li><para>
    /// Agent auto-disconnect timeout
    /// </para></li></ul><para>
    /// For more information about how chat timeouts work, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/setup-chat-timeouts.html">Set
    /// up chat timeouts for human participants</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CONNParticipantRoleConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateParticipantRoleConfig API operation.", Operation = new[] {"UpdateParticipantRoleConfig"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateParticipantRoleConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateParticipantRoleConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateParticipantRoleConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNParticipantRoleConfigCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Amazon Connect. </para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Chat_ParticipantTimerConfigList
        /// <summary>
        /// <para>
        /// <para>A list of participant timers. You can specify any unique combination of role and timer
        /// type. Duplicate entries error out the request with a 400.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChannelConfiguration_Chat_ParticipantTimerConfigList")]
        public Amazon.Connect.Model.ParticipantTimerConfiguration[] Chat_ParticipantTimerConfigList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateParticipantRoleConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNParticipantRoleConfig (UpdateParticipantRoleConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateParticipantRoleConfigResponse, UpdateCONNParticipantRoleConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Chat_ParticipantTimerConfigList != null)
            {
                context.Chat_ParticipantTimerConfigList = new List<Amazon.Connect.Model.ParticipantTimerConfiguration>(this.Chat_ParticipantTimerConfigList);
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateParticipantRoleConfigRequest();
            
            
             // populate ChannelConfiguration
            var requestChannelConfigurationIsNull = true;
            request.ChannelConfiguration = new Amazon.Connect.Model.UpdateParticipantRoleConfigChannelInfo();
            Amazon.Connect.Model.ChatParticipantRoleConfig requestChannelConfiguration_channelConfiguration_Chat = null;
            
             // populate Chat
            var requestChannelConfiguration_channelConfiguration_ChatIsNull = true;
            requestChannelConfiguration_channelConfiguration_Chat = new Amazon.Connect.Model.ChatParticipantRoleConfig();
            List<Amazon.Connect.Model.ParticipantTimerConfiguration> requestChannelConfiguration_channelConfiguration_Chat_chat_ParticipantTimerConfigList = null;
            if (cmdletContext.Chat_ParticipantTimerConfigList != null)
            {
                requestChannelConfiguration_channelConfiguration_Chat_chat_ParticipantTimerConfigList = cmdletContext.Chat_ParticipantTimerConfigList;
            }
            if (requestChannelConfiguration_channelConfiguration_Chat_chat_ParticipantTimerConfigList != null)
            {
                requestChannelConfiguration_channelConfiguration_Chat.ParticipantTimerConfigList = requestChannelConfiguration_channelConfiguration_Chat_chat_ParticipantTimerConfigList;
                requestChannelConfiguration_channelConfiguration_ChatIsNull = false;
            }
             // determine if requestChannelConfiguration_channelConfiguration_Chat should be set to null
            if (requestChannelConfiguration_channelConfiguration_ChatIsNull)
            {
                requestChannelConfiguration_channelConfiguration_Chat = null;
            }
            if (requestChannelConfiguration_channelConfiguration_Chat != null)
            {
                request.ChannelConfiguration.Chat = requestChannelConfiguration_channelConfiguration_Chat;
                requestChannelConfigurationIsNull = false;
            }
             // determine if request.ChannelConfiguration should be set to null
            if (requestChannelConfigurationIsNull)
            {
                request.ChannelConfiguration = null;
            }
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.UpdateParticipantRoleConfigResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateParticipantRoleConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateParticipantRoleConfig");
            try
            {
                return client.UpdateParticipantRoleConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Connect.Model.ParticipantTimerConfiguration> Chat_ParticipantTimerConfigList { get; set; }
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateParticipantRoleConfigResponse, UpdateCONNParticipantRoleConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
