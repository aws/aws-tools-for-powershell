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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Updates a Voice Connector's streaming configuration settings.
    /// </summary>
    [Cmdlet("Write", "CHMVOVoiceConnectorStreamingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.StreamingConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice PutVoiceConnectorStreamingConfiguration API operation.", Operation = new[] {"PutVoiceConnectorStreamingConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.StreamingConfiguration or Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.StreamingConfiguration object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCHMVOVoiceConnectorStreamingConfigurationCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MediaInsightsConfiguration_ConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The configuration's ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingConfiguration_MediaInsightsConfiguration_ConfigurationArn")]
        public System.String MediaInsightsConfiguration_ConfigurationArn { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_DataRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The amount of time, in hours, to the Kinesis data.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("StreamingConfiguration_DataRetentionInHours")]
        public System.Int32? StreamingConfiguration_DataRetentionInHour { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_Disabled
        /// <summary>
        /// <para>
        /// <para>When true, streaming to Kinesis is off.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? StreamingConfiguration_Disabled { get; set; }
        #endregion
        
        #region Parameter MediaInsightsConfiguration_Disabled
        /// <summary>
        /// <para>
        /// <para>Denotes the configuration as enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingConfiguration_MediaInsightsConfiguration_Disabled")]
        public System.Boolean? MediaInsightsConfiguration_Disabled { get; set; }
        #endregion
        
        #region Parameter StreamingConfiguration_StreamingNotificationTarget
        /// <summary>
        /// <para>
        /// <para>The streaming notification targets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamingConfiguration_StreamingNotificationTargets")]
        public Amazon.ChimeSDKVoice.Model.StreamingNotificationTarget[] StreamingConfiguration_StreamingNotificationTarget { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamingConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamingConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CHMVOVoiceConnectorStreamingConfiguration (PutVoiceConnectorStreamingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse, WriteCHMVOVoiceConnectorStreamingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StreamingConfiguration_DataRetentionInHour = this.StreamingConfiguration_DataRetentionInHour;
            #if MODULAR
            if (this.StreamingConfiguration_DataRetentionInHour == null && ParameterWasBound(nameof(this.StreamingConfiguration_DataRetentionInHour)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingConfiguration_DataRetentionInHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamingConfiguration_Disabled = this.StreamingConfiguration_Disabled;
            #if MODULAR
            if (this.StreamingConfiguration_Disabled == null && ParameterWasBound(nameof(this.StreamingConfiguration_Disabled)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamingConfiguration_Disabled which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaInsightsConfiguration_ConfigurationArn = this.MediaInsightsConfiguration_ConfigurationArn;
            context.MediaInsightsConfiguration_Disabled = this.MediaInsightsConfiguration_Disabled;
            if (this.StreamingConfiguration_StreamingNotificationTarget != null)
            {
                context.StreamingConfiguration_StreamingNotificationTarget = new List<Amazon.ChimeSDKVoice.Model.StreamingNotificationTarget>(this.StreamingConfiguration_StreamingNotificationTarget);
            }
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
            var request = new Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationRequest();
            
            
             // populate StreamingConfiguration
            var requestStreamingConfigurationIsNull = true;
            request.StreamingConfiguration = new Amazon.ChimeSDKVoice.Model.StreamingConfiguration();
            System.Int32? requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour = null;
            if (cmdletContext.StreamingConfiguration_DataRetentionInHour != null)
            {
                requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour = cmdletContext.StreamingConfiguration_DataRetentionInHour.Value;
            }
            if (requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour != null)
            {
                request.StreamingConfiguration.DataRetentionInHours = requestStreamingConfiguration_streamingConfiguration_DataRetentionInHour.Value;
                requestStreamingConfigurationIsNull = false;
            }
            System.Boolean? requestStreamingConfiguration_streamingConfiguration_Disabled = null;
            if (cmdletContext.StreamingConfiguration_Disabled != null)
            {
                requestStreamingConfiguration_streamingConfiguration_Disabled = cmdletContext.StreamingConfiguration_Disabled.Value;
            }
            if (requestStreamingConfiguration_streamingConfiguration_Disabled != null)
            {
                request.StreamingConfiguration.Disabled = requestStreamingConfiguration_streamingConfiguration_Disabled.Value;
                requestStreamingConfigurationIsNull = false;
            }
            List<Amazon.ChimeSDKVoice.Model.StreamingNotificationTarget> requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget = null;
            if (cmdletContext.StreamingConfiguration_StreamingNotificationTarget != null)
            {
                requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget = cmdletContext.StreamingConfiguration_StreamingNotificationTarget;
            }
            if (requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget != null)
            {
                request.StreamingConfiguration.StreamingNotificationTargets = requestStreamingConfiguration_streamingConfiguration_StreamingNotificationTarget;
                requestStreamingConfigurationIsNull = false;
            }
            Amazon.ChimeSDKVoice.Model.MediaInsightsConfiguration requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration = null;
            
             // populate MediaInsightsConfiguration
            var requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfigurationIsNull = true;
            requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration = new Amazon.ChimeSDKVoice.Model.MediaInsightsConfiguration();
            System.String requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_ConfigurationArn = null;
            if (cmdletContext.MediaInsightsConfiguration_ConfigurationArn != null)
            {
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_ConfigurationArn = cmdletContext.MediaInsightsConfiguration_ConfigurationArn;
            }
            if (requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_ConfigurationArn != null)
            {
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration.ConfigurationArn = requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_ConfigurationArn;
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfigurationIsNull = false;
            }
            System.Boolean? requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_Disabled = null;
            if (cmdletContext.MediaInsightsConfiguration_Disabled != null)
            {
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_Disabled = cmdletContext.MediaInsightsConfiguration_Disabled.Value;
            }
            if (requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_Disabled != null)
            {
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration.Disabled = requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration_mediaInsightsConfiguration_Disabled.Value;
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfigurationIsNull = false;
            }
             // determine if requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration should be set to null
            if (requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfigurationIsNull)
            {
                requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration = null;
            }
            if (requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration != null)
            {
                request.StreamingConfiguration.MediaInsightsConfiguration = requestStreamingConfiguration_streamingConfiguration_MediaInsightsConfiguration;
                requestStreamingConfigurationIsNull = false;
            }
             // determine if request.StreamingConfiguration should be set to null
            if (requestStreamingConfigurationIsNull)
            {
                request.StreamingConfiguration = null;
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
        
        private Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "PutVoiceConnectorStreamingConfiguration");
            try
            {
                #if DESKTOP
                return client.PutVoiceConnectorStreamingConfiguration(request);
                #elif CORECLR
                return client.PutVoiceConnectorStreamingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? StreamingConfiguration_DataRetentionInHour { get; set; }
            public System.Boolean? StreamingConfiguration_Disabled { get; set; }
            public System.String MediaInsightsConfiguration_ConfigurationArn { get; set; }
            public System.Boolean? MediaInsightsConfiguration_Disabled { get; set; }
            public List<Amazon.ChimeSDKVoice.Model.StreamingNotificationTarget> StreamingConfiguration_StreamingNotificationTarget { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.PutVoiceConnectorStreamingConfigurationResponse, WriteCHMVOVoiceConnectorStreamingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamingConfiguration;
        }
        
    }
}
