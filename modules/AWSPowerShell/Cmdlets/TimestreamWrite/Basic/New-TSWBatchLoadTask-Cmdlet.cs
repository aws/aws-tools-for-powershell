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
using Amazon.TimestreamWrite;
using Amazon.TimestreamWrite.Model;

namespace Amazon.PowerShell.Cmdlets.TSW
{
    /// <summary>
    /// Creates a new Timestream batch load task. A batch load task processes data from a
    /// CSV source in an S3 location and writes to a Timestream table. A mapping from source
    /// to target is defined in a batch load task. Errors and events are written to a report
    /// at an S3 location. For the report, if the KMS key is not specified, the report will
    /// be encrypted with an S3 managed key when <c>SSE_S3</c> is the option. Otherwise an
    /// error is thrown. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#aws-managed-cmk">Amazon
    /// Web Services managed keys</a>. <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/ts-limits.html">Service
    /// quotas apply</a>. For details, see <a href="https://docs.aws.amazon.com/timestream/latest/developerguide/code-samples.create-batch-load.html">code
    /// sample</a>.
    /// </summary>
    [Cmdlet("New", "TSWBatchLoadTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Timestream Write CreateBatchLoadTask API operation.", Operation = new[] {"CreateBatchLoadTask"}, SelectReturnType = typeof(Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse))]
    [AWSCmdletOutput("System.String or Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTSWBatchLoadTaskCmdlet : AmazonTimestreamWriteClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataModelS3Configuration_BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModelS3Configuration_BucketName")]
        public System.String DataModelS3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter DataSourceS3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para>The bucket name of the customer S3 bucket.</para>
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
        [Alias("DataSourceConfiguration_DataSourceS3Configuration_BucketName")]
        public System.String DataSourceS3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter ReportS3Configuration_BucketName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportConfiguration_ReportS3Configuration_BucketName")]
        public System.String ReportS3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter CsvConfiguration_ColumnSeparator
        /// <summary>
        /// <para>
        /// <para>Column separator can be one of comma (','), pipe ('|), semicolon (';'), tab('/t'),
        /// or blank space (' '). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_CsvConfiguration_ColumnSeparator")]
        public System.String CsvConfiguration_ColumnSeparator { get; set; }
        #endregion
        
        #region Parameter DataSourceConfiguration_DataFormat
        /// <summary>
        /// <para>
        /// <para>This is currently CSV.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.TimestreamWrite.BatchLoadDataFormat")]
        public Amazon.TimestreamWrite.BatchLoadDataFormat DataSourceConfiguration_DataFormat { get; set; }
        #endregion
        
        #region Parameter DataModel_DimensionMapping
        /// <summary>
        /// <para>
        /// <para>Source to target mappings for dimensions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_DimensionMappings")]
        public Amazon.TimestreamWrite.Model.DimensionMapping[] DataModel_DimensionMapping { get; set; }
        #endregion
        
        #region Parameter ReportS3Configuration_EncryptionOption
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportConfiguration_ReportS3Configuration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.TimestreamWrite.S3EncryptionOption")]
        public Amazon.TimestreamWrite.S3EncryptionOption ReportS3Configuration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter CsvConfiguration_EscapeChar
        /// <summary>
        /// <para>
        /// <para>Escape character can be one of </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_CsvConfiguration_EscapeChar")]
        public System.String CsvConfiguration_EscapeChar { get; set; }
        #endregion
        
        #region Parameter ReportS3Configuration_KmsKeyId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportConfiguration_ReportS3Configuration_KmsKeyId")]
        public System.String ReportS3Configuration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter DataModel_MeasureNameColumn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_MeasureNameColumn")]
        public System.String DataModel_MeasureNameColumn { get; set; }
        #endregion
        
        #region Parameter DataModel_MixedMeasureMapping
        /// <summary>
        /// <para>
        /// <para>Source to target mappings for measures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_MixedMeasureMappings")]
        public Amazon.TimestreamWrite.Model.MixedMeasureMapping[] DataModel_MixedMeasureMapping { get; set; }
        #endregion
        
        #region Parameter MultiMeasureMappings_MultiMeasureAttributeMapping
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_MultiMeasureMappings_MultiMeasureAttributeMappings")]
        public Amazon.TimestreamWrite.Model.MultiMeasureAttributeMapping[] MultiMeasureMappings_MultiMeasureAttributeMapping { get; set; }
        #endregion
        
