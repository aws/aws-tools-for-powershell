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
using Amazon.Route53RecoveryControlConfig;
using Amazon.Route53RecoveryControlConfig.Model;

namespace Amazon.PowerShell.Cmdlets.R53RC
{
    /// <summary>
    /// Creates a new routing control.
    /// 
    ///  
    /// <para>
    /// A routing control has one of two states: ON and OFF. You can map the routing control
    /// state to the state of an Amazon Route 53 health check, which can be used to control
    /// traffic routing.
    /// </para><para>
    /// To get or update the routing control state, see the Recovery Cluster (data plane)
    /// API actions for Amazon Route 53 Application Recovery Controller.
    /// </para>
    /// </summary>
    [Cmdlet("New", "R53RCRoutingControl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Route53RecoveryControlConfig.Model.RoutingControl")]
    [AWSCmdlet("Calls the AWS Route53 Recovery Control Config CreateRoutingControl API operation.", Operation = new[] {"CreateRoutingControl"}, SelectReturnType = typeof(Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse))]
    [AWSCmdletOutput("Amazon.Route53RecoveryControlConfig.Model.RoutingControl or Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse",
        "This cmdlet returns an Amazon.Route53RecoveryControlConfig.Model.RoutingControl object.",
        "The service call response (type Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewR53RCRoutingControlCmdlet : AmazonRoute53RecoveryControlConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the cluster that includes the routing control.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter ControlPanelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the control panel that includes the routing control.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ControlPanelArn { get; set; }
        #endregion
        
        #region Parameter RoutingControlName
        /// <summary>
        /// <para>
        /// <para>The name of the routing control.</para>
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
        public System.String RoutingControlName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string of up to 64 ASCII characters. To make an idempotent
        /// API request with an action, specify a client token in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RoutingControl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse).
        /// Specifying the name of a property of type Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RoutingControl";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RoutingControlName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-R53RCRoutingControl (CreateRoutingControl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse, NewR53RCRoutingControlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ControlPanelArn = this.ControlPanelArn;
            context.RoutingControlName = this.RoutingControlName;
            #if MODULAR
            if (this.RoutingControlName == null && ParameterWasBound(nameof(this.RoutingControlName)))
            {
                WriteWarning("You are passing $null as a value for parameter RoutingControlName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.ControlPanelArn != null)
            {
                request.ControlPanelArn = cmdletContext.ControlPanelArn;
            }
            if (cmdletContext.RoutingControlName != null)
            {
                request.RoutingControlName = cmdletContext.RoutingControlName;
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
        
        private Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse CallAWSServiceOperation(IAmazonRoute53RecoveryControlConfig client, Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Route53 Recovery Control Config", "CreateRoutingControl");
            try
            {
                return client.CreateRoutingControlAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ClusterArn { get; set; }
            public System.String ControlPanelArn { get; set; }
            public System.String RoutingControlName { get; set; }
            public System.Func<Amazon.Route53RecoveryControlConfig.Model.CreateRoutingControlResponse, NewR53RCRoutingControlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RoutingControl;
        }
        
    }
}
