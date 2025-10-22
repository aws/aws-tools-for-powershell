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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Describes the specified network interfaces or all your network interfaces.
    /// 
    ///  
    /// <para>
    /// If you have a large number of network interfaces, the operation fails unless you use
    /// pagination or one of the following filters: <c>group-id</c>, <c>mac-address</c>, <c>private-dns-name</c>,
    /// <c>private-ip-address</c>, <c>subnet-id</c>, or <c>vpc-id</c>.
    /// </para><important><para>
    /// We strongly recommend using only paginated requests. Unpaginated requests are susceptible
    /// to throttling and timeouts.
    /// </para></important><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2NetworkInterface")]
    [OutputType("Amazon.EC2.Model.NetworkInterface")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeNetworkInterfaces API operation.", Operation = new[] {"DescribeNetworkInterfaces"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeNetworkInterfacesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.NetworkInterface or Amazon.EC2.Model.DescribeNetworkInterfacesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.NetworkInterface objects.",
        "The service call response (type Amazon.EC2.Model.DescribeNetworkInterfacesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2NetworkInterfaceCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><c>association.allocation-id</c> - The allocation ID returned when you allocated
        /// the Elastic IP address (IPv4) for your network interface.</para></li><li><para><c>association.association-id</c> - The association ID returned when the network
        /// interface was associated with an IPv4 address.</para></li><li><para><c>addresses.association.owner-id</c> - The owner ID of the addresses associated
        /// with the network interface.</para></li><li><para><c>addresses.association.public-ip</c> - The association ID returned when the network
        /// interface was associated with the Elastic IP address (IPv4).</para></li><li><para><c>addresses.primary</c> - Whether the private IPv4 address is the primary IP address
        /// associated with the network interface. </para></li><li><para><c>addresses.private-ip-address</c> - The private IPv4 addresses associated with
        /// the network interface.</para></li><li><para><c>association.ip-owner-id</c> - The owner of the Elastic IP address (IPv4) associated
        /// with the network interface.</para></li><li><para><c>association.public-ip</c> - The address of the Elastic IP address (IPv4) bound
        /// to the network interface.</para></li><li><para><c>association.public-dns-name</c> - The public DNS name for the network interface
        /// (IPv4).</para></li><li><para><c>attachment.attach-time</c> - The time that the network interface was attached
        /// to an instance.</para></li><li><para><c>attachment.attachment-id</c> - The ID of the interface attachment.</para></li><li><para><c>attachment.delete-on-termination</c> - Indicates whether the attachment is deleted
        /// when an instance is terminated.</para></li><li><para><c>attachment.device-index</c> - The device index to which the network interface
        /// is attached.</para></li><li><para><c>attachment.instance-id</c> - The ID of the instance to which the network interface
        /// is attached.</para></li><li><para><c>attachment.instance-owner-id</c> - The owner ID of the instance to which the network
        /// interface is attached.</para></li><li><para><c>attachment.status</c> - The status of the attachment (<c>attaching</c> | <c>attached</c>
        /// | <c>detaching</c> | <c>detached</c>).</para></li><li><para><c>availability-zone</c> - The Availability Zone of the network interface.</para></li><li><para><c>availability-zone-id</c> - The ID of the Availability Zone of the network interface.</para></li><li><para><c>description</c> - The description of the network interface.</para></li><li><para><c>group-id</c> - The ID of a security group associated with the network interface.</para></li><li><para><c>ipv6-addresses.ipv6-address</c> - An IPv6 address associated with the network
        /// interface.</para></li><li><para><c>interface-type</c> - The type of network interface (<c>api_gateway_managed</c>
        /// | <c>aws_codestar_connections_managed</c> | <c>branch</c> | <c>ec2_instance_connect_endpoint</c>
        /// | <c>efa</c> | <c>efa-only</c> | <c>efs</c> | <c>evs</c> | <c>gateway_load_balancer</c>
        /// | <c>gateway_load_balancer_endpoint</c> | <c>global_accelerator_managed</c> | <c>interface</c>
        /// | <c>iot_rules_managed</c> | <c>lambda</c> | <c>load_balancer</c> | <c>nat_gateway</c>
        /// | <c>network_load_balancer</c> | <c>quicksight</c> | <c>transit_gateway</c> | <c>trunk</c>
        /// | <c>vpc_endpoint</c>).</para></li><li><para><c>mac-address</c> - The MAC address of the network interface.</para></li><li><para><c>network-interface-id</c> - The ID of the network interface.</para></li><li><para><c>operator.managed</c> - A Boolean that indicates whether this is a managed network
        /// interface.</para></li><li><para><c>operator.principal</c> - The principal that manages the network interface. Only
        /// valid for managed network interfaces, where <c>managed</c> is <c>true</c>.</para></li><li><para><c>owner-id</c> - The Amazon Web Services account ID of the network interface owner.</para></li><li><para><c>private-dns-name</c> - The private DNS name of the network interface (IPv4).</para></li><li><para><c>private-ip-address</c> - The private IPv4 address or addresses of the network
        /// interface.</para></li><li><para><c>requester-id</c> - The alias or Amazon Web Services account ID of the principal
        /// or service that created the network interface.</para></li><li><para><c>requester-managed</c> - Indicates whether the network interface is being managed
        /// by an Amazon Web Services service (for example, Amazon Web Services Management Console,
        /// Auto Scaling, and so on).</para></li><li><para><c>source-dest-check</c> - Indicates whether the network interface performs source/destination
        /// checking. A value of <c>true</c> means checking is enabled, and <c>false</c> means
        /// checking is disabled. The value must be <c>false</c> for the network interface to
        /// perform network address translation (NAT) in your VPC. </para></li><li><para><c>status</c> - The status of the network interface. If the network interface is
        /// not attached to an instance, the status is <c>available</c>; if a network interface
        /// is attached to an instance the status is <c>in-use</c>.</para></li><li><para><c>subnet-id</c> - The ID of the subnet for the network interface.</para></li><li><para><c>tag</c>:&lt;key&gt; - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>vpc-id</c> - The ID of the VPC for the network interface.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The network interface IDs.</para><para>Default: Describes all your network interfaces.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("NetworkInterfaceIds")]
        public System.String[] NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of items to return for this request. To get the next page of items,
        /// make another request with the token returned in the output. You cannot specify this
        /// parameter and the network interface IDs parameter in the same request. For more information,
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkInterfaces'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeNetworkInterfacesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeNetworkInterfacesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkInterfaces";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeNetworkInterfacesResponse, GetEC2NetworkInterfaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
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
            if (this.NetworkInterfaceId != null)
            {
                context.NetworkInterfaceId = new List<System.String>(this.NetworkInterfaceId);
            }
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.EC2.Model.DescribeNetworkInterfacesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceIds = cmdletContext.NetworkInterfaceId;
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
            var request = new Amazon.EC2.Model.DescribeNetworkInterfacesRequest();
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceIds = cmdletContext.NetworkInterfaceId;
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
                    int _receivedThisCall = response.NetworkInterfaces?.Count ?? 0;
                    
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
        
        private Amazon.EC2.Model.DescribeNetworkInterfacesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeNetworkInterfacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeNetworkInterfaces");
            try
            {
                return client.DescribeNetworkInterfacesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<Amazon.EC2.Model.Filter> Filter { get; set; }
            public int? MaxResult { get; set; }
            public List<System.String> NetworkInterfaceId { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeNetworkInterfacesResponse, GetEC2NetworkInterfaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkInterfaces;
        }
        
    }
}
