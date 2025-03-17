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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Modifies a Capacity Reservation Fleet.
    /// 
    ///  
    /// <para>
    /// When you modify the total target capacity of a Capacity Reservation Fleet, the Fleet
    /// automatically creates new Capacity Reservations, or modifies or cancels existing Capacity
    /// Reservations in the Fleet to meet the new total target capacity. When you modify the
    /// end date for the Fleet, the end dates for all of the individual Capacity Reservations
    /// in the Fleet are updated accordingly.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "EC2CapacityReservationFleet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyCapacityReservationFleet API operation.", Operation = new[] {"ModifyCapacityReservationFleet"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyCapacityReservationFleetResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyCapacityReservationFleetResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ModifyCapacityReservationFleetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2CapacityReservationFleetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapacityReservationFleetId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation Fleet to modify.</para>
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
        public System.String CapacityReservationFleetId { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EndDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the Capacity Reservation Fleet expires. When the Capacity
        /// Reservation Fleet expires, its state changes to <c>expired</c> and all of the Capacity
        /// Reservations in the Fleet expire.</para><para>The Capacity Reservation Fleet expires within an hour after the specified time. For
        /// example, if you specify <c>5/31/2019</c>, <c>13:30:55</c>, the Capacity Reservation
        /// Fleet is guaranteed to expire between <c>13:30:55</c> and <c>14:30:55</c> on <c>5/31/2019</c>.</para><para>You can't specify <b>EndDate</b> and <b> RemoveEndDate</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
        #endregion
        
        #region Parameter RemoveEndDate
        /// <summary>
        /// <para>
        /// <para>Indicates whether to remove the end date from the Capacity Reservation Fleet. If you
        /// remove the end date, the Capacity Reservation Fleet does not expire and it remains
        /// active until you explicitly cancel it using the <b>CancelCapacityReservationFleet</b>
        /// action.</para><para>You can't specify <b>RemoveEndDate</b> and <b> EndDate</b> in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveEndDate { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? TotalTargetCapacity { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyCapacityReservationFleetResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyCapacityReservationFleetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityReservationFleetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2CapacityReservationFleet (ModifyCapacityReservationFleet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyCapacityReservationFleetResponse, EditEC2CapacityReservationFleetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapacityReservationFleetId = this.CapacityReservationFleetId;
            #if MODULAR
            if (this.CapacityReservationFleetId == null && ParameterWasBound(nameof(this.CapacityReservationFleetId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationFleetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DryRun = this.DryRun;
            context.EndDate = this.EndDate;
            context.RemoveEndDate = this.RemoveEndDate;
            context.TotalTargetCapacity = this.TotalTargetCapacity;
            
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
            var request = new Amazon.EC2.Model.ModifyCapacityReservationFleetRequest();
            
            if (cmdletContext.CapacityReservationFleetId != null)
            {
                request.CapacityReservationFleetId = cmdletContext.CapacityReservationFleetId;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EndDate != null)
            {
                request.EndDate = cmdletContext.EndDate.Value;
            }
            if (cmdletContext.RemoveEndDate != null)
            {
                request.RemoveEndDate = cmdletContext.RemoveEndDate.Value;
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
        
        private Amazon.EC2.Model.ModifyCapacityReservationFleetResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyCapacityReservationFleetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyCapacityReservationFleet");
            try
            {
                return client.ModifyCapacityReservationFleetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CapacityReservationFleetId { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.DateTime? EndDate { get; set; }
            public System.Boolean? RemoveEndDate { get; set; }
            public System.Int32? TotalTargetCapacity { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyCapacityReservationFleetResponse, EditEC2CapacityReservationFleetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
