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
using Amazon.ChimeSDKMeetings;
using Amazon.ChimeSDKMeetings.Model;

namespace Amazon.PowerShell.Cmdlets.CHMTG
{
    /// <summary>
    /// Creates a new attendee for an active Amazon Chime SDK meeting. For more information
    /// about the Amazon Chime SDK, see <a href="https://docs.aws.amazon.com/chime/latest/dg/meetings-sdk.html">Using
    /// the Amazon Chime SDK</a> in the <i>Amazon Chime Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMTGAttendee", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMeetings.Model.Attendee")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings CreateAttendee API operation.", Operation = new[] {"CreateAttendee"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMeetings.Model.Attendee or Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse",
        "This cmdlet returns an Amazon.ChimeSDKMeetings.Model.Attendee object.",
        "The service call response (type Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMTGAttendeeCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Capabilities_Audio
        /// <summary>
        /// <para>
        /// <para>The audio capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Audio { get; set; }
        #endregion
        
        #region Parameter Capabilities_Content
        /// <summary>
        /// <para>
        /// <para>The content capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Content { get; set; }
        #endregion
        
        #region Parameter ExternalUserId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime SDK external user ID. An idempotency token. Links the attendee to
        /// an identity managed by a builder application.</para><para>Pattern: <c>[-_&amp;@+=,(){}\[\]\/«».:|'"#a-zA-Z0-9À-ÿ\s]*</c></para><para>Values that begin with <c>aws:</c> are reserved. You can't configure a value that
        /// uses this prefix.</para>
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
        public System.String ExternalUserId { get; set; }
        #endregion
        
        #region Parameter MeetingId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the meeting.</para>
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
        public System.String MeetingId { get; set; }
        #endregion
        
        #region Parameter Capabilities_Video
        /// <summary>
        /// <para>
        /// <para>The video capability assigned to an attendee.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MediaCapabilities")]
        public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Video { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Attendee'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Attendee";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ExternalUserId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ExternalUserId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ExternalUserId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExternalUserId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMTGAttendee (CreateAttendee)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse, NewCHMTGAttendeeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ExternalUserId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Capabilities_Audio = this.Capabilities_Audio;
            context.Capabilities_Content = this.Capabilities_Content;
            context.Capabilities_Video = this.Capabilities_Video;
            context.ExternalUserId = this.ExternalUserId;
            #if MODULAR
            if (this.ExternalUserId == null && ParameterWasBound(nameof(this.ExternalUserId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalUserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequest();
            
            
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
            if (cmdletContext.ExternalUserId != null)
            {
                request.ExternalUserId = cmdletContext.ExternalUserId;
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
        
        private Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "CreateAttendee");
            try
            {
                #if DESKTOP
                return client.CreateAttendee(request);
                #elif CORECLR
                return client.CreateAttendeeAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Audio { get; set; }
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Content { get; set; }
            public Amazon.ChimeSDKMeetings.MediaCapabilities Capabilities_Video { get; set; }
            public System.String ExternalUserId { get; set; }
            public System.String MeetingId { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.CreateAttendeeResponse, NewCHMTGAttendeeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Attendee;
        }
        
    }
}