        #region Parameter CsvConfiguration_NullValue
        /// <summary>
        /// <para>
        /// <para>Can be blank space (' ').</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_CsvConfiguration_NullValue")]
        public System.String CsvConfiguration_NullValue { get; set; }
        #endregion
        
        #region Parameter DataModelS3Configuration_ObjectKey
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModelS3Configuration_ObjectKey")]
        public System.String DataModelS3Configuration_ObjectKey { get; set; }
        #endregion
        
        #region Parameter DataSourceS3Configuration_ObjectKeyPrefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_DataSourceS3Configuration_ObjectKeyPrefix")]
        public System.String DataSourceS3Configuration_ObjectKeyPrefix { get; set; }
        #endregion
        
        #region Parameter ReportS3Configuration_ObjectKeyPrefix
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReportConfiguration_ReportS3Configuration_ObjectKeyPrefix")]
        public System.String ReportS3Configuration_ObjectKeyPrefix { get; set; }
        #endregion
        
        #region Parameter CsvConfiguration_QuoteChar
        /// <summary>
        /// <para>
        /// <para>Can be single quote (') or double quote (").</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_CsvConfiguration_QuoteChar")]
        public System.String CsvConfiguration_QuoteChar { get; set; }
        #endregion
        
        #region Parameter RecordVersion
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? RecordVersion { get; set; }
        #endregion
        
        #region Parameter TargetDatabaseName
        /// <summary>
        /// <para>
        /// <para>Target Timestream database for a batch load task.</para>
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
        public System.String TargetDatabaseName { get; set; }
        #endregion
        
