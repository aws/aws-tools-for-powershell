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
    /// Modifies the Capacity Reservation settings for a stopped instance. Use this action
    /// to configure an instance to target a specific Capacity Reservation, run in any <code>open</code>
    /// Capacity Reservation with matching attributes, or run On-Demand Instance capacity.
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceCapacityReservationAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyInstanceCapacityReservationAttributes API operation.", Operation = new[] {"ModifyInstanceCapacityReservationAttributes"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2InstanceCapacityReservationAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId")]
        public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Indicates the instance's Capacity Reservation preferences. Possible preferences include:</para><ul><li><para><code>open</code> - The instance can run in any <code>open</code> Capacity Reservation
        /// that has matching attributes (instance type, platform, Availability Zone).</para></li><li><para><code>none</code> - The instance avoids running in a Capacity Reservation even if
        /// one is available. The instance runs as an On-Demand Instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationPreference")]
        public Amazon.EC2.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance to be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceCapacityReservationAttribute (ModifyInstanceCapacityReservationAttributes)"))
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
            
            context.CapacityReservationSpecification_CapacityReservationPreference = this.CapacityReservationSpecification_CapacityReservationPreference;
            context.CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId = this.CapacityReservationTarget_CapacityReservationId;
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesRequest();
            
            
             // populate CapacityReservationSpecification
            bool requestCapacityReservationSpecificationIsNull = true;
            request.CapacityReservationSpecification = new Amazon.EC2.Model.CapacityReservationSpecification();
            Amazon.EC2.CapacityReservationPreference requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = cmdletContext.CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference != null)
            {
                request.CapacityReservationSpecification.CapacityReservationPreference = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference;
                requestCapacityReservationSpecificationIsNull = false;
            }
            Amazon.EC2.Model.CapacityReservationTarget requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            bool requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = new Amazon.EC2.Model.CapacityReservationTarget();
            System.String requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = cmdletContext.CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationId = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
             // determine if requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget should be set to null
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget != null)
            {
                request.CapacityReservationSpecification.CapacityReservationTarget = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget;
                requestCapacityReservationSpecificationIsNull = false;
            }
             // determine if request.CapacityReservationSpecification should be set to null
            if (requestCapacityReservationSpecificationIsNull)
            {
                request.CapacityReservationSpecification = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyInstanceCapacityReservationAttributes");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceCapacityReservationAttributes(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyInstanceCapacityReservationAttributesAsync(request);
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
            public Amazon.EC2.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
            public System.String CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId { get; set; }
            public System.String InstanceId { get; set; }
        }
        
    }
}
