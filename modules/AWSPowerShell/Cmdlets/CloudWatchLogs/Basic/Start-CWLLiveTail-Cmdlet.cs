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
    /// Starts a Live Tail streaming session for one or more log groups. A Live Tail session
    /// returns a stream of log events that have been recently ingested in the log groups.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatchLogs_LiveTail.html">Use
    /// Live Tail to view logs in near real time</a>. 
    /// 
    ///  
    /// <para>
    /// The response to this operation is a response stream, over which the server sends live
    /// log events and the client receives them.
    /// </para><para>
    /// The following objects are sent over the stream:
    /// </para><ul><li><para>
    /// A single <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_LiveTailSessionStart.html">LiveTailSessionStart</a>
    /// object is sent at the start of the session.
    /// </para></li><li><para>
    /// Every second, a <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_LiveTailSessionUpdate.html">LiveTailSessionUpdate</a>
    /// object is sent. Each of these objects contains an array of the actual log events.
    /// </para><para>
    /// If no new log events were ingested in the past second, the <c>LiveTailSessionUpdate</c>
    /// object will contain an empty array.
    /// </para><para>
    /// The array of log events contained in a <c>LiveTailSessionUpdate</c> can include as
    /// many as 500 log events. If the number of log events matching the request exceeds 500
    /// per second, the log events are sampled down to 500 log events to be included in each
    /// <c>LiveTailSessionUpdate</c> object.
    /// </para><para>
    /// If your client consumes the log events slower than the server produces them, CloudWatch
    /// Logs buffers up to 10 <c>LiveTailSessionUpdate</c> events or 5000 log events, after
    /// which it starts dropping the oldest events.
    /// </para></li><li><para>
    /// A <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartLiveTailResponseStream.html#CWL-Type-StartLiveTailResponseStream-SessionStreamingException">SessionStreamingException</a>
    /// object is returned if an unknown error occurs on the server side.
    /// </para></li><li><para>
    /// A <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_StartLiveTailResponseStream.html#CWL-Type-StartLiveTailResponseStream-SessionTimeoutException">SessionTimeoutException</a>
    /// object is returned when the session times out, after it has been kept open for three
    /// hours.
    /// </para></li></ul><note><para>
    /// The <c>StartLiveTail</c> API routes requests to <c>streaming-logs.<i>Region</i>.amazonaws.com</c>
    /// using SDK host prefix injection. VPC endpoint support is not available for this API.
    /// </para></note><important><para>
    /// You can end a session before it times out by closing the session stream or by closing
    /// the client that is receiving the stream. The session also ends if the established
    /// connection between the client and the server breaks.
    /// </para></important><para>
    /// For examples of using an SDK to start a Live Tail session, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/example_cloudwatch-logs_StartLiveTail_section.html">
    /// Start a Live Tail session using an Amazon Web Services SDK</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CWLLiveTail", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.StartLiveTailResponseStream")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs StartLiveTail API operation.", Operation = new[] {"StartLiveTail"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.StartLiveTailResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.StartLiveTailResponseStream or Amazon.CloudWatchLogs.Model.StartLiveTailResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.StartLiveTailResponseStream object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.StartLiveTailResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartCWLLiveTailCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogEventFilterPattern
        /// <summary>
        /// <para>
        /// <para>An optional pattern to use to filter the results to include only log events that match
        /// the pattern. For example, a filter pattern of <c>error 404</c> causes only log events
        /// that include both <c>error</c> and <c>404</c> to be included in the Live Tail stream.</para><para>Regular expression filter patterns are supported.</para><para>For more information about filter pattern syntax, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">Filter
        /// and Pattern Syntax</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String LogEventFilterPattern { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>An array where each item in the array is a log group to include in the Live Tail session.</para><para>Specify each log group by its ARN. </para><para>If you specify an ARN, the ARN can't end with an asterisk (*).</para><note><para> You can include up to 10 log groups.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("LogGroupIdentifiers")]
        public System.String[] LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter LogStreamNamePrefix
        /// <summary>
        /// <para>
        /// <para>If you specify this parameter, then only log events in the log streams that have names
        /// that start with the prefixes that you specify here are included in the Live Tail session.</para><para>If you specify this field, you can't also specify the <c>logStreamNames</c> field.</para><note><para>You can specify this parameter only if you specify only one log group in <c>logGroupIdentifiers</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogStreamNamePrefixes")]
        public System.String[] LogStreamNamePrefix { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>If you specify this parameter, then only log events in the log streams that you specify
        /// here are included in the Live Tail session.</para><para>If you specify this field, you can't also specify the <c>logStreamNamePrefixes</c>
        /// field.</para><note><para>You can specify this parameter only if you specify only one log group in <c>logGroupIdentifiers</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogStreamNames")]
        public System.String[] LogStreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResponseStream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.StartLiveTailResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.StartLiveTailResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResponseStream";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogEventFilterPattern parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogEventFilterPattern' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogEventFilterPattern' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogEventFilterPattern), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CWLLiveTail (StartLiveTail)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.StartLiveTailResponse, StartCWLLiveTailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogEventFilterPattern;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LogEventFilterPattern = this.LogEventFilterPattern;
            if (this.LogGroupIdentifier != null)
            {
                context.LogGroupIdentifier = new List<System.String>(this.LogGroupIdentifier);
            }
            #if MODULAR
            if (this.LogGroupIdentifier == null && ParameterWasBound(nameof(this.LogGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LogStreamNamePrefix != null)
            {
                context.LogStreamNamePrefix = new List<System.String>(this.LogStreamNamePrefix);
            }
            if (this.LogStreamName != null)
            {
                context.LogStreamName = new List<System.String>(this.LogStreamName);
            }
            
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
            var request = new Amazon.CloudWatchLogs.Model.StartLiveTailRequest();
            
            if (cmdletContext.LogEventFilterPattern != null)
            {
                request.LogEventFilterPattern = cmdletContext.LogEventFilterPattern;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifiers = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.LogStreamNamePrefix != null)
            {
                request.LogStreamNamePrefixes = cmdletContext.LogStreamNamePrefix;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamNames = cmdletContext.LogStreamName;
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
        
        private Amazon.CloudWatchLogs.Model.StartLiveTailResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.StartLiveTailRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "StartLiveTail");
            try
            {
                #if DESKTOP
                return client.StartLiveTail(request);
                #elif CORECLR
                return client.StartLiveTailAsync(request).GetAwaiter().GetResult();
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
            public System.String LogEventFilterPattern { get; set; }
            public List<System.String> LogGroupIdentifier { get; set; }
            public List<System.String> LogStreamNamePrefix { get; set; }
            public List<System.String> LogStreamName { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.StartLiveTailResponse, StartCWLLiveTailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResponseStream;
        }
        
    }
}
