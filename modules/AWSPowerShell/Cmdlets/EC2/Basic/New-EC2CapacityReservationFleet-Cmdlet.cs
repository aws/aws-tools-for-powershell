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
    /// Creates a Capacity Reservation Fleet. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/work-with-cr-fleets.html#create-crfleet">Create
    /// a Capacity Reservation Fleet</a> in the <i>Amazon EC2 User Guide</i>.
    /// </summary>
    [Cmdlet("New", "EC2CapacityReservationFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CreateCapacityReservationFleetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateCapacityReservationFleet API operation.", Operation = new[] {"CreateCapacityReservationFleet"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateCapacityReservationFleetResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CreateCapacityReservationFleetResponse",
        "This cmdlet returns an Amazon.EC2.Model.CreateCapacityReservationFleetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2CapacityReservationFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllocationStrategy
        /// <summary>
        /// <para>
        /// <para>The strategy used by the Capacity Reservation Fleet to determine which of the specified
        /// instance types to use. Currently, only the <c>prioritized</c> allocation strategy
        /// is supported. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/crfleet-concepts.html#allocation-strategy">
        /// Allocation strategy</a> in the <i>Amazon EC2 User Guide</i>.</para><para>Valid values: <c>prioritized</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AllocationStrategy { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation Fleet expires. When the Capacity
        /// Reservation Fleet expires, its state changes to <c>expired</c> and all of the Capacity
        /// Reservations in the Fleet expire.</para><para>The Capacity Reservation Fleet expires within an hour after the specified time. For
        /// example, if you specify <c>5/31/2019</c>, <c>13:30:55</c>, the Capacity Reservation
        /// Fleet is guaranteed to expire between <c>13:30:55</c> and <c>14:30:55</c> on <c>5/31/2019</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter InstanceMatchCriterion
        /// <summary>
        /// <para>
        /// <para>Indicates the type of instance launches that the Capacity Reservation Fleet accepts.
        /// All Capacity Reservations in the Fleet inherit this instance matching criteria.</para><para>Currently, Capacity Reservation Fleets support <c>open</c> instance matching criteria
        /// only. This means that instances that have matching attributes (instance type, platform,
        /// and Availability Zone) run in the Capacity Reservations automatically. Instances do
        /// not need to explicitly target a Capacity Reservation Fleet to use its reserved capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceMatchCriteria")]
        [AWSConstantClassSource("Amazon.EC2.FleetInstanceMatchCriteria")]
        public Amazon.EC2.FleetInstanceMatchCriteria InstanceMatchCriterion { get; set; }
        #endregion
        
        #region Parameter InstanceTypeSpecification
        /// <summary>
        /// <para>
        /// <para>Information about the instance types for which to reserve the capacity.</para>
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
        [Alias("InstanceTypeSpecifications")]
        public Amazon.EC2.Model.ReservationFleetInstanceSpecification[] InstanceTypeSpecification { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the Capacity Reservation Fleet. The tags are automatically assigned
        /// to the Capacity Reservations in the Fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>Indicates the tenancy of the Capacity Reservation Fleet. All Capacity Reservations
        /// in the Fleet inherit this tenancy. The Capacity Reservation Fleet can have one of
        /// the following tenancy settings:</para><ul><li><para><c>default</c> - The Capacity Reservation Fleet is created on hardware that is shared
        /// with other Amazon Web Services accounts.</para></li><li><para><c>dedicated</c> - The Capacity Reservations are created on single-tenant hardware
        /// that is dedicated to a single Amazon Web Services account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.FleetCapacityReservationTenancy")]
        public Amazon.EC2.FleetCapacityReservationTenancy Tenancy { get; set; }
        #endregion
        
        #region Parameter TotalTargetCapacity
        /// <summary>
        /// <para>
        /// <para>The total number of capacity units to be reserved by the Capacity Reservation Fleet.
        /// This value, together with the instance type weights that you assign to each instance
        /// type used by the Fleet determine the number of instances for which the Fleet reserves
        /// capacity. Both values are based on units that make sense for your workload. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/crfleet-concepts.html#target-capacity">Total
        /// target capacity</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensure
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateCapacityReservationFleetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateCapacityReservationFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TotalTargetCapacity parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TotalTargetCapacity' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TotalTargetCapacity' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TotalTargetCapacity), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2CapacityReservationFleet (CreateCapacityReservationFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateCapacityReservationFleetResponse, NewEC2CapacityReservationFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TotalTargetCapacity;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllocationStrategy = this.AllocationStrategy;
            context.ClientToken = this.ClientToken;
            context.EndDate = this.EndDate;
            context.InstanceMatchCriterion = this.InstanceMatchCriterion;
            if (this.InstanceTypeSpecification != null)
            {
                context.InstanceTypeSpecification = new List<Amazon.EC2.Model.ReservationFleetInstanceSpecification>(this.InstanceTypeSpecification);
            }
            #if MODULAR
            if (this.InstanceTypeSpecification == null && ParameterWasBound(nameof(this.InstanceTypeSpecification)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceTypeSpecification which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.Tenancy = this.Tenancy;
            context.TotalTargetCapacity = this.TotalTargetCapacity;
            #if MODULAR
            if (this.TotalTargetCapacity == null && ParameterWasBound(nameof(this.TotalTargetCapacity)))
            {
                WriteWarning("You are passing $null as a value for parameter TotalTargetCapacity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CreateCapacityReservationFleetRequest();
            
            if (cmdletContext.AllocationStrategy != null)
            {
                request.AllocationStrategy = cmdletContext.AllocationStrategy;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.InstanceMatchCriterion != null)
            {
                request.InstanceMatchCriteria = cmdletContext.InstanceMatchCriterion;
            }
            if (cmdletContext.InstanceTypeSpecification != null)
            {
                request.InstanceTypeSpecifications = cmdletContext.InstanceTypeSpecification;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
            }
            if (cmdletContext.TotalTargetCapacity != null)
            {
                request.TotalTargetCapacity = cmdletContext.TotalTargetCapacity.Value;
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
        
        private Amazon.EC2.Model.CreateCapacityReservationFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateCapacityReservationFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateCapacityReservationFleet");
            try
            {
                #if DESKTOP
                return client.CreateCapacityReservationFleet(request);
                #elif CORECLR
                return client.CreateCapacityReservationFleetAsync(request).GetAwaiter().GetResult();
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
            public System.String AllocationStrategy { get; set; }
            public System.String ClientToken { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.FleetInstanceMatchCriteria InstanceMatchCriterion { get; set; }
            public List<Amazon.EC2.Model.ReservationFleetInstanceSpecification> InstanceTypeSpecification { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.FleetCapacityReservationTenancy Tenancy { get; set; }
            public System.Int32? TotalTargetCapacity { get; set; }
            public System.Func<Amazon.EC2.Model.CreateCapacityReservationFleetResponse, NewEC2CapacityReservationFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
