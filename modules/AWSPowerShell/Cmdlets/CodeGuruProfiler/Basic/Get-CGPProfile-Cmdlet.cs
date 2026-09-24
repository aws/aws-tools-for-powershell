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
using Amazon.CodeGuruProfiler;
using Amazon.CodeGuruProfiler.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGP
{
    /// <summary>
    /// Gets the aggregated profile of a profiling group for a specified time range. Amazon
    /// CodeGuru Profiler collects posted agent profiles for a profiling group into aggregated
    /// profiles. 
    /// 
    ///  <note><para>
    ///  Because aggregated profiles expire over time <c>GetProfile</c> is not idempotent.
    /// 
    /// </para></note><para>
    ///  Specify the time range for the requested aggregated profile using 1 or 2 of the following
    /// parameters: <c>startTime</c>, <c>endTime</c>, <c>period</c>. The maximum time range
    /// allowed is 7 days. If you specify all 3 parameters, an exception is thrown. If you
    /// specify only <c>period</c>, the latest aggregated profile is returned. 
    /// </para><para>
    ///  Aggregated profiles are available with aggregation periods of 5 minutes, 1 hour,
    /// and 1 day, aligned to UTC. The aggregation period of an aggregated profile determines
    /// how long it is retained. For more information, see <a href="https://docs.aws.amazon.com/codeguru/latest/profiler-api/API_AggregatedProfileTime.html"><c>AggregatedProfileTime</c></a>. The aggregated profile's aggregation period determines
    /// how long it is retained by CodeGuru Profiler. 
    /// </para><ul><li><para>
    ///  If the aggregation period is 5 minutes, the aggregated profile is retained for 15
    /// days. 
    /// </para></li><li><para>
    ///  If the aggregation period is 1 hour, the aggregated profile is retained for 60 days.
    /// 
    /// </para></li><li><para>
    ///  If the aggregation period is 1 day, the aggregated profile is retained for 3 years.
    /// 
    /// </para></li></ul><para>
    /// There are two use cases for calling <c>GetProfile</c>.
    /// </para><ol><li><para>
    ///  If you want to return an aggregated profile that already exists, use <a href="https://docs.aws.amazon.com/codeguru/latest/profiler-api/API_ListProfileTimes.html"><c>ListProfileTimes</c></a> to view the time ranges of existing aggregated profiles.
    /// Use them in a <c>GetProfile</c> request to return a specific, existing aggregated
    /// profile. 
    /// </para></li><li><para>
    ///  If you want to return an aggregated profile for a time range that doesn't align with
    /// an existing aggregated profile, then CodeGuru Profiler makes a best effort to combine
    /// existing aggregated profiles from the requested time range and return them as one
    /// aggregated profile. 
    /// </para><para>
    ///  If aggregated profiles do not exist for the full time range requested, then aggregated
    /// profiles for a smaller time range are returned. For example, if the requested time
    /// range is from 00:00 to 00:20, and the existing aggregated profiles are from 00:15
    /// and 00:25, then the aggregated profiles from 00:15 to 00:20 are returned. 
    /// </para></li></ol>
    /// </summary>
    [Cmdlet("Get", "CGPProfile")]
    [OutputType("Amazon.CodeGuruProfiler.Model.GetProfileResponse")]
    [AWSCmdlet("Calls the Amazon CodeGuru Profiler GetProfile API operation.", Operation = new[] {"GetProfile"}, SelectReturnType = typeof(Amazon.CodeGuruProfiler.Model.GetProfileResponse))]
    [AWSCmdletOutput("Amazon.CodeGuruProfiler.Model.GetProfileResponse",
        "This cmdlet returns an Amazon.CodeGuruProfiler.Model.GetProfileResponse object containing multiple properties."
    )]
    public partial class GetCGPProfileCmdlet : AmazonCodeGuruProfilerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para> The format of the returned profiling data. The format maps to the <c>Accept</c> and
        /// <c>Content-Type</c> headers of the HTTP request. You can specify one of the following:
        /// or the default . </para><ul><li><para><c>application/json</c> — standard JSON format </para></li><li><para><c>application/x-amzn-ion</c> — the Amazon Ion data format. For more information,
        /// see <a href="http://amzn.github.io/ion-docs/">Amazon Ion</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para> The end time of the requested profile. Specify using the ISO 8601 format. For example,
        /// 2020-06-01T13:15:02.001Z represents 1 millisecond past June 1, 2020 1:15:02 PM UTC.
        /// </para><para> If you specify <c>endTime</c>, then you must also specify <c>period</c> or <c>startTime</c>,
        /// but not both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter MaxDepth
        /// <summary>
        /// <para>
        /// <para> The maximum depth of the stacks in the code that is represented in the aggregated
        /// profile. For example, if CodeGuru Profiler finds a method <c>A</c>, which calls method
        /// <c>B</c>, which calls method <c>C</c>, which calls method <c>D</c>, then the depth
        /// is 4. If the <c>maxDepth</c> is set to 2, then the aggregated profile contains representations
        /// of methods <c>A</c> and <c>B</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxDepth { get; set; }
        #endregion
        
        #region Parameter Period
        /// <summary>
        /// <para>
        /// <para> Used with <c>startTime</c> or <c>endTime</c> to specify the time range for the returned
        /// aggregated profile. Specify using the ISO 8601 format. For example, <c>P1DT1H1M1S</c>.
        /// </para><para> To get the latest aggregated profile, specify only <c>period</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Period { get; set; }
        #endregion
        
        #region Parameter ProfilingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the profiling group to get.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ProfilingGroupName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time of the profile to get. Specify using the ISO 8601 format. For example,
        /// 2020-06-01T13:15:02.001Z represents 1 millisecond past June 1, 2020 1:15:02 PM UTC.</para><para> If you specify <c>startTime</c>, then you must also specify <c>period</c> or <c>endTime</c>,
        /// but not both. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeGuruProfiler.Model.GetProfileResponse).
        /// Specifying the name of a property of type Amazon.CodeGuruProfiler.Model.GetProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.CodeGuruProfiler.Model.GetProfileResponse, GetCGPProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            context.EndTime = this.EndTime;
            context.MaxDepth = this.MaxDepth;
            context.Period = this.Period;
            context.ProfilingGroupName = this.ProfilingGroupName;
            #if MODULAR
            if (this.ProfilingGroupName == null && ParameterWasBound(nameof(this.ProfilingGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfilingGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CodeGuruProfiler.Model.GetProfileRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.MaxDepth != null)
            {
                request.MaxDepth = cmdletContext.MaxDepth.Value;
            }
            if (cmdletContext.Period != null)
            {
                request.Period = cmdletContext.Period;
            }
            if (cmdletContext.ProfilingGroupName != null)
            {
                request.ProfilingGroupName = cmdletContext.ProfilingGroupName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeGuruProfiler.Model.GetProfileResponse CallAWSServiceOperation(IAmazonCodeGuruProfiler client, Amazon.CodeGuruProfiler.Model.GetProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CodeGuru Profiler", "GetProfile");
            try
            {
                return client.GetProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Accept { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.Int32? MaxDepth { get; set; }
            public System.String Period { get; set; }
            public System.String ProfilingGroupName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.CodeGuruProfiler.Model.GetProfileResponse, GetCGPProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
