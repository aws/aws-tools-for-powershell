/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Defines a new matchmaking configuration for use with FlexMatch. A matchmaking configuration
    /// sets out guidelines for matching players and getting the matches into games. You can
    /// set up multiple matchmaking configurations to handle the scenarios needed for your
    /// game. Each matchmaking request (<a>StartMatchmaking</a>) specifies a configuration
    /// for the match and provides player attributes to support the configuration being used.
    /// 
    /// 
    ///  
    /// <para>
    /// To create a matchmaking configuration, at a minimum you must specify the following:
    /// configuration name; a rule set that governs how to evaluate players and find acceptable
    /// matches; a game session queue to use when placing a new game session for the match;
    /// and the maximum time allowed for a matchmaking attempt.
    /// </para><para><b>Player acceptance</b> -- In each configuration, you have the option to require
    /// that all players accept participation in a proposed match. To enable this feature,
    /// set <i>AcceptanceRequired</i> to true and specify a time limit for player acceptance.
    /// Players have the option to accept or reject a proposed match, and a match does not
    /// move ahead to game session placement unless all matched players accept. 
    /// </para><para><b>Matchmaking status notification</b> -- There are two ways to track the progress
    /// of matchmaking tickets: (1) polling ticket status with <a>DescribeMatchmaking</a>;
    /// or (2) receiving notifications with Amazon Simple Notification Service (SNS). To use
    /// notifications, you first need to set up an SNS topic to receive the notifications,
    /// and provide the topic ARN in the matchmaking configuration (see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/match-notification.html">
    /// Setting up Notifications for Matchmaking</a>). Since notifications promise only "best
    /// effort" delivery, we recommend calling <code>DescribeMatchmaking</code> if no notifications
    /// are received within 30 seconds.
    /// </para><para>
    /// Operations related to match configurations and rule sets include:
    /// </para><ul><li><para><a>CreateMatchmakingConfiguration</a></para></li><li><para><a>DescribeMatchmakingConfigurations</a></para></li><li><para><a>UpdateMatchmakingConfiguration</a></para></li><li><para><a>DeleteMatchmakingConfiguration</a></para></li><li><para><a>CreateMatchmakingRuleSet</a></para></li><li><para><a>DescribeMatchmakingRuleSets</a></para></li><li><para><a>ValidateMatchmakingRuleSet</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "GMLMatchmakingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.MatchmakingConfiguration")]
    [AWSCmdlet("Calls the Amazon GameLift Service CreateMatchmakingConfiguration API operation.", Operation = new[] {"CreateMatchmakingConfiguration"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.MatchmakingConfiguration",
        "This cmdlet returns a MatchmakingConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.CreateMatchmakingConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGMLMatchmakingConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptanceRequired
        /// <summary>
        /// <para>
        /// <para>Flag that determines whether or not a match that was created with this configuration
        /// must be accepted by the matched players. To require acceptance, set to TRUE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AcceptanceRequired { get; set; }
        #endregion
        
        #region Parameter AcceptanceTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Length of time (in seconds) to wait for players to accept a proposed match. If any
        /// player rejects the match or fails to accept before the timeout, the ticket continues
        /// to look for an acceptable match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AcceptanceTimeoutSeconds")]
        public System.Int32 AcceptanceTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter AdditionalPlayerCount
        /// <summary>
        /// <para>
        /// <para>Number of player slots in a match to keep open for future players. For example, if
        /// the configuration's rule set specifies a match for a single 12-person team, and the
        /// additional player count is set to 2, only 10 players are selected for the match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 AdditionalPlayerCount { get; set; }
        #endregion
        
        #region Parameter CustomEventData
        /// <summary>
        /// <para>
        /// <para>Information to attached to all events related to the matchmaking configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomEventData { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Meaningful description of the matchmaking configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>Set of custom properties for a game session, formatted as key:value pairs. These properties
        /// are passed to a game server process in the <a>GameSession</a> object with a request
        /// to start a new game session (see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>). This information is added to the new <a>GameSession</a> object
        /// that is created for a successful match. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter GameSessionData
        /// <summary>
        /// <para>
        /// <para>Set of custom game session properties, formatted as a single string value. This data
        /// is passed to a game server process in the <a>GameSession</a> object with a request
        /// to start a new game session (see <a href="http://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html#gamelift-sdk-server-startsession">Start
        /// a Game Session</a>). This information is added to the new <a>GameSession</a> object
        /// that is created for a successful match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String GameSessionData { get; set; }
        #endregion
        
        #region Parameter GameSessionQueueArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (<a href="http://docs.aws.amazon.com/AmazonS3/latest/dev/s3-arn-format.html">ARN</a>)
        /// that is assigned to a game session queue and uniquely identifies it. Format is <code>arn:aws:gamelift:&lt;region&gt;::fleet/fleet-a1234567-b8c9-0d1e-2fa3-b45c6d7e8912</code>.
        /// These queues are used when placing game sessions for matches that are created with
        /// this matchmaking configuration. Queues can be located in any region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GameSessionQueueArns")]
        public System.String[] GameSessionQueueArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking configuration. This name is used to identify the
        /// configuration associated with a matchmaking request or ticket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NotificationTarget
        /// <summary>
        /// <para>
        /// <para>SNS topic ARN that is set up to receive matchmaking notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTarget { get; set; }
        #endregion
        
        #region Parameter RequestTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Maximum duration, in seconds, that a matchmaking ticket can remain in process before
        /// timing out. Requests that time out can be resubmitted as needed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RequestTimeoutSeconds")]
        public System.Int32 RequestTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RuleSetName
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking rule set to use with this configuration. A matchmaking
        /// configuration can only use rule sets that are defined in the same region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RuleSetName { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RuleSetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLMatchmakingConfiguration (CreateMatchmakingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("AcceptanceRequired"))
                context.AcceptanceRequired = this.AcceptanceRequired;
            if (ParameterWasBound("AcceptanceTimeoutSecond"))
                context.AcceptanceTimeoutSeconds = this.AcceptanceTimeoutSecond;
            if (ParameterWasBound("AdditionalPlayerCount"))
                context.AdditionalPlayerCount = this.AdditionalPlayerCount;
            context.CustomEventData = this.CustomEventData;
            context.Description = this.Description;
            if (this.GameProperty != null)
            {
                context.GameProperties = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionData = this.GameSessionData;
            if (this.GameSessionQueueArn != null)
            {
                context.GameSessionQueueArns = new List<System.String>(this.GameSessionQueueArn);
            }
            context.Name = this.Name;
            context.NotificationTarget = this.NotificationTarget;
            if (ParameterWasBound("RequestTimeoutSecond"))
                context.RequestTimeoutSeconds = this.RequestTimeoutSecond;
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
            var request = new Amazon.GameLift.Model.CreateMatchmakingConfigurationRequest();
            
            if (cmdletContext.AcceptanceRequired != null)
            {
                request.AcceptanceRequired = cmdletContext.AcceptanceRequired.Value;
            }
            if (cmdletContext.AcceptanceTimeoutSeconds != null)
            {
                request.AcceptanceTimeoutSeconds = cmdletContext.AcceptanceTimeoutSeconds.Value;
            }
            if (cmdletContext.AdditionalPlayerCount != null)
            {
                request.AdditionalPlayerCount = cmdletContext.AdditionalPlayerCount.Value;
            }
            if (cmdletContext.CustomEventData != null)
            {
                request.CustomEventData = cmdletContext.CustomEventData;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.GameProperties != null)
            {
                request.GameProperties = cmdletContext.GameProperties;
            }
            if (cmdletContext.GameSessionData != null)
            {
                request.GameSessionData = cmdletContext.GameSessionData;
            }
            if (cmdletContext.GameSessionQueueArns != null)
            {
                request.GameSessionQueueArns = cmdletContext.GameSessionQueueArns;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NotificationTarget != null)
            {
                request.NotificationTarget = cmdletContext.NotificationTarget;
            }
            if (cmdletContext.RequestTimeoutSeconds != null)
            {
                request.RequestTimeoutSeconds = cmdletContext.RequestTimeoutSeconds.Value;
            }
            if (cmdletContext.RuleSetName != null)
            {
                request.RuleSetName = cmdletContext.RuleSetName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Configuration;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateMatchmakingConfigurationAsync(request);
                return task.Result;
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
            public System.Int32? AcceptanceTimeoutSeconds { get; set; }
            public System.Int32? AdditionalPlayerCount { get; set; }
            public System.String CustomEventData { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperties { get; set; }
            public System.String GameSessionData { get; set; }
            public List<System.String> GameSessionQueueArns { get; set; }
            public System.String Name { get; set; }
            public System.String NotificationTarget { get; set; }
            public System.Int32? RequestTimeoutSeconds { get; set; }
            public System.String RuleSetName { get; set; }
        }
        
    }
}
