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
using Amazon.Billing;
using Amazon.Billing.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AWSB
{
    /// <summary>
    /// Lists the segments of a billing view over a given time period. Each segment identifies
    /// the billing domain (<c>PRO_FORMA</c> or <c>BILLABLE</c>) and the account relationships
    /// that apply during its time range.
    /// 
    ///  
    /// <para>
    /// If you don't provide an <c>arn</c>, the response includes segments for the caller's
    /// <c>PRIMARY</c> billing view.
    /// </para><para>
    /// If a mid-period change occurs, the response includes multiple segments, each with
    /// its own time range. The response omits hidden segments, so the segments it returns
    /// might not cover the entire requested time period.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "AWSBBillingViewSegmentList")]
    [OutputType("Amazon.Billing.Model.BillingViewSegmentsListElement")]
    [AWSCmdlet("Calls the AWS Billing ListBillingViewSegments API operation.", Operation = new[] {"ListBillingViewSegments"}, SelectReturnType = typeof(Amazon.Billing.Model.ListBillingViewSegmentsResponse))]
    [AWSCmdletOutput("Amazon.Billing.Model.BillingViewSegmentsListElement or Amazon.Billing.Model.ListBillingViewSegmentsResponse",
        "This cmdlet returns a collection of Amazon.Billing.Model.BillingViewSegmentsListElement objects.",
        "The service call response (type Amazon.Billing.Model.ListBillingViewSegmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetAWSBBillingViewSegmentListCmdlet : AmazonBillingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) that uniquely identifies the billing view to query.
        /// If you don't provide an ARN, the caller's <c>PRIMARY</c> billing view is used. The
        /// ARN must reference a primary billing view. Custom billing views aren't supported.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter TimeRange_BeginDateInclusive
        /// <summary>
        /// <para>
        /// <para> The inclusive start of the time range. This value can't be in the future. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRange_BeginDateInclusive { get; set; }
        #endregion
        
        #region Parameter TimeRange_EndDateExclusive
        /// <summary>
        /// <para>
        /// <para> The exclusive end of the time range. This value must be after <c>beginDateInclusive</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TimeRange_EndDateExclusive { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para> The number of entries a paginated response contains. Valid values range from 1 to
        /// 100. The default is 100. </para>
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
        /// <para> The pagination token that is used on subsequent calls to list billing view segments.
        /// </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Billing.Model.ListBillingViewSegmentsResponse).
        /// Specifying the name of a property of type Amazon.Billing.Model.ListBillingViewSegmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.Billing.Model.ListBillingViewSegmentsResponse, GetAWSBBillingViewSegmentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
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
            context.TimeRange_BeginDateInclusive = this.TimeRange_BeginDateInclusive;
            context.TimeRange_EndDateExclusive = this.TimeRange_EndDateExclusive;
            
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
            var request = new Amazon.Billing.Model.ListBillingViewSegmentsRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            
             // populate TimeRange
            var requestTimeRangeIsNull = true;
            request.TimeRange = new Amazon.Billing.Model.BillingViewSegmentTimeRange();
            System.DateTime? requestTimeRange_timeRange_BeginDateInclusive = null;
            if (cmdletContext.TimeRange_BeginDateInclusive != null)
            {
                requestTimeRange_timeRange_BeginDateInclusive = cmdletContext.TimeRange_BeginDateInclusive.Value;
            }
            if (requestTimeRange_timeRange_BeginDateInclusive != null)
            {
                request.TimeRange.BeginDateInclusive = requestTimeRange_timeRange_BeginDateInclusive.Value;
                requestTimeRangeIsNull = false;
            }
            System.DateTime? requestTimeRange_timeRange_EndDateExclusive = null;
            if (cmdletContext.TimeRange_EndDateExclusive != null)
            {
                requestTimeRange_timeRange_EndDateExclusive = cmdletContext.TimeRange_EndDateExclusive.Value;
            }
            if (requestTimeRange_timeRange_EndDateExclusive != null)
            {
                request.TimeRange.EndDateExclusive = requestTimeRange_timeRange_EndDateExclusive.Value;
                requestTimeRangeIsNull = false;
            }
             // determine if request.TimeRange should be set to null
            if (requestTimeRangeIsNull)
            {
                request.TimeRange = null;
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
        
        private Amazon.Billing.Model.ListBillingViewSegmentsResponse CallAWSServiceOperation(IAmazonBilling client, Amazon.Billing.Model.ListBillingViewSegmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Billing", "ListBillingViewSegments");
            try
            {
                return client.ListBillingViewSegmentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.DateTime? TimeRange_BeginDateInclusive { get; set; }
            public System.DateTime? TimeRange_EndDateExclusive { get; set; }
            public System.Func<Amazon.Billing.Model.ListBillingViewSegmentsResponse, GetAWSBBillingViewSegmentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
