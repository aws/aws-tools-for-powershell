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
    /// Creates a custom line item that can be used to create a one-time fixed charge that
    /// can be applied to a single billing group for the current or previous billing period.
    /// The one-time fixed charge is either a fee or discount.
    /// </summary>
    [Cmdlet("New", "ABCCustomLineItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWSBillingConductor CreateCustomLineItem API operation.", Operation = new[] {"CreateCustomLineItem"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.CreateCustomLineItemResponse))]
    [AWSCmdletOutput("System.String or Amazon.BillingConductor.Model.CreateCustomLineItemResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.BillingConductor.Model.CreateCustomLineItemResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewABCCustomLineItemCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account in which this custom line item will be applied to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Percentage_AssociatedValue
        /// <summary>
        /// <para>
        /// <para>A list of resource ARNs to associate to the percentage custom line item.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_Percentage_AssociatedValues")]
        public System.String[] Percentage_AssociatedValue { get; set; }
        #endregion
        
        #region Parameter BillingGroupArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that references the billing group where the custom
        /// line item applies to. </para>
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
        public System.String BillingGroupArn { get; set; }
        #endregion
        
        #region Parameter Flat_ChargeValue
        /// <summary>
        /// <para>
        /// <para>The custom line item's fixed charge value in USD.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_Flat_ChargeValue")]
        public System.Double? Flat_ChargeValue { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the custom line item. This is shown on the Bills page in association
        /// with the charge value. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_ExclusiveEndBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive end billing period that defines a billing period range where a custom
        /// line is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_InclusiveStartBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive start billing period that defines a billing period range where a custom
        /// line is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter ChargeDetails_LineItemFilter
        /// <summary>
        /// <para>
        /// <para>A representation of the line item filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_LineItemFilters")]
        public Amazon.BillingConductor.Model.LineItemFilter[] ChargeDetails_LineItemFilter { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the custom line item. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Percentage_PercentageValue
        /// <summary>
        /// <para>
        /// <para>The custom line item's percentage value. This will be multiplied against the combined
        /// value of its associated resources to determine its charge value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChargeDetails_Percentage_PercentageValue")]
        public System.Double? Percentage_PercentageValue { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A map that contains tag keys and tag values that are attached to a custom line item.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ChargeDetails_Type
        /// <summary>
        /// <para>
        /// <para>The type of the custom line item that indicates whether the charge is a fee or credit.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BillingConductor.CustomLineItemType")]
        public Amazon.BillingConductor.CustomLineItemType ChargeDetails_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> The token that is needed to support idempotency. Idempotency isn't currently supported,
        /// but will be implemented in a future update. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.CreateCustomLineItemResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.CreateCustomLineItemResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BillingGroupArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BillingGroupArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BillingGroupArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ABCCustomLineItem (CreateCustomLineItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.CreateCustomLineItemResponse, NewABCCustomLineItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BillingGroupArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            context.BillingGroupArn = this.BillingGroupArn;
            #if MODULAR
            if (this.BillingGroupArn == null && ParameterWasBound(nameof(this.BillingGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BillingGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingPeriodRange_ExclusiveEndBillingPeriod = this.BillingPeriodRange_ExclusiveEndBillingPeriod;
            context.BillingPeriodRange_InclusiveStartBillingPeriod = this.BillingPeriodRange_InclusiveStartBillingPeriod;
            context.Flat_ChargeValue = this.Flat_ChargeValue;
            if (this.ChargeDetails_LineItemFilter != null)
            {
                context.ChargeDetails_LineItemFilter = new List<Amazon.BillingConductor.Model.LineItemFilter>(this.ChargeDetails_LineItemFilter);
            }
            if (this.Percentage_AssociatedValue != null)
            {
                context.Percentage_AssociatedValue = new List<System.String>(this.Percentage_AssociatedValue);
            }
            context.Percentage_PercentageValue = this.Percentage_PercentageValue;
            context.ChargeDetails_Type = this.ChargeDetails_Type;
            #if MODULAR
            if (this.ChargeDetails_Type == null && ParameterWasBound(nameof(this.ChargeDetails_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter ChargeDetails_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.BillingConductor.Model.CreateCustomLineItemRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BillingGroupArn != null)
            {
                request.BillingGroupArn = cmdletContext.BillingGroupArn;
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
            request.ChargeDetails = new Amazon.BillingConductor.Model.CustomLineItemChargeDetails();
            List<Amazon.BillingConductor.Model.LineItemFilter> requestChargeDetails_chargeDetails_LineItemFilter = null;
            if (cmdletContext.ChargeDetails_LineItemFilter != null)
            {
                requestChargeDetails_chargeDetails_LineItemFilter = cmdletContext.ChargeDetails_LineItemFilter;
            }
            if (requestChargeDetails_chargeDetails_LineItemFilter != null)
            {
                request.ChargeDetails.LineItemFilters = requestChargeDetails_chargeDetails_LineItemFilter;
                requestChargeDetailsIsNull = false;
            }
            Amazon.BillingConductor.CustomLineItemType requestChargeDetails_chargeDetails_Type = null;
            if (cmdletContext.ChargeDetails_Type != null)
            {
                requestChargeDetails_chargeDetails_Type = cmdletContext.ChargeDetails_Type;
            }
            if (requestChargeDetails_chargeDetails_Type != null)
            {
                request.ChargeDetails.Type = requestChargeDetails_chargeDetails_Type;
                requestChargeDetailsIsNull = false;
            }
            Amazon.BillingConductor.Model.CustomLineItemFlatChargeDetails requestChargeDetails_chargeDetails_Flat = null;
            
             // populate Flat
            var requestChargeDetails_chargeDetails_FlatIsNull = true;
            requestChargeDetails_chargeDetails_Flat = new Amazon.BillingConductor.Model.CustomLineItemFlatChargeDetails();
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
            Amazon.BillingConductor.Model.CustomLineItemPercentageChargeDetails requestChargeDetails_chargeDetails_Percentage = null;
            
             // populate Percentage
            var requestChargeDetails_chargeDetails_PercentageIsNull = true;
            requestChargeDetails_chargeDetails_Percentage = new Amazon.BillingConductor.Model.CustomLineItemPercentageChargeDetails();
            List<System.String> requestChargeDetails_chargeDetails_Percentage_percentage_AssociatedValue = null;
            if (cmdletContext.Percentage_AssociatedValue != null)
            {
                requestChargeDetails_chargeDetails_Percentage_percentage_AssociatedValue = cmdletContext.Percentage_AssociatedValue;
            }
            if (requestChargeDetails_chargeDetails_Percentage_percentage_AssociatedValue != null)
            {
                requestChargeDetails_chargeDetails_Percentage.AssociatedValues = requestChargeDetails_chargeDetails_Percentage_percentage_AssociatedValue;
                requestChargeDetails_chargeDetails_PercentageIsNull = false;
            }
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.BillingConductor.Model.CreateCustomLineItemResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.CreateCustomLineItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "CreateCustomLineItem");
            try
            {
                #if DESKTOP
                return client.CreateCustomLineItem(request);
                #elif CORECLR
                return client.CreateCustomLineItemAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String BillingGroupArn { get; set; }
            public System.String BillingPeriodRange_ExclusiveEndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_InclusiveStartBillingPeriod { get; set; }
            public System.Double? Flat_ChargeValue { get; set; }
            public List<Amazon.BillingConductor.Model.LineItemFilter> ChargeDetails_LineItemFilter { get; set; }
            public List<System.String> Percentage_AssociatedValue { get; set; }
            public System.Double? Percentage_PercentageValue { get; set; }
            public Amazon.BillingConductor.CustomLineItemType ChargeDetails_Type { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BillingConductor.Model.CreateCustomLineItemResponse, NewABCCustomLineItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
