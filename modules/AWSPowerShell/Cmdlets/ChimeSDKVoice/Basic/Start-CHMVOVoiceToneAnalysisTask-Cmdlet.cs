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
using Amazon.ChimeSDKVoice;
using Amazon.ChimeSDKVoice.Model;

namespace Amazon.PowerShell.Cmdlets.CHMVO
{
    /// <summary>
    /// Starts a voice tone analysis task. For more information about voice tone analysis,
    /// see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/pstn-voice-analytics.html">Using
    /// Amazon Chime SDK voice analytics</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// 
    ///  <important><para>
    /// Before starting any voice tone analysis tasks, you must provide all notices and obtain
    /// all consents from the speaker as required under applicable privacy and biometrics
    /// laws, and as required under the <a href="https://aws.amazon.com/service-terms/">AWS
    /// service terms</a> for the Amazon Chime SDK.
    /// </para></important>
    /// </summary>
    [Cmdlet("Start", "CHMVOVoiceToneAnalysisTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice StartVoiceToneAnalysisTask API operation.", Operation = new[] {"StartVoiceToneAnalysisTask"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask or Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceToneAnalysisTask object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCHMVOVoiceToneAnalysisTaskCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        [AWSConstantClassSource("Amazon.ChimeSDKVoice.LanguageCode")]
        public Amazon.ChimeSDKVoice.LanguageCode LanguageCode { get; set; }
        #endregion
        
        #region Parameter TransactionId
        /// <summary>
        /// <para>
        /// <para>The transaction ID.</para>
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
        public System.String TransactionId { get; set; }
        #endregion
        
        #region Parameter VoiceConnectorId
        /// <summary>
        /// <para>
        /// <para>The Voice Connector ID.</para>
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
        public System.String VoiceConnectorId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceToneAnalysisTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceToneAnalysisTask";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TransactionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TransactionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TransactionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TransactionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CHMVOVoiceToneAnalysisTask (StartVoiceToneAnalysisTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse, StartCHMVOVoiceToneAnalysisTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TransactionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.LanguageCode = this.LanguageCode;
            #if MODULAR
            if (this.LanguageCode == null && ParameterWasBound(nameof(this.LanguageCode)))
            {
                WriteWarning("You are passing $null as a value for parameter LanguageCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TransactionId = this.TransactionId;
            #if MODULAR
            if (this.TransactionId == null && ParameterWasBound(nameof(this.TransactionId)))
            {
                WriteWarning("You are passing $null as a value for parameter TransactionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.LanguageCode != null)
            {
                request.LanguageCode = cmdletContext.LanguageCode;
            }
            if (cmdletContext.TransactionId != null)
            {
                request.TransactionId = cmdletContext.TransactionId;
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
        
        private Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "StartVoiceToneAnalysisTask");
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
            public Amazon.ChimeSDKVoice.LanguageCode LanguageCode { get; set; }
            public System.String TransactionId { get; set; }
            public System.String VoiceConnectorId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.StartVoiceToneAnalysisTaskResponse, StartCHMVOVoiceToneAnalysisTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceToneAnalysisTask;
        }
        
    }
}
