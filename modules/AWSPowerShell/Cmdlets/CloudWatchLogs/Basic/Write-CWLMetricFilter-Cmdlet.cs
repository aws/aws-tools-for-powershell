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
    /// Creates or updates a metric filter and associates it with the specified log group.
    /// With metric filters, you can configure rules to extract metric data from log events
    /// ingested through <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutLogEvents.html">PutLogEvents</a>.
    /// 
    ///  
    /// <para>
    /// The maximum number of metric filters that can be associated with a log group is 100.
    /// </para><para>
    /// Using regular expressions in filter patterns is supported. For these filters, there
    /// is a quota of two regular expression patterns within a single filter pattern. There
    /// is also a quota of five regular expression patterns per log group. For more information
    /// about using regular expressions in filter patterns, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html">
    /// Filter pattern syntax for metric filters, subscription filters, filter log events,
    /// and Live Tail</a>.
    /// </para><para>
    /// When you create a metric filter, you can also optionally assign a unit and dimensions
    /// to the metric that is created.
    /// </para><important><para>
    /// Metrics extracted from log events are charged as custom metrics. To prevent unexpected
    /// high charges, do not specify high-cardinality fields such as <c>IPAddress</c> or <c>requestID</c>
    /// as dimensions. Each different value found for a dimension is treated as a separate
    /// metric and accrues charges as a separate custom metric. 
    /// </para><para>
    /// CloudWatch Logs might disable a metric filter if it generates 1,000 different name/value
    /// pairs for your specified dimensions within one hour.
    /// </para><para>
    /// You can also set up a billing alarm to alert you if your charges are higher than expected.
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/monitor_estimated_charges_with_cloudwatch.html">
    /// Creating a Billing Alarm to Monitor Your Estimated Amazon Web Services Charges</a>.
    /// 
    /// </para></important>
    /// </summary>
    [Cmdlet("Write", "CWLMetricFilter", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutMetricFilter API operation.", Operation = new[] {"PutMetricFilter"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutMetricFilterResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.PutMetricFilterResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.PutMetricFilterResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLMetricFilterCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplyOnTransformedLog
        /// <summary>
        /// <para>
        /// <para>This parameter is valid only for log groups that have an active log transformer. For
        /// more information about log transformers, see <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutTransformer.html">PutTransformer</a>.</para><para>If the log group uses either a log-group level or account-level transformer, and you
        /// specify <c>true</c>, the metric filter will be applied on the transformed version
        /// of the log events instead of the original ingested log events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApplyOnTransformedLogs")]
        public System.Boolean? ApplyOnTransformedLog { get; set; }
        #endregion
        
        #region Parameter EmitSystemFieldDimension
        /// <summary>
        /// <para>
        /// <para>A list of system fields to emit as additional dimensions in the generated metrics.
        /// Valid values are <c>@aws.account</c> and <c>@aws.region</c>. These dimensions help
        /// identify the source of centralized log data and count toward the total dimension limit
        /// for metric filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmitSystemFieldDimensions")]
        public System.String[] EmitSystemFieldDimension { get; set; }
        #endregion
        
        #region Parameter FieldSelectionCriterion
        /// <summary>
        /// <para>
        /// <para>A filter expression that specifies which log events should be processed by this metric
        /// filter based on system fields such as source account and source region. Uses selection
        /// criteria syntax with operators like <c>=</c>, <c>!=</c>, <c>AND</c>, <c>OR</c>, <c>IN</c>,
        /// <c>NOT IN</c>. Example: <c>@aws.region = "us-east-1"</c> or <c>@aws.account IN ["123456789012",
        /// "987654321098"]</c>. Maximum length: 2000 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FieldSelectionCriteria")]
        public System.String FieldSelectionCriterion { get; set; }
        #endregion
        
        #region Parameter FilterName
        /// <summary>
        /// <para>
        /// <para>A name for the metric filter.</para>
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
        /// <para>A filter pattern for extracting metric data out of ingested log events.</para>
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
        
        #region Parameter MetricTransformation
        /// <summary>
        /// <para>
        /// <para>A collection of information that defines how metric data gets emitted.</para>
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
        [Alias("MetricTransformations")]
        public Amazon.CloudWatchLogs.Model.MetricTransformation[] MetricTransformation { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutMetricFilterResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLMetricFilter (PutMetricFilter)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutMetricFilterResponse, WriteCWLMetricFilterCmdlet>(Select) ??
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
            context.ApplyOnTransformedLog = this.ApplyOnTransformedLog;
            if (this.EmitSystemFieldDimension != null)
            {
                context.EmitSystemFieldDimension = new List<System.String>(this.EmitSystemFieldDimension);
            }
            context.FieldSelectionCriterion = this.FieldSelectionCriterion;
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
            if (this.MetricTransformation != null)
            {
                context.MetricTransformation = new List<Amazon.CloudWatchLogs.Model.MetricTransformation>(this.MetricTransformation);
            }
            #if MODULAR
            if (this.MetricTransformation == null && ParameterWasBound(nameof(this.MetricTransformation)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricTransformation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.CloudWatchLogs.Model.PutMetricFilterRequest();
            
            if (cmdletContext.ApplyOnTransformedLog != null)
            {
                request.ApplyOnTransformedLogs = cmdletContext.ApplyOnTransformedLog.Value;
            }
            if (cmdletContext.EmitSystemFieldDimension != null)
            {
                request.EmitSystemFieldDimensions = cmdletContext.EmitSystemFieldDimension;
            }
            if (cmdletContext.FieldSelectionCriterion != null)
            {
                request.FieldSelectionCriteria = cmdletContext.FieldSelectionCriterion;
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
            if (cmdletContext.MetricTransformation != null)
            {
                request.MetricTransformations = cmdletContext.MetricTransformation;
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
        
        private Amazon.CloudWatchLogs.Model.PutMetricFilterResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutMetricFilterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutMetricFilter");
            try
            {
                #if DESKTOP
                return client.PutMetricFilter(request);
                #elif CORECLR
                return client.PutMetricFilterAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ApplyOnTransformedLog { get; set; }
            public List<System.String> EmitSystemFieldDimension { get; set; }
            public System.String FieldSelectionCriterion { get; set; }
            public System.String FilterName { get; set; }
            public System.String FilterPattern { get; set; }
            public System.String LogGroupName { get; set; }
            public List<Amazon.CloudWatchLogs.Model.MetricTransformation> MetricTransformation { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutMetricFilterResponse, WriteCWLMetricFilterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
