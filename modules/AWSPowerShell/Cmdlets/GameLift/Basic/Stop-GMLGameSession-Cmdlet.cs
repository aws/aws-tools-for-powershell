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
using Amazon.GameLift;
using Amazon.GameLift.Model;

namespace Amazon.PowerShell.Cmdlets.GML
{
    /// <summary>
    /// <b>This API works with the following fleet types:</b> EC2, Anywhere, Container
    /// 
    ///  
    /// <para>
    /// Ends a game session that's currently in progress. Use this action to terminate any
    /// game session that isn't in <c>ERROR</c> status. Terminating a game session is the
    /// most efficient way to free up a server process when it's hosting a game session that's
    /// in a bad state or not ending properly. You can use this action to terminate a game
    /// session that's being hosted on any type of Amazon GameLift Servers fleet compute,
    /// including computes for managed EC2, managed container, and Anywhere fleets. The game
    /// server must be integrated with Amazon GameLift Servers server SDK 5.x or greater.
    /// </para><para><b>Request options</b></para><para>
    /// Request termination for a single game session. Provide the game session ID and the
    /// termination mode. There are two potential methods for terminating a game session:
    /// </para><ul><li><para>
    /// Initiate a graceful termination using the normal game session shutdown sequence. With
    /// this mode, the Amazon GameLift Servers service prompts the server process that's hosting
    /// the game session by calling the server SDK callback method <c>OnProcessTerminate()</c>.
    /// The callback implementation is part of the custom game server code. It might involve
    /// a variety of actions to gracefully end a game session, such as notifying players,
    /// before stopping the server process.
    /// </para></li><li><para>
    /// Force an immediate game session termination. With this mode, the Amazon GameLift Servers
    /// service takes action to stop the server process, which ends the game session without
    /// the normal game session shutdown sequence. 
    /// </para></li></ul><para><b>Results</b></para><para>
    /// If successful, game session termination is initiated. During this activity, the game
    /// session status is changed to <c>TERMINATING</c>. When completed, the server process
    /// that was hosting the game session has been stopped and replaced with a new server
    /// process that's ready to host a new game session. The old game session's status is
    /// changed to <c>TERMINATED</c> with a status reason that indicates the termination method
    /// used.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-server-api.html">Add
    /// Amazon GameLift Servers to your game server</a></para><para>
    /// Amazon GameLift Servers server SDK 5 reference guide for <c>OnProcessTerminate()</c>
    /// (<a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-server-sdk5-cpp-initsdk.html">C++</a>)
    /// (<a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-server-sdk5-csharp-initsdk.html">C#</a>)
    /// (<a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-server-sdk5-unreal-initsdk.html">Unreal</a>)
    /// (<a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-server-sdk-go-initsdk.html">Go</a>)
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service TerminateGameSession API operation.", Operation = new[] {"TerminateGameSession"}, SelectReturnType = typeof(Amazon.GameLift.Model.TerminateGameSessionResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession or Amazon.GameLift.Model.TerminateGameSessionResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSession object.",
        "The service call response (type Amazon.GameLift.Model.TerminateGameSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session to be terminated. A game session ARN has
        /// the following format: <c>arn:aws:gamelift:&lt;location&gt;::gamesession/&lt;fleet
        /// ID&gt;/&lt;custom ID string or idempotency token&gt;</c>.</para>
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
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter TerminationMode
        /// <summary>
        /// <para>
        /// <para>The method to use to terminate the game session. Available methods include: </para><ul><li><para><c>TRIGGER_ON_PROCESS_TERMINATE</c> – Prompts the Amazon GameLift Servers service
        /// to send an <c>OnProcessTerminate()</c> callback to the server process and initiate
        /// the normal game session shutdown sequence. The <c>OnProcessTerminate</c> method, which
        /// is implemented in the game server code, must include a call to the server SDK action
        /// <c>ProcessEnding()</c>, which is how the server process signals to Amazon GameLift
        /// Servers that a game session is ending. If the server process doesn't call <c>ProcessEnding()</c>,
        /// the game session termination won't conclude successfully.</para></li><li><para><c>FORCE_TERMINATE</c> – Prompts the Amazon GameLift Servers service to stop the
        /// server process immediately. Amazon GameLift Servers takes action (depending on the
        /// type of fleet) to shut down the server process without the normal game session shutdown
        /// sequence. </para><note><para>This method is not available for game sessions that are running on Anywhere fleets
        /// unless the fleet is deployed with the Amazon GameLift Servers Agent. In this scenario,
        /// a force terminate request results in an invalid or bad request exception.</para></note></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GameLift.TerminationMode")]
        public Amazon.GameLift.TerminationMode TerminationMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.TerminateGameSessionResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.TerminateGameSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSession";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GameSessionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GameSessionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GameSessionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GameSessionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-GMLGameSession (TerminateGameSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.TerminateGameSessionResponse, StopGMLGameSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GameSessionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GameSessionId = this.GameSessionId;
            #if MODULAR
            if (this.GameSessionId == null && ParameterWasBound(nameof(this.GameSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TerminationMode = this.TerminationMode;
            #if MODULAR
            if (this.TerminationMode == null && ParameterWasBound(nameof(this.TerminationMode)))
            {
                WriteWarning("You are passing $null as a value for parameter TerminationMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.TerminateGameSessionRequest();
            
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.TerminationMode != null)
            {
                request.TerminationMode = cmdletContext.TerminationMode;
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
        
        private Amazon.GameLift.Model.TerminateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.TerminateGameSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "TerminateGameSession");
            try
            {
                #if DESKTOP
                return client.TerminateGameSession(request);
                #elif CORECLR
                return client.TerminateGameSessionAsync(request).GetAwaiter().GetResult();
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
            public System.String GameSessionId { get; set; }
            public Amazon.GameLift.TerminationMode TerminationMode { get; set; }
            public System.Func<Amazon.GameLift.Model.TerminateGameSessionResponse, StopGMLGameSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSession;
        }
        
    }
}
