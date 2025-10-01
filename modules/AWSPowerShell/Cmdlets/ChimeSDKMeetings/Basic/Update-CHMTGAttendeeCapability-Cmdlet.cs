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
using Amazon.ChimeSDKMeetings;
using Amazon.ChimeSDKMeetings.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMTG
{
    /// <summary>
    /// The capabilities that you want to update.
    /// 
    ///  <note><para>
    /// You use the capabilities with a set of values that control what the capabilities can
    /// do, such as <c>SendReceive</c> data. For more information about those values, see
    /// .
    /// </para></note><para>
    /// When using capabilities, be aware of these corner cases:
    /// </para><ul><li><para>
    /// If you specify <c>MeetingFeatures:Video:MaxResolution:None</c> when you create a meeting,
    /// all API requests that include <c>SendReceive</c>, <c>Send</c>, or <c>Receive</c> for
    /// <c>AttendeeCapabilities:Video</c> will be rejected with <c>ValidationError 400</c>.
    /// </para></li><li><para>
    /// If you specify <c>MeetingFeatures:Content:MaxResolution:None</c> when you create a
    /// meeting, all API requests that include <c>SendReceive</c>, <c>Send</c>, or <c>Receive</c>
    /// for <c>AttendeeCapabilities:Content</c> will be rejected with <c>ValidationError 400</c>.
    /// </para></li><li><para>
    /// You can't set <c>content</c> capabilities to <c>SendReceive</c> or <c>Receive</c>
    /// unless you also set <c>video</c> capabilities to <c>SendReceive</c> or <c>Receive</c>.
    /// If you don't set the <c>video</c> capability to receive, the response will contain
    /// an HTTP 400 Bad Request status code. However, you can set your <c>video</c> capability
    /// to receive and you set your <c>content</c> capability to not receive.
    /// </para></li><li><para>
    /// If meeting features is defined as <c>Video:MaxResolution:None</c> but <c>Content:MaxResolution</c>
    /// is defined as something other than <c>None</c> and attendee capabilities are not defined
    /// in the API request, then the default attendee video capability is set to <c>Receive</c>
    /// and attendee content capability is set to <c>SendReceive</c>. This is because content
    /// <c>SendReceive</c> requires video to be at least <c>Receive</c>.
    /// </para></li><li><para>
    /// When you change an <c>audio</c> capability from <c>None</c> or <c>Receive</c> to <c>Send</c>
    /// or <c>SendReceive</c> , and if the attendee left their microphone unmuted, audio will
    /// flow from the attendee to the other meeting participants.
    /// </para></li><li><para>
    /// When you change a <c>video</c> or <c>content</c> capability from <c>None</c> or <c>Receive</c>
    /// to <c>Send</c> or <c>SendReceive</c> , and if the attendee turned on their video or
    /// content streams, remote attendees can receive those streams, but only after media
    /// renegotiation between the client and the Amazon Chime back-end server.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "CHMTGAttendeeCapability", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMeetings.Model.Attendee")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings UpdateAttendeeCapabilities API operation.", Operation = new[] {"UpdateAttendeeCapabilities"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMeetings.Model.Attendee or Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse",
        "This cmdlet returns an Amazon.ChimeSDKMeetings.Model.Attendee object.",
        "The service call response (type Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMTGAttendeeCapabilityCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttendeeId
        /// <summary>
        /// <para>
        /// <para>The ID of the attendee associated with the update request.</para>
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
        public System.String AttendeeId { get; set; }
        #endregion
        
        #region Parameter Capabilities_Audio
        /// <summary>
        /// <para>
        /// <para>The audio capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Audio { get; set; }
        #endregion
        
        #region Parameter Capabilities_Content
        /// <summary>
        /// <para>
        /// <para>The content capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Content { get; set; }
        #endregion
        
        #region Parameter MeetingId
        /// <summary>
        /// <para>
        /// <para>The ID of the meeting associated with the update request.</para>
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
        public System.String MeetingId { get; set; }
        #endregion
        
        #region Parameter Capabilities_Video
        /// <summary>
        /// <para>
        /// <para>The video capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Video { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attendee'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attendee";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MeetingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMTGAttendeeCapability (UpdateAttendeeCapabilities)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse, UpdateCHMTGAttendeeCapabilityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AttendeeId = this.AttendeeId;
            #if MODULAR
            if (this.AttendeeId == null && ParameterWasBound(nameof(this.AttendeeId)))
            {
                WriteWarning("You are passing $null as a value for parameter AttendeeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Capabilities_Audio = this.Capabilities_Audio;
            #if MODULAR
            if (this.Capabilities_Audio == null && ParameterWasBound(nameof(this.Capabilities_Audio)))
            {
                WriteWarning("You are passing $null as a value for parameter Capabilities_Audio which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Capabilities_Content = this.Capabilities_Content;
            #if MODULAR
            if (this.Capabilities_Content == null && ParameterWasBound(nameof(this.Capabilities_Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Capabilities_Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Capabilities_Video = this.Capabilities_Video;
            #if MODULAR
            if (this.Capabilities_Video == null && ParameterWasBound(nameof(this.Capabilities_Video)))
            {
                WriteWarning("You are passing $null as a value for parameter Capabilities_Video which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeetingId = this.MeetingId;
            #if MODULAR
            if (this.MeetingId == null && ParameterWasBound(nameof(this.MeetingId)))
            {
                WriteWarning("You are passing $null as a value for parameter MeetingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesRequest();
            
            if (cmdletContext.AttendeeId != null)
            {
                request.AttendeeId = cmdletContext.AttendeeId;
            }
            
             // populate Capabilities
            var requestCapabilitiesIsNull = true;
            request.Capabilities = new Amazon.ChimeSDKMeetings.Model.AttendeeCapabilities();
            Amazon.ChimeSDKMeetings.MediaCapabilities requestCapabilities_capabilities_Audio = null;
            if (cmdletContext.Capabilities_Audio != null)
            {
                requestCapabilities_capabilities_Audio = cmdletContext.Capabilities_Audio;
            }
            if (requestCapabilities_capabilities_Audio != null)
            {
                request.Capabilities.Audio = requestCapabilities_capabilities_Audio;
                requestCapabilitiesIsNull = false;
            }
            Amazon.ChimeSDKMeetings.MediaCapabilities requestCapabilities_capabilities_Content = null;
            if (cmdletContext.Capabilities_Content != null)
            {
                requestCapabilities_capabilities_Content = cmdletContext.Capabilities_Content;
            }
            if (requestCapabilities_capabilities_Content != null)
            {
                request.Capabilities.Content = requestCapabilities_capabilities_Content;
                requestCapabilitiesIsNull = false;
            }
            Amazon.ChimeSDKMeetings.MediaCapabilities requestCapabilities_capabilities_Video = null;
            if (cmdletContext.Capabilities_Video != null)
            {
                requestCapabilities_capabilities_Video = cmdletContext.Capabilities_Video;
            }
            if (requestCapabilities_capabilities_Video != null)
            {
                request.Capabilities.Video = requestCapabilities_capabilities_Video;
                requestCapabilitiesIsNull = false;
            }
             // determine if request.Capabilities should be set to null
            if (requestCapabilitiesIsNull)
            {
                request.Capabilities = null;
            }
            if (cmdletContext.MeetingId != null)
            {
                request.MeetingId = cmdletContext.MeetingId;
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
        
        private Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "UpdateAttendeeCapabilities");
            try
            {
                return client.UpdateAttendeeCapabilitiesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttendeeId { get; set; }
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Audio { get; set; }
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Content { get; set; }
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Video { get; set; }
            public System.String MeetingId { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.UpdateAttendeeCapabilitiesResponse, UpdateCHMTGAttendeeCapabilityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attendee;
        }
        
    }
}
