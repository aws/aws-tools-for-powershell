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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes your subnets. The default is to describe all your subnets. Alternatively,
    /// you can specify specific subnet IDs or filter the results to include only the subnets
    /// that match specific criteria.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/configure-subnets.html">Subnets</a>
    /// in the <i>Amazon VPC User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2Subnet")]
    [OutputType("Amazon.EC2.Model.Subnet")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeSubnets API operation.", Operation = new[] {"DescribeSubnets"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeSubnetsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.Subnet or Amazon.EC2.Model.DescribeSubnetsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.Subnet objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSubnetsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2SubnetCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>availability-zone</c> - The Availability Zone for the subnet. You can also use
        /// <c>availabilityZone</c> as the filter name.</para></li><li><para><c>availability-zone-id</c> - The ID of the Availability Zone for the subnet. You
        /// can also use <c>availabilityZoneId</c> as the filter name.</para></li><li><para><c>available-ip-address-count</c> - The number of IPv4 addresses in the subnet that
        /// are available.</para></li><li><para><c>cidr-block</c> - The IPv4 CIDR block of the subnet. The CIDR block you specify
        /// must exactly match the subnet's CIDR block for information to be returned for the
        /// subnet. You can also use <c>cidr</c> or <c>cidrBlock</c> as the filter names.</para></li><li><para><c>customer-owned-ipv4-pool</c> - The customer-owned IPv4 address pool associated
        /// with the subnet.</para></li><li><para><c>default-for-az</c> - Indicates whether this is the default subnet for the Availability
        /// Zone (<c>true</c> | <c>false</c>). You can also use <c>defaultForAz</c> as the filter
        /// name.</para></li><li><para><c>enable-dns64</c> - Indicates whether DNS queries made to the Amazon-provided DNS
        /// Resolver in this subnet should return synthetic IPv6 addresses for IPv4-only destinations.</para></li><li><para><c>enable-lni-at-device-index</c> - Indicates the device position for local network
        /// interfaces in this subnet. For example, <c>1</c> indicates local network interfaces
        /// in this subnet are the secondary network interface (eth1). </para></li><li><para><c>ipv6-cidr-block-association.ipv6-cidr-block</c> - An IPv6 CIDR block associated
        /// with the subnet.</para></li><li><para><c>ipv6-cidr-block-association.association-id</c> - An association ID for an IPv6
        /// CIDR block associated with the subnet.</para></li><li><para><c>ipv6-cidr-block-association.state</c> - The state of an IPv6 CIDR block associated
        /// with the subnet.</para></li><li><para><c>ipv6-native</c> - Indicates whether this is an IPv6 only subnet (<c>true</c> |
        /// <c>false</c>).</para></li><li><para><c>map-customer-owned-ip-on-launch</c> - Indicates whether a network interface created
        /// in this subnet (including a network interface created by <a>RunInstances</a>) receives
        /// a customer-owned IPv4 address.</para></li><li><para><c>map-public-ip-on-launch</c> - Indicates whether instances launched in this subnet
        /// receive a public IPv4 address.</para></li><li><para><c>outpost-arn</c> - The Amazon Resource Name (ARN) of the Outpost.</para></li><li><para><c>owner-id</c> - The ID of the Amazon Web Services account that owns the subnet.</para></li><li><para><c>private-dns-name-options-on-launch.hostname-type</c> - The type of hostname to
        /// assign to instances in the subnet at launch. For IPv4-only and dual-stack (IPv4 and
        /// IPv6) subnets, an instance DNS name can be based on the instance IPv4 address (ip-name)
        /// or the instance ID (resource-name). For IPv6 only subnets, an instance DNS name must
        /// be based on the instance ID (resource-name).</para></li><li><para><c>private-dns-name-options-on-launch.enable-resource-name-dns-a-record</c> - Indicates
        /// whether to respond to DNS queries for instance hostnames with DNS A records.</para></li><li><para><c>private-dns-name-options-on-launch.enable-resource-name-dns-aaaa-record</c> -
        /// Indicates whether to respond to DNS queries for instance hostnames with DNS AAAA records.</para></li><li><para><c>state</c> - The state of the subnet (<c>pending</c> | <c>available</c>).</para></li><li><para><c>subnet-arn</c> - The Amazon Resource Name (ARN) of the subnet.</para></li><li><para><c>subnet-id</c> - The ID of the subnet.</para></li><li><para><c>tag</c> - The key/value combination of a tag assigned to the resource. Use the
        /// tag key in the filter name and the tag value as the filter value. For example, to
        /// find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>vpc-id</c> - The ID of the VPC for the subnet.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets.</para><para>Default: Describes all your subnets.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Query-Requests.html#api-pagination">Pagination</a>.</para>
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
        /// <para>The token returned from a previous paginated request. Pagination continues from the
        /// end of the items returned by the previous request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Subnets'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeSubnetsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeSubnetsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Subnets";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SubnetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SubnetId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeSubnetsResponse, GetEC2SubnetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SubnetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
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
            context.NextToken = this.NextToken;
            if (this.SubnetId != null)
            {
                context.SubnetId = new List<System.String>(this.SubnetId);
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSubnetsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.EC2.Model.DescribeSubnetsRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetIds = cmdletContext.SubnetId;
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
                // The service has a maximum page size of 1000. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 1000 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(1000, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
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
                    int _receivedThisCall = response.Subnets.Count;
                    
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 5));
            
            
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
        
        private Amazon.EC2.Model.DescribeSubnetsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSubnetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeSubnets");
            try
            {
                #if DESKTOP
                return client.DescribeSubnets(request);
                #elif CORECLR
                return client.DescribeSubnetsAsync(request).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> SubnetId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeSubnetsResponse, GetEC2SubnetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Subnets;
        }
        
    }
}
