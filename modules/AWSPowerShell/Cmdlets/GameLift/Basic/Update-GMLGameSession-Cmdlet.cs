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
    /// Updates the mutable properties of a game session. 
    /// 
    ///  
    /// <para>
    /// To update a game session, specify the game session ID and the values you want to change.
    /// 
    /// </para><para>
    /// If successful, the updated <c>GameSession</c> object is returned. 
    /// </para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-awssdk.html#reference-awssdk-resources-fleets">All
    /// APIs by task</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLGameSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.GameSession")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateGameSession API operation.", Operation = new[] {"UpdateGameSession"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateGameSessionResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GameSession or Amazon.GameLift.Model.UpdateGameSessionResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GameSession object.",
        "The service call response (type Amazon.GameLift.Model.UpdateGameSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGMLGameSessionCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GameProperty
        /// <summary>
        /// <para>
        /// <para>A set of key-value pairs that can store custom data in a game session. For example:
        /// <c>{"Key": "difficulty", "Value": "novice"}</c>. You can use this parameter to modify
        /// game properties in an active game session. This action adds new properties and modifies
        /// existing properties. There is no way to delete properties. For an example, see <a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/gamelift-sdk-client-api.html#game-properties-update">Update
        /// the value of a game property</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GameProperties")]
        public Amazon.GameLift.Model.GameProperty[] GameProperty { get; set; }
        #endregion
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session to update. </para>
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
        
        #region Parameter MaximumPlayerSessionCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of players that can be connected simultaneously to the game session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaximumPlayerSessionCount { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A descriptive label that is associated with a game session. Session names do not need
        /// to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PlayerSessionCreationPolicy
        /// <summary>
        /// <para>
        /// <para>A policy that determines whether the game session is accepting new players.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.PlayerSessionCreationPolicy")]
        public Amazon.GameLift.PlayerSessionCreationPolicy PlayerSessionCreationPolicy { get; set; }
        #endregion
        
        #region Parameter ProtectionPolicy
        /// <summary>
        /// <para>
        /// <para>Game session protection policy to apply to this game session only.</para><ul><li><para><c>NoProtection</c> -- The game session can be terminated during a scale-down event.</para></li><li><para><c>FullProtection</c> -- If the game session is in an <c>ACTIVE</c> status, it cannot
        /// be terminated during a scale-down event.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GameLift.ProtectionPolicy")]
        public Amazon.GameLift.ProtectionPolicy ProtectionPolicy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GameSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateGameSessionResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateGameSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GameSession";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLGameSession (UpdateGameSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateGameSessionResponse, UpdateGMLGameSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.GameProperty != null)
            {
                context.GameProperty = new List<Amazon.GameLift.Model.GameProperty>(this.GameProperty);
            }
            context.GameSessionId = this.GameSessionId;
            #if MODULAR
            if (this.GameSessionId == null && ParameterWasBound(nameof(this.GameSessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter GameSessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaximumPlayerSessionCount = this.MaximumPlayerSessionCount;
            context.Name = this.Name;
            context.PlayerSessionCreationPolicy = this.PlayerSessionCreationPolicy;
            context.ProtectionPolicy = this.ProtectionPolicy;
            
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
            var request = new Amazon.GameLift.Model.UpdateGameSessionRequest();
            
            if (cmdletContext.GameProperty != null)
            {
                request.GameProperties = cmdletContext.GameProperty;
            }
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
        
        private Amazon.GameLift.Model.UpdateGameSessionResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateGameSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateGameSession");
            try
            {
                #if DESKTOP
                return client.UpdateGameSession(request);
                #elif CORECLR
                return client.UpdateGameSessionAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GameLift.Model.GameProperty> GameProperty { get; set; }
            public System.String GameSessionId { get; set; }
            public System.Int32? MaximumPlayerSessionCount { get; set; }
            public System.String Name { get; set; }
            public Amazon.GameLift.PlayerSessionCreationPolicy PlayerSessionCreationPolicy { get; set; }
            public Amazon.GameLift.ProtectionPolicy ProtectionPolicy { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateGameSessionResponse, UpdateGMLGameSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GameSession;
        }
        
    }
}
