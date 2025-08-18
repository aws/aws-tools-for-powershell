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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Adds a new participant into an on-going chat contact or webRTC call. For more information,
    /// see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/chat-customize-flow.html">Customize
    /// chat flow experiences by integrating custom participants</a> or <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-multiuser-inapp.html">Enable
    /// multi-user web, in-app, and video calling</a>.
    /// </summary>
    [Cmdlet("New", "CONNParticipant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateParticipantResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateParticipant API operation.", Operation = new[] {"CreateParticipant"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateParticipantResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateParticipantResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateParticipantResponse object containing multiple properties."
    )]
    public partial class NewCONNParticipantCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Amazon Connect. Supports contacts
        /// in the CHAT channel and VOICE (WebRTC) channels. For WebRTC calls, this should be
        /// the initial contact ID that was generated when the contact was first created (from
        /// the StartWebRTCContact API) in the VOICE channel</para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the participant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParticipantDetails_DisplayName { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance. </para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter ParticipantDetails_ParticipantRole
        /// <summary>
        /// <para>
        /// <para>The role of the participant being added.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.ParticipantRole")]
        public Amazon.Connect.ParticipantRole ParticipantDetails_ParticipantRole { get; set; }
        #endregion
        
        #region Parameter ParticipantCapabilities_ScreenShare
        /// <summary>
        /// <para>
        /// <para>The screen sharing capability that is enabled for the participant. <c>SEND</c> indicates
        /// the participant can share their screen.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParticipantDetails_ParticipantCapabilities_ScreenShare")]
        [AWSConstantClassSource("Amazon.Connect.ScreenShareCapability")]
        public Amazon.Connect.ScreenShareCapability ParticipantCapabilities_ScreenShare { get; set; }
        #endregion
        
        #region Parameter ParticipantCapabilities_Video
        /// <summary>
        /// <para>
        /// <para>The configuration having the video and screen sharing capabilities for participants
        /// over the call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ParticipantDetails_ParticipantCapabilities_Video")]
        [AWSConstantClassSource("Amazon.Connect.VideoCapability")]
        public Amazon.Connect.VideoCapability ParticipantCapabilities_Video { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateParticipantResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateParticipantResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ContactId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ContactId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ContactId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ContactId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNParticipant (CreateParticipant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateParticipantResponse, NewCONNParticipantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ContactId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
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
            context.ParticipantDetails_DisplayName = this.ParticipantDetails_DisplayName;
            context.ParticipantCapabilities_ScreenShare = this.ParticipantCapabilities_ScreenShare;
            context.ParticipantCapabilities_Video = this.ParticipantCapabilities_Video;
            context.ParticipantDetails_ParticipantRole = this.ParticipantDetails_ParticipantRole;
            
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
            var request = new Amazon.Connect.Model.CreateParticipantRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate ParticipantDetails
            var requestParticipantDetailsIsNull = true;
            request.ParticipantDetails = new Amazon.Connect.Model.ParticipantDetailsToAdd();
            System.String requestParticipantDetails_participantDetails_DisplayName = null;
            if (cmdletContext.ParticipantDetails_DisplayName != null)
            {
                requestParticipantDetails_participantDetails_DisplayName = cmdletContext.ParticipantDetails_DisplayName;
            }
            if (requestParticipantDetails_participantDetails_DisplayName != null)
            {
                request.ParticipantDetails.DisplayName = requestParticipantDetails_participantDetails_DisplayName;
                requestParticipantDetailsIsNull = false;
            }
            Amazon.Connect.ParticipantRole requestParticipantDetails_participantDetails_ParticipantRole = null;
            if (cmdletContext.ParticipantDetails_ParticipantRole != null)
            {
                requestParticipantDetails_participantDetails_ParticipantRole = cmdletContext.ParticipantDetails_ParticipantRole;
            }
            if (requestParticipantDetails_participantDetails_ParticipantRole != null)
            {
                request.ParticipantDetails.ParticipantRole = requestParticipantDetails_participantDetails_ParticipantRole;
                requestParticipantDetailsIsNull = false;
            }
            Amazon.Connect.Model.ParticipantCapabilities requestParticipantDetails_participantDetails_ParticipantCapabilities = null;
            
             // populate ParticipantCapabilities
            var requestParticipantDetails_participantDetails_ParticipantCapabilitiesIsNull = true;
            requestParticipantDetails_participantDetails_ParticipantCapabilities = new Amazon.Connect.Model.ParticipantCapabilities();
            Amazon.Connect.ScreenShareCapability requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_ScreenShare = null;
            if (cmdletContext.ParticipantCapabilities_ScreenShare != null)
            {
                requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_ScreenShare = cmdletContext.ParticipantCapabilities_ScreenShare;
            }
            if (requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_ScreenShare != null)
            {
                requestParticipantDetails_participantDetails_ParticipantCapabilities.ScreenShare = requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_ScreenShare;
                requestParticipantDetails_participantDetails_ParticipantCapabilitiesIsNull = false;
            }
            Amazon.Connect.VideoCapability requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_Video = null;
            if (cmdletContext.ParticipantCapabilities_Video != null)
            {
                requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_Video = cmdletContext.ParticipantCapabilities_Video;
            }
            if (requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_Video != null)
            {
                requestParticipantDetails_participantDetails_ParticipantCapabilities.Video = requestParticipantDetails_participantDetails_ParticipantCapabilities_participantCapabilities_Video;
                requestParticipantDetails_participantDetails_ParticipantCapabilitiesIsNull = false;
            }
             // determine if requestParticipantDetails_participantDetails_ParticipantCapabilities should be set to null
            if (requestParticipantDetails_participantDetails_ParticipantCapabilitiesIsNull)
            {
                requestParticipantDetails_participantDetails_ParticipantCapabilities = null;
            }
            if (requestParticipantDetails_participantDetails_ParticipantCapabilities != null)
            {
                request.ParticipantDetails.ParticipantCapabilities = requestParticipantDetails_participantDetails_ParticipantCapabilities;
                requestParticipantDetailsIsNull = false;
            }
             // determine if request.ParticipantDetails should be set to null
            if (requestParticipantDetailsIsNull)
            {
                request.ParticipantDetails = null;
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
        
        private Amazon.Connect.Model.CreateParticipantResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateParticipantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateParticipant");
            try
            {
                #if DESKTOP
                return client.CreateParticipant(request);
                #elif CORECLR
                return client.CreateParticipantAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ContactId { get; set; }
            public System.String InstanceId { get; set; }
            public System.String ParticipantDetails_DisplayName { get; set; }
            public Amazon.Connect.ScreenShareCapability ParticipantCapabilities_ScreenShare { get; set; }
            public Amazon.Connect.VideoCapability ParticipantCapabilities_Video { get; set; }
            public Amazon.Connect.ParticipantRole ParticipantDetails_ParticipantRole { get; set; }
            public System.Func<Amazon.Connect.Model.CreateParticipantResponse, NewCONNParticipantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
