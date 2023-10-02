/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Creates or updates a metric stream. Metric streams can automatically stream CloudWatch
    /// metrics to Amazon Web Services destinations, including Amazon S3, and to many third-party
    /// solutions.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Metric-Streams.html">
    /// Using Metric Streams</a>.
    /// </para><para>
    /// To create a metric stream, you must be signed in to an account that has the <code>iam:PassRole</code>
    /// permission and either the <code>CloudWatchFullAccess</code> policy or the <code>cloudwatch:PutMetricStream</code>
    /// permission.
    /// </para><para>
    /// When you create or update a metric stream, you choose one of the following:
    /// </para><ul><li><para>
    /// Stream metrics from all metric namespaces in the account.
    /// </para></li><li><para>
    /// Stream metrics from all metric namespaces in the account, except for the namespaces
    /// that you list in <code>ExcludeFilters</code>.
    /// </para></li><li><para>
    /// Stream metrics from only the metric namespaces that you list in <code>IncludeFilters</code>.
    /// </para></li></ul><para>
    /// By default, a metric stream always sends the <code>MAX</code>, <code>MIN</code>, <code>SUM</code>,
    /// and <code>SAMPLECOUNT</code> statistics for each metric that is streamed. You can
    /// use the <code>StatisticsConfigurations</code> parameter to have the metric stream
    /// send additional statistics in the stream. Streaming additional statistics incurs additional
    /// costs. For more information, see <a href="https://aws.amazon.com/cloudwatch/pricing/">Amazon
    /// CloudWatch Pricing</a>. 
    /// </para><para>
    /// When you use <code>PutMetricStream</code> to create a new metric stream, the stream
    /// is created in the <code>running</code> state. If you use it to update an existing
    /// stream, the state of the stream is not changed.
    /// </para><para>
    /// If you are using CloudWatch cross-account observability and you create a metric stream
    /// in a monitoring account, you can choose whether to include metrics from source accounts
    /// in the stream. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-Unified-Cross-Account.html">CloudWatch
    /// cross-account observability</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWMetricStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch PutMetricStream API operation.", Operation = new[] {"PutMetricStream"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.PutMetricStreamResponse))]
    [AWSCmdletOutput("System.String or Amazon.CloudWatch.Model.PutMetricStreamResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatch.Model.PutMetricStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWMetricStreamCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExcludeFilter
        /// <summary>
        /// <para>
        /// <para>If you specify this parameter, the stream sends metrics from all metric namespaces
        /// except for the namespaces that you specify here.</para><para>You cannot include <code>ExcludeFilters</code> and <code>IncludeFilters</code> in
        /// the same operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeFilters")]
        public Amazon.CloudWatch.Model.MetricStreamFilter[] ExcludeFilter { get; set; }
        #endregion
        
        #region Parameter FirehoseArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Kinesis Data Firehose delivery stream to use for this metric
        /// stream. This Amazon Kinesis Data Firehose delivery stream must already exist and must
        /// be in the same account as the metric stream.</para>
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
        public System.String FirehoseArn { get; set; }
        #endregion
        
        #region Parameter IncludeFilter
        /// <summary>
        /// <para>
        /// <para>If you specify this parameter, the stream sends only the metrics from the metric namespaces
        /// that you specify here.</para><para>You cannot include <code>IncludeFilters</code> and <code>ExcludeFilters</code> in
        /// the same operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeFilters")]
        public Amazon.CloudWatch.Model.MetricStreamFilter[] IncludeFilter { get; set; }
        #endregion
        
        #region Parameter IncludeLinkedAccountsMetric
        /// <summary>
        /// <para>
        /// <para>If you are creating a metric stream in a monitoring account, specify <code>true</code>
        /// to include metrics from source accounts in the metric stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeLinkedAccountsMetrics")]
        public System.Boolean? IncludeLinkedAccountsMetric { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>If you are creating a new metric stream, this is the name for the new stream. The
        /// name must be different than the names of other metric streams in this account and
        /// Region.</para><para>If you are updating a metric stream, specify the name of that stream here.</para><para>Valid characters are A-Z, a-z, 0-9, "-" and "_".</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OutputFormat
        /// <summary>
        /// <para>
        /// <para>The output format for the stream. Valid values are <code>json</code> and <code>opentelemetry0.7</code>.
        /// For more information about metric stream output formats, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch-metric-streams-formats.html">
        /// Metric streams output formats</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatch.MetricStreamOutputFormat")]
        public Amazon.CloudWatch.MetricStreamOutputFormat OutputFormat { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that this metric stream will use to access Amazon Kinesis Data
        /// Firehose resources. This IAM role must already exist and must be in the same account
        /// as the metric stream. This IAM role must include the following permissions:</para><ul><li><para>firehose:PutRecord</para></li><li><para>firehose:PutRecordBatch</para></li></ul>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter StatisticsConfiguration
        /// <summary>
        /// <para>
        /// <para>By default, a metric stream always sends the <code>MAX</code>, <code>MIN</code>, <code>SUM</code>,
        /// and <code>SAMPLECOUNT</code> statistics for each metric that is streamed. You can
        /// use this parameter to have the metric stream also send additional statistics in the
        /// stream. This array can have up to 100 members.</para><para>For each entry in this array, you specify one or more metrics and the list of additional
        /// statistics to stream for those metrics. The additional statistics that you can stream
        /// depend on the stream's <code>OutputFormat</code>. If the <code>OutputFormat</code>
        /// is <code>json</code>, you can stream any additional statistic that is supported by
        /// CloudWatch, listed in <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/Statistics-definitions.html.html">
        /// CloudWatch statistics definitions</a>. If the <code>OutputFormat</code> is <code>opentelemetry0.7</code>,
        /// you can stream percentile statistics such as p95, p99.9, and so on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatisticsConfigurations")]
        public Amazon.CloudWatch.Model.MetricStreamStatisticsConfiguration[] StatisticsConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the metric stream. You can associate as
        /// many as 50 tags with a metric stream.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions by granting a user permission to access or change only resources
        /// with certain tag values.</para><para>You can use this parameter only when you are creating a new metric stream. If you
        /// are using this operation to update an existing metric stream, any tags you specify
        /// in this parameter are ignored. To change the tags of an existing metric stream, use
        /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_TagResource.html">TagResource</a>
        /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_UntagResource.html">UntagResource</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CloudWatch.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.PutMetricStreamResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.PutMetricStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWMetricStream (PutMetricStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.PutMetricStreamResponse, WriteCWMetricStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ExcludeFilter != null)
            {
                context.ExcludeFilter = new List<Amazon.CloudWatch.Model.MetricStreamFilter>(this.ExcludeFilter);
            }
            context.FirehoseArn = this.FirehoseArn;
            #if MODULAR
            if (this.FirehoseArn == null && ParameterWasBound(nameof(this.FirehoseArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirehoseArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.IncludeFilter != null)
            {
                context.IncludeFilter = new List<Amazon.CloudWatch.Model.MetricStreamFilter>(this.IncludeFilter);
            }
            context.IncludeLinkedAccountsMetric = this.IncludeLinkedAccountsMetric;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputFormat = this.OutputFormat;
            #if MODULAR
            if (this.OutputFormat == null && ParameterWasBound(nameof(this.OutputFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StatisticsConfiguration != null)
            {
                context.StatisticsConfiguration = new List<Amazon.CloudWatch.Model.MetricStreamStatisticsConfiguration>(this.StatisticsConfiguration);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CloudWatch.Model.Tag>(this.Tag);
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
            var request = new Amazon.CloudWatch.Model.PutMetricStreamRequest();
            
            if (cmdletContext.ExcludeFilter != null)
            {
                request.ExcludeFilters = cmdletContext.ExcludeFilter;
            }
            if (cmdletContext.FirehoseArn != null)
            {
                request.FirehoseArn = cmdletContext.FirehoseArn;
            }
            if (cmdletContext.IncludeFilter != null)
            {
                request.IncludeFilters = cmdletContext.IncludeFilter;
            }
            if (cmdletContext.IncludeLinkedAccountsMetric != null)
            {
                request.IncludeLinkedAccountsMetrics = cmdletContext.IncludeLinkedAccountsMetric.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OutputFormat != null)
            {
                request.OutputFormat = cmdletContext.OutputFormat;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.StatisticsConfiguration != null)
            {
                request.StatisticsConfigurations = cmdletContext.StatisticsConfiguration;
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
        
        private Amazon.CloudWatch.Model.PutMetricStreamResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.PutMetricStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "PutMetricStream");
            try
            {
                #if DESKTOP
                return client.PutMetricStream(request);
                #elif CORECLR
                return client.PutMetricStreamAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatch.Model.MetricStreamFilter> ExcludeFilter { get; set; }
            public System.String FirehoseArn { get; set; }
            public List<Amazon.CloudWatch.Model.MetricStreamFilter> IncludeFilter { get; set; }
            public System.Boolean? IncludeLinkedAccountsMetric { get; set; }
            public System.String Name { get; set; }
            public Amazon.CloudWatch.MetricStreamOutputFormat OutputFormat { get; set; }
            public System.String RoleArn { get; set; }
            public List<Amazon.CloudWatch.Model.MetricStreamStatisticsConfiguration> StatisticsConfiguration { get; set; }
            public List<Amazon.CloudWatch.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.CloudWatch.Model.PutMetricStreamResponse, WriteCWMetricStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
