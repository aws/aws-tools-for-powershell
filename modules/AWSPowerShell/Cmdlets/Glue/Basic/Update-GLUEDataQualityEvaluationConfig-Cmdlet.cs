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
    /// Updates a data quality evaluation configuration. Fields that you don't specify keep
    /// their current values.
    /// </summary>
    [Cmdlet("Update", "GLUEDataQualityEvaluationConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse")]
    [AWSCmdlet("Calls the AWS Glue UpdateDataQualityEvaluationConfig API operation.", Operation = new[] {"UpdateDataQualityEvaluationConfig"}, SelectReturnType = typeof(Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse))]
    [AWSCmdletOutput("Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse",
        "This cmdlet returns an Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse object containing multiple properties."
    )]
    public partial class UpdateGLUEDataQualityEvaluationConfigCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalDataSource
        /// <summary>
        /// <para>
        /// <para>A map of reference strings to additional data sources you can specify for an evaluation
        /// run.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalDataSources")]
        public System.Collections.Hashtable AdditionalDataSource { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_AdditionalOption
        /// <summary>
        /// <para>
        /// <para>Options for reading the table. The following keys are supported:</para><ul><li><para><c>pushDownPredicate</c>: to filter on partitions without having to list and read
        /// all the files in your dataset.</para></li><li><para><c>catalogPartitionPredicate</c>: to use server-side partition pruning using partition
        /// indexes in the Glue Data Catalog.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSource_GlueTables_AdditionalOptions")]
        public System.Collections.Hashtable DataSource_GlueTables_AdditionalOption { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_CatalogId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_GlueTables_CatalogId { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_CloudWatchMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable CloudWatch metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdditionalRunOptions_CloudWatchMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_CompositeRuleEvaluationMethod
        /// <summary>
        /// <para>
        /// <para>Set the evaluation method for composite rules in the ruleset to ROW/COLUMN</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.DQCompositeRuleEvaluationMethod")]
        public Amazon.Glue.DQCompositeRuleEvaluationMethod AdditionalRunOptions_CompositeRuleEvaluationMethod { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_ConnectionName
        /// <summary>
        /// <para>
        /// <para>The name of the connection to the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_GlueTables_ConnectionName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_CustomLogGroupPrefix
        /// <summary>
        /// <para>
        /// <para>A custom prefix for the CloudWatch log group names. When specified, evaluation run
        /// logs are written to <c>&lt;CustomLogGroupPrefix&gt;/error</c> and <c>&lt;CustomLogGroupPrefix&gt;/output</c>
        /// instead of the default <c>/aws-glue/data-quality/error</c> and <c>/aws-glue/data-quality/output</c>
        /// log groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_CustomLogGroupPrefix { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the database in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_DatabaseName
        /// <summary>
        /// <para>
        /// <para>A database name in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_GlueTables_DatabaseName { get; set; }
        #endregion
        
        #region Parameter EndAt
        /// <summary>
        /// <para>
        /// <para>The time at which the schedule stops running, exclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndAt { get; set; }
        #endregion
        
        #region Parameter ManagedRulesetName
        /// <summary>
        /// <para>
        /// <para>A built-in ruleset, <c>SIMPLE</c> or <c>ADVANCED</c>, that profiles each table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.DataQualityEvaluationConfigManagedRuleset")]
        public Amazon.Glue.DataQualityEvaluationConfigManagedRuleset ManagedRulesetName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_MaxRowsToWrite
        /// <summary>
        /// <para>
        /// <para>The maximum number of rows to write in the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AdditionalRunOptions_RowLevelResults_MaxRowsToWrite { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the data quality evaluation configuration to update.</para>
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
        
        #region Parameter NumberOfWorker
        /// <summary>
        /// <para>
        /// <para>The number of <c>G.1X</c> workers to be used in the run. The default is 5.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NumberOfWorkers")]
        public System.Int32? NumberOfWorker { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationMode
        /// <summary>
        /// <para>
        /// <para>The observation mode for the evaluation run. Specifies how anomaly detection bounds
        /// are calculated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ObservationMode")]
        public Amazon.Glue.ObservationMode AdditionalRunOptions_ObservationMode { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationScope
        /// <summary>
        /// <para>
        /// <para>The scope of the observation for the evaluation run. Specifies whether anomaly detection
        /// is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ObservationConfiguration")]
        public Amazon.Glue.ObservationConfiguration AdditionalRunOptions_ObservationScope { get; set; }
        #endregion
        
        #region Parameter PauseRun
        /// <summary>
        /// <para>
        /// <para>Specifies whether to pause the configuration. While paused, the configuration evaluates
        /// nothing, including tables added to the catalog or database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PauseRuns")]
        public System.Boolean? PauseRun { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_PreProcessingQuery
        /// <summary>
        /// <para>
        /// <para>SQL Query of SparkSQL format that can be used to pre-process the data for the table
        /// in Glue Data Catalog, before running the Data Quality Operation.</para><para>For the <c>CATALOG</c> and <c>DATABASE</c> levels, use the <c>{{DATABASE_NAME}}</c>
        /// and <c>{{TABLE_NAME}}</c> placeholders, which are filled in for each table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_GlueTables_PreProcessingQuery { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ResultsS3Prefix
        /// <summary>
        /// <para>
        /// <para>Prefix for Amazon S3 to store results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ResultsS3Prefix { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_ResultType
        /// <summary>
        /// <para>
        /// <para>The result type to include in the row-level results output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Glue.ResultTypeEnum")]
        public Amazon.Glue.ResultTypeEnum AdditionalRunOptions_RowLevelResults_ResultType { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM role that evaluations assume. You can specify the role name or the role Amazon
        /// Resource Name (ARN). The role needs the trust policy and permissions described for
        /// <c>CreateDataQualityEvaluationConfig</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter RulesetName
        /// <summary>
        /// <para>
        /// <para>The name of a Data Quality Definition Language (DQDL) ruleset, containing analyzers,
        /// rules, or both, to evaluate tables with. You create the ruleset using the <c>CreateDataQualityRuleset</c>
        /// API. Specify either <c>RulesetName</c> or <c>ManagedRulesetName</c>, not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RulesetName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for storing the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for storing the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for storing the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for storing the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location for storing the results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron or rate expression, in UTC, for the <c>SCHEDULE</c> trigger, for example <c>cron(0
        /// 6 * * ? *)</c>. The schedule can run at most once an hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter StartAt
        /// <summary>
        /// <para>
        /// <para>The time from which the schedule runs, inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartAt { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName { get; set; }
        #endregion
        
        #region Parameter DataSource_GlueTables_TableNamePattern
        /// <summary>
        /// <para>
        /// <para>For the <c>CATALOG</c> and <c>DATABASE</c> levels, a glob pattern, such as <c>orders_*</c>,
        /// that selects tables. If you don't specify a pattern, every table at the level is in
        /// scope. For the <c>TABLE</c> level, the name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSource_GlueTables_TableNamePattern { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The timeout for a run in minutes. This is the maximum time that a run can consume
        /// resources before it is terminated and enters <c>TIMEOUT</c> status. The default is
        /// 2,880 minutes (48 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter Trigger
        /// <summary>
        /// <para>
        /// <para>When the configuration evaluates tables. Replaces the current triggers. Choose from
        /// the following triggers:</para><dl><dt>ONCE</dt><dd><para>Evaluates each table one time, including when tables are added to a database or catalog.</para></dd><dt>SCHEDULE</dt><dd><para>Evaluates each table on the cron or rate expression in <c>ScheduleExpression</c>,
        /// between the optional <c>StartAt</c> and <c>EndAt</c> times.</para></dd><dt>METADATA_CHANGE</dt><dd><para>Evaluates a table whenever its Glue Data Catalog metadata changes, such as a schema
        /// change or an Apache Iceberg commit.</para></dd></dl><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Triggers")]
        public System.String[] Trigger { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to write data quality rule results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to write distribution results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to write observation results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled { get; set; }
        #endregion
        
        #region Parameter AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled
        /// <summary>
        /// <para>
        /// <para>Set to true to write profiling results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse).
        /// Specifying the name of a property of type Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GLUEDataQualityEvaluationConfig (UpdateDataQualityEvaluationConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse, UpdateGLUEDataQualityEvaluationConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalDataSource != null)
            {
                context.AdditionalDataSource = new Dictionary<System.String, Amazon.Glue.Model.DataSource>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalDataSource.Keys)
                {
                    context.AdditionalDataSource.Add((String)hashKey, (Amazon.Glue.Model.DataSource)(this.AdditionalDataSource[hashKey]));
                }
            }
            context.AdditionalRunOptions_CloudWatchMetricsEnabled = this.AdditionalRunOptions_CloudWatchMetricsEnabled;
            context.AdditionalRunOptions_CompositeRuleEvaluationMethod = this.AdditionalRunOptions_CompositeRuleEvaluationMethod;
            context.AdditionalRunOptions_CustomLogGroupPrefix = this.AdditionalRunOptions_CustomLogGroupPrefix;
            context.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId = this.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId;
            context.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName = this.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName;
            context.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location = this.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location;
            context.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName = this.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName;
            context.AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled = this.AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled;
            context.AdditionalRunOptions_ObservationMode = this.AdditionalRunOptions_ObservationMode;
            context.AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId = this.AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId;
            context.AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName = this.AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName;
            context.AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location = this.AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location;
            context.AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName = this.AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName;
            context.AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled = this.AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled;
            context.AdditionalRunOptions_ObservationScope = this.AdditionalRunOptions_ObservationScope;
            context.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId = this.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId;
            context.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName = this.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName;
            context.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location = this.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location;
            context.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName = this.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName;
            context.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId = this.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId;
            context.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName = this.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName;
            context.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location = this.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location;
            context.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName = this.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName;
            context.AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled = this.AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled;
            context.AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled = this.AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled;
            context.AdditionalRunOptions_ResultsS3Prefix = this.AdditionalRunOptions_ResultsS3Prefix;
            context.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId = this.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId;
            context.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName = this.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName;
            context.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location = this.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location;
            context.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName = this.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName;
            context.AdditionalRunOptions_RowLevelResults_MaxRowsToWrite = this.AdditionalRunOptions_RowLevelResults_MaxRowsToWrite;
            context.AdditionalRunOptions_RowLevelResults_ResultType = this.AdditionalRunOptions_RowLevelResults_ResultType;
            if (this.DataSource_GlueTables_AdditionalOption != null)
            {
                context.DataSource_GlueTables_AdditionalOption = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DataSource_GlueTables_AdditionalOption.Keys)
                {
                    context.DataSource_GlueTables_AdditionalOption.Add((String)hashKey, (System.String)(this.DataSource_GlueTables_AdditionalOption[hashKey]));
                }
            }
            context.DataSource_GlueTables_CatalogId = this.DataSource_GlueTables_CatalogId;
            context.DataSource_GlueTables_ConnectionName = this.DataSource_GlueTables_ConnectionName;
            context.DataSource_GlueTables_DatabaseName = this.DataSource_GlueTables_DatabaseName;
            context.DataSource_GlueTables_PreProcessingQuery = this.DataSource_GlueTables_PreProcessingQuery;
            context.DataSource_GlueTables_TableNamePattern = this.DataSource_GlueTables_TableNamePattern;
            context.EndAt = this.EndAt;
            context.ManagedRulesetName = this.ManagedRulesetName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfWorker = this.NumberOfWorker;
            context.PauseRun = this.PauseRun;
            context.Role = this.Role;
            context.RulesetName = this.RulesetName;
            context.ScheduleExpression = this.ScheduleExpression;
            context.StartAt = this.StartAt;
            context.Timeout = this.Timeout;
            if (this.Trigger != null)
            {
                context.Trigger = new List<System.String>(this.Trigger);
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
            var request = new Amazon.Glue.Model.UpdateDataQualityEvaluationConfigRequest();
            
            if (cmdletContext.AdditionalDataSource != null)
            {
                request.AdditionalDataSources = cmdletContext.AdditionalDataSource;
            }
            
             // populate AdditionalRunOptions
            var requestAdditionalRunOptionsIsNull = true;
            request.AdditionalRunOptions = new Amazon.Glue.Model.DataQualityEvaluationConfigAdditionalRunOptions();
            System.Boolean? requestAdditionalRunOptions_additionalRunOptions_CloudWatchMetricsEnabled = null;
            if (cmdletContext.AdditionalRunOptions_CloudWatchMetricsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_CloudWatchMetricsEnabled = cmdletContext.AdditionalRunOptions_CloudWatchMetricsEnabled.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_CloudWatchMetricsEnabled != null)
            {
                request.AdditionalRunOptions.CloudWatchMetricsEnabled = requestAdditionalRunOptions_additionalRunOptions_CloudWatchMetricsEnabled.Value;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.DQCompositeRuleEvaluationMethod requestAdditionalRunOptions_additionalRunOptions_CompositeRuleEvaluationMethod = null;
            if (cmdletContext.AdditionalRunOptions_CompositeRuleEvaluationMethod != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_CompositeRuleEvaluationMethod = cmdletContext.AdditionalRunOptions_CompositeRuleEvaluationMethod;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_CompositeRuleEvaluationMethod != null)
            {
                request.AdditionalRunOptions.CompositeRuleEvaluationMethod = requestAdditionalRunOptions_additionalRunOptions_CompositeRuleEvaluationMethod;
                requestAdditionalRunOptionsIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_CustomLogGroupPrefix = null;
            if (cmdletContext.AdditionalRunOptions_CustomLogGroupPrefix != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_CustomLogGroupPrefix = cmdletContext.AdditionalRunOptions_CustomLogGroupPrefix;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_CustomLogGroupPrefix != null)
            {
                request.AdditionalRunOptions.CustomLogGroupPrefix = requestAdditionalRunOptions_additionalRunOptions_CustomLogGroupPrefix;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.ObservationMode requestAdditionalRunOptions_additionalRunOptions_ObservationMode = null;
            if (cmdletContext.AdditionalRunOptions_ObservationMode != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationMode = cmdletContext.AdditionalRunOptions_ObservationMode;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationMode != null)
            {
                request.AdditionalRunOptions.ObservationMode = requestAdditionalRunOptions_additionalRunOptions_ObservationMode;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.ObservationConfiguration requestAdditionalRunOptions_additionalRunOptions_ObservationScope = null;
            if (cmdletContext.AdditionalRunOptions_ObservationScope != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationScope = cmdletContext.AdditionalRunOptions_ObservationScope;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationScope != null)
            {
                request.AdditionalRunOptions.ObservationScope = requestAdditionalRunOptions_additionalRunOptions_ObservationScope;
                requestAdditionalRunOptionsIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ResultsS3Prefix = null;
            if (cmdletContext.AdditionalRunOptions_ResultsS3Prefix != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ResultsS3Prefix = cmdletContext.AdditionalRunOptions_ResultsS3Prefix;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ResultsS3Prefix != null)
            {
                request.AdditionalRunOptions.ResultsS3Prefix = requestAdditionalRunOptions_additionalRunOptions_ResultsS3Prefix;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.Model.DataQualityRuleResultsOptions requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults = null;
            
             // populate DataQualityRuleResults
            var requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResultsIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults = new Amazon.Glue.Model.DataQualityRuleResultsOptions();
            System.Boolean? requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled = null;
            if (cmdletContext.AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled = cmdletContext.AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults.WriteDataQualityRuleResultsEnabled = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled.Value;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResultsIsNull = false;
            }
            Amazon.Glue.Model.CatalogTableConfigOptions requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig = null;
            
             // populate CatalogTableConfig
            var requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig = new Amazon.Glue.Model.CatalogTableConfigOptions();
            System.String requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId = null;
            if (cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId = cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig.CatalogId = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName = null;
            if (cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName = cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig.DatabaseName = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location = null;
            if (cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location = cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig.S3Location = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName = null;
            if (cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName = cmdletContext.AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig.TableName = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfigIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults.CatalogTableConfig = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults_additionalRunOptions_DataQualityRuleResults_CatalogTableConfig;
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResultsIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResultsIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults != null)
            {
                request.AdditionalRunOptions.DataQualityRuleResults = requestAdditionalRunOptions_additionalRunOptions_DataQualityRuleResults;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.Model.ObservationResultsOptions requestAdditionalRunOptions_additionalRunOptions_ObservationResults = null;
            
             // populate ObservationResults
            var requestAdditionalRunOptions_additionalRunOptions_ObservationResultsIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ObservationResults = new Amazon.Glue.Model.ObservationResultsOptions();
            System.Boolean? requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_WriteObservationResultsEnabled = null;
            if (cmdletContext.AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_WriteObservationResultsEnabled = cmdletContext.AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_WriteObservationResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults.WriteObservationResultsEnabled = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_WriteObservationResultsEnabled.Value;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResultsIsNull = false;
            }
            Amazon.Glue.Model.CatalogTableConfigOptions requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig = null;
            
             // populate CatalogTableConfig
            var requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig = new Amazon.Glue.Model.CatalogTableConfigOptions();
            System.String requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId = null;
            if (cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId = cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig.CatalogId = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName = null;
            if (cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName = cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig.DatabaseName = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_S3Location = null;
            if (cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_S3Location = cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig.S3Location = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_S3Location;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_TableName = null;
            if (cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_TableName = cmdletContext.AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig.TableName = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig_additionalRunOptions_ObservationResults_CatalogTableConfig_TableName;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfigIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults.CatalogTableConfig = requestAdditionalRunOptions_additionalRunOptions_ObservationResults_additionalRunOptions_ObservationResults_CatalogTableConfig;
                requestAdditionalRunOptions_additionalRunOptions_ObservationResultsIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ObservationResults should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResultsIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ObservationResults = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ObservationResults != null)
            {
                request.AdditionalRunOptions.ObservationResults = requestAdditionalRunOptions_additionalRunOptions_ObservationResults;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.Model.ProfilingResultsOptions requestAdditionalRunOptions_additionalRunOptions_ProfilingResults = null;
            
             // populate ProfilingResults
            var requestAdditionalRunOptions_additionalRunOptions_ProfilingResultsIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ProfilingResults = new Amazon.Glue.Model.ProfilingResultsOptions();
            System.Boolean? requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled = cmdletContext.AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults.WriteProfilingResultsEnabled = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled.Value;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResultsIsNull = false;
            }
            Amazon.Glue.Model.DistributionResultsOptions requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults = null;
            
             // populate DistributionResults
            var requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResultsIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults = new Amazon.Glue.Model.DistributionResultsOptions();
            System.Boolean? requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled = cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults.WriteDistributionResultsEnabled = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled.Value;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResultsIsNull = false;
            }
            Amazon.Glue.Model.CatalogTableConfigOptions requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig = null;
            
             // populate CatalogTableConfig
            var requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig = new Amazon.Glue.Model.CatalogTableConfigOptions();
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId = cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig.CatalogId = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName = cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig.DatabaseName = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location = cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig.S3Location = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName = cmdletContext.AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig.TableName = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfigIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults.CatalogTableConfig = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults_additionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResultsIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResultsIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults.DistributionResults = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_DistributionResults;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResultsIsNull = false;
            }
            Amazon.Glue.Model.CatalogTableConfigOptions requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig = null;
            
             // populate CatalogTableConfig
            var requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig = new Amazon.Glue.Model.CatalogTableConfigOptions();
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId = cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig.CatalogId = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName = cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig.DatabaseName = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location = cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig.S3Location = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_TableName = null;
            if (cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_TableName = cmdletContext.AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig.TableName = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig_additionalRunOptions_ProfilingResults_CatalogTableConfig_TableName;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfigIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults.CatalogTableConfig = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults_additionalRunOptions_ProfilingResults_CatalogTableConfig;
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResultsIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_ProfilingResults should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResultsIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_ProfilingResults = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_ProfilingResults != null)
            {
                request.AdditionalRunOptions.ProfilingResults = requestAdditionalRunOptions_additionalRunOptions_ProfilingResults;
                requestAdditionalRunOptionsIsNull = false;
            }
            Amazon.Glue.Model.RowLevelResultsOptions requestAdditionalRunOptions_additionalRunOptions_RowLevelResults = null;
            
             // populate RowLevelResults
            var requestAdditionalRunOptions_additionalRunOptions_RowLevelResultsIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_RowLevelResults = new Amazon.Glue.Model.RowLevelResultsOptions();
            System.Int32? requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_MaxRowsToWrite = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_MaxRowsToWrite != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_MaxRowsToWrite = cmdletContext.AdditionalRunOptions_RowLevelResults_MaxRowsToWrite.Value;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_MaxRowsToWrite != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults.MaxRowsToWrite = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_MaxRowsToWrite.Value;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResultsIsNull = false;
            }
            Amazon.Glue.ResultTypeEnum requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_ResultType = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_ResultType != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_ResultType = cmdletContext.AdditionalRunOptions_RowLevelResults_ResultType;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_ResultType != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults.ResultType = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_ResultType;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResultsIsNull = false;
            }
            Amazon.Glue.Model.CatalogTableConfigOptions requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig = null;
            
             // populate CatalogTableConfig
            var requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull = true;
            requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig = new Amazon.Glue.Model.CatalogTableConfigOptions();
            System.String requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId = cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig.CatalogId = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName = cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig.DatabaseName = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location = cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig.S3Location = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull = false;
            }
            System.String requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_TableName = null;
            if (cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_TableName = cmdletContext.AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_TableName != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig.TableName = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig_additionalRunOptions_RowLevelResults_CatalogTableConfig_TableName;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfigIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig != null)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults.CatalogTableConfig = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults_additionalRunOptions_RowLevelResults_CatalogTableConfig;
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResultsIsNull = false;
            }
             // determine if requestAdditionalRunOptions_additionalRunOptions_RowLevelResults should be set to null
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResultsIsNull)
            {
                requestAdditionalRunOptions_additionalRunOptions_RowLevelResults = null;
            }
            if (requestAdditionalRunOptions_additionalRunOptions_RowLevelResults != null)
            {
                request.AdditionalRunOptions.RowLevelResults = requestAdditionalRunOptions_additionalRunOptions_RowLevelResults;
                requestAdditionalRunOptionsIsNull = false;
            }
             // determine if request.AdditionalRunOptions should be set to null
            if (requestAdditionalRunOptionsIsNull)
            {
                request.AdditionalRunOptions = null;
            }
            
             // populate DataSource
            var requestDataSourceIsNull = true;
            request.DataSource = new Amazon.Glue.Model.DataQualityEvaluationConfigDataSource();
            Amazon.Glue.Model.DataQualityEvaluationConfigGlueTables requestDataSource_dataSource_GlueTables = null;
            
             // populate GlueTables
            var requestDataSource_dataSource_GlueTablesIsNull = true;
            requestDataSource_dataSource_GlueTables = new Amazon.Glue.Model.DataQualityEvaluationConfigGlueTables();
            Dictionary<System.String, System.String> requestDataSource_dataSource_GlueTables_dataSource_GlueTables_AdditionalOption = null;
            if (cmdletContext.DataSource_GlueTables_AdditionalOption != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_AdditionalOption = cmdletContext.DataSource_GlueTables_AdditionalOption;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_AdditionalOption != null)
            {
                requestDataSource_dataSource_GlueTables.AdditionalOptions = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_AdditionalOption;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTables_dataSource_GlueTables_CatalogId = null;
            if (cmdletContext.DataSource_GlueTables_CatalogId != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_CatalogId = cmdletContext.DataSource_GlueTables_CatalogId;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_CatalogId != null)
            {
                requestDataSource_dataSource_GlueTables.CatalogId = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_CatalogId;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTables_dataSource_GlueTables_ConnectionName = null;
            if (cmdletContext.DataSource_GlueTables_ConnectionName != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_ConnectionName = cmdletContext.DataSource_GlueTables_ConnectionName;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_ConnectionName != null)
            {
                requestDataSource_dataSource_GlueTables.ConnectionName = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_ConnectionName;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTables_dataSource_GlueTables_DatabaseName = null;
            if (cmdletContext.DataSource_GlueTables_DatabaseName != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_DatabaseName = cmdletContext.DataSource_GlueTables_DatabaseName;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_DatabaseName != null)
            {
                requestDataSource_dataSource_GlueTables.DatabaseName = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_DatabaseName;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTables_dataSource_GlueTables_PreProcessingQuery = null;
            if (cmdletContext.DataSource_GlueTables_PreProcessingQuery != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_PreProcessingQuery = cmdletContext.DataSource_GlueTables_PreProcessingQuery;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_PreProcessingQuery != null)
            {
                requestDataSource_dataSource_GlueTables.PreProcessingQuery = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_PreProcessingQuery;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
            System.String requestDataSource_dataSource_GlueTables_dataSource_GlueTables_TableNamePattern = null;
            if (cmdletContext.DataSource_GlueTables_TableNamePattern != null)
            {
                requestDataSource_dataSource_GlueTables_dataSource_GlueTables_TableNamePattern = cmdletContext.DataSource_GlueTables_TableNamePattern;
            }
            if (requestDataSource_dataSource_GlueTables_dataSource_GlueTables_TableNamePattern != null)
            {
                requestDataSource_dataSource_GlueTables.TableNamePattern = requestDataSource_dataSource_GlueTables_dataSource_GlueTables_TableNamePattern;
                requestDataSource_dataSource_GlueTablesIsNull = false;
            }
             // determine if requestDataSource_dataSource_GlueTables should be set to null
            if (requestDataSource_dataSource_GlueTablesIsNull)
            {
                requestDataSource_dataSource_GlueTables = null;
            }
            if (requestDataSource_dataSource_GlueTables != null)
            {
                request.DataSource.GlueTables = requestDataSource_dataSource_GlueTables;
                requestDataSourceIsNull = false;
            }
             // determine if request.DataSource should be set to null
            if (requestDataSourceIsNull)
            {
                request.DataSource = null;
            }
            if (cmdletContext.EndAt != null)
            {
                request.EndAt = cmdletContext.EndAt.Value;
            }
            if (cmdletContext.ManagedRulesetName != null)
            {
                request.ManagedRulesetName = cmdletContext.ManagedRulesetName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NumberOfWorker != null)
            {
                request.NumberOfWorkers = cmdletContext.NumberOfWorker.Value;
            }
            if (cmdletContext.PauseRun != null)
            {
                request.PauseRuns = cmdletContext.PauseRun.Value;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.RulesetName != null)
            {
                request.RulesetName = cmdletContext.RulesetName;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.StartAt != null)
            {
                request.StartAt = cmdletContext.StartAt.Value;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            if (cmdletContext.Trigger != null)
            {
                request.Triggers = cmdletContext.Trigger;
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
        
        private Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.UpdateDataQualityEvaluationConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "UpdateDataQualityEvaluationConfig");
            try
            {
                return client.UpdateDataQualityEvaluationConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.Glue.Model.DataSource> AdditionalDataSource { get; set; }
            public System.Boolean? AdditionalRunOptions_CloudWatchMetricsEnabled { get; set; }
            public Amazon.Glue.DQCompositeRuleEvaluationMethod AdditionalRunOptions_CompositeRuleEvaluationMethod { get; set; }
            public System.String AdditionalRunOptions_CustomLogGroupPrefix { get; set; }
            public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_CatalogId { get; set; }
            public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_DatabaseName { get; set; }
            public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_S3Location { get; set; }
            public System.String AdditionalRunOptions_DataQualityRuleResults_CatalogTableConfig_TableName { get; set; }
            public System.Boolean? AdditionalRunOptions_DataQualityRuleResults_WriteDataQualityRuleResultsEnabled { get; set; }
            public Amazon.Glue.ObservationMode AdditionalRunOptions_ObservationMode { get; set; }
            public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_CatalogId { get; set; }
            public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_DatabaseName { get; set; }
            public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_S3Location { get; set; }
            public System.String AdditionalRunOptions_ObservationResults_CatalogTableConfig_TableName { get; set; }
            public System.Boolean? AdditionalRunOptions_ObservationResults_WriteObservationResultsEnabled { get; set; }
            public Amazon.Glue.ObservationConfiguration AdditionalRunOptions_ObservationScope { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_CatalogId { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_DatabaseName { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_S3Location { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_CatalogTableConfig_TableName { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_CatalogId { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_DatabaseName { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_S3Location { get; set; }
            public System.String AdditionalRunOptions_ProfilingResults_DistributionResults_CatalogTableConfig_TableName { get; set; }
            public System.Boolean? AdditionalRunOptions_ProfilingResults_DistributionResults_WriteDistributionResultsEnabled { get; set; }
            public System.Boolean? AdditionalRunOptions_ProfilingResults_WriteProfilingResultsEnabled { get; set; }
            public System.String AdditionalRunOptions_ResultsS3Prefix { get; set; }
            public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_CatalogId { get; set; }
            public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_DatabaseName { get; set; }
            public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_S3Location { get; set; }
            public System.String AdditionalRunOptions_RowLevelResults_CatalogTableConfig_TableName { get; set; }
            public System.Int32? AdditionalRunOptions_RowLevelResults_MaxRowsToWrite { get; set; }
            public Amazon.Glue.ResultTypeEnum AdditionalRunOptions_RowLevelResults_ResultType { get; set; }
            public Dictionary<System.String, System.String> DataSource_GlueTables_AdditionalOption { get; set; }
            public System.String DataSource_GlueTables_CatalogId { get; set; }
            public System.String DataSource_GlueTables_ConnectionName { get; set; }
            public System.String DataSource_GlueTables_DatabaseName { get; set; }
            public System.String DataSource_GlueTables_PreProcessingQuery { get; set; }
            public System.String DataSource_GlueTables_TableNamePattern { get; set; }
            public System.DateTime? EndAt { get; set; }
            public Amazon.Glue.DataQualityEvaluationConfigManagedRuleset ManagedRulesetName { get; set; }
            public System.String Name { get; set; }
            public System.Int32? NumberOfWorker { get; set; }
            public System.Boolean? PauseRun { get; set; }
            public System.String Role { get; set; }
            public System.String RulesetName { get; set; }
            public System.String ScheduleExpression { get; set; }
            public System.DateTime? StartAt { get; set; }
            public System.Int32? Timeout { get; set; }
            public List<System.String> Trigger { get; set; }
            public System.Func<Amazon.Glue.Model.UpdateDataQualityEvaluationConfigResponse, UpdateGLUEDataQualityEvaluationConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
