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
    /// Modifies a Capacity Reservation's capacity and the conditions under which it is to
    /// be released. You cannot change a Capacity Reservation's instance type, EBS optimization,
    /// instance store settings, platform, Availability Zone, or instance eligibility. If
    /// you need to modify any of these attributes, we recommend that you cancel the Capacity
    /// Reservation, and then create a new one with the required attributes.
    /// </summary>
    [Cmdlet("Edit", "EC2CapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud ModifyCapacityReservation API operation.", Operation = new[] {"ModifyCapacityReservation"})]
    [AWSCmdletOutput("System.Boolean",
        "This cmdlet returns a Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyCapacityReservationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2CapacityReservationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation expires. When a Capacity Reservation
        /// expires, the reserved capacity is released and you can no longer launch instances
        /// into it. The Capacity Reservation's state changes to <code>expired</code> when it
        /// reaches its end date and time.</para><para>The Capacity Reservation is cancelled within an hour from the specified time. For
        /// example, if you specify 5/31/2019, 13:30:55, the Capacity Reservation is guaranteed
        /// to end between 13:30:55 and 14:30:55 on 5/31/2019.</para><para>You must provide an <code>EndDate</code> value if <code>EndDateType</code> is <code>limited</code>.
        /// Omit <code>EndDate</code> if <code>EndDateType</code> is <code>unlimited</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime EndDate { get; set; }
        #endregion
        
        #region Parameter EndDateType
        /// <summary>
        /// <para>
        /// <para>Indicates the way in which the Capacity Reservation ends. A Capacity Reservation can
        /// have one of the following end types:</para><ul><li><para><code>unlimited</code> - The Capacity Reservation remains active until you explicitly
        /// cancel it. Do not provide an <code>EndDate</code> value if <code>EndDateType</code>
        /// is <code>unlimited</code>.</para></li><li><para><code>limited</code> - The Capacity Reservation expires automatically at a specified
        /// date and time. You must provide an <code>EndDate</code> value if <code>EndDateType</code>
        /// is <code>limited</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.EndDateType")]
        public Amazon.EC2.EndDateType EndDateType { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances for which to reserve capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 InstanceCount { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("CapacityReservationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2CapacityReservation (ModifyCapacityReservation)"))
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
            
            context.CapacityReservationId = this.CapacityReservationId;
            if (ParameterWasBound("EndDate"))
                context.EndDate = this.EndDate;
            context.EndDateType = this.EndDateType;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            
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
            var request = new Amazon.EC2.Model.ModifyCapacityReservationRequest();
            
            if (cmdletContext.CapacityReservationId != null)
            {
                request.CapacityReservationId = cmdletContext.CapacityReservationId;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.EndDateType != null)
            {
                request.EndDateType = cmdletContext.EndDateType;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
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
        
        private Amazon.EC2.Model.ModifyCapacityReservationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "ModifyCapacityReservation");
            try
            {
                #if DESKTOP
                return client.ModifyCapacityReservation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyCapacityReservationAsync(request);
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
            public System.String CapacityReservationId { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.EndDateType EndDateType { get; set; }
            public System.Int32? InstanceCount { get; set; }
        }
        
    }
}
