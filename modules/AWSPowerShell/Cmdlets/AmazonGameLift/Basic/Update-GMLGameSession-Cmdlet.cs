/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates game session properties. This includes the session name, maximum player count,
    /// protection policy, which controls whether or not an active game session can be terminated
    /// during a scale-down event, and the player session creation policy, which controls
    /// whether or not new players can join the session. To update a game session, specify
    /// the game session ID and the values you want to change. If successful, an updated <a>GameSession</a>
    /// object is returned.
    /// </summary>
    [Cmdlet("Update", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Invokes the UpdateGameSession operation against Amazon GameLift Service.", Operation = new[] {"UpdateGameSession"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession",
        "This cmdlet returns a GameSession object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a game session. Specify the game session you want to update.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GameSessionId { get; set; }
        #endregion
        
        #region Parameter MaximumPlayerSessionCount
        /// <summary>
        /// <para>
        /// <para>Maximum number of players that can be simultaneously connected to the game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaximumPlayerSessionCount { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Descriptive label associated with a game session. Session names do not need to be
        /// unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlayerSessionCreationPolicy
        /// <summary>
        /// <para>
        /// <para>Policy determining whether or not the game session accepts new players.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.PlayerSessionCreationPolicy")]
        public Amazon.GameLift.PlayerSessionCreationPolicy PlayerSessionCreationPolicy { get; set; }
        #endregion
        
        #region Parameter ProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>Game session protection policy to apply to this game session only.</para><ul><li><b>NoProtection</b> – The game session can be terminated during a scale-down
        /// event.</li><li><b>FullProtection</b> – If the game session is in an <code>ACTIVE</code>
        /// status, it cannot be terminated during a scale-down event.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy ProtectionPolicy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("GameSessionId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLGameSession (UpdateGameSession)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.GameSessionId = this.GameSessionId;
            if (ParameterWasBound("MaximumPlayerSessionCount"))
                context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            context.Name = this.Name;
            context.PlayerSessionCreationPolicy = this.PlayerSessionCreationPolicy;
            context.ProtectionPolicy = this.ProtectionPolicy;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.UpdateGameSessionRequest();
            
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.MaximumPlayerSessionCount != null)
            {
                request.MaximumPlayerSessionCount = cmdletContext.MaximumPlayerSessionCount.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PlayerSessionCreationPolicy != null)
            {
                request.PlayerSessionCreationPolicy = cmdletContext.PlayerSessionCreationPolicy;
            }
            if (cmdletContext.ProtectionPolicy != null)
            {
                request.ProtectionPolicy = cmdletContext.ProtectionPolicy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GameSession;
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
        
        private static Amazon.GameLift.Model.UpdateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateGameSessionRequest request)
        {
            return client.UpdateGameSession(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String GameSessionId { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.PlayerSessionCreationPolicy PlayerSessionCreationPolicy { get; set; }
            public Amazon.GameLift.ProtectionPolicy ProtectionPolicy { get; set; }
        }
        
    }
}
