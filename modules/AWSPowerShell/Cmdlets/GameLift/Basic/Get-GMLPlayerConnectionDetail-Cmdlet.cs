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
    /// <b>This API works with the following fleet types:</b> EC2 (server SDK 5.x or later),
    /// Container
    /// 
    ///  
    /// <para>
    /// Retrieves connection details for game clients to connect to game sessions. 
    /// </para><para><b>Player gateway benefits:</b> DDoS protection with negligible impact to latency.
    /// 
    /// </para><para>
    /// To enable player gateway on your fleet, set <c>PlayerGatewayMode</c> to <c>ENABLED</c>
    /// or <c>REQUIRED</c> when calling <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateFleet.html">CreateFleet</a>
    /// or <a href="https://docs.aws.amazon.com/gamelift/latest/apireference/API_CreateContainerFleet.html">CreateContainerFleet</a>.
    /// </para><para><b>How to use:</b> After creating a game session and adding players, call this operation
    /// with the game session ID and player IDs. When player gateway is enabled, the response
    /// includes connection endpoints and player gateway tokens that your game clients can
    /// use to connect to the game session through player gateway. To learn more about player
    /// gateway integration, see <a href="https://docs.aws.amazon.com/gameliftservers/latest/developerguide/ddos-protection-intro.html">DDoS
    /// protection with Amazon GameLift Servers player gateway</a>.
    /// </para><para>
    /// When player gateway is disabled or in locations where player gateway is not supported,
    /// this operation returns game server connection information without player gateway tokens,
    /// so that your game clients directly connect to the game server endpoint.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GMLPlayerConnectionDetail")]
    [OutputType("Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse")]
    [AWSCmdlet("Calls the Amazon GameLift Service GetPlayerConnectionDetails API operation.", Operation = new[] {"GetPlayerConnectionDetails"}, SelectReturnType = typeof(Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse object containing multiple properties."
    )]
    public partial class GetGMLPlayerConnectionDetailCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GameSessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the game session for which to retrieve player connection details.</para>
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
        
        #region Parameter PlayerId
        /// <summary>
        /// <para>
        /// <para>List of unique identifiers for players. Connection details are returned for each player
        /// in this list.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse, GetGMLPlayerConnectionDetailCmdlet>(Select) ??
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
            var request = new Amazon.GameLift.Model.GetPlayerConnectionDetailsRequest();
            
            if (cmdletContext.GameSessionId != null)
            {
                request.GameSessionId = cmdletContext.GameSessionId;
            }
            if (cmdletContext.PlayerId != null)
            {
                request.PlayerIds = cmdletContext.PlayerId;
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
        
        private Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.GetPlayerConnectionDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "GetPlayerConnectionDetails");
            try
            {
                #if DESKTOP
                return client.GetPlayerConnectionDetails(request);
                #elif CORECLR
                return client.GetPlayerConnectionDetailsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> PlayerId { get; set; }
            public System.Func<Amazon.GameLift.Model.GetPlayerConnectionDetailsResponse, GetGMLPlayerConnectionDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
