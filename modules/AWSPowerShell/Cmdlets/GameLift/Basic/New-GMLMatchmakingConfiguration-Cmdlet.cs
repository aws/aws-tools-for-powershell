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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// Defines a new matchmaking configuration for use with FlexMatch. Whether your are using
    /// FlexMatch with Amazon GameLift hosting or as a standalone matchmaking service, the
    /// matchmaking configuration sets out rules for matching players and forming teams. If
    /// you're also using Amazon GameLift hosting, it defines how to start game sessions for
    /// each match. Your matchmaking system can use multiple configurations to handle different
    /// game scenarios. All matchmaking requests identify the matchmaking configuration to
    /// use and provide player attributes consistent with that configuration. 
    /// 
    ///  
    /// <para>
    /// To create a matchmaking configuration, you must provide the following: configuration
    /// name and FlexMatch mode (with or without Amazon GameLift hosting); a rule set that
    /// specifies how to evaluate players and find acceptable matches; whether player acceptance
    /// is required; and the maximum time allowed for a matchmaking attempt. When using FlexMatch
    /// with Amazon GameLift hosting, you also need to identify the game session queue to
    /// use when starting a game session for the match.
    /// </para><para>
    /// In addition, you must set up an Amazon Simple Notification Service topic to receive
    /// matchmaking notifications. Provide the topic ARN in the matchmaking configuration.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-configuration.html">
    /// Design a FlexMatch matchmaker</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-notification.html">
    /// Set up FlexMatch event notification</a></para>
    /// </summary>
    [Cmdlet("New", "GMLMatchmakingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingConfiguration")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateMatchmakingConfiguration API operation.", Operation = new[] {"CreateMatchmakingConfiguration"}, SelectReturnType = typeof(Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingConfiguration or Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLMatchmakingConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>A flag that determines whether a match that was created with this configuration must
        /// be accepted by the matched players. To require acceptance, set to <c>TRUE</c>. With
        /// this option enabled, matchmaking tickets use the status <c>REQUIRES_ACCEPTANCE</c>
        /// to indicate when a completed potential match is waiting for player acceptance. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter AcceptanceTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The length of time (in seconds) to wait for players to accept a proposed match, if
        /// acceptance is required. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AcceptanceTimeoutSeconds")]
        public System.Int32? AcceptanceTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter AdditionalPlayerCount
        /// <summary>
        /// <para>
        /// <para>The number of player slots in a match to keep open for future players. For example,
        /// if the configuration's rule set specifies a match for a single 10-person team, and
        /// the additional player count is set to 2, 10 players will be selected for the match
        /// and 2 more player slots will be open for future players. This parameter is not used
        /// if <c>FlexMatchMode</c> is set to <c>STANDALONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AdditionalPlayerCount { get; set; }
        #endregion
        
        #region Parameter BackfillMode
        /// <summary>
        /// <para>
        /// <para>The method used to backfill game sessions that are created with this matchmaking configuration.
        /// Specify <c>MANUAL</c> when your game manages backfill requests manually or does not
        /// use the match backfill feature. Specify <c>AUTOMATIC</c> to have Amazon GameLift create
        /// a backfill request whenever a game session has one or more open slots. Learn more
        /// about manual and automatic backfill in <a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-backfill.html">
        /// Backfill Existing Games with FlexMatch</a>. Automatic backfill is not available when
        /// <c>FlexMatchMode</c> is set to <c>STANDALONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.BackfillMode")]
        public Amazon.GameLift.BackfillMode BackfillMode { get; set; }
        #endregion
        
        #region Parameter CustomEventData
        /// <summary>
        /// <para>
        /// <para>Information to be added to all events related to this matchmaking configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomEventData { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A human-readable description of the matchmaking configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FlexMatchMode
        /// <summary>
        /// <para>
        /// <para>Indicates whether this matchmaking configuration is being used with Amazon GameLift
        /// hosting or as a standalone matchmaking solution. </para><ul><li><para><b>STANDALONE</b> - FlexMatch forms matches and returns match information, including
        /// players and team assignments, in a <a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-events.html#match-events-matchmakingsucceeded">
        /// MatchmakingSucceeded</a> event.</para></li><li><para><b>WITH_QUEUE</b> - FlexMatch forms matches and uses the specified Amazon GameLift
        /// queue to start a game session for the match. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.FlexMatchMode")]
        public Amazon.GameLift.FlexMatchMode FlexMatchMode { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that can store custom data in a game session. For example:
        /// <c>{"Key": "difficulty", "Value": "novice"}</c>. This information is added to the
        /// new <c>GameSession</c> object that is created for a successful match. This parameter
        /// is not used if <c>FlexMatchMode</c> is set to <c>STANDALONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter GameSessionData
        /// <summary>
        /// <para>
        /// <para>A set of custom game session properties, formatted as a single string value. This
        /// data is passed to a game server process with a request to start a new game session
        /// (see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>). This information is added to the new <c>GameSession</c> object
        /// that is created for a successful match. This parameter is not used if <c>FlexMatchMode</c>
        /// is set to <c>STANDALONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionData { get; set; }
        #endregion
        
        #region Parameter GameSessionQueueArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (<a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// that is assigned to a Amazon GameLift game session queue resource and uniquely identifies
        /// it. ARNs are unique across all Regions. Format is <c>arn:aws:gamelift:&lt;region&gt;::gamesessionqueue/&lt;queue
        /// name&gt;</c>. Queues can be located in any Region. Queues are used to start new Amazon
        /// GameLift-hosted game sessions for matches that are created with this matchmaking configuration.
        /// If <c>FlexMatchMode</c> is set to <c>STANDALONE</c>, do not set this parameter. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameSessionQueueArns")]
        public System.String[] GameSessionQueueArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the matchmaking configuration. This name is used to identify
        /// the configuration associated with a matchmaking request or ticket.</para>
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
        
        #region Parameter NotificationTarget
        /// <summary>
        /// <para>
        /// <para>An SNS topic ARN that is set up to receive matchmaking notifications. See <a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-notification.html">
        /// Setting up notifications for matchmaking</a> for more information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationTarget { get; set; }
        #endregion
        
        #region Parameter RequestTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum duration, in seconds, that a matchmaking ticket can remain in process
        /// before timing out. Requests that fail due to timing out can be resubmitted as needed.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RequestTimeoutSeconds")]
        public System.Int32? RequestTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RuleSetName
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the matchmaking rule set to use with this configuration. You
        /// can use either the rule set name or ARN value. A matchmaking configuration can only
        /// use rule sets that are defined in the same Region.</para>
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
        public System.String RuleSetName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of labels to assign to the new matchmaking configuration resource. Tags are
        /// developer-defined key-value pairs. Tagging Amazon Web Services resources are useful
        /// for resource management, access management and cost allocation. For more information,
        /// see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html"> Tagging
        /// Amazon Web Services Resources</a> in the <i>Amazon Web Services General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.GameLift.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RuleSetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLMatchmakingConfiguration (CreateMatchmakingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse, NewGMLMatchmakingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptanceRequired = this.AcceptanceRequired;
            #if MODULAR
            if (this.AcceptanceRequired == null && ParameterWasBound(nameof(this.AcceptanceRequired)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceptanceRequired which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AcceptanceTimeoutSecond = this.AcceptanceTimeoutSecond;
            context.AdditionalPlayerCount = this.AdditionalPlayerCount;
            context.BackfillMode = this.BackfillMode;
            context.CustomEventData = this.CustomEventData;
            context.Description = this.Description;
            context.FlexMatchMode = this.FlexMatchMode;
            if (this.GameProperty != null)
            {
                context.GameProperty = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionData = this.GameSessionData;
            if (this.GameSessionQueueArn != null)
            {
                context.GameSessionQueueArn = new List<System.String>(this.GameSessionQueueArn);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationTarget = this.NotificationTarget;
            context.RequestTimeoutSecond = this.RequestTimeoutSecond;
            #if MODULAR
            if (this.RequestTimeoutSecond == null && ParameterWasBound(nameof(this.RequestTimeoutSecond)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestTimeoutSecond which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuleSetName = this.RuleSetName;
            #if MODULAR
            if (this.RuleSetName == null && ParameterWasBound(nameof(this.RuleSetName)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleSetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.GameLift.Model.Tag>(this.Tag);
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
            var request = new Amazon.GameLift.Model.CreateMatchmakingConfigurationRequest();
            
            if (cmdletContext.AcceptanceRequired != null)
            {
                request.AcceptanceRequired = cmdletContext.AcceptanceRequired.Value;
            }
            if (cmdletContext.AcceptanceTimeoutSecond != null)
            {
                request.AcceptanceTimeoutSeconds = cmdletContext.AcceptanceTimeoutSecond.Value;
            }
            if (cmdletContext.AdditionalPlayerCount != null)
            {
                request.AdditionalPlayerCount = cmdletContext.AdditionalPlayerCount.Value;
            }
            if (cmdletContext.BackfillMode != null)
            {
                request.BackfillMode = cmdletContext.BackfillMode;
            }
            if (cmdletContext.CustomEventData != null)
            {
                request.CustomEventData = cmdletContext.CustomEventData;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FlexMatchMode != null)
            {
                request.FlexMatchMode = cmdletContext.FlexMatchMode;
            }
            if (cmdletContext.GameProperty != null)
            {
                request.GameProperties = cmdletContext.GameProperty;
            }
            if (cmdletContext.GameSessionData != null)
            {
                request.GameSessionData = cmdletContext.GameSessionData;
            }
            if (cmdletContext.GameSessionQueueArn != null)
            {
                request.GameSessionQueueArns = cmdletContext.GameSessionQueueArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotificationTarget != null)
            {
                request.NotificationTarget = cmdletContext.NotificationTarget;
            }
            if (cmdletContext.RequestTimeoutSecond != null)
            {
                request.RequestTimeoutSeconds = cmdletContext.RequestTimeoutSecond.Value;
            }
            if (cmdletContext.RuleSetName != null)
            {
                request.RuleSetName = cmdletContext.RuleSetName;
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
        
        private Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateMatchmakingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "CreateMatchmakingConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateMatchmakingConfiguration(request);
                #elif CORECLR
                return client.CreateMatchmakingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AcceptanceRequired { get; set; }
            public System.Int32? AcceptanceTimeoutSecond { get; set; }
            public System.Int32? AdditionalPlayerCount { get; set; }
            public Amazon.GameLift.BackfillMode BackfillMode { get; set; }
            public System.String CustomEventData { get; set; }
            public System.String Description { get; set; }
            public Amazon.GameLift.FlexMatchMode FlexMatchMode { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperty { get; set; }
            public System.String GameSessionData { get; set; }
            public List<System.String> GameSessionQueueArn { get; set; }
            public System.String Name { get; set; }
            public System.String NotificationTarget { get; set; }
            public System.Int32? RequestTimeoutSecond { get; set; }
            public System.String RuleSetName { get; set; }
            public List<Amazon.GameLift.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse, NewGMLMatchmakingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
