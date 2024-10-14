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
    /// Creates a voice profile, which consists of an enrolled user and their latest voice
    /// print.
    /// 
    ///  <important><para>
    /// Before creating any voice profiles, you must provide all notices and obtain all consents
    /// from the speaker as required under applicable privacy and biometrics laws, and as
    /// required under the <a href="https://aws.amazon.com/service-terms/">AWS service terms</a>
    /// for the Amazon Chime SDK.
    /// </para></important><para>
    /// For more information about voice profiles and voice analytics, see <a href="https://docs.aws.amazon.com/chime-sdk/latest/dg/pstn-voice-analytics.html">Using
    /// Amazon Chime SDK Voice Analytics</a> in the <i>Amazon Chime SDK Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CHMVOVoiceProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKVoice.Model.VoiceProfile")]
    [AWSCmdlet("Calls the Amazon Chime SDK Voice CreateVoiceProfile API operation.", Operation = new[] {"CreateVoiceProfile"}, SelectReturnType = typeof(Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKVoice.Model.VoiceProfile or Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse",
        "This cmdlet returns an Amazon.ChimeSDKVoice.Model.VoiceProfile object.",
        "The service call response (type Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMVOVoiceProfileCmdlet : AmazonChimeSDKVoiceClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SpeakerSearchTaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the speaker search task.</para>
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
        public System.String SpeakerSearchTaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VoiceProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VoiceProfile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SpeakerSearchTaskId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SpeakerSearchTaskId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SpeakerSearchTaskId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpeakerSearchTaskId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMVOVoiceProfile (CreateVoiceProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse, NewCHMVOVoiceProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SpeakerSearchTaskId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SpeakerSearchTaskId = this.SpeakerSearchTaskId;
            #if MODULAR
            if (this.SpeakerSearchTaskId == null && ParameterWasBound(nameof(this.SpeakerSearchTaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpeakerSearchTaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKVoice.Model.CreateVoiceProfileRequest();
            
            if (cmdletContext.SpeakerSearchTaskId != null)
            {
                request.SpeakerSearchTaskId = cmdletContext.SpeakerSearchTaskId;
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
        
        private Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse CallAWSServiceOperation(IAmazonChimeSDKVoice client, Amazon.ChimeSDKVoice.Model.CreateVoiceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Voice", "CreateVoiceProfile");
            try
            {
                #if DESKTOP
                return client.CreateVoiceProfile(request);
                #elif CORECLR
                return client.CreateVoiceProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String SpeakerSearchTaskId { get; set; }
            public System.Func<Amazon.ChimeSDKVoice.Model.CreateVoiceProfileResponse, NewCHMVOVoiceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VoiceProfile;
        }
        
    }
}
