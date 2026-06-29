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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Updates the configuration of an existing RCS agent. You can update the opt-out list,
    /// deletion protection, two-way messaging settings, and self-managed opt-outs configuration.
    /// </summary>
    [Cmdlet("Update", "SMSVRcsAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 UpdateRcsAgent API operation.", Operation = new[] {"UpdateRcsAgent"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse object containing multiple properties."
    )]
    public partial class UpdateSMSVRcsAgentCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeletionProtectionEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true the RCS agent can't be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtectionEnabled { get; set; }
        #endregion
        
        #region Parameter OptOutListName
        /// <summary>
        /// <para>
        /// <para>The OptOutList to associate with the RCS agent. Valid values are either OptOutListName
        /// or OptOutListArn.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OptOutListName { get; set; }
        #endregion
        
        #region Parameter RcsAgentId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the RCS agent to update. You can use either the RcsAgentId
        /// or RcsAgentArn.</para>
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
        public System.String RcsAgentId { get; set; }
        #endregion
        
        #region Parameter SelfManagedOptOutsEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true you're responsible for responding
        /// to HELP and STOP requests. You're also responsible for tracking and honoring opt-out
        /// requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SelfManagedOptOutsEnabled { get; set; }
        #endregion
        
        #region Parameter TwoWayChannelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the two way channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayChannelArn { get; set; }
        #endregion
        
        #region Parameter TwoWayChannelRole
        /// <summary>
        /// <para>
        /// <para>An optional IAM Role Arn for a service to assume, to be able to post inbound SMS messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayChannelRole { get; set; }
        #endregion
        
        #region Parameter TwoWayEnabled
        /// <summary>
        /// <para>
        /// <para>By default this is set to false. When set to true you can receive incoming text messages
        /// from your end recipients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TwoWayEnabled { get; set; }
        #endregion
        
        #region Parameter TwoWayMediaS3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket where inbound RCS media files are stored. Two-way messaging
        /// must be enabled on the agent. To remove the media configuration, pass the sentinel
        /// value <c>UNSET_RCS_MEDIA_CONFIGURATION</c> for both this field and TwoWayMediaS3Role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayMediaS3BucketName { get; set; }
        #endregion
        
        #region Parameter TwoWayMediaS3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The key prefix used for inbound RCS media objects in the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayMediaS3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter TwoWayMediaS3Role
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role used to write inbound RCS media files to the S3 bucket. The
        /// role must have <c>s3:PutObject</c> permission on the bucket and a trust policy allowing
        /// <c>sms-voice.amazonaws.com</c> to assume it. To remove the media configuration, pass
        /// the sentinel value <c>UNSET_RCS_MEDIA_CONFIGURATION</c> for both this field and TwoWayMediaS3BucketName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TwoWayMediaS3Role { get; set; }
        #endregion
        
        #region Parameter TwoWayRcsEventsEnabled
        /// <summary>
        /// <para>
        /// <para>The list of RCS event types to enable for two-way messaging. Pass an empty list to
        /// disable all event types. The special value <c>ALL</c> enables all current and future
        /// event types and must be the sole element if used.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] TwoWayRcsEventsEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RcsAgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSVRcsAgent (UpdateRcsAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse, UpdateSMSVRcsAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletionProtectionEnabled = this.DeletionProtectionEnabled;
            context.OptOutListName = this.OptOutListName;
            context.RcsAgentId = this.RcsAgentId;
            #if MODULAR
            if (this.RcsAgentId == null && ParameterWasBound(nameof(this.RcsAgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter RcsAgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SelfManagedOptOutsEnabled = this.SelfManagedOptOutsEnabled;
            context.TwoWayChannelArn = this.TwoWayChannelArn;
            context.TwoWayChannelRole = this.TwoWayChannelRole;
            context.TwoWayEnabled = this.TwoWayEnabled;
            context.TwoWayMediaS3BucketName = this.TwoWayMediaS3BucketName;
            context.TwoWayMediaS3KeyPrefix = this.TwoWayMediaS3KeyPrefix;
            context.TwoWayMediaS3Role = this.TwoWayMediaS3Role;
            if (this.TwoWayRcsEventsEnabled != null)
            {
                context.TwoWayRcsEventsEnabled = new List<System.String>(this.TwoWayRcsEventsEnabled);
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentRequest();
            
            if (cmdletContext.DeletionProtectionEnabled != null)
            {
                request.DeletionProtectionEnabled = cmdletContext.DeletionProtectionEnabled.Value;
            }
            if (cmdletContext.OptOutListName != null)
            {
                request.OptOutListName = cmdletContext.OptOutListName;
            }
            if (cmdletContext.RcsAgentId != null)
            {
                request.RcsAgentId = cmdletContext.RcsAgentId;
            }
            if (cmdletContext.SelfManagedOptOutsEnabled != null)
            {
                request.SelfManagedOptOutsEnabled = cmdletContext.SelfManagedOptOutsEnabled.Value;
            }
            if (cmdletContext.TwoWayChannelArn != null)
            {
                request.TwoWayChannelArn = cmdletContext.TwoWayChannelArn;
            }
            if (cmdletContext.TwoWayChannelRole != null)
            {
                request.TwoWayChannelRole = cmdletContext.TwoWayChannelRole;
            }
            if (cmdletContext.TwoWayEnabled != null)
            {
                request.TwoWayEnabled = cmdletContext.TwoWayEnabled.Value;
            }
            if (cmdletContext.TwoWayMediaS3BucketName != null)
            {
                request.TwoWayMediaS3BucketName = cmdletContext.TwoWayMediaS3BucketName;
            }
            if (cmdletContext.TwoWayMediaS3KeyPrefix != null)
            {
                request.TwoWayMediaS3KeyPrefix = cmdletContext.TwoWayMediaS3KeyPrefix;
            }
            if (cmdletContext.TwoWayMediaS3Role != null)
            {
                request.TwoWayMediaS3Role = cmdletContext.TwoWayMediaS3Role;
            }
            if (cmdletContext.TwoWayRcsEventsEnabled != null)
            {
                request.TwoWayRcsEventsEnabled = cmdletContext.TwoWayRcsEventsEnabled;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "UpdateRcsAgent");
            try
            {
                return client.UpdateRcsAgentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DeletionProtectionEnabled { get; set; }
            public System.String OptOutListName { get; set; }
            public System.String RcsAgentId { get; set; }
            public System.Boolean? SelfManagedOptOutsEnabled { get; set; }
            public System.String TwoWayChannelArn { get; set; }
            public System.String TwoWayChannelRole { get; set; }
            public System.Boolean? TwoWayEnabled { get; set; }
            public System.String TwoWayMediaS3BucketName { get; set; }
            public System.String TwoWayMediaS3KeyPrefix { get; set; }
            public System.String TwoWayMediaS3Role { get; set; }
            public List<System.String> TwoWayRcsEventsEnabled { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.UpdateRcsAgentResponse, UpdateSMSVRcsAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
