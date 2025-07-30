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
    /// Describes the status of the specified volumes. Volume status provides the result of
    /// the checks performed on your volumes to determine events that can impair the performance
    /// of your volumes. The performance of a volume can be affected if an issue occurs on
    /// the volume's underlying host. If the volume's underlying host experiences a power
    /// outage or system issue, after the system is restored, there could be data inconsistencies
    /// on the volume. Volume events notify you if this occurs. Volume actions notify you
    /// if any action needs to be taken in response to the event.
    /// 
    ///  
    /// <para>
    /// The <c>DescribeVolumeStatus</c> operation provides the following information about
    /// the specified volumes:
    /// </para><para><i>Status</i>: Reflects the current status of the volume. The possible values are
    /// <c>ok</c>, <c>impaired</c> , <c>warning</c>, or <c>insufficient-data</c>. If all checks
    /// pass, the overall status of the volume is <c>ok</c>. If the check fails, the overall
    /// status is <c>impaired</c>. If the status is <c>insufficient-data</c>, then the checks
    /// might still be taking place on your volume at the time. We recommend that you retry
    /// the request. For more information about volume status, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/monitoring-volume-status.html">Monitor
    /// the status of your volumes</a> in the <i>Amazon EBS User Guide</i>.
    /// </para><para><i>Events</i>: Reflect the cause of a volume status and might require you to take
    /// action. For example, if your volume returns an <c>impaired</c> status, then the volume
    /// event might be <c>potential-data-inconsistency</c>. This means that your volume has
    /// been affected by an issue with the underlying host, has all I/O operations disabled,
    /// and might have inconsistent data.
    /// </para><para><i>Actions</i>: Reflect the actions you might have to take in response to an event.
    /// For example, if the status of the volume is <c>impaired</c> and the volume event shows
    /// <c>potential-data-inconsistency</c>, then the action shows <c>enable-volume-io</c>.
    /// This means that you may want to enable the I/O operations for the volume and then
    /// check the volume for data consistency. For more information, see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/work_volumes_impaired.html">Work
    /// with an impaired EBS volume</a>.
    /// </para><para>
    /// Volume status is based on the volume status checks, and does not reflect the volume
    /// state. Therefore, volume status does not indicate volumes in the <c>error</c> state
    /// (for example, when a volume is incapable of accepting I/O.)
    /// </para><note><para>
    /// The order of the elements in the response, including those within nested structures,
    /// might vary. Applications should not assume the elements appear in a particular order.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "EC2VolumeStatus")]
    [OutputType("Amazon.EC2.Model.VolumeStatusItem")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) DescribeVolumeStatus API operation.", Operation = new[] {"DescribeVolumeStatus"}, SelectReturnType = typeof(Amazon.EC2.Model.DescribeVolumeStatusResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.VolumeStatusItem or Amazon.EC2.Model.DescribeVolumeStatusResponse",
        "This cmdlet returns a collection of Amazon.EC2.Model.VolumeStatusItem objects.",
        "The service call response (type Amazon.EC2.Model.DescribeVolumeStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetEC2VolumeStatusCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para><ul><li><para><c>action.code</c> - The action code for the event (for example, <c>enable-volume-io</c>).</para></li><li><para><c>action.description</c> - A description of the action.</para></li><li><para><c>action.event-id</c> - The event ID associated with the action.</para></li><li><para><c>availability-zone</c> - The Availability Zone of the instance.</para></li><li><para><c>event.description</c> - A description of the event.</para></li><li><para><c>event.event-id</c> - The event ID.</para></li><li><para><c>event.event-type</c> - The event type (for <c>io-enabled</c>: <c>passed</c> |
        /// <c>failed</c>; for <c>io-performance</c>: <c>io-performance:degraded</c> | <c>io-performance:severely-degraded</c>
        /// | <c>io-performance:stalled</c>).</para></li><li><para><c>event.not-after</c> - The latest end time for the event.</para></li><li><para><c>event.not-before</c> - The earliest start time for the event.</para></li><li><para><c>volume-status.details-name</c> - The cause for <c>volume-status.status</c> (<c>io-enabled</c>
        /// | <c>io-performance</c>).</para></li><li><para><c>volume-status.details-status</c> - The status of <c>volume-status.details-name</c>
        /// (for <c>io-enabled</c>: <c>passed</c> | <c>failed</c>; for <c>io-performance</c>:
        /// <c>normal</c> | <c>degraded</c> | <c>severely-degraded</c> | <c>stalled</c>).</para></li><li><para><c>volume-status.status</c> - The status of the volume (<c>ok</c> | <c>impaired</c>
        /// | <c>warning</c> | <c>insufficient-data</c>).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.EC2.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter VolumeId
        /// <summary>
        /// <para>
        /// <para>The IDs of the volumes.</para><para>Default: Describes all your volumes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("VolumeIds")]
        public System.String[] VolumeId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VolumeStatuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.DescribeVolumeStatusResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.DescribeVolumeStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VolumeStatuses";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VolumeId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VolumeId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.DescribeVolumeStatusResponse, GetEC2VolumeStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VolumeId;
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
            if (this.VolumeId != null)
            {
                context.VolumeId = new List<System.String>(this.VolumeId);
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
            var request = new Amazon.EC2.Model.DescribeVolumeStatusRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeIds = cmdletContext.VolumeId;
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
            var request = new Amazon.EC2.Model.DescribeVolumeStatusRequest();
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.VolumeId != null)
            {
                request.VolumeIds = cmdletContext.VolumeId;
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
                    int _receivedThisCall = response.VolumeStatuses.Count;
                    
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
        
        private Amazon.EC2.Model.DescribeVolumeStatusResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.DescribeVolumeStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "DescribeVolumeStatus");
            try
            {
                #if DESKTOP
                return client.DescribeVolumeStatus(request);
                #elif CORECLR
                return client.DescribeVolumeStatusAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> VolumeId { get; set; }
            public System.Func<Amazon.EC2.Model.DescribeVolumeStatusResponse, GetEC2VolumeStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VolumeStatuses;
        }
        
    }
}
