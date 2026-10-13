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
using Amazon.Glue;
using Amazon.Glue.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// <note><para>
    /// This operation is intended for internal use. Do not call it directly.
    /// </para></note><para>
    /// AWS Glue Data Quality uses this operation to publish a data quality result.
    /// </para>
    /// </summary>
    [Cmdlet("Publish", "GLUEDataQualityResultV2", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue PublishDataQualityResultV2 API operation.", Operation = new[] {"PublishDataQualityResultV2"}, SelectReturnType = typeof(Amazon.Glue.Model.PublishDataQualityResultV2Response))]
    [AWSCmdletOutput("System.String or Amazon.Glue.Model.PublishDataQualityResultV2Response",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Glue.Model.PublishDataQualityResultV2Response) can be returned by specifying '-Select *'."
    )]
    public partial class PublishGLUEDataQualityResultV2Cmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnalyzerResult
        /// <summary>
        /// <para>
        /// <para>The analyzer level results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AnalyzerResults")]
        public Amazon.Glue.Model.DataQualityAnalyzerResult[] AnalyzerResult { get; set; }
        #endregion
        
        #region Parameter DataQualitySecurityConfiguration
        /// <summary>
        /// <para>
        /// <para>The security configuration for the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataQualitySecurityConfiguration { get; set; }
        #endregion
        
        #region Parameter Descriptor
        /// <summary>
        /// <para>
        /// <para>The descriptors for the result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Descriptors")]
        public System.Collections.Hashtable Descriptor { get; set; }
        #endregion
        
        #region Parameter Dimension
        /// <summary>
        /// <para>
        /// <para>The dimensions for the result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Dimensions")]
        public System.Collections.Hashtable Dimension { get; set; }
        #endregion
        
        #region Parameter Telemetry_Engine
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.DataQualityEngine")]
        public Amazon.Glue.DataQualityEngine Telemetry_Engine { get; set; }
        #endregion
        
        #region Parameter EvaluationContext
        /// <summary>
        /// <para>
        /// <para>The evaluation context for the result.</para>
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
        public System.String EvaluationContext { get; set; }
        #endregion
        
        #region Parameter ExecutionCompletedOn
        /// <summary>
        /// <para>
        /// <para>The time execution completed for the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExecutionCompletedOn { get; set; }
        #endregion
        
        #region Parameter ExecutionStartedOn
        /// <summary>
        /// <para>
        /// <para>The time execution started for the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExecutionStartedOn { get; set; }
        #endregion
        
        #region Parameter Telemetry_FlagsEnabled
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Telemetry_FlagsEnabled { get; set; }
        #endregion
        
        #region Parameter Telemetry_HostRuntimeVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Telemetry_HostRuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Telemetry_LibraryVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Telemetry_LibraryVersion { get; set; }
        #endregion
        
        #region Parameter RunConfiguration_ObservationMode
        /// <summary>
        /// <para>
        /// <para>The observation mode for the run. Valid values are:</para><ul><li><para><c>SCHEDULED</c></para></li><li><para><c>FIXED</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ObservationMode")]
        public Amazon.Glue.ObservationMode RunConfiguration_ObservationMode { get; set; }
        #endregion
        
        #region Parameter Observation
        /// <summary>
        /// <para>
        /// <para>The observations for the result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Observations")]
        public Amazon.Glue.Model.DataQualityObservation[] Observation { get; set; }
        #endregion
        
        #region Parameter RunConfiguration_ObservationsEnabled
        /// <summary>
        /// <para>
        /// <para>Whether observations are enabled for the run. Valid values are:</para><ul><li><para><c>ALL</c></para></li><li><para><c>NONE</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ObservationConfiguration")]
        public Amazon.Glue.ObservationConfiguration RunConfiguration_ObservationsEnabled { get; set; }
        #endregion
        
        #region Parameter RuleResult
        /// <summary>
        /// <para>
        /// <para>The rule level results.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("RuleResults")]
        public Amazon.Glue.Model.DataQualityRuleResult[] RuleResult { get; set; }
        #endregion
        
        #region Parameter RulesetName
        /// <summary>
        /// <para>
        /// <para>The ruleset name for the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RulesetName { get; set; }
        #endregion
        
        #region Parameter Score
        /// <summary>
        /// <para>
        /// <para>The score for the result.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? Score { get; set; }
        #endregion
        
        #region Parameter Telemetry_SparkVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Telemetry_SparkVersion { get; set; }
        #endregion
        
        #region Parameter Statistic
        /// <summary>
        /// <para>
        /// <para>The statistics for the result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statistics")]
        public Amazon.Glue.Model.StatisticSummary[] Statistic { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRowsFailed
        /// <summary>
        /// <para>
        /// <para>The total number of rows that failed one or more data quality rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRowsFailed { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRowsPassed
        /// <summary>
        /// <para>
        /// <para>The total number of rows that passed all applicable data quality rules.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRowsPassed { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRowsProcessed
        /// <summary>
        /// <para>
        /// <para>The total number of rows that were processed during the data quality evaluation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRowsProcessed { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRulesFailed
        /// <summary>
        /// <para>
        /// <para>The total number of data quality rules that failed their evaluation criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRulesFailed { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRulesPassed
        /// <summary>
        /// <para>
        /// <para>The total number of data quality rules that passed their evaluation criteria.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRulesPassed { get; set; }
        #endregion
        
        #region Parameter AggregatedMetrics_TotalRulesProcessed
        /// <summary>
        /// <para>
        /// <para>The total number of data quality rules that were evaluated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? AggregatedMetrics_TotalRulesProcessed { get; set; }
        #endregion
        
        #region Parameter Telemetry_VcpuHour
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Telemetry_VcpuHours")]
        public System.Double? Telemetry_VcpuHour { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token for the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResultId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.PublishDataQualityResultV2Response).
        /// Specifying the name of a property of type Amazon.Glue.Model.PublishDataQualityResultV2Response will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResultId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RulesetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Publish-GLUEDataQualityResultV2 (PublishDataQualityResultV2)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.PublishDataQualityResultV2Response, PublishGLUEDataQualityResultV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregatedMetrics_TotalRowsFailed = this.AggregatedMetrics_TotalRowsFailed;
            context.AggregatedMetrics_TotalRowsPassed = this.AggregatedMetrics_TotalRowsPassed;
            context.AggregatedMetrics_TotalRowsProcessed = this.AggregatedMetrics_TotalRowsProcessed;
            context.AggregatedMetrics_TotalRulesFailed = this.AggregatedMetrics_TotalRulesFailed;
            context.AggregatedMetrics_TotalRulesPassed = this.AggregatedMetrics_TotalRulesPassed;
            context.AggregatedMetrics_TotalRulesProcessed = this.AggregatedMetrics_TotalRulesProcessed;
            if (this.AnalyzerResult != null)
            {
                context.AnalyzerResult = new List<Amazon.Glue.Model.DataQualityAnalyzerResult>(this.AnalyzerResult);
            }
            context.ClientToken = this.ClientToken;
            context.DataQualitySecurityConfiguration = this.DataQualitySecurityConfiguration;
            if (this.Descriptor != null)
            {
                context.Descriptor = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Descriptor.Keys)
                {
                    context.Descriptor.Add((String)hashKey, (System.String)(this.Descriptor[hashKey]));
                }
            }
            if (this.Dimension != null)
            {
                context.Dimension = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Dimension.Keys)
                {
                    context.Dimension.Add((String)hashKey, (System.String)(this.Dimension[hashKey]));
                }
            }
            #if MODULAR
            if (this.Dimension == null && ParameterWasBound(nameof(this.Dimension)))
            {
                WriteWarning("You are passing $null as a value for parameter Dimension which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EvaluationContext = this.EvaluationContext;
            #if MODULAR
            if (this.EvaluationContext == null && ParameterWasBound(nameof(this.EvaluationContext)))
            {
                WriteWarning("You are passing $null as a value for parameter EvaluationContext which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionCompletedOn = this.ExecutionCompletedOn;
            context.ExecutionStartedOn = this.ExecutionStartedOn;
            if (this.Observation != null)
            {
                context.Observation = new List<Amazon.Glue.Model.DataQualityObservation>(this.Observation);
            }
            if (this.RuleResult != null)
            {
                context.RuleResult = new List<Amazon.Glue.Model.DataQualityRuleResult>(this.RuleResult);
            }
            #if MODULAR
            if (this.RuleResult == null && ParameterWasBound(nameof(this.RuleResult)))
            {
                WriteWarning("You are passing $null as a value for parameter RuleResult which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RulesetName = this.RulesetName;
            context.RunConfiguration_ObservationMode = this.RunConfiguration_ObservationMode;
            context.RunConfiguration_ObservationsEnabled = this.RunConfiguration_ObservationsEnabled;
            context.Score = this.Score;
            #if MODULAR
            if (this.Score == null && ParameterWasBound(nameof(this.Score)))
            {
                WriteWarning("You are passing $null as a value for parameter Score which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Statistic != null)
            {
                context.Statistic = new List<Amazon.Glue.Model.StatisticSummary>(this.Statistic);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Telemetry_Engine = this.Telemetry_Engine;
            if (this.Telemetry_FlagsEnabled != null)
            {
                context.Telemetry_FlagsEnabled = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Telemetry_FlagsEnabled.Keys)
                {
                    context.Telemetry_FlagsEnabled.Add((String)hashKey, (System.String)(this.Telemetry_FlagsEnabled[hashKey]));
                }
            }
            context.Telemetry_HostRuntimeVersion = this.Telemetry_HostRuntimeVersion;
            context.Telemetry_LibraryVersion = this.Telemetry_LibraryVersion;
            context.Telemetry_SparkVersion = this.Telemetry_SparkVersion;
            context.Telemetry_VcpuHour = this.Telemetry_VcpuHour;
            
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
            var request = new Amazon.Glue.Model.PublishDataQualityResultV2Request();
            
            
             // populate AggregatedMetrics
            var requestAggregatedMetricsIsNull = true;
            request.AggregatedMetrics = new Amazon.Glue.Model.DataQualityAggregatedMetrics();
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRowsFailed = null;
            if (cmdletContext.AggregatedMetrics_TotalRowsFailed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRowsFailed = cmdletContext.AggregatedMetrics_TotalRowsFailed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRowsFailed != null)
            {
                request.AggregatedMetrics.TotalRowsFailed = requestAggregatedMetrics_aggregatedMetrics_TotalRowsFailed.Value;
                requestAggregatedMetricsIsNull = false;
            }
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRowsPassed = null;
            if (cmdletContext.AggregatedMetrics_TotalRowsPassed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRowsPassed = cmdletContext.AggregatedMetrics_TotalRowsPassed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRowsPassed != null)
            {
                request.AggregatedMetrics.TotalRowsPassed = requestAggregatedMetrics_aggregatedMetrics_TotalRowsPassed.Value;
                requestAggregatedMetricsIsNull = false;
            }
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRowsProcessed = null;
            if (cmdletContext.AggregatedMetrics_TotalRowsProcessed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRowsProcessed = cmdletContext.AggregatedMetrics_TotalRowsProcessed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRowsProcessed != null)
            {
                request.AggregatedMetrics.TotalRowsProcessed = requestAggregatedMetrics_aggregatedMetrics_TotalRowsProcessed.Value;
                requestAggregatedMetricsIsNull = false;
            }
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRulesFailed = null;
            if (cmdletContext.AggregatedMetrics_TotalRulesFailed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRulesFailed = cmdletContext.AggregatedMetrics_TotalRulesFailed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRulesFailed != null)
            {
                request.AggregatedMetrics.TotalRulesFailed = requestAggregatedMetrics_aggregatedMetrics_TotalRulesFailed.Value;
                requestAggregatedMetricsIsNull = false;
            }
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRulesPassed = null;
            if (cmdletContext.AggregatedMetrics_TotalRulesPassed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRulesPassed = cmdletContext.AggregatedMetrics_TotalRulesPassed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRulesPassed != null)
            {
                request.AggregatedMetrics.TotalRulesPassed = requestAggregatedMetrics_aggregatedMetrics_TotalRulesPassed.Value;
                requestAggregatedMetricsIsNull = false;
            }
            System.Double? requestAggregatedMetrics_aggregatedMetrics_TotalRulesProcessed = null;
            if (cmdletContext.AggregatedMetrics_TotalRulesProcessed != null)
            {
                requestAggregatedMetrics_aggregatedMetrics_TotalRulesProcessed = cmdletContext.AggregatedMetrics_TotalRulesProcessed.Value;
            }
            if (requestAggregatedMetrics_aggregatedMetrics_TotalRulesProcessed != null)
            {
                request.AggregatedMetrics.TotalRulesProcessed = requestAggregatedMetrics_aggregatedMetrics_TotalRulesProcessed.Value;
                requestAggregatedMetricsIsNull = false;
            }
             // determine if request.AggregatedMetrics should be set to null
            if (requestAggregatedMetricsIsNull)
            {
                request.AggregatedMetrics = null;
            }
            if (cmdletContext.AnalyzerResult != null)
            {
                request.AnalyzerResults = cmdletContext.AnalyzerResult;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataQualitySecurityConfiguration != null)
            {
                request.DataQualitySecurityConfiguration = cmdletContext.DataQualitySecurityConfiguration;
            }
            if (cmdletContext.Descriptor != null)
            {
                request.Descriptors = cmdletContext.Descriptor;
            }
            if (cmdletContext.Dimension != null)
            {
                request.Dimensions = cmdletContext.Dimension;
            }
            if (cmdletContext.EvaluationContext != null)
            {
                request.EvaluationContext = cmdletContext.EvaluationContext;
            }
            if (cmdletContext.ExecutionCompletedOn != null)
            {
                request.ExecutionCompletedOn = cmdletContext.ExecutionCompletedOn.Value;
            }
            if (cmdletContext.ExecutionStartedOn != null)
            {
                request.ExecutionStartedOn = cmdletContext.ExecutionStartedOn.Value;
            }
            if (cmdletContext.Observation != null)
            {
                request.Observations = cmdletContext.Observation;
            }
            if (cmdletContext.RuleResult != null)
            {
                request.RuleResults = cmdletContext.RuleResult;
            }
            if (cmdletContext.RulesetName != null)
            {
                request.RulesetName = cmdletContext.RulesetName;
            }
            
             // populate RunConfiguration
            var requestRunConfigurationIsNull = true;
            request.RunConfiguration = new Amazon.Glue.Model.DataQualityConfigurationV2();
            Amazon.Glue.ObservationMode requestRunConfiguration_runConfiguration_ObservationMode = null;
            if (cmdletContext.RunConfiguration_ObservationMode != null)
            {
                requestRunConfiguration_runConfiguration_ObservationMode = cmdletContext.RunConfiguration_ObservationMode;
            }
            if (requestRunConfiguration_runConfiguration_ObservationMode != null)
            {
                request.RunConfiguration.ObservationMode = requestRunConfiguration_runConfiguration_ObservationMode;
                requestRunConfigurationIsNull = false;
            }
            Amazon.Glue.ObservationConfiguration requestRunConfiguration_runConfiguration_ObservationsEnabled = null;
            if (cmdletContext.RunConfiguration_ObservationsEnabled != null)
            {
                requestRunConfiguration_runConfiguration_ObservationsEnabled = cmdletContext.RunConfiguration_ObservationsEnabled;
            }
            if (requestRunConfiguration_runConfiguration_ObservationsEnabled != null)
            {
                request.RunConfiguration.ObservationsEnabled = requestRunConfiguration_runConfiguration_ObservationsEnabled;
                requestRunConfigurationIsNull = false;
            }
             // determine if request.RunConfiguration should be set to null
            if (requestRunConfigurationIsNull)
            {
                request.RunConfiguration = null;
            }
            if (cmdletContext.Score != null)
            {
                request.Score = cmdletContext.Score.Value;
            }
            if (cmdletContext.Statistic != null)
            {
                request.Statistics = cmdletContext.Statistic;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate Telemetry
            var requestTelemetryIsNull = true;
            request.Telemetry = new Amazon.Glue.Model.DataQualityTelemetry();
            Amazon.Glue.DataQualityEngine requestTelemetry_telemetry_Engine = null;
            if (cmdletContext.Telemetry_Engine != null)
            {
                requestTelemetry_telemetry_Engine = cmdletContext.Telemetry_Engine;
            }
            if (requestTelemetry_telemetry_Engine != null)
            {
                request.Telemetry.Engine = requestTelemetry_telemetry_Engine;
                requestTelemetryIsNull = false;
            }
            Dictionary<System.String, System.String> requestTelemetry_telemetry_FlagsEnabled = null;
            if (cmdletContext.Telemetry_FlagsEnabled != null)
            {
                requestTelemetry_telemetry_FlagsEnabled = cmdletContext.Telemetry_FlagsEnabled;
            }
            if (requestTelemetry_telemetry_FlagsEnabled != null)
            {
                request.Telemetry.FlagsEnabled = requestTelemetry_telemetry_FlagsEnabled;
                requestTelemetryIsNull = false;
            }
            System.String requestTelemetry_telemetry_HostRuntimeVersion = null;
            if (cmdletContext.Telemetry_HostRuntimeVersion != null)
            {
                requestTelemetry_telemetry_HostRuntimeVersion = cmdletContext.Telemetry_HostRuntimeVersion;
            }
            if (requestTelemetry_telemetry_HostRuntimeVersion != null)
            {
                request.Telemetry.HostRuntimeVersion = requestTelemetry_telemetry_HostRuntimeVersion;
                requestTelemetryIsNull = false;
            }
            System.String requestTelemetry_telemetry_LibraryVersion = null;
            if (cmdletContext.Telemetry_LibraryVersion != null)
            {
                requestTelemetry_telemetry_LibraryVersion = cmdletContext.Telemetry_LibraryVersion;
            }
            if (requestTelemetry_telemetry_LibraryVersion != null)
            {
                request.Telemetry.LibraryVersion = requestTelemetry_telemetry_LibraryVersion;
                requestTelemetryIsNull = false;
            }
            System.String requestTelemetry_telemetry_SparkVersion = null;
            if (cmdletContext.Telemetry_SparkVersion != null)
            {
                requestTelemetry_telemetry_SparkVersion = cmdletContext.Telemetry_SparkVersion;
            }
            if (requestTelemetry_telemetry_SparkVersion != null)
            {
                request.Telemetry.SparkVersion = requestTelemetry_telemetry_SparkVersion;
                requestTelemetryIsNull = false;
            }
            System.Double? requestTelemetry_telemetry_VcpuHour = null;
            if (cmdletContext.Telemetry_VcpuHour != null)
            {
                requestTelemetry_telemetry_VcpuHour = cmdletContext.Telemetry_VcpuHour.Value;
            }
            if (requestTelemetry_telemetry_VcpuHour != null)
            {
                request.Telemetry.VcpuHours = requestTelemetry_telemetry_VcpuHour.Value;
                requestTelemetryIsNull = false;
            }
             // determine if request.Telemetry should be set to null
            if (requestTelemetryIsNull)
            {
                request.Telemetry = null;
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
        
        private Amazon.Glue.Model.PublishDataQualityResultV2Response CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.PublishDataQualityResultV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "PublishDataQualityResultV2");
            try
            {
                return client.PublishDataQualityResultV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? AggregatedMetrics_TotalRowsFailed { get; set; }
            public System.Double? AggregatedMetrics_TotalRowsPassed { get; set; }
            public System.Double? AggregatedMetrics_TotalRowsProcessed { get; set; }
            public System.Double? AggregatedMetrics_TotalRulesFailed { get; set; }
            public System.Double? AggregatedMetrics_TotalRulesPassed { get; set; }
            public System.Double? AggregatedMetrics_TotalRulesProcessed { get; set; }
            public List<Amazon.Glue.Model.DataQualityAnalyzerResult> AnalyzerResult { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DataQualitySecurityConfiguration { get; set; }
            public Dictionary<System.String, System.String> Descriptor { get; set; }
            public Dictionary<System.String, System.String> Dimension { get; set; }
            public System.String EvaluationContext { get; set; }
            public System.DateTime? ExecutionCompletedOn { get; set; }
            public System.DateTime? ExecutionStartedOn { get; set; }
            public List<Amazon.Glue.Model.DataQualityObservation> Observation { get; set; }
            public List<Amazon.Glue.Model.DataQualityRuleResult> RuleResult { get; set; }
            public System.String RulesetName { get; set; }
            public Amazon.Glue.ObservationMode RunConfiguration_ObservationMode { get; set; }
            public Amazon.Glue.ObservationConfiguration RunConfiguration_ObservationsEnabled { get; set; }
            public System.Double? Score { get; set; }
            public List<Amazon.Glue.Model.StatisticSummary> Statistic { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.Glue.DataQualityEngine Telemetry_Engine { get; set; }
            public Dictionary<System.String, System.String> Telemetry_FlagsEnabled { get; set; }
            public System.String Telemetry_HostRuntimeVersion { get; set; }
            public System.String Telemetry_LibraryVersion { get; set; }
            public System.String Telemetry_SparkVersion { get; set; }
            public System.Double? Telemetry_VcpuHour { get; set; }
            public System.Func<Amazon.Glue.Model.PublishDataQualityResultV2Response, PublishGLUEDataQualityResultV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResultId;
        }
        
    }
}
