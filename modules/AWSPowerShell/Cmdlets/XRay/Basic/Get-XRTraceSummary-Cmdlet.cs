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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Retrieves IDs and annotations for traces available for a specified time frame using
    /// an optional filter. To get the full traces, pass the trace IDs to <c>BatchGetTraces</c>.
    /// 
    ///  
    /// <para>
    /// A filter expression can target traced requests that hit specific service nodes or
    /// edges, have errors, or come from a known user. For example, the following filter expression
    /// targets traces that pass through <c>api.example.com</c>:
    /// </para><para><c>service("api.example.com")</c></para><para>
    /// This filter expression finds traces that have an annotation named <c>account</c> with
    /// the value <c>12345</c>:
    /// </para><para><c>annotation.account = "12345"</c></para><para>
    /// For a full list of indexed fields and keywords that you can use in filter expressions,
    /// see <a href="https://docs.aws.amazon.com/xray/latest/devguide/aws-xray-interface-console.html#xray-console-filters">Use
    /// filter expressions</a> in the <i>Amazon Web Services X-Ray Developer Guide</i>.
    /// </para><br/><br/>In the AWS.Tools.XRay module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "XRTraceSummary")]
    [OutputType("Amazon.XRay.Model.GetTraceSummariesResponse")]
    [AWSCmdlet("Calls the AWS X-Ray GetTraceSummaries API operation.", Operation = new[] {"GetTraceSummaries"}, SelectReturnType = typeof(Amazon.XRay.Model.GetTraceSummariesResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.GetTraceSummariesResponse",
        "This cmdlet returns an Amazon.XRay.Model.GetTraceSummariesResponse object containing multiple properties."
    )]
    public partial class GetXRTraceSummaryCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time frame for which to retrieve traces.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter FilterExpression
        /// <summary>
        /// <para>
        /// <para>Specify a filter expression to retrieve trace summaries for services or requests that
        /// meet certain requirements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterExpression { get; set; }
        #endregion
        
        #region Parameter SamplingStrategy_Name
        /// <summary>
        /// <para>
        /// <para>The name of a sampling rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.XRay.SamplingStrategyName")]
        public Amazon.XRay.SamplingStrategyName SamplingStrategy_Name { get; set; }
        #endregion
        
        #region Parameter Sampling
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to get summaries for only a subset of available traces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Sampling { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time frame for which to retrieve traces.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter TimeRangeType
        /// <summary>
        /// <para>
        /// <para>Query trace summaries by TraceId (trace start time), Event (trace update time), or
        /// Service (trace segment end time).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.XRay.TimeRangeType")]
        public Amazon.XRay.TimeRangeType TimeRangeType { get; set; }
        #endregion
        
        #region Parameter SamplingStrategy_Value
        /// <summary>
        /// <para>
        /// <para>The value of a sampling rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? SamplingStrategy_Value { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token returned by a previous request to retrieve the next page
        /// of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.XRay module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.GetTraceSummariesResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.GetTraceSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StartTime parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StartTime' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StartTime' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
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
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.GetTraceSummariesResponse, GetXRTraceSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StartTime;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            #if MODULAR
            if (this.EndTime == null && ParameterWasBound(nameof(this.EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FilterExpression = this.FilterExpression;
            context.NextToken = this.NextToken;
            context.Sampling = this.Sampling;
            context.SamplingStrategy_Name = this.SamplingStrategy_Name;
            context.SamplingStrategy_Value = this.SamplingStrategy_Value;
            context.StartTime = this.StartTime;
            #if MODULAR
            if (this.StartTime == null && ParameterWasBound(nameof(this.StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRangeType = this.TimeRangeType;
            
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
            var request = new Amazon.XRay.Model.GetTraceSummariesRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.Sampling != null)
            {
                request.Sampling = cmdletContext.Sampling.Value;
            }
            
             // populate SamplingStrategy
            var requestSamplingStrategyIsNull = true;
            request.SamplingStrategy = new Amazon.XRay.Model.SamplingStrategy();
            Amazon.XRay.SamplingStrategyName requestSamplingStrategy_samplingStrategy_Name = null;
            if (cmdletContext.SamplingStrategy_Name != null)
            {
                requestSamplingStrategy_samplingStrategy_Name = cmdletContext.SamplingStrategy_Name;
            }
            if (requestSamplingStrategy_samplingStrategy_Name != null)
            {
                request.SamplingStrategy.Name = requestSamplingStrategy_samplingStrategy_Name;
                requestSamplingStrategyIsNull = false;
            }
            System.Double? requestSamplingStrategy_samplingStrategy_Value = null;
            if (cmdletContext.SamplingStrategy_Value != null)
            {
                requestSamplingStrategy_samplingStrategy_Value = cmdletContext.SamplingStrategy_Value.Value;
            }
            if (requestSamplingStrategy_samplingStrategy_Value != null)
            {
                request.SamplingStrategy.Value = requestSamplingStrategy_samplingStrategy_Value.Value;
                requestSamplingStrategyIsNull = false;
            }
             // determine if request.SamplingStrategy should be set to null
            if (requestSamplingStrategyIsNull)
            {
                request.SamplingStrategy = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TimeRangeType != null)
            {
                request.TimeRangeType = cmdletContext.TimeRangeType;
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
            // create request
            var request = new Amazon.XRay.Model.GetTraceSummariesRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterExpression != null)
            {
                request.FilterExpression = cmdletContext.FilterExpression;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Sampling != null)
            {
                request.Sampling = cmdletContext.Sampling.Value;
            }
            
             // populate SamplingStrategy
            var requestSamplingStrategyIsNull = true;
            request.SamplingStrategy = new Amazon.XRay.Model.SamplingStrategy();
            Amazon.XRay.SamplingStrategyName requestSamplingStrategy_samplingStrategy_Name = null;
            if (cmdletContext.SamplingStrategy_Name != null)
            {
                requestSamplingStrategy_samplingStrategy_Name = cmdletContext.SamplingStrategy_Name;
            }
            if (requestSamplingStrategy_samplingStrategy_Name != null)
            {
                request.SamplingStrategy.Name = requestSamplingStrategy_samplingStrategy_Name;
                requestSamplingStrategyIsNull = false;
            }
            System.Double? requestSamplingStrategy_samplingStrategy_Value = null;
            if (cmdletContext.SamplingStrategy_Value != null)
            {
                requestSamplingStrategy_samplingStrategy_Value = cmdletContext.SamplingStrategy_Value.Value;
            }
            if (requestSamplingStrategy_samplingStrategy_Value != null)
            {
                request.SamplingStrategy.Value = requestSamplingStrategy_samplingStrategy_Value.Value;
                requestSamplingStrategyIsNull = false;
            }
             // determine if request.SamplingStrategy should be set to null
            if (requestSamplingStrategyIsNull)
            {
                request.SamplingStrategy = null;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.TimeRangeType != null)
            {
                request.TimeRangeType = cmdletContext.TimeRangeType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.XRay.Model.GetTraceSummariesResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.GetTraceSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "GetTraceSummaries");
            try
            {
                #if DESKTOP
                return client.GetTraceSummaries(request);
                #elif CORECLR
                return client.GetTraceSummariesAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public System.String FilterExpression { get; set; }
            public System.String NextToken { get; set; }
            public System.Boolean? Sampling { get; set; }
            public Amazon.XRay.SamplingStrategyName SamplingStrategy_Name { get; set; }
            public System.Double? SamplingStrategy_Value { get; set; }
            public System.DateTime? StartTime { get; set; }
            public Amazon.XRay.TimeRangeType TimeRangeType { get; set; }
            public System.Func<Amazon.XRay.Model.GetTraceSummariesResponse, GetXRTraceSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
