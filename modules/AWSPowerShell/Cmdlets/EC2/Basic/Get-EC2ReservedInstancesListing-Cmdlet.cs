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
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Sell
    /// in the Reserved Instance Marketplace</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesListing")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesListing")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeReservedInstancesListings API operation.", Operation = new[] {"DescribeReservedInstancesListings"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeReservedInstancesListingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesListing or Amazon.EC2.Model.DescribeReservedInstancesListingsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ReservedInstancesListing objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesListingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2ReservedInstancesListingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>reserved-instances-id</c> - The ID of the Reserved Instances.</para></li><li><para><c>reserved-instances-listing-id</c> - The ID of the Reserved Instances listing.</para></li><li><para><c>status</c> - The status of the Reserved Instance listing (<c>pending</c> | <c>active</c>
        /// | <c>cancelled</c> | <c>closed</c>).</para></li><li><para><c>status-message</c> - The reason for the status.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstancesListings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeReservedInstancesListingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeReservedInstancesListingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstancesListings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReservedInstancesListingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReservedInstancesListingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReservedInstancesListingId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeReservedInstancesListingsResponse, GetEC2ReservedInstancesListingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReservedInstancesListingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
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
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
        
        private Amazon.EC2.Model.DescribeReservedInstancesListingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesListingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeReservedInstancesListings");
            try
            {
                #if DESKTOP
                return client.DescribeReservedInstancesListings(request);
                #elif CORECLR
                return client.DescribeReservedInstancesListingsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.String ReservedInstancesId { get; set; }
            public System.String ReservedInstancesListingId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeReservedInstancesListingsResponse, GetEC2ReservedInstancesListingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstancesListings;
        }
        
    }
}
