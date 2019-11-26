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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified Spot Fleet request.
    /// 
    ///  
    /// <para>
    /// You can only modify a Spot Fleet request of type <code>maintain</code>.
    /// </para><para>
    /// While the Spot Fleet request is being modified, it is in the <code>modifying</code>
    /// state.
    /// </para><para>
    /// To scale up your Spot Fleet, increase its target capacity. The Spot Fleet launches
    /// the additional Spot Instances according to the allocation strategy for the Spot Fleet
    /// request. If the allocation strategy is <code>lowestPrice</code>, the Spot Fleet launches
    /// instances using the Spot Instance pool with the lowest price. If the allocation strategy
    /// is <code>diversified</code>, the Spot Fleet distributes the instances across the Spot
    /// Instance pools. If the allocation strategy is <code>capacityOptimized</code>, Spot
    /// Fleet launches instances from Spot Instance pools with optimal capacity for the number
    /// of instances that are launching.
    /// </para><para>
    /// To scale down your Spot Fleet, decrease its target capacity. First, the Spot Fleet
    /// cancels any open requests that exceed the new target capacity. You can request that
    /// the Spot Fleet terminate Spot Instances until the size of the fleet no longer exceeds
    /// the new target capacity. If the allocation strategy is <code>lowestPrice</code>, the
    /// Spot Fleet terminates the instances with the highest price per unit. If the allocation
    /// strategy is <code>capacityOptimized</code>, the Spot Fleet terminates the instances
    /// in the Spot Instance pools that have the least available Spot Instance capacity. If
    /// the allocation strategy is <code>diversified</code>, the Spot Fleet terminates instances
    /// across the Spot Instance pools. Alternatively, you can request that the Spot Fleet
    /// keep the fleet at its current size, but not replace any Spot Instances that are interrupted
    /// or that you terminate manually.
    /// </para><para>
    /// If you are finished with your Spot Fleet for now, but will use it again later, you
    /// can set the target capacity to 0.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifySpotFleetRequest API operation.", Operation = new[] {"ModifySpotFleetRequest"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifySpotFleetRequestResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifySpotFleetRequestResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifySpotFleetRequestResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2SpotFleetRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ExcessCapacityTerminationPolicy
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot Instances should be terminated if the target capacity
        /// of the Spot Fleet request is decreased below the current size of the Spot Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ExcessCapacityTerminationPolicy")]
        public Amazon.EC2.ExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter OnDemandTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The number of On-Demand Instances in the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? OnDemandTargetCapacity { get; set; }
        #endregion
        
        #region Parameter TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The size of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TargetCapacity { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the Spot Fleet request.</para>
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
        public System.String SpotFleetRequestId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifySpotFleetRequestResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifySpotFleetRequestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SpotFleetRequestId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SpotFleetRequestId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SpotFleetRequestId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpotFleetRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2SpotFleetRequest (ModifySpotFleetRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifySpotFleetRequestResponse, EditEC2SpotFleetRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SpotFleetRequestId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            context.OnDemandTargetCapacity = this.OnDemandTargetCapacity;
            context.SpotFleetRequestId = this.SpotFleetRequestId;
            #if MODULAR
            if (this.SpotFleetRequestId == null && ParameterWasBound(nameof(this.SpotFleetRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpotFleetRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetCapacity = this.TargetCapacity;
            
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
            var request = new Amazon.EC2.Model.ModifySpotFleetRequestRequest();
            
            if (cmdletContext.ExcessCapacityTerminationPolicy != null)
            {
                request.ExcessCapacityTerminationPolicy = cmdletContext.ExcessCapacityTerminationPolicy;
            }
            if (cmdletContext.OnDemandTargetCapacity != null)
            {
                request.OnDemandTargetCapacity = cmdletContext.OnDemandTargetCapacity.Value;
            }
            if (cmdletContext.SpotFleetRequestId != null)
            {
                request.SpotFleetRequestId = cmdletContext.SpotFleetRequestId;
            }
            if (cmdletContext.TargetCapacity != null)
            {
                request.TargetCapacity = cmdletContext.TargetCapacity.Value;
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
        
        private Amazon.EC2.Model.ModifySpotFleetRequestResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifySpotFleetRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifySpotFleetRequest");
            try
            {
                #if DESKTOP
                return client.ModifySpotFleetRequest(request);
                #elif CORECLR
                return client.ModifySpotFleetRequestAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EC2.ExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
            public System.Int32? OnDemandTargetCapacity { get; set; }
            public System.String SpotFleetRequestId { get; set; }
            public System.Int32? TargetCapacity { get; set; }
            public System.Func<Amazon.EC2.Model.ModifySpotFleetRequestResponse, EditEC2SpotFleetRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
