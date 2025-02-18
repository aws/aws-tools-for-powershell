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
using Amazon.Route53RecoveryCluster;
using Amazon.Route53RecoveryCluster.Model;

namespace Amazon.PowerShell.Cmdlets.RRC
{
    /// <summary>
    /// Set the state of the routing control to reroute traffic. You can set the value to
    /// ON or OFF. When the state is ON, traffic flows to a cell. When the state is OFF, traffic
    /// does not flow.
    /// 
    ///  
    /// <para>
    /// With Route 53 ARC, you can add safety rules for routing controls, which are safeguards
    /// for routing control state updates that help prevent unexpected outcomes, like fail
    /// open traffic routing. However, there are scenarios when you might want to bypass the
    /// routing control safeguards that are enforced with safety rules that you've configured.
    /// For example, you might want to fail over quickly for disaster recovery, and one or
    /// more safety rules might be unexpectedly preventing you from updating a routing control
    /// state to reroute traffic. In a "break glass" scenario like this, you can override
    /// one or more safety rules to change a routing control state and fail over your application.
    /// </para><para>
    /// The <c>SafetyRulesToOverride</c> property enables you override one or more safety
    /// rules and update routing control states. For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.override-safety-rule.html">
    /// Override safety rules to reroute traffic</a> in the Amazon Route 53 Application Recovery
    /// Controller Developer Guide.
    /// </para><para><i>You must specify Regional endpoints when you work with API cluster operations
    /// to get or update routing control states in Route 53 ARC.</i></para><para>
    /// To see a code example for getting a routing control state, including accessing Regional
    /// cluster endpoints in sequence, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/service_code_examples_actions.html">API
    /// examples</a> in the Amazon Route 53 Application Recovery Controller Developer Guide.
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.update.html">
    /// Viewing and updating routing control states</a></para></li><li><para><a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.html">Working
    /// with routing controls overall</a></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "RRCRoutingControlState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Route53 Recovery Cluster UpdateRoutingControlState API operation.", Operation = new[] {"UpdateRoutingControlState"}, SelectReturnType = typeof(Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse))]
    [AWSCmdletOutput("None or Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateRRCRoutingControlStateCmdlet : AmazonRoute53RecoveryClusterClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RoutingControlArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the routing control that you want to update the
        /// state for.</para>
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
        public System.String RoutingControlArn { get; set; }
        #endregion
        
        #region Parameter RoutingControlState
        /// <summary>
        /// <para>
        /// <para>The state of the routing control. You can set the value to ON or OFF.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Route53RecoveryCluster.RoutingControlState")]
        public Amazon.Route53RecoveryCluster.RoutingControlState RoutingControlState { get; set; }
        #endregion
        
        #region Parameter SafetyRulesToOverride
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) for the safety rules that you want to override when
        /// you're updating the state of a routing control. You can override one safety rule or
        /// multiple safety rules by including one or more ARNs, separated by commas.</para><para>For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.override-safety-rule.html">
        /// Override safety rules to reroute traffic</a> in the Amazon Route 53 Application Recovery
        /// Controller Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SafetyRulesToOverride { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoutingControlArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RRCRoutingControlState (UpdateRoutingControlState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse, UpdateRRCRoutingControlStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RoutingControlArn = this.RoutingControlArn;
            #if MODULAR
            if (this.RoutingControlArn == null && ParameterWasBound(nameof(this.RoutingControlArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingControlArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoutingControlState = this.RoutingControlState;
            #if MODULAR
            if (this.RoutingControlState == null && ParameterWasBound(nameof(this.RoutingControlState)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingControlState which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.SafetyRulesToOverride != null)
            {
                context.SafetyRulesToOverride = new List<System.String>(this.SafetyRulesToOverride);
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
            var request = new Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateRequest();
            
            if (cmdletContext.RoutingControlArn != null)
            {
                request.RoutingControlArn = cmdletContext.RoutingControlArn;
            }
            if (cmdletContext.RoutingControlState != null)
            {
                request.RoutingControlState = cmdletContext.RoutingControlState;
            }
            if (cmdletContext.SafetyRulesToOverride != null)
            {
                request.SafetyRulesToOverride = cmdletContext.SafetyRulesToOverride;
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
        
        private Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse CallAWSServiceOperation(IAmazonRoute53RecoveryCluster client, Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Route53 Recovery Cluster", "UpdateRoutingControlState");
            try
            {
                return client.UpdateRoutingControlStateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RoutingControlArn { get; set; }
            public Amazon.Route53RecoveryCluster.RoutingControlState RoutingControlState { get; set; }
            public List<System.String> SafetyRulesToOverride { get; set; }
            public System.Func<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse, UpdateRRCRoutingControlStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
