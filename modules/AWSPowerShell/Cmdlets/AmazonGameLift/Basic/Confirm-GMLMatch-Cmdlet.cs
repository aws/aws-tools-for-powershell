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
    /// Registers a player's acceptance or rejection of a proposed FlexMatch match. A matchmaking
    /// configuration may require player acceptance; if so, then matches built with that configuration
    /// cannot be completed unless all players accept the proposed match within a specified
    /// time limit. 
    /// 
    ///  
    /// <para>
    /// When FlexMatch builds a match, all the matchmaking tickets involved in the proposed
    /// match are placed into status <code>REQUIRES_ACCEPTANCE</code>. This is a trigger for
    /// your game to get acceptance from all players in the ticket. Acceptances are only valid
    /// for tickets when they are in this status; all other acceptances result in an error.
    /// </para><para>
    /// To register acceptance, specify the ticket ID, a response, and one or more players.
    /// Once all players have registered acceptance, the matchmaking tickets advance to status
    /// <code>PLACING</code>, where a new game session is created for the match. 
    /// </para><para>
    /// If any player rejects the match, or if acceptances are not received before a specified
    /// timeout, the proposed match is dropped. The matchmaking tickets are then handled in
    /// one of two ways: For tickets where all players accepted the match, the ticket status
    /// is returned to <code>SEARCHING</code> to find a new match. For tickets where one or
    /// more players failed to accept the match, the ticket status is set to <code>FAILED</code>,
    /// and processing is terminated. A new matchmaking request for these players can be submitted
    /// as needed. 
    /// </para><para>
    /// Matchmaking-related operations include:
    /// </para><ul><li><para><a>StartMatchmaking</a></para></li><li><para><a>DescribeMatchmaking</a></para></li><li><para><a>StopMatchmaking</a></para></li><li><para><a>AcceptMatch</a></para></li><li><para><a>StartMatchBackfill</a></para></li></ul>
    /// </summary>
    [Cmdlet("Confirm", "GMLMatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon GameLift Service AcceptMatch API operation.", Operation = new[] {"AcceptMatch"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the TicketId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.GameLift.Model.AcceptMatchResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConfirmGMLMatchCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AcceptanceType
        /// <summary>
        /// <para>
        /// <para>Player response to the proposed match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.AcceptanceType")]
        public Amazon.GameLift.AcceptanceType AcceptanceType { get; set; }
        #endregion
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a player delivering the response. This parameter can include
        /// one or multiple player IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlayerIds")]
        public System.String[] PlayerId { get; set; }
        #endregion
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a matchmaking ticket. The ticket must be in status <code>REQUIRES_ACCEPTANCE</code>;
        /// otherwise this request will fail.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TicketId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the TicketId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TicketId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-GMLMatch (AcceptMatch)"))
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
            
            context.AcceptanceType = this.AcceptanceType;
            if (this.PlayerId != null)
            {
                context.PlayerIds = new List<System.String>(this.PlayerId);
            }
            context.TicketId = this.TicketId;
            
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
            var request = new Amazon.GameLift.Model.AcceptMatchRequest();
            
            if (cmdletContext.AcceptanceType != null)
            {
                request.AcceptanceType = cmdletContext.AcceptanceType;
            }
            if (cmdletContext.PlayerIds != null)
            {
                request.PlayerIds = cmdletContext.PlayerIds;
            }
            if (cmdletContext.TicketId != null)
            {
                request.TicketId = cmdletContext.TicketId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.TicketId;
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
        
        private Amazon.GameLift.Model.AcceptMatchResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.AcceptMatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "AcceptMatch");
            try
            {
                #if DESKTOP
                return client.AcceptMatch(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AcceptMatchAsync(request);
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
            public Amazon.GameLift.AcceptanceType AcceptanceType { get; set; }
            public List<System.String> PlayerIds { get; set; }
            public System.String TicketId { get; set; }
        }
        
    }
}
