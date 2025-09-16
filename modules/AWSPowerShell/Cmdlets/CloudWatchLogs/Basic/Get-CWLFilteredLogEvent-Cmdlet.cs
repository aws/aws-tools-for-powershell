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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Lists log events from the specified log group. You can list all the log events or
    /// filter the results using one or more of the following:
    /// 
    ///  <ul><li><para>
    /// A filter pattern
    /// </para></li><li><para>
    /// A time range
    /// </para></li><li><para>
    /// The log stream name, or a log stream name prefix that matches multiple log streams
    /// </para></li></ul><para>
    /// You must have the <c>logs:FilterLogEvents</c> permission to perform this operation.
    /// </para><para>
    /// You can specify the log group to search by using either <c>logGroupIdentifier</c>
    /// or <c>logGroupName</c>. You must include one of these two parameters, but you can't
    /// include both. 
    /// </para><para><c>FilterLogEvents</c> is a paginated operation. Each page returned can contain up
    /// to 1 MB of log events or up to 10,000 log events. A returned page might only be partially
    /// full, or even empty. For example, if the result of a query would return 15,000 log
    /// events, the first page isn't guaranteed to have 10,000 log events even if they all
    /// fit into 1 MB.
    /// </para><para>
    /// Partially full or empty pages don't necessarily mean that pagination is finished.
    /// If the results include a <c>nextToken</c>, there might be more log events available.
    /// You can return these additional log events by providing the nextToken in a subsequent
    /// <c>FilterLogEvents</c> operation. If the results don't include a <c>nextToken</c>,
    /// then pagination is finished. 
    /// </para><para>
    /// Specifying the <c>limit</c> parameter only guarantees that a single page doesn't return
    /// more log events than the specified limit, but it might return fewer events than the
    /// limit. This is the expected API behavior.
    /// </para><para>
    /// The returned log events are sorted by event timestamp, the timestamp when the event
    /// was ingested by CloudWatch Logs, and the ID of the <c>PutLogEvents</c> request.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability, you can use this operation
    /// in a monitoring account and view data from the linked source accounts. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// </para><note><para>
    /// If you are using <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatch-Logs-Transformation.html">log
    /// transformation</a>, the <c>FilterLogEvents</c> operation returns only the original
    /// versions of log events, before they were transformed. To view the transformed versions,
    /// you must use a <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/AnalyzingLogData.html">CloudWatch
    /// Logs query.</a></para></note><br/><br/>In the AWS.Tools.CloudWatchLogs module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWLFilteredLogEvent")]
    [OutputType("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs FilterLogEvents API operation.", Operation = new[] {"FilterLogEvents"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.FilterLogEventsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.FilterLogEventsResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.FilterLogEventsResponse object containing multiple properties."
    )]
    public partial class GetCWLFilteredLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range, expressed as the number of milliseconds after <c>Jan 1,
        /// 1970 00:00:00 UTC</c>. Events with a timestamp later than this time are not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? EndTime { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>The filter pattern to use. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">Filter
        /// and Pattern Syntax</a>.</para><para>If not provided, all the events are matched.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Specify either the name or ARN of the log group to view log events from. If the log
        /// group is in a source account and you are using a monitoring account, you must use
        /// the log group ARN.</para><note><para> You must include either <c>logGroupIdentifier</c> or <c>logGroupName</c>, but not
        /// both. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group to search.</para><note><para> You must include either <c>logGroupIdentifier</c> or <c>logGroupName</c>, but not
        /// both. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>Filters the results to include only events from log streams that have names starting
        /// with this prefix.</para><para>If you specify a value for both <c>logStreamNamePrefix</c> and <c>logStreamNames</c>,
        /// the action returns an <c>InvalidParameterException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>Filters the results to only logs from the log streams in this list.</para><para>If you specify a value for both <c>logStreamNames</c> and <c>logStreamNamePrefix</c>,
        /// the action returns an <c>InvalidParameterException</c> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogStreamNames")]
        public System.String[] LogStreamName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range, expressed as the number of milliseconds after <c>Jan
        /// 1, 1970 00:00:00 UTC</c>. Events with a timestamp before this time are not returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StartTime { get; set; }
        #endregion
        
        #region Parameter Unmask
        /// <summary>
        /// <para>
        /// <para>Specify <c>true</c> to display the log event fields with all sensitive data unmasked
        /// and visible. The default is <c>false</c>.</para><para>To use this operation with this parameter, you must be signed into an account with
        /// the <c>logs:Unmask</c> permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Unmask { get; set; }
        #endregion
        
        #region Parameter Interleaved
        /// <summary>
        /// <para>
        /// <para>If the value is true, the operation attempts to provide responses that contain events
        /// from multiple log streams within the log group, interleaved in a single response.
        /// If the value is false, all the matched log events in the first log stream are searched
        /// first, then those in the next log stream, and so on.</para><para><b>Important</b> As of June 17, 2019, this parameter is ignored and the value is
        /// assumed to be true. The response from this operation always interleaves events from
        /// multiple log streams within a log group.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Starting on June 17, 2019, this parameter will be ignored and the value will be assumed to be true. The response from this operation will always interleave events from multiple log streams within a log group.")]
        public System.Boolean? Interleaved { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of events to return. The default is 10,000 events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of events to return. (You received this token from a previous
        /// call.)</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CloudWatchLogs module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.FilterLogEventsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.FilterLogEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.FilterLogEventsResponse, GetCWLFilteredLogEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EndTime = this.EndTime;
            context.FilterPattern = this.FilterPattern;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Interleaved = this.Interleaved;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Limit = this.Limit;
            context.LogGroupIdentifier = this.LogGroupIdentifier;
            context.LogGroupName = this.LogGroupName;
            context.LogStreamNamePrefix = this.LogStreamNamePrefix;
            if (this.LogStreamName != null)
            {
                context.LogStreamName = new List<System.String>(this.LogStreamName);
            }
            context.NextToken = this.NextToken;
            context.StartTime = this.StartTime;
            context.Unmask = this.Unmask;
            
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
            var request = new Amazon.CloudWatchLogs.Model.FilterLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Interleaved != null)
            {
                request.Interleaved = cmdletContext.Interleaved.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifier = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefix = cmdletContext.LogStreamNamePrefix;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamNames = cmdletContext.LogStreamName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Unmask != null)
            {
                request.Unmask = cmdletContext.Unmask.Value;
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
            var request = new Amazon.CloudWatchLogs.Model.FilterLogEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Interleaved != null)
            {
                request.Interleaved = cmdletContext.Interleaved.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifier = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefix = cmdletContext.LogStreamNamePrefix;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamNames = cmdletContext.LogStreamName;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            if (cmdletContext.Unmask != null)
            {
                request.Unmask = cmdletContext.Unmask.Value;
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
        
        private Amazon.CloudWatchLogs.Model.FilterLogEventsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.FilterLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "FilterLogEvents");
            try
            {
                #if DESKTOP
                return client.FilterLogEvents(request);
                #elif CORECLR
                return client.FilterLogEventsAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? EndTime { get; set; }
            public System.String FilterPattern { get; set; }
            [System.ObsoleteAttribute]
            public System.Boolean? Interleaved { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String LogGroupIdentifier { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamNamePrefix { get; set; }
            public List<System.String> LogStreamName { get; set; }
            public System.String NextToken { get; set; }
            public System.Int64? StartTime { get; set; }
            public System.Boolean? Unmask { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.FilterLogEventsResponse, GetCWLFilteredLogEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
