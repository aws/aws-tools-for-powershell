/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/concepts-on-demand-reserved-instances.html">Reserved
    /// Instances</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Reserved
    /// Instance Marketplace</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2ReservedInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud PurchaseReservedInstancesOffering API operation.", Operation = new[] {"PurchaseReservedInstancesOffering"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.EC2.Model.PurchaseReservedInstancesOfferingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2ReservedInstanceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter LimitPrice_Amount
        /// <summary>
        /// <para>
        /// <para>Used for Reserved Instance Marketplace offerings. Specifies the limit price on the
        /// total order (instanceCount * price).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.Double LimitPrice_Amount { get; set; }
        #endregion
        
        #region Parameter LimitPrice_CurrencyCode
        /// <summary>
        /// <para>
        /// <para>The currency in which the <code>limitPrice</code> amount is specified. At this time,
        /// the only supported currency is <code>USD</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        [AWSConstantClassSource("Amazon.EC2.CurrencyCodeValues")]
        public Amazon.EC2.CurrencyCodeValues LimitPrice_CurrencyCode { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of Reserved Instances to purchase.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 InstanceCount { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>The ID of the Reserved Instance offering to purchase.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedInstancesOfferingId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ReservedInstance (PurchaseReservedInstancesOffering)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            if (ParameterWasBound("LimitPrice_Amount"))
                context.LimitPrice_Amount = this.LimitPrice_Amount;
            context.LimitPrice_CurrencyCode = this.LimitPrice_CurrencyCode;
            context.ReservedInstancesOfferingId = this.ReservedInstancesOfferingId;
            
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
            bool requestLimitPriceIsNull = true;
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
            if (cmdletContext.ReservedInstancesOfferingId != null)
            {
                request.ReservedInstancesOfferingId = cmdletContext.ReservedInstancesOfferingId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedInstancesId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "PurchaseReservedInstancesOffering");
            try
            {
                #if DESKTOP
                return client.PurchaseReservedInstancesOffering(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PurchaseReservedInstancesOfferingAsync(request);
                return task.Result;
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
            public System.String ReservedInstancesOfferingId { get; set; }
        }
        
    }
}
