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
using System.Threading;
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Modifies a DB capacity reservation. You can change the reserved capacity in each Availability
    /// Zone of the reservation, and you can change the end date of the reservation. You can't
    /// change the Availability Zones of an existing reservation.
    /// 
    ///  
    /// <para>
    /// The reservation must be in the <c>active</c> state. A future-dated reservation that
    /// hasn't started isn't modifiable, and neither is a reservation that Amazon RDS is already
    /// modifying.
    /// </para><para>
    /// You must specify <c>CapacityPerAvailabilityZone</c>, <c>EndDateType</c>, or <c>EndDate</c>.
    /// A request that specifies none of the three changes nothing, and Amazon RDS rejects
    /// it.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RDSDBCapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCapacityReservation")]
    [AWSCmdlet("Calls the Amazon Relational Database Service ModifyDBCapacityReservation API operation.", Operation = new[] {"ModifyDBCapacityReservation"}, SelectReturnType = typeof(Amazon.RDS.Model.ModifyDBCapacityReservationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCapacityReservation or Amazon.RDS.Model.ModifyDBCapacityReservationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCapacityReservation object.",
        "The service call response (type Amazon.RDS.Model.ModifyDBCapacityReservationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditRDSDBCapacityReservationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapacityPerAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The new number of DB instances to reserve in each Availability Zone of the reservation.
        /// Amazon RDS applies this number to every Availability Zone of the reservation.</para><para>An increase reserves more capacity at the time of the request, so it can fail when
        /// the Amazon Web Services Region has insufficient capacity.</para><para>This value multiplied by the number of Availability Zones counts against the DB instances
        /// quota for your Amazon Web Services account in the Amazon Web Services Region. Amazon
        /// RDS checks the quota only when you increase the value.</para><para>Constraints:</para><ul><li><para>Minimum 1.</para></li><li><para>Can't be less than the highest number of DB instances that use the reservation in
        /// any single Availability Zone of the reservation. That number includes a DB instance
        /// that holds a unit of reserved capacity for a pending modification. To find that number
        /// for an Availability Zone, subtract <c>AvailableCapacity</c> from <c>ReservedCapacityPerAvailabilityZone</c>.</para></li><li><para>During a capacity commitment, can't be less than <c>CommittedCapacityPerAvailabilityZone</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CapacityPerAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DBCapacityReservationIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier or the name of the DB capacity reservation to modify. You can specify
        /// the identifier, which has the prefix <c>dbcr-</c>, or the reservation name.</para>
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
        public System.String DBCapacityReservationIdentifier { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The new end date for the reservation, in Universal Coordinated Time (UTC). Required
        /// when <c>EndDateType</c> is <c>limited</c>. Don't specify a value when <c>EndDateType</c>
        /// is <c>unlimited</c>.</para><para>When you specify <c>EndDate</c>, you must also specify <c>EndDateType</c>.</para><para>Constraints:</para><ul><li><para>Must be a date and time in the future.</para></li><li><para>During a capacity commitment, must be at or after <c>CommitmentEndDate</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter EndDateType
        /// <summary>
        /// <para>
        /// <para>The end date type for the reservation.</para><para>Valid Values:</para><ul><li><para><c>limited</c> - The reservation has a specific end date. You must also specify <c>EndDate</c>.</para></li><li><para><c>unlimited</c> - The reservation doesn't expire. Don't specify <c>EndDate</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.RDS.EndDateType")]
        public Amazon.RDS.EndDateType EndDateType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCapacityReservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.ModifyDBCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.ModifyDBCapacityReservationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCapacityReservation";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBCapacityReservationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RDSDBCapacityReservation (ModifyDBCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.ModifyDBCapacityReservationResponse, EditRDSDBCapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityPerAvailabilityZone = this.CapacityPerAvailabilityZone;
            context.DBCapacityReservationIdentifier = this.DBCapacityReservationIdentifier;
            #if MODULAR
            if (this.DBCapacityReservationIdentifier == null && ParameterWasBound(nameof(this.DBCapacityReservationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBCapacityReservationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDate = this.EndDate;
            context.EndDateType = this.EndDateType;
            
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
            var request = new Amazon.RDS.Model.ModifyDBCapacityReservationRequest();
            
            if (cmdletContext.CapacityPerAvailabilityZone != null)
            {
                request.CapacityPerAvailabilityZone = cmdletContext.CapacityPerAvailabilityZone.Value;
            }
            if (cmdletContext.DBCapacityReservationIdentifier != null)
            {
                request.DBCapacityReservationIdentifier = cmdletContext.DBCapacityReservationIdentifier;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.EndDateType != null)
            {
                request.EndDateType = cmdletContext.EndDateType;
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
        
        private Amazon.RDS.Model.ModifyDBCapacityReservationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.ModifyDBCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "ModifyDBCapacityReservation");
            try
            {
                return client.ModifyDBCapacityReservationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CapacityPerAvailabilityZone { get; set; }
            public System.String DBCapacityReservationIdentifier { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.RDS.EndDateType EndDateType { get; set; }
            public System.Func<Amazon.RDS.Model.ModifyDBCapacityReservationResponse, EditRDSDBCapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCapacityReservation;
        }
        
    }
}
