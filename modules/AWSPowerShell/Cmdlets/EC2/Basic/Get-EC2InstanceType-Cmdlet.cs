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
    /// Describes the details of the instance types that are offered in a location. The results
    /// can be filtered by the attributes of the instance types.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2InstanceType")]
    [OutputType("Amazon.EC2.Model.InstanceTypeInfo")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeInstanceTypes API operation.", Operation = new[] {"DescribeInstanceTypes"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeInstanceTypesResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.InstanceTypeInfo or Amazon.EC2.Model.DescribeInstanceTypesResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.InstanceTypeInfo objects.",
        "The service call response (type Amazon.EC2.Model.DescribeInstanceTypesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEC2InstanceTypeCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>One or more filters. Filter names and values are case-sensitive.</para><ul><li><para><code>auto-recovery-supported</code> - Indicates whether auto recovery is supported
        /// (<code>true</code> | <code>false</code>).</para></li><li><para><code>bare-metal</code> - Indicates whether it is a bare metal instance type (<code>true</code>
        /// | <code>false</code>).</para></li><li><para><code>burstable-performance-supported</code> - Indicates whether it is a burstable
        /// performance instance type (<code>true</code> | <code>false</code>).</para></li><li><para><code>current-generation</code> - Indicates whether this instance type is the latest
        /// generation instance type of an instance family (<code>true</code> | <code>false</code>).</para></li><li><para><code>ebs-info.ebs-optimized-info.baseline-bandwidth-in-mbps</code> - The baseline
        /// bandwidth performance for an EBS-optimized instance type, in Mbps.</para></li><li><para><code>ebs-info.ebs-optimized-info.baseline-iops</code> - The baseline input/output
        /// storage operations per second for an EBS-optimized instance type.</para></li><li><para><code>ebs-info.ebs-optimized-info.baseline-throughput-in-mbps</code> - The baseline
        /// throughput performance for an EBS-optimized instance type, in MB/s.</para></li><li><para><code>ebs-info.ebs-optimized-info.maximum-bandwidth-in-mbps</code> - The maximum
        /// bandwidth performance for an EBS-optimized instance type, in Mbps.</para></li><li><para><code>ebs-info.ebs-optimized-info.maximum-iops</code> - The maximum input/output
        /// storage operations per second for an EBS-optimized instance type.</para></li><li><para><code>ebs-info.ebs-optimized-info.maximum-throughput-in-mbps</code> - The maximum
        /// throughput performance for an EBS-optimized instance type, in MB/s.</para></li><li><para><code>ebs-info.ebs-optimized-support</code> - Indicates whether the instance type
        /// is EBS-optimized (<code>supported</code> | <code>unsupported</code> | <code>default</code>).</para></li><li><para><code>ebs-info.encryption-support</code> - Indicates whether EBS encryption is supported
        /// (<code>supported</code> | <code>unsupported</code>).</para></li><li><para><code>ebs-info.nvme-support</code> - Indicates whether non-volatile memory express
        /// (NVMe) is supported for EBS volumes (<code>required</code> | <code>supported</code>
        /// | <code>unsupported</code>).</para></li><li><para><code>free-tier-eligible</code> - Indicates whether the instance type is eligible
        /// to use in the free tier (<code>true</code> | <code>false</code>).</para></li><li><para><code>hibernation-supported</code> - Indicates whether On-Demand hibernation is supported
        /// (<code>true</code> | <code>false</code>).</para></li><li><para><code>hypervisor</code> - The hypervisor (<code>nitro</code> | <code>xen</code>).</para></li><li><para><code>instance-storage-info.disk.count</code> - The number of local disks.</para></li><li><para><code>instance-storage-info.disk.size-in-gb</code> - The storage size of each instance
        /// storage disk, in GB.</para></li><li><para><code>instance-storage-info.disk.type</code> - The storage technology for the local
        /// instance storage disks (<code>hdd</code> | <code>ssd</code>).</para></li><li><para><code>instance-storage-info.encryption-supported</code> - Indicates whether data
        /// is encrypted at rest (<code>required</code> | <code>unsupported</code>).</para></li><li><para><code>instance-storage-info.nvme-support</code> - Indicates whether non-volatile
        /// memory express (NVMe) is supported for instance store (<code>required</code> | <code>supported</code>
        /// | <code>unsupported</code>).</para></li><li><para><code>instance-storage-info.total-size-in-gb</code> - The total amount of storage
        /// available from all local instance storage, in GB.</para></li><li><para><code>instance-storage-supported</code> - Indicates whether the instance type has
        /// local instance storage (<code>true</code> | <code>false</code>).</para></li><li><para><code>instance-type</code> - The instance type (for example <code>c5.2xlarge</code>
        /// or c5*).</para></li><li><para><code>memory-info.size-in-mib</code> - The memory size.</para></li><li><para><code>network-info.efa-info.maximum-efa-interfaces</code> - The maximum number of
        /// Elastic Fabric Adapters (EFAs) per instance.</para></li><li><para><code>network-info.efa-supported</code> - Indicates whether the instance type supports
        /// Elastic Fabric Adapter (EFA) (<code>true</code> | <code>false</code>).</para></li><li><para><code>network-info.ena-support</code> - Indicates whether Elastic Network Adapter
        /// (ENA) is supported or required (<code>required</code> | <code>supported</code> | <code>unsupported</code>).</para></li><li><para><code>network-info.encryption-in-transit-supported</code> - Indicates whether the
        /// instance type automatically encrypts in-transit traffic between instances (<code>true</code>
        /// | <code>false</code>).</para></li><li><para><code>network-info.ipv4-addresses-per-interface</code> - The maximum number of private
        /// IPv4 addresses per network interface.</para></li><li><para><code>network-info.ipv6-addresses-per-interface</code> - The maximum number of private
        /// IPv6 addresses per network interface.</para></li><li><para><code>network-info.ipv6-supported</code> - Indicates whether the instance type supports
        /// IPv6 (<code>true</code> | <code>false</code>).</para></li><li><para><code>network-info.maximum-network-interfaces</code> - The maximum number of network
        /// interfaces per instance.</para></li><li><para><code>network-info.network-performance</code> - The network performance (for example,
        /// "25 Gigabit").</para></li><li><para><code>processor-info.supported-architecture</code> - The CPU architecture (<code>arm64</code>
        /// | <code>i386</code> | <code>x86_64</code>).</para></li><li><para><code>processor-info.sustained-clock-speed-in-ghz</code> - The CPU clock speed, in
        /// GHz.</para></li><li><para><code>supported-boot-mode</code> - The boot mode (<code>legacy-bios</code> | <code>uefi</code>).</para></li><li><para><code>supported-root-device-type</code> - The root device type (<code>ebs</code>
        /// | <code>instance-store</code>).</para></li><li><para><code>supported-usage-class</code> - The usage class (<code>on-demand</code> | <code>spot</code>).</para></li><li><para><code>supported-virtualization-type</code> - The virtualization type (<code>hvm</code>
        /// | <code>paravirtual</code>).</para></li><li><para><code>vcpu-info.default-cores</code> - The default number of cores for the instance
        /// type.</para></li><li><para><code>vcpu-info.default-threads-per-core</code> - The default number of threads per
        /// core for the instance type.</para></li><li><para><code>vcpu-info.default-vcpus</code> - The default number of vCPUs for the instance
        /// type.</para></li><li><para><code>vcpu-info.valid-cores</code> - The number of cores that can be configured for
        /// the instance type.</para></li><li><para><code>vcpu-info.valid-threads-per-core</code> - The number of threads per core that
        /// can be configured for the instance type. For example, "1" or "1,2".</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceType
        /// <summary>
        /// <para>
        /// <para>The instance types. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/instance-types.html">Instance
        /// types</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceTypes")]
        public System.String[] InstanceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return for the request in a single page. The remaining
        /// results can be seen by sending another request with the next token value.</para>
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeInstanceTypesResponse, GetEC2InstanceTypeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
                    int _receivedThisCall = response.InstanceTypes.Count;
                    
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
                #if DESKTOP
                return client.DescribeInstanceTypes(request);
                #elif CORECLR
                return client.DescribeInstanceTypesAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> InstanceType { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeInstanceTypesResponse, GetEC2InstanceTypeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InstanceTypes;
        }
        
    }
}
