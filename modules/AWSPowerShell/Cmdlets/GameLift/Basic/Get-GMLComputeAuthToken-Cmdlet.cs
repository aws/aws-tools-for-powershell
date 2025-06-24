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
    /// Requests an authentication token from Amazon GameLift Servers for a compute resource
    /// in an Amazon GameLift Servers fleet. Game servers that are running on the compute
    /// use this token to communicate with the Amazon GameLift Servers service, such as when
    /// calling the Amazon GameLift Servers server SDK action <c>InitSDK()</c>. Authentication
    /// tokens are valid for a limited time span, so you need to request a fresh token before
    /// the current token expires.
    /// 
    ///  
    /// <para><b>Request options</b></para><ul><li><para>
    /// For managed EC2 fleets (compute type <c>EC2</c>), auth token retrieval and refresh
    /// is handled automatically. All game servers that are running on all fleet instances
    /// have access to a valid auth token.
    /// </para></li><li><para>
    /// For Anywhere fleets (compute type <c>ANYWHERE</c>), if you're using the Amazon GameLift
    /// Servers Agent, auth token retrieval and refresh is handled automatically for any compute
    /// where the Agent is running. If you're not using the Agent, create a mechanism to retrieve
    /// and refresh auth tokens for computes that are running game server processes.
    /// </para></li></ul><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-creating-anywhere.html">Create
    /// an Anywhere fleet</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/integration-testing.html">Test
    /// your integration</a></para></li><li><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/reference-serversdk.html">Server
    /// SDK reference guides</a> (for version 5.x)
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "GMLComputeAuthToken")]
    [OutputType("Amazon.GameLift.Model.GetComputeAuthTokenResponse")]
    [AWSCmdlet("Calls the Amazon GameLift Service GetComputeAuthToken API operation.", Operation = new[] {"GetComputeAuthToken"}, SelectReturnType = typeof(Amazon.GameLift.Model.GetComputeAuthTokenResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.GetComputeAuthTokenResponse",
        "This cmdlet returns an Amazon.GameLift.Model.GetComputeAuthTokenResponse object containing multiple properties."
    )]
    public partial class GetGMLComputeAuthTokenCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputeName
        /// <summary>
        /// <para>
        /// <para>The name of the compute resource you are requesting the authentication token for.
        /// For an Anywhere fleet compute, use the registered compute name. For an EC2 fleet instance,
        /// use the instance ID.</para>
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
        public System.String ComputeName { get; set; }
        #endregion
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet that the compute is registered to.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.GetComputeAuthTokenResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.GetComputeAuthTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ComputeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ComputeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ComputeName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.GetComputeAuthTokenResponse, GetGMLComputeAuthTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ComputeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeName = this.ComputeName;
            #if MODULAR
            if (this.ComputeName == null && ParameterWasBound(nameof(this.ComputeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GameLift.Model.GetComputeAuthTokenRequest();
            
            if (cmdletContext.ComputeName != null)
            {
                request.ComputeName = cmdletContext.ComputeName;
            }
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
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
        
        private Amazon.GameLift.Model.GetComputeAuthTokenResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.GetComputeAuthTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "GetComputeAuthToken");
            try
            {
                #if DESKTOP
                return client.GetComputeAuthToken(request);
                #elif CORECLR
                return client.GetComputeAuthTokenAsync(request).GetAwaiter().GetResult();
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
            public System.String ComputeName { get; set; }
            public System.String FleetId { get; set; }
            public System.Func<Amazon.GameLift.Model.GetComputeAuthTokenResponse, GetGMLComputeAuthTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
