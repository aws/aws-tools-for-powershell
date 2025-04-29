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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a subscription filter and associates it with the specified log
    /// group. With subscription filters, you can subscribe to a real-time stream of log events
    /// ingested through <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutLogEvents.html">PutLogEvents</a>
    /// and have them delivered to a specific destination. When log events are sent to the
    /// receiving service, they are Base64 encoded and compressed with the GZIP format.
    /// 
    ///  
    /// <para>
    /// The following destinations are supported for subscription filters:
    /// </para><ul><li><para>
    /// An Amazon Kinesis data stream belonging to the same account as the subscription filter,
    /// for same-account delivery.
    /// </para></li><li><para>
    /// A logical destination created with <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDestination.html">PutDestination</a>
    /// that belongs to a different account, for cross-account delivery. We currently support
    /// Kinesis Data Streams and Firehose as logical destinations.
    /// </para></li><li><para>
    /// An Amazon Kinesis Data Firehose delivery stream that belongs to the same account as
    /// the subscription filter, for same-account delivery.
    /// </para></li><li><para>
    /// An Lambda function that belongs to the same account as the subscription filter, for
    /// same-account delivery.
    /// </para></li></ul><para>
    /// Each log group can have up to two subscription filters associated with it. If you
    /// are updating an existing filter, you must specify the correct name in <c>filterName</c>.
    /// 
    /// </para><para>
    /// Using regular expressions in filter patterns is supported. For these filters, there
    /// is a quotas of quota of two regular expression patterns within a single filter pattern.
    /// There is also a quota of five regular expression patterns per log group. For more
    /// information about using regular expressions in filter patterns, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">
    /// Filter pattern syntax for metric filters, subscription filters, filter log events,
    /// and Live Tail</a>.
    /// </para><para>
    /// To perform a <c>PutSubscriptionFilter</c> operation for any destination except a Lambda
    /// function, you must also have the <c>iam:PassRole</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLSubscriptionFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutSubscriptionFilter API operation.", Operation = new[] {"PutSubscriptionFilter"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLSubscriptionFilterCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplyOnTransformedLog
        /// <summary>
        /// <para>
        /// <para>This parameter is valid only for log groups that have an active log transformer. For
        /// more information about log transformers, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutTransformer.html">PutTransformer</a>.</para><para>If the log group uses either a log-group level or account-level transformer, and you
        /// specify <c>true</c>, the subscription filter will be applied on the transformed version
        /// of the log events instead of the original ingested log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplyOnTransformedLogs")]
        public System.Boolean? ApplyOnTransformedLog { get; set; }
        #endregion
        
        #region Parameter DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination to deliver matching log events to. Currently, the supported
        /// destinations are:</para><ul><li><para>An Amazon Kinesis stream belonging to the same account as the subscription filter,
        /// for same-account delivery.</para></li><li><para>A logical destination (specified using an ARN) belonging to a different account, for
        /// cross-account delivery.</para><para>If you're setting up a cross-account subscription, the destination must have an IAM
        /// policy associated with it. The IAM policy must allow the sender to send logs to the
        /// destination. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDestinationPolicy.html">PutDestinationPolicy</a>.</para></li><li><para>A Kinesis Data Firehose delivery stream belonging to the same account as the subscription
        /// filter, for same-account delivery.</para></li><li><para>A Lambda function belonging to the same account as the subscription filter, for same-account
        /// delivery.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DestinationArn { get; set; }
        #endregion
        
        #region Parameter Distribution
        /// <summary>
        /// <para>
        /// <para>The method used to distribute log data to the destination. By default, log data is
        /// grouped by log stream, but the grouping can be set to random for a more even distribution.
        /// This property is only applicable when the destination is an Amazon Kinesis data stream.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.Distribution")]
        public Amazon.CloudWatchLogs.Distribution Distribution { get; set; }
        #endregion
        
        #region Parameter FilterName
        /// <summary>
        /// <para>
        /// <para>A name for the subscription filter. If you are updating an existing filter, you must
        /// specify the correct name in <c>filterName</c>. To find the name of the filter currently
        /// associated with a log group, use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_DescribeSubscriptionFilters.html">DescribeSubscriptionFilters</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilterName { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern for subscribing to a filtered stream of log events.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
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
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that grants CloudWatch Logs permissions to deliver ingested
        /// log events to the destination stream. You don't need to provide the ARN when you are
        /// working with a logical destination for cross-account delivery.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLSubscriptionFilter (PutSubscriptionFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse, WriteCWLSubscriptionFilterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplyOnTransformedLog = this.ApplyOnTransformedLog;
            context.DestinationArn = this.DestinationArn;
            #if MODULAR
            if (this.DestinationArn == null && ParameterWasBound(nameof(this.DestinationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Distribution = this.Distribution;
            context.FilterName = this.FilterName;
            #if MODULAR
            if (this.FilterName == null && ParameterWasBound(nameof(this.FilterName)))
            {
                WriteWarning("You are passing $null as a value for parameter FilterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FilterPattern = this.FilterPattern;
            #if MODULAR
            if (this.FilterPattern == null && ParameterWasBound(nameof(this.FilterPattern)))
            {
                WriteWarning("You are passing $null as a value for parameter FilterPattern which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogGroupName = this.LogGroupName;
            #if MODULAR
            if (this.LogGroupName == null && ParameterWasBound(nameof(this.LogGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest();
            
            if (cmdletContext.ApplyOnTransformedLog != null)
            {
                request.ApplyOnTransformedLogs = cmdletContext.ApplyOnTransformedLog.Value;
            }
            if (cmdletContext.DestinationArn != null)
            {
                request.DestinationArn = cmdletContext.DestinationArn;
            }
            if (cmdletContext.Distribution != null)
            {
                request.Distribution = cmdletContext.Distribution;
            }
            if (cmdletContext.FilterName != null)
            {
                request.FilterName = cmdletContext.FilterName;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutSubscriptionFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutSubscriptionFilter");
            try
            {
                return client.PutSubscriptionFilterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyOnTransformedLog { get; set; }
            public System.String DestinationArn { get; set; }
            public Amazon.CloudWatchLogs.Distribution Distribution { get; set; }
            public System.String FilterName { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutSubscriptionFilterResponse, WriteCWLSubscriptionFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
