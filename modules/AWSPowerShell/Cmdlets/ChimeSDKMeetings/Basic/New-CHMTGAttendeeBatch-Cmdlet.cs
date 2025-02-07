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
    /// Creates up to 100 attendees for an active Amazon Chime SDK meeting. For more information
    /// about the Amazon Chime SDK, see <a href="https://docs.aws.amazon.com/chime/latest/dg/meetings-sdk.html">Using
    /// the Amazon Chime SDK</a> in the <i>Amazon Chime Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMTGAttendeeBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings BatchCreateAttendee API operation.", Operation = new[] {"BatchCreateAttendee"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse",
        "This cmdlet returns an Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse object containing multiple properties."
    )]
    public partial class NewCHMTGAttendeeBatchCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Attendee
        /// <summary>
        /// <para>
        /// <para>The attendee information, including attendees' IDs and join tokens.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Attendees")]
        public Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem[] Attendee { get; set; }
        #endregion
        
        #region Parameter MeetingId
        /// <summary>
        /// <para>
        /// <para>The Amazon Chime SDK ID of the meeting to which you're adding attendees.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MeetingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMTGAttendeeBatch (BatchCreateAttendee)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse, NewCHMTGAttendeeBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attendee != null)
            {
                context.Attendee = new List<Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem>(this.Attendee);
            }
            #if MODULAR
            if (this.Attendee == null && ParameterWasBound(nameof(this.Attendee)))
            {
                WriteWarning("You are passing $null as a value for parameter Attendee which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeRequest();
            
            if (cmdletContext.Attendee != null)
            {
                request.Attendees = cmdletContext.Attendee;
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
        
        private Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "BatchCreateAttendee");
            try
            {
                #if DESKTOP
                return client.BatchCreateAttendee(request);
                #elif CORECLR
                return client.BatchCreateAttendeeAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ChimeSDKMeetings.Model.CreateAttendeeRequestItem> Attendee { get; set; }
            public System.String MeetingId { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.BatchCreateAttendeeResponse, NewCHMTGAttendeeBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
