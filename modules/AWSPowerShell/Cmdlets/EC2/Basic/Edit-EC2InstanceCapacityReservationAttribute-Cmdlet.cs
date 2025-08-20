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
    /// Modifies the Capacity Reservation settings for a stopped instance. Use this action
    /// to configure an instance to target a specific Capacity Reservation, run in any <c>open</c>
    /// Capacity Reservation with matching attributes, run in On-Demand Instance capacity,
    /// or only run in a Capacity Reservation.
    /// </summary>
    [Cmdlet("Edit", "EC2InstanceCapacityReservationAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ModifyInstanceCapacityReservationAttributes API operation.", Operation = new[] {"ModifyInstanceCapacityReservationAttributes"}, SelectReturnType = typeof(Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse",
        "This cmdlet returns a System.Boolean object.",
        "The service call response (type Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class EditEC2InstanceCapacityReservationAttributeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CapacityReservationTarget_CapacityReservationId
        /// <summary>
        /// <para>
        /// <para>The ID of the Capacity Reservation in which to run the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationId")]
        public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
        #endregion
        
        #region Parameter CapacityReservationSpecification_CapacityReservationPreference
        /// <summary>
        /// <para>
        /// <para>Indicates the instance's Capacity Reservation preferences. Possible preferences include:</para><ul><li><para><c>capacity-reservations-only</c> - The instance will only run in a Capacity Reservation
        /// or Capacity Reservation group. If capacity isn't available, the instance will fail
        /// to launch.</para></li><li><para><c>open</c> - The instance can run in any <c>open</c> Capacity Reservation that has
        /// matching attributes (instance type, platform, Availability Zone, and tenancy). If
        /// capacity isn't available, the instance runs as an On-Demand Instance.</para></li><li><para><c>none</c> - The instance doesn't run in a Capacity Reservation even if one is available.
        /// The instance runs as an On-Demand Instance.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CapacityReservationPreference")]
        public Amazon.EC2.CapacityReservationPreference CapacityReservationSpecification_CapacityReservationPreference { get; set; }
        #endregion
        
        #region Parameter CapacityReservationTarget_CapacityReservationResourceGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Capacity Reservation resource group in which to run the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CapacityReservationSpecification_CapacityReservationTarget_CapacityReservationResourceGroupArn")]
        public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance to be modified.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-EC2InstanceCapacityReservationAttribute (ModifyInstanceCapacityReservationAttributes)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse, EditEC2InstanceCapacityReservationAttributeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CapacityReservationSpecification_CapacityReservationPreference = this.CapacityReservationSpecification_CapacityReservationPreference;
            context.CapacityReservationTarget_CapacityReservationId = this.CapacityReservationTarget_CapacityReservationId;
            context.CapacityReservationTarget_CapacityReservationResourceGroupArn = this.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesRequest();
            
            
             // populate CapacityReservationSpecification
            request.CapacityReservationSpecification = new Amazon.EC2.Model.CapacityReservationSpecification();
            Amazon.EC2.CapacityReservationPreference requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = null;
            if (cmdletContext.CapacityReservationSpecification_CapacityReservationPreference != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference = cmdletContext.CapacityReservationSpecification_CapacityReservationPreference;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference != null)
            {
                request.CapacityReservationSpecification.CapacityReservationPreference = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationPreference;
            }
            Amazon.EC2.Model.CapacityReservationTarget requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = null;
            
             // populate CapacityReservationTarget
            var requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = true;
            requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget = new Amazon.EC2.Model.CapacityReservationTarget();
            System.String requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId = cmdletContext.CapacityReservationTarget_CapacityReservationId;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationId = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationId;
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTargetIsNull = false;
            }
            System.String requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = null;
            if (cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn = cmdletContext.CapacityReservationTarget_CapacityReservationResourceGroupArn;
            }
            if (requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn != null)
            {
                requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget.CapacityReservationResourceGroupArn = requestCapacityReservationSpecification_capacityReservationSpecification_CapacityReservationTarget_capacityReservationTarget_CapacityReservationResourceGroupArn;
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
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ModifyInstanceCapacityReservationAttributes");
            try
            {
                #if DESKTOP
                return client.ModifyInstanceCapacityReservationAttributes(request);
                #elif CORECLR
                return client.ModifyInstanceCapacityReservationAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.String CapacityReservationTarget_CapacityReservationId { get; set; }
            public System.String CapacityReservationTarget_CapacityReservationResourceGroupArn { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.EC2.Model.ModifyInstanceCapacityReservationAttributesResponse, EditEC2InstanceCapacityReservationAttributeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
