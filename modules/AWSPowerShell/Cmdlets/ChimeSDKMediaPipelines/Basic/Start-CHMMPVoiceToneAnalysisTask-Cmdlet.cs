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
using Amazon.ChimeSDKMediaPipelines;
using Amazon.ChimeSDKMediaPipelines.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMP
{
    /// <summary>
    /// Starts a voice tone analysis task. For more information about voice tone analysis,
    /// see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/voice-analytics.html">Using
    /// Amazon Chime SDK voice analytics</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// 
    ///  <important><para>
    /// Before starting any voice tone analysis tasks, you must provide all notices and obtain
    /// all consents from the speaker as required under applicable privacy and biometrics
    /// laws, and as required under the <a href="https://aws.amazon.com/service-terms/">AWS
    /// service terms</a> for the Amazon Chime SDK.
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "CHMMPVoiceToneAnalysisTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMediaPipelines.Model.VoiceToneAnalysisTask")]
    [AWSCmdlet("Calls the Amazon Chime SDK Media Pipelines StartVoiceToneAnalysisTask API operation.", Operation = new[] {"StartVoiceToneAnalysisTask"}, SelectReturnType = typeof(Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMediaPipelines.Model.VoiceToneAnalysisTask or Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse",
        "This cmdlet returns an Amazon.ChimeSDKMediaPipelines.Model.VoiceToneAnalysisTask object.",
        "The service call response (type Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCHMMPVoiceToneAnalysisTaskCmdlet : AmazonChimeSDKMediaPipelinesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KinesisVideoStreamSourceTaskConfiguration_ChannelId
        /// <summary>
        /// <para>
        /// <para>The channel ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? KinesisVideoStreamSourceTaskConfiguration_ChannelId { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. Use a different token for different
        /// voice tone analysis tasks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamSourceTaskConfiguration_FragmentNumber
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the fragment to begin processing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisVideoStreamSourceTaskConfiguration_FragmentNumber { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the resource to be updated. Valid values include the ID and
        /// ARN of the media insights pipeline.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter LanguageCode
        /// <summary>
        /// <para>
        /// <para>The language code.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMediaPipelines.VoiceAnalyticsLanguageCode")]
        public Amazon.ChimeSDKMediaPipelines.VoiceAnalyticsLanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter KinesisVideoStreamSourceTaskConfiguration_StreamArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KinesisVideoStreamSourceTaskConfiguration_StreamArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceToneAnalysisTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceToneAnalysisTask";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CHMMPVoiceToneAnalysisTask (StartVoiceToneAnalysisTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse, StartCHMMPVoiceToneAnalysisTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KinesisVideoStreamSourceTaskConfiguration_ChannelId = this.KinesisVideoStreamSourceTaskConfiguration_ChannelId;
            context.KinesisVideoStreamSourceTaskConfiguration_FragmentNumber = this.KinesisVideoStreamSourceTaskConfiguration_FragmentNumber;
            context.KinesisVideoStreamSourceTaskConfiguration_StreamArn = this.KinesisVideoStreamSourceTaskConfiguration_StreamArn;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            
             // populate KinesisVideoStreamSourceTaskConfiguration
            var requestKinesisVideoStreamSourceTaskConfigurationIsNull = true;
            request.KinesisVideoStreamSourceTaskConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.KinesisVideoStreamSourceTaskConfiguration();
            System.Int32? requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_ChannelId = null;
            if (cmdletContext.KinesisVideoStreamSourceTaskConfiguration_ChannelId != null)
            {
                requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_ChannelId = cmdletContext.KinesisVideoStreamSourceTaskConfiguration_ChannelId.Value;
            }
            if (requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_ChannelId != null)
            {
                request.KinesisVideoStreamSourceTaskConfiguration.ChannelId = requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_ChannelId.Value;
                requestKinesisVideoStreamSourceTaskConfigurationIsNull = false;
            }
            System.String requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_FragmentNumber = null;
            if (cmdletContext.KinesisVideoStreamSourceTaskConfiguration_FragmentNumber != null)
            {
                requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_FragmentNumber = cmdletContext.KinesisVideoStreamSourceTaskConfiguration_FragmentNumber;
            }
            if (requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_FragmentNumber != null)
            {
                request.KinesisVideoStreamSourceTaskConfiguration.FragmentNumber = requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_FragmentNumber;
                requestKinesisVideoStreamSourceTaskConfigurationIsNull = false;
            }
            System.String requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_StreamArn = null;
            if (cmdletContext.KinesisVideoStreamSourceTaskConfiguration_StreamArn != null)
            {
                requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_StreamArn = cmdletContext.KinesisVideoStreamSourceTaskConfiguration_StreamArn;
            }
            if (requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_StreamArn != null)
            {
                request.KinesisVideoStreamSourceTaskConfiguration.StreamArn = requestKinesisVideoStreamSourceTaskConfiguration_kinesisVideoStreamSourceTaskConfiguration_StreamArn;
                requestKinesisVideoStreamSourceTaskConfigurationIsNull = false;
            }
             // determine if request.KinesisVideoStreamSourceTaskConfiguration should be set to null
            if (requestKinesisVideoStreamSourceTaskConfigurationIsNull)
            {
                request.KinesisVideoStreamSourceTaskConfiguration = null;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
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
        
        private Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse CallAWSServiceOperation(IAmazonChimeSDKMediaPipelines client, Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Media Pipelines", "StartVoiceToneAnalysisTask");
            try
            {
                #if DESKTOP
                return client.StartVoiceToneAnalysisTask(request);
                #elif CORECLR
                return client.StartVoiceToneAnalysisTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Identifier { get; set; }
            public System.Int32? KinesisVideoStreamSourceTaskConfiguration_ChannelId { get; set; }
            public System.String KinesisVideoStreamSourceTaskConfiguration_FragmentNumber { get; set; }
            public System.String KinesisVideoStreamSourceTaskConfiguration_StreamArn { get; set; }
            public Amazon.ChimeSDKMediaPipelines.VoiceAnalyticsLanguageCode LanguageCode { get; set; }
            public System.Func<Amazon.ChimeSDKMediaPipelines.Model.StartVoiceToneAnalysisTaskResponse, StartCHMMPVoiceToneAnalysisTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceToneAnalysisTask;
        }
        
    }
}
