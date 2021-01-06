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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Starts recording the contact when the agent joins the call. StartContactRecording
    /// is a one-time action. For example, if you use StopContactRecording to stop recording
    /// an ongoing call, you can't use StartContactRecording to restart it. For scenarios
    /// where the recording has started and you want to suspend and resume it, such as when
    /// collecting sensitive information (for example, a credit card number), use SuspendContactRecording
    /// and ResumeContactRecording.
    /// 
    ///  
    /// <para>
    /// You can use this API to override the recording behavior configured in the <a href="https://docs.aws.amazon.com/connect/latest/adminguide/set-recording-behavior.html">Set
    /// recording behavior</a> block.
    /// </para><para>
    /// Only voice recordings are supported at this time.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CONNContactRecording", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service StartContactRecording API operation.", Operation = new[] {"StartContactRecording"}, SelectReturnType = typeof(Amazon.Connect.Model.StartContactRecordingResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.StartContactRecordingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.StartContactRecordingResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCONNContactRecordingCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact.</para>
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
        
        #region Parameter InitialContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact. This is the identifier of the contact associated with
        /// the first interaction with the contact center.</para>
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
        public System.String InitialContactId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance.</para>
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
        
        #region Parameter VoiceRecordingConfiguration_VoiceRecordingTrack
        /// <summary>
        /// <para>
        /// <para>Identifies which track is being recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.VoiceRecordingTrack")]
        public Amazon.Connect.VoiceRecordingTrack VoiceRecordingConfiguration_VoiceRecordingTrack { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.StartContactRecordingResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CONNContactRecording (StartContactRecording)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.StartContactRecordingResponse, StartCONNContactRecordingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InitialContactId = this.InitialContactId;
            #if MODULAR
            if (this.InitialContactId == null && ParameterWasBound(nameof(this.InitialContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter InitialContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceRecordingConfiguration_VoiceRecordingTrack = this.VoiceRecordingConfiguration_VoiceRecordingTrack;
            
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
            var request = new Amazon.Connect.Model.StartContactRecordingRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InitialContactId != null)
            {
                request.InitialContactId = cmdletContext.InitialContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate VoiceRecordingConfiguration
            var requestVoiceRecordingConfigurationIsNull = true;
            request.VoiceRecordingConfiguration = new Amazon.Connect.Model.VoiceRecordingConfiguration();
            Amazon.Connect.VoiceRecordingTrack requestVoiceRecordingConfiguration_voiceRecordingConfiguration_VoiceRecordingTrack = null;
            if (cmdletContext.VoiceRecordingConfiguration_VoiceRecordingTrack != null)
            {
                requestVoiceRecordingConfiguration_voiceRecordingConfiguration_VoiceRecordingTrack = cmdletContext.VoiceRecordingConfiguration_VoiceRecordingTrack;
            }
            if (requestVoiceRecordingConfiguration_voiceRecordingConfiguration_VoiceRecordingTrack != null)
            {
                request.VoiceRecordingConfiguration.VoiceRecordingTrack = requestVoiceRecordingConfiguration_voiceRecordingConfiguration_VoiceRecordingTrack;
                requestVoiceRecordingConfigurationIsNull = false;
            }
             // determine if request.VoiceRecordingConfiguration should be set to null
            if (requestVoiceRecordingConfigurationIsNull)
            {
                request.VoiceRecordingConfiguration = null;
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
        
        private Amazon.Connect.Model.StartContactRecordingResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.StartContactRecordingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "StartContactRecording");
            try
            {
                #if DESKTOP
                return client.StartContactRecording(request);
                #elif CORECLR
                return client.StartContactRecordingAsync(request).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public System.String InitialContactId { get; set; }
            public System.String InstanceId { get; set; }
            public Amazon.Connect.VoiceRecordingTrack VoiceRecordingConfiguration_VoiceRecordingTrack { get; set; }
            public System.Func<Amazon.Connect.Model.StartContactRecordingResponse, StartCONNContactRecordingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
