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
using Amazon.TimestreamQuery;
using Amazon.TimestreamQuery.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.TSQ
{
    /// <summary>
    /// Create a scheduled query that will be run on your behalf at the configured schedule.
    /// Timestream assumes the execution role provided as part of the <c>ScheduledQueryExecutionRoleArn</c>
    /// parameter to run the query. You can use the <c>NotificationConfiguration</c> parameter
    /// to configure notification for your scheduled query operations.
    /// </summary>
    [Cmdlet("New", "TSQScheduledQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Timestream Query CreateScheduledQuery API operation.", Operation = new[] {"CreateScheduledQuery"}, SelectReturnType = typeof(Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse))]
    [AWSCmdletOutput("System.String or Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTSQScheduledQueryCmdlet : AmazonTimestreamQueryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Configuration_BucketName
        /// <summary>
        /// <para>
        /// <para> Name of the S3 bucket under which error reports will be created.</para>
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
        [Alias("ErrorReportConfiguration_S3Configuration_BucketName")]
        public System.String S3Configuration_BucketName { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_DatabaseName
        /// <summary>
        /// <para>
        /// <para>Name of Timestream database to which the query result will be written.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_DatabaseName")]
        public System.String TimestreamConfiguration_DatabaseName { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_DimensionMapping
        /// <summary>
        /// <para>
        /// <para> This is to allow mapping column(s) from the query result to the dimension in the
        /// destination table. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_DimensionMappings")]
        public Amazon.TimestreamQuery.Model.DimensionMapping[] TimestreamConfiguration_DimensionMapping { get; set; }
        #endregion
        
        #region Parameter S3Configuration_EncryptionOption
        /// <summary>
        /// <para>
        /// <para> Encryption at rest options for the error reports. If no encryption option is specified,
        /// Timestream will choose SSE_S3 as default. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ErrorReportConfiguration_S3Configuration_EncryptionOption")]
        [AWSConstantClassSource("Amazon.TimestreamQuery.S3EncryptionOption")]
        public Amazon.TimestreamQuery.S3EncryptionOption S3Configuration_EncryptionOption { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon KMS key used to encrypt the scheduled query resource, at-rest. If the Amazon
        /// KMS key is not specified, the scheduled query resource will be encrypted with a Timestream
        /// owned Amazon KMS key. To specify a KMS key, use the key ID, key ARN, alias name, or
        /// alias ARN. When using an alias name, prefix the name with <i>alias/</i></para><para>If ErrorReportConfiguration uses <c>SSE_KMS</c> as encryption type, the same KmsKeyId
        /// is used to encrypt the error report at rest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_MeasureNameColumn
        /// <summary>
        /// <para>
        /// <para>Name of the measure column.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_MeasureNameColumn")]
        public System.String TimestreamConfiguration_MeasureNameColumn { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_MixedMeasureMapping
        /// <summary>
        /// <para>
        /// <para>Specifies how to map measures to multi-measure records.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_MixedMeasureMappings")]
        public Amazon.TimestreamQuery.Model.MixedMeasureMapping[] TimestreamConfiguration_MixedMeasureMapping { get; set; }
        #endregion
        
        #region Parameter MultiMeasureMappings_MultiMeasureAttributeMapping
        /// <summary>
        /// <para>
        /// <para>Required. Attribute mappings to be used for mapping query results to ingest data for
        /// multi-measure attributes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_MultiMeasureMappings_MultiMeasureAttributeMappings")]
        public Amazon.TimestreamQuery.Model.MultiMeasureAttributeMapping[] MultiMeasureMappings_MultiMeasureAttributeMapping { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of the scheduled query.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3Configuration_ObjectKeyPrefix
        /// <summary>
        /// <para>
        /// <para> Prefix for the error report key. Timestream by default adds the following prefix
        /// to the error report path. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ErrorReportConfiguration_S3Configuration_ObjectKeyPrefix")]
        public System.String S3Configuration_ObjectKeyPrefix { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to run. Parameter names can be specified in the query string <c>@</c>
        /// character followed by an identifier. The named Parameter <c>@scheduled_runtime</c>
        /// is reserved and can be used in the query to get the time at which the query is scheduled
        /// to run.</para><para>The timestamp calculated according to the ScheduleConfiguration parameter, will be
        /// the value of <c>@scheduled_runtime</c> paramater for each query run. For example,
        /// consider an instance of a scheduled query executing on 2021-12-01 00:00:00. For this
        /// instance, the <c>@scheduled_runtime</c> parameter is initialized to the timestamp
        /// 2021-12-01 00:00:00 when invoking the query.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter ScheduledQueryExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN for the IAM role that Timestream will assume when running the scheduled query.
        /// </para>
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
        public System.String ScheduledQueryExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleConfiguration_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>An expression that denotes when to trigger the scheduled query run. This can be a
        /// cron expression or a rate expression. </para>
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
        public System.String ScheduleConfiguration_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_TableName
        /// <summary>
        /// <para>
        /// <para>Name of Timestream table that the query result will be written to. The table should
        /// be within the same database that is provided in Timestream configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_TableName")]
        public System.String TimestreamConfiguration_TableName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to label the scheduled query.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.TimestreamQuery.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter MultiMeasureMappings_TargetMultiMeasureName
        /// <summary>
        /// <para>
        /// <para>The name of the target multi-measure name in the derived table. This input is required
        /// when measureNameColumn is not provided. If MeasureNameColumn is provided, then value
        /// from that column will be used as multi-measure name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_MultiMeasureMappings_TargetMultiMeasureName")]
        public System.String MultiMeasureMappings_TargetMultiMeasureName { get; set; }
        #endregion
        
        #region Parameter TimestreamConfiguration_TimeColumn
        /// <summary>
        /// <para>
        /// <para>Column from query result that should be used as the time column in destination table.
        /// Column type for this should be TIMESTAMP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetConfiguration_TimestreamConfiguration_TimeColumn")]
        public System.String TimestreamConfiguration_TimeColumn { get; set; }
        #endregion
        
        #region Parameter SnsConfiguration_TopicArn
        /// <summary>
        /// <para>
        /// <para>SNS topic ARN that the scheduled query status notifications will be sent to.</para>
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
        [Alias("NotificationConfiguration_SnsConfiguration_TopicArn")]
        public System.String SnsConfiguration_TopicArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Using a ClientToken makes the call to CreateScheduledQuery idempotent, in other words,
        /// making the same request repeatedly will produce the same result. Making multiple identical
        /// CreateScheduledQuery requests has the same effect as making a single request. </para><ul><li><para> If CreateScheduledQuery is called without a <c>ClientToken</c>, the Query SDK generates
        /// a <c>ClientToken</c> on your behalf.</para></li><li><para> After 8 hours, any request with the same <c>ClientToken</c> is treated as a new request.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse).
        /// Specifying the name of a property of type Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TSQScheduledQuery (CreateScheduledQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse, NewTSQScheduledQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.S3Configuration_BucketName = this.S3Configuration_BucketName;
            #if MODULAR
            if (this.S3Configuration_BucketName == null && ParameterWasBound(nameof(this.S3Configuration_BucketName)))
            {
                WriteWarning("You are passing $null as a value for parameter S3Configuration_BucketName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3Configuration_EncryptionOption = this.S3Configuration_EncryptionOption;
            context.S3Configuration_ObjectKeyPrefix = this.S3Configuration_ObjectKeyPrefix;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnsConfiguration_TopicArn = this.SnsConfiguration_TopicArn;
            #if MODULAR
            if (this.SnsConfiguration_TopicArn == null && ParameterWasBound(nameof(this.SnsConfiguration_TopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SnsConfiguration_TopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleConfiguration_ScheduleExpression = this.ScheduleConfiguration_ScheduleExpression;
            #if MODULAR
            if (this.ScheduleConfiguration_ScheduleExpression == null && ParameterWasBound(nameof(this.ScheduleConfiguration_ScheduleExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleConfiguration_ScheduleExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledQueryExecutionRoleArn = this.ScheduledQueryExecutionRoleArn;
            #if MODULAR
            if (this.ScheduledQueryExecutionRoleArn == null && ParameterWasBound(nameof(this.ScheduledQueryExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledQueryExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.TimestreamQuery.Model.Tag>(this.Tag);
            }
            context.TimestreamConfiguration_DatabaseName = this.TimestreamConfiguration_DatabaseName;
            if (this.TimestreamConfiguration_DimensionMapping != null)
            {
                context.TimestreamConfiguration_DimensionMapping = new List<Amazon.TimestreamQuery.Model.DimensionMapping>(this.TimestreamConfiguration_DimensionMapping);
            }
            context.TimestreamConfiguration_MeasureNameColumn = this.TimestreamConfiguration_MeasureNameColumn;
            if (this.TimestreamConfiguration_MixedMeasureMapping != null)
            {
                context.TimestreamConfiguration_MixedMeasureMapping = new List<Amazon.TimestreamQuery.Model.MixedMeasureMapping>(this.TimestreamConfiguration_MixedMeasureMapping);
            }
            if (this.MultiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                context.MultiMeasureMappings_MultiMeasureAttributeMapping = new List<Amazon.TimestreamQuery.Model.MultiMeasureAttributeMapping>(this.MultiMeasureMappings_MultiMeasureAttributeMapping);
            }
            context.MultiMeasureMappings_TargetMultiMeasureName = this.MultiMeasureMappings_TargetMultiMeasureName;
            context.TimestreamConfiguration_TableName = this.TimestreamConfiguration_TableName;
            context.TimestreamConfiguration_TimeColumn = this.TimestreamConfiguration_TimeColumn;
            
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
            var request = new Amazon.TimestreamQuery.Model.CreateScheduledQueryRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ErrorReportConfiguration
            var requestErrorReportConfigurationIsNull = true;
            request.ErrorReportConfiguration = new Amazon.TimestreamQuery.Model.ErrorReportConfiguration();
            Amazon.TimestreamQuery.Model.S3Configuration requestErrorReportConfiguration_errorReportConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestErrorReportConfiguration_errorReportConfiguration_S3ConfigurationIsNull = true;
            requestErrorReportConfiguration_errorReportConfiguration_S3Configuration = new Amazon.TimestreamQuery.Model.S3Configuration();
            System.String requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_BucketName = null;
            if (cmdletContext.S3Configuration_BucketName != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_BucketName = cmdletContext.S3Configuration_BucketName;
            }
            if (requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_BucketName != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration.BucketName = requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_BucketName;
                requestErrorReportConfiguration_errorReportConfiguration_S3ConfigurationIsNull = false;
            }
            Amazon.TimestreamQuery.S3EncryptionOption requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_EncryptionOption = null;
            if (cmdletContext.S3Configuration_EncryptionOption != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_EncryptionOption = cmdletContext.S3Configuration_EncryptionOption;
            }
            if (requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_EncryptionOption != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration.EncryptionOption = requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_EncryptionOption;
                requestErrorReportConfiguration_errorReportConfiguration_S3ConfigurationIsNull = false;
            }
            System.String requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_ObjectKeyPrefix = null;
            if (cmdletContext.S3Configuration_ObjectKeyPrefix != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_ObjectKeyPrefix = cmdletContext.S3Configuration_ObjectKeyPrefix;
            }
            if (requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_ObjectKeyPrefix != null)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration.ObjectKeyPrefix = requestErrorReportConfiguration_errorReportConfiguration_S3Configuration_s3Configuration_ObjectKeyPrefix;
                requestErrorReportConfiguration_errorReportConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestErrorReportConfiguration_errorReportConfiguration_S3Configuration should be set to null
            if (requestErrorReportConfiguration_errorReportConfiguration_S3ConfigurationIsNull)
            {
                requestErrorReportConfiguration_errorReportConfiguration_S3Configuration = null;
            }
            if (requestErrorReportConfiguration_errorReportConfiguration_S3Configuration != null)
            {
                request.ErrorReportConfiguration.S3Configuration = requestErrorReportConfiguration_errorReportConfiguration_S3Configuration;
                requestErrorReportConfigurationIsNull = false;
            }
             // determine if request.ErrorReportConfiguration should be set to null
            if (requestErrorReportConfigurationIsNull)
            {
                request.ErrorReportConfiguration = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NotificationConfiguration
            var requestNotificationConfigurationIsNull = true;
            request.NotificationConfiguration = new Amazon.TimestreamQuery.Model.NotificationConfiguration();
            Amazon.TimestreamQuery.Model.SnsConfiguration requestNotificationConfiguration_notificationConfiguration_SnsConfiguration = null;
            
             // populate SnsConfiguration
            var requestNotificationConfiguration_notificationConfiguration_SnsConfigurationIsNull = true;
            requestNotificationConfiguration_notificationConfiguration_SnsConfiguration = new Amazon.TimestreamQuery.Model.SnsConfiguration();
            System.String requestNotificationConfiguration_notificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn = null;
            if (cmdletContext.SnsConfiguration_TopicArn != null)
            {
                requestNotificationConfiguration_notificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn = cmdletContext.SnsConfiguration_TopicArn;
            }
            if (requestNotificationConfiguration_notificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn != null)
            {
                requestNotificationConfiguration_notificationConfiguration_SnsConfiguration.TopicArn = requestNotificationConfiguration_notificationConfiguration_SnsConfiguration_snsConfiguration_TopicArn;
                requestNotificationConfiguration_notificationConfiguration_SnsConfigurationIsNull = false;
            }
             // determine if requestNotificationConfiguration_notificationConfiguration_SnsConfiguration should be set to null
            if (requestNotificationConfiguration_notificationConfiguration_SnsConfigurationIsNull)
            {
                requestNotificationConfiguration_notificationConfiguration_SnsConfiguration = null;
            }
            if (requestNotificationConfiguration_notificationConfiguration_SnsConfiguration != null)
            {
                request.NotificationConfiguration.SnsConfiguration = requestNotificationConfiguration_notificationConfiguration_SnsConfiguration;
                requestNotificationConfigurationIsNull = false;
            }
             // determine if request.NotificationConfiguration should be set to null
            if (requestNotificationConfigurationIsNull)
            {
                request.NotificationConfiguration = null;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            
             // populate ScheduleConfiguration
            var requestScheduleConfigurationIsNull = true;
            request.ScheduleConfiguration = new Amazon.TimestreamQuery.Model.ScheduleConfiguration();
            System.String requestScheduleConfiguration_scheduleConfiguration_ScheduleExpression = null;
            if (cmdletContext.ScheduleConfiguration_ScheduleExpression != null)
            {
                requestScheduleConfiguration_scheduleConfiguration_ScheduleExpression = cmdletContext.ScheduleConfiguration_ScheduleExpression;
            }
            if (requestScheduleConfiguration_scheduleConfiguration_ScheduleExpression != null)
            {
                request.ScheduleConfiguration.ScheduleExpression = requestScheduleConfiguration_scheduleConfiguration_ScheduleExpression;
                requestScheduleConfigurationIsNull = false;
            }
             // determine if request.ScheduleConfiguration should be set to null
            if (requestScheduleConfigurationIsNull)
            {
                request.ScheduleConfiguration = null;
            }
            if (cmdletContext.ScheduledQueryExecutionRoleArn != null)
            {
                request.ScheduledQueryExecutionRoleArn = cmdletContext.ScheduledQueryExecutionRoleArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TargetConfiguration
            var requestTargetConfigurationIsNull = true;
            request.TargetConfiguration = new Amazon.TimestreamQuery.Model.TargetConfiguration();
            Amazon.TimestreamQuery.Model.TimestreamConfiguration requestTargetConfiguration_targetConfiguration_TimestreamConfiguration = null;
            
             // populate TimestreamConfiguration
            var requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = true;
            requestTargetConfiguration_targetConfiguration_TimestreamConfiguration = new Amazon.TimestreamQuery.Model.TimestreamConfiguration();
            System.String requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DatabaseName = null;
            if (cmdletContext.TimestreamConfiguration_DatabaseName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DatabaseName = cmdletContext.TimestreamConfiguration_DatabaseName;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DatabaseName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.DatabaseName = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DatabaseName;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            List<Amazon.TimestreamQuery.Model.DimensionMapping> requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DimensionMapping = null;
            if (cmdletContext.TimestreamConfiguration_DimensionMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DimensionMapping = cmdletContext.TimestreamConfiguration_DimensionMapping;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DimensionMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.DimensionMappings = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_DimensionMapping;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MeasureNameColumn = null;
            if (cmdletContext.TimestreamConfiguration_MeasureNameColumn != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MeasureNameColumn = cmdletContext.TimestreamConfiguration_MeasureNameColumn;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MeasureNameColumn != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.MeasureNameColumn = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MeasureNameColumn;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            List<Amazon.TimestreamQuery.Model.MixedMeasureMapping> requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MixedMeasureMapping = null;
            if (cmdletContext.TimestreamConfiguration_MixedMeasureMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MixedMeasureMapping = cmdletContext.TimestreamConfiguration_MixedMeasureMapping;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MixedMeasureMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.MixedMeasureMappings = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_MixedMeasureMapping;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TableName = null;
            if (cmdletContext.TimestreamConfiguration_TableName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TableName = cmdletContext.TimestreamConfiguration_TableName;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TableName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.TableName = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TableName;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TimeColumn = null;
            if (cmdletContext.TimestreamConfiguration_TimeColumn != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TimeColumn = cmdletContext.TimestreamConfiguration_TimeColumn;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TimeColumn != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.TimeColumn = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_timestreamConfiguration_TimeColumn;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
            Amazon.TimestreamQuery.Model.MultiMeasureMappings requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings = null;
            
             // populate MultiMeasureMappings
            var requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappingsIsNull = true;
            requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings = new Amazon.TimestreamQuery.Model.MultiMeasureMappings();
            List<Amazon.TimestreamQuery.Model.MultiMeasureAttributeMapping> requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping = null;
            if (cmdletContext.MultiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping = cmdletContext.MultiMeasureMappings_MultiMeasureAttributeMapping;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings.MultiMeasureAttributeMappings = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_MultiMeasureAttributeMapping;
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappingsIsNull = false;
            }
            System.String requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName = null;
            if (cmdletContext.MultiMeasureMappings_TargetMultiMeasureName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName = cmdletContext.MultiMeasureMappings_TargetMultiMeasureName;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings.TargetMultiMeasureName = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings_multiMeasureMappings_TargetMultiMeasureName;
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappingsIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings should be set to null
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappingsIsNull)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings = null;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings != null)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration.MultiMeasureMappings = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration_targetConfiguration_TimestreamConfiguration_MultiMeasureMappings;
                requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull = false;
            }
             // determine if requestTargetConfiguration_targetConfiguration_TimestreamConfiguration should be set to null
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfigurationIsNull)
            {
                requestTargetConfiguration_targetConfiguration_TimestreamConfiguration = null;
            }
            if (requestTargetConfiguration_targetConfiguration_TimestreamConfiguration != null)
            {
                request.TargetConfiguration.TimestreamConfiguration = requestTargetConfiguration_targetConfiguration_TimestreamConfiguration;
                requestTargetConfigurationIsNull = false;
            }
             // determine if request.TargetConfiguration should be set to null
            if (requestTargetConfigurationIsNull)
            {
                request.TargetConfiguration = null;
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
        
        private Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse CallAWSServiceOperation(IAmazonTimestreamQuery client, Amazon.TimestreamQuery.Model.CreateScheduledQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Timestream Query", "CreateScheduledQuery");
            try
            {
                return client.CreateScheduledQueryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String S3Configuration_BucketName { get; set; }
            public Amazon.TimestreamQuery.S3EncryptionOption S3Configuration_EncryptionOption { get; set; }
            public System.String S3Configuration_ObjectKeyPrefix { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String SnsConfiguration_TopicArn { get; set; }
            public System.String QueryString { get; set; }
            public System.String ScheduleConfiguration_ScheduleExpression { get; set; }
            public System.String ScheduledQueryExecutionRoleArn { get; set; }
            public List<Amazon.TimestreamQuery.Model.Tag> Tag { get; set; }
            public System.String TimestreamConfiguration_DatabaseName { get; set; }
            public List<Amazon.TimestreamQuery.Model.DimensionMapping> TimestreamConfiguration_DimensionMapping { get; set; }
            public System.String TimestreamConfiguration_MeasureNameColumn { get; set; }
            public List<Amazon.TimestreamQuery.Model.MixedMeasureMapping> TimestreamConfiguration_MixedMeasureMapping { get; set; }
            public List<Amazon.TimestreamQuery.Model.MultiMeasureAttributeMapping> MultiMeasureMappings_MultiMeasureAttributeMapping { get; set; }
            public System.String MultiMeasureMappings_TargetMultiMeasureName { get; set; }
            public System.String TimestreamConfiguration_TableName { get; set; }
            public System.String TimestreamConfiguration_TimeColumn { get; set; }
            public System.Func<Amazon.TimestreamQuery.Model.CreateScheduledQueryResponse, NewTSQScheduledQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
