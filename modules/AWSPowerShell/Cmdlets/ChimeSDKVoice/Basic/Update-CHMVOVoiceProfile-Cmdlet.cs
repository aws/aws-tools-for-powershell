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
    /// Updates the specified voice profile’s voice print and refreshes its expiration timestamp.
    /// 
    ///  <important><para>
    /// As a condition of using this feature, you acknowledge that the collection, use, storage,
    /// and retention of your caller’s biometric identifiers and biometric information (“biometric
    /// data”) in the form of a digital voiceprint requires the caller’s informed consent
    /// via a written release. Such consent is required under various state laws, including
    /// biometrics laws in Illinois, Texas, Washington and other state privacy laws.
    /// </para><para>
    /// You must provide a written release to each caller through a process that clearly reflects
    /// each caller’s informed consent before using Amazon Chime SDK Voice Insights service,
    /// as required under the terms of your agreement with AWS governing your use of the service.
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "CHMVOVoiceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceProfile")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice UpdateVoiceProfile API operation.", Operation = new[] {"UpdateVoiceProfile"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceProfile or Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceProfile object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMVOVoiceProfileCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SpeakerSearchTaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the speaker search task.</para>
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
        public System.String SpeakerSearchTaskId { get; set; }
        #endregion
        
        #region Parameter VoiceProfileId
        /// <summary>
        /// <para>
        /// <para>The profile ID.</para>
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
        public System.String VoiceProfileId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceProfile";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VoiceProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMVOVoiceProfile (UpdateVoiceProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse, UpdateCHMVOVoiceProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SpeakerSearchTaskId = this.SpeakerSearchTaskId;
            #if MODULAR
            if (this.SpeakerSearchTaskId == null && ParameterWasBound(nameof(this.SpeakerSearchTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpeakerSearchTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceProfileId = this.VoiceProfileId;
            #if MODULAR
            if (this.VoiceProfileId == null && ParameterWasBound(nameof(this.VoiceProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileRequest();
            
            if (cmdletContext.SpeakerSearchTaskId != null)
            {
                request.SpeakerSearchTaskId = cmdletContext.SpeakerSearchTaskId;
            }
            if (cmdletContext.VoiceProfileId != null)
            {
                request.VoiceProfileId = cmdletContext.VoiceProfileId;
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
        
        private Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "UpdateVoiceProfile");
            try
            {
                return client.UpdateVoiceProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SpeakerSearchTaskId { get; set; }
            public System.String VoiceProfileId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.UpdateVoiceProfileResponse, UpdateCHMVOVoiceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceProfile;
        }
        
    }
}
