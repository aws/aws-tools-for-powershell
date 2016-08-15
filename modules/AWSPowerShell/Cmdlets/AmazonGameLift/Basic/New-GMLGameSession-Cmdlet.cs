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
    /// Creates a multiplayer game session for players. This action creates a game session
    /// record and assigns the new session to an instance in the specified fleet, which initializes
    /// a new server process to host the game session. A fleet must be in an <code>ACTIVE</code>
    /// status before a game session can be created in it.
    /// 
    ///  
    /// <para>
    /// To create a game session, specify either a fleet ID or an alias ID and indicate the
    /// maximum number of players the game session allows. You can also provide a name and
    /// a set of properties for your game (optional). If successful, a <a>GameSession</a>
    /// object is returned containing session properties, including an IP address. By default,
    /// newly created game sessions are set to accept adding any new players to the game session.
    /// Use <a>UpdateGameSession</a> to change the creation policy.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Invokes the CreateGameSession operation against Amazon GameLift Service.", Operation = new[] {"CreateGameSession"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession",
        "This cmdlet returns a GameSession object.",
        "The service call response (type Amazon.GameLift.Model.CreateGameSessionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter AliasId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet alias. Each request must reference either a fleet ID
        /// or alias ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AliasId { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet. Each request must reference either a fleet ID or alias
        /// ID, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>Set of properties used to administer a game session. These properties are passed to
        /// the server process hosting it. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter MaximumPlayerSessionCount
        /// <summary>
        /// <para>
        /// <para>Maximum number of players that can be connected simultaneously to the game session.
        /// </para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GMLGameSession (CreateGameSession)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AliasId = this.AliasId;
            context.FleetId = this.FleetId;
            if (this.GameProperty != null)
            {
                context.GameProperties = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            if (ParameterWasBound("MaximumPlayerSessionCount"))
                context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            context.Name = this.Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.GameLift.Model.CreateGameSessionRequest();
            
            if (cmdletContext.AliasId != null)
            {
                request.AliasId = cmdletContext.AliasId;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            if (cmdletContext.GameProperties != null)
            {
                request.GameProperties = cmdletContext.GameProperties;
            }
            if (cmdletContext.MaximumPlayerSessionCount != null)
            {
                request.MaximumPlayerSessionCount = cmdletContext.MaximumPlayerSessionCount.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private static Amazon.GameLift.Model.CreateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.CreateGameSessionRequest request)
        {
            return client.CreateGameSession(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AliasId { get; set; }
            public System.String FleetId { get; set; }
            public List<Amazon.GameLift.Model.GameProperty> GameProperties { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
