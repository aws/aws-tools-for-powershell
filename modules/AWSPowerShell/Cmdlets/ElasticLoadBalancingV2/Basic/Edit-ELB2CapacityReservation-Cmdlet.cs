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
using Amazon.ElasticLoadBalancingV2;
using Amazon.ElasticLoadBalancingV2.Model;

namespace Amazon.PowerShell.Cmdlets.ELB2
{
    /// <summary>
    /// Modifies the capacity reservation of the specified load balancer.
    /// 
    ///  
    /// <para>
    /// When modifying capacity reservation, you must include at least one <c>MinimumLoadBalancerCapacity</c>
    /// or <c>ResetCapacityReservation</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "ELB2CapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse")]
    [AWSCmdlet("Calls the Elastic Load Balancing V2 ModifyCapacityReservation API operation.", Operation = new[] {"ModifyCapacityReservation"}, SelectReturnType = typeof(Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse))]
    [AWSCmdletOutput("Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse",
        "This cmdlet returns an Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse object containing multiple properties."
    )]
    public partial class EditELB2CapacityReservationCmdlet : AmazonElasticLoadBalancingV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MinimumLoadBalancerCapacity_CapacityUnit
        /// <summary>
        /// <para>
        /// <para>The number of capacity units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinimumLoadBalancerCapacity_CapacityUnits")]
        public System.Int32? MinimumLoadBalancerCapacity_CapacityUnit { get; set; }
        #endregion
        
        #region Parameter LoadBalancerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the load balancer.</para>
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
        public System.String LoadBalancerArn { get; set; }
        #endregion
        
        #region Parameter ResetCapacityReservation
        /// <summary>
        /// <para>
        /// <para>Resets the capacity reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ResetCapacityReservation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LoadBalancerArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LoadBalancerArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LoadBalancerArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LoadBalancerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-ELB2CapacityReservation (ModifyCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse, EditELB2CapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LoadBalancerArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LoadBalancerArn = this.LoadBalancerArn;
            #if MODULAR
            if (this.LoadBalancerArn == null && ParameterWasBound(nameof(this.LoadBalancerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LoadBalancerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinimumLoadBalancerCapacity_CapacityUnit = this.MinimumLoadBalancerCapacity_CapacityUnit;
            context.ResetCapacityReservation = this.ResetCapacityReservation;
            
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
            var request = new Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationRequest();
            
            if (cmdletContext.LoadBalancerArn != null)
            {
                request.LoadBalancerArn = cmdletContext.LoadBalancerArn;
            }
            
             // populate MinimumLoadBalancerCapacity
            var requestMinimumLoadBalancerCapacityIsNull = true;
            request.MinimumLoadBalancerCapacity = new Amazon.ElasticLoadBalancingV2.Model.MinimumLoadBalancerCapacity();
            System.Int32? requestMinimumLoadBalancerCapacity_minimumLoadBalancerCapacity_CapacityUnit = null;
            if (cmdletContext.MinimumLoadBalancerCapacity_CapacityUnit != null)
            {
                requestMinimumLoadBalancerCapacity_minimumLoadBalancerCapacity_CapacityUnit = cmdletContext.MinimumLoadBalancerCapacity_CapacityUnit.Value;
            }
            if (requestMinimumLoadBalancerCapacity_minimumLoadBalancerCapacity_CapacityUnit != null)
            {
                request.MinimumLoadBalancerCapacity.CapacityUnits = requestMinimumLoadBalancerCapacity_minimumLoadBalancerCapacity_CapacityUnit.Value;
                requestMinimumLoadBalancerCapacityIsNull = false;
            }
             // determine if request.MinimumLoadBalancerCapacity should be set to null
            if (requestMinimumLoadBalancerCapacityIsNull)
            {
                request.MinimumLoadBalancerCapacity = null;
            }
            if (cmdletContext.ResetCapacityReservation != null)
            {
                request.ResetCapacityReservation = cmdletContext.ResetCapacityReservation.Value;
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
        
        private Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse CallAWSServiceOperation(IAmazonElasticLoadBalancingV2 client, Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Elastic Load Balancing V2", "ModifyCapacityReservation");
            try
            {
                #if DESKTOP
                return client.ModifyCapacityReservation(request);
                #elif CORECLR
                return client.ModifyCapacityReservationAsync(request).GetAwaiter().GetResult();
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
            public System.String LoadBalancerArn { get; set; }
            public System.Int32? MinimumLoadBalancerCapacity_CapacityUnit { get; set; }
            public System.Boolean? ResetCapacityReservation { get; set; }
            public System.Func<Amazon.ElasticLoadBalancingV2.Model.ModifyCapacityReservationResponse, EditELB2CapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
