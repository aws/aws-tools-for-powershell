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
    /// Updates the runtime configuration for the specified fleet. The runtime configuration
    /// tells Amazon GameLift how to launch server processes on computes in the fleet. For
    /// managed EC2 fleets, it determines what server processes to run on each fleet instance.
    /// For container fleets, it describes what server processes to run in each replica container
    /// group. You can update a fleet's runtime configuration at any time after the fleet
    /// is created; it does not need to be in <c>ACTIVE</c> status.
    /// 
    ///  
    /// <para>
    /// To update runtime configuration, specify the fleet ID and provide a <c>RuntimeConfiguration</c>
    /// with an updated set of server process configurations.
    /// </para><para>
    /// If successful, the fleet's runtime configuration settings are updated. Fleet computes
    /// that run game server processes regularly check for and receive updated runtime configurations.
    /// The computes immediately take action to comply with the new configuration by launching
    /// new server processes or by not replacing existing processes when they shut down. Updating
    /// a fleet's runtime configuration never affects existing server processes.
    /// </para><para><b>Learn more</b></para><para><a href="https://docs.aws.amazon.com/gamelift/latest/developerguide/fleets-intro.html">Setting
    /// up Amazon GameLift fleets</a></para>
    /// </summary>
    [Cmdlet("Update", "GMLRuntimeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.RuntimeConfiguration")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateRuntimeConfiguration API operation.", Operation = new[] {"UpdateRuntimeConfiguration"}, SelectReturnType = typeof(Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse))]
    [AWSCmdletOutput("Amazon.GameLift.Model.RuntimeConfiguration or Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse",
        "This cmdlet returns an Amazon.GameLift.Model.RuntimeConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLRuntimeConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the fleet to update runtime configuration for. You can use
        /// either the fleet ID or ARN value.</para>
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
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_GameSessionActivationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The maximum amount of time (in seconds) allowed to launch a new game session and have
        /// it report ready to host players. During this time, the game session is in status <c>ACTIVATING</c>.
        /// If the game session does not become active before the timeout, it is ended and the
        /// game session status is changed to <c>TERMINATED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_GameSessionActivationTimeoutSeconds")]
        public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_MaxConcurrentGameSessionActivation
        /// <summary>
        /// <para>
        /// <para>The number of game sessions in status <c>ACTIVATING</c> to allow on an instance or
        /// container. This setting limits the instance resources that can be used for new game
        /// activations at any one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_MaxConcurrentGameSessionActivations")]
        public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_ServerProcess
        /// <summary>
        /// <para>
        /// <para>A collection of server process configurations that identify what server processes
        /// to run on fleet computes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RuntimeConfiguration_ServerProcesses")]
        public Amazon.GameLift.Model.ServerProcess[] RuntimeConfiguration_ServerProcess { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RuntimeConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse).
        /// Specifying the name of a property of type Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RuntimeConfiguration";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FleetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FleetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLRuntimeConfiguration (UpdateRuntimeConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse, UpdateGMLRuntimeConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FleetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FleetId = this.FleetId;
            #if MODULAR
            if (this.FleetId == null && ParameterWasBound(nameof(this.FleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter FleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RuntimeConfiguration_GameSessionActivationTimeoutSecond = this.RuntimeConfiguration_GameSessionActivationTimeoutSecond;
            context.RuntimeConfiguration_MaxConcurrentGameSessionActivation = this.RuntimeConfiguration_MaxConcurrentGameSessionActivation;
            if (this.RuntimeConfiguration_ServerProcess != null)
            {
                context.RuntimeConfiguration_ServerProcess = new List<Amazon.GameLift.Model.ServerProcess>(this.RuntimeConfiguration_ServerProcess);
            }
            
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
            var request = new Amazon.GameLift.Model.UpdateRuntimeConfigurationRequest();
            
            if (cmdletContext.FleetId != null)
            {
                request.FleetId = cmdletContext.FleetId;
            }
            
             // populate RuntimeConfiguration
            var requestRuntimeConfigurationIsNull = true;
            request.RuntimeConfiguration = new Amazon.GameLift.Model.RuntimeConfiguration();
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = null;
            if (cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSecond.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                request.RuntimeConfiguration.GameSessionActivationTimeoutSeconds = requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = null;
            if (cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivation.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                request.RuntimeConfiguration.MaxConcurrentGameSessionActivations = requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            List<Amazon.GameLift.Model.ServerProcess> requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = null;
            if (cmdletContext.RuntimeConfiguration_ServerProcess != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = cmdletContext.RuntimeConfiguration_ServerProcess;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_ServerProcess != null)
            {
                request.RuntimeConfiguration.ServerProcesses = requestRuntimeConfiguration_runtimeConfiguration_ServerProcess;
                requestRuntimeConfigurationIsNull = false;
            }
             // determine if request.RuntimeConfiguration should be set to null
            if (requestRuntimeConfigurationIsNull)
            {
                request.RuntimeConfiguration = null;
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
        
        private Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateRuntimeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateRuntimeConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateRuntimeConfiguration(request);
                #elif CORECLR
                return client.UpdateRuntimeConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String FleetId { get; set; }
            public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
            public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
            public List<Amazon.GameLift.Model.ServerProcess> RuntimeConfiguration_ServerProcess { get; set; }
            public System.Func<Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse, UpdateGMLRuntimeConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RuntimeConfiguration;
        }
        
    }
}
