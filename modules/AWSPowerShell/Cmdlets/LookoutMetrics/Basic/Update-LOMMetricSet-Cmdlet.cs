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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Updates a dataset.
    /// </summary>
    [Cmdlet("Update", "LOMMetricSet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics UpdateMetricSet API operation.", Operation = new[] {"UpdateMetricSet"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.UpdateMetricSetResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutMetrics.Model.UpdateMetricSetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutMetrics.Model.UpdateMetricSetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateLOMMetricSetCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CsvFormatDescriptor_Charset
        /// <summary>
        /// <para>
        /// <para>The character set in which the source CSV file is written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_Charset")]
        public System.String CsvFormatDescriptor_Charset { get; set; }
        #endregion
        
        #region Parameter JsonFormatDescriptor_Charset
        /// <summary>
        /// <para>
        /// <para>The character set in which the source JSON file is written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_Charset")]
        public System.String JsonFormatDescriptor_Charset { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>A string identifying the Redshift cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_ClusterIdentifier")]
        public System.String RedshiftSourceConfig_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter TimestampColumn_ColumnFormat
        /// <summary>
        /// <para>
        /// <para>The format of the timestamp column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimestampColumn_ColumnFormat { get; set; }
        #endregion
        
        #region Parameter TimestampColumn_ColumnName
        /// <summary>
        /// <para>
        /// <para>The name of the timestamp column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TimestampColumn_ColumnName { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_ContainsHeader
        /// <summary>
        /// <para>
        /// <para>Whether or not the source CSV file contains a header.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_ContainsHeader")]
        public System.Boolean? CsvFormatDescriptor_ContainsHeader { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_DatabaseHost
        /// <summary>
        /// <para>
        /// <para>The host name of the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_DatabaseHost")]
        public System.String RDSSourceConfig_DatabaseHost { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_DatabaseHost
        /// <summary>
        /// <para>
        /// <para>The name of the database host.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_DatabaseHost")]
        public System.String RedshiftSourceConfig_DatabaseHost { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The database's name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_DatabaseName")]
        public System.String AthenaSourceConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The name of the RDS database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_DatabaseName")]
        public System.String RDSSourceConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_DatabaseName
        /// <summary>
        /// <para>
        /// <para>The Redshift database name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_DatabaseName")]
        public System.String RedshiftSourceConfig_DatabaseName { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_DatabasePort
        /// <summary>
        /// <para>
        /// <para>The port number where the database can be accessed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_DatabasePort")]
        public System.Int32? RDSSourceConfig_DatabasePort { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_DatabasePort
        /// <summary>
        /// <para>
        /// <para>The port number where the database can be accessed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_DatabasePort")]
        public System.Int32? RedshiftSourceConfig_DatabasePort { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_DataCatalog
        /// <summary>
        /// <para>
        /// <para>The database's data catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_DataCatalog")]
        public System.String AthenaSourceConfig_DataCatalog { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>A string identifying the database instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_DBInstanceIdentifier")]
        public System.String RDSSourceConfig_DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_Delimiter
        /// <summary>
        /// <para>
        /// <para>The character used to delimit the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_Delimiter")]
        public System.String CsvFormatDescriptor_Delimiter { get; set; }
        #endregion
        
        #region Parameter DimensionFilterList
        /// <summary>
        /// <para>
        /// <para>Describes a list of filters for choosing specific dimensions and specific values.
        /// Each filter consists of the dimension and one of its values that you want to include.
        /// When multiple dimensions or values are specified, the dimensions are joined with an
        /// AND operation and the values are joined with an OR operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LookoutMetrics.Model.MetricSetDimensionFilter[] DimensionFilterList { get; set; }
        #endregion
        
        #region Parameter DimensionList
        /// <summary>
        /// <para>
        /// <para>The dimension list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] DimensionList { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_FileCompression
        /// <summary>
        /// <para>
        /// <para>The level of compression of the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_FileCompression")]
        [AWSConstantClassSource("Amazon.LookoutMetrics.CSVFileCompression")]
        public Amazon.LookoutMetrics.CSVFileCompression CsvFormatDescriptor_FileCompression { get; set; }
        #endregion
        
        #region Parameter JsonFormatDescriptor_FileCompression
        /// <summary>
        /// <para>
        /// <para>The level of compression of the source CSV file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_FileCompression")]
        [AWSConstantClassSource("Amazon.LookoutMetrics.JsonFileCompression")]
        public Amazon.LookoutMetrics.JsonFileCompression JsonFormatDescriptor_FileCompression { get; set; }
        #endregion
        
        #region Parameter AppFlowConfig_FlowName
        /// <summary>
        /// <para>
        /// <para> name of the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AppFlowConfig_FlowName")]
        public System.String AppFlowConfig_FlowName { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_HeaderList
        /// <summary>
        /// <para>
        /// <para>A list of the source CSV file's headers, if any.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_HeaderList")]
        public System.String[] CsvFormatDescriptor_HeaderList { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_HistoricalDataPathList
        /// <summary>
        /// <para>
        /// <para>A list of paths to the historical data files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_HistoricalDataPathList")]
        public System.String[] S3SourceConfig_HistoricalDataPathList { get; set; }
        #endregion
        
        #region Parameter MetricList
        /// <summary>
        /// <para>
        /// <para>The metric list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LookoutMetrics.Model.Metric[] MetricList { get; set; }
        #endregion
        
        #region Parameter MetricSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the dataset to update.</para>
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
        public System.String MetricSetArn { get; set; }
        #endregion
        
        #region Parameter MetricSetDescription
        /// <summary>
        /// <para>
        /// <para>The dataset's description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MetricSetDescription { get; set; }
        #endregion
        
        #region Parameter MetricSetFrequency
        /// <summary>
        /// <para>
        /// <para>The dataset's interval.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutMetrics.Frequency")]
        public Amazon.LookoutMetrics.Frequency MetricSetFrequency { get; set; }
        #endregion
        
        #region Parameter Offset
        /// <summary>
        /// <para>
        /// <para>After an interval ends, the amount of seconds that the detector waits before importing
        /// data. Offset is only supported for S3, Redshift, Athena and datasources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Offset { get; set; }
        #endregion
        
        #region Parameter CsvFormatDescriptor_QuoteSymbol
        /// <summary>
        /// <para>
        /// <para>The character used as a quote character.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_QuoteSymbol")]
        public System.String CsvFormatDescriptor_QuoteSymbol { get; set; }
        #endregion
        
        #region Parameter AppFlowConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>An IAM role that gives Amazon Lookout for Metrics permission to access the flow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AppFlowConfig_RoleArn")]
        public System.String AppFlowConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>An IAM role that gives Amazon Lookout for Metrics permission to access the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_RoleArn")]
        public System.String AthenaSourceConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>An IAM role that gives Amazon Lookout for Metrics permission to access data in Amazon
        /// CloudWatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_CloudWatchConfig_RoleArn")]
        public System.String CloudWatchConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_RoleArn")]
        public System.String RDSSourceConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role providing access to the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_RoleArn")]
        public System.String RedshiftSourceConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role that has read and write access permissions to the source S3
        /// bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_RoleArn")]
        public System.String S3SourceConfig_RoleArn { get; set; }
        #endregion
        
        #region Parameter BackTestConfiguration_RunBackTestMode
        /// <summary>
        /// <para>
        /// <para>Run a backtest instead of monitoring new data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_BackTestConfiguration_RunBackTestMode")]
        public System.Boolean? BackTestConfiguration_RunBackTestMode { get; set; }
        #endregion
        
        #region Parameter MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode
        /// <summary>
        /// <para>
        /// <para>Run a backtest instead of monitoring new data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CloudWatch_BackTestConfiguration_RunBackTestMode")]
        public System.Boolean? MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_S3ResultsPath
        /// <summary>
        /// <para>
        /// <para>The database's results path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_S3ResultsPath")]
        public System.String AthenaSourceConfig_S3ResultsPath { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_SecretManagerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_SecretManagerArn")]
        public System.String RDSSourceConfig_SecretManagerArn { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_SecretManagerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Secrets Manager role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_SecretManagerArn")]
        public System.String RedshiftSourceConfig_SecretManagerArn { get; set; }
        #endregion
        
        #region Parameter MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the list of security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RDSSourceConfig_VpcConfiguration_SecurityGroupIdList")]
        public System.String[] MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList { get; set; }
        #endregion
        
        #region Parameter MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the list of security groups.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList { get; set; }
        #endregion
        
        #region Parameter MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the Amazon VPC subnet IDs (e.g., <c>subnet-0bb1c79de3EXAMPLE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RDSSourceConfig_VpcConfiguration_SubnetIdList")]
        public System.String[] MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList { get; set; }
        #endregion
        
        #region Parameter MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList
        /// <summary>
        /// <para>
        /// <para>An array of strings containing the Amazon VPC subnet IDs (e.g., <c>subnet-0bb1c79de3EXAMPLE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The database's table name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_TableName")]
        public System.String AthenaSourceConfig_TableName { get; set; }
        #endregion
        
        #region Parameter RDSSourceConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table in the database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RDSSourceConfig_TableName")]
        public System.String RDSSourceConfig_TableName { get; set; }
        #endregion
        
        #region Parameter RedshiftSourceConfig_TableName
        /// <summary>
        /// <para>
        /// <para>The table name of the Redshift database.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_RedshiftSourceConfig_TableName")]
        public System.String RedshiftSourceConfig_TableName { get; set; }
        #endregion
        
        #region Parameter S3SourceConfig_TemplatedPathList
        /// <summary>
        /// <para>
        /// <para>A list of templated paths to the source files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_S3SourceConfig_TemplatedPathList")]
        public System.String[] S3SourceConfig_TemplatedPathList { get; set; }
        #endregion
        
        #region Parameter AthenaSourceConfig_WorkGroupName
        /// <summary>
        /// <para>
        /// <para>The database's work group name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetricSource_AthenaSourceConfig_WorkGroupName")]
        public System.String AthenaSourceConfig_WorkGroupName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MetricSetArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.UpdateMetricSetResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.UpdateMetricSetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MetricSetArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MetricSetArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-LOMMetricSet (UpdateMetricSet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.UpdateMetricSetResponse, UpdateLOMMetricSetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DimensionFilterList != null)
            {
                context.DimensionFilterList = new List<Amazon.LookoutMetrics.Model.MetricSetDimensionFilter>(this.DimensionFilterList);
            }
            if (this.DimensionList != null)
            {
                context.DimensionList = new List<System.String>(this.DimensionList);
            }
            if (this.MetricList != null)
            {
                context.MetricList = new List<Amazon.LookoutMetrics.Model.Metric>(this.MetricList);
            }
            context.MetricSetArn = this.MetricSetArn;
            #if MODULAR
            if (this.MetricSetArn == null && ParameterWasBound(nameof(this.MetricSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter MetricSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetricSetDescription = this.MetricSetDescription;
            context.MetricSetFrequency = this.MetricSetFrequency;
            context.AppFlowConfig_FlowName = this.AppFlowConfig_FlowName;
            context.AppFlowConfig_RoleArn = this.AppFlowConfig_RoleArn;
            context.BackTestConfiguration_RunBackTestMode = this.BackTestConfiguration_RunBackTestMode;
            context.AthenaSourceConfig_DatabaseName = this.AthenaSourceConfig_DatabaseName;
            context.AthenaSourceConfig_DataCatalog = this.AthenaSourceConfig_DataCatalog;
            context.AthenaSourceConfig_RoleArn = this.AthenaSourceConfig_RoleArn;
            context.AthenaSourceConfig_S3ResultsPath = this.AthenaSourceConfig_S3ResultsPath;
            context.AthenaSourceConfig_TableName = this.AthenaSourceConfig_TableName;
            context.AthenaSourceConfig_WorkGroupName = this.AthenaSourceConfig_WorkGroupName;
            context.MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode = this.MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode;
            context.CloudWatchConfig_RoleArn = this.CloudWatchConfig_RoleArn;
            context.RDSSourceConfig_DatabaseHost = this.RDSSourceConfig_DatabaseHost;
            context.RDSSourceConfig_DatabaseName = this.RDSSourceConfig_DatabaseName;
            context.RDSSourceConfig_DatabasePort = this.RDSSourceConfig_DatabasePort;
            context.RDSSourceConfig_DBInstanceIdentifier = this.RDSSourceConfig_DBInstanceIdentifier;
            context.RDSSourceConfig_RoleArn = this.RDSSourceConfig_RoleArn;
            context.RDSSourceConfig_SecretManagerArn = this.RDSSourceConfig_SecretManagerArn;
            context.RDSSourceConfig_TableName = this.RDSSourceConfig_TableName;
            if (this.MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                context.MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList = new List<System.String>(this.MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList);
            }
            if (this.MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                context.MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList = new List<System.String>(this.MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList);
            }
            context.RedshiftSourceConfig_ClusterIdentifier = this.RedshiftSourceConfig_ClusterIdentifier;
            context.RedshiftSourceConfig_DatabaseHost = this.RedshiftSourceConfig_DatabaseHost;
            context.RedshiftSourceConfig_DatabaseName = this.RedshiftSourceConfig_DatabaseName;
            context.RedshiftSourceConfig_DatabasePort = this.RedshiftSourceConfig_DatabasePort;
            context.RedshiftSourceConfig_RoleArn = this.RedshiftSourceConfig_RoleArn;
            context.RedshiftSourceConfig_SecretManagerArn = this.RedshiftSourceConfig_SecretManagerArn;
            context.RedshiftSourceConfig_TableName = this.RedshiftSourceConfig_TableName;
            if (this.MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                context.MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList = new List<System.String>(this.MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList);
            }
            if (this.MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                context.MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList = new List<System.String>(this.MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList);
            }
            context.CsvFormatDescriptor_Charset = this.CsvFormatDescriptor_Charset;
            context.CsvFormatDescriptor_ContainsHeader = this.CsvFormatDescriptor_ContainsHeader;
            context.CsvFormatDescriptor_Delimiter = this.CsvFormatDescriptor_Delimiter;
            context.CsvFormatDescriptor_FileCompression = this.CsvFormatDescriptor_FileCompression;
            if (this.CsvFormatDescriptor_HeaderList != null)
            {
                context.CsvFormatDescriptor_HeaderList = new List<System.String>(this.CsvFormatDescriptor_HeaderList);
            }
            context.CsvFormatDescriptor_QuoteSymbol = this.CsvFormatDescriptor_QuoteSymbol;
            context.JsonFormatDescriptor_Charset = this.JsonFormatDescriptor_Charset;
            context.JsonFormatDescriptor_FileCompression = this.JsonFormatDescriptor_FileCompression;
            if (this.S3SourceConfig_HistoricalDataPathList != null)
            {
                context.S3SourceConfig_HistoricalDataPathList = new List<System.String>(this.S3SourceConfig_HistoricalDataPathList);
            }
            context.S3SourceConfig_RoleArn = this.S3SourceConfig_RoleArn;
            if (this.S3SourceConfig_TemplatedPathList != null)
            {
                context.S3SourceConfig_TemplatedPathList = new List<System.String>(this.S3SourceConfig_TemplatedPathList);
            }
            context.Offset = this.Offset;
            context.TimestampColumn_ColumnFormat = this.TimestampColumn_ColumnFormat;
            context.TimestampColumn_ColumnName = this.TimestampColumn_ColumnName;
            
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
            var request = new Amazon.LookoutMetrics.Model.UpdateMetricSetRequest();
            
            if (cmdletContext.DimensionFilterList != null)
            {
                request.DimensionFilterList = cmdletContext.DimensionFilterList;
            }
            if (cmdletContext.DimensionList != null)
            {
                request.DimensionList = cmdletContext.DimensionList;
            }
            if (cmdletContext.MetricList != null)
            {
                request.MetricList = cmdletContext.MetricList;
            }
            if (cmdletContext.MetricSetArn != null)
            {
                request.MetricSetArn = cmdletContext.MetricSetArn;
            }
            if (cmdletContext.MetricSetDescription != null)
            {
                request.MetricSetDescription = cmdletContext.MetricSetDescription;
            }
            if (cmdletContext.MetricSetFrequency != null)
            {
                request.MetricSetFrequency = cmdletContext.MetricSetFrequency;
            }
            
             // populate MetricSource
            var requestMetricSourceIsNull = true;
            request.MetricSource = new Amazon.LookoutMetrics.Model.MetricSource();
            Amazon.LookoutMetrics.Model.AppFlowConfig requestMetricSource_metricSource_AppFlowConfig = null;
            
             // populate AppFlowConfig
            var requestMetricSource_metricSource_AppFlowConfigIsNull = true;
            requestMetricSource_metricSource_AppFlowConfig = new Amazon.LookoutMetrics.Model.AppFlowConfig();
            System.String requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_FlowName = null;
            if (cmdletContext.AppFlowConfig_FlowName != null)
            {
                requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_FlowName = cmdletContext.AppFlowConfig_FlowName;
            }
            if (requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_FlowName != null)
            {
                requestMetricSource_metricSource_AppFlowConfig.FlowName = requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_FlowName;
                requestMetricSource_metricSource_AppFlowConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_RoleArn = null;
            if (cmdletContext.AppFlowConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_RoleArn = cmdletContext.AppFlowConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_AppFlowConfig.RoleArn = requestMetricSource_metricSource_AppFlowConfig_appFlowConfig_RoleArn;
                requestMetricSource_metricSource_AppFlowConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_AppFlowConfig should be set to null
            if (requestMetricSource_metricSource_AppFlowConfigIsNull)
            {
                requestMetricSource_metricSource_AppFlowConfig = null;
            }
            if (requestMetricSource_metricSource_AppFlowConfig != null)
            {
                request.MetricSource.AppFlowConfig = requestMetricSource_metricSource_AppFlowConfig;
                requestMetricSourceIsNull = false;
            }
            Amazon.LookoutMetrics.Model.CloudWatchConfig requestMetricSource_metricSource_CloudWatchConfig = null;
            
             // populate CloudWatchConfig
            var requestMetricSource_metricSource_CloudWatchConfigIsNull = true;
            requestMetricSource_metricSource_CloudWatchConfig = new Amazon.LookoutMetrics.Model.CloudWatchConfig();
            System.String requestMetricSource_metricSource_CloudWatchConfig_cloudWatchConfig_RoleArn = null;
            if (cmdletContext.CloudWatchConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_CloudWatchConfig_cloudWatchConfig_RoleArn = cmdletContext.CloudWatchConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_CloudWatchConfig_cloudWatchConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_CloudWatchConfig.RoleArn = requestMetricSource_metricSource_CloudWatchConfig_cloudWatchConfig_RoleArn;
                requestMetricSource_metricSource_CloudWatchConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.BackTestConfiguration requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration = null;
            
             // populate BackTestConfiguration
            var requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfigurationIsNull = true;
            requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration = new Amazon.LookoutMetrics.Model.BackTestConfiguration();
            System.Boolean? requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration_metricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode = null;
            if (cmdletContext.MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode != null)
            {
                requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration_metricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode = cmdletContext.MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode.Value;
            }
            if (requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration_metricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode != null)
            {
                requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration.RunBackTestMode = requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration_metricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode.Value;
                requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfigurationIsNull = false;
            }
             // determine if requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration should be set to null
            if (requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfigurationIsNull)
            {
                requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration = null;
            }
            if (requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration != null)
            {
                requestMetricSource_metricSource_CloudWatchConfig.BackTestConfiguration = requestMetricSource_metricSource_CloudWatchConfig_metricSource_CloudWatchConfig_BackTestConfiguration;
                requestMetricSource_metricSource_CloudWatchConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_CloudWatchConfig should be set to null
            if (requestMetricSource_metricSource_CloudWatchConfigIsNull)
            {
                requestMetricSource_metricSource_CloudWatchConfig = null;
            }
            if (requestMetricSource_metricSource_CloudWatchConfig != null)
            {
                request.MetricSource.CloudWatchConfig = requestMetricSource_metricSource_CloudWatchConfig;
                requestMetricSourceIsNull = false;
            }
            Amazon.LookoutMetrics.Model.S3SourceConfig requestMetricSource_metricSource_S3SourceConfig = null;
            
             // populate S3SourceConfig
            var requestMetricSource_metricSource_S3SourceConfigIsNull = true;
            requestMetricSource_metricSource_S3SourceConfig = new Amazon.LookoutMetrics.Model.S3SourceConfig();
            List<System.String> requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList = null;
            if (cmdletContext.S3SourceConfig_HistoricalDataPathList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList = cmdletContext.S3SourceConfig_HistoricalDataPathList;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig.HistoricalDataPathList = requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_HistoricalDataPathList;
                requestMetricSource_metricSource_S3SourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_RoleArn = null;
            if (cmdletContext.S3SourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_RoleArn = cmdletContext.S3SourceConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_S3SourceConfig.RoleArn = requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_RoleArn;
                requestMetricSource_metricSource_S3SourceConfigIsNull = false;
            }
            List<System.String> requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList = null;
            if (cmdletContext.S3SourceConfig_TemplatedPathList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList = cmdletContext.S3SourceConfig_TemplatedPathList;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig.TemplatedPathList = requestMetricSource_metricSource_S3SourceConfig_s3SourceConfig_TemplatedPathList;
                requestMetricSource_metricSource_S3SourceConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.FileFormatDescriptor requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor = null;
            
             // populate FileFormatDescriptor
            var requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptorIsNull = true;
            requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor = new Amazon.LookoutMetrics.Model.FileFormatDescriptor();
            Amazon.LookoutMetrics.Model.JsonFormatDescriptor requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = null;
            
             // populate JsonFormatDescriptor
            var requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = true;
            requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = new Amazon.LookoutMetrics.Model.JsonFormatDescriptor();
            System.String requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset = null;
            if (cmdletContext.JsonFormatDescriptor_Charset != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset = cmdletContext.JsonFormatDescriptor_Charset;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor.Charset = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_Charset;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.JsonFileCompression requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression = null;
            if (cmdletContext.JsonFormatDescriptor_FileCompression != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression = cmdletContext.JsonFormatDescriptor_FileCompression;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor.FileCompression = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor_jsonFormatDescriptor_FileCompression;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull = false;
            }
             // determine if requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor should be set to null
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptorIsNull)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor = null;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor.JsonFormatDescriptor = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_JsonFormatDescriptor;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.Model.CsvFormatDescriptor requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = null;
            
             // populate CsvFormatDescriptor
            var requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = true;
            requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = new Amazon.LookoutMetrics.Model.CsvFormatDescriptor();
            System.String requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset = null;
            if (cmdletContext.CsvFormatDescriptor_Charset != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset = cmdletContext.CsvFormatDescriptor_Charset;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.Charset = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Charset;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.Boolean? requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader = null;
            if (cmdletContext.CsvFormatDescriptor_ContainsHeader != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader = cmdletContext.CsvFormatDescriptor_ContainsHeader.Value;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.ContainsHeader = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_ContainsHeader.Value;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.String requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter = null;
            if (cmdletContext.CsvFormatDescriptor_Delimiter != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter = cmdletContext.CsvFormatDescriptor_Delimiter;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.Delimiter = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_Delimiter;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            Amazon.LookoutMetrics.CSVFileCompression requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression = null;
            if (cmdletContext.CsvFormatDescriptor_FileCompression != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression = cmdletContext.CsvFormatDescriptor_FileCompression;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.FileCompression = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_FileCompression;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            List<System.String> requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList = null;
            if (cmdletContext.CsvFormatDescriptor_HeaderList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList = cmdletContext.CsvFormatDescriptor_HeaderList;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.HeaderList = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_HeaderList;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
            System.String requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol = null;
            if (cmdletContext.CsvFormatDescriptor_QuoteSymbol != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol = cmdletContext.CsvFormatDescriptor_QuoteSymbol;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor.QuoteSymbol = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor_csvFormatDescriptor_QuoteSymbol;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull = false;
            }
             // determine if requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor should be set to null
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptorIsNull)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor = null;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor != null)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor.CsvFormatDescriptor = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor_metricSource_S3SourceConfig_FileFormatDescriptor_CsvFormatDescriptor;
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptorIsNull = false;
            }
             // determine if requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor should be set to null
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptorIsNull)
            {
                requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor = null;
            }
            if (requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor != null)
            {
                requestMetricSource_metricSource_S3SourceConfig.FileFormatDescriptor = requestMetricSource_metricSource_S3SourceConfig_metricSource_S3SourceConfig_FileFormatDescriptor;
                requestMetricSource_metricSource_S3SourceConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_S3SourceConfig should be set to null
            if (requestMetricSource_metricSource_S3SourceConfigIsNull)
            {
                requestMetricSource_metricSource_S3SourceConfig = null;
            }
            if (requestMetricSource_metricSource_S3SourceConfig != null)
            {
                request.MetricSource.S3SourceConfig = requestMetricSource_metricSource_S3SourceConfig;
                requestMetricSourceIsNull = false;
            }
            Amazon.LookoutMetrics.Model.AthenaSourceConfig requestMetricSource_metricSource_AthenaSourceConfig = null;
            
             // populate AthenaSourceConfig
            var requestMetricSource_metricSource_AthenaSourceConfigIsNull = true;
            requestMetricSource_metricSource_AthenaSourceConfig = new Amazon.LookoutMetrics.Model.AthenaSourceConfig();
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DatabaseName = null;
            if (cmdletContext.AthenaSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DatabaseName = cmdletContext.AthenaSourceConfig_DatabaseName;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.DatabaseName = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DatabaseName;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DataCatalog = null;
            if (cmdletContext.AthenaSourceConfig_DataCatalog != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DataCatalog = cmdletContext.AthenaSourceConfig_DataCatalog;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DataCatalog != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.DataCatalog = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_DataCatalog;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_RoleArn = null;
            if (cmdletContext.AthenaSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_RoleArn = cmdletContext.AthenaSourceConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.RoleArn = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_RoleArn;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_S3ResultsPath = null;
            if (cmdletContext.AthenaSourceConfig_S3ResultsPath != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_S3ResultsPath = cmdletContext.AthenaSourceConfig_S3ResultsPath;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_S3ResultsPath != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.S3ResultsPath = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_S3ResultsPath;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_TableName = null;
            if (cmdletContext.AthenaSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_TableName = cmdletContext.AthenaSourceConfig_TableName;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.TableName = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_TableName;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_WorkGroupName = null;
            if (cmdletContext.AthenaSourceConfig_WorkGroupName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_WorkGroupName = cmdletContext.AthenaSourceConfig_WorkGroupName;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_WorkGroupName != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.WorkGroupName = requestMetricSource_metricSource_AthenaSourceConfig_athenaSourceConfig_WorkGroupName;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.BackTestConfiguration requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration = null;
            
             // populate BackTestConfiguration
            var requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfigurationIsNull = true;
            requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration = new Amazon.LookoutMetrics.Model.BackTestConfiguration();
            System.Boolean? requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration_backTestConfiguration_RunBackTestMode = null;
            if (cmdletContext.BackTestConfiguration_RunBackTestMode != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration_backTestConfiguration_RunBackTestMode = cmdletContext.BackTestConfiguration_RunBackTestMode.Value;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration_backTestConfiguration_RunBackTestMode != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration.RunBackTestMode = requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration_backTestConfiguration_RunBackTestMode.Value;
                requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfigurationIsNull = false;
            }
             // determine if requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration should be set to null
            if (requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfigurationIsNull)
            {
                requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration = null;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration != null)
            {
                requestMetricSource_metricSource_AthenaSourceConfig.BackTestConfiguration = requestMetricSource_metricSource_AthenaSourceConfig_metricSource_AthenaSourceConfig_BackTestConfiguration;
                requestMetricSource_metricSource_AthenaSourceConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_AthenaSourceConfig should be set to null
            if (requestMetricSource_metricSource_AthenaSourceConfigIsNull)
            {
                requestMetricSource_metricSource_AthenaSourceConfig = null;
            }
            if (requestMetricSource_metricSource_AthenaSourceConfig != null)
            {
                request.MetricSource.AthenaSourceConfig = requestMetricSource_metricSource_AthenaSourceConfig;
                requestMetricSourceIsNull = false;
            }
            Amazon.LookoutMetrics.Model.RDSSourceConfig requestMetricSource_metricSource_RDSSourceConfig = null;
            
             // populate RDSSourceConfig
            var requestMetricSource_metricSource_RDSSourceConfigIsNull = true;
            requestMetricSource_metricSource_RDSSourceConfig = new Amazon.LookoutMetrics.Model.RDSSourceConfig();
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseHost = null;
            if (cmdletContext.RDSSourceConfig_DatabaseHost != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseHost = cmdletContext.RDSSourceConfig_DatabaseHost;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseHost != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.DatabaseHost = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseHost;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseName = null;
            if (cmdletContext.RDSSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseName = cmdletContext.RDSSourceConfig_DatabaseName;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.DatabaseName = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabaseName;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.Int32? requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabasePort = null;
            if (cmdletContext.RDSSourceConfig_DatabasePort != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabasePort = cmdletContext.RDSSourceConfig_DatabasePort.Value;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabasePort != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.DatabasePort = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DatabasePort.Value;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DBInstanceIdentifier = null;
            if (cmdletContext.RDSSourceConfig_DBInstanceIdentifier != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DBInstanceIdentifier = cmdletContext.RDSSourceConfig_DBInstanceIdentifier;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DBInstanceIdentifier != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.DBInstanceIdentifier = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_DBInstanceIdentifier;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_RoleArn = null;
            if (cmdletContext.RDSSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_RoleArn = cmdletContext.RDSSourceConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.RoleArn = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_RoleArn;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_SecretManagerArn = null;
            if (cmdletContext.RDSSourceConfig_SecretManagerArn != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_SecretManagerArn = cmdletContext.RDSSourceConfig_SecretManagerArn;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_SecretManagerArn != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.SecretManagerArn = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_SecretManagerArn;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_TableName = null;
            if (cmdletContext.RDSSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_TableName = cmdletContext.RDSSourceConfig_TableName;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.TableName = requestMetricSource_metricSource_RDSSourceConfig_rDSSourceConfig_TableName;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.VpcConfiguration requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfigurationIsNull = true;
            requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration = new Amazon.LookoutMetrics.Model.VpcConfiguration();
            List<System.String> requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList = null;
            if (cmdletContext.MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList = cmdletContext.MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration.SecurityGroupIdList = requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList;
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfigurationIsNull = false;
            }
            List<System.String> requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList = null;
            if (cmdletContext.MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList = cmdletContext.MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration.SubnetIdList = requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration_metricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList;
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfigurationIsNull = false;
            }
             // determine if requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration should be set to null
            if (requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfigurationIsNull)
            {
                requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration = null;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration != null)
            {
                requestMetricSource_metricSource_RDSSourceConfig.VpcConfiguration = requestMetricSource_metricSource_RDSSourceConfig_metricSource_RDSSourceConfig_VpcConfiguration;
                requestMetricSource_metricSource_RDSSourceConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_RDSSourceConfig should be set to null
            if (requestMetricSource_metricSource_RDSSourceConfigIsNull)
            {
                requestMetricSource_metricSource_RDSSourceConfig = null;
            }
            if (requestMetricSource_metricSource_RDSSourceConfig != null)
            {
                request.MetricSource.RDSSourceConfig = requestMetricSource_metricSource_RDSSourceConfig;
                requestMetricSourceIsNull = false;
            }
            Amazon.LookoutMetrics.Model.RedshiftSourceConfig requestMetricSource_metricSource_RedshiftSourceConfig = null;
            
             // populate RedshiftSourceConfig
            var requestMetricSource_metricSource_RedshiftSourceConfigIsNull = true;
            requestMetricSource_metricSource_RedshiftSourceConfig = new Amazon.LookoutMetrics.Model.RedshiftSourceConfig();
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_ClusterIdentifier = null;
            if (cmdletContext.RedshiftSourceConfig_ClusterIdentifier != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_ClusterIdentifier = cmdletContext.RedshiftSourceConfig_ClusterIdentifier;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_ClusterIdentifier != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.ClusterIdentifier = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_ClusterIdentifier;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseHost = null;
            if (cmdletContext.RedshiftSourceConfig_DatabaseHost != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseHost = cmdletContext.RedshiftSourceConfig_DatabaseHost;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseHost != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.DatabaseHost = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseHost;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseName = null;
            if (cmdletContext.RedshiftSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseName = cmdletContext.RedshiftSourceConfig_DatabaseName;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseName != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.DatabaseName = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabaseName;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.Int32? requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabasePort = null;
            if (cmdletContext.RedshiftSourceConfig_DatabasePort != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabasePort = cmdletContext.RedshiftSourceConfig_DatabasePort.Value;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabasePort != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.DatabasePort = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_DatabasePort.Value;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_RoleArn = null;
            if (cmdletContext.RedshiftSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_RoleArn = cmdletContext.RedshiftSourceConfig_RoleArn;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_RoleArn != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.RoleArn = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_RoleArn;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_SecretManagerArn = null;
            if (cmdletContext.RedshiftSourceConfig_SecretManagerArn != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_SecretManagerArn = cmdletContext.RedshiftSourceConfig_SecretManagerArn;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_SecretManagerArn != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.SecretManagerArn = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_SecretManagerArn;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            System.String requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_TableName = null;
            if (cmdletContext.RedshiftSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_TableName = cmdletContext.RedshiftSourceConfig_TableName;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_TableName != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.TableName = requestMetricSource_metricSource_RedshiftSourceConfig_redshiftSourceConfig_TableName;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
            Amazon.LookoutMetrics.Model.VpcConfiguration requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfigurationIsNull = true;
            requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration = new Amazon.LookoutMetrics.Model.VpcConfiguration();
            List<System.String> requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList = null;
            if (cmdletContext.MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList = cmdletContext.MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration.SecurityGroupIdList = requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList;
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfigurationIsNull = false;
            }
            List<System.String> requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList = null;
            if (cmdletContext.MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList = cmdletContext.MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration.SubnetIdList = requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration_metricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList;
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfigurationIsNull = false;
            }
             // determine if requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration should be set to null
            if (requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfigurationIsNull)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration = null;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration != null)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig.VpcConfiguration = requestMetricSource_metricSource_RedshiftSourceConfig_metricSource_RedshiftSourceConfig_VpcConfiguration;
                requestMetricSource_metricSource_RedshiftSourceConfigIsNull = false;
            }
             // determine if requestMetricSource_metricSource_RedshiftSourceConfig should be set to null
            if (requestMetricSource_metricSource_RedshiftSourceConfigIsNull)
            {
                requestMetricSource_metricSource_RedshiftSourceConfig = null;
            }
            if (requestMetricSource_metricSource_RedshiftSourceConfig != null)
            {
                request.MetricSource.RedshiftSourceConfig = requestMetricSource_metricSource_RedshiftSourceConfig;
                requestMetricSourceIsNull = false;
            }
             // determine if request.MetricSource should be set to null
            if (requestMetricSourceIsNull)
            {
                request.MetricSource = null;
            }
            if (cmdletContext.Offset != null)
            {
                request.Offset = cmdletContext.Offset.Value;
            }
            
             // populate TimestampColumn
            var requestTimestampColumnIsNull = true;
            request.TimestampColumn = new Amazon.LookoutMetrics.Model.TimestampColumn();
            System.String requestTimestampColumn_timestampColumn_ColumnFormat = null;
            if (cmdletContext.TimestampColumn_ColumnFormat != null)
            {
                requestTimestampColumn_timestampColumn_ColumnFormat = cmdletContext.TimestampColumn_ColumnFormat;
            }
            if (requestTimestampColumn_timestampColumn_ColumnFormat != null)
            {
                request.TimestampColumn.ColumnFormat = requestTimestampColumn_timestampColumn_ColumnFormat;
                requestTimestampColumnIsNull = false;
            }
            System.String requestTimestampColumn_timestampColumn_ColumnName = null;
            if (cmdletContext.TimestampColumn_ColumnName != null)
            {
                requestTimestampColumn_timestampColumn_ColumnName = cmdletContext.TimestampColumn_ColumnName;
            }
            if (requestTimestampColumn_timestampColumn_ColumnName != null)
            {
                request.TimestampColumn.ColumnName = requestTimestampColumn_timestampColumn_ColumnName;
                requestTimestampColumnIsNull = false;
            }
             // determine if request.TimestampColumn should be set to null
            if (requestTimestampColumnIsNull)
            {
                request.TimestampColumn = null;
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
        
        private Amazon.LookoutMetrics.Model.UpdateMetricSetResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.UpdateMetricSetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "UpdateMetricSet");
            try
            {
                #if DESKTOP
                return client.UpdateMetricSet(request);
                #elif CORECLR
                return client.UpdateMetricSetAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.LookoutMetrics.Model.MetricSetDimensionFilter> DimensionFilterList { get; set; }
            public List<System.String> DimensionList { get; set; }
            public List<Amazon.LookoutMetrics.Model.Metric> MetricList { get; set; }
            public System.String MetricSetArn { get; set; }
            public System.String MetricSetDescription { get; set; }
            public Amazon.LookoutMetrics.Frequency MetricSetFrequency { get; set; }
            public System.String AppFlowConfig_FlowName { get; set; }
            public System.String AppFlowConfig_RoleArn { get; set; }
            public System.Boolean? BackTestConfiguration_RunBackTestMode { get; set; }
            public System.String AthenaSourceConfig_DatabaseName { get; set; }
            public System.String AthenaSourceConfig_DataCatalog { get; set; }
            public System.String AthenaSourceConfig_RoleArn { get; set; }
            public System.String AthenaSourceConfig_S3ResultsPath { get; set; }
            public System.String AthenaSourceConfig_TableName { get; set; }
            public System.String AthenaSourceConfig_WorkGroupName { get; set; }
            public System.Boolean? MetricSource_CloudWatchConfig_BackTestConfiguration_RunBackTestMode { get; set; }
            public System.String CloudWatchConfig_RoleArn { get; set; }
            public System.String RDSSourceConfig_DatabaseHost { get; set; }
            public System.String RDSSourceConfig_DatabaseName { get; set; }
            public System.Int32? RDSSourceConfig_DatabasePort { get; set; }
            public System.String RDSSourceConfig_DBInstanceIdentifier { get; set; }
            public System.String RDSSourceConfig_RoleArn { get; set; }
            public System.String RDSSourceConfig_SecretManagerArn { get; set; }
            public System.String RDSSourceConfig_TableName { get; set; }
            public List<System.String> MetricSource_RDSSourceConfig_VpcConfiguration_SecurityGroupIdList { get; set; }
            public List<System.String> MetricSource_RDSSourceConfig_VpcConfiguration_SubnetIdList { get; set; }
            public System.String RedshiftSourceConfig_ClusterIdentifier { get; set; }
            public System.String RedshiftSourceConfig_DatabaseHost { get; set; }
            public System.String RedshiftSourceConfig_DatabaseName { get; set; }
            public System.Int32? RedshiftSourceConfig_DatabasePort { get; set; }
            public System.String RedshiftSourceConfig_RoleArn { get; set; }
            public System.String RedshiftSourceConfig_SecretManagerArn { get; set; }
            public System.String RedshiftSourceConfig_TableName { get; set; }
            public List<System.String> MetricSource_RedshiftSourceConfig_VpcConfiguration_SecurityGroupIdList { get; set; }
            public List<System.String> MetricSource_RedshiftSourceConfig_VpcConfiguration_SubnetIdList { get; set; }
            public System.String CsvFormatDescriptor_Charset { get; set; }
            public System.Boolean? CsvFormatDescriptor_ContainsHeader { get; set; }
            public System.String CsvFormatDescriptor_Delimiter { get; set; }
            public Amazon.LookoutMetrics.CSVFileCompression CsvFormatDescriptor_FileCompression { get; set; }
            public List<System.String> CsvFormatDescriptor_HeaderList { get; set; }
            public System.String CsvFormatDescriptor_QuoteSymbol { get; set; }
            public System.String JsonFormatDescriptor_Charset { get; set; }
            public Amazon.LookoutMetrics.JsonFileCompression JsonFormatDescriptor_FileCompression { get; set; }
            public List<System.String> S3SourceConfig_HistoricalDataPathList { get; set; }
            public System.String S3SourceConfig_RoleArn { get; set; }
            public List<System.String> S3SourceConfig_TemplatedPathList { get; set; }
            public System.Int32? Offset { get; set; }
            public System.String TimestampColumn_ColumnFormat { get; set; }
            public System.String TimestampColumn_ColumnName { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.UpdateMetricSetResponse, UpdateLOMMetricSetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MetricSetArn;
        }
        
    }
}
