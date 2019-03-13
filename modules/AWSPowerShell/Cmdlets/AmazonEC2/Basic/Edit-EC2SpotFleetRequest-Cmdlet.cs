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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies the specified Spot Fleet request.
    /// 
    ///  
    /// <para>
    /// While the Spot Fleet request is being modified, it is in the <code>modifying</code>
    /// state.
    /// </para><para>
    /// To scale up your Spot Fleet, increase its target capacity. The Spot Fleet launches
    /// the additional Spot Instances according to the allocation strategy for the Spot Fleet
    /// request. If the allocation strategy is <code>lowestPrice</code>, the Spot Fleet launches
    /// instances using the Spot pool with the lowest price. If the allocation strategy is
    /// <code>diversified</code>, the Spot Fleet distributes the instances across the Spot
    /// pools.
    /// </para><para>
    /// To scale down your Spot Fleet, decrease its target capacity. First, the Spot Fleet
    /// cancels any open requests that exceed the new target capacity. You can request that
    /// the Spot Fleet terminate Spot Instances until the size of the fleet no longer exceeds
    /// the new target capacity. If the allocation strategy is <code>lowestPrice</code>, the
    /// Spot Fleet terminates the instances with the highest price per unit. If the allocation
    /// strategy is <code>diversified</code>, the Spot Fleet terminates instances across the
    /// Spot pools. Alternatively, you can request that the Spot Fleet keep the fleet at its
    /// current size, but not replace any Spot Instances that are interrupted or that you
    /// terminate manually.
    /// </para><para>
    /// If you are finished with your Spot Fleet for now, but will use it again later, you
    /// can set the target capacity to 0.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifySpotFleetRequest API operation.", Operation = new[] {"ModifySpotFleetRequest"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
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
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.ExcessCapacityTerminationPolicy")]
        public Amazon.EC2.ExcessCapacityTerminationPolicy ExcessCapacityTerminationPolicy { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestId
        /// <summary>
        /// <para>
        /// <para>The ID of the Spot Fleet request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SpotFleetRequestId { get; set; }
        #endregion
        
        #region Parameter TargetCapacity
        /// <summary>
        /// <para>
        /// <para>The size of the fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TargetCapacity { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ExcessCapacityTerminationPolicy = this.ExcessCapacityTerminationPolicy;
            context.SpotFleetRequestId = this.SpotFleetRequestId;
            if (ParameterWasBound("TargetCapacity"))
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.ModifySpotFleetRequestResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifySpotFleetRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifySpotFleetRequest");
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
            public System.String SpotFleetRequestId { get; set; }
            public System.Int32? TargetCapacity { get; set; }
        }
        
    }
}
