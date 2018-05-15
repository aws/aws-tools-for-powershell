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
    /// Updates the current run-time configuration for the specified fleet, which tells Amazon
    /// GameLift how to launch server processes on instances in the fleet. You can update
    /// a fleet's run-time configuration at any time after the fleet is created; it does not
    /// need to be in an <code>ACTIVE</code> status.
    /// 
    ///  
    /// <para>
    /// To update run-time configuration, specify the fleet ID and provide a <code>RuntimeConfiguration</code>
    /// object with the updated collection of server process configurations.
    /// </para><para>
    /// Each instance in a Amazon GameLift fleet checks regularly for an updated run-time
    /// configuration and changes how it launches server processes to comply with the latest
    /// version. Existing server processes are not affected by the update; they continue to
    /// run until they end, while Amazon GameLift simply adds new server processes to fit
    /// the current run-time configuration. As a result, the run-time configuration changes
    /// are applied gradually as existing processes shut down and new processes are launched
    /// in Amazon GameLift's normal process recycling activity.
    /// </para><para>
    /// Fleet-related operations include:
    /// </para><ul><li><para><a>CreateFleet</a></para></li><li><para><a>ListFleets</a></para></li><li><para><a>DeleteFleet</a></para></li><li><para>
    /// Describe fleets:
    /// </para><ul><li><para><a>DescribeFleetAttributes</a></para></li><li><para><a>DescribeFleetCapacity</a></para></li><li><para><a>DescribeFleetPortSettings</a></para></li><li><para><a>DescribeFleetUtilization</a></para></li><li><para><a>DescribeRuntimeConfiguration</a></para></li><li><para><a>DescribeEC2InstanceLimits</a></para></li><li><para><a>DescribeFleetEvents</a></para></li></ul></li><li><para>
    /// Update fleets:
    /// </para><ul><li><para><a>UpdateFleetAttributes</a></para></li><li><para><a>UpdateFleetCapacity</a></para></li><li><para><a>UpdateFleetPortSettings</a></para></li><li><para><a>UpdateRuntimeConfiguration</a></para></li></ul></li><li><para>
    /// Manage fleet actions:
    /// </para><ul><li><para><a>StartFleetActions</a></para></li><li><para><a>StopFleetActions</a></para></li></ul></li></ul>
    /// </summary>
    [Cmdlet("Update", "GMLRuntimeConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GameLift.Model.RuntimeConfiguration")]
    [AWSCmdlet("Calls the Amazon GameLift Service UpdateRuntimeConfiguration API operation.", Operation = new[] {"UpdateRuntimeConfiguration"})]
    [AWSCmdletOutput("Amazon.GameLift.Model.RuntimeConfiguration",
        "This cmdlet returns a RuntimeConfiguration object.",
        "The service call response (type Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGMLRuntimeConfigurationCmdlet : AmazonGameLiftClientCmdlet, IExecutor
    {
        
        #region Parameter FleetId
        /// <summary>
        /// <para>
        /// <para>Unique identifier for a fleet to update run-time configuration for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String FleetId { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_GameSessionActivationTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Maximum amount of time (in seconds) that a game session can remain in status <code>ACTIVATING</code>.
        /// If the game session is not active before the timeout, activation is terminated and
        /// the game session status is changed to <code>TERMINATED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_GameSessionActivationTimeoutSeconds")]
        public System.Int32 RuntimeConfiguration_GameSessionActivationTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_MaxConcurrentGameSessionActivation
        /// <summary>
        /// <para>
        /// <para>Maximum number of game sessions with status <code>ACTIVATING</code> to allow on an
        /// instance simultaneously. This setting limits the amount of instance resources that
        /// can be used for new game activations at any one time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_MaxConcurrentGameSessionActivations")]
        public System.Int32 RuntimeConfiguration_MaxConcurrentGameSessionActivation { get; set; }
        #endregion
        
        #region Parameter RuntimeConfiguration_ServerProcess
        /// <summary>
        /// <para>
        /// <para>Collection of server process configurations that describe which server processes to
        /// run on each instance in a fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RuntimeConfiguration_ServerProcesses")]
        public Amazon.GameLift.Model.ServerProcess[] RuntimeConfiguration_ServerProcess { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("FleetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GMLRuntimeConfiguration (UpdateRuntimeConfiguration)"))
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
            
            context.FleetId = this.FleetId;
            if (ParameterWasBound("RuntimeConfiguration_GameSessionActivationTimeoutSecond"))
                context.RuntimeConfiguration_GameSessionActivationTimeoutSeconds = this.RuntimeConfiguration_GameSessionActivationTimeoutSecond;
            if (ParameterWasBound("RuntimeConfiguration_MaxConcurrentGameSessionActivation"))
                context.RuntimeConfiguration_MaxConcurrentGameSessionActivations = this.RuntimeConfiguration_MaxConcurrentGameSessionActivation;
            if (this.RuntimeConfiguration_ServerProcess != null)
            {
                context.RuntimeConfiguration_ServerProcesses = new List<Amazon.GameLift.Model.ServerProcess>(this.RuntimeConfiguration_ServerProcess);
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
            bool requestRuntimeConfigurationIsNull = true;
            request.RuntimeConfiguration = new Amazon.GameLift.Model.RuntimeConfiguration();
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = null;
            if (cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSeconds != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond = cmdletContext.RuntimeConfiguration_GameSessionActivationTimeoutSeconds.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond != null)
            {
                request.RuntimeConfiguration.GameSessionActivationTimeoutSeconds = requestRuntimeConfiguration_runtimeConfiguration_GameSessionActivationTimeoutSecond.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            System.Int32? requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = null;
            if (cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivations != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation = cmdletContext.RuntimeConfiguration_MaxConcurrentGameSessionActivations.Value;
            }
            if (requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation != null)
            {
                request.RuntimeConfiguration.MaxConcurrentGameSessionActivations = requestRuntimeConfiguration_runtimeConfiguration_MaxConcurrentGameSessionActivation.Value;
                requestRuntimeConfigurationIsNull = false;
            }
            List<Amazon.GameLift.Model.ServerProcess> requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = null;
            if (cmdletContext.RuntimeConfiguration_ServerProcesses != null)
            {
                requestRuntimeConfiguration_runtimeConfiguration_ServerProcess = cmdletContext.RuntimeConfiguration_ServerProcesses;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.RuntimeConfiguration;
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
        
        private Amazon.GameLift.Model.UpdateRuntimeConfigurationResponse CallAWSServiceOperation(IAmazonGameLift client, Amazon.GameLift.Model.UpdateRuntimeConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GameLift Service", "UpdateRuntimeConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateRuntimeConfiguration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRuntimeConfigurationAsync(request);
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
            public System.String FleetId { get; set; }
            public System.Int32? RuntimeConfiguration_GameSessionActivationTimeoutSeconds { get; set; }
            public System.Int32? RuntimeConfiguration_MaxConcurrentGameSessionActivations { get; set; }
            public List<Amazon.GameLift.Model.ServerProcess> RuntimeConfiguration_ServerProcesses { get; set; }
        }
        
    }
}
