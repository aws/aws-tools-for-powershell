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
using System.Threading;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes Reserved Instance offerings that are available for purchase. With Reserved
    /// Instances, you purchase the right to launch instances for a period of time. During
    /// that time period, you do not receive insufficient capacity errors, and you pay a lower
    /// usage rate than the rate charged for On-Demand instances for the actual time used.
    /// 
    ///  
    /// <para>
    /// If you have listed your own Reserved Instances for sale in the Reserved Instance Marketplace,
    /// they will be excluded from these results. This is to ensure that you do not purchase
    /// your own Reserved Instances.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ri-market-general.html">Sell
    /// in the Reserved Instance Marketplace</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2ReservedInstancesOffering")]
    [OutputType("Amazon.EC2.Model.ReservedInstancesOffering")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeReservedInstancesOfferings API operation.", Operation = new[] {"DescribeReservedInstancesOfferings"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.ReservedInstancesOffering or Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.ReservedInstancesOffering objects.",
        "The service call response (type Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2ReservedInstancesOfferingCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zone in which the Reserved Instance can be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>availability-zone</c> - The Availability Zone where the Reserved Instance can
        /// be used.</para></li><li><para><c>duration</c> - The duration of the Reserved Instance (for example, one year or
        /// three years), in seconds (<c>31536000</c> | <c>94608000</c>).</para></li><li><para><c>fixed-price</c> - The purchase price of the Reserved Instance (for example, 9800.0).</para></li><li><para><c>instance-type</c> - The instance type that is covered by the reservation.</para></li><li><para><c>marketplace</c> - Set to <c>true</c> to show only Reserved Instance Marketplace
        /// offerings. When this filter is not used, which is the default behavior, all offerings
        /// from both Amazon Web Services and the Reserved Instance Marketplace are listed.</para></li><li><para><c>product-description</c> - The Reserved Instance product platform description (<c>Linux/UNIX</c>
        /// | <c>Linux with SQL Server Standard</c> | <c>Linux with SQL Server Web</c> | <c>Linux
        /// with SQL Server Enterprise</c> | <c>SUSE Linux</c> | <c>Red Hat Enterprise Linux</c>
        /// | <c>Red Hat Enterprise Linux with HA</c> | <c>Windows</c> | <c>Windows with SQL Server
        /// Standard</c> | <c>Windows with SQL Server Web</c> | <c>Windows with SQL Server Enterprise</c>).</para></li><li><para><c>reserved-instances-offering-id</c> - The Reserved Instances offering ID.</para></li><li><para><c>scope</c> - The scope of the Reserved Instance (<c>Availability Zone</c> or <c>Region</c>).</para></li><li><para><c>usage-price</c> - The usage price of the Reserved Instance, per hour (for example,
        /// 0.84).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncludeMarketplace
        /// <summary>
        /// <para>
        /// <para>Include Reserved Instance Marketplace offerings in the response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeMarketplace { get; set; }
        #endregion
        
        #region Parameter InstanceTenancy
        /// <summary>
        /// <para>
        /// <para>The tenancy of the instances covered by the reservation. A Reserved Instance with
        /// a tenancy of <c>dedicated</c> is applied to instances that run in a VPC on single-tenant
        /// hardware (i.e., Dedicated Instances).</para><para><b>Important:</b> The <c>host</c> value cannot be used with this parameter. Use the
        /// <c>default</c> or <c>dedicated</c> values only.</para><para>Default: <c>default</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.Tenancy")]
        public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance type that the reservation will cover (for example, <c>m1.small</c>).
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Amazon
        /// EC2 instance types</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.InstanceType")]
        public Amazon.EC2.InstanceType InstanceType { get; set; }
        #endregion
        
        #region Parameter MaxDuration
        /// <summary>
        /// <para>
        /// <para>The maximum duration (in seconds) to filter when searching for offerings.</para><para>Default: 94608000 (3 years)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MaxDuration { get; set; }
        #endregion
        
        #region Parameter MaxInstanceCount
        /// <summary>
        /// <para>
        /// <para>The maximum number of instances to filter when searching for offerings.</para><para>Default: 20</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxInstanceCount { get; set; }
        #endregion
        
        #region Parameter MinDuration
        /// <summary>
        /// <para>
        /// <para>The minimum duration (in seconds) to filter when searching for offerings.</para><para>Default: 2592000 (1 month)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? MinDuration { get; set; }
        #endregion
        
        #region Parameter OfferingClass
        /// <summary>
        /// <para>
        /// <para>The offering class of the Reserved Instance. Can be <c>standard</c> or <c>convertible</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OfferingClassType")]
        public Amazon.EC2.OfferingClassType OfferingClass { get; set; }
        #endregion
        
        #region Parameter OfferingType
        /// <summary>
        /// <para>
        /// <para>The Reserved Instance offering type. If you are using tools that predate the 2011-11-01
        /// API version, you only have access to the <c>Medium Utilization</c> Reserved Instance
        /// offering type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.OfferingTypeValues")]
        public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
        #endregion
        
        #region Parameter ProductDescription
        /// <summary>
        /// <para>
        /// <para>The Reserved Instance product platform description. Instances that include <c>(Amazon
        /// VPC)</c> in the description are for use with Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.RIProductDescription")]
        public Amazon.EC2.RIProductDescription ProductDescription { get; set; }
        #endregion
        
        #region Parameter ReservedInstancesOfferingId
        /// <summary>
        /// <para>
        /// <para>One or more Reserved Instances offering IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("ReservedInstancesId","ReservedInstancesOfferingIds")]
        public System.String[] ReservedInstancesOfferingId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for the request in a single page. The remaining
        /// results of the initial request can be seen by sending another request with the returned
        /// <c>NextToken</c> value. The maximum is 100.</para><para>Default: 100</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to retrieve the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReservedInstancesOfferings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReservedInstancesOfferings";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse, GetEC2ReservedInstancesOfferingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            context.IncludeMarketplace = this.IncludeMarketplace;
            context.InstanceTenancy = this.InstanceTenancy;
            context.InstanceType = this.InstanceType;
            context.MaxDuration = this.MaxDuration;
            context.MaxInstanceCount = this.MaxInstanceCount;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MinDuration = this.MinDuration;
            context.NextToken = this.NextToken;
            context.OfferingClass = this.OfferingClass;
            context.OfferingType = this.OfferingType;
            context.ProductDescription = this.ProductDescription;
            if (this.ReservedInstancesOfferingId != null)
            {
                context.ReservedInstancesOfferingId = new List<System.String>(this.ReservedInstancesOfferingId);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeReservedInstancesOfferingsRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MinDuration != null)
            {
                request.MinDuration = cmdletContext.MinDuration.Value;
            }
            if (cmdletContext.OfferingClass != null)
            {
                request.OfferingClass = cmdletContext.OfferingClass;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedInstancesOfferingId != null)
            {
                request.ReservedInstancesOfferingIds = cmdletContext.ReservedInstancesOfferingId;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeReservedInstancesOfferingsRequest();
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
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
            if (cmdletContext.OfferingClass != null)
            {
                request.OfferingClass = cmdletContext.OfferingClass;
            }
            if (cmdletContext.OfferingType != null)
            {
                request.OfferingType = cmdletContext.OfferingType;
            }
            if (cmdletContext.ProductDescription != null)
            {
                request.ProductDescription = cmdletContext.ProductDescription;
            }
            if (cmdletContext.ReservedInstancesOfferingId != null)
            {
                request.ReservedInstancesOfferingIds = cmdletContext.ReservedInstancesOfferingId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(_emitLimit.Value);
                }
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    int _receivedThisCall = response.ReservedInstancesOfferings?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeReservedInstancesOfferingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeReservedInstancesOfferings");
            try
            {
                return client.DescribeReservedInstancesOfferingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public System.Boolean? IncludeMarketplace { get; set; }
            public Amazon.EC2.Tenancy InstanceTenancy { get; set; }
            public Amazon.EC2.InstanceType InstanceType { get; set; }
            public System.Int64? MaxDuration { get; set; }
            public System.Int32? MaxInstanceCount { get; set; }
            public int? MaxResult { get; set; }
            public System.Int64? MinDuration { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.EC2.OfferingClassType OfferingClass { get; set; }
            public Amazon.EC2.OfferingTypeValues OfferingType { get; set; }
            public Amazon.EC2.RIProductDescription ProductDescription { get; set; }
            public List<System.String> ReservedInstancesOfferingId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeReservedInstancesOfferingsResponse, GetEC2ReservedInstancesOfferingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReservedInstancesOfferings;
        }
        
    }
}
