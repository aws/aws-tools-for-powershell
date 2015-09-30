/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modifies the specified Spot fleet request.
    /// 
    ///  
    /// <para>
    /// While the Spot fleet request is being modified, it is in the <code>modifying</code>
    /// state.
    /// </para><para>
    /// To scale up your Spot fleet, increase its target capacity. The Spot fleet launches
    /// the additional Spot instances according to the allocation strategy for the Spot fleet
    /// request. If the allocation strategy is <code>lowestPrice</code>, the Spot fleet launches
    /// instances using the Spot pool with the lowest price. If the allocation strategy is
    /// <code>diversified</code>, the Spot fleet distributes the instances across the Spot
    /// pools.
    /// </para><para>
    /// To scale down your Spot fleet, decrease its target capacity. First, the Spot fleet
    /// cancels any open bids that exceed the new target capacity. You can request that the
    /// Spot fleet terminate Spot instances until the size of the fleet no longer exceeds
    /// the new target capacity. If the allocation strategy is <code>lowestPrice</code>, the
    /// Spot fleet terminates the instances with the highest price per unit. If the allocation
    /// strategy is <code>diversified</code>, the Spot fleet terminates instances across the
    /// Spot pools. Alternatively, you can request that the Spot fleet keep the fleet at its
    /// current size, but not replace any Spot instances that are interrupted or that you
    /// terminate manually.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Invokes the ModifySpotFleetRequest operation against Amazon Elastic Compute Cloud.", Operation = new[] {"ModifySpotFleetRequest"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type ModifySpotFleetRequestResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class EditEC2SpotFleetRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Indicates whether running Spot instances should be terminated if the target capacity
        /// of the Spot fleet request is decreased below the current size of the Spot fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public ExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The size of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 TargetCapacity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the Spot fleet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String SpotFleetRequestId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SpotFleetRequestId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2SpotFleetRequest (ModifySpotFleetRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            context.SpotFleetRequestId = this.SpotFleetRequestId;
            if (ParameterWasBound("TargetCapacity"))
                context.TargetCapacity = this.TargetCapacity;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new ModifySpotFleetRequestRequest();
            
            if (cmdletContext.ExcessCapacityTerminationPolicy != null)
            {
                request.ExcessCapacityTerminationPolicy = cmdletContext.ExcessCapacityTerminationPolicy;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ModifySpotFleetRequest(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Return;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public ExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
            public String SpotFleetRequestId { get; set; }
            public Int32? TargetCapacity { get; set; }
        }
        
    }
}
