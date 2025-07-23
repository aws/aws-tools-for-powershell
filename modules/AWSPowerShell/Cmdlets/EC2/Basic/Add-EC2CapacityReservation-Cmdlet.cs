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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a new Capacity Reservation with the specified attributes. Capacity Reservations
    /// enable you to reserve capacity for your Amazon EC2 instances in a specific Availability
    /// Zone for any duration.
    /// 
    ///  
    /// <para>
    /// You can create a Capacity Reservation at any time, and you can choose when it starts.
    /// You can create a Capacity Reservation for immediate use or you can request a Capacity
    /// Reservation for a future date.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-capacity-reservations.html">
    /// Reserve compute capacity with On-Demand Capacity Reservations</a> in the <i>Amazon
    /// EC2 User Guide</i>.
    /// </para><para>
    /// Your request to create a Capacity Reservation could fail if:
    /// </para><ul><li><para>
    /// Amazon EC2 does not have sufficient capacity. In this case, try again at a later time,
    /// try in a different Availability Zone, or request a smaller Capacity Reservation. If
    /// your workload is flexible across instance types and sizes, try with different instance
    /// attributes.
    /// </para></li><li><para>
    /// The requested quantity exceeds your On-Demand Instance quota. In this case, increase
    /// your On-Demand Instance quota for the requested instance type and try again. For more
    /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-resource-limits.html">
    /// Amazon EC2 Service Quotas</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Add", "EC2CapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CapacityReservation")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateCapacityReservation API operation.", Operation = new[] {"CreateCapacityReservation"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateCapacityReservationResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CapacityReservation or Amazon.EC2.Model.CreateCapacityReservationResponse",
        "This cmdlet returns an Amazon.EC2.Model.CapacityReservation object.",
        "The service call response (type Amazon.EC2.Model.CreateCapacityReservationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddEC2CapacityReservationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which to create the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone in which to create the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter CommitmentDuration
        /// <summary>
        /// <para>
        /// <note><para>Required for future-dated Capacity Reservations only. To create a Capacity Reservation
        /// for immediate use, omit this parameter. </para></note><para>Specify a commitment duration, in seconds, for the future-dated Capacity Reservation.</para><para>The commitment duration is a minimum duration for which you commit to having the future-dated
        /// Capacity Reservation in the <c>active</c> state in your account after it has been
        /// delivered.</para><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/cr-concepts.html#cr-commitment-duration">
        /// Commitment duration</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? CommitmentDuration { get; set; }
        #endregion
        
        #region Parameter DeliveryPreference
        /// <summary>
        /// <para>
        /// <note><para>Required for future-dated Capacity Reservations only. To create a Capacity Reservation
        /// for immediate use, omit this parameter. </para></note><para>Indicates that the requested capacity will be delivered in addition to any running
        /// instances or reserved capacity that you have in your account at the requested date
        /// and time.</para><para>The only supported value is <c>incremental</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationDeliveryPreference")]
        public Amazon.EC2.CapacityReservationDeliveryPreference DeliveryPreference { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EbsOptimized { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation expires. When a Capacity Reservation
        /// expires, the reserved capacity is released and you can no longer launch instances
        /// into it. The Capacity Reservation's state changes to <c>expired</c> when it reaches
        /// its end date and time.</para><para>You must provide an <c>EndDate</c> value if <c>EndDateType</c> is <c>limited</c>.
        /// Omit <c>EndDate</c> if <c>EndDateType</c> is <c>unlimited</c>.</para><para>If the <c>EndDateType</c> is <c>limited</c>, the Capacity Reservation is cancelled
        /// within an hour from the specified time. For example, if you specify 5/31/2019, 13:30:55,
        /// the Capacity Reservation is guaranteed to end between 13:30:55 and 14:30:55 on 5/31/2019.</para><para>If you are requesting a future-dated Capacity Reservation, you can't specify an end
        /// date and time that is within the commitment duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter EndDateType
        /// <summary>
        /// <para>
        /// <para>Indicates the way in which the Capacity Reservation ends. A Capacity Reservation can
        /// have one of the following end types:</para><ul><li><para><c>unlimited</c> - The Capacity Reservation remains active until you explicitly cancel
        /// it. Do not provide an <c>EndDate</c> if the <c>EndDateType</c> is <c>unlimited</c>.</para></li><li><para><c>limited</c> - The Capacity Reservation expires automatically at a specified date
        /// and time. You must provide an <c>EndDate</c> value if the <c>EndDateType</c> value
        /// is <c>limited</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.EndDateType")]
        public Amazon.EC2.EndDateType EndDateType { get; set; }
        #endregion
        
        #region Parameter EphemeralStorage
        /// <summary>
        /// <para>
        /// <para><i>Deprecated.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EphemeralStorage { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances for which to reserve capacity.</para><note><para>You can request future-dated Capacity Reservations for an instance count with a minimum
        /// of 64 vCPUs. For example, if you request a future-dated Capacity Reservation for <c>m5.xlarge</c>
        /// instances, you must request at least 25 instances (<i>16 * m5.xlarge = 64 vCPUs</i>).</para></note><para>Valid range: 1 - 1000</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter InstanceMatchCriterion
        /// <summary>
        /// <para>
        /// <para>Indicates the type of instance launches that the Capacity Reservation accepts. The
        /// options include:</para><ul><li><para><c>open</c> - The Capacity Reservation automatically matches all instances that have
        /// matching attributes (instance type, platform, and Availability Zone). Instances that
        /// have matching attributes run in the Capacity Reservation automatically without specifying
        /// any additional parameters.</para></li><li><para><c>targeted</c> - The Capacity Reservation only accepts instances that have matching
        /// attributes (instance type, platform, and Availability Zone), and explicitly target
        /// the Capacity Reservation. This ensures that only permitted instances can use the reserved
        /// capacity. </para></li></ul><note><para>If you are requesting a future-dated Capacity Reservation, you must specify <c>targeted</c>.</para></note><para>Default: <c>open</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationInstancePlatform")]
        public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type for which to reserve capacity.</para><note><para>You can request future-dated Capacity Reservations for instance types in the C, M,
        /// R, I, T, and G instance families only.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// types</a> in the <i>Amazon EC2 User Guide</i>.</para>
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
        public System.String InstanceType { get; set; }
        #endregion
        
        #region Parameter OutpostArn
        /// <summary>
        /// <para>
        /// <note><para>Not supported for future-dated Capacity Reservations.</para></note><para>The Amazon Resource Name (ARN) of the Outpost on which to create the Capacity Reservation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostArn { get; set; }
        #endregion
        
        #region Parameter PlacementGroupArn
        /// <summary>
        /// <para>
        /// <note><para>Not supported for future-dated Capacity Reservations.</para></note><para>The Amazon Resource Name (ARN) of the cluster placement group in which to create the
        /// Capacity Reservation. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/cr-cpg.html">
        /// Capacity Reservations for cluster placement groups</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlacementGroupArn { get; set; }
        #endregion
        
        #region Parameter StartDate
        /// <summary>
        /// <para>
        /// <note><para>Required for future-dated Capacity Reservations only. To create a Capacity Reservation
        /// for immediate use, omit this parameter. </para></note><para>The date and time at which the future-dated Capacity Reservation should become available
        /// for use, in the ISO8601 format in the UTC time zone (<c>YYYY-MM-DDThh:mm:ss.sssZ</c>).</para><para>You can request a future-dated Capacity Reservation between 5 and 120 days in advance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartDate { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Capacity Reservation during launch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter Tenancy
        /// <summary>
        /// <para>
        /// <para>Indicates the tenancy of the Capacity Reservation. A Capacity Reservation can have
        /// one of the following tenancy settings:</para><ul><li><para><c>default</c> - The Capacity Reservation is created on hardware that is shared with
        /// other Amazon Web Services accounts.</para></li><li><para><c>dedicated</c> - The Capacity Reservation is created on single-tenant hardware
        /// that is dedicated to a single Amazon Web Services account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationTenancy")]
        public Amazon.EC2.CapacityReservationTenancy Tenancy { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CapacityReservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateCapacityReservationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CapacityReservation";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceType' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceType), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-EC2CapacityReservation (CreateCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateCapacityReservationResponse, AddEC2CapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.CommitmentDuration = this.CommitmentDuration;
            context.DeliveryPreference = this.DeliveryPreference;
            context.EbsOptimized = this.EbsOptimized;
            context.EndDate = this.EndDate;
            context.EndDateType = this.EndDateType;
            context.EphemeralStorage = this.EphemeralStorage;
            context.InstanceCount = this.InstanceCount;
            #if MODULAR
            if (this.InstanceCount == null && ParameterWasBound(nameof(this.InstanceCount)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceMatchCriterion = this.InstanceMatchCriterion;
            context.InstancePlatform = this.InstancePlatform;
            #if MODULAR
            if (this.InstancePlatform == null && ParameterWasBound(nameof(this.InstancePlatform)))
            {
                WriteWarning("You are passing $null as a value for parameter InstancePlatform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceType = this.InstanceType;
            #if MODULAR
            if (this.InstanceType == null && ParameterWasBound(nameof(this.InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutpostArn = this.OutpostArn;
            context.PlacementGroupArn = this.PlacementGroupArn;
            context.StartDate = this.StartDate;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CommitmentDuration != null)
            {
                request.CommitmentDuration = cmdletContext.CommitmentDuration.Value;
            }
            if (cmdletContext.DeliveryPreference != null)
            {
                request.DeliveryPreference = cmdletContext.DeliveryPreference;
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
            if (cmdletContext.InstanceMatchCriterion != null)
            {
                request.InstanceMatchCriteria = cmdletContext.InstanceMatchCriterion;
            }
            if (cmdletContext.InstancePlatform != null)
            {
                request.InstancePlatform = cmdletContext.InstancePlatform;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.OutpostArn != null)
            {
                request.OutpostArn = cmdletContext.OutpostArn;
            }
            if (cmdletContext.PlacementGroupArn != null)
            {
                request.PlacementGroupArn = cmdletContext.PlacementGroupArn;
            }
            if (cmdletContext.StartDate != null)
            {
                request.StartDate = cmdletContext.StartDate.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.Tenancy != null)
            {
                request.Tenancy = cmdletContext.Tenancy;
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
        
        private Amazon.EC2.Model.CreateCapacityReservationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateCapacityReservation");
            try
            {
                #if DESKTOP
                return client.CreateCapacityReservation(request);
                #elif CORECLR
                return client.CreateCapacityReservationAsync(request).GetAwaiter().GetResult();
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
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int64? CommitmentDuration { get; set; }
            public Amazon.EC2.CapacityReservationDeliveryPreference DeliveryPreference { get; set; }
            public System.Boolean? EbsOptimized { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.EndDateType EndDateType { get; set; }
            public System.Boolean? EphemeralStorage { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public Amazon.EC2.InstanceMatchCriteria InstanceMatchCriterion { get; set; }
            public Amazon.EC2.CapacityReservationInstancePlatform InstancePlatform { get; set; }
            public System.String InstanceType { get; set; }
            public System.String OutpostArn { get; set; }
            public System.String PlacementGroupArn { get; set; }
            public System.DateTime? StartDate { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.CapacityReservationTenancy Tenancy { get; set; }
            public System.Func<Amazon.EC2.Model.CreateCapacityReservationResponse, AddEC2CapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CapacityReservation;
        }
        
    }
}
