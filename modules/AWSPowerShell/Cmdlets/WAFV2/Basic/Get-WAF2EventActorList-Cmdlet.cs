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
using Amazon.WAFV2;
using Amazon.WAFV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAF2
{
    /// <summary>
    /// Retrieves a paginated list of the event actors in your account that are associated
    /// with events in the specified time window. An event actor is a client that is associated
    /// with one or more events. The operation returns up to the top 100 event actors by event
    /// count. Results are paginated. Use the <c>NextMarker</c> value from the response to
    /// retrieve the next batch of results. Currently, this operation supports API Security
    /// Amazon Web Services Managed Rules.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WAF2EventActorList")]
    [OutputType("Amazon.WAFV2.Model.EventActorSummary")]
    [AWSCmdlet("Calls the AWS WAFV2 ListEventActors API operation.", Operation = new[] {"ListEventActors"}, SelectReturnType = typeof(Amazon.WAFV2.Model.ListEventActorsResponse))]
    [AWSCmdletOutput("Amazon.WAFV2.Model.EventActorSummary or Amazon.WAFV2.Model.ListEventActorsResponse",
        "This cmdlet returns a collection of Amazon.WAFV2.Model.EventActorSummary objects.",
        "The service call response (type Amazon.WAFV2.Model.ListEventActorsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWAF2EventActorListCmdlet : AmazonWAFV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TimeWindow_EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_EndTime { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Specifies whether this is for a global resource type, such as a Amazon CloudFront
        /// distribution. For an Amplify application, use <c>CLOUDFRONT</c>.</para><para>To work with CloudFront, you must also specify the Region US East (N. Virginia) as
        /// follows: </para><ul><li><para>CLI - Specify the Region when you use the CloudFront scope: <c>--scope=CLOUDFRONT
        /// --region=us-east-1</c>. </para></li><li><para>API and SDKs - For all calls, use the Region endpoint us-east-1. </para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WAFV2.Scope")]
        public Amazon.WAFV2.Scope Scope { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort event actors by. The only supported value is <c>EVENT_COUNT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WAFV2.EventActorSortBy")]
        public Amazon.WAFV2.EventActorSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter TimeWindow_StartTime
        /// <summary>
        /// <para>
        /// <para>The beginning of the time range from which you want <c>GetSampledRequests</c> to return
        /// a sample of the requests that your Amazon Web Services resource received. You must
        /// specify the times in Coordinated Universal Time (UTC) format. UTC format includes
        /// the special designator, <c>Z</c>. For example, <c>"2016-09-27T14:50Z"</c>. You can
        /// specify any time range in the previous three hours.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? TimeWindow_StartTime { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of event actors that you want WAF to return for this request. Valid
        /// values are 1 to 100. If more event actors are available, WAF returns a <c>NextMarker</c>
        /// value in the response that you can use in a subsequent call to get the next batch
        /// of event actors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextMarker
        /// <summary>
        /// <para>
        /// <para>When you request a list of objects with a <c>Limit</c> setting, if the number of objects
        /// that are still available for retrieval exceeds the limit, WAF returns a <c>NextMarker</c>
        /// value in the response. To retrieve the next batch of objects, provide the marker from
        /// the prior call in your next request.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextMarker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextMarker' to null for the first call then set the 'NextMarker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextMarker { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventActors'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WAFV2.Model.ListEventActorsResponse).
        /// Specifying the name of a property of type Amazon.WAFV2.Model.ListEventActorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventActors";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextMarker
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
                context.Select = CreateSelectDelegate<Amazon.WAFV2.Model.ListEventActorsResponse, GetWAF2EventActorListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Limit = this.Limit;
            context.NextMarker = this.NextMarker;
            context.Scope = this.Scope;
            #if MODULAR
            if (this.Scope == null && ParameterWasBound(nameof(this.Scope)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SortBy = this.SortBy;
            context.TimeWindow_EndTime = this.TimeWindow_EndTime;
            #if MODULAR
            if (this.TimeWindow_EndTime == null && ParameterWasBound(nameof(this.TimeWindow_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeWindow_StartTime = this.TimeWindow_StartTime;
            #if MODULAR
            if (this.TimeWindow_StartTime == null && ParameterWasBound(nameof(this.TimeWindow_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeWindow_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WAFV2.Model.ListEventActorsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            
             // populate TimeWindow
            var requestTimeWindowIsNull = true;
            request.TimeWindow = new Amazon.WAFV2.Model.TimeWindow();
            System.DateTime? requestTimeWindow_timeWindow_EndTime = null;
            if (cmdletContext.TimeWindow_EndTime != null)
            {
                requestTimeWindow_timeWindow_EndTime = cmdletContext.TimeWindow_EndTime.Value;
            }
            if (requestTimeWindow_timeWindow_EndTime != null)
            {
                request.TimeWindow.EndTime = requestTimeWindow_timeWindow_EndTime.Value;
                requestTimeWindowIsNull = false;
            }
            System.DateTime? requestTimeWindow_timeWindow_StartTime = null;
            if (cmdletContext.TimeWindow_StartTime != null)
            {
                requestTimeWindow_timeWindow_StartTime = cmdletContext.TimeWindow_StartTime.Value;
            }
            if (requestTimeWindow_timeWindow_StartTime != null)
            {
                request.TimeWindow.StartTime = requestTimeWindow_timeWindow_StartTime.Value;
                requestTimeWindowIsNull = false;
            }
             // determine if request.TimeWindow should be set to null
            if (requestTimeWindowIsNull)
            {
                request.TimeWindow = null;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextMarker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextMarker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextMarker = _nextToken;
                
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
                    
                    _nextToken = response.NextMarker;
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
        
        private Amazon.WAFV2.Model.ListEventActorsResponse CallAWSServiceOperation(IAmazonWAFV2 client, Amazon.WAFV2.Model.ListEventActorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS WAFV2", "ListEventActors");
            try
            {
                return client.ListEventActorsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? Limit { get; set; }
            public System.String NextMarker { get; set; }
            public Amazon.WAFV2.Scope Scope { get; set; }
            public Amazon.WAFV2.EventActorSortBy SortBy { get; set; }
            public System.DateTime? TimeWindow_EndTime { get; set; }
            public System.DateTime? TimeWindow_StartTime { get; set; }
            public System.Func<Amazon.WAFV2.Model.ListEventActorsResponse, GetWAF2EventActorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventActors;
        }
        
    }
}
