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
    /// Set the state of the routing control to reroute traffic. You can set the value to
    /// be On or Off. When the state is On, traffic flows to a cell. When it's off, traffic
    /// does not flow.
    /// 
    ///  
    /// <para>
    /// For more information about working with routing controls, see <a href="https://docs.aws.amazon.com/r53recovery/latest/dg/routing-control.html">Routing
    /// control</a> in the Route 53 Application Recovery Controller Developer Guide.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "RRCRoutingControlState", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Route53 Recovery Cluster UpdateRoutingControlState API operation.", Operation = new[] {"UpdateRoutingControlState"}, SelectReturnType = typeof(Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse))]
    [AWSCmdletOutput("None or Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRRCRoutingControlStateCmdlet : AmazonRoute53RecoveryClusterClientCmdlet, IExecutor
    {
        
        #region Parameter RoutingControlArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) for the routing control that you want to update the
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
        /// <para>The state of the routing control. You can set the value to be On or Off.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RoutingControlArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RoutingControlArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RoutingControlArn' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoutingControlArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RRCRoutingControlState (UpdateRoutingControlState)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse, UpdateRRCRoutingControlStateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RoutingControlArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
                #if DESKTOP
                return client.UpdateRoutingControlState(request);
                #elif CORECLR
                return client.UpdateRoutingControlStateAsync(request).GetAwaiter().GetResult();
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
            public System.String RoutingControlArn { get; set; }
            public Amazon.Route53RecoveryCluster.RoutingControlState RoutingControlState { get; set; }
            public System.Func<Amazon.Route53RecoveryCluster.Model.UpdateRoutingControlStateResponse, UpdateRRCRoutingControlStateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
