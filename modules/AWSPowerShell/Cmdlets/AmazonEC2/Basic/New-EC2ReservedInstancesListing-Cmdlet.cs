/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a listing for Amazon EC2 Reserved instances to be sold in the Reserved Instance
    /// Marketplace. You can submit one Reserved instance listing at a time. To get a list
    /// of your Reserved instances, you can use the <a>DescribeReservedInstances</a> operation.
    /// 
    ///  
    /// <para>
    /// The Reserved Instance Marketplace matches sellers who want to resell Reserved instance
    /// capacity that they no longer need with buyers who want to purchase additional capacity.
    /// Reserved instances bought and sold through the Reserved Instance Marketplace work
    /// like any other Reserved instances.
    /// </para><para>
    /// To sell your Reserved instances, you must first register as a seller in the Reserved
    /// Instance Marketplace. After completing the registration process, you can create a
    /// Reserved Instance Marketplace listing of some or all of your Reserved instances, and
    /// specify the upfront price to receive for them. Your Reserved instance listings then
    /// become available for purchase. To view the details of your Reserved instance listing,
    /// you can use the <a>DescribeReservedInstancesListings</a> operation.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Reserved
    /// Instance Marketplace</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2ReservedInstancesListing", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.ReservedInstancesListing")]
    [AWSCmdlet("Invokes the CreateReservedInstancesListing operation against Amazon Elastic Compute Cloud.", Operation = new[] {"CreateReservedInstancesListing"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesListing",
        "This cmdlet returns a collection of ReservedInstancesListing objects.",
        "The service call response (type Amazon.EC2.Model.CreateReservedInstancesListingResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewEC2ReservedInstancesListingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of your listings.
        /// This helps avoid duplicate listings. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String ClientToken { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The number of instances that are a part of a Reserved instance account to be listed
        /// in the Reserved Instance Marketplace. This number should be less than or equal to
        /// the instance count associated with the Reserved instance ID specified in this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 InstanceCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list specifying the price of the Reserved instance for each month remaining in the
        /// Reserved instance term.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("PriceSchedules","PricingSchedules")]
        public Amazon.EC2.Model.PriceScheduleSpecification[] PriceSchedule { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the active Reserved instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedInstancesId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReservedInstancesId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2ReservedInstancesListing (CreateReservedInstancesListing)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            if (this.PriceSchedule != null)
            {
                context.PriceSchedules = new List<Amazon.EC2.Model.PriceScheduleSpecification>(this.PriceSchedule);
            }
            context.ReservedInstancesId = this.ReservedInstancesId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.EC2.Model.CreateReservedInstancesListingRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.InstanceCount != null)
            {
                request.InstanceCount = cmdletContext.InstanceCount.Value;
            }
            if (cmdletContext.PriceSchedules != null)
            {
                request.PriceSchedules = cmdletContext.PriceSchedules;
            }
            if (cmdletContext.ReservedInstancesId != null)
            {
                request.ReservedInstancesId = cmdletContext.ReservedInstancesId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateReservedInstancesListing(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReservedInstancesListings;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientToken { get; set; }
            public System.Int32? InstanceCount { get; set; }
            public List<Amazon.EC2.Model.PriceScheduleSpecification> PriceSchedules { get; set; }
            public System.String ReservedInstancesId { get; set; }
        }
        
    }
}
