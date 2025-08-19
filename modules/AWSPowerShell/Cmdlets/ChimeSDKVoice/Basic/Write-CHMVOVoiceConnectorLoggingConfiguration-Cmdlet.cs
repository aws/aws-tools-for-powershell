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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Updates a Voice Connector's logging configuration.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.LoggingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorLoggingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorLoggingConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.LoggingConfiguration or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.LoggingConfiguration object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorLoggingConfigurationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LoggingConfiguration_EnableMediaMetricLog
        /// <summary>
        /// <para>
        /// <para>Enables or disables media metrics logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_EnableMediaMetricLogs")]
        public System.Boolean? LoggingConfiguration_EnableMediaMetricLog { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_EnableSIPLog
        /// <summary>
        /// <para>
        /// <para>Boolean that enables sending SIP message logs to Amazon CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingConfiguration_EnableSIPLogs")]
        public System.Boolean? LoggingConfiguration_EnableSIPLog { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LoggingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LoggingConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorLoggingConfiguration (PutVoiceConnectorLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse, WriteCHMVOVoiceConnectorLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LoggingConfiguration_EnableMediaMetricLog = this.LoggingConfiguration_EnableMediaMetricLog;
            context.LoggingConfiguration_EnableSIPLog = this.LoggingConfiguration_EnableSIPLog;
            context.VoiceConnectorId = this.VoiceConnectorId;
            #if MODULAR
            if (this.VoiceConnectorId == null && ParameterWasBound(nameof(this.VoiceConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationRequest();
            
            
             // populate LoggingConfiguration
            request.LoggingConfiguration = new Amazon.ChimeSDKVoice.Model.LoggingConfiguration();
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog = null;
            if (cmdletContext.LoggingConfiguration_EnableMediaMetricLog != null)
            {
                requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog = cmdletContext.LoggingConfiguration_EnableMediaMetricLog.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog != null)
            {
                request.LoggingConfiguration.EnableMediaMetricLogs = requestLoggingConfiguration_loggingConfiguration_EnableMediaMetricLog.Value;
            }
            System.Boolean? requestLoggingConfiguration_loggingConfiguration_EnableSIPLog = null;
            if (cmdletContext.LoggingConfiguration_EnableSIPLog != null)
            {
                requestLoggingConfiguration_loggingConfiguration_EnableSIPLog = cmdletContext.LoggingConfiguration_EnableSIPLog.Value;
            }
            if (requestLoggingConfiguration_loggingConfiguration_EnableSIPLog != null)
            {
                request.LoggingConfiguration.EnableSIPLogs = requestLoggingConfiguration_loggingConfiguration_EnableSIPLog.Value;
            }
            if (cmdletContext.VoiceConnectorId != null)
            {
                request.VoiceConnectorId = cmdletContext.VoiceConnectorId;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorLoggingConfiguration");
            try
            {
                return client.PutVoiceConnectorLoggingConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? LoggingConfiguration_EnableMediaMetricLog { get; set; }
            public System.Boolean? LoggingConfiguration_EnableSIPLog { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorLoggingConfigurationResponse, WriteCHMVOVoiceConnectorLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LoggingConfiguration;
        }
        
    }
}
