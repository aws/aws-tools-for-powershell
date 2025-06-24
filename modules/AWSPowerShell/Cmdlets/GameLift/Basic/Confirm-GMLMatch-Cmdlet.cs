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
using Amazon.GameLift;
using Amazon.GameLift.Model;

#pragma warning disable CS0618, CS0612
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
    /// match are placed into status <c>REQUIRES_ACCEPTANCE</c>. This is a trigger for your
    /// game to get acceptance from all players in each ticket. Calls to this action are only
    /// valid for tickets that are in this status; calls for tickets not in this status result
    /// in an error.
    /// </para><para>
    /// To register acceptance, specify the ticket ID, one or more players, and an acceptance
    /// response. When all players have accepted, Amazon GameLift Servers advances the matchmaking
    /// tickets to status <c>PLACING</c>, and attempts to create a new game session for the
    /// match. 
    /// </para><para>
    /// If any player rejects the match, or if acceptances are not received before a specified
    /// timeout, the proposed match is dropped. Each matchmaking ticket in the failed match
    /// is handled as follows: 
    /// </para><ul><li><para>
    /// If the ticket has one or more players who rejected the match or failed to respond,
    /// the ticket status is set <c>CANCELLED</c> and processing is terminated.
    /// </para></li><li><para>
    /// If all players in the ticket accepted the match, the ticket status is returned to
    /// <c>SEARCHING</c> to find a new match. 
    /// </para></li></ul><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-client.html">
    /// Add FlexMatch to a game client</a></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/flexmatchguide/match-events.html">
    /// FlexMatch events</a> (reference)
    /// </para>
    /// </summary>
    [Cmdlet("Confirm", "GMLMatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon GameLift Service AcceptMatch API operation.", Operation = new[] {"AcceptMatch"}, SelectReturnType = typeof(Amazon.GameLift.Model.AcceptMatchResponse))]
    [AWSCmdletOutput("None or Amazon.GameLift.Model.AcceptMatchResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.GameLift.Model.AcceptMatchResponse) be returned by specifying '-Select *'."
    )]
    public partial class ConfirmGMLMatchCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AcceptanceType
        /// <summary>
        /// <para>
        /// <para>Player response to the proposed match.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.AcceptanceType")]
        public Amazon.GameLift.AcceptanceType AcceptanceType { get; set; }
        #endregion
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a player delivering the response. This parameter can include
        /// one or multiple player IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("PlayerIds")]
        public System.String[] PlayerId { get; set; }
        #endregion
        
        #region Parameter TicketId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a matchmaking ticket. The ticket must be in status <c>REQUIRES_ACCEPTANCE</c>;
        /// otherwise this request will fail.</para>
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
        public System.String TicketId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.AcceptMatchResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TicketId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-GMLMatch (AcceptMatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.AcceptMatchResponse, ConfirmGMLMatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AcceptanceType = this.AcceptanceType;
            #if MODULAR
            if (this.AcceptanceType == null && ParameterWasBound(nameof(this.AcceptanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter AcceptanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PlayerId != null)
            {
                context.PlayerId = new List<System.String>(this.PlayerId);
            }
            #if MODULAR
            if (this.PlayerId == null && ParameterWasBound(nameof(this.PlayerId)))
            {
                WriteWarning("You are passing $null as a value for parameter PlayerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TicketId = this.TicketId;
            #if MODULAR
            if (this.TicketId == null && ParameterWasBound(nameof(this.TicketId)))
            {
                WriteWarning("You are passing $null as a value for parameter TicketId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.AcceptMatchRequest();
            
            if (cmdletContext.AcceptanceType != null)
            {
                request.AcceptanceType = cmdletContext.AcceptanceType;
            }
            if (cmdletContext.PlayerId != null)
            {
                request.PlayerIds = cmdletContext.PlayerId;
            }
            if (cmdletContext.TicketId != null)
            {
                request.TicketId = cmdletContext.TicketId;
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
        
        private Amazon.GameLift.Model.AcceptMatchResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.AcceptMatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "AcceptMatch");
            try
            {
                return client.AcceptMatchAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> PlayerId { get; set; }
            public System.String TicketId { get; set; }
            public System.Func<Amazon.GameLift.Model.AcceptMatchResponse, ConfirmGMLMatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
