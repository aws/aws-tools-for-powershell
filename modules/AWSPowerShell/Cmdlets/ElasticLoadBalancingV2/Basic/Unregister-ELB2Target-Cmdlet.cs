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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Deregisters the specified targets from the specified target group. After the targets
    /// are deregistered, they no longer receive traffic from the load balancer.
    /// 
    ///  
    /// <para>
    /// The load balancer stops sending requests to targets that are deregistering, but uses
    /// connection draining to ensure that in-flight traffic completes on the existing connections.
    /// This deregistration delay is configured by default but can be updated for each target
    /// group.
    /// </para><para>
    /// For more information, see the following:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/application/load-balancer-target-groups.html#deregistration-delay">
    /// Deregistration delay</a> in the <i>Application Load Balancers User Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/network/load-balancer-target-groups.html#deregistration-delay">
    /// Deregistration delay</a> in the <i>Network Load Balancers User Guide</i></para></li><li><para><a href="https://docs.aws.amazon.com/elasticloadbalancing/latest/gateway/target-groups.html#deregistration-delay">
    /// Deregistration delay</a> in the <i>Gateway Load Balancers User Guide</i></para></li></ul><para>
    /// Note: If the specified target does not exist, the action returns successfully.
    /// </para>
    /// </summary>
    [Cmdlet("Unregister", "ELB2Target", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 DeregisterTargets API operation.", Operation = new[] {"DeregisterTargets"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse))]
    [AWSCmdletOutput("None or Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UnregisterELB2TargetCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TargetGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the target group.</para>
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
        public System.String TargetGroupArn { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets. If you specified a port override when you registered a target, you must
        /// specify both the target ID and the port when you deregister it.</para>
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
        [Alias("Targets")]
        public Amazon.ElasticLoadBalancingV2.Model.TargetDescription[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetGroupArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetGroupArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetGroupArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-ELB2Target (DeregisterTargets)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse, UnregisterELB2TargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetGroupArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TargetGroupArn = this.TargetGroupArn;
            #if MODULAR
            if (this.TargetGroupArn == null && ParameterWasBound(nameof(this.TargetGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Target != null)
            {
                context.Target = new List<Amazon.ElasticLoadBalancingV2.Model.TargetDescription>(this.Target);
            }
            #if MODULAR
            if (this.Target == null && ParameterWasBound(nameof(this.Target)))
            {
                WriteWarning("You are passing $null as a value for parameter Target which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsRequest();
            
            if (cmdletContext.TargetGroupArn != null)
            {
                request.TargetGroupArn = cmdletContext.TargetGroupArn;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "DeregisterTargets");
            try
            {
                #if DESKTOP
                return client.DeregisterTargets(request);
                #elif CORECLR
                return client.DeregisterTargetsAsync(request).GetAwaiter().GetResult();
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
            public System.String TargetGroupArn { get; set; }
            public List<Amazon.ElasticLoadBalancingV2.Model.TargetDescription> Target { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.DeregisterTargetsResponse, UnregisterELB2TargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
