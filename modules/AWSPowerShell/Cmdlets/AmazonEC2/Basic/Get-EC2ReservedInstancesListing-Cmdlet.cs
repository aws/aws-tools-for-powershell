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
    /// Describes your account's Reserved Instance listings in the Reserved Instance Marketplace.
    /// 
    ///  
    /// <para>
    /// The Reserved Instance Marketplace matches sellers who want to resell Reserved Instance
    /// capacity that they no longer need with buyers who want to purchase additional capacity.
    /// Reserved Instances bought and sold through the Reserved Instance Marketplace work
    /// like any other Reserved Instances.
    /// </para><para>
    /// As a seller, you choose to list some or all of your Reserved Instances, and you specify
    /// the upfront price to receive for them. Your Reserved Instances are then listed in
    /// the Reserved Instance Marketplace and are available for purchase.
    /// </para><para>
    /// As a buyer, you specify the configuration of the Reserved Instance to purchase, and
    /// the Marketplace matches what you're searching for with what's available. The Marketplace
    /// first sells the lowest priced Reserved Instances to you, and continues to sell available
    /// Reserved Instance listings to you until your demand is met. You are charged based
    /// on the total price of all of the listings that you purchase.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Reserved
    /// Instance Marketplace</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesListing")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesListing")]
    [AWSCmdlet("Invokes the DescribeReservedInstancesListings operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeReservedInstancesListings"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesListing",
        "This cmdlet returns a collection of ReservedInstancesListing objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesListingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ReservedInstancesListingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>reserved-instances-id</code> - The ID of the Reserved Instances.</para></li><li><para><code>reserved-instances-listing-id</code> - The ID of the Reserved Instances listing.</para></li><li><para><code>status</code> - The status of the Reserved Instance listing (<code>pending</code>
        /// | <code>active</code> | <code>cancelled</code> | <code>closed</code>).</para></li><li><para><code>status-message</code> - The reason for the status.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesId
        /// <summary>
        /// <para>
        /// <para>One or more Reserved Instance IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String ReservedInstancesId { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesListingId
        /// <summary>
        /// <para>
        /// <para>One or more Reserved Instance listing IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReservedInstancesListingId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.ReservedInstancesId = this.ReservedInstancesId;
            context.ReservedInstancesListingId = this.ReservedInstancesListingId;
            
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
            var request = new Amazon.EC2.Model.DescribeReservedInstancesListingsRequest();
            
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.ReservedInstancesId != null)
            {
                request.ReservedInstancesId = cmdletContext.ReservedInstancesId;
            }
            if (cmdletContext.ReservedInstancesListingId != null)
            {
                request.ReservedInstancesListingId = cmdletContext.ReservedInstancesListingId;
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
        
        private static Amazon.EC2.Model.DescribeReservedInstancesListingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesListingsRequest request)
        {
            #if DESKTOP
            return client.DescribeReservedInstancesListings(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeReservedInstancesListingsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public System.String ReservedInstancesId { get; set; }
            public System.String ReservedInstancesListingId { get; set; }
        }
        
    }
}