        #region Parameter MultiMeasureMappings_TargetMultiMeasureName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_MultiMeasureMappings_TargetMultiMeasureName")]
        public System.String MultiMeasureMappings_TargetMultiMeasureName { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>Target Timestream table for a batch load task.</para>
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
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter DataModel_TimeColumn
        /// <summary>
        /// <para>
        /// <para>Source column to be mapped to time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_TimeColumn")]
        public System.String DataModel_TimeColumn { get; set; }
        #endregion
        
        #region Parameter DataModel_TimeUnit
        /// <summary>
        /// <para>
        /// <para> The granularity of the timestamp unit. It indicates if the time value is in seconds,
        /// milliseconds, nanoseconds, or other supported values. Default is <c>MILLISECONDS</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataModelConfiguration_DataModel_TimeUnit")]
        [AWSConstantClassSource("Amazon.TimestreamWrite.TimeUnit")]
        public Amazon.TimestreamWrite.TimeUnit DataModel_TimeUnit { get; set; }
        #endregion
        
        #region Parameter CsvConfiguration_TrimWhiteSpace
        /// <summary>
        /// <para>
        /// <para>Specifies to trim leading and trailing white space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceConfiguration_CsvConfiguration_TrimWhiteSpace")]
        public System.Boolean? CsvConfiguration_TrimWhiteSpace { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TaskId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse).
        /// Specifying the name of a property of type Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TaskId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TSWBatchLoadTask (CreateBatchLoadTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse, NewTSWBatchLoadTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.DataModel_DimensionMapping != null)
            {
                context.DataModel_DimensionMapping = new List<Amazon.TimestreamWrite.Model.DimensionMapping>(this.DataModel_DimensionMapping);
            }
            context.DataModel_MeasureNameColumn = this.DataModel_MeasureNameColumn;
            if (this.DataModel_MixedMeasureMapping != null)
            {
                context.DataModel_MixedMeasureMapping = new List<Amazon.TimestreamWrite.Model.MixedMeasureMapping>(this.DataModel_MixedMeasureMapping);
            }
            if (this.MultiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                context.MultiMeasureMappings_MultiMeasureAttributeMapping = new List<Amazon.TimestreamWrite.Model.MultiMeasureAttributeMapping>(this.MultiMeasureMappings_MultiMeasureAttributeMapping);
            }
            context.MultiMeasureMappings_TargetMultiMeasureName = this.MultiMeasureMappings_TargetMultiMeasureName;
            context.DataModel_TimeColumn = this.DataModel_TimeColumn;
            context.DataModel_TimeUnit = this.DataModel_TimeUnit;
            context.DataModelS3Configuration_BucketName = this.DataModelS3Configuration_BucketName;
            context.DataModelS3Configuration_ObjectKey = this.DataModelS3Configuration_ObjectKey;
            context.CsvConfiguration_ColumnSeparator = this.CsvConfiguration_ColumnSeparator;
            context.CsvConfiguration_EscapeChar = this.CsvConfiguration_EscapeChar;
            context.CsvConfiguration_NullValue = this.CsvConfiguration_NullValue;
            context.CsvConfiguration_QuoteChar = this.CsvConfiguration_QuoteChar;
            context.CsvConfiguration_TrimWhiteSpace = this.CsvConfiguration_TrimWhiteSpace;
            context.DataSourceConfiguration_DataFormat = this.DataSourceConfiguration_DataFormat;
            #if MODULAR
            if (this.DataSourceConfiguration_DataFormat == null && ParameterWasBound(nameof(this.DataSourceConfiguration_DataFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceConfiguration_DataFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceS3Configuration_BucketName = this.DataSourceS3Configuration_BucketName;
            #if MODULAR
            if (this.DataSourceS3Configuration_BucketName == null && ParameterWasBound(nameof(this.DataSourceS3Configuration_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceS3Configuration_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceS3Configuration_ObjectKeyPrefix = this.DataSourceS3Configuration_ObjectKeyPrefix;
            context.RecordVersion = this.RecordVersion;
            context.ReportS3Configuration_BucketName = this.ReportS3Configuration_BucketName;
            context.ReportS3Configuration_EncryptionOption = this.ReportS3Configuration_EncryptionOption;
            context.ReportS3Configuration_KmsKeyId = this.ReportS3Configuration_KmsKeyId;
            context.ReportS3Configuration_ObjectKeyPrefix = this.ReportS3Configuration_ObjectKeyPrefix;
            context.TargetDatabaseName = this.TargetDatabaseName;
            #if MODULAR
            if (this.TargetDatabaseName == null && ParameterWasBound(nameof(this.TargetDatabaseName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDatabaseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetTableName = this.TargetTableName;
            #if MODULAR
            if (this.TargetTableName == null && ParameterWasBound(nameof(this.TargetTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TimestreamWrite.Model.CreateBatchLoadTaskRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataModelConfiguration
            var requestDataModelConfigurationIsNull = true;
            request.DataModelConfiguration = new Amazon.TimestreamWrite.Model.DataModelConfiguration();
            Amazon.TimestreamWrite.Model.DataModelS3Configuration requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration = null;
            
             // populate DataModelS3Configuration
            var requestDataModelConfiguration_dataModelConfiguration_DataModelS3ConfigurationIsNull = true;
            requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration = new Amazon.TimestreamWrite.Model.DataModelS3Configuration();
            System.String requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_BucketName = null;
            if (cmdletContext.DataModelS3Configuration_BucketName != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_BucketName = cmdletContext.DataModelS3Configuration_BucketName;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_BucketName != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration.BucketName = requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_BucketName;
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3ConfigurationIsNull = false;
            }
            System.String requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_ObjectKey = null;
            if (cmdletContext.DataModelS3Configuration_ObjectKey != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_ObjectKey = cmdletContext.DataModelS3Configuration_ObjectKey;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_ObjectKey != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration.ObjectKey = requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration_dataModelS3Configuration_ObjectKey;
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3ConfigurationIsNull = false;
            }
             // determine if requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration should be set to null
            if (requestDataModelConfiguration_dataModelConfiguration_DataModelS3ConfigurationIsNull)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration = null;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration != null)
            {
                request.DataModelConfiguration.DataModelS3Configuration = requestDataModelConfiguration_dataModelConfiguration_DataModelS3Configuration;
                requestDataModelConfigurationIsNull = false;
            }
            Amazon.TimestreamWrite.Model.DataModel requestDataModelConfiguration_dataModelConfiguration_DataModel = null;
            
             // populate DataModel
            var requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = true;
            requestDataModelConfiguration_dataModelConfiguration_DataModel = new Amazon.TimestreamWrite.Model.DataModel();
            List<Amazon.TimestreamWrite.Model.DimensionMapping> requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_DimensionMapping = null;
            if (cmdletContext.DataModel_DimensionMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_DimensionMapping = cmdletContext.DataModel_DimensionMapping;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_DimensionMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.DimensionMappings = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_DimensionMapping;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
            System.String requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MeasureNameColumn = null;
            if (cmdletContext.DataModel_MeasureNameColumn != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MeasureNameColumn = cmdletContext.DataModel_MeasureNameColumn;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MeasureNameColumn != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.MeasureNameColumn = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MeasureNameColumn;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
            List<Amazon.TimestreamWrite.Model.MixedMeasureMapping> requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MixedMeasureMapping = null;
            if (cmdletContext.DataModel_MixedMeasureMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MixedMeasureMapping = cmdletContext.DataModel_MixedMeasureMapping;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MixedMeasureMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.MixedMeasureMappings = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_MixedMeasureMapping;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
            System.String requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeColumn = null;
            if (cmdletContext.DataModel_TimeColumn != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeColumn = cmdletContext.DataModel_TimeColumn;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeColumn != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.TimeColumn = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeColumn;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
            Amazon.TimestreamWrite.TimeUnit requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeUnit = null;
            if (cmdletContext.DataModel_TimeUnit != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeUnit = cmdletContext.DataModel_TimeUnit;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeUnit != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.TimeUnit = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModel_TimeUnit;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
            Amazon.TimestreamWrite.Model.MultiMeasureMappings requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings = null;
            
             // populate MultiMeasureMappings
            var requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappingsIsNull = true;
            requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings = new Amazon.TimestreamWrite.Model.MultiMeasureMappings();
            List<Amazon.TimestreamWrite.Model.MultiMeasureAttributeMapping> requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping = null;
            if (cmdletContext.MultiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping = cmdletContext.MultiMeasureMappings_MultiMeasureAttributeMapping;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings.MultiMeasureAttributeMappings = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping;
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappingsIsNull = false;
            }
            System.String requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName = null;
            if (cmdletContext.MultiMeasureMappings_TargetMultiMeasureName != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName = cmdletContext.MultiMeasureMappings_TargetMultiMeasureName;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings.TargetMultiMeasureName = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName;
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappingsIsNull = false;
            }
             // determine if requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings should be set to null
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappingsIsNull)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings = null;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings != null)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel.MultiMeasureMappings = requestDataModelConfiguration_dataModelConfiguration_DataModel_dataModelConfiguration_DataModel_MultiMeasureMappings;
                requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull = false;
            }
             // determine if requestDataModelConfiguration_dataModelConfiguration_DataModel should be set to null
            if (requestDataModelConfiguration_dataModelConfiguration_DataModelIsNull)
            {
                requestDataModelConfiguration_dataModelConfiguration_DataModel = null;
            }
            if (requestDataModelConfiguration_dataModelConfiguration_DataModel != null)
            {
                request.DataModelConfiguration.DataModel = requestDataModelConfiguration_dataModelConfiguration_DataModel;
                requestDataModelConfigurationIsNull = false;
            }
             // determine if request.DataModelConfiguration should be set to null
            if (requestDataModelConfigurationIsNull)
            {
                request.DataModelConfiguration = null;
            }
            
             // populate DataSourceConfiguration
            var requestDataSourceConfigurationIsNull = true;
            request.DataSourceConfiguration = new Amazon.TimestreamWrite.Model.DataSourceConfiguration();
            Amazon.TimestreamWrite.BatchLoadDataFormat requestDataSourceConfiguration_dataSourceConfiguration_DataFormat = null;
            if (cmdletContext.DataSourceConfiguration_DataFormat != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataFormat = cmdletContext.DataSourceConfiguration_DataFormat;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_DataFormat != null)
            {
                request.DataSourceConfiguration.DataFormat = requestDataSourceConfiguration_dataSourceConfiguration_DataFormat;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.TimestreamWrite.Model.DataSourceS3Configuration requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration = null;
            
             // populate DataSourceS3Configuration
            var requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3ConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration = new Amazon.TimestreamWrite.Model.DataSourceS3Configuration();
            System.String requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_BucketName = null;
            if (cmdletContext.DataSourceS3Configuration_BucketName != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_BucketName = cmdletContext.DataSourceS3Configuration_BucketName;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_BucketName != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration.BucketName = requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_BucketName;
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3ConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_ObjectKeyPrefix = null;
            if (cmdletContext.DataSourceS3Configuration_ObjectKeyPrefix != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_ObjectKeyPrefix = cmdletContext.DataSourceS3Configuration_ObjectKeyPrefix;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_ObjectKeyPrefix != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration.ObjectKeyPrefix = requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration_dataSourceS3Configuration_ObjectKeyPrefix;
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3ConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3ConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration != null)
            {
                request.DataSourceConfiguration.DataSourceS3Configuration = requestDataSourceConfiguration_dataSourceConfiguration_DataSourceS3Configuration;
                requestDataSourceConfigurationIsNull = false;
            }
            Amazon.TimestreamWrite.Model.CsvConfiguration requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration = null;
            
             // populate CsvConfiguration
            var requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = true;
            requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration = new Amazon.TimestreamWrite.Model.CsvConfiguration();
            System.String requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_ColumnSeparator = null;
            if (cmdletContext.CsvConfiguration_ColumnSeparator != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_ColumnSeparator = cmdletContext.CsvConfiguration_ColumnSeparator;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_ColumnSeparator != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration.ColumnSeparator = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_ColumnSeparator;
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_EscapeChar = null;
            if (cmdletContext.CsvConfiguration_EscapeChar != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_EscapeChar = cmdletContext.CsvConfiguration_EscapeChar;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_EscapeChar != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration.EscapeChar = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_EscapeChar;
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_NullValue = null;
            if (cmdletContext.CsvConfiguration_NullValue != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_NullValue = cmdletContext.CsvConfiguration_NullValue;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_NullValue != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration.NullValue = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_NullValue;
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = false;
            }
            System.String requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_QuoteChar = null;
            if (cmdletContext.CsvConfiguration_QuoteChar != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_QuoteChar = cmdletContext.CsvConfiguration_QuoteChar;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_QuoteChar != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration.QuoteChar = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_QuoteChar;
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = false;
            }
            System.Boolean? requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_TrimWhiteSpace = null;
            if (cmdletContext.CsvConfiguration_TrimWhiteSpace != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_TrimWhiteSpace = cmdletContext.CsvConfiguration_TrimWhiteSpace.Value;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_TrimWhiteSpace != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration.TrimWhiteSpace = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration_csvConfiguration_TrimWhiteSpace.Value;
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull = false;
            }
             // determine if requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration should be set to null
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfigurationIsNull)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration = null;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration != null)
            {
                request.DataSourceConfiguration.CsvConfiguration = requestDataSourceConfiguration_dataSourceConfiguration_CsvConfiguration;
                requestDataSourceConfigurationIsNull = false;
            }
             // determine if request.DataSourceConfiguration should be set to null
            if (requestDataSourceConfigurationIsNull)
            {
                request.DataSourceConfiguration = null;
            }
            if (cmdletContext.RecordVersion != null)
            {
                request.RecordVersion = cmdletContext.RecordVersion.Value;
            }
            
             // populate ReportConfiguration
            var requestReportConfigurationIsNull = true;
            request.ReportConfiguration = new Amazon.TimestreamWrite.Model.ReportConfiguration();
            Amazon.TimestreamWrite.Model.ReportS3Configuration requestReportConfiguration_reportConfiguration_ReportS3Configuration = null;
            
             // populate ReportS3Configuration
            var requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull = true;
            requestReportConfiguration_reportConfiguration_ReportS3Configuration = new Amazon.TimestreamWrite.Model.ReportS3Configuration();
            System.String requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_BucketName = null;
            if (cmdletContext.ReportS3Configuration_BucketName != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_BucketName = cmdletContext.ReportS3Configuration_BucketName;
            }
            if (requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_BucketName != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration.BucketName = requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_BucketName;
                requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull = false;
            }
            Amazon.TimestreamWrite.S3EncryptionOption requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_EncryptionOption = null;
            if (cmdletContext.ReportS3Configuration_EncryptionOption != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_EncryptionOption = cmdletContext.ReportS3Configuration_EncryptionOption;
            }
            if (requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_EncryptionOption != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration.EncryptionOption = requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_EncryptionOption;
                requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull = false;
            }
            System.String requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_KmsKeyId = null;
            if (cmdletContext.ReportS3Configuration_KmsKeyId != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_KmsKeyId = cmdletContext.ReportS3Configuration_KmsKeyId;
            }
            if (requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_KmsKeyId != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration.KmsKeyId = requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_KmsKeyId;
                requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull = false;
            }
            System.String requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_ObjectKeyPrefix = null;
            if (cmdletContext.ReportS3Configuration_ObjectKeyPrefix != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_ObjectKeyPrefix = cmdletContext.ReportS3Configuration_ObjectKeyPrefix;
            }
            if (requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_ObjectKeyPrefix != null)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration.ObjectKeyPrefix = requestReportConfiguration_reportConfiguration_ReportS3Configuration_reportS3Configuration_ObjectKeyPrefix;
                requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull = false;
            }
             // determine if requestReportConfiguration_reportConfiguration_ReportS3Configuration should be set to null
            if (requestReportConfiguration_reportConfiguration_ReportS3ConfigurationIsNull)
            {
                requestReportConfiguration_reportConfiguration_ReportS3Configuration = null;
            }
            if (requestReportConfiguration_reportConfiguration_ReportS3Configuration != null)
            {
                request.ReportConfiguration.ReportS3Configuration = requestReportConfiguration_reportConfiguration_ReportS3Configuration;
                requestReportConfigurationIsNull = false;
            }
             // determine if request.ReportConfiguration should be set to null
            if (requestReportConfigurationIsNull)
            {
                request.ReportConfiguration = null;
            }
            if (cmdletContext.TargetDatabaseName != null)
            {
                request.TargetDatabaseName = cmdletContext.TargetDatabaseName;
            }
            if (cmdletContext.TargetTableName != null)
            {
                request.TargetTableName = cmdletContext.TargetTableName;
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
        
        private Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse CallAWSServiceOperation(IAmazonTimestreamWrite client, Amazon.TimestreamWrite.Model.CreateBatchLoadTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Write", "CreateBatchLoadTask");
            try
            {
                #if DESKTOP
                return client.CreateBatchLoadTask(request);
                #elif CORECLR
                return client.CreateBatchLoadTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.TimestreamWrite.Model.DimensionMapping> DataModel_DimensionMapping { get; set; }
            public System.String DataModel_MeasureNameColumn { get; set; }
            public List<Amazon.TimestreamWrite.Model.MixedMeasureMapping> DataModel_MixedMeasureMapping { get; set; }
            public List<Amazon.TimestreamWrite.Model.MultiMeasureAttributeMapping> MultiMeasureMappings_MultiMeasureAttributeMapping { get; set; }
            public System.String MultiMeasureMappings_TargetMultiMeasureName { get; set; }
            public System.String DataModel_TimeColumn { get; set; }
            public Amazon.TimestreamWrite.TimeUnit DataModel_TimeUnit { get; set; }
            public System.String DataModelS3Configuration_BucketName { get; set; }
            public System.String DataModelS3Configuration_ObjectKey { get; set; }
            public System.String CsvConfiguration_ColumnSeparator { get; set; }
            public System.String CsvConfiguration_EscapeChar { get; set; }
            public System.String CsvConfiguration_NullValue { get; set; }
            public System.String CsvConfiguration_QuoteChar { get; set; }
            public System.Boolean? CsvConfiguration_TrimWhiteSpace { get; set; }
            public Amazon.TimestreamWrite.BatchLoadDataFormat DataSourceConfiguration_DataFormat { get; set; }
            public System.String DataSourceS3Configuration_BucketName { get; set; }
            public System.String DataSourceS3Configuration_ObjectKeyPrefix { get; set; }
            public System.Int64? RecordVersion { get; set; }
            public System.String ReportS3Configuration_BucketName { get; set; }
            public Amazon.TimestreamWrite.S3EncryptionOption ReportS3Configuration_EncryptionOption { get; set; }
            public System.String ReportS3Configuration_KmsKeyId { get; set; }
            public System.String ReportS3Configuration_ObjectKeyPrefix { get; set; }
            public System.String TargetDatabaseName { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Func<Amazon.TimestreamWrite.Model.CreateBatchLoadTaskResponse, NewTSWBatchLoadTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TaskId;
        }
        
    }
}
