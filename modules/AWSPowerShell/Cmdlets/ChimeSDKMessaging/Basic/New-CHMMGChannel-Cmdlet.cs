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
using Amazon.ChimeSDKMessaging;
using Amazon.ChimeSDKMessaging.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMG
{
    /// <summary>
    /// Creates a channel to which you can add users and send messages.
    /// 
    ///  
    /// <para><b>Restriction</b>: You can't change a channel's privacy.
    /// </para><note><para>
    /// The <code>x-amz-chime-bearer</code> request header is mandatory. Use the <code>AppInstanceUserArn</code>
    /// of the user that makes the API call as the value in the header.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CHMMGChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Chime SDK Messaging CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.ChimeSDKMessaging.Model.CreateChannelResponse))]
    [AWSCmdletOutput("System.String or Amazon.ChimeSDKMessaging.Model.CreateChannelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ChimeSDKMessaging.Model.CreateChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCHMMGChannelCmdlet : AmazonChimeSDKMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter AppInstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the channel request.</para>
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
        public System.String AppInstanceArn { get; set; }
        #endregion
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// <para>The ID of the channel in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter ChimeBearer
        /// <summary>
        /// <para>
        /// <para>The <code>AppInstanceUserArn</code> of the user that makes the API call.</para>
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
        public System.String ChimeBearer { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The client token for the request. An <code>Idempotency</code> token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ElasticChannelConfiguration_MaximumSubChannel
        /// <summary>
        /// <para>
        /// <para>The maximum number of SubChannels that you want to allow in the elastic channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ElasticChannelConfiguration_MaximumSubChannels")]
        public System.Int32? ElasticChannelConfiguration_MaximumSubChannel { get; set; }
        #endregion
        
        #region Parameter MemberArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the channel members in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberArns")]
        public System.String[] MemberArn { get; set; }
        #endregion
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The metadata of the creation request. Limited to 1KB and UTF-8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Metadata { get; set; }
        #endregion
        
        #region Parameter ElasticChannelConfiguration_MinimumMembershipPercentage
        /// <summary>
        /// <para>
        /// <para>The minimum allowed percentage of TargetMembershipsPerSubChannel users. Ceil of the
        /// calculated value is used in balancing members among SubChannels of the elastic channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticChannelConfiguration_MinimumMembershipPercentage { get; set; }
        #endregion
        
        #region Parameter Mode
        /// <summary>
        /// <para>
        /// <para>The channel mode: <code>UNRESTRICTED</code> or <code>RESTRICTED</code>. Administrators,
        /// moderators, and channel members can add themselves and other members to unrestricted
        /// channels. Only administrators and moderators can add members to restricted channels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelMode")]
        public Amazon.ChimeSDKMessaging.ChannelMode Mode { get; set; }
        #endregion
        
        #region Parameter ModeratorArn
        /// <summary>
        /// <para>
        /// <para>The ARNs of the channel moderators in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModeratorArns")]
        public System.String[] ModeratorArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the channel.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Privacy
        /// <summary>
        /// <para>
        /// <para>The channel's privacy level: <code>PUBLIC</code> or <code>PRIVATE</code>. Private
        /// channels aren't discoverable by users outside the channel. Public channels are discoverable
        /// by anyone in the <code>AppInstance</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ChimeSDKMessaging.ChannelPrivacy")]
        public Amazon.ChimeSDKMessaging.ChannelPrivacy Privacy { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the creation request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMessaging.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ElasticChannelConfiguration_TargetMembershipsPerSubChannel
        /// <summary>
        /// <para>
        /// <para>The maximum number of members allowed in a SubChannel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ElasticChannelConfiguration_TargetMembershipsPerSubChannel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMessaging.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMessaging.Model.CreateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AppInstanceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AppInstanceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AppInstanceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMGChannel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMessaging.Model.CreateChannelResponse, NewCHMMGChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AppInstanceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AppInstanceArn = this.AppInstanceArn;
            #if MODULAR
            if (this.AppInstanceArn == null && ParameterWasBound(nameof(this.AppInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AppInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelId = this.ChannelId;
            context.ChimeBearer = this.ChimeBearer;
            #if MODULAR
            if (this.ChimeBearer == null && ParameterWasBound(nameof(this.ChimeBearer)))
            {
                WriteWarning("You are passing $null as a value for parameter ChimeBearer which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientRequestToken = this.ClientRequestToken;
            context.ElasticChannelConfiguration_MaximumSubChannel = this.ElasticChannelConfiguration_MaximumSubChannel;
            context.ElasticChannelConfiguration_MinimumMembershipPercentage = this.ElasticChannelConfiguration_MinimumMembershipPercentage;
            context.ElasticChannelConfiguration_TargetMembershipsPerSubChannel = this.ElasticChannelConfiguration_TargetMembershipsPerSubChannel;
            if (this.MemberArn != null)
            {
                context.MemberArn = new List<System.String>(this.MemberArn);
            }
            context.Metadata = this.Metadata;
            context.Mode = this.Mode;
            if (this.ModeratorArn != null)
            {
                context.ModeratorArn = new List<System.String>(this.ModeratorArn);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Privacy = this.Privacy;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMessaging.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKMessaging.Model.CreateChannelRequest();
            
            if (cmdletContext.AppInstanceArn != null)
            {
                request.AppInstanceArn = cmdletContext.AppInstanceArn;
            }
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.ChimeBearer != null)
            {
                request.ChimeBearer = cmdletContext.ChimeBearer;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate ElasticChannelConfiguration
            var requestElasticChannelConfigurationIsNull = true;
            request.ElasticChannelConfiguration = new Amazon.ChimeSDKMessaging.Model.ElasticChannelConfiguration();
            System.Int32? requestElasticChannelConfiguration_elasticChannelConfiguration_MaximumSubChannel = null;
            if (cmdletContext.ElasticChannelConfiguration_MaximumSubChannel != null)
            {
                requestElasticChannelConfiguration_elasticChannelConfiguration_MaximumSubChannel = cmdletContext.ElasticChannelConfiguration_MaximumSubChannel.Value;
            }
            if (requestElasticChannelConfiguration_elasticChannelConfiguration_MaximumSubChannel != null)
            {
                request.ElasticChannelConfiguration.MaximumSubChannels = requestElasticChannelConfiguration_elasticChannelConfiguration_MaximumSubChannel.Value;
                requestElasticChannelConfigurationIsNull = false;
            }
            System.Int32? requestElasticChannelConfiguration_elasticChannelConfiguration_MinimumMembershipPercentage = null;
            if (cmdletContext.ElasticChannelConfiguration_MinimumMembershipPercentage != null)
            {
                requestElasticChannelConfiguration_elasticChannelConfiguration_MinimumMembershipPercentage = cmdletContext.ElasticChannelConfiguration_MinimumMembershipPercentage.Value;
            }
            if (requestElasticChannelConfiguration_elasticChannelConfiguration_MinimumMembershipPercentage != null)
            {
                request.ElasticChannelConfiguration.MinimumMembershipPercentage = requestElasticChannelConfiguration_elasticChannelConfiguration_MinimumMembershipPercentage.Value;
                requestElasticChannelConfigurationIsNull = false;
            }
            System.Int32? requestElasticChannelConfiguration_elasticChannelConfiguration_TargetMembershipsPerSubChannel = null;
            if (cmdletContext.ElasticChannelConfiguration_TargetMembershipsPerSubChannel != null)
            {
                requestElasticChannelConfiguration_elasticChannelConfiguration_TargetMembershipsPerSubChannel = cmdletContext.ElasticChannelConfiguration_TargetMembershipsPerSubChannel.Value;
            }
            if (requestElasticChannelConfiguration_elasticChannelConfiguration_TargetMembershipsPerSubChannel != null)
            {
                request.ElasticChannelConfiguration.TargetMembershipsPerSubChannel = requestElasticChannelConfiguration_elasticChannelConfiguration_TargetMembershipsPerSubChannel.Value;
                requestElasticChannelConfigurationIsNull = false;
            }
             // determine if request.ElasticChannelConfiguration should be set to null
            if (requestElasticChannelConfigurationIsNull)
            {
                request.ElasticChannelConfiguration = null;
            }
            if (cmdletContext.MemberArn != null)
            {
                request.MemberArns = cmdletContext.MemberArn;
            }
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.Mode != null)
            {
                request.Mode = cmdletContext.Mode;
            }
            if (cmdletContext.ModeratorArn != null)
            {
                request.ModeratorArns = cmdletContext.ModeratorArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Privacy != null)
            {
                request.Privacy = cmdletContext.Privacy;
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
        
        private Amazon.ChimeSDKMessaging.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonChimeSDKMessaging client, Amazon.ChimeSDKMessaging.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Messaging", "CreateChannel");
            try
            {
                #if DESKTOP
                return client.CreateChannel(request);
                #elif CORECLR
                return client.CreateChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String AppInstanceArn { get; set; }
            public System.String ChannelId { get; set; }
            public System.String ChimeBearer { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Int32? ElasticChannelConfiguration_MaximumSubChannel { get; set; }
            public System.Int32? ElasticChannelConfiguration_MinimumMembershipPercentage { get; set; }
            public System.Int32? ElasticChannelConfiguration_TargetMembershipsPerSubChannel { get; set; }
            public List<System.String> MemberArn { get; set; }
            public System.String Metadata { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelMode Mode { get; set; }
            public List<System.String> ModeratorArn { get; set; }
            public System.String Name { get; set; }
            public Amazon.ChimeSDKMessaging.ChannelPrivacy Privacy { get; set; }
            public List<Amazon.ChimeSDKMessaging.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKMessaging.Model.CreateChannelResponse, NewCHMMGChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelArn;
        }
        
    }
}
