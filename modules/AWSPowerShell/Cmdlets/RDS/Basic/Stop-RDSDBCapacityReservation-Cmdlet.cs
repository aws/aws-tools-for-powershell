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
    /// Cancels a DB capacity reservation. Amazon RDS changes the state of the reservation
    /// to <c>cancelled</c> and stops reporting available capacity for it. Amazon RDS then
    /// releases the reserved capacity.
    /// 
    ///  
    /// <para>
    /// A DB instance that uses the reservation keeps running. It continues on unreserved
    /// capacity, and Amazon RDS doesn't stop it or modify it. However, Amazon RDS no longer
    /// reserves capacity for the DB instance. If Amazon RDS later moves the DB instance to
    /// different hardware, for example during hardware maintenance, that move can fail when
    /// the Amazon Web Services Region has insufficient capacity for the DB instance class.
    /// </para><para>
    /// You can't cancel a reservation in the <c>active</c> state during a capacity commitment.
    /// The response of <c>DescribeDBCapacityReservations</c> reports the end of the commitment
    /// in <c>CommitmentInfo</c>.
    /// </para><para>
    /// Constraints:
    /// </para><ul><li><para>
    /// The reservation must be in the <c>active</c>, <c>assessing</c>, or <c>delayed</c>
    /// state.
    /// </para></li><li><para>
    /// The reservation must not be past its end date.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Stop", "RDSDBCapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCapacityReservation")]
    [AWSCmdlet("Calls the Amazon Relational Database Service CancelDBCapacityReservation API operation.", Operation = new[] {"CancelDBCapacityReservation"}, SelectReturnType = typeof(Amazon.RDS.Model.CancelDBCapacityReservationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCapacityReservation or Amazon.RDS.Model.CancelDBCapacityReservationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCapacityReservation object.",
        "The service call response (type Amazon.RDS.Model.CancelDBCapacityReservationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopRDSDBCapacityReservationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DBCapacityReservationIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier or the name of the DB capacity reservation to cancel. You can specify
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCapacityReservation'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.CancelDBCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.CancelDBCapacityReservationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-RDSDBCapacityReservation (CancelDBCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.CancelDBCapacityReservationResponse, StopRDSDBCapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBCapacityReservationIdentifier = this.DBCapacityReservationIdentifier;
            #if MODULAR
            if (this.DBCapacityReservationIdentifier == null && ParameterWasBound(nameof(this.DBCapacityReservationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBCapacityReservationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.CancelDBCapacityReservationRequest();
            
            if (cmdletContext.DBCapacityReservationIdentifier != null)
            {
                request.DBCapacityReservationIdentifier = cmdletContext.DBCapacityReservationIdentifier;
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
        
        private Amazon.RDS.Model.CancelDBCapacityReservationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.CancelDBCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "CancelDBCapacityReservation");
            try
            {
                return client.CancelDBCapacityReservationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DBCapacityReservationIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.CancelDBCapacityReservationResponse, StopRDSDBCapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCapacityReservation;
        }
        
    }
}
