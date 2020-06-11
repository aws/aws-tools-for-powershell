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
    /// Describes the specified Spot Instance requests.
    /// 
    ///  
    /// <para>
    /// You can use <code>DescribeSpotInstanceRequests</code> to find a running Spot Instance
    /// by examining the response. If the status of the Spot Instance is <code>fulfilled</code>,
    /// the instance ID appears in the response and contains the identifier of the instance.
    /// Alternatively, you can use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_DescribeInstances">DescribeInstances</a>
    /// with a filter to look for instances where the instance lifecycle is <code>spot</code>.
    /// </para><para>
    /// We recommend that you set <code>MaxResults</code> to a value between 5 and 1000 to
    /// limit the number of results returned. This paginates the output, which makes the list
    /// more manageable and returns the results faster. If the list of results exceeds your
    /// <code>MaxResults</code> value, then that number of results is returned along with
    /// a <code>NextToken</code> value that can be passed to a subsequent <code>DescribeSpotInstanceRequests</code>
    /// request to retrieve the remaining results.
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
        "The service call response (type Amazon.EC2.Model.DescribeSpotInstanceRequestsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2SpotInstanceRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters.</para><ul><li><para><code>availability-zone-group</code> - The Availability Zone group.</para></li><li><para><code>create-time</code> - The time stamp when the Spot Instance request was created.</para></li><li><para><code>fault-code</code> - The fault code related to the request.</para></li><li><para><code>fault-message</code> - The fault message related to the request.</para></li><li><para><code>instance-id</code> - The ID of the instance that fulfilled the request.</para></li><li><para><code>launch-group</code> - The Spot Instance launch group.</para></li><li><para><code>launch.block-device-mapping.delete-on-termination</code> - Indicates whether
        /// the EBS volume is deleted on instance termination.</para></li><li><para><code>launch.block-device-mapping.device-name</code> - The device name for the volume
        /// in the block device mapping (for example, <code>/dev/sdh</code> or <code>xvdh</code>).</para></li><li><para><code>launch.block-device-mapping.snapshot-id</code> - The ID of the snapshot for
        /// the EBS volume.</para></li><li><para><code>launch.block-device-mapping.volume-size</code> - The size of the EBS volume,
        /// in GiB.</para></li><li><para><code>launch.block-device-mapping.volume-type</code> - The type of EBS volume: <code>gp2</code>
        /// for General Purpose SSD, <code>io1</code> for Provisioned IOPS SSD, <code>st1</code>
        /// for Throughput Optimized HDD, <code>sc1</code>for Cold HDD, or <code>standard</code>
        /// for Magnetic.</para></li><li><para><code>launch.group-id</code> - The ID of the security group for the instance.</para></li><li><para><code>launch.group-name</code> - The name of the security group for the instance.</para></li><li><para><code>launch.image-id</code> - The ID of the AMI.</para></li><li><para><code>launch.instance-type</code> - The type of instance (for example, <code>m3.medium</code>).</para></li><li><para><code>launch.kernel-id</code> - The kernel ID.</para></li><li><para><code>launch.key-name</code> - The name of the key pair the instance launched with.</para></li><li><para><code>launch.monitoring-enabled</code> - Whether detailed monitoring is enabled for
        /// the Spot Instance.</para></li><li><para><code>launch.ramdisk-id</code> - The RAM disk ID.</para></li><li><para><code>launched-availability-zone</code> - The Availability Zone in which the request
        /// is launched.</para></li><li><para><code>network-interface.addresses.primary</code> - Indicates whether the IP address
        /// is the primary private IP address.</para></li><li><para><code>network-interface.delete-on-termination</code> - Indicates whether the network
        /// interface is deleted when the instance is terminated.</para></li><li><para><code>network-interface.description</code> - A description of the network interface.</para></li><li><para><code>network-interface.device-index</code> - The index of the device for the network
        /// interface attachment on the instance.</para></li><li><para><code>network-interface.group-id</code> - The ID of the security group associated
        /// with the network interface.</para></li><li><para><code>network-interface.network-interface-id</code> - The ID of the network interface.</para></li><li><para><code>network-interface.private-ip-address</code> - The primary private IP address
        /// of the network interface.</para></li><li><para><code>network-interface.subnet-id</code> - The ID of the subnet for the instance.</para></li><li><para><code>product-description</code> - The product description associated with the instance
        /// (<code>Linux/UNIX</code> | <code>Windows</code>).</para></li><li><para><code>spot-instance-request-id</code> - The Spot Instance request ID.</para></li><li><para><code>spot-price</code> - The maximum hourly price for any Spot Instance launched
        /// to fulfill the request.</para></li><li><para><code>state</code> - The state of the Spot Instance request (<code>open</code> |
        /// <code>active</code> | <code>closed</code> | <code>cancelled</code> | <code>failed</code>).
        /// Spot request status information can help you track your Amazon EC2 Spot Instance requests.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/spot-bid-status.html">Spot
        /// request status</a> in the <i>Amazon EC2 User Guide for Linux Instances</i>.</para></li><li><para><code>status-code</code> - The short code describing the most recent evaluation of
        /// your Spot Instance request.</para></li><li><para><code>status-message</code> - The message explaining the status of the Spot Instance
        /// request.</para></li><li><para><code>tag</code>:&lt;key&gt; - The key/value combination of a tag assigned to the
        /// resource. Use the tag key in the filter name and the tag value as the filter value.
        /// For example, to find all resources that have a tag with the key <code>Owner</code>
        /// and the value <code>TeamA</code>, specify <code>tag:Owner</code> for the filter name
        /// and <code>TeamA</code> for the filter value.</para></li><li><para><code>tag-key</code> - The key of a tag assigned to the resource. Use this filter
        /// to find all resources assigned a tag with a specific key, regardless of the tag value.</para></li><li><para><code>type</code> - The type of Spot Instance request (<code>one-time</code> | <code>persistent</code>).</para></li><li><para><code>valid-from</code> - The start date of the request.</para></li><li><para><code>valid-until</code> - The end date of the request.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter SpotInstanceRequestId
        /// <summary>
        /// <para>
        /// <para>One or more Spot Instance request IDs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("SpotInstanceRequestIds")]
        public System.String[] SpotInstanceRequestId { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. Specify a value between
        /// 5 and 1000. To retrieve the remaining results, make another call with the returned
        /// <code>NextToken</code> value.</para>
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
        /// <para>The token to request the next set of results. This value is <code>null</code> when
        /// there are no more results to return.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
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
