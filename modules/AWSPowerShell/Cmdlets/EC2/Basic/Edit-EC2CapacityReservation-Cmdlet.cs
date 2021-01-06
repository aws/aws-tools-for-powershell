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
    /// Modifies a Capacity Reservation's capacity and the conditions under which it is to
    /// be released. You cannot change a Capacity Reservation's instance type, EBS optimization,
    /// instance store settings, platform, Availability Zone, or instance eligibility. If
    /// you need to modify any of these attributes, we recommend that you cancel the Capacity
    /// Reservation, and then create a new one with the required attributes.
    /// </summary>
    [Cmdlet("Edit", "EC2CapacityReservation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyCapacityReservation API operation.", Operation = new[] {"ModifyCapacityReservation"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyCapacityReservationResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyCapacityReservationResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyCapacityReservationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditEC2CapacityReservationCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>Reserved. Capacity Reservations you have created are accepted by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Accept { get; set; }
        #endregion
        
        #region Parameter CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndDate { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.EndDateType")]
        public Amazon.EC2.EndDateType EndDateType { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances for which to reserve capacity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyCapacityReservationResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyCapacityReservationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CapacityReservationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CapacityReservationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CapacityReservationId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CapacityReservationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2CapacityReservation (ModifyCapacityReservation)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyCapacityReservationResponse, EditEC2CapacityReservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CapacityReservationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Accept = this.Accept;
            context.CapacityReservationId = this.CapacityReservationId;
            #if MODULAR
            if (this.CapacityReservationId == null && ParameterWasBound(nameof(this.CapacityReservationId)))
            {
                WriteWarning("You are passing $null as a value for parameter CapacityReservationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndDate = this.EndDate;
            context.EndDateType = this.EndDateType;
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
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept.Value;
            }
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
        
        private Amazon.EC2.Model.ModifyCapacityReservationResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyCapacityReservationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyCapacityReservation");
            try
            {
                #if DESKTOP
                return client.ModifyCapacityReservation(request);
                #elif CORECLR
                return client.ModifyCapacityReservationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Accept { get; set; }
            public System.String CapacityReservationId { get; set; }
            public System.DateTime? EndDate { get; set; }
            public Amazon.EC2.EndDateType EndDateType { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyCapacityReservationResponse, EditEC2CapacityReservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
