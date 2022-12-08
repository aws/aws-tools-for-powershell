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
using Amazon.ChimeSDKMeetings;
using Amazon.ChimeSDKMeetings.Model;

namespace Amazon.PowerShell.Cmdlets.CHMTG
{
    /// <summary>
    /// Creates a new Amazon Chime SDK meeting in the specified media Region with no initial
    /// attendees. For more information about specifying media Regions, see <a href="https://docs.aws.amazon.com/chime/latest/dg/chime-sdk-meetings-regions.html">Amazon
    /// Chime SDK Media Regions</a> in the <i>Amazon Chime Developer Guide</i>. For more information
    /// about the Amazon Chime SDK, see <a href="https://docs.aws.amazon.com/chime/latest/dg/meetings-sdk.html">Using
    /// the Amazon Chime SDK</a> in the <i>Amazon Chime Developer Guide</i>.
    /// </summary>
    [Cmdlet("New", "CHMTGMeeting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMeetings.Model.Meeting")]
    [AWSCmdlet("Calls the Amazon Chime SDK Meetings CreateMeeting API operation.", Operation = new[] {"CreateMeeting"}, SelectReturnType = typeof(Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMeetings.Model.Meeting or Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse",
        "This cmdlet returns an Amazon.ChimeSDKMeetings.Model.Meeting object.",
        "The service call response (type Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMTGMeetingCmdlet : AmazonChimeSDKMeetingsClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the client request. Use a different token for different
        /// meetings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Audio_EchoReduction
        /// <summary>
        /// <para>
        /// <para>Makes echo reduction available to clients who connect to the meeting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MeetingFeatures_Audio_EchoReduction")]
        [AWSConstantClassSource("Amazon.ChimeSDKMeetings.MeetingFeatureStatus")]
        public Amazon.ChimeSDKMeetings.MeetingFeatureStatus Audio_EchoReduction { get; set; }
        #endregion
        
        #region Parameter ExternalMeetingId
        /// <summary>
        /// <para>
        /// <para>The external meeting ID.</para>
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
        public System.String ExternalMeetingId { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_LambdaFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Lambda function in the notifications configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_LambdaFunctionArn { get; set; }
        #endregion
        
        #region Parameter MediaRegion
        /// <summary>
        /// <para>
        /// <para>The Region in which to create the meeting.</para><para> Available values: <code>af-south-1</code>, <code>ap-northeast-1</code>, <code>ap-northeast-2</code>,
        /// <code>ap-south-1</code>, <code>ap-southeast-1</code>, <code>ap-southeast-2</code>,
        /// <code>ca-central-1</code>, <code>eu-central-1</code>, <code>eu-north-1</code>, <code>eu-south-1</code>,
        /// <code>eu-west-1</code>, <code>eu-west-2</code>, <code>eu-west-3</code>, <code>sa-east-1</code>,
        /// <code>us-east-1</code>, <code>us-east-2</code>, <code>us-west-1</code>, <code>us-west-2</code>.
        /// </para><para>Available values in AWS GovCloud (US) Regions: <code>us-gov-east-1</code>, <code>us-gov-west-1</code>.</para>
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
        public System.String MediaRegion { get; set; }
        #endregion
        
        #region Parameter MeetingHostId
        /// <summary>
        /// <para>
        /// <para>Reserved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeetingHostId { get; set; }
        #endregion
        
        #region Parameter PrimaryMeetingId
        /// <summary>
        /// <para>
        /// <para>When specified, replicates the media from the primary meeting to the new meeting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryMeetingId { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SnsTopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
        #endregion
        
        #region Parameter NotificationsConfiguration_SqsQueueArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SQS queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to an Amazon Chime SDK meeting. Note the following:</para><ul><li><para>Not all resources have tags. For a list of services with resources that support tagging
        /// using this operation, see <a href="https://docs.aws.amazon.com/resourcegroupstagging/latest/APIReference/supported-services.html">Services
        /// that support the Resource Groups Tagging API</a>. If the resource doesn't yet support
        /// this operation, the resource's service might support tagging using its own API operations.
        /// For more information, refer to the documentation for that service.</para></li><li><para>Each resource can have up to 50 tags. For other limits, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html#tag-conventions">Tag
        /// Naming and Usage Conventions</a> in the <i>AWS General Reference</i>.</para></li><li><para>You can only tag resources that are located in the specified AWS Region for the AWS
        /// account.</para></li><li><para>To add tags to a resource, you need the necessary permissions for the service that
        /// the resource belongs to as well as permissions for adding tags. For more information,
        /// see the documentation for each service.</para></li></ul><important><para>Do not store personally identifiable information (PII) or other confidential or sensitive
        /// information in tags. We use tags to provide you with billing and administration services.
        /// Tags are not intended to be used for private or sensitive data.</para></important><para><b>Minimum permissions</b></para><para> In addition to the <code>tag:TagResources </code>permission required by this operation,
        /// you must also have the tagging permission defined by the service that created the
        /// resource. For example, to tag a <code>ChimeSDKMeetings</code> instance using the <code>TagResources</code>
        /// operation, you must have both of the following permissions:</para><para><code>tag:TagResources</code></para><para><code>ChimeSDKMeetings:CreateTags</code></para><note><para>Some services might have specific requirements for tagging some resources. For example,
        /// to tag an Amazon S3 bucket, you must also have the <code>s3:GetBucketTagging</code>
        /// permission. If the expected minimum permissions don't work, check the documentation
        /// for that service's tagging APIs for more information.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMeetings.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>A consistent and opaque identifier, created and maintained by the builder to represent
        /// a segment of their users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TenantIds")]
        public System.String[] TenantId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Meeting'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Meeting";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientRequestToken parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientRequestToken' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExternalMeetingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMTGMeeting (CreateMeeting)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse, NewCHMTGMeetingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientRequestToken;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.ExternalMeetingId = this.ExternalMeetingId;
            #if MODULAR
            if (this.ExternalMeetingId == null && ParameterWasBound(nameof(this.ExternalMeetingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalMeetingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaRegion = this.MediaRegion;
            #if MODULAR
            if (this.MediaRegion == null && ParameterWasBound(nameof(this.MediaRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Audio_EchoReduction = this.Audio_EchoReduction;
            context.MeetingHostId = this.MeetingHostId;
            context.NotificationsConfiguration_LambdaFunctionArn = this.NotificationsConfiguration_LambdaFunctionArn;
            context.NotificationsConfiguration_SnsTopicArn = this.NotificationsConfiguration_SnsTopicArn;
            context.NotificationsConfiguration_SqsQueueArn = this.NotificationsConfiguration_SqsQueueArn;
            context.PrimaryMeetingId = this.PrimaryMeetingId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMeetings.Model.Tag>(this.Tag);
            }
            if (this.TenantId != null)
            {
                context.TenantId = new List<System.String>(this.TenantId);
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
            var request = new Amazon.ChimeSDKMeetings.Model.CreateMeetingRequest();
            
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
            
             // populate MeetingFeatures
            var requestMeetingFeaturesIsNull = true;
            request.MeetingFeatures = new Amazon.ChimeSDKMeetings.Model.MeetingFeaturesConfiguration();
            Amazon.ChimeSDKMeetings.Model.AudioFeatures requestMeetingFeatures_meetingFeatures_Audio = null;
            
             // populate Audio
            var requestMeetingFeatures_meetingFeatures_AudioIsNull = true;
            requestMeetingFeatures_meetingFeatures_Audio = new Amazon.ChimeSDKMeetings.Model.AudioFeatures();
            Amazon.ChimeSDKMeetings.MeetingFeatureStatus requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction = null;
            if (cmdletContext.Audio_EchoReduction != null)
            {
                requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction = cmdletContext.Audio_EchoReduction;
            }
            if (requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction != null)
            {
                requestMeetingFeatures_meetingFeatures_Audio.EchoReduction = requestMeetingFeatures_meetingFeatures_Audio_audio_EchoReduction;
                requestMeetingFeatures_meetingFeatures_AudioIsNull = false;
            }
             // determine if requestMeetingFeatures_meetingFeatures_Audio should be set to null
            if (requestMeetingFeatures_meetingFeatures_AudioIsNull)
            {
                requestMeetingFeatures_meetingFeatures_Audio = null;
            }
            if (requestMeetingFeatures_meetingFeatures_Audio != null)
            {
                request.MeetingFeatures.Audio = requestMeetingFeatures_meetingFeatures_Audio;
                requestMeetingFeaturesIsNull = false;
            }
             // determine if request.MeetingFeatures should be set to null
            if (requestMeetingFeaturesIsNull)
            {
                request.MeetingFeatures = null;
            }
            if (cmdletContext.MeetingHostId != null)
            {
                request.MeetingHostId = cmdletContext.MeetingHostId;
            }
            
             // populate NotificationsConfiguration
            var requestNotificationsConfigurationIsNull = true;
            request.NotificationsConfiguration = new Amazon.ChimeSDKMeetings.Model.NotificationsConfiguration();
            System.String requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn = null;
            if (cmdletContext.NotificationsConfiguration_LambdaFunctionArn != null)
            {
                requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn = cmdletContext.NotificationsConfiguration_LambdaFunctionArn;
            }
            if (requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn != null)
            {
                request.NotificationsConfiguration.LambdaFunctionArn = requestNotificationsConfiguration_notificationsConfiguration_LambdaFunctionArn;
                requestNotificationsConfigurationIsNull = false;
            }
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
            if (cmdletContext.PrimaryMeetingId != null)
            {
                request.PrimaryMeetingId = cmdletContext.PrimaryMeetingId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TenantId != null)
            {
                request.TenantIds = cmdletContext.TenantId;
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
        
        private Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse CallAWSServiceOperation(IAmazonChimeSDKMeetings client, Amazon.ChimeSDKMeetings.Model.CreateMeetingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Meetings", "CreateMeeting");
            try
            {
                #if DESKTOP
                return client.CreateMeeting(request);
                #elif CORECLR
                return client.CreateMeetingAsync(request).GetAwaiter().GetResult();
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
            public System.String ExternalMeetingId { get; set; }
            public System.String MediaRegion { get; set; }
            public Amazon.ChimeSDKMeetings.MeetingFeatureStatus Audio_EchoReduction { get; set; }
            public System.String MeetingHostId { get; set; }
            public System.String NotificationsConfiguration_LambdaFunctionArn { get; set; }
            public System.String NotificationsConfiguration_SnsTopicArn { get; set; }
            public System.String NotificationsConfiguration_SqsQueueArn { get; set; }
            public System.String PrimaryMeetingId { get; set; }
            public List<Amazon.ChimeSDKMeetings.Model.Tag> Tag { get; set; }
            public List<System.String> TenantId { get; set; }
            public System.Func<Amazon.ChimeSDKMeetings.Model.CreateMeetingResponse, NewCHMTGMeetingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Meeting;
        }
        
    }
}
