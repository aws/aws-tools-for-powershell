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
using Amazon.Sustainability;
using Amazon.Sustainability.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SUST
{
    /// <summary>
    /// Returns estimated water allocation values based on customer grouping and filtering
    /// parameters. We recommend using pagination to ensure that the operation returns quickly
    /// and successfully.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SUSTEstimatedWaterAllocation")]
    [OutputType("Amazon.Sustainability.Model.EstimatedWaterAllocation")]
    [AWSCmdlet("Calls the AWS Sustainability GetEstimatedWaterAllocation API operation.", Operation = new[] {"GetEstimatedWaterAllocation"}, SelectReturnType = typeof(Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse))]
    [AWSCmdletOutput("Amazon.Sustainability.Model.EstimatedWaterAllocation or Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse",
        "This cmdlet returns a collection of Amazon.Sustainability.Model.EstimatedWaterAllocation objects.",
        "The service call response (type Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSUSTEstimatedWaterAllocationCmdlet : AmazonSustainabilityClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllocationType
        /// <summary>
        /// <para>
        /// <para>The allocation types to include in the results. If absent, returns <c>TOTAL_WATER_WITHDRAWALS</c>
        /// allocation types. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllocationTypes")]
        public System.String[] AllocationType { get; set; }
        #endregion
        
        #region Parameter FilterBy_Dimension
        /// <summary>
        /// <para>
        /// <para>Filters environmental impact values by specific dimension values.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterBy_Dimensions")]
        public System.Collections.Hashtable FilterBy_Dimension { get; set; }
        #endregion
        
        #region Parameter TimePeriod_End
        /// <summary>
        /// <para>
        /// <para>The end (exclusive) of the time period. ISO-8601 formatted timestamp, for example:
        /// <c>YYYY-MM-DDThh:mm:ss.sssZ</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimePeriod_End { get; set; }
        #endregion
        
        #region Parameter Granularity
        /// <summary>
        /// <para>
        /// <para>The time granularity for the results. Only <c>YEARLY_CALENDAR</c> time granularity
        /// is currently supported for water allocation. Defaults to <c>YEARLY_CALENDAR</c> if
        /// absent.</para><para> If requesting partial time periods, data will be returned based on the smallest supported
        /// granularity. For example, requesting <c>2025-04-01T00:00:00Z</c> to <c>2026-04-01T00:00:00Z</c>
        /// with <c>YEARLY_CALENDAR</c> will return all the data for 2026 only. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Sustainability.TimeGranularity")]
        public Amazon.Sustainability.TimeGranularity Granularity { get; set; }
        #endregion
        
        #region Parameter GroupBy
        /// <summary>
        /// <para>
        /// <para>The dimensions available for grouping estimated water allocation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] GroupBy { get; set; }
        #endregion
        
        #region Parameter TimePeriod_Start
        /// <summary>
        /// <para>
        /// <para>The start (inclusive) of the time period. ISO-8601 formatted timestamp, for example:
        /// <c>YYYY-MM-DDThh:mm:ss.sssZ</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimePeriod_Start { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. Default is 1000.</para>
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
        /// <para>The pagination token specifying which page of results to return in the response. If
        /// no token is provided, the default page is the first page. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse).
        /// Specifying the name of a property of type Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
                context.Select = CreateSelectDelegate<Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse, GetSUSTEstimatedWaterAllocationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllocationType != null)
            {
                context.AllocationType = new List<System.String>(this.AllocationType);
            }
            if (this.FilterBy_Dimension != null)
            {
                context.FilterBy_Dimension = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.FilterBy_Dimension.Keys)
                {
                    object hashValue = this.FilterBy_Dimension[hashKey];
                    if (hashValue == null)
                    {
                        context.FilterBy_Dimension.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.FilterBy_Dimension.Add((String)hashKey, valueSet);
                }
            }
            context.Granularity = this.Granularity;
            if (this.GroupBy != null)
            {
                context.GroupBy = new List<System.String>(this.GroupBy);
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
            context.TimePeriod_End = this.TimePeriod_End;
            #if MODULAR
            if (this.TimePeriod_End == null && ParameterWasBound(nameof(this.TimePeriod_End)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod_End which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimePeriod_Start = this.TimePeriod_Start;
            #if MODULAR
            if (this.TimePeriod_Start == null && ParameterWasBound(nameof(this.TimePeriod_Start)))
            {
                WriteWarning("You are passing $null as a value for parameter TimePeriod_Start which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.Sustainability.Model.GetEstimatedWaterAllocationRequest();
            
            if (cmdletContext.AllocationType != null)
            {
                request.AllocationTypes = cmdletContext.AllocationType;
            }
            
             // populate FilterBy
            var requestFilterByIsNull = true;
            request.FilterBy = new Amazon.Sustainability.Model.FilterExpression();
            Dictionary<System.String, List<System.String>> requestFilterBy_filterBy_Dimension = null;
            if (cmdletContext.FilterBy_Dimension != null)
            {
                requestFilterBy_filterBy_Dimension = cmdletContext.FilterBy_Dimension;
            }
            if (requestFilterBy_filterBy_Dimension != null)
            {
                request.FilterBy.Dimensions = requestFilterBy_filterBy_Dimension;
                requestFilterByIsNull = false;
            }
             // determine if request.FilterBy should be set to null
            if (requestFilterByIsNull)
            {
                request.FilterBy = null;
            }
            if (cmdletContext.Granularity != null)
            {
                request.Granularity = cmdletContext.Granularity;
            }
            if (cmdletContext.GroupBy != null)
            {
                request.GroupBy = cmdletContext.GroupBy;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate TimePeriod
            var requestTimePeriodIsNull = true;
            request.TimePeriod = new Amazon.Sustainability.Model.TimePeriod();
            System.DateTime? requestTimePeriod_timePeriod_End = null;
            if (cmdletContext.TimePeriod_End != null)
            {
                requestTimePeriod_timePeriod_End = cmdletContext.TimePeriod_End.Value;
            }
            if (requestTimePeriod_timePeriod_End != null)
            {
                request.TimePeriod.End = requestTimePeriod_timePeriod_End.Value;
                requestTimePeriodIsNull = false;
            }
            System.DateTime? requestTimePeriod_timePeriod_Start = null;
            if (cmdletContext.TimePeriod_Start != null)
            {
                requestTimePeriod_timePeriod_Start = cmdletContext.TimePeriod_Start.Value;
            }
            if (requestTimePeriod_timePeriod_Start != null)
            {
                request.TimePeriod.Start = requestTimePeriod_timePeriod_Start.Value;
                requestTimePeriodIsNull = false;
            }
             // determine if request.TimePeriod should be set to null
            if (requestTimePeriodIsNull)
            {
                request.TimePeriod = null;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse CallAWSServiceOperation(IAmazonSustainability client, Amazon.Sustainability.Model.GetEstimatedWaterAllocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Sustainability", "GetEstimatedWaterAllocation");
            try
            {
                return client.GetEstimatedWaterAllocationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllocationType { get; set; }
            public Dictionary<System.String, List<System.String>> FilterBy_Dimension { get; set; }
            public Amazon.Sustainability.TimeGranularity Granularity { get; set; }
            public List<System.String> GroupBy { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? TimePeriod_End { get; set; }
            public System.DateTime? TimePeriod_Start { get; set; }
            public System.Func<Amazon.Sustainability.Model.GetEstimatedWaterAllocationResponse, GetSUSTEstimatedWaterAllocationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
