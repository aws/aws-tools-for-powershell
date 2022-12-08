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
using Amazon.Route53RecoveryCluster;
using Amazon.Route53RecoveryCluster.Model;

namespace Amazon.PowerShell.Cmdlets.RRC
{
    /// <summary>
    /// Set multiple routing control states. You can set the value for each state to be On
    /// or Off. When the state is On, traffic flows to a cell. When it's Off, traffic does
    /// not flow.
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
    /// The <code>SafetyRulesToOverride</code> property enables you override one or more safety
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
    [Cmdlet("Update", "RRCRoutingControlStateBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Route53 Recovery Cluster UpdateRoutingControlStates API operation.", Operation = new[] {"UpdateRoutingControlStates"}, SelectReturnType = typeof(Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse))]
    [AWSCmdletOutput("None or Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRRCRoutingControlStateBatchCmdlet : AmazonRoute53RecoveryClusterClientCmdlet, IExecutor
    {
        
        #region Parameter SafetyRulesToOverride
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) for the safety rules that you want to override when
        /// you're updating routing control states. You can override one safety rule or multiple
        /// safety rules by including one or more ARNs, separated by commas.</para><para>For more information, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.override-safety-rule.html">
        /// Override safety rules to reroute traffic</a> in the Amazon Route 53 Application Recovery
        /// Controller Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] SafetyRulesToOverride { get; set; }
        #endregion
        
        #region Parameter UpdateRoutingControlStateEntry
        /// <summary>
        /// <para>
        /// <para>A set of routing control entries that you want to update.</para>
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
        [Alias("UpdateRoutingControlStateEntries")]
        public Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry[] UpdateRoutingControlStateEntry { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateRoutingControlStateEntry), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RRCRoutingControlStateBatch (UpdateRoutingControlStates)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse, UpdateRRCRoutingControlStateBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.SafetyRulesToOverride != null)
            {
                context.SafetyRulesToOverride = new List<System.String>(this.SafetyRulesToOverride);
            }
            if (this.UpdateRoutingControlStateEntry != null)
            {
                context.UpdateRoutingControlStateEntry = new List<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry>(this.UpdateRoutingControlStateEntry);
            }
            #if MODULAR
            if (this.UpdateRoutingControlStateEntry == null && ParameterWasBound(nameof(this.UpdateRoutingControlStateEntry)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateRoutingControlStateEntry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesRequest();
            
            if (cmdletContext.SafetyRulesToOverride != null)
            {
                request.SafetyRulesToOverride = cmdletContext.SafetyRulesToOverride;
            }
            if (cmdletContext.UpdateRoutingControlStateEntry != null)
            {
                request.UpdateRoutingControlStateEntries = cmdletContext.UpdateRoutingControlStateEntry;
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
        
        private Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse CallAWSServiceOperation(IAmazonRoute53RecoveryCluster client, Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Route53 Recovery Cluster", "UpdateRoutingControlStates");
            try
            {
                #if DESKTOP
                return client.UpdateRoutingControlStates(request);
                #elif CORECLR
                return client.UpdateRoutingControlStatesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SafetyRulesToOverride { get; set; }
            public List<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateEntry> UpdateRoutingControlStateEntry { get; set; }
            public System.Func<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStatesResponse, UpdateRRCRoutingControlStateBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
