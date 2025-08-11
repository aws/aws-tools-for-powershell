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
    /// Describes the specified Spot Instance requests.
    /// 
    ///  
    /// <para>
    /// You can use <c>DescribeSpotInstanceRequests</c> to find a running Spot Instance by
    /// examining the response. If the status of the Spot Instance is <c>fulfilled</c>, the
    /// instance ID appears in the response and contains the identifier of the instance. Alternatively,
    /// you can use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeInstances">DescribeInstances</a>
    /// with a filter to look for instances where the instance lifecycle is <c>spot</c>.
    /// </para><para>
    /// We recommend that you set <c>MaxResults</c> to a value between 5 and 1000 to limit
    /// the number of items returned. This paginates the output, which makes the list more
    /// manageable and returns the items faster. If the list of items exceeds your <c>MaxResults</c>
    /// value, then that number of items is returned along with a <c>NextToken</c> value that
    /// can be passed to a subsequent <c>DescribeSpotInstanceRequests</c> request to retrieve
    /// the remaining items.
    /// </para><para>
    /// Spot Instance requests are deleted four hours after they are canceled and their instances
    /// are terminated.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2SpotInstanceRequest")]
    [OutputType("Amazon.EC2.Model.SpotInstanceRequest")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeSpotInstanceRequests API operation.", Operation = new[] {"DescribeSpotInstanceRequests"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.SpotInstanceRequest or Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.SpotInstanceRequest objects.",
        "The service call response (type Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2SpotInstanceRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>availability-zone-group</c> - The Availability Zone group.</para></li><li><para><c>create-time</c> - The time stamp when the Spot Instance request was created.</para></li><li><para><c>fault-code</c> - The fault code related to the request.</para></li><li><para><c>fault-message</c> - The fault message related to the request.</para></li><li><para><c>instance-id</c> - The ID of the instance that fulfilled the request.</para></li><li><para><c>launch-group</c> - The Spot Instance launch group.</para></li><li><para><c>launch.block-device-mapping.delete-on-termination</c> - Indicates whether the
        /// EBS volume is deleted on instance termination.</para></li><li><para><c>launch.block-device-mapping.device-name</c> - The device name for the volume in
        /// the block device mapping (for example, <c>/dev/sdh</c> or <c>xvdh</c>).</para></li><li><para><c>launch.block-device-mapping.snapshot-id</c> - The ID of the snapshot for the EBS
        /// volume.</para></li><li><para><c>launch.block-device-mapping.volume-size</c> - The size of the EBS volume, in GiB.</para></li><li><para><c>launch.block-device-mapping.volume-type</c> - The type of EBS volume: <c>gp2</c>
        /// or <c>gp3</c> for General Purpose SSD, <c>io1</c> or <c>io2</c> for Provisioned IOPS
        /// SSD, <c>st1</c> for Throughput Optimized HDD, <c>sc1</c> for Cold HDD, or <c>standard</c>
        /// for Magnetic.</para></li><li><para><c>launch.group-id</c> - The ID of the security group for the instance.</para></li><li><para><c>launch.group-name</c> - The name of the security group for the instance.</para></li><li><para><c>launch.image-id</c> - The ID of the AMI.</para></li><li><para><c>launch.instance-type</c> - The type of instance (for example, <c>m3.medium</c>).</para></li><li><para><c>launch.kernel-id</c> - The kernel ID.</para></li><li><para><c>launch.key-name</c> - The name of the key pair the instance launched with.</para></li><li><para><c>launch.monitoring-enabled</c> - Whether detailed monitoring is enabled for the
        /// Spot Instance.</para></li><li><para><c>launch.ramdisk-id</c> - The RAM disk ID.</para></li><li><para><c>launched-availability-zone</c> - The Availability Zone in which the request is
        /// launched.</para></li><li><para><c>launched-availability-zone-id</c> - The ID of the Availability Zone in which the
        /// request is launched.</para></li><li><para><c>network-interface.addresses.primary</c> - Indicates whether the IP address is
        /// the primary private IP address.</para></li><li><para><c>network-interface.delete-on-termination</c> - Indicates whether the network interface
        /// is deleted when the instance is terminated.</para></li><li><para><c>network-interface.description</c> - A description of the network interface.</para></li><li><para><c>network-interface.device-index</c> - The index of the device for the network interface
        /// attachment on the instance.</para></li><li><para><c>network-interface.group-id</c> - The ID of the security group associated with
        /// the network interface.</para></li><li><para><c>network-interface.network-interface-id</c> - The ID of the network interface.</para></li><li><para><c>network-interface.private-ip-address</c> - The primary private IP address of the
        /// network interface.</para></li><li><para><c>network-interface.subnet-id</c> - The ID of the subnet for the instance.</para></li><li><para><c>product-description</c> - The product description associated with the instance
        /// (<c>Linux/UNIX</c> | <c>Windows</c>).</para></li><li><para><c>spot-instance-request-id</c> - The Spot Instance request ID.</para></li><li><para><c>spot-price</c> - The maximum hourly price for any Spot Instance launched to fulfill
        /// the request.</para></li><li><para><c>state</c> - The state of the Spot Instance request (<c>open</c> | <c>active</c>
        /// | <c>closed</c> | <c>cancelled</c> | <c>failed</c>). Spot request status information
        /// can help you track your Amazon EC2 Spot Instance requests. For more information, see
        /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-request-status.html">Spot
        /// request status</a> in the <i>Amazon EC2 User Guide</i>.</para></li><li><para><c>status-code</c> - The short code describing the most recent evaluation of your
        /// Spot Instance request.</para></li><li><para><c>status-message</c> - The message explaining the status of the Spot Instance request.</para></li><li><para><c>tag:&lt;key&gt;</c> - The key/value combination of a tag assigned to the resource.
        /// Use the tag key in the filter name and the tag value as the filter value. For example,
        /// to find all resources that have a tag with the key <c>Owner</c> and the value <c>TeamA</c>,
        /// specify <c>tag:Owner</c> for the filter name and <c>TeamA</c> for the filter value.</para></li><li><para><c>tag-key</c> - The key of a tag assigned to the resource. Use this filter to find
        /// all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><c>type</c> - The type of Spot Instance request (<c>one-time</c> | <c>persistent</c>).</para></li><li><para><c>valid-from</c> - The start date of the request.</para></li><li><para><c>valid-until</c> - The end date of the request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SpotInstanceRequestId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Spot Instance requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SpotInstanceRequestIds")]
        public System.String[] SpotInstanceRequestId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SpotInstanceRequests'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SpotInstanceRequests";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SpotInstanceRequestId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SpotInstanceRequestId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SpotInstanceRequestId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse, GetEC2SpotInstanceRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SpotInstanceRequestId;
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
            if (this.SpotInstanceRequestId != null)
            {
                context.SpotInstanceRequestId = new List<System.String>(this.SpotInstanceRequestId);
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
            var request = new Amazon.EC2.Model.DescribeSpotInstanceRequestsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SpotInstanceRequestId != null)
            {
                request.SpotInstanceRequestIds = cmdletContext.SpotInstanceRequestId;
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
            var request = new Amazon.EC2.Model.DescribeSpotInstanceRequestsRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.SpotInstanceRequestId != null)
            {
                request.SpotInstanceRequestIds = cmdletContext.SpotInstanceRequestId;
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
                    int _receivedThisCall = response.SpotInstanceRequests.Count;
                    
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
        
        private Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeSpotInstanceRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeSpotInstanceRequests");
            try
            {
                #if DESKTOP
                return client.DescribeSpotInstanceRequests(request);
                #elif CORECLR
                return client.DescribeSpotInstanceRequestsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SpotInstanceRequestId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse, GetEC2SpotInstanceRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SpotInstanceRequests;
        }
        
    }
}
