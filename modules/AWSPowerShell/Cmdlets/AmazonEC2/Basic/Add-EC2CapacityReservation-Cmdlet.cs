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
    /// Creates a new Capacity Reservation with the specified attributes.
    /// 
    ///  
    /// <para>
    /// Capacity Reservations enable you to reserve capacity for your Amazon EC2 instances
    /// in a specific Availability Zone for any duration. This gives you the flexibility to
    /// selectively add capacity reservations and still get the Regional RI discounts for
    /// that usage. By creating Capacity Reservations, you ensure that you always have access
    /// to Amazon EC2 capacity when you need it, for as long as you need it. For more information,
    /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-capacity-reservations.html">Capacity
    /// Reservations</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para><para>
    /// Your request to create a Capacity Reservation could fail if Amazon EC2 does not have
    /// sufficient capacity to fulfill the request. If your request fails due to Amazon EC2
    /// capacity constraints, either try again at a later time, try in a different Availability
    /// Zone, or request a smaller capacity reservation. If your application is flexible across
    /// instance types and sizes, try to create a Capacity Reservation with different instance
    /// attributes.
    /// </para><para>
    /// Your request could also fail if the requested quantity exceeds your On-Demand Instance
    /// limit for the selected instance type. If your request fails due to limit constraints,
    /// increase your On-Demand Instance limit for the required instance type and try again.
    /// For more information about increasing your instance limits, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">Amazon
    /// EC2 Service Limits</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "EC2CapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CapacityReservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud CreateCapacityReservation API operation.", Operation = new[] {"CreateCapacityReservation"})]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityReservation",
        "This cmdlet returns a CapacityReservation object.",
        "The service call response (type Amazon.EC2.Model.CreateCapacityReservationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddEC2CapacityReservationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">How
        /// to Ensure Idempotency</a>.</para><para>Constraint: Maximum 64 ASCII characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter EbsOptimized
        /// <summary>
        /// <para>
        /// <para>Indicates whether the Capacity Reservation supports EBS-optimized instances. This
        /// optimization provides dedicated throughput to Amazon EBS and an optimized configuration
        /// stack to provide optimal I/O performance. This optimization isn't available with all
        /// instance types. Additional usage charges apply when using an EBS- optimized instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EbsOptimized { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation expires. When a Capacity Reservation
        /// expires, the reserved capacity is released and you can no longer launch instances
        /// into it. The Capacity Reservation's state changes to <code>expired</code> when it
        /// reaches its end date and time.</para><para>You must provide an <code>EndDate</code> value if <code>EndDateType</code> is <code>limited</code>.
        /// Omit <code>EndDate</code> if <code>EndDateType</code> is <code>unlimited</code>.</para><para>If the <code>EndDateType</code> is <code>limited</code>, the Capacity Reservation
        /// is cancelled within an hour from the specified time. For example, if you specify 5/31/2019,
        /// 13:30:55, the Capacity Reservation is guaranteed to end between 13:30:55 and 14:30:55
        /// on 5/31/2019.</para>
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
        /// cancel it. Do not provide an <code>EndDate</code> if the <code>EndDateType</code>
        /// is <code>unlimited</code>.</para></li><li><para><code>limited</code> - The Capacity Reservation expires automatically at a specified
        /// date and time. You must provide an <code>EndDate</code> value if the <code>EndDateType</code>
        /// value is <code>limited</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.EndDateType")]
        public Amazon.EC2.EndDateType EndDateType { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage
        /// <summary>
        /// <para>
        /// <para>Indicates whether the Capacity Reservation supports instances with temporary, block-level
        /// storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EphemeralStorage { get; set; }
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
        
        #region Parameter InstanceMatchCriterion
        /// <summary>
        /// <para>
        /// <para>Indicates the type of instance launches that the Capacity Reservation accepts. The
        /// options include:</para><ul><li><para><code>open</code> - The Capacity Reservation automatically matches all instances
        /// that have matching attributes (instance type, platform, and Availability Zone). Instances
        /// that have matching attributes run in the Capacity Reservation automatically without
        /// specifying any additional parameters.</para></li><li><para><code>targeted</code> - The Capacity Reservation only accepts instances that have
        /// matching attributes (instance type, platform, and Availability Zone), and explicitly
        /// target the Capacity Reservation. This ensures that only permitted instances can use
        /// the reserved capacity. </para></li></ul><para>Default: <code>open</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("InstanceMatchCriteria")]
        [AWSConstantClassSource("Amazon.EC2.InstanceMatchCriteria")]
        public Amazon.EC2.InstanceMatchCriteria InstanceMatchCriterion { get; set; }
        #endregion
        
        #region Parameter InstancePlatform
        /// <summary>
        /// <para>
        /// <para>The type of operating system for which to reserve capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationInstancePlatform")]
        public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for which to reserve capacity. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Capacity Reservation during launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>Indicates the tenancy of the Capacity Reservation. A Capacity Reservation can have
        /// one of the following tenancy settings:</para><ul><li><para><code>default</code> - The Capacity Reservation is created on hardware that is shared
        /// with other AWS accounts.</para></li><li><para><code>dedicated</code> - The Capacity Reservation is created on single-tenant hardware
        /// that is dedicated to a single AWS account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationTenancy")]
        public Amazon.EC2.CapacityReservationTenancy Tenancy { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceType", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EC2CapacityReservation (CreateCapacityReservation)"))
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
            
            context.AvailabilityZone = this.AvailabilityZone;
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("EbsOptimized"))
                context.EbsOptimized = this.EbsOptimized;
            if (ParameterWasBound("EndDate"))
                context.EndDate = this.EndDate;
            context.EndDateType = this.EndDateType;
            if (ParameterWasBound("EphemeralStorage"))
                context.EphemeralStorage = this.EphemeralStorage;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            context.InstanceMatchCriteria = this.InstanceMatchCriterion;
            context.InstancePlatform = this.InstancePlatform;
            context.InstanceType = this.InstanceType;
            if (this.TagSpecification != null)
            {
                context.TagSpecifications = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Tenancy = this.Tenancy;
            
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
            var request = new Amazon.EC2.Model.CreateCapacityReservationRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EbsOptimized != null)
            {
                request.EbsOptimized = cmdletContext.EbsOptimized.Value;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.EndDateType != null)
            {
                request.EndDateType = cmdletContext.EndDateType;
            }
            if (cmdletContext.EphemeralStorage != null)
            {
                request.EphemeralStorage = cmdletContext.EphemeralStorage.Value;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.InstanceMatchCriteria != null)
            {
                request.InstanceMatchCriteria = cmdletContext.InstanceMatchCriteria;
            }
            if (cmdletContext.InstancePlatform != null)
            {
                request.InstancePlatform = cmdletContext.InstancePlatform;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.TagSpecifications != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecifications;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.CapacityReservation;
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
        
        private Amazon.EC2.Model.CreateCapacityReservationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateCapacityReservation");
            try
            {
                #if DESKTOP
                return client.CreateCapacityReservation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateCapacityReservationAsync(request);
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
            public System.String AvailabilityZone { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.EndDateType EndDateType { get; set; }
            public System.Boolean? EphemeralStorage { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public Amazon.EC2.InstanceMatchCriteria InstanceMatchCriteria { get; set; }
            public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
            public System.String InstanceType { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecifications { get; set; }
            public Amazon.EC2.CapacityReservationTenancy Tenancy { get; set; }
        }
        
    }
}
