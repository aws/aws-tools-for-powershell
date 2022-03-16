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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Update an existing custom line item in the current or previous billing period.
    /// </summary>
    [Cmdlet("Update", "ABCCustomLineItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BillingConductor.Model.UpdateCustomLineItemResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor UpdateCustomLineItem API operation.", Operation = new[] {"UpdateCustomLineItem"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.UpdateCustomLineItemResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.UpdateCustomLineItemResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.UpdateCustomLineItemResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateABCCustomLineItemCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para> The ARN of the custom line item to be updated. </para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter Flat_ChargeValue
        /// <summary>
        /// <para>
        /// <para> The custom line item's new fixed charge value in USD. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_Flat_ChargeValue")]
        public System.Double? Flat_ChargeValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The new line item description of the custom line item. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_ExclusiveEndBillingPeriod
        /// <summary>
        /// <para>
        /// <para> The inclusive end billing period that defines a billing period range where a custom
        /// line is applied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_InclusiveStartBillingPeriod
        /// <summary>
        /// <para>
        /// <para> The inclusive start billing period that defines a billing period range where a custom
        /// line is applied. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The new name for the custom line item. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Percentage_PercentageValue
        /// <summary>
        /// <para>
        /// <para> The custom line item's new percentage value. This will be multiplied against the
        /// combined value of its associated resources to determine its charge value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_Percentage_PercentageValue")]
        public System.Double? Percentage_PercentageValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.UpdateCustomLineItemResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.UpdateCustomLineItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ABCCustomLineItem (UpdateCustomLineItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.UpdateCustomLineItemResponse, UpdateABCCustomLineItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingPeriodRange_ExclusiveEndBillingPeriod = this.BillingPeriodRange_ExclusiveEndBillingPeriod;
            context.BillingPeriodRange_InclusiveStartBillingPeriod = this.BillingPeriodRange_InclusiveStartBillingPeriod;
            context.Flat_ChargeValue = this.Flat_ChargeValue;
            context.Percentage_PercentageValue = this.Percentage_PercentageValue;
            context.Description = this.Description;
            context.Name = this.Name;
            
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
            var request = new Amazon.BillingConductor.Model.UpdateCustomLineItemRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate BillingPeriodRange
            var requestBillingPeriodRangeIsNull = true;
            request.BillingPeriodRange = new Amazon.BillingConductor.Model.CustomLineItemBillingPeriodRange();
            System.String requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod = cmdletContext.BillingPeriodRange_ExclusiveEndBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod != null)
            {
                request.BillingPeriodRange.ExclusiveEndBillingPeriod = requestBillingPeriodRange_billingPeriodRange_ExclusiveEndBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
            System.String requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod = cmdletContext.BillingPeriodRange_InclusiveStartBillingPeriod;
            }
            if (requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod != null)
            {
                request.BillingPeriodRange.InclusiveStartBillingPeriod = requestBillingPeriodRange_billingPeriodRange_InclusiveStartBillingPeriod;
                requestBillingPeriodRangeIsNull = false;
            }
             // determine if request.BillingPeriodRange should be set to null
            if (requestBillingPeriodRangeIsNull)
            {
                request.BillingPeriodRange = null;
            }
            
             // populate ChargeDetails
            var requestChargeDetailsIsNull = true;
            request.ChargeDetails = new Amazon.BillingConductor.Model.UpdateCustomLineItemChargeDetails();
            Amazon.BillingConductor.Model.UpdateCustomLineItemFlatChargeDetails requestChargeDetails_chargeDetails_Flat = null;
            
             // populate Flat
            var requestChargeDetails_chargeDetails_FlatIsNull = true;
            requestChargeDetails_chargeDetails_Flat = new Amazon.BillingConductor.Model.UpdateCustomLineItemFlatChargeDetails();
            System.Double? requestChargeDetails_chargeDetails_Flat_flat_ChargeValue = null;
            if (cmdletContext.Flat_ChargeValue != null)
            {
                requestChargeDetails_chargeDetails_Flat_flat_ChargeValue = cmdletContext.Flat_ChargeValue.Value;
            }
            if (requestChargeDetails_chargeDetails_Flat_flat_ChargeValue != null)
            {
                requestChargeDetails_chargeDetails_Flat.ChargeValue = requestChargeDetails_chargeDetails_Flat_flat_ChargeValue.Value;
                requestChargeDetails_chargeDetails_FlatIsNull = false;
            }
             // determine if requestChargeDetails_chargeDetails_Flat should be set to null
            if (requestChargeDetails_chargeDetails_FlatIsNull)
            {
                requestChargeDetails_chargeDetails_Flat = null;
            }
            if (requestChargeDetails_chargeDetails_Flat != null)
            {
                request.ChargeDetails.Flat = requestChargeDetails_chargeDetails_Flat;
                requestChargeDetailsIsNull = false;
            }
            Amazon.BillingConductor.Model.UpdateCustomLineItemPercentageChargeDetails requestChargeDetails_chargeDetails_Percentage = null;
            
             // populate Percentage
            var requestChargeDetails_chargeDetails_PercentageIsNull = true;
            requestChargeDetails_chargeDetails_Percentage = new Amazon.BillingConductor.Model.UpdateCustomLineItemPercentageChargeDetails();
            System.Double? requestChargeDetails_chargeDetails_Percentage_percentage_PercentageValue = null;
            if (cmdletContext.Percentage_PercentageValue != null)
            {
                requestChargeDetails_chargeDetails_Percentage_percentage_PercentageValue = cmdletContext.Percentage_PercentageValue.Value;
            }
            if (requestChargeDetails_chargeDetails_Percentage_percentage_PercentageValue != null)
            {
                requestChargeDetails_chargeDetails_Percentage.PercentageValue = requestChargeDetails_chargeDetails_Percentage_percentage_PercentageValue.Value;
                requestChargeDetails_chargeDetails_PercentageIsNull = false;
            }
             // determine if requestChargeDetails_chargeDetails_Percentage should be set to null
            if (requestChargeDetails_chargeDetails_PercentageIsNull)
            {
                requestChargeDetails_chargeDetails_Percentage = null;
            }
            if (requestChargeDetails_chargeDetails_Percentage != null)
            {
                request.ChargeDetails.Percentage = requestChargeDetails_chargeDetails_Percentage;
                requestChargeDetailsIsNull = false;
            }
             // determine if request.ChargeDetails should be set to null
            if (requestChargeDetailsIsNull)
            {
                request.ChargeDetails = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.BillingConductor.Model.UpdateCustomLineItemResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.UpdateCustomLineItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "UpdateCustomLineItem");
            try
            {
                #if DESKTOP
                return client.UpdateCustomLineItem(request);
                #elif CORECLR
                return client.UpdateCustomLineItemAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
            public System.Double? Flat_ChargeValue { get; set; }
            public System.Double? Percentage_PercentageValue { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.BillingConductor.Model.UpdateCustomLineItemResponse, UpdateABCCustomLineItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
