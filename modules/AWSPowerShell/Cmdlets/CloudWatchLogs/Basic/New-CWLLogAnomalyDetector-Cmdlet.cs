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
    /// Creates an <i>anomaly detector</i> that regularly scans one or more log groups and
    /// look for patterns and anomalies in the logs.
    /// 
    ///  
    /// <para>
    /// An anomaly detector can help surface issues by automatically discovering anomalies
    /// in your log event traffic. An anomaly detector uses machine learning algorithms to
    /// scan log events and find <i>patterns</i>. A pattern is a shared text structure that
    /// recurs among your log fields. Patterns provide a useful tool for analyzing large sets
    /// of logs because a large number of log events can often be compressed into a few patterns.
    /// </para><para>
    /// The anomaly detector uses pattern recognition to find <c>anomalies</c>, which are
    /// unusual log events. It uses the <c>evaluationFrequency</c> to compare current log
    /// events and patterns with trained baselines. 
    /// </para><para>
    /// Fields within a pattern are called <i>tokens</i>. Fields that vary within a pattern,
    /// such as a request ID or timestamp, are referred to as <i>dynamic tokens</i> and represented
    /// by <c>&lt;*&gt;</c>. 
    /// </para><para>
    /// The following is an example of a pattern:
    /// </para><para><c>[INFO] Request time: &lt;*&gt; ms</c></para><para>
    /// This pattern represents log events like <c>[INFO] Request time: 327 ms</c> and other
    /// similar log events that differ only by the number, in this csse 327. When the pattern
    /// is displayed, the different numbers are replaced by <c>&lt;*&gt;</c></para><note><para>
    /// Any parts of log events that are masked as sensitive data are not scanned for anomalies.
    /// For more information about masking sensitive data, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/mask-sensitive-log-data.html">Help
    /// protect sensitive log data with masking</a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "CWLLogAnomalyDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs CreateLogAnomalyDetector API operation.", Operation = new[] {"CreateLogAnomalyDetector"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWLLogAnomalyDetectorCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyVisibilityTime
        /// <summary>
        /// <para>
        /// <para>The number of days to have visibility on an anomaly. After this time period has elapsed
        /// for an anomaly, it will be automatically baselined and the anomaly detector will treat
        /// new occurrences of a similar anomaly as normal. Therefore, if you do not correct the
        /// cause of an anomaly during the time period specified in <c>anomalyVisibilityTime</c>,
        /// it will be considered normal going forward and will not be detected as an anomaly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? AnomalyVisibilityTime { get; set; }
        #endregion
        
        #region Parameter DetectorName
        /// <summary>
        /// <para>
        /// <para>A name for this anomaly detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DetectorName { get; set; }
        #endregion
        
        #region Parameter EvaluationFrequency
        /// <summary>
        /// <para>
        /// <para>Specifies how often the anomaly detector is to run and look for anomalies. Set this
        /// value according to the frequency that the log group receives new logs. For example,
        /// if the log group receives new log events every 10 minutes, then 15 minutes might be
        /// a good setting for <c>evaluationFrequency</c> .</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.EvaluationFrequency")]
        public Amazon.CloudWatchLogs.EvaluationFrequency EvaluationFrequency { get; set; }
        #endregion
        
        #region Parameter FilterPattern
        /// <summary>
        /// <para>
        /// <para>You can use this parameter to limit the anomaly detection model to examine only log
        /// events that match the pattern you specify here. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">Filter
        /// and Pattern Syntax</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterPattern { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>Optionally assigns a KMS key to secure this anomaly detector and its findings. If
        /// a key is assigned, the anomalies found and the model used by this detector are encrypted
        /// at rest with the key. If a key is assigned to an anomaly detector, a user must have
        /// permissions for both this key and for the anomaly detector to retrieve information
        /// about the anomalies that it finds.</para><para> Make sure the value provided is a valid KMS key ARN. For more information about using
        /// a KMS key and to see the required IAM policy, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/LogsAnomalyDetection-KMS.html">Use
        /// a KMS key with an anomaly detector</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter LogGroupArnList
        /// <summary>
        /// <para>
        /// <para>An array containing the ARN of the log group that this anomaly detector will watch.
        /// You can specify only one log group ARN.</para>
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
        public System.String[] LogGroupArnList { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An optional list of key-value pairs to associate with the resource.</para><para>For more information about tagging, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws_tagging.html">Tagging
        /// Amazon Web Services resources</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnomalyDetectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnomalyDetectorArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLLogAnomalyDetector (CreateLogAnomalyDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse, NewCWLLogAnomalyDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyVisibilityTime = this.AnomalyVisibilityTime;
            context.DetectorName = this.DetectorName;
            context.EvaluationFrequency = this.EvaluationFrequency;
            context.FilterPattern = this.FilterPattern;
            context.KmsKeyId = this.KmsKeyId;
            if (this.LogGroupArnList != null)
            {
                context.LogGroupArnList = new List<System.String>(this.LogGroupArnList);
            }
            #if MODULAR
            if (this.LogGroupArnList == null && ParameterWasBound(nameof(this.LogGroupArnList)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupArnList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorRequest();
            
            if (cmdletContext.AnomalyVisibilityTime != null)
            {
                request.AnomalyVisibilityTime = cmdletContext.AnomalyVisibilityTime.Value;
            }
            if (cmdletContext.DetectorName != null)
            {
                request.DetectorName = cmdletContext.DetectorName;
            }
            if (cmdletContext.EvaluationFrequency != null)
            {
                request.EvaluationFrequency = cmdletContext.EvaluationFrequency;
            }
            if (cmdletContext.FilterPattern != null)
            {
                request.FilterPattern = cmdletContext.FilterPattern;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.LogGroupArnList != null)
            {
                request.LogGroupArnList = cmdletContext.LogGroupArnList;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "CreateLogAnomalyDetector");
            try
            {
                return client.CreateLogAnomalyDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int64? AnomalyVisibilityTime { get; set; }
            public System.String DetectorName { get; set; }
            public Amazon.CloudWatchLogs.EvaluationFrequency EvaluationFrequency { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String KmsKeyId { get; set; }
            public List<System.String> LogGroupArnList { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.CreateLogAnomalyDetectorResponse, NewCWLLogAnomalyDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnomalyDetectorArn;
        }
        
    }
}
