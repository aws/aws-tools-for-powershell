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
    /// Creates a listing for Amazon EC2 Standard Reserved Instances to be sold in the Reserved
    /// Instance Marketplace. You can submit one Standard Reserved Instance listing at a time.
    /// To get a list of your Standard Reserved Instances, you can use the <a>DescribeReservedInstances</a>
    /// operation.
    /// 
    ///  <note><para>
    /// Only Standard Reserved Instances with a capacity reservation can be sold in the Reserved
    /// Instance Marketplace. Convertible Reserved Instances and Standard Reserved Instances
    /// with a regional benefit cannot be sold.
    /// </para></note><para>
    /// The Reserved Instance Marketplace matches sellers who want to resell Standard Reserved
    /// Instance capacity that they no longer need with buyers who want to purchase additional
    /// capacity. Reserved Instances bought and sold through the Reserved Instance Marketplace
    /// work like any other Reserved Instances.
    /// </para><para>
    /// To sell your Standard Reserved Instances, you must first register as a seller in the
    /// Reserved Instance Marketplace. After completing the registration process, you can
    /// create a Reserved Instance Marketplace listing of some or all of your Standard Reserved
    /// Instances, and specify the upfront price to receive for them. Your Standard Reserved
    /// Instance listings then become available for purchase. To view the details of your
    /// Standard Reserved Instance listing, you can use the <a>DescribeReservedInstancesListings</a>
    /// operation.
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
    public partial class NewEC2ReservedInstancesListingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of your listings.
        /// This helps avoid duplicate listings. For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter InstanceCount
        /// <summary>
        /// <para>
        /// <para>The number of instances that are a part of a Reserved Instance account to be listed
        /// in the Reserved Instance Marketplace. This number should be less than or equal to
        /// the instance count associated with the Reserved Instance ID specified in this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.Int32 InstanceCount { get; set; }
        #endregion
        
        #region Parameter PriceSchedule
        /// <summary>
        /// <para>
        /// <para>A list specifying the price of the Standard Reserved Instance for each month remaining
        /// in the Reserved Instance term.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("PriceSchedules","PricingSchedules")]
        public Amazon.EC2.Model.PriceScheduleSpecification[] PriceSchedule { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesId
        /// <summary>
        /// <para>
        /// <para>The ID of the active Standard Reserved Instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedInstancesId { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("InstanceCount"))
                context.InstanceCount = this.InstanceCount;
            if (this.PriceSchedule != null)
            {
                context.PriceSchedules = new List<Amazon.EC2.Model.PriceScheduleSpecification>(this.PriceSchedule);
            }
            context.ReservedInstancesId = this.ReservedInstancesId;
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.CreateReservedInstancesListingResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateReservedInstancesListingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud", "CreateReservedInstancesListing");
            #if DESKTOP
            return client.CreateReservedInstancesListing(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateReservedInstancesListingAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
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
