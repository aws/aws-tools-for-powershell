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
    /// Purchases a Reserved Instance for use with your account. With Reserved Instances,
    /// you pay a lower hourly rate compared to On-Demand instance pricing.
    /// 
    ///  
    /// <para>
    /// Use <a>DescribeReservedInstancesOfferings</a> to get a list of Reserved Instance offerings
    /// that match your specifications. After you've purchased a Reserved Instance, you can
    /// check for your new Reserved Instance with <a>DescribeReservedInstances</a>.
    /// </para><para>
    /// To queue a purchase for a future date and time, specify a purchase time. If you do
    /// not specify a purchase time, the default is the current time.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/concepts-on-demand-reserved-instances.html">Reserved
    /// Instances</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Sell
    /// in the Reserved Instance Marketplace</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2ReservedInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) PurchaseReservedInstancesOffering API operation.", Operation = new[] {"PurchaseReservedInstancesOffering"}, SelectReturnType = typeof(Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2ReservedInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LimitPrice_Amount
        /// <summary>
        /// <para>
        /// <para>Used for Reserved Instance Marketplace offerings. Specifies the limit price on the
        /// total order (instanceCount * price).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Double? LimitPrice_Amount { get; set; }
        #endregion
        
        #region Parameter LimitPrice_CurrencyCode
        /// <summary>
        /// <para>
        /// <para>The currency in which the <c>limitPrice</c> amount is specified. At this time, the
        /// only supported currency is <c>USD</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.CurrencyCodeValues")]
        public Amazon.EC2.CurrencyCodeValues LimitPrice_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of Reserved Instances to purchase.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? InstanceCount { get; set; }
        #endregion
        
        #region Parameter PurchaseTime
        /// <summary>
        /// <para>
        /// <para>The time at which to purchase the Reserved Instance, in UTC format (for example, <i>YYYY</i>-<i>MM</i>-<i>DD</i>T<i>HH</i>:<i>MM</i>:<i>SS</i>Z).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? PurchaseTime { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Reserved Instance offering to purchase.</para>
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
        public System.String ReservedInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstancesId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstancesId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReservedInstancesOfferingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ReservedInstance (PurchaseReservedInstancesOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse, NewEC2ReservedInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceCount = this.InstanceCount;
            #if MODULAR
            if (this.InstanceCount == null && ParameterWasBound(nameof(this.InstanceCount)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LimitPrice_Amount = this.LimitPrice_Amount;
            context.LimitPrice_CurrencyCode = this.LimitPrice_CurrencyCode;
            context.PurchaseTime = this.PurchaseTime;
            context.ReservedInstancesOfferingId = this.ReservedInstancesOfferingId;
            #if MODULAR
            if (this.ReservedInstancesOfferingId == null && ParameterWasBound(nameof(this.ReservedInstancesOfferingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ReservedInstancesOfferingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.PurchaseReservedInstancesOfferingRequest();
            
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            
             // populate LimitPrice
            var requestLimitPriceIsNull = true;
            request.LimitPrice = new Amazon.EC2.Model.ReservedInstanceLimitPrice();
            System.Double? requestLimitPrice_limitPrice_Amount = null;
            if (cmdletContext.LimitPrice_Amount != null)
            {
                requestLimitPrice_limitPrice_Amount = cmdletContext.LimitPrice_Amount.Value;
            }
            if (requestLimitPrice_limitPrice_Amount != null)
            {
                request.LimitPrice.Amount = requestLimitPrice_limitPrice_Amount.Value;
                requestLimitPriceIsNull = false;
            }
            Amazon.EC2.CurrencyCodeValues requestLimitPrice_limitPrice_CurrencyCode = null;
            if (cmdletContext.LimitPrice_CurrencyCode != null)
            {
                requestLimitPrice_limitPrice_CurrencyCode = cmdletContext.LimitPrice_CurrencyCode;
            }
            if (requestLimitPrice_limitPrice_CurrencyCode != null)
            {
                request.LimitPrice.CurrencyCode = requestLimitPrice_limitPrice_CurrencyCode;
                requestLimitPriceIsNull = false;
            }
             // determine if request.LimitPrice should be set to null
            if (requestLimitPriceIsNull)
            {
                request.LimitPrice = null;
            }
            if (cmdletContext.PurchaseTime != null)
            {
                request.PurchaseTime = cmdletContext.PurchaseTime.Value;
            }
            if (cmdletContext.ReservedInstancesOfferingId != null)
            {
                request.ReservedInstancesOfferingId = cmdletContext.ReservedInstancesOfferingId;
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
        
        private Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.PurchaseReservedInstancesOfferingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "PurchaseReservedInstancesOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedInstancesOffering(request);
                #elif CORECLR
                return client.PurchaseReservedInstancesOfferingAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? InstanceCount { get; set; }
            public System.Double? LimitPrice_Amount { get; set; }
            public Amazon.EC2.CurrencyCodeValues LimitPrice_CurrencyCode { get; set; }
            public System.DateTime? PurchaseTime { get; set; }
            public System.String ReservedInstancesOfferingId { get; set; }
            public System.Func<Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse, NewEC2ReservedInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstancesId;
        }
        
    }
}
