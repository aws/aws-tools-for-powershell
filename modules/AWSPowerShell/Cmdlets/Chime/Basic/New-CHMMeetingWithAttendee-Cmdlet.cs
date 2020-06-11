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
using Amazon.Chime;
using Amazon.Chime.Model;

namespace Amazon.PowerShell.Cmdlets.CHM
{
    /// <summary>
    /// Creates a new Amazon Chime SDK meeting in the specified media Region, with attendees.
    /// For more information about specifying media Regions, see <a href="https://docs.aws.amazon.com/chime/latest/dg/chime-sdk-meetings-regions.html">Amazon
    /// Chime SDK Media Regions</a> in the <i>Amazon Chime Developer Guide</i>. For more information
    /// about the Amazon Chime SDK, see <a href="https://docs.aws.amazon.com/chime/latest/dg/meetings-sdk.html">Using
    /// the Amazon Chime SDK</a> in the <i>Amazon Chime Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMMeetingWithAttendee", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Chime.Model.Meeting")]
    [AWSCmdlet("Calls the Amazon Chime CreateMeetingWithAttendees API operation.", Operation = new[] {"CreateMeetingWithAttendees"}, SelectReturnType = typeof(Amazon.Chime.Model.CreateMeetingWithAttendeesResponse))]
    [AWSCmdletOutput("Amazon.Chime.Model.Meeting or Amazon.Chime.Model.CreateMeetingWithAttendeesResponse",
        "This cmdlet returns an Amazon.Chime.Model.Meeting object.",
        "The service call response (type Amazon.Chime.Model.CreateMeetingWithAttendeesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMMeetingWithAttendeeCmdlet : AmazonChimeClientCmdlet, IExecutor
    {
        
        #region Parameter Attendee
        /// <summary>
        /// <para>
        /// <para>The request containing the attendees to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attendees")]
        public Amazon.Chime.Model.CreateAttendeeRequestItem[] Attendee { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. Use a different token for different
        /// meetings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ExternalMeetingId
        /// <summary>
        /// <para>
        /// <para>The external meeting ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalMeetingId { get; set; }
        #endregion
        
        #region Parameter MediaRegion
        /// <summary>
        /// <para>
        /// <para>The Region in which to create the meeting. Default: <code>us-east-1</code>.</para><para>Available values: <code>ap-northeast-1</code>, <code>ap-southeast-1</code>, <code>ap-southeast-2</code>,
        /// <code>ca-central-1</code>, <code>eu-central-1</code>, <code>eu-north-1</code>, <code>eu-west-1</code>,
        /// <code>eu-west-2</code>, <code>eu-west-3</code>, <code>sa-east-1</code>, <code>us-east-1</code>,
        /// <code>us-east-2</code>, <code>us-west-1</code>, <code>us-west-2</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MediaRegion { get; set; }
        #endregion
        
        #region Parameter MeetingHostId
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String MeetingHostId { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The SNS topic ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SqsQueueArn
        /// <summary>
        /// <para>
        /// <para>The SQS queue ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tag key-value pairs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Chime.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Meeting'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Chime.Model.CreateMeetingWithAttendeesResponse).
        /// Specifying the name of a property of type Amazon.Chime.Model.CreateMeetingWithAttendeesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Meeting";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MeetingHostId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MeetingHostId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MeetingHostId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MeetingHostId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMeetingWithAttendee (CreateMeetingWithAttendees)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Chime.Model.CreateMeetingWithAttendeesResponse, NewCHMMeetingWithAttendeeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MeetingHostId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Attendee != null)
            {
                context.Attendee = new List<Amazon.Chime.Model.CreateAttendeeRequestItem>(this.Attendee);
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.ExternalMeetingId = this.ExternalMeetingId;
            context.MediaRegion = this.MediaRegion;
            context.MeetingHostId = this.MeetingHostId;
            context.NotificationsConfiguration_SnsTopicArn = this.NotificationsConfiguration_SnsTopicArn;
            context.NotificationsConfiguration_SqsQueueArn = this.NotificationsConfiguration_SqsQueueArn;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Chime.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.Chime.Model.CreateMeetingWithAttendeesRequest();
            
            if (cmdletContext.Attendee != null)
            {
                request.Attendees = cmdletContext.Attendee;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.ExternalMeetingId != null)
            {
                request.ExternalMeetingId = cmdletContext.ExternalMeetingId;
            }
            if (cmdletContext.MediaRegion != null)
            {
                request.MediaRegion = cmdletContext.MediaRegion;
            }
            if (cmdletContext.MeetingHostId != null)
            {
                request.MeetingHostId = cmdletContext.MeetingHostId;
            }
            
             // populate NotificationsConfiguration
            var requestNotificationsConfigurationIsNull = true;
            request.NotificationsConfiguration = new Amazon.Chime.Model.MeetingNotificationConfiguration();
            System.String requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn = null;
            if (cmdletContext.NotificationsConfiguration_SnsTopicArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn = cmdletContext.NotificationsConfiguration_SnsTopicArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn != null)
            {
                request.NotificationsConfiguration.SnsTopicArn = requestNotificationsConfiguration_notificationsConfiguration_SnsTopicArn;
                requestNotificationsConfigurationIsNull = false;
            }
            System.String requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn = null;
            if (cmdletContext.NotificationsConfiguration_SqsQueueArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn = cmdletContext.NotificationsConfiguration_SqsQueueArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn != null)
            {
                request.NotificationsConfiguration.SqsQueueArn = requestNotificationsConfiguration_notificationsConfiguration_SqsQueueArn;
                requestNotificationsConfigurationIsNull = false;
            }
             // determine if request.NotificationsConfiguration should be set to null
            if (requestNotificationsConfigurationIsNull)
            {
                request.NotificationsConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Chime.Model.CreateMeetingWithAttendeesResponse CallAWSServiceOperation(IAmazonChime client, Amazon.Chime.Model.CreateMeetingWithAttendeesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime", "CreateMeetingWithAttendees");
            try
            {
                #if DESKTOP
                return client.CreateMeetingWithAttendees(request);
                #elif CORECLR
                return client.CreateMeetingWithAttendeesAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Chime.Model.CreateAttendeeRequestItem> Attendee { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String ExternalMeetingId { get; set; }
            public System.String MediaRegion { get; set; }
            public System.String MeetingHostId { get; set; }
            public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
            public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
            public List<Amazon.Chime.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Chime.Model.CreateMeetingWithAttendeesResponse, NewCHMMeetingWithAttendeeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Meeting;
        }
        
    }
}
