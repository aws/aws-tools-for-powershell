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
    /// Describes Reserved instance offerings that are available for purchase. With Reserved
    /// instances, you purchase the right to launch instances for a period of time. During
    /// that time period, you do not receive insufficient capacity errors, and you pay a lower
    /// usage rate than the rate charged for On-Demand instances for the actual time used.
    /// 
    ///  
    /// <para>
    /// If you have listed your own Reserved instances for sale in the Reserved Instance Marketplace,
    /// they will be excluded from these results. This is to ensure that you do not purchase
    /// your own Reserved instances.
    /// </para><para>
    /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Reserved
    /// Instance Marketplace</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesOffering")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesOffering")]
    [AWSCmdlet("Invokes the DescribeReservedInstancesOfferings operation against Amazon Elastic Compute Cloud.", Operation = new[] {"DescribeReservedInstancesOfferings"})]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesOffering",
        "This cmdlet returns a collection of ReservedInstancesOffering objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextToken (type System.String)"
    )]
    public class GetEC2ReservedInstancesOfferingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which the Reserved instance can be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone</code> - The Availability Zone where the Reserved instance
        /// can be used.</para></li><li><para><code>duration</code> - The duration of the Reserved instance (for example, one year
        /// or three years), in seconds (<code>31536000</code> | <code>94608000</code>).</para></li><li><para><code>fixed-price</code> - The purchase price of the Reserved instance (for example,
        /// 9800.0).</para></li><li><para><code>instance-type</code> - The instance type that is covered by the reservation.</para></li><li><para><code>marketplace</code> - Set to <code>true</code> to show only Reserved Instance
        /// Marketplace offerings. When this filter is not used, which is the default behavior,
        /// all offerings from both AWS and the Reserved Instance Marketplace are listed.</para></li><li><para><code>product-description</code> - The Reserved instance product platform description.
        /// Instances that include <code>(Amazon VPC)</code> in the product platform description
        /// will only be displayed to EC2-Classic account holders and are for use with Amazon
        /// VPC. (<code>Linux/UNIX</code> | <code>Linux/UNIX (Amazon VPC)</code> | <code>SUSE
        /// Linux</code> | <code>SUSE Linux (Amazon VPC)</code> | <code>Red Hat Enterprise Linux</code>
        /// | <code>Red Hat Enterprise Linux (Amazon VPC)</code> | <code>Windows</code> | <code>Windows
        /// (Amazon VPC)</code> | <code>Windows with SQL Server Standard</code> | <code>Windows
        /// with SQL Server Standard (Amazon VPC)</code> | <code>Windows with SQL Server Web</code>
        /// | <code> Windows with SQL Server Web (Amazon VPC)</code> | <code>Windows with SQL
        /// Server Enterprise</code> | <code>Windows with SQL Server Enterprise (Amazon VPC)</code>)
        /// </para></li><li><para><code>reserved-instances-offering-id</code> - The Reserved instances' offering ID.</para></li><li><para><code>usage-price</code> - The usage price of the Reserved instance, per hour (for
        /// example, 0.84).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Include Reserved Instance Marketplace offerings in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean IncludeMarketplace { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instances covered by the reservation. A Reserved instance with
        /// a tenancy of <code>dedicated</code> is applied to instances that run in a VPC on single-tenant
        /// hardware (i.e., Dedicated instances).</para><para>Default: <code>default</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The instance type that the reservation will cover (for example, <code>m1.small</code>).
        /// For more information, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// Types</a> in the <i>Amazon Elastic Compute Cloud User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public Amazon.EC2.InstanceType InstanceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum duration (in seconds) to filter when searching for offerings.</para><para>Default: 94608000 (3 years)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 MaxDuration { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances to filter when searching for offerings.</para><para>Default: 20</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxInstanceCount { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The minimum duration (in seconds) to filter when searching for offerings.</para><para>Default: 2592000 (1 month)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int64 MinDuration { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Reserved instance offering type. If you are using tools that predate the 2011-11-01
        /// API version, you only have access to the <code>Medium Utilization</code> Reserved
        /// instance offering type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Reserved instance product platform description. Instances that include <code>(Amazon
        /// VPC)</code> in the description are for use with Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.EC2.RIProductDescription ProductDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>One or more Reserved instances offering IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ReservedInstancesId","ReservedInstancesOfferingIds")]
        public System.String[] ReservedInstancesOfferingId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for the request in a single page. The remaining
        /// results of the initial request can be seen by sending another request with the returned
        /// <code>NextToken</code> value. The maximum is 100.</para><para>Default: 100</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems","MaxResults")]
        public int MaxResult { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AvailabilityZone = this.AvailabilityZone;
            if (this.Filter != null)
            {
                context.Filters = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (ParameterWasBound("IncludeMarketplace"))
                context.IncludeMarketplace = this.IncludeMarketplace;
            context.InstanceTenancy = this.InstanceTenancy;
            context.InstanceType = this.InstanceType;
            if (ParameterWasBound("MaxDuration"))
                context.MaxDuration = this.MaxDuration;
            if (ParameterWasBound("MaxInstanceCount"))
                context.MaxInstanceCount = this.MaxInstanceCount;
            if (ParameterWasBound("MaxResult"))
                context.MaxResults = this.MaxResult;
            if (ParameterWasBound("MinDuration"))
                context.MinDuration = this.MinDuration;
            context.NextToken = this.NextToken;
            context.OfferingType = this.OfferingType;
            context.ProductDescription = this.ProductDescription;
            if (this.ReservedInstancesOfferingId != null)
            {
                context.ReservedInstancesOfferingIds = new List<System.String>(this.ReservedInstancesOfferingId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeReservedInstancesOfferingsRequest();
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Filters != null)
            {
                request.Filters = cmdletContext.Filters;
            }
            if (cmdletContext.IncludeMarketplace != null)
            {
                request.IncludeMarketplace = cmdletContext.IncludeMarketplace.Value;
            }
            if (cmdletContext.InstanceTenancy != null)
            {
                request.InstanceTenancy = cmdletContext.InstanceTenancy;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceType = cmdletContext.InstanceType;
            }
            if (cmdletContext.MaxDuration != null)
            {
                request.MaxDuration = cmdletContext.MaxDuration.Value;
            }
            if (cmdletContext.MaxInstanceCount != null)
            {
                request.MaxInstanceCount = cmdletContext.MaxInstanceCount.Value;
            }
            if (cmdletContext.MinDuration != null)
            {
                request.MinDuration = cmdletContext.MinDuration.Value;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedInstancesOfferingIds != null)
            {
                request.ReservedInstancesOfferingIds = cmdletContext.ReservedInstancesOfferingIds;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextMarker = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextMarker = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.MaxResults))
            {
                _emitLimit = cmdletContext.MaxResults;
            }
            bool _userControllingPaging = AutoIterationHelpers.HasValue(cmdletContext.NextToken) || AutoIterationHelpers.HasValue(cmdletContext.MaxResults);
            bool _continueIteration = true;
            
            try
            {
                do
                {
                    request.NextToken = _nextMarker;
                    if (AutoIterationHelpers.HasValue(_emitLimit))
                    {
                        request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                    }
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.DescribeReservedInstancesOfferings(request);
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.ReservedInstancesOfferings;
                        notes = new Dictionary<string, object>();
                        notes["NextToken"] = response.NextToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        int _receivedThisCall = response.ReservedInstancesOfferings.Count;
                        if (_userControllingPaging)
                        {
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.NextToken));
                        }
                        
                        _nextMarker = response.NextToken;
                        
                        _retrievedSoFar += _receivedThisCall;
                        if (AutoIterationHelpers.HasValue(_emitLimit) && (_retrievedSoFar == 0 || _retrievedSoFar >= _emitLimit.Value))
                        {
                            _continueIteration = false;
                        }
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                } while (_continueIteration && AutoIterationHelpers.HasValue(_nextMarker));
                
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AvailabilityZone { get; set; }
            public List<Amazon.EC2.Model.Filter> Filters { get; set; }
            public System.Boolean? IncludeMarketplace { get; set; }
            public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
            public Amazon.EC2.InstanceType InstanceType { get; set; }
            public System.Int64? MaxDuration { get; set; }
            public System.Int32? MaxInstanceCount { get; set; }
            public int? MaxResults { get; set; }
            public System.Int64? MinDuration { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
            public Amazon.EC2.RIProductDescription ProductDescription { get; set; }
            public List<System.String> ReservedInstancesOfferingIds { get; set; }
        }
        
    }
}
