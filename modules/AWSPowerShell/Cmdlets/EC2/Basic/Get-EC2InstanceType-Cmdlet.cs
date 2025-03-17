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
    /// Describes the specified instance types. By default, all instance types for the current
    /// Region are described. Alternatively, you can filter the results.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceType")]
    [OutputType("Amazon.EC2.Model.InstanceTypeInfo")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeInstanceTypes API operation.", Operation = new[] {"DescribeInstanceTypes"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeInstanceTypesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceTypeInfo or Amazon.EC2.Model.DescribeInstanceTypesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceTypeInfo objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstanceTypesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2InstanceTypeCmdlet : AmazonEC2ClientCmdlet, IExecutor
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
        /// <para>One or more filters. Filter names and values are case-sensitive.</para><ul><li><para><c>auto-recovery-supported</c> - Indicates whether Amazon CloudWatch action based
        /// recovery is supported (<c>true</c> | <c>false</c>).</para></li><li><para><c>bare-metal</c> - Indicates whether it is a bare metal instance type (<c>true</c>
        /// | <c>false</c>).</para></li><li><para><c>burstable-performance-supported</c> - Indicates whether the instance type is a
        /// burstable performance T instance type (<c>true</c> | <c>false</c>).</para></li><li><para><c>current-generation</c> - Indicates whether this instance type is the latest generation
        /// instance type of an instance family (<c>true</c> | <c>false</c>).</para></li><li><para><c>ebs-info.ebs-optimized-info.baseline-bandwidth-in-mbps</c> - The baseline bandwidth
        /// performance for an EBS-optimized instance type, in Mbps.</para></li><li><para><c>ebs-info.ebs-optimized-info.baseline-iops</c> - The baseline input/output storage
        /// operations per second for an EBS-optimized instance type.</para></li><li><para><c>ebs-info.ebs-optimized-info.baseline-throughput-in-mbps</c> - The baseline throughput
        /// performance for an EBS-optimized instance type, in MB/s.</para></li><li><para><c>ebs-info.ebs-optimized-info.maximum-bandwidth-in-mbps</c> - The maximum bandwidth
        /// performance for an EBS-optimized instance type, in Mbps.</para></li><li><para><c>ebs-info.ebs-optimized-info.maximum-iops</c> - The maximum input/output storage
        /// operations per second for an EBS-optimized instance type.</para></li><li><para><c>ebs-info.ebs-optimized-info.maximum-throughput-in-mbps</c> - The maximum throughput
        /// performance for an EBS-optimized instance type, in MB/s.</para></li><li><para><c>ebs-info.ebs-optimized-support</c> - Indicates whether the instance type is EBS-optimized
        /// (<c>supported</c> | <c>unsupported</c> | <c>default</c>).</para></li><li><para><c>ebs-info.encryption-support</c> - Indicates whether EBS encryption is supported
        /// (<c>supported</c> | <c>unsupported</c>).</para></li><li><para><c>ebs-info.nvme-support</c> - Indicates whether non-volatile memory express (NVMe)
        /// is supported for EBS volumes (<c>required</c> | <c>supported</c> | <c>unsupported</c>).</para></li><li><para><c>free-tier-eligible</c> - Indicates whether the instance type is eligible to use
        /// in the free tier (<c>true</c> | <c>false</c>).</para></li><li><para><c>hibernation-supported</c> - Indicates whether On-Demand hibernation is supported
        /// (<c>true</c> | <c>false</c>).</para></li><li><para><c>hypervisor</c> - The hypervisor (<c>nitro</c> | <c>xen</c>).</para></li><li><para><c>instance-storage-info.disk.count</c> - The number of local disks.</para></li><li><para><c>instance-storage-info.disk.size-in-gb</c> - The storage size of each instance
        /// storage disk, in GB.</para></li><li><para><c>instance-storage-info.disk.type</c> - The storage technology for the local instance
        /// storage disks (<c>hdd</c> | <c>ssd</c>).</para></li><li><para><c>instance-storage-info.encryption-support</c> - Indicates whether data is encrypted
        /// at rest (<c>required</c> | <c>supported</c> | <c>unsupported</c>).</para></li><li><para><c>instance-storage-info.nvme-support</c> - Indicates whether non-volatile memory
        /// express (NVMe) is supported for instance store (<c>required</c> | <c>supported</c>
        /// | <c>unsupported</c>).</para></li><li><para><c>instance-storage-info.total-size-in-gb</c> - The total amount of storage available
        /// from all local instance storage, in GB.</para></li><li><para><c>instance-storage-supported</c> - Indicates whether the instance type has local
        /// instance storage (<c>true</c> | <c>false</c>).</para></li><li><para><c>instance-type</c> - The instance type (for example <c>c5.2xlarge</c> or c5*).</para></li><li><para><c>memory-info.size-in-mib</c> - The memory size.</para></li><li><para><c>network-info.bandwidth-weightings</c> - For instances that support bandwidth weighting
        /// to boost performance (<c>default</c>, <c>vpc-1</c>, <c>ebs-1</c>).</para></li><li><para><c>network-info.efa-info.maximum-efa-interfaces</c> - The maximum number of Elastic
        /// Fabric Adapters (EFAs) per instance.</para></li><li><para><c>network-info.efa-supported</c> - Indicates whether the instance type supports
        /// Elastic Fabric Adapter (EFA) (<c>true</c> | <c>false</c>).</para></li><li><para><c>network-info.ena-support</c> - Indicates whether Elastic Network Adapter (ENA)
        /// is supported or required (<c>required</c> | <c>supported</c> | <c>unsupported</c>).</para></li><li><para><c>network-info.encryption-in-transit-supported</c> - Indicates whether the instance
        /// type automatically encrypts in-transit traffic between instances (<c>true</c> | <c>false</c>).</para></li><li><para><c>network-info.ipv4-addresses-per-interface</c> - The maximum number of private
        /// IPv4 addresses per network interface.</para></li><li><para><c>network-info.ipv6-addresses-per-interface</c> - The maximum number of private
        /// IPv6 addresses per network interface.</para></li><li><para><c>network-info.ipv6-supported</c> - Indicates whether the instance type supports
        /// IPv6 (<c>true</c> | <c>false</c>).</para></li><li><para><c>network-info.maximum-network-cards</c> - The maximum number of network cards per
        /// instance.</para></li><li><para><c>network-info.maximum-network-interfaces</c> - The maximum number of network interfaces
        /// per instance.</para></li><li><para><c>network-info.network-performance</c> - The network performance (for example, "25
        /// Gigabit").</para></li><li><para><c>nitro-enclaves-support</c> - Indicates whether Nitro Enclaves is supported (<c>supported</c>
        /// | <c>unsupported</c>).</para></li><li><para><c>nitro-tpm-support</c> - Indicates whether NitroTPM is supported (<c>supported</c>
        /// | <c>unsupported</c>).</para></li><li><para><c>nitro-tpm-info.supported-versions</c> - The supported NitroTPM version (<c>2.0</c>).</para></li><li><para><c>processor-info.supported-architecture</c> - The CPU architecture (<c>arm64</c>
        /// | <c>i386</c> | <c>x86_64</c>).</para></li><li><para><c>processor-info.sustained-clock-speed-in-ghz</c> - The CPU clock speed, in GHz.</para></li><li><para><c>processor-info.supported-features</c> - The supported CPU features (<c>amd-sev-snp</c>).</para></li><li><para><c>supported-boot-mode</c> - The boot mode (<c>legacy-bios</c> | <c>uefi</c>).</para></li><li><para><c>supported-root-device-type</c> - The root device type (<c>ebs</c> | <c>instance-store</c>).</para></li><li><para><c>supported-usage-class</c> - The usage class (<c>on-demand</c> | <c>spot</c> |
        /// <c>capacity-block</c>).</para></li><li><para><c>supported-virtualization-type</c> - The virtualization type (<c>hvm</c> | <c>paravirtual</c>).</para></li><li><para><c>vcpu-info.default-cores</c> - The default number of cores for the instance type.</para></li><li><para><c>vcpu-info.default-threads-per-core</c> - The default number of threads per core
        /// for the instance type.</para></li><li><para><c>vcpu-info.default-vcpus</c> - The default number of vCPUs for the instance type.</para></li><li><para><c>vcpu-info.valid-cores</c> - The number of cores that can be configured for the
        /// instance type.</para></li><li><para><c>vcpu-info.valid-threads-per-core</c> - The number of threads per core that can
        /// be configured for the instance type. For example, "1" or "1,2".</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InstanceTypes'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeInstanceTypesResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeInstanceTypesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InstanceTypes";
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeInstanceTypesResponse, GetEC2InstanceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.EC2.Model.Filter>(this.Filter);
            }
            if (this.InstanceType != null)
            {
                context.InstanceType = new List<System.String>(this.InstanceType);
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
            var request = new Amazon.EC2.Model.DescribeInstanceTypesRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceTypes = cmdletContext.InstanceType;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
            var request = new Amazon.EC2.Model.DescribeInstanceTypesRequest();
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceType != null)
            {
                request.InstanceTypes = cmdletContext.InstanceType;
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
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
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
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
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
                    int _receivedThisCall = response.InstanceTypes?.Count ?? 0;
                    
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
        
        private Amazon.EC2.Model.DescribeInstanceTypesResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeInstanceTypesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeInstanceTypes");
            try
            {
                return client.DescribeInstanceTypesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> InstanceType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeInstanceTypesResponse, GetEC2InstanceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceTypes;
        }
        
    }
}
