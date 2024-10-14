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
    /// Updates settings for a FlexMatch matchmaking configuration. These changes affect all
    /// matches and game sessions that are created after the update. To update settings, specify
    /// the configuration name to be updated and provide the new settings. 
    /// 
    ///  
    /// <para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-configuration.html">
    /// Design a FlexMatch matchmaker</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLMatchmakingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingConfiguration")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateMatchmakingConfiguration API operation.", Operation = new[] {"UpdateMatchmakingConfiguration"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingConfiguration or Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse",
        "This cmdlet returns an Amazon.GameLift.Model.MatchmakingConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLMatchmakingConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>A flag that indicates whether a match that was created with this configuration must
        /// be accepted by the matched players. To require acceptance, set to TRUE. With this
        /// option enabled, matchmaking tickets use the status <c>REQUIRES_ACCEPTANCE</c> to indicate
        /// when a completed potential match is waiting for player acceptance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter AcceptanceTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The length of time (in seconds) to wait for players to accept a proposed match, if
        /// acceptance is required.</para>
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
        /// <para>The method that is used to backfill game sessions created with this matchmaking configuration.
        /// Specify MANUAL when your game manages backfill requests manually or does not use the
        /// match backfill feature. Specify AUTOMATIC to have GameLift create a match backfill
        /// request whenever a game session has one or more open slots. Learn more about manual
        /// and automatic backfill in <a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-backfill.html">Backfill
        /// Existing Games with FlexMatch</a>. Automatic backfill is not available when <c>FlexMatchMode</c>
        /// is set to <c>STANDALONE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.BackfillMode")]
        public Amazon.GameLift.BackfillMode BackfillMode { get; set; }
        #endregion
        
        #region Parameter CustomEventData
        /// <summary>
        /// <para>
        /// <para>Information to add to all events related to the matchmaking configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomEventData { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the matchmaking configuration.</para>
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
        /// a Game Session</a>). This information is added to the game session that is created
        /// for a successful match. This parameter is not used if <c>FlexMatchMode</c> is set
        /// to <c>STANDALONE</c>.</para>
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
        /// If <c>FlexMatchMode</c> is set to <c>STANDALONE</c>, do not set this parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameSessionQueueArns")]
        public System.String[] GameSessionQueueArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the matchmaking configuration to update. You can use either
        /// the configuration name or ARN value. </para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuleSetName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Configuration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Configuration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLMatchmakingConfiguration (UpdateMatchmakingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse, UpdateGMLMatchmakingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AcceptanceRequired = this.AcceptanceRequired;
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
            context.RuleSetName = this.RuleSetName;
            
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
            var request = new Amazon.GameLift.Model.UpdateMatchmakingConfigurationRequest();
            
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
        
        private Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateMatchmakingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateMatchmakingConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateMatchmakingConfiguration(request);
                #elif CORECLR
                return client.UpdateMatchmakingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.GameLift.Model.UpdateMatchmakingConfigurationResponse, UpdateGMLMatchmakingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Configuration;
        }
        
    }
}
